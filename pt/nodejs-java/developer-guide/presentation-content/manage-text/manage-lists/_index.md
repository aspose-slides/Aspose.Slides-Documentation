---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações Usando JavaScript
linktitle: Gerenciar Listas
type: docs
weight: 60
url: /pt/nodejs-java/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como criar e formatar listas com marcadores, de imagem, multinível e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por meio do seu formato de parágrafo.

Use a classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) para acessar as configurações de lista ao nível do parágrafo. O ponto de entrada principal é `Paragraph.getParagraphFormat().getBullet()`, que retorna um objeto [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador com imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente
- ler os marcadores e números reais da lista ao lado do texto do parágrafo

## **Criar uma Lista com Marcadores**

Para criar uma lista com marcadores, adicione objetos [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) a um [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) e defina `BulletFormat.setType` como [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Em seguida, você pode definir `BulletFormat.setChar`, `BulletFormat.getColor` e `BulletFormat.setHeight` para controlar a aparência do marcador.

O seguinte código JavaScript demonstra como criar uma lista com marcadores em um slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os símbolos de marcadores](symbol_bullets.png)

## **Criar uma Lista Numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina `BulletFormat.setType` como [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Você também pode escolher um formato de numeração com `BulletFormat.setNumberedBulletStyle` ou definir `BulletFormat.setNumberedBulletStartWith` quando a lista deve começar a partir de um valor diferente de 1.

O seguinte código JavaScript mostra como criar uma lista numerada em um slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um Marcador com Imagem**

Aspose.Slides permite substituir um símbolo de marcador regular por uma imagem. Marcadores com imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes pequenos.

{{% alert color="info" title="Note" %}}
Idealmente, se você pretende substituir o símbolo de marcador regular por uma imagem, é melhor escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Tenha em mente que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que permaneça clara e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador com imagem, adicione uma imagem ao [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) com `Presentation.getImages().addImage` e atribua o objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) retornado a `BulletFormat.getPicture().setImage`. Defina `BulletFormat.setType` como [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) antes de atribuir a imagem.

Suponha que tenhamos um "image.png":

![Uma imagem para os marcadores](picture_for_bullets.png)

O seguinte código JavaScript mostra como criar marcadores com imagem em um slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma Lista Multinível**

Use `ParagraphFormat.setDepth` para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim por diante.

O seguinte código JavaScript mostra como criar uma lista com marcadores multinível:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma Lista Existente**

Para alterar a formatação de lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações `ParagraphFormat.getBullet`. As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O seguinte código JavaScript altera o primeiro parágrafo em um quadro de texto para usar um estilo de lista numerada:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ler Valores Reais de Marcadores**

Ao extrair o conteúdo de uma apresentação, mantenha os marcadores de lista ao lado do texto do parágrafo. Chame [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) e acesse [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) para obter o formato de marcador efetivo. Verifique seu [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) antes de ler [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Para listas numeradas, distinga estes três valores:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) determina o formato, como números arábicos seguidos de ponto ou letras minúsculas seguidas de ponto.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) especifica o número inicial para um grupo de parágrafos numerados.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retorna o marcador formatado para um parágrafo específico. Por exemplo, o segundo item em uma lista que começa em 5 retorna `6.`.

Preserve [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) com cada parágrafo para manter seu nível de aninhamento. O marcador real não codifica a hierarquia completa: um item aninhado pode retornar `c.` em vez de um rótulo combinado como `6.c.`.

O seguinte exemplo autocontido cria listas, salva-as em uma apresentação e recarrega a apresentação para relatar o texto, profundidade, tipo de marcador e valor real de cada parágrafo. O pequeno marcador de imagem azul é criado a partir de SVG embutido.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Criar um marcador de imagem sem um arquivo de imagem externo.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

As listas de origem são mostradas abaixo.

![Listas iniciando em 5, itens aninhados de letra e números romanos, um marcador de símbolo, um parágrafo sem marcador e um marcador de imagem azul](actual_bullet_values.png)

O relatório corresponde aos marcadores exibidos no PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Para [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retorna `null`, não uma string vazia. Trate esses tipos separadamente: o primeiro não tem marcador, enquanto o segundo requer a extração da imagem do marcador separadamente. Um marcador com imagem não pode ser reproduzido apenas extraindo um marcador de texto.

## **FAQ**

**É possível exportar listas com marcadores e numeradas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação de lista quando o formato de destino suporta o layout de texto e os recursos de marcador correspondentes.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações `ParagraphFormat.getBullet` e salve a apresentação.

**As listas podem conter texto não‑latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportam os caracteres necessários.