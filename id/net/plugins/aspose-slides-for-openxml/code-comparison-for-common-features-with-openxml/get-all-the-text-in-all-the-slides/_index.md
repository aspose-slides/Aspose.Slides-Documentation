---
title: Dapatkan semua teks di semua slide
type: docs
weight: 100
url: /id/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
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

    // Buka presentasi sebagai read-only.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Lewatkan presentasi ke metode CountSlides berikutnya

        // dan kembalikan jumlah slide.

        return CountSlides(presentationDocument);

    }

}

// Hitung slide dalam presentasi.

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

        // Dapatkan ID hubungan slide pertama.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Dapatkan bagian slide dari ID hubungan.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Buat objek StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Dapatkan teks dalam slide:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

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

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Instansiasi kelas PresentationEx yang mewakili PPTX
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }

}

public static string GetSlideText(string docName, int index)

{
    string sldText = "";
    //Instansiasi kelas PresentationEx yang mewakili PPTX
    using (Presentation pres = new Presentation(docName))
    {
        //Akses slide
        ISlide sld = pres.Slides[index];
        //Iterasi melalui shape untuk menemukan placeholder
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {
                //dapatkan teks setiap placeholder
                sldText += ((AutoShape)shp).TextFrame.Text;
            }
    }
    return sldText;
}

``` 
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)