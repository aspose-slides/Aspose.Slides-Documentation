---
title: Hole die Titel aller Folien
type: docs
weight: 120
url: /de/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Hole die Titel aller Folien.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Hole eine Liste der Titel aller Folien in der Präsentation.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Öffne die Präsentation als schreibgeschützt.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Hole eine Liste der Titel aller Folien in der Präsentation.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Hole ein PresentationPart-Objekt aus dem PresentationDocument-Objekt.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Hole ein Presentation-Objekt aus dem PresentationPart-Objekt.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Hole den Titel jeder Folie in der Folienreihenfolge.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Hole den Foliens Titel.

                string title = GetSlideTitle(slidePart);

                // Ein leerer Titel kann auch hinzugefügt werden.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Hole den Titelstring der Folie.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Deklariere einen Absatztrenner.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Finde alle Titelformen.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Hole den Text in jedem Absatz in dieser Form.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Füge einen Zeilenumbruch hinzu.

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

// Bestimmt, ob die Form eine Titelform ist.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Jede Titelform.

            case PlaceholderValues.Title:

            // Ein zentrierter Titel.

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

string FileName = FilePath + "Hole allen Text in einer Folie.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Anzahl der Folien = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Folie #{0} enthält: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Öffne die Präsentation als schreibgeschützt.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Übergib die Präsentation an die nächste CountSlides-Methode

        // und gib die Folienanzahl zurück.

        return CountSlides(presentationDocument);

    }

}

// Zähle die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Überprüfen auf ein null-Dokumentobjekt.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hole den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hole die Folienanzahl von den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Gib die Folienanzahl an die vorherige Methode zurück.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Hole die Beziehungs-ID der ersten Folie.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Hole das Folienpart von der Beziehungs-ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Baue ein StringBuilder-Objekt.

        StringBuilder paragraphText = new StringBuilder();

        // Hole den inneren Text der Folie:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Beispielcode herunterladen**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Hole%20die%20Titel%20aller%20Folien%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Hole%20die%20Titel%20aller%20Folien%20\(Aspose.Slides\).zip)