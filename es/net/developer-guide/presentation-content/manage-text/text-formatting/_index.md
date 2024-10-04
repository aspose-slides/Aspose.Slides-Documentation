---
title: Formato de Texto
linktitle: Formato de Texto
type: docs
weight: 50
url: /es/net/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafos de texto
- transparencia del texto
- propiedades de fuente de párrafo
- familia de fuentes
- rotación de texto
- rotación de ángulo personalizado
- marco de texto
- espaciado de línea
- propiedad de ajuste automático
- ancla del marco de texto
- tabulación de texto
- estilo de texto predeterminado
- C#
- Aspose.Slides para .NET
description: "Gestionar y manipular las propiedades del texto y del marco de texto en C#"
---

## Descripción General

Este artículo describe cómo **trabajar con el formato de texto de presentaciones de PowerPoint usando C#**, por ejemplo, resaltar texto, aplicar una expresión regular, alinear párrafos de texto, establecer la transparencia del texto, cambiar las propiedades de la fuente del párrafo, usar familias de fuentes, establecer una rotación de texto, personalizar una rotación de ángulo, gestionar un marco de texto, establecer un espaciado de línea, usar la propiedad de ajuste automático, establecer un ancla del marco de texto, cambiar la tabulación del texto. El artículo cubre estos temas.

## **Resaltar Texto**
Se ha añadido un nuevo método HighlightText a la interfaz ITextFrame y a la clase TextFrame.

Permite resaltar una parte del texto con color de fondo usando una muestra de texto, similar a la herramienta de color de resaltado de texto en PowerPoint 2019.

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con el archivo de entrada.
   - El archivo de entrada puede ser PPT, PPTX, ODP, etc.
3. Acceder a su diapositiva usando la colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)
4. Acceder a la forma usando la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) como [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Resaltar el texto usando el método [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext).
6. Guardar la presentación en el formato de salida deseado, es decir, PPT, PPTX u ODP, etc.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // resaltando todas las palabras 'importante'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // resaltando todas las ocurrencias separadas de 'el'
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose proporciona un simple [servicio de edición de PowerPoint en línea gratuito](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar Texto usando Expresión Regular**
Se ha añadido un nuevo método HighlightRegex a la interfaz ITextFrame y a la clase TextFrame.

Permite resaltar una parte del texto con color de fondo usando regex, similar a la herramienta de color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // resaltando todas las palabras con 10 símbolos o más
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **Establecer Color de Fondo del Texto**

Aspose.Slides permite especificar su color preferido para el fondo de un texto.

Este código C# le muestra cómo establecer el color de fondo para un texto completo:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Negro");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rojo ");
    
    var portion3 = new Portion("Negro");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

Este código C# le muestra cómo establecer el color de fondo para solo una porción de un texto:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Negro");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rojo ");
    
    var portion3 = new Portion("Negro");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Rojo"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **Alinear Párrafos de Texto**

El formato de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para .NET admite la adición de texto a las diapositivas, pero en este tema, veremos cómo podemos controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides para .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva utilizando su índice.
3. Acceder a las formas de marcador de posición presentes en la diapositiva y convertirlas a AutoShape.
4. Obtener el párrafo (que necesita ser alineado) del TextFrame expuesto por AutoShape.
5. Alinear el párrafo. Un párrafo se puede alinear a la derecha, izquierda, centro y justificar.
6. Escribir la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Accediendo a la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Cambiar el texto en ambos marcadores de posición
    tf1.Text = "Alinear al Centro por Aspose";
    tf2.Text = "Alinear al Centro por Aspose";

    // Obtener el primer párrafo de los marcadores de posición
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Alinear el párrafo de texto al centro
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // Escribir la presentación como un archivo PPTX
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Transparencia para el Texto**
Este artículo demuestra cómo establecer la propiedad de transparencia en cualquier forma de texto usando Aspose.Slides para .NET. Para establecer la transparencia en el texto. Siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva.
3. Establecer el color de sombra.
4. Escribir la presentación como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - la transparencia es: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // establecer transparencia al cero por ciento
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Establecer Espaciado de Caracteres para Texto**

Aspose.Slides permite establecer el espacio entre letras en un cuadro de texto. De esta manera, se puede ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espaciado entre caracteres.

Este código C# le muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // expandir
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // condensar

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Gestionar Propiedades de Fuente de Párrafo**

Las presentaciones suelen contener tanto texto como imágenes. El texto puede ser formateado de diversas maneras, ya sea para resaltar secciones y palabras específicas, o para ajustarse a estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia y el estilo del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para .NET para configurar las propiedades de fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides para .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva usando su índice.
3. Acceder a las formas de marcador de posición en la diapositiva y convertirlas a AutoShape.
4. Obtener el párrafo del TextFrame expuesto por AutoShape.
5. Justificar el párrafo.
6. Acceder a la porción de texto de un párrafo.
7. Definir la fuente usando FontData y establecer la fuente de la porción de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
8. Establecer el color de fuente usando el FillFormat expuesto por el objeto de Porción.
9. Escribir la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se da a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.

```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Accediendo a una diapositiva usando su posición en la diapositiva
    ISlide slide = pres.Slides[0];

    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Accediendo al primer párrafo
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Accediendo a la primera porción
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Definir nuevas fuentes
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Asignar nuevas fuentes a la porción
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Establecer la fuente en Negrita
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Establecer la fuente en Cursiva
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Establecer el color de la fuente
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // Escribir el PPTX en el disco
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```

## **Gestionar Familia de Fuentes de Texto**
Una Porción se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para .NET para crear un cuadro de texto con algo de texto y luego definir una fuente particular y varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer las propiedades de fuente del texto en él:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva usando su índice.
3. Agregar un AutoShape del tipo Rectángulo a la diapositiva.
4. Eliminar el estilo de relleno asociado con el AutoShape.
5. Acceder al TextFrame del AutoShape.
6. Agregar algo de texto al TextFrame.
7. Acceder al objeto Porción asociado con el TextFrame.
8. Definir la fuente que se utilizará para la Porción.
9. Establecer otras propiedades de fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto Porción.
10. Escribir la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

```c#
// Instanciar una Presentación
using (Presentation presentation = new Presentation())
{
   
    // Obtener la primera diapositiva
    ISlide sld = presentation.Slides[0];

    // Agregar un AutoShape del tipo Rectángulo
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Eliminar cualquier estilo de relleno asociado con el AutoShape
    ashp.FillFormat.FillType = FillType.NoFill;

    // Acceder al TextFrame asociado con el AutoShape
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Cuadro de Texto de Aspose";

    // Acceder a la Porción asociada con el TextFrame
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Establecer la Fuente para la Porción
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Establecer la propiedad Negrita de la Fuente
    port.PortionFormat.FontBold = NullableBool.True;

    // Establecer la propiedad Cursiva de la Fuente
    port.PortionFormat.FontItalic = NullableBool.True;

    // Establecer la propiedad Subrayado de la Fuente
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Establecer la Altura de la Fuente
    port.PortionFormat.FontHeight = 25;

    // Establecer el color de la Fuente
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Escribir el PPTX en disco 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Tamaño de Fuente para Texto**

Aspose.Slides permite elegir su tamaño de fuente preferido para el texto existente en un párrafo y otros textos que puedan añadirse al párrafo más adelante.

Este C# le muestra cómo establecer el tamaño de fuente para textos contenidos en un párrafo:

```c#
var presentation = new Presentation("example.pptx");

// Obtener la primera forma, por ejemplo.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // Obtener el primer párrafo, por ejemplo.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Establecer el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto en el párrafo. 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // Establecer el tamaño de fuente a 20 pt para las porciones de texto actuales en el párrafo. 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Establecer Rotación de Texto**

Aspose.Slides para .NET permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical o WordArtVerticalRightToLeft. Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Rotar el texto.
6. Guardar el archivo en disco.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtener la primera diapositiva 
ISlide slide = presentation.Slides[0];

// Agregar un AutoShape del tipo Rectángulo
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Agregar TextFrame al Rectángulo
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accediendo al marco de texto
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// Crear el objeto Párrafo para el marco de texto
IParagraph para = txtFrame.Paragraphs[0];

// Crear objeto Porción para el párrafo
IPortion portion = para.Portions[0];
portion.Text = "Un zorro marrón rápido salta sobre el perro perezoso. Un zorro marrón rápido salta sobre el perro perezoso.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Guardar presentación
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```

## **Establecer Ángulo de Rotación Personalizado para TextFrame**
Aspose.Slides para .NET ahora admite, establecer un ángulo de rotación personalizado para el text frame. En este tema, veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. La nueva propiedad RotationAngle se ha añadido a las interfaces IChartTextBlockFormat y ITextFrameFormat, y permite establecer el ángulo de rotación personalizado para el text frame. Para establecer la propiedad RotationAngle, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Agregar un gráfico en la diapositiva.
3. Establecer la propiedad RotationAngle.
4. Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, establecemos la propiedad RotationAngle.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Título personalizado").TextFrameFormat.RotationAngle = -30;

// Guardar presentación
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```

## **Espaciado de Línea de Párrafo**
Aspose.Slides proporciona propiedades ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore), y [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) bajo la clase [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) que le permiten gestionar el espaciado de línea para un párrafo. Las tres propiedades se utilizan de esta manera:

* Para especificar el espaciado de línea para un párrafo en porcentaje, use un valor positivo. 
* Para especificar el espaciado de línea para un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un espaciado de línea de 16pt para un párrafo estableciendo la propiedad `SpaceBefore` a -16.

Así es como se especifica el espaciado de línea para un párrafo específico:

1. Cargar una presentación que contenga un AutoShape con algo de texto en él.
2. Obtener la referencia de una diapositiva a través de su índice.
3. Acceder al TextFrame.
4. Acceder al Párrafo.
5. Establecer las propiedades del Párrafo.
6. Guardar la presentación.

Este código C# le muestra cómo especificar el espaciado de línea para un párrafo:

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Obtener la referencia de una diapositiva mediante su índice
ISlide sld = presentation.Slides[0];

// Acceder al TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Acceder al Párrafo
IParagraph para1 = tf1.Paragraphs[0];

// Establecer propiedades del Párrafo
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Guardar presentación
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```

## **Establecer la Propiedad AutofitType para TextFrame**
En este tema, exploraremos las diferentes propiedades de formato del marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType del marco de texto, anclar el texto y rotar el texto en la presentación. Aspose.Slides para .NET permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType puede establecerse en Normal o Shape. Si se establece en Normal, la forma permanecerá igual mientras que el texto se ajustará sin cambiar la forma en sí, mientras que si AutofitType se establece en Shape, la forma será modificada de tal manera que solo el texto requerido esté contenido en ella. Para establecer la propiedad AutofitType de un marco de texto, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Establecer el AutofitType del TextFrame.
6. Guardar el archivo en disco.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Acceder a la primera diapositiva 
ISlide slide = presentation.Slides[0];

// Agregar un AutoShape del tipo Rectángulo
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Agregar TextFrame al Rectángulo
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accediendo al marco de texto
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Crear el objeto Párrafo para el marco de texto
IParagraph para = txtFrame.Paragraphs[0];

// Crear objeto Porción para el párrafo
IPortion portion = para.Portions[0];
portion.Text = "Un zorro marrón rápido salta sobre el perro perezoso. Un zorro marrón rápido salta sobre el perro perezoso.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Guardar presentación
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```

## **Establecer Ancla de TextFrame**
Aspose.Slides para .NET permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca ese texto en la forma. TextAnchorType puede establecerse en Top, Center, Bottom, Justified o Distributed. Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Establecer el TextAnchorType del TextFrame.
6. Guardar el archivo en disco.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtener la primera diapositiva 
ISlide slide = presentation.Slides[0];

// Agregar un AutoShape del tipo Rectángulo
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Agregar TextFrame al Rectángulo
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accediendo al marco de texto
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Crear el objeto Párrafo para el marco de texto
IParagraph para = txtFrame.Paragraphs[0];

// Crear objeto Porción para el párrafo
IPortion portion = para.Portions[0];
portion.Text = "Un zorro marrón rápido salta sobre el perro perezoso. Un zorro marrón rápido salta sobre el perro perezoso.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Guardar presentación
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Establecer Tabulación de Texto**
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las tabulaciones predeterminadas).
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabulaciones predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera tabulación explícita (Posición = 731), index = 1 - segunda tabulación (Posición = 1241). Si intenta obtener la siguiente tabulación con index = 2, devolverá la primera tabulación predeterminada (Posición = 1470) y etc.
- EffectiveTabs.GetTabAfterPosition(pos) se utiliza para obtener la siguiente tabulación después de algún texto. Por ejemplo, tienes el texto: "¡Helloworld!". Para renderizar tal texto debes saber dónde comenzar a dibujar "¡world!". Al principio, debes calcular la longitud de "Hola" en píxeles y llamar a GetTabAfterPosition con ese valor. Obtendrás la posición de la siguiente tabulación para dibujar "¡world!".

## **Establecer Idioma de Corrección**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) para permitirle establecer el idioma de corrección para un documento de PowerPoint. El idioma de corrección es el idioma para el cual se revisan las ortografías y gramáticas en PowerPoint.

Este código C# le muestra cómo establecer el idioma de corrección para un PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // establecer el Id de un idioma de corrección
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Establecer Idioma Predeterminado**

Este código C# le muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint:

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Agrega una nueva forma rectangular con texto
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Nuevo Texto";
    
    // Comprueba el idioma de la primera porción
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **Establecer Estilo de Texto Predeterminado**

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación de una vez, puede utilizar la propiedad `DefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) y establecer el formato preferido. El siguiente ejemplo de código muestra cómo establecer la fuente predeterminada en negrita (14 pt) para el texto en todas las diapositivas en una nueva presentación.

```c#
using (Presentation presentation = new Presentation())
{
    // Obtener el formato de párrafo de nivel superior.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```