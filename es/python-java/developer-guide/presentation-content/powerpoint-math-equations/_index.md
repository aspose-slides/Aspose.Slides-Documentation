---
title: Agregar ecuaciones matemáticas a presentaciones de PowerPoint en Python
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/python-java/powerpoint-math-equations/
keywords:
- ecuación matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- agregar ecuación matemática
- agregar símbolo matemático
- agregar fórmula matemática
- agregar texto matemático
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para Python a través de Java, compatible con OMML, controles de formato y ejemplos claros de código Python."
---
## **Visión general**

PowerPoint almacena las ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides for Python a través de Java, puedes crear el mismo tipo de contenido matemático de forma programática: fracciones, radicales, funciones, límites, operadores N-arios, matrices, arreglos y bloques matemáticos con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insertar > Ecuación**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides construye ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) almacena el contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

La mayoría de los ejemplos siguientes utilizan [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) y los métodos fluidos de [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) para mantener el código breve y legible.

Para escenarios de exportación MathML, consulta [Exportar ecuaciones matemáticas desde presentaciones en Python](/slides/es/python-java/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo utiliza [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) para crear una forma matemática y agrega el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) crea una forma que ya contiene un párrafo matemático. Accede al primer [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) y añade bloques matemáticos o elementos matemáticos.
{{% /alert %}}

## **Añadir fracciones**

Utiliza [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Una fracción matemática sesgada que muestra uno dividido por x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para una fracción apilada, utiliza [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Añadir radicales**

Utiliza [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) para crear una raíz cuadrada, cúbica u otra raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de n-ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir funciones y límites**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) o [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) o utiliza [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![El límite de x cuando x tiende a infinito](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para un nombre de función personalizado, convierte el nombre de la función en el elemento actual y llama a [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) con su argumento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Añadir operadores N-arios e integrales**

Utiliza [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) para sumas, uniones, intersecciones y otros operadores grandes. Utiliza [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) para integrales. Ambos métodos permiten establecer límites inferior y superior.

![Una sumatoria con límites inferior y superior](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Los operadores N-arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` se añaden normalmente como [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) y se unen a la expresión.

Para una integral, utiliza [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes de forma predeterminada, por lo que debes encerrar la matriz cuando necesites paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir matrices de ecuaciones**

Utiliza [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Una matriz matemática vertical con x sobre y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Alinear una matriz con los elementos circundantes**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) controla la alineación vertical de una matriz respecto a los elementos matemáticos que la rodean. El ejemplo siguiente compara la alineación con la primera fila, el centro de la matriz y la última fila.

El siguiente ejemplo crea tres matrices idénticas, cada una con tres filas y los elementos vecinos `A=` y `=B`. Todo el texto matemático utiliza Cambria Math a 24 puntos. Solo cambia la alineación de la matriz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La siguiente comparación muestra la presentación guardada en PowerPoint. Observa la posición de `A=` y `=B` al lado de cada matriz.

![Matrices de ecuaciones en PowerPoint con alineación superior, central e inferior y elementos vecinos idénticos](equation-array-alignment.png)

### **Configurar el espaciado de filas**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) selecciona la regla de espaciado para las filas dentro de la matriz. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) proporciona un valor numérico para una regla de espaciado explícita y se ignora cuando se usan reglas predefinidas.

Para un espaciado exacto, el valor se mide en puntos. Para un espaciado proporcional, se mide en media línea: el valor `3` en el ejemplo especifica 1,5 líneas. Establece ambas propiedades al especificar un valor explícito; cambiar solo el valor numérico no selecciona una regla de espaciado.

El ejemplo siguiente guarda cinco presentaciones con las mismas ecuaciones, alineación y configuración de fuentes. Las tres primeras usan valores predefinidos; las dos últimas muestran valores explícitos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

El espaciado de filas de la matriz es independiente del espaciado de párrafo. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) y [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) añaden espacio alrededor del párrafo contenedor, no entre filas de la matriz. Del mismo modo, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) posiciona horizontalmente todo el párrafo matemático; no sustituye la configuración de alineación vertical de la matriz.

## **Añadir funciones trigonométricas**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) cuando el argumento es el elemento actual y se conoce el nombre de la función.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir subíndices y superíndices**

Utiliza los auxiliares de subíndice y superíndice para índices y potencias. Cuando los índices deben aparecer en el lado izquierdo de la base, usa [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Una Y mayúscula con subíndice 1 a la izquierda y superíndice n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir delimitadores**

Utiliza [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadoras que contengan varios elementos.

![Una expresión delimitadora que contiene x, y y z separados por barras verticales](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tamaño y alineación de delimitadores**

Paso `True` a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) para que los paréntesis crezcan alrededor de un operando alto, o paso `False` para mantener su tamaño normal. Usa [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) con uno de los dos valores de [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` centra los paréntesis en el eje matemático, que pasa por el medio del signo igual. `Match` los alinea con el contenido incluido. Ambas configuraciones afectan solo a los delimitadores. La expresión interna permanece igual.

El ejemplo coloca una fracción en el exponente de `x` de modo que la expresión se extienda más por encima de la línea base que por debajo. Las cuatro ecuaciones utilizan los mismos paréntesis y la misma configuración de fuente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En PowerPoint, compara las filas para ver el efecto del crecimiento. En la fila superior, los paréntesis crecen para encerrar el exponente y son similares en ambas formas. En la fila inferior, el crecimiento está desactivado. Los paréntesis más pequeños a la izquierda (`Centered`) se alinean con el signo igual, mientras que los de la derecha (`Match`) se sitúan más arriba alrededor de la expresión.

![Cuatro ecuaciones en PowerPoint con crecimiento de delimitadores activado en la parte superior y desactivado en la inferior, y Centered a la izquierda y Match a la derecha](delimiter-sizing.png)

## **Añadir un recuadro con bordes**

Llama a [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) sobre una fracción para encuadrar toda la expresión. El [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) devuelto muestra los cuatro lados por defecto. Utiliza [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) y [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) para eliminar lados individuales.

El ejemplo coloca seis copias de la misma fracción en una diapositiva. Para mostrar una cancelación, oculta los cuatro lados y pasa `True` a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) para una diagonal ascendente (↗) o a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) para una diagonal descendente (↘). También puedes usar [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) o [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) con cualquier combinación de lados visibles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Seis fracciones editables en PowerPoint. Fila superior: borde completo, lados inferior e izquierdo, diagonal ascendente. Fila inferior: diagonal descendente, barra horizontal, barra vertical con borde completo.](border-box-fractions.png)

En esta fracción, la barra horizontal se superpone a la barra de la fracción. La barra vertical cruza tanto el numerador como el denominador mientras el borde circundante sigue visible. Estas líneas decoran toda la expresión. El tachado de texto ordinario se aplica a los caracteres en una ejecución de texto. Después de volver a abrir la presentación en PowerPoint, todavía puedes editar el numerador y el denominador de forma independiente.

## **Agrupar términos**

Utiliza [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dar formato a los elementos matemáticos**

Utiliza los auxiliares de formato solo donde clarifiquen la fórmula. Por ejemplo, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dar formato al texto en una ecuación existente**

Para dar formato al texto en toda una ecuación existente, recorre el árbol de elementos de cada bloque matemático. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) devuelve solo los hijos inmediatos, por lo que debes llamarlo recursivamente para alcanzar el texto dentro de fracciones, scripts, radicales y otras estructuras anidadas. Verifica el elemento actual así como sus hijos para incluir el elemento inicial cuando sea [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Este ejemplo asume que `input.pptx` contiene una ecuación como `z = xᵢ / ∛y`, con una fracción que tiene un subíndice en su numerador y un radical en su denominador. Procesar solo los elementos de nivel superior del bloque omitirá el texto dentro de la fracción. El ejemplo encuentra porciones matemáticas en los marcos de texto de las diapositivas, accede a sus bloques a través de [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), y usa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para establecer el tamaño de fuente a 28 puntos mediante el método [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) de cada elemento de texto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentación guardada contiene el formato de texto actualizado en cada nivel de cada ecuación procesada, preservando su contenido textual y su estructura matemática.

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Crear fracciones | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Añadir superíndice o subíndice | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Añadir funciones | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Añadir radicales | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Añadir límites | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Añadir scripts del lado izquierdo | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Añadir matrices de ecuaciones | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Agrupar términos | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, encuentra la forma que contiene un [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) y actualiza los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas editables de PowerPoint?**

Sí. Al guardar en PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Sí. Obtén el [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) de la ecuación a partir de su [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), y llama a [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) para exportarlo directamente. Para un ejemplo completo, consulta [Exportar ecuaciones matemáticas desde presentaciones en Python](/slides/es/python-java/exporting-math-equations/#export-math-equations-to-latex).