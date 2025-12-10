---
title: Управление текстовыми частями в презентациях в .NET
linktitle: Текстовая часть
type: docs
weight: 70
url: /ru/net/portion/
keywords:
- текстовая часть
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять текстовыми частями в презентациях PowerPoint с помощью Aspose.Slides для .NET, повышая производительность и возможности настройки."
---

## **Получить координаты части текста**
**GetCoordinates()** метод был добавлен в IPortion и класс Portion, что позволяет получать координаты начала части:
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **Часто задаваемые вопросы**

**Можно ли применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/net/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); если и там нет, то из [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

Применяются [правила подстановки шрифтов](/slides/ru/net/font-selection-sequence/). Текст может перераспределиться: могут измениться метрики, переносы и ширина, что важно для точного позиционирования.

**Можно ли задать прозрачность или градиент заливки текста на уровне Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) могут отличаться от соседних фрагментов.