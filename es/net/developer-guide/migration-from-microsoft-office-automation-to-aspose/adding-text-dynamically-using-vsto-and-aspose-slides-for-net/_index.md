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
description: "Vea cómo migrar de la automatización de Microsoft Office a Aspose.Slides para .NET y agregar texto dinámico a presentaciones PowerPoint (PPT, PPTX) en C#."
---

{{% alert color="primary" %}} 

Una tarea común que los desarrolladores deben realizar es añadir texto a diapositivas de forma dinámica. Este artículo muestra ejemplos de código para añadir texto dinámicamente usando [VSTO](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) y [Aspose.Slides for .NET](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Ambos métodos siguen estos pasos:

1. Crear una presentación.
1. Agregar una diapositiva en blanco.
1. Agregar un cuadro de texto.
1. Establecer algún texto.
1. Guardar la presentación.
## **VSTO Code Example**
Los fragmentos de código a continuación generan una presentación con una diapositiva simple y una cadena de texto.

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba de esta forma
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Crear una presentación
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtener el diseño de diapositiva en blanco
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Agregar una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Agregar un texto
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Establecer un texto
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Escribir la salida en disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **Aspose.Slides for .NET Example**
Los fragmentos de código a continuación usan Aspose.Slides para crear una presentación con una diapositiva simple y una cadena de texto.

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Crear una presentación
Presentation pres = new Presentation();

//La diapositiva en blanco se añade por defecto, cuando creas
//presentación con el constructor por defecto
//Así que no es necesario añadir ninguna diapositiva en blanco
ISlide sld = pres.Slides[1];

//Agregar un cuadro de texto
//Para añadirlo, primero agregaremos un rectángulo
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
