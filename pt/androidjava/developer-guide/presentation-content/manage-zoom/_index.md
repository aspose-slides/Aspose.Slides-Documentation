---
title: Gerenciar Zoom de Apresentação no Android
linktitle: Gerenciar Zoom
type: docs
weight: 60
url: /pt/androidjava/manage-zoom/
keywords:
- zoom
- quadro de zoom
- zoom de slide
- zoom de seção
- zoom de resumo
- adicionar zoom
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie e personalize Zoom com Aspose.Slides para Android via Java — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Os Zooms no PowerPoint permitem que você vá e volte entre slides, seções e partes específicas de uma apresentação. Ao apresentar, essa capacidade de navegar rapidamente pelo conteúdo pode ser muito útil. 

![overview_image](overview.png)

* Para resumir uma apresentação inteira em um único slide, use um [Summary Zoom](#Summary-Zoom).
* Para exibir apenas slides selecionados, use um [Slide Zoom](#Slide-Zoom).
* Para exibir apenas uma única seção, use um [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Um slide zoom pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre slides em qualquer ordem que escolher, sem interromper o fluxo da apresentação. Os slide zooms são ótimos para apresentações curtas sem muitas seções, mas ainda podem ser usados em diferentes cenários de apresentação.

Os slide zooms ajudam você a aprofundar várias informações enquanto parece estar em uma única tela. 

![overview_image](slidezoomsel.png)

Para objetos de slide zoom, o Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ZoomImageType), a interface [IZoomFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IZoomFrame) e alguns métodos sob a interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).

### **Criar Quadros de Zoom**

Você pode adicionar um quadro de zoom em um slide desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie novos slides aos quais pretende vincular os quadros de zoom. 
3.	Adicione um texto de identificação e plano de fundo aos slides criados.
4.	Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona novos slides à apresentação
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Cria um plano de fundo para o segundo slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Cria uma caixa de texto para o segundo slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Cria um plano de fundo para o terceiro slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adiciona objetos ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Criar Quadros de Zoom com Imagens Personalizadas**
Com o Aspose.Slides para Android via Java, você pode criar um quadro de zoom com uma imagem de pré-visualização de slide diferente desta forma:
1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie um novo slide ao qual pretende vincular o quadro de zoom. 
3.	Adicione um texto de identificação e plano de fundo ao slide.
4.	Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que será usado para preencher o quadro.
5.	Adicione quadros de zoom (contendo a referência ao slide criado) ao primeiro slide.
6.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Cria um plano de fundo para o segundo slide
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Cria uma caixa de texto para o terceiro slide
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Cria uma nova imagem para o objeto de zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adiciona o objeto ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatar Quadros de Zoom**
Nas seções anteriores, mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um quadro de zoom. 

Você pode controlar a formatação de um quadro de zoom em um slide desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie novos slides aos quais pretende vincular o quadro de zoom. 
3.	Adicione algum texto de identificação e plano de fundo aos slides criados.
4.	Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5.	Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que será usado para preencher o quadro.
6.	Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7.	Altere a formatação da linha para o segundo objeto de quadro de zoom.
8.	Remova o plano de fundo de uma imagem do segundo objeto de quadro de zoom.
5.	Salve a apresentação modificada como um arquivo PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Adiciona novos slides à apresentação
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Cria um plano de fundo para o segundo slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Cria uma caixa de texto para o segundo slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Cria um plano de fundo para o terceiro slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adiciona objetos ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Cria uma nova imagem para o objeto de zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Define imagem personalizada para o objeto zoomFrame1
    zoomFrame1.setImage(picture);

    // Define um formato de quadro de zoom para o objeto zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Configuração para não mostrar plano de fundo para o objeto zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Section Zoom**

Um section zoom é um link para uma seção da sua apresentação. Você pode usar section zooms para voltar a seções que deseja realmente enfatizar. Ou pode usá-los para destacar como certas partes da sua apresentação se conectam. 

![overview_image](seczoomsel.png)

Para objetos de section zoom, o Aspose.Slides fornece a interface [ISectionZoomFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISectionZoomFrame) e alguns métodos sob a interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).

### **Criar Quadros de Section Zoom**

Você pode adicionar um quadro de section zoom a um slide desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie um novo slide. 
3.	Adicione um plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5.	Adicione um quadro de section zoom (contendo referências à seção criada) ao primeiro slide.
6.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    // Adiciona um objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Criar Quadros de Section Zoom com Imagens Personalizadas**

Com o Aspose.Slides para Android via Java, você pode criar um quadro de section zoom com uma imagem de pré-visualização de slide diferente desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie um novo slide.
3.	Adicione um plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5.	Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que será usado para preencher o quadro.
5.	Adicione um quadro de section zoom (contendo a referência à seção criada) ao primeiro slide.
6.	Salve a apresentação modificada como um arquivo PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Adiciona novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    // Cria uma nova imagem para o objeto de zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatar Quadros de Section Zoom**

Para criar quadros de section zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um quadro de section zoom. 

Você pode controlar a formatação de um quadro de section zoom em um slide desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie um novo slide.
3.	Adicione plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5.	Adicione um quadro de section zoom (contendo referências à seção criada) ao primeiro slide.
6.	Altere o tamanho e a posição do objeto de section zoom criado.
7.	Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPPImage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que será usado para preencher o quadro.
8.	Defina uma imagem personalizada para o objeto de quadro de section zoom criado.
9.	Defina a capacidade de *retornar ao slide original a partir da seção vinculada*. 
10.	Remova o plano de fundo de uma imagem do objeto de quadro de section zoom.
11.	Altere a formatação da linha para o segundo objeto de quadro de zoom.
12.	Altere a duração da transição.
13.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova Seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    // Adiciona objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatação para SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Summary Zoom**

Um summary zoom é como uma página de destino onde todas as partes da sua apresentação são exibidas de uma só vez. Quando você está apresentando, pode usar o zoom para ir de um ponto da apresentação a outro em qualquer ordem que desejar. Você pode ser criativo, avançar rapidamente ou revisitar partes do seu slide show sem interromper o fluxo da apresentação.

![overview_image](sumzoomsel.png)

Para objetos de summary zoom, o Aspose.Slides fornece as interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISummaryZoomSection) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) e alguns métodos sob a interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).

### **Criar um Summary Zoom**

Você pode adicionar um quadro de summary zoom a um slide desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione o quadro de summary zoom ao primeiro slide.
4.	Salve a apresentação modificada como um arquivo PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 2", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 3", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 4", slide);

    // Adiciona um objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Adicionar e Remover uma Seção de Summary Zoom**

Todas as seções em um quadro de summary zoom são representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISummaryZoomSection), que são armazenados no objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Você pode adicionar ou remover um objeto de seção de summary zoom através da interface [ISummaryZoomSectionCollection] desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione um quadro de summary zoom ao primeiro slide.
4.	Adicione um novo slide e seção à apresentação.
5.	Adicione a seção criada ao quadro de summary zoom.
6.	Remova a primeira seção do quadro de summary zoom.
7.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 2", slide);

    // Adiciona objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adiciona uma seção ao Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Remove a seção do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatar Seções de Summary Zoom**

Para criar objetos de seção de summary zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um objeto de seção de summary zoom. 

Você pode controlar a formatação de um objeto de seção de summary zoom em um quadro de summary zoom desta maneira:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione um quadro de summary zoom ao primeiro slide.
4.	Obtenha um objeto de seção de summary zoom para o primeiro objeto da `ISummaryZoomSectionCollection`.
7.	Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPPImage) adicionando uma imagem à coleção images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que será usado para preencher o quadro.
8.	Defina uma imagem personalizada para o objeto de quadro de section zoom criado.
9.	Defina a capacidade de *retornar ao slide original a partir da seção vinculada*. 
11.	Altere a formatação da linha para o segundo objeto de quadro de zoom.
12.	Altere a duração da transição.
13.	Salve a apresentação modificada como um arquivo PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adiciona uma nova seção à apresentação
    pres.getSections().addSection("Section 2", slide);

    // Adiciona um objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Obtém o primeiro objeto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //Formatação para objeto SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Salva a apresentação
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso controlar o retorno ao slide 'pai' após exibir o alvo?**

Sim. O [Zoom frame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zoomframe/) ou [section](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sectionzoomframe/) possui um comportamento de retorno ao pai que, quando habilitado, envia os espectadores de volta ao slide de origem após visitarem o conteúdo alvo.

**Posso ajustar a 'velocidade' ou a duração da transição do Zoom?**

Sim. O Zoom permite definir a duração da transição, de forma que você possa controlar quanto tempo a animação de salto leva.

**Existem limites para quantos objetos de Zoom uma apresentação pode conter?**

Não há um limite rígido de API documentado. Os limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas considere o tamanho do arquivo e o tempo de renderização.