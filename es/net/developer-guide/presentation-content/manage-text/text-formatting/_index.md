---
title: Formato de texto de presentación en .NET
linktitle: Formato de texto
type: docs
weight: 50
url: /es/net/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia del texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad de ajuste automático
- anclaje del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Dar formato y estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabuladores y configuración de idioma.

A menos que se indique lo contrario, los ejemplos usan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita utilizan formato efectivo, incluido el formato negrita heredado:

![Texto de ejemplo](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/net/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaultportionformat/) para establecer el color de resaltado predeterminado de un párrafo, o use [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/highlightcolor/) para porciones de texto individuales.

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

El ejemplo de código a continuación muestra cómo establecer el color de fondo para **porciones de texto con fuente en negrita**:

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

Utilice [IParagraphFormat.Alignment](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/alignment/) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

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

## **Establecer transparencia para el texto**

La transparencia del texto se controla a través del componente alfa del color asignado a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/fillformat/). En los ejemplos a continuación, `alpha = 50` es un valor alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

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

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con fuente en negrita**:

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

Utilice [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/spacing/) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

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

El ejemplo de código a continuación muestra cómo ampliar el espaciado de caracteres en **porciones de texto con fuente en negrita**:

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

En algunos casos, el texto renderizado por Aspose.Slides puede aparecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como la primera forma en la primera diapositiva. Comprueba los nombres de fuente efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

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

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a que el renderizado de Aspose.Slides se asemeje al resultado visual de PowerPoint para las fuentes afectadas por este comportamiento específico de PowerPoint.

## **Administrar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaultportionformat/) o en porciones individuales mediante [IPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo en Times New Roman de 12 puntos, con formato negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados.

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

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuya formato efectivo es negrita:

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

## **Establecer rotación del texto**

Utilice [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/textverticaltype/) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/es/net/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

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

## **Establecer rotación personalizada para marcos de texto**

Utilice [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/rotationangle/) para establecer un ángulo de rotación personalizado para un [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/).

El ejemplo de código a continuación rota el marco de texto 3 grados en sentido horario dentro de la forma:

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

## **Establecer espaciado entre líneas de los párrafos**

Aspose.Slides proporciona [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spacebefore/) y [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spacewithin/) para controlar el espaciado de los párrafos. Estas propiedades se utilizan de la siguiente manera:

* Use un valor positivo para especificar el espaciado de línea como un porcentaje de la altura de la línea.
* Use un valor negativo para especificar el espaciado de línea en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo al 200 % de la altura de la línea (doble espacio):

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

![El espaciado de línea dentro del párrafo](line_spacing.png)

## **Controlar el salto de línea**

Las reglas de salto de línea de los párrafos son útiles en bloques de texto estrechos y presentaciones que combinan texto latino y asiático oriental. Las siguientes propiedades pertenecen a [IParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/), por lo que se aplican a un párrafo completo:

- [LatinLineBreak](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/latinlinebreak/) controla las reglas de salto de línea latinas. En texto mixto, cambiarla también puede modificar dónde se envuelve el texto y la puntuación asiática oriental adyacente.
- [EastAsianLineBreak](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controla las reglas de salto de línea asiáticas orientales, incluidas las restricciones de caracteres al comienzo y al final de una línea.

Estas reglas no sustituyen a [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/wraptext/), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo autocontenido crea un bloque de texto estrecho que contiene chino y texto latino. Configura ambas propiedades de salto de línea de forma explícita y guarda "line_breaking.pptx". Para experimentar con cualquiera de las reglas, cambie el valor de esa propiedad manteniendo la otra configuración fija. El ejemplo usa Arial de 24 pt y SimSun con un ancho de marco de 160 pt y márgenes horizontales del marco en cero. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/autofittype/) se establece en [TextAutofitType.None](https://reference.aspose.com/slides/es/net/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

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

## **Controlar la puntuación colgante**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/hangingpunctuation/) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo autocontenido habilita la puntuación colgante en un marco de texto de 100 pt de ancho y guarda "hanging_punctuation.pptx". Con Arial de 24 pt y márgenes horizontales del marco en cero, el punto final permanece después de "sentence" y se extiende más allá del borde derecho del texto. Establezca la propiedad en [NullableBool.False](https://reference.aspose.com/slides/es/net/aspose.slides/nullablebool/) para comparar: con esta configuración, el punto ocupa una línea separada. El ajuste de texto está habilitado y el autofit está desactivado para mantener el ancho disponible fijo.

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

No todas las marcas de puntuación pueden colgar. Las [condiciones de fuente y diseño descritas arriba](#conditions-and-limitations) también se aplican a esta comparación: cambiar la fuente, el ancho disponible, los márgenes o la configuración de autofit puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/autofittype/) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, se desborda o redimensiona la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse a su texto y guarda el resultado en "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Para contar líneas después del ajuste automático y ver cómo cambia el texto o el ancho de la forma, consulte [Contar líneas renderizadas](/slides/es/net/manage-paragraph/). El recuento de líneas por sí solo no indica si el texto se desborda de su contenedor.

## **Establecer anclaje de los marcos de texto**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/anchoringtype/) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, central o inferior. El siguiente ejemplo ancla el texto a la parte inferior de la primera forma y guarda el resultado en "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Establecer tabulación del texto**

Utilice [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaulttabsize/) y [IParagraphFormat.Tabs](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/tabs/) para configurar los tabuladores en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado en 100 puntos y añade un tabulador alineado a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

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

Aspose.Slides ofrece [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma utilizado para la revisión ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere "presentation.pptx" con un cuadro de texto como la primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo con "1。", establece SimSun como su fuente y asigna el idioma de corrección chino simplificado (`zh-CN`). Guarda el resultado en "proofing_language.pptx":

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

## **Establecer idioma predeterminado**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaulttextlanguage/) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU. como idioma predeterminado del texto, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

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

Para aplicar formato de texto predeterminado a nivel de presentación, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/defaulttextstyle/).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y la guarda en "default_text_style.pptx". El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

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

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se introdujo. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/es/net/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere "sample2.pptx" con un cuadro de texto como la primera forma en la primera diapositiva. Su primer párrafo contiene "Hello, Aspose!" con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

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

## **Preguntas frecuentes**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/). Recorra las celdas y actualice cada celda mediante [ICell.TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/icell/textframe/) y el formato de párrafo mediante [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/paragraphformat/).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/fillformat/). Establezca [IFillFormat.FillType](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformat/filltype/) en [FillType.Gradient](https://reference.aspose.com/slides/es/net/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.