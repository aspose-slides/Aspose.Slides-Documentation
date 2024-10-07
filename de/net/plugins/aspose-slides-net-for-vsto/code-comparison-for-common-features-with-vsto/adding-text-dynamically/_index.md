---
title: Text Dynamisch Hinzufügen
type: docs
weight: 40
url: /net/adding-text-dynamically/
---

Beide Methoden folgen diesen Schritten:

- Erstellen einer Präsentation.
- Fügen Sie eine leere Folie hinzu.
- Fügen Sie ein Textfeld hinzu.
- Setzen Sie einigen Text.
- Schreiben Sie die Präsentation.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Erstellen einer Präsentation

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Holen Sie sich das Layout der leeren Folie

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Fügen Sie eine leere Folie hinzu

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Fügen Sie einen Text hinzu

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Setzen Sie einen Text

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text dynamisch hinzugefügt";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Schreiben Sie die Ausgabe auf die Festplatte

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Erstellen einer Präsentation

	Presentation pres = new Presentation();

	//Eine leere Folie wird standardmäßig hinzugefügt, wenn Sie erstellen

	//eine Präsentation aus dem Standardkonstruktor

	//Daher müssen wir keine leere Folie hinzufügen

	Slide sld = pres.GetSlideByPosition(1);

	//Erhalten Sie den Schriftartenindex für Arial

	//Es ist immer 0, wenn Sie die Präsentation aus

	//dem Standardkonstruktor erstellen

	int arialFontIndex = 0;

	//Fügen Sie ein Textfeld hinzu

	//Um es hinzuzufügen, werden wir zuerst ein Rechteck hinzufügen

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Verstecken Sie seine Linie

	shp.LineFormat.ShowLines = false;

	//Fügen Sie dann ein Textfeld darin hinzu

	TextFrame tf = shp.AddTextFrame("");

	//Setzen Sie einen Text

	tf.Text = "Text dynamisch hinzugefügt";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Schreiben Sie die Ausgabe auf die Festplatte

	pres.Write("outAspose.ppt");

}

``` 
## **Download Beispielcode**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)