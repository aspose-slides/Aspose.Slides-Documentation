---
title: Gerenciar parágrafos de texto do PowerPoint no Android
linktitle: Gerenciar Parágrafo
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
description: "Aprenda como criar e formatar parágrafos, trechos, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafo com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java representa o texto como uma hierarquia de quadros de texto, parágrafos e trechos:

* [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) representa um parágrafo em um quadro de texto e fornece acesso aos seus trechos e à formatação no nível do parágrafo.
* [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) representa uma execução de texto dentro de um parágrafo. Cada trecho pode ter seu próprio texto e formatação a nível de caractere.

Um parágrafo pode, portanto, conter texto com fontes, cores, tamanhos e outras formatações diferentes, usando vários trechos.

## **Criar e formatar parágrafos**

### **Criar parágrafos com múltiplos trechos**

Os passos a seguir criam um quadro de texto com três parágrafos, cada um contendo três trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide relevante pelo seu índice.
3. Adicione uma [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma.
5. Use o parágrafo padrão e adicione mais dois objetos [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) ao quadro de texto.
6. Adicione objetos [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) suficientes para que cada parágrafo contenha três trechos. O parágrafo padrão já contém um trecho vazio.
7. Defina o texto de cada trecho.
8. Aplique formatação a nível de caractere através de [IPortion.getPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Salve a apresentação modificada.

Este exemplo Android via Java implementa os passos:

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

### **Criar uma lista com marcadores ou numerada**

Marcadores e numeração facilitam a visualização de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [IBulletFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide relevante pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-int-) para [BulletType.Symbol](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-int-) para [BulletType.Numbered](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/).
11. Configure o estilo do marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

Este exemplo Android via Java cria um marcador de símbolo e um marcador numerado:

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

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide relevante pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) e acesse seu [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/) e defina seu texto.
7. Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-int-) para [BulletType.Picture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/).
8. Atribua a imagem através de [IBulletFormat.getPicture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#getPicture--) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

Este exemplo Android via Java cria um marcador de imagem:

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

Defina [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar os parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) e limpe o parágrafo padrão do seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina os valores de [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo Android via Java cria uma lista com marcadores de quatro níveis:

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

### **Iniciar itens de lista numerada com valores personalizados**

Use [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) para definir o número inicial exibido para um parágrafo numerado.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) para `2`, `3` e `7` nos respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo Android via Java atribui um número inicial personalizado a cada parágrafo:

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

## **Controlar layout de parágrafo e propriedades de fim**

### **Definir recuo da primeira linha**

Use [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar o recuo da primeira linha de um parágrafo. Este método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando precisar mover todo o parágrafo. Use [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione uma [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina valores diferentes de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir o recuo de um parágrafo:

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

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Passe um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, passe um valor positivo para `setMarginLeft` e um valor negativo para `setIndent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde linhas quebradas devem alinhar-se sob o corpo do parágrafo em vez de sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione uma [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie parágrafos e passe um valor positivo para [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) para cada parágrafo.
6. Passe um valor negativo para [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

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

### **Definir propriedades de execução do final do parágrafo**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controla a formatação da marca de fim de parágrafo. O exemplo a seguir atribui um tamanho de fonte e fonte latina à marca de fim do segundo parágrafo:

1. Carregue uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione trechos de texto a eles.
4. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portionformat/) para a marca de fim do segundo parágrafo.
5. Defina [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) e [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Atribua o formato com [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) e salve a apresentação.

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

## **Importar e exportar conteúdo de parágrafos**

### **Importar texto HTML em parágrafos**

Use [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para converter marcação HTML em parágrafos e trechos em um quadro de texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse um slide e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma e limpe o parágrafo padrão.
4. Leia o arquivo HTML fonte.
5. Passe a string HTML para [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Salve a apresentação modificada.

Este exemplo Android via Java importa HTML em um quadro de texto:

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

Use [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse o slide e encontre o [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) que contém o texto.
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da forma.
4. Chame [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) com o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Escreva a string HTML retornada em um arquivo.

Este exemplo Android via Java exporta todos os parágrafos da primeira forma de texto:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **Renderizar um parágrafo como imagem**

[IParagraph.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getImage--) renderiza diretamente um parágrafo individual e retorna um [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/). Salve o resultado em um arquivo ou fluxo com [IImage.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Não é necessário renderizar a forma que contém ou recortar um bitmap manualmente.

[IParagraph.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getImage--) pode retornar `null` se o parágrafo não for encontrado em sua coleção pai, não possuir limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá-lo e descarte a imagem retornada após o uso.

#### **Renderizar um parágrafo na escala padrão**

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada no formato PNG. O bloco `finally` garante que a imagem seja descartada corretamente.

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

#### **Renderizar um parágrafo em uma célula de tabela com escala**

Use a sobrecarga de [IParagraph.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) que aceita os parâmetros `float scaleX` e `float scaleY` para definir os fatores de escala horizontal e vertical. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com o dobro da largura e altura padrão, e salva o resultado como uma imagem PNG.

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

Um fator de escala `1` mantém esse eixo no tamanho de pixel padrão. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente o dobro das dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores diferentes horizontal e verticalmente esticam a saída independentemente.

Renderizar toda a forma com [IShape.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getImage--) ainda é útil quando a saída precisa incluir o preenchimento, a borda ou outro contexto visual da forma. Para uma imagem apenas do parágrafo, use [IParagraph.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Can I completely disable line wrapping inside a text frame?**  
Sim. Defina [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) para desativar a quebra, de modo que as linhas não sejam interrompidas nas bordas do quadro de texto.

**How can I get the exact on-slide bounds of a specific paragraph?**  
Use [IParagraph.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getRect--) para obter o retângulo delimitador do parágrafo. [IPortion.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getRect--) fornece os limites de um trecho individual.

**Where is paragraph alignment (left, right, center, or justify) controlled?**  
[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) é uma configuração de nível de parágrafo e se aplica ao parágrafo inteiro, independentemente da formatação de trechos individuais.

**Can I set the proofing language for part of a paragraph?**  
Sim. Defina [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para trechos individuais, permitindo que um parágrafo contenha texto em vários idiomas.