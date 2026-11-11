---
title: Renderizza le diapositive di presentazione come immagini SVG in .NET
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /it/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in .NET e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑produzione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e gli elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile su diversi browser o pronto per un uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Il nome file utilizza [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) invece dell'indice del ciclo. È inoltre possibile esportare una singola forma con [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) quando un visualizzatore di diapositive o una pagina web ha bisogno solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) include il riquadro di testo nell'area di rendering, e [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) su `true` quando il testo deve essere renderizzato senza legature.

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

Quando si esportano diapositive in SVG, è possibile controllare se il testo rimane testo o viene convertito in grafica vettoriale e come i caratteri esterni sono inclusi o referenziati. Le seguenti opzioni ti aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dei caratteri nell'SVG esportato.

### **Vettorizza tutto il testo**

Imposta [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per referenziare file di carattere separati, `Embed` per includere i dati del carattere nell'SVG, o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica la licenza dei caratteri prima di incorporarli.

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

## **Riduci le dimensioni delle immagini incorporate**

Usa [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) per omettere le aree ritagliate delle sorgenti e [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) per controllare la qualità di codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine mantenuti.

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

## **Controlla la risoluzione di rasterizzazione dei metafile**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) imposta il limite di risoluzione più basso per rasterizzare i metafile durante l'esportazione SVG. Usalo per bilanciare dettaglio e dimensione del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per l'SVG né costringe ogni oggetto della diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonalmente ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Tutte le altre impostazioni di esportazione rimangono identiche così da poter confrontare i risultati.

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

Nell'output, l'EMF è diventato un PNG incorporato in ciascun SVG. Le seguenti misurazioni si riferiscono alla presentazione fornita; non sono una formula generale per convertire DPI in dimensioni pixel.

| Risoluzione di rasterizzazione del metafile DPI | Dimensioni PNG incorporate | Dimensione file SVG (byte) |
|---|---|---|
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto qui sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelatura visibile a 72 DPI e bordi più lisci a risoluzioni maggiori, mentre il file SVG cresce. Aumentare il valore non migliora necessariamente ogni dettaglio né modifica ogni immagine esportata.

![Dettaglio ingrandito della linea diagonale a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) controlla la riduzione della risoluzione dell'immagine e può mascherare l'effetto della modifica della risoluzione di rasterizzazione del metafile. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) controlla la qualità di codifica JPEG, non la risoluzione di rasterizzazione del metafile.

## **Assegna ID stabili a forme e testo**

Usa [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) per impostare [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) per ogni forma SVG. Per impostare i valori di [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) sugli elementi `tspan` del testo, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assegna uno di questi controller con [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Il controller seguente utilizza [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi `tspan` di testo. Questo rende gli ID generati adatti al post‑processing di una presentazione non modificata.

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

## **Aggiungi gestori di eventi SVG**

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), chiama [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

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

La pagina host può definire la funzione JavaScript referenziata dal gestore. L'assegnazione di ID e gestori di eventi abilita visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree ritagliate e scegliendo file di carattere collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché risoluzione immagine più bassa, qualità JPEG più bassa e testo vettorizzato hanno ciascuno compromessi diversi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o script del browser.