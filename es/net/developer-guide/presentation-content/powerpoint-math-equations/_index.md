---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en .NET
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/net/powerpoint-math-equations/
keywords:
- ecuación matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- añadir ecuación matemática
- añadir símbolo matemático
- añadir fórmula matemática
- añadir texto matemático
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para .NET, con soporte de OMML, controles de formato y ejemplos de código C# claros."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides for .NET, puede crear el mismo tipo de contenido matemático mediante código: fracciones, radicales, funciones, límites, operadores N-arios, matrices, arreglos y bloques matemáticos con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones mediante **Insertar > Ecuación**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides genera ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [AddMathShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addmathshape/), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathportion/) almacena el contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathblock/).

La mayoría de los ejemplos siguientes utilizan [MathematicalText](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathematicaltext/) y los métodos fluidos de [IMathElement](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/) para mantener el código breve y legible.

Para escenarios de exportación a MathML, vea [Exportar ecuaciones matemáticas desde presentaciones en .NET](/slides/es/net/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo crea una forma matemática y añade el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape` crea una forma que ya contiene un párrafo matemático. Acceda al primer `MathPortion`, obtenga su `MathParagraph` y añada bloques matemáticos o elementos matemáticos a él.
{{% /alert %}}

## **Añadir fracciones**

Use `Divide` para crear una fracción. Puede elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathfractiontypes/).

![Una fracción matemática sesgada que muestra uno dividido por x](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Para una fracción apilada, use `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Añadir radicales**

Use `Radical` para crear una raíz cuadrada, raíz cúbica u otra raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de raíz n-ésima con x bajo el signo radical](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Añadir funciones y límites**

Use `AsArgumentOfFunction` o `Function` para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloque `lim` en un [MathLimit](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathlimit/) o use `SetLowerLimit`.

![El límite de x cuando x tiende a infinito](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Para un nombre de función personalizado, convierta el nombre de la función en el elemento actual:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Añadir operadores N-arios e integrales**

Use `Nary` para sumas, uniones, intersecciones y otros operadores grandes. Use `Integral` para integrales. Ambos métodos le permiten establecer límites inferior y superior.

![Una suma con límites inferior y superior](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Los operadores N-arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` suelen añadirse como `MathematicalText` y concatenarse en la expresión.

Para una integral, use `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Añadir matrices**

Use [MathMatrix](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, por lo que debe encerrar la matriz cuando necesite paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Añadir arreglos de ecuaciones**

Use `ToMathArray` cuando necesite ecuaciones alineadas o una pila vertical de expresiones.

![Un arreglo matemático vertical con x encima de y](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Añadir funciones trigonométricas**

Use `AsArgumentOfFunction` cuando el argumento es el elemento actual y el nombre de la función es conocido.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Añadir subíndices y superíndices**

Use los ayudantes de subíndice y superíndice para índices y potencias. Cuando los índices deben aparecer en el lado izquierdo de la base, use `SetSubSuperscriptOnTheLeft`.

![Una Y mayúscula con subíndice 1 a la izquierda y superíndice n](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Añadir delimitadores**

Use `Enclose` para colocar una expresión dentro de delimitadores. También puede establecer un carácter separador para expresiones delimitadas que contengan varios elementos.

![Una expresión delimitada que contiene x, y, y z separados por barras verticales](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **Añadir un recuadro con borde**

Use `ToBorderBox` cuando la ecuación misma debe estar enmarcada.

![Una ecuación enmarcada que muestra a al cuadrado es igual a b al cuadrado más c al cuadrado](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Agrupar términos**

Use `Group` para colocar un carácter de agrupación encima o debajo de una expresión. Añada un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo de ella](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Dar formato a los elementos matemáticos**

Use los ayudantes de formato solo donde clarifiquen la fórmula. Por ejemplo, `Overbar` coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.Join](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/join/) |
| Crear fracciones | [IMathElement.Divide](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/divide/) |
| Añadir superíndice o subíndice | [SetSuperscript](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Añadir funciones | [Function](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Añadir radicales | [IMathElement.Radical](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/radical/) |
| Añadir límites | [SetLowerLimit](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Añadir scripts del lado izquierdo | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Añadir sumas e integrales | [Nary](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/integral/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathmatrix/) |
| Añadir arreglos de ecuaciones | [ToMathArray](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Añadir delimitadores | [Enclose](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/enclose/) |
| Añadir barras y bordes | [Overbar](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Agrupar términos | [Group](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathelement/group/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación de PowerPoint existente?**

Sí. Abra la presentación, encuentre la forma que contiene un `MathPortion`, obtenga su `MathParagraph` y actualice los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas editables de PowerPoint?**

Sí. Al guardar en PPTX, Aspose.Slides escribe la ecuación como contenido matemático editable de Office.

**¿Puedo exportar ecuaciones a LaTeX?**

Aspose.Slides exporta ecuaciones matemáticas a MathML. Si necesita LaTeX, exporte primero a MathML y luego convierta MathML con una herramienta que admita el dialecto LaTeX que requiera.