---
title: Szöveg dinamikusan hozzáadása
type: docs
weight: 40
url: /hu/net/adding-text-dynamically/
---
Mindkét módszer a következő lépéseket követi:

- Prezentáció létrehozása.
- Üres dia hozzáadása.
- Szövegmező hozzáadása.
- Szöveg beállítása.
- Prezentáció mentése.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Prezentáció létrehozása
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//Az üres dia elrendezés lekérése
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//Üres dia hozzáadása
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//Szöveg hozzáadása
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//Szöveg beállítása
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//Az eredmény írása lemezre
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Prezentáció létrehozása
	Presentation pres = new Presentation();

	//Alapértelmezés szerint üres dia kerül hozzáadásra, amikor létrehozza
	//a prezentációt az alapértelmezett konstruktorral
	//Így nem kell üres diát hozzáadni
	Slide sld = pres.GetSlideByPosition(1);

	//Az Arial betűkészlet indexének lekérése
	//Mindig 0, ha a prezentációt az
	//alapértelmezett konstruktorral hozza létre
	int arialFontIndex = 0;

	//Szövegmező hozzáadása
	//Ennek hozzáadásához először egy téglalapot adunk hozzá
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//A vonal elrejtése
	shp.LineFormat.ShowLines = false;

	//Ezután egy szövegkeretet adunk hozzá benne
	TextFrame tf = shp.AddTextFrame("");

	//Szöveg beállítása
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Az eredmény írása lemezre
	pres.Write("outAspose.ppt");

}
``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)