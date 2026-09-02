---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em JavaScript
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/nodejs-java/search-and-replace-text/
keywords:
- pesquisar texto
- realçar texto
- substituir texto
- expressão regular
- callback de resultado
- caixa de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Pesquisar, realçar e substituir texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode pesquisar, realçar e substituir texto em uma única caixa de texto ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um callback de resultado. Isso permite atualizar a apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondido, seu contexto, posição, caixa de texto e número do slide.

Esses recursos são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de geração de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado “sample.pptx”, que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Sample text](sample_text.png)

## **Escolher o escopo da pesquisa**

Use os métodos em [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) para limitar uma operação a uma caixa de texto. Use os métodos em [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Uma caixa de texto | Toda a apresentação |
|---|---|---|
| Realçar texto literal | [TextFrame.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Realçar correspondências de expressão regular | [TextFrame.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Substituir texto literal | [TextFrame.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Substituir correspondências de expressão regular | [TextFrame.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar a correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita as correspondências a palavras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla se a caixa dos caracteres deve coincidir.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclui notas de slide nas operações de pesquisa, substituição e realce em nível de apresentação.

Operações de expressão regular usam um `Pattern` Java, portanto regras como sensibilidade a maiúsculas/minúsculas e limites de palavra são definidas pela própria expressão e por seus sinalizadores.

## **Coletar informações da correspondência com um callback**

Crie um proxy Java para o callback de resultado a fim de receber uma notificação para cada correspondência. A função proxy recebe a caixa de texto relacionada, o texto-fonte, o texto correspondido e a posição da correspondência.

O callback não recebe o número do slide diretamente. A implementação abaixo o obtém por meio de [TextFrame.getSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getSlideNumber--), e [NotesSlide.getParentSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Também trata texto encontrado nas notas de slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Para operações de substituição, `foundText` contém o texto original correspondido, de modo que o callback pode registrar exatamente quais termos foram substituídos.

## **Realçar texto**

Use o método [TextFrame.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para realçar correspondências de texto literal em uma caixa de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/) para controlar a pesquisa.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça apenas a palavra completa **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Realçar cada ocorrência de "try" na caixa de texto.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Realçar apenas a palavra completa "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The highlighted text](highlighted_text.png)

## **Realçar texto usando expressões regulares**

O método [TextFrame.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) realça correspondências encontradas por uma expressão regular em uma caixa de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Realçar texto em toda a apresentação**

Use [Presentation.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) para pesquisar todas as caixas de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de e‑mail:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Substituir texto em uma caixa de texto**

Use [TextFrame.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal e [TextFrame.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro da caixa de texto existente, mantendo a formatação da porção ao redor em vez de reconstruir a caixa de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e, em seguida, substitui rótulos de versão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se uma correspondência abranger porções com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir texto em toda a apresentação**

Use [Presentation.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar correspondências para relatório**

Como cada resultado coletado armazena seu número de slide e caixa de texto, os aplicativos podem agrupar as correspondências para auditoria, geração de relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados primeiro por slide e depois por caixa de texto:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha a caixa de texto da forma e chame [TextFrame.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [TextFrame.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) nessa caixa de texto. Os métodos em nível de apresentação processam todas as caixas de texto aplicáveis.

**Como posso combinar palavras completas com a capitalização correta?**

Defina [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Pattern` Java.

**A pesquisa e substituição podem incluir texto nas notas de slide?**

Sim. Defina [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) como `true` ao usar uma operação literal de nível de apresentação. A implementação do callback mostrada acima mapeia uma correspondência em uma nota de slide de volta ao número do slide pai.

**Como criar um relatório sem analisar a apresentação uma segunda vez?**

Passe um proxy de callback de resultado Java para a operação de realce ou substituição. O callback recebe cada correspondência enquanto a operação é executada, permitindo que o aplicativo armazene o texto-fonte, texto correspondido, posição, caixa de texto e número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[TextFrame.replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [TextFrame.replaceRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificam o texto correspondido dentro da caixa de texto existente e mantêm a formatação da porção ao redor. Se uma correspondência abranger porções com formatações diferentes, inspeccione o resultado para garantir que a substituição use o estilo desejado.