---
title: Az összes dia címének lekérése
type: docs
weight: 120
url: /hu/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// A prezentáció összes dia címének listájának lekérése.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // A prezentáció megnyitása csak olvasásra.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// A prezentáció összes dia címének listájának lekérése.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // PresentationPart objektum lekérése a PresentationDocument objektumból.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Presentation objektum lekérése a PresentationPart objektumból.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Minden dia címének lekérése a diák sorrendjében.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Dia címének lekérése.

                string title = GetSlideTitle(slidePart);

                // Üres cím is hozzáadható.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// A dia címszövegének lekérése.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Bekezdéselválasztó deklarálása.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Az összes címes alakzat megtalálása.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // A szöveg lekérése az alakzat minden bekezdéséből.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Új sor beszúrása.

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

// Megállapítja, hogy az alakzat címes-e.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Bármely címes alakzat.

            case PlaceholderValues.Title:

            // Középre igazított cím.

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

    // A prezentáció megnyitása csak olvasásra.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // A prezentáció átadása a következő CountSlides metódusnak

        // és a dia számának visszaadása.

        return CountSlides(presentationDocument);

    }

}

// A prezentáció diáinak megszámolása.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ellenőrzés, hogy a dokumentumobjektum null-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // A dokumentum prezentációs részének lekérése.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // A dia számának lekérése a SlideParts elemekből.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // A dia számának visszaadása az előző metódusnak.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Az első dia kapcsolatazonosítójának lekérése.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // A dia részének lekérése a kapcsolatazonosítóból.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // StringBuilder objektum felépítése.

        StringBuilder paragraphText = new StringBuilder();

        // A dia belső szövegének lekérése:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Minta Kód Letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)