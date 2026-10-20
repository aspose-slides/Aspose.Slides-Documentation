---
title: Formen auf Präsentationsfolien in .NET skalieren
type: docs
weight: 130
url: /de/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /de/net/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Skalieren Sie mühelos Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET – automatisieren Sie die Anpassung von Folienlayouts und steigern Sie die Produktivität."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen ihrer Folien in der Größe anpassen und neu positionieren, um den neuen Abmessungen zu entsprechen. Dieser Artikel zeigt, wie Formen manuell skaliert werden können und wie Tabellen auf Folien, Master-Folien und Layouts behandelt werden.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf ihre vertikalen Koordinaten und Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße auf A4 und speichert das Ergebnis. Es verwendet [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) mit [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind einheitenlos; die Positionen und Abmessungen von Formen werden in Punkt gemessen. Unterschiedliche Breiten- und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie deren Spaltenbreiten und Zeilenhöhen, anstatt die gesamte Breite und Höhe der Tabelle zuzuweisen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zelleninhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Master-Folien und Layouts sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Seine Hilfsklasse bearbeitet jedes [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) indem sie [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) und [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen separat zu skalieren.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Formen auf Mastern und Layouts sowie einzelnen Folien skalieren.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Warum sind Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausreichen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann Formen ebenfalls verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen gedacht. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und Tabellendaten die Zeilenhöhen einschränken können.

**Wie skaliere ich Tabellen beim Ändern einer Folie?**

Skalieren Sie die Spaltenbreiten nach dem Breitenverhältnis und die minimale Zeilenhöhe nach dem Höhenverhältnis, und anschließend die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Skalierung für Master-Folien und Layout-Folien?**

Ja. Das zweite Beispiel iteriert über [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) und die [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) jedes Masters und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Querformat) zusammen mit der Skalierung ändern?**

Ja. Setzen Sie [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) nachdem Sie die Foliengröße geändert und bevor Sie die Zielabmessungen auslesen, damit die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) festlegen. Die unterstützten Abmessungen hängen auch vom Präsentationsformat und der Anwendung ab, die die Datei öffnet.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in die neuen Folienabmessungen einzupassen, nutzen Sie das kleinere der beiden Verhältnisse (Breite bzw. Höhe) für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch entlang einer Kante ungenutzter Raum verbleiben.