---
title: Administrar Zoom
type: docs
weight: 60
url: /es/python-net/manage-zoom/
keywords: "Zoom, marco de zoom, Agregar zoom, Formato de marco de zoom, Resumen de zoom, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar zoom o marcos de zoom a presentaciones de PowerPoint en Python"
---

## **Descripción general**
Los zooms en PowerPoint te permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando estás presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil.

![overview](overview.png)

* Para resumir toda una presentación en una sola diapositiva, utiliza un [Resumen de Zoom](#Resumen-Zoom).
* Para mostrar solo diapositivas seleccionadas, utiliza un [Zoom de Diapositivas](#Zoom-de-Diapositivas).
* Para mostrar solo una única sección, utiliza un [Zoom de Sección](#Zoom-de-Sección).

## **Zoom de Diapositivas**

Un zoom de diapositivas puede hacer que tu presentación sea más dinámica, permitiéndote navegar libremente entre diapositivas en cualquier orden que elijas sin interrumpir el flujo de tu presentación. Los zooms de diapositivas son excelentes para presentaciones cortas sin muchas secciones, pero aún puedes utilizarlos en diferentes escenarios de presentación.

Los zooms de diapositivas te ayudan a profundizar en múltiples piezas de información mientras sientes que estás en un solo lienzo.

![slidezoomsel](slidezoomsel.png)

Para los objetos de zoom de diapositivas, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), la interfaz [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) y algunos métodos en la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Creando Marcos de Zoom**
Puedes agregar un marco de zoom en una diapositiva de esta forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear nuevas diapositivas a las que planeas vincular.
3. Agregar un texto de identificación y un fondo a las diapositivas creadas.
4. Agregar marcos de zoom (que contengan las referencias a las diapositivas creadas) en la primera diapositiva.
5. Escribir la presentación modificada como un archivo PPTX.

Este código de ejemplo te muestra cómo crear un marco de zoom en una diapositiva:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar nuevas diapositivas a la presentación
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la segunda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Segunda Diapositiva"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Tercera Diapositiva"

    #Agregar objetos ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Guardar la presentación
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Creando Marcos de Zoom con Imágenes Personalizadas**
Con Aspose.Slides para Python a través de .NET, puedes crear un marco de zoom con una imagen diferente a la imagen de vista previa de la diapositiva de esta manera: 
1. Crear una instancia de la clase `Presentation`.
2. Crear una nueva diapositiva a la que planeas vincular. 
3. Agregar un texto de identificación y un fondo a la diapositiva creada.
4. Crear un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) al agregar una imagen a la colección de Imágenes asociada con el objeto Presentation que se utilizará para llenar el marco.
5. Agregar marcos de zoom (que contengan la referencia a la diapositiva creada) en la primera diapositiva.
6. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo crear un marco de zoom con una imagen diferente:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Segunda Diapositiva"

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Agregar el objeto ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formateando Marcos de Zoom**
En las secciones anteriores (arriba), te mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complicados, debes alterar el formato de los marcos. Hay varias configuraciones de formato que puedes aplicar a un marco de zoom. 

Puedes controlar el formato de un marco de zoom en una diapositiva de esta manera:

1. Crear una instancia de la clase `Presentation`.
2. Crear nuevas diapositivas para vincular.
3. Agregar texto de identificación y fondo a las diapositivas creadas.
4. Agregar marcos de zoom (que contengan las referencias a las diapositivas creadas) en la primera diapositiva.
5. Crear un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) al agregar una imagen a la colección de Imágenes asociada con el objeto Presentation que se utilizará para llenar el marco.
6. Establecer una imagen personalizada para el primer objeto de marco de zoom.
7. Cambiar el formato de línea para el segundo objeto de marco de zoom.
8. Eliminar el fondo de una imagen del segundo objeto de marco de zoom.
9. Escribir la presentación modificada como un archivo PPTX.

Este código de ejemplo en Python te muestra cómo cambiar el formato de un marco de zoom: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar nuevas diapositivas a la presentación
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la segunda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Segunda Diapositiva"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Tercera Diapositiva"

    #Agregar objetos ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Establecer una imagen personalizada para el objeto zoomFrame1
    zoomFrame1.image = image

    # Establecer un formato de marco de zoom para el objeto zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # No mostrar el fondo del objeto zoomFrame2
    zoomFrame2.show_background = False

    # Guardar la presentación
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom de Sección**

Un zoom de sección es un enlace a una sección en tu presentación. Puedes usar los zooms de sección para volver a las secciones que realmente deseas enfatizar. O puedes usarlos para resaltar cómo ciertas partes de tu presentación están conectadas.

![seczoomsel](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Creando Marcos de Zoom de Sección**

Puedes agregar un marco de zoom de sección a una diapositiva de esta forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear una nueva diapositiva.
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Agregar un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo crear un marco de zoom en una diapositiva:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Agregar una nueva Sección a la presentación
    pres.sections.add_section("Sección 1", slide)

    # Agregar un objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Creando Marcos de Zoom de Sección con Imágenes Personalizadas**

Usando Aspose.Slides para Python, puedes crear un marco de zoom de sección con una imagen diferente de esta manera: 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear una nueva diapositiva.
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Crear un objeto `IPPImage` al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para llenar el marco.
6. Agregar un marco de zoom de sección (que contenga una referencia a la sección creada) a la primera diapositiva.
7. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo crear un marco de zoom con una imagen diferente:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Agregar una nueva Sección a la presentación
    pres.sections.add_section("Sección 1", slide)

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Agregar un objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formateando Marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formateo que puedes aplicar a un marco de zoom de sección. 

Puedes controlar el formato de un marco de zoom de sección en una diapositiva de esta forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear una nueva diapositiva.
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Agregar un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6. Cambiar el tamaño y la posición del objeto de zoom de sección creado.
7. Crear un objeto `IPPImage` al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para llenar el marco.
8. Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9. Establecer la capacidad de *volver a la diapositiva original desde la sección vinculada*. 
10. Eliminar el fondo de una imagen del objeto de marco de zoom de sección.
11. Cambiar el formato de línea para el segundo objeto de marco de zoom.
12. Cambiar la duración de la transición.
13. Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo cambiar el formato de un marco de zoom de sección:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva Sección a la presentación
    pres.sections.add_section("Sección 1", slide)

    # Agregar objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formato para SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom de Resumen**

Un zoom de resumen es como una página de aterrizaje donde se muestran todas las piezas de tu presentación a la vez. Cuando estás presentando, puedes usar el zoom para ir de un lugar a otro en tu presentación en cualquier orden que desees. Puedes ser creativo, saltar hacia adelante o volver a visitar piezas de tu presentación sin interrumpir el flujo de tu presentación.

![overview_image](summaryzoom.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Creando Zoom de Resumen**

Puedes agregar un marco de zoom de resumen a una diapositiva de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar el marco de zoom de resumen a la primera diapositiva.
4. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo crear un marco de zoom de resumen en una diapositiva:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Crear matriz de diapositivas
    for slideNumber in range(5):
        #Agregar nuevas diapositivas a la presentación
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Crear un fondo para la diapositiva
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Crear un cuadro de texto para la diapositiva
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Diapositiva - {num}".format(num = (slideNumber + 2))

    # Crear objetos de zoom para todas las diapositivas en la primera diapositiva
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Establecer la propiedad ReturnToParent para volver a la primera diapositiva
        zoomFrame.return_to_parent = True

    # Guardar la presentación
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Agregando y Eliminando Secciones de Resumen de Zoom**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). Puedes agregar o eliminar un objeto de sección de resumen de zoom a través de la interfaz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar un marco de zoom de resumen en la primera diapositiva.
4. Agregar una nueva diapositiva y sección a la presentación.
5. Agregar la sección creada al marco de zoom de resumen.
6. Eliminar la primera sección del marco de zoom de resumen.
7. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo agregar y eliminar secciones en un marco de zoom de resumen:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva sección a la presentación
    pres.sections.add_section("Sección 1", slide)

    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva sección a la presentación
    pres.sections.add_section("Sección 2", slide)

    # Agregar objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva sección a la presentación
    section3 = pres.sections.add_section("Sección 3", slide)

    # Agregar una sección al zoom de resumen
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Eliminar sección del zoom de resumen
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formateando Secciones de Resumen de Zoom**

Para crear objetos de sección de resumen de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un objeto de sección de resumen de zoom. 

Puedes controlar el formato de un objeto de sección de resumen de zoom en un marco de zoom de resumen de esta forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar un marco de zoom de resumen a la primera diapositiva.
4. Obtener un objeto de sección de resumen de zoom para el primer objeto de la `ISummaryZoomSectionCollection`.
5. Crear un objeto `IPPImage` al agregar una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para llenar el marco.
6. Establecer una imagen personalizada para el objeto de sección de resumen de zoom creado.
7. Establecer la capacidad de *volver a la diapositiva original desde la sección vinculada*. 
8. Cambiar el formato de línea para el segundo objeto de marco de zoom.
9. Cambiar la duración de la transición.
10. Escribir la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo cambiar el formato de un objeto de sección de resumen de zoom:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva sección a la presentación
    pres.sections.add_section("Sección 1", slide)

    #Agregar una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Agregar una nueva sección a la presentación
    pres.sections.add_section("Sección 2", slide)

    # Agregar objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Obtener el primer objeto SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formato para el objeto SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```