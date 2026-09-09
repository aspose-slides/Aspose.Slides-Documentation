---
title: Gestionar Zoom de Presentación en Python vía Java
linktitle: Gestionar Zoom
type: docs
weight: 60
url: /es/python-java/manage-zoom/
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
- Java
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para Python vía Java — pasar entre secciones, añadir miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---
## **Introducción**

Los Zoom en PowerPoint le permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente a través del contenido puede resultar muy útil.

![overview_image](overview.png)

* Para resumir toda una presentación en una sola diapositiva, use un [Resumen Zoom](#summary-zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de Diapositiva](#slide-zoom).
* Para mostrar solo una sección, use un [Zoom de Sección](#section-zoom).

## **Zoom de Diapositiva**
Un zoom de diapositiva puede hacer su presentación más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zooms de diapositiva son excelentes para presentaciones cortas sin muchas secciones, pero también puede utilizarlos en diferentes escenarios de presentación.

Los zooms de diapositiva le ayudan a profundizar en múltiples fragmentos de información mientras siente que está en un único lienzo.

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomimagetype/), la clase [ZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomframe/) y algunos métodos en la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).

### **Crear Marcos de Zoom**

Puede añadir un marco de zoom en una diapositiva de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree nuevas diapositivas a las que pretenda enlazar los marcos de zoom.
3. Añada texto identificativo y fondo a las diapositivas creadas.
4. Añada marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo crear un marco de zoom en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Añade nuevas diapositivas a la presentación
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea un fondo para la segunda diapositiva
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea un cuadro de texto para la segunda diapositiva
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea un fondo para la tercera diapositiva
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crea un cuadro de texto para la tercera diapositiva
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Añade objetos ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Crear Marcos de Zoom con Imágenes Personalizadas**
Con Aspose.Slides for Python via Java, puede crear un marco de zoom con una imagen de vista previa de diapositiva distinta de esta forma:
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree una nueva diapositiva a la que pretenda enlazar el marco de zoom.
3. Añada texto identificativo y fondo a la diapositiva.
4. Cree un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) añadiendo una imagen a la colección de imágenes asociada al objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que se utilizará para rellenar el marco.
5. Añada marcos de zoom (conteniendo la referencia a la diapositiva creada) a la primera diapositiva.
6. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo crear un marco de zoom con una imagen diferente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea un fondo para la segunda diapositiva
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea un cuadro de texto para la segunda diapositiva
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea una nueva imagen para el objeto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Añade el objeto ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formato de los Marcos de Zoom**
En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom.

Puede controlar el formato de un marco de zoom en una diapositiva de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree nuevas diapositivas a las que pretenda enlazar los marcos de zoom.
3. Añada texto identificativo y fondo a las diapositivas creadas.
4. Añada marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5. Cree un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) añadiendo una imagen a la colección de imágenes asociada al objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6. Establezca una imagen personalizada para el primer objeto de marco de zoom.
7. Cambie el formato de línea del segundo objeto de marco de zoom.
8. Elimine el fondo de la imagen del segundo objeto de marco de zoom.
9. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo cambiar el formato de un marco de zoom en una diapositiva:

```python
import jpype
import asposeslides

if not jp_runtime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Añade nuevas diapositivas a la presentación
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea un fondo para la segunda diapositiva
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea un cuadro de texto para la segunda diapositiva
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea un fondo para la tercera diapositiva
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crea un cuadro de texto para la tercera diapositiva
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Añade objetos ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Crea una nueva imagen para el objeto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Establece una imagen personalizada para el objeto first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Establece un formato de marco de zoom para el objeto second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Configuración para no mostrar el fondo del objeto second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom de Sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zooms de sección para volver a secciones que desea enfatizar realmente. O puede utilizarlos para resaltar cómo ciertos fragmentos de su presentación se conectan.

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la clase [SectionZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/sectionzoomframe/) y algunos métodos en la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).

### **Crear Marcos de Zoom de Sección**

Puede añadir un marco de zoom de sección a una diapositiva de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree una nueva diapositiva.
3. Añada un fondo distintivo a la diapositiva creada.
4. Cree una nueva sección a la que pretenda enlazar el marco de zoom.
5. Añada un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo crear un marco de zoom en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    #  Añade un objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Crear Marcos de Zoom de Sección con Imágenes Personalizadas**

Usando Aspose.Slides for Python via Java, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva distinta de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree una nueva diapositiva.
3. Añada un fondo distintivo a la diapositiva creada.
4. Cree una nueva sección a la que pretenda enlazar el marco de zoom.
5. Cree un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) añadiendo una imagen a la colección de imágenes asociada al objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6. Añada un marco de zoom de sección (conteniendo una referencia a la sección creada) a la primera diapositiva.
7. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo crear un marco de zoom con una imagen diferente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    #  Crea una nueva imagen para el objeto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Añade un objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formato de los Marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complicados, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección.

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree una nueva diapositiva.
3. Añada un fondo distintivo a la diapositiva creada.
4. Cree una nueva sección a la que pretenda enlazar el marco de zoom.
5. Añada un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6. Cambie el tamaño y la posición del objeto de zoom de sección creado.
7. Cree un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) añadiendo una imagen a la colección de imágenes asociada al objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que se utilizará para rellenar el marco.
8. Establezca una imagen personalizada para el objeto de zoom de sección creado.
9. Active la capacidad de *volver a la diapositiva original desde la sección enlazada*.
10. Elimine el fondo de la imagen del objeto de zoom de sección.
11. Cambie el formato de línea del objeto de zoom de sección.
12. Cambie la duración de la transición.
13. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo cambiar el formato de un marco de zoom de sección:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    #  Añade un objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formato para SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Resumen Zoom**

Un resumen Zoom es como una página de inicio donde se muestran todos los fragmentos de su presentación a la vez. Cuando está presentando, puede usar el zoom para pasar de un punto de su presentación a otro en cualquier orden que desee. Puede ser creativo, avanzar rápidamente o volver a visitar partes de su presentación sin interrumpir el flujo de la misma.

![overview_image](sumzoomsel.png)

Para los objetos de resumen Zoom, Aspose.Slides proporciona las clases [SummaryZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsection/) y [SummaryZoomSectionCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsectioncollection/), así como algunos métodos en la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).

### **Crear un Resumen Zoom**

Puede añadir un marco de resumen zoom a una diapositiva de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree nuevas diapositivas con un fondo distintivo y nuevas secciones para las diapositivas creadas.
3. Añada el marco de resumen zoom a la primera diapositiva.
4. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo crear un marco de resumen zoom en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 2", slide)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 3", slide)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 4", slide)

    #  Añade un objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Añadir y Eliminar una Sección de Resumen Zoom**

Todas las secciones en un marco de resumen zoom están representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsection/), que se almacenan en el objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsectioncollection/). Puede añadir o eliminar un objeto de sección de resumen zoom a través de la clase [SummaryZoomSectionCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsectioncollection/) de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree nuevas diapositivas con un fondo distintivo y nuevas secciones para las diapositivas creadas.
3. Añada un marco de resumen zoom en la primera diapositiva.
4. Añada una nueva diapositiva y sección a la presentación.
5. Añada la sección creada al marco de resumen zoom.
6. Elimine la primera sección del marco de resumen zoom.
7. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo añadir y eliminar secciones en un marco de resumen zoom:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 2", slide)

    #  Añade un objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Añade una sección al Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Elimina la sección del Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formato de las Secciones de Resumen Zoom**

Para crear objetos de sección de resumen zoom más complicados, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un objeto de sección de resumen zoom.

Puede controlar el formato de un objeto de sección de resumen zoom en un marco de resumen zoom de esta forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Cree nuevas diapositivas con un fondo distintivo y nuevas secciones para las diapositivas creadas.
3. Añada un marco de resumen zoom a la primera diapositiva.
4. Obtenga el primer objeto de sección de resumen zoom de la [SummaryZoomSectionCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Cree un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) añadiendo una imagen a la colección de imágenes asociada al objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que se utilizará para rellenar el marco.
6. Establezca una imagen personalizada para el objeto de sección de resumen zoom.
7. Active la capacidad de *volver a la diapositiva original desde la sección enlazada*.
8. Cambie el formato de línea del objeto de sección de resumen zoom.
9. Cambie la duración de la transición.
10. Guarde la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo cambiar el formato de un objeto de sección de resumen zoom:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 1", slide)

    # Añade una nueva diapositiva a la presentación
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Añade una nueva sección a la presentación
    presentation.getSections().addSection("Section 2", slide)

    #  Añade un objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Obtiene el primer objeto SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formato para el objeto SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Guarda la presentación
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo controlar el regreso a la diapositiva “principal” después de mostrar el objetivo?**

Sí. El [ZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomframe/) o el [SectionZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/sectionzoomframe/) admite volver a la diapositiva de origen mediante [setReturnToParent](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomobject/#setReturnToParent), que envía a los espectadores de vuelta después de que visiten el contenido objetivo cuando está habilitado.

**¿Puedo ajustar la “velocidad” o duración de la transición de Zoom?**

Sí. Zoom permite establecer una duración de transición con [setTransitionDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomobject/#setTransitionDuration) para que pueda controlar cuánto tiempo tarda la animación del salto.

**¿Existen límites en la cantidad de objetos Zoom que puede contener una presentación?**

No hay un límite duro de API documentado. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede añadir muchos marcos de Zoom, pero tenga en cuenta el tamaño del archivo y el tiempo de renderizado.