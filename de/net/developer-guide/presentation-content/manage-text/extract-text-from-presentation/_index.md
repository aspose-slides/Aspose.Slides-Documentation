---
title: Fortgeschrittene Textextraktion aus Präsentationen in .NET
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/de/
keywords:
  - Text extrahieren
  - Text aus Folie extrahieren
  - Text aus Präsentation extrahieren
  - Text aus PowerPoint extrahieren
  - Text aus OpenDocument extrahieren
  - Text aus PPT extrahieren
  - Text aus PPTX extrahieren
  - Text aus ODP extrahieren
  - Text abrufen
  - Text aus Folie abrufen
  - Text aus Präsentation abrufen
  - Text aus PowerPoint abrufen
  - Text aus OpenDocument abrufen
  - Text aus PPT abrufen
  - Text aus PPTX abrufen
  - Text aus ODP abrufen
  - PowerPoint
  - OpenDocument
  - Präsentation
  - .NET
  - C#
  - Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET. Folgen Sie unserer einfachen Schritt-für-Schritt-Anleitung, um Zeit zu sparen."
---
## **Übersicht**

Das Extrahieren von Text aus Präsentationen ist eine verbreitete, aber wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Egal, ob Sie mit Microsoft PowerPoint‑Dateien im PPT‑ oder PPTX‑Format oder mit OpenDocument‑Präsentationen (ODP) zu tun haben – der Zugriff auf und das Abrufen von Textdaten kann für Analyse, Automatisierung, Indizierung oder die Migration von Inhalten entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text effizient aus verschiedenen Präsentationsformaten – einschließlich PPT, PPTX und ODP – mithilfe von Aspose.Slides für .NET extrahieren können. Sie lernen, wie Sie systematisch durch Präsentationselemente iterieren, um den benötigten Textinhalt exakt zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides für .NET stellt den Namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/de/net/aspose.slides.util/) bereit, der die Klasse [SlideUtil](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/) enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [GetAllTextBoxes](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/getalltextboxes/). Diese Methode akzeptiert ein Objekt vom Typ [IBaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/) als Parameter. Beim Aufruf scannt die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) zurück, wobei sämtliche Textformatierungen erhalten bleiben.

Das folgende Code‑Snippet extrahiert den gesamten Text aus der ersten Folie der Präsentation:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Text aus einer Präsentation extrahieren**

Um Text aus der gesamten Präsentation zu erfassen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/getalltextframes/) der Klasse [SlideUtil](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/). Sie akzeptiert zwei Parameter:

1. Zunächst ein Objekt vom Typ [IPresentation](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/), das eine PowerPoint‑ oder OpenDocument‑Präsentation darstellt, aus der der Text extrahiert werden soll.
1. Zweitens ein `Boolean`‑Wert, der angibt, ob die Master‑Folien beim Durchsuchen der Präsentation einbezogen werden sollen.

Die Methode liefert ein Array von Objekten des Typs [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/), einschließlich Informationen zur Textformatierung. Der nachfolgende Code scannt den Text und die Formatierungsdetails einer Präsentation, einschließlich der Master‑Folien.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Kategorisierte und schnelle Textextraktion**

Die Klasse [PresentationFactory](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/) bietet ebenfalls Methoden zum Extrahieren des gesamten Textes aus Präsentationen:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Das Enum‑Argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/de/net/aspose.slides/textextractionarrangingmode/) gibt den Modus für die Anordnung des Textextraktions‑Ergebnisses an und kann auf die folgenden Werte gesetzt werden:
- `Unarranged` – Der Rohtext, ohne Rücksicht auf seine Position auf der Folie.
- `Arranged` – Der Text wird in derselben Reihenfolge angeordnet wie auf der Folie.

Der Modus *Unarranged* kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Modus *Arranged*.

[IPresentationText](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationtext/) repräsentiert den rohen, aus der Präsentation extrahierten Text. Seine Eigenschaft `SlidesText` gibt ein Array von Objekten des Typs [ISlideText](https://reference.aspose.com/slides/de/net/aspose.slides/islidetext/) zurück. Jedes Objekt repräsentiert den Text auf der jeweiligen Folie. Das Objekt vom Typ [ISlideText](https://reference.aspose.com/slides/de/net/aspose.slides/islidetext/) besitzt die folgenden Eigenschaften:

- `Text` – Der Text innerhalb der Formen der Folie.
- `MasterText` – Der Text innerhalb der Formen der Master‑Folie, die dieser Folie zugeordnet ist.
- `LayoutText` – Der Text innerhalb der Formen der Layout‑Folie, die dieser Folie zugeordnet ist.
- `NotesText` – Der Text innerhalb der Formen der Notiz‑Folie, die dieser Folie zugeordnet ist.
- `CommentsText` – Der Text innerhalb von Kommentaren, die dieser Folie zugeordnet sind.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und kann selbst [große Präsentationen](/slides/de/net/open-presentation/) verarbeiten, sodass es sich für Echtzeit‑ oder Batch‑Verarbeitungsszenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja. Aspose.Slides kann Text aus vielen Folienelementen extrahieren, einschließlich Tabellen und diagrammbezogenen Objekten, sodass Sie auf textuelle Inhalte gängiger Präsentationsstrukturen zugreifen und diese analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings gibt es [bestimmte Einschränkungen](/slides/de/net/licensing/), etwa die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zum Umgang mit größeren Präsentationen wird der Kauf einer Voll‑Lizenz empfohlen.