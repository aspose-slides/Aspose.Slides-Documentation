---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en Python
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para Python a través de .NET, compatible con OMML, controles de formato y ejemplos claros de código en Python."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides for Python via .NET, puedes crear el mismo tipo de contenido matemático de forma programática: fracciones, radicales, funciones, límites, operadores N‑arios, matrices, arreglos y bloques de matemáticas formateados.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insertar > Ecuación**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides construye ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [add_math_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_math_shape/), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathportion/) almacena el contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathblock/).

La mayoría de los ejemplos a continuación usan [MathematicalText](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathematicaltext/) y los métodos fluidos de [IMathElement](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/) para mantener el código corto y legible.

Para escenarios de exportación a MathML, consulta [Export Math Equations from Presentations in Python via .NET](/slides/es/python-net/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo crea una forma matemática y añade el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
`add_math_shape` crea una forma que ya contiene un párrafo matemático. Accede al primer `MathPortion`, obtén su `MathParagraph` y añade bloques o elementos matemáticos a él.
{{% /alert %}}

## **Añadir fracciones**

Utiliza [`divide`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/divide/) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Una fracción matemática sesgada que muestra uno dividido por x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Para una fracción apilada, usa `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Añadir radicales**

Utiliza [`radical`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/radical/) para crear una raíz cuadrada, cúbica u otro tipo de raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de n‑ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir funciones y límites**

Utiliza [`as_argument_of_function`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) o [`function`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/function/) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathlimit/) o usa [`set_lower_limit`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![El límite de x cuando x tiende a infinito](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Para un nombre de función personalizado, haz que el nombre de la función sea el elemento actual:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Añadir operadores N‑arios e integrales**

Utiliza [`nary`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/nary/) para sumas, uniones, intersecciones y otros operadores grandes. Utiliza [`integral`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/integral/) para integrales. Ambos métodos permiten establecer límites inferior y superior.

![Una sumatoria con límites inferior y superior](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Los operadores N‑arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` normalmente se añaden como `MathematicalText` y se concatenan en la expresión.

Para una integral, usa `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, así que encierra la matriz cuando necesites paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir arreglos de ecuaciones**

Utiliza [`to_math_array`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/to_math_array/) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Un arreglo matemático vertical con x sobre y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir funciones trigonométricas**

Utiliza [`as_argument_of_function`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) cuando el argumento sea el elemento actual y el nombre de la función sea conocido.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir subíndices y superíndices**

Utiliza los auxiliares de subíndice y superíndice para índices y potencias. Cuando los índices deben aparecer a la izquierda de la base, usa [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Una Y mayúscula con subíndice 1 a la izquierda y superíndice n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir delimitadores**

Utiliza [`enclose`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/enclose/) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadas que contengan varios elementos.

![Una expresión delimitada que contiene x, y y z separados por barras verticales](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir un recuadro con borde**

Utiliza [`to_border_box`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/to_border_box/) cuando la ecuación misma debe estar enmarcada.

![Una ecuación en un recuadro que muestra a al cuadrado es igual a b al cuadrado más c al cuadrado](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Agrupar términos**

Utiliza [`group`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/group/) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x + y agrupada con la etiqueta cualquier texto debajo](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatear elementos matemáticos**

Utiliza auxiliares de formato solo donde clarifiquen la fórmula. Por ejemplo, [`overbar`](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/overbar/) coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.join](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/join/) |
| Crear fracciones | [IMathElement.divide](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Añadir superíndice o subíndice | [set_superscript](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Añadir funciones | [function](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Añadir radicales | [radical](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Añadir límites | [set_lower_limit](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Añadir scripts a la izquierda | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/mathmatrix/) |
| Añadir arreglos de ecuaciones | [to_math_array](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Agrupar términos | [group](https://reference.aspose.com/slides/es/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, localiza la forma que contiene un `MathPortion`, obtén su `MathParagraph` y actualiza los bloques matemáticos en ese párrafo.

**¿Las ecuaciones se guardan como matemáticas editables de PowerPoint?**

Sí. Cuando guardas en PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Aspose.Slides exporta ecuaciones matemáticas a MathML. Si necesitas LaTeX, exporta primero a MathML y luego conviértelo con una herramienta que soporte el dialecto de LaTeX que deseas.