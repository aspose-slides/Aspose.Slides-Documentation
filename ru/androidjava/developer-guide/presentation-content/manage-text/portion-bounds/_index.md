---
title: Получить границы текстового фрагмента из презентаций на Android
linktitle: Границы фрагмента
type: docs
weight: 47
url: /ru/androidjava/portion-bounds/
keywords:
- границы текстового фрагмента
- текстовый фрагмент
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как получать границы текстовых фрагментов в презентациях PowerPoint с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Текстовый фрагмент представляет собой определённый кусок текста внутри абзаца и позволяет работать с этим куском независимо от окружающего содержимого. В Aspose.Slides фрагменты могут использоваться, когда необходимо получить границы текстового фрагмента, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник фрагмента, используя [IPortion.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPortion#getRect--). Также показано, как получить координаты начала фрагмента, используя [IPortion.getCoordinates](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPortion#getCoordinates--). Кроме того, рассматриваются типичные сценарии работы с фрагментами, такие как применение гиперссылки к отдельному куску текста, понимание того, как разрешается форматирование через фрагмент, абзац, текстовый кадр и наследование темы, а также обработка случаев, когда указанный шрифт недоступен.

## **Получить границы текстового фрагмента**

Используйте [IPortion.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPortion#getRect--) для получения ограничивающего прямоугольника текстового фрагмента:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Получить координаты текстового фрагмента**

Используйте [IPortion.getCoordinates](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPortion#getCoordinates--) для получения координат начала текстового фрагмента:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Могу ли я применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [назначить гиперссылку](/slides/ru/androidjava/manage-hyperlinks/) для отдельного фрагмента; только этот кусок будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет фрагмент, а что берётся из абзаца или текстового кадра?**

Свойства уровня фрагмента имеют наивысший приоритет. Если свойство не установлено в [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/), Aspose.Slides берёт его из [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/). Если оно не установлено и там, Aspose.Slides использует стиль из [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) или [theme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/theme/).

**Что происходит, если шрифт, указанный для фрагмента, отсутствует на целевой машине или сервере?**

[правила замены шрифтов](/slides/ru/androidjava/font-selection-sequence/) применяются. Текст может переполняться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного фрагмента независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) могут отличаться от соседних фрагментов.