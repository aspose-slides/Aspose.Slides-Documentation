---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/python-net/examples/elements/master-slide/
keywords:
- diapositiva maestra
- añadir diapositiva maestra
- acceder diapositiva maestra
- eliminar diapositiva maestra
- diapositiva maestra sin usar
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestiona diapositivas maestras en Python con Aspose.Slides: crea, edita, clona y da formato a temas, fondos y marcadores de posición para unificar diapositivas en PowerPoint y OpenDocument."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y gestionar diapositivas maestras usando Aspose.Slides for Python via .NET.

## **Añadir una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Clona la diapositiva maestra predeterminada.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Consejo 1:** Las diapositivas maestras proporcionan una forma de aplicar una marca consistente o elementos de diseño compartidos en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Consejo 2:** Cualquier forma o formato añadido a una diapositiva maestra se hereda por las diapositivas de diseño y, a su vez, por todas las diapositivas normales que utilizan esos diseños.  
> La imagen a continuación muestra cómo un cuadro de texto añadido en una diapositiva maestra se representa automáticamente en la diapositiva final.

![Master Inheritance Example](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puede acceder a las diapositivas maestras mediante la colección `Presentation.masters`. Así es como se recuperan y se trabaja con ellas:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Accede a la primera diapositiva maestra.
        first_master_slide = presentation.masters[0]
```

## **Eliminar una diapositiva maestra**

Las diapositivas maestras pueden eliminarse por índice o por referencia.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Eliminar por índice.
        presentation.masters.remove_at(0)

        # O eliminar por referencia.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar diapositivas maestras no usadas**

Algunas presentaciones contienen diapositivas maestras que no se están utilizando. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Elimina todas las diapositivas maestras no usadas (incluso las marcadas como Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Consejo:** Use `remove_unused(True)` para limpiar las diapositivas maestras no usadas y minimizar el tamaño de la presentación.