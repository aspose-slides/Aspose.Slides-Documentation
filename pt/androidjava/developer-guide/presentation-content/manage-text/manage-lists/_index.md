---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações no Android
linktitle: Gerenciar Listas
type: docs
weight: 60
url: /pt/androidjava/manage-lists/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a criar e formatar listas com marcadores, imagens, multiníveis e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides for Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas através do seu formato de parágrafo.

Use o método [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) para acessar as configurações de lista no nível do parágrafo. O ponto de entrada principal é [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), que devolve um objeto [IBulletFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de listas em uma apresentação existente

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione parágrafos a um [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) e defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Symbol](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/). Em seguida, você pode definir [IBulletFormat.setChar](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#getColor--) e [IBulletFormat.setHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) para controlar a aparência do marcador.

O código Java a seguir demonstra como criar uma lista com marcadores em um slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
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

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Numbered](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/). Você também pode escolher um formato de numeração com [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ou definir [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) quando a lista deve iniciar a partir de um valor diferente de 1.

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

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador comum por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes pequenos.

{{% alert color="primary" %}}
Idealmente, se você pretende substituir o símbolo de marcador padrão por uma imagem, o melhor é escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Lembre-se de que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos enfaticamente selecionar uma imagem que continue clara e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [Presentation.getImages](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getImages--) e atribua o objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) retornado a [IBulletFormat.getPicture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Defina [IBulletFormat.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) como [BulletType.Picture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/bullettype/) antes de atribuir a imagem.

Suponha que temos um "image.png":

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

## **Criar uma lista multinível**

Use [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele, e assim por diante.

O código Java a seguir mostra como criar uma lista com marcadores multinível:

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

## **Alterar uma lista existente**

Para alterar a formatação de listas em uma apresentação existente, acesse o parágrafo desejado e atualize suas configurações de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Os mesmos métodos usados para criar listas podem ser usados para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código Java a seguir altera o primeiro parágrafo em uma caixa de texto para usar um estilo de lista numerada:

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

## **Perguntas frequentes**

**As listas com marcadores e numeradas podem ser exportadas para PDF ou imagens?**

Sim. O Aspose.Slides preserva a formatação de listas quando o formato de destino suporta o layout de texto correspondente e os recursos de marcadores.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo desejado, inspecione ou atualize suas configurações de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), e salve a apresentação.

**As listas podem conter texto não latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, portanto você pode criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportam os caracteres necessários.