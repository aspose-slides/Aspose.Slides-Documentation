---
title: Надстрочный и подстрочный текст
type: docs
weight: 80
url: /ru/java/superscript-and-subscript/
---

## **Управление надстрочным и подстрочным текстом**
Вы можете добавлять надстрочный и подстрочный текст внутри любого абзаца. Чтобы добавить надстрочный или подстрочный текст в текстовом фрейме Aspose.Slides, необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

Это свойство возвращает или задает надстрочный или подстрочный текст (значение от -100% (подстрочный) до 100% (надстрочный). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame), связанному с [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для хранения надстрочного текста и добавьте его в [коллекцию IParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Создайте новый объект части.
- Установите свойство Escapement для части от 0 до 100 для добавления надстрочного текста. (0 означает отсутствие надстрочного текста).
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект абзаца для хранения подстрочного текста и добавьте его в коллекцию IParagraphs [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Создайте новый объект части.
- Установите свойство Escapement для части от 0 до -100 для добавления подстрочного текста. (0 означает отсутствие подстрочного текста).
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в виде файла PPTX.

Реализация вышеперечисленных шагов приведена ниже.

```java
// Создайте экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получите слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создайте текстовое поле
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Создайте абзац для надстрочного текста
    IParagraph superPar = new Paragraph();

    // Создайте часть с обычным текстом
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Создайте часть с надстрочным текстом
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Создайте абзац для подстрочного текста
    IParagraph paragraph2 = new Paragraph();

    // Создайте часть с обычным текстом
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Создайте часть с подстрочным текстом
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Добавьте абзацы в текстовое поле
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```