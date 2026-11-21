---
title: Ändern der Notizseitengröße und -orientierung in .NET
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/net/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Querformat-Notizen
- Hochformat-Notizen
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Lesen und ändern Sie die Notizseitendimensionen in Aspose.Slides für .NET, wechseln Sie die Ausrichtung, überprüfen Sie gespeicherte Größen und exportieren Sie Notizen oder Handouts zu PDF und Bildern."
---
## **Übersicht**

Verwenden Sie [Presentation.NotesSize](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/notessize/) , um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [INotesSize](https://reference.aspose.com/slides/de/net/aspose.slides/inotessize/) Objekt zurück, dessen [Size](https://reference.aspose.com/slides/de/net/aspose.slides/inotessize/size/) Eigenschaft schreibbar ist. Obwohl das Einstellungsobjekt selbst schreibgeschützt ist, können Sie neue Dimensionen seiner Size‑Eigenschaft zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8 ⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/notessize/) | Steuert die Abmessungen der Notizseite und die für den Handout-Export verwendeten Seitenabmessungen. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slidesize/) | Steuert die regulären Folienabmessungen der Präsentation über [ISlideSize](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/). |

Das Ändern einer der Einstellungen ändert nicht automatisch die andere. Das Ändern der Notizseiten‑Orientierung dreht die regulären Folien ebenfalls nicht. Siehe [Slide Size](/slides/de/net/slide-size/), um die regulären Folien zu ändern.

Die nachfolgenden Beispiele verwenden eine vorhandene Datei `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Lautsprecher‑Notizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Lesen der Notizseitengröße und -orientierung**

Lesen Sie die Breite und Höhe und vergleichen Sie sie, um die Orientierung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Wechsel zu Querformat, ohne die Papiergröße zu ändern**

Um nur die Orientierung zu ändern, tauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, auch bei einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite zurück ins Hochformat gewechselt wird, und lässt eine quadratische Seite unverändert.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Für Hochformat verwenden Sie dieselbe Zuweisung, wenn `size.Width > size.Height`. Ersetzen Sie nicht A4- oder Letter‑Abmessungen, sofern Sie nicht ebenfalls die Papiergröße ändern möchten.

## **Festlegen und Überprüfen einer benutzerdefinierten Notizseitengröße**

Weisen Sie beide Dimensionen gemeinsam zu und verwenden Sie anschließend [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) , um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkt‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Gleitkommawerte; er ist keine Garantie für Präzision bei jedem Dateiformat.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Das erwartete Ergebnis ist `900 x 600 points` und `Size preserved: True`. Das Überprüfen einer frisch geöffneten Präsentation verifiziert die gespeicherte Datei, nicht nur die in‑Memory‑Einstellungen.

## **Exportieren von Notizen und Handouts**

Die Seitenabmessungen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht automatisch: Konfigurieren Sie auch die Exportoptionen. Der Export regulärer Folien verwendet weiterhin die Folienabmessungen.

### **Exportieren von Notizen nach PDF und PNG**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/) [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) zu, um Notizen in das PDF einzubeziehen. Dieses Beispiel rendert zudem die erste Folie mit Notizen nach PNG mittels [Slide.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/slide/getimage/) und [RenderingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/net/aspose.slides.export/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet Seiten mit 900 × 600 Punkten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Für den PDF‑Export mit langen Notizen erlaubt [BottomFull](https://reference.aspose.com/slides/de/net/aspose.slides.export/notespositions/) bei Bedarf zusätzliche Seiten zu erzeugen. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folien‑Bildaufruf, der ihn nicht unterstützt. Nach dem Ändern der Größe überprüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; das alleinige Ändern der Seitenabmessungen sollte nicht als Garantie dafür angesehen werden, dass sämtlicher Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/net/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizexport.

### **Exportieren von Handouts nach PDF**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/handoutlayoutingoptions/) , um mehrere Folien‑Thumbnails auf einer Seite zu platzieren. Das folgende Beispiel legt eine 900 × 600‑Punkt‑Seite fest und nutzt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/de/net/aspose.slides.export/handouttype/) , um bis zu vier Folien pro Seite anzuordnen. Die horizontale Vorgabe steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus ihrer Breite und Höhe.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Das Ändern der Seitengröße verändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Ausgangsfolien zu ändern. Für Handout‑Bilder verwenden Sie [Presentation.GetImages](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/getimages/) mit dem Handout‑Layout, anstatt die Bildmethode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das handout‑Rendering auf Präsentationsebene die Notizseitengrößen, während der Bildaufruf einer einzelnen Folie keine Handout‑Seite erzeugt. Siehe [Handout Mode](/slides/de/net/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Viewern, Export und Druck**

Behalten Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Presentation viewers:** Ein Viewer kann Notizen mit eigenen Layout‑Regeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen erneut; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Export formats:** Die PDF‑Beispiele für Notizen und Handouts oben verwenden die konfigurierten Seitengrößen. Rasterbilder verwenden ganzzahlige Pixelabmessungen und einen Rendermaßstab, sodass bruchteils‑Punkt‑Werte im Bild ausgegeben gerundet werden können. Der Export regulärer Folien berücksichtigt nicht die Notizseitengröße.
- **Printer drivers:** Papierauswahl, automatische Drehung und Fit‑to‑Page‑Einstellungen können das physische Ergebnis ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu verändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft liefert keine separate Seitengröße für jede Folie.

**Warum hat das Ändern der Notiz‑Orientierung meine Folien nicht geändert?**

Notizseiten und reguläre Folien besitzen unabhängige Abmessungen. Verwenden Sie die regulären Foliengrößeneinstellungen, wenn Sie die Folien selbst ändern möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn diese geändert wurden, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, überprüfen Sie das Export‑Layout, den Bildmaßstab, die Viewereinstellungen und die Papierauswahl des Druckers.