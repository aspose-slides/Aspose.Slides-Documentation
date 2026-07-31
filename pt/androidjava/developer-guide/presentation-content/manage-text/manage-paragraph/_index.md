---
title: Gerenciar Parágrafos de Texto do PowerPoint no Android
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
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
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Domine a formatação de parágrafos com Aspose.Slides para Android—otimize alinhamento, espaçamento e estilo em apresentações PPT, PPTX e ODP em Java."
---
## **Introdução**

Aspose.Slides fornece todas as interfaces e classes de que você precisa para trabalhar com textos, parágrafos e trechos do PowerPoint em Java.

* Aspose.Slides fornece a interface [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) que permite acrescentar objetos que representam um parágrafo. Um objeto `ITextFame` pode ter um ou vários parágrafos (cada parágrafo é criado através de uma quebra de linha).
* Aspose.Slides fornece a interface [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) que permite acrescentar objetos que representam trechos. Um objeto `IParagraph` pode ter um ou vários trechos (coleção de objetos iPortions).
* Aspose.Slides fornece a interface [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) que permite acrescentar objetos que representam textos e suas propriedades de formatação.

Um objeto `IParagraph` é capaz de manipular textos com diferentes propriedades de formatação por meio de seus objetos subjacentes `IPortion`.

## **Adicionar Vários Parágrafos contendo Várias Porções de Texto**

Estas etapas mostram como adicionar um quadro de texto contendo 3 parágrafos e cada parágrafo contendo 3 trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um retângulo [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
4. Obtenha o ITextFrame associado ao [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).
5. Crie dois objetos [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) e adicione-os à coleção `IParagraphs` do [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/).
6. Crie três objetos [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) para cada novo `IParagraph` (dois objetos Portion para o Parágrafo padrão) e adicione cada objeto `IPortion` à coleção IPortion de cada `IParagraph`.
7. Defina algum texto para cada porção.
8. Aplique os recursos de formatação desejados a cada porção usando as propriedades de formatação expostas pelo objeto `IPortion`.
9. Salve a apresentação modificada.

Este código Java é uma implementação das etapas para adicionar parágrafos contendo trechos:

```java
// Instanciar uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessando o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionar um AutoShape do tipo Retângulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Acessar o TextFrame do AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Criar Parágrafos e Porções com diferentes formatos de texto
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // Gravar PPTX no disco
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar Marcadores de Parágrafo**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são sempre mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/).
7. Defina o `Type` do marcador para `Symbol` e configure o caractere do marcador.
8. Defina o `Text` do parágrafo.
9. Defina a `Indent` do parágrafo para o marcador.
10. Defina uma cor para o marcador.
11. Defina a altura do marcador.
12. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
13. Adicione o segundo parágrafo e repita o processo descrito nas etapas 7 a 13.
14. Salve a apresentação.

Este código Java mostra como adicionar um marcador de parágrafo:

```java
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adiciona e acessa o Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Remove o parágrafo padrão
    txtFrm.getParagraphs().removeAt(0);

    // Cria um parágrafo
    Paragraph para = new Paragraph();

    // Define o estilo e o símbolo do marcador de parágrafo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Define o texto do parágrafo
    para.setText("Welcome to Aspose.Slides");

    // Define o recuo do marcador
    para.getParagraphFormat().setIndent(25);

    // Define a cor do marcador
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // definir IsBulletHardColor como true para usar a própria cor do marcador

    // Define a altura do marcador
    para.getParagraphFormat().getBullet().setHeight(100);

    // Adiciona o parágrafo ao quadro de texto
    txtFrm.getParagraphs().add(para);

    // Cria o segundo parágrafo
    Paragraph para2 = new Paragraph();

    // Define o tipo e o estilo do marcador do parágrafo
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Adiciona o texto do parágrafo
    para2.setText("This is numbered bullet");

    // Define o recuo do marcador
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // definir IsBulletHardColor como true para usar a própria cor do marcador

    // Define a altura do marcador
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Adiciona o parágrafo ao quadro de texto
    txtFrm.getParagraphs().add(para2);
    
    // Salva a apresentação modificada
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com imagens são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/).
7. Carregue a imagem em [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/).
8. Defina o tipo de marcador como [Picture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) e configure a imagem.
9. Defina o `Text` do parágrafo.
10. Defina a `Indent` do parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina a altura do marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo baseado nas etapas anteriores.
15. Salve a apresentação modificada.

Este código Java mostra como adicionar e gerenciar marcadores de imagem:

```java
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation presentation = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instancia a imagem para marcadores
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Adiciona e acessa o Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Remove o parágrafo padrão
    textFrame.getParagraphs().removeAt(0);

    // Cria um novo parágrafo
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Define o estilo e a imagem do marcador do parágrafo
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Define a altura do marcador
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Adiciona o parágrafo ao quadro de texto
    textFrame.getParagraphs().add(paragraph);

    // Grava a apresentação como um arquivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Grava a apresentação como um arquivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gerenciar Marcadores de Níveis Múltiplos**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores de níveis múltiplos são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) no novo slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/) e defina a profundidade como 0.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina a profundidade como 1.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina a profundidade como 2.
9. Crie a quarta instância de parágrafo através da classe `Paragraph` e defina a profundidade como 3.
10. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
11. Salve a apresentação modificada.

Este código Java mostra como adicionar e gerenciar marcadores de níveis múltiplos:

```java
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adiciona e acessa Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape criado
    ITextFrame text = aShp.addTextFrame("");

    // Limpa o parágrafo padrão
    text.getParagraphs().clear();

    // Adiciona o primeiro parágrafo
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Define o nível do marcador
    para1.getParagraphFormat().setDepth((short)0);

    // Adiciona o segundo parágrafo
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Define o nível do marcador
    para2.getParagraphFormat().setDepth((short)1);

    // Adiciona o terceiro parágrafo
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Define o nível do marcador
    para3.getParagraphFormat().setDepth((short)2);

    // Adiciona o quarto parágrafo
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Define o nível do marcador
    para4.getParagraphFormat().setDepth((short)3);

    // Adiciona os parágrafos à coleção
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Grava a apresentação como um arquivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar um Parágrafo com uma Lista Numerada Personalizada**

A interface [IBulletFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/) fornece a propriedade [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) e outras que permitem gerenciar parágrafos com numeração ou formatação personalizada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide que contém o parágrafo.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/) e defina [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) como 2.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 3.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 7.
9. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
10. Salve a apresentação modificada.

Este código Java mostra como adicionar e gerenciar parágrafos com numeração ou formatação personalizada:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape criado
    ITextFrame textFrame = shape.getTextFrame();

    // Remove o parágrafo padrão existente
    textFrame.getParagraphs().removeAt(0);

    // Primeira lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use o método [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar o recuo da primeira linha de um parágrafo. Este método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando precisar mover todo o parágrafo. Use [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de recuo para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [Indent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir o recuo de um parágrafo:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

O resultado:

![Recuo da primeira linha dos parágrafos](first_line_indent.png)

## **Definir Recuo Suspenso para um Parágrafo**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com o método [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Defina o recuo como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo para `MarginLeft` e um valor negativo para `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos em que as linhas quebradas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

O resultado:

![Recuo suspenso dos parágrafos](hanging_indent.png)

## **Gerenciar Propriedades de Execução de Fim de Parágrafo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha a referência do slide que contém o parágrafo por sua posição.
1. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) retangular ao slide.
1. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) com dois parágrafos ao retângulo.
1. Defina o `FontHeight` e o tipo de fonte para os parágrafos.
1. Defina as propriedades End para os parágrafos.
1. Grave a apresentação modificada como um arquivo PPTX.

Este código Java mostra como definir as propriedades End para parágrafos no PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Importar Texto HTML em Parágrafos**

Aspose.Slides oferece suporte avançado para importação de texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
4. Adicione e acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) do autoshape.
5. Remova o parágrafo padrão no `ITextFrame`.
6. Leia o arquivo HTML de origem em um TextReader.
7. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/).
8. Adicione o conteúdo do arquivo HTML lido no TextReader à [ParagraphCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphcollection/) do TextFrame.
9. Salve a apresentação modificada.

Este código Java é uma implementação das etapas para importar textos HTML em parágrafos:

```java
// Criar instância vazia de apresentação
Presentation pres = new Presentation();
try {
    // Acessar o slide padrão inicial da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionar AutoShape para acomodar o conteúdo HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Adicionar quadro de texto à forma
    ashape.addTextFrame("");

    // Limpar todos os parágrafos no quadro de texto adicionado
    ashape.getTextFrame().getParagraphs().clear();

    // Carregar o arquivo HTML usando StreamReader
    TextReader tr = new StreamReader("file.html");

    // Adicionar texto do leitor de fluxo HTML ao quadro de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Salvar apresentação
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportar Texto de Parágrafo para HTML**

Aspose.Slides oferece suporte avançado para exportar textos (contidos em parágrafos) para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse a referência do slide relevante por meio de seu índice.
3. Acesse a forma que contém o texto que será exportado para HTML.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) da forma.
5. Crie uma instância de `StreamWriter` e adicione o novo arquivo HTML.
6. Forneça um índice inicial ao StreamWriter e exporte os parágrafos desejados.

Este código Java mostra como exportar textos de parágrafos do PowerPoint para HTML:

```java
// Carregar o arquivo de apresentação
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Acessar o slide padrão inicial da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Índice desejado
    int index = 0;

    // Acessar a forma adicionada
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Criar arquivo HTML de saída
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extrair o primeiro parágrafo como HTML
    // Escrever dados dos parágrafos em HTML fornecendo o índice inicial do parágrafo e o total de parágrafos a serem copiados
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela interface [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/), como imagem. Ambos os exemplos incluem a obtenção da imagem de uma forma que contém o parágrafo usando os métodos `getImage` da interface [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/), o cálculo dos limites do parágrafo dentro da forma e a exportação como bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil em diversos cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtém‑se o segundo parágrafo como imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando se precisa salvar um parágrafo específico como imagem separada, preservando as dimensões e a formatação exatas do texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salvar a forma na memória como bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Criar um bitmap da forma a partir da memória.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior adicionando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de maior resolução ao exportar o parágrafo. Os limites do parágrafo são então calculados considerando a escala. A escala pode ser particularmente útil quando se necessita de uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salvar a forma na memória como bitmap com escala.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Criar um bitmap da forma a partir da memória.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Perguntas Frequentes**

**Posso desativar completamente a quebra automática de linha dentro de um quadro de texto?**

Sim. Use a configuração de quebra de texto do quadro ([setWrapText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) para desligar a quebra, de modo que as linhas não se interrompam nas bordas do quadro.

**Como obter os limites exatos de um parágrafo específico na lâmina?**

Você pode recuperar o retângulo delimitador do parágrafo (e até mesmo de um único trecho) para conhecer sua posição e tamanho precisos na lâmina.

**Onde o alinhamento do parágrafo (esquerda/direita/centralizado/justificado) é controlado?**

[Alignment](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) é uma configuração ao nível do parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphformat/); ele se aplica a todo o parágrafo independentemente da formatação de trechos individuais.

**Posso definir um idioma de verificação ortográfica apenas para parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido no nível do trecho ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), permitindo que múltiplos idiomas coexistam dentro de um único parágrafo.