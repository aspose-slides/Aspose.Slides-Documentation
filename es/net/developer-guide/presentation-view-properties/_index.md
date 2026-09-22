---
title: Recuperar y actualizar las propiedades de vista de la presentación en .NET
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos de esquema
- ajuste del divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para .NET para personalizar los formatos PPT, PPTX y ODP de las diapositivas: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva propiamente dicha, una región lateral de contenido y una región inferior de contenido. Propiedades relacionadas con la posición de las distintas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

La propiedad [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/properties/normalviewproperties) se ha añadido para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/net/aspose.slides/inormalviewrestoredproperties) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/net/aspose.slides/splitterbarstatetype).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al visualizar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra de división horizontal o vertical. Una barra de división horizontal separa la diapositiva de la región de contenido situada bajo ella, mientras que una barra de división vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el dimensionado de la región de diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región lateral de contenido debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo de cómo acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Establecer el valor predeterminado de zoom**

Aspose.Slides para .NET ahora permite establecer el valor de zoom predeterminado para una presentación de modo que, al abrirla, el zoom ya esté configurado. Esto puede lograrse estableciendo las [ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties) de una presentación. Tanto las propiedades de vista de diapositiva como las [NotesViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/properties/notesviewproperties) pueden configurarse programáticamente. En este tema veremos, con un ejemplo, cómo establecer las propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation)
1. Establezca las [Properties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties) de vista de la presentación
1. Guarde la presentación como archivo PPTX

En el ejemplo que se muestra a continuación, hemos configurado el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Configurar las propiedades de vista de la presentación
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom en porcentaje para la vista de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) para acceder a la configuración de vista a nivel de presentación. La propiedad [IViewProperties.GridSpacing](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/gridspacing/) lee o modifica el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, tal y como lo exige la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra el espaciado actual de la cuadrícula, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La cuadrícula es distinta de las [drawing guides](/slides/es/net/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no modifica el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Almacenar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o del editor.

## **FAQ**

**¿Por qué no se ve la cuadrícula después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Revise la configuración de visibilidad de la cuadrícula del editor.

**¿El borrado de guías de dibujo modifica el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Borrar las guías deja sin cambios el intervalo almacenado de la cuadrícula.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [configuraciones de vista](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/slideviewproperties/)), no por sección, de modo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Los ajustes se almacenan en el archivo y son compartidos. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo crear una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma forma?**

Sí. Como las [propiedades de vista](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.