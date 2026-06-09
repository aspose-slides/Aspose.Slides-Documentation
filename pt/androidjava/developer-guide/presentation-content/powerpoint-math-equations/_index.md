---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint no Android
linktitle: Equações Matemáticas PowerPoint
type: docs
weight: 80
url: /pt/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Inserir e editar equações matemáticas em PowerPoint PPT e PPTX com Aspose.Slides para Android, suportando OMML, controles de formatação e exemplos claros de código Java."
---
## **Visão Geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com o Aspose.Slides para Android via Java, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N-ários, matrizes, vetores e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações a partir de **Insert > Equation**:

![A guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides constrói esse texto matemático através de três objetos principais:

- Uma forma matemática, criada com [addMathShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/), é a forma que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathportion/) armazena o conteúdo matemático dentro do quadro de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathematicaltext/) e os métodos fluentes de [IMathElement](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Exportar Equações Matemáticas de Apresentações no Android](/slides/pt/androidjava/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

`addMathShape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos matemáticos ou elementos matemáticos a ele.

{{% /alert %}}

## **Adicionar Frações**

Use `divide` para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para uma fração empilhada, use `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Adicionar Radicais**

Use `radical` para criar uma raiz quadrada, raiz cúbica ou outra raiz. O elemento atual torna‑se a base, e o argumento torna‑se o índice.

![Uma expressão radical de enésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Funções e Limites**

Use `asArgumentOfFunction` ou `function` para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathlimit/) ou use `setLowerLimit`.

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para um nome de função personalizado, torne o nome da função o elemento atual:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Adicionar Operadores N-ários e Integrais**

Use `nary` para somas, uniões, intersecções e outros operadores grandes. Use `integral` para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Uma soma com limites inferior e superior](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operadores N-ários são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` são normalmente adicionados como `MathematicalText` e unidos à expressão.

Para uma integral, use `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathmatrix/) para linhas e colunas. As matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Matrizes de Equações**

Use `toMathArray` quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um vetor matemático vertical com x acima de y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Funções Trigonométricas**

Use `asArgumentOfFunction` quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Subscritos e Sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer à esquerda da base, use `setSubSuperscriptOnTheLeft`.

![Um Y maiúsculo com subscrito à esquerda 1 e sobrescrito n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Delimitadores**

Use `enclose` para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contenham vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar uma Caixa de Borda**

Use `toBorderBox` quando a própria equação deve ser enquadrada.

![Uma equação em caixa mostrando a ao quadrado igual a b ao quadrado mais c ao quadrado](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar Termos**

Use `group` para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatar Elementos Matemáticos**

Use auxiliares de formatação apenas onde eles esclarecem a fórmula. Por exemplo, `overbar` coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra acima](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Referência Rápida**

| Tarefa | API Principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathematicaltext/) |
| Combinar elementos | [IMathElement.join](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Criar frações | [IMathElement.divide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar sobrescrito ou subscrito | [setSuperscript](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar funções | [function](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar radicais | [IMathElement.radical](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar limites | [setLowerLimit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar scripts à esquerda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar somas e integrais | [nary](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathmatrix/) |
| Adicionar matrizes de equações | [toMathArray](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar delimitadores | [enclose](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Adicionar barras e bordas | [overbar](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |
| Agrupar termos | [group](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imathelement/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar como PPTX, o Aspose.Slides grava a equação como conteúdo de matemática Office editável.

**Posso exportar equações para LaTeX?**

O Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e então converta o MathML com uma ferramenta que suporte o dialeto LaTeX desejado.