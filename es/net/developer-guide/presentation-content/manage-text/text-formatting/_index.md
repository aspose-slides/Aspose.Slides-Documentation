---
title: Formato del texto de la presentación en .NET
linktitle: Formato de texto
type: docs
weight: 50
url: /es/net/text-formatting/
keywords:
- resaltar texto
- expresión regular
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
description: "Da formato y estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument mediante Aspose.Slides para .NET. Cubre el resaltado, colores de fondo, transparencia, espaciado entre caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje del texto, tabuladores y configuraciones de idioma.

En los ejemplos siguientes, usaremos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Resaltar texto**

Utilice el método [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/) cuando necesite resaltar texto que coincida con una muestra específica dentro de un marco de texto. El método aplica un color de resaltado a los fragmentos de texto coincidentes y puede usarse con [TextSearchOptions](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/) para controlar cómo se realiza la búsqueda, por ejemplo, para que coincida solo con palabras completas.

El siguiente ejemplo de código resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Obtener la primera forma de la primera diapositiva.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Resaltar la palabra "try" en la forma.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Resaltar la palabra "to" en la forma.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/) resalta las coincidencias de texto encontradas mediante una expresión regular. En .NET, esta API está expuesta en [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/).

El siguiente ejemplo de código resalta todas las palabras que contienen **siete o más caracteres**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Resaltar todas las palabras con siete o más caracteres.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

El resultado:

![Texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Establecer color de fondo del texto**

Utilice [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaultportionformat/) para establecer el color de resaltado predeterminado para un párrafo, o use [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/highlightcolor/) para porciones de texto individuales.

El siguiente ejemplo de código muestra cómo establecer el color de fondo para el **párrafo completo**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer el color de resaltado para todo el párrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El ejemplo de código a continuación muestra cómo establecer el color de fondo para **porciones de texto con fuente en negrita**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Utilice [IParagraphFormat.Alignment](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/alignment/) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer la alineación del párrafo al centro.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [IPortionFormat.FillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/fillformat/). En los ejemplos siguientes, `alpha = 50` es un valor del canal alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer el color de relleno del texto a color transparente.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con fuente en negrita**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Utilice [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/spacing/) para ampliar o reducir el espaciado entre caracteres en un cuadro de texto.

El siguiente código C# muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nota: Use valores negativos para comprimir el espaciado de caracteres.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expandir el espaciado de caracteres.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente ejemplo de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con fuente en negrita**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar el interletraje para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más apretado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de interletraje para ciertas fuentes, incluso cuando la fuente contiene información de interletraje válida y el interletraje está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque más a PowerPoint en esos casos, puede desactivar el interletraje para las porciones de texto que usan la fuente afectada. Establezca [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valor significativamente mayor que el tamaño real de la fuente:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Esta configuración evita que se aplique interletraje a las porciones de texto coincidentes y puede ayudar a alinear la renderización de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Administrar propiedades de fuente del texto**

Las propiedades de fuente pueden configurarse a nivel de párrafo mediante [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaultportionformat/) o en porciones individuales mediante [IPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/).

El siguiente código establece la fuente y el estilo de texto para el párrafo completo: aplica el tamaño de fuente, negrita, cursiva, subrayado punteado y la fuente Times New Roman a todas las porciones del párrafo.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer las propiedades de fuente del párrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El siguiente ejemplo de código aplica propiedades similares a **porciones de texto con fuente en negrita**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Establecer rotación del texto**

Utilice [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/textverticaltype/) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a `Vertical270`, lo que rota el texto **90 grados en sentido antihorario**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Establecer rotación personalizada para marcos de texto**

Utilice [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/rotationangle/) para establecer un ángulo de rotación personalizado para un [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/).

El siguiente ejemplo de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La rotación personalizada del texto](custom_text_rotation.png)

## **Establecer espaciado entre líneas de los párrafos**

Aspose.Slides ofrece [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spacebefore/) y [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/spacewithin/) para controlar el espaciado de los párrafos. Estas propiedades se usan de la siguiente manera:

* Utilice un valor positivo para especificar el espaciado entre líneas como un porcentaje de la altura de la línea.
* Utilice un valor negativo para especificar el espaciado entre líneas en puntos.

El siguiente ejemplo de código muestra cómo especificar el espaciado entre líneas dentro del párrafo:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El espaciado entre líneas dentro del párrafo](line_spacing.png)

## **Establecer tipo de ajuste automático para marcos de texto**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/autofittype/) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona la forma automáticamente.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Establecer ancla de los marcos de texto**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/anchoringtype/) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo en la parte superior, media o inferior.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Establecer tabulación del texto**

Utilice [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/defaulttabsize/) y [IParagraphFormat.Tabs](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/tabs/) para configurar los tabuladores en un párrafo.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

El resultado:

![Los tabuladores del párrafo](paragraph_tabs.png)

## **Establecer idioma de corrección**

Aspose.Slides proporciona [IPortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/languageid/), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma utilizado para la revisión ortográfica y gramatical en PowerPoint.

El siguiente ejemplo de código muestra cómo establecer el idioma de corrección para una porción de texto:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Establecer el Id de un idioma de corrección.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaulttextlanguage/) para definir el idioma predeterminado para el texto creado al cargar o crear una presentación.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Agregar una nueva forma rectangular con texto.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Comprobar el idioma de la primera porción.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Establecer estilo de texto predeterminado**

Para aplicar el formato de texto predeterminado a nivel de presentación, utilice [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/defaulttextstyle/).

El siguiente ejemplo de código muestra cómo establecer una fuente predeterminada en negrita con un tamaño de 14 pt para todo el texto en todas las diapositivas de una nueva presentación.

```cs
using (var presentation = new Presentation())
{
    // Obtener el formato de párrafo de nivel superior.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque inicialmente se haya escrito en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/es/net/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![El efecto de mayúsculas](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Salida:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Preguntas frecuentes**

**¿Cómo modificar texto en una tabla de una diapositiva?**

Para modificar texto en una tabla de una diapositiva, utilice [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/). Recorra las celdas y actualice cada celda mediante [ICell.TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/icell/textframe/) y el formato de párrafo mediante [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/paragraphformat/).

**¿Cómo aplicar un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [IPortionFormat.FillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/fillformat/). Establezca [IFillFormat.FillType](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformat/filltype/) a [FillType.Gradient](https://reference.aspose.com/slides/es/net/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.