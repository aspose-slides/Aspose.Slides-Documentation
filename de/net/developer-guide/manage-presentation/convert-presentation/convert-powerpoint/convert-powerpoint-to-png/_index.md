---
title: PowerPoint-Folien nach PNG konvertieren in .NET
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für .NET und dabei präzise, automatisierte Ergebnisse sicherstellen."
---
## **Übersicht**

Dieses Dokument erklärt, wie man Präsentationsfolien in PNG‑Bilder mit Aspose.Slides für .NET konvertiert. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separates PNG‑Bild speichern.

Die nachfolgenden Beispiele zeigen, wie man Thumbnails rendert, Skalierungsfaktoren festlegt, die Ausgabedimensionen in Pixeln angibt und einen Gradienten‑Renderstil auswählt.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und greifen Sie über die Sammlung [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) auf deren Folien zu. Das Beispiel rendert jede Folie mit [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) ohne Parameter, um ein Thumbnail zu erzeugen. Anschließend wird [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) mit [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Die parameterlose Überladung von [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) rendert mit einem Maßstab von 0,2. Beispielsweise erzeugt eine Folie mit den Maßen 720 × 540 Punkt ein Thumbnail von 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit den Maßen 720 × 540 Punkt ein Bild von 1440 × 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jedes Bild wird im PNG‑Format mit [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) gespeichert.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixel anzugeben, übergeben Sie statt Skalierungsfaktoren eine Größe an [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/). Dieses Beispiel rendert jede Folie mit 960 × 720 Pixel und speichert das Ergebnis mit [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Verzerren des Bildes zu vermeiden.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Wählen Sie einen Gradienten‑Renderstil**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anderweitig anders als in PowerPoint. Sie können die Eigenschaft [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) von [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) verwenden, um zu bestimmen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stoppunkte bei 0% und 100%.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Die Bilder unten zeigen die Ausgabe derselben Folie, wobei in jedem Bild beide Verläufe zu sehen sind:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-orange und Blau-zu-gelb Verläufe, gerendert mit Default](gradient-Default.png) | ![Die gleichen Verläufe, gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und den Stoppunkten im Verlauf ab.

Wählen Sie `Default`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Verwenden Sie `PowerPointUI`, wenn es Ihnen wichtig ist, das Aussehen von PowerPoint zu reproduzieren. Vergleichen Sie beide Ausgaben mit dem gewünschten Ergebnis; keine der beiden Optionen ist grundsätzlich überlegen.

## **FAQ**

**Wie kann ich eine bestimmte Form, z. B. ein Diagramm oder ein Bild, anstatt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Thumbnails für einzelne Formen](/slides/de/net/create-shape-thumbnails/), sodass Sie eine Form als PNG‑Bild rendern können.

**Wird eine parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzelne Instanz über Threads hinweg](/slides/de/net/multithreading/).

**Welche Einschränkungen gelten im Evaluierungsmodus beim Export nach PNG?**

Im Evaluierungsmodus wird ein Wasserzeichen zu den Ausgabebildern hinzugefügt und es gelten [weitere Beschränkungen](/slides/de/net/licensing/), bis eine Lizenz angewendet wird.