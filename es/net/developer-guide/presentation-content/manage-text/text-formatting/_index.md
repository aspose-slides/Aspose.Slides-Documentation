---
title: Formato de texto de presentación en .NET
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
- familia de fuente
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
description: "Formatee y diseñe texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Personalice fuentes, colores, alineación y más."
---

## **Visión general**

Este artículo presenta cómo administrar y dar formato al texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para .NET. Aprenderá a aplicar características de formato de texto como la selección de fuente, tamaño, color, resaltado, color de fondo, espaciado y alineación. Además, cubre el trabajo con marcos de texto, párrafos, formato y opciones avanzadas de diseño como rotación personalizada y comportamientos de ajuste automático.

Ya sea que genere presentaciones programáticamente o personalice contenido existente, estos ejemplos le ayudarán a crear diseños de texto claros y de aspecto profesional que realzan sus diapositivas y mejoran la legibilidad.

En los ejemplos a continuación, utilizaremos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de muestra](sample_text.png)

## **Resaltar texto**

El método [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) permite resaltar una parte del texto con un color de fondo basado en una muestra de texto coincidente.

Para usar este método, siga estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con un archivo de entrada (PPT, PPTX, ODP, etc.).
2. Acceder a la diapositiva deseada usando la colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. Acceder a la forma objetivo de la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) y convertirla a [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Resaltar el texto deseado usando el método [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) proporcionando el texto de muestra y el color.
5. Guardar la presentación en el formato de salida deseado (p. ej., PPT, PPTX, ODP).

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y de la palabra completa **"to"**.
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

{{% alert color="primary" %}} 
Aspose ofrece un sencillo [Editor de PowerPoint en línea GRATUITO](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Resaltar texto usando expresiones regulares**

Aspose.Slides para .NET le permite buscar y resaltar partes específicas del texto en diapositivas de PowerPoint usando expresiones regulares. Esta característica es especialmente útil cuando necesita enfatizar dinámicamente palabras clave, patrones o contenido basado en datos. El método [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) permite resaltar partes del texto con un color de fondo usando una expresión regular.

El ejemplo de código a continuación resalta todas las palabras que contienen **siete o más caracteres**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Resaltar todas las palabras con siete o más caracteres.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Establecer color de fondo del texto**

Aspose.Slides para .NET le permite aplicar colores de fondo a párrafos completos o a porciones de texto individuales en diapositivas de PowerPoint. Esta funcionalidad es útil cuando desea resaltar palabras o frases específicas, llamar la atención sobre mensajes clave o mejorar el atractivo visual de sus presentaciones.

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

El ejemplo de código a continuación demuestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:
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

La alineación del texto es un aspecto clave del formato de diapositivas que afecta tanto a la legibilidad como al atractivo visual. En Aspose.Slides para .NET, puede controlar precisamente la alineación de los párrafos dentro de los marcos de texto, asegurando que su contenido se presente de forma consistente—ya sea centrado, alineado a la izquierda, a la derecha o justificado. Esta sección explica cómo aplicar y personalizar la alineación del texto en sus presentaciones de PowerPoint.

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

## **Establecer transparencia para texto**

Ajustar la transparencia del texto le permite crear efectos visuales sutiles y mejorar la estética de las diapositivas. Aspose.Slides para .NET proporciona la capacidad de establecer el nivel de transparencia de párrafos y porciones de texto, facilitando mezclar el texto con fondos o enfatizar elementos específicos. Esta sección muestra cómo aplicar configuraciones de transparencia al texto en sus presentaciones.

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

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:
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

## **Establecer espaciado de caracteres para texto**

Aspose.Slides le permite establecer el espaciado entre letras en un cuadro de texto. Esto le permite ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espacio entre caracteres.

El siguiente código C# muestra cómo expandir el espaciado de caracteres en el **párrafo completo**:
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

El ejemplo de código a continuación muestra cómo expandir el espaciado de caracteres en **porciones de texto con una fuente en negrita**:
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

## **Administrar propiedades de fuente de texto**

Aspose.Slides para .NET le permite afinar la configuración de fuentes tanto a nivel de párrafo como para porciones de texto individuales, asegurando consistencia visual y cumpliendo con los requisitos de diseño de su presentación. Puede definir estilos de fuente, tamaños y otras opciones de formato para párrafos completos, brindándole mayor control sobre la apariencia del texto. Esta sección demuestra cómo administrar las propiedades de fuente para párrafos de texto en una diapositiva.

El siguiente código establece la fuente y el estilo de texto para el párrafo completo: aplica tamaño de fuente, negrita, cursiva, subrayado punteado y la fuente Times New Roman a todas las porciones del párrafo.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer las propiedades de fuente para el párrafo.
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

El ejemplo de código a continuación aplica propiedades similares a **porciones de texto con una fuente en negrita**:
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

Girar el texto puede mejorar la disposición de sus diapositivas y ayudar a enfatizar contenido específico. Con Aspose.Slides para .NET, puede aplicar fácilmente rotación al texto dentro de formas, ajustando el ángulo para que coincida con su diseño. Esta sección demuestra cómo establecer y controlar la rotación del texto para lograr el efecto visual deseado.

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

Establecer un ángulo de rotación personalizado para un `TextFrame` le permite posicionar el texto en ángulos precisos, habilitando diseños de diapositivas más creativos y flexibles. Aspose.Slides para .NET brinda control total sobre la rotación de los marcos de texto, facilitando alinear el texto con otros elementos de la diapositiva. Esta sección le guía para aplicar un ángulo de rotación específico a un `TextFrame`.

El ejemplo de código a continuación rota el marco de texto 3 grados en sentido horario dentro de la forma:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


El resultado:

![La rotación de texto personalizada](custom_text_rotation.png)

## **Establecer interlineado de párrafos**

Aspose.Slides ofrece las propiedades `SpaceAfter`, `SpaceBefore` y `SpaceWithin` bajo la clase [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), lo que permite gestionar el interlineado de un párrafo. Estas propiedades se utilizan de la siguiente manera:

* Utilice un valor positivo para especificar el interlineado como un porcentaje de la altura de la línea.
* Utilice un valor negativo para especificar el interlineado en puntos.

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

![El interlineado dentro del párrafo](line_spacing.png)

## **Establecer tipo de ajuste automático para marcos de texto**

La propiedad AutoFitType determina cómo se comporta el texto cuando supera los límites de su contenedor. Aspose.Slides para .NET le permite controlar si el texto debe encogerse para ajustarse, desbordarse o redimensionar automáticamente la forma. Esta sección demuestra cómo establecer el `AutofitType` para un `TextFrame` para gestionar eficazmente el diseño del texto dentro de las formas.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Establecer anclaje de marcos de texto**

El anclaje define cómo se posiciona el texto dentro de una forma verticalmente. Con Aspose.Slides para .NET, puede establecer el tipo de anclaje de un `TextFrame` para alinear el texto en la parte superior, media o inferior de la forma. Esta sección muestra cómo ajustar la configuración de anclaje para lograr la alineación vertical deseada del contenido de texto.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Establecer tabulación de texto**

La tabulación ayuda a organizar el texto en diseños bien estructurados al agregar un espaciado coherente entre los elementos de contenido. Aspose.Slides para .NET soporta la configuración de tabulaciones personalizadas dentro de los párrafos de texto, permitiendo un control preciso sobre la posición del texto. Esta sección demuestra cómo configurar la tabulación de texto para mejorar la alineación y el formato.
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

![Las tabulaciones del párrafo](paragraph_tabs.png)

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad `LanguageId` de la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), que permite establecer el idioma de revisión para un documento de PowerPoint. El idioma de revisión determina el idioma utilizado para la corrección ortográfica y gramatical en PowerPoint.

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

Especificar el idioma predeterminado para el texto garantiza una correcta corrección ortográfica, guionado y comportamiento de texto a voz en PowerPoint. Aspose.Slides para .NET permite establecer el idioma a nivel de porción de texto o de párrafo. Esta sección muestra cómo definir el idioma predeterminado para el texto de su presentación.
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

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación de una sola vez, puede usar la propiedad `DefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) y definir el formato preferido.

El siguiente ejemplo de código muestra cómo establecer una fuente en negrita predeterminada con un tamaño de 14 pt para todo el texto en todas las diapositivas de una nueva presentación.
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

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera una porción de texto de este tipo con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para manejar esto, verifique [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)—si indica `All`, simplemente convierta la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

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

Para modificar texto en una tabla de una diapositiva, debe utilizar el objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Puede iterar todas las celdas de la tabla y cambiar el texto de cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat` dentro de cada celda.

**¿Cómo aplicar color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar color degradado al texto, use la propiedad `FillFormat` en [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Establezca `FilFormat` a `Gradient`, donde puede definir los colores de inicio y fin del degradado, junto con otras propiedades como la dirección y la transparencia para crear el efecto degradado en el texto.