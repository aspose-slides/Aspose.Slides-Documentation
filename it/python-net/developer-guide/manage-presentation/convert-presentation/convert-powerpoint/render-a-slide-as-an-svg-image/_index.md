---
title: Renderizza le diapositive di presentazione come immagini SVG in Python
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /it/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in Python e controlla caratteri, testo e immagini con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post-pubblicazione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e elementi SVG.

Usa [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) quando il file SVG esportato deve essere compatto, prevedibile su tutti i browser o pronto per un uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Il nome file usa [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) invece dell'indice del ciclo. È inoltre possibile esportare una forma individuale con [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) quando un visualizzatore di diapositive o una pagina web richiede solo quella forma.

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

## **Controlla il ritaglio delle estremità delle linee alle punte delle frecce**

SVG 1.1 non dispone di un'impostazione di inserimento del marcatore per specificare dove una linea deve fermarsi sotto una punta di freccia. Per impostazione predefinita, Aspose.Slides accorcia la linea esportata affinché il tratto non sporga attraverso il marcatore. Imposta [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) su `True` per disegnare il tratto fino all'estremità originale della linea. Questa impostazione influisce solo sull'output SVG. La linea mantiene la sua posizione e lunghezza nella diapositiva.

L'esempio disegna punte di freccia a triangolo e a diamante su linee larghe 2 e 10 punti. Esporta la stessa diapositiva due volte, modificando solo l'opzione di ritaglio.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Il confronto mostra la punta di freccia triangolare sulla linea da 10 punti. Con il ritaglio abilitato, la punta è affilata. Con il ritaglio disabilitato, il tratto sporge attraverso i lati inclinati del marcatore e lascia un'estremità piatta.

![Triangolo da 10 punti ingrandito con punta affilata quando il ritaglio è abilitato e estremità piatta quando il ritaglio è disabilitato](line-end-cropping.png)

Nelle altre linee dell'esempio, il tratto sporgente è meno visibile sul triangolo da 2 punti. Il diamante riempito copre l'estremità del tratto in entrambe le larghezze.

## **Controlla testo e caratteri**

Durante l'esportazione delle diapositive in SVG, è possibile controllare se il testo rimane come testo o viene convertito in grafica vettoriale, e come i caratteri esterni vengono inclusi o referenziati. Le opzioni seguenti ti aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dai caratteri nel file SVG esportato.

### **Vettorializza tutto il testo**

Imposta [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) su `True` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente su tutti i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `ADD_LINKS_TO_FONT_FILES` per referenziare file di carattere separati, `EMBED` per includere i dati del carattere nell'SVG, o `VECTORIZE` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

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

## **Riduci la dimensione delle immagini incorporate**

Usa [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) per omettere le aree di origine ritagliate e [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) per controllare la qualità di codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **Controlla la risoluzione di rasterizzazione dei Metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) imposta il limite inferiore di risoluzione per la rasterizzazione dei metafile durante l'esportazione SVG. Usalo per bilanciare i dettagli e le dimensioni del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per l'SVG né costringe ogni oggetto nella diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali molto ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tutte le altre impostazioni di esportazione rimangono identiche così i risultati possono essere confrontati.

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

Nel risultato, l'EMF è diventato un PNG incorporato in ogni SVG. Le misurazioni seguenti si riferiscono alla presentazione fornita; non costituiscono una formula generale per convertire DPI in dimensioni dei pixel.

| DPI rasterizzazione Metafile | Dimensioni PNG incorporate | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelazione visibile a 72 DPI e bordi più lisci a risoluzioni più alte, mentre il file SVG aumenta. Incrementare il valore non migliora necessariamente ogni dettaglio né modifica ogni immagine esportata.

![Dettaglio della linea diagonale ingrandito a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) controlla la riduzione della risoluzione delle immagini e può mascherare l'effetto della modifica della risoluzione di rasterizzazione dei metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) controlla la qualità di codifica JPEG, non la risoluzione di rasterizzazione dei metafile.

## **FAQ**

**Quando dovrei usare [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) invece di [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di carattere collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorializzato hanno ciascuno compromessi diversi tra qualità e dimensione.