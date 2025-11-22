---
title: Эффективные свойства фигур
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords: "Свойства фигуры, Свойства камеры, Light Rig, Фаска фигуры, Текстовая рамка, Текстовый стиль, Значение высоты шрифта, Формат заливки таблицы, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Получить эффективные свойства фигур в презентациях PowerPoint на C# или .NET"
---

В этой статье мы рассмотрим **эффективные** и **локальные** свойства. Когда мы задаём значения непосредственно на этих уровнях

1. В свойствах фрагмента на слайде фрагмента.  
1. В стиле текста прототипной фигуры на макете или главном слайде (если у формы текстовой рамки фрагмента есть такой стиль).  
1. В глобальных настройках текста презентации.

тогда эти значения называют **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но в конечном итоге, когда приложение должно узнать, как должен выглядеть фрагмент, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

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
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс **CameraEffectiveData**. Класс CameraEffectiveData представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

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



## **Получить эффективные свойства Light Rig**
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен класс **LightRigEffectiveData**. Класс LightRigEffectiveData представляет неизменяемый объект, содержащий эффективные свойства Light Rig. Экземпляр класса **LightRigEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства Light Rig.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Получить эффективные свойства фаски фигуры**
Aspose.Slides for .NET позволяет разработчикам получать эффективные свойства фаски фигуры. Для этой цели в Aspose.Slides был добавлен класс **ShapeBevelEffectiveData**. Класс ShapeBevelEffectiveData представляет неизменяемый объект, содержащий эффективные свойства рельефа грани фигуры. Экземпляр класса **ShapeBevelEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства фаски фигуры.
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
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства текстовой рамки. Для этой цели в Aspose.Slides был добавлен класс **TextFrameFormatEffectiveData**, который содержит эффективные свойства форматирования текстовой рамки.

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
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства текстового стиля. Для этой цели в Aspose.Slides был добавлен класс **TextStyleEffectiveData**, который содержит эффективные свойства текстового стиля.

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
С помощью Aspose.Slides for .NET вы можете получить эффективные свойства высоты шрифта. Ниже приведён код, демонстрирующий изменение эффективного значения высоты шрифта фрагмента после установки локальных значений высоты шрифта на разных уровнях структуры презентации.
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
С помощью Aspose.Slides for .NET вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс **IFillFormatEffectiveData**, который содержит эффективные свойства форматирования заливки. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки; строка имеет более высокий приоритет, чем столбец, а столбец — чем вся таблица.

Таким образом, свойства **CellFormatEffectiveData** в конечном итоге всегда используются для отрисовки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для различных логических частей таблицы.
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

**Как определить, что я получил "снимок", а не "живой объект", и когда следует вновь считывать эффективные свойства?**  
Объекты EffectiveData являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные настройки фигуры, получите эффективные данные снова, чтобы получить обновленные значения.

**Влияет ли изменение макета/главного слайда на эффективные свойства, которые уже были получены?**  
Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам по себе — запросите его снова после изменения макета или главного слайда.

**Могу ли я изменять значения через EffectiveData?**  
Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (фигура/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/главного слайда и глобальных настроек?**  
Эффективное значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли, исходя из эффективного значения шрифта, определить, с какого уровня пришли размер или гарнитура?**  
Не напрямую. EffectiveData возвращает окончательное значение. Чтобы определить источник, проверьте локальные значения у фрагмента/абзаца/текстовой рамки и стили текста на уровне макета/главного слайда/презентации, чтобы увидеть, где появилось первое явное определение.

**Почему значения EffectiveData иногда совпадают с локальными?**  
Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**  
Используйте EffectiveData, когда нужен результат «как будет отображено» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если необходимо изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, снова считывайте EffectiveData для проверки результата.