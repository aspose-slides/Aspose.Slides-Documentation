---
title: Agregar texto dinámicamente usando VSTO y Aspose.Slides para .NET
type: docs
weight: 20
url: /net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

Una tarea común que los desarrolladores deben realizar es agregar texto a las diapositivas dinámicamente. Este artículo muestra ejemplos de código para agregar texto dinámicamente usando [VSTO](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) y [Aspose.Slides para .NET](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Agregar texto dinámicamente**
Ambos métodos siguen estos pasos:

1. Crear una presentación.
1. Agregar una diapositiva en blanco.
1. Agregar un cuadro de texto.
1. Establecer algún texto.
1. Escribir la presentación.
## **Ejemplo de código VSTO**
Los fragmentos de código a continuación resultan en una presentación con una diapositiva simple y una cadena de texto en ella.

**La presentación creada en VSTO** 

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

//Agregar una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Agregar un texto
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Establecer un texto
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Texto agregado dinámicamente";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Escribir la salida en el disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Ejemplo de Aspose.Slides para .NET**
Los fragmentos de código a continuación utilizan Aspose.Slides para crear una presentación con una diapositiva simple y una cadena de texto en ella.

**La presentación creada usando Aspose.Slides para .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Crear una presentación
Presentation pres = new Presentation();

//La diapositiva en blanco se agrega por defecto, cuando se crea
//una presentación desde el constructor por defecto
//Por lo tanto, no necesitamos agregar ninguna diapositiva en blanco
ISlide sld = pres.Slides[1];

//Agregar un cuadro de texto
//Para agregarlo, primero agregaremos un rectángulo
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ocultar su línea
shp.LineFormat.Style = LineStyle.NotDefined;

//Luego agregar un marco de texto dentro de él
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Establecer un texto
tf.Text = "Texto agregado dinámicamente";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Escribir la salida en el disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```