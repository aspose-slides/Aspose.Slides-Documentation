---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/python-net/examples/elements/layout-slide/
keywords:
- diapositiva de diseño
- agregar diapositiva de diseño
- acceder diapositiva de diseño
- eliminar diapositiva de diseño
- diapositiva de diseño no utilizada
- clonar diapositiva de diseño
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Utilice Python para gestionar diapositivas de diseño con Aspose.Slides: crear, aplicar, clonar, renombrar y personalizar marcadores de posición y temas en presentaciones para PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con **Layout Slides** en Aspose.Slides for Python via .NET. Una diapositiva de diseño define el diseño y formato heredados por las diapositivas normales. Puede agregar, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las que no se usan para reducir el tamaño de la presentación.

## **Agregar una diapositiva de diseño**

Puede crear una diapositiva de diseño personalizada para definir un formato reutilizable.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Crear una diapositiva de diseño con el tipo y nombre especificados.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Consejo 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir elementos comunes una vez y reutilizarlos en muchas diapositivas.

> 💡 **Consejo 2:** Cuando agrega formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán ese contenido compartido automáticamente.  
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas que heredan contenido de diseño](layout-slide-result.png)


## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p. ej., `Blank`, `Title`, `SectionHeader`, etc.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Acceder por índice.
        first_layout_slide = presentation.layout_slides[0]

        # Acceder por tipo de diseño.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Eliminar una diapositiva de diseño**

Puede eliminar una diapositiva de diseño específica si ya no es necesaria.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtener una diapositiva de diseño por tipo y eliminarla.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar diapositivas de diseño sin usar**

Para reducir el tamaño de la presentación, es posible eliminar las diapositivas de diseño que no son utilizadas por ninguna diapositiva normal.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Elimina automáticamente todas las diapositivas de diseño que no estén referenciadas por ninguna diapositiva.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar una diapositiva de diseño**

Puede duplicar una diapositiva de diseño utilizando el método `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtener una diapositiva de diseño existente por tipo.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas potentes para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de diapositivas de diseño.