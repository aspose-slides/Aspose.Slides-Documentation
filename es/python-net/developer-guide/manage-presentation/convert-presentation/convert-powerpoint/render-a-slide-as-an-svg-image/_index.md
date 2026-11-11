---
title: Renderizar diapositivas de presentación como imágenes SVG en Python
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Exportar diapositivas de PowerPoint como imágenes SVG en Python y controlar fuentes, texto e imágenes con Aspose.Slides."
---
## **Descripción general**

SVG es un formato de imagen escalable basado en XML que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y post‑procesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG independiente y permite controlar cómo se escribe el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en distintos navegadores o listo para su uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), seleccione una diapositiva y escríbala en un flujo. El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG independiente.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

El nombre de archivo usa [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) en lugar del índice del bucle. También puede exportar una forma individual con [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) cuando un visor de diapositivas o una página web necesite solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) controla la renderización SVG. Para marcos de texto, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) incluye el marco de texto en el área de renderizado, y [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina si se aplica la rotación del marco. Establezca [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) en `True` cuando el texto deba renderizarse sin ligaduras.

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

## **Controlar el recorte del extremo de la línea en las puntas de flecha**

SVG 1.1 no tiene una configuración de inserción de marcador para especificar dónde debe detenerse una línea bajo una punta de flecha. De forma predeterminada, Aspose.Slides acorta la línea exportada para que su trazo no sobresalga del marcador. Establezca [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) en `True` para dibujar el trazo hasta el punto final original de la línea. Esta configuración afecta solo a la salida SVG. La línea conserva su posición y longitud en la diapositiva.

El ejemplo dibuja puntas de flecha triangulares y de diamante en líneas de 2 y 10 puntos de grosor. Exporta la misma diapositiva dos veces, cambiando solo la opción de recorte.

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

La comparación muestra la punta triangular en la línea de 10 puntos. Con el recorte habilitado, la punta es afilada. Con el recorte deshabilitado, el trazo sobresale por los lados inclinados del marcador y deja un extremo plano.

![Triángulo de 10 puntos ampliado con una punta afilada cuando el recorte está habilitado y un extremo plano cuando el recorte está deshabilitado](line-end-cropping.png)

En el resto de líneas del ejemplo, el trazo sobresaliente es menos visible en el triángulo de 2 puntos. El diamante relleno cubre el extremo del trazo en ambos grosores.

## **Controlar texto y fuentes**

Al exportar diapositivas a SVG, puede controlar si el texto permanece como texto o se convierte en gráficos vectoriales, y cómo se incluyen o hacen referencia a las fuentes externas. Las siguientes opciones le ayudan a equilibrar la consistencia visual, la selección de texto y las dependencias de fuentes en el SVG exportado.

### **Vectorizar todo el texto**

Establezca [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) en `True` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina dependencias de fuentes y hace que el resultado visual sea más consistente entre navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Elegir cómo se gestionan las fuentes externas**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utiliza un valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `ADD_LINKS_TO_FONT_FILES` para referenciar archivos de fuentes separados, `EMBED` para incluir los datos de la fuente en el SVG, o `VECTORIZE` para renderizar solo el texto que usa fuentes externas como gráficos. Verifique la licencia de la fuente antes de incrustarla.

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

## **Reducir el tamaño de las imágenes incrustadas**

Utilice [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) para reducir la resolución de las imágenes incrustadas, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) para omitir áreas de origen recortadas y [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

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

## **Controlar la resolución de rasterización de metarchivos**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) establece el límite inferior de resolución para rasterizar metarchivos durante la exportación a SVG. Úselo para equilibrar detalle y tamaño del archivo cuando una imagen EMF o WMF se rasteriza. No define un DPI global para el SVG ni obliga a que cada objeto de la diapositiva se convierta en una imagen rasterizada.

Descargue [metafile-rasterization.pptx](metafile-rasterization.pptx), que contiene una imagen EMF con líneas diagonales muy cercanas. El siguiente ejemplo exporta su primera diapositiva a tres resoluciones de rasterización mediante [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Todas las demás configuraciones de exportación permanecen idénticas para que los resultados puedan compararse.

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

En la salida, el EMF se convierte en un PNG incrustado en cada SVG. Las siguientes mediciones corresponden a la presentación suministrada; no constituyen una fórmula general para convertir DPI a dimensiones en píxeles.

| DPI de rasterización del metarchivo | Dimensiones del PNG incrustado | Tamaño del archivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparación a continuación muestra la misma zona del raster incrustado con el mismo tamaño de visualización ampliado. Las líneas diagonales presentan pixelación visible a 72 DPI y bordes más suaves a resoluciones mayores, mientras el archivo SVG aumenta. Incrementar el valor no mejora necesariamente cada detalle ni cambia cada imagen exportada.

![Detalle ampliado de línea diagonal a 72, 150 y 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) controla la reducción de la resolución de la imagen y puede enmascarar el efecto de cambiar la resolución de rasterización del metarchivo. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) controla la calidad de codificación JPEG, no la resolución de rasterización del metarchivo.

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) en lugar de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Utilice [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) cuando solo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Empiece comprimiendo las imágenes incrustadas, eliminando áreas de imagen recortadas y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque una resolución de imagen menor, una calidad JPEG más baja y el texto vectorizado tienen diferentes compromisos de calidad y tamaño.