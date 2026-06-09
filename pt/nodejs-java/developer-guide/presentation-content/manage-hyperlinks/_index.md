---
title: Gerenciar hyperlinks de apresentação em JavaScript
linktitle: Gerenciar hyperlink
type: docs
weight: 20
url: /pt/nodejs-java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie hyperlinks em apresentações PowerPoint e OpenDocument com facilidade usando Aspose.Slides para Node.js—melhore a interatividade e o fluxo de trabalho em minutos."
---
## **Introdução**

Um hyperlink é uma referência a um objeto, dado ou um local em algo. Estes são hyperlinks comuns em apresentações do PowerPoint:

* Links para sites dentro de textos, formas ou mídia
* Links para slides

Aspose.Slides for Node.js via Java permite que você execute muitas tarefas envolvendo hyperlinks em apresentações.

{{% alert color="primary" %}} 

Você pode querer conferir o simples Aspose, [editor online gratuito de PowerPoint.](https://products.aspose.app/slides/pt/editor)

{{% /alert %}} 

## **Adicionando hyperlinks de URL**

### **Adicionando hyperlinks de URL a textos**

Este código JavaScript mostra como adicionar um hyperlink de site a um texto:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Adicionando hyperlinks de URL a formas ou quadros**

Este código de exemplo em JavaScript mostra como adicionar um hyperlink de site a uma forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Adicionando hyperlinks de URL a mídia**

Aspose.Slides permite que você adicione hyperlinks a imagens, arquivos de áudio e vídeo. 

Este código de exemplo mostra como adicionar um hyperlink a uma **imagem**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona imagem à apresentação
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Cria quadro de imagem no slide 1 com base na imagem adicionada anteriormente
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este código de exemplo mostra como adicionar um hyperlink a um **arquivo de áudio**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este código de exemplo mostra como adicionar um hyperlink a um **vídeo**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 

Você pode querer ver *[Gerenciar OLE](/slides/pt/nodejs-java/manage-ole/)*.

{{% /alert %}}

## **Usando hyperlinks para criar sumário**

Como os hyperlinks permitem adicionar referências a objetos ou locais, você pode usá-los para criar um sumário. 

Este código de exemplo mostra como criar um sumário com hyperlinks:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Formatando hyperlinks**

### **Cor**

Com o método [setColorSource](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) na classe [Hyperlink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink), você pode definir a cor dos hyperlinks e também obter as informações de cor dos hyperlinks. O recurso foi introduzido pela primeira vez no PowerPoint 2019, portanto alterações envolvendo a propriedade não se aplicam a versões mais antigas do PowerPoint.

Este código de exemplo demonstra uma operação onde hyperlinks com cores diferentes foram adicionados ao mesmo slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Removendo hyperlinks em apresentações**

### **Removendo hyperlinks de textos**

Este código JavaScript mostra como remover o hyperlink de um texto em um slide de apresentação:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Verifica se a forma suporta quadro de texto (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Itera pelos parágrafos no quadro de texto
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Itera por cada porção no parágrafo
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Altera o texto
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Altera a formatação
                    }
                }
            }
        }
    }
    // Salva a apresentação modificada
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Removendo hyperlinks de formas ou quadros**

Este código JavaScript mostra como remover o hyperlink de uma forma em um slide de apresentação:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hyperlink mutável**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink) é mutável. Com esta classe, você pode alterar os valores dessas propriedades:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

O snippet de código mostra como adicionar um hyperlink a um slide e editar sua dica de ferramenta posteriormente:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Propriedades suportadas em IHyperlinkQueries**

Você pode acessar [HyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries) a partir de uma apresentação, slide ou texto para o qual o hyperlink está definido.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries) suporta estes métodos e propriedades:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Perguntas frequentes**

**Como posso criar navegação interna não apenas para um slide, mas para uma "seção" ou o primeiro slide de uma seção?**

Seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para "navegar para uma seção", normalmente você vincula ao seu primeiro slide.

**Posso anexar um hyperlink a elementos de slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e de layout suportam hyperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Em [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), sim—os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/nodejs-java/convert-powerpoint-to-png/) e [vídeo](/slides/pt/nodejs-java/convert-powerpoint-to-video/), a capacidade de clique não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hyperlinks).