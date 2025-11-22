---
title: Абзац
type: docs
weight: 60
url: /ru/nodejs-java/paragraph/
---

## **Получить координаты абзаца и части в TextFrame**
Используя Aspose.Slides для Node.js через Java, разработчики теперь могут получить прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Он также позволяет получить [координаты части](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) внутри коллекции частей абзаца. В этой статье мы с помощью примера покажем, как получить прямоугольные координаты абзаца вместе с позицией части внутри абзаца.
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Получить прямоугольные координаты абзаца**
С помощью метода [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) разработчики могут получить прямоугольник границ абзаца.
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить размер абзаца и части внутри текстового фрейма ячейки таблицы**
Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) или [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) в текстовом фрейме ячейки таблицы, вы можете использовать методы [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) и [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--).
Этот пример кода демонстрирует описанную операцию:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**В каких единицах возвращаются координаты абзаца и текстовых частей?**  
В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**  
Да. Если [перенос](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) включён в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), текст разбивается, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**  
Да. Преобразуйте пункты в пиксели с помощью: pixels = points × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**  
Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/nodejs-java/shape-effective-properties/); она возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и других параметров.