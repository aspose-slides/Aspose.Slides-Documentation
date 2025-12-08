---
title: Formatear texto de PowerPoint en C#
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
- espaciado entre caracteres
- propiedades de fuente
- familia de fuente
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- C#
- Aspose.Slides
description: "Aprenda a dar formato y estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET. Personalice fuentes, colores, alineación y más con potentes ejemplos de código en C#."
---

## **Descripción general**

Este artículo presenta cómo administrar y dar formato al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET. Aprenderá a aplicar características de formato de texto como selección de fuente, tamaño, color, resaltado, color de fondo, espaciado y alineación. Además, cubre el trabajo con marcos de texto, párrafos, formato y opciones avanzadas de diseño como rotación personalizada y comportamientos de ajuste automático.

Ya sea que esté generando presentaciones programáticamente o personalizando contenido existente, estos ejemplos le ayudarán a crear diseños de texto claros y profesionales que realzan sus diapositivas y mejoran la legibilidad.

En los ejemplos a continuación, utilizaremos un archivo llamado "sample.pptx", que contiene un solo cuadro de texto en la primera diapositiva con el siguiente texto:

![Sample text](sample_text.png)

## **Resaltar texto**

El método [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) permite resaltar una parte del texto con un color de fondo basado en una muestra de texto coincidente.

Para usar este método, siga estos pasos:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con un archivo de entrada (PPT, PPTX, ODP, etc.).
2. Acceda a la diapositiva deseada mediante la colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. Acceda a la forma objetivo de la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) y conviértala a [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Resalte el texto deseado usando el método [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) proporcionando el texto de muestra y el color.
5. Guarde la presentación en el formato de salida que desee (por ejemplo, PPT, PPTX, ODP).

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y la palabra completa **"to"**.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Obtenga la primera forma de la primera diapositiva.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Resalte la palabra "try" en la forma.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Resalte la palabra "to" en la forma.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The highlighted text](highlighted_text.png)

{{% alert color="primary" %}} 
Aspose ofrece un [EDITOR DE POWERPOINT EN LÍNEA GRATUITO](https://products.aspose.app/slides/editor). 
{{% /alert %}} 

## **Resaltar texto usando expresiones regulares**

Aspose.Slides para .NET le permite buscar y resaltar partes específicas de texto en diapositivas PowerPoint usando expresiones regulares. Esta característica es especialmente útil cuando necesita enfatizar dinámicamente palabras clave, patrones o contenido generado por datos. El método [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) le permite resaltar partes de texto con un color de fondo usando una expresión regular.

El ejemplo de código a continuación resalta todas las palabras que contienen **siete o más caracteres**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Resalte todas las palabras con siete o más caracteres.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Establecer color de fondo del texto**

Aspose.Slides para .NET le permite aplicar colores de fondo a párrafos completos o a porciones de texto individuales en diapositivas PowerPoint. Esta funcionalidad es útil cuando desea resaltar palabras o frases específicas, llamar la atención sobre mensajes clave o mejorar el atractivo visual de sus presentaciones.

El siguiente ejemplo de código muestra cómo establecer el color de fondo para el **párrafo completo**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establezca el color de resaltado para todo el párrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The gray paragraph](gray_paragraph.png)

El ejemplo de código a continuación demuestra cómo establecer el color de fondo para **porciones de texto con fuente en negrita**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Establezca el color de resaltado para la porción de texto.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The gray text portions](gray_text_portions.png)

## **Alinear párrafos de texto**

La alineación del texto es un aspecto clave del formato de diapositivas que afecta tanto la legibilidad como el atractivo visual. En Aspose.Slides para .NET, puede controlar con precisión la alineación de los párrafos dentro de los marcos de texto, garantizando que su contenido se presente de forma coherente, ya sea centrado, alineado a la izquierda, a la derecha o justificado. Esta sección explica cómo aplicar y personalizar la alineación del texto en sus presentaciones PowerPoint.

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

![The aligned paragraph](aligned_paragraph.png)

## **Establecer transparencia para el texto**

Ajustar la transparencia del texto le permite crear efectos visuales sutiles y mejorar la estética de las diapositivas. Aspose.Slides para .NET permite establecer el nivel de transparencia de párrafos y porciones de texto, facilitando la mezcla del texto con fondos o el énfasis en elementos específicos. Esta sección muestra cómo aplicar configuraciones de transparencia al texto en sus presentaciones.

El ejemplo de código a continuación muestra cómo aplicar transparencia al **párrafo completo**:
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

![The transparent paragraph](transparent_paragraph.png)

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

![The transparent text portions](transparent_text_portions.png)

## **Establecer espaciado entre caracteres para el texto**

Aspose.Slides le permite establecer el espaciado entre letras en un cuadro de texto. Esto le permite ajustar la densidad visual de una línea o bloque de texto al expandir o condensar el espacio entre caracteres.

El siguiente código C# muestra cómo expandir el espaciado entre caracteres en el **párrafo completo**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nota: Use valores negativos para comprimir el espaciado entre caracteres.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expandir el espaciado entre caracteres.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

El ejemplo de código a continuación muestra cómo expandir el espaciado entre caracteres en **porciones de texto con fuente en negrita**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nota: Use valores negativos para comprimir el espaciado entre caracteres.
            portion.PortionFormat.Spacing = 3;  // Expandir el espaciado entre caracteres.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

## **Administrar propiedades de fuente del texto**

Aspose.Slides para .NET le permite afinar la configuración de fuentes tanto a nivel de párrafo como para porciones de texto individuales, garantizando consistencia visual y cumpliendo con los requisitos de diseño de su presentación. Puede definir estilos de fuente, tamaños y otras opciones de formato para párrafos completos, lo que le brinda mayor control sobre la apariencia del texto. Esta sección demuestra cómo administrar propiedades de fuente para párrafos de texto en una diapositiva.

El siguiente código establece la fuente y el estilo de texto para el párrafo completo: aplica tamaño de fuente, negrita, cursiva, subrayado punteado y la fuente Times New Roman a todas las porciones del párrafo.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

El ejemplo de código a continuación aplica propiedades similares a **porciones de texto con fuente en negrita**:
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Establecer rotación del texto**

Rotar el texto puede mejorar el diseño de sus diapositivas y ayudar a enfatizar contenido específico. Con Aspose.Slides para .NET, puede aplicar fácilmente rotación al texto dentro de formas, ajustando el ángulo para que coincida con su diseño. Esta sección demuestra cómo establecer y controlar la rotación del texto para lograr el efecto visual deseado.

El siguiente ejemplo de código establece la orientación del texto en la forma a `Vertical270`, que rota el texto **90 grados en sentido antihorario**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The text rotation](text_rotation.png)

## **Establecer rotación personalizada para marcos de texto**

Establecer un ángulo de rotación personalizado para un `TextFrame` le permite posicionar el texto en ángulos precisos, habilitando diseños de diapositivas más creativos y flexibles. Aspose.Slides para .NET brinda control total sobre la rotación de los marcos de texto, facilitando alinear el texto con otros elementos de la diapositiva. Esta sección le guía para aplicar un ángulo de rotación específico a un `TextFrame`.

El ejemplo de código a continuación rota el marco de texto 3 grados en el sentido de las agujas del reloj dentro de la forma:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The custom text rotation](custom_text_rotation.png)

## **Establecer interlineado de párrafos**

Aspose.Slides proporciona las propiedades `SpaceAfter`, `SpaceBefore` y `SpaceWithin` bajo la clase [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), lo que le permite gestionar el interlineado de un párrafo. Estas propiedades se utilizan de la siguiente manera:

* Use un valor positivo para especificar el interlineado como un porcentaje de la altura de la línea.
* Use un valor negativo para especificar el interlineado en puntos.

El siguiente ejemplo de código muestra cómo especificar el interlineado dentro del párrafo:
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

![The line spacing within the paragraph](line_spacing.png)

## **Establecer tipo de ajuste automático para marcos de texto**

La propiedad AutoFitType determina cómo se comporta el texto cuando supera los límites de su contenedor. Aspose.Slides para .NET le permite controlar si el texto debe encogerse para ajustarse, desbordarse o redimensionar la forma automáticamente. Esta sección demuestra cómo establecer el `AutofitType` para un `TextFrame` y gestionar eficazmente el diseño del texto dentro de las formas.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Establecer ancla de los marcos de texto**

El anclaje define cómo se posiciona verticalmente el texto dentro de una forma. Con Aspose.Slides para .NET, puede establecer el tipo de ancla de un `TextFrame` para alinear el texto en la parte superior, media o inferior de la forma. Esta sección muestra cómo ajustar la configuración de ancla para lograr la alineación vertical deseada del contenido de texto.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Establecer tabulación del texto**

La tabulación ayuda a organizar el texto en diseños bien estructurados al añadir espaciado coherente entre los elementos de contenido. Aspose.Slides para .NET admite la configuración de tabuladores personalizados dentro de los párrafos de texto, lo que permite un control preciso sobre la posición del texto. Esta sección muestra cómo configurar la tabulación del texto para mejorar la alineación y el formato.
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

![The paragraph tabs](paragraph_tabs.png)

## **Establecer idioma de revisión**

Aspose.Slides ofrece la propiedad `LanguageId` de la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), que permite establecer el idioma de revisión para un documento PowerPoint. El idioma de revisión determina el idioma utilizado para la verificación ortográfica y gramatical en PowerPoint.

El siguiente ejemplo de código muestra cómo establecer el idioma de revisión para una porción de texto:
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

    // Establecer el Id de un idioma de revisión.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **Establecer idioma predeterminado**

Especificar el idioma predeterminado para el texto garantiza la corrección ortográfica, la guionización y el comportamiento de texto a voz adecuados en PowerPoint. Aspose.Slides para .NET le permite establecer el idioma a nivel de porción de texto o de párrafo. Esta sección muestra cómo definir el idioma predeterminado para el texto de su presentación.
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Agregar una nueva forma rectangular con texto.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Verificar el idioma de la primera porción.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **Establecer estilo de texto predeterminado**

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto en una presentación de una sola vez, puede usar la propiedad `DefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) y definir el formato que prefiera.

El siguiente ejemplo de código muestra cómo establecer una fuente negrita predeterminada con tamaño de 14 pt para todo el texto en todas las diapositivas de una nueva presentación.
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

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera una porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para manejar esto, verifique [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)—si indica `All`, simplemente convierta la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

 El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:
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


## **FAQ**

**¿Cómo modificar texto en una tabla de una diapositiva?**

Para modificar texto en una tabla de una diapositiva, debe usar el objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Puede iterar a través de todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat`.

**¿Cómo aplicar color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar color degradado al texto, use la propiedad `FillFormat` en [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Establezca `FilFormat` a `Gradient`, donde podrá definir los colores de inicio y fin del degradado, junto con otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.