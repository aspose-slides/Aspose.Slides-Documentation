---
title: Format ar Texto de Apresentação em .NET
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/net/text-formatting/
keywords:
- realçar texto
- expressão regular
- alinhar parágrafo
- estilo de texto
- fundo do texto
- transparência do texto
- espaçamento entre caracteres
- propriedades da fonte
- família de fontes
- rotação do texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- âncora do quadro de texto
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

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides for .NET. Ele aborda realce, cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Nos exemplos abaixo, usaremos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Destacar Texto**

Use o [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/) quando precisar destacar texto que corresponda a um padrão específico dentro de um quadro de texto. O método aplica uma cor de destaque aos fragmentos de texto correspondentes e pode ser usado com [TextSearchOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/) para controlar como a pesquisa é realizada, por exemplo, para corresponder apenas a palavras inteiras.

O exemplo de código abaixo destaca todas as ocorrências dos caracteres **"try"** e depois destaca somente a palavra completa **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Obtenha a primeira forma do primeiro slide.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Realce a palavra "try" na forma.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Realce a palavra "to" na forma.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O texto destacado](highlighted_text.png)

## **Destacar Texto Usando Expressões Regulares**

O método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/) destaca correspondências de texto encontradas por uma expressão regular. No .NET, essa API está exposta em [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/).

O exemplo de código abaixo destaca todas as palavras que contêm **sete ou mais caracteres**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Realce todas as palavras com sete ou mais caracteres.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O texto destacado usando a expressão regular](highlighted_text_using_regex.png)

## **Definir Cor de Fundo do Texto**

Use [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/defaultportionformat/) para definir a cor de destaque padrão de um parágrafo, ou use [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/highlightcolor/) para porções de texto individuais.

O exemplo de código a seguir mostra como definir a cor de fundo para o **parágrafo inteiro**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Defina a cor de destaque para todo o parágrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **porções de texto com fonte em negrito**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Defina a cor de destaque para a porção de texto.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As porções de texto cinza](gray_text_portions.png)

## **Alinhar Parágrafos de Texto**

Use [IParagraphFormat.Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/alignment/) para definir o alinhamento de parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado, etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Defina o alinhamento do parágrafo para o centro.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Definir Transparência para Texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [IPortionFormat.FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/fillformat/). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Defina a cor de preenchimento do texto como cor transparente.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **porções de texto com fonte em negrito**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Defina a transparência da porção de texto.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir Espaçamento de Caracteres para Texto**

Use [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/spacing/) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto.

O código C# a seguir mostra como expandir o espaçamento de caracteres no **parágrafo inteiro**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expanda o espaçamento entre caracteres.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O espaçamento de caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento de caracteres em **porções de texto com fonte em negrito**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.PortionFormat.Spacing = 3;  // Expanda o espaçamento entre caracteres.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O espaçamento de caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desabilitar Kerning para Fontes Específicas**

Em alguns casos, o texto renderizado pelo Aspose.Slides pode parecer um pouco mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para certas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para que a saída renderizada fique mais próxima do PowerPoint nesses casos, você pode desabilitar o kerning para as porções de texto que usam a fonte afetada. Defina [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/kerningminimalsize/) para um valor significativamente maior que o tamanho real da fonte:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Esta configuração impede que o kerning seja aplicado às porções de texto correspondentes e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar Propriedades de Fonte do Texto**

As propriedades de fonte podem ser definidas ao nível do parágrafo através de [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/defaultportionformat/) ou em porções individuais através de [IPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/).

O código a seguir define a fonte e o estilo de texto para o parágrafo inteiro: ele aplica tamanho de fonte, negrito, itálico, sublinhado pontilhado e a fonte Times New Roman a todas as porções do parágrafo.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Defina as propriedades da fonte para o parágrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo de código abaixo aplica propriedades semelhantes a **porções de texto com fonte em negrito**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Defina as propriedades da fonte para a porção de texto.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As propriedades de fonte das porções de texto](font_properties_for_text_portions.png)

## **Definir Rotação do Texto**

Use [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/textverticaltype/) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma como `Vertical270`, que gira o texto **90 graus no sentido anti‑horário**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir Rotação Personalizada para Quadros de Texto**

Use [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/rotationangle/) para definir um ângulo de rotação personalizado para um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir Espaçamento entre Linhas dos Parágrafos**

Aspose.Slides fornece [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/spacebefore/) e [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/spacewithin/) para controlar o espaçamento de parágrafo. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento como uma porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento em pontos.

O exemplo de código a seguir mostra como especificar o espaçamento entre linhas dentro do parágrafo:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Definir Tipo de Ajuste Automático para Quadros de Texto**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/autofittype/) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Definir Âncora dos Quadros de Texto**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/anchoringtype/) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo no topo, meio ou fundo.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Definir Tabulação de Texto**

Use [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/tabs/) para configurar as tabulações em um parágrafo.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir Idioma de Revisão**

Aspose.Slides fornece [IPortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/languageid/), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado nas verificações ortográficas e gramaticais no PowerPoint.

O exemplo de código a seguir mostra como definir o idioma de revisão para uma porção de texto:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Defina o Id de um idioma de revisão.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Definir Idioma Padrão**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaulttextlanguage/) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Adicione uma nova forma retangular com texto.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Verifique o idioma da primeira porção.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Definir Estilo de Texto Padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/defaulttextstyle/).

O exemplo de código a seguir mostra como definir uma fonte em negrito padrão com tamanho 14 pt para todo o texto em todas as slides de uma nova apresentação.

```cs
using (var presentation = new Presentation())
{
    // Obtenha o formato de parágrafo de nível superior.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Extrair Texto com o Efeito Tudo em Maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide, mesmo que ele tenha sido digitado originalmente em minúsculas. Ao recuperar tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/pt/net/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Suponha que tenhamos a seguinte caixa de texto no primeiro slide do arquivo sample2.pptx.

![O efeito Tudo em Maiúsculas](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/). Itere pelas células e atualize cada célula através de [ICell.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/textframe/) e da formatação de parágrafo por meio de [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/paragraphformat/).

**Como aplicar cor degradê ao texto em um slide do PowerPoint?**

Para aplicar uma cor degradê ao texto, use [IPortionFormat.FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/fillformat/). Defina [IFillFormat.FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/ifillformat/filltype/) como [FillType.Gradient](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) e configure as paradas do degradê, a direção e a transparência.