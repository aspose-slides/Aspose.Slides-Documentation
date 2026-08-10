---
title: "Renderizzare diapositive di presentazione come immagini SVG in .NET"
linktitle: "Diapositiva in SVG"
type: docs
weight: 50
url: /it/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint in SVG"
- "presentazione in SVG"
- "diapositiva in SVG"
- "PPT in SVG"
- "PPTX in SVG"
- "opzioni di esportazione SVG"
- "SVG interattivo"
- "PowerPoint"
- "presentazione"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Esporta le diapositive PowerPoint come immagini SVG in .NET e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione post-processing automatica. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile su tutti i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Il nome file utilizza [ISlide.SlideNumber](https://reference.aspose.com/slides/it/net/aspose.slides/islide/slidenumber/) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [IShape.WriteAsSvg](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/writeassvg/) quando un visualizzatore di diapositive o una pagina web richiede solo quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/useframesize/) include il riquadro di testo nell'area di rendering e [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/useframerotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/disablefontligatures/) su `true` quando il testo deve essere renderizzato senza legature.

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

## **Controlla testo e caratteri**

### **Vettorizza tutto il testo**

Imposta [SVGOptions.VectorizeText](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/vectorizetext/) su `true` per scrivere tutto il testo delle diapositive come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

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

### **Scegli come gestire i caratteri esterni**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/externalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per fare riferimento a file di carattere separati, `Embed` per includere i dati dei caratteri nell'SVG o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

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

## **Riduci la dimensione delle immagini incorporate**

Utilizza [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/picturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) per omettere le aree ritagliate delle sorgenti e [SVGOptions.JpegQuality](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/jpegquality/) per controllare la qualità di codifica JPEG. Queste impostazioni riducono la dimensione del file a scapito della fedeltà dell'immagine o dei dati mantenuti.

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

## **Assegna ID stabili a forme e testo**

Utilizza [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshapeformattingcontroller/) per impostare [ISvgShape.Id](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshape/id/) per ciascuna forma SVG. Per impostare anche i valori [ISvgTSpan.Id](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgtspan/id/) sugli elementi di testo `tspan`, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assegna uno dei due controller con [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Il controller seguente utilizza [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/officeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi `tspan` di testo. Questo rende gli ID generati adatti al post-processing di una presentazione non modificata.

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

## **Aggiungi gestori di evento SVG**

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshapeformattingcontroller/), chiama [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgevent/) per aggiungere un gestore di evento JavaScript a una forma esportata. Assegna il controller con [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

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

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di evento consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.VectorizeText](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/vectorizetext/) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgexternalfontshandling/)?**

Utilizza [SVGOptions.VectorizeText](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/vectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Utilizza [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree ritagliate delle immagini e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato comportano ciascuno compromessi diversi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna gli ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post-processing o nello script del browser.