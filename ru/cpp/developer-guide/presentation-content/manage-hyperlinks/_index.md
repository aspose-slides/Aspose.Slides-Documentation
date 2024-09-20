---
title: Управление гиперссылками
type: docs
weight: 20
url: /cpp/manage-hyperlinks/
keywords: "Гиперссылка PowerPoint, текстовая гиперссылка, гиперссылка на слайд, гиперссылка на фигуру, гиперссылка на изображение, гиперссылка на видео, C++"
description: "Как добавить гиперссылку в презентацию PowerPoint на C++"
---

Гиперссылка — это ссылка на объект или данные или место в чем-то. Вот обычные гиперссылки в презентациях PowerPoint:

* Ссылки на веб-сайты внутри текстов, фигур или медиа
* Ссылки на слайды

Aspose.Slides для C++ позволяет выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Вы можете ознакомиться с простым, [бесплатным онлайн редактором PowerPoint Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление гиперссылок на URL**

### **Добавление гиперссылок на URL к текстам**

Этот код на C++ показывает, как добавить гиперссылку на веб-сайт к тексту:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Добавление гиперссылок на URL к фигурам или рамкам**

Этот образец кода на C++ показывает, как добавить гиперссылку на веб-сайт к фигуре:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Добавление гиперссылок на URL к медиа**

Aspose.Slides позволяет добавлять гиперссылки на изображения, аудио и видео файлы.

Этот образец кода показывает, как добавить гиперссылку к **изображению**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Добавляет изображение в презентацию
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Создает кадр изображения на слайде 1 на основе ранее добавленного изображения
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Этот образец кода показывает, как добавить гиперссылку к **аудиофайлу**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Этот образец кода показывает, как добавить гиперссылку к **видео**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Совет"  color="primary"  %}} 

Вы можете ознакомиться с *[Управление OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, вы можете использовать их для создания оглавления.

Этот образец кода показывает, как создать оглавление с гиперссылками:

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
paragraph->set_Text(u"Заголовок слайда 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Страница 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **Форматирование гиперссылок**

### **Цвет**

С помощью методов [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) и [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink) вы можете установить цвет для гиперссылок и получить информацию о цвете из гиперссылок. Эта функция была впервые введена в PowerPoint 2019, поэтому изменения, касающиеся свойства, не применимы к более ранним версиям PowerPoint.

Этот образец кода демонстрирует операцию, где гиперссылки с разными цветами были добавлены на один и тот же слайд:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"Это пример цветной гиперссылки.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"Это пример обычной гиперссылки.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текстов**

Этот код на C++ показывает, как удалить гиперссылку из текста на слайде презентации:

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

### **Удаление гиперссылок из фигур или рамок**

Этот код на C++ показывает, как удалить гиперссылку из фигуры на слайде презентации: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) является изменяемым. С помощью этого класса вы можете изменить значения для следующих методов:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Фрагмент кода показывает, как добавить гиперссылку на слайд и изменить ее подсказку позже:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"Более 70% компаний из списка Fortune 100 доверяют API Aspose");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Поддерживаемые методы в IHyperlinkQueries**

Вы можете получить доступ к IHyperlinkQueries из презентации, слайда или текста, для которого определена гиперссылка.

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Класс IHyperlinkQueries поддерживает следующие методы: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)