---
title: Administrar párrafos de texto de PowerPoint en .NET
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
  - agregar texto
  - agregar párrafo
  - gestionar texto
  - gestionar párrafo
  - gestionar viñeta
  - sangría de párrafo
  - sangría colgante
  - viñeta de párrafo
  - lista numerada
  - lista con viñetas
  - propiedades del párrafo
  - importar HTML
  - texto a HTML
  - párrafo a HTML
  - párrafo a imagen
  - texto a imagen
  - exportar párrafo
  - PowerPoint
  - presentación
  - .NET
  - C#
  - Aspose.Slides
description: "Aprenda a crear y dar formato a párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides para .NET."
---
## **Visión general**

Aspose.Slides for .NET representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y dar formato a párrafos**

Cree párrafos en el marco de texto de una forma y utilice porciones para dar formato a ejecuciones de texto individuales. Esta sección muestra cómo combinar varias porciones dentro de cada párrafo y aplicar diferentes colores, tamaños de fuente y estilos.

### **Crear párrafos con múltiples porciones**

El siguiente ejemplo en C# crea tres párrafos, cada uno con tres ejecuciones de texto en su colección [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). Reutiliza el párrafo predeterminado y su porción vacía, luego agrega los párrafos y porciones restantes. El formato se aplica a través de [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): la primera porción en cada párrafo es roja, en negrita y de 15 puntos; la segunda es azul, en cursiva y de 18 puntos. La tercera porción conserva su formato predeterminado:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Crear listas con viñetas y numeradas**

Organice el texto de los párrafos en listas con símbolos, números o imágenes personalizadas. Los ejemplos de esta sección cubren el formato de viñetas, listas multinivel y números de inicio personalizados.

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la exploración de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Este ejemplo en C# agrega una viñeta de símbolo y un elemento numerado al mismo marco de texto. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) selecciona el tipo de viñeta, mientras que [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) proporciona el símbolo y [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) selecciona el estilo de numeración. Ambos elementos usan viñetas negras con una altura del 100 % y una sangría de párrafo de 25 puntos:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Usar viñetas de imagen**

Las viñetas de imagen le permiten usar una imagen personalizada en lugar de un símbolo o número.

Este ejemplo en C# agrega una imagen a la colección de imágenes de la presentación como un [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) y la utiliza como viñeta de párrafo. Establece [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) para usar una viñeta de imagen y asigna la imagen mediante [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) se establece en 100 % para dimensionar la viñeta en relación con el texto del párrafo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Crear una lista multinivel**

Establezca [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) para situar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

Este ejemplo en C# asigna valores de [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) de 0 a 3 a cuatro párrafos, creando una jerarquía dentro de un mismo marco de texto. Cada párrafo usa una viñeta de símbolo, con [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) alternando entre una viñeta redonda y un guion para diferenciar los niveles adyacentes:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Iniciar elementos de lista numerada con valores personalizados**

Utilice [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) para establecer el número inicial que se muestra en un párrafo numerado.

Este ejemplo en C# establece [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) para usar numeración en tres párrafos y asigna valores de [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) de 2, 3 y 7. El valor de inicio se configura por separado para cada párrafo, lo que permite que los números mostrados omitan valores:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Controlar el diseño del párrafo y sus propiedades finales**

Ajuste los márgenes y sangrías de los párrafos para controlar la posición de la primera línea y de las líneas continuas. También puede dar formato al carácter de fin de párrafo por separado del texto visible.

### **Establecer una sangría de primera línea**

Utilice la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) para controlar la sangría de la primera línea de un párrafo. Esta propiedad solo desplaza la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Use [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) cuando necesite mover todo el párrafo. Use [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) cuando necesite mover solo la primera línea.

El siguiente ejemplo asigna a tres párrafos la misma [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) de 20 puntos y valores de [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) de 0, 20 y 40 puntos. Las primeras líneas comienzan en desplazamientos progresivamente mayores, mientras que las líneas continuas conservan el mismo margen izquierdo:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

El resultado:

![El sangrado de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda de las líneas restantes. En Aspose.Slides, crea este efecto con la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Establezca `Indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo de `MarginLeft` y un valor negativo de `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas continuas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

El siguiente ejemplo en C# combina valores de [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) de 40 y 60 puntos con valores de [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) de -20 y -30 puntos. En cada párrafo, la primera línea comienza a la izquierda de las líneas continuas; el segundo párrafo tiene una sangría colgante más profunda:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución al final del párrafo**

La propiedad [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) controla el formato del carácter de fin de párrafo. El siguiente ejemplo crea un [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) con [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) establecido en 48 puntos y [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) a Times New Roman. Asigna este formato al carácter de fin del segundo párrafo, dejando sin cambios las porciones de texto visibles:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Contar líneas renderizadas**

Para las reglas de párrafo que afectan el ajuste automático y la puntuación al final de línea, consulte [Control Line Breaking](/slides/es/net/text-formatting/#control-line-breaking) y [Control Hanging Punctuation](/slides/es/net/text-formatting/#control-hanging-punctuation).

Utilice [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) para contar las líneas ocupadas por un párrafo después del diseño del texto, incluido el ajuste automático. Esto es útil al comprobar la longitud del texto y el diseño en plantillas de presentaciones.

Un párrafo es un elemento de [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), y puede ocupar varias líneas renderizadas. Un salto de línea explícito dentro de un párrafo fuerza una nueva línea sin crear otro párrafo. El ajuste automático crea líneas en función del ancho disponible sin insertar saltos de línea explícitos en el texto. Por lo tanto, contar párrafos o caracteres de salto de línea no proporciona el recuento de líneas renderizadas.

El siguiente ejemplo crea una forma de texto, cuenta sus líneas, estrecha la forma y luego reemplaza el texto por una cadena más corta. El ejemplo habilita [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) y deshabilita [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) para que el ancho de la forma controle el ajuste sin reducir automáticamente el texto ni redimensionar la forma. Cada medición utiliza [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Las dimensiones de la forma están en puntos. Finalmente, el ejemplo agrega otro párrafo y suma los recuentos de líneas de todo el marco de texto.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Con este texto y estas dimensiones, estrechar la forma incrementa el número de líneas, mientras que reemplazar el texto por la cadena corta lo reduce. Los recuentos exactos pueden variar según la disponibilidad y sustitución de fuentes, el tamaño de fuente, los márgenes, la sangría, el ajuste y la configuración de autofit. Use las fuentes y la configuración de diseño previstas para el entorno de destino al validar una plantilla.

El recuento de líneas por sí solo no determina si el texto se desborda del contenedor. También importan la altura disponible, la altura de línea, el espaciado de párrafo y línea, y el comportamiento de autofit; incluso una sola línea puede superar el ancho disponible cuando el ajuste está desactivado.

## **Importar y exportar contenido de párrafos**

Utilice HTML para introducir texto en una presentación o exportar párrafos existentes para usarlos fuera de ella. Esta sección también muestra cómo renderizar párrafos individuales como imágenes, incluidos los párrafos en celdas de tabla.

### **Importar texto HTML a párrafos**

Use [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) para convertir marcado HTML en párrafos y porciones en un marco de texto.

Este ejemplo en C# lee HTML de un archivo y pasa el marcado a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Elimina el párrafo predeterminado del marco de texto para que el marco contenga solo el contenido importado. La forma rectangular deja un margen de 10 puntos en cada lado de la diapositiva:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Exportar texto de párrafo a HTML**

Use [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) para exportar un rango seleccionado de párrafos como HTML. Al reutilizar texto de una presentación en un sitio web, puede desear conservar el énfasis local sin trasladar la fuente, el tamaño o los estilos del cuadro de texto de la presentación. Establezca [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) para controlar hasta dónde sigue el exportador la herencia de formato.

Descargue [la presentación de ejemplo](text-inheritance.pptx) y colóquela en el directorio de trabajo de la aplicación. Su primera diapositiva contiene una forma de texto con el texto "Inherited text; explicit red 18pt". La entrada usa deliberadamente varios niveles de formato:

- El estilo de texto predeterminado de la presentación suministra Calibri y un tamaño de 28 pt.
- El estilo de texto de primer nivel del marco de texto suministra texto azul e itálica.
- El párrafo establece explícitamente texto en negrita.
- La segunda porción, "explicit red 18pt", establece explícitamente texto rojo y un tamaño de 18 pt.

El siguiente ejemplo completo exporta los mismos párrafos tres veces. Pasa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) al método de exportación y escribe cada resultado en un archivo HTML UTF‑8 separado:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

El HTML generado contiene el siguiente CSS para la primera porción, "Inherited text; ". La tabla enumera las declaraciones relevantes; otras propiedades generadas se omiten por claridad.

| Salida | CSS relevante para la primera porción | Apariencia |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, en negrita y cursiva a 28 pt en Calibri, si esa fuente está disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, en negrita y cursiva; la página o el navegador proporcionan la familia y el tamaño de fuente. |
| `ParagraphOnly.html` | `font-weight:bold` | Texto en negrita; la página o el navegador proporcionan la familia, el tamaño, el color y el estilo cursiva. |

La segunda porción conserva `color:#ff0000`, `font-size:18pt` y `font-weight:bold` en los tres resultados. También conserva la cursiva en `All` y `TextBox`, pero no en `ParagraphOnly`. Restringir la herencia, por tanto, no elimina el formato asignado explícitamente a un párrafo o porción.

Abra los archivos en el mismo navegador para compararlos. En los dos modos restringidos, las propiedades CSS omitidas se resuelven mediante los estilos de la página de destino o los valores predeterminados del navegador, de modo que la apariencia resultante depende del entorno donde se utilice el HTML.

### **Renderizar un párrafo como imagen**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no se puede renderizar. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de usarla.

#### **Renderizar un párrafo a escala predeterminada**

El ejemplo usa una presentación con una diapositiva cuya primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo selecciona el segundo párrafo en el índice 1 y llama a [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) sin parámetros de escala. Verifica que la forma contenga el párrafo requerido y que el renderizado devuelva una imagen antes de llamar a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) para guardarla en formato PNG. La declaración `using` libera la imagen después de su uso.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Utilice la sobrecarga de [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) que acepta los parámetros `float scaleX` y `float scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y alto predeterminados, y guarda el resultado como imagen PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuyo ancho y alto son aproximadamente el doble de las dimensiones originales, lo que genera cuatro veces más píxeles. Factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Factores por debajo de `1` producen imágenes más pequeñas con menos detalle. Use factores iguales para conservar la proporción del párrafo; factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen solo del párrafo, utilice [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) para obtener el rectángulo delimitador del párrafo. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación de párrafo (izquierda, derecha, centrado o justificado)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de porciones individuales.

Para alinear verticalmente porciones de diferentes tamaños de fuente dentro de cada línea, consulte [Align Fonts Within a Line](/slides/es/net/text-formatting/#align-fonts-within-a-line).

**¿Puedo establecer el idioma de revisión para parte de un párrafo?**

Sí. Establezca [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.