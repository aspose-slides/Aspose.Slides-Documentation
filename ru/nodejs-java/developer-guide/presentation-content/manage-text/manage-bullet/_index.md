---
title: Управление маркированными и нумерованными списками в презентациях с помощью JavaScript
linktitle: Управление списками
type: docs
weight: 60
url: /ru/nodejs-java/manage-bullet/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- графический маркер
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с помощью JavaScript, используя Aspose.Slides для Node.js. Пошаговое руководство."
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как делаете это в Word и других текстовых редакторах. **Aspose.Slides for Node.js via Java** также позволяет использовать маркеры и цифры в слайдах ваших презентаций.

## **Зачем использовать маркированные списки?**

Маркированные списки помогают быстро и эффективно организовывать и представлять информацию.

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основные функции:

- привлекает внимание читателей или зрителей к важной информации
- позволяет читателям или зрителям быстро просматривать ключевые моменты
- эффективно передаёт и доставляет важные детали.

## **Зачем использовать нумерованные списки?**

Нумерованные списки также помогают организовывать и представлять информацию. В идеале следует использовать цифры (вместо маркеров), когда важен порядок элементов (например, *шаг 1, шаг 2* и т.д.) или когда на элемент нужно ссылаться (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (шаг 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (шаги 3–14).
3. Сохраните презентацию.

## **Создание маркеров**

Эта тема также является частью серии тем по управлению текстовыми абзацами. На этой странице будет продемонстрировано, как управлять маркерами абзацев. Маркеры полезны, когда что‑то описывается пошагово. Кроме того, текст выглядит более организованным при использовании маркеров. Маркированные абзацы всегда легче читать и понимать. Мы покажем, как разработчики могут использовать эту небольшую, но мощную возможность Aspose.Slides for Node.js via Java. Пожалуйста, следуйте приведённым ниже шагам для управления маркерами абзацев с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов, используя объект [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) добавленной фигуры.
5. Удалите абзац по умолчанию в TextFrame.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
7. Установите тип маркера для абзаца.
8. Установите тип маркера в [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) и задайте символ маркера.
9. Задайте текст абзаца.
10. Установите отступ абзаца для задания маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркеров.
13. Добавьте созданный абзац в коллекцию абзацев TextFrame.
14. Добавьте второй абзац и повторите процесс, описанный в шагах **7–13**.
15. Сохраните презентацию.

```javascript
// Создать экземпляр класса Presentation, который представляет файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получение первого слайда
    var slide = pres.getSlides().get_Item(0);
    // Добавление и получение AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Получение текстового фрейма созданной AutoShape
    var txtFrm = aShp.getTextFrame();
    // Удаление параграфа по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    // Создание параграфа
    var para = new aspose.slides.Paragraph();
    // Установка стиля маркера и символа для параграфа
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Установка текста параграфа
    para.setText("Welcome to Aspose.Slides");
    // Установка отступа маркера
    para.getParagraphFormat().setIndent(25);
    // Установка цвета маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    // Добавление параграфа в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    // Сохранение презентации в файл PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Создание графических маркеров**

Aspose.Slides for Node.js via Java позволяет изменять маркеры в списках. Вы можете заменять маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь ещё больше внимания к элементам списка, вы можете использовать собственное изображение в качестве маркера.

{{% alert color="primary" %}} 
В идеале, если вы собираетесь заменить обычный символ маркера картинкой, следует выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров. 

В любом случае выбранное изображение будет уменьшено до очень небольшого размера, поэтому настоятельно рекомендуем выбирать изображение, которое выглядит хорошо (в качестве замены символа маркера) в списке. 
{{% /alert %}} 

Чтобы создать графический маркер, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов, используя объект [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
3. Добавьте автофигуру в выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Создайте первый экземпляр абзаца, используя класс Paragraph.
7. Загрузите изображение с диска в [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Установите тип маркера в Picture и задайте изображение.
9. Задайте текст абзаца.
10. Установите отступ абзаца для задания маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркеров.
13. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
14. Добавьте второй абзац и повторите процесс, описанный в предыдущих шагах.
15. Сохраните презентацию.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Создание изображения для маркеров
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавление и доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной AutoShape
    var txtFrm = aShp.getTextFrame();
    // Удаление стандартного существующего параграфа
    txtFrm.getParagraphs().removeAt(0);
    // Создание нового параграфа
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Установка стиля маркера и изображения для параграфа
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    // Добавление параграфа в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    // Запись презентации в файл PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создание многоуровневых маркеров**

Чтобы создать маркированный список, содержащий элементы разных уровней — дополнительные списки под основным — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов, используя объект [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
3. Добавьте автофигуру в выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Создайте первый экземпляр абзаца, используя класс Paragraph, и задайте глубину 0.
7. Создайте второй экземпляр абзаца, используя класс Paragraph, и задайте глубину 1.
8. Создайте третий экземпляр абзаца, используя класс Paragraph, и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца, используя класс Paragraph, и задайте глубину 3.
10. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
11. Сохраните презентацию.

```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавление и доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной AutoShape
    var txtFrm = aShp.addTextFrame("");
    // Удаление стандартного существующего параграфа
    txtFrm.getParagraphs().clear();
    // Создание первого параграфа
    var para1 = new aspose.slides.Paragraph();
    // Установка стиля маркера и символа для параграфа
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para1.getParagraphFormat().setDepth(0);
    // Создание второго параграфа
    var para2 = new aspose.slides.Paragraph();
    // Установка стиля маркера и символа для параграфа
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para2.getParagraphFormat().setDepth(1);
    // Создание третьего параграфа
    var para3 = new aspose.slides.Paragraph();
    // Установка стиля маркера и символа для параграфа
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para3.getParagraphFormat().setDepth(2);
    // Создание четвертого параграфа
    var para4 = new aspose.slides.Paragraph();
    // Установка стиля маркера и символа для параграфа
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para4.getParagraphFormat().setDepth(3);
    // Добавление параграфов в текстовый фрейм
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // Сохранение презентации в файл PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создание пользовательского нумерованного списка**

Aspose.Slides for Node.js via Java предоставляет простой API для управления абзацами с пользовательским форматированием чисел. Чтобы добавить пользовательский нумерованный список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов, используя объект [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
3. Добавьте автофигуру в выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Создайте первый экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** равным 2.
7. Создайте второй экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** равным 3.
8. Создайте третий экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** равным 7.
9. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
10. Сохраните презентацию.

```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавление и доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной AutoShape
    var txtFrm = aShp.addTextFrame("");
    // Удаление стандартного существующего параграфа
    txtFrm.getParagraphs().clear();
    // Первый список
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // Второй список
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки, созданные с помощью Aspose.Slides, в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркированных и нумерованных списков при экспорте презентаций в такие форматы, как PDF, изображения и другие, обеспечивая согласованные результаты.

**Можно ли импортировать маркированные или нумерованные списки из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать маркированные или нумерованные списки из существующих презентаций, сохраняя их оригинальное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркированные и нумерованные списки в презентациях, созданных на нескольких языках?**

Да, Aspose.Slides полностью поддерживает многоязычные презентации, позволяя создавать маркированные и нумерованные списки на любом языке, включая использование специальных или нелатинских символов.