---
title: Верхний и нижний индекс
type: docs
weight: 80
url: /ru/nodejs-java/superscript-and-subscript/
---

## **Управление верхним и нижним индексом текста**

Вы можете добавлять текст в верхнем и нижнем индексе в любую часть абзаца. Для добавления текста в верхнем или нижнем индексе в текстовый фрейм Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat).

Это свойство возвращает или задает текст в верхнем или нижнем индексе (значение от -100 % (нижний индекс) до 100 % (верхний индекс)). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), связанному с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
- Очистите существующие абзацы
- Создайте новый объект параграфа для хранения текста верхнего индекса и добавьте его в [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) объекта [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).
- Создайте новый объект части
- Установите свойство Escapement для части в диапазоне от 0 до 100 для добавления верхнего индекса. (0 означает отсутствие верхнего индекса)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект параграфа для хранения текста нижнего индекса и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект части
- Установите свойство Escapement для части в диапазоне от 0 до -100 для добавления нижнего индекса. (0 означает отсутствие нижнего индекса)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов представлена ниже.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить слайд
    var slide = pres.getSlides().get_Item(0);
    // Создать текстовое поле
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Создать абзац для текста в верхнем индексе
    var superPar = new aspose.slides.Paragraph();
    // Создать часть с обычным текстом
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Создать часть с текстом верхнего индекса
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Создать абзац для текста в нижнем индексе
    var paragraph2 = new aspose.slides.Paragraph();
    // Создать часть с обычным текстом
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Создать часть с текстом нижнего индекса
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Добавить абзацы в текстовое поле
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Будут ли верхний и нижний индекс сохраняться при экспорте в PDF или другие форматы?**

Да, Aspose.Slides правильно сохраняет форматирование верхнего и нижнего индекса при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Можно ли комбинировать верхний и нижний индекс с другими стилями форматирования, такими как полужирный или курсив?**

Да, Aspose.Slides позволяет смешивать различные стили текста в одной части текста. Вы можете включать полужирный, курсив, подчёркивание и одновременно применять верхний или нижний индекс, настраивая соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

**Работает ли форматирование верхнего и нижнего индекса для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) и их контейнерам текста, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) аналогичным образом.