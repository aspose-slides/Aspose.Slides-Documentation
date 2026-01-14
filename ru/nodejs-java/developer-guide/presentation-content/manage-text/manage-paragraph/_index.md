---
title: Управление абзацами текста PowerPoint в JavaScript
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/nodejs-java/manage-paragraph/
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
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспорт абзаца
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте форматирование абзацев с Aspose.Slides для Node.js через Java — оптимизируйте выравнивание, интервал и стиль в презентациях PPT, PPTX и ODP на JavaScript."
---

Aspose.Slides предоставляет все необходимые классы для работы с текстами, абзацами и фрагментами PowerPoint в Java.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `TextFame` может содержать один или несколько абзацев (каждый абзац создаётся с помощью символа переноса строки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) , позволяющий добавлять объекты, представляющие фрагменты. Объект `Paragraph` может содержать один или несколько фрагментов (коллекцию объектов фрагментов текста).
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) , позволяющий добавлять объекты, представляющие тексты и их свойства форматирования.

Объект `Paragraph` способен обрабатывать тексты с различными свойствами форматирования через содержащиеся в нём объекты `Portion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите `ITextFrame`, связанный с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
5. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) и добавьте их в коллекцию `IParagraphs` объекта [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Для каждого нового `Paragraph` создайте три объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (для абзаца по умолчанию – два объекта Portion) и добавьте каждый объект `Portion` в коллекцию `IPortion` соответствующего `Paragraph`.
7. Задайте некоторый текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту, используя свойства форматирования, доступные в объекте `Portion`.
9. Сохраните изменённую презентацию.

```javascript
// Создайте объект класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавьте AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Доступ к TextFrame AutoShape
    var tf = ashp.getTextFrame();
    // Create Paragraphs and Portions with different text formats
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
    // Сохраните PPTX на диск
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Управление маркерами абзацев**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) автоконтуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Установите для абзаца тип маркера `Type` в значение `Symbol` и задайте символ маркера.
8. Задайте текст абзаца `Text`.
9. Установите отступ абзаца `Indent` для маркера.
10. Задайте цвет маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в шагах 7‑13.
14. Сохраните презентацию.

```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавляет AutoShape и получает к нему доступ
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает доступ к текстовому фрейму автоформы
    var txtFrm = aShp.getTextFrame();
    // Удаляет абзац по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    // Создает абзац
    var para = new aspose.slides.Paragraph();
    // Устанавливает стиль маркера абзаца и символ
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Устанавливает текст абзаца
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
    // Создает второй абзац
    var para2 = new aspose.slides.Paragraph();
    // Устанавливает тип и стиль маркера абзаца
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Добавляет текст абзаца
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
    // Сохраняет измененную презентацию
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Управление графическими маркерами**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Абзацы с изображениями легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) автоконтуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Загрузите изображение в [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) и задайте изображение.
9. Задайте текст абзаца `Text`.
10. Установите отступ абзаца `Indent` для маркера.
11. Задайте цвет маркера.
12. Установите высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = presentation.getSlides().get_Item(0);
    // Создает изображение для маркеров
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет и получает доступ к AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает доступ к текстовому фрейму автоформы
    var textFrame = autoShape.getTextFrame();
    // Удаляет абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);
    // Создает новый абзац
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Устанавливает стиль маркера абзаца и изображение
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Устанавливает высоту маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Добавляет абзац в текстовый фрейм
    textFrame.getParagraphs().add(paragraph);
    // Сохраняет презентацию как файл PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Сохраняет презентацию как файл PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Управление многоуровневыми маркерами**

Списки с маркерами помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) автоконтуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) и установите глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и установите глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавляет и получает доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает доступ к текстовому фрейму созданной автоформы
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

Класс [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) автоконтуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) и задайте [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) = 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` = 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` = 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получает доступ к текстовому фрейму созданной автоформы
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


## **Установка отступа абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на нужный слайд по его индексу.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) с тремя абзацами в прямоугольный автоконтур.
1. Спрячьте линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) через свойство `BulletOffset`.
1. Запишите изменённую презентацию в файл PPT.

```javascript
// Создает объект класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавляет прямоугольную форму
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // Добавляет TextFrame к прямоугольнику
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // Устанавливает автоадаптацию текста к форме
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Скрывает линии прямоугольника
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // Получает первый абзац в TextFrame и задает отступ
    var para1 = tf.getParagraphs().get_Item(0);
    // Настройка стиля маркера абзаца и символа
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // Получает второй абзац в TextFrame и задает отступ
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // Получает третий абзац в TextFrame и задает отступ
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // Записывает презентацию на диск
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка висячего отступа для абзаца**

Этот Javascript‑код показывает, как установить висячий отступ для абзаца:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Управление свойствами конца абзаца (End Run Properties) для абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, содержащий абзац, по его позиции.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите свойства End для абзацев.
1. Запишите изменённую презентацию в файл PPTX.

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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) автоконтуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Считайте исходный HTML‑файл в `TextReader`.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла из `TextReader` в [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) `TextFrame`.
9. Сохраните изменённую презентацию.

```javascript
// Создайте пустой объект презентации
var pres = new aspose.slides.Presentation();
try {
    // Получаем первый слайд презентации по умолчанию
    var slide = pres.getSlides().get_Item(0);
    // Добавляем AutoShape для размещения HTML‑контента
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

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите требуемую презентацию.
2. Получите ссылку na нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и откройте новый HTML‑файл.
6. Укажите начальный индекс для `StreamWriter` и экспортируйте требуемые абзацы.

```javascript
// Загрузите файл презентации
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Получаем первый слайд презентации по умолчанию
    var slide = pres.getSlides().get_Item(0);
    // Желаемый индекс
    var index = 0;
    // Доступ к добавленной фигуре
    var ashape = slide.getShapes().get_Item(index);
    // Создание выходного HTML-файла
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Извлечение первого абзаца в виде HTML
    // Запись данных абзацев в HTML, задавая начальный индекс абзаца и общее количество копируемых абзацев
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

В этом разделе рассматриваются два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `getImage` класса [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Эти подходы позволяют извлекать конкретные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме формы. После этого абзац перерисовывается на новое растровое изображение, которое сохраняется в формате PNG. Этот метод особенно полезен, когда требуется сохранить конкретный абзац как отдельное изображение с точным сохранением размеров и форматирования текста.
```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти как растровое изображение.
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

    // Вычислить координаты и размеры выходного изображения (минимальный размер - 1x1 пиксель).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Обрезать растровое изображение формы, оставив только растровое изображение абзаца.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте абзаца. Границы абзаца вычисляются с учётом масштаба. Масштабирование особенно полезно, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти как растровое изображение с масштабированием.
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

    // Обрезать растровое изображение формы, оставив только растровое изображение абзаца.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Вопросы и ответы**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста у текстового фрейма ([setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)), чтобы отключить перенос, и строки не будут разбираться по краям фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить ограничивающий прямоугольник абзаца (и даже отдельного фрагмента), чтобы узнать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (по левому/правому краю/по центру/по ширине)?**

Метод [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) предназначен для настройки уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/); он применяется ко всему абзацу независимо от отдельного форматирования фрагментов.

**Можно ли задать язык проверки орфографии только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), поэтому в одном абзаце могут сосуществовать несколько языков.