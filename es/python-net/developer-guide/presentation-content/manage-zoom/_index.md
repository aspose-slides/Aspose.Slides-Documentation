---
title: Gestionar Zooms en presentaciones con Python
linktitle: Zoom
type: docs
weight: 60
url: /es/python-net/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- añadir zoom
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crea y personaliza Zoom con Aspose.Slides para Python a través de .NET — salta entre secciones, añade miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Visión general**
Los Zooms en PowerPoint le permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview](overview.png)

* Para resumir toda la presentación en una sola diapositiva, use un [Zoom de resumen](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**

Un zoom de diapositiva puede hacer que su presentación sea más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zooms de diapositiva son excelentes para presentaciones breves sin muchas secciones, pero también puede utilizarlos en diferentes escenarios de presentación.

Los zooms de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un único lienzo. 

![slidezoomsel](slidezoomsel.png)

Para objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), la clase [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) y algunos métodos en la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Creación de marcos de zoom**
Puede añadir un marco de zoom en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear nuevas diapositivas a las que pretenda enlazar. 
3.	Añadir un texto de identificación y un fondo a las diapositivas creadas.
4.	Añadir marcos de zoom (conteniendo las referencias a las diapositivas creadas) en la primera diapositiva.
5.	Escribir la presentación modificada como un archivo PPTX.

Este código de ejemplo muestra cómo crear un marco de zoom en una diapositiva:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Añadir nuevas diapositivas a la presentación
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la segunda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Añadir objetos ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Guardar la presentación
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Creación de marcos de zoom con imágenes personalizadas**
Con Aspose.Slides for Python vía .NET, puede crear un marco de zoom con una imagen distinta a la imagen de vista previa de la diapositiva de esta manera: 
1.	Crear una instancia de la clase `Presentation`.
2.	Crear una nueva diapositiva a la que pretenda enlazar. 
3.	Añadir un texto de identificación y un fondo a la diapositiva creada.
4.	Crear un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto Presentation que se utilizará para rellenar el marco.
5.	Añadir marcos de zoom (conteniendo la referencia a la diapositiva creada) en la primera diapositiva.
6.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un marco de zoom con una imagen diferente:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Añadir una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Añadir el objeto ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formato de marcos de zoom**
En las secciones anteriores (arriba), le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de los marcos. Existen varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Crear una instancia de la clase `Presentation`.
2.	Crear nuevas diapositivas a enlazar.
3.	Añadir texto de identificación y fondo a las diapositivas creadas.
4.	Añadir marcos de zoom (conteniendo las referencias a las diapositivas creadas) en la primera diapositiva.
5.	Crear un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto Presentation que se utilizará para rellenar el marco.
6.	Establecer una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
8.	Eliminar el fondo de la imagen del segundo objeto de marco de zoom.
5.	Escribir la presentación modificada como un archivo PPTX.

Este código de muestra Python muestra cómo cambiar el formato de un marco de zoom: 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Añadir nuevas diapositivas a la presentación
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crear un fondo para la segunda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crear un cuadro de texto para la segunda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    # Añadir objetos ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Establecer imagen personalizada para el objeto zoomFrame1
    zoomFrame1.image = image

    # Establecer un formato de marco de zoom para el objeto zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # No mostrar fondo para el objeto zoomFrame2
    zoomFrame2.show_background = False

    # Guardar la presentación
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Zoom de sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zooms de sección para volver a secciones que desea enfatizar realmente. O puede utilizarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![seczoomsel](seczoomsel.png)

Para objetos de zoom de sección, Aspose.Slides proporciona la clase [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Creación de marcos de zoom de sección**

Puede añadir un marco de zoom de sección a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear una nueva diapositiva. 
3.	Añadir un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Añadir un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un marco de zoom en una diapositiva:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 1", slide)

    # Añade un objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Guarda la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Creación de marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides for Python, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera: 

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear una nueva diapositiva.
3.	Añadir un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Crear un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6.	Añadir un marco de zoom de sección (conteniendo una referencia a la sección creada) a la primera diapositiva.
7.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un marco de zoom con una imagen diferente:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 1", slide)

    # Crea una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Añade un objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Guarda la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formato de marcos de zoom de sección**

Para crear marcos de zoom de sección más complejos, debe alterar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear una nueva diapositiva.
3.	Añadir fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Añadir un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Cambiar el tamaño y la posición del objeto de zoom de sección creado.
7.	Crear un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
8.	Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Eliminar el fondo de la imagen del objeto de marco de zoom de sección.
11.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
12.	Cambiar la duración de la transición.
13.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo cambiar el formato de un marco de zoom de sección:
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 1", slide)

    # Añade un objeto SectionZoomFrame
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

    # Guarda la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Zoom de resumen**

Un zoom de resumen es como una página de destino donde se muestran simultáneamente todas las piezas de su presentación. Cuando está presentando, puede usar el zoom para pasar de un lugar de la presentación a otro en cualquier orden que desee. Puede ser creativo, avanzar rápidamente o volver a visitar partes de su presentación sin interrumpir el flujo. 

![overview_image](summaryzoom.png)

Para objetos de zoom de resumen, Aspose.Slides proporciona la clase [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) y [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Creación de zoom de resumen**

Puede añadir un marco de zoom de resumen a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añadir el marco de zoom de resumen a la primera diapositiva.
4.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo crear un marco de zoom de resumen en una diapositiva:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Crear matriz de diapositivas
    for slideNumber in range(5):
        # Añadir nuevas diapositivas a la presentación
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Crear un fondo para la diapositiva
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Crear un cuadro de texto para la diapositiva
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

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


### **Añadir y eliminar secciones de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), que se almacenan en el objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/). Puede añadir o eliminar un objeto de sección de zoom de resumen a través de la clase [SummaryZoomSectionCollection]{{ }} de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añadir un marco de zoom de resumen a la primera diapositiva.
4.	Añadir una nueva diapositiva y sección a la presentación.
5.	Añadir la sección creada al marco de zoom de resumen.
6.	Eliminar la primera sección del marco de zoom de resumen.
7.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo añadir y eliminar secciones en un marco de zoom de resumen:
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 1", slide)

    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 2", slide)

    # Añade un objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    section3 = pres.sections.add_section("Section 3", slide)

    # Añade una sección al Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Elimina la sección del Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Guarda la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formato de secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe alterar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añadir un marco de zoom de resumen a la primera diapositiva.
4.	Obtener un objeto de sección de zoom de resumen del primer elemento de `SummaryZoomSectionCollection`.
5.	Crear un objeto `PPImage` añadiendo una imagen a la colección images asociada al objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6.	Establecer una imagen personalizada para el objeto de marco de sección de zoom creado.
7.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
8.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
9.	Cambiar la duración de la transición.
10.	Escribir la presentación modificada como un archivo PPTX.

Este código Python muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 1", slide)

    #Añade una nueva diapositiva a la presentación
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Añade una nueva sección a la presentación
    pres.sections.add_section("Section 2", slide)

    # Añade un objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Obtiene el primer objeto SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formato del objeto SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Guarda la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Puedo controlar el retorno a la diapositiva «padre» después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) o [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) tiene un comportamiento `return_to_parent` que, cuando está habilitado, devuelve al espectador a la diapositiva de origen después de visitar el contenido objetivo.

**¿Puedo ajustar la «velocidad» o duración de la transición del Zoom?**

Sí. El Zoom permite establecer una `transition_duration` para que pueda controlar cuánto dura la animación del salto.

**¿Existen límites sobre cuántos objetos Zoom puede contener una presentación?**

No hay un límite duro documentado en la API. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede añadir muchos marcos de Zoom, pero tenga en cuenta el tamaño del archivo y el tiempo de renderizado.