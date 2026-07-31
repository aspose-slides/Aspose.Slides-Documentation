---
title: Управление абзацами текста PowerPoint в JavaScript
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импортировать HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте форматирование абзацев с Aspose.Slides для Node.js через Java — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на JavaScript."
---
## **Введение**

Aspose.Slides предоставляет все классы, необходимые для работы с текстом, абзацами и частями PowerPoint в Java.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `TextFame` может содержать один или несколько абзацев (каждый абзац создаётся при помощи возврата каретки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) , позволяющий добавлять объекты, представляющие части. Объект `Paragraph` может содержать одну или несколько частей (коллекцию объектов части текста).
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) , позволяющий добавлять объекты, представляющие текст и его свойства форматирования.

Объект `Paragraph` может обрабатывать тексты с различными свойствами форматирования через вложенные объекты `Portion`.

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите ITextFrame, ассоциированный с [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).
5. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) и добавьте их в коллекцию `IParagraphs` [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).
6. Создайте три объекта [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) для каждого нового `Paragraph` (по два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `Portion` в коллекцию IPortion соответствующего `Paragraph`.
7. Установите текст для каждой части.
8. Примените желаемые свойства форматирования к каждой части, используя свойства форматирования, доступные в объекте `Portion`.
9. Сохраните изменённую презентацию.

Этот Javascript‑код реализует описанные шаги по добавлению абзацев, содержащих части:

```javascript
// Создайте объект класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получаем первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавляем AutoShape типа Прямоугольник
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Получаем TextFrame AutoShape
    var tf = ashp.getTextFrame();
    // Создаём абзацы и части с различными форматами текста
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Записываем PPTX на диск
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Управление маркерами абзацев**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами всегда легче читать и воспринимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) автоконтурной формы.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/).
7. Установите свойство `Type` маркера для абзаца в `Symbol` и задайте символ маркера.
8. Задайте `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
10. Задайте цвет маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в шагах 7‑13.
14. Сохраните презентацию.

Этот Javascript‑код демонстрирует, как добавить маркер к абзацу:

```javascript
// Создаёт объект класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавляет и получает автоконтурную форму
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает текстовый фрейм автоконтурной формы
    var txtFrm = aShp.getTextFrame();
    // Удаляет абзац по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    // Создаёт абзац
    var para = new aspose.slides.Paragraph();
    // Устанавливает стиль маркера абзаца и символ
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Задает текст абзаца
    para.setText("Welcome to Aspose.Slides");
    // Устанавливает отступ маркера
    para.getParagraphFormat().setIndent(25);
    // Устанавливает цвет маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
    // Устанавливает высоту маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    // Добавляет абзац в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    // Создаёт второй абзац
    var para2 = new aspose.slides.Paragraph();
    // Устанавливает тип и стиль маркера абзаца
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Задает текст абзаца
    para2.setText("This is numbered bullet");
    // Устанавливает отступ маркера
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
    // Устанавливает высоту маркера
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Добавляет абзац в текстовый фрейм
    txtFrm.getParagraphs().add(para2);
    // Сохраняет изменённую презентацию
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Управление маркерами‑картинками**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами‑картинками легко читаются и воспринимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) автоконтурной формы.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/).
7. Загрузите изображение в объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) и задайте изображение.
9. Задайте `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Установите высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните изменённую презентацию.

```javascript
// Создаёт объект класса Presentation, представляющий файл PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = presentation.getSlides().get_Item(0);
    // Создаёт изображение для маркеров
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет и получает автоконтурную форму
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает текстовый фрейм автоконтурной формы
    var textFrame = autoShape.getTextFrame();
    // Удаляет абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);
    // Создаёт новый абзац
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Устанавливает стиль маркера абзаца и изображение
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Устанавливает высоту маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Добавляет абзац в текстовый фрейм
    textFrame.getParagraphs().add(paragraph);
    // Записывает презентацию в файл PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Записывает презентацию в файл PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Управление многоуровневыми маркерами**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читаются и воспринимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) автоконтурной формы.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph] и задайте глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

```javascript
// Создаёт объект класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавляет и получает автоконтурную форму
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает текстовый фрейм созданной автоконтурной формы
    var text = aShp.addTextFrame("");
    // Очищает абзац по умолчанию
    text.getParagraphs().clear();
    // Добавляет первый абзац
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Устанавливает уровень маркера
    para1.getParagraphFormat().setDepth(0);
    // Добавляет второй абзац
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Устанавливает уровень маркера
    para2.getParagraphFormat().setDepth(1);
    // Добавляет третий абзац
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Устанавливает уровень маркера
    para3.getParagraphFormat().setDepth(2);
    // Добавляет четвертый абзац
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Устанавливает уровень маркера
    para4.getParagraphFormat().setDepth(3);
    // Добавляет абзацы в коллекцию
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Сохраняет презентацию в файл PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Управление абзацами с пользовательским нумерованным списком**

Класс [BulletFormat] предоставляет свойство [NumberedBulletStartWith] и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) автоконтурной формы.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph] и установите [NumberedBulletStartWith] равным 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` равным 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` равным 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает текстовый фрейм созданной автоконтурной формы
    var textFrame = shape.getTextFrame();
    // Удаляет существующий абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);
    // Первый список
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Установка отступа первой строки для абзаца**

Используйте метод [ParagraphFormat.setIndent] для управления отступом первой строки абзаца. Этот метод перемещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.setMarginLeft], когда необходимо переместить весь абзац. Используйте [ParagraphFormat.setIndent], когда нужно переместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет разные значения отступа, чтобы продемонстрировать влияние отступа первой строки на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) в форму и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent].
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

## **Установка висячего отступа для абзаца**

Висячий отступ — это формат абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью метода [ParagraphFormat.setIndent]. Установите отступ в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.setMarginLeft] определяет левую позицию тела абзаца, а [ParagraphFormat.setIndent] определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где строки переноса должны выравниваться по телу абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) в форму и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft].
6. Задайте отрицательное значение [Indent] для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

## **Управление конечными свойствами абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий абзац, по его позиции.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
5. Установите `FontHeight` и тип шрифта для абзацев.
6. Задайте свойства End для абзацев.
7. Запишите изменённую презентацию в файл PPTX.

Этот Javascript‑код показывает, как задать свойства End для абзацев в PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) автоконтурной формы.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, прочитанного TextReader, в [ParagraphCollection] TextFrame.
9. Сохраните изменённую презентацию.

```javascript
// Создать пустой экземпляр презентации
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд презентации по умолчанию
    var slide = pres.getSlides().get_Item(0);
    // Добавляем AutoShape для размещения HTML‑содержимого
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Добавляем текстовый фрейм к фигуре
    ashape.addTextFrame("");
    // Очищаем все абзацы в добавленном текстовом фрейме
    ashape.getTextFrame().getParagraphs().clear();
    // Загружаем HTML‑файл с помощью StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Добавляем текст из HTML‑потока в текстовый фрейм
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Сохраняем презентацию
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текста (содержащегося в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте выбранные абзацы.

```javascript
// Load the presentation file
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Получить первый слайд презентации по умолчанию
    var slide = pres.getSlides().get_Item(0);
    // Желаемый индекс
    var index = 0;
    // Получаем добавленную форму
    var ashape = slide.getShapes().get_Item(index);
    // Создаём выходной HTML‑файл
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Извлекаем первый абзац в формате HTML
    // Записываем данные абзацев в HTML, указав индекс начала абзаца и общее количество копируемых абзацев
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Сохранение абзаца как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph], в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `getImage` класса [Shape], вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Example 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого мы извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме формы. Затем абзац перерисовывается на новое растровое изображение, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде растрового изображения.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Создать растровое изображение формы из памяти.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Вычислить границы второго абзаца.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Вычислить координаты и размер выходного изображения (минимальный размер — 1x1 пиксель).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![Изображение абзаца](paragraph_to_image_output.png)

**Example 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование может быть особенно полезным, когда требуется более детализированное изображение, например, для использования в печатных материалах высокого качества.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде растрового изображения с масштабированием.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Создать растровое изображение формы из памяти.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Вычислить границы второго абзаца.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Вычислить координаты и размер выходного изображения (минимальный размер — 1x1 пиксель).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста в фрейме ([setWrapText]), чтобы отключить перенос, и строки не будут разрываться у границ фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Вы можете получить ограничивающий прямоугольник абзаца (и даже отдельной части), чтобы знать его точное расположение и размер на слайде.

**Где контролируется выравнивание абзаца (по левому/правому краю/по центру/по ширине)?**

[setAlignment] — это метод, задающий выравнивание на уровне абзаца в [ParagraphFormat]; он применяется ко всему абзацу независимо от форматирования отдельных частей.

**Можно ли задать язык проверки орфографии только для части абзаца (например, для одного слова)?**

Да. Язык задаётся на уровне части ([PortionFormat.setLanguageId]), поэтому в одном абзаце могут сосуществовать несколько языков.