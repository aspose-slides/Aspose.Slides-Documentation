---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações em Java
linktitle: Gerenciar Listas
type: docs
weight: 60
url: /pt/java/manage-lists/
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
- Java
- Aspose.Slides
description: "Aprenda a criar e formatar listas com marcadores, imagem, multinível e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Java."
---
## **Visão geral**

Aspose.Slides for Java permite que você crie e formate listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por meio de seu formato de parágrafo.

Use o método [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph/#getParagraphFormat--) para acessar as configurações de lista ao nível do parágrafo. O ponto de entrada principal é [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getBullet--), que retorna um objeto [IBulletFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente

## **Criar uma Lista com Marcadores**

Para criar uma lista com marcadores, adicione objetos [IParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph/) a um [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) e defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Symbol](https://reference.aspose.com/slides/pt/java/com.aspose.slides/bullettype/#Symbol). Em seguida, você pode definir [IBulletFormat.setChar](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#getColor--) e [IBulletFormat.setHeight](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setHeight-float-) para controlar a aparência do marcador.

O código Java a seguir demonstra como criar uma lista com marcadores em um slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores de símbolo](symbol_bullets.png)

## **Criar uma Lista Numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Numbered](https://reference.aspose.com/slides/pt/java/com.aspose.slides/bullettype/#Numbered). Você também pode escolher um formato de numeração com [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ou definir [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) quando a lista deve começar a partir de um valor diferente de 1.

O código Java a seguir mostra como criar uma lista numerada em um slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um Marcador de Imagem**

Aspose.Slides permite substituir um símbolo de marcador padrão por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes pequenos.

{{% alert color="primary" %}}
Idealmente, se você planeja substituir o símbolo de marcador padrão por uma imagem, é melhor escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Lembre-se de que a imagem será reduzida para um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que permaneça nítida e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [Presentation.getImages](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getImages--) e atribua o objeto de imagem retornado a [IBulletFormat.getPicture](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#getPicture--). Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Picture](https://reference.aspose.com/slides/pt/java/com.aspose.slides/bullettype/#Picture) antes de atribuir a imagem.

Digamos que temos um "image.png":

![Uma imagem para os marcadores](picture_for_bullets.png)

O código Java a seguir mostra como criar marcadores de imagem em um slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma Lista Multinível**

Use [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele, e assim por diante.

O código Java a seguir mostra como criar uma lista de marcadores multinível:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma Lista Existente**

Para alterar a formatação de lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getBullet--). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**É possível exportar listas com marcadores e numeradas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação da lista quando o formato de destino oferece suporte ao layout de texto e aos recursos de marcadores correspondentes.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getBullet--), e salve a apresentação.

**As listas podem conter texto não latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportem os caracteres necessários.