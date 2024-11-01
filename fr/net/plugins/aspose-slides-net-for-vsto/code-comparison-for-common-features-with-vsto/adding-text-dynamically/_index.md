---
title: Ajouter du texte dynamiquement
type: docs
weight: 40
url: /fr/net/adding-text-dynamically/
---

Les deux méthodes suivent ces étapes :

- Créer une présentation.
- Ajouter une diapositive vierge.
- Ajouter une zone de texte.
- Définir un texte.
- Écrire la présentation.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Créer une présentation

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Obtenir la mise en page de la diapositive vierge

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Ajouter une diapositive vierge

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Ajouter un texte

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Définir un texte

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Texte ajouté dynamiquement";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Écrire la sortie sur le disque

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

	//Il est toujours 0 si vous créez une présentation à partir

	//du constructeur par défaut

	int arialFontIndex = 0;

	//Ajouter une zone de texte

	//Pour l'ajouter, nous ajouterons d'abord un rectangle

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Cacher sa ligne

	shp.LineFormat.ShowLines = false;

	//Puis ajouter un cadre de texte à l'intérieur

	TextFrame tf = shp.AddTextFrame("");

	//Définir un texte

	tf.Text = "Texte ajouté dynamiquement";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Écrire la sortie sur le disque

	pres.Write("outAspose.ppt");

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)