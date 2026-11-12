---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em PHP
linktitle: Equações Matemáticas do PowerPoint
type: docs
weight: 80
url: /pt/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Inserir e editar equações matemáticas em PPT e PPTX do PowerPoint com Aspose.Slides para PHP via Java, suportando OMML, controles de formatação e exemplos claros de código PHP."
---
## **Visão geral**

PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides for PHP via Java, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N‑ário, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações a partir de **Inserir > Equação**:

![A guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides constrói esse texto matemático através de três objetos principais:

- Uma forma matemática, criada com [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), é a forma que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) armazena o conteúdo matemático dentro da moldura de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) e os métodos fluentes de [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Exportar equações matemáticas de apresentações em PHP via Java](/slides/pt/php-java/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo usa [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) para criar uma forma matemática e adiciona o teorema de Pitágoras:

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) cria uma forma que já contém um parágrafo matemático. Acesse o primeiro [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), chame [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), e adicione blocos ou elementos matemáticos a ele.
{{% /alert %}}

## **Adicionar Frações**

Use [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

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

Para uma fração empilhada, use [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Adicionar Radicais**

Use [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) para criar uma raiz quadrada, raiz cúbica ou outra raiz. O elemento atual torna‑se a base, e o argumento torna‑se o grau.

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

Use [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ou [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) ou use [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

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

Para um nome de função personalizado, torne o nome da função o elemento atual e chame [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) com seu argumento:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Adicionar Operadores N‑ário e Integrais**

Use [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) para somatórios, uniões, interseções e outros operadores grandes. Use [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Um somatório com limites inferior e superior](powerpoint-math-equations_7.png)

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

Operadores N‑ário são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) e unidos à expressão.

Para uma integral, use [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

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

Use [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) quando precisar de equações alinhadas ou uma pilha vertical de expressões.

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

### **Alinhar um Array com Elementos Circundantes**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) controla o alinhamento vertical de um array em relação aos elementos matemáticos ao seu lado. O exemplo abaixo compara o alinhamento com a primeira linha, o centro do array e a última linha.

O exemplo a seguir cria três arrays idênticos, cada um com três linhas e os elementos vizinhos `A=` e `=B`. Todo o texto matemático usa Cambria Math em 24 pontos. Apenas o alinhamento do array muda.

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

A comparação a seguir mostra a apresentação salva no PowerPoint. Observe a posição de `A=` e `=B` ao lado de cada array.

![Arrays de equações no PowerPoint com alinhamento Superior, Central e Inferior e elementos vizinhos idênticos](equation-array-alignment.png)

### **Configurar Espaçamento de Linhas**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) seleciona a regra de espaçamento para linhas dentro do array. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) fornece um valor numérico para uma regra de espaçamento explícita e é ignorado pelas regras predefinidas.

Para espaçamento exato, o valor é medido em pontos. Para espaçamento proporcional, é medido em meia‑linha: o valor `3` no exemplo especifica 1,5 linhas. Defina ambas as propriedades ao especificar um valor explícito; alterar apenas o valor numérico não seleciona uma regra de espaçamento.

O exemplo abaixo salva cinco apresentações com as mesmas equações, alinhamento e configurações de fonte. As três primeiras usam predefinições; as duas últimas mostram valores explícitos.

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

O espaçamento de linhas do array é separado do espaçamento de parágrafo. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) e [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) adicionam espaço ao redor do parágrafo contido, não entre as linhas do array. Da mesma forma, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) posiciona todo o parágrafo matemático horizontalmente; ele não substitui a configuração de alinhamento vertical do array.

## **Adicionar Funções Trigonométricas**

Use [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) quando o argumento é o elemento atual e o nome da função é conhecido.

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

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer no lado esquerdo da base, use [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Um Y maiúsculo com subscrito à esquerda 1 e sobrescrito n](powerpoint-math-equations_9.png)

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

Use [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contenham vários elementos.

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

### **Tamanho e Alinhamento dos Delimitadores**

Passe `true` para [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) para que os parênteses cresçam ao redor de um operando alto, ou passe `false` para mantê‑los no tamanho normal. Use [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) com um dos dois valores de [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` centraliza os parênteses no eixo matemático, que passa pelo meio do sinal de igualdade. `Match` os alinha com o conteúdo envolvido. Ambas as configurações afetam apenas os delimitadores. A expressão interna permanece a mesma.

O exemplo coloca uma fração no expoente de `x` para que a expressão se estenda mais acima da linha de base do que abaixo dela. Todas as quatro equações usam os mesmos parênteses e configurações de fonte.

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

No PowerPoint, compare as linhas para ver o efeito do crescimento. Na linha superior, os parênteses crescem para envolver o expoente e ficam semelhantes para ambas as formas. Na linha inferior, o crescimento está desativado. Os parênteses menores à esquerda (`Centered`) alinham‑se com o sinal de igualdade, enquanto os da direita (`Match`) ficam mais altos ao redor da expressão.

![Quatro equações no PowerPoint com crescimento de delimitadores habilitado acima e desativado abaixo, e Centralizado à esquerda e Correspondente à direita](delimiter-sizing.png)

## **Adicionar uma Caixa de Borda**

Chame [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) em uma fração para enquadrar a expressão inteira. O [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) retornado mostra os quatro lados por padrão. Use [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) e [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) para remover lados individuais.

O exemplo coloca seis cópias da mesma fração em um slide. Para mostrar cancelamento, oculte os quatro lados e passe `true` para [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) para uma diagonal ascendente (↗) ou [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) para uma diagonal descendente (↘). Você também pode usar [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) ou [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) com qualquer combinação de lados visíveis.

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

![Seis frações editáveis no PowerPoint. Linha superior: borda completa, lados inferior e esquerdo, diagonal ascendente. Linha inferior: diagonal descendente, risco horizontal, risco vertical com borda completa](border-box-fractions.png)

Nesta fração, o risco horizontal sobrepõe a barra da fração. O risco vertical cruza tanto o numerador quanto o denominador enquanto a borda ao redor permanece visível. Essas linhas decoram toda a expressão. O tachado de texto comum se aplica a caracteres em uma sequência de texto. Após reabrir a apresentação no PowerPoint, você ainda pode editar o numerador e o denominador de forma independente.

## **Agrupar Termos**

Use [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

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

Use auxiliares de formatação somente onde eles esclarecem a fórmula. Por exemplo, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) coloca uma barra acima de um elemento matemático.

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

### **Formatar Texto em uma Equação Existente**

Para formatar texto em toda uma equação existente, percorra a árvore de elementos de cada bloco matemático. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) retorna apenas os filhos imediatos, então chame‑a recursivamente para alcançar texto dentro de frações, scripts, radicais e outras estruturas aninhadas. Verifique o elemento atual assim como seus filhos para incluir o elemento inicial quando ele for [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Este exemplo assume que `input.pptx` contém uma equação como `z = xᵢ / ∛y`, com uma fração contendo um subscrito em seu numerador e um radical em seu denominador. Processar apenas os elementos de nível superior do bloco perderia o texto dentro da fração. O exemplo encontra porções matemáticas em molduras de texto de slides, acessa seus blocos através de [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), e usa [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para definir o tamanho da fonte para 28 pontos por meio do método [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) de cada elemento de texto.

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

A apresentação salva contém a formatação de texto atualizada em todos os níveis de cada equação processada, preservando seu conteúdo textual e estrutura matemática.

## **Referência Rápida**

| Tarefa | API Principal |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Combine elements | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Create fractions | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add superscript or subscript | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add functions | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add radicals | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add limits | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add left-side scripts | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Add equation arrays | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Group terms | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), chame [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), e atualize os blocos matemáticos nesse parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Quando você salva em PPTX, Aspose.Slides grava a equação como conteúdo matemático do Office editável.

**Posso exportar equações para LaTeX?**

Sim. Obtenha o [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) da sua [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), e chame [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) para exportá‑lo diretamente. Para um exemplo completo, veja [Exportar Equações Matemáticas de Apresentações em PHP via Java](/slides/pt/php-java/exporting-math-equations/#export-math-equations-to-latex).