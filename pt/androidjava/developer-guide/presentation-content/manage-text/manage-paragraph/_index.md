---
title: Gerenciar parágrafos de texto do PowerPoint no Android
linktitle: Gerenciar parágrafo
type: docs
weight: 40
url: /pt/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Saiba como criar e formatar parágrafos, porções, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafos com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java representa o texto como uma hierarquia de quadros de texto, parágrafos e porções:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) representa um parágrafo em um quadro de texto e fornece acesso às suas porções e à formatação ao nível do parágrafo.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) representa uma sequência de texto dentro de um parágrafo. Cada porção pode ter seu próprio texto e formatação ao nível de caractere.

Um parágrafo, portanto, pode conter texto com diferentes fontes, cores, tamanhos e outras formatações usando várias porções.

## **Criar e formatar parágrafos**

Crie parágrafos no quadro de texto de uma forma e use porções para formatar execuções individuais de texto. Esta seção mostra como combinar múltiplas porções dentro de cada parágrafo e aplicar cores, tamanhos de fonte e estilos diferentes.

### **Criar parágrafos com várias porções**

O exemplo a seguir para Android via Java cria três parágrafos, cada um contendo três execuções de texto na coleção retornada por [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). Ele reutiliza o parágrafo padrão e sua porção vazia, depois adiciona os parágrafos e porções restantes. A formatação é aplicada através de [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): a primeira porção em cada parágrafo é vermelha, negrito e 15 pontos; a segunda é azul, itálico e 18 pontos. A terceira porção mantém sua formatação padrão:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar listas com marcadores e numeradas**

Organize o texto dos parágrafos em listas com símbolos, números ou imagens personalizadas. Os exemplos nesta seção cobrem formatação de marcadores, listas multiníveis e números iniciais personalizados.

### **Criar uma lista com marcadores ou numerada**

Marcadores e numeração facilitam a leitura de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

Este exemplo para Android via Java adiciona um marcador de símbolo e um item numerado ao mesmo quadro de texto. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) seleciona o tipo de marcador, enquanto [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) fornece o símbolo e [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) seleciona o estilo de numeração. Ambos os itens usam marcadores pretos com altura de 100 % e recuo de parágrafo de 25 pontos:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usar marcadores de imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

Este exemplo para Android via Java adiciona uma imagem à coleção de imagens da apresentação como um [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) e a usa como marcador de parágrafo. Ele chama [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) para usar um marcador de imagem e atribui a imagem através de [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) é definido como 100 % para dimensionar o marcador em relação ao texto do parágrafo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Criar uma lista multinível**

Defina [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para posicionar parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

Este exemplo para Android via Java atribui valores de [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) de 0 a 3 a quatro parágrafos, criando uma hierarquia dentro de um único quadro de texto. Cada parágrafo usa um marcador de símbolo, com [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) alternando entre um marcador redondo e um hífen para distinguir níveis adjacentes:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniciar itens numerados a partir de valores personalizados**

Use [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) para definir o número inicial exibido para um parágrafo numerado.

Este exemplo para Android via Java define [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) para usar numeração em três parágrafos e atribui valores de [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) de 2, 3 e 7. O valor inicial é configurado separadamente para cada parágrafo, permitindo que os números exibidos pulem valores:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar layout e propriedades de término do parágrafo**

Ajuste margens e recuos de parágrafo para controlar a posição da primeira linha e das linhas com quebra. Você também pode formatar a marca de término do parágrafo separadamente das porções de texto visíveis.

### **Definir recuo da primeira linha**

Use o método [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar o recuo da primeira linha de um parágrafo. Essa configuração move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando precisar mover todo o parágrafo. Use [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando precisar mover apenas a primeira linha.

O exemplo a seguir atribui a três parágrafos a mesma [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de 20 pts e valores de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) de 0, 20 e 40 pts. As primeiras linhas começam em deslocamentos progressivamente maiores, enquanto as linhas com quebra mantêm a mesma margem esquerda:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

### **Definir recuo suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com a propriedade [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Defina `Indent` como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um `MarginLeft` positivo e um `Indent` negativo.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde as linhas com quebra devem alinhar-se sob o corpo do parágrafo em vez de sob o primeiro caractere da primeira linha.

O exemplo Android via Java a seguir combina valores de [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de 40 pts e 60 pts com valores de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) de -20 pts e -30 pts. Em cada parágrafo, a primeira linha inicia à esquerda das linhas com quebra; o segundo parágrafo tem um recuo suspenso mais profundo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

### **Definir propriedades de execução do fim do parágrafo**

O método [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controla a formatação da marca de término do parágrafo. O exemplo a seguir cria um [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) com [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) definido como 48 pts e [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) definido como Times New Roman. Ele atribui esse formato à marca de término do segundo parágrafo, deixando as porções de texto visíveis inalteradas:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contar linhas renderizadas**

Para regras de parágrafo que afetam a quebra automática e pontuação no final das linhas, veja [Control Line Breaking](/slides/pt/androidjava/text-formatting/#control-line-breaking) e [Control Hanging Punctuation](/slides/pt/androidjava/text-formatting/#control-hanging-punctuation).

Use [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) para contar as linhas ocupadas por um parágrafo após o layout do texto, incluindo a quebra automática. Isso é útil ao verificar o comprimento do texto e o layout em modelos de apresentação.

Um parágrafo é um item em [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--), e pode ocupar várias linhas renderizadas. Uma quebra de linha explícita dentro de um parágrafo força uma nova linha sem criar outro parágrafo. A quebra automática cria linhas com base na largura disponível sem inserir quebras explícitas no texto. Contar parágrafos ou caracteres de quebra de linha, portanto, não fornece a contagem de linhas renderizadas.

O exemplo a seguir cria uma forma de texto, conta suas linhas, reduz a largura da forma e depois substitui o texto por uma string mais curta. O exemplo habilita a quebra com [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) e desabilita o autofit com [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) para que a largura da forma controle a quebra sem reduzir automaticamente o texto ou redimensionar a forma. Cada medição usa [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). As dimensões da forma são em pontos. Finalmente, o exemplo adiciona outro parágrafo e soma as contagens de linhas em todo o quadro de texto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Com esse texto e essas dimensões, reduzir a forma aumenta a contagem de linhas, enquanto substituir o texto pela string curta a reduz. Contagens exatas podem variar com a disponibilidade e substituição de fontes, tamanho da fonte, margens, recuos, quebra e configurações de autofit. Use as fontes e configurações de layout previstas para o ambiente de destino ao validar um modelo.

A contagem de linhas, por si só, não determina se o texto transborda seu contêiner. A altura disponível, altura das linhas, espaçamento entre parágrafos e linhas, e o comportamento de autofit também são relevantes; até mesmo uma única linha pode exceder a largura disponível quando a quebra está desativada.

## **Importar e exportar conteúdo de parágrafos**

Use HTML para inserir texto em uma apresentação ou exportar parágrafos existentes para uso externo. Esta seção também mostra como renderizar parágrafos individuais como imagens, inclusive parágrafos em células de tabela.

### **Importar texto HTML para parágrafos**

Use [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para converter marcação HTML em parágrafos e porções em um quadro de texto.

Este exemplo Android via Java lê HTML de um arquivo e passa a marcação para [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Ele limpa o parágrafo padrão do quadro de texto para que o quadro contenha apenas o conteúdo importado. A forma retangular deixa uma margem de 10 pts em cada lado do slide:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Exportar texto de parágrafo para HTML**

Use [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar um intervalo selecionado de parágrafos como HTML. Ao reutilizar texto de apresentação em um site, pode ser desejável preservar o destaque local sem levar a fonte, tamanho ou estilos da caixa de texto da apresentação. Defina [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) para controlar até onde o exportador segue a herança de formatação.

Baixe [a apresentação de exemplo](text-inheritance.pptx) e coloque-a no diretório de trabalho do aplicativo. Seu primeiro slide contém uma forma de texto com o texto “Inherited text; explicit red 18pt”. A entrada deliberadamente usa vários níveis de formatação:

- O estilo de texto padrão da apresentação fornece Calibri e tamanho de 28 pt.
- O estilo de texto de primeiro nível do quadro de texto fornece texto azul e itálico.
- O parágrafo define explicitamente texto em negrito.
- A segunda porção, “explicit red 18pt”, define explicitamente texto vermelho e tamanho de 18 pt.

O exemplo completo a seguir exporta os mesmos parágrafos três vezes. Ele passa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) para o método de exportação e grava cada resultado como um arquivo HTML UTF‑8 separado:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

O HTML gerado contém o seguinte CSS para a primeira porção, “Inherited text; ”. A tabela lista as declarações relevantes; outras propriedades geradas foram omitidas para clareza.

| Saída | CSS relevante para a primeira porção | Aparência |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrito, itálico em 28 pt na Calibri, se a fonte estiver disponível. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrito, itálico; a página ou navegador fornece a família e o tamanho da fonte. |
| `ParagraphOnly.html` | `font-weight:bold` | Texto em negrito; a página ou navegador fornece família, tamanho, cor e estilo itálico. |

A segunda porção mantém `color:#ff0000`, `font-size:18pt` e `font-weight:bold` em todas as três saídas. Ela também mantém itálico em `All` e `TextBox`, mas não em `ParagraphOnly`. Restringir a herança, portanto, não remove a formatação atribuída explicitamente a um parágrafo ou porção.

Abra os arquivos no mesmo navegador para compará‑los. Nos dois modos restritos, as propriedades CSS omitidas são resolvidas pelos estilos da página de destino ou pelos padrões do navegador, de modo que a aparência resultante depende de onde o HTML for usado.

### **Renderizar um parágrafo como imagem**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) renderiza um parágrafo individual diretamente e devolve um [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Salve o resultado em um arquivo ou fluxo com [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Não é necessário renderizar a forma contenedora ou recortar um bitmap manualmente.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) pode devolver `null` se o parágrafo não for encontrado na coleção pai, não possuir limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá‑lo e libere a imagem retornada após o uso.

#### **Renderizar um parágrafo na escala padrão**

O exemplo usa uma apresentação com um slide cujo primeiro objeto é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo a seguir seleciona o segundo parágrafo no índice 1 e chama [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) sem parâmetros de escala. Ele verifica se a forma contém o parágrafo necessário e se a renderização devolve uma imagem antes de chamar [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) para salvá‑la em formato PNG. O bloco `finally` libera a imagem após o uso.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

#### **Renderizar um parágrafo em célula de tabela com escala**

Use a sobrecarga de [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) que aceita parâmetros `float scaleX` e `float scaleY` para definir os fatores de escala horizontal e vertical. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com o dobro da largura e altura padrão e salva o resultado como imagem PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Um fator de escala `1` mantém aquele eixo no tamanho padrão de pixel. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente o dobro das dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores diferentes horizontal e verticalmente esticam a saída independentemente.

Renderizar uma forma inteira com [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) continua útil quando a saída deve incluir o preenchimento, a borda ou outro contexto visual da forma. Para uma imagem somente de parágrafo, use [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Perguntas frequentes**

**Posso desativar completamente a quebra automática de linhas dentro de um quadro de texto?**

Sim. Defina [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) para desativar a quebra, de modo que as linhas não se partam nas bordas do quadro de texto.

**Como obter os limites exatos de um parágrafo específico no slide?**

Use [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) para recuperar o retângulo delimitador do parágrafo. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) fornece os limites de uma porção individual.

**Onde a alinhamento de parágrafo (esquerda, direita, centralizado ou justificado) é controlado?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) é uma configuração ao nível do parágrafo e se aplica a todo o parágrafo independentemente da formatação das porções individuais.

Para alinhar verticalmente porções com tamanhos de fonte diferentes dentro de cada linha, veja [Align Fonts Within a Line](/slides/pt/androidjava/text-formatting/#align-fonts-within-a-line).

**Posso definir o idioma de revisão para parte de um parágrafo?**

Sim. Defina [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para porções individuais, de modo que um parágrafo possa conter texto em vários idiomas.