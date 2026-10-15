---
title: Управление абзацами PowerPoint в .NET
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
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
- экспортировать абзац
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides для .NET представляет текст как иерархию текстовых фреймов, абзацев и частей:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к его коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его частям и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) представляет фрагмент текста внутри абзаца. Каждая часть может иметь собственный текст и форматирование на уровне символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько частей.

## **Создание и форматирование абзацев**

Создавайте абзацы в текстовом фрейме фигуры и используйте части для форматирования отдельных фрагментов текста. Этот раздел показывает, как объединять несколько частей внутри каждого абзаца и применять разные цвета, размеры шрифтов и стили.

### **Создание абзацев с несколькими частями**

Следующий пример на C# создает три абзаца, каждый из которых содержит три фрагмента текста в своей коллекции [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). Он повторно использует абзац по умолчанию и его пустую часть, затем добавляет оставшиеся абзацы и части. Форматирование применяется через [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): первая часть в каждом абзаце красная, полужирная и размером 15 пунктов; вторая — синяя, курсив и 18 пунктов. Третья часть сохраняет форматирование по умолчанию:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Создание маркированных и нумерованных списков**

Организуйте текст абзацев в списки с символами, цифрами или пользовательскими изображениями. Примеры в этом разделе охватывают форматирование маркеров, многоуровневые списки и пользовательские начальные номера.

### **Создание маркированного или нумерованного списка**

Маркеры и нумерация упрощают сканирование связанных элементов. В Aspose.Slides настройки списка определяются через [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Этот пример на C# добавляет символический маркер и нумерованный элемент в один и тот же текстовый фрейм. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) выбирает тип маркера, [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) задает символ, а [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) выбирает стиль нумерации. Оба элемента используют черные маркеры высотой 100 процентов и отступ абзаца 25 пунктов:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Использование маркеров‑картинок**

Маркеры‑картинки позволяют использовать пользовательское изображение вместо символа или числа.

Этот пример на C# добавляет изображение в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) и использует его в качестве маркера абзаца. Он устанавливает [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) для использования маркера‑картинки и присваивает изображение через [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) задается как 100 процентов, чтобы размер маркера был относительно текста абзаца:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Создание многоуровневого списка**

Установите [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) , чтобы поместить абзацы на разные уровни списка. Верхний уровень имеет глубину `0`.

Этот пример на C# присваивает значения [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) от 0 до 3 четырём абзацам, создавая иерархию внутри одного текстового фрейма. Каждый абзац использует символический маркер, при этом [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) чередуется между круглым маркером и дефисом, чтобы различать соседние уровни:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Начало нумерованных пунктов со пользовательских значений**

Используйте [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) для установки начального номера, отображаемого для нумерованного абзаца.

Этот пример на C# устанавливает [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) для использования нумерации в трёх абзацах и задаёт значения [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 2, 3 и 7. Начальное значение задаётся отдельно для каждого абзаца, позволяя пропускать номера:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Управление макетом абзаца и свойствами окончания**

Настройте отступы и инденты абзаца, чтобы управлять позицией первой строки и перенесённых строк. Вы также можете форматировать знак конца абзаца отдельно от видимых частей текста.

### **Установка отступа первой строки**

Используйте свойство [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) для контроля отступа первой строки абзаца. Это свойство перемещает только первую строку относительно левого отступа абзаца. Положительное значение смещает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) когда нужно переместить весь абзац. Используйте [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) когда нужно переместить только первую строку.

Следующий пример задаёт трём абзацам одинаковый [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) в 20 пунктов и значения [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 0, 20 и 40 пунктов. Первые линии начинаются с постепенно увеличивающихся смещений, тогда как перенесённые строки сохраняют тот же левый отступ:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Результат:

![Отступ первой строки у абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это макет абзаца, при котором первая строка начинается слева от остальных строк. В Aspose.Slides вы создаёте этот эффект с помощью свойства [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Задайте `Indent` отрицательным, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) определяет левую позицию тела абзаца, а [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) задаёт позицию первой строки относительно этого отступа. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

Следующий пример на C# сочетает значения [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 40 и 60 пунктов с значениями [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) -20 и -30 пунктов. В каждом абзаце первая строка начинается слева от перенесённых строк; во втором абзаце висячий отступ глубже:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Результат:

![Висячий отступ у абзацев](hanging_indent.png)

### **Установка свойств конечного фрагмента абзаца**

Свойство [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) контролирует форматирование знака окончания абзаца. Следующий пример создаёт [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) с [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 48 пунктов и [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) Times New Roman. Этот формат назначается знаку окончания второго абзаца, оставляя видимые части текста без изменений:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Подсчёт отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Управление разрывом строк](/slides/ru/net/text-formatting/#control-line-breaking) и [Управление висячей пунктуацией](/slides/ru/net/text-formatting/#control-hanging-punctuation).

Используйте [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) для подсчёта строк, занимаемых абзацем после разметки текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац — один элемент в [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), и он может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет перейти на новую строку без создания другого абзаца. Автоматический перенос создаёт строки на основе доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строк не даёт количества отрисованных строк.

Следующий пример создаёт текстовую фигуру, считает её строки, сужает фигуру и затем заменяет текст более короткой строкой. Пример включает включение [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) и отключение [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/), чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Каждый измерение использует [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк во всем текстовом фрейме.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

При этих тексте и размерах сужение фигуры увеличивает количество строк, тогда как замена текста на короткую строку уменьшает его. Точные подсчёты могут варьироваться в зависимости от доступности шрифтов и их подстановки, размера шрифта, отступов, индентов, переноса и параметров автоподгонки. Используйте шрифты и настройки макета, предназначенные для целевой среды, при проверке шаблона.

Само количество строк не определяет, переполняет ли текст контейнер. Важны доступная высота, высота строк, межстрочный и абзацный интервалы, а также поведение автоподгонки; даже одна строка может выйти за пределы ширины, если перенос отключён.

## **Импорт и экспорт содержимого абзацев**

Используйте HTML для импорта текста в презентацию или экспорта существующих абзацев для внешнего использования. Этот раздел также показывает, как отрисовывать отдельные абзацы как изображения, включая абзацы в ячейках таблиц.

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) для преобразования HTML‑разметки в абзацы и части в текстовом фрейме.

Этот пример на C# читает HTML из файла и передаёт разметку в [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Он очищает абзац по умолчанию в текстовом фрейме, чтобы фрейм содержал только импортированный контент. Прямоугольная фигура оставляет 10‑пунктовый отступ со всех сторон слайда:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) для экспорта выбранного диапазона абзацев в HTML. При повторном использовании текста презентации на веб‑сайте вы можете захотеть сохранить локальное выделение без переноса шрифта, размера или стилей текстового поля презентации. Установите [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) для управления глубиной наследования форматирования экспортёром.

Скачайте [sample presentation](text-inheritance.pptx) и поместите её в рабочий каталог приложения. Его первый слайд содержит одну текстовую фигуру с текстом «Inherited text; explicit red 18pt». Входные данные намеренно используют несколько уровней форматирования:

- Стиль текста по умолчанию презентации задаёт Calibri размером 28 pt.
- Стиль первого уровня текстового фрейма задаёт синий цвет и курсив.
- Абзац явно задаёт полужирный текст.
- Вторая часть, «explicit red 18pt», явно задаёт красный цвет и размер 18 pt.

Следующий полностью готовый пример экспортирует те же абзацы трижды. Он передаёт [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) в метод экспорта и пишет каждый результат в отдельный UTF‑8 HTML‑файл:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Сгенерированный HTML содержит следующий CSS для первой части, «Inherited text; ». Таблица перечисляет соответствующие декларации; другие сгенерированные свойства опущены для ясности.

| Вывод | Соответствующий CSS для первой части | Внешний вид |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст размером 28 pt в Calibri, если шрифт доступен. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст; шрифт и размер задаются страницей или браузером. |
| `ParagraphOnly.html` | `font-weight:bold` | Полужирный текст; шрифт, размер, цвет и курсив задаются страницей или браузером. |

Вторая часть сохраняет `color:#ff0000`, `font-size:18pt` и `font-weight:bold` во всех трёх выводах. Она также сохраняет курсив в `All` и `TextBox`, но не в `ParagraphOnly`. Ограничение наследования therefore does not remove formatting explicitly assigned to a paragraph or portion.

Откройте файлы в одном браузере для сравнения. В двух ограниченных режимах опущенные свойства CSS разрешаются стилями целевой страницы или настройками браузера, поэтому итоговый вид зависит от места использования HTML.

### **Отрисовка абзаца как изображения**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) отрисовывает отдельный абзац напрямую и возвращает [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Не требуется отрисовывать содержащую фигуру или вручную обрезать bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) может возвращать `null`, если абзац не найден в его родительской коллекции, нет действительных границ отрисовки или он не может быть отрисован. Проверьте результат перед сохранением и освобождайте полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Пример использует презентацию с одним слайдом, первый объект которой — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример выбирает второй абзац с индексом 1 и вызывает [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) без параметров масштаба. Он проверяет, что фигура содержит требуемый абзац и что отрисовка вернула изображение, перед тем как вызвать [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) для сохранения в формате PNG. Оператор `using` освобождает изображение после использования.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Отрисовка абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/), принимающую параметры `float scaleX` и `float scaleY`, чтобы задать горизонтальный и вертикальный коэффициенты масштабирования. Следующий пример создаёт таблицу, отрисовывает абзац в её первой ячейке с двойной шириной и высотой по сравнению с размером по умолчанию и сохраняет результат в PNG‑изображение.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Коэффициент масштабирования `1` оставляет соответствующую ось в её стандартном размере пикселей. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое больше стандартных размеров, что приводит к четырём раз больше пикселей. Большие коэффициенты обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` дают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка целой фигуры с помощью [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) остаётся полезной, когда необходимо включить заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) для отключения переноса, чтобы строки не разбивались по краям текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) для получения ограничивающего прямоугольника абзаца. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) предоставляет границы отдельной части.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) — это настройка уровня абзаца и применяется к всему абзацу независимо от форматирования отдельных частей.

Чтобы вертикально выровнять части с разными размерами шрифтов в каждой строке, см. [Align Fonts Within a Line](/slides/ru/net/text-formatting/#align-fonts-within-a-line).

**Можно ли задать язык проверки правописания для части абзаца?**

Да. Установите [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) для отдельных частей, чтобы один абзац мог содержать текст на разных языках.