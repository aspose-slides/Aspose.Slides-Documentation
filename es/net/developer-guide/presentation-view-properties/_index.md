---
title: Propiedades de vista de la presentación
type: docs
weight: 80
url: /es/net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido de esquema
- iconos de esquema
- ajustar divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- autoajuste
- zoom predeterminado
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides for .NET
description: "Gestione las propiedades de vista de presentaciones PowerPoint en C# o .NET"
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la ubicación de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido la propiedad [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) y su descendiente, el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype).  

{{% /alert %}}

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar íconos al visualizar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, mientras que una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState**, respectivamente.

## **Acerca de Restaurar INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (ancho cuando es hija de RestoredTop, altura cuando es hija de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es hija de restoredTop, altura cuando es hija de restoredLeft).  

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo de cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.  
```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Restaurar las propiedades de vista de la presentación
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **Establecer el valor de zoom predeterminado**

Aspose.Slides para .NET ahora admite la configuración del valor de zoom predeterminado para una presentación, de modo que cuando la presentación se abre, el zoom ya está establecido. Esto se puede lograr configurando las [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de una presentación. Las propiedades de vista de diapositiva así como las [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) pueden establecerse mediante código. En este tema, veremos con un ejemplo cómo establecer las ViewProperties de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Establezca las [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de la presentación
3. Guarde la presentación como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.  
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Configuración de las propiedades de vista de la presentación
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.