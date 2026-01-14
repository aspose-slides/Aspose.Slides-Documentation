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
- iconos de esquema
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
description: "Descubra las propiedades de vista de Aspose.Slides para Python vía .NET para personalizar formatos PPT, PPTX y ODP—ajuste diseños, niveles de zoom y configuraciones de visualización."
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la propia diapositiva, una región de contenido lateral y una región de contenido inferior. Propiedades relativas a la posición de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando se guardó por última vez la presentación.

Se ha añadido la propiedad [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/). 

{{% /alert %}} 

## **Acerca de INormalViewProperties** 

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al visualizar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, y una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de la restauración de INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hija de RestoredTop, altura cuando es hija de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (anchura cuando es hija de restoredTop, altura cuando es hija de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurar las propiedades de vista de la presentación
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer el valor de zoom predeterminado**

Aspose.Slides for Python via .NET ahora permite establecer el valor de zoom predeterminado para una presentación, de modo que cuando la presentación se abre, el zoom ya está configurado. Esto se puede hacer estableciendo las [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) de una presentación. Las propiedades de vista de diapositiva así como las [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) pueden configurarse mediante código. En este tema veremos, con un ejemplo, cómo establecer las propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Establezca las [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) de la presentación.
1. Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom para la vista de diapositiva así como para la vista de notas.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Configurar las propiedades de vista de la presentación
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de notas

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Los [view settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirlo.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Los ajustes se almacenan en el archivo y son compartidos. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.