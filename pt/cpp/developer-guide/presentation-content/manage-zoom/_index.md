---
title: Gerenciar Zoom de Apresentação em C++
linktitle: Gerenciar Zoom
type: docs
weight: 60
url: /pt/cpp/manage-zoom/
keywords:
- zoom
- quadro de zoom
- zoom de slide
- zoom de seção
- zoom de resumo
- adicionar zoom
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e personalize o Zoom com Aspose.Slides para C++ — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Os Zooms no PowerPoint permitem que você salte para e de slides, seções e partes específicas de uma apresentação. Ao apresentar, essa capacidade de navegação rápida pelo conteúdo pode ser muito útil. 

![overview_image](Overview.png)

* Para resumir toda a apresentação em um único slide, use um [Summary Zoom](#Summary-Zoom).
* Para mostrar apenas os slides selecionados, use um [Slide Zoom](#Slide-Zoom).
* Para mostrar apenas uma única seção, use um [Section Zoom](#Section-Zoom).

## **Zoom de Slide**
Um zoom de slide pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre os slides em qualquer ordem que escolher, sem interromper o fluxo da apresentação. Os zooms de slide são ótimos para apresentações curtas sem muitas seções, mas ainda podem ser usados em diferentes cenários de apresentação.

Os zooms de slide ajudam a aprofundar várias informações enquanto você tem a sensação de estar em uma única tela. 

![overview_image](slidezoomsel.png)

Para objetos de zoom de slide, o Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/zoomimagetype/), a interface [IZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/izoomframe/) e alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/).

### **Criar Quadros de Zoom**

Você pode adicionar um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie novos slides aos quais você pretende vincular os quadros de zoom. 
3. Adicione um texto de identificação e fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Grave a apresentação modificada como um arquivo PPTX.

Este código C++ mostra como criar um quadro de zoom em um slide:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona novos slides à apresentação
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Cria um fundo para o segundo slide
SetSlideBackground(slide2, Color::get_Cyan());

// Cria uma caixa de texto para o segundo slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Cria um fundo para o terceiro slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Cria uma caixa de texto para o terceiro slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adiciona objetos ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Criar Quadros de Zoom com Imagens Personalizadas**
Com o Aspose.Slides para C++, você pode criar um quadro de zoom com uma imagem de visualização de slide diferente desta forma: 
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie um novo slide ao qual você pretende vincular o quadro de zoom. 
3. Adicione um texto de identificação e fundo ao slide.
4. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que será usada para preencher o quadro.
5. Adicione quadros de zoom (contendo a referência ao slide criado) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

Este código C++ mostra como criar um quadro de zoom com uma imagem diferente:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Cria um fundo para o segundo slide
SetSlideBackground(slide, Color::get_Cyan());

// Cria uma caixa de texto para o terceiro slide
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Cria uma nova imagem para o objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Adiciona o objeto ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatar Quadros de Zoom**
Nas seções anteriores, mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complexos, é necessário alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom. 

Você pode controlar a formatação de um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie novos slides aos quais você pretende vincular o quadro de zoom. 
3. Adicione algum texto de identificação e fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que será usada para preencher o quadro.
6. Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7. Altere o formato da linha para o segundo objeto de quadro de zoom.
8. Remova o fundo de uma imagem do segundo objeto de quadro de zoom.
9. Grave a apresentação modificada como um arquivo PPTX.

Este código C++ mostra como mudar a formatação de um quadro de zoom em um slide: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Adiciona novos slides à apresentação
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Cria um fundo para o segundo slide
SetSlideBackground(slide2, Color::get_Cyan());

// Cria uma caixa de texto para o segundo slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Cria um fundo para o terceiro slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Cria uma caixa de texto para o terceiro slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adiciona objetos ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Cria uma nova imagem para o objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Define imagem personalizada para o objeto zoomFrame1
zoomFrame1->set_Image(image);

// Define um formato de quadro de zoom para o objeto zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Configuração para não mostrar o fundo do objeto zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom de Seção**

Um zoom de seção é um link para uma seção da sua apresentação. Você pode usar zooms de seção para voltar a seções que deseja realmente enfatizar. Ou pode usá-los para destacar como determinadas partes da sua apresentação se conectam. 

![overview_image](seczoomsel.png)

Para objetos de zoom de seção, o Aspose.Slides fornece a interface [ISectionZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectionzoomframe/) e alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/).

### **Criar Quadros de Zoom de Seção**

Você pode adicionar um quadro de zoom de seção a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie um novo slide. 
3. Adicione um fundo de identificação ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adiciona uma nova Seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

// Adiciona um objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Criar Quadros de Zoom de Seção com Imagens Personalizadas**

Usando o Aspose.Slides para C++, você pode criar um quadro de zoom de seção com uma imagem de visualização de slide diferente desta forma: 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie um novo slide.
3. Adicione um fundo de identificação ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que será usada para preencher o quadro.
6. Adicione um quadro de zoom de seção (contendo uma referência à seção criada) ao primeiro slide.
7. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adiciona uma nova Seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

//Cria uma nova imagem para o objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Adiciona objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatar Quadros de Zoom de Seção**

Para criar quadros de zoom de seção mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom de seção. 

Você pode controlar a formatação de um quadro de zoom de seção em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie um novo slide.
3. Adicione fundo de identificação ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Altere o tamanho e a posição do objeto de zoom de seção criado.
7. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que será usada para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original da seção vinculada*. 
10. Remova o fundo de uma imagem do objeto de quadro de zoom de seção.
11. Altere o formato da linha para o segundo objeto de quadro de zoom.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adiciona uma nova Seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

// Adiciona objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formatação para SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom de Resumo**

Um zoom de resumo funciona como uma página de destino onde todas as partes da sua apresentação são exibidas de uma vez. Ao apresentar, você pode usar o zoom para ir de um ponto da sua apresentação a outro, na ordem que desejar. Você pode ser criativo, avançar ou revisitar partes da sua apresentação sem interromper o fluxo da mesma.

![overview_image](sumzoomsel.png)

Para objetos de zoom de resumo, o Aspose.Slides fornece as interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomsection/) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomsectioncollection/), além de alguns métodos da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/).

### **Criar Zoom de Resumo**

Você pode adicionar um quadro de zoom de resumo a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie novos slides com fundo de identificação e novas seções para os slides criados.
3. Adicione o quadro de zoom de resumo ao primeiro slide.
4. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

// Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 3", slide);

// Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 4", slide);

// Adiciona um objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Adicionar e Remover uma Seção de Zoom de Resumo**

Todas as seções em um quadro de zoom de resumo são representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomsection/), que são armazenados no objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomsectioncollection/). Você pode adicionar ou remover um objeto de seção de zoom de resumo através da interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomsectioncollection/) desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie novos slides com fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Adicione um novo slide e uma nova seção à apresentação.
5. Adicione a seção criada ao quadro de zoom de resumo.
6. Remova a primeira seção do quadro de zoom de resumo.
7. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adiciona objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Adiciona uma nova seção à apresentação
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Adiciona uma seção ao Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Remove seção do Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatar Seções de Zoom de Resumo**

Para criar objetos de seção de zoom de resumo mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um objeto de seção de zoom de resumo. 

Você pode controlar a formatação de um objeto de seção de zoom de resumo em um quadro de zoom de resumo desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Crie novos slides com fundo de identificação e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Obtenha um objeto de seção de zoom de resumo para o primeiro objeto da `ISummaryZoomSectionCollection`.
5. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) adicionando uma imagem à coleção images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que será usada para preencher o quadro.
6. Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
7. Defina a capacidade de *retornar ao slide original da seção vinculada*. 
8. Altere o formato da linha para o segundo objeto de quadro de zoom.
9. Altere a duração da transição.
10. Grave a apresentação modificada como um arquivo PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adiciona um novo slide à apresentação
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adiciona um novo slide à apresentação
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Adiciona uma nova seção à apresentação
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adiciona um objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Obtém o primeiro objeto SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatação para o objeto SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Salva a apresentação
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso controlar o retorno ao slide 'pai' após exibir o destino?**

Sim. O [Zoom frame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/zoomframe/) ou a [section](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sectionzoomframe/) possui um método `set_ReturnToParent` que devolve os visualizadores ao slide de origem após visitarem o conteúdo alvo.

**Posso ajustar a 'velocidade' ou duração da transição do Zoom?**

Sim. O Zoom permite definir a duração da transição, permitindo controlar quanto tempo a animação de salto leva.

**Existem limites para a quantidade de objetos Zoom que uma apresentação pode conter?**

Não há um limite rígido de API documentado. Os limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas considere o tamanho do arquivo e o tempo de renderização.