---
title: Formato de texto usando VSTO y Aspose.Slides para .NET
linktitle: Formato de texto
type: docs
weight: 30
url: /es/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formatear texto
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Migra de la automatización de Microsoft Office a Aspose.Slides para .NET y formatea texto en presentaciones de PowerPoint (PPT, PPTX) con control preciso."
---

{{% alert color="primary" %}} 

A veces, necesita formatear el texto en las diapositivas programáticamente. Este artículo muestra cómo leer una presentación de ejemplo con algo de texto en la primera diapositiva usando ya sea [VSTO](/slides/es/net/format-text-using-vsto-and-aspose-slides-and-net/) y [Aspose.Slides for .NET](/slides/es/net/format-text-using-vsto-and-aspose-slides-and-net/). El código formatea el texto en el tercer cuadro de texto de la diapositiva para que se vea como el texto en el último cuadro de texto.

{{% /alert %}} 
## **Formateo de texto**
Ambos métodos, VSTO y Aspose.Slides, siguen los siguientes pasos:

1. Abrir la presentación de origen.
1. Acceder a la primera diapositiva.
1. Acceder al tercer cuadro de texto.
1. Cambiar el formato del texto en el tercer cuadro de texto.
1. Guardar la presentación en disco.

Las capturas de pantalla a continuación muestran la diapositiva de ejemplo antes y después de la ejecución del código VSTO y Aspose.Slides para .NET.

**La presentación de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Ejemplo de código VSTO**
El código a continuación muestra cómo reformatear texto en una diapositiva usando VSTO.

**El texto reformateado con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba así
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Abrir la presentación
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Acceder a la primera diapositiva
PowerPoint.Slide slide = pres.Slides[1];

//Acceder a la tercera forma
PowerPoint.Shape shp = slide.Shapes[3];

//Cambiar la fuente del texto a Verdana y la altura a 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Poner en negrita
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Poner en cursiva
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Cambiar el color del texto
txtRange.Font.Color.RGB = 0x00CC3333;

//Cambiar el color de fondo de la forma
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposicionarla horizontalmente
shp.Left -= 70;

//Escribir la salida en disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **Ejemplo de Aspose.Slides para .NET**
Para formatear texto con Aspose.Slides, agregue la fuente antes de formatear el texto.

**La presentación de salida creada con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //Abrir la presentación
Presentation pres = new Presentation("c:\\source.ppt");

//Acceder a la primera diapositiva
ISlide slide = pres.Slides[0];

//Acceder a la tercera forma
IShape shp = slide.Shapes[2];

//Cambiar la fuente del texto a Verdana y la altura a 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Poner en negrita
port.PortionFormat.FontBold = NullableBool.True;

//Poner en cursiva
port.PortionFormat.FontItalic = NullableBool.True;

//Cambiar color del texto
//Establecer color de fuente
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Cambiar color de fondo de la forma
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Escribir la salida en disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
