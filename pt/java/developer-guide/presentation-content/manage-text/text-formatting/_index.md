---
title: Formatar texto de apresentação em Java
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/java/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo do texto
- transparência do texto
- espaçamento entre caracteres
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
- Java
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Java. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Java. Ele aborda cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento entre parágrafos, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Exceto quando indicado de outra forma, os exemplos usam [sample.pptx](sample.pptx). O primeiro formato no seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slide quanto de forma são baseados em zero. Exemplos que selecionam trechos em negrito usam formatação efetiva, incluindo formatação negrito herdada:

![Texto de exemplo](sample_text.png)

Para encontrar e realçar texto literal ou correspondências de expressão regular, veja [Pesquisar e Substituir Texto](/slides/pt/java/search-and-replace-text/).

## **Definir cor de fundo do texto**

Use [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) para definir a cor de destaque padrão para um parágrafo, ou use [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) para porções de texto individuais.

O exemplo a seguir define um destaque cinza claro como padrão para o primeiro parágrafo. Cores de destaque explícitas em porções individuais têm precedência sobre esse padrão:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina a cor de destaque para todo o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **porções de texto com fonte em negrito**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina a cor de destaque para a porção de texto.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As porções de texto cinza](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) para definir o alinhamento de parágrafos dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **Alinhar fontes dentro de uma linha**

Use [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) para alinhar verticalmente porções de texto de diferentes tamanhos de fonte dentro de uma linha. Essa configuração se aplica a todo o parágrafo e controla o alinhamento dentro de cada uma de suas linhas.

O exemplo autocontido a seguir cria quatro caixas de texto rotuladas em um slide. Cada parágrafo contém o mesmo texto com 18, 36 e 54 pontos, com um alinhamento de fonte diferente. Ele usa Arial, desabilita ajuste automático e quebra de linha, e mantém os quadros de texto grandes o suficiente para uma única linha.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Comparação de alinhamento Baseline, Top, Center e Bottom com tamanhos de fonte misturados](font_alignment.png)

O alinhamento de fonte usa métricas de fonte, portanto as bordas visíveis das letras individuais nem sempre se alinham exatamente. O exemplo inclui uma letra maiúscula e um descendente para mostrar a diferença entre alinhamento de linha de base e inferior. Disponibilidade e substituição de fontes, os caracteres usados e a diferença nos tamanhos de fonte afetam o resultado. Dimensões do quadro, margens, espaçamento entre linhas, quebra de linha e ajuste automático também influenciam o layout; use as mesmas fontes e configurações de layout ao comparar os modos.

Esta configuração difere de [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), que controla o alinhamento horizontal do parágrafo, e de [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), que posiciona o bloco de texto verticalmente dentro de sua forma. Formatação de sobrescrito e subscrito através de [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) desloca porções individuais em relação à linha de base ao invés de definir o alinhamento de fonte para as linhas do parágrafo.

## **Definir transparência para o texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina a cor de preenchimento do texto como cor transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O código a seguir mostra como aplicar transparência a **porções de texto com fonte em negrito**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento entre caracteres para o texto**

Use [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código Java a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Expandir espaçamento entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento entre caracteres em **porções de texto com fonte em negrito**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.getPortionFormat().setSpacing(3); // Expandir o espaçamento entre caracteres.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desativar kerning para fontes específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para determinadas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para que a saída renderizada fique mais próxima do PowerPoint nesses casos, você pode desativar o kerning para as porções de texto que usam a fonte afetada. Defina [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) para um valor maior que o tamanho real da fonte. Este exemplo requer "presentation.pptx" com uma caixa de texto como primeira forma no primeiro slide. Ele verifica os nomes de fonte efetivos, incluindo fontes herdadas, e define um limite de 100 pontos para porções que usam Roboto. Isso desativa o kerning para as porções correspondentes com tamanho de fonte inferior a 100 pontos:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para texto correspondente abaixo do limite, essa configuração impede o kerning e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ou em porções individuais através de [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo como Times New Roman 12 pontos com negrito, itálico e sublinhado pontilhado. Formatação explícita em porções individuais tem precedência sobre esses padrões.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Defina as propriedades de fonte para o parágrafo.
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

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo a seguir aplica Times New Roman 13 pontos, formatação itálica e sublinhado pontilhado às porções cujo formato efetivo é negrito:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Defina as propriedades de fonte para a porção de texto.
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

![As propriedades de fonte das porções de texto](font_properties_for_text_portions.png)

## **Controlar a normalização da altura do texto**

Use [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) ao reproduzir tipografia de modelo ou investigar diferenças na altura dos caracteres. No PowerPoint, habilitar a normalização estica ou comprime caracteres individuais verticalmente para dar a eles uma altura visível uniforme dentro da porção de texto. Isso não garante alturas de texto iguais entre diferentes fontes.

Defina a propriedade como [NullableBool.True ou False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) para habilitar ou desabilitar explicitamente a normalização. `NullableBool.NotDefined` deixa a configuração local indefinida, de modo que a porção herde seu valor, por exemplo, do [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) do parágrafo. Não significa `False`. Use [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) e leia [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) para obter o valor Boolean resolvido.

O exemplo autocontido a seguir requer **Arial** instalado. Ele cria dois blocos de texto contendo as mesmas letras maiúsculas, minúsculas, descendentes e caracteres acentuados com 54 pontos. Ambos os parágrafos habilitam a normalização por padrão. A porção superior desabilita explicitamente; a inferior herda. Os tamanhos dos quadros, margens e espaçamento entre parágrafos são idênticos, com quebra de linha e ajuste automático desativados para manter a comparação consistente. O exemplo grava `False: false` e `NotDefined: true`, depois salva "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo foi exportada da apresentação salva. A linha superior tem normalização desativada (`False`); a linha inferior herda a configuração habilitada (`NotDefined` → `True`). Mantenha Arial instalado para reproduzir esta aparência.

![Texto Arial 54 pontos com normalização desativada acima e normalização herdada ativada abaixo](text_height_normalization.png)

A normalização altera a altura dos caracteres sem mudar o valor atribuído a [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--), que especifica o tamanho da fonte em pontos. O método [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) do parágrafo controla o espaçamento entre linhas, enquanto [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) do quadro de texto controla como o texto ou seu contêiner se ajusta. Essas configurações servem a propósitos diferentes e podem afetar o layout geral independentemente. Para mais informações sobre formatação de parágrafos e herança, veja [Gerenciar Parágrafo](/slides/pt/java/manage-paragraph/).

## **Aplicar e remover tachado**

Use [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) em uma porção de texto para exibir correções, termos cancelados ou preços anteriores sem excluir o texto original. Defina como [TextStrikethroughType.Single ou Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) para uma ou duas linhas através do texto.

Para remover o tachado, passe [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Isso desabilita explicitamente o efeito, mesmo que a formatação circundante especifique tachado. Em contraste, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) deixa a configuração local indefinida, permitindo que a porção herde a formatação, por exemplo, do parágrafo. Não garante que o tachado seja removido. Use [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) para ler a formatação resultante, incluindo valores herdados.

O exemplo autocontido a seguir cria três comparações de preços. Cada parágrafo tem porções separadas para o rótulo, preço anterior e preço atual, de modo que apenas o preço anterior é afetado. A primeira linha aplica e depois remove o tachado; as demais linhas mantêm tachado simples e duplo. Alterar essa configuração preserva o texto e sua outra formatação, incluindo o preço anterior em negrito.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Aplicar tachado, depois remover explicitamente do primeiro preço anterior.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado, de cima para baixo: sem tachado, tachado simples e tachado duplo.

![Preços anteriores sem tachado, com tachado simples e com tachado duplo](strikethrough.png)

## **Definir rotação do texto**

Use [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), que gira o texto **90 graus no sentido anti-horário**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Exibir dígitos lado a lado em texto vertical**

Para manter um número de dois dígitos junto em um rótulo japonês vertical, coloque ambos os dígitos em uma única porção de texto e chame [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) nessa porção. O exemplo usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 pontos para ambos os rótulos. Apenas o valor [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) passado para a porção numérica difere.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No PowerPoint, o rótulo esquerdo (`True`) mostra os dígitos em pé e lado a lado entre 和 e 年. No rótulo direito (`False`), o par está girado 90 graus no sentido horário. Os caracteres japoneses ao redor permanecem em pé em ambos os rótulos.

![Comparação no PowerPoint de rótulos de data vertical com dígitos em pé à esquerda e dígitos girados à direita.](vertical_date.png)

## **Definir rotação personalizada para quadros de texto**

Use [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) para definir um ângulo de rotação personalizado para um [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir espaçamento entre linhas de parágrafos**

Aspose.Slides fornece [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) para controlar o espaçamento entre parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como uma porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo a seguir define o espaçamento interno do primeiro parágrafo para 200 % da altura da linha (espaçamento duplo):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Controlar quebra de linha**

As regras de quebra de linha de parágrafo são úteis em blocos de texto estreitos e apresentações que mesclam texto latino e asiático oriental. Os métodos a seguir pertencem a [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), portanto aplicam‑se a um parágrafo inteiro:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) controla as regras de quebra de linha latinas. Em texto misto, alterá‑las também pode mudar onde o texto e pontuação asiáticos orientais adjacentes são enrolados.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) controla as regras de quebra de linha asiáticas orientais, incluindo restrições de caracteres no início e fim de uma linha.

Essas regras não substituem [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo autocontido a seguir cria um bloco de texto estreito contendo texto chinês e latino. Define ambas as opções de quebra de linha explicitamente e salva "line_breaking.pptx". Para experimentar cada regra, altere o valor correspondente mantendo as outras configurações fixas. O exemplo usa Arial 24 pt e SimSun com largura de quadro de 160 pt e margens horizontais do quadro de texto iguais a zero. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) é chamado com [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar pontuação pendente**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) permite que pontuação elegível se estenda além da borda direita da linha de texto ao invés de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de um recuo suspenso.

O exemplo autocontido a seguir habilita pontuação pendente em um quadro de texto com largura de 100 pt e salva "hanging_punctuation.pptx". Com Arial 24 pt e margens horizontais do quadro de texto iguais a zero, o ponto final final permanece após "sentence" e se estende além da borda direita do texto. Defina a propriedade como [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto ocupa uma linha separada. A quebra de linha está habilitada e o ajuste automático desativado para manter a largura disponível fixa.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nem toda pontuação pode pendurar. As [condições de fonte e layout descritas acima](#control-line-breaking) também se aplicam a esta comparação: mudar a fonte, largura disponível, margens ou configurações de ajuste automático pode remover a diferença visível.

## **Definir tipo de ajuste automático para quadros de texto**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar e ajustar ao texto e salva o resultado em "autofit_type.pptx".

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para contar linhas após a quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Contar Linhas Renderizadas](/slides/pt/java/manage-paragraph/). Apenas a contagem de linhas não indica se o texto transborda seu contêiner.

## **Definir ancoragem de quadros de texto**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou base. O exemplo a seguir ancora o texto na base da primeira forma e salva o resultado em "text_anchor.pptx".

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir tabulação de texto**

Use [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo padrão de tabulação para 100 pontos e adiciona uma tabulação à esquerda em 30 pontos. Essas configurações afetam texto contendo caracteres de tabulação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
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

## **Definir idioma de revisão**

Aspose.Slides fornece [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado nas verificações ortográficas e gramaticais no PowerPoint.

O exemplo a seguir requer "presentation.pptx" com uma caixa de texto como primeira forma no primeiro slide e ao menos um parágrafo. Ele substitui o conteúdo do primeiro parágrafo por "1。", define SimSun como sua fonte e atribui o idioma de revisão Chinês Simplificado (`zh-CN`). Salva o resultado em "proofing_language.pptx":

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Defina o Id de um idioma de revisão.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copiar metadados de idioma**

Ao copiar texto multilíngue de um modelo, preserve tanto [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) quanto [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). O exemplo autocontido a seguir cria uma porção fonte com inglês dos EUA como idioma e francês como idioma alternativo e copia o texto e os identificadores para uma porção em uma nova apresentação.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Se a origem não tiver idioma alternativo, null limpa o valor de destino.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para experimentar uma fonte sem idioma alternativo, omita a atribuição de `"fr-FR"`. O identificador alternativo então será `null`, e a mesma instrução de cópia preserva sua ausência sem introduzir um valor padrão, mesmo que o destino já tivesse um idioma alternativo atribuído.

Esses identificadores armazenam metadados de idioma. Preservá‑los não determina qual dicionário o PowerPoint seleciona para verificações ortográficas ou gramaticais.

## **Definir idioma padrão**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma padrão de texto, adiciona uma caixa de texto e imprime `en-US` para sua primeira porção de texto.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma nova forma retangular com texto.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verificar o idioma da primeira porção.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

O exemplo a seguir define uma fonte de 14 pontos em negrito como padrão para parágrafos de nível superior em uma nova apresentação e a salva em "default_text_style.pptx". O texto pode herdar esses padrões, a menos que formatação mais específica os sobrescreva.

```java
import com.aspose.slides.*;

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

## **Extrair texto com o efeito de caixa alta**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide mesmo quando foi originalmente digitado em minúsculas. Quando você recupera tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Este exemplo requer "sample2.pptx" com uma caixa de texto como primeira forma no primeiro slide. Seu primeiro parágrafo tem como primeira porção "Hello, Aspose!" com o efeito All Caps aplicado, como mostrado abaixo.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

**Como modifico o texto em uma tabela em um slide?**

Para modificar o texto em uma tabela em um slide, use [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Itere pelas células e atualize cada célula através de [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) e a formatação de parágrafo através de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Como aplico uma cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor gradiente ao texto, use [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Defina [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) como [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) e configure as paradas de gradiente, direção e transparência.

Recurso relacionado: [Formatar texto dentro de slides](/slides/pt/features/text-formatting/).