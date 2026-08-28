---
title: Convertir diapositivas de presentación a imágenes en Python
linktitle: Diapositiva a imagen
type: docs
weight: 41
url: /es/python-net/convert-slide/
keywords:
- convertir diapositiva
- exportar diapositiva
- diapositiva a imagen
- guardar diapositiva como imagen
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a mapa de bits
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Convertir diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en Python con Aspose.Slides."
---
## **Introducción**

Aspose.Slides for Python a través de .NET puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/).
4. Llame al método [Slide.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/). Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/).
5. Llame al método [IImage.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/save/) y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más sencilla utiliza la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en Python renderiza la primera diapositiva y la guarda como una imagen PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga de [Slide.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) que acepta un valor [Size](https://reference.aspose.com/slides/es/python-net/aspose.pydrawing/size/) para renderizar una diapositiva con dimensiones de píxeles exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Convertir diapositivas con notas y comentarios a imágenes**

Por defecto, las imágenes de diapositivas no incluyen notas ni comentarios. Asigne un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notescommentslayoutingoptions/) a la propiedad [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas debajo de la diapositiva y los comentarios a su derecha:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Para la conversión de diapositiva a imagen, no establezca la propiedad [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) a [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notespositions/). Las notas pueden contener más texto del que el tamaño fijo de la imagen puede albergar. Utilice [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Convertir todas las diapositivas a imágenes**

Itere a través de la colección de diapositivas para convertir toda la presentación en una serie de imágenes. Las diapositivas ocultas se incluyen a menos que las omita explícitamente.

El siguiente ejemplo renderiza cada diapositiva como una imagen JPEG con factores de escala horizontal y vertical de 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Crear salida de Metarchivo Mejorado**

Enhanced Metafile (EMF) es útil cuando los gráficos basados en vectores deben intercambiarse con Microsoft Office u otras aplicaciones de Windows que admiten metarchivos de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar las operaciones de dibujo vectorial que se escalan sin perder nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metarchivos de Windows, no un formato de intercambio universal. Además, el contenido complejo de las diapositivas, como imágenes de mapa de bits y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor de metarchivos vectoriales.

### **Exportar una diapositiva a EMF**

El método [Slide.write_as_emf](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/write_as_emf/) escribe una [Slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/) a un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

El llamador posee el flujo pasado a [Slide.write_as_emf](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/write_as_emf/) y debe cerrarlo. Aspose.Slides escribe en la posición actual del flujo y lo deja abierto.

### **Convertir una imagen SVG a EMF y agregarla a una presentación**

Utilice [SvgImage.write_as_emf](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/write_as_emf/) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación a través de [ImageCollection.add_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/add_image/) y colocarse en una diapositiva con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/).

El siguiente ejemplo crea una [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/) a partir de marcado SVG, lo convierte a un EMF en memoria, inserta el metarchivo en la primera diapositiva y guarda la presentación:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/write_as_emf/) no toma posesión del flujo de destino. Después de escribir, la posición del flujo está al final de los datos generados. Llame a `getvalue` para obtener el búfer completo sin importar la posición actual del flujo, como se muestra arriba. Mantenga el flujo abierto hasta que los datos se hayan leído y ciérrelo después.

La generación de EMF está disponible en los sistemas operativos compatibles con Aspose.Slides for Python a través de .NET, pero la renderización puede variar entre plataformas cuando faltan fuentes o dependencias gráficas nativas. Instale las fuentes utilizadas por el contenido de origen o configure sustituciones adecuadas, siga los [platform requirements](/slides/es/python-net/system-requirements/) de Aspose.Slides y valide el resultado en la aplicación receptora de EMF. Las aplicaciones en Linux y macOS a menudo tienen soporte limitado o inconsistente para mostrar y editar metarchivos de Windows.

## **Renderizado de Emoji a Color**

{{% alert title="Note" color="info" %}}
Para renderizar correctamente los emojis a color al convertir diapositivas de presentación a imágenes, las fuentes de emojis utilizadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación usa **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes de salida.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite la renderización de diapositivas con animaciones?**

No. El método [Slide.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar las diapositivas ocultas como imágenes?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de las diapositivas?**

Sí. Aspose.Slides renderiza sombras, transparencias y otros efectos gráficos compatibles en las imágenes de las diapositivas.