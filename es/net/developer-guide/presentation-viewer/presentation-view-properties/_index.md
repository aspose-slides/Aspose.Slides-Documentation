---
title: Propiedades de la Vista de Presentación
type: docs
url: /es/net/presentation-view-properties/
keywords: "visor de PowerPoint, propiedades del visor, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Propiedades del visor de presentaciones de PowerPoint en C# o .NET"
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirlo, la vista esté en el mismo estado en que se guardó por última vez la presentación.

La propiedad [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) se ha añadido para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) y sus descendientes, el enum [**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype).

{{% /alert %}} 



## **Acerca de INormalViewProperties** #

Representa las propiedades de la vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar íconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustar a un estado minimizado cuando la región lateral es suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una región de contenido de ventana completa sobre la vista normal estándar con tres regiones de contenido. Si se activa, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra de divisor horizontal o vertical. Una barra de divisor horizontal separa la diapositiva de la región de contenido debajo de la diapositiva, la barra de divisor vertical separa la diapositiva de la región lateral de contenido. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva de la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** para **VerticalBarState** y **HorizontalBarState** en consecuencia.



## **Acerca de INormalViewRestoredProperties** #

Especifica el tamaño de la región de la diapositiva (ancho cuando es un hijo de RestoredTop, alto cuando es un hijo de RestoredLeft) de la vista normal, cuando la región es de un tamaño restaurado variable (ni minimizado ni maximizado). 

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es un hijo de restoredTop, alto cuando es un hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región lateral de contenido debe compensar el nuevo tamaño cuando se redimensiona la ventana que contiene la vista dentro de la aplicación.

Un ejemplo que se muestra a continuación muestra cómo acceder a las propiedades **ViewProperties.NormalViewProperties** para una presentación.

```c#
//Instanciar un objeto de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **Establecer Valor de Zoom Predeterminado**
Aspose.Slides para .NET ahora admite establecer el valor de zoom predeterminado para la presentación de manera que cuando se abre la presentación, el zoom ya está configurado. Esto se puede hacer configurando las [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de una presentación. Las propiedades de vista de diapositivas, así como [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) se pueden establecer programáticamente. En este tema, veremos con un ejemplo cómo establecer las propiedades de vista de la presentación en Aspose.Slides.

Para establecer las propiedades de vista, por favor siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Establecer las [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de Vista de la Presentación
1. Guardar la presentación como un archivo PPTX

En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas así como para la vista de notas.

```c#
// Instanciar un objeto de Presentación que representa un archivo de presentación
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Estableciendo las propiedades de vista de la Presentación

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de diapositivas
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **Establecer Propiedades de Vista**
Para establecer las propiedades de vista, por favor siga los pasos a continuación:

1. Crear una instancia de la clase Presentation.
1. Establecer las propiedades de vista de la presentación.
1. Guardar la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas así como para la vista de notas.

```c#
// Instanciar un objeto de Presentación que representa un archivo de presentación
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Estableciendo las propiedades de vista de la Presentación

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de diapositivas
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```