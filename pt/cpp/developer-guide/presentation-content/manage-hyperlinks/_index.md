---
title: Gerenciar hyperlinks de apresentação em C++
linktitle: Gerenciar Hyperlink
type: docs
weight: 20
url: /pt/cpp/manage-hyperlinks/
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
- C++
- Aspose.Slides
description: "Gerencie hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++ de forma simples — aumente a interatividade e a produtividade em minutos."
---
## **Introdução**

Um hyperlink é uma referência a um objeto, dados ou a um local em algo. Estes são hyperlinks comuns em Apresentações do PowerPoint:

* Links para sites dentro de textos, formas ou mídia
* Links para slides

Aspose.Slides for C++ permite que você execute muitas tarefas envolvendo hyperlinks em apresentações. 

{{% alert color="primary" %}} 

Você pode querer conferir o simples, [editor online gratuito de PowerPoint da Aspose.](https://products.aspose.app/slides/pt/editor)

{{% /alert %}} 

## **Adicionar Hyperlinks de URL**

### **Adicionar Hyperlinks de URL ao Texto**

Este código C++ mostra como adicionar um hyperlink de site a um texto:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Adicionar Hyperlinks de URL a Formas ou Quadros**

Este exemplo de código em C++ mostra como adicionar um hyperlink de site a uma forma:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Adicionar Hyperlinks de URL a Mídia**

Aspose.Slides permite que você adicione hyperlinks a imagens, arquivos de áudio e vídeo. 

Este exemplo de código mostra como adicionar um hyperlink a uma **imagem**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Adiciona imagem à apresentação
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Cria quadro de imagem no slide 1 com base na imagem adicionada anteriormente
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Este exemplo de código mostra como adicionar um hyperlink a um **arquivo de áudio**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Este exemplo de código mostra como adicionar um hyperlink a um **vídeo**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 

Você pode querer ver *[Gerenciar OLE](https://docs.aspose.com/slides/pt/cpp/manage-ole/)*.

{{% /alert %}}



## **Usar Hyperlinks para Criar um Índice**

Como os hyperlinks permitem adicionar referências a objetos ou locais, você pode usá‑los para criar um índice. 

Este exemplo de código mostra como criar um índice com hyperlinks:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **Formatar Hyperlinks**

### **Cor**

Com os métodos [set_ColorSource()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) e [get_ColorSource()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) da interface [IHyperlink](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink), você pode definir a cor dos hyperlinks e também obter as informações de cor dos hyperlinks. O recurso foi introduzido pela primeira vez no PowerPoint 2019, portanto alterações envolvendo a propriedade não se aplicam às versões mais antigas do PowerPoint.

Este exemplo de código demonstra uma operação onde hyperlinks com cores diferentes foram adicionados ao mesmo slide:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **Remover Hyperlinks de Apresentações**

### **Remover Hyperlinks do Texto**

Este código C++ mostra como remover o hyperlink de um texto em um slide de apresentação:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Remover Hyperlinks de Formas ou Quadros**

Este código C++ mostra como remover o hyperlink de uma forma em um slide de apresentação: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Hyperlink Mutável**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.hyperlink) é mutável. Com esta classe, você pode alterar os valores para estes métodos:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

O trecho de código mostra como adicionar um hyperlink a um slide e editar sua dica de ferramenta posteriormente:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```




## **Métodos Compatíveis em IHyperlinkQueries**

Você pode acessar IHyperlinkQueries a partir de uma apresentação, slide ou texto para o qual o hyperlink está definido. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

A classe IHyperlinkQueries suporta estes métodos: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Como posso criar navegação interna não apenas para um slide, mas para uma "seção" ou o primeiro slide de uma seção?**

Seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para "navegar para uma seção", normalmente você cria um link para o primeiro slide dela.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos do slide mestre e de layout suportam hyperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Em [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), sim—os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/cpp/convert-powerpoint-to-png/) e [vídeo](/slides/pt/cpp/convert-powerpoint-to-video/), a capacidade de clique não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hyperlinks).