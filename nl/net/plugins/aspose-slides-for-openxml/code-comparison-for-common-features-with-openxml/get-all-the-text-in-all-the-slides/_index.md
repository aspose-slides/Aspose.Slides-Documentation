---
title: Alle tekst in alle dia's ophalen
type: docs
weight: 100
url: /nl/net/get-all-the-text-in-all-the-slides/
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

    // Open de presentatie als alleen-lezen.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geef de presentatie door aan de volgende CountSlides-methode
        // en retourneer het aantal dia's.
        return CountSlides(presentationDocument);

    }

}

// Tel het aantal dia's in de presentatie.
public static int CountSlides(PresentationDocument presentationDocument)

{

    // Controleer of het documentobject null is.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Haal het presentatiedeel van het document op.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Haal het aantal dia's op uit de SlideParts.
    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourneer het aantal dia's naar de vorige methode.
    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Haal de relatie-ID van de eerste dia op.
        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Haal het dia-deel op via de relatie-ID.
        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Maak een StringBuilder-object aan.
        StringBuilder paragraphText = new StringBuilder();

        // Haal de interne tekst van de dia op:
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

    //Instantieer PresentationEx-klasse die PPTX vertegenwoordigt
    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instantieer PresentationEx-klasse die PPTX vertegenwoordigt
    using (Presentation pres = new Presentation(docName))

    {

        //Toegang tot de dia
        ISlide sld = pres.Slides[index];

        //Itereer door de vormen om de placeholder te vinden
        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //haal de tekst van elke placeholder op
                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

```
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)