---
title: Formater le texte avec VSTO et Aspose.Slides pour .NET
linktitle: Formater le texte
type: docs
weight: 30
url: /fr/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formater le texte
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Migrer de l'automatisation Microsoft Office vers Aspose.Slides pour .NET et formater le texte dans les présentations PowerPoint (PPT, PPTX) avec un contrôle précis."
---

{{% alert color="primary" %}} 

Parfois, vous devez formater le texte sur les diapositives de manière programmatique. Cet article montre comment lire une présentation d'exemple contenant du texte sur la première diapositive en utilisant soit [VSTO](/slides/fr/net/format-text-using-vsto-and-aspose-slides-and-net/) et [Aspose.Slides for .NET](/slides/fr/net/format-text-using-vsto-and-aspose-slides-and-net/). Le code formate le texte de la troisième zone de texte sur la diapositive pour qu'il ressemble au texte de la dernière zone de texte.

{{% /alert %}} 
## **Mise en forme du texte**
Les méthodes VSTO et Aspose.Slides suivent les étapes suivantes :

1. Ouvrir la présentation source.
1. Accéder à la première diapositive.
1. Accéder à la troisième zone de texte.
1. Modifier la mise en forme du texte dans la troisième zone de texte.
1. Enregistrer la présentation sur le disque.

Les captures d'écran ci-dessous montrent la diapositive d'exemple avant et après l'exécution du code VSTO et Aspose.Slides pour .NET.

**La présentation d'entrée** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Exemple de code VSTO**
Le code ci-dessous montre comment reformater le texte sur une diapositive en utilisant VSTO.

**Le texte reformatté avec VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//Remarque : PowerPoint est un espace de noms qui a été défini ci-dessus comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **Exemple Aspose.Slides pour .NET**
Pour formater le texte avec Aspose.Slides, ajoutez la police avant de formater le texte.

**La présentation de sortie créée avec Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //Ouvrir la présentation
Presentation pres = new Presentation("c:\\source.ppt");

//Accéder à la première diapositive
ISlide slide = pres.Slides[0];

//Accéder à la troisième forme
IShape shp = slide.Shapes[2];

//Modifier la police du texte en Verdana et la taille à 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Mettre en gras
port.PortionFormat.FontBold = NullableBool.True;

//Mettre en italique
port.PortionFormat.FontItalic = NullableBool.True;

//Changer la couleur du texte
//Définir la couleur de la police
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Changer la couleur d'arrière-plan de la forme
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Écrire la sortie sur le disque
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
