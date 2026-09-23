---
title: Recuperar y actualizar propiedades de vista de la presentación en Python
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajustar divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides para Python mediante .NET y sus propiedades de vista para personalizar formatos PPT, PPTX y ODP—ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posicionación de las distintas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

La propiedad [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/normal_view_properties/) se ha añadido para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/normalviewrestoredproperties/) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/python-net/aspose.slides/splitterbarstatetype/).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al mostrar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si la barra divisoria vertical debe ajustarse a un estado minimizado cuando la región lateral es suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido en toda la ventana en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra divisoria horizontal o vertical. Una barra divisoria horizontal separa la diapositiva de la región de contenido situada bajo ella; una barra divisoria vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región de diapositiva superior o lateral de la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el dimensionado de la región de diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

La propiedad **DimensionSize** especifica el tamaño de la región de diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurar las propiedades de vista de la presentación
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el valor de zoom predeterminado**

Aspose.Slides for Python via .NET ahora admite establecer el valor de zoom predeterminado para una presentación de modo que, al abrirse, el zoom ya esté configurado. Esto puede hacerse estableciendo la [view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) de una presentación. Las propiedades de vista de diapositiva, así como [notes_view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/notes_view_properties/) pueden configurarse programáticamente. En este tema veremos, con un ejemplo, cómo establecer las Propiedades de Vista de una Presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/)
2. Establecer las [view properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/) de la presentación
3. Guardar la presentación como archivo PPTX

En el ejemplo que se muestra a continuación, hemos configurado el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Estableciendo las propiedades de vista de la presentación
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) para acceder a la configuración de vista a nivel de presentación. La propiedad [ViewProperties.grid_spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/grid_spacing/) lee o modifica el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Use un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La cuadrícula es diferente de las [drawing guides](/slides/es/python-net/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG ni en una presentación. Almacenar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o editor.

## **Mostrar u ocultar comentarios al abrir una presentación**

Utilice [Presentation.view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) para acceder a la configuración de vista a nivel de presentación. Lea o modifique [ViewProperties.show_comments](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/show_comments/) para almacenar una preferencia sobre si los comentarios deben mostrarse cuando la presentación se abre en PowerPoint u otro editor compatible.

Esta configuración solo controla la preferencia de vista almacenada. No añade, elimina, edita ni resuelve comentarios. Ocultar comentarios conserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/python-net/presentation-comments/) para operaciones que modifican los propios comentarios.

El siguiente ejemplo requiere un `comments.pptx` existente que contenga comentarios. Muestra la configuración de visibilidad actual, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También establece [ViewProperties.last_view](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/last_view/) a [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewtype/) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Esta configuración no determina si los comentarios se incluyen en exportaciones a PDF, HTML, imagen, notas o folletos. Configure las opciones específicas de exportación correspondientes por separado.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Revise la configuración de visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja sin cambios el intervalo de la cuadrícula almacenado.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/slide_view_properties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un solo conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con Propiedades de Vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.