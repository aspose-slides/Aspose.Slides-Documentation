---
title: Супер.script и Суб.script
type: docs
weight: 80
url: /ru/androidjava/superscript-and-subscript/
---

## **Управление текстом супер.script и суб.script**
Вы можете добавить текст в супер.script и суб.script в любую часть абзаца. Для добавления текста супер.script или суб.script в текстовом фрейме Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Это свойство возвращает или устанавливает текст супер.script или суб.script (значение от -100% (суб.script) до 100% (супер.script). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), связанному с [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для хранения текста супер.script и добавьте его в [коллекцию IParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) объекта [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до 100 для добавления супер.script. (0 означает отсутствие супер.script)
- Установите текст для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) и затем добавьте его в коллекцию порций абзаца.
- Создайте новый объект абзаца для хранения текста суб.script и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до -100 для добавления суб.script. (0 означает отсутствие суб.script)
- Установите текст для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) и затем добавьте его в коллекцию порций абзаца.
- Сохраните презентацию в формате PPTX.

Реализация вышеуказанных шагов приведена ниже.

```java
// Создание экземпляра класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получите слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создайте текстовое поле
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Создайте абзац для текста супер.script
    IParagraph superPar = new Paragraph();

    // Создайте порцию с обычным текстом
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Создайте порцию с текстом супер.script
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Создайте абзац для текста суб.script
    IParagraph paragraph2 = new Paragraph();

    // Создайте порцию с обычным текстом
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Создайте порцию с текстом суб.script
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Добавьте абзацы в текстовое поле
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```