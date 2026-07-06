---
title: Получить границы абзаца из презентаций в JavaScript
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/nodejs-java/paragraph-bounds/
keywords:
- границы абзаца
- координаты абзаца
- размер абзаца
- текстовый кадр
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для Node.js через Java, чтобы оптимизировать позиционирование текста в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как получить границы, размер и координаты абзацев в Aspose.Slides. Описывается, как получить прямоугольник абзаца из [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) с помощью [Paragraph.getRect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/getrect/), как получить координаты абзаца внутри текстового кадра ячейки таблицы и выделяются важные детали, такие как единицы измерения, влияние переноса текста на границы, преобразование пикселей и эффективные параметры форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [Paragraph.getRect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/getrect/) для получения ограничивающего прямоугольника абзаца.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Получить размер абзаца внутри текстового кадра ячейки таблицы**

Чтобы получить размер и координаты [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) в текстовом кадре ячейки таблицы, используйте [Paragraph.getRect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/getrect/). Возвращаемый прямоугольник относится к текстовому кадру ячейки таблицы, поэтому при необходимости координат уровня слайда добавьте позицию таблицы и смещение ячейки.

Следующий пример получает границы абзаца внутри ячейки таблицы и рисует прямоугольники на слайде для визуализации этих границ:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**В каких единицах измеряются координаты абзаца?**

Они измеряются в пунктах, где 1 дюйм равен 72 пунктам. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) включена опция [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/setwraptext/), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI для рендеринга или экспорта.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/nodejs-java/shape-effective-properties/); она возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и прочего.