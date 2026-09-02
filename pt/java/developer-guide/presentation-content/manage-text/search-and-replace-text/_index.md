---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em Java
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/java/search-and-replace-text/
keywords:
- pesquisar texto
- realçar texto
- substituir texto
- expressão regular
- retorno de chamada de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Pesquise, realce e substitua texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides para Java."
---
## **Visão geral**

Aspose.Slides for Java pode buscar, realçar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um retorno de chamada de resultado. Isso torna possível atualizar uma apresentação e simultaneamente gerar um registro de auditoria contendo o texto correspondido, seu contexto, posição, quadro de texto e número do slide.

Essas funcionalidades são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Sample text](sample_text.png)

## **Escolher o escopo da pesquisa**

Use os métodos em [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) para limitar uma operação a um quadro de texto. Use os métodos em [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Realçar correspondências de expressão regular | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Substituir texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Substituir correspondências de expressão regular | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita as correspondências a palavras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla se a distinção entre maiúsculas e minúsculas deve ser observada.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclui as notas dos slides nas operações de busca, substituição e realce em nível de apresentação.

As operações de expressão regular usam um `Pattern` Java, portanto regras de correspondência como distinção entre maiúsculas/minúsculas e limites de palavra são definidas pela expressão e seus sinalizadores.

## **Coletar informações de correspondência com um retorno de chamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/) para receber uma notificação a cada correspondência. Seu método [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fornece o quadro de texto relacionado, o texto de origem, o texto correspondido e a posição da correspondência.

O retorno de chamada não recebe diretamente o número do slide. A implementação abaixo o obtém a partir do slide pai e também trata texto encontrado nas notas do slide. Um `Integer` anulável permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Para operações de substituição, `foundText` contém o texto original correspondido, de modo que o retorno de chamada pode registrar exatamente quais termos foram substituídos.

## **Realçar texto**

Use o método [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para realçar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/) para controlar a busca e um retorno de chamada para coletar os detalhes da correspondência.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça apenas a palavra completa **"to"**. Ambas as buscas enviam suas correspondências ao mesmo retorno de chamada.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Realçar cada ocorrência de "try" no quadro de texto.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Realçar somente a palavra completa "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The highlighted text](highlighted_text.png)

## **Realçar texto usando expressões regulares**

O método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) realça correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres e coleta cada correspondência:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Realçar texto em toda a apresentação**

Use [Presentation.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) para buscar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de e‑mail, mantendo coleções de resultados separadas para as duas buscas.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Substituir texto em um quadro de texto**

Use [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, que mantém a formatação da parte circundante em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e depois substitui rótulos de versão. O mesmo retorno de chamada registra os termos originais correspondidos por ambas as operações.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se uma correspondência abrange partes com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir texto em toda a apresentação**

Use [Presentation.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar correspondências para relatórios**

Como cada resultado armazena seu número de slide e quadro de texto, os aplicativos podem agrupar as correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**Como posso buscar apenas em uma caixa de texto em vez de em toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e diferenciação entre maiúsculas/minúsculas no próprio `Pattern` Java.

**A busca e substituição podem incluir texto nas notas dos slides?**

Sim. Defina [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) como `true` ao usar uma operação de texto literal em nível de apresentação. A implementação do retorno de chamada mostrada acima mapeia uma correspondência em um slide de notas de volta ao número do slide pai.

**Como criar um relatório sem analisar a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/) para a operação de realce ou substituição. O retorno de chamada recebe cada correspondência enquanto a operação executa, de modo que o aplicativo pode armazenar o texto de origem, o texto correspondido, a posição, o quadro de texto e o número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação da parte circundante. Se uma correspondência abrange partes com formatações diferentes, inspecione o resultado para garantir que a substituição use o estilo desejado.