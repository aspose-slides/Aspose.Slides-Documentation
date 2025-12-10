---
title: Obtener propiedades efectivas de forma de presentaciones en .NET
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for .NET calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En propiedades de porción en la diapositiva de la porción.
1. En el estilo de texto de la forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene una).
1. En la configuración global de texto de la presentación.

entonces esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse o omitirse. Pero, finalmente, cuando llega el momento en que la aplicación necesita saber cómo debería verse la porción, usa los valores **efectivos**. Puedes obtener los valores efectivos mediante el método **getEffective()** del formato local.

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


## **Obtener propiedades efectivas de una cámara**
Aspose.Slides for .NET permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se ha añadido la clase **CameraEffectiveData** en Aspose.Slides. La clase CameraEffectiveData representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la cámara.
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


## **Obtener propiedades efectivas de un Light Rig**
Aspose.Slides for .NET permite a los desarrolladores obtener propiedades efectivas de Light Rig. Para este propósito, se ha añadido la clase **LightRigEffectiveData** en Aspose.Slides. LightRigEffectiveData representa un objeto inmutable que contiene propiedades efectivas del conjunto de luces. Una instancia de la clase **LightRigEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para el Light Rig.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Obtener propiedades efectivas de una forma biselada**
Aspose.Slides for .NET permite a los desarrolladores obtener propiedades efectivas de Shape Bevel. Para este propósito, se ha añadido la clase **ShapeBevelEffectiveData** en Aspose.Slides. ShapeBevelEffectiveData representa un objeto inmutable que contiene propiedades efectivas del relieve de la cara de la forma. Una instancia de la clase **ShapeBevelEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la forma biselada.
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


## **Obtener propiedades efectivas de un marco de texto**
Con Aspose.Slides for .NET, puedes obtener propiedades efectivas del marco de texto. Para este propósito, se ha añadido la clase **TextFrameFormatEffectiveData** en Aspose.Slides, que contiene propiedades de formato efectivas del marco de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades de formato efectivas del marco de texto.
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


## **Obtener propiedades efectivas de un estilo de texto**
Con Aspose.Slides for .NET, puedes obtener propiedades efectivas del estilo de texto. Para este propósito, se ha añadido la clase **TextStyleEffectiveData** en Aspose.Slides, que contiene propiedades efectivas del estilo de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas del estilo de texto.
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


## **Obtener el valor efectivo de la altura de fuente**
Con Aspose.Slides for .NET, puedes obtener propiedades efectivas de la altura de fuente. Aquí tienes el código que demuestra cómo cambia el valor efectivo de la altura de fuente de la porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.
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


## **Obtener el formato de relleno efectivo para una tabla**
Con Aspose.Slides for .NET, puedes obtener formato de relleno efectivo para diferentes partes lógicas de una tabla. Para este propósito, se ha añadido la interfaz **IFillFormatEffectiveData** en Aspose.Slides, que contiene propiedades de formato de relleno efectivas. Ten en cuenta que el formato de celda siempre tiene mayor prioridad que el formato de fila, una fila tiene mayor prioridad que la columna y la columna mayor que toda la tabla.

Por lo tanto, finalmente siempre se utilizan las propiedades **CellFormatEffectiveData** para dibujar la tabla. El siguiente ejemplo de código muestra cómo obtener formato de relleno efectivo para diferentes partes lógicas de la tabla.
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


## **Preguntas frecuentes**

**¿Cómo puedo saber si obtuve una "instantánea" en lugar de un "objeto en vivo", y cuándo debo volver a leer las propiedades efectivas?**  
Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambias la configuración local o heredada de la forma, recupera los datos efectivos nuevamente para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño/maestra afecta a las propiedades efectivas que ya se han recuperado?**  
Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicítalo nuevamente después de cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**  
No. EffectiveData es de solo lectura. Realiza cambios en los objetos de formato local (forma/texto/3D, etc.) y luego vuelve a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**  
El valor efectivo se determina mediante el mecanismo predeterminado (valores predeterminados de PowerPoint/Aspose.Slides). Ese valor resuelto forma parte de la instantánea EffectiveData.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o la tipografía?**  
No directamente. EffectiveData devuelve el valor final. Para encontrar la fuente, revisa los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores EffectiveData a veces parecen idénticos a los locales?**  
Porque el valor local resultó ser final (no se necesitó herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo debo trabajar solo con las locales?**  
Utiliza EffectiveData cuando necesites el resultado “tal como se renderiza” después de aplicar toda la herencia (por ejemplo, para alinear colores, sangrías o tamaños). Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y, si es necesario, vuelve a leer EffectiveData para verificar el resultado.