---
title: Ajout dynamique de texte avec VSTO et Aspose.Slides pour .NET
linktitle: Ajout de texte dynamique
type: docs
weight: 20
url: /fr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- ajouter du texte
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Voir comment migrer de l'automatisation Microsoft Office vers Aspose.Slides pour .NET et ajouter du texte dynamique aux présentations PowerPoint (PPT, PPTX) en C#."
---

{{% alert color="primary" %}} 

Une tâche courante que les développeurs doivent accomplir est d’ajouter du texte aux diapositives de manière dynamique. Cet article montre des exemples de code pour ajouter du texte dynamiquement en utilisant [VSTO](/slides/fr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) et [Aspose.Slides for .NET](/slides/fr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Ajouter du texte dynamiquement**
Les deux méthodes suivent ces étapes :

1. Créer une présentation.
1. Ajouter une diapositive vierge.
1. Ajouter une zone de texte.
1. Définir du texte.
1. Enregistrer la présentation.
## **Exemple de code VSTO**
Les extraits de code ci-dessous produisent une présentation avec une diapositive simple et une chaîne de texte.

**La présentation telle que créée dans VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Remarque: PowerPoint est un espace de noms qui a été défini ci-dessous comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **Exemple Aspose.Slides pour .NET**
Les extraits de code ci-dessous utilisent Aspose.Slides pour créer une présentation avec une diapositive simple et une chaîne de texte.

**La présentation telle que créée avec Aspose.Slides pour .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Créer une présentation
Presentation pres = new Presentation();

//La diapositive vierge est ajoutée par défaut, lorsque vous créez
//une présentation à partir du constructeur par défaut
//Donc, nous n'avons pas besoin d'ajouter une diapositive vierge
ISlide sld = pres.Slides[1];

//Ajouter une zone de texte
//Pour l'ajouter, nous allons d'abord ajouter un rectangle
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Masquer sa ligne
shp.LineFormat.Style = LineStyle.NotDefined;

//Puis ajouter un cadre de texte à l'intérieur
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Définir un texte
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Écrire la sortie sur le disque
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
