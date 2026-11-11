---
title: Präsentationsfolien als SVG-Bilder in .NET rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG-Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in .NET und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML‑basiertes Bildformat, das sich gut für Web‑Publishing, Folien‑Viewer, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Der Dateiname verwendet [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) anstatt des Schleifenindexes. Sie können zudem eine einzelne Form mit [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) exportieren, wenn ein Folien‑Viewer oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) steuert die SVG‑Renderung. Für Textrahmen fügt [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) den Textrahmen zum Renderbereich hinzu, und [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftart‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftart‑Abhängigkeiten und das visuelle Ergebnis ist über verschiedene Browser konsistenter, jedoch ist der Text nicht mehr auswählbar oder durchsuchbar als SVG‑Text.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Wählen Sie, wie externe Schriftarten behandelt werden**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑Wert für extern geladene Schriftarten. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten nutzt, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zulasten der Bildtreue oder der behaltenen Bilddaten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Rasterisierungsauflösung von Metadateien steuern**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterung von Metadateien beim SVG‑Export fest. Verwenden Sie sie, um Details und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert keinen globalen DPI‑Wert für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonallinien enthält. Das folgende Beispiel exportiert dessen erste Folie mit drei Rasterisierungsauflösungen über [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Alle anderen Export‑Einstellungen bleiben identisch, damit die Ergebnisse verglichen werden können.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Im Ergebnis wurde das EMF zu einem eingebetteten PNG in jedem SVG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Dimensionen des eingebetteten PNG | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der nachfolgende Vergleich zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonallinien zeigen bei 72 DPI eine sichtbare Pixelbildung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Wertes verbessert nicht zwangsläufig jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonallinien‑Detail bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) steuert die Reduktion der Bildauflösung und kann die Auswirkung einer Änderung der Metadatei‑Rasterisierungsauflösung maskieren. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) steuert die JPEG‑Kodierungsqualität, nicht jedoch die Rasterisierungsauflösung von Metadateien.

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), um [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) für jede SVG‑Form festzulegen. Um auch Werte für [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) auf Text‑`tspan`‑Elementen zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller mit [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu.

Der folgende Controller verwendet [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für ihre Text‑Spans. Dadurch sind die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation geeignet.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **SVG‑Ereignishandler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), rufen Sie [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folien‑Viewer, Barrierefreiheits‑Erweiterungen und weitere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG zu verkleinern?**

Beginnen Sie mit dem Komprimieren eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Auswahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungscontroller zu und wählen Sie anschließend die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.