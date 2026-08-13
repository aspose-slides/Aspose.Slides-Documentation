---
title: Añadiendo texto de forma dinámica usando VSTO y Aspose.Slides para .NET
linktitle: Añadiendo texto de forma dinámica
type: docs
weight: 20
url: /es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- añadir texto
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Vea cómo migrar de la automatización de Microsoft Office a Aspose.Slides para .NET y añadir texto dinámico a presentaciones de PowerPoint (PPT, PPTX) en C#."
---
{{% alert color="info" %}}

Una tarea común que los desarrolladores deben realizar es añadir texto a las diapositivas de forma dinámica. Este artículo muestra ejemplos de código para añadir texto de forma dinámica usando [VSTO](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) y [Aspose.Slides for .NET](/slides/es/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Añadir texto de forma dinámica**
Ambos métodos siguen estos pasos:

1. Crear una presentación.
1. Añadir una diapositiva en blanco.
1. Añadir un cuadro de texto.
1. Establecer algo de texto.
1. Guardar la presentación.
## **Ejemplo de código VSTO**
Los fragmentos de código a continuación generan una presentación con una diapositiva simple y una cadena de texto.

**La presentación como se crea en VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba de esta manera
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Crear una presentación
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtener el diseño de diapositiva en blanco
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Añadir una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Añadir texto
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Establecer texto
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Guardar la salida en disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Ejemplo de Aspose.Slides para .NET**
Los fragmentos de código a continuación usan Aspose.Slides para crear una presentación con una diapositiva simple y una cadena de texto.

**La presentación como se crea usando Aspose.Slides para .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Crear una presentación
Presentation pres = new Presentation();

//La diapositiva en blanco se añade por defecto, cuando creas
//una presentación con el constructor predeterminado
//Así que no es necesario añadir ninguna diapositiva en blanco
ISlide sld = pres.Slides[1];

//Añadir un cuadro de texto
//Para añadirlo, primero añadiremos un rectángulo
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ocultar su línea
shp.LineFormat.Style = LineStyle.NotDefined;

//Luego añadir un marco de texto dentro de él
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Establecer texto
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Guardar la salida en disco
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```