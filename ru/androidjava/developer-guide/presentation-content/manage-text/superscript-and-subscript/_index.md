---
title: Управление надстрочным и подстрочным текстом в презентациях на Android
linktitle: Надстрочный и подстрочный
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
description: "Освойте надстрочный и подстрочный текст в Aspose.Slides для Android на Java и улучшите свои презентации профессиональным форматированием текста для максимального воздействия."
---

## **Управление надстрочным и подстрочным текстом**
Вы можете добавить надстрочный и подстрочный текст внутри любой части абзаца. Для добавления надстрочного или подстрочного текста в текстовый фрейм Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Это свойство возвращает или задает надстрочный или подстрочный текст (значение от -100 % (подстрочный) до 100 % (надстрочный)). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), связанному с [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для надстрочного текста и добавьте его в коллекцию [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) объекта [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- Создайте новый объект части.
- Установите свойство Escapement для части в диапазоне от 0 до 100, чтобы добавить надстрочный текст. (0 означает отсутствие надстрочного текста)
- Задайте текст для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект абзаца для подстрочного текста и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект части.
- Установите свойство Escapement для части в диапазоне от 0 до -100, чтобы добавить подстрочный текст. (0 означает отсутствие подстрочного текста)
- Задайте текст для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Реализация указанных шагов приведена ниже.
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

**Сохранятся ли надстрочный и подстрочный текст при экспорте в PDF или другие форматы?**

Да, Aspose.Slides корректно сохраняет форматирование надстрочного и подстрочного текста при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Можно ли комбинировать надстрочный и подстрочный текст с другими стилями форматирования, например, полужирным или курсивом?**

Да, Aspose.Slides позволяет смешивать различные стили текста внутри одной части. Вы можете включить полужирный, курсив, подчёркивание и одновременно применить надстрочный или подстрочный текст, настроив соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**Работает ли форматирование надстрочного и подстрочного текста для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) аналогичным образом.