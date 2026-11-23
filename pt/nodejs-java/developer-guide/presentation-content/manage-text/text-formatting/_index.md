---
title: Formatar texto de apresentação em JavaScript
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/nodejs-java/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo do texto
- transparência do texto
- espaçamento entre caracteres
- propriedades da fonte
- família da fonte
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
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Ele abrange cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafos, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Salvo indicação em contrário, os exemplos usam [sample.pptx](sample.pptx). A primeira forma no seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slides quanto os de formas são baseados em zero. Exemplos que selecionam trechos em negrito usam formatação efetiva, incluindo formatação de negrito herdada:

![Texto de exemplo](sample_text.png)

Para localizar e realçar texto literal ou correspondências de expressões regulares, veja [Pesquisar e Substituir Texto](/slides/pt/nodejs-java/search-and-replace-text/).

## **Definir Cor de Fundo do Texto**

Use [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para definir a cor de realce padrão de um parágrafo, ou use [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) para trechos de texto individuais.

O exemplo a seguir define um realce cinza‑claro como padrão para o primeiro parágrafo. Cores de realce explícitas em trechos individuais têm precedência sobre esse padrão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina a cor de realce para todo o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **trechos de texto com fonte em negrito**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina a cor de realce para o trecho de texto.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os trechos de texto cinza](gray_text_portions.png)

## **Alinhar Parágrafos de Texto**

Use [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) para definir o alinhamento de parágrafos dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina o alinhamento do parágrafo para o centro.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Alinhar Fontes Dentro de uma Linha**

Use [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) para alinhar verticalmente trechos de texto com tamanhos de fonte diferentes dentro de uma linha. Essa configuração se aplica ao parágrafo inteiro e controla o alinhamento dentro de cada uma de suas linhas.

O exemplo autocontido a seguir cria quatro caixas de texto rotuladas em um único slide. Cada parágrafo contém o mesmo texto em 18, 36 e 54 pontos, com um alinhamento de fonte diferente. Usa Arial, desativa ajuste automático e quebra automática, e mantém os quadros de texto grandes o suficiente para uma única linha.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Comparação de alinhamento de baseline, topo, centro e base com tamanhos de fonte misturados](font_alignment.png)

O alinhamento de fonte usa métricas tipográficas, portanto as bordas visíveis de letras individuais nem sempre se alinham exatamente. O exemplo inclui tanto uma letra maiúscula quanto um descendente para ajudar a mostrar a diferença entre baseline e alinhamento inferior. A disponibilidade e substituição de fontes, os caracteres usados e a diferença nos tamanhos de fonte afetam o resultado. Dimensões da moldura, margens, espaçamento de linhas, quebra automática e ajuste automático também afetam o layout; use as mesmas fontes e configurações de layout ao comparar os modos.

Esta configuração difere de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), que controla o alinhamento horizontal do parágrafo, e de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), que posiciona o bloco de texto verticalmente dentro de sua forma. Formatação de sobrescrito e subscrito via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) desloca trechos individuais em relação à baseline em vez de definir o alinhamento de fonte para as linhas do parágrafo.

## **Definir Transparência para Texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Defina a cor de preenchimento do texto para cor transparente.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **trechos de texto com fonte em negrito**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Defina a transparência do trecho de texto.
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

![Os trechos de texto transparentes](transparent_text_portions.png)

## **Definir Espaçamento entre Caracteres para Texto**

Use [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código JavaScript a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Expanda o espaçamento entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento entre caracteres em **trechos de texto com fonte em negrito**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.getPortionFormat().setSpacing(3); // Expanda o espaçamento entre caracteres.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre caracteres nos trechos de texto](character_spacing_in_text_portions.png)

### **Desativar Kerning para Fontes Específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais compacto que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar dados de kerning para certas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para que a renderização fique mais próxima do PowerPoint nesses casos, você pode desativar o kerning para trechos de texto que utilizam a fonte afetada. Defina [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) para um valor maior que o tamanho real da fonte. Este exemplo requer “presentation.pptx” com uma caixa de texto como a primeira forma no primeiro slide. Ele verifica os nomes de fonte efetivos, incluindo fontes herdadas, e define um limiar de 100 pontos para trechos que usam Roboto. Isso desativa o kerning para trechos correspondentes com tamanho de fonte abaixo de 100 pontos:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para texto correspondido abaixo do limiar, essa configuração impede o kerning e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar Propriedades de Fonte do Texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou em trechos individuais através de [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo como Times New Roman 12 pt com negrito, itálico e sublinhado pontilhado. Formatação explícita em trechos individuais tem precedência sobre esses padrões.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Defina as propriedades de fonte para o parágrafo.
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

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo a seguir aplica Times New Roman 13 pt, itálico e sublinhado pontilhado a trechos cujo formatação efetiva é negrito:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Defina as propriedades de fonte para o trecho de texto.
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

![As propriedades de fonte dos trechos de texto](font_properties_for_text_portions.png)

## **Controlar Normalização da Altura do Texto**

Use [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) ao reproduzir tipografia de modelo ou investigar diferenças na altura de caracteres. No PowerPoint, habilitar a normalização estica ou comprime verticalmente caracteres individuais para dar a eles uma altura visível uniforme dentro do trecho de texto. Não garante alturas de texto iguais entre diferentes fontes.

Defina a propriedade como [NullableBool.True ou False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) para habilitar ou desabilitar explicitamente a normalização. `NullableBool.NotDefined` deixa a configuração local indefinida, de modo que o trecho herda seu valor, por exemplo, do [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) do parágrafo. Não significa `False`. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) e leia [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) para obter o valor booleano resolvido.

O exemplo autocontido a seguir requer **Arial** instalado. Ele cria dois blocos de texto contendo as mesmas letras maiúsculas, minúsculas, descendentes e caracteres acentuados em 54 pt. Ambos os parágrafos habilitam a normalização por padrão. O trecho superior desabilita explicitamente; o inferior a herda. Os tamanhos da moldura, margens e espaçamento de parágrafos são idênticos, com quebra automática e ajuste automático desativados para manter a comparação consistente. O exemplo imprime `False: false` e `NotDefined: true`, então salva “text_height_normalization.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo foi exportada da apresentação salva. A linha superior tem normalização desabilitada (`False`); a inferior herda a configuração habilitada (`NotDefined` → `True`). Mantenha Arial instalado para reproduzir essa aparência.

![Texto Arial 54 pt com normalização desativada acima e normalização herdada ativada abaixo](text_height_normalization.png)

A normalização altera a altura dos caracteres sem mudar o valor atribuído a [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), que especifica o tamanho da fonte em pontos. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) controla o espaçamento entre linhas, enquanto [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) controla como o texto ou seu contêiner se ajusta. Essas configurações servem a propósitos diferentes e podem afetar o layout geral independentemente. Para mais sobre formatação de parágrafos e herança, veja [Gerenciar Parágrafo](/slides/pt/nodejs-java/manage-paragraph/).

## **Aplicar e Remover Tachado**

Use [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) em um trecho de texto para exibir correções, termos cancelados ou preços anteriores sem excluir o texto original. Defina como [TextStrikethroughType.Single ou Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) para uma ou duas linhas através do texto.

Para remover o tachado, passe [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Isso desabilita explicitamente o efeito, mesmo que a formatação ao redor especifique tachado. Em contraste, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) deixa a configuração local indefinida, permitindo que o trecho herde a formatação, por exemplo, do parágrafo. Não garante que o tachado seja removido. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) para ler a formatação resultante, incluindo valores herdados.

O exemplo autocontido a seguir cria três comparações de preço. Cada parágrafo tem trechos separados para o rótulo, preço anterior e preço atual, de modo que apenas o preço anterior é afetado. A primeira linha aplica e depois remove o tachado; as demais mantêm tachado simples e duplo. Alterar essa configuração preserva o texto e sua outra formatação, inclusive o preço anterior em negrito.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Aplicar tachado, então remover explicitamente do primeiro preço anterior.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado, de cima para baixo: sem tachado, tachado simples e tachado duplo.

![Preços anteriores sem tachado, com tachado simples e com tachado duplo](strikethrough.png)

## **Definir Rotação do Texto**

Use [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma como [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), que gira o texto **90 graus no sentido anti‑horário**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Exibir Dígitos Lado a Lado em Texto Vertical**

Para manter um número de dois dígitos junto em um rótulo vertical japonês, coloque ambos os dígitos em um único trecho de texto e chame [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) na formatação desse trecho. O exemplo usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 pt para ambos os rótulos. Apenas o valor [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) passado ao trecho numérico difere.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No PowerPoint, o rótulo da esquerda (`True`) mostra os dígitos na vertical e lado a lado entre 和 e 年. No rótulo da direita (`False`), o par é girado 90 graus no sentido horário. Os caracteres japoneses ao redor permanecem na vertical em ambos os rótulos.

![Comparação no PowerPoint de rótulos de data vertical com dígitos na vertical à esquerda e dígitos girados à direita.](vertical_date.png)

## **Definir Rotação Personalizada para Quadros de Texto**

Use [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

O exemplo de código abaixo gira o quadro de texto em 3  graus no sentido horário dentro da forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir Espaçamento entre Linhas de Parágrafos**

Aspose.Slides fornece [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo a seguir define o espaçamento dentro do primeiro parágrafo como 200 % da altura da linha (espaçamento duplo):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Controlar Quebra de Linha**

Regras de quebra de linha de parágrafo são úteis em blocos de texto estreitos e apresentações que mesclam texto latino e asiático oriental. Os métodos a seguir pertencem a [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), portanto se aplicam a um parágrafo inteiro:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla as regras de quebra de linha para texto latino. Em texto misto, alterá‑la também pode mudar onde o texto e pontuação asiática oriental adjacentes são quebrados.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla as regras de quebra de linha para texto asiático oriental, incluindo restrições de caracteres no início e no fim de uma linha.

Essas regras não substituem [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra automática ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo autocontido a seguir cria um bloco de texto estreito contendo texto chinês e latino. Define explicitamente ambas as opções de quebra de linha e salva “line_breaking.pptx”. Para experimentar cada regra, altere o valor correspondente mantendo as demais configurações fixas. O exemplo usa Arial 24 pt e SimSun com largura de quadro 160 pt e margem horizontal zero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) é chamado com [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar Pontuação Suspensa**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que pontuação elegível se estenda além da borda direita da linha de texto em vez de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de recuo suspenso.

O exemplo autocontido a seguir habilita pontuação suspensa em um quadro de texto de 100 pt de largura e salva “hanging_punctuation.pptx”. Com Arial 24 pt e margens horizontais zero, o ponto final final permanece após “sentença” e se estende além da borda direita do texto. Defina a propriedade como [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto ocupa uma linha separada. A quebra automática está habilitada e o ajuste automático está desabilitado para manter a largura disponível fixa.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nem toda pontuação pode suspender. As [condições de fonte e layout descritas acima](#control-line-breaking) também se aplicam a esta comparação: mudar a fonte, a largura disponível, as margens ou as configurações de ajuste automático pode eliminar a diferença visível.

## **Definir Tipo de Ajuste Automático para Quadros de Texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar e se ajustar ao texto e salva o resultado em “autofit_type.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para contar linhas após quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Contar Linhas Renderizadas](/slides/pt/nodejs-java/manage-paragraph/). A contagem de linhas por si só não indica se o texto transborda seu contêiner.

## **Definir Âncora de Quadros de Texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou base. O exemplo a seguir ancora o texto na base da primeira forma e salva o resultado em “text_anchor.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Tabulação de Texto**

Use [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo padrão de tabulação para 100 pt e adiciona uma parada de tabulação alinhada à esquerda em 30 pt. Essas configurações afetam texto que contém caracteres de tabulação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

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

Aspose.Slides fornece [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), que permite definir o idioma de revisão para um trecho de texto. O idioma de revisão determina o idioma usado para verificações ortográficas e gramaticais no PowerPoint.

O exemplo a seguir requer “presentation.pptx” com uma caixa de texto como a primeira forma no primeiro slide e ao menos um parágrafo. Ele substitui o conteúdo do primeiro parágrafo por “1。”, define SimSun como sua fonte e atribui o idioma de revisão Chinês Simplificado (`zh-CN`). Salva o resultado em “proofing_language.pptx”:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Defina o Id de um idioma de revisão.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copiar Metadados de Idioma**

Ao copiar texto multilíngue de um modelo, preserve tanto [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) quanto [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). O exemplo autocontido a seguir cria um trecho fonte com inglês dos EUA como idioma e francês como idioma alternativo e copia o texto e os identificadores para um trecho em uma nova apresentação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Se a fonte não tiver idioma alternativo, null limpa o valor de destino.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para testar uma fonte sem idioma alternativo, omita a atribuição de `"fr-FR"`. O identificador alternativo será então `null`, e a mesma instrução de cópia preserva sua ausência sem introduzir um valor padrão, mesmo que o destino anteriormente tivesse um idioma alternativo atribuído.

Esses identificadores armazenam metadados de idioma. Preservá‑los não define qual dicionário o PowerPoint seleciona para verificações ortográficas ou gramaticais.

## **Definir Idioma Padrão**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma padrão de texto, adiciona uma caixa de texto e imprime `en-US` para seu primeiro trecho de texto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Adicione uma nova forma retangular com texto.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verifique o idioma da primeira porção.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Definir Estilo de Texto Padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

O exemplo a seguir define uma fonte negrito de 14 pt como padrão para parágrafos de nível superior em uma nova apresentação e a salva como “default_text_style.pptx”. O texto pode herdar esses padrões, a menos que formatações mais específicas os sobrescrevam.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Obtenha o formato de parágrafo de nível superior.
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

## **Extrair Texto com o Efeito Todas as Maiúsculas**

No PowerPoint, aplicar o efeito de fonte **Todas as Maiúsculas** faz o texto aparecer em caixa alta no slide mesmo quando foi originalmente digitado em caixa baixa. Quando você recupera tal trecho de texto com Aspose.Slides, a biblioteca retorna o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) e converta a string retornada para caixa alta quando o valor for `All`.

Este exemplo requer “sample2.pptx” com uma caixa de texto como a primeira forma no primeiro slide. Seu primeiro parágrafo tem como primeiro trecho “Hello, Aspose!” com o efeito Todas as Maiúsculas aplicado, como mostrado abaixo.

![O efeito Todas as Maiúsculas](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **Todas as Maiúsculas** aplicado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
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

## **FAQ**

**Como modifico texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Percorra as células e atualize cada célula através de [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) e formatação de parágrafo através de [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Como aplico uma cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor gradiente ao texto, use [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Defina [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) como [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) e configure as paradas de gradiente, direção e transparência.