---
title: Gestionar guías de dibujo en presentaciones con Python
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/python-net/drawing-guides/
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
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint mediante Aspose.Slides para Python vía .NET."
---
## **Visión general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma coherente mientras editan una presentación en PowerPoint. Son especialmente útiles cuando una aplicación genera una presentación que luego se perfeccionará manualmente: la aplicación puede guardar las mismas ayudas de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación ni en la salida renderizada. Aspose.Slides for Python via .NET las expone a través de la interfaz [IDrawingGuidesCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguidescollection/). Una guía está representada por [IDrawingGuide](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o maestro correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Agregar guías a la vista de diapositiva**

Utilice [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/es/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguidescollection/add/) con un valor de [Orientation](https://reference.aspose.com/slides/es/python-net/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal por debajo de ella:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a las guías de dibujo**

La propiedad [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguidescollection/count/) y el indexador proporcionan acceso a las guías existentes. Las propiedades [IDrawingGuide.orientation](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguide/position/) y [IDrawingGuide.color](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguide/color/) pueden leerse o modificarse.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada arriba:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Agregar guías a diapositivas master y de diseño**

Un maestro de diapositiva y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterslide/drawing_guides/) para una diapositiva master y [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/es/python-net/aspose.slides/ilayoutslide/drawing_guides/) para una diapositiva de diseño.

El siguiente ejemplo agrega una guía vertical a la primera diapositiva master y una guía horizontal a la primera diapositiva de diseño:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar guías a los maestros de notas y de folletos**

Los maestros de notas y los maestros de folletos también admiten guías de dibujo. Utilice [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasternotesslide/drawing_guides/) y [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) para acceder a sus colecciones. Si una presentación no contiene uno de estos maestros, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) o [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) crea el maestro predeterminado y lo devuelve.

El siguiente ejemplo agrega una guía horizontal a un maestro de notas y una guía vertical a un maestro de folletos:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Borrar guías de dibujo**

Llame a [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/idrawingguidescollection/clear/) para eliminar todas las guías de una colección concreta. Borrar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo borra las guías de la vista de diapositiva y todas las guías en los maestros de diapositivas, diapositivas de diseño, el maestro de notas y el maestro de folletos sin crear maestros ausentes:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede agregar una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para los maestros de diapositivas, las diapositivas de diseño, los maestros de notas y los maestros de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales se miden desde el borde superior.

**¿El borrado de las guías de dibujo elimina formas o cambia el contenido de la diapositiva?**

No. El método `clear` elimina solo las guías de la colección seleccionada. Las formas y el resto del contenido de la diapositiva permanecen sin cambios.