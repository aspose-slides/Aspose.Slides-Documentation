---
title: "Adicionar Equações Matemáticas a Apresentações PowerPoint em PHP"
linktitle: "Equações Matemáticas PowerPoint"
type: docs
weight: 80
url: /pt/php-java/powerpoint-math-equations/
keywords:
- "equação matemática"
- "símbolo matemático"
- "fórmula matemática"
- "texto matemático"
- "adicionar equação matemática"
- "adicionar símbolo matemático"
- "adicionar fórmula matemática"
- "adicionar texto matemático"
- "PowerPoint"
- "apresentação"
- "PHP"
- "Aspose.Slides"
description: "Inserir e editar equações matemáticas em PowerPoint PPT e PPTX com Aspose.Slides para PHP via Java, com suporte a OMML, controles de formatação e exemplos de código PHP claros."
---
## **Visão geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides para PHP via Java, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N‑ário, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações a partir de **Inserir > Equação**:

![A guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides constrói esse texto matemático por meio de três objetos principais:

- Uma forma matemática, criada com [addMathShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addMathShape), é a forma que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/) armazena o conteúdo matemático dentro da caixa de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathematicaltext/) e os métodos fluentes de [MathElementBase](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Exportar equações matemáticas de apresentações em PHP via Java](/slides/pt/php-java/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

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
`addMathShape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos matemáticos ou elementos matemáticos a ele.
{{% /alert %}}

## **Adicionar Frações**

Use [`divide`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

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

Para uma fração empilhada, use `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Adicionar Radicais**

Use [`radical`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para criar uma raiz quadrada, cúbica ou outra raiz. O elemento atual torna‑se a base e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

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

## **Adicionar Funções e Limites**

Use [`asArgumentOfFunction`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) ou [`function`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathlimit/) ou use [`setLowerLimit`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/).

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

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

Para um nome de função personalizado, faça o nome da função o elemento atual:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Adicionar Operadores N‑ário e Integrais**

Use [`nary`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para somatórios, uniões, interseções e outros operadores grandes. Use [`integral`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Uma soma com limites inferior e superior](powerpoint-math-equations_7.png)

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

Operadores N‑ário são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como `MathematicalText` e concatenados na expressão.

Para uma integral, use `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

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

## **Adicionar Arrays de Equações**

Use [`toMathArray`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

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

## **Adicionar Funções Trigonométricas**

Use [`asArgumentOfFunction`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

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

## **Adicionar Subscritos e Sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer no lado esquerdo da base, use [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/).

![Um Y maiúsculo com subscrito 1 e sobrescrito n no lado esquerdo](powerpoint-math-equations_9.png)

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

## **Adicionar Delimitadores**

Use [`enclose`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contêm vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

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

## **Adicionar uma Caixa de Borda**

Use [`toBorderBox`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) quando a equação em si deve ser enquadrada.

![Uma equação em caixa mostrando a ao quadrado igual a b ao quadrado mais c ao quadrado](powerpoint-math-equations_12.png)

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

## **Agrupar Termos**

Use [`group`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

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

## **Formatar Elementos Matemáticos**

Use auxiliares de formatação somente onde eles clarificam a fórmula. Por exemplo, [`overbar`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

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

## **Referência Rápida**

| Tarefa | API Principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathematicaltext/) |
| Combinar elementos | [join](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Criar frações | [divide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar sobrescrito ou subscrito | [setSuperscript](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar funções | [function](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar radicais | [radical](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar limites | [setLowerLimit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar scripts à esquerda | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar somatórios e integrais | [nary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathmatrix/) |
| Adicionar arrays de equações | [toMathArray](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar delimitadores | [enclose](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Adicionar barras e bordas | [overbar](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |
| Agrupar termos | [group](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathelementbase/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, localize a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos de matemática naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, o Aspose.Slides grava a equação como conteúdo de matemática do Office editável.

**Posso exportar equações para LaTeX?**

O Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e depois converta o MathML com uma ferramenta que suporte o dialeto LaTeX desejado.