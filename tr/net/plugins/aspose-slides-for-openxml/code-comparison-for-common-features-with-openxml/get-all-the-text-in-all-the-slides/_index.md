---
title: Tüm slaytlardaki tüm metni alın
type: docs
weight: 100
url: /tr/net/get-all-the-text-in-all-the-slides/
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

    // Sunumu yalnızca okuma modunda aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu bir sonraki CountSlides yöntemine ilet

        // ve slayt sayısını döndür.

        return CountSlides(presentationDocument);

    }

}

// Sunumdaki slaytları say.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Belge nesnesinin null olup olmadığını kontrol et.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Belgenin sunum kısmını al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts'tan slayt sayısını al.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Slayt sayısını önceki metoda döndür.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // İlk slaydın ilişki kimliğini al.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // İlişki kimliğinden slayt parçasını al.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Bir StringBuilder nesnesi oluştur.

        StringBuilder paragraphText = new StringBuilder();

        // Slaytın iç metnini al:

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

    //PPTX'i temsil eden PresentationEx sınıfını oluştur

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //PPTX'i temsil eden PresentationEx sınıfını oluştur

    using (Presentation pres = new Presentation(docName))

    {

        //Slayta eriş

        ISlide sld = pres.Slides[index];

        //Yer tutucuyu bulmak için şekillerde döngü yap

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //her yer tutucunun metnini al

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)