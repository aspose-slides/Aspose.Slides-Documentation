---
title: Получить границы абзаца из презентаций в Java
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/java/paragraph-bounds/
keywords:
- границы абзаца
- координаты абзаца
- размер абзаца
- текстовый фрейм
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для Java, чтобы оптимизировать позиционирование текста в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как получить границы, размер и координаты абзацев в Aspose.Slides. Показано, как получить прямоугольник абзаца из [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) с помощью [IParagraph.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IParagraph#getRect--), как получить координаты абзаца внутри текстового фрейма ячейки таблицы, а также выделяются важные детали, такие как единицы измерения, влияние переноса текста на границы, конвертация в пиксели и эффективные параметры форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IParagraph#getRect--) чтобы получить ограничивающий прямоугольник абзаца.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Получить размер абзаца внутри текстового фрейма ячейки таблицы**

Чтобы получить размер и координаты [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) в текстовом фрейме ячейки таблицы, используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IParagraph#getRect--). Возвращаемый прямоугольник относится к текстовому фрейму ячейки таблицы, поэтому при необходимости координат уровня слайда добавьте позицию таблицы и смещение ячейки.

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

Они измеряются в points, где 1 дюйм равен 72 points. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) включена настройка [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), текст переносится, чтобы поместиться в ширину области, что изменяет реальные границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями при экспорте изображения?**

Да. Преобразуйте points в пиксели по формуле: pixels = points × (DPI / 72). Результат зависит от выбранного DPI для рендеринга или экспорта.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/java/shape-effective-properties/); он возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и др.