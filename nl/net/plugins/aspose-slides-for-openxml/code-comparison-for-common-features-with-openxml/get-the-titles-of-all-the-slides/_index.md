---
title: De titels van alle dia's ophalen
type: docs
weight: 120
url: /nl/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Een lijst ophalen met de titels van alle dia's in de presentatie.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Open de presentatie in alleen-lezen modus.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Een lijst ophalen met de titels van alle dia's in de presentatie.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Haal een PresentationPart-object op uit het PresentationDocument-object.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Haal een Presentation-object op uit het PresentationPart-object.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Haal de titel van elke dia op in de volgorde van de dia's.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Haal de titel van de dia op.

                string title = GetSlideTitle(slidePart);

                // Een lege titel kan ook worden toegevoegd.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Haal de titeltekenreeks van de dia op.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Declareer een paragraafseparator.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Zoek alle titelvormen.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Haal de tekst op in elke alinea van deze vorm.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Voeg een regeleinde toe.

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

// Bepaalt of de vorm een titelvorm is.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Elke titelvorm.

            case PlaceholderValues.Title:

            // Een gecentreerde titel.

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

    // Controleer op een null documentobject.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Haal het presentatie‑onderdeel van het document op.

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

        // Haal de relationship‑ID van de eerste dia op.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Haal het slide‑onderdeel op via de relationship‑ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Maak een StringBuilder‑object aan.

        StringBuilder paragraphText = new StringBuilder();

        // Haal de binnenste tekst van de dia op:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)