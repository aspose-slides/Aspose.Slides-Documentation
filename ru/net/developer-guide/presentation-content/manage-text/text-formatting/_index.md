---
title: Форматирование текста
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/net/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание текстовых абзацев
- прозрачность текста
- свойства шрифта параграфа
- семейство шрифтов
- поворот текста
- пользовательский угол поворота
- текстовая рамка
- межстрочное расстояние
- свойство автоматического подбора размера
- якорь текстовой рамки
- табуляция текста
- стиль текста по умолчанию
- C#
- Aspose.Slides для .NET
description: "Управление и манипуляция текстом и свойствами текстовых рамок на C#"
---

## Обзор

Эта статья описывает, как **работать с форматированием текста презентации PowerPoint с использованием C#**, например, выделять текст, применять регулярные выражения, выравнивать текстовые абзацы, устанавливать прозрачность текста, изменять свойства шрифта параграфа, использовать семейства шрифтов, устанавливать поворот текста, настраивать угол поворота, управлять текстовой рамкой, устанавливать межстрочное расстояние, использовать свойство Автоподбор, устанавливать якорь текстовой рамки и изменять табуляцию текста. В статье рассматриваются эти темы.

## **Выделение текста**
В интерфейс ITextFrame и класс TextFrame добавлен новый метод HighlightText.

Он позволяет выделять часть текста цветом фона с помощью текстового образца, подобно инструменту Text Highlight Color в PowerPoint 2019.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с входным файлом.
   - Входной файл может быть PPT, PPTX, ODP и т. д.
3. Получите доступ к слайду с использованием коллекции [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)
4. Получите доступ к фигуре с использованием коллекции [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) как [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Выделите текст с помощью метода [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext).
6. Сохраните презентацию в желаемом выходном формате, т. е. PPT, PPTX или ODP и т. д.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // выделение всех слов 'important'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // выделение всех отдельных вхождений 'the'
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн-сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Выделение текста с использованием регулярного выражения**
В интерфейс ITextFrame и класс TextFrame добавлен новый метод HighlightRegex.

Он позволяет выделять часть текста цветом фона с помощью regex, подобно инструменту Text Highlight Color в PowerPoint 2019.


Ниже приведен фрагмент кода, который показывает, как использовать эту функцию:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // выделение всех слов длиной 10 символов или более
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **Установка цвета фона текста**

Aspose.Slides позволяет вам указать цвет фона для текста.

Этот код на C# показывает, как установить цвет фона для всего текста: 

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

Этот код на C# показывает, как установить цвет фона только для части текста:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Red"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **Выравнивание текстовых абзацев**

Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для .NET поддерживает добавление текста на слайды, но в этой теме мы увидим, как мы можем управлять выравниванием текстовых абзацев на слайде. Пожалуйста, следуйте приведенным ниже шагам, чтобы выровнять текстовые абзацы с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к заполняющим фигурам на слайде и приведите их к типу AutoShape.
4. Получите параграф (который необходимо выровнять) из TextFrame, предоставляемого AutoShape.
5. Выровняйте параграф. Параграф может быть выровнен по правому, левому, центру и по ширине.
6. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```c#
// Создание объекта Presentation, представляющего PPTX файл
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Доступ к первому слайду
    ISlide slide = pres.Slides[0];

    // Доступ к первому и второму заполнительному полю на слайде и приведение к AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Изменение текста в обоих заполнительных полях
    tf1.Text = "Центрирование от Aspose";
    tf2.Text = "Центрирование от Aspose";

    // Получение первого параграфа заполнителей
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Выравнивание текстового абзаца по центру
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // Запись презентации в файл PPTX
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **Установка прозрачности для текста**
Эта статья демонстрирует, как установить свойство прозрачности для любой текстовой фигуры, используя Aspose.Slides для .NET. Чтобы установить прозрачность для текста, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени
4. Запишите презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - прозрачность: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // установка прозрачности на ноль процентов
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Установка межбуквенного расстояния для текста**

Aspose.Slides позволяет вам задать расстояние между буквами в текстовом поле. Таким образом, вы можете отрегулировать визуальную плотность строки или блока текста, расширив или сокращая расстояние между символами.

Этот код на C# показывает, как расширить расстояние для одной строки текста и сократить расстояние для другой строки:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // расширение
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // сжатие

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Управление свойствами шрифта абзацев**

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, чтобы выделить определенные разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям изменять внешний вид и ощущение содержания презентации. Эта статья показывает, как использовать Aspose.Slides для .NET для настройки свойств шрифта абзацев текста на слайдах. Для управления свойствами шрифта абзаца с помощью Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к заполняющим фигурам на слайде и приведите их к типу AutoShape.
4. Получите параграф из TextFrame, предоставляемого AutoShape.
5. Выравняйте абзац по ширине.
6. Получите текстовую порцию абзаца.
7. Определите шрифт с помощью FontData и установите шрифт для текстовой порции соответствующим образом.
   1. Установите шрифт как жирный.
   1. Установите шрифт как курсивный.
8. Установите цвет шрифта, используя FillFormat, предоставленный объектом Portion.
9. Запишите измененную презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она берет неприкрытую презентацию и форматирует шрифты на одном из слайдов.

```c#
// Создание объекта Presentation, представляющего PPTX файл
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Доступ к слайду по его позициям
    ISlide slide = pres.Slides[0];

    // Доступ к первому и второму заполнительному полю на слайде и приведение к AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Доступ к первому абзацу
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Доступ к первой порции
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Определение новых шрифтов
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Присвоение новых шрифтов порции
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Установка шрифта на жирный
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Установка шрифта на курсивный
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Установка цвета шрифта
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // Запись PPTX на диск
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Управление семейством шрифтов текста**
Порция используется для хранения текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для .NET для создания текстового поля с некоторым текстом и затем определения конкретного шрифта и различных других свойств категории семейства шрифтов. Чтобы создать текстовое поле и установить свойства шрифтов текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Прямоугольник на слайд.
4. Удалите стиль заполнения, связанный с AutoShape.
5. Получите доступ к TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Получите доступ к объекту Portion, связанному с TextFrame.
8. Определите шрифт, который будет использоваться для Portion.
9. Установите другие свойства шрифта, такие как жирный, курсивный, подчеркивание, цвет и высота, используя соответствующие свойства, предоставленные объектом Portion.
10. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```c#
// Создание презентации
using (Presentation presentation = new Presentation())
{
   
    // Получение первого слайда
    ISlide sld = presentation.Slides[0];

    // Добавление AutoShape типа Прямоугольник
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Удаление любого стиля заполнения, связанного с AutoShape
    ashp.FillFormat.FillType = FillType.NoFill;

    // Доступ к TextFrame, связанному с AutoShape
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // Доступ к Portion, связанному с TextFrame
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Установка шрифта для Portion
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Установка свойства Bold шрифта
    port.PortionFormat.FontBold = NullableBool.True;

    // Установка свойства Italic шрифта
    port.PortionFormat.FontItalic = NullableBool.True;

    // Установка свойства Underline шрифта
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Установка высоты шрифта
    port.PortionFormat.FontHeight = 25;

    // Установка цвета шрифта
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Запись PPTX на диск 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **Установка размера шрифта для текста**

Aspose.Slides позволяет вам выбрать предпочтительный размер шрифта для существующего текста в абзаце и другого текста, который может быть добавлен в абзац позже.

Этот код на C# показывает, как установить размер шрифта для текстов, содержащихся в абзаце:

```c#
var presentation = new Presentation("example.pptx");

// Получаем первую фигуру, например.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // Получаем первый абзац, например.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Устанавливаем размер шрифта по умолчанию на 20 пунктов для всех текстовых порций в абзаце. 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // Устанавливаем размер шрифта на 20 пунктов для текущих текстовых порций в абзаце. 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Установка поворота текста**

Aspose.Slides для .NET позволяет разработчикам поворачивать текст. Текст можно установить в горизонтальном, вертикальном, вертикальном270, WordArtVertical, EastAsianVertical, MongolianVertical или WordArtVerticalRightToLeft. Чтобы повернуть текст любой TextFrame, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Поверните текст.
6. Сохраните файл на диск.

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation();

// Получение первого слайда 
ISlide slide = presentation.Slides[0];

// Добавление AutoShape типа Прямоугольник
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Добавление TextFrame к Прямоугольнику
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Доступ к текстовой рамке
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// Создание объекта Paragraph для текстовой рамки
IParagraph para = txtFrame.Paragraphs[0];

// Создание объекта Portion для параграфа
IPortion portion = para.Portions[0];
portion.Text = "Мороз и солнце; день чудесный."; 
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Сохранение презентации
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **Установка пользовательского угла поворота для TextFrame**
Aspose.Slides для .NET теперь поддерживает установку пользовательского угла поворота для текстовой рамки. В этой теме мы увидим на примере, как установить свойство RotationAngle в Aspose.Slides. Новое свойство RotationAngle было добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat, позволяя установить пользовательский угол поворота для текстовой рамки. Чтобы установить свойство RotationAngle, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Добавьте график на слайд.
3. Установите свойство RotationAngle.
4. Запишите презентацию в файл PPTX.

В приведенном ниже примере мы устанавливаем свойство RotationAngle.

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Пользовательский заголовок").TextFrameFormat.RotationAngle = -30;

// Сохранение презентации
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Межстрочное расстояние абзаца**
Aspose.Slides предоставляет свойства ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore), и [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) в классе [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), которые позволяют управлять межстрочным расстоянием для абзаца. Три свойства используются следующим образом:

* Чтобы указать межстрочное расстояние для абзаца в процентах, используйте положительное значение. 
* Чтобы указать межстрочное расстояние для абзаца в пунктах, используйте отрицательное значение.

Например, вы можете применить межстрочное расстояние 16pt для абзаца, установив свойство `SpaceBefore` в -16.

Вот как вы указываете межстрочное расстояние для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом.
2. Получите ссылку на слайд по его индексу.
3. Доступ к TextFrame.
4. Получите доступ к абзацу.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот код на C# показывает вам, как указать межстрочное расстояние для абзаца:

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Получение ссылки на слайд по индексу
ISlide sld = presentation.Slides[0];

// Доступ к TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Доступ к абзацу
IParagraph para1 = tf1.Paragraphs[0];

// Установка свойств абзаца
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Сохранение презентации
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **Установка свойства AutofitType для TextFrame**
В этой теме мы рассмотрим различные свойства форматирования текстовой рамки. В этой статье рассматривается, как установить свойство AutofitType для текстовой рамки, якорь текста и поворот текста в презентации. Aspose.Slides для .NET позволяет разработчикам установить свойство AutofitType для любой текстовой рамки. AutofitType может быть установлен на Normal или Shape. Если установлено на Normal, форма останется прежней, в то время как текст будет отрегулирован без изменения самой формы, в то время как если AutofitType установлен на Shape, то форма будет изменена таким образом, чтобы содержать только необходимый текст. Чтобы установить свойство AutofitType текстовой рамки, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Установите AutofitType для TextFrame.
6. Сохраните файл на диск.

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation();

// Получение первого слайда 
ISlide slide = presentation.Slides[0];

// Добавление AutoShape типа Прямоугольник
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Добавление TextFrame к Прямоугольнику
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Доступ к текстовой рамке
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Создание объекта Paragraph для текстовой рамки
IParagraph para = txtFrame.Paragraphs[0];

// Создание объекта Portion для абзаца
IPortion portion = para.Portions[0];
portion.Text = "Мороз и солнце; день чудесный.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Сохранение презентации
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **Установка якоря TextFrame**
Aspose.Slides для .NET позволяет разработчикам устанавливать якорь для любой TextFrame. TextAnchorType указывает, где размещен текст в фигуре. TextAnchorType может быть установлен на Top, Center, Bottom, Justified или Distributed. Чтобы установить якорь для любой TextFrame, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Установите TextAnchorType для TextFrame.
6. Сохраните файл на диск.

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation();

// Получение первого слайда 
ISlide slide = presentation.Slides[0];

// Добавление AutoShape типа Прямоугольник
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Добавление TextFrame к Прямоугольнику
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Доступ к текстовой рамке
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Создание объекта Paragraph для текстовой рамки
IParagraph para = txtFrame.Paragraphs[0];

// Создание объекта Portion для абзаца
IPortion portion = para.Portions[0];
portion.Text = "Мороз и солнце; день чудесный.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Сохранение презентации
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Установка табуляции текста**
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и стандартных табуляций)
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между стандартными табуляциями (3 и 4 в нашем примере).
- EffectiveTabs.GetTabByIndex(index) с индексом = 0 вернет первую явную табуляцию (Position = 731), индекс = 1 - вторую табуляцию (Position = 1241). Если вы попытаетесь получить следующую табуляцию с индексом = 2, это вернет первую стандартную табуляцию (Position = 1470), и так далее.
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Привет, мир!". Чтобы отобразить такой текст, вам нужно знать, с какого места начинать рисовать "мир!". Вначале вы должны вычислить длину "Привет" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции, чтобы нарисовать "мир!".

## **Установка языка проверки**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (предоставленное классом [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)), что позволяет вам установить язык проверки для документа PowerPoint. Язык проверки - это язык, на котором проверяются орфография и грамматика в PowerPoint.

Этот код на C# показывает, как установить язык проверки для PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // установить идентификатор языка проверки
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Установка языка по умолчанию**

Этот код на C# показывает, как установить язык по умолчанию для всей презентации PowerPoint: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Добавление новой прямоугольной фигуры с текстом
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Новый текст";
    
    // Проверка языка первой порции
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **Установка стиля текста по умолчанию**

Если вам нужно применить одно и то же форматирование текста по умолчанию ко всем текстовым элементам презентации сразу, вы можете использовать свойство `DefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) и установить предпочтительное форматирование. Пример кода ниже показывает, как установить жирный шрифт по умолчанию (14 пунктов) для текста на всех слайдах в новой презентации.

```c#
using (Presentation presentation = new Presentation())
{
    // Получение формата абзаца верхнего уровня.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```