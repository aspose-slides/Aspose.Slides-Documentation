---
title: Agregar Texto Dinámicamente
type: docs
weight: 40
url: /es/net/adding-text-dynamically/
---

Ambos métodos siguen estos pasos:

- Crear una presentación.
- Agregar una diapositiva en blanco.
- Agregar un cuadro de texto.
- Establecer algún texto.
- Escribir la presentación.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Crear una presentación

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Obtener el diseño de diapositiva en blanco

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Agregar una diapositiva en blanco

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Agregar un texto

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Establecer un texto

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Texto agregado dinámicamente";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Escribir la salida en el disco

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Crear una presentación

	Presentation pres = new Presentation();

	//La diapositiva en blanco se agrega por defecto, cuando creas

	//la presentación desde el constructor por defecto

	//Así que no necesitamos agregar ninguna diapositiva en blanco

	Slide sld = pres.GetSlideByPosition(1);

	//Obtener el índice de fuente para Arial

	//Siempre es 0 si creas la presentación desde

	//el constructor por defecto

	int arialFontIndex = 0;

	//Agregar un cuadro de texto

	//Para agregarlo, primero agregaremos un rectángulo

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Ocultar su línea

	shp.LineFormat.ShowLines = false;

	//Luego agregar un marco de texto dentro de él

	TextFrame tf = shp.AddTextFrame("");

	//Establecer un texto

	tf.Text = "Texto agregado dinámicamente";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Escribir la salida en el disco

	pres.Write("outAspose.ppt");

}

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)