---
title: Formatear texto de presentación en .NET
linktitle: Formateo de texto
type: docs
weight: 50
url: /es/net/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- anclaje de marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Formatee y dé estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Personalice fuentes, colores, alineación y más."
---
## **Descripción general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de autofit, anclaje de texto, tabuladores y configuración de idioma.

A menos que se indique lo contrario, los ejemplos usan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita usan formato efectivo, incluido el formato en negrita heredado:

![Texto de ejemplo](sample_text.png)

Para encontrar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/net/search-and-replace-text/).

## **Establecer color de fondo del texto**

Use [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) para establecer el color de resaltado predeterminado de un párrafo, o use [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) para porciones individuales de texto.

El siguiente ejemplo establece un resaltado gris claro como predeterminado para el primer párrafo. Los colores de resaltado explícitos en porciones individuales tienen prioridad sobre este valor predeterminado:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Establecer el color de resaltado para todo el párrafo.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El siguiente fragmento de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Establecer el color de resaltado para la porción de texto.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Use [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Establecer la alineación del párrafo al centro.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Alinear fuentes dentro de una línea**

Use [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) para alinear verticalmente porciones de texto de diferentes tamaños de fuente dentro de una línea. Esta configuración se aplica a todo el párrafo y controla la alineación dentro de cada una de sus líneas.

El siguiente ejemplo independiente crea cuatro cuadros de texto etiquetados en una diapositiva. Cada párrafo contiene el mismo texto en 18, 36 y 54 puntos, con una alineación de fuente diferente. Utiliza Arial, desactiva autofit y ajuste de línea, y mantiene los marcos de texto lo suficientemente grandes para una sola línea.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

El resultado:

![Comparación de alineación de línea base, superior, centrada e inferior con tamaños de fuente mixtos](font_alignment.png)

La alineación de fuente usa métricas tipográficas, por lo que los bordes visibles de letras individuales no siempre coinciden exactamente. El ejemplo incluye tanto una letra mayúscula como una descendente para ayudar a mostrar la diferencia entre la alineación de línea base y la inferior. La disponibilidad y sustitución de fuentes, los caracteres usados y la diferencia de tamaños de fuente afectan el resultado. Las dimensiones del marco, los márgenes, el interlineado, el ajuste de línea y el autofit también influyen en el diseño; use las mismas fuentes y configuración de diseño al comparar los modos.

Esta configuración difiere de [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), que controla la alineación horizontal del párrafo, y de [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), que posiciona el bloque de texto verticalmente dentro de su forma. El formato de superíndice y subíndice mediante [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) desplaza porciones individuales respecto a la línea base en lugar de establecer la alineación de fuente para las líneas del párrafo.

## **Establecer transparencia para el texto**

La transparencia del texto se controla a través del componente alfa del color asignado a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). En los ejemplos siguientes, `alpha = 50` es un valor alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente fragmento de código muestra cómo aplicar transparencia al **párrafo completo**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Establecer un relleno negro semitransparente para el texto.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente fragmento de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Establecer la transparencia de la porción de texto.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Use [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código C# muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nota: Use valores negativos para comprimir el espaciado de caracteres.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expandir el espaciado de caracteres.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente fragmento de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Nota: Use valores negativos para comprimir el espaciado de caracteres.
        portion.PortionFormat.Spacing = 3;  // Expandir el espaciado de caracteres.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más apretado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se asemeje más a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuente efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a alinear la representación de Aspose.Slides con la salida visual de PowerPoint para las fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) o en porciones individuales mediante [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo a Times New Roman de 12 puntos con negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Establecer las propiedades de fuente del párrafo.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Establecer las propiedades de fuente para la porción de texto.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Controlar la normalización de la altura del texto**

Use [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) al reproducir tipografía de plantilla o investigar diferencias en la altura de los caracteres. En PowerPoint, habilitar la normalización estira o comprime verticalmente los caracteres individuales para darles una altura visible uniforme dentro de la porción de texto. No garantiza alturas de texto iguales entre diferentes fuentes.

Establezca la propiedad en [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) para habilitar o deshabilitar explícitamente la normalización. `NullableBool.NotDefined` deja la configuración local sin definir de modo que la porción herede su valor, por ejemplo, del [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) del párrafo. No equivale a `False`. Use [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) y lea [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) para obtener el valor booleano resuelto.

El siguiente ejemplo independiente requiere que **Arial** esté instalado. Crea dos bloques de texto que contienen las mismas letras mayúsculas, minúsculas, descendentes y caracteres acentuados a 54 puntos. Ambos párrafos habilitan la normalización de forma predeterminada. La porción superior la deshabilita explícitamente; la inferior la hereda. Los tamaños del marco, los márgenes y el espaciado de párrafo son idénticos, con ajuste de línea y autofit desactivados para mantener la comparación consistente. El ejemplo imprime `False: False` y `NotDefined: True`, luego guarda "text_height_normalization.pptx".

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

La comparación siguiente se exportó de la presentación guardada. La fila superior tiene la normalización desactivada (`False`); la fila inferior hereda la configuración activada (`NotDefined` → `True`). Mantenga Arial instalado para reproducir esta apariencia.

![Texto Arial de 54 puntos con normalización desactivada arriba y normalización heredada activada abajo](text_height_normalization.png)

La normalización cambia la altura de los caracteres sin cambiar el valor asignado de [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), que especifica el tamaño de la fuente en puntos. [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) del párrafo controla el interlineado, mientras que [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) del marco de texto controla cómo el texto o su contenedor se ajusta. Estas configuraciones sirven a propósitos diferentes y pueden afectar el diseño general de forma independiente. Para más información sobre el formato de párrafo y herencia, consulte [Gestionar párrafo](/slides/es/net/manage-paragraph/).

## **Aplicar y eliminar tachado**

Use [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) en una porción de texto para mostrar correcciones, términos cancelados o precios anteriores sin eliminar el texto original. Establézcalo en [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) para una o dos líneas tachadas a través del texto.

Para eliminar el tachado, asigne `TextStrikethroughType.None`. Esto desactiva explícitamente el efecto, incluso si el formato circundante especifica tachado. Por el contrario, `TextStrikethroughType.NotDefined` deja la configuración local sin definir, permitiendo que la porción herede el formato, por ejemplo, del párrafo. No garantiza que el tachado se elimine. Use [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) para leer el formato resultante, incluidos los valores heredados.

El siguiente ejemplo independiente crea tres comparaciones de precios. Cada párrafo tiene porciones separadas para la etiqueta, el precio anterior y el precio actual, de modo que solo el precio anterior se ve afectado. La primera fila aplica y luego elimina el tachado; las demás filas conservan el tachado simple y doble. Cambiar esta propiedad conserva el texto y su resto de formato, incluida la negrita del precio anterior.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Aplicar tachado y luego eliminarlo explícitamente del primer precio anterior.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

El resultado, de arriba a abajo: sin tachado, tachado simple y tachado doble.

![Precios anteriores sin tachado, con tachado simple y con doble tachado](strikethrough.png)

## **Establecer rotación del texto**

Use [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente fragmento de código establece la orientación del texto en la forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Mostrar dígitos uno al lado del otro en texto vertical**

Para mantener juntos dos dígitos en una etiqueta vertical japonesa, coloque ambos dígitos en una sola porción de texto y establezca [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) en esa porción. El ejemplo usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) y MS Gothic de 40 puntos para ambas etiquetas. Sólo difiere el valor de [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) asignado a la porción numérica.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

En PowerPoint, la etiqueta izquierda (`True`) muestra los dígitos en posición vertical y uno al lado del otro entre 和 y 年. En la etiqueta derecha (`False`), el par se rota 90 grados en sentido horario. Los caracteres japoneses circundantes permanecen verticales en ambas etiquetas.

![Comparación en PowerPoint de etiquetas de fecha vertical con dígitos verticales a la izquierda y dígitos rotados a la derecha.](vertical_date.png)

## **Establecer rotación personalizada para marcos de texto**

Use [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) para establecer un ángulo de rotación personalizado para un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

El siguiente fragmento de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

El resultado:

![La rotación de texto personalizada](custom_text_rotation.png)

## **Establecer interlineado de párrafos**

Aspose.Slides proporciona [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), y [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) para controlar el espaciado de los párrafos. Estas propiedades se usan de la siguiente manera:

* Use un valor positivo para especificar el interlineado como porcentaje de la altura de línea.
* Use un valor negativo para especificar el interlineado en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo al 200 % de la altura de línea (doble interlineado):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

El resultado:

![El interlineado dentro del párrafo](line_spacing.png)

## **Controlar el quiebre de línea**

Las reglas de quiebre de línea del párrafo son útiles en bloques de texto estrechos y presentaciones que combinan texto latino y de Asia Oriental. Las siguientes propiedades pertenecen a [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), por lo que se aplican a un párrafo completo:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) controla las reglas de quiebre de línea latinas. En texto mixto, cambiarla también puede cambiar dónde se envuelve el texto y la puntuación asiática adyacente.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controla las reglas de quiebre de línea de Asia Oriental, incluidas las restricciones de caracteres al inicio y al final de una línea.

Estas reglas no sustituyen a [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando se produce el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo independiente crea un bloque de texto estrecho que contiene texto chino y latino. Establece ambas propiedades de quiebre de línea explícitamente y guarda "line_breaking.pptx". Para experimentar con cada regla, cambie el valor de esa propiedad manteniendo las demás configuraciones fijas. El ejemplo usa Arial de 24 puntos y SimSun con un ancho de marco de 160 puntos y márgenes horizontales del marco de texto a cero. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) se establece en [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Controlar puntuación colgante**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo independiente habilita la puntuación colgante en un marco de texto de 100 puntos de ancho y guarda "hanging_punctuation.pptx". Con Arial de 24 puntos y márgenes horizontales del marco de texto a cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad en [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) para comparar: con esta configuración, el punto ocupa una línea separada. El ajuste de línea está habilitado y el autofit desactivado para mantener el ancho disponible fijo.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

No todas las marcas de puntuación pueden colgar. Las [condiciones de fuente y diseño descritas arriba](#control-line-breaking) también se aplican a esta comparación: cambiar la fuente, el ancho disponible, los márgenes o la configuración de autofit puede eliminar la diferencia visible.

## **Establecer tipo de autofit para marcos de texto**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona automáticamente la forma. El siguiente ejemplo configura la forma para redimensionarse y ajustarse al texto y guarda el resultado en "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Para contar líneas tras el ajuste automático y ver cómo cambia el ancho del texto o de la forma, consulte [Contar líneas renderizadas](/slides/es/net/manage-paragraph/). El recuento de líneas por sí solo no indica si el texto desborda su contenedor.

## **Establecer anclaje de marcos de texto**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, media o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Establecer tabulación de texto**

Use [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) y [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) para configurar los tabuladores en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado a 100 puntos y añade un tabulador alineado a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

El resultado:

![Los tabuladores del párrafo](paragraph_tabs.png)

## **Establecer idioma de corrección**

Aspose.Slides proporciona [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma usado para la ortografía y la gramática en PowerPoint.

El siguiente ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo con "1。", establece SimSun como su fuente y asigna el idioma de corrección Simplificado chino (`zh-CN`). Guarda el resultado en "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Establecer el idioma de corrección a chino simplificado.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Copiar metadatos de idioma**

Al copiar texto multilingüe de una plantilla, conserve tanto [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) como [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). El siguiente ejemplo independiente crea una porción fuente con inglés estadounidense como idioma y francés como idioma alternativo y copia el texto y los identificadores a una porción en una nueva presentación.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Si la fuente no tiene idioma alternativo, null borra el valor del destino.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Para probar una fuente sin idioma alternativo, omita la asignación de `"fr-FR"`. El identificador alternativo será entonces `null`, y la misma instrucción de copia conserva su ausencia sin introducir un valor predeterminado, incluso si el destino ya tenía asignado un idioma alternativo.

Estos identificadores almacenan metadatos de idioma. Conservarlos no establece qué diccionario selecciona PowerPoint para la ortografía o la gramática.

## **Establecer idioma predeterminado**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) para definir el idioma predeterminado para el texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés estadounidense como idioma de texto predeterminado, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Añadir una nueva forma rectangular con texto.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Comprobar el idioma de la primera porción.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Establecer estilo de texto predeterminado**

Para aplicar formato de texto predeterminado a nivel de presentación, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminado para los párrafos de nivel superior en una nueva presentación y guarda el archivo "default_text_style.pptx". El texto puede heredar estos valores predeterminados salvo que un formato más específico los sobrescriba.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Obtener el formato de párrafo de nivel superior.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aun cuando se haya escrito originalmente en minúsculas. Cuando reciba esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para coincidir con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere "sample2.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene la primera porción "Hello, Aspose!" con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

El fragmento de código a continuación muestra cómo extraer el texto con el **efecto All Caps** aplicado:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Salida:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Recorra las celdas y actualice cada celda a través de [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) y el formato de párrafo mediante [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Establezca [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) en [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) y configure los puntos de degradado, la dirección y la transparencia.

Recurso relacionado: [Format text within slides](/slides/es/features/text-formatting/).