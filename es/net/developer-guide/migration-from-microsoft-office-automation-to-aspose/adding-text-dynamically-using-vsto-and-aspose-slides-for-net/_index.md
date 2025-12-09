---
title: Agregar texto dinámicamente usando VSTO y Aspose.Slides para .NET
linktitle: Agregar texto dinámicamente
type: docs
weight: 20
url: /es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- agregar texto
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Vea cómo migrar de la automatización de Microsoft Office a Aspose.Slides para .NET y agregar texto dinámico a presentaciones de PowerPoint (PPT, PPTX) en C#."
---

{{% alert color="primary" %}}

Una tarea común que los desarrolladores deben realizar es añadir texto a diapositivas de forma dinámica. Este artículo muestra ejemplos de código para añadir texto dinámicamente usando [VSTO](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) y [Aspose.Slides for .NET](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}}
## **Agregar texto dinámicamente**
Ambos métodos siguen estos pasos:

1. Crear una presentación.
1. Añadir una diapositiva en blanco.
1. Añadir un cuadro de texto.
1. Establecer algún texto.
1. Guardar la presentación.
## **Ejemplo de código VSTO**
Los fragmentos de código a continuación generan una presentación con una diapositiva simple y una cadena de texto.

**La presentación creada en VSTO**

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba así
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


## **Ejemplo de Aspose.Slides para .NET**
Los fragmentos de código a continuación usan Aspose.Slides para crear una presentación con una diapositiva simple y una cadena de texto.

**La presentación creada usando Aspose.Slides para .NET**

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Crear una presentación
Presentation pres = new Presentation();

//La diapositiva en blanco se agrega por defecto, cuando creas
//una presentación desde el constructor predeterminado
//Por lo tanto, no necesitamos agregar ninguna diapositiva en blanco
ISlide sld = pres.Slides[1];

//Agregar un cuadro de texto
//Para agregarlo, primero añadiremos un rectángulo
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ocultar su línea
shp.LineFormat.Style = LineStyle.NotDefined;

//Luego agregar un marco de texto dentro de él
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Establecer un texto
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Escribir la salida en disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
