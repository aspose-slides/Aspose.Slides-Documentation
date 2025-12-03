---
title: Управление надстрочным и подстрочным в презентациях с использованием Java
linktitle: Надстрочный и подстрочный
type: docs
weight: 80
url: /ru/java/superscript-and-subscript/
keywords:
- надстрочный
- подстрочный
- добавить надстрочный
- добавить подстрочный
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Овладейте надстрочным и подстрочным в Aspose.Slides для Java и улучшите свои презентации профессиональным форматированием текста для максимального воздействия."
---

## **Управление верхним и нижним индексом текста**
Можно добавить текст в виде верхнего или нижнего индекса в любой части абзаца. Чтобы добавить верхний или нижний индекс в текстовый фрейм Aspose.Slides, необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

Это свойство возвращает или задает текст в виде верхнего или нижнего индекса (значение от -100 % (нижний индекс) до 100 % (верхний индекс)). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame), связанному с объектом [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для размещения текста в верхнем индексе и добавьте его в коллекцию [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) объекта [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Создайте новый объект части.
- Установите свойство Escapement для части в диапазоне от 0 до 100, чтобы добавить верхний индекс. (0 означает отсутствие верхнего индекса)
- Задайте некоторый текст для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект абзаца для размещения текста в нижнем индексе и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект части.
- Установите свойство Escapement для части в диапазоне от 0 до -100, чтобы добавить нижний индекс. (0 означает отсутствие нижнего индекса)
- Задайте некоторый текст для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создать текстовое поле
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Создать абзац для текста в верхнем индексе
    IParagraph superPar = new Paragraph();

    // Создать часть с обычным текстом
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Создать часть с текстом в верхнем индексе
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Создать абзац для текста в нижнем индексе
    IParagraph paragraph2 = new Paragraph();

    // Создать часть с обычным текстом
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Создать часть с текстом в нижнем индексе
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Добавить абзацы в текстовое поле
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Вопросы и ответы**

**Будут ли верхний и нижний индексы сохраняться при экспорте в PDF или другие форматы?**

Да, Aspose.Slides корректно сохраняет форматирование верхнего и нижнего индекса при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование сохраняется во всех выходных файлах.

**Можно ли сочетать верхний и нижний индексы с другими стилями форматирования, такими как полужирный или курсив?**

Да, Aspose.Slides позволяет смешивать различные стили текста в пределах одной части текста. Вы можете включить полужирный, курсив, подчеркивание и одновременно применить верхний или нижний индекс, настроив соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/).

**Работает ли форматирование верхнего и нижнего индекса для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) аналогичным образом.