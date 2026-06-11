---
title: Dynamiczne dodawanie tekstu
type: docs
weight: 40
url: /pl/net/adding-text-dynamically/
---
Obie metody wykonują następujące kroki:

- Utwórz prezentację.
- Dodaj pusty slajd.
- Dodaj pole tekstowe.
- Ustaw tekst.
- Zapisz prezentację.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Utwórz prezentację

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Pobierz układ pustego slajdu

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Dodaj pusty slajd

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Dodaj tekst

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Ustaw tekst

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Zapisz wynik na dysku

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Utwórz prezentację
	Presentation pres = new Presentation();

	//Pusty slajd jest dodawany domyślnie, gdy tworzysz
	//prezentację z domyślnego konstruktora
	//Więc nie musimy dodawać żadnego pustego slajdu
	Slide sld = pres.GetSlideByPosition(1);

	//Pobierz indeks czcionki dla Arial
	//Zawsze wynosi 0, jeśli tworzysz prezentację z
	//domyślnego konstruktora
	int arialFontIndex = 0;

	//Dodaj pole tekstowe
	//Aby to dodać, najpierw dodamy prostokąt
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Ukryj jego linię
	shp.LineFormat.ShowLines = false;

	//Następnie dodaj ramkę tekstową wewnątrz niego
	TextFrame tf = shp.AddTextFrame("");

	//Ustaw tekst
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Zapisz wynik na dysku
	pres.Write("outAspose.ppt");

}

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)