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
  - символический маркер
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
description: "Узнайте, как создавать и форматировать маркированные, маркеры‑изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого управляются через формат абзаца.

Используйте свойство [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) для доступа к настройкам списка на уровне абзаца. Основной точкой входа является [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), который возвращает объект [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/). С помощью этого объекта можно задать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальный номер.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации
- читать фактические маркеры списка и номера рядом с текстом абзаца

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) в [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) и установите [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Затем можно задать [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) и [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) для управления внешним видом маркера.

В следующем примере кода C# показано, как создать маркированный список на слайде:

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

![Символные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда важен порядок элементов. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Можно также выбрать формат нумерации с помощью [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) или задать [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/), когда список должен начинаться с значения, отличного от 1.

В следующем примере кода C# показано, как создать нумерованный список на слайде:

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

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми изображениями, которые остаются разборчивыми при небольшом размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" title="Note" %}}
В идеале, если вы планируете заменить обычный символ маркера изображением, лучше выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркера.

Имейте в виду, что изображение будет уменьшено до очень маленького размера. По этой причине мы настоятельно рекомендуем выбирать изображение, которое остаётся чётким и визуально эффективным, когда используется в качестве маркера в списке.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) и присвойте полученный объект изображения свойству [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Установите [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) перед назначением изображения.

Допустим, у нас есть "image.png":

![Изображение для маркеров](picture_for_bullets.png)

В следующем примере кода C# показано, как создать маркеры‑изображения на слайде:

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

Используйте [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и так далее.

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

Чтобы изменить форматирование списка в существующей презентации, получите целевой абзац и обновите его настройки [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/). Те же свойства, которые использовались для создания списков, могут быть использованы для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

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

## **Читать фактические значения маркеров**

При извлечении содержимого презентации сохраняйте маркеры списка рядом с текстом абзаца. Вызовите [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) и получите доступ к [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) для получения эффективного формата маркера. Проверьте его [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) перед чтением [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

Для нумерованных списков различайте эти три значения:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) определяет формат, например, арабские числа с точкой или строчные буквы с точкой.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) задаёт начальный номер для группы нумерованных абзацев.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) возвращает отформатированный маркер для конкретного абзаца. Например, второй элемент в списке, начинающемся с 5, возвращает `6.`.

Сохраняйте [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) у каждого абзаца, чтобы удерживать его уровень вложенности. Фактический маркер не кодирует всю иерархию: вложенный элемент может вернуть `c.` вместо комбинированного ярлыка, например `6.c.`.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Создайте маркер‑изображение без внешнего файла изображения.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Исходные списки показаны ниже.

![Списки, начинающиеся с 5, вложенные элементы с буквами и римскими цифрами, символический маркер, абзац без маркера и синий маркер‑изображение](actual_bullet_values.png)

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

Для [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) возвращает `null`, а не пустую строку. Обрабатывайте эти типы отдельно: у первого нет маркера, у второго требуется отдельное извлечение изображения маркера. Маркер‑изображение нельзя воссоздать, только извлекая текстовый маркер.

## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, когда целевой формат поддерживает соответствующее расположение текста и функции маркеров.

**Могу ли я редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, получите целевой абзац, просмотрите или обновите его настройки [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**

Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что используемые в презентации шрифты поддерживают необходимые символы.