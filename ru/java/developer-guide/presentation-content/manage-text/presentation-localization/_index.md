---
title: Локализация Презентации
type: docs
weight: 100
url: /java/presentation-localization/
---

## **Смена языка текста в презентации и фигурах**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Прямоугольник](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте текст в TextFrame.
- [Установка идентификатора языка](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеперечисленных шагов показана ниже в примере.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Текст для применения проверки орфографии");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```