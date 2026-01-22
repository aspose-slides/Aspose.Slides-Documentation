---
title: Управление текстовыми частями в презентациях на Android
linktitle: Текстовая часть
type: docs
weight: 70
url: /ru/androidjava/portion/
keywords:
- текстовая часть
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять текстовыми частями в презентациях PowerPoint с помощью Aspose.Slides для Android на Java, повышая производительность и возможности настройки."
---

## **Получить координаты части текста**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) метод был добавлен в классы [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) и [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), что позволяет получить координаты начала части.
```java
// Создать объект класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Переформирование контекста презентации
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

**Можно ли применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/androidjava/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); если и там оно не задано, из [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

Применяются [правила подстановки шрифтов](/slides/ru/androidjava/font-selection-sequence/). Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Можно ли задать прозрачность или градиент заливки текста для конкретного Portion, независимый от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) могут отличаться от соседних фрагментов.