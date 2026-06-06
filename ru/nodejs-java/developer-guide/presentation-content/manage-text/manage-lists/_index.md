---
title: Управление маркированными и нумерованными списками в презентациях с помощью JavaScript
linktitle: Управление списками
type: docs
weight: 60
url: /ru/nodejs-java/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- маркер‑изображение
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
description: "Узнайте, как создавать и форматировать маркированные, маркеры‑изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого контролируются через его формат абзаца.

Используйте класс [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) для доступа к настройкам списка уровня абзаца. Основной входной пункт — `Paragraph.getParagraphFormat().getBullet()`, который возвращает объект [BulletFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/bulletformat/). С помощью этого объекта можно установить тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальный номер.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) в [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) и задайте `BulletFormat.setType` значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/bullettype/). Затем можно установить `BulletFormat.setChar`, `BulletFormat.getColor` и `BulletFormat.setHeight` для управления внешним видом маркера.

Следующий код JavaScript демонстрирует, как создать маркированный список на слайде:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Символические маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов имеет значение. Задайте `BulletFormat.setType` значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/bullettype/). Также можно выбрать формат нумерации с помощью `BulletFormat.setNumberedBulletStyle` или установить `BulletFormat.setNumberedBulletStartWith`, если список должен начинаться с значения, отличного от 1.

Следующий код JavaScript показывает, как создать нумерованный список на слайде:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми рисунками, которые остаются разборчивыми при небольшом размере, например, значками или небольшими прозрачными PNG‑файлами.

{{% alert color="primary" %}}
Идеально, если вы планируете заменить обычный символ маркера изображением, выбрать простой графический элемент с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) с помощью `Presentation.getImages().addImage` и присвойте возвращённый объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) свойству `BulletFormat.getPicture().setImage`. Перед назначением изображения задайте `BulletFormat.setType` значение [BulletType.Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/bullettype/).

Предположим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

Следующий код JavaScript показывает, как создать маркеры‑изображения на слайде:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Результат:

![Маркер‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Используйте `ParagraphFormat.setDepth` для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и так далее.

Следующий код JavaScript показывает, как создать многоуровневый маркированный список:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, обратитесь к нужному абзацу и обновите его настройки `ParagraphFormat.getBullet`. Те же свойства, которые использовались для создания списков, можно применять для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, когда целевой формат поддерживает соответствующее размещение текста и функции маркеров.

**Могу ли я редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, обратитесь к нужному абзацу, просмотрите или обновите его настройки `ParagraphFormat.getBullet` и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**

Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что используемые в презентации шрифты поддерживают необходимые символы.