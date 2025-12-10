---
title: Получить эффективные свойства формы из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства формы
- свойства камеры
- система освещения
- фаска формы
- текстовый кадр
- стиль текста
- высота шрифта
- формат заполнения
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for .NET вычисляет и применяет эффективные свойства формы для точного рендеринга PowerPoint."
---

В этой теме мы рассмотрим **effective** и **local** свойства. Когда мы задаем значения непосредственно на этих уровнях

1. В свойствах части на слайде части.  
1. В стиле текста прототипа формы на макете или слайде‑шаблоне (если у формы текстового кадра части есть стиль).  
1. В глобальных настройках текста презентации.

тогда такие значения называют **local** значениями. На любом уровне **local** значения могут быть определены или опущены. Но в конечном итоге, когда приложению необходимо знать, как должна выглядеть часть, оно использует **effective** значения. Получить effective значения можно, используя метод **getEffective()** из локального формата.

Следующий пример демонстрирует, как получить effective значения.
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


## **Получить effective свойства камеры**
Aspose.Slides for .NET позволяет разработчикам получать effective свойства камеры. Для этой цели в Aspose.Slides добавлен класс **CameraEffectiveData**. Класс CameraEffectiveData представляет собой неизменяемый объект, содержащий effective свойства камеры. Экземпляр класса **CameraEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой effective значений для класса ThreeDFormat.

Следующий образец кода демонстрирует, как получить effective свойства камеры.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **Получить effective свойства Light Rig**
Aspose.Slides for .NET позволяет разработчикам получать effective свойства Light Rig. Для этой цели в Aspose.Slides добавлен класс **LightRigEffectiveData**. Класс LightRigEffectiveData представляет собой неизменяемый объект, содержащий effective свойства светового оборудования. Экземпляр класса **LightRigEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой effective значений для класса ThreeDFormat.

Следующий образец кода демонстрирует, как получить effective свойства Light Rig.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Получить effective свойства Bevel Shape**
Aspose.Slides for .NET позволяет разработчикам получать effective свойства Bevel Shape. Для этой цели в Aspose.Slides добавлен класс **ShapeBevelEffectiveData**. Класс ShapeBevelEffectiveData представляет собой неизменяемый объект, содержащий effective свойства рельефа грани формы. Экземпляр класса **ShapeBevelEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой effective значений для класса ThreeDFormat.

Следующий образец кода демонстрирует, как получить effective свойства Bevel Shape.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```


## **Получить effective свойства Text Frame**
С помощью Aspose.Slides for .NET вы можете получить effective свойства Text Frame. Для этой цели в Aspose.Slides добавлен класс **TextFrameFormatEffectiveData**, содержащий effective свойства форматирования текстового кадра.

Следующий образец кода демонстрирует, как получить effective свойства форматирования текстового кадра.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```


## **Получить effective свойства Text Style**
С помощью Aspose.Slides for .NET вы можете получить effective свойства Text Style. Для этой цели в Aspose.Slides добавлен класс **TextStyleEffectiveData**, содержащий effective свойства текстового стиля.

Следующий образец кода демонстрирует, как получить effective свойства текстового стиля.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```


## **Получить effective значение высоты шрифта**
С помощью Aspose.Slides for .NET вы можете получить effective свойства высоты шрифта. Ниже показан код, демонстрирующий изменение effective значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуре презентации.  
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **Получить effective формат заполнения для таблицы**
С помощью Aspose.Slides for .NET вы можете получить effective формат заполнения для разных логических частей таблицы. Для этой цели в Aspose.Slides добавлен интерфейс **IFillFormatEffectiveData**, содержащий effective свойства форматирования заполнения. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки, строка — выше, чем столбец, а столбец — выше, чем вся таблица.

Таким образом, свойства **CellFormatEffectiveData** всегда используются для отрисовки таблицы. Следующий образец кода демонстрирует, как получить effective формат заполнения для разных логических частей таблицы.
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


## **FAQ**

**Как определить, что я получил «снимок», а не «живой объект», и когда следует снова читать effective свойства?**  
EffectiveData объекты являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные настройки формы, получите effective данные снова, чтобы получить обновленные значения.

**Влияет ли изменение макета/шаблона слайда на уже полученные effective свойства?**  
Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется автоматически — запросите его заново после изменения макета или шаблона.

**Могу ли я изменить значения через EffectiveData?**  
Нет. EffectiveData только для чтения. Вносите изменения в локальные объекты форматирования (форма/текст/3D и т.д.), а затем снова получайте effective значения.

**Что происходит, если свойство не задано ни на уровне формы, ни в макете/шаблоне, ни в глобальных настройках?**  
Effective значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли из effective значения шрифта определить, какой уровень предоставил размер или тип шрифта?**  
Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения на уровне части/параграфа/текстового кадра и стили текста на макете/шаблоне/презентации, чтобы увидеть, где появилось первое явное определение.

**Почему иногда значения EffectiveData выглядят идентичными локальным?**  
Потому что локальное значение стало окончательным (не потребовалось наследование с более высокого уровня). В таких случаях effective значение совпадает с локальным.

**Когда следует использовать effective свойства, а когда работать только с локальными?**  
Используйте EffectiveData, когда нужен результат «как отрендерено» после применения всего наследования (например, для выравнивания цветов, отступов или размеров). Если необходимо изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, повторно считывайте EffectiveData для проверки результата.