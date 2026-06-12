---
title: Tekst dynamisch toevoegen
type: docs
weight: 40
url: /nl/net/adding-text-dynamically/
---
Beide methoden volgen deze stappen:

- Maak een presentatie.
- Voeg een lege dia toe.
- Voeg een tekstvak toe.
- Stel een tekst in.
- Schrijf de presentatie.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Maak een presentatie
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//Haal de lege dia-indeling op
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//Voeg een lege dia toe
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//Voeg tekst toe
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//Stel tekst in
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//Schrijf de uitvoer naar schijf
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Maak een presentatie
	Presentation pres = new Presentation();

	//Lege dia wordt standaard toegevoegd, wanneer je maakt
	//presentatie vanuit de standaardconstructor
	//Dus, we hoeven geen lege dia toe te voegen
	Slide sld = pres.GetSlideByPosition(1);

	//Haal de lettertype-index op voor Arial
	//Het is altijd 0 als je een presentatie maakt vanuit
	//standaardconstructor
	int arialFontIndex = 0;

	//Voeg een tekstvak toe
	//Om het toe te voegen, zullen we eerst een rechthoek toevoegen
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Verberg de lijn
	shp.LineFormat.ShowLines = false;

	//Voeg daarna een tekstkader toe binnenin
	TextFrame tf = shp.AddTextFrame("");

	//Stel een tekst in
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Schrijf de uitvoer naar de schijf
	pres.Write("outAspose.ppt");

}
``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)