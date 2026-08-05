---
title: "Продвинутое извлечение текста из презентаций на C++"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for C++. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, либо с презентациями OpenDocument (ODP), доступ к текстовым данным и их извлечение могут быть критичными для анализа, автоматизации, индексирования или миграции контента.

В этой статье представлено подробное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for C++. Вы узнаете, как систематически перебрать элементы презентации, чтобы точно получить необходимое текстовое содержимое.

## **Извлечение текста со слайда**

Aspose.Slides for C++ предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/), которое включает класс [SlideUtil](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/). Этот класс открывает несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextboxes/). Этот метод принимает объект типа [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/) в качестве параметра. При выполнении метод сканирует весь слайд в поиске текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), сохраняющий любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Извлечение текста из презентации**

Чтобы просканировать текст всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextframes/), предоставляемый классом [SlideUtil](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Во-первых, объект [IPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
1. Во-вторых, значение `Boolean`, указывающее, следует ли включать главные слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), включая информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая главные слайды.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Категоризированное и быстрое извлечение текста**

[PresentationFactory](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может быть установлен в одно из следующих значений:
- `Unarranged` — Необработанный текст без учёта его расположения на слайде.
- `Arranged` — Текст упорядочен в том же порядке, что и на слайде.

Неупорядоченный режим может использоваться, когда важна скорость; он быстрее, чем упорядоченный режим.

[IPresentationText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationtext/) представляет собой необработанный текст, извлечённый из презентации. Его метод `get_SlidesText()` возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidetext/). Каждый объект представляет текст на соответствующем слайде. Объект типа [ISlideText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidetext/) имеет следующие методы:

- `get_Text()` — Текст внутри фигур слайда.
- `get_MasterText()` — Текст внутри фигур главного слайда, связанного с этим слайдом.
- `get_LayoutText()` — Текст внутри фигур макетного слайда, связанного с этим слайдом.
- `get_NotesText()` — Текст внутри фигур слайда заметок, связанного с этим слайдом.
- `get_CommentsText()` — Текст внутри комментариев, связанных с этим слайдом.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [large presentations](/slides/ru/cpp/open-presentation/), делая его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да. Aspose.Slides может извлекать текст из многих элементов слайда, включая таблицы и объекты, связанные с диаграммами, поэтому вы можете получать доступ к текстовому содержимому и анализировать его в обычных структурах презентаций.

**Нужна ли мне специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя у неё есть [certain limitations](/slides/ru/cpp/licensing/), такие как обработка только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.