---
title: Управление текстовыми фрагментами в презентациях с использованием C++
linktitle: Текстовый фрагмент
type: docs
weight: 70
url: /ru/cpp/portion/
keywords:
- текстовый фрагмент
- текстовая часть
- координаты текста
- позиция текста
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять текстовыми фрагментами в презентациях PowerPoint с помощью Aspose.Slides для C++, повышая производительность и возможности настройки."
---

## **Получить координаты части текста**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **Вопросы и ответы**

**Могу ли я применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [присвоить гиперссылку](/slides/ru/cpp/manage-hyperlinks/) отдельному фрагменту; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано в [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/); если его нет и там, берёт из [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) или стиля [тема](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

[правила замены шрифтов](/slides/ru/cpp/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я установить прозрачность или градиент заливки текста, специфичный для Portion, независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) могут отличаться от соседних фрагментов.