---
title: Управление маркированными и нумерованными списками в презентациях на .NET
linktitle: Управление списками
type: docs
weight: 70
url: /ru/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и форматировать маркированные, изображённые, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка представляет собой абзац, настройки маркера которого управляются через формат абзаца.

Используйте свойство [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/paragraphformat/) для доступа к настройкам списка уровня абзаца. Основная точка входа — [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/bullet/), которая возвращает объект [IBulletFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/). С помощью этого объекта вы можете задавать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальное число.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) в [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) и установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/). Затем можно задать [IBulletFormat.Char](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/color/), и [IBulletFormat.Height](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/height/) для управления внешним видом маркера.

Следующий код на C# демонстрирует, как создать маркированный список на слайде:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Результат:

![Символические маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Нумерованные списки используют, когда порядок элементов имеет значение. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/). Вы также можете выбрать формат нумерации с помощью [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstyle/) или задать [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith/), если список должен начинаться с числа, отличного от 1.

Следующий код на C# показывает, как создать нумерованный список на слайде:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми картинками, которые остаются разборчивыми при небольшом размере, например, иконками или небольшими PNG‑файлами с прозрачным фоном.

{{% alert color="info" %}}
В идеале, если вы планируете заменить обычный символ маркера изображением, лучше выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [Presentation.Images](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/images/) и присвойте полученный объект изображения свойству [IBulletFormat.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/picture/). Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/) перед присвоением изображения.

Предположим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

Следующий код на C# показывает, как создать маркер‑изображения в слайде:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Результат:

![Маркер‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Используйте [IParagraphFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/depth/) для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним, и т.д.

Следующий код на C# показывает, как создать многоуровневый маркированный список:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, получите целевой абзац и обновите его настройки [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/bullet/). Те же свойства, которые используются для создания списков, можно применять для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Часто задаваемые вопросы**

### Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?

Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующее размещение текста и функции маркеров.

### Могу ли я редактировать списки в существующих презентациях?

Да. Загрузите презентацию, получите целевой абзац, просмотрите или обновите его настройки [IParagraphFormat.Bullet] и сохраните презентацию.

### Могут ли списки содержать нелатинский текст?

Да. Текст элементов списка может содержать Unicode‑символы, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые вам символы.