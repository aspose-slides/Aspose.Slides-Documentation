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
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para PHP a través de Java, con soporte OMML, controles de formato y ejemplos claros de código PHP."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides para PHP a través de Java, puedes crear el mismo tipo de contenido matemático de forma programática: fracciones, radicales, funciones, límites, operadores N-ario, matrices, arreglos y bloques matemáticos con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insert > Equation**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides genera ese texto matemático a través de tres objetos principales:

- Una forma matemática, creada con [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) almacena contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

La mayoría de los ejemplos a continuación utilizan [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) y los métodos fluidos de [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) para mantener el código corto y legible.

Para escenarios de exportación a MathML, consulta [Exportar ecuaciones matemáticas desde presentaciones en PHP a través de Java](/slides/es/php-java/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo utiliza [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) para crear una forma matemática y agrega el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) crea una forma que ya contiene un párrafo matemático. Accede al primer [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), y añade bloques matemáticos o elementos matemáticos a él.
{{% /alert %}}

## **Añadir fracciones**

Utiliza [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Una fracción matemática inclinada que muestra uno dividido por x](powerpoint-math-equations_4.png)

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

Para una fracción apilada, utiliza [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Añadir radicales**

Utiliza [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) para crear una raíz cuadrada, raíz cúbica u otra raíz. El elemento actual se convierte en la base, y el argumento se convierte en el índice.

![Una expresión radical de n-ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

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

### **Mostrar u ocultar el grado de una raíz cuadrada**

Una raíz cuadrada puede mostrar un 2 explícito o usar la notación convencional √x. El método [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) de [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) controla qué forma aparece. Ambas formas conservan el grado 2 y el radicando x en la ecuación editable.

![La misma raíz cuadrada con el grado visible a la izquierda y oculto a la derecha](square-root-degree.png)

El ejemplo guarda la misma raíz cuadrada dos veces. En `visible-degree.pptx`, el 2 es visible. En `hidden-degree.pptx`, está oculto.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Añadir funciones y límites**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) o [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) o usa [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

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

Para un nombre de función personalizado, haz que el nombre de la función sea el elemento actual y llama a [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) con su argumento:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Añadir operadores N-ario e integrales**

Utiliza [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) para sumas, uniones, intersecciones y otros operadores extensos. Utiliza [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) para integrales. Ambos métodos permiten establecer límites inferior y superior.

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

Los operadores N-ario son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` se añaden normalmente como [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) y se unen a la expresión.

Para una integral, utiliza [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, así que encierra la matriz cuando necesites paréntesis, corchetes o llaves.

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

### **Editar una matriz existente**

Supongamos que una lección de álgebra lineal comienza con la matriz de coeficientes en `matrix.pptx`, guardada por el ejemplo anterior. Para el siguiente ejercicio, conserva la primera ecuación, reemplaza la segunda con dos nuevas ecuaciones y revisa el conjunto de variables. Abre la matriz existente mediante [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) para conservar los coeficientes que aún son aplicables.

![Matriz de coeficientes original de dos filas con entradas 1, x y una celda vacía en la primera fila, y x, 2 y y en la segunda](matrix-before-edit.png)

Los índices de filas y columnas comienzan en cero y se refieren a la matriz tal como está en cada llamada. Insertar una fila antes del índice 1 desplaza la fila segunda original al índice 2. Insertar después del índice 2 añade una fila. Eliminar la fila 2 quita la ecuación segunda original y mueve la fila añadida una posición arriba. Las columnas se desplazan de la misma manera.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // Las nuevas celdas son inicialmente nulas. Establece primero los coeficientes distintos de cero.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) alinea la primera columna a la izquierda. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) alinea tres columnas consecutivas a la derecha, comenzando en el índice 1. En `updated-matrix.pptx`, la matriz tiene tres ecuaciones y cuatro variables. Los coeficientes de la primera fila original `1` y `x` ahora aparecen en la primera y tercera columnas.

![Matriz actualizada de tres filas mostrando las filas 1, 0, x, 0; 12, 1, 0, 0; y 0, 0, 10, 1](matrix-after-edit.png)

## **Añadir matrices de ecuaciones**

Utiliza [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Una matriz matemática vertical con x encima de y](powerpoint-math-equations_11.png)

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

### **Alinear una matriz con los elementos circundantes**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) controla la alineación vertical de una matriz respecto a los elementos matemáticos a su lado. El ejemplo a continuación compara la alineación con la primera fila, el centro de la matriz y la última fila.

El siguiente ejemplo crea tres matrices idénticas, cada una con tres filas y los elementos vecinos `A=` y `=B`. Todo el texto matemático utiliza Cambria Math a 24 puntos. Sólo cambia la alineación de la matriz.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La siguiente comparación muestra la presentación guardada en PowerPoint. Observa la posición de `A=` y `=B` junto a cada matriz.

![Matrices de ecuaciones en PowerPoint con alineación Superior, Centro e Inferior y elementos vecinos idénticos](equation-array-alignment.png)

### **Configurar el espaciado de filas**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) selecciona la regla de espaciado para las filas dentro de la matriz. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) proporciona un valor numérico para una regla de espaciado explícita y se ignora con las reglas predefinidas.

Para un espaciado exacto, el valor se mide en puntos. Para un espaciado proporcional, se mide en medias líneas: el valor `3` en el ejemplo indica 1,5 líneas. Establece ambas propiedades al especificar un valor explícito; cambiar solo el valor numérico no selecciona una regla de espaciado.

El ejemplo a continuación guarda cinco presentaciones con las mismas ecuaciones, alineación y configuración de fuente. Las tres primeras usan preajustes; las dos últimas muestran valores explícitos.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

El espaciado de filas de la matriz es independiente del espaciado de párrafo. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) y [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) añaden espacio alrededor del párrafo contenedor, no entre filas de la matriz. De manera similar, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) posiciona todo el párrafo matemático horizontalmente; no sustituye la configuración de alineación vertical de la matriz.

## **Añadir funciones trigonométricas**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) cuando el argumento es el elemento actual y se conoce el nombre de la función.

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

Utiliza los asistentes de subíndice y superíndice para índices y exponentes. Cuando los índices deben aparecer en el lado izquierdo de la base, utiliza [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Una Y mayúscula con subíndice 1 a la izquierda y superíndice n](powerpoint-math-equations_9.png)

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

Utiliza [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadas que contienen varios elementos.

![Una expresión delimitada que contiene x, y y z separados por barras verticales](powerpoint-math-equations_13.png)

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

### **Tamaño y alineación de delimitadores**

Pasa `true` a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) para que los paréntesis crezcan alrededor de un operando alto, o pasa `false` para mantener su tamaño normal. Utiliza [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) con uno de los dos valores de [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` centra los paréntesis en el eje matemático, que pasa por el medio del signo igual. `Match` los alinea con el contenido incluido. Ambas configuraciones afectan solo a los delimitadores. La expresión interior permanece igual.

El ejemplo coloca una fracción en el exponente de `x` de modo que la expresión se extienda más arriba de la línea de base que abajo. Las cuatro ecuaciones utilizan los mismos paréntesis y configuración de fuente.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En PowerPoint, compara las filas para ver el efecto del crecimiento. En la fila superior, los paréntesis crecen para encerrar el exponente y se ven iguales para ambas formas. En la fila inferior, el crecimiento está desactivado. Los paréntesis más pequeños a la izquierda (`Centered`) se alinean con el signo igual, mientras que los de la derecha (`Match`) se sitúan más altos alrededor de la expresión.

![Cuatro ecuaciones en PowerPoint con crecimiento de delimitadores activado arriba y desactivado abajo, y Centered a la izquierda y Match a la derecha](delimiter-sizing.png)

## **Añadir un cuadro con borde**

Llama a [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) sobre una fracción para encuadrar toda la expresión. El [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) devuelto muestra los cuatro lados por defecto. Utiliza [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) y [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) para eliminar lados individuales.

El ejemplo coloca seis copias de la misma fracción en una diapositiva. Para mostrar cancelación, oculta los cuatro lados y pasa `true` a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) para una diagonal ascendente (↗) o a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) para una diagonal descendente (↘). También puedes usar [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) o [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) con cualquier combinación de lados visibles.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Seis fracciones editables en PowerPoint. Fila superior: borde completo, lados inferior e izquierdo, diagonal ascendente. Fila inferior: diagonal descendente, barra horizontal, barra vertical con borde completo](border-box-fractions.png)

En esta fracción, la barra horizontal se superpone a la barra de la fracción. La barra vertical cruza tanto el numerador como el denominador mientras el borde circundante permanece visible. Estas líneas decoran toda la expresión. El tachado de texto ordinario se aplica a los caracteres dentro de una ejecución de texto. Después de volver a abrir la presentación en PowerPoint, aún puedes editar el numerador y el denominador de forma independiente.

## **Controlar la visibilidad y disposición con elementos fantasma**

Envuelve una expresión en [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) para controlar su visibilidad y el espacio que aporta a una ecuación de forma independiente. Los métodos de [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) controlan lo siguiente:

| Método | Efecto |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | Pasa `false` para ocultar la expresión. Sus dimensiones siguen contribuyendo al diseño a menos que los métodos correspondientes a continuación reciban `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | Trata el ancho horizontal de la expresión como cero, permitiendo que los elementos vecinos se acerquen. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | Trata su ascenso, la altura por encima de la línea base, como cero. Esto puede reducir el espacio reservado sobre los elementos vecinos. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | Trata su descenso, la profundidad bajo la línea base, como cero. Esto puede mover una barra de fracción u otro contenido bajo la expresión más cercano a sus vecinos. |

La línea base es la línea de referencia sobre la que se sitúan las letras matemáticas ordinarias. Ocultar contenido no elimina sus dimensiones, y tratar una dimensión como cero no borra la expresión. La expresión subyacente sigue disponible a través de [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase). Pasa `true` a [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) para volver a mostrarla; los ajustes de dimensión permanecen sin cambios.

El ejemplo a continuación crea cinco variantes una al lado de la otra: una fracción visible, una fracción oculta que reserva espacio, y tres fracciones ocultas con una dimensión tratada como cero. Cada variante utiliza la misma expresión circundante y Cambria Math a 24 puntos. Todas las formas de ecuaciones tienen la misma posición superior, marcada por la guía gris. Colocar el fantasma en el numerador de una fracción externa facilita la visualización de los cambios de disposición vertical.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Cinco ecuaciones en PowerPoint comparando una fracción visible, una fracción oculta que reserva espacio y fracciones ocultas con ZeroWidth, ZeroAsc o ZeroDesc activados](math-phantom.png)

## **Agrupar términos**

Utiliza [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo de ella](powerpoint-math-equations_15.png)

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

## **Dar formato a los elementos matemáticos**

Utiliza los asistentes de formato solo donde aclaren la fórmula. Por ejemplo, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) coloca una barra sobre un elemento matemático.

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

### **Dar formato al texto en una ecuación existente**

Para dar formato al texto en toda una ecuación existente, recorre el árbol de elementos de cada bloque matemático. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) devuelve solo los hijos inmediatos, por lo que hay que llamarlo recursivamente para alcanzar el texto dentro de fracciones, scripts, radicales y otras estructuras anidadas. Verifica el elemento actual así como sus hijos para incluir el elemento inicial cuando sea [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Este ejemplo asume que `input.pptx` contiene una ecuación como `z = xᵢ / ∛y`, con una fracción que contiene un subíndice en su numerador y un radical en su denominador. Procesar solo los elementos de nivel superior del bloque perdería el texto dentro de la fracción. El ejemplo encuentra porciones matemáticas en marcos de texto de diapositivas, accede a sus bloques mediante [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), y usa [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para establecer el tamaño de fuente a 28 puntos a través del método [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) de cada elemento de texto.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La presentación guardada contiene el formato de texto actualizado en cada nivel de cada ecuación procesada, conservando su contenido de texto y estructura matemática.

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Crear fracciones | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir superíndice o subíndice | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir funciones | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir radicales | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir límites | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir scripts del lado izquierdo | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Añadir arreglos de ecuaciones | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Agrupar términos | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación de PowerPoint existente?**

Sí. Abre la presentación, encuentra la forma que contiene un [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), y actualiza los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas de PowerPoint editables?**

Sí. Cuando guardas a PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Sí. Obtén el [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) de la ecuación a partir de su [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), y llama a [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) para exportarlo directamente. Para un ejemplo completo, consulta [Exportar ecuaciones matemáticas desde presentaciones en PHP a través de Java](/slides/es/php-java/exporting-math-equations/#export-math-equations-to-latex).