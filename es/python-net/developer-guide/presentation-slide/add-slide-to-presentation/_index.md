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
description: "Agregue diapositivas a sus presentaciones de PowerPoint y OpenDocument de forma fácil con Aspose.Slides para Python a través de .NET: inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Visión general**

Antes de agregar diapositivas a una presentación, es útil comprender cómo PowerPoint las organiza. Cada presentación contiene una diapositiva maestra, diapositivas de diseño opcionales y una o más diapositivas normales. Cada diapositiva tiene una ID única, y las diapositivas normales se ordenan mediante un índice basado en cero. Este artículo muestra cómo usar Aspose.Slides para Python para crear diapositivas y elegir diseños apropiados.

## **Agregar diapositivas a presentaciones**

Aspose.Slides le permite anexar nuevas diapositivas basándose en diapositivas de diseño existentes. El ejemplo a continuación recorre cada diseño en la presentación, agrega una diapositiva que utiliza ese diseño y luego guarda el archivo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Para cada elemento en `presentation.layout_slides`, llame a `add_empty_slide` para añadir una diapositiva que use ese diseño.
4. Opcionalmente modifique las diapositivas recién agregadas.
5. Guarde la presentación como archivo PPTX.

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la colección de diapositivas.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Añadir una diapositiva vacía a la colección.
        slides.add_empty_slide(layout_slide)

    # Realizar trabajo con las diapositivas recién agregadas.

    # Guardar la presentación en disco.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y de su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación “vacía” antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante a la hora de calcular los índices de inserción.

**¿Cómo elijo el diseño “correcto” para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [añadirlo al maestro](/slides/es/python-net/slide-layout/) y luego usarlo.