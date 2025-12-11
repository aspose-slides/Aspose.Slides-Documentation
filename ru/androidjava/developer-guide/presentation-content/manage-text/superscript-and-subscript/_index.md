---
title: Управление надстрочным и подстрочным текстом в презентациях на Android
linktitle: Надстрочный и подстрочный текст
type: docs
weight: 80
url: /ru/androidjava/superscript-and-subscript/
keywords:
- надстрочный
- подстрочный
- добавить надстрочный
- добавить подстрочный
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте надстрочный и подстрочный текст в Aspose.Slides для Android на Java и улучшите свои презентации с помощью профессионального форматирования текста для максимального воздействия."
---

## **Управление надстрочным и подстрочным текстом**
Вы можете добавить надстрочный и подстрочный текст внутри любой части абзаца. Для добавления надстрочного или подстрочного текста в текстовый фрейм Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Это свойство возвращает или задает надстрочный или подстрочный текст (значение от -100 % (подстрочный) до 100 % (надстрочный)). Например:

- Создайте экземпляр класса Presentation.
- Получите ссылку на слайд, используя его Index.
- Добавьте IAutoShape типа Rectangle на слайд.
- Получите доступ к ITextFrame, связанному с IAutoShape.
- Очистите существующие Paragraphs.
- Создайте новый объект абзаца для размещения надстрочного текста и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект Portion.
- Установите свойство Escapement для Portion в диапазоне от 0 до 100 для добавления надстрочного текста. (0 означает отсутствие надстрочного текста)
- Установите некоторый текст для Portion, затем добавьте его в коллекцию Portion абзаца.
- Создайте новый объект абзаца для размещения подстрочного текста и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект Portion.
- Установите свойство Escapement для Portion в диапазоне от 0 до -100 для добавления подстрочного текста. (0 означает отсутствие подстрочного текста)
- Установите некоторый текст для Portion, затем добавьте его в коллекцию Portion абзаца.
- Сохраните презентацию в формате PPTX.

Реализация указанных выше шагов представлена ниже.
```java
// Создать экземпляр класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получить слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создать текстовое поле
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Создать абзац для надстрочного текста
    IParagraph superPar = new Paragraph();

    // Создать часть с обычным текстом
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Создать часть с надстрочным текстом
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Создать абзац для подстрочного текста
    IParagraph paragraph2 = new Paragraph();

    // Создать часть с обычным текстом
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Создать часть с подстрочным текстом
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


## **FAQ**

**Сохраняются ли надстрочный и подстрочный текст при экспорте в PDF или другие форматы?**

Да, Aspose.Slides правильно сохраняет форматирование надстрочного и подстрочного текста при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование сохраняется во всех выходных файлах.

**Можно ли комбинировать надстрочный и подстрочный текст с другими стилями форматирования, такими как полужирный или курсив?**

Да, Aspose.Slides позволяет сочетать различные стили текста внутри одной Portion. Вы можете включать полужирный, курсив, подчеркивание и одновременно применять надстрочный или подстрочный текст, настраивая соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**Работает ли надстрочный и подстрочный формат для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) и их контейнерам текста, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) аналогичным образом.