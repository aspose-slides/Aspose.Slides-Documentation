---
title: Genera diapositive della presentazione come immagini SVG in Python
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /it/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentazione a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opzioni di esportazione SVG
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in Python e controlla i font, il testo e le immagini con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑produzione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come testo, caratteri, immagini e elementi SVG vengono scritti.

Usa [SVGOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), seleziona una diapositiva e scrivila in un flusso. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Il nome file utilizza [Slide.slide_number](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_number/) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [Shape.write_as_svg](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) quando un visualizzatore di diapositive o una pagina web richiede solo quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/use_frame_size/) include il riquadro di testo nell'area di rendering e [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) su `True` quando il testo deve essere renderizzato senza legature.

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

### **Vettorizza tutto il testo**

Imposta [SVGOptions.vectorize_text](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/vectorize_text/) su `True` per scrivere tutto il testo della diapositiva come grafica vettoriale. Ciò elimina le dipendenze dei caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `ADD_LINKS_TO_FONT_FILES` per fare riferimento a file di caratteri separati, `EMBED` per includere i dati dei caratteri nell'SVG o `VECTORIZE` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

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

Usa [SVGOptions.pictures_compression](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/pictures_compression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) per omettere le aree ritagliate delle sorgenti e [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/jpeg_quality/) per controllare la qualità della codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **FAQ**

**Quando dovrei usare [SVGOptions.vectorize_text](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/vectorize_text/) invece di [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions.vectorize_text](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/vectorize_text/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere più piccolo un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato hanno ciascuno compromessi differenti in termini di qualità e dimensione.