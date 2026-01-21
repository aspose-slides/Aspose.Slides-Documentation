---
title: Управление текстовыми фрагментами в презентациях с использованием Java
linktitle: Текстовый фрагмент
type: docs
weight: 70
url: /ru/java/portion/
keywords:
- текстовый фрагмент
- текстовая часть
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять текстовыми фрагментами в презентациях PowerPoint с помощью Aspose.Slides для Java, повышая производительность и возможности настройки."
---

## **Получить координаты части текста**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) метод был добавлен в классы [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) и [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), что позволяет получать координаты начала части.
```java
// Создать объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Изменение контекста презентации
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [присвоить гиперссылку](/slides/ru/java/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) имеют наивысший приоритет. Если свойство не задано на [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); если и там оно не задано, — из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/).

**Что происходит, если указанный для Portion шрифт отсутствует на целевой машине/сервере?**

[правила замены шрифтов](/slides/ru/java/font-selection-sequence/) применяются. Текст может перераспределиться: могут измениться метрики, переносы и ширина, что важно для точного позиционирования.

**Могу ли я задать прозрачность или градиент заливки текста для конкретного Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) могут отличаться от соседних фрагментов.