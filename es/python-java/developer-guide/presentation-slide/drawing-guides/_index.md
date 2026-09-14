---
title: Gestionar guías de dibujo en presentaciones en Python
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/python-java/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folletos
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint usando Aspose.Slides para Python a través de Java."
---
## **Visión general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma consistente mientras editan una presentación en PowerPoint. Son especialmente útiles cuando una aplicación genera una presentación que luego será refinada manualmente: la aplicación puede guardar los mismos auxiliares de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación o en la salida renderizada. Aspose.Slides for Python via Java las expone a través de la clase [DrawingGuidesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/). Una guía está representada por [DrawingGuide](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o maestro correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Añadir guías a la vista de diapositiva**

Utilice [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/es/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [DrawingGuidesCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/#add) con un valor de [Orientation](https://reference.aspose.com/slides/es/python-java/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a las guías de dibujo**

Los métodos [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/#getCount) y [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/#get_Item) proporcionan acceso a las guías existentes. Los métodos [DrawingGuide.getOrientation](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguide/#getPosition) y [DrawingGuide.getColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguide/#getColor) devuelven valores que también pueden modificarse mediante los métodos setter correspondientes.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada anteriormente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Añadir guías a la diapositiva maestra y a las diapositivas de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getDrawingGuides) para una diapositiva maestra y [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getDrawingGuides) para una diapositiva de diseño.

El siguiente ejemplo añade una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir guías a los maestros de notas y de folletos**

Los maestros de notas y los maestros de folletos también admiten guías de dibujo. Utilice [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslide/#getDrawingGuides) y [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acceder a sus colecciones. Si una presentación no contiene uno de estos maestros, `MasterNotesSlideManager.setDefaultMasterNotesSlide` o `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crea el maestro predeterminado y lo devuelve.

El siguiente ejemplo añade una guía horizontal a un maestro de notas y una guía vertical a un maestro de folletos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eliminar guías de dibujo**

Llama a [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/#clear) para eliminar todas las guías de una colección determinada. Limpiar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías en los maestros de diapositiva, diapositivas de diseño, el maestro de notas y el maestro de folletos sin crear maestros ausentes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para los maestros de diapositiva, diapositivas de diseño, maestros de notas y maestros de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales desde el borde superior.

**¿Eliminar las guías de dibujo elimina formas o modifica el contenido de la diapositiva?**

No. El método [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/drawingguidescollection/#clear) elimina solo las guías de la colección seleccionada. Las formas y el resto del contenido de la diapositiva permanecen sin cambios.