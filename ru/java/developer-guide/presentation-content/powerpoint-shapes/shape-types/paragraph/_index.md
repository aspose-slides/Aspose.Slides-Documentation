---
title: Получить границы абзаца в презентациях на Java
linktitle: Абзац
type: docs
weight: 60
url: /ru/java/paragraph/
keywords:
- границы абзаца
- границы текстового фрагмента
- координаты абзаца
- координаты фрагмента
- размер абзаца
- размер текстового фрагмента
- текстовый фрейм
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстовых фрагментов в Aspose.Slides для Java, чтобы оптимизировать размещение текста в презентациях PowerPoint."
---

## **Получить координаты абзаца и фрагмента в TextFrame**
С помощью Aspose.Slides for Java разработчики теперь могут получать прямоугольные координаты абзаца (Paragraph) внутри коллекции абзацев TextFrame. Это также позволяет получать [координаты фрагмента](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) внутри коллекции фрагментов абзаца. В этой статье мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с положением фрагмента внутри абзаца.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Получить прямоугольные координаты абзаца**
С помощью метода [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) разработчики могут получить ограничивающий прямоугольник абзаца.
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


## **Получить размер абзаца и фрагмента внутри TextFrame ячейки таблицы**
Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) или [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) в текстовом фрейме ячейки таблицы, можно использовать методы [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) и [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--).
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


## **Часто задаваемые вопросы**

**В каких единицах измеряются координаты, возвращаемые для абзаца и текстовых фрагментов?**  
В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**  
Да. Если [перенос](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-) включён в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/), текст разбивается, чтобы вписаться в ширину области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**  
Да. Преобразуйте пункты в пиксели по формуле: pixels = points × (DPI / 72). Результат зависит от выбранного DPI для рендеринга/экспорта.

**Как получить «эффективные» параметры форматирования абзаца, учитывающие наследование стилей?**  
Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/java/shape-effective-properties/); она возвращает окончательные агрегированные значения отступов, интервалов, переноса, направления RTL и др.