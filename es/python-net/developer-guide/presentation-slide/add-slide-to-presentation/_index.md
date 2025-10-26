---
title: Añadir diapositivas a presentaciones con Python
linktitle: Añadir diapositiva
type: docs
weight: 10
url: /es/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Añada diapositivas a sus presentaciones de PowerPoint y OpenDocument de forma fácil con Aspose.Slides para Python mediante .NET: inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Resumen**

Antes de añadir diapositivas a una presentación, es útil comprender cómo PowerPoint las organiza. Cada presentación contiene una diapositiva maestra, diapositivas de diseño opcionales y una o más diapositivas normales. Cada diapositiva tiene un ID único, y las diapositivas normales están ordenadas por un índice que comienza en cero. Este artículo muestra cómo usar Aspose.Slides para Python para crear diapositivas y elegir los diseños apropiados.

## **Añadir diapositivas a presentaciones**

Aspose.Slides le permite anexar nuevas diapositivas basadas en diapositivas de diseño existentes. El ejemplo a continuación recorre cada diseño en la presentación, añade una diapositiva que usa ese diseño y luego guarda el archivo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceda a la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. Para cada elemento en `presentation.layout_slides`, llame a `add_empty_slide` para anexar una diapositiva que usa ese diseño.
1. Opcionalmente modifique las diapositivas recién añadidas.
1. Guarde la presentación como un archivo PPTX.

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la colección de diapositivas.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Añadir una diapositiva vacía a la colección.
        slides.add_empty_slide(layout_slide)

    # Realizar alguna tarea en las diapositivas recién añadidas.

    # Guardar la presentación en disco.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo insertar una diapositiva nueva en una posición específica y no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), por lo que puede añadir una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al añadir una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y de su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de añadir diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante al calcular los índices de inserción.

**¿Cómo elijo el diseño “correcto” para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si falta ese diseño, puede [añadirlo al maestro](/slides/es/python-net/slide-layout/) y luego usarlo.