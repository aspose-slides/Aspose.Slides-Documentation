---
title: Ajouter du texte dynamiquement en utilisant VSTO et Aspose.Slides pour .NET
type: docs
weight: 20
url: /net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

Une tâche courante que les développeurs doivent accomplir est d'ajouter du texte aux diapositives de manière dynamique. Cet article montre des exemples de code pour ajouter du texte dynamiquement en utilisant [VSTO](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) et [Aspose.Slides for .NET](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Ajouter du texte dynamiquement**
Les deux méthodes suivent ces étapes :

1. Créer une présentation.
1. Ajouter une diapositive vierge.
1. Ajouter une zone de texte.
1. Définir du texte.
1. Écrire la présentation.
## **Exemple de code VSTO**
Les extraits de code ci-dessous donnent lieu à une présentation avec une diapositive simple et une chaîne de texte dessus.

**La présentation créée dans VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Remarque : PowerPoint est un espace de noms qui a été défini ci-dessus comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtenir la mise en page de diapositive vierge
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Ajouter une diapositive vierge
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Ajouter un texte
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Définir un texte
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Texte ajouté dynamiquement";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Écrire la sortie sur le disque
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```

## **Exemple d'Aspose.Slides pour .NET**
Les extraits de code ci-dessous utilisent Aspose.Slides pour créer une présentation avec une diapositive simple et une chaîne de texte dessus.

**La présentation créée en utilisant Aspose.Slides pour .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Créer une présentation
Presentation pres = new Presentation();

//Une diapositive vierge est ajoutée par défaut, lorsque vous créez
//une présentation à partir du constructeur par défaut
//Donc, nous n'avons pas besoin d'ajouter de diapositive vierge
ISlide sld = pres.Slides[1];

//Ajouter une zone de texte
//Pour l'ajouter, nous allons d'abord ajouter un rectangle
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Cacher sa ligne
shp.LineFormat.Style = LineStyle.NotDefined;

//Puis ajouter un cadre de texte à l'intérieur
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Définir un texte
tf.Text = "Texte ajouté dynamiquement";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Écrire la sortie sur le disque
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```