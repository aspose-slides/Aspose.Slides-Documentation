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
description: "Agregue diapositivas de forma fácil a sus presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET: inserción de diapositivas sin interrupciones y eficiente en segundos."
---

## **Descripción general**

Antes de agregar diapositivas a una presentación, es útil comprender cómo PowerPoint las organiza. Cada presentación contiene una diapositiva maestra, diapositivas de diseño opcionales y una o más diapositivas normales. Cada diapositiva tiene un ID único, y las diapositivas normales se ordenan mediante un índice base cero. Este artículo muestra cómo usar Aspose.Slides para Python para crear diapositivas y elegir diseños apropiados.

## **Agregar diapositivas a presentaciones**

Aspose.Slides le permite anexar nuevas diapositivas basadas en diapositivas de diseño existentes. El ejemplo a continuación recorre cada diseño en la presentación, agrega una diapositiva que usa ese diseño y luego guarda el archivo.

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la [ColecciónDeDiapositivas](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. Para cada elemento en `presentation.layout_slides`, llamar a `add_empty_slide` para añadir una diapositiva que use ese diseño.
1. Opcionalmente modificar las diapositivas recién añadidas.
1. Guardar la presentación como archivo PPTX.

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la colección de diapositivas.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Añadir una diapositiva vacía a la colección de diapositivas.
        slides.add_empty_slide(layout_slide)

    # Realizar trabajo en las diapositivas recién añadidas.

    # Guardar la presentación en disco.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insertar](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clonar](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y de su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente elija el [DiseñoDeDiapositiva](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [agregarlo al maestro](/slides/es/python-net/slide-layout/) y luego usarlo.