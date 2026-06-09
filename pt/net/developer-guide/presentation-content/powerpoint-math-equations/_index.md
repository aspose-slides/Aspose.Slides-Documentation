---
title: Adicionar Equações Matemáticas a Apresentações PowerPoint em .NET
linktitle: Equações Matemáticas PowerPoint
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
description: "Inserir e editar equações matemáticas em arquivos PowerPoint PPT e PPTX com Aspose.Slides para .NET, suportando OMML, controles de formatação e exemplos de código C# claros."
---
## **Visão geral**

PowerPoint armazena equações como Office Math Markup Language (OMML). Com Aspose.Slides para .NET, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores N‑ário, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações por meio de **Inserir > Equação**:

![Guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

Aspose.Slides constrói esse texto matemático através de três objetos principais:

- Uma forma matemática, criada com [AddMathShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addmathshape/), é a forma que contém a equação.
- O [MathPortion](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/) armazena o conteúdo matemático dentro da caixa de texto da forma.
- O [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathematicaltext/) e os métodos fluentes de [IMathElement](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/) para manter o código curto e legível.

Para cenários de exportação MathML, veja [Exportar Equações Matemáticas de Apresentações em .NET](/slides/pt/net/exporting-math-equations/).

## **Criar uma Equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c ao quadrado igual a a ao quadrado mais b ao quadrado](powerpoint-math-equations_3.png)

```csharp
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

{{% alert color="primary" %}}
`AddMathShape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos matemáticos ou elementos matemáticos a ele.
{{% /alert %}}

## **Adicionar Frações**

Use `Divide` para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathfractiontypes/).

![Uma fração matemática inclinada mostrando um dividido por x](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Para uma fração empilhada, use `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Adicionar Radicais**

Use `Radical` para criar uma raiz quadrada, raiz cúbica ou outra raiz. O elemento atual torna‑se a base e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

```csharp
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

Use `AsArgumentOfFunction` ou `Function` para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathlimit/) ou use `SetLowerLimit`.

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

```csharp
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

Para um nome de função personalizado, torne o nome da função o elemento atual:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Adicionar Operadores N‑ários e Integrais**

Use `Nary` para somatórios, uniões, interseções e outros operadores grandes. Use `Integral` para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Um somatório com limites inferior e superior](powerpoint-math-equations_7.png)

```csharp
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

Operadores N‑ários são para operadores grandes com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como `MathematicalText` e unidos na expressão.

Para uma integral, use `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Adicionar Matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto coloque a matriz entre parênteses, colchetes ou chaves quando precisar.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

```csharp
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

## **Adicionar Arrays de Equações**

Use `ToMathArray` quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

```csharp
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

## **Adicionar Funções Trigonométricas**

Use `AsArgumentOfFunction` quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Adicionar Subscritos e Superescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer no lado esquerdo da base, use `SetSubSuperscriptOnTheLeft`.

![Um Y maiúsculo com subscrito 1 à esquerda e sobrescrito n](powerpoint-math-equations_9.png)

```csharp
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

Use `Enclose` para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadoras que contêm vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

```csharp
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

## **Adicionar uma Caixa de Borda**

Use `ToBorderBox` quando a própria equação deve ser emoldurada.

![Uma equação em caixa mostrando a ao quadrado igual a b ao quadrado mais c ao quadrado](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Agrupar Termos**

Use `Group` para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x mais y agrupada com o rótulo algum texto abaixo dela](powerpoint-math-equations_15.png)

```csharp
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

Use os auxiliares de formatação apenas onde eles esclarecem a fórmula. Por exemplo, `Overbar` coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Referência Rápida**

| Tarefa | API Principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.Join](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/join/) |
| Criar frações | [IMathElement.Divide](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/divide/) |
| Adicionar sobrescrito ou subscrito | [SetSuperscript](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Adicionar funções | [Function](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Adicionar radicais | [IMathElement.Radical](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/radical/) |
| Adicionar limites | [SetLowerLimit](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Adicionar scripts do lado esquerdo | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Adicionar somatórios e integrais | [Nary](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/integral/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathmatrix/) |
| Adicionar arrays de equações | [ToMathArray](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Adicionar delimitadores | [Enclose](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/enclose/) |
| Adicionar barras e bordas | [Overbar](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Agrupar termos | [Group](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathelement/group/) |

## **Perguntas Frequentes**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos matemáticos naquele parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, o Aspose.Slides grava a equação como conteúdo matemático editável do Office.

**Posso exportar equações para LaTeX?**

O Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e depois converta o MathML com uma ferramenta que suporte seu dialeto LaTeX alvo.