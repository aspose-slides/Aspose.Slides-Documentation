---
title: Créer de nouvelles présentations avec VSTO et Aspose.Slides pour .NET
linktitle: Créer une nouvelle présentation
type: docs
weight: 10
url: /fr/net/create-a-new-presentation/
keywords:
- créer présentation
- nouvelle présentation
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Migrez de l'automatisation Microsoft Office vers Aspose.Slides pour .NET et créez de nouvelles présentations PowerPoint (PPT, PPTX) en C# avec un code propre et fiable."
---
{{% alert color="info" %}} 

VSTO a été développé pour permettre aux développeurs de créer des applications pouvant s'exécuter à l'intérieur de Microsoft Office. VSTO est basé sur COM, mais il est encapsulé dans un objet .NET afin de pouvoir être utilisé dans les applications .NET. VSTO nécessite le support du .NET Framework ainsi que le runtime basé sur CLR de Microsoft Office. Bien qu'il puisse être utilisé pour créer des compléments Microsoft Office, il est presque impossible de l'utiliser comme composant côté serveur. Il présente également de sérieux problèmes de déploiement.

Aspose.Slides for .NET est un composant qui permet de manipuler des présentations Microsoft PowerPoint, tout comme VSTO, mais il présente plusieurs avantages :

- Aspose.Slides ne contient que du code géré et ne nécessite pas l'installation du runtime Microsoft Office.
- Il peut être utilisé comme composant côté client ou comme composant côté serveur.
- Le déploiement est simple car Aspose.Slides est contenu dans une seule DLL.

{{% /alert %}} 
## **Créer une présentation**
Ci-dessous deux exemples de code qui illustrent comment VSTO et Aspose.Slides for .NET peuvent être utilisés pour atteindre le même objectif. Le premier exemple est [VSTO](/slides/fr/net/create-a-new-presentation/); [le deuxième exemple](/slides/fr/net/create-a-new-presentation/) utilise Aspose.Slides.
### **Exemple VSTO**
**Sortie VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Remarque : PowerPoint est un espace de noms qui a été défini ci-dessus comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Définir le texte du titre
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Définir le texte du sous‑titre
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Écrire la sortie sur le disque
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemple Aspose.Slides for .NET**
**Sortie d'Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Créer une présentation
Presentation pres = new Presentation();

//Ajouter la diapositive de titre
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Définir le texte du titre
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Définir le texte du sous-titre
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Écrire la sortie sur le disque
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```