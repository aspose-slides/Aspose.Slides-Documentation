---
title: Text dynamisch hinzufügen
type: docs
weight: 40
url: /de/net/adding-text-dynamically/
---

Beide Methoden folgen diesen Schritten:

- Erstellen Sie eine Präsentation.
- Fügen Sie eine leere Folie hinzu.
- Fügen Sie ein Textfeld hinzu.
- Setzen Sie etwas Text.
- Schreiben Sie die Präsentation.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Erstelle eine Präsentation
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Hole das leere Folienlayout
	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Füge eine leere Folie hinzu
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Füge einen Text hinzu
	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Setze Text
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Schreibe die Ausgabe auf die Festplatte
	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Erstelle eine Präsentation
	Presentation pres = new Presentation();

	//Leere Folie wird standardmäßig hinzugefügt, wenn Sie
	//eine Präsentation über den Standardkonstruktor erstellen
	//Daher müssen wir keine leere Folie hinzufügen
	Slide sld = pres.GetSlideByPosition(1);

	//Hole den Schriftartenindex für Arial
	//Er ist immer 0, wenn Sie
	//die Präsentation über den Standardkonstruktor erstellen
	int arialFontIndex = 0;

	//Füge ein Textfeld hinzu
	//Um es hinzuzufügen, fügen wir zuerst ein Rechteck hinzu
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Verstecke seine Linie
	shp.LineFormat.ShowLines = false;

	//Füge dann einen Textrahmen darin ein
	TextFrame tf = shp.AddTextFrame("");

	//Setze Text
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Schreibe die Ausgabe auf die Festplatte
	pres.Write("outAspose.ppt");

}

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)