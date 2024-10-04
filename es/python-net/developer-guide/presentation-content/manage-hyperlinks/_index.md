---
title: Gestionar hipervínculos
type: docs
weight: 20
url: /python-net/manage-hyperlinks/
keywords: "Agregar hipervínculo, Presentación de PowerPoint, Hipervínculo de PowerPoint, hipervínculo de texto, hipervínculo de diapositiva, hipervínculo de forma, hipervínculo de imagen, hipervínculo de video, Python"
description: "Agregar hipervínculo a una presentación de PowerPoint en Python"
---

Un hipervínculo es una referencia a un objeto o datos o un lugar en algo. Estos son hipervínculos comunes en presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides para Python a través de .NET te permite realizar muchas tareas que involucran hipervínculos en presentaciones. 

{{% alert color="primary" %}} 

Es posible que desees ver el [editor de PowerPoint en línea simple y gratuito de Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Agregar hipervínculos URL**

### **Agregar hipervínculos URL a textos**

Este código en Python te muestra cómo agregar un hipervínculo de sitio web a un texto:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: API de formatos de archivo")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Agregar hipervínculos URL a formas o marcos**

Este código de ejemplo en Python te muestra cómo agregar un hipervínculo de sitio web a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Agregar hipervínculos URL a medios**

Aspose.Slides te permite agregar hipervínculos a imágenes, archivos de audio y video. 

Este código de ejemplo te muestra cómo agregar un hipervínculo a una **imagen**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Agrega imagen a la presentación
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # Crea un marco de imagen en la diapositiva 1 basado en la imagen añadida previamente
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 Este código de ejemplo te muestra cómo agregar un hipervínculo a un **archivo de audio**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 Este código de ejemplo te muestra cómo agregar un hipervínculo a un **video**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="Consejo"  color="primary"  %}} 

Quizás quieras ver *[Gestionar OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*.

{{% /alert %}}



## **Usar hipervínculos para crear una tabla de contenido**

Dado que los hipervínculos te permiten agregar referencias a objetos o lugares, puedes usarlos para crear una tabla de contenido. 

Este código de ejemplo te muestra cómo crear una tabla de contenido con hipervínculos:

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
    paragraph.text = "Título de la diapositiva 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "Página 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **Formato de hipervínculos**

### **Color**

Con la propiedad [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) en la interfaz [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/), puedes establecer el color para los hipervínculos y también obtener la información de color de los hipervínculos. Esta característica se introdujo por primera vez en PowerPoint 2019, por lo que los cambios que involucran la propiedad no se aplican a versiones más antiguas de PowerPoint.

Este código de ejemplo muestra una operación donde se agregaron hipervínculos con diferentes colores en la misma diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Este es un ejemplo de hipervínculo coloreado.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("Este es un ejemplo de hipervínculo habitual.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **Eliminar hipervínculos en presentaciones**

### **Eliminar hipervínculos de textos**

Este código en Python te muestra cómo eliminar el hipervínculo de un texto en una diapositiva de presentación:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminar hipervínculos de formas o marcos**

Este código en Python te muestra cómo eliminar el hipervínculo de una forma en una diapositiva de presentación: 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **Hipervínculo mutable**

La clase [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) es mutable. Con esta clase, puedes cambiar los valores de estas propiedades:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

El fragmento de código te muestra cómo agregar un hipervínculo a una diapositiva y editar su tooltip más tarde:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: API de formatos de archivo")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Más del 70% de las empresas Fortune 100 confían en las API de Aspose."
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Propiedades compatibles en IHyperlinkQueries**

Puedes acceder a IHyperlinkQueries desde una presentación, diapositiva o texto para el cual se define el hipervínculo. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

La clase IHyperlinkQueries admite estos métodos y propiedades: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)