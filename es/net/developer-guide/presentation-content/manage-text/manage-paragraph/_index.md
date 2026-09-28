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
- añadir texto
- añadir párrafo
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

* [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y demás formatos mediante el uso de varias porciones.

## **Crear y dar formato a párrafos**

### **Crear párrafos con varias porciones**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma.
5. Utilice el párrafo predeterminado y añada dos objetos [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) más al marco de texto.
6. Añada suficientes objetos [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) para que cada párrafo contenga tres porciones. El párrafo predeterminado ya contiene una porción vacía.
7. Establezca el texto de cada porción.
8. Aplique formato a nivel de carácter mediante [IPortion.PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/portionformat/).
9. Guarde la presentación modificada.

Este ejemplo en C# implementa los pasos:

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

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [IBulletFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma.
5. Elimine el párrafo predeterminado del marco de texto.
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Symbol](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/) y especifique el carácter de la viñeta.
8. Defina el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Cree un segundo párrafo y establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Numbered](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/).
11. Configure el estilo de viñeta numerada y añada el párrafo al marco de texto.
12. Guarde la presentación.

Este ejemplo en C# crea una viñeta de símbolo y una viñeta numerada:

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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) y acceda a su [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/).
4. Elimine el párrafo predeterminado del marco de texto.
5. Cargue la imagen de la viñeta y añádala a la colección de imágenes de la presentación como [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/) y establezca su texto.
7. Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/).
8. Asigne la imagen mediante [IBulletFormat.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/picture/) y defina la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Guarde la presentación modificada.

Este ejemplo en C# crea una viñeta de imagen:

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

Establezca [IParagraphFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/depth/) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) y elimine el párrafo predeterminado de su marco de texto.
3. Cree cuatro párrafos y configure sus símbolos de viñeta.
4. Establezca sus valores de [IParagraphFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/depth/) a `0`, `1`, `2` y `3`.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo en C# crea una lista con viñetas de cuatro niveles:

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

### **Iniciar los elementos numerados de la lista con valores personalizados**

Utilice [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith/) para establecer el número inicial que se muestra en un párrafo numerado.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a una diapositiva.
2. Elimine el párrafo predeterminado del marco de texto de la forma.
3. Cree tres párrafos numerados.
4. Establezca [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith/) a `2`, `3` y `7` para los párrafos correspondientes.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo en C# asigna un número inicial personalizado a cada párrafo:

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

## **Controlar la disposición y propiedades finales del párrafo**

### **Establecer una sangría de primera línea**

Utilice la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para controlar la sangría de la primera línea de un párrafo. Esta propiedad solo desplaza la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las demás líneas permanecen alineadas con el cuerpo del párrafo.

Utilice [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) cuando necesite mover todo el párrafo. Utilice [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) cuando solo necesite mover la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para demostrar cómo la sangría de primera línea afecta la disposición del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código muestra cómo establecer la sangría de un párrafo:

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

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es una disposición de párrafo en la que la primera línea comienza a la izquierda del resto de las líneas. En Aspose.Slides, se crea este efecto con la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/). Establezca `Indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo en `MarginLeft` y un valor negativo en `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) .
2. Acceda a la diapositiva objetivo.
3. Añada una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) para cada párrafo.
6. Establezca un valor negativo de [Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría colgante para un párrafo:

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

La propiedad [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/endparagraphportionformat/) controla el formato del marcador de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al marcador de fin del segundo párrafo:

1. Cargue una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) y elimine su párrafo predeterminado.
3. Cree dos párrafos y añada porciones de texto a ellos.
4. Cree un [PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/portionformat/) para el marcador de fin del segundo párrafo.
5. Establezca [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/fontheight/) y [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/latinfont/).
6. Asigne el formato a [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/endparagraphportionformat/) y guarde la presentación.

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

Para reglas de párrafo que afectan el ajuste automático y la puntuación al final de línea, consulte [Control de salto de línea](/slides/es/net/text-formatting/#control-line-breaking) y [Control de puntuación colgante](/slides/es/net/text-formatting/#control-hanging-punctuation).

Utilice [IParagraph.GetLinesCount](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getlinescount/) para contar las líneas ocupadas por un párrafo después del diseño del texto, incluido el ajuste automático. Esto es útil al comprobar la longitud y disposición del texto en plantillas de presentaciones.

Un párrafo es un elemento de [ITextFrame.Paragraphs](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/paragraphs/), y puede ocupar varias líneas renderizadas. Un salto de línea explícito dentro de un párrafo fuerza una nueva línea sin crear otro párrafo. El ajuste automático crea líneas según el ancho disponible sin insertar saltos de línea explícitos en el texto. Por lo tanto, contar párrafos o caracteres de salto de línea no brinda el recuento de líneas renderizadas.

El siguiente ejemplo crea una forma de texto, cuenta sus líneas, estrecha la forma y luego reemplaza el texto por una cadena más corta. El ajuste está habilitado y el autofit está desactivado para que el ancho de la forma controle el ajuste sin reducir automáticamente el texto ni cambiar el tamaño de la forma. Las dimensiones de la forma están en puntos. Finalmente, el ejemplo añade otro párrafo y suma los recuentos de líneas en todo el marco de texto.

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

Con este texto y estas dimensiones, estrechar la forma aumenta el recuento de líneas, mientras que reemplazar el texto por la cadena corta lo reduce. Los recuentos exactos pueden variar según la disponibilidad y sustitución de fuentes, el tamaño de la fuente, los márgenes, la sangría, el ajuste y la configuración de autofit. Utilice las fuentes y la configuración de disposición previstas para el entorno objetivo al comprobar una plantilla.

El número de líneas por sí solo no determina si el texto desborda su contenedor. También influyen la altura disponible, la altura de las líneas, el espaciado de párrafos y líneas, y el comportamiento de autofit; incluso una única línea puede superar el ancho disponible cuando el ajuste está desactivado.

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Utilice [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphcollection/addfromhtml/) para convertir marcado HTML en párrafos y porciones dentro de un marco de texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a una diapositiva y añada una [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma y elimine su párrafo predeterminado.
4. Lea el archivo HTML de origen.
5. Pase la cadena HTML a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Guarde la presentación modificada.

Este ejemplo en C# importa HTML en un marco de texto:

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

Utilice [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphcollection/exporttohtml/) para exportar un rango seleccionado de párrafos como HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) y cargue la presentación deseada.
2. Acceda a la diapositiva y encuentre la [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) que contiene el texto.
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la forma.
4. Llame a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphcollection/exporttohtml/) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escriba la cadena HTML devuelta en un archivo.

Este ejemplo en C# exporta todos los párrafos del primer marco de texto:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Renderizar un párrafo como imagen**

[IParagraph.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getimage/) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/save/). No es necesario renderizar la forma que lo contiene ni recortar un bitmap manualmente.

[IParagraph.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getimage/) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de su uso.

#### **Renderizar un párrafo a escala predeterminada**

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El ejemplo siguiente renderiza el segundo párrafo en una forma de texto normal a escala predeterminada y guarda la imagen resultante en formato PNG. La declaración `using` garantiza que la imagen se libere correctamente.

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

#### **Renderizar un párrafo en una celda de tabla con escala**

Utilice la sobrecarga de [IParagraph.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getimage/) que acepta los parámetros `float scaleX` y `float scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG.

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

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, dando como resultado cuatro veces más píxeles. Los factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores inferiores a `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para preservar la relación de aspecto del párrafo; factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [IShape.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getimage/) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen solo del párrafo, use [IParagraph.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getimage/).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/wraptext/) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [IParagraph.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getrect/) para obtener el rectángulo delimitador del párrafo. [IPortion.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/getrect/) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/alignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de las porciones individuales.

**¿Puedo establecer el idioma de corrección para una parte de un párrafo?**

Sí. Establezca [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.