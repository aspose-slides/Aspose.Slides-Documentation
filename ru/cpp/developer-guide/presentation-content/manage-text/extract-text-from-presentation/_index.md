---
title: Продвинутое извлечение текста из презентаций на C++
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/cpp/extract-text-from-presentation/
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
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for C++. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важным для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено подробное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for C++. Вы узнаете, как систематически проходить элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for C++ предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/), которое включает класс [SlideUtil](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/). Этот класс раскрывает несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextboxes/). Этот метод принимает объект типа [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/) в качестве параметра. При выполнении метод сканирует весь слайд на наличие текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), сохраняя любое форматирование текста.

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

Чтобы просканировать текст всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextframes/) класса [SlideUtil](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Во‑первых, объект [IPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
2. Во‑вторых, значение `Boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), включающий сведения о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования во всей презентации, включая мастер‑слайды.

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

## **Категоризованное и быстрое извл