---
title: Formen auf Präsentationsfolien skalieren
type: docs
weight: 130
url: /de/net/re-sizing-shapes-on-slide/
keywords:
  - Formgröße ändern
  - Formgröße anpassen
  - PowerPoint
  - OpenDocument
  - Präsentation
  - .NET
  - C#
  - Aspose.Slides
description: "Skalieren Sie Formen auf PowerPoint- und OpenDocument-Folien einfach mit Aspose.Slides für .NET – automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---

## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides für .NET‑Kunden ist, wie man Formen so skaliert, dass beim Ändern der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das geht.

## **Formen skalieren**

Um zu verhindern, dass Formen beim Ändern der Foliengröße missaligned werden, aktualisieren Sie Position und Abmessungen jeder Form, sodass sie dem neuen Folienlayout entsprechen.
```c#
// Präsentationsdatei laden.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Originale Foliengröße ermitteln.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Neue Foliengröße ermitteln.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formen auf jeder Folie skalieren und neu positionieren.
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

Enthält eine Folie eine Tabelle, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.

{{% /alert %}}

Verwenden Sie den folgenden Code, um Folien, die Tabellen enthalten, zu skalieren. Für Tabellen ist das Festlegen von Breite oder Höhe ein Sonderfall: Sie müssen die einzelnen Zeilenhöhen und Spaltenbreiten anpassen, um die Gesamtabmessungen der Tabelle zu ändern.
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Originale Foliengröße ermitteln.
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

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht ausdrücklich geändert wird. Das kann dazu führen, dass Inhalte beschnitten oder Formen falsch ausgerichtet werden.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das Grundbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen müssen Sie jedoch Zeilen und Spalten separat behandeln, da Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt werden.

**Wie skaliere ich Tabellen beim Skalieren einer Folie?**

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe und Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

**Funktioniert dieses Skalieren für Masterfolien und Layoutfolien?**

Ja, jedoch sollten Sie auch die [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) und [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) durchlaufen und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

**Kann ich die Orientierung einer Folie (Hochformat/Querformat) zusammen mit dem Skalieren ändern?**

Ja. Sie können [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) setzen, um die Orientierung zu ändern. Achten Sie darauf, die Skalierungslogik entsprechend anzupassen, um das Layout zu erhalten.

**Gibt es eine Obergrenze für die Foliengröße, die ich festlegen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit bestimmten PowerPoint‑Versionen einschränken.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können vor dem Skalieren die Eigenschaft `AspectRatioLocked` der Form prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.