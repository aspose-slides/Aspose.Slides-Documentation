---
title: "Präsentationsfolien als SVG-Bilder in .NET rendern"
linktitle: "Folie zu SVG"
type: docs
weight: 50
url: /de/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint zu SVG"
- "Präsentation zu SVG"
- "Folie zu SVG"
- "PPT zu SVG"
- "PPTX zu SVG"
- "SVG-Exportoptionen"
- "interaktives SVG"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in .NET und steuern Sie Schriften, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML‑basiertes Bildformat, das sich gut für Web‑Veröffentlichungen, Folien‑Viewer, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriften, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

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

Der Dateiname verwendet [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) anstelle des Schleifen‑Indexes. Sie können auch eine einzelne Form mit [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) exportieren, wenn ein Folien‑Viewer oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) steuert das Rendering von SVG. Für Textfelder beinhaltet [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) den Textrahmen im Rendering‑Bereich, und [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Zeilenende‑Beschneidung bei Pfeilspitzen steuern**

SVG 1.1 hat keine Markereinsetz‑Einstellung, um festzulegen, wo eine Linie unter einer Pfeilspitze enden soll. Standardmäßig verkürzt Aspose.Slides die exportierte Linie, sodass ihr Strich nicht durch den Marker hindurchsteht. Setzen Sie [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) auf `true`, um den Strich bis zum ursprünglichen Endpunkt der Linie zu zeichnen. Diese Einstellung wirkt sich nur auf die SVG‑Ausgabe aus. Die Linie behält ihre Position und Länge auf der Folie bei.

Das Beispiel zeichnet Dreieck‑ und Diamant‑Pfeilspitzen auf Linien mit 2 und 10 Punkt Breite. Es exportiert dieselbe Folie zweimal und ändert nur die Beschneidungs‑Option.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Der Vergleich zeigt die dreieckige Pfeilspitze auf der 10‑Punkt‑Linie. Bei aktivierter Beschneidung ist die Spitze scharf. Bei deaktivierter Beschneidung ragt der Strich durch die schrägen Seiten des Markers und hinterlässt ein flaches Ende.

![Vergrößertes 10-Punkt-Dreieck mit spitzer Spitze bei aktiviertem Beschneiden und flachem Ende bei deaktiviertem Beschneiden](line-end-cropping.png)

In den anderen Linien des Beispiels ist der hervortretende Strich weniger sichtbar bei dem 2‑Punkt‑Dreieck. Der ausgefüllte Diamant deckt das Endes des Strichs bei beiden Breiten ab.

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriften eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schrift‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) auf `true`, um gesamten Folientext als Vektorgrafiken zu schreiben. Damit entfallen Schrift‑Abhängigkeiten und das visuelle Ergebnis ist über Browser hinweg konsistenter, jedoch ist der Text nicht mehr als SVG‑Text auswähl‑ oder durchsuchbar.

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

### **Auswahl, wie externe Schriften behandelt werden**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑Wert für extern geladene Schriften. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schrift­daten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriften verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriften, bevor Sie sie einbetten.

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

Verwenden Sie [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/), um die JPEG‑Kodierungs‑Qualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Auflösung der Metafile‑Rasterisierung steuern**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterisierung von Metadateien beim SVG‑Export fest. Nutzen Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert keinen globalen DPI‑Wert für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten diagonalen Linien enthält. Das folgende Beispiel exportiert dessen erste Folie mit drei Rasterisierungs‑Auflösungen über [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Alle übrigen Exporteinstellungen bleiben identisch, sodass die Ergebnisse vergleichbar sind.

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

In der Ausgabe wurde das EMF in jeder SVG‑Datei zu einem eingebetteten PNG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixel‑Abmessungen dar.

| Metafile‑Rasterisierungs‑DPI | Abmessungen des eingebetteten PNG | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigengröße. Die diagonalen Linien zeigen bei 72 DPI deutliche Pixelbildung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Wertes verbessert nicht zwingend jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) steuert die Reduktion der Bildauflösung und kann die Auswirkung einer Änderung der Metafile‑Rasterisierungs‑Auflösung maskieren. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) steuert die JPEG‑Kodierungs‑Qualität, nicht die Rasterisierungs‑Auflösung.

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), um [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) für jede SVG‑Form festzulegen. Um ebenfalls [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/)‑Werte für Text‑`tspan`‑Elemente zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller über [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu.

Der folgende Controller nutzt [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für deren Text‑Spans. Damit eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller über [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folien‑Viewer, Barrierefrei­keits‑Verbesserungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), wenn sämtlicher Text unabhängig von Schriften sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriften nutzt, in Grafiken umgewandelt werden soll.

**Wie kann man SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, wenn die Zielumgebung sie bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größen‑Kompromisse darstellen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie anschließend die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Werkzeug oder Browser‑Script aus.