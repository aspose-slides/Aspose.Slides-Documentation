---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em JavaScript
linktitle: Equações Matemáticas PowerPoint
type: docs
weight: 80
url: /pt/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Inserir e editar equações matemáticas em PPT e PPTX do PowerPoint com Aspose.Slides para Node.js via Java, suportando OMML, controles de formatação e exemplos de código JavaScript claros."
---
## **Visão geral**

PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides para Node.js via Java, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N‑ário, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações a partir de **Inserir > Equação**:

![Aba Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides constrói esse texto matemático por meio de três objetos principais:

- Uma forma matemática, criada com [addMathShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addMathShape), é a forma que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/) armazena o conteúdo matemático dentro do quadro de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathematicaltext/) e os métodos fluentes de [MathElementBase](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Export Math Equations from Presentations in Node.js via Java](/slides/pt/nodejs-java/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

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
`addMathShape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos matemáticos ou elementos matemáticos a ele.
{{% /alert %}}

## **Adicionar Frações**

Use [`divide`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

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

Para uma fração empilhada, use `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Adicionar Radicais**

Use [`radical`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para criar uma raiz quadrada, cúbica ou outra raiz. O elemento atual torna‑se a base, e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésimo grau com x sob o sinal radical](powerpoint-math-equations_5.png)

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

## **Adicionar Funções e Limites**

Use [`asArgumentOfFunction`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) ou [`function`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathlimit/) ou use [`setLowerLimit`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/).

![O limite de x quando x se aproxima do infinito](powerpoint-math-equations_8.png)

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

Para um nome de função personalizado, torne o nome da função o elemento atual:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Adicionar Operadores N‑ários e Integrais**

Use [`nary`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para somatórios, uniões, interseções e outros operadores grandes. Use [`integral`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Uma soma com limites inferior e superior](powerpoint-math-equations_7.png)

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

Operadores N‑ários são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como `MathematicalText` e mesclados na expressão.

Para um integral, use `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

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

## **Adicionar Arrays de Equações**

Use [`toMathArray`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

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

## **Adicionar Funções Trigonométricas**

Use [`asArgumentOfFunction`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

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

## **Adicionar Índices e Expoentes**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer ao lado esquerdo da base, use [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/).

![Um Y maiúsculo com subscript à esquerda 1 e superscript n](powerpoint-math-equations_9.png)

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

## **Adicionar Delimitadores**

Use [`enclose`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadas que contenham vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

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

## **Adicionar uma Caixa com Borda**

Use [`toBorderBox`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) quando a própria equação deve ser emoldurada.

![Uma equação em caixa mostrando a ao quadrado igual a b ao quadrado mais c ao quadrado](powerpoint-math-equations_12.png)

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

## **Agrupar Termos**

Use [`group`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

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

## **Formatar Elementos Matemáticos**

Use auxiliares de formatação apenas onde eles esclarecem a fórmula. Por exemplo, [`overbar`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

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

## **Referência Rápida**

| Tarefa | API principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [join](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Criar frações | [divide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar sobrescrito ou subscrito | [setSuperscript](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar funções | [function](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar radicais | [radical](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar limites | [setLowerLimit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar scripts à esquerda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar somatórios e integrais | [nary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathmatrix/) |
| Adicionar arrays de equações | [toMathArray](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar delimitadores | [enclose](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Adicionar barras e bordas | [overbar](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |
| Agrupar termos | [group](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathelementbase/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, Aspose.Slides grava a equação como conteúdo Office Math editável.

**Posso exportar equações para LaTeX?**

Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e depois converta o MathML com uma ferramenta que suporte o dialeto LaTeX desejado.