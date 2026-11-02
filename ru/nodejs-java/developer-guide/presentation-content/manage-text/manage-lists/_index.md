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
- символный маркер
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
description: "Узнайте, как создавать и форматировать маркированные, маркер‑изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого контролируются через формат абзаца.

Используйте класс [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) для доступа к настройкам списка уровня абзаца. Основной входной пункт — `Paragraph.getParagraphFormat().getBullet()`, который возвращает объект [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/). С помощью этого объекта вы можете установить тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальное число.

Эта статья показывает, как:

- создать маркированный список с пользовательским символом
- создать маркер в виде изображения
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации
- читать фактические маркеры списка и номера рядом с текстом абзаца

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) и установите `BulletFormat.setType` в значение [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Затем можно задать `BulletFormat.setChar`, `BulletFormat.getColor` и `BulletFormat.setHeight` для управления внешним видом маркера.

Следующий код JavaScript демонстрирует, как создать маркированный список на слайде:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

![Символьные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов имеет значение. Установите `BulletFormat.setType` в [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Также можно выбрать формат нумерации с помощью `BulletFormat.setNumberedBulletStyle` или задать `BulletFormat.setNumberedBulletStartWith`, если список должен начинаться с значения, отличного от 1.

Следующий код JavaScript показывает, как создать нумерованный список на слайде:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Создать маркер в виде изображения**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры в виде изображений лучше всего работают с простыми изображениями, которые остаются разборчивыми при небольшом размере, например иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" title="Note" %}}
Оптимально, если вы планируете заменить обычный символ маркера изображением, выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.
{{% /alert %}}

Чтобы создать маркер в виде изображения, добавьте изображение в [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) с помощью `Presentation.getImages().addImage` и присвойте полученный объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) свойству `BulletFormat.getPicture().setImage`. Перед присвоением изображения установите `BulletFormat.setType` в [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).

Допустим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

Следующий код JavaScript показывает, как создать маркеры‑изображения на слайде:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

![Маркеры‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Используйте `ParagraphFormat.setDepth` для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и т.д.

Следующий код JavaScript показывает, как создать многоуровневый маркированный список:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Чтобы изменить форматирование списка в существующей презентации, получайте целевой абзац и обновляйте его настройки `ParagraphFormat.getBullet`. Те же свойства, которые использовались для создания списков, можно применять для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

Следующий код JavaScript меняет первый абзац в текстовом фрейме, чтобы использовать стиль нумерованного списка:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Чтение фактических значений маркеров**

При извлечении содержимого презентации сохраняйте маркеры списка рядом с текстом абзаца. Вызовите [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) и получите [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) , чтобы получить эффективный формат маркера. Проверьте его [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) перед чтением [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Для нумерованных списков различайте три значения:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) определяет формат, например арабские цифры с точкой или строчные буквы с точкой.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) задает начальное число для группы нумерованных абзацев.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) возвращает отформатированный маркер для конкретного абзаца. Например, второй элемент списка, начинающегося с 5, вернёт `6.`.

Сохраняйте значение [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) для каждого абзаца, чтобы удерживать уровень вложенности. Фактический маркер не кодирует всю иерархию: вложенный элемент может вернуть `c.`, а не комбинированную метку вроде `6.c.`.

Следующий автономный пример создает списки, сохраняет их в презентацию и повторно загружает презентацию, чтобы вывести текст каждого абзаца, глубину, тип маркера и фактическое значение. Маленький синий маркер‑изображение создаётся из встроенного SVG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Создать маркер‑изображение без внешнего файла изображения.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Исходные списки показаны ниже.

![Списки, начинающиеся с 5, вложенные элементы с буквами и римскими цифрами, символьный маркер, абзац без маркера и синий маркер‑изображение](actual_bullet_values.png)

Отчёт соответствует маркерам, отображаемым в PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Для [BulletType.None и BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) метод [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) возвращает `null`, а не пустую строку. Обрабатывайте эти типы отдельно: первый не имеет маркера, второй требует отдельного извлечения изображения маркера. Маркер‑изображение нельзя воспроизвести только путем извлечения текстового маркера.

## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующую раскладку текста и функции маркеров.

**Можно ли редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, получите целевой абзац, проверьте или обновите его настройки `ParagraphFormat.getBullet` и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**

Да. Текст элементов списка может содержать Unicode‑символы, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые вам символы.