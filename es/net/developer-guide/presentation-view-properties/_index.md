---
title: Recuperar y Actualizar las Propiedades de Vista de la Presentación en .NET
linktitle: Propiedades de Vista
type: docs
weight: 80
url: /es/net/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- divisor vertical ajustable
- vista única
- estado de la barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Utilice Aspose.Slides para .NET para configurar la distribución de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral de miniaturas o un esquema y un panel de notas debajo. Aspose.Slides para .NET expone las preferencias de edición guardadas de la presentación a través de [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Estas incluyen la distribución de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de INormalViewProperties**

Utilice [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) para acceder a la interfaz [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) controla si aparecen iconos junto a los títulos de diapositiva en el esquema. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo reduce. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) indica una preferencia por mostrar un solo panel en la ventana completa.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) controla el divisor entre el panel lateral y la diapositiva. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) controla el divisor encima del panel de notas. Ambos aceptan un valor [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Acerca de Restaurar INormalViewProperties**

Cuando se restaura un divisor, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) proporciona el tamaño guardado del panel lateral y [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) proporciona el tamaño guardado del área superior de la diapositiva. Ambos exponen [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Su propiedad [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) acepta un porcentaje de 0 a 100, y [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) controla si el editor ajusta el tamaño cuando la ventana se redimensiona.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) al 80% con el ajuste automático habilitado, y maximiza el divisor vertical. También habilita [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) para la vista de esquema.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Establecer el valor de zoom predeterminado**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) y [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de exportación de imágenes.

Este ejemplo abre una presentación existente y habilita [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y establece [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) a un zoom fijo del 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Establecer el espaciado de la cuadrícula**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) establece la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Acepta un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La cuadrícula se repite a intervalos fijos. [Guías de dibujo](/slides/es/net/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambas son ayudas de edición y aparecen solo en los editores que las muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG las omiten.

## **Mostrar u Ocultar Comentarios al Abrir una Presentación**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) almacena una preferencia que los editores compatibles usan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También establece [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) a [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) para que la copia se abra en vista de diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Ocultar los comentarios conserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Comentarios de la presentación](/slides/es/net/presentation-comments/). La configuración de exportación controla si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta cuando vuelvo a abrir la presentación?**

La presentación almacena el intervalo de la cuadrícula. Para ver la cuadrícula, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo altera el espaciado de la cuadrícula?**

No. Añadir, mover o eliminar una guía deja el intervalo de la cuadrícula sin cambios.

**¿Pueden diferentes secciones de una presentación tener distintas configuraciones de vista?**

No. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) se aplica a toda la presentación.

**¿Puedo guardar distintas configuraciones de vista para diferentes usuarios?**

El archivo almacena un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales de un usuario.

**¿Puedo guardar configuraciones de vista en una plantilla?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.