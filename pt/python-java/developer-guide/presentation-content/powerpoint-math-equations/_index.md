---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em Python
linktitle: Equações Matemáticas PowerPoint
type: docs
weight: 80
url: /pt/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Insira e edite equações matemáticas no PowerPoint PPT e PPTX com Aspose.Slides para Python via Java, suportando OMML, controles de formatação e exemplos claros de código Python."
---
## **Visão geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides for Python via Java, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N‑ários, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente inserem equações em **Inserir > Equação**:

![A guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides cria esse texto matemático por meio de três objetos principais:

- Uma forma matemática, criada com [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) armazena o conteúdo matemático dentro da caixa de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) e os métodos fluentes de [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) para manter o código curto e legível.

Para cenários de exportação para MathML, veja [Export Math Equations from Presentations in Python](/slides/pt/python-java/exporting-math-equations/).

## **Criar uma equação**

Este exemplo usa [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) para criar uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Nota" %}}

[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) cria uma forma que já contém um parágrafo matemático. Acesse a primeira [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), chame [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e adicione blocos ou elementos matemáticos a ele.

{{% /alert %}}

## **Adicionar frações**

Use [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Uma fração inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

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

Para uma fração empilhada, use [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Adicionar radicais**

Use [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) para criar uma raiz quadrada, cúbica ou outra raiz. O elemento atual torna‑se a base e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

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

## **Adicionar funções e limites**

Use [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ou [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) ou use [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

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

Para um nome de função personalizado, torne o nome da função o elemento atual e chame [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) com seu argumento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Adicionar operadores N‑ários e integrais**

Use [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) para somatórios, uniões, interseções e outros operadores grandes. Use [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Um somatório com limites inferior e superior](powerpoint-math-equations_7.png)

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

Operadores N‑ários são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) e concatenados na expressão.

Para um integral, use [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Adicionar matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

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

## **Adicionar arrays de equações**

Use [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

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

## **Adicionar funções trigonométricas**

Use [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

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

## **Adicionar subscritos e sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices precisam aparecer ao lado esquerdo da base, use [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Um Y maiúsculo com subscrito à esquerda 1 e sobrescrito n](powerpoint-math-equations_9.png)

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

## **Adicionar delimitadores**

Use [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contenham vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

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

### **Dimensionar e alinhar delimitadores**

Passe `True` para [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) para que os parênteses cresçam ao redor de um operando alto, ou `False` para mantê‑los no tamanho normal. Use [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) com um dos valores de [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` centraliza os parênteses no eixo matemático, que passa pelo meio do sinal de igualdade. `Match` os alinha com o conteúdo incluído. Ambas as configurações afetam apenas os delimitadores. A expressão interna permanece a mesma.

O exemplo coloca uma fração no expoente de `x` para que a expressão se estenda mais acima da linha de base do que abaixo dela. Todas as quatro equações usam os mesmos parênteses e configurações de fonte.

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

No PowerPoint, compare as linhas para ver o efeito do crescimento. Na linha superior, os parênteses crescem para envolver o expoente e ficam iguais para ambas as formas. Na linha inferior, o crescimento está desativado. Os parênteses menores à esquerda (`Centered`) alinham‑se com o sinal de igualdade, enquanto os da direita (`Match`) ficam mais altos ao redor da expressão.

![Quatro equações no PowerPoint com crescimento de delimitadores ativado acima e desativado abaixo, e Centralizado à esquerda e Correspondente à direita](delimiter-sizing.png)

## **Adicionar uma caixa de borda**

Chame [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) em uma fração para enquadrar toda a expressão. O [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) retornado mostra os quatro lados por padrão. Use [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) e [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) para remover lados individuais.

O exemplo coloca seis cópias da mesma fração em um slide. Para mostrar cancelamento, oculte os quatro lados e passe `True` para [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) para obter uma diagonal ascendente (↗) ou [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) para uma diagonal descendente (↘). Você também pode usar [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) ou [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) com qualquer combinação de lados visíveis.

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

![Seis frações editáveis no PowerPoint. Linha superior: borda completa, lados inferior e esquerdo, diagonal ascendente. Linha inferior: diagonal descendente, risco horizontal, risco vertical com borda completa.](border-box-fractions.png)

Nesta fração, o risco horizontal sobrepõe a barra da fração. O risco vertical cruza tanto o numerador quanto o denominador enquanto a borda ao redor permanece visível. Essas linhas decoram a expressão inteira. O tachado de texto comum se aplica a caracteres em um trecho de texto. Após reabrir a apresentação no PowerPoint, você ainda pode editar o numerador e o denominador independentemente.

## **Agrupar termos**

Use [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

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

## **Formatar elementos matemáticos**

Use assistentes de formatação apenas onde eles esclarecem a fórmula. Por exemplo, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

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

### **Formatar texto em uma equação existente**

Para formatar texto em toda uma equação existente, percorra a árvore de elementos de cada bloco matemático. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) retorna apenas os filhos imediatos, portanto chame‑o recursivamente para alcançar texto dentro de frações, scripts, radicais e outras estruturas aninhadas. Verifique o elemento atual assim como seus filhos para incluir o elemento inicial quando ele for [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Este exemplo supõe que `input.pptx` contém uma equação como `z = xᵢ / ∛y`, com uma fração contendo um subscrito no numerador e um radical no denominador. Processar apenas os elementos de nível superior do bloco perderia o texto dentro da fração. O exemplo encontra porções matemáticas em quadros de texto de slides, acessa seus blocos por meio de [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e usa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para definir o tamanho da fonte para 28 pontos através do método [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) de cada elemento de texto.

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

A apresentação salva contém a formatação de texto atualizada em todos os níveis de cada equação processada, preservando seu conteúdo textual e sua estrutura matemática.

## **Referência rápida**

| Tarefa | API principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Criar frações | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Adicionar sobrescrito ou subscrito | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Adicionar funções | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Adicionar radicais | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Adicionar limites | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Adicionar scripts à esquerda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Adicionar somatórios e integrais | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Adicionar arrays de equações | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Adicionar delimitadores | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Adicionar barras e bordas | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Agrupar termos | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**Posso editar uma equação existente no PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém uma [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), chame [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática do PowerPoint editável?**

Sim. Ao salvar em PPTX, Aspose.Slides grava a equação como conteúdo matemático do Office editável.

**Posso exportar equações para LaTeX?**

Sim. Obtenha o [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) da sua [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), e chame [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) para exportá‑lo diretamente. Para um exemplo completo, veja [Export Math Equations from Presentations in Python](/slides/pt/python-java/exporting-math-equations/#export-math-equations-to-latex).