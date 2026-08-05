---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en PHP
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para PHP mediante Java, compatible con OMML, controles de formato y ejemplos claros de código PHP."
---
## **Descripción general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides para PHP mediante Java, puedes crear el mismo tipo de contenido matemático mediante código: fracciones, radicales, funciones, límites, operadores N‑arios, matrices, arreglos y bloques matemáticos con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insertar > Ecuación**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides genera ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [addMathShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/#addMathShape), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/) almacena el contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathblock/).

La mayoría de los ejemplos a continuación usan [MathematicalText](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathematicaltext/) y los métodos fluidos de [MathElementBase](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para mantener el código corto y legible.

Para escenarios de exportación a MathML, consulta [Export Math Equations from Presentations in PHP via Java](/slides/es/php-java/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo crea una forma matemática y añade el teorema de Pitágoras:

![La ecuación c al cuadrado igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}

`addMathShape` crea una forma que ya contiene un párrafo matemático. Accede al primer `MathPortion`, obtén su `MathParagraph` y añade bloques matemáticos o elementos matemáticos.

{{% /alert %}}

## **Añadir fracciones**

Utiliza [`divide`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathfractiontypes/).

![Una fracción matemática sesgada que muestra uno dividido por x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Para una fracción apilada, usa `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Añadir radicales**

Utiliza [`radical`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para crear una raíz cuadrada, cúbica u otro tipo de raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de n‑ésima raíz con x bajo el símbolo radical](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir funciones y límites**

Utiliza [`asArgumentOfFunction`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) o [`function`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathlimit/) o usa [`setLowerLimit`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/).

![El límite de x cuando x tiende a infinito](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Para un nombre de función personalizado, haz que el nombre de la función sea el elemento actual:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Añadir operadores N‑arios e integrales**

Utiliza [`nary`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para sumas, uniones, intersecciones y otros operadores grandes. Utiliza [`integral`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para integrales. Ambos métodos permiten establecer límites inferior y superior.

![Una suma con límites inferior y superior](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Los operadores N‑arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` suelen añadirse como `MathematicalText` y combinarse en la expresión.

Para una integral, usa `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, por lo que debes encerrar la matriz cuando necesites paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir arreglos de ecuaciones**

Utiliza [`toMathArray`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Un arreglo matemático vertical con x encima de y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir funciones trigonométricas**

Utiliza [`asArgumentOfFunction`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) cuando el argumento sea el elemento actual y se conozca el nombre de la función.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir subíndices y superíndices**

Utiliza los ayudantes de subíndice y superíndice para índices y potencias. Cuando los índices deban aparecer a la izquierda de la base, usa [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/).

![Una Y mayúscula con subíndice 1 y superíndice n a la izquierda](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir delimitadores**

Utiliza [`enclose`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadoras que contengan varios elementos.

![Una expresión delimitadora que contiene x, y y z separados por barras verticales](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Añadir un recuadro**

Utiliza [`toBorderBox`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) cuando la ecuación misma deba estar enmarcada.

![Una ecuación en recuadro que muestra a² = b² + c²](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Agrupar términos**

Utiliza [`group`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) para colocar un carácter de agrupación arriba o bajo una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x + y agrupada con la etiqueta cualquier texto debajo](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Formatear elementos matemáticos**

Utiliza los ayudantes de formato solo donde clarifiquen la fórmula. Por ejemplo, [`overbar`](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [join](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Crear fracciones | [divide](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir superíndice o subíndice | [setSuperscript](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir funciones | [function](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir radicales | [radical](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir límites | [setLowerLimit](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir scripts a la izquierda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathmatrix/) |
| Añadir arreglos de ecuaciones | [toMathArray](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |
| Agrupar términos | [group](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathelementbase/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, busca la forma que contenga un `MathPortion`, obtén su `MathParagraph` y actualiza los bloques matemáticos en ese párrafo.

**¿Las ecuaciones se guardan como math editable de PowerPoint?**

Sí. Al guardar en PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Sí. Obtén el [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/) de su [MathPortion](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/) y llama a [MathParagraph::toLatex](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/#toLatex) para exportarlo directamente. Para un ejemplo completo, consulta [Export Math Equations from Presentations in PHP via Java](/slides/es/php-java/exporting-math-equations/#export-math-equations-to-latex).