---
title: Управление частями текста в презентациях с помощью Java
linktitle: Текстовая часть
type: docs
weight: 70
url: /ru/java/portion/
keywords:
- часть текста
- фрагмент текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять частями текста в презентациях PowerPoint с помощью Aspose.Slides для Java, повышая производительность и возможности настройки."
---

## **Получить координаты части текста**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) метод был добавлен в классы [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) и [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion), которые позволяют получить координаты начала части.
```java
// Создать объект Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Переформатировать контекст презентации
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


## **Часто задаваемые вопросы**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [привязать гиперссылку](/slides/ru/java/manage-hyperlinks/) к отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); если оно не задано и там, — из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

[Правила замены шрифтов](/slides/ru/java/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) могут отличаться от соседних фрагментов.