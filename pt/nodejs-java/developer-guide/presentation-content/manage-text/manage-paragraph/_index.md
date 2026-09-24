---
title: Gerenciar parágrafos de texto do PowerPoint em JavaScript
linktitle: Gerenciar parágrafo
type: docs
weight: 40
url: /pt/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo do parágrafo
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar e formatar parágrafos, trechos, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafos com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java representa o texto como uma hierarquia de quadros de texto, parágrafos e trechos:

* [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) representa um parágrafo em um quadro de texto e fornece acesso aos seus trechos e à formatação em nível de parágrafo.
* [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) representa uma sequência de texto dentro de um parágrafo. Cada trecho pode ter seu próprio texto e formatação em nível de caractere.

Um parágrafo, portanto, pode conter texto com diferentes fontes, cores, tamanhos e outras formatações usando vários trechos.

## **Criar e Formatar Parágrafos**

### **Criar Parágrafos com Vários Trechos**

As etapas a seguir criam um quadro de texto com três parágrafos, cada um contendo três trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide desejado pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma.
5. Use o parágrafo padrão e adicione mais dois objetos [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) ao quadro de texto.
6. Adicione trechos [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) suficientes para que cada parágrafo contenha três trechos. O parágrafo padrão já contém um trecho vazio.
7. Defina o texto de cada trecho.
8. Aplique formatação em nível de caractere através de [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/getportionformat/).
9. Salve a apresentação modificada.

O exemplo JavaScript implementa as etapas:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar Listas com Marcadores e Numeração**

### **Criar uma Lista com Marcadores ou Numerada**

Marcadores e numeração facilitam a leitura de itens relacionados. No Aspose.Slides, as configurações da lista são definidas por meio de [BulletFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide desejado pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [BulletFormat.setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/settype/) como [BulletType.Symbol](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [BulletFormat.setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/settype/) como [BulletType.Numbered](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bullettype/).
11. Configure o estilo do marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

O exemplo JavaScript cria um marcador de símbolo e um marcador numerado:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usar Marcadores de Imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide desejado pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) e acesse seu [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) e defina seu texto.
7. Defina [BulletFormat.setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/settype/) como [BulletType.Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bullettype/).
8. Associe a imagem através de [BulletFormat.getPicture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/getpicture/) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

O exemplo JavaScript cria um marcador de imagem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Criar uma Lista Multinível**

Defina [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setdepth/) para posicionar parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) e limpe o parágrafo padrão de seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina seus valores de [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setdepth/) como `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

O exemplo JavaScript cria uma lista com quatro níveis de marcadores:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniciar Itens Numerados com Valores Personalizados**

Use [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) para definir o número inicial exibido para um parágrafo numerado.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) como `2`, `3` e `7` para os respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

O exemplo JavaScript atribui um número inicial personalizado a cada parágrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar Layout do Parágrafo e Propriedades de Fim**

### **Definir Recuo da Primeira Linha**

Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para controlar o recuo da primeira linha de um parágrafo. Esse método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) quando precisar mover todo o parágrafo. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica valores diferentes de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina valores diferentes de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir um recuo de parágrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

### **Definir Recuo Suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/). Passe um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, passe um valor positivo para `setMarginLeft` e um valor negativo para `setIndent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos em que linhas envolvidas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma e remova o parágrafo padrão.
5. Crie parágrafos e passe um valor positivo para [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) para cada parágrafo.
6. Passe um valor negativo para [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setindent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

### **Definir Propriedades de Execução do Parágrafo Final**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) controla a formatação da marca de fim do parágrafo. O exemplo a seguir atribui um tamanho de fonte e a fonte latina à marca de fim do segundo parágrafo:

1. Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione trechos de texto a eles.
4. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/) para a marca de fim do segundo parágrafo.
5. Defina [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) e [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Atribua o formato com [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) e salve a apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contar Linhas Renderizadas**

Use [Paragraph.getLinesCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getLinesCount) para contar as linhas ocupadas por um parágrafo após o layout do texto, incluindo quebras automáticas. Isso é útil ao verificar o comprimento e o layout do texto em modelos de apresentação.

Um parágrafo é um item em [TextFrame.getParagraphs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParagraphs) e pode ocupar várias linhas renderizadas. Uma quebra de linha explícita dentro de um parágrafo força uma nova linha sem criar outro parágrafo. A quebra automática gera linhas com base na largura disponível sem inserir quebras de linha explícitas no texto. Portanto, contar parágrafos ou caracteres de quebra de linha não fornece a contagem de linhas renderizadas.

O exemplo a seguir cria uma forma de texto, conta suas linhas, estreita a forma e, em seguida, substitui o texto por uma string mais curta. A quebra de linha está habilitada e o ajuste automático está desabilitado para que a largura da forma controle a quebra sem reduzir automaticamente o texto ou redimensionar a forma. As dimensões da forma são em pontos. Por fim, o exemplo adiciona outro parágrafo e soma as contagens de linhas em todo o quadro de texto.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Com esse texto e essas dimensões, estreitar a forma aumenta a contagem de linhas, enquanto substituir o texto pela string curta a reduz. Contagens exatas podem variar conforme a disponibilidade e substituição de fontes, tamanho da fonte, margens, recuos, quebra automática e configurações de ajuste automático. Use as fontes e as configurações de layout previstas para o ambiente de destino ao validar um modelo.

A contagem de linhas isolada não determina se o texto excede seu contêiner. A altura disponível, alturas de linha, espaçamento entre parágrafos e linhas e o comportamento de ajuste automático também são importantes; até uma única linha pode ultrapassar a largura disponível quando a quebra automática está desativada.

## **Importar e Exportar Conteúdo de Parágrafos**

### **Importar Texto HTML para Parágrafos**

Use [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) para converter marcação HTML em parágrafos e trechos dentro de um quadro de texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse um slide e adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
3. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma e limpe seu parágrafo padrão.
4. Defina ou leia a string HTML de origem.
5. Passe a string HTML para [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Salve a apresentação modificada.

Este exemplo JavaScript importa HTML para um quadro de texto:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exportar Texto do Parágrafo para HTML**

Use [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie ou carregue uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o slide e localize o [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) que contém o texto.
3. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da forma.
4. Chame [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) informando o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Grave a string HTML retornada em um arquivo.

Este exemplo JavaScript autossuficiente cria uma forma de texto e exporta todos os seus parágrafos:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderizar um Parágrafo como Imagem**

[Paragraph.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getImage) renderiza um parágrafo individualmente e devolve um [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/). Salve o resultado em um arquivo com [IImage.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save). Não é necessário renderizar a forma que contém o parágrafo nem recortar um bitmap manualmente.

[Paragraph.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getImage) pode devolver `null` se o parágrafo não for encontrado em sua coleção pai, não possuir limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá‑lo e libere a imagem retornada após o uso.

#### **Renderizar um Parágrafo na Escala Padrão**

A caixa de texto a seguir contém três parágrafos:

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada em formato PNG. O bloco `finally` garante que a imagem seja descartada corretamente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

#### **Renderizar um Parágrafo em Célula de Tabela com Redimensionamento**

Use a sobrecarga de [Paragraph.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getImage) que aceita os parâmetros `scaleX` e `scaleY` para definir os fatores de escala horizontal e vertical. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula em duas vezes a largura e altura padrão, e salva o resultado como imagem PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Um fator de escala `1` mantém aquele eixo no tamanho de pixel padrão. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente o dobro das dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente geram texto mais nítido para zoom ou saída em alta resolução, mas também aumentam o consumo de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores horizontais e verticais diferentes esticam a saída independentemente.

Renderizar toda a forma com [Shape.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) continua útil quando a saída deve incluir o preenchimento, borda ou outro contexto visual da forma. Para uma imagem apenas do parágrafo, use [Paragraph.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Defina [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/setwraptext/) para desativar a quebra, de modo que as linhas não se interrompam nas bordas do quadro de texto.

**Como obtenho as coordenadas exatas de um parágrafo específico no slide?**

Use [Paragraph.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/getrect/) para recuperar o retângulo delimitador do parágrafo. [Portion.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getRect) fornece os limites de um trecho individual.

**Onde é controlado o alinhamento do parágrafo (esquerda, direita, centralizado ou justificado)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setalignment/) é uma configuração em nível de parágrafo e se aplica a todo o parágrafo, independentemente da formatação de trechos individuais.

**Posso definir o idioma de revisão para parte de um parágrafo?**

Sim. Defina [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) para trechos individuais, de modo que um parágrafo possa conter texto em vários idiomas.