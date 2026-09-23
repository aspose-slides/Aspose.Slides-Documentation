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
- iconos del esquema
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
description: "Descubra las propiedades de vista de Aspose.Slides para .NET para personalizar los formatos PPT, PPTX y ODP—ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva propiamente dicha, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista se encuentre en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido la propiedad [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/properties/normalviewproperties) para proporcionar acceso a las propiedades de vista normal de la presentación.

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/net/aspose.slides/inormalviewrestoredproperties) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/net/aspose.slides/splitterbarstatetype).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al visualizar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva, mientras que la barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState**, respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

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

## **Establecer el valor de zoom predeterminado**

Aspose.Slides for .NET ahora admite la configuración del valor de zoom predeterminado para una presentación, de modo que cuando se abre la presentación, el zoom ya está establecido. Esto puede hacerse configurando las [ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties) de una presentación. Tanto las propiedades de vista de diapositiva como las [NotesViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/properties/notesviewproperties) pueden establecerse mediante código. En este tema, veremos mediante un ejemplo cómo establecer las propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation)
1. Establecer las [Properties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties) de vista de la presentación
1. Guardar la presentación como un archivo PPTX

En el ejemplo que sigue, hemos establecido el valor de zoom para la vista de diapositiva y la vista de notas.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Establecer las propiedades de vista de la presentación
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom en porcentajes para la vista de diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom en porcentajes para la vista de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) para acceder a la configuración de vista a nivel de presentación. La propiedad [IViewProperties.GridSpacing](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/gridspacing/) lee o modifica el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

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

La cuadrícula es diferente de las [drawing guides](/slides/es/net/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o presentaciones. Almacenar el espaciado de la cuadrícula no garantiza que un editor lo muestre: su visibilidad también depende de las preferencias del visor o del editor.

## **Mostrar u ocultar comentarios al abrir una presentación**

Utilice [Presentation.ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) para acceder a la configuración de vista a nivel de presentación. Lea o modifique [IViewProperties.ShowComments](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/showcomments/) para almacenar una preferencia sobre si los comentarios deben mostrarse al abrir la presentación en PowerPoint u otro editor compatible.

Esta configuración sólo controla la preferencia de vista almacenada. No añade, elimina, edita ni resuelve comentarios. Ocultar los comentarios preserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/net/presentation-comments/) para conocer las operaciones que modifican los propios comentarios.

El siguiente ejemplo necesita un `comments.pptx` existente que contenga comentarios. Muestra la configuración de visibilidad actual, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También establece [IViewProperties.LastView](https://reference.aspose.com/slides/es/net/aspose.slides/iviewproperties/lastview/) a [ViewType.SlideView](https://reference.aspose.com/slides/es/net/aspose.slides/viewtype/) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Esta configuración no determina si los comentarios se incluyen en las exportaciones a PDF, HTML, imágenes, notas o folletos. Configure por separado las opciones específicas de exportación correspondientes.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**  
El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**  
No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja sin cambios el intervalo de la cuadrícula almacenado.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**  
Las [View settings](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**  
No. La configuración se almacena en el archivo y se comparte. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo crear una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma forma?**  
Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/viewproperties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.