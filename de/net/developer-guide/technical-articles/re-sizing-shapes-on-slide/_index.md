---
title: Formen auf Präsentationsfolien in .NET skalieren
type: docs
weight: 130
url: /de/net/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Größe der Form ändern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET einfach skalieren – Folienlayout-Anpassungen automatisieren und die Produktivität steigern."
---
## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides für .NET‑Kunden ist, wie man Formen skaliert, sodass bei einer Änderung der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das geht.

## **Formen skalieren**

Um zu verhindern, dass sich Formen bei einer Änderung der Foliengröße verschieben, aktualisieren Sie die Position und Abmessungen jeder Form, damit sie dem neuen Folienlayout entsprechen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Präsentationsdatei laden.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Originale Foliengröße abrufen.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Neue Foliengröße abrufen.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formen auf jeder Folie skalieren und neu positionieren.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Größe der Form skalieren.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Position der Form skalieren.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Falls eine Folie eine Tabelle enthält, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle in der Tabelle skaliert werden.
{{% /alert %}}

Verwenden Sie den folgenden Code, um Folien mit Tabellen zu skalieren. Bei Tabellen skalieren Sie die einzelnen Zeilenhöhen und Spaltenbreiten anstelle der Breite und Höhe der Form – eine doppelte Skalierung würde die Tabelle zweimal vergrößern und sie von der Folie schieben.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Originale Foliengröße abrufen.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Neue Foliengröße abrufen.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Größe der Form skalieren.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Position der Form skalieren.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Größe der Form skalieren.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Position der Form skalieren.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Tabellengröße über ihre Zeilen und Spalten skalieren.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Größe der Form skalieren.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Position der Form skalieren.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Warum werden Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?

Beim Ändern der Foliengröße behalten Formen ihre ursprüngliche Position und Größe bei, wenn die Skalierung nicht explizit geändert wird. Dies kann dazu führen, dass Inhalte beschnitten oder Formen verschoben werden.

### Funktioniert der bereitgestellte Code für alle Formtypen?

Das Basisbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen müssen Sie jedoch Zeilen und Spalten separat behandeln, da die Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt wird.

### Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe bzw. Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

### Funktioniert diese Skalierung für Masterfolien und Layoutfolien?

Ja, aber Sie sollten ebenfalls durch [Masters](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/masters/) und [LayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/layoutslides/) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

### Kann ich die Ausrichtung einer Folie (Hochformat/Landscape) zusammen mit der Skalierung ändern?

Ja. Sie können [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/orientation/) setzen, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

### Gibt es ein Limit für die Foliengröße, die ich festlegen kann?

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit einigen PowerPoint‑Versionen einschränken.

### Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?

Sie können vor dem Skalieren die Eigenschaft `AspectRatioLocked` der Form prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.