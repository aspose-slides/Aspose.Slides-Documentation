---
title: Formater du texte avec VSTO et Aspose.Slides et .NET
type: docs
weight: 30
url: /net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

Parfois, vous devez formater le texte sur les diapositives de manière programmatique. Cet article montre comment lire une présentation d'exemple avecdu texte sur la première diapositive en utilisant soit [VSTO](/slides/net/format-text-using-vsto-and-aspose-slides-and-net/) soit [Aspose.Slides for .NET](/slides/net/format-text-using-vsto-and-aspose-slides-and-net/). Le code formate le texte dans la troisième zone de texte de la diapositive pour qu'il ressemble au texte dans la dernière zone de texte.

{{% /alert %}} 
## **Formatage du texte**
Les méthodes VSTO et Aspose.Slides suivent les étapes suivantes :

1. Ouvrir la présentation source.
1. Accéder à la première diapositive.
1. Accéder à la troisième zone de texte.
1. Modifier le formatage du texte dans la troisième zone de texte.
1. Enregistrer la présentation sur le disque.

Les captures d'écran ci-dessous montrent la diapositive d'exemple avant et après l'exécution du code VSTO et Aspose.Slides pour .NET.

**La présentation d'entrée** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Exemple de code VSTO**
Le code ci-dessous montre comment reformater le texte sur une diapositive en utilisant VSTO.

**Le texte reformaté avec VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Note: PowerPoint est un espace de noms qui a été défini ci-dessus comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Ouvrir la présentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Accéder à la première diapositive
PowerPoint.Slide slide = pres.Slides[1];

//Accéder à la troisième forme
PowerPoint.Shape shp = slide.Shapes[3];

//Modifier la police du texte en Verdana et la hauteur à 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Mettre en gras
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Mettre en italique
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Modifier la couleur du texte
txtRange.Font.Color.RGB = 0x00CC3333;

//Modifier la couleur de fond de la forme
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Repositionner horizontalement
shp.Left -= 70;

//Écrire la sortie sur le disque
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Exemple d'Aspose.Slides pour .NET**
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

//Modifier la police du texte en Verdana et la hauteur à 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Mettre en gras
port.PortionFormat.FontBold = NullableBool.True;

//Mettre en italique
port.PortionFormat.FontItalic = NullableBool.True;

//Modifier la couleur du texte
//Définir la couleur de la police
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Modifier la couleur de fond de la forme
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Écrire la sortie sur le disque
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```