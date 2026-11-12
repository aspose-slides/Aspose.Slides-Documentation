---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em .NET
linktitle: Equações Matemáticas do PowerPoint
type: docs
weight: 80
url: /pt/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Inserir e editar equações matemáticas em PPT e PPTX do PowerPoint com Aspose.Slides para .NET, suportando OMML, controles de formatação e exemplos de código C# claros."
---
## **Visão geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides para .NET, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N-ários, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações por **Inserir > Equação**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides gera esse texto matemático por meio de três objetos principais:

- Uma forma matemática, criada com [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), é a forma que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) armazena o conteúdo matemático dentro da caixa de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) e os métodos fluentes de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Exportar Equações Matemáticas de Apresentações em .NET](/slides/pt/net/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo usa [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) para criar uma forma matemática e adiciona o teorema de Pitágoras:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) cria uma forma que já contém um parágrafo matemático. Acesse o primeiro [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), obtenha seu [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), e adicione blocos matemáticos ou elementos matemáticos a ele.

{{% /alert %}}

## **Adicionar Frações**

Use [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Para uma fração empilhada, use [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Adicionar Radicais**

Use [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) para criar uma raiz quadrada, raiz cúbica ou outra raiz. O elemento atual torna‑se a base, e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Adicionar Funções e Limites**

Use [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) ou [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) ou use [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Para um nome de função personalizado, torne o nome da função o elemento atual e chame [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) com seu argumento:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Adicionar Operadores N‑ários e Integrais**

Use [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) para somatórios, uniões, interseções e outros operadores grandes. Use [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Um somatório com limites inferior e superior](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Operadores N‑ários são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) e juntados na expressão.

Para uma integral, use [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto envolva a matriz quando precisar de parênteses, colchetes ou chaves.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Adicionar Matrizes de Equações**

Use [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Uma matriz matemática vertical com x acima de y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

### **Alinhar uma Matriz com Elementos ao Redor**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) controla o alinhamento vertical de uma matriz em relação aos elementos matemáticos ao seu lado. O exemplo abaixo compara o alinhamento com a primeira linha, o centro da matriz e a última linha.

O exemplo a seguir cria três matrizes idênticas, cada uma com três linhas e os elementos vizinhos `A=` e `=B`. Todo o texto matemático usa Cambria Math de 24 pontos. Apenas o alinhamento da matriz muda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

A comparação a seguir mostra a apresentação salva no PowerPoint. Observe a posição de `A=` e `=B` ao lado de cada matriz.

![Matrizes de equações no PowerPoint com alinhamento Superior, Central e Inferior e elementos vizinhos idênticos](equation-array-alignment.png)

### **Configurar Espaçamento de Linhas**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) seleciona a regra de espaçamento para linhas dentro da matriz. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) fornece um valor numérico para uma regra de espaçamento explícita e é ignorado pelas regras predefinidas.

Para espaçamento exato, o valor é medido em pontos. Para espaçamento proporcional, ele é medido em meio‑linhas: o valor `3` no exemplo especifica 1,5 linhas. Defina ambas as propriedades ao especificar um valor explícito; alterar apenas o valor numérico não seleciona uma regra de espaçamento.

O exemplo abaixo salva cinco apresentações com as mesmas equações, alinhamento e configurações de fonte. As três primeiras usam predefinições; as duas últimas mostram valores explícitos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

O espaçamento de linhas da matriz é separado do espaçamento de parágrafo. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) e [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) adicionam espaço ao redor do parágrafo que contém, não entre as linhas da matriz. Da mesma forma, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) posiciona todo o parágrafo matemático horizontalmente; ele não substitui a configuração de alinhamento vertical da matriz.

## **Adicionar Funções Trigonométricas**

Use [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Adicionar Subscritos e Sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices precisam aparecer no lado esquerdo da base, use [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Um Y maiúsculo com subscrito à esquerda 1 e sobrescrito n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Adicionar Delimitadores**

Use [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contêm vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **Dimensionar e Alinhar Delimitadores**

Defina [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) como `true` para permitir que os parênteses cresçam em torno de um operando alto, ou como `false` para mantê‑los em seu tamanho normal. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) aceita um dos dois valores [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` centraliza os parênteses no eixo matemático, que passa pelo meio do sinal de igualdade. `Match` os alinha ao conteúdo delimitado. Ambas as configurações afetam apenas os delimitadores. A expressão interna permanece a mesma.

O exemplo coloca uma fração no expoente de `x` para que a expressão se estenda mais acima da linha de base do que abaixo dela. Todas as quatro equações usam os mesmos parênteses e configurações de fonte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

No PowerPoint, compare as linhas para observar o efeito do crescimento. Na linha superior, os parênteses crescem para envolver o expoente e ficam semelhantes para ambas as formas. Na linha inferior, o crescimento está desativado. Os parênteses menores à esquerda (`Centered`) alinham‑se com o sinal de igualdade, enquanto os da direita (`Match`) ficam mais altos ao redor da expressão.

![Quatro equações no PowerPoint com crescimento de delimitadores ativado acima e desativado abaixo, e Centralizado à esquerda e Correspondente à direita](delimiter-sizing.png)

## **Adicionar uma Caixa de Borda**

Chame [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) em uma fração para enquadrar toda a expressão. O [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) retornado exibe os quatro lados por padrão. Use [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), e [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) para remover lados individuais.

O exemplo coloca seis cópias da mesma fração em um slide. Para mostrar cancelamento, oculte os quatro lados e defina [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) para uma diagonal ascendente (↗) ou [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) para uma diagonal descendente (↘). Você também pode usar [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) ou [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) com qualquer combinação de lados visíveis.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Seis frações editáveis no PowerPoint. Linha superior: borda completa, lados inferior e esquerdo, diagonal ascendente. Linha inferior: diagonal descendente, traço horizontal, traço vertical com borda completa](border-box-fractions.png)

Nesta fração, o traço horizontal sobrepõe a barra da fração. O traço vertical cruza tanto o numerador quanto o denominador enquanto a borda ao redor permanece visível. Estas linhas decoram toda a expressão. O tachado de texto comum aplica‑se a caracteres em uma sequência de texto. Após reabrir a apresentação no PowerPoint, você ainda pode editar o numerador e o denominador independentemente.

## **Agrupar Termos**

Use [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) para colocar um caractere de agrupar acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo algum texto abaixo dela](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Formatar Elementos Matemáticos**

Use auxiliares de formatação somente onde eles esclarecem a fórmula. Por exemplo, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra acima](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Formatar Texto em uma Equação Existente**

Para formatar texto em toda uma equação existente, percorra a árvore de elementos de cada bloco matemático. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) retorna apenas os filhos imediatos, portanto chame‑o recursivamente para alcançar texto dentro de frações, scripts, radicais e outras estruturas aninhadas. Verifique o elemento atual assim como seus filhos para incluir o elemento inicial quando ele for [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Este exemplo supõe que uma apresentação contenha uma equação como `z = xᵢ / ∛y`, com uma fração contendo um subscrito no numerador e um radical no denominador. O exemplo encontra partes matemáticas em caixas de texto de slides, acessa seus blocos através de [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), e define [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para 28 pontos através da propriedade [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) de cada elemento de texto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

A apresentação salva contém a formatação de texto atualizada em todos os níveis de cada equação processada, preservando seu conteúdo textual e estrutura matemática.

## **Referência Rápida**

| Tarefa | API Principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Criar frações | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Adicionar sobrescrito ou subscrito | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Adicionar funções | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Adicionar radicais | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Adicionar limites | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Adicionar scripts do lado esquerdo | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Adicionar somatórios e integrais | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Adicionar matrizes de equações | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Adicionar delimitadores | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Adicionar barras e bordas | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Agrupar termos | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), obtenha seu [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, Aspose.Slides grava a equação como conteúdo matemático editável do Office.

**Posso exportar equações para LaTeX?**

Sim. Obtenha o [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) da sua [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), e chame [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) para exportá‑lo diretamente. Para um exemplo completo, veja [Exportar Equações Matemáticas de Apresentações em .NET](/slides/pt/net/exporting-math-equations/#export-math-equations-to-latex).