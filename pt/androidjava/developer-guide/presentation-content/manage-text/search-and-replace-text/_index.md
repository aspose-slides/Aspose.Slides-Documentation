---
title: Pesquisa e substituição de texto em apresentações PowerPoint no Android
linktitle: Pesquisar e substituir texto
type: docs
weight: 55
url: /pt/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Pesquise, realce e substitua texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java pode pesquisar, realçar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um retorno de chamada de resultado. Isso possibilita atualizar uma apresentação e simultaneamente construir um trilho de auditoria contendo o texto correspondido, seu contexto, posição, quadro de texto e número do slide.

Essas funcionalidades são úteis para revisão, redação, verificações de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado **"sample.pptx"**, que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Sample text](sample_text.png)

## **Escolha o escopo da pesquisa**

Use métodos em [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) para limitar uma operação a um quadro de texto. Use métodos em [IPresentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Realçar correspondências de expressão regular | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Substituir texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Substituir correspondências de expressão regular | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar a correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita as correspondências a palavras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla se a diferenciação entre maiúsculas e minúsculas é exigida.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclui notas de slide nas operações de pesquisa, substituição e realce em nível de apresentação.

Operações de expressão regular utilizam um `Pattern` Java, portanto as regras de correspondência, como sensibilidade a maiúsculas/minúsculas e limites de palavra, são definidas pela própria expressão e seus sinalizadores.

## **Coletar informações de correspondência com um retorno de chamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifindresultcallback/) para receber uma notificação para cada correspondência. Seu método [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fornece o quadro de texto relacionado, o texto de origem, o texto correspondido e a posição da correspondência.

O retorno de chamada não recebe o número do slide diretamente. A implementação abaixo o obtém a partir do slide pai e também trata texto encontrado em notas de slide. Um `Integer` anulável permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

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

Use o método [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para realçar correspondências de texto literal em um quadro de texto. Passe um [TextSearchOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/) para controlar a pesquisa e um retorno de chamada para coletar detalhes da correspondência.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça somente a palavra completa **"to"**. Ambas as pesquisas enviam suas correspondências ao mesmo retorno de chamada.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Realçar cada ocorrência de "try" no quadro de texto.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

O método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) realça correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres e coleta cada correspondência:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

Use [IPresentation.highlightText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [IPresentation.highlightRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de e‑mail, mantendo coleções de resultados separadas para as duas pesquisas.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

Use [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, preservando a formatação das partes ao redor em vez de reconstruir o quadro a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e, em seguida, substitui rótulos de versão. O mesmo retorno de chamada registra os termos originais correspondidos por ambas as operações.

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

Se uma correspondência abranger trechos com formatação diferente, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir texto em toda a apresentação**

Use [IPresentation.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [IPresentation.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

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

## **Agrupar correspondências para relatório**

Como cada resultado armazena seu número de slide e quadro de texto, as aplicações podem agrupar as correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

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

## **Perguntas frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ou [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) naquele quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso combinar palavras completas com a capitalização correta?**

Defina [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Pattern` Java.

**A pesquisa e substituição podem incluir texto nas notas de slide?**

Sim. Defina [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) como `true` ao usar uma operação de texto literal em nível de apresentação. A implementação do retorno de chamada mostrada acima mapeia uma correspondência em um slide de notas de volta ao número do slide pai.

**Como posso criar um relatório sem analisar a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifindresultcallback/) para a operação de realce ou substituição. O retorno de chamada recebe cada correspondência enquanto a operação é executada, permitindo que o aplicativo armazene o texto de origem, texto correspondido, posição, quadro de texto e número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação das partes ao redor. Se uma correspondência abranger trechos com formatação diferente, inspecione o resultado para garantir que a substituição use o estilo desejado.