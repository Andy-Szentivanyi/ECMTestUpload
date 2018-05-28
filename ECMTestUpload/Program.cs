using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECMTestUpload
{
    class Program
    {
        static void Main( string [ ] args )
        {
            UploadDocument( );
        }

        public static void UploadDocument( )
        {
            NameValueCollection qstring = new NameValueCollection( );
            //qstring.Add( "Title" , "7502" );
            //qstring.Add( "Description" , "integration document" );
            //qstring.Add( "ReleaseDate" , "2017-09-13" );
            //qstring.Add( "DocDataAsOfDate" , "2017-09-13" );
            //qstring.Add( "ExpiryDate" , "2021-09-13" );
            //qstring.Add( "FileName" , "Test.pdf" );
            //qstring.Add( "Version" , "1" );
            //qstring.Add( "ClientId" , "7502" );
            //qstring.Add( "ClientName" , "Andy Szentivanyi" );


            //qstring.Add( "CUSIP" , "46625H100" );
            //qstring.Add( "DocumentName" , "CONFIRM" );
            //qstring.Add( "TradeDate" , "2017-08-11" );
            //qstring.Add( "TradeNumber" , "81005" );

            //qstring.Add( "VisibleToClient" , "Y" );
            //qstring.Add( "VisibletoIA" , "Y" );
            //qstring.Add( "RestrictedDocument" , "N" );            

            //qstring.Add( "Account" , "4003J40J" );
            //qstring.Add( "Author" , "Batch" );
            //qstring.Add( "LOB" , "PCD" );

            //qstring.Add( "Branch" , "JE" );
            //qstring.Add( "BuySell" , "SELL" );

            //qstring.Add( "Language" , "E" );
            //qstring.Add( "Currency" , "USD" );




            string clientno = "100";





            qstring.Add( "Title" , clientno );
            qstring.Add( "Description" , "1" );
            qstring.Add( "Author" , "2" );
            qstring.Add( "Release Date" , "2017-11-05" );
            qstring.Add( "Expiry Date" , "2027-11-05" );
            qstring.Add( "ECMFileName" , "api.pdf" );
            //qstring.Add( "Version" , "1" );
            //qstring.Add( "File Size" , "1" );


            qstring.Add( "Account" , "10" );
            qstring.Add( "Account" , "20" );
            qstring.Add( "Account" , "30" );


            qstring.Add( "Branch" , "1" );
            qstring.Add( "BuySell" , "1" );
            qstring.Add( "ClientId" , clientno );
            qstring.Add( "ClientName" , "1" );
            qstring.Add( "ClientName1" , "1" );
            qstring.Add( "ClientName2" , "1" );
            qstring.Add( "ClientName3" , "1" );
            qstring.Add( "ClientName4" , "1" );
            qstring.Add( "ClientName5" , "1" );
            qstring.Add( "ClientName6" , "1" );
            qstring.Add( "ClientName7" , "1" );
            qstring.Add( "ClientName8" , "1" );
            qstring.Add( "ClientName9" , "1" );
            qstring.Add( "ClosedClientIDDate" , "1" );
            qstring.Add( "Currency" , "1" );
            qstring.Add( "CUSIP" , "1" );
            qstring.Add( "DeleteStatus" , "1" );
            qstring.Add( "DocDataAsOfDate" , "1" );
            qstring.Add( "DocumentExpiryDate" , "1" );
            qstring.Add( "DocumentName" , "1" );
            qstring.Add( "DUPFlag" , "1" );
            qstring.Add( "HoldMailFlag" , "1" );
            qstring.Add( "IANumber" , "1" );
            qstring.Add( "Language" , "1" );
            qstring.Add( "LegalHold" , "1" );
            qstring.Add( "Market" , "1" );
            qstring.Add( "Net" , "1" );
            qstring.Add( "Notes" , "1" );
            qstring.Add( "NumberOfPages" , "1" );
            qstring.Add( "OrderNumber" , "1" );
            qstring.Add( "Price" , "1" );
            qstring.Add( "PublishDate" , "1" );
            qstring.Add( "Quantity" , "1" );
            qstring.Add( "RestrictedDocument" , "1" );
            qstring.Add( "SecurityName" , "This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name,This is going to be a very long security name" );
            qstring.Add( "SettlementDate" , "1" );
            qstring.Add( "StatementEdelivery" , "1" );
            qstring.Add( "SynDocID" , "1" );
            qstring.Add( "SynDocPublished" , "1" );
            qstring.Add( "SynDocVerIsCur" , "1" );
            qstring.Add( "SynFileName" , "1" );
            qstring.Add( "SynReferenceAccountID" , "1" );
            qstring.Add( "TradeDate" , "1" );
            qstring.Add( "TradeNumber" , "1" );
            qstring.Add( "UploadDate" , "1" );
            qstring.Add( "VisibleToClient" , "1" );
            qstring.Add( "VisibletoIA" , "1" );
            qstring.Add( "LOB" , "PCD" );
            qstring.Add( "Andy" , "Andy" );





            HttpUploadFile( "https://ecm.richardsongmp.com/RGMPECM/api/checkIn?bin=150917&passwd=ssss18nc&doctype=TestConfirms&mid=" + clientno ,

                //@"C:\Users\aszentivanyi\Documents\test pdf.pdf" , 

                "test.pdf" , "application/pdf" , qstring

                );

        }






        public static void HttpUploadFile( string url , string paramName , string contentType , NameValueCollection nvc )
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString( "x" );
            byte [ ] boundarybytes = System.Text.Encoding.ASCII.GetBytes( "\r\n--" + boundary + "\r\n" );

            HttpWebRequest wr = ( HttpWebRequest ) WebRequest.Create( url );
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream( );

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach ( string key in nvc.Keys )
            {
                rs.Write( boundarybytes , 0 , boundarybytes.Length );
                string formitem = string.Format( formdataTemplate , key , nvc [ key ] );
                byte [ ] formitembytes = System.Text.Encoding.UTF8.GetBytes( formitem );
                rs.Write( formitembytes , 0 , formitembytes.Length );
            }
            rs.Write( boundarybytes , 0 , boundarybytes.Length );

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format( headerTemplate , paramName , "Test PDF.pdf" , contentType );
            byte [ ] headerbytes = System.Text.Encoding.UTF8.GetBytes( header );
            rs.Write( headerbytes , 0 , headerbytes.Length );


            int bytesRead = Properties.Resources.Test_PDF.Length;

            rs.Write( Properties.Resources.Test_PDF , 0 , bytesRead );


            byte [ ] trailer = System.Text.Encoding.ASCII.GetBytes( "\r\n--" + boundary + "--\r\n" );
            rs.Write( trailer , 0 , trailer.Length );
            rs.Close( );

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse( );
                Stream stream2 = wresp.GetResponseStream( );
                StreamReader reader2 = new StreamReader( stream2 );
                string result = string.Format( "File uploaded, server response is: {0}" , reader2.ReadToEnd( ) );
            }
            catch ( Exception ex )
            {

                if ( wresp != null )
                {
                    wresp.Close( );
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }


    }
}
