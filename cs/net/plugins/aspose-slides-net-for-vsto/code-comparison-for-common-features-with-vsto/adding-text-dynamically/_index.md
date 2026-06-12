---
title: Přidání textu dynamicky
type: docs
weight: 40
url: /cs/net/adding-text-dynamically/
---
Obě metody následují tyto kroky:

- Vytvořte prezentaci.
- Přidejte prázdný snímek.
- Přidejte textové pole.
- Nastavte nějaký text.
- Uložte prezentaci.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Vytvořte prezentaci

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Získejte rozložení prázdného snímku

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Přidejte prázdný snímek

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Přidejte text

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Nastavte text

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Uložte výstup na disk

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Vytvořte prezentaci

	Presentation pres = new Presentation();

	//Prázdný snímek je přidán ve výchozím nastavení, když vytvoříte

	//prezentaci z výchozího konstruktoru

	//Takže nemusíme přidávat žádný prázdný snímek

	Slide sld = pres.GetSlideByPosition(1);

	//Získat index písma pro Arial

	//Je vždy 0, pokud vytvoříte prezentaci z

	//výchozího konstruktoru

	int arialFontIndex = 0;

	//Přidejte textové pole

	//Pro jeho přidání nejprve přidáme obdélník

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Skrýt jeho čáru

	shp.LineFormat.ShowLines = false;

	//Pak přidejte textový rámec uvnitř něj

	TextFrame tf = shp.AddTextFrame("");

	//Nastavte text

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Uložte výstup na disk

	pres.Write("outAspose.ppt");

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)