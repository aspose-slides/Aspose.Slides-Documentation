---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint no .NET
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/net/search-and-replace-text/
keywords:
- texto de pesquisa
- realçar texto
- substituir texto
- expressão regular
- callback de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Pesquise, realce e substitua texto em apresentações PowerPoint enquanto coleta todas as correspondências com Aspose.Slides for .NET."
---
## **Visão Geral**

Aspose.Slides for .NET pode pesquisar, realçar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um retorno de chamada de resultado. Isso permite atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondente, seu contexto, posição, quadro de texto e número do slide.

Esses recursos são úteis para revisão, redação, verificações de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Escolher o Escopo da Pesquisa**

Use métodos em [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) para limitar uma operação a um único quadro de texto. Use métodos em [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlighttext/) |
| Realçar correspondências de expressão regular | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlightregex/) |
| Substituir texto literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replacetext/) |
| Substituir correspondências de expressão regular | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replaceregex/) |

## **Configurar Correspondência de Texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/wholewordsonly/) limita as correspondências a palavras completas.  
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/casesensitive/) controla se a diferenciação entre maiúsculas e minúsculas deve coincidir.  
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/includenotes/) inclui notas de slide nas operações de pesquisa, substituição e realce em nível de apresentação.

Operações de expressão regular usam um `Regex` do .NET, portanto regras de correspondência como sensibilidade a maiúsculas/minúsculas e limites de palavra são definidas pela expressão e suas opções.

## **Identificar o Proprietário de um Quadro de Texto**

Fluxos de trabalho genéricos de processamento de texto frequentemente recebem um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) ao pesquisar, substituir, validar ou exportar texto. Use [ITextFrame.ParentShape](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentshape/) e [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) para determinar qual objeto da apresentação possui o quadro de texto.

Os valores esperados dependem do proprietário:

| Proprietário do quadro de texto | `ParentShape` | `ParentCell` |
|---|---|---|
| Um AutoShape ou outra forma que contém texto | O [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) proprietário | `null` |
| Uma célula de tabela | `null` | O [ICell](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/) proprietário |

Ambas as propriedades são propriedades de navegação somente leitura. Ler elas não move o quadro de texto nem altera seu proprietário. O código genérico deve verificar ambos os valores para `null` e tratar a possibilidade de que nenhum proprietário esteja disponível.

O exemplo a seguir usa [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextframes/) para iterar pelos quadros de texto em uma apresentação. Para formas, ele relata o nome da forma, o tipo de forma e o slide contendo. Para células de tabela, ele relata as coordenadas de coluna e linha baseadas em zero e o slide contendo.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Para conteúdo SmartArt, itere pelas formas em [ISmartArtNode.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartartnode/shapes/) e acesse cada [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartartshape/textframe/). O quadro de texto pode ser rastreado até sua forma associada por meio de [ITextFrame.ParentShape](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentshape/), enquanto [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) é `null`. Portanto, o ramo de forma no exemplo também lida com texto de nós SmartArt.

## **Coletar Informações de Correspondência com um Callback**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/) para receber uma notificação para cada correspondência. Seu método [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/foundresult/) fornece o quadro de texto relacionado, o texto de origem, o texto correspondido e a posição da correspondência.

O callback não recebe um número de slide diretamente. A implementação abaixo o deriva do slide pai e também lida com texto encontrado nas notas de slide. Um número de slide anulável permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Para operações de substituição, `FoundText` contém o texto original correspondido, portanto o callback pode registrar exatamente quais termos foram substituídos.

## **Realçar Texto**

Use o método [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/) para realçar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/) para controlar a pesquisa e um callback para coletar detalhes da correspondência.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e depois realça apenas a palavra completa **"to"**. Ambas as pesquisas reportam suas correspondências ao mesmo callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Obtenha a primeira forma do primeiro slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

O resultado:

![O texto realçado](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/) realça as correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres e coleta cada correspondência:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

O resultado:

![O texto realçado usando a expressão regular](highlighted_text_using_regex.png)

## **Realçar Texto em Toda a Apresentação**

Use [Presentation.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlighttext/) e [Presentation.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlightregex/) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de e‑mail, mantendo coleções de resultados separadas para as duas pesquisas.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Substituir Texto em um Quadro de Texto**

Use [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) para texto literal e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, que mantém a formatação da porção circundante em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e então substitui rótulos de versão. O mesmo callback registra os termos originais correspondidos por ambas as operações.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Se uma correspondência abranger porções com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto de substituição.

## **Substituir Texto em Toda a Apresentação**

Use [Presentation.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replacetext/) e [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replaceregex/) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Agrupar Correspondências para Relatórios**

Como cada resultado armazena seu número de slide e quadro de texto, os aplicativos podem agrupar correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **Perguntas Frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) ou [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/wholewordsonly/) e [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/casesensitive/) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas diretamente no `Regex` do .NET.

**A pesquisa e substituição podem incluir texto nas notas de slide?**

Sim. Defina [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/includenotes/) como `true` ao usar uma operação de texto literal em nível de apresentação. A implementação do callback mostrada acima mapeia uma correspondência em um slide de notas de volta para o número do slide pai.

**Como posso criar um relatório sem analisar a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/) para a operação de realce ou substituição. O callback recebe cada correspondência enquanto a operação é executada, permitindo que o aplicativo armazene o texto de origem, o texto correspondido, a posição, o quadro de texto e o número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação da porção circundante. Se uma correspondência abranger porções com formatações diferentes, inspecione o resultado para garantir que a substituição use o estilo desejado.