---
title: Aggiungere testo dinamicamente
type: docs
weight: 40
url: /it/net/adding-text-dynamically/
---
Entrambi i metodi seguono questi passaggi:

- Crea una presentazione.
- Aggiungi una diapositiva vuota.
- Aggiungi una casella di testo.
- Imposta del testo.
- Scrivi la presentazione.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Crea una presentazione

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Ottieni il layout della diapositiva vuota

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Aggiungi una diapositiva vuota

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Aggiungi un testo

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Imposta un testo

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Scrivi l'output su disco

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()
{
	//Crea una presentazione
	Presentation pres = new Presentation();
	//La diapositiva vuota viene aggiunta per impostazione predefinita, quando crei
	//la presentazione dal costruttore predefinito
	//Quindi, non è necessario aggiungere alcuna diapositiva vuota
	Slide sld = pres.GetSlideByPosition(1);
	//Ottieni l'indice del font per Arial
	//È sempre 0 se crei una presentazione da
	//costruttore predefinito
	int arialFontIndex = 0;
	//Aggiungi una casella di testo
	//Per aggiungerla, prima aggiungeremo un rettangolo
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);
	//Nascondi la sua linea
	shp.LineFormat.ShowLines = false;
	//Quindi aggiungi un textframe al suo interno
	TextFrame tf = shp.AddTextFrame("");
	//Imposta un testo
	tf.Text = "Text added dynamically";
	Portion port = tf.Paragraphs[0].Portions[0];
	port.FontIndex = arialFontIndex;
	port.FontBold = true;
	port.FontHeight = 32;
	//Scrivi l'output su disco
	pres.Write("outAspose.ppt");
}
``` 
## **Scarica codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)