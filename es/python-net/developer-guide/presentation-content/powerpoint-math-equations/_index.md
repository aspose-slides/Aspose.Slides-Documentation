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
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para Python mediante .NET, con soporte de OMML, controles de formato y ejemplos de código Python claros."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides for Python via .NET, puedes crear el mismo tipo de contenido matemático de forma programática: fracciones, radicales, funciones, límites, operadores N-ario, matrices, arreglos y bloques de matemáticas con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insert > Equation**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides construye ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) almacena contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

La mayoría de los ejemplos a continuación usan [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) y los métodos fluidos de [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) para mantener el código corto y legible.

Para escenarios de exportación de MathML, consulte [Exportar ecuaciones matemáticas desde presentaciones en Python mediante .NET](/slides/es/python-net/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo usa [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) para crear una forma matemática y añade el teorema de Pitágoras:

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

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) crea una forma que ya contiene un párrafo matemático. Accede al primer [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), obtén su [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), y añade bloques matemáticos o elementos matemáticos a él.
{{% /alert %}}

### **Combinar bloques matemáticos**

Cuando las partes de una ecuación se construyen de forma independiente como objetos [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), usa [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) para combinarlas. El ejemplo construye `c² =` en el bloque izquierdo y `a² + b²` en el bloque derecho. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) crea superíndices matemáticos editables para los tres exponentes.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) devuelve `left_block` mismo, ahora conteniendo ambas partes en orden, y deja `right_block` vacío. Añade el bloque combinado al [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) solo una vez. Después de volver a abrir `equation.pptx`, el párrafo contiene un bloque que representa `c² = a² + b²`, con los tres exponentes preservados como superíndices matemáticos.

Llamar a [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) como `left_block.add(right_block)` en su lugar intenta anidar un bloque directamente dentro de otro y genera un `RuntimeError` que envuelve una `InvalidOperationException` de .NET.

## **Añadir fracciones**

Utiliza [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

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

Para una fracción apilada, usa [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Añadir radicales**

Utiliza [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) para crear una raíz cuadrada, cúbica u otra raíz. El elemento actual se convierte en la base, y el argumento se convierte en el grado.

![Una expresión radical de n-ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

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

### **Mostrar u ocultar el grado de una raíz cuadrada**

Una raíz cuadrada puede mostrar un 2 explícito o usar la notación convencional √x. La propiedad [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) de [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) controla cuál forma aparece. Ambas formas conservan el grado 2 y el radicando x en la ecuación editable.

![La raíz cuadrada de x con el grado 2 visible a la izquierda y oculto a la derecha](square-root-degree.png)

El ejemplo guarda la misma raíz cuadrada dos veces. El 2 es visible en `visible-degree.pptx` y está oculto en `hidden-degree.pptx`.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir funciones y límites**

Utiliza [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) o [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) para funciones como `sin(x)`, `log(x)`, o nombres de funciones personalizadas. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) o usa [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

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

Para un nombre de función personalizado, convierte el nombre de la función en el elemento actual y llama a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) con su argumento:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Añadir operadores N-ario e integrales**

Utiliza [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) para sumas, uniones, intersecciones y otros operadores grandes. Utiliza [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) para integrales. Ambos métodos permiten establecer límites inferior y superior.

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

Los operadores N-ario son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` suelen añadirse como [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) y unirse a la expresión.

Para una integral, usa [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Añadir matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, así que encierra la matriz cuando necesites paréntesis, corchetes o llaves.

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

### **Editar una matriz existente**

Supongamos que una lección de álgebra lineal comienza con la matriz de coeficientes en `matrix.pptx`, guardada por el ejemplo anterior. Para el siguiente ejercicio, conserva la primera ecuación, reemplaza la segunda por dos nuevas ecuaciones y revisa el conjunto de variables. Accede a la matriz existente como [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) para conservar los coeficientes que aún se aplican.

![Matriz de coeficientes original de dos filas con entradas 1, x y una celda vacía en la primera fila y x, 2 y y en la segunda](matrix-before-edit.png)

Los índices de fila y columna comienzan en cero y se refieren a la matriz tal como está en cada llamada. Insertar una fila antes del índice 1 mueve la fila segunda original al índice 2. Insertar después del índice 2 añade una fila. Eliminar la fila 2 quita la ecuación segunda original y mueve la fila añadida una posición hacia arriba. Las columnas se desplazan de la misma manera.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) alinea la primera columna a la izquierda. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) alinea tres columnas consecutivas a la derecha, comenzando en el índice 1. En `updated-matrix.pptx`, la matriz tiene tres ecuaciones y cuatro variables. Los coeficientes originales de la primera fila `1` y `x` ahora aparecen en la primera y tercera columnas.

![Matriz actualizada de tres filas que muestra las filas 1, 0, x, 0; 12, 1, 0, 0; y 0, 0, 10, 1](matrix-after-edit.png)

## **Añadir arreglos de ecuaciones**

Utiliza [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

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

### **Alinear un arreglo con los elementos circundantes**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) controla la alineación vertical de un arreglo respecto a los elementos matemáticos a su lado. El ejemplo siguiente compara la alineación con la primera fila, el centro del arreglo y la última fila.

El siguiente ejemplo crea tres arreglos idénticos, cada uno con tres filas y los elementos vecinos `A=` y `=B`. Todo el texto matemático usa Cambria Math a 24 puntos. Sólo cambia la alineación del arreglo.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

La comparación siguiente muestra la presentación guardada en PowerPoint. Observa la posición de `A=` y `=B` junto a cada arreglo.

![Arreglos de ecuaciones en PowerPoint con alineación Superior, Central y Inferior y elementos vecinos idénticos](equation-array-alignment.png)

### **Configurar el espaciado de filas**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) selecciona la regla de espaciado para las filas dentro del arreglo. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) proporciona un valor numérico para una regla de espaciado explícita y se ignora con las reglas predefinidas.

Para un espaciado exacto, el valor se mide en puntos. Para un espaciado proporcional, se mide en media línea: el valor `3` en el ejemplo especifica 1,5 líneas. Define ambas propiedades al especificar un valor explícito; cambiar solo el valor numérico no selecciona una regla de espaciado.

El ejemplo siguiente guarda cinco presentaciones con las mismas ecuaciones, alineación y configuraciones de fuente. Las tres primeras usan valores predefinidos; las dos últimas muestran valores explícitos.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

El espaciado de filas del arreglo es independiente del espaciado de párrafo. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) y [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) añaden espacio alrededor del párrafo contenedor, no entre filas del arreglo. Asimismo, [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) posiciona todo el párrafo matemático horizontalmente; no sustituye la configuración de alineación vertical del arreglo.

## **Añadir funciones trigonométricas**

Utiliza [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) cuando el argumento es el elemento actual y el nombre de la función se conoce.

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

Utiliza los asistentes de subíndice y superíndice para índices y potencias. Cuando los índices deben aparecer en el lado izquierdo de la base, usa [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

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

Utiliza [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadas que contengan varios elementos.

![Una expresión delimitada que contiene x, y, y z separados por barras verticales](powerpoint-math-equations_13.png)

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

### **Tamaño y alineación de delimitadores**

Establece [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) a `True` para permitir que los paréntesis crezcan alrededor de un operando alto, o a `False` para mantener su tamaño normal. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) toma uno de dos valores [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` centra los paréntesis en el eje matemático, que pasa por el medio del signo igual. `MATCH` los alinea con el contenido incluido. Ambas configuraciones afectan solo a los delimitadores. La expresión interior permanece igual.

El ejemplo coloca una fracción en el exponente de `x` de modo que la expresión se extienda más arriba de la línea base que debajo de ella. Las cuatro ecuaciones usan los mismos paréntesis y configuraciones de fuente.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

En PowerPoint, compara las filas para ver el efecto del crecimiento. En la fila superior, los paréntesis crecen para envolver el exponente y se ven iguales en ambas formas. En la fila inferior, el crecimiento está desactivado. Los paréntesis más pequeños a la izquierda (`CENTERED`) se alinean con el signo igual, mientras que los de la derecha (`MATCH`) se sitúan más arriba alrededor de la expresión.

![Cuatro ecuaciones en PowerPoint con crecimiento de delimitadores activado arriba y desactivado abajo, y Centered a la izquierda y Match a la derecha](delimiter-sizing.png)

## **Añadir un recuadro con borde**

Llama a [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) sobre una fracción para encuadrar toda la expresión. El [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) devuelto muestra los cuatro lados por defecto. Usa [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), y [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) para eliminar lados individuales.

El ejemplo coloca seis copias de la misma fracción en una diapositiva. Para mostrar cancelación, oculta los cuatro lados y define [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) para una diagonal ascendente (↗) o [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) para una diagonal descendente (↘). También puedes usar [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) o [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) con cualquier combinación de lados visibles.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Seis fracciones editables en PowerPoint. Fila superior: borde completo, lados inferior e izquierdo, diagonal ascendente. Fila inferior: diagonal descendente, raya horizontal, raya vertical con borde completo.](border-box-fractions.png)

En esta fracción, la raya horizontal se superpone a la barra de la fracción. La raya vertical cruza tanto el numerador como el denominador mientras el borde circundante permanece visible. Estas líneas decoran toda la expresión. El tachado de texto ordinario se aplica a los caracteres en una secuencia de texto. Después de volver a abrir la presentación en PowerPoint, aún puedes editar el numerador y el denominador de forma independiente.

## **Controlar la visibilidad y el diseño con elementos fantasma**

Envuelve una expresión en [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) para controlar su visibilidad y el espacio que aporta a una ecuación de forma independiente. Sus propiedades controlan lo siguiente:

| Propiedad | Efecto |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | Establecer a `False` para ocultar la expresión. Sus dimensiones siguen contribuyendo al diseño a menos que las propiedades correspondientes a continuación sean `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | Tratar el ancho horizontal de la expresión como cero, permitiendo que los elementos vecinos se acerquen más. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Tratar su ascenso, la altura por encima de la línea base, como cero. Esto puede reducir el espacio reservado sobre los elementos vecinos. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Tratar su descenso, la profundidad por debajo de la línea base, como cero. Esto puede mover una barra de fracción u otro contenido debajo de la expresión más cerca de sus vecinos. |

La línea base es la línea de referencia sobre la que se asientan las letras matemáticas habituales. Ocultar contenido no elimina sus dimensiones, y tratar una dimensión como cero no borra la expresión. La expresión subyacente sigue disponible a través de [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/). Restablece [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) a `True` para volver a mostrarla; la configuración de dimensiones permanece sin cambios.

El ejemplo siguiente crea cinco variantes una al lado de otra: una fracción visible, una fracción oculta que reserva espacio, y tres fracciones ocultas con una dimensión tratada como cero. Cada variante usa la misma expresión circundante y Cambria Math a 24 puntos. Todas las formas de ecuación tienen la misma posición superior, marcada por la guía gris. Colocar el fantasma en el numerador de una fracción externa facilita la visualización de los cambios de diseño vertical.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![Cinco ecuaciones en PowerPoint comparando una fracción visible, una fracción oculta que reserva espacio y fracciones ocultas con ZeroWidth, ZeroAsc o ZeroDesc activados](math-phantom.png)

## **Agrupar términos**

Utiliza [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo de ella](powerpoint-math-equations_15.png)

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

## **Dar formato a los elementos matemáticos**

Utiliza los asistentes de formato solo donde aclaren la fórmula. Por ejemplo, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) coloca una barra sobre un elemento matemático.

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

### **Dar formato al texto en una ecuación existente**

Para dar formato al texto en toda una ecuación existente, recorre el árbol de elementos de cada bloque matemático. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) devuelve solo los hijos inmediatos, por lo que hay que llamarlo recursivamente para alcanzar el texto dentro de fracciones, índices, radicales y otras estructuras anidadas. Verifica el elemento actual así como sus hijos para incluir el elemento inicial cuando es [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Este ejemplo asume que `input.pptx` contiene una ecuación como `z = xᵢ / ∛y`, con una fracción que contiene un subíndice en su numerador y un radical en su denominador. Procesar solo los elementos de nivel superior del bloque haría que se omitiera el texto dentro de la fracción. El ejemplo busca porciones matemáticas en los marcos de texto de diapositivas, accede a sus bloques mediante [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), y establece [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) a 28 puntos mediante la propiedad [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) de cada elemento de texto.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

La presentación guardada contiene el formato de texto actualizado en cada nivel de cada ecuación procesada, conservando su contenido textual y su estructura matemática.

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Crear fracciones | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Añadir superíndice o subíndice | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Añadir funciones | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Añadir radicales | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Añadir límites | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Añadir scripts del lado izquierdo | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Añadir sumas e integrales | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Añadir matrices | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Añadir arreglos de ecuaciones | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Añadir delimitadores | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Añadir barras y bordes | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Agrupar términos | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, encuentra la forma que contiene una [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), obtén su [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), y actualiza los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas editables de PowerPoint?**

Sí. Cuando guardas en PPTX, Aspose.Slides escribe la ecuación como contenido matemático editable de Office.

**¿Puedo exportar ecuaciones a LaTeX?**

Sí. Obtén el [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) de su [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), y llama a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) para exportarla directamente. Para un ejemplo completo, vea [Exportar ecuaciones matemáticas desde presentaciones en Python mediante .NET](/slides/es/python-net/exporting-math-equations/#export-math-equations-to-latex).