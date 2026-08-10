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

SVG ist ein skalierbares XML‑basiertes Bildformat, das sich gut für Web‑Publikationen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/) wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Der Dateiname verwendet [ISlide.SlideNumber](https://reference.aspose.com/slides/de/net/aspose.slides/islide/slidenumber/) anstelle des Schleifenindex. Sie können auch eine einzelne Form mit [IShape.WriteAsSvg](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/writeassvg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/) steuert das Rendering von SVG. Für Textfelder fügt [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/useframesize/) den Textrahmen in den Render‑Bereich ein, und [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/useframerotation/) legt fest, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/disablefontligatures/) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/vectorizetext/) auf `true`, um den gesamten Folientext als Vektorgrafik zu schreiben. Dadurch entfallen Schriftart‑Abhängigkeiten und das visuelle Ergebnis ist über Browser hinweg konsistenter, jedoch ist der Text nicht mehr als SVG‑Text auswählbar oder durchsuchbar.

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

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/externalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafik zu rendern. Prüfen Sie die Lizenzbedingungen, bevor Sie Schriftarten einbetten.

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

## **Einbettete Bildgröße reduzieren**

Verwenden Sie [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/picturescompression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.JpegQuality](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/jpegquality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgshapeformattingcontroller/), um [ISvgShape.Id](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgshape/id/) für jede SVG‑Form festzulegen. Um zusätzlich [ISvgTSpan.Id](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgtspan/id/)‑Werte auf Text‑`tspan`‑Elementen zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller über [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu.

Der folgende Controller nutzt [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/officeinteropshapeid/), das während der Lebensdauer der Form stabil bleibt, und einen wiederholbaren Zähler für seine Text‑Spans. Dadurch eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

## **SVG-Ereignishandler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/de/net/aspose.slides.export/isvgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgevent/)‑Wert auf, um einem exportierten Form-Element einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die JavaScript‑Funktion bereitstellen, auf die der Handler verweist. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheits‑Erweiterungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.VectorizeText](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/vectorizetext/) statt [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.VectorizeText](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/vectorizetext/), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgexternalfontshandling/), wenn nur der Text, der externe Schriftarten nutzt, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG zu verkleinern?**

Beginnen Sie damit, eingebettete Bilder zu komprimieren, beschnittene Bildbereiche zu entfernen und verlinkte Schriftdateien zu wählen, wenn die Zielumgebung sie bereitstellen kann. Testen Sie das Ergebnis, da eine niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export bearbeiten?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie dann die entsprechenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.