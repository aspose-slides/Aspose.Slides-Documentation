---
title: Formatar formas do PowerPoint em .NET
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/net/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em tons de cinza
- rotacionar forma
- efeito de chanfradura 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em C# usando Aspose.Slides—defina preenchimentos, linhas e estilos de efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

Formate formas no PowerPoint ajustando seus contornos, preenchimentos e efeitos. Aspose.Slides for .NET permite controlar essas configurações programaticamente, incluindo transparência, rotação e formatação 3D.

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fornece interfaces e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Use [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para controlar o contorno de uma forma. Este exemplo cria um retângulo sem preenchimento com um contorno azul, tracejado. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) seleciona uma linha composta espessa-fina, enquanto [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) define sua largura para 7 pontos e [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) seleciona o padrão de traço.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

O resultado:

![The formatted lines in the presentation](formatted-lines.png)

### **Definir padrões de traço de linha personalizados**

Use [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) quando os estilos de linha predefinidos não fornecem os comprimentos de traço e espaço que você precisa, por exemplo para contornos de marca ou diagramas técnicos. Atribuir um padrão define automaticamente [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) como [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

As entradas do array alternam entre comprimentos de traço e espaço, começando com um traço. Cada valor é um múltiplo da largura da linha: `{ 4, 2 }` com largura de 3 pontos produz um traço de 12 pontos seguido por um espaço de 6 pontos. Use pares de valores finitos e não negativos para definir segmentos completos de traço e espaço. O exemplo usa valores positivos para manter cada traço e espaço visíveis.

Este exemplo cria cinco linhas azuis com o mesmo comprimento e extremidades planas. As três primeiras comparam padrões com largura de 3 pontos. A quarta repete o primeiro padrão com o dobro da largura, dobrando os comprimentos do traço e do espaço. A quinta troca de um padrão personalizado para uma linha sólida.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Para voltar a um estilo tracejado predefinido, atribua [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). O estilo selecionado controla a aparência da linha.

O resultado no PowerPoint, de cima para baixo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)


### **Definir acabamentos de linha**

Use [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) para definir as extremidades de uma linha aberta. A enumeração [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) fornece três estilos de acabamento explícitos:

- `Flat`: O traço termina no ponto final.
- `Round`: Um acabamento semicircular se estende além do ponto final em meia largura da linha.
- `Square`: Um acabamento quadrado se estende além do ponto final em meia largura da linha.

A enumeração também inclui `NotDefined`, que significa que nenhum acabamento foi atribuído explicitamente.

Os acabamentos são diferentes de pontas de seta, que adicionam símbolos às extremidades da linha, e de junções, que controlam cantos entre segmentos de linha. Este exemplo desabilita pontas de seta através de [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) e [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) para que apenas os formatos de acabamento sejam comparados.

O exemplo a seguir cria três linhas horizontais, de outra forma idênticas, com 20 pontos de largura. De cima para baixo, elas usam acabamentos plano, arredondado e quadrado. Seus pontos finais têm as mesmas coordenadas horizontais; os acabamentos arredondado e quadrado se estendem 10 pontos além de cada ponto final.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

O resultado no PowerPoint, de cima para baixo: **Flat**, **Round**, e **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Aplicar efeitos de esboço às linhas da forma**

Um efeito de esboço faz com que a linha de uma forma pareça desenhada à mão. Use [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para acessar as configurações da linha, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) para acessar as configurações de esboço e [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

O código C# a seguir mostra como aplicar um efeito [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

O valor retornado por [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), acesse [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) e leia [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). O valor efetivo reflete a formatação realmente aplicada após a resolução da herança. Este exemplo requer uma apresentação existente com ao menos uma forma no primeiro slide e imprime ambos os valores:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

O estilo de junção controla como dois segmentos de contorno se encontram em um canto. Use **Round** para cantos arredondados, **Miter** para cantos agudos ou **Bevel** para cantos chanfrados.

![The join style in the presentation](join-style-powerpoint.png)

Este exemplo cria três retângulos pretos com contornos azuis de 15 pontos de largura. Ele define [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) para os valores miter, bevel e round da enumeração [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), respectivamente, para comparar como os cantos são desenhados.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Limitar junções em ângulos agudos**

Use [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) com [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) definido como [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) para limitar o quanto um canto agudo pode se estender.

O limite é uma razão entre a distância entre os cantos interno e externo da junção e a largura da linha. Por exemplo, um valor de `8` permite um comprimento de corte de até oito vezes a largura da linha; não é uma medida em pontos. Se o canto exceder o limite, o PowerPoint usa uma junção chanfrada nesse canto. Um limite maior permite pontas mais agudas. A configuração afeta apenas junções tipo miter e não tem efeito visível quando o canto permanece dentro dos limites.

Este exemplo cria dois triângulos idênticos, sem preenchimento, com contornos de 20 pontos de largura. O triângulo esquerdo usa um limite de `2` e o direito usa `8`. Cada triângulo tem 80 pontos de largura e 160 pontos de altura, dando ao seu canto superior uma razão comprimento‑da‑corte‑para‑largura‑da‑linha de aproximadamente `4.12`. Consequentemente, o PowerPoint chanfrá o ápice esquerdo e preservará o ápice direito.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

O resultado no PowerPoint: **Limite de corte 2** à esquerda e **limite de corte 8** à direita.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Preenchimento gradiente**

Um preenchimento gradiente mescla cores ao longo de uma forma. Este exemplo preenche uma elipse com um gradiente linear em um ângulo de 45 graus do vermelho ao roxo usando [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). O método [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) coloca as paradas de cor em 0 e 1, o início e o fim do gradiente. Limpar as paradas existentes garante que apenas essas duas cores sejam usadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

O resultado:

![The ellipse with gradient fill](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada do que no PowerPoint, veja [Choose a Gradient Rendering Style](/slides/pt/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem mudar o preenchimento gradiente armazenado na apresentação.

### **Definir o ângulo do gradiente linear**

Use [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) para controlar a orientação de um preenchimento [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). O ângulo é medido em graus e aumenta no sentido horário: `0` vai da esquerda para a direita, `90` de cima para baixo, `180` da direita para a esquerda e `270` de baixo para cima. Ângulos fracionais são suportados. Ângulos finitos fora de `[0, 360)` são normalizados para uma revolução; por exemplo, `-45` torna‑se `315` e `360` torna‑se `0`.

Este exemplo cria seis retângulos com paradas de cor vermelha, verde e azul idênticas nas posições `0`, `0.5` e `1`. O dimensionamento está desativado para que o ângulo possa ser comparado independentemente das proporções dos retângulos. Os ângulos, da esquerda para a direita, são `0`, `45` e `90` na primeira linha, e `135`, `180` e `270` na segunda linha.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

O resultado no PowerPoint:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Dimensionar um gradiente linear com a forma**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) aceita um valor [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Defina‑o explicitamente como `False` para manter o ângulo geométrico do gradiente conforme as proporções da forma mudam, ou como `True` para dimensionar o gradiente com a largura e altura da forma. Com o dimensionamento ativado, o ângulo visível pode diferir do ângulo atribuído em uma forma não quadrada.

O exemplo a seguir usa um ângulo de `45` graus e as mesmas paradas de cor do comparativo de ângulo. A coluna da esquerda usa `False`; a da direita usa `True`. Cada coluna contém um retângulo largo acima de um retângulo alto. Ambos começam com as mesmas dimensões largas; alterar a largura e altura do segundo retângulo demonstra como o preenchimento responde ao redimensionamento sem mudar suas configurações de gradiente.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

O resultado no PowerPoint, com dimensionamento desativado à esquerda e ativado à direita:

![Wide and tall rectangles with a 45-degree gradient, comparing LinearGradientScaled False on the left with True on the right](linear-gradient-scaling.png)

Com o dimensionamento desativado, as faixas de cor diagonais mantêm a mesma orientação em ambos os retângulos. Com o dimensionamento ativado, as faixas se esticam com as proporções da forma. Isso ajuda a reproduzir o gradiente de um modelo ao adaptar uma forma a um tamanho diferente. Em um quadrado, habilitar o dimensionamento não altera a aparência deste gradiente de `45` graus.

Ambos os ajustes de ângulo e dimensionamento se aplicam a gradientes lineares. Eles não controlam preenchimentos [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Combinar o ângulo com a direção do gradiente**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) seleciona um estilo de gradiente da enumeração [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); não substitui um ângulo numérico. Para um gradiente linear, os estilos de canto podem mudar a área sobre a qual as cores são distribuídas sem mudar [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Mantenha a direção inalterada ao comparar ângulos ou dimensionamento.

O exemplo a seguir aplica as mesmas configurações em ordens opostas. Os dois retângulos têm a mesma aparência: atribuir a direção antes ou depois do ângulo não altera o resultado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Preenchimento de padrão**

Um preenchimento de padrão aplica um desenho de duas cores, como pontos, listras ou quadriculados. Este exemplo usa [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) para selecionar um padrão de treliça. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) fornece o fundo cinza claro, e [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) fornece a cor amarela do padrão.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento de imagem**

Um preenchimento de imagem usa uma imagem dentro de uma forma. Este exemplo requer uma imagem local e usa [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) para carregá‑la na coleção de imagens da apresentação. Definir [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) para o modo mosaico repete a imagem dentro do retângulo. A imagem fonte usada aqui é mostrada abaixo:

![The lotus picture](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

O resultado:

![The shape with picture fill](picture-fill.png)

### **Ladrilhar imagem como textura**

Se quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, você pode usar as seguintes propriedades da interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica o alinhamento dos mosaicos dentro da forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Controla se o mosaico é espelhado horizontalmente, verticalmente ou em ambas as direções.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Define o deslocamento horizontal do mosaico (em pontos) a partir da origem da forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Define o deslocamento vertical do mosaico (em pontos) a partir da origem da forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Define a escala horizontal do mosaico como porcentagem.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Define a escala vertical do mosaico como porcentagem.

Este exemplo requer uma imagem local e configura [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) para repeti‑la em 50 % do tamanho original. Deslocamentos de −32 pontos deslocam os mosaicos horizontal e verticalmente; o alinhamento inferior‑direito e o espelhamento em ambas as direções determinam como a textura repetida é organizada.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

O resultado:

![The tile options](tile-options.png)

## **Preenchimento de cor sólida**

Um preenchimento sólido atribui à forma uma única cor uniforme. Este exemplo define [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) para o modo de preenchimento sólido e atribui amarelo através de [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), então salva o retângulo em uma apresentação.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

O resultado:

![The shape with solid color fill](solid-color-fill.png)

### **Copiar cores preservando referências de tema**

Use [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) para copiar uma definição de cor, incluindo seu tipo de cor, referência de tema e transformações. Isso é útil ao transferir a cor de preenchimento entre formas que devem continuar seguindo o tema da apresentação. O método copia apenas a cor: não copia o tipo de preenchimento, contorno ou outra formatação da forma. Defina explicitamente o [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) de destino.

Este exemplo cria três retângulos, da esquerda para a direita: a origem, uma cópia consciente de tema e uma cópia RGB fixa. A origem usa [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) para referenciar a primeira cor de destaque e adiciona um matiz através de [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). A cópia RGB usa a cor de preenchimento efetiva da origem, de modo que as três inicialmente pareçam idênticas. Atribuir [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) define um valor RGB fixo e limpa quaisquer transformações de cor existentes.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Antes da mudança de tema, todos os três preenchimentos correspondem:

![Source, CopyFrom destination, and fixed RGB destination with identical blue fills](color-copy-before.png)

Depois da mudança de tema, a origem e a cópia consciente de tema seguem a nova cor de destaque e mantêm o matiz. A cópia RGB fixa permanece azul:

![Source and CopyFrom destination with orange fills, while the fixed RGB destination remains blue](color-copy-after.png)

A definição copiada é independente da origem. Alterar posteriormente a referência de tema da origem, atribuir outra cor ou adicionar/remover suas transformações não altera o destino. Uma mudança de tema ainda afeta ambas as formas porque cada uma refere‑se independentemente à mesma cor de tema.

Salvar e reabrir o PPTX preserva o [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), a referência de tema e a coleção [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) da cor copiada; não transforma a definição em RGB.

Ao copiar entre diferentes contextos de tema, como apresentações com paletas de destaque distintas, a referência copiada é resolvida contra o tema de destino. A mesma referência e transformações podem, portanto, produzir uma cor visível diferente. Consulte [Presentation Theme](/slides/pt/net/presentation-theme/) para mais informações sobre configuração de cores de tema.

## **Usar o plano de fundo do slide como preenchimento da forma**

Use [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) quando uma forma deve combinar com o plano de fundo do slide, por exemplo em um modelo de apresentação. Defina [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) como [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) primeiro para remover qualquer preenchimento explícito. Com essa combinação, a forma usa o plano de fundo do slide em vez do preenchimento de estilo. Habilitar a flag sozinha não remove um preenchimento explícito existente.

Isso difere de [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): o preenchimento de plano de fundo cobre objetos atrás da forma com a área correspondente do plano de fundo do slide, enquanto sem preenchimento esses objetos permanecem visíveis. Um gradiente permanece alinhado ao slide em vez de reiniciar dentro de cada forma.

O exemplo a seguir cria um plano de fundo mestre herdado pelo slide e coloca uma faixa magenta atrás de três retângulos. O retângulo da esquerda usa o plano de fundo, o do meio não tem preenchimento e o da direita alterna do preenchimento de plano de fundo para um preenchimento laranja explícito.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Herdar o gradiente do mestre.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Adicionar este objeto primeiro para que ele apareça atrás dos retângulos.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Desativar preenchimento de fundo antes de aplicar um preenchimento explícito.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

O resultado, da esquerda para a direita: **preenchimento de plano de fundo**, **sem preenchimento** e **preenchimento explícito**. A faixa magenta é ocultada pelos retângulos esquerdo e direito, mas permanece visível através do retângulo do meio.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

O mesmo comportamento se aplica a um plano de fundo definido diretamente no slide ou herdado de um layout. A forma usa o plano de fundo resolvido do slide; o exemplo deixa tanto o plano de fundo do slide quanto o do layout indefinidos para que o mestre o forneça.

## **Definir transparência**

Para um preenchimento sólido, o componente alfa da cor controla a opacidade: 0 é totalmente transparente e 255 é totalmente opaco. Este exemplo usa um valor alfa de 128 para um retângulo amarelo, tornando‑o aproximadamente 50 % transparente, de modo que o retângulo abaixo permaneça visível. A cor é atribuída através de [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

O resultado:

![The transparent shape](shape-transparency.png)

## **Rotacionar formas**

Use [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) para rotacionar uma forma no plano do slide. O ângulo é medido em graus; este exemplo rotaciona um retângulo 5 graus no sentido horário e salva a apresentação.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

O resultado:

![The shape rotation](shape-rotation.png)

## **Adicionar efeitos de chanfradura 3D**

Use [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) para dar profundidade a uma forma e bordas chanfradas. Este exemplo cria uma elipse verde com contorno laranja, define [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) para 4 pontos e aplica um chanfrado superior circular com largura e altura de 6 pontos através de [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Uma câmera ortográfica frontal e iluminação de três pontos tornam o chanfrado visível.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

O resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

A visualização 3D de uma forma é controlada pelas configurações da câmera. Este exemplo usa [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) com ângulos de latitude, longitude e revolução de 40, 35 e 20 graus, respectivamente. Seleciona uma câmera isométrica através de [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) e iluminação balanceada através de [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), então salva o retângulo formatado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Controlar renderização em preto e branco para formas**

A propriedade [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto‑e‑branco. Ela não habilita a exibição em preto‑e‑branco por si só e não altera o preenchimento, a linha ou outra formatação da forma no modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` deixa o aplicativo de renderização escolher a conversão, `Gray` e `LightGray` usam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal, e `Hidden` omite a forma no modo preto‑e‑branco. `NotDefined` significa que nenhum modo de forma foi atribuído.

Este exemplo cria um retângulo laranja e define [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) como gray. A forma salva mantém seu preenchimento laranja para exibição em cores normais e solicita coloração cinza de aplicativos que respeitam as configurações de exibição em preto‑e‑branco:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Em modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto‑e‑branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição em preto‑e‑branco da apresentação.

## **Redefinir formatação**

Use [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) para restaurar a posição, tamanho e formatação dos marcadores de posição do slide a partir dos marcadores de posição correspondentes do layout. Este exemplo requer uma apresentação existente com marcadores de posição vinculados ao layout e redefine cada slide antes de salvar. Formas sem marcadores de posição correspondentes no layout não são redefinidas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Cores, estilos de linha e configurações de efeito geralmente adicionam poucos dados comparados com imagens e mídia incorporadas. Preenchimentos de imagem podem aumentar o tamanho do arquivo porque suas imagens são armazenadas na apresentação.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as propriedades de formatação principais de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica a gestão de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas de que precisar e reaplique sua formatação onde for necessário.