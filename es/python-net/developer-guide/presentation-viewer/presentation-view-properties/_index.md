---
title: Propiedades de Vista de Presentación
type: docs
url: /python-net/presentation-view-properties/
keywords: "visor de PowerPoint, propiedades del visor, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Propiedades del visor de presentaciones de PowerPoint en Python"
---

{{% alert color="primary" %}} 

La vista normal consiste en tres regiones de contenido: la diapositiva misma, una región de contenido lateral y una región de contenido inferior. Las propiedades correspondientes a la posición de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirlo, la vista esté en el mismo estado en que se guardó por última vez la presentación.

La propiedad [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) se ha añadido para proporcionar acceso a las propiedades de la vista normal de la presentación. 

Se han añadido las interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) y sus descendientes, así como el enum [**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/).

{{% /alert %}} 

## **Acerca de INormalViewProperties** 

Representa las propiedades de la vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar íconos si se está mostrando contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el separador vertical debe ajustarse a un estado minimizado cuando la región lateral es suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una región de contenido único a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si se activa, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en que se debe mostrar la barra separadora horizontal o vertical. Una barra separadora horizontal separa la diapositiva de la región de contenido debajo de la diapositiva, la barra separadora vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región de la diapositiva superior o lateral de la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** para **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de INormalViewRestoredProperties** 

Especifica el tamaño de la región de la diapositiva (ancho cuando es un hijo de RestoredTop, alto cuando es un hijo de RestoredLeft) de la vista normal, cuando la región es de un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es un hijo de restoredTop, alto cuando es un hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se presenta un ejemplo que muestra cómo acceder a las propiedades **ViewProperties.NormalViewProperties** para una presentación.

```py
import aspose.slides as slides

# Instanciar un objeto de presentación que representa un archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el Valor de Zoom Predeterminado**
Aspose.Slides para Python a través de .NET ahora admite establecer el valor de zoom predeterminado para la presentación de modo que, cuando se abra la presentación, el zoom ya esté configurado. Esto se puede hacer configurando las [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) de una presentación. Las propiedades de vista de diapositiva, así como las [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) se pueden establecer programáticamente. En este tema, veremos con un ejemplo cómo establecer las propiedades de vista de la presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Establezca las propiedades de vista de la presentación.
1. Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas y la vista de notas.

```py
import aspose.slides as slides

# Instanciar un objeto de Presentación que representa un archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Estableciendo las propiedades de vista de la presentación
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de diapositivas
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Propiedades de Vista**
Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Establezca las propiedades de vista de la presentación.
1. Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas y la vista de notas.

```py
import aspose.slides as slides

# Instanciar un objeto de Presentación que representa un archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Estableciendo las propiedades de vista de la presentación
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de diapositivas
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom en porcentaje para la vista de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```