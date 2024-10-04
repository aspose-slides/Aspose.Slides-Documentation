---
title: Formatear texto usando VSTO y Aspose.Slides y .NET
type: docs
weight: 30
url: /net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

A veces, necesitas formatear el texto en las diapositivas programáticamente. Este artículo muestra cómo leer una presentación de muestra con algo de texto en la primera diapositiva usando [VSTO](/slides/net/format-text-using-vsto-and-aspose-slides-and-net/) y [Aspose.Slides for .NET](/slides/net/format-text-using-vsto-and-aspose-slides-and-net/). El código formatea el texto en el tercer cuadro de texto en la diapositiva para que se vea como el texto en el último cuadro de texto.

{{% /alert %}} 
## **Formateo de Texto**
Tanto los métodos de VSTO como de Aspose.Slides siguen los siguientes pasos:

1. Abrir la presentación de origen.
1. Acceder a la primera diapositiva.
1. Acceder al tercer cuadro de texto.
1. Cambiar el formato del texto en el tercer cuadro de texto.
1. Guardar la presentación en el disco.

Las capturas de pantalla a continuación muestran la diapositiva de muestra antes y después de la ejecución del código de VSTO y Aspose.Slides para .NET.

**La presentación de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Ejemplo de Código VSTO**
El código a continuación muestra cómo reformatear el texto en una diapositiva utilizando VSTO.

**El texto reformateado con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Nota: PowerPoint es un espacio de nombres que ha sido definido arriba de esta manera
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

//Cambiar la fuente de su texto a Verdana y la altura a 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Ponerlo en negrita
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ponerlo en cursiva
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Cambiar el color del texto
txtRange.Font.Color.RGB = 0x00CC3333;

//Cambiar el color de fondo de la forma
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reubicarlo horizontalmente
shp.Left -= 70;

//Escribir la salida en el disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Ejemplo de Aspose.Slides para .NET**
Para formatear texto con Aspose.Slides, agrega la fuente antes de formatear el texto.

**La presentación de salida creada con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
//Abrir la presentación
Presentation pres = new Presentation("c:\\source.ppt");

//Acceder a la primera diapositiva
ISlide slide = pres.Slides[0];

//Acceder a la tercera forma
IShape shp = slide.Shapes[2];

//Cambiar la fuente de su texto a Verdana y la altura a 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Ponerlo en negrita
port.PortionFormat.FontBold = NullableBool.True;

//Ponerlo en cursiva
port.PortionFormat.FontItalic = NullableBool.True;

//Cambiar el color del texto
//Establecer el color de la fuente
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Cambiar el color de fondo de la forma
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Escribir la salida en el disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```