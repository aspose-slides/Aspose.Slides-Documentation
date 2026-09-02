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
description: "Exporta diapositivas de PowerPoint como imágenes SVG en Python y controla fuentes, texto e imágenes con Aspose.Slides."
---
## **Resumen**

SVG es un formato de imagen escalable basado en XML que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y el post‑procesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG separado y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en todos los navegadores o estar preparado para uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/), seleccione una diapositiva y escríbala en un flujo. El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG separado.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

El nombre del archivo utiliza [Slide.slide_number](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/slide_number/) en lugar del índice del bucle. También puede exportar una forma individual con [Shape.write_as_svg](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/write_as_svg/) cuando un visor de diapositivas o una página web necesita solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/) controla la representación SVG. Para los marcos de texto, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/use_frame_size/) incluye el marco de texto en el área de representación, y [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina si se aplica la rotación del marco. Establezca [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) en `True` cuando el texto deba renderizarse sin ligaduras.

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

## **Controlar texto y fuentes**

### **Vectorizar todo el texto**

Establezca [SVGOptions.vectorize_text](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/vectorize_text/) en `True` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más coherente entre navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Elegir cómo se manejan las fuentes externas**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utiliza un valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `ADD_LINKS_TO_FONT_FILES` para hacer referencia a archivos de fuentes separados, `EMBED` para incluir los datos de la fuente en el SVG, o `VECTORIZE` para representar solo el texto que utiliza fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

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

## **Reducir el tamaño de imágenes incrustadas**

Utilice [SVGOptions.pictures_compression](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/pictures_compression/) para reducir la resolución de las imágenes incrustadas, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) para omitir áreas recortadas de la fuente, y [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/jpeg_quality/) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

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

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions.vectorize_text](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/vectorize_text/) en lugar de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Utilice [SVGOptions.vectorize_text](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/vectorize_text/) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgexternalfontshandling/) cuando solo el texto que utiliza fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando las áreas recortadas y eligiendo archivos de fuentes vinculados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la menor resolución de la imagen, la menor calidad JPEG y el texto vectorizado tienen cada uno diferentes compromisos entre calidad y tamaño.