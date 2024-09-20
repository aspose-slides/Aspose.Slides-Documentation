---
title: Локализация Презентации
type: docs
weight: 100
url: /androidjava/presentation-localization/
---

## **Изменить Язык для Презентации и Текста Фигуры**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте немного текста в TextFrame.
- [Установите Идентификатор Языка](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
- Запишите презентацию в файл PPTX.

Реализация вышеуказанных шагов представлена ниже в примере.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Текст для применения языка проверки правописания");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```