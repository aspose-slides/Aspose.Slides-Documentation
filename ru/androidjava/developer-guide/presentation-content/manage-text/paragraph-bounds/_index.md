---
title: Получить границы абзаца из презентаций на Android
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/androidjava/paragraph-bounds/
keywords:
- границы абзаца
- координаты абзаца
- размер абзаца
- текстовый кадр
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для Android через Java, чтобы оптимизировать позиционирование текста в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как получить границы, размер и координаты абзацев в Aspose.Slides. Показано, как получить прямоугольник абзаца из [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) с помощью [IParagraph.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraph#getRect--), как получить координаты абзаца внутри текстового кадра ячейки таблицы, а также выделены важные детали, такие как единицы измерения, влияние переноса текста на границы, преобразование в пиксели и значения эффективного форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraph#getRect--) для получения ограничивающего прямоугольника абзаца.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Получить размер абзаца внутри текстового кадра ячейки таблицы**

Чтобы получить размер и координаты [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) в текстовом кадре ячейки таблицы, используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraph#getRect--). Возвращаемый прямоугольник относится к текстовому кадру ячейки таблицы, поэтому при необходимости координат уровня слайда добавьте позицию таблицы и смещение ячейки.

Следующий пример получает границы абзаца внутри ячейки таблицы и рисует прямоугольники на слайде для визуализации этих границ:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**В каких единицах измеряются координаты абзаца?**

Они измеряются в пунктах, где 1 дюйм равен 72 пунктам. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) включён [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно преобразовать координаты абзаца в пиксели в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI для рендеринга или экспорта.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/androidjava/shape-effective-properties/); он возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и других параметров.