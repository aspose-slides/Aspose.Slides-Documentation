---
title: Часть
type: docs
weight: 70
url: /ru/net/portion/
keywords: "Portion, Форма PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Получить часть в презентации PowerPoint на C# или .NET"
---

## **Получить координаты позиции части**
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

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); если не задано и там, из [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевом компьютере/сервере?**

[Правила подстановки шрифтов](/slides/ru/net/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Можно ли задать прозрачность заливки текста или градиент для конкретного Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) могут отличаться от соседних фрагментов.