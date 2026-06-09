---
title: Formatar texto da apresentação em JavaScript
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/nodejs-java/text-formatting/
keywords:
- destacar texto
- expressão regular
- alinhar parágrafo
- estilo de texto
- fundo do texto
- transparência do texto
- espaçamento de caracteres
- propriedades de fonte
- família de fonte
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatar e estilizar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo demonstra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Ele abrange realce, cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Nos exemplos abaixo, usaremos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Realçar Texto**

Use o método [TextFrame.highlightText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) quando precisar realçar texto que corresponda a um exemplo específico dentro de um quadro de texto. O método aplica uma cor de realce aos fragmentos de texto correspondentes e pode ser usado com [TextSearchOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textsearchoptions/) para controlar como a pesquisa é realizada, por exemplo, para corresponder apenas a palavras inteiras.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça apenas a palavra completa **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Realçar a palavra "try" na forma.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Realçar a palavra "to" na forma.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O texto realçado](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [TextFrame.highlightRegex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) realça as correspondências de texto encontradas por uma expressão regular. No Node.js via Java, essa API è exposta em [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).

O exemplo de código abaixo realça todas as palavras que contêm **sete ou mais caracteres**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Realçar todas as palavras com sete ou mais caracteres.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Texto realçado usando a expressão regular](highlighted_text_using_regex.png)

## **Definir Cor de Fundo do Texto**

Use [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) para definir a cor de realce padrão para um parágrafo, ou use [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) para porções de texto individuais.

O exemplo de código a seguir mostra como definir a cor de fundo para o **parágrafo inteiro**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Definir a cor de realce para o parágrafo inteiro.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **porções de texto com fonte em negrito**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Definir a cor de realce para a porção de texto.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As porções de texto cinzas](gray_text_portions.png)

## **Alinhar Parágrafos de Texto**

Use [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, alinhado à direita, justificado, etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Definir o alinhamento do parágrafo para o centro.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Definir Transparência para Texto**

A transparência do texto é controlada pelo componente alfa da cor atribuída a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0-255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Definir a cor de preenchimento do texto para cor transparente.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **porções de texto com fonte em negrito**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Definir a transparência da porção de texto.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir Espaçamento de Caracteres para Texto**

Use [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto.

O código JavaScript a seguir mostra como expandir o espaçamento de caracteres no **parágrafo inteiro**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Expandir o espaçamento de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento de caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento de caracteres em **porções de texto com fonte em negrito**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.getPortionFormat().setSpacing(3); // Expandir o espaçamento de caracteres.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento de caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desativar Kerning para Fontes Específicas**

Em alguns casos, o texto renderizado pelo Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para determinadas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para que a saída renderizada fique mais próxima do PowerPoint nesses casos, você pode desativar o kerning para as porções de texto que usam a fonte afetada. Defina [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) para um valor significativamente maior que o tamanho real da fonte:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta configuração impede que o kerning seja aplicado às porções de texto correspondentes e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar Propriedades de Fonte do Texto**

As propriedades de fonte podem ser definidas ao nível do parágrafo através de [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) ou em porções individuais através de [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/).

O código a seguir define a fonte e o estilo de texto para o parágrafo inteiro: ele aplica tamanho de fonte, negrito, itálico, sublinhado pontilhado e a fonte Times New Roman a todas as porções do parágrafo.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Definir as propriedades da fonte para o parágrafo.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As propriedades de fonte para o parágrafo](font_properties_for_paragraph.png)

O exemplo de código abaixo aplica propriedades semelhantes a **porções de texto com fonte em negrito**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Definir as propriedades da fonte para a porção de texto.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As propriedades de fonte para as porções de texto](font_properties_for_text_portions.png)

## **Definir Rotação do Texto**

Use [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma como `Vertical270`, que gira o texto **90 graus no sentido anti-horário**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir Rotação Personalizada para Quadros de Texto**

Use [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação de texto personalizada](custom_text_rotation.png)

## **Definir Espaçamento entre Linhas de Parágrafos**

O Aspose.Slides oferece [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como uma porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo de código a seguir mostra como especificar o espaçamento entre linhas dentro do parágrafo:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Definir Tipo de Ajuste Automático para Quadros de Texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) determina como o texto se comporta quando excede os limites de seu contêiner. Use-o para controlar se o texto diminui, transborda ou redimensiona a forma automaticamente.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Âncora de Quadros de Texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo no topo, meio ou base.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Tabulação de Texto**

Use [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#getTabs--) para configurar as tabulações em um parágrafo.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir Idioma de Revisão**

O Aspose.Slides fornece [PortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado para verificação ortográfica e gramatical no PowerPoint.

O exemplo de código a seguir mostra como definir o idioma de revisão para uma porção de texto:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Definir o Id de um idioma de revisão.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Idioma Padrão**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Adicionar uma nova forma retangular com texto.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verificar o idioma da primeira porção.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Definir Estilo de Texto Padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

O exemplo de código a seguir mostra como definir uma fonte padrão em negrito com tamanho de 14 pt para todo o texto em todas as slides em uma nova apresentação.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Obter o formato de parágrafo de nível superior.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrair Texto com o Efeito Todas as Letras Maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** (todas as letras maiúsculas) faz com que o texto apareça em maiúsculas no slide mesmo que originalmente tenha sido digitado em minúsculas. Quando você recupera tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Suponha que tenhamos a seguinte caixa de texto no primeiro slide do arquivo sample2.pptx.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
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

## **Perguntas Frequentes**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/). Iterate through the cells and update each cell through [Cell.getTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/#getTextFrame--) and paragraph formatting through [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Como aplicar cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor gradiente ao texto, use [PortionFormat.getFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Set [FillFormat.setFillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) to [FillType.Gradient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) and configure the gradient stops, direction, and transparency.