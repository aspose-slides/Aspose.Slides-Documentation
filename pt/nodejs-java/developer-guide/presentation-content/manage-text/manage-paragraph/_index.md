---
title: Gerenciar Parágrafos de Texto do PowerPoint em JavaScript
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/nodejs-java/manage-paragraph/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine a formatação de parágrafos com Aspose.Slides para Node.js via Java—otimize alinhamento, espaçamento e estilo em apresentações PPT, PPTX e ODP em JavaScript."
---
## **Introdução**

Aspose.Slides fornece todas as classes necessárias para trabalhar com textos, parágrafos e trechos do PowerPoint em Java.

* Aspose.Slides fornece a classe [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) para permitir que você adicione objetos que representam um parágrafo. Um objeto `TextFame` pode ter um ou vários parágrafos (cada parágrafo é criado por meio de uma quebra de linha).
* Aspose.Slides fornece a classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) para permitir que você adicione objetos que representam trechos. Um objeto `Paragraph` pode ter um ou vários trechos (coleção de objetos de trecho de texto).
* Aspose.Slides fornece a classe [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) para permitir que você adicione objetos que representam textos e suas propriedades de formatação.

Um objeto `Paragraph` é capaz de lidar com textos com diferentes propriedades de formatação por meio de seus objetos subjacentes `Portion`.

## **Adicionar Vários Parágrafos Contendo Vários Trechos**

Estas etapas mostram como adicionar uma caixa de texto contendo 3 parágrafos e cada parágrafo contendo 3 trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Obtenha o ITextFrame associado ao [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
5. Crie dois objetos [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) e adicione-os à coleção `IParagraphs` do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
6. Crie três objetos [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) para cada novo `Paragraph` (dois objetos Portion para o Paragraph padrão) e adicione cada objeto `Portion` à coleção IPortion de cada `Paragraph`.
7. Defina algum texto para cada trecho.
8. Aplique os recursos de formatação desejados a cada trecho usando as propriedades de formatação expostas pelo objeto `Portion`.
9. Salve a apresentação modificada.

Este código Javascript é uma implementação das etapas para adicionar parágrafos contendo trechos:

```javascript
// Instanciar uma classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessando o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo Retângulo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Acessar o TextFrame do AutoShape
    var tf = ashp.getTextFrame();
    // Criar Parágrafos e Trechos com diferentes formatos de texto
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Gravar o PPTX no disco
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerenciar Marcadores de Parágrafo**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são sempre mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do AutoShape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/).
7. Defina o `Type` do marcador para `Symbol` e defina o caractere do marcador.
8. Defina o `Text` do parágrafo.
9. Defina o `Indent` do parágrafo para o marcador.
10. Defina uma cor para o marcador.
11. Defina a altura do marcador.
12. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
13. Adicione o segundo parágrafo e repita o processo descrito nas etapas 7 a 13.
14. Salve a apresentação.

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adiciona e acessa um AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Acessa o quadro de texto do AutoShape
    var txtFrm = aShp.getTextFrame();
    // Remove o parágrafo padrão
    txtFrm.getParagraphs().removeAt(0);
    // Cria um parágrafo
    var para = new aspose.slides.Paragraph();
    // Define o estilo e símbolo de marcador do parágrafo
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Define o texto do parágrafo
    para.setText("Welcome to Aspose.Slides");
    // Define o recuo do marcador
    para.getParagraphFormat().setIndent(25);
    // Define a cor do marcador
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// defina IsBulletHardColor como true para usar a própria cor do marcador
    // Define a altura do marcador
    para.getParagraphFormat().getBullet().setHeight(100);
    // Adiciona o parágrafo ao quadro de texto
    txtFrm.getParagraphs().add(para);
    // Cria o segundo parágrafo
    var para2 = new aspose.slides.Paragraph();
    // Define o tipo e estilo de marcador do parágrafo
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Adiciona o texto do parágrafo
    para2.setText("This is numbered bullet");
    // Define o recuo do marcador
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// defina IsBulletHardColor como true para usar a própria cor do marcador
    // Define a altura do marcador
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Adiciona o parágrafo ao quadro de texto
    txtFrm.getParagraphs().add(para2);
    // Salva a apresentação modificada
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com imagens são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do AutoShape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/).
7. Carregue a imagem em [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/).
8. Defina o tipo de marcador como [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) e defina a imagem.
9. Defina o `Text` do Parágrafo.
10. Defina o `Indent` do parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina a altura do marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo com base nas etapas anteriores.
15. Salve a apresentação modificada.

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var slide = presentation.getSlides().get_Item(0);
    // Instancia a imagem para marcadores
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona e acessa um AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Acessa o quadro de texto do autoshape
    var textFrame = autoShape.getTextFrame();
    // Remove o parágrafo padrão
    textFrame.getParagraphs().removeAt(0);
    // Cria um novo parágrafo
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Define o estilo de marcador do parágrafo e a imagem
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Define a altura do marcador
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Adiciona o parágrafo ao quadro de texto
    textFrame.getParagraphs().add(paragraph);
    // Grava a apresentação como um arquivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Grava a apresentação como um arquivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gerenciar Marcadores Multiníveis**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores multiníveis são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) no novo slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do AutoShape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) e defina a profundidade como 0.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina a profundidade como 1.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina a profundidade como 2.
9. Crie a quarta instância de parágrafo através da classe `Paragraph` e defina a profundidade como 3.
10. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
11. Salve a apresentação modificada.

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adiciona e acessa um AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Acessa o quadro de texto do AutoShape criado
    var text = aShp.addTextFrame("");
    // Limpa o parágrafo padrão
    text.getParagraphs().clear();
    // Adiciona o primeiro parágrafo
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define o nível do marcador
    para1.getParagraphFormat().setDepth(0);
    // Adiciona o segundo parágrafo
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define o nível do marcador
    para2.getParagraphFormat().setDepth(1);
    // Adiciona o terceiro parágrafo
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define o nível do marcador
    para3.getParagraphFormat().setDepth(2);
    // Adiciona o quarto parágrafo
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define o nível do marcador
    para4.getParagraphFormat().setDepth(3);
    // Adiciona os parágrafos à coleção
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Grava a apresentação como um arquivo PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerenciar Parágrafo com Lista Numerada Personalizada**

A classe [BulletFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/) fornece a propriedade [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) e outras que permitem gerenciar parágrafos com numeração ou formatação personalizada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide que contém o parágrafo.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do AutoShape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) e defina [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) para 2.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` para 3.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` para 7.
9. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
10. Salve a apresentação modificada.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Acessa o quadro de texto do autoshape criado
    var textFrame = shape.getTextFrame();
    // Remove o parágrafo padrão existente
    textFrame.getParagraphs().removeAt(0);
    // Primeira lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use o método [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para controlar o recuo da primeira linha de um parágrafo. Este método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) quando precisar mover todo o parágrafo. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de recuo para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [Indent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

The result:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Definir Recuo Suspenso para um Parágrafo**

Um hanging indent é um layout de parágrafo no qual a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com o método [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/). Defina o recuo como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo para `MarginLeft` e um valor negativo para `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde as linhas quebradas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

The result:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gerenciar Propriedades de Execução de Final de Parágrafo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Obtenha a referência do slide que contém o parágrafo por sua posição.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) com dois parágrafos ao retângulo.
5. Defina o `FontHeight` e o tipo de fonte para os parágrafos.
6. Defina as propriedades de Final para os parágrafos.
7. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Importar Texto HTML para Parágrafos**

Aspose.Slides fornece suporte aprimorado para importar texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
4. Adicione e acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do `AutoShape`.
5. Remova o parágrafo padrão no `TextFrame`.
6. Leia o arquivo HTML fonte em um TextReader.
7. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/).
8. Adicione o conteúdo do arquivo HTML lido pelo TextReader à [ParagraphCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphcollection/) do TextFrame.
9. Salve a apresentação modificada.

```javascript
// Criar instância vazia de apresentação
var pres = new aspose.slides.Presentation();
try {
    // Acessar o primeiro slide padrão da apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adicionar o AutoShape para acomodar o conteúdo HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Adicionar quadro de texto à forma
    ashape.addTextFrame("");
    // Limpar todos os parágrafos no quadro de texto adicionado
    ashape.getTextFrame().getParagraphs().clear();
    // Carregar o arquivo HTML usando o leitor de fluxo
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Adicionar texto do leitor de fluxo HTML no quadro de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Salvar a apresentação
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportar Texto de Parágrafos para HTML**

Aspose.Slides fornece suporte aprimorado para exportar textos (contidos em parágrafos) para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse a referência do slide relevante por meio de seu índice.
3. Acesse a forma que contém o texto que será exportado para HTML.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma.
5. Crie uma instância de `StreamWriter` e adicione o novo arquivo HTML.
6. Forneça um índice inicial ao StreamWriter e exporte os parágrafos desejados.

```javascript
// Carregar o arquivo de apresentação
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Acessar o primeiro slide padrão da apresentação
    var slide = pres.getSlides().get_Item(0);
    // Índice desejado
    var index = 0;
    // Acessando a forma adicionada
    var ashape = slide.getShapes().get_Item(index);
    // Criando o arquivo HTML de saída
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extraindo o primeiro parágrafo como HTML
    // Gravando os dados dos parágrafos em HTML fornecendo o índice inicial do parágrafo e o total de parágrafos a serem copiados
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela classe [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/), como uma imagem. Ambos os exemplos incluem obter a imagem de uma forma que contém o parágrafo usando os métodos `getImage` da classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/), calcular os limites do parágrafo dentro da forma e exportá‑lo como uma imagem bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil em diversos cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtemos o segundo parágrafo como imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e então calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando você precisa salvar um parágrafo específico como imagem separada preservando as dimensões e formatação exatas do texto.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salvar a forma na memória como um bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Criar um bitmap da forma a partir da memória.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Cortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

The result:

![The paragraph image](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior adicionando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de resolução mais alta ao exportar o parágrafo. Os limites do parágrafo são então calculados considerando a escala. A escala pode ser particularmente útil quando é necessária uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salvar a forma na memória como um bitmap com escala.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Criar um bitmap da forma a partir da memória.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Cortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Perguntas Frequentes**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Use a configuração de quebra de linha do quadro de texto ([setWrapText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/setwraptext/)) para desativar a quebra, de modo que as linhas não sejam interrompidas nas bordas do quadro.

**Como posso obter os limites exatos na lâmina de um parágrafo específico?**

Você pode recuperar o retângulo delimitador do parágrafo (ou mesmo de um único trecho) para conhecer sua posição e tamanho precisos na lâmina.

**Onde o alinhamento do parágrafo (esquerda/direita/centro/justificado) é controlado?**

[setAlignment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setalignment/) é um método de configuração ao nível do parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/); ele se aplica a todo o parágrafo independentemente da formatação de trechos individuais.

**Posso definir um idioma de verificação ortográfica para apenas parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido ao nível do trecho ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), permitindo que múltiplos idiomas coexistam dentro de um único parágrafo.