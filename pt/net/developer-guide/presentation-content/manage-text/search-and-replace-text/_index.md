---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint no .NET
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/net/search-and-replace-text/
keywords:
- pesquisar texto
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
description: "Pesquisar, realçar e substituir texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET pode pesquisar, realçar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um callback de resultado. Isso possibilita atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondido, seu contexto, posição, quadro de texto e número do slide.

Essas funcionalidades são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Escolher o escopo da pesquisa**

Use os métodos em [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) para limitar uma operação a um quadro de texto. Use os métodos em [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlighttext/) |
| Realçar correspondências de expressão regular | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/highlightregex/) |
| Substituir texto literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replacetext/) |
| Substituir correspondências de expressão regular | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replaceregex/) |

## **Configurar correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/wholewordsonly/) limita as correspondências a palavras completas.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/casesensitive/) controla se a capitalização dos caracteres deve ser considerada.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/includenotes/) inclui notas de slide nas operações de pesquisa, substituição e realce em nível de apresentação.

Operações de expressão regular utilizam um `Regex` do .NET, portanto regras de correspondência como sensibilidade a maiúsculas e limites de palavras são definidas pela própria expressão e suas opções.

## **Coletar informações de correspondência com um callback**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/) para receber uma notificação para cada correspondência. Seu método [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/foundresult/) fornece o quadro de texto relacionado, o texto de origem, o texto correspondido e a posição da correspondência.

O callback não recebe diretamente o número do slide. A implementação abaixo o deriva do slide pai e também lida com texto encontrado nas notas do slide. Um número de slide anulável permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

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
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

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

Para operações de substituição, `FoundText` contém o texto original correspondido, de modo que o callback pode registrar exatamente quais termos foram substituídos.

## **Realçar Texto**

Use o método [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/) para realçar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/) para controlar a pesquisa e um callback para coletar detalhes das correspondências.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça apenas a palavra completa **"to"**. Ambas as pesquisas enviam suas correspondências ao mesmo callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
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

![O texto destacado](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/) realça textos correspondidos por uma expressão regular em um quadro de texto.

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

![O texto destacado usando a expressão regular](highlighted_text_using_regex.png)

## **Realçar Texto em uma Apresentação**

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

Use [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) para texto literal e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, que mantém a formatação da porção ao redor em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e, em seguida, substitui rótulos de versão. O mesmo callback registra os termos originais correspondidos por ambas as operações.

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

Se uma correspondência abranger partes com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir Texto em uma Apresentação**

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

Como cada resultado armazena seu número de slide e quadro de texto, as aplicações podem agrupar correspondências para auditoria, relatório ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

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

## **FAQ**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) ou [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/wholewordsonly/) e [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/casesensitive/) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Regex` do .NET.

**A pesquisa e substituição podem incluir texto nas notas de slide?**

Sim. Defina [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pt/net/aspose.slides/textsearchoptions/includenotes/) como `true` ao usar uma operação de texto literal em nível de apresentação. A implementação do callback mostrada acima mapeia uma correspondência em um slide de notas de volta ao número do slide pai.

**Como posso criar um relatório sem analisar a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/ifindresultcallback/) para a operação de realce ou substituição. O callback recebe cada correspondência enquanto a operação é executada, permitindo que a aplicação armazene o texto de origem, o texto correspondido, a posição, o quadro de texto e o número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replacetext/) e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/replaceregex/) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação da porção ao redor. Se uma correspondência abranger partes com formatações diferentes, examine o resultado para garantir que a substituição use o estilo desejado.