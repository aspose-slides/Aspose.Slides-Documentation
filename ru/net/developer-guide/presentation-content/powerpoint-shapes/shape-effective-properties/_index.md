---
title: Эффективные Свойства Формы
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords: "Свойства формы, Свойства камеры, осветительное оборудование, фаска формы, текстовая рамка, стиль текста, значение высоты шрифта, формат заполнения для таблицы, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Получение эффективных свойств формы в презентациях PowerPoint на C# или .NET"
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы устанавливаем значения напрямую на этих уровнях

1. В свойствах выделенного текста на слайде выделенного текста.
1. В стиле текста прототипа формы на макете или главном слайде (если у формы текстовой рамки есть один).
1. В глобальных текстовых настройках презентации.

тогда эти значения называются **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но в конечном итоге, когда приложению нужно знать, как должно выглядеть выделение, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

Следующий пример показывает, как получить эффективные значения.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```


## **Получение Эффективных Свойств Камеры**
Aspose.Slides для .NET позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс **CameraEffectiveData**. Класс CameraEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства для камеры.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Эффективные свойства камеры =");
	Console.WriteLine("Тип: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Угол обзора: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Масштаб: " + threeDEffectiveData.Camera.Zoom);
}
```


## **Получение Эффективных Свойств Осветительного Оборудования**
Aspose.Slides для .NET позволяет разработчикам получать эффективные свойства Осветительного Оборудования. Для этой цели в Aspose.Slides был добавлен класс **LightRigEffectiveData**. Класс LightRigEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства осветительного оборудования. Экземпляр класса **LightRigEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий кодовый пример показывает, как получить эффективные свойства для Осветительного Оборудования.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Эффективные свойства осветительного оборудования =");
	Console.WriteLine("Тип: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Направление: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Получение Эффективных Свойств Фаски Формы**
Aspose.Slides для .NET позволяет разработчикам получать эффективные свойства Фаски Формы. Для этой цели в Aspose.Slides был добавлен класс **ShapeBevelEffectiveData**. Класс ShapeBevelEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства рельефа лицевой стороны формы. Экземпляр класса **ShapeBevelEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий кодовый пример показывает, как получить эффективные свойства для Фаски Формы.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Эффективные свойства верхнего рельефа формы =");
	Console.WriteLine("Тип: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Ширина: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Высота: " + threeDEffectiveData.BevelTop.Height);
}
```


## **Получение Эффективных Свойств Текстовой Рамки**
С помощью Aspose.Slides для .NET вы можете получить эффективные свойства Текстовой Рамки. Для этой цели в Aspose.Slides был добавлен класс **TextFrameFormatEffectiveData**, который содержит эффективные свойства форматирования текстовой рамки.

Следующий кодовый пример показывает, как получить эффективные свойства форматирования текстовой рамки.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Тип закрепления: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Тип автоформатирования: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Тип вертикального текста: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Поля");
	Console.WriteLine("   Слева: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Сверху: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Справа: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Снизу: " + effectiveTextFrameFormat.MarginBottom);
}
```


## **Получение Эффективных Свойств Стиля Текста**
С помощью Aspose.Slides для .NET вы можете получить эффективные свойства Стиля Текста. Для этой цели в Aspose.Slides был добавлен класс **TextStyleEffectiveData**, который содержит эффективные свойства стиля текста.

Следующий кодовый пример показывает, как получить эффективные свойства стиля текста.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Эффективное форматирование абзаца для уровня стиля #" + i + " =");

        Console.WriteLine("Глубина: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Отступ: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Выравнивание: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Выравнивание шрифта: " + effectiveStyleLevel.FontAlignment);
    }
}
```


## **Получение Эффективного Значения Высоты Шрифта**
С помощью Aspose.Slides для .NET вы можете получить эффективные свойства Высоты Шрифта. Вот код, демонстрирующий изменение эффективного значения высоты шрифта выделенного текста после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Пример текста с первым выделением");
    IPortion portion1 = new Portion(" и вторым выделением.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Эффективная высота шрифта сразу после создания:");
    Console.WriteLine("Выделение #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Выделение #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Эффективная высота шрифта после установки высоты шрифта для всей презентации:");
    Console.WriteLine("Выделение #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Выделение #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Эффективная высота шрифта после установки высоты шрифта по умолчанию для абзаца:");
    Console.WriteLine("Выделение #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Выделение #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Эффективная высота шрифта после установки высоты шрифта для выделения #0:");
    Console.WriteLine("Выделение #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Выделение #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Эффективная высота шрифта после установки высоты шрифта для выделения #1:");
    Console.WriteLine("Выделение #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Выделение #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **Получение Эффективного Формата Заполнения для Таблицы**
С помощью Aspose.Slides для .NET вы можете получить эффективное форматирование заполнения для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс **IFillFormatEffectiveData**, который содержит эффективные свойства форматирования заполнения. Обратите внимание, что форматирование ячеек всегда имеет более высокий приоритет, чем форматирование строк, строка имеет более высокий приоритет, чем столбец, а столбец выше, чем вся таблица.

Таким образом, свойства **CellFormatEffectiveData** всегда используются для рисования таблицы. Следующий кодовый пример показывает, как получить эффективное форматирование заполнения для различных логических частей таблицы.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```