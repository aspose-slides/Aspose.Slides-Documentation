---
title: Gerenciar Zoom de Apresentação em JavaScript
linktitle: Gerenciar Zoom
type: docs
weight: 60
url: /pt/nodejs-java/manage-zoom/
keywords:
- zoom
- quadro de zoom
- zoom de slide
- zoom de seção
- zoom de resumo
- adicionar zoom
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e personalize Zoom com Aspose.Slides para Node.js — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Os zooms no PowerPoint permitem que você vá para slides, seções e partes específicas de uma apresentação e retorne deles. Ao apresentar, essa capacidade de navegar rapidamente pelo conteúdo pode ser muito útil. 

![overview_image](overview.png)

* Para resumir toda a apresentação em um único slide, use um [Zoom de Resumo](#Summary-Zoom).
* Para exibir apenas slides selecionados, use um [Zoom de Slide](#Slide-Zoom).
* Para exibir apenas uma única seção, use um [Zoom de Seção](#Section-Zoom).

## **Zoom de Slide**

Um zoom de slide pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre slides em qualquer ordem que escolher sem interromper o fluxo da sua apresentação. Os zooms de slide são ótimos para apresentações curtas sem muitas seções, mas você ainda pode usá-los em diferentes cenários de apresentação.

Os zooms de slide ajudam a aprofundar várias informações enquanto você sente que está em uma única tela. 

![overview_image](slidezoomsel.png)

Para objetos de zoom de slide, o Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ZoomImageType), a classe [ZoomFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ZoomFrame) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).

### **Criando Quadros de Zoom**

Você pode adicionar um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie novos slides aos quais pretende vincular os quadros de zoom. 
3. Adicione um texto de identificação e plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona novos slides à apresentação
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Cria um plano de fundo para o segundo slide
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Cria uma caixa de texto para o segundo slide
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Cria um plano de fundo para o terceiro slide
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Adiciona objetos ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando Quadros de Zoom com Imagens Personalizadas**

Com o Aspose.Slides for Node.js via Java, você pode criar um quadro de zoom com uma imagem de pré‑visualização de slide diferente desta forma:
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie um novo slide ao qual pretende vincular o quadro de zoom. 
3. Adicione um texto de identificação e plano de fundo ao slide.
4. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que será usada para preencher o quadro.
5. Adicione quadros de zoom (contendo a referência ao slide criado) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Cria um plano de fundo para o segundo slide
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Cria uma caixa de texto para o terceiro slide
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Cria uma nova imagem para o objeto zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona o objeto ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatando Quadros de Zoom**

Nas seções anteriores, mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom. 

Você pode controlar a formatação de um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie novos slides aos quais pretende vincular o quadro de zoom. 
3. Adicione algum texto de identificação e plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que será usada para preencher o quadro.
6. Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7. Altere o formato da linha para o segundo objeto de quadro de zoom.
8. Remova o plano de fundo de uma imagem do segundo objeto de quadro de zoom.
5. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona novos slides à apresentação
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Cria um plano de fundo para o segundo slide
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Cria uma caixa de texto para o segundo slide
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Cria um plano de fundo para o terceiro slide
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Adiciona objetos ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Cria uma nova imagem para o objeto zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Define imagem personalizada para o objeto zoomFrame1
    zoomFrame1.setImage(picture);
    // Define o formato do quadro de zoom para o objeto zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Configuração para não exibir plano de fundo no objeto zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom de Seção**

Um zoom de seção é um link para uma seção da sua apresentação. Você pode usar zooms de seção para voltar a seções que deseja realmente enfatizar. Ou pode usá-los para destacar como certas partes da sua apresentação se conectam. 

![overview_image](seczoomsel.png)

Para objetos de zoom de seção, o Aspose.Slides fornece a classe [SectionZoomFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SectionZoomFrame) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).

### **Criando Quadros de Zoom de Seção**

Você pode adicionar um quadro de zoom de seção a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie um novo slide. 
3. Adicione um plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Adiciona um objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando Quadros de Zoom de Seção com Imagens Personalizadas**

Usando o Aspose.Slides for Node.js via Java, você pode criar um quadro de zoom de seção com uma imagem de pré‑visualização de slide diferente desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie um novo slide.
3. Adicione um plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que será usada para preencher o quadro.
5. Adicione um quadro de zoom de seção (contendo uma referência à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Cria uma nova imagem para o objeto zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona um objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatando Quadros de Zoom de Seção**

Para criar quadros de zoom de seção mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom de seção. 

Você pode controlar a formatação de um quadro de zoom de seção em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie um novo slide.
3. Adicione plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Altere o tamanho e a posição do objeto de zoom de seção criado.
7. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que será usada para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original a partir da seção vinculada*. 
10. Remova o plano de fundo de uma imagem do objeto de zoom de seção.
11. Altere o formato da linha para o segundo objeto de quadro de zoom.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Adiciona objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formatação para SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom de Resumo**

Um zoom de resumo é como uma página de destino onde todas as partes da sua apresentação são exibidas de uma vez. Quando você está apresentando, pode usar o zoom para ir de um ponto da apresentação a outro em qualquer ordem que desejar. Você pode ser criativo, avançar ou revisitar partes da sua apresentação sem interromper o fluxo.

![overview_image](sumzoomsel.png)

Para objetos de zoom de resumo, o Aspose.Slides fornece as classes [SummaryZoomFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SummaryZoomSection) e [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SummaryZoomSectionCollection) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).

### **Criando Zoom de Resumo**

Você pode adicionar um quadro de zoom de resumo a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione o quadro de zoom de resumo ao primeiro slide.
4. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 2", slide);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 3", slide);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 4", slide);
    // Adiciona um objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Adicionando e Removendo Seção de Zoom de Resumo**

Todas as seções em um quadro de zoom de resumo são representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SummaryZoomSection), que são armazenados no objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Você pode adicionar ou remover um objeto de seção de zoom de resumo através da classe [SummaryZoomSectionCollection] desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Adicione um novo slide e seção à apresentação.
5. Adicione a seção criada ao quadro de zoom de resumo.
6. Remova a primeira seção do quadro de zoom de resumo.
7. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 2", slide);
    // Adiciona objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova seção à apresentação
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Adiciona uma seção ao Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Remove seção do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatando Seções de Zoom de Resumo**

Para criar objetos de seção de zoom de resumo mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um objeto de seção de zoom de resumo. 

Você pode controlar a formatação de um objeto de seção de zoom de resumo em um quadro de zoom de resumo desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Obtenha um objeto de seção de zoom de resumo para o primeiro objeto da `ISummaryZoomSectionCollection`.
7. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à coleção images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que será usada para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original a partir da seção vinculada*. 
11. Altere o formato da linha para o segundo objeto de quadro de zoom.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um novo slide à apresentação
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 1", slide);
    // Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 2", slide);
    // Adiciona um objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Obtém o primeiro objeto SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formatação para objeto SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Salva a apresentação
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Posso controlar o retorno ao slide “pai” após exibir o alvo?**

Sim. O [Zoom frame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zoomframe/) ou [section](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectionzoomframe/) possui um método `setReturnToParent` que, quando habilitado, envia o espectador de volta ao slide de origem após visitar o conteúdo alvo.

**Posso ajustar a “velocidade” ou a duração da transição do Zoom?**

Sim. O Zoom expõe um método `setTransitionDuration` para que você possa controlar quanto tempo a animação de salto leva.

**Existem limites de quantos objetos Zoom uma apresentação pode conter?**

Não há um limite rígido de API documentado. Limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas considere o tamanho do arquivo e o tempo de renderização.