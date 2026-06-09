---
title: Gerenciar Zoom de Apresentação no .NET
linktitle: Gerenciar Zoom
type: docs
weight: 60
url: /pt/net/manage-zoom/
keywords:
- zoom
- quadro de zoom
- zoom de slide
- zoom de seção
- zoom de resumo
- adicionar zoom
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize o Zoom com Aspose.Slides para .NET — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Zooms no PowerPoint permitem que você vá e volte a slides, seções e partes específicas de uma apresentação. Ao apresentar, essa capacidade de navegar rapidamente pelo conteúdo pode ser muito útil. 

![overview_image](overview.png)

* Para resumir toda a apresentação em um único slide, use um [Summary Zoom](#Summary-Zoom).
* Para mostrar apenas slides selecionados, use um [Slide Zoom](#Slide-Zoom).
* Para mostrar apenas uma única seção, use um [Section Zoom](#Section-Zoom).

## **Zoom de Slide**
Um zoom de slide pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre slides em qualquer ordem que escolher sem interromper o fluxo da apresentação. Os zooms de slide são ótimos para apresentações curtas sem muitas seções, mas ainda podem ser usados em diferentes cenários de apresentação.

Os zooms de slide ajudam a aprofundar múltiplas informações enquanto você sente que está em uma única tela. 

![overview_image](slidezoomsel.png)

Para objetos de zoom de slide, o Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/net/aspose.slides/zoomimagetype), a interface [IZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/izoomframe) e alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection).

### **Criar Quadros de Zoom**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie novos slides aos quais pretende vincular os quadros de zoom. 
3. Adicione um texto de identificação e um plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona novos slides à apresentação
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Cria um plano de fundo para o segundo slide
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Cria uma caixa de texto para o segundo slide
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Cria um plano de fundo para o terceiro slide
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adiciona objetos ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Criar Quadros de Zoom com Imagens Personalizadas**
Com Aspose.Slides para .NET, você pode criar um quadro de zoom com uma imagem de pré‑visualização de slide diferente desta forma: 
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie um novo slide ao qual pretende vincular o quadro de zoom. 
3. Adicione um texto de identificação e um plano de fundo ao slide.
4. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que será usado para preencher o quadro.
5. Adicione quadros de zoom (contendo a referência ao slide criado) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Cria um plano de fundo para o segundo slide
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Cria uma caixa de texto para o terceiro slide
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Cria uma nova imagem para o objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Adiciona o objeto ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatar Quadros de Zoom**
Nas seções anteriores, mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um quadro de zoom. 

Você pode controlar a formatação de um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie novos slides para os quais pretende vincular o quadro de zoom. 
3. Adicione algum texto de identificação e plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que será usado para preencher o quadro.
6. Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7. Altere o formato da linha para o segundo objeto de quadro de zoom.
8. Remova o plano de fundo de uma imagem do segundo objeto de quadro de zoom.
5. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona novos slides à apresentação
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Cria um plano de fundo para o segundo slide
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Cria uma caixa de texto para o segundo slide
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Cria um plano de fundo para o terceiro slide
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Cria uma caixa de texto para o terceiro slide
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adiciona objetos ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Cria uma nova imagem para o objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Define imagem personalizada para o objeto zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Define um formato de quadro de zoom para o objeto zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Configuração para não mostrar o plano de fundo para o objeto zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom de Seção**

Um zoom de seção é um link para uma seção em sua apresentação. Você pode usar zooms de seção para voltar a seções que deseja realmente enfatizar. Ou pode usá-los para destacar como certas partes da sua apresentação se conectam. 

![overview_image](seczoomsel.png)

Para objetos de zoom de seção, o Aspose.Slides fornece a interface [ISectionZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/isectionzoomframe) e alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection).

### **Criar Quadros de Zoom de Seção**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie um novo slide. 
3. Adicione um plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova Seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    // Adiciona um objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Criar Quadros de Zoom de Seção com Imagens Personalizadas**

Usando Aspose.Slides para .NET, você pode criar um quadro de zoom de seção com uma imagem de pré‑visualização de slide diferente desta forma: 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie um novo slide.
3. Adicione um plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que será usado para preencher o quadro.
5. Adicione um quadro de zoom de seção (contendo uma referência à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova Seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    // Cria uma nova imagem para o objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adiciona um objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatar Quadros de Zoom de Seção**

Para criar quadros de zoom de seção mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um quadro de zoom de seção. 

Você pode controlar a formatação de um quadro de zoom de seção em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie um novo slide.
3. Adicione um plano de fundo de identificação ao slide criado.
4. Crie uma nova seção à qual pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Altere o tamanho e a posição do objeto de zoom de seção criado.
7. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que será usado para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original da seção vinculada*. 
10. Remova o plano de fundo de uma imagem do objeto de quadro de zoom de seção.
11. Altere o formato da linha para o segundo objeto de quadro de zoom.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova Seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    // Adiciona objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatação para SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom de Resumo**

Um zoom de resumo funciona como uma página inicial onde todas as partes da sua apresentação são exibidas de uma vez. Quando você está apresentando, pode usar o zoom para ir de um ponto da apresentação a outro em qualquer ordem que desejar. Você pode ser criativo, pular adiante ou revisitar partes da sua apresentação sem interromper o fluxo.

![overview_image](sumzoomsel.png)

Para objetos de zoom de resumo, o Aspose.Slides fornece as interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomsection) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomsectioncollection) e alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection).

### **Criar um Zoom de Resumo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione o quadro de zoom de resumo ao primeiro slide.
4. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 2", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 3", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 4", slide);

    // Adiciona um objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Adicionar e Remover uma Seção de Zoom de Resumo**

Todas as seções em um quadro de zoom de resumo são representadas por objetos [ISummaryZoomFrameSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomsection), que são armazenados no objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomsectioncollection). Você pode adicionar ou remover um objeto de seção de zoom de resumo através da interface [ISummaryZoomSectionCollection] desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Adicione um novo slide e uma nova seção à apresentação.
5. Adicione a seção criada ao quadro de zoom de resumo.
6. Remova a primeira seção do quadro de zoom de resumo.
7. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 2", slide);

    // Adiciona objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Adiciona uma seção ao Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Remove a seção do Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatar Seções de Zoom de Resumo**

Para criar objetos de seção de zoom de resumo mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que podem ser aplicadas a um objeto de seção de zoom de resumo. 

Você pode controlar a formatação de um objeto de seção de zoom de resumo em um quadro de zoom de resumo desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Obtenha um objeto de seção de zoom de resumo para o primeiro objeto da `ISummaryZoomSectionCollection`.
7. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à coleção images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que será usado para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original da seção vinculada*. 
11. Altere o formato da linha para o segundo objeto de quadro de zoom.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adiciona um novo slide à apresentação
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 1", slide);

    //Adiciona um novo slide à apresentação
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adiciona uma nova seção à apresentação
    pres.Sections.AddSection("Section 2", slide);

    // Adiciona objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Obtém o primeiro objeto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formatação para o objeto SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Salva a apresentação
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso controlar o retorno ao slide 'pai' após mostrar o alvo?**

Sim. O [Zoom frame](https://reference.aspose.com/slides/pt/net/aspose.slides/zoomframe/) ou [section](https://reference.aspose.com/slides/pt/net/aspose.slides/sectionzoomframe/) tem um comportamento `ReturnToParent` que, quando habilitado, envia os visualizadores de volta ao slide de origem depois que eles visitam o conteúdo alvo.

**Posso ajustar a 'velocidade' ou duração da transição do Zoom?**

Sim. O Zoom suporta a definição de um `TransitionDuration` para que você possa controlar quanto tempo a animação de salto leva.

**Existem limites para a quantidade de objetos Zoom que uma apresentação pode conter?**

Não há um limite rígido de API documentado. Os limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas considere o tamanho do arquivo e o tempo de renderização.