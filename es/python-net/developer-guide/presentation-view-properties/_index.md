---
title: Recuperar y actualizar las propiedades de vista de la presentación en Python
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajuste del divisor vertical
- vista única
- estado de la barra
- tamaño de la dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Utilice Aspose.Slides for Python a través de .NET para configurar la disposición de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral para miniaturas o un esquema y un panel de notas debajo. Aspose.Slides for Python a través de .NET expone las preferencias de edición guardadas de la presentación mediante [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Estas incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de NormalViewProperties**

Utilice [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) para acceder al objeto [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) controla si aparecen iconos junto a los títulos de diapositiva en el esquema. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo estrecha. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) indica una preferencia por mostrar un solo panel en la ventana completa.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) controla el divisor entre el panel lateral y la diapositiva. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) controla el divisor sobre el panel de notas. Ambos aceptan un valor [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) de `MINIMIZED`, `MAXIMIZED` o `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Un editor conceptual separa un panel lateral, la zona de diapositiva y la zona inferior con divisores verticales y horizontales etiquetados.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*En la vista normal, el divisor vertical controla el ancho del panel lateral. El divisor horizontal controla el espacio sobre el panel de notas.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Sobre la restauración de NormalViewProperties**

Cuando se restaura un divisor, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) proporciona el tamaño guardado del panel lateral y [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) proporciona el tamaño guardado del área superior de la diapositiva. Ambos exponen [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Su propiedad [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) acepta un porcentaje de 0 a 100, y [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) controla si el editor ajusta el tamaño cuando la ventana se redimensiona.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) al 80 % con ajuste automático activado y maximiza el divisor vertical. También activa [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) para la vista de esquema.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el valor de zoom predeterminado**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) y [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan a las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de exportación de imágenes.

Este ejemplo abre una presentación existente y habilita [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y establece [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) a un zoom fijo del 80 %.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el espaciado de la cuadrícula**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) define la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Acepta un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La cuadrícula se repite a un intervalo fijo. [Guías de dibujo](/slides/es/python-net/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambas son ayudas de edición y aparecen solo en los editores que las muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG las omiten.

## **Mostrar u ocultar los comentarios al abrir una presentación**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) almacena una preferencia que los editores compatibles utilizan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También establece [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) a [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) para que la copia se abra en vista de diapositiva.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Ocultar los comentarios conserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Presentation Comments](/slides/es/python-net/presentation-comments/). La configuración de exportación controla si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta al volver a abrir la presentación?**

La presentación guarda el intervalo de la cuadrícula. Para ver la cuadrícula, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Añadir, mover o eliminar una guía deja el intervalo de la cuadrícula sin cambios.

**¿Pueden diferentes secciones de una presentación tener distintas configuraciones de vista?**

No. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) se aplica a toda la presentación.

**¿Puedo guardar distintas configuraciones de vista para diferentes usuarios?**

El archivo guarda un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales de un usuario.

**¿Puedo guardar configuraciones de vista en una plantilla?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.