---
title: Ajout de texte dynamique
type: docs
weight: 40
url: /fr/net/adding-text-dynamically/
---

Les deux méthodes suivent les étapes suivantes :

- Créer une présentation.
- Ajouter une diapositive vierge.
- Ajouter une zone de texte.
- Définir du texte.
- Enregistrer la présentation.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Créer une présentation

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Obtenir la disposition de diapositive vierge

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Ajouter une diapositive vierge

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Ajouter une zone de texte

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Définir le texte

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Enregistrer le fichier sur le disque

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Créer une présentation

	Presentation pres = new Presentation();

	//Une diapositive vierge est ajoutée par défaut, lorsque vous créez

	//une présentation à partir du constructeur par défaut

	//Donc, nous n'avons pas besoin d'ajouter de diapositive vierge

	Slide sld = pres.GetSlideByPosition(1);

	//Obtenir l'index de police pour Arial

	//Il est toujours 0 si vous créez une présentation à partir du

	//constructeur par défaut

	int arialFontIndex = 0;

	//Ajouter une zone de texte

	//Pour l'ajouter, nous allons d'abord ajouter un rectangle

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Masquer sa ligne

	shp.LineFormat.ShowLines = false;

	//Puis ajouter un cadre de texte à l'intérieur

	TextFrame tf = shp.AddTextFrame("");

	//Définir le texte

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Enregistrer le fichier sur le disque

	pres.Write("outAspose.ppt");

}

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)