---
title: Dapatkan semua teks dalam slide
type: docs
weight: 110
url: /id/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Dapatkan semua teks dalam slide.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Buka presentasi dalam mode baca-saja.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Lewatkan presentasi dan indeks slide

        // ke metode GetAllTextInSlide berikutnya, dan

        // kemudian kembalikan array string yang dikembalikannya. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verifikasi bahwa dokumen presentasi ada.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verifikasi bahwa indeks slide tidak di luar jangkauan.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Dapatkan bagian presentasi dari dokumen presentasi.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verifikasi bahwa bagian presentasi dan presentasi ada.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Dapatkan objek Presentation dari bagian presentasi.

        Presentation presentation = presentationPart.Presentation;

        // Verifikasi bahwa daftar ID slide ada.

        if (presentation.SlideIdList != null)

        {

            // Dapatkan koleksi ID slide dari daftar ID slide.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Jika ID slide berada dalam jangkauan...

            if (slideIndex < slideIds.Count)

            {

                // Dapatkan ID relasi slide.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Dapatkan bagian slide yang ditentukan dari ID relasi.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Lewatkan bagian slide ke metode berikutnya, dan

                // kemudian kembalikan array string yang metode itu

                // mengembalikan ke metode sebelumnya.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Jika tidak, kembalikan null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verifikasi bahwa bagian slide ada.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Buat linked list baru berisi string.

    LinkedList<string> texts = new LinkedList<string>();

    // Jika slide ada...

    if (slidePart.Slide != null)

    {

        // Iterasi semua paragraf dalam slide.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Buat StringBuilder baru.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iterasi baris-baris paragraf.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Tambahkan setiap baris ke baris sebelumnya.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Tambahkan setiap paragraf ke linked list.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Kembalikan array string.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Dapatkan semua teks dalam slide.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Buat linked list baru berisi string.

List<string> texts = new List<string>();

// Instansiasi kelas PresentationEx yang mewakili PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    // Akses slide

    ISlide sld = pres.Slides[slideIndex];

    // Iterasi bentuk-bentuk untuk menemukan placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // dapatkan teks setiap placeholder

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Kembalikan array string.

return texts;

}

``` 
## **Unduh Contoh Kode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)