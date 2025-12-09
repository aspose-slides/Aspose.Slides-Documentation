---
title: Administrar Zooms en Presentaciones con Python
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
- agregar zoom
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para Python a través de .NET — saltar entre secciones, agregar miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Visión general**
Los Zoom en PowerPoint le permiten saltar a y desde diapositivas específicas, secciones y partes de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview](overview.png)

* Para resumir toda una presentación en una sola diapositiva, use un [Zoom de resumen](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**

Un zoom de diapositiva puede hacer que su presentación sea más dinámica, permitiendo navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los Zoom de diapositiva son excelentes para presentaciones breves sin muchas secciones, pero aún puede utilizarlos en diferentes escenarios de presentación.

Los Zoom de diapositiva le ayudan a profundizar en múltiples fragmentos de información mientras siente que está en un solo lienzo. 

![slidezoomsel](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), la interfaz [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) y algunos métodos en la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Crear marcos de zoom**
Puede agregar un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree nuevas diapositivas a las que desea enlazar. 
3.	Agregue un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contengan las referencias a las diapositivas creadas) en la primera diapositiva.
5.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.text_frame.text = "Second Slide"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Agregar objetos ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Guardar la presentación
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Crear marcos de zoom con imágenes personalizadas**
Con Aspose.Slides para Python vía .NET, puede crear un marco de zoom con una imagen distinta a la imagen de vista previa de la diapositiva de esta manera: 
1.	Cree una instancia de la clase `Presentation`.
2.	Cree una nueva diapositiva a la que desea enlazar. 
3.	Agregue un texto de identificación y un fondo a la diapositiva creada.
4.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) añadiendo una imagen a la colección Images asociada con el objeto Presentation que se utilizará para rellenar el marco.
5.	Agregue marcos de zoom (que contengan la referencia a la diapositiva creada) en la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.text_frame.text = "Second Slide"

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Agregar el objeto ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Guardar la presentación
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formato de marcos de zoom**
En las secciones anteriores (arriba), le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe modificar el formato de los marcos. Hay varios ajustes de formato que puede aplicar a un marco de zoom.

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase `Presentation`.
2.	Cree nuevas diapositivas a las que enlazar.
3.	Agregue un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contengan las referencias a las diapositivas creadas) en la primera diapositiva.
5.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) añadiendo una imagen a la colección Images asociada con el objeto Presentation que se utilizará para rellenar el marco.
6.	Establezca una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambie el formato de línea para el segundo objeto de marco de zoom.
8.	Elimine el fondo de la imagen del segundo objeto de marco de zoom.
9.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.text_frame.text = "Second Slide"

    # Crear un fondo para la tercera diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crear un cuadro de texto para la tercera diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Agregar objetos ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Crear una nueva imagen para el objeto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Establecer imagen personalizada para el objeto zoomFrame1
    zoomFrame1.image = image

    # Establecer formato de marco de zoom para el objeto zoomFrame2
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

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zoom de sección para volver a las secciones que desea enfatizar realmente. O puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![seczoomsel](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Crear marcos de zoom de sección**

Puede agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree una nueva diapositiva. 
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que desea enlazar el marco de zoom.
5.	Agregue un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

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


### **Crear marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para Python, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera: 

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que desea enlazar el marco de zoom.
5.	Cree un objeto `IPPImage` añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6.	Agregue un marco de zoom de sección (que contenga una referencia a la sección creada) a la primera diapositiva.
7.	Guarde la presentación modificada como un archivo PPTX.

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

Para crear marcos de zoom de sección más complejos, debe modificar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un marco de zoom de sección.

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que desea enlazar el marco de zoom.
5.	Agregue un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Cambie el tamaño y la posición del objeto de zoom de sección creado.
7.	Cree un objeto `IPPImage` añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*.
10.	Elimine el fondo de la imagen del objeto de marco de zoom de sección.
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Guarde la presentación modificada como un archivo PPTX.

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

    # Añade el objeto SectionZoomFrame
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

Un zoom de resumen es como una página de inicio donde se muestran todas las partes de su presentación a la vez. Cuando está presentando, puede usar el zoom para ir de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, avanzar rápidamente o volver a visitar partes de su presentación sin interrumpir el flujo de la presentación.

![overview_image](summaryzoom.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Crear zoom de resumen**

Puede agregar un marco de zoom de resumen a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue el marco de zoom de resumen a la primera diapositiva.
4.	Guarde la presentación modificada como un archivo PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Crear arreglo de diapositivas
    for slideNumber in range(5):
        #Agregar nuevas diapositivas a la presentación
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


### **Agregar y eliminar secciones de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomFrameSection], que se almacenan en el objeto [ISummaryZoomSectionCollection]. Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la interfaz [ISummaryZoomSectionCollection] de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Agregue una nueva diapositiva y sección a la presentación.
5.	Agregue la sección creada al marco de zoom de resumen.
6.	Elimine la primera sección del marco de zoom de resumen.
7.	Guarde la presentación modificada como un archivo PPTX.

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

    # Añade el objeto SummaryZoomFrame
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

Para crear objetos de sección de zoom de resumen más complejos, debe modificar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen.

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Obtenga un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
5.	Cree un objeto `IPPImage` añadiendo una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
7.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*.
8.	Cambie el formato de línea para el segundo objeto de marco de zoom.
9.	Cambie la duración de la transición.
10.	Guarde la presentación modificada como un archivo PPTX.

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

    # Formato para el objeto SummaryZoomSection
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


## **Preguntas frecuentes**

**¿Puedo controlar el regreso a la diapositiva 'padre' después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) tiene un comportamiento `return_to_parent` que, cuando está habilitado, devuelve a los espectadores a la diapositiva de origen después de que visiten el contenido objetivo.

**¿Puedo ajustar la 'velocidad' o duración de la transición del Zoom?**

Sí. Zoom permite establecer un `transition_duration` para que pueda controlar cuánto dura la animación de salto.

**¿Existen límites en la cantidad de objetos Zoom que puede contener una presentación?**

No hay un límite estricto de API documentado. Los límites prácticos dependen de la complejidad total de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero debe considerar el tamaño del archivo y el tiempo de renderizado.