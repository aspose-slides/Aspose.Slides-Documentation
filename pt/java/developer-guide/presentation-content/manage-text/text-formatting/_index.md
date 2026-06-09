---
title: Formatar texto da apresentação em Java
linktitle: Formatação de texto
type: docs
weight: 50
url: /pt/java/text-formatting/
keywords:
- realçar texto
- expressão regular
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência de texto
- espaçamento de caracteres
- propriedades da fonte
- família de fontes
- rotação de texto
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
- Java
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Java. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides for Java. Ele abrange realce, cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento entre parágrafos, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Nos exemplos abaixo, usaremos um arquivo chamado **sample.pptx**, que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Realçar Texto**

Use o método [ITextFrame.highlightText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) quando precisar realçar texto que corresponda a um trecho específico dentro de um quadro de texto. O método aplica uma cor de realce aos fragmentos de texto correspondentes e pode ser usado com [TextSearchOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textsearchoptions/) para controlar como a pesquisa é realizada, por exemplo, para corresponder apenas a palavras inteiras.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e depois realça apenas a palavra completa **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Obtém a primeira forma do primeiro slide.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Realça a palavra "try" na forma.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Realça a palavra "to" na forma.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O texto realçado](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) realça correspondências de texto encontradas por uma expressão regular. Em Java, esta API está exposta em [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/).

O exemplo de código abaixo realça todas as palavras que contêm **sete ou mais caracteres**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Realça todas as palavras com sete ou mais caracteres.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O texto realçado usando a expressão regular](highlighted_text_using_regex.png)

## **Definir Cor de Fundo do Texto**

Use [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) para definir a cor de realce padrão de um parágrafo, ou use [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) para trechos de texto individuais.

O exemplo de código a seguir mostra como definir a cor de fundo para o **parágrafo inteiro**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Define a cor de realce para todo o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **trechos de texto com fonte em negrito**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina a cor de realce para a porção de texto.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As partes de texto cinza](gray_text_portions.png)

## **Alinhar Parágrafos de Texto**

Use [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina o alinhamento do parágrafo para o centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Definir Transparência para o Texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0‑255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina a cor de preenchimento do texto para cor transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **trechos de texto com fonte em negrito**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina a transparência da porção de texto.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As partes de texto transparentes](transparent_text_portions.png)

## **Definir Espaçamento de Caracteres para o Texto**

Use [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto.

O código Java a seguir mostra como expandir o espaçamento de caracteres no **parágrafo inteiro**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Observação: use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Expandir o espaçamento entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento de caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento de caracteres em **trechos de texto com fonte em negrito**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Observação: use valores negativos para comprimir o espaçamento entre caracteres.
            portion.getPortionFormat().setSpacing(3); // Expandir o espaçamento entre caracteres.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento de caracteres nas partes de texto](character_spacing_in_text_portions.png)

### **Desativar Kerning para Fontes Específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais compacto que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar dados de kerning para determinadas fontes, mesmo quando a fonte contém informações válidas de kerning e o kerning está ativado nas configurações do PowerPoint.

Para que a saída renderizada fique mais próxima do PowerPoint nesses casos, você pode desativar o kerning para trechos de texto que utilizam a fonte afetada. Defina [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) com um valor significativamente maior que o tamanho real da fonte:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta configuração impede que o kerning seja aplicado aos trechos de texto correspondentes e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar Propriedades da Fonte do Texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ou em trechos individuais através de [IPortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformat/).

O código a seguir define a fonte e o estilo de texto para o **parágrafo inteiro**: ele aplica tamanho de fonte, negrito, itálico, sublinhado pontilhado e a fonte Times New Roman a todos os trechos do parágrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina as propriedades da fonte para o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As propriedades da fonte para o parágrafo](font_properties_for_paragraph.png)

O exemplo de código abaixo aplica propriedades semelhantes a **trechos de texto com fonte em negrito**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina as propriedades da fonte para a porção de texto.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As propriedades da fonte para as partes de texto](font_properties_for_text_portions.png)

## **Definir Rotação do Texto**

Use [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para `Vertical270`, que rotaciona o texto **90 graus no sentido anti‑horário**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir Rotação Personalizada para Quadros de Texto**

Use [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) para definir um ângulo de rotação personalizado para um [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir Espaçamento entre Linhas dos Parágrafos**

Aspose.Slides fornece [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) para controlar o espaçamento dos parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo de código a seguir mostra como especificar o espaçamento entre linhas dentro do parágrafo:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Definir Tipo de Ajuste Automático para Quadros de Texto**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina como o texto se comporta quando excede os limites de seu contêiner. Use-o para controlar se o texto encolhe, transborda ou redimensiona automaticamente a forma.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Âncora dos Quadros de Texto**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, no meio ou na parte inferior.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Tabulação de Texto**

Use [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getTabs--) para configurar as tabulações em um parágrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir Idioma de Verificação**

Aspose.Slides fornece [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), que permite definir o idioma de verificação para um trecho de texto. O idioma de verificação determina o idioma usado para correções ortográficas e gramaticais no PowerPoint.

O exemplo de código a seguir mostra como definir o idioma de verificação para um trecho de texto:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Defina o Id de um idioma de verificação.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Idioma Padrão**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para definir o idioma padrão para textos criados ao carregar ou criar uma apresentação.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma nova forma retangular com texto.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verifique o idioma da primeira porção.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Definir Estilo de Texto Padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

O exemplo de código a seguir mostra como definir uma fonte padrão em negrito com tamanho 14 pt para todo o texto em todos os slides de uma nova apresentação.

```java
Presentation presentation = new Presentation();
try {
    // Obtenha o formato de parágrafo de nível superior.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrair Texto com o Efeito Tudo em Maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide mesmo que tenha sido digitado originalmente em minúsculas. Quando você recupera esse trecho de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Suponha que temos a seguinte caixa de texto no primeiro slide do arquivo **sample2.pptx**.

![O efeito Tudo em Maiúsculas](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [ITable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itable/). Percorra as células e atualize cada célula através de [ICell.getTextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icell/#getTextFrame--) e a formatação de parágrafos através de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Como aplicar cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor gradiente ao texto, use [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Defina [IFillFormat.setFillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifillformat/#setFillType-byte-) para [FillType.Gradient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) e configure as paradas do gradiente, a direção e a transparência.