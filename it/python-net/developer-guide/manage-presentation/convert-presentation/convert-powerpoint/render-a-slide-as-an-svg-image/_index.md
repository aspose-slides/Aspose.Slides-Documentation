---
title: "Esporta le diapositive di presentazione come immagini SVG in Python"
linktitle: "Diapositiva in SVG"
type: docs
weight: 50
url: /it/python-net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint in SVG"
- "presentazione in SVG"
- "diapositiva in SVG"
- "PPT in SVG"
- "PPTX in SVG"
- "opzioni di esportazione SVG"
- "PowerPoint"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Esporta le diapositive PowerPoint come immagini SVG in Python e controlla caratteri, testo e immagini con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatizzata post‑produzione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come testo, caratteri, immagini e elementi SVG vengono scritti.

Usa [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) quando il SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Il nome file utilizza [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) anziché l'indice del ciclo. È inoltre possibile esportare una singola forma con [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) quando un visualizzatore di diapositive o una pagina web necessita solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) include il riquadro di testo nell'area di rendering, e [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina se la rotazione del riquadro viene applicata. Imposta [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) su `True` quando il testo deve essere renderizzato senza legature.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Controlla testo e caratteri**

Durante l'esportazione delle diapositive in SVG, è possibile controllare se il testo rimane come testo o viene convertito in grafica vettoriale, e come i caratteri esterni sono inclusi o riferiti. Le opzioni seguenti aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dei caratteri nello SVG esportato.

### **Vettorializza tutto il testo**

Imposta [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) su `True` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `ADD_LINKS_TO_FONT_FILES` per fare riferimento a file di caratteri separati, `EMBED` per includere i dati dei caratteri nel SVG, o `VECTORIZE` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Riduci le dimensioni delle immagini incorporate**

Usa [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) per omettere le aree ritagliate dell'origine, e [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) per controllare la qualità di codifica JPEG. Queste impostazioni riducono la dimensione del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Controlla la risoluzione di rasterizzazione dei metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) imposta il limite inferiore di risoluzione per la rasterizzazione dei metafile durante l'esportazione SVG. Usalo per bilanciare i dettagli e la dimensione del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per lo SVG né costringe ogni oggetto sulla diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali strettamente ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tutte le altre impostazioni di esportazione rimangono identiche affinché i risultati possano essere confrontati.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Nell'output, l'EMF è diventato un PNG incorporato in ogni SVG. Le seguenti misurazioni sono per la presentazione fornita; non costituiscono una formula generale per convertire DPI in dimensioni pixel.

| DPI rasterizzazione metafile | Dimensioni PNG incorporato | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto qui sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelatura evidente a 72 DPI e bordi più regolari a risoluzioni più elevate, mentre il file SVG cresce. Aumentare il valore non migliora necessariamente ogni dettaglio né modifica ogni immagine esportata.

![Dettaglio ingrandito della linea diagonale a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) controlla la riduzione della risoluzione dell'immagine e può mascherare l'effetto della modifica della risoluzione di rasterizzazione del metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) controlla la qualità di codifica JPEG, non la risoluzione di rasterizzazione del metafile.

## **FAQ**

**Quando dovrei usare [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) invece di [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché la riduzione della risoluzione dell'immagine, la qualità JPEG più bassa e il testo vettorializzato comportano ciascuno compromessi diversi tra qualità e dimensione.