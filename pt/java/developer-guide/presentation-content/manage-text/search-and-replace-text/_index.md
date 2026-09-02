---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em Java
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/java/search-and-replace-text/
keywords:
- pesquisar texto
- destacar texto
- substituir texto
- expressão regular
- callback de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Pesquise, destaque e substitua texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides for Java."
---
## **Visão geral**

Aspose.Slides for Java pode pesquisar, destacar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um retorno de chamada de resultado. Isso possibilita atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondente, seu contexto, posição, quadro de texto e número do slide.

Esses recursos são úteis para revisão, censura, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Escolher o escopo da pesquisa**

Use métodos em [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) para limitar uma operação a um quadro de texto. Use métodos em [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Destacar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Destacar correspondências de expressão regular | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Substituir texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Substituir correspondências de expressão regular | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita as correspondências a palavras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla se a diferenciação entre maiúsculas e minúsculas deve ser considerada.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclui notas de slide nas operações de pesquisa, substituição e destaque em nível de apresentação.

Operações de expressão regular usam um `Pattern` Java, portanto as regras de correspondência, como sensibilidade a maiúsculas/minúsculas e limites de palavra, são definidas pela expressão e seus indicadores.

## **Identificar o proprietário de um quadro de texto**

Fluxos de trabalho genéricos de processamento de texto frequentemente recebem um [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) ao pesquisar, substituir, validar ou exportar texto. Use [ITextFrame.getParentShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#getParentShape--) e [ITextFrame.getParentCell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#getParentCell--) para determinar qual objeto da apresentação possui o quadro de texto.

Os valores esperados dependem do proprietário:

| Proprietário do quadro de texto | `getParentShape` | `getParentCell` |
|---|---|---|
| Um AutoShape ou outra forma que contenha texto | O [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) proprietário | `null` |
| Uma célula de tabela | `null` | O [ICell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icell/) proprietário |

Ambos os métodos fornecem navegação somente leitura. Chamá‑los não move o quadro de texto nem altera seu proprietário. O código genérico deve verificar ambos os valores quanto a `null` e tratar a possibilidade de que nenhum proprietário esteja disponível.

O exemplo a seguir usa [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) para percorrer os quadros de texto de uma apresentação. Para formas, ele relata o nome da forma, o tipo de runtime Java e o slide contendo. Para células de tabela, ele relata as coordenadas de coluna e linha baseadas em zero e o slide contendo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Para conteúdo SmartArt, percorra as formas em [ISmartArtNode.getShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartartnode/#getShapes--) e acesse cada [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartartshape/#getTextFrame--). O quadro de texto pode ser rastreado até sua forma associada por meio de [ITextFrame.getParentShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#getParentShape--), enquanto [ITextFrame.getParentCell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#getParentCell--) retorna `null`. Portanto, o ramo de forma no exemplo também trata texto de nós SmartArt.

## **Coletar informações de correspondência com um callback**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/) para receber uma notificação para cada correspondência. Seu método [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fornece o quadro de texto relacionado, o texto‑fonte, o texto correspondido e a posição da correspondência.

O callback não recebe diretamente um número de slide. A implementação abaixo o obtém a partir do slide pai e também trata texto encontrado em notas de slide. Um `Integer` anulável permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

Para operações de substituição, `foundText` contém o texto original correspondido, de modo que o callback pode registrar exatamente quais termos foram substituídos.

## **Destacar texto**

Use o método [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para destacar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions] para controlar a pesquisa e um callback para coletar os detalhes das correspondências.

O exemplo de código abaixo destaca todas as ocorrências dos caracteres **"try"** e depois destaca apenas a palavra completa **"to"**. Ambas as pesquisas relatam suas correspondências ao mesmo callback.

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

    // Destacar cada ocorrência de "try" no quadro de texto.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Destacar apenas a palavra completa "to".
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

![O texto destacado](highlighted_text.png)

## **Destacar texto usando expressões regulares**

O método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) destaca as correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir destaca todas as palavras que contêm sete ou mais caracteres e coleta cada correspondência:

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

![O texto destacado usando a expressão regular](highlighted_text_using_regex.png)

## **Destacar texto em toda a apresentação**

Use [Presentation.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir destaca um termo literal e todos os endereços de e‑mail, mantendo coleções de resultados separadas para as duas pesquisas.

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

Use [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, preservando a formatação da porção ao redor em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e depois substitui rótulos de versão. O mesmo callback registra os termos originais correspondidos por ambas as operações.

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

Se uma correspondência abranger trechos com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir texto em toda a apresentação**

Use [Presentation.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualização de terminologia e censura.

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

Como cada resultado armazena seu número de slide e quadro de texto, as aplicações podem agrupar correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

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

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) como `true`, e passe as opções para um método de destaque ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Pattern` do Java.

**A pesquisa e substituição podem incluir texto nas notas do slide?**

Sim. Defina [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) como `true` ao usar uma operação de texto literal em nível de apresentação. A implementação de callback mostrada acima mapeia uma correspondência em um slide de notas de volta ao número do slide pai.

**Como posso criar um relatório sem escanear a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifindresultcallback/) para a operação de destaque ou substituição. O callback recebe cada correspondência enquanto a operação executa, permitindo que o aplicativo armazene o texto fonte, texto correspondido, posição, quadro de texto e número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva a formatação?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificam o texto correspondido dentro do quadro de texto existente e retêm a formatação da porção circundante. Se uma correspondência abranger trechos com formatações diferentes, inspecione o resultado para garantir que a substituição use o estilo desejado.