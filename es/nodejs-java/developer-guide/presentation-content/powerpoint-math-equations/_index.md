---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en JavaScript
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en archivos PowerPoint PPT y PPTX con Aspose.Slides para Node.js a través de Java, con soporte de OMML, controles de formato y ejemplos de código JavaScript claros."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides para Node.js a través de Java, puedes crear el mismo tipo de contenido matemático de forma programada: fracciones, radicales, funciones, límites, operadores N-arios, matrices, arreglos y bloques matemáticos formateados.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insertar > Ecuación**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides construye ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [addMathShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addMathShape), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathportion/) almacena contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathblock/).

La mayoría de los ejemplos a continuación utilizan [MathematicalText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathematicaltext/) y los métodos fluidos de [MathElementBase](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para mantener el código corto y legible.

Para escenarios de exportación a MathML, consulta [Exportar ecuaciones matemáticas desde presentaciones en Node.js a través de Java](/slides/es/nodejs-java/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo crea una forma matemática y añade el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` crea una forma que ya contiene un párrafo matemático. Accede al primer `MathPortion`, obtén su `MathParagraph` y añade bloques matemáticos o elementos matemáticos.
{{% /alert %}}

## **Añadir fracciones**

Utiliza [`divide`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathfractiontypes/).

![Una fracción matemática sesgada que muestra uno dividido por x](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para una fracción apilada, usa `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Añadir radicales**

Utiliza [`radical`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para crear una raíz cuadrada, cúbica u otra raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de n-ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir funciones y límites**

Utiliza [`asArgumentOfFunction`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) o [`function`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathlimit/) o usa [`setLowerLimit`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/).

![El límite de x conforme x tiende a infinito](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para un nombre de función personalizado, haz que el nombre de la función sea el elemento actual:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Añadir operadores N-arios e integrales**

Utiliza [`nary`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para sumatorias, uniones, intersecciones y otros operadores grandes. Utiliza [`integral`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para integrales. Ambos métodos te permiten establecer límites inferior y superior.

![Una sumatoria con límites inferior y superior](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los operadores N-arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` se añaden normalmente como `MathematicalText` y se unen a la expresión.

Para una integral, usa `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, por lo que debes encerrarlas cuando necesites paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir arreglos de ecuaciones**

Utiliza [`toMathArray`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Un arreglo matemático vertical con x sobre y](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir funciones trigonométricas**

Utiliza [`asArgumentOfFunction`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) cuando el argumento sea el elemento actual y el nombre de la función sea conocido.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir subíndices y superíndices**

Utiliza los asistentes de subíndice y superíndice para índices y potencias. Cuando los índices deben aparecer al lado izquierdo de la base, usa [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/).

![Una Y mayúscula con subíndice 1 a la izquierda y superíndice n](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir delimitadores**

Utiliza [`enclose`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadoras que contengan varios elementos.

![Una expresión delimitadora que contiene x, y, y z separados por barras verticales](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir un cuadro con borde**

Utiliza [`toBorderBox`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) cuando la ecuación misma deba estar enmarcada.

![Una ecuación enmarcada que muestra a al cuadrado es igual a b al cuadrado más c al cuadrado](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar términos**

Utiliza [`group`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dar formato a los elementos matemáticos**

Utiliza los asistentes de formato solo donde clarifiquen la fórmula. Por ejemplo, [`overbar`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Referencia rápida**

| Tarea | Main API |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [join](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Crear fracciones | [divide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir superíndice o subíndice | [setSuperscript](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir funciones | [function](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir radicales | [radical](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir límites | [setLowerLimit](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir scripts a la izquierda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathmatrix/) |
| Añadir arreglos de ecuaciones | [toMathArray](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |
| Agrupar términos | [group](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathelementbase/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, localiza la forma que contiene un `MathPortion`, obtén su `MathParagraph` y actualiza los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas editables de PowerPoint?**

Sí. Al guardar en PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Aspose.Slides exporta ecuaciones matemáticas a MathML. Si necesitas LaTeX, primero exporta a MathML y luego convierte MathML con una herramienta que admita el dialecto LaTeX que requieras.