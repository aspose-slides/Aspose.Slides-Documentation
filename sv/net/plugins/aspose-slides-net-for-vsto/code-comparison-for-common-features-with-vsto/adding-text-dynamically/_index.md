---
title: Lägga till text dynamiskt
type: docs
weight: 40
url: /sv/net/adding-text-dynamically/
---
Båda metoderna följer dessa steg:

- Skapa en presentation.
- Lägg till en tom bild.
- Lägg till en textruta.
- Ställ in lite text.
- Skriv presentationen.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Skapa en presentation

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Hämta den tomma bildlayouten

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Lägg till en tom bild

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Lägg till text

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Ställ in text

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Skriv utdata till disk

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Skapa en presentation

	Presentation pres = new Presentation();

	//Tom bild läggs till som standard, när du skapar

	//presentation från standardkonstruktor

	//Så, vi behöver inte lägga till någon tom bild

	Slide sld = pres.GetSlideByPosition(1);

	//Hämta typsnittsindex för Arial

	//Det är alltid 0 om du skapar presentation från

	//standardkonstruktor

	int arialFontIndex = 0;

	//Lägg till en textruta

	//För att lägga till den, lägger vi först till en rektangel

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Dölj dess linje

	shp.LineFormat.ShowLines = false;

	//Lägg sedan till en textram inuti den

	TextFrame tf = shp.AddTextFrame("");

	//Ställ in text

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Skriv utdata till disk

	pres.Write("outAspose.ppt");

}

``` 
## **Ladda ner exempelcode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)