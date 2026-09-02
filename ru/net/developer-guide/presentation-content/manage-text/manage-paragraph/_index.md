---
title: Управление текстовыми абзацами PowerPoint в .NET
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
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides для .NET представляет текст как иерархию текстовых фреймов, абзацев и фрагментов:

* [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовый фрейм с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) в текстовый фрейм.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) , чтобы каждый абзац содержал три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст для каждого фрагмента.
8. Примените форматирование уровня символов через [IPortion.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/portionformat/).
9. Сохраните изменённую презентацию.

Следующий пример на C# реализует эти шаги:

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

Маркировка и нумерация упрощают просмотр связанных пунктов. В Aspose.Slides настройки списка задаются через [IBulletFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы.
5. Удалите абзац по умолчанию из текстового фрейма.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) для символа буллета.
7. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/) и укажите символ буллета.
8. Установите текст абзаца, отступ, цвет буллета и высоту буллета.
9. Добавьте абзац в текстовый фрейм.
10. Создайте второй абзац и установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/).
11. Настройте стиль нумерованного буллета и добавьте абзац в текстовый фрейм.
12. Сохраните презентацию.

Следующий пример на C# создаёт символный буллет и нумерованный буллет:

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

### **Использование пунктов с изображениями**

Пункты с изображениями позволяют использовать пользовательскую картинку вместо символа или номера.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и получите его [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстового фрейма.
5. Загрузите изображение буллета и добавьте его в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) и задайте его текст.
7. Установите [IBulletFormat.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/type/) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/bullettype/).
8. Назначьте изображение через [IBulletFormat.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/picture/) и укажите высоту буллета.
9. Добавьте абзац в текстовый фрейм.
10. Сохраните изменённую презентацию.

Следующий пример на C# создаёт пункт с изображением:

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

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и получите слайд.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и очистите абзац по умолчанию из его текстового фрейма.
3. Создайте четыре абзаца и настройте их символы буллетов.
4. Установите значения [IParagraphFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/depth/) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Следующий пример на C# создаёт четырёхуровневый маркированный список:

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

### **Начало нумерованных пунктов списка с пользовательских значений**

Используйте [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith/) , чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте [Presentation] и добавьте [IAutoShape] на слайд.
2. Очистите абзац по умолчанию из текстового фрейма формы.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith/) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Следующий пример на C# назначает пользовательский начальный номер каждому абзацу:

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

## **Управление расположением абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте свойство [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы управлять отступом первой строки абзаца. Это свойство смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, а остальные строки остаются выровнены по телу абзаца.

Используйте [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) , когда нужно переместить весь абзац. Используйте [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , когда нужно переместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет различные значения [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы продемонстрировать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы и удалите абзац по умолчанию.
5. Создайте несколько абзацев и установите для них разные значения [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) .
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

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

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides вы создаёте этот эффект с помощью свойства [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) . Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) определяет левую позицию тела абзаца, а [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где строки переноса должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) .
6. Установите отрицательное значение [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

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

Свойство [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/endparagraphportionformat/) управляет форматированием конечного маркера абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного маркера второго абзаца:

1. Загрузите [Presentation] и получите слайд.
2. Добавьте [IAutoShape] и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/portionformat/) для конечного маркера второго абзаца.
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

## **Импорт и экспорт содержимого абзаца**

### **Импорт HTML-текста в абзацы**

Используйте [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/addfromhtml/) , чтобы преобразовать разметку HTML в абзацы и фрагменты в текстовом фрейме.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите слайд и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) .
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы и очистите её абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Сохраните изменённую презентацию.

Следующий пример на C# импортирует HTML в текстовый фрейм:

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

Используйте [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/exporttohtml/) , чтобы экспортировать выбранный диапазон абзацев в формате HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) и загрузите нужную презентацию.
2. Получите слайд и найдите [IAutoShape] , содержащий текст.
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) формы.
4. Вызовите [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/exporttohtml/) , указав индекс начального абзаца и количество абзацев для экспорта.
5. Запишите полученную строку HTML в файл.

Следующий пример на C# экспортирует все абзацы из первой текстовой фигуры:

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

[IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) отрисовывает отдельный абзац напрямую и возвращает объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) . Сохраните результат в файл или поток с помощью [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/save/) . Вам не нужно отрисовывать содержащую форму или вручную обрезать bitmap.

Метод [IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет допустимых границ отрисовки или не может быть отрисован. Проверьте результат перед сохранением и после использования освободите полученное изображение.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример отрисовывает второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Объявление `using` гарантирует корректное освобождение изображения.

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

Используйте перегрузку [IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) , принимающую параметры `float scaleX` и `float scaleY` , чтобы задать горизонтальный и вертикальный коэффициенты масштабирования. Следующий пример создаёт таблицу, отрисовывает абзац в её первой ячейке в два раза шире и выше, чем по умолчанию, и сохраняет результат в виде PNG‑изображения.

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

Коэффициент масштабирования `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обеих осей создаёт изображение, ширина и высота которого примерно вдвое больше стандартных, что даёт в четыре раза больше пикселей. Большие коэффициенты обычно обеспечивают более чёткий текст при масштабировании или выводе в высоком разрешении, но также увеличивают использование памяти и размер файла. Коэффициенты ниже `1` дают более небольшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [IShape.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getimage/) остаётся полезной, когда вывод должен включать заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getimage/) .

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/wraptext/) , чтобы отключить перенос, и строки не будут разрываться у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getrect/) , чтобы получить ограничивающий прямоугольник абзаца. [IPortion.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getrect/) даёт границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии для части абзаца?**

Да. Установите [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.