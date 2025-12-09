---
title: Formen auf Präsentationsfolien in .NET skalieren
type: docs
weight: 130
url: /de/net/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Formen auf PowerPoint- und OpenDocument-Folien ganz einfach mit Aspose.Slides für .NET skalieren - Layout-Anpassungen automatisieren und die Produktivität steigern."
---

## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides für .NET‑Kunden ist, wie man Formen so skaliert, dass bei einer Änderung der Foliengröße keine Daten abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das geht.

## **Formen skalieren**

Um zu verhindern, dass Formen bei einer Änderung der Foliengröße fehlpositioniert werden, aktualisieren Sie die Position und Größe jeder Form, sodass sie dem neuen Folienlayout entsprechen.
```c#
// Lade die Präsentationsdatei.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hole die ursprüngliche Foliengröße.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ändere die Foliengröße, ohne vorhandene Formen zu skalieren.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Hole die neue Foliengröße.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formen auf jeder Folie skalieren und neu positionieren.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Skaliere die Formgröße.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skaliere die Formposition.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

Enthält eine Folie eine Tabelle, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.

{{% /alert %}}

Verwenden Sie den folgenden Code, um Folien mit Tabellen zu skalieren. Für Tabellen ist das Setzen von Breite oder Höhe ein Sonderfall: Sie müssen die einzelnen Zeilenhöhen und Spaltenbreiten anpassen, um die Gesamtabmessungen der Tabelle zu ändern.
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Ursprüngliche Foliengröße ermitteln.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Neue Foliengröße ermitteln.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Formgröße skalieren.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Formposition skalieren.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Formgröße skalieren.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Formposition skalieren.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Formgröße skalieren.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Formposition skalieren.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?**

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht explizit geändert wird. Das kann dazu führen, dass Inhalte beschnitten oder Formen fehlpositioniert werden.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das Basisbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen müssen Sie jedoch Zeilen und Spalten separat behandeln, da die Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt wird.

**Wie skaliere ich Tabellen, wenn ich eine Folie skalieren möchte?**

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe und Breite proportional anpassen, wie im zweiten Code‑Beispiel gezeigt.

**Funktioniert diese Skalierung für Master‑Folien und Layout‑Folien?**

Ja, Sie sollten zusätzlich durch [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) und [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

**Kann ich die Ausrichtung einer Folie (Hochformat/Landscape) zusammen mit der Skalierung ändern?**

Ja. Sie können [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) setzen, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Abmessungen können die Leistung beeinträchtigen oder die Kompatibilität mit manchen PowerPoint‑Versionen einschränken.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können die `AspectRatioLocked`‑Eigenschaft der Form vor dem Skalieren prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.