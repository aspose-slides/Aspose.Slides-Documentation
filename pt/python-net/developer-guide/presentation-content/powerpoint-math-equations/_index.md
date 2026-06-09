---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em Python
linktitle: Equações Matemáticas PowerPoint
type: docs
weight: 80
url: /pt/python-net/powerpoint-math-equations/
keywords:
- equação matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- adicionar equação matemática
- adicionar símbolo matemático
- adicionar fórmula matemática
- adicionar texto matemático
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Inserir e editar equações matemáticas no PowerPoint PPT e PPTX com Aspose.Slides para Python via .NET, suportando OMML, controles de formatação e exemplos claros de código Python."
---
## **Visão geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides para Python via .NET, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N-ário, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações em **Inserir > Equação**:

![Guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides cria esse texto matemático através de três objetos principais:

- Uma forma matemática, criada com [add_math_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_math_shape/), é a forma que contém a equação.
- O [MathPortion](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/) armazena o conteúdo matemático dentro da moldura de texto da forma.
- O [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathematicaltext/) e os métodos fluentes de [IMathElement](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Export Math Equations from Presentations in Python via .NET](/slides/pt/python-net/exporting-math-equations/).

## **Criar uma equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

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

`add_math_shape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos matemáticos ou elementos matemáticos a ele.

{{% /alert %}}

## **Adicionar frações**

Use [`divide`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/divide/) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

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

Para uma fração empilhada, use `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Adicionar radicais**

Use [`radical`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/radical/) para criar uma raiz quadrada, cúbica ou outra raiz. O elemento atual se torna a base, e o argumento se torna o grau.

![Uma expressão radical de n-ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

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

## **Adicionar funções e limites**

Use [`as_argument_of_function`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) ou [`function`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/function/) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathlimit/) ou use [`set_lower_limit`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

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

Para um nome de função personalizado, faça o nome da função o elemento atual:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Adicionar operadores N-ário e integrais**

Use [`nary`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/nary/) para somatórios, uniões, interseções e outros operadores grandes. Use [`integral`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/integral/) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Uma soma com limites inferior e superior](powerpoint-math-equations_7.png)

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

Operadores N-ário são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` normalmente são adicionados como `MathematicalText` e concatenados na expressão.

Para uma integral, use `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Adicionar matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

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

## **Adicionar arrays de equações**

Use [`to_math_array`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/to_math_array/) quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

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

## **Adicionar funções trigonométricas**

Use [`as_argument_of_function`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

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

## **Adicionar subscritos e sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices precisam aparecer à esquerda da base, use [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Um Y maiúsculo com subscrito 1 à esquerda e sobrescrito n](powerpoint-math-equations_9.png)

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

## **Adicionar delimitadores**

Use [`enclose`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/enclose/) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contenham vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

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

## **Adicionar uma caixa de borda**

Use [`to_border_box`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/to_border_box/) quando a própria equação deve ser enquadrada.

![Uma equação em caixa mostrando a ao quadrado igual b ao quadrado mais c ao quadrado](powerpoint-math-equations_12.png)

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

## **Agrupar termos**

Use [`group`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/group/) para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

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

## **Formatar elementos matemáticos**

Use auxiliares de formatação apenas onde eles esclarecem a fórmula. Por exemplo, [`overbar`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/overbar/) coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

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

## **Referência rápida**

| Tarefa | API principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.join](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/join/) |
| Criar frações | [IMathElement.divide](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Adicionar sobrescrito ou subscrito | [set_superscript](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Adicionar funções | [function](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Adicionar radicais | [radical](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Adicionar limites | [set_lower_limit](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Adicionar scripts do lado esquerdo | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Adicionar somatórios e integrais | [nary](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathmatrix/) |
| Adicionar arrays de equações | [to_math_array](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Adicionar delimitadores | [enclose](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Adicionar barras e bordas | [overbar](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Agrupar termos | [group](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, localize a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, Aspose.Slides grava a equação como conteúdo matemático editável do Office.

**Posso exportar equações para LaTeX?**

Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e depois converta o MathML com uma ferramenta que suporte o dialeto LaTeX desejado.