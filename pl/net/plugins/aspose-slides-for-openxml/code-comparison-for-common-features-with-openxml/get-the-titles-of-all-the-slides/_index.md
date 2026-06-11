---
title: Pobierz tytuły wszystkich slajdów
type: docs
weight: 120
url: /pl/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Pobierz listę tytułów wszystkich slajdów w prezentacji.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Pobierz listę tytułów wszystkich slajdów w prezentacji.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Pobierz obiekt PresentationPart z obiektu PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Pobierz obiekt Presentation z obiektu PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Pobierz tytuł każdego slajdu w kolejności slajdów.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Pobierz tytuł slajdu.

                string title = GetSlideTitle(slidePart);

                // Można również dodać pusty tytuł.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Pobierz łańcuch tytułu slajdu.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Zadeklaruj separator akapitu.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Znajdź wszystkie kształty tytułu.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Pobierz tekst w każdym akapicie tego kształtu.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Dodaj znak końca linii.

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

// Określa, czy kształt jest kształtem tytułu.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Dowolny kształt tytułu.

            case PlaceholderValues.Title:

            // Wyśrodkowany tytuł.

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

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację do kolejnej metody CountSlides

        // i zwróć liczbę slajdów.

        return CountSlides(presentationDocument);

    }

}

// Count the slides in the presentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Sprawdź, czy obiekt dokumentu jest null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Pobierz część prezentacji z dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz liczbę slajdów z obiektów SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Zwróć liczbę slajdów do poprzedniej metody.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Pobierz identyfikator relacji pierwszego slajdu.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Pobierz część slajdu za pomocą identyfikatora relacji.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Zbuduj obiekt StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Pobierz wewnętrzny tekst slajdu:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)