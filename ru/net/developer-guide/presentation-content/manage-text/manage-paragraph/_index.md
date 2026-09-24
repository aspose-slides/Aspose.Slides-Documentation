---
title: Управление абзацами текста PowerPoint в .NET
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
description: "Узнайте, как создать и отформатировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET представляет текст как иерархию текстовых рамок, абзацев и частей:

* [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) представляет контейнер текста в фигуре и обеспечивает доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) представляет один абзац в текстовой рамке и обеспечивает доступ к её частям и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) представляет часть текста внутри абзаца. Каждая часть может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько частей.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими частями**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) для каждого абзаца, чтобы в нём было три части. Абзац по умолчанию уже содержит одну пустую часть.
7. Установите текст для каждой части.
8. Примените форматирование уровня символов через [IPortion.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/portionformat/).
9. Сохраните изменённую презентацию.

Этот пример на C# реализует эти шаги:

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

### **Создание маркированного или нумерованного списка**

Маркировка и нумерация упрощают просмотр связанных элементов. В Aspose.Slides параметры списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) для символа‑маркировки.
7. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/) и укажите символ маркировки.
8. Установите текст абзаца, отступ, цвет маркировки и высоту маркировки.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/).
11. Настройте стиль нумерованной маркировки и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на C# создает символ‑маркировку и нумерованную маркировку:

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

### **Использование графических маркеров**

Графические маркеры позволяют использовать собственное изображение вместо символа или цифры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и получите его [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) и задайте его текст.
7. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/).
8. Назначьте изображение через [IBulletFormat.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/picture/) и задайте высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на C# создаёт графический маркер:

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

Установите [IParagraphFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/depth/) , чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и очистите от абзаца по умолчанию его текстовую рамку.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [IParagraphFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/depth/) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на C# создаёт четырёхуровневый маркированный список:

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

### **Задание пользовательского начального номера в нумерованных списках**

Используйте [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith/) , чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith/) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на C# назначает пользовательский начальный номер каждому абзацу:

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

## **Управление макетом абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте свойство [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы управлять отступом первой строки абзаца. Это свойство сдвигает только первую строку относительно левого поля абзаца. Положительное значение перемещает первую строку вправо, остальные строки остаются выровнены по телу абзаца.

Используйте [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) , когда необходимо переместить весь абзац. Используйте [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , когда нужно переместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет разные значения [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , демонстрируя, как отступ первой строки влияет на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) .
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

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

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью свойства [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) . Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) определяет левое положение тела абзаца, а [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) .
6. Задайте отрицательное значение [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы получить эффект висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

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

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств конечного фрагмента абзаца**

Свойство [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/endparagraphportionformat/) управляет форматированием конечного знака абзаца. Ниже приведён пример, который задаёт размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и очистите её от абзаца по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые части.
4. Создайте объект [PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/portionformat/) для конечного знака второго абзаца.
5. Установите [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fontheight/) и [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/latinfont/) .
6. Назначьте формат [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/endparagraphportionformat/) и сохраните презентацию.

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

Используйте [IParagraph.GetLinesCount](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getlinescount/) , чтобы посчитать строки, занятые абзацем после раскладки текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац является одним элементом в [ITextFrame.Paragraphs](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/paragraphs/), и он может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет перейти на новую строку без создания нового абзаца. Автоматический перенос создаёт строки на основе доступной ширины, не вставляя явные разрывы в текст. Поэтому подсчёт абзацев или символов разрыва строки не даёт количества отрисованных строк.

Следующий пример создаёт текстовую фигуру, подсчитывает её строки, сужает фигуру, а затем заменяет текст более короткой строкой. Перенос включён, а автоподгонка отключена, чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Размеры фигур указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке.

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

С этим текстом и этими размерами сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные счётчики могут различаться в зависимости от доступных шрифтов и их замены, размера шрифта, полей, отступов, переноса и настроек автоподгонки. При проверке шаблона используйте шрифты и параметры макета, предназначенные для целевой среды.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высоты строк, интервалы между абзацами и строками, а также поведение автоподгонки; даже одна строка может превысить доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзаца**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/addfromhtml/) , чтобы преобразовать разметку HTML в абзацы и части в текстовой рамке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите слайд и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) .
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) фигуры и очистите её от абзаца по умолчанию.
4. Прочитайте исходный файл HTML.
5. Передайте строку HTML в [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Сохраните изменённую презентацию.

Этот пример на C# импортирует HTML в текстовую рамку:

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

Используйте [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/exporttohtml/) , чтобы экспортировать выбранный диапазон абзацев в виде HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) и загрузите нужную презентацию.
2. Получите слайд и найдите [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) , содержащий текст.
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) фигуры.
4. Вызовите [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/exporttohtml/) с индексом начального абзаца и количеством абзацев для экспорта.
5. Запишите полученную строку HTML в файл.

Этот пример на C# экспортирует все абзацы из первой текстовой фигуры:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Отрисовка абзаца как изображения**

[IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) отрисовывает отдельный абзац напрямую и возвращает объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) . Сохраните результат в файл или поток с помощью [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/save/) . Нет необходимости отрисовывать содержащую фигуру или вручную обрезать растровое изображение.

[IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) может вернуть `null`, если абзац не найден в родительской коллекции, у него нет действительных границ отрисовки или он не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример отрисовывает второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Объявление `using` гарантирует правильное освобождение изображения.

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

Используйте перегрузку [IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) , принимающую параметры `float scaleX` и `float scaleY` , чтобы задать горизонтальные и вертикальные коэффициенты масштабирования. Пример ниже создаёт таблицу, отрисовывает абзац в её первой ячейке при двойной ширине и высоте по сравнению с масштабом по умолчанию и сохраняет результат в виде PNG‑изображения.

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

Коэффициент масштаба `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обоих коэффициентов создаёт изображение, ширина и высота которого приблизительно вдвое больше стандартных размеров, что приводит к четырём раз больше пикселей. Большие коэффициенты обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают расход памяти и размер файла. Коэффициенты ниже `1` создают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [IShape.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getimage/) остаётся полезной, когда в выводе должны присутствовать заливка, граница или иной визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) .

## **FAQ**

**Могу ли я полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/wraptext/) , чтобы отключить перенос, и строки не будут разбиваться у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getrect/) , чтобы получить ограничивающий прямоугольник абзаца. [IPortion.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getrect/) предоставляет границы отдельной части.

**Где управляется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных частей.

**Могу ли я задать язык проверки орфографии для части абзаца?**

Да. Установите [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/) для отдельных частей, чтобы один абзац мог содержать текст на нескольких языках.