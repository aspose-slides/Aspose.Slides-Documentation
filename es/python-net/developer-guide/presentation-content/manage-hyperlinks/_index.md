---
title: Administrar hipervínculos en presentaciones con Python
linktitle: Administrar hipervínculo
type: docs
weight: 20
url: /es/python-net/manage-hyperlinks/
keywords:
- agregar URL
- agregar hipervínculo
- crear hipervínculo
- formatear hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- hipervínculo de texto
- hipervínculo de diapositiva
- hipervínculo de forma
- hipervínculo de imagen
- hipervínculo de video
- hipervínculo mutable
- PowerPoint
- OpenDocument
- presentación
- Python
description: "Administre hipervínculos sin esfuerzo en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET—mejore la interactividad y el flujo de trabajo en minutos."
---

## **Visión general**

Un hipervínculo es una referencia a un recurso externo, un objeto o elemento de datos, o una ubicación específica dentro de un archivo. Los tipos comunes de hipervínculos en presentaciones de PowerPoint incluyen:

* Enlaces a sitios web incrustados en texto, formas o medios
* Enlaces a diapositivas

Aspose.Slides para Python mediante .NET permite una amplia gama de operaciones relacionadas con hipervínculos en presentaciones.

## **Agregar hipervínculos URL**

Esta sección explica cómo agregar hipervínculos URL a los elementos de la diapositiva al trabajar con Aspose.Slides. Cubre la asignación de direcciones de enlace a texto, formas e imágenes para garantizar una navegación fluida durante las presentaciones.

### **Agregar hipervínculos URL al texto**

El siguiente ejemplo de código muestra cómo agregar un hipervínculo a un sitio web en texto:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Agregar hipervínculos URL a formas o marcos**

El siguiente ejemplo de código muestra cómo agregar un hipervínculo a un sitio web en una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Agregar hipervínculos URL a medios**

Aspose.Slides le permite agregar hipervínculos a imágenes, archivos de audio y video.

El siguiente ejemplo de código muestra cómo agregar un hipervínculo a una **imagen**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar una imagen a la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Crear un marco de imagen en la diapositiva 1 usando la imagen agregada anteriormente.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

El siguiente ejemplo de código muestra cómo agregar un hipervínculo a un **archivo de audio**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

El siguiente ejemplo de código muestra cómo agregar un hipervínculo a un **video**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Consejo" color="primary" %}}
Puede que desee ver [Administrar OLE en presentaciones usando Python](/slides/es/python-net/manage-ole/).
{{% /alert %}}

## **Usar hipervínculos para crear una tabla de contenido**

Porque los hipervínculos le permiten referenciar objetos o ubicaciones, puede usarlos para crear una tabla de contenido.

El código de muestra a continuación muestra cómo crear una tabla de contenido con hipervínculos:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formato de hipervínculos**

Esta sección muestra cómo dar formato a la apariencia de los hipervínculos en Aspose.Slides. Aprenderá a controlar el color y otras opciones de estilo para mantener la consistencia del formato del hipervínculo en texto, formas e imágenes.

### **Color del hipervínculo**

Usando la propiedad [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) de la clase [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/), puede establecer el color de un hipervínculo y leer su información de color. Esta característica se introdujo en PowerPoint 2019, por lo que los cambios realizados a través de esta propiedad no se aplican a versiones anteriores de PowerPoint.

El siguiente ejemplo muestra cómo agregar hipervínculos con diferentes colores a la misma diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar hipervínculos de presentaciones**

Esta sección explica cómo eliminar hipervínculos de presentaciones al trabajar con Aspose.Slides. Aprenderá a borrar los destinos de enlace de texto, formas e imágenes mientras preserva el contenido y formato originales.

### **Eliminar hipervínculos del texto**

El siguiente código de ejemplo muestra cómo eliminar hipervínculos del texto en una diapositiva de presentación:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminar hipervínculos de formas o marcos**

El siguiente código de ejemplo muestra cómo eliminar hipervínculos de formas en una diapositiva de presentación:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hipervínculos mutables**

La clase [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) es mutable. Usando esta clase, puede cambiar los valores de estas propiedades:

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

El siguiente fragmento de código muestra cómo agregar un hipervínculo a una diapositiva y luego editar su información sobre herramientas:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Propiedades compatibles en IHyperlinkQueries**

Puede acceder a [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) desde la presentación, diapositiva o texto que contiene el hipervínculo.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

La clase [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) soporta estos métodos:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Puede que desee probar el sencillo y gratuito editor en línea de PowerPoint de Aspose [PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo crear una navegación interna no solo a una diapositiva, sino a una “sección” o a la primera diapositiva de una sección?**

Las secciones en PowerPoint son agrupaciones de diapositivas; la navegación técnicamente apunta a una diapositiva específica. Para “navegar a una sección”, normalmente se enlaza a su primera diapositiva.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de distribución admiten hipervínculos. dichos enlaces aparecen en las diapositivas hijas y son clicables durante la presentación.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o video?**

En [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) y [HTML](/slides/es/python-net/convert-powerpoint-to-html/), sí—los enlaces se conservan generalmente. Al exportar a [imágenes](/slides/es/python-net/convert-powerpoint-to-png/) y [video](/slides/es/python-net/convert-powerpoint-to-video/), la capacidad de hacer clic no se mantiene debido a la naturaleza de esos formatos (fotogramas rasterizados/video no admiten hipervínculos).