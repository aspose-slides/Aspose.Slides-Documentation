---
title: Получить эффективные свойства формы из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства формы
- свойства камеры
- световой комплект
- фаска формы
- текстовая рамка
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for .NET вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы задаём значения непосредственно на этих уровнях

1. В свойствах части на слайде части.
1. В стиле текста прототипа формы на макете или главном слайде (если у формы текстовой области части есть такой стиль).
1. В глобальных настройках текста презентации.

тогда такие значения называются **локальными**. На любом уровне **локальные** значения могут быть определены или опущены. Но в конечном итоге, когда приложение должно узнать, как должна выглядеть часть, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

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


## **Получить эффективные свойства камеры**
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides добавлен класс **CameraEffectiveData**. Класс CameraEffectiveData представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства камеры.
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


## **Получить эффективные свойства светового комплекта**
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides добавлен класс **LightRigEffectiveData**. LightRigEffectiveData class представляет неизменяемый объект, содержащий эффективные свойства светового комплекта. Экземпляр класса **LightRigEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства светового комплекта.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Получить эффективные свойства фаски формы**
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides добавлен класс **ShapeBevelEffectiveData**. ShapeBevelEffectiveData class представляет неизменяемый объект, содержащий эффективные свойства рельефа грани формы. Экземпляр класса **ShapeBevelEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства фаски формы.
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


## **Получить эффективные свойства текстовой рамки**
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства текстовой рамки. Для этой цели в Aspose.Slides добавлен класс **TextFrameFormatEffectiveData**, который содержит свойства форматирования эффективной текстовой рамки.

Следующий пример кода показывает, как получить эффективные свойства форматирования текстовой рамки.
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


## **Получить эффективные свойства текстового стиля**
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства текстового стиля. Для этой цели в Aspose.Slides добавлен класс **TextStyleEffectiveData**, который содержит эффективные свойства текстового стиля.

Следующий пример кода показывает, как получить эффективные свойства текстового стиля.
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


## **Получить эффективное значение высоты шрифта**
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства высоты шрифта. Ниже приведён код, демонстрирующий изменение эффективного значения высоты шрифта части после задания локальных значений высоты шрифта на разных уровнях структуры презентации.
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


## **Получить эффективный формат заливки для таблицы**
С помощью Aspose.Slides for .NET вы можете получить эффективное форматирование заливки для разных логических частей таблицы. Для этой цели в Aspose.Slides добавлен интерфейс **IFillFormatEffectiveData**, который содержит свойства эффективного форматирования заливки. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки, строка имеет более высокий приоритет, чем столбец, а столбец — чем вся таблица.

Таким образом, в конечном итоге свойства **CellFormatEffectiveData** всегда используются для отрисовки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для разных логических частей таблицы.
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

**Как определить, что я получил «снимок», а не «живой объект», и когда следует заново считывать эффективные свойства?**  
Объекты EffectiveData являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные настройки формы, получите эффективные данные снова, чтобы получить обновлённые значения.

**Влияет ли изменение макета/главного слайда на уже полученные эффективные свойства?**  
Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам — запросите его снова после изменения макета или главного слайда.

**Можно ли изменять значения через EffectiveData?**  
Нет. EffectiveData только для чтения. Вносите изменения в локальные объекты форматирования (форма/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/главного слайда и глобальных настроек?**  
Эффективное значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или гарнитуру?**  
Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/абзаце/текстовой рамке и стили текста в макете/главном слайде/презентации, чтобы увидеть, где появилось первое явное определение.

**Почему значения EffectiveData иногда совпадают с локальными?**  
Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**  
Используйте EffectiveData, когда нужен результат «как отрендерено» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если необходимо изменить форматирование на определённом уровне, изменяйте локальные свойства и при необходимости снова считывайте EffectiveData, чтобы проверить результат.