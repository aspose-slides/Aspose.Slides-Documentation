---
title: Agregar diapositivas a presentaciones con Python
linktitle: Agregar diapositiva
type: docs
weight: 10
url: /es/python-net/add-slide-to-presentation/
keywords:
- agregar diapositiva
- crear diapositiva
- diapositiva vacía
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Agregue diapositivas fácilmente a sus presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python vía .NET: inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Resumen**

Antes de agregar diapositivas a una presentación, es útil comprender cómo PowerPoint las organiza. Cada presentación contiene una diapositiva maestra, diapositivas de diseño opcionales y una o más diapositivas normales. Cada diapositiva tiene una ID única, y las diapositivas normales se ordenan mediante un índice basado en cero. Este artículo muestra cómo usar Aspose.Slides para Python para crear diapositivas y elegir diseños apropiados.

## **Agregar diapositivas a presentaciones**

Aspose.Slides le permite añadir nuevas diapositivas basadas en diapositivas de diseño existentes. El siguiente ejemplo recorre cada diseño en la presentación, agrega una diapositiva que usa ese diseño y luego guarda el archivo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Para cada elemento en `presentation.layout_slides`, llame a `add_empty_slide` para agregar una diapositiva que utilice ese diseño.
4. Opcionalmente, modifique las diapositivas recién añadidas.
5. Guarde la presentación como un archivo PPTX.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante a tener en cuenta al calcular los índices de inserción.

**¿Cómo elegir el diseño "correcto" para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente, elija la [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [agregarlo al maestro](/slides/es/python-net/slide-layout/) y luego usarlo.