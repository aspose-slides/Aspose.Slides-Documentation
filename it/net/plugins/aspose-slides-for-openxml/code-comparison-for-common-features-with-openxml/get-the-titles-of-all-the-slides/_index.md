---
title: Ottieni i titoli di tutte le diapositive
type: docs
weight: 120
url: /it/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Ottieni un elenco dei titoli di tutte le diapositive nella presentazione.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Apri la presentazione in sola lettura.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Ottieni un elenco dei titoli di tutte le diapositive nella presentazione.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Ottieni un oggetto PresentationPart dall'oggetto PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Ottieni un oggetto Presentation dall'oggetto PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Ottieni il titolo di ciascuna diapositiva nell'ordine delle diapositive.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Ottieni il titolo della diapositiva.

                string title = GetSlideTitle(slidePart);

                // Può anche essere aggiunto un titolo vuoto.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Ottieni la stringa del titolo della diapositiva.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Dichiara un separatore di paragrafo.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Trova tutte le forme titolo.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Ottieni il testo in ogni paragrafo di questa forma.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Aggiungi un'interruzione di riga.

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

// Determina se la forma è una forma titolo.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Qualsiasi forma titolo.

            case PlaceholderValues.Title:

            // Un titolo centrato.

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

    // Apri la presentazione in sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione al successivo metodo CountSlides

        // e restituisci il numero di diapositive.

        return CountSlides(presentationDocument);

    }

}

// Conta le diapositive nella presentazione.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifica se l'oggetto documento è null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Ottieni la parte Presentation del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni il conteggio delle diapositive dalle SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Restituisci il conteggio delle diapositive al metodo precedente.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Ottieni l'ID di relazione della prima diapositiva.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Ottieni la parte della diapositiva dall'ID di relazione.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Crea un oggetto StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Ottieni il testo interno della diapositiva:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Scarica codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)