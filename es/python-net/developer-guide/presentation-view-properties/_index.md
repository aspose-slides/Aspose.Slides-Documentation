---
title: Recuperar y actualizar las propiedades de vista de la presentación en Python
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/python-net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido de esquema
- iconos de esquema
- ajuste del divisor vertical
- vista única
- estado de la barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para Python a través de .NET para personalizar formatos PPT, PPTX y ODP—ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la propia diapositiva, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite que la aplicación guarde el estado de la vista en el archivo, de modo que al volver a abrirlo la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido la propiedad [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/normal_view_properties/) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/normalviewrestoredproperties/) y sus descendientes, y el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/python-net/aspose.slides/splitterbarstatetype/).

## **Acerca de INormalViewProperties** 

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al visualizar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido en ventana completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, la barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el dimensionado de la región de diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).  

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

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

Aspose.Slides para Python a través de .NET ahora admite la configuración del valor de zoom predeterminado para una presentación, de modo que cuando se abre la presentación, el zoom ya está establecido. Esto puede hacerse configurando las [view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) de una presentación. Las propiedades de vista de diapositiva así como las [notes_view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/notes_view_properties/) pueden establecerse mediante programación. En este tema, veremos con un ejemplo cómo establecer las Propiedades de Vista de una Presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/)
1. Establecer las [view properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/) de la presentación
1. Guardar la presentación como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom para la vista de diapositiva y la vista de notas.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Establecer las propiedades de vista de la presentación
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom en porcentajes para la vista de diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom en porcentajes para la vista de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.view_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) para acceder a la configuración de vista a nivel de presentación. La propiedad [ViewProperties.grid_spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/grid_spacing/) lee o modifica el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra el espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La cuadrícula es diferente de las [drawing guides](/slides/es/python-net/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Guardar el espaciado de la cuadrícula no garantiza que un editor lo muestre: su visibilidad también depende de las preferencias del visor o del editor.

## **FAQ**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de la cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [configuraciones de vista](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/slide_view_properties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirlo.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con Propiedades de Vista predefinidas para que las nuevas presentaciones se abran de la misma forma?**

Sí. Debido a que las [propiedades de vista](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/view_properties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.