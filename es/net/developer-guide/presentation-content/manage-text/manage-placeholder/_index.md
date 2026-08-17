---
title: Gestionar marcadores de posición de presentación en .NET
linktitle: Gestionar marcadores de posición
type: docs
weight: 10
url: /es/net/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de sugerencia
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a inspeccionar y editar marcadores de posición de texto, imagen, gráfico y contenido, y comprenda la herencia de marcadores de posición con Aspose.Slides para .NET."
---
## **Resumen**

Un marcador de posición es una forma que reserva una posición para un tipo concreto de contenido en una plantilla de presentación. Los ejemplos más habituales son marcadores de posición de título, cuerpo, imagen, gráfico y contenido de uso general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y demás ajustes de una diapositiva de diseño o una diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través de la propiedad [IShape.Placeholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/placeholder/). La propiedad devuelve un objeto [IPlaceholder](https://reference.aspose.com/slides/es/net/aspose.slides/iplaceholder/) o `null` para una forma normal. Utilice [IPlaceholder.Type](https://reference.aspose.com/slides/es/net/aspose.slides/iplaceholder/type/) para determinar qué se pretende que contenga el marcador de posición.

La interfaz de forma sigue siendo importante una vez que conoce el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido suele representarse mediante un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).
- Un marcador de posición de imagen poblado puede representarse mediante un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/).
- Un marcador de posición de gráfico poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Compruebe tanto [IPlaceholder.Type](https://reference.aspose.com/slides/es/net/aspose.slides/iplaceholder/type/) como la interfaz de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/es/net/aspose.slides/iplaceholder/type/) describe la función de un marcador de posición; no garantiza el tipo de forma en tiempo de ejecución. Siempre realice una comprobación de tipo antes de acceder a miembros específicos de texto, imagen, gráfico, tabla o multimedia.
{{% /alert %}}

## **Entender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel de maestro.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición de esa diapositiva y puede heredar de su diseño.

Llame a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getbaseplaceholder/) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `null` cuando la forma no tiene marcador de posición base.

El ejemplo siguiente enumera los marcadores de posición de la primera diapositiva e informa de sus marcadores de posición base:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Editar un marcador de posición en una diapositiva normal crea o modifica una sobrescritura local para esa diapositiva. Editar el diseño o la maestra relacionados puede afectar a todas las diapositivas que aún hereden esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar solo porque ocupa las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto normalmente admiten texto. Verifique que sea un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) antes de usar su propiedad [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/textframe/).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Este patrón evita convertir a [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) los marcadores de posición de imagen, gráfico, tabla o multimedia. Además identifica el marcador de posición por su finalidad en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para añadir título*. Establezca texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar alcanzarlo a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [ISlide.LayoutSlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/layoutslide/) y recorra [ILayoutSlide.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/shapes/).

El ejemplo siguiente cambia las sugerencias de título y subtítulo en el diseño utilizado por la primera diapositiva:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

El texto de sugerencia no es contenido de diapositiva normal. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que el usuario o el programa proporcionan contenido real, la sugerencia deja de mostrarse. Cambiar una sugerencia tampoco sustituye el texto existente en las diapositivas que utilizan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos que atender:

- Si el marcador de posición de imagen ya está poblado y está representado por un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/), reemplace la imagen mediante [IPictureFillFormat.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/picture/) y [ISlidesPicture.Image](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/image/).
- Si sigue siendo un marcador de posición vacío, añada un fotograma de imagen en las coordenadas del marcador de posición con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addpictureframe/) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

El reemplazo creado para un marcador de posición vacío es un fotograma de imagen local, no un nuevo marcador de posición, porque [IShape.Placeholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/placeholder/) es de solo lectura. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación del marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) resultante con Aspose.Slides.

Para la transparencia de imágenes, recorte y otros efectos específicos de la imagen, consulte [Manage Picture Frames](/slides/es/net/picture-frame/). esas operaciones pertenecen al fotograma de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/). Este ejemplo encuentra dicho gráfico tanto por tipo de marcador de posición como por interfaz en tiempo de ejecución, cambia su título y guarda el archivo:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Un marcador de posición de contenido general suele tener [PlaceholderType.Object](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/). En PowerPoint actúa como lanzador de varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y multimedia. Después de haber sido poblado, inspeccione la interfaz de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType.Chart](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/es/net/aspose.slides/placeholdertype/).

Aspose.Slides no convierte un marcador de posición vacío de [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) en un [IChart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/) simplemente cambiando [IPlaceholder.Type](https://reference.aspose.com/slides/es/net/aspose.slides/iplaceholder/type/); el tipo es de solo lectura. Para rellenar programáticamente un área vacía de gráfico o contenido, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición del diseño. Utilice los artículos dedicados a la gestión de gráficos [chart management articles](/slides/es/net/powerpoint-charts/) cuando necesite sustituir sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar contenido de texto o imagen**

El siguiente ejemplo de extremo a extremo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, comprueba los tipos de marcador de posición y de forma, actualiza el contenido correspondiente y guarda la salida. El ejemplo evita deliberadamente suponer un índice de forma o convertir todos los marcadores de posición a la misma interfaz.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que otro marcador de posición hereda. Utilice [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getbaseplaceholder/) para recuperarlo. Una forma local ordinaria devuelve `null` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición de diseño?**

Puede cambiar el formato heredado o el texto de sugerencia a través de un diseño, pero el contenido del título existente está almacenado en las diapositivas normales. Para sustituir el texto real del título en toda la presentación, recorra las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los administradores de encabezado y pie de página en el ámbito correspondiente (diapositiva, diseño, maestro, notas o folleto). Consulte [Manage Presentation Header and Footer](/slides/es/net/presentation-header-and-footer/) para ejemplos completos.