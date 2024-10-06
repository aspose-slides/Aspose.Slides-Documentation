---
title: Créer une nouvelle présentation dans VSTO et Aspose.Slides
type: docs
weight: 80
url: /net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

Voici deux exemples de code qui illustrent comment VSTO et Aspose.Slides pour .NET peuvent être utilisés pour atteindre le même objectif.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtenir la mise en page du diapositive de titre

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Ajouter une diapositive de titre.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Définir le texte du titre

slide.Shapes.Title.TextFrame.TextRange.Text = "Titre de la diapositive";

//Définir le texte du sous-titre

slide.Shapes[2].TextFrame.TextRange.Text = "Sous-titre de la diapositive";

//Écrire la sortie sur le disque

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Créer une présentation

	Presentation pres = new Presentation();

	//Ajouter la diapositive de titre

	Slide slide = pres.AddTitleSlide();

	//Définir le texte du titre

	((TextHolder)slide.Placeholders[0]).Text = "Titre de la diapositive";

	//Définir le texte du sous-titre

	((TextHolder)slide.Placeholders[1]).Text = "Sous-titre de la diapositive";

	//Écrire la sortie sur le disque

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)