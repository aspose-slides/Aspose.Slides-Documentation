---
title: Verschieben eines Absatzes von einer Präsentation zu einer anderen
type: docs
weight: 130
url: /net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML Präsentation**
``` csharp

  string FilePath = @"..\..\..\..\Beispieldateien\";

string FileName = FilePath + "Verschieben eines Absatzes von einer Präsentation zu einer anderen 1.pptx";

string DestFileName = FilePath + "Verschieben eines Absatzes von einer Präsentation zu einer anderen 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Verschiebt einen Absatzbereich in einer TextBody-Form im Quelldokument

// zu einer anderen TextBody-Form im Zieldokument.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Öffne die Quelldatei im Lese-/Schreibmodus.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Öffne die Zieldatei im Lese-/Schreibmodus.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Hole die erste Folie in der Quellpräsentation.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Hole die erste TextBody-Form darin.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Hole den ersten Absatz in der TextBody-Form.

        // Hinweis: "Drawing" ist der Alias für den Namensraum DocumentFormat.OpenXml.Drawing

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Hole die erste Folie in der Zielpräsentation.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Hole die erste TextBody-Form darin.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Klone den Quellabsatz und füge den geklonten Absatz in die Ziel-TextBody-Form ein.

        // Das Übergeben von "true" erzeugt ein tiefes Klonen, das eine Kopie des 

        // Paragraph-Objekts und alles, was direkt oder indirekt von diesem Objekt referenziert wird, erstellt.

        textBody2.Append(p1.CloneNode(true));

        // Entferne den Quellabsatz aus der Quelldatei.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Ersetze den entfernten Absatz mit einem Platzhalter.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Speichere die Folie in der Quelldatei.

        slide1.Slide.Save();

        // Speichere die Folie in der Zieldatei.

        slide2.Slide.Save();

    }

}

}

// Hole den Folienteil der ersten Folie im Präsentationsdokument.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Hole die Beziehungs-ID der ersten Folie

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Hole den Folienteil anhand der Beziehungs-ID.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahieren können. Ob Sie Text von einer Folie oder einer gesamten Präsentation extrahieren, Aspose.Slides verwendet die PresentationScanner-Klasse und die statischen Methoden, die sie bereitstellt. Alle sind im Namensraum [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil) gebündelt.

``` csharp

 string FilePath = @"..\..\..\..\Beispieldateien\";

string FileName = FilePath + "Verschieben eines Absatzes von einer Präsentation zu einer anderen 1.pptx";

string DestFileName = FilePath + "Verschieben eines Absatzes von einer Präsentation zu einer anderen 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Verschiebt einen Absatzbereich in einer TextBody-Form im Quelldokument

// zu einer anderen TextBody-Form im Zieldokument.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    // Instanziiere die Präsentationsklasse, die PPTX darstellt

    Presentation sourcePres = new Presentation(sourceFile);

    // Greife auf die erste Form in der ersten Folie zu

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        // Hole den Text aus dem Platzhalter

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    // Greife auf die erste Form in der ersten Folie zu

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        // Hole den Text aus dem Platzhalter

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **Lade das laufende Codebeispiel herunter**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Verschieben eines Absatzes/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Verschieben%20eines%20Absatzes)