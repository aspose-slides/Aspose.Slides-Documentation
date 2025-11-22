---
title: Erweiterte Textextraktion aus Präsentationen in C#
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/net/extract-text-from-presentation/
keywords:
- Text extrahieren
- Text aus Folie extrahieren
- Text aus Präsentation extrahieren
- Text aus PowerPoint extrahieren
- Text aus PPT extrahieren
- Text aus PPTX extrahieren
- Text aus ODP extrahieren
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text aus PowerPoint-Präsentationen mit Aspose.Slides für .NET schnell und einfach extrahieren können. Folgen Sie unserer einfachen Schritt-für-Schritt-Anleitung, um Zeit zu sparen und effizient auf Folieninhalte in Ihren Anwendungen zuzugreifen."
---

## **Überblick**

Das Extrahieren von Text aus Präsentationen ist eine gängige, aber wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Egal, ob Sie Microsoft PowerPoint-Dateien im PPT- oder PPTX-Format oder OpenDocument-Präsentationen (ODP) bearbeiten, der Zugriff auf und das Abrufen von Textdaten kann für Analysen, Automatisierung, Indexierung oder die Migration von Inhalten entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text aus verschiedenen Präsentationsformaten, einschließlich PPT, PPTX und ODP, mithilfe von Aspose.Slides für .NET effizient extrahieren. Sie lernen, wie Sie systematisch durch Präsentationselemente iterieren, um den benötigten Textinhalt exakt zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides für .NET stellt den Namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) bereit, der die Klasse [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). Diese Methode akzeptiert ein Objekt vom Typ [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) als Parameter. Bei Ausführung scannt die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zurück, wobei sämtliche Textformatierungen beibehalten werden.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:
```cs
int slideIndex = 0;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
using Presentation presentation = new Presentation("demo.pptx");

// Holen Sie eine Referenz zur Folie.
ISlide slide = presentation.Slides[slideIndex];

// Erhalten Sie ein Array von Textframes aus der Folie.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Durchlaufen Sie das Array der Textframes.
for (int i = 0; i < textFrames.Length; i++)
{
    // Durchlaufen Sie die Absätze im aktuellen Textframe.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Durchlaufen Sie die Textteile im aktuellen Absatz.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Geben Sie den Text im aktuellen Textteil aus.
            Console.WriteLine(portion.Text);

            // Geben Sie die Schriftgröße des Textes aus.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Geben Sie den Schriftartnamen des Textes aus.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Text aus einer Präsentation extrahieren**

Um Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/), die von der Klasse [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) bereitgestellt wird. Sie akzeptiert zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Objekt, das eine PowerPoint- oder OpenDocument-Präsentation darstellt, aus der Text extrahiert werden soll.
1. Zweitens ein `Boolean`-Wert, der angibt, ob die Masterfolien beim Scannen des Textes aus der Präsentation einbezogen werden sollen.

Die Methode gibt ein Array von Objekten des Typs [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zurück, das Textformatierungsinformationen enthält. Der untenstehende Code scannt den Text und Formatierungsdetails aus einer Präsentation, einschließlich der Masterfolien.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using Presentation presentation = new Presentation("demo.pptx");

// Holen Sie ein Array von Textframes aus allen Folien der Präsentation.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Durchlaufen Sie das Array der Textframes.
for (int i = 0; i < textFrames.Length; i++)
{
    // Durchlaufen Sie die Absätze im aktuellen Textframe.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Durchlaufen Sie die Textteile im aktuellen Absatz.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Geben Sie den Text im aktuellen Textteil aus.
            Console.WriteLine(portion.Text);

            // Geben Sie die Schriftgröße des Textes aus.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Geben Sie den Schriftartnamen des Textes aus.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Kategorisierte und schnelle Textextraktion**

Die Klasse [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) bietet ebenfalls statische Methoden zum Extrahieren des gesamten Textes aus Präsentationen:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


Das Enum-Argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) gibt den Modus zur Anordnung des Textextraktionsergebnisses an und kann auf die folgenden Werte gesetzt werden:
- `Unarranged` – Der Rohtext ohne Rücksicht auf seine Position auf der Folie.
- `Arranged` – Der Text wird in derselben Reihenfolge wie auf der Folie angeordnet.

Der unarranged‑Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der arranged‑Modus.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Sie enthält die Eigenschaft [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) aus dem Namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), die ein Array von Objekten des Typs [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) zurückgibt. Jedes Objekt repräsentiert den Text der entsprechenden Folie. Das Objekt des Typs [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) verfügt über die folgenden Eigenschaften:

- `Text` – Der Text innerhalb der Formen der Folie.
- `MasterText` – Der Text innerhalb der Formen der Masterfolie, die dieser Folie zugeordnet ist.
- `LayoutText` – Der Text innerhalb der Formen der Layoutfolie, die dieser Folie zugeordnet ist.
- `NotesText` – Der Text innerhalb der Formen der Notizfolie, die dieser Folie zugeordnet ist.
- `CommentsText` – Der Text innerhalb von Kommentaren, die dieser Folie zugeordnet sind.
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst große Präsentationen effizient, sodass es für Echtzeit‑ oder Massenszenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie problemlos auf sämtlichen Textinhalt zugreifen und ihn analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings hat diese bestimmte Einschränkungen, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und die Verarbeitung größerer Präsentationen wird der Kauf einer VollLizenz empfohlen.