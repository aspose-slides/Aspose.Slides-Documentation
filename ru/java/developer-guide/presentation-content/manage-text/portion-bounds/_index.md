---
title: Получить границы текстовой части в презентациях Java
linktitle: Границы части
type: docs
weight: 47
url: /ru/java/portion-bounds/
keywords:
- границы текстовой части
- текстовая часть
- текстовый фрагмент
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как получить границы текстовой части в презентациях PowerPoint с помощью Aspose.Slides для Java."
---
## **Обзор**

Текстовая часть представляет собой конкретный фрагмент текста внутри абзаца и позволяет работать с этим фрагментом независимо от окружающего содержимого. В Aspose.Slides части текста могут использоваться, когда необходимо получить границы текстового фрагмента, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник части текста с помощью [IPortion.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortion#getRect--). Также показано, как получить координаты начала части текста с помощью [IPortion.getCoordinates](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortion#getCoordinates--). Кроме того, рассматриваются распространённые сценарии, связанные с частями текста, такие как применение гиперссылки к отдельному фрагменту текста, понимание того, как форматирование наследуется через часть, абзац, текстовый кадр и тему, а также обработка случаев, когда указанный шрифт недоступен.

## **Получить границы текстового фрагмента**

Используйте [IPortion.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortion#getRect--) для получения ограничивающего прямоугольника текстовой части:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Получить координаты текстового фрагмента**

Используйте [IPortion.getCoordinates](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortion#getCoordinates--) для получения координат начала текстовой части:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/java/manage-hyperlinks/) к отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяется в части текста, а что берётся из абзаца или текстового кадра?**

Свойства уровня части имеют наивысший приоритет. Если свойство не задано у [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/), Aspose.Slides берёт его из [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/). Если оно не задано и там, Aspose.Slides использует стиль [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) или [theme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/theme/).

**Что происходит, если шрифт, указанный для части текста, отсутствует на целевой машине или сервере?**

[Правила подстановки шрифтов](/slides/ru/java/font-selection-sequence/) применяются. Текст может перераспределяться: могут измениться метрики, переносы и ширина, что имеет значение для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для отдельной части независимо от остальных абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) могут отличаться от соседних фрагментов.