---
title: Dapatkan judul semua slide
type: docs
weight: 120
url: /id/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Dapatkan daftar judul semua slide dalam presentasi.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Buka presentasi dalam mode hanya-baca.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Dapatkan daftar judul semua slide dalam presentasi.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Dapatkan objek PresentationPart dari objek PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Dapatkan objek Presentation dari objek PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Dapatkan judul setiap slide dalam urutan slide.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Dapatkan judul slide.

                string title = GetSlideTitle(slidePart);

                // Judul kosong juga dapat ditambahkan.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Dapatkan string judul slide.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Deklarasikan pemisah paragraf.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Temukan semua shape judul.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Dapatkan teks di setiap paragraf dalam shape ini.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Tambahkan pemisah baris.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Menentukan apakah shape merupakan shape judul.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Setiap shape judul.

            case PlaceholderValues.Title:

            // Judul terpusat.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Buka presentasi dalam mode hanya-baca.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Kirim presentasi ke metode CountSlides berikutnya

        // dan kembalikan jumlah slide.

        return CountSlides(presentationDocument);

    }

}

// Hitung jumlah slide dalam presentasi.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Periksa apakah objek dokumen null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Dapatkan bagian presentasi dari dokumen.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Dapatkan jumlah slide dari SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Kembalikan jumlah slide ke metode sebelumnya.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Dapatkan ID hubungan (relationship ID) slide pertama.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Dapatkan bagian slide dari relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Buat objek StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Dapatkan teks internal slide:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)