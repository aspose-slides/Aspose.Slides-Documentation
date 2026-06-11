---
title: Hämta all text i alla bilder
type: docs
weight: 100
url: /sv/net/get-all-the-text-in-all-the-slides/
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

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen till nästa CountSlides‑metod

        // och returnera bildantalet.

        return CountSlides(presentationDocument);

    }

}

// Räkna antalet bilder i presentationen.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kontrollera om dokumentobjektet är null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hämta presentationsdelen av dokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta bildantalet från SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Returnera bildantalet till föregående metod.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Hämta relations‑ID för den första bilden.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Hämta bilddelen från relations‑ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Bygg ett StringBuilder‑objekt.

        StringBuilder paragraphText = new StringBuilder();

        // Hämta bildens interna text:

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

    //Instansiera PresentationEx-klassen som representerar PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instansiera PresentationEx-klassen som representerar PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Hämta bilden

        ISlide sld = pres.Slides[index];

        //Iterera genom former för att hitta platshållaren

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //hämta texten för varje platshållare

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)