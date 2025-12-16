---
title: Получить границы абзаца из презентаций на Android
linktitle: Абзац
type: docs
weight: 60
url: /ru/androidjava/paragraph/
keywords:
- границы абзаца
- границы текстовой части
- координаты абзаца
- координаты части
- размер абзаца
- размер текстовой части
- текстовый кадр
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстовой части в Aspose.Slides для Android через Java, чтобы оптимизировать расположение текста в презентациях PowerPoint."
---

## **Получение координат абзаца и части в TextFrame**
Используя Aspose.Slides для Android через Java, разработчики теперь могут получить прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Это также позволяет получить [координаты части](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) внутри коллекции частей абзаца. В этой статье мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с позицией части внутри абзаца.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Получение прямоугольных координат абзаца**
С помощью метода [**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) разработчики могут получить ограничивающий прямоугольник абзаца.
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получение размеров абзаца и части внутри TextFrame ячейки таблицы**

Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) или [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) в TextFrame ячейки таблицы, можно использовать методы [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) и [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--).

Этот пример кода демонстрирует описанную операцию:
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**В каких единицах измеряются возвращаемые координаты абзаца и текстовых частей?**

В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если [wrapping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) включён в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надежно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели с помощью формулы: pixels = points × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/androidjava/shape-effective-properties/); она возвращает окончательные согласованные значения отступов, интервалов, переноса, RTL и прочего.