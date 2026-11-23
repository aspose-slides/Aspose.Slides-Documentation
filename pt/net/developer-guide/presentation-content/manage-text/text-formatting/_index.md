---
title: Formatar Texto de Apresentação em .NET
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/net/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência de texto
- espaçamento de caracteres
- propriedades de fonte
- família de fonte
- rotação de texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- âncora de quadro de texto
- tabulação de texto
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET. Ele cobre cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoramento de texto, tabulações e configurações de idioma.

Exceto quando indicado de outra forma, os exemplos usam [sample.pptx](sample.pptx). A primeira forma em seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slide quanto de forma são baseados em zero. Os exemplos que selecionam trechos em negrito utilizam formatação efetiva, incluindo formatação de negrito herdada:

![Texto de exemplo](sample_text.png)

Para encontrar e realçar texto literal ou correspondências de expressões regulares, veja [Buscar e Substituir Texto](/slides/pt/net/search-and-replace-text/).

## **Definir cor de fundo do texto**

Use [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) para definir a cor de destaque padrão para um parágrafo, ou use [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) para trechos individuais de texto.

O exemplo a seguir define um realce cinza claro como padrão para o primeiro parágrafo. Cores de realce explícitas em trechos individuais têm precedência sobre esse padrão:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Defina a cor de realce para todo o parágrafo.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **trechos de texto com fonte em negrito**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Defina a cor de realce para o trecho de texto.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

![Os trechos de texto cinza](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, alinhado à direita, justificado, etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Defina o alinhamento do parágrafo para o centro.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

![O parágrafo alinhado](aligned_paragraph.png)

## **Alinhar fontes dentro de uma linha**

Use [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) para alinhar verticalmente trechos de texto com tamanhos de fonte diferentes dentro de uma linha. Esta configuração se aplica a todo o parágrafo e controla o alinhamento dentro de cada uma de suas linhas.

O exemplo autocontido a seguir cria quatro caixas de texto rotuladas em um slide. Cada parágrafo contém o mesmo texto em 18, 36 e 54 pontos, com um alinhamento de fonte diferente. Ele usa Arial, desativa ajuste automático e quebra de linha, e mantém os quadros de texto grandes o suficiente para uma única linha.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

![Comparação de alinhamento de fonte Baseline, Topo, Centro e Base com tamanhos de fonte misturados](font_alignment.png)

Alinhamento de fonte usa métricas de fonte, portanto as bordas visíveis de letras individuais não se alinham necessariamente exatamente. O exemplo inclui tanto uma letra maiúscula quanto uma descendente para ajudar a mostrar a diferença entre o alinhamento baseline e o alinhamento inferior. A disponibilidade e substituição de fontes, os caracteres usados e a diferença nos tamanhos de fonte afetam o resultado. As dimensões do quadro, margens, espaçamento entre linhas, quebra de linha e ajuste automático também influenciam o layout; use as mesmas fontes e configurações de layout ao comparar os modos.

Essa configuração difere de [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), que controla o alinhamento horizontal do parágrafo, e de [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), que posiciona o bloco de texto verticalmente dentro de sua forma. A formatação de sobrescrito e subscrito através de [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) desloca trechos individuais em relação à linha base em vez de definir o alinhamento de fonte para as linhas do parágrafo.

## **Definir transparência para texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala de 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Defina um preenchimento preto semitransparente para o texto.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **trechos de texto com fonte em negrito**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Defina a transparência do trecho de texto.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

![Os trechos de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento entre caracteres para texto**

Use [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código C# a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expandir espaçamento entre caracteres.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

![O espaçamento entre caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento entre caracteres em **trechos de texto com fonte em negrito**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
        portion.PortionFormat.Spacing = 3;  // Expandir o espaçamento entre caracteres.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

![O espaçamento entre caracteres nos trechos de texto](character_spacing_in_text_portions.png)

### **Desativar Kerning para fontes específicas**

Em alguns casos, o texto renderizado pelo Aspose.Slides pode parecer ligeiramente mais compacto do que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para determinadas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para aproximar a saída renderizada do PowerPoint nesses casos, você pode desativar o kerning para trechos de texto que utilizam a fonte afetada. Defina [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) para um valor maior que o tamanho real da fonte. Este exemplo requer "presentation.pptx" com uma caixa de texto como primeira forma no primeiro slide. Ele verifica os nomes de fonte efetivos, incluindo fontes herdadas, e define um limite de 100 pontos para trechos que usam Roboto. Isso desativa o kerning para trechos correspondentes com tamanho de fonte inferior a 100 pontos:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Para texto correspondente abaixo do limite, essa configuração impede o kerning e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas ao nível do parágrafo através de [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ou em trechos individuais através de [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo como Times New Roman de 12 pontos com formatação em negrito, itálico e sublinhado pontilhado. A formatação explícita em trechos individuais tem precedência sobre esses padrões:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Defina as propriedades de fonte do parágrafo.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo a seguir aplica Times New Roman de 13 pontos, formatação itálica e sublinhado pontilhado a trechos cuja formatação efetiva é negrito:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Defina as propriedades de fonte para o trecho de texto.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

![As propriedades de fonte dos trechos de texto](font_properties_for_text_portions.png)

## **Controlar normalização de altura do texto**

Use [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) ao reproduzir tipografia de modelo ou investigar diferenças na altura dos caracteres. No PowerPoint, habilitar a normalização estica ou comprime verticalmente caracteres individuais para lhes dar uma altura visível uniforme dentro do trecho de texto. Isso não garante alturas de texto iguais entre diferentes fontes.

Defina a propriedade para [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) para habilitar ou desabilitar explicitamente a normalização. `NullableBool.NotDefined` deixa a configuração local indefinida, permitindo que o trecho herde seu valor, por exemplo, do [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) do parágrafo. Isso não significa `False`. Use [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) e leia [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) para obter o valor booleano resolvido.

O exemplo autocontido a seguir requer **Arial** instalado. Ele cria dois blocos de texto contendo as mesmas letras maiúsculas, minúsculas, descendentes e caracteres acentuados em 54 pontos. Ambos os parágrafos habilitam a normalização por padrão. O trecho superior desabilita explicitamente; o trecho inferior herda. Os tamanhos de quadro, margens e espaçamento de parágrafo são idênticos, com quebra de linha e ajuste automático desativados para manter a comparação consistente. O exemplo imprime `False: False` e `NotDefined: True`, então salva "text_height_normalization.pptx".

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

A comparação abaixo foi exportada da apresentação salva. A linha superior tem a normalização desativada (`False`); a linha inferior herda a configuração habilitada (`NotDefined` → `True`). Mantenha Arial instalado para reproduzir esta aparência.

![Texto Arial de 54 pontos com normalização desativada acima e normalização herdada habilitada abaixo](text_height_normalization.png)

A normalização altera a altura dos caracteres sem mudar o valor de [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), que especifica o tamanho da fonte em pontos. O [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) do parágrafo controla o espaçamento entre linhas, enquanto o [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) do quadro de texto controla como o texto ou seu contêiner se ajusta. Essas configurações têm propósitos diferentes e podem afetar o layout geral de forma independente. Para mais informações sobre formatação de parágrafo e herança, veja [Gerenciar Parágrafo](/slides/pt/net/manage-paragraph/).

## **Aplicar e remover tachado**

Use [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) em um trecho de texto para exibir correções, termos cancelados ou preços anteriores sem excluir o texto original. Defina para [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) para uma ou duas linhas atravessando o texto.

Para remover o tachado, atribua `TextStrikethroughType.None`. Isso desabilita explicitamente o efeito, mesmo que a formatação ao redor especificque tachado. Por outro lado, `TextStrikethroughType.NotDefined` deixa a configuração local indefinida, permitindo que o trecho herde a formatação, por exemplo, do parágrafo. Isso não garante que o tachado seja removido. Use [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) para ler a formatação resultante, incluindo valores herdados.

O exemplo autocontido a seguir cria três comparações de preço. Cada parágrafo tem trechos separados para o rótulo, preço anterior e preço atual, de modo que apenas o preço anterior é afetado. A primeira linha aplica e depois remove o tachado; as outras linhas mantêm tachado simples e duplo. Alterar esta propriedade preserva o texto e sua outra formatação, incluindo o preço anterior em negrito.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Aplicar tachado, depois removê‑lo explicitamente do primeiro preço anterior.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

O resultado, de cima para baixo: sem tachado, tachado simples e tachado duplo.

![Preços anteriores sem tachado, com tachado simples e com tachado duplo](strikethrough.png)

## **Definir rotação do texto**

Use [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), que rota o texto **90 graus no sentido anti-horário**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

![A rotação do texto](text_rotation.png)

## **Exibir dígitos lado a lado em texto vertical**

Para manter um número de dois dígitos junto em um rótulo vertical japonês, coloque ambos os dígitos em um único trecho de texto e defina [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) nesse trecho. O exemplo usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) e MS Gothic de 40 pontos para ambos os rótulos. Apenas o valor de [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) atribuído ao trecho numérico difere.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

No PowerPoint, o rótulo à esquerda (`True`) mostra os dígitos em pé e lado a lado entre 和 e 年. No rótulo à direita (`False`), o par é rotacionado 90 graus no sentido horário. Os caracteres japoneses ao redor permanecem em pé em ambos os rótulos.

![Comparação no PowerPoint de rótulos de data vertical com dígitos em pé à esquerda e dígitos rotacionados à direita.](vertical_date.png)

## **Definir rotação personalizada para quadros de texto**

Use [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) para definir um ângulo de rotação personalizado para um [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

![A rotação de texto personalizada](custom_text_rotation.png)

## **Definir espaçamento entre linhas dos parágrafos**

Aspose.Slides fornece [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) e [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo a seguir define o espaçamento dentro do primeiro parágrafo para 200% da altura da linha (espaçamento duplo):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Controlar quebra de linha**

As regras de quebra de linha de parágrafo são úteis em blocos de texto estreitos e apresentações que misturam texto latino e asiático oriental. As seguintes propriedades pertencem a [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), portanto se aplicam a todo o parágrafo:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) controla as regras de quebra de linha latinas. Em texto misto, alterá‑la também pode mudar onde o texto e pontuação asiáticos orientais adjacentes são quebrados.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controla as regras de quebra de linha asiáticas orientais, incluindo restrições de caracteres no início e no final de uma linha.

Essas regras não substituem [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo autocontido a seguir cria um bloco de texto estreito contendo texto chinês e latino. Ele define explicitamente ambas as propriedades de quebra de linha e salva "line_breaking.pptx". Para experimentar cada regra, altere o valor dessa propriedade mantendo as outras configurações fixas. O exemplo usa Arial de 24 pontos e SimSun com largura de quadro de 160 pontos e margens horizontais do quadro de texto zero. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) está definido como [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Controlar pontuação pendente**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) permite que pontuação elegível se estenda além da borda direita da linha de texto em vez de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de um recuo pendente.

O exemplo autocontido a seguir habilita a pontuação pendente em um quadro de texto de 100 pontos de largura e salva "hanging_punctuation.pptx". Com Arial de 24 pontos e margens horizontais do quadro de texto zero, o ponto final permanece após "sentence" e se estende além da borda direita do texto. Defina a propriedade para [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto ocupa uma linha separada. A quebra de linha está habilitada e o ajuste automático está desabilitado para manter a largura disponível fixa.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Nem toda marca de pontuação pode ficar pendente. As [condições de fonte e layout descritas acima](#control-line-breaking) também se aplicam a esta comparação: mudar a fonte, largura disponível, margens ou configurações de ajuste automático pode remover a diferença visível.

## **Definir tipo de ajuste automático para quadros de texto**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑a para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar e ajustar ao seu texto e salva o resultado em "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Para contar linhas após a quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Contar linhas renderizadas](/slides/pt/net/manage-paragraph/). A contagem de linhas por si só não indica se o texto transborda seu contêiner.

## **Definir âncora de quadros de texto**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou fundo. O exemplo a seguir ancora o texto na parte inferior da primeira forma e salva o resultado em "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Definir tabulação de texto**

Use [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo padrão de tabulação para 100 pontos e adiciona uma tabulação alinhada à esquerda em 30 pontos. Essas configurações afetam texto contendo caracteres de tabulação.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir idioma de verificação**

Aspose.Slides fornece [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), que permite definir o idioma de verificação para um trecho de texto. O idioma de verificação determina o idioma usado para correção ortográfica e gramatical no PowerPoint.

O exemplo a seguir requer "presentation.pptx" com uma caixa de texto como a primeira forma no primeiro slide e ao menos um parágrafo. Ele substitui o conteúdo do primeiro parágrafo por "1。", define SimSun como sua fonte e atribui o idioma de verificação Chinês Simplificado (`zh-CN`). Salva o resultado em "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Defina o idioma de verificação para Chinês Simplificado.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Copiar metadados de idioma**

Ao copiar texto multilíngue de um modelo, preserve tanto [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) quanto [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). O exemplo autocontido a seguir cria um trecho de origem com inglês dos EUA como idioma e francês como idioma alternativo e copia o texto e os identificadores para um trecho em uma nova apresentação.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Se a origem não tiver idioma alternativo, null limpa o valor de destino.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Para tentar uma origem sem idioma alternativo, omita a atribuição de `"fr-FR"`. O identificador alternativo será então `null`, e a mesma instrução de cópia preserva sua ausência sem introduzir um valor padrão, mesmo que o destino anteriormente tivesse um idioma alternativo atribuído.

Esses identificadores são metadados de idioma armazenados. Preservá‑los não define qual dicionário o PowerPoint seleciona para verificação ortográfica ou gramatical.

## **Definir idioma padrão**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma de texto padrão, adiciona uma caixa de texto e imprime `en-US` para seu primeiro trecho de texto.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Adicione uma nova forma retangular com texto.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Verifique o idioma da primeira porção.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

O exemplo a seguir define uma fonte em negrito de 14 pontos como padrão para parágrafos de nível superior em uma nova apresentação e a salva em "default_text_style.pptx". O texto pode herdar esses padrões, a menos que formatações mais específicas os sobrescrevam.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Obtenha o formato de parágrafo de nível superior.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extrair texto com o efeito tudo em maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide mesmo quando originalmente digitado em minúsculas. Ao recuperar tal trecho de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Este exemplo requer "sample2.pptx" com uma caixa de texto como a primeira forma no primeiro slide. O primeiro trecho do primeiro parágrafo contém "Hello, Aspose!" com o efeito All Caps aplicado, como mostrado abaixo.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modifico texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Itere pelas células e atualize cada célula através de [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) e a formatação de parágrafo através de [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Como aplico uma cor em gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor em gradiente ao texto, use [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Defina [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) como [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) e configure as paradas do gradiente, a direção e a transparência.

[Formatar texto em slides](/slides/pt/features/text-formatting/)