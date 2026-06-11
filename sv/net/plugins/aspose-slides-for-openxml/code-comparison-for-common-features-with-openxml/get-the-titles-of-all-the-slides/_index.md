---
title: Hämta titlarna på alla bilderna
type: docs
weight: 120
url: /sv/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Hämta en lista med titlarna på alla bilderna i presentationen.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Hämta en lista med titlarna på alla bilderna i presentationen.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Hämta ett PresentationPart-objekt från PresentationDocument-objektet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Hämta ett Presentation-objekt från PresentationPart-objektet.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Hämta titeln på varje bild i bildordningen.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Hämta bildens titel.

                string title = GetSlideTitle(slidePart);

                // En tom titel kan också läggas till.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Hämta titelsträngen för bilden.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Deklarera en styckeavgränsare.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Hitta alla titelformer.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Hämta texten i varje stycke i denna form.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Lägg till en radbrytning.

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

// Avgör om formen är en titelform.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Vilken som helst titelform.

            case PlaceholderValues.Title:

            // En centrerad titel.

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

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen till nästa CountSlides-metod

        // och returnera bildantalet.

        return CountSlides(presentationDocument);

    }

}

// Räkna bilderna i presentationen.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kontrollera om dokumentobjektet är null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hämta presentationdelen av dokumentet.

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

        // Hämta relations-ID för den första bilden.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Hämta bilddelen från relations-ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Bygg ett StringBuilder-objekt.

        StringBuilder paragraphText = new StringBuilder();

        // Hämta bildens inre text:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)