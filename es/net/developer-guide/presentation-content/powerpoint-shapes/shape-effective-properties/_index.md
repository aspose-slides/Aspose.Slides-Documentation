---
title: Propiedades Efectivas de la Forma
type: docs
weight: 50
url: /net/shape-effective-properties/
keywords: "Propiedades de la forma, propiedades de la cámara, rig de luz, forma de bisel, cuadro de texto, estilo de texto, valor de altura de fuente, formato de relleno para tabla, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Obtenga propiedades efectivas de la forma en presentaciones de PowerPoint en C# o .NET"
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente a estos niveles

1. En las propiedades de porción en la diapositiva de la porción.
1. En el estilo de texto de forma prototipo en la diapositiva de diseño o maestra (si la forma del cuadro de texto de la porción tiene uno).
1. En la configuración global de texto de la presentación.

entonces esos valores se llaman valores **locales**. En cualquier nivel, los valores **locales** podrían definirse u omitirse. Pero finalmente, cuando llega el momento en que la aplicación necesita saber cómo debería verse la porción, utiliza valores **efectivos**. Puede obtener valores efectivos utilizando el método **getEffective()** del formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos.

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



## **Obtener Propiedades Efectivas de la Cámara**
Aspose.Slides para .NET permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se ha añadido la clase **CameraEffectiveData** en Aspose.Slides. La clase CameraEffectiveData representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la cámara.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propiedades efectivas de la cámara =");
	Console.WriteLine("Tipo: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Campo de visión: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **Obtener Propiedades Efectivas del Rig de Luz**
Aspose.Slides para .NET permite a los desarrolladores obtener propiedades efectivas del Rig de Luz. Para este propósito, se ha añadido la clase **LightRigEffectiveData** en Aspose.Slides. La clase LightRigEffectiveData representa un objeto inmutable que contiene propiedades efectivas del rig de luz. Una instancia de la clase **LightRigEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para el Rig de Luz.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propiedades efectivas del rig de luz =");
	Console.WriteLine("Tipo: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Dirección: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Obtener Propiedades Efectivas de la Forma de Bisel**
Aspose.Slides para .NET permite a los desarrolladores obtener propiedades efectivas de la Forma de Bisel. Para este propósito, se ha añadido la clase **ShapeBevelEffectiveData** en Aspose.Slides. La clase ShapeBevelEffectiveData representa un objeto inmutable que contiene propiedades de relieve de la cara de la forma. Una instancia de la clase **ShapeBevelEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la Forma de Bisel.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propiedades efectivas del relieve de la cara superior de la forma =");
	Console.WriteLine("Tipo: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Ancho: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Altura: " + threeDEffectiveData.BevelTop.Height);
}
```



## **Obtener Propiedades Efectivas del Cuadro de Texto**
Usando Aspose.Slides para .NET, puede obtener propiedades efectivas del Cuadro de Texto. Para este propósito, se ha añadido la clase **TextFrameFormatEffectiveData** en Aspose.Slides, que contiene propiedades de formato de cuadro de texto efectivas.

El siguiente ejemplo de código muestra cómo obtener propiedades de formato de cuadro de texto efectivas.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Tipo de anclaje: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Tipo de ajuste automático: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Tipo de texto vertical: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Márgenes");
	Console.WriteLine("   Izquierda: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Superior: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Derecha: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Inferior: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **Obtener Propiedades Efectivas del Estilo de Texto**
Usando Aspose.Slides para .NET, puede obtener propiedades efectivas del Estilo de Texto. Para este propósito, se ha añadido la clase **TextStyleEffectiveData** en Aspose.Slides, que contiene propiedades de estilo de texto efectivas.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas del estilo de texto.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Formato efectivo del párrafo para el nivel de estilo #" + i + " =");

        Console.WriteLine("Profundidad: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Sangría: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alineación: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Alineación de fuente: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **Obtener Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para .NET, puede obtener propiedades efectivas de la Altura de Fuente. Aquí está el código que demuestra cómo el valor efectivo de altura de fuente de la porción cambia después de establecer los valores de altura de fuente locales en diferentes niveles de la estructura de la presentación.

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Texto de muestra con la primera porción");
    IPortion portion1 = new Portion(" y segunda porción.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Altura de fuente efectiva justo después de la creación:");
    Console.WriteLine("Porción #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Porción #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de toda la presentación:");
    Console.WriteLine("Porción #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Porción #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Altura de fuente efectiva después de establecer la altura de fuente predeterminada del párrafo:");
    Console.WriteLine("Porción #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Porción #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Altura de fuente efectiva después de establecer altura de fuente de la porción #0:");
    Console.WriteLine("Porción #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Porción #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Altura de fuente efectiva después de establecer altura de fuente de la porción #1:");
    Console.WriteLine("Porción #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Porción #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **Obtener Formato de Relleno Efectivo para Tabla**
Usando Aspose.Slides para .NET, puede obtener el formato de relleno efectivo para diferentes partes lógicas de la tabla. Para este propósito, se ha añadido la interfaz **IFillFormatEffectiveData** en Aspose.Slides, que contiene propiedades de formato de relleno efectivo. Tenga en cuenta que el formato de celda siempre tiene una prioridad más alta que el formato de fila, una fila tiene una prioridad más alta que la columna y la columna tiene una prioridad más alta que toda la tabla.

Así que, finalmente, las propiedades de **CellFormatEffectiveData** siempre se utilizan para dibujar la tabla. El siguiente ejemplo de código muestra cómo obtener el formato de relleno efectivo para diferentes partes lógicas de la tabla.

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