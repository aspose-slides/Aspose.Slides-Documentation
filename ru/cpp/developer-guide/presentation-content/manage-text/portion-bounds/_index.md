---
title: Получить границы текстовой части из презентаций в C++
linktitle: Границы части
type: docs
weight: 47
url: /ru/cpp/portion-bounds/
keywords:
- границы текстовой части
- текстовая часть
- текстовый фрагмент
- координаты текста
- позиция текста
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как получить границы текстовой части в презентациях PowerPoint с помощью Aspose.Slides для C++."
---
## **Обзор**

Текстовая часть представляет собой конкретный фрагмент текста внутри абзаца и позволяет работать с этим фрагментом независимо от окружающего содержимого. В Aspose.Slides части можно использовать, когда необходимо получить границы текстового фрагмента, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник части, используя [IPortion::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/getrect/). Также показано, как получить координаты начала части, используя [IPortion::GetCoordinates](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/getcoordinates/). Кроме того, рассматриваются распространённые сценарии, связанные с частями, такие как применение гиперссылки к отдельному текстовому фрагменту, понимание того, как форматирование наследуется через часть, абзац, текстовый кадр и тему, а также обработка случаев, когда указанный шрифт недоступен.

## **Получение границ текстовой части**

Используйте [IPortion::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/getrect/) для получения ограничивающего прямоугольника текстовой части:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Получение координат текстовой части**

Используйте [IPortion::GetCoordinates](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/getcoordinates/) для получения координат начала текстовой части:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Можно ли применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [назначить гиперссылку](/slides/ru/cpp/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет часть, а что берётся из абзаца или текстового кадра?**

Свойства уровня части имеют наивысший приоритет. Если свойство не задано в [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/), Aspose.Slides берёт его из [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/). Если оно не задано и там, Aspose.Slides использует стиль [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) или [theme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для части, отсутствует на целевой машине или сервере?**

[Правила подстановки шрифтов](/slides/ru/cpp/font-selection-sequence/) применяются. Текст может перераспределяться: метрики, переносы и ширина могут измениться, что актуально для точного позиционирования.

**Можно ли задать прозрачность заливки текста или градиент, специфичные для части, независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) могут отличаться от соседних фрагментов.