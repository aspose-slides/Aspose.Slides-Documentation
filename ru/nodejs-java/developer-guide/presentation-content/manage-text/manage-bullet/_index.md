---
title: Управление маркерами
type: docs
weight: 60
url: /ru/nodejs-java/manage-bullet/
keywords: "Маркеры, Маркированные списки, Номера, Нумерованные списки, Маркеры-изображения, Многоуровневые маркеры, Презентация PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Создание маркированных и нумерованных списков в презентации PowerPoint на JavaScript"
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как в Word и других текстовых редакторах. **Aspose.Slides for Node.js via Java** также позволяет использовать маркеры и номера в слайдах ваших презентаций.

## **Зачем использовать маркированные списки?**

Маркированные списки помогают быстро и эффективно организовывать и представлять информацию.

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко просматривать ключевые моменты
- эффективно передаёт и доносит важные детали.

## **Зачем использовать нумерованные списки?**

Нумерованные списки также помогают в организации и представлении информации. Желательно использовать цифры (вместо маркеров), когда порядок элементов (например, *шаг 1, шаг 2* и т.д.) имеет значение или когда необходимо ссылаться на элемент (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (шаг 1-шаг 15) процедуры **Creating Bullets**, приведенной ниже:

1. Создайте экземпляр класса презентации. 
2. Выполните несколько задач (шаги 3-14). 
3. Сохраните презентацию. 

## **Создание маркеров**

Эта тема также является частью серии статей по управлению текстовыми абзацами. На этой странице показано, как управлять маркерами абзацев. Маркеры полезны, когда необходимо описать что‑то пошагово. Кроме того, текст выглядит более упорядоченным при использовании маркеров. Абзацы с маркерами всегда легче читать и понимать. Мы покажем, как разработчики могут использовать эту небольшую, но мощную возможность Aspose.Slides for Node.js via Java. Пожалуйста, выполните следующие шаги для управления маркерами абзацев с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) на выбранный слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) добавленной формы.
1. Удалите абзац по умолчанию в TextFrame.
1. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
1. Установите тип маркера абзаца.
1. Установите тип маркера в [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) и задайте символ маркера.
1. Установите текст абзаца.
1. Установите отступ абзаца для установки маркера.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев TextFrame.
1. Добавьте второй абзац и повторите процесс, указанный в шагах **7-13**.
1. Сохраните презентацию.

```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавление и доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной AutoShape
    var txtFrm = aShp.getTextFrame();
    // Удаление абзаца по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    // Создание абзаца
    var para = new aspose.slides.Paragraph();
    // Установка стиля маркера абзаца и символа
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Установка текста абзаца
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
    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    // Сохранение презентации в файл PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Создание маркеров‑изображений**

Aspose.Slides for Node.js via Java позволяет изменять маркеры в списках. Вы можете заменять маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь ещё больше внимания к элементам списка, вы можете использовать собственное изображение в качестве маркера.

{{% alert color="primary" %}} 

Идеально, если вы планируете заменить обычный символ маркера картинкой, выбирайте простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров. 

В любом случае выбранное изображение будет уменьшено до очень маленького размера, поэтому настоятельно рекомендуем подобрать изображение, которое хорошо выглядит (в качестве замены символа маркера) в списке. 

{{% /alert %}} 

Для создания маркера‑изображения выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)
1. Доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide)
1. Добавьте автоконтур в выбранный слайд
1. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной формы
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. Создайте первый экземпляр абзаца с помощью класса Paragraph
1. Загрузите изображение с диска в [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage)
1. Установите тип маркера в Picture и задайте изображение
1. Установите текст абзаца
1. Установите отступ абзаца для установки маркера
1. Установите цвет маркера
1. Установите высоту маркеров
1. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. Добавьте второй абзац и повторите процесс, указанный в предыдущих шагах
1. Сохраните презентацию

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Создать изображение для маркеров
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавление и доступ к Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной autoshape
    var txtFrm = aShp.getTextFrame();
    // Удаление абзаца по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    // Создание нового абзаца
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Установка стиля маркера абзаца и изображения
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    // Добавление абзаца в текстовый фрейм
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

Для создания списка с маркерами, содержащего элементы разных уровней (дополнительные списки под основным), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Добавьте автоконтур в выбранный слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной формы.
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Создайте первый экземпляр абзаца с помощью класса Paragraph и установите глубину 0.
1. Создайте второй экземпляр абзаца с помощью класса Paragraph и установите глубину 1.
1. Создайте третий экземпляр абзаца с помощью класса Paragraph и установите глубину 2.
1. Создайте четвертый экземпляр абзаца с помощью класса Paragraph и установите глубину 3.
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Сохраните презентацию.

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
    // Удаление существующего абзаца по умолчанию
    txtFrm.getParagraphs().clear();
    // Создание первого абзаца
    var para1 = new aspose.slides.Paragraph();
    // Установка стиля маркера абзаца и символа
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para1.getParagraphFormat().setDepth(0);
    // Создание второго абзаца
    var para2 = new aspose.slides.Paragraph();
    // Установка стиля маркера абзаца и символа
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para2.getParagraphFormat().setDepth(1);
    // Создание третьего абзаца
    var para3 = new aspose.slides.Paragraph();
    // Установка стиля маркера абзаца и символа
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para3.getParagraphFormat().setDepth(2);
    // Создание четвертого абзаца
    var para4 = new aspose.slides.Paragraph();
    // Установка стиля маркера абзаца и символа
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Установка уровня маркера
    para4.getParagraphFormat().setDepth(3);
    // Добавление абзаца в текстовый фрейм
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

Aspose.Slides for Node.js via Java предоставляет простой API для управления абзацами с пользовательским форматированием номеров. Чтобы добавить пользовательский нумерованный список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Добавьте автоконтур в выбранный слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) добавленной формы.
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Создайте первый абзац с помощью класса Paragraph и установите **NumberedBulletStartWith** в 2
1. Создайте второй абзац с помощью класса Paragraph и установите **NumberedBulletStartWith** в 3
1. Создайте третий абзац с помощью класса Paragraph и установите **NumberedBulletStartWith** в 7
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Сохраните презентацию.

```javascript
// Создать экземпляр класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавление и доступ к AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Доступ к текстовому фрейму созданной AutoShape
    var txtFrm = aShp.addTextFrame("");
    // Удаление существующего абзаца по умолчанию
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

**Могут ли списки с маркерами и нумерацией, созданные с помощью Aspose.Slides, экспортироваться в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркеров и нумерованных списков при экспорте презентаций в такие форматы, как PDF, изображения и другие, обеспечивая согласованные результаты.

**Можно ли импортировать списки с маркерами или нумерацией из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать списки с маркерами или нумерацией из существующих презентаций, сохраняя их исходное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркеры и нумерованные списки в презентациях, созданных на разных языках?**

Да, Aspose.Slides полностью поддерживает многоязычные презентации, позволяя создавать маркеры и нумерованные списки на любом языке, включая использование специальных или нелатинских символов.