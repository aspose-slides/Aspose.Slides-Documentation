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
description: "Migrer de l'automatisation Microsoft Office vers Aspose.Slides pour .NET et créer de nouvelles présentations PowerPoint (PPT, PPTX) en C# avec du code propre et fiable."
---

{{% alert color="primary" %}} 

VSTO a été développé pour permettre aux développeurs de créer des applications pouvant s’exécuter à l’intérieur de Microsoft Office. VSTO est basé sur COM mais il est encapsulé dans un objet .NET afin de pouvoir être utilisé dans des applications .NET. VSTO nécessite la prise en charge du framework .NET ainsi que l’environnement d’exécution CLR de Microsoft Office. Bien qu’il puisse être utilisé pour créer des compléments Microsoft Office, il est presque impossible de l’utiliser en tant que composant côté serveur. Il présente également de sérieux problèmes de déploiement.

Aspose.Slides for .NET est un composant qui peut être utilisé pour manipuler des présentations Microsoft PowerPoint, tout comme VSTO, mais il présente plusieurs avantages :

- Aspose.Slides ne contient que du code managé et ne nécessite pas que le runtime Microsoft Office soit installé.
- Il peut être utilisé en tant que composant côté client ou côté serveur.
- Le déploiement est facile puisque Aspose.Slides est fourni dans un seul DLL.

{{% /alert %}} 
## **Créer une présentation**
Ci-dessous se trouvent deux exemples de code illustrant comment VSTO et Aspose.Slides for .NET peuvent être utilisés pour atteindre le même objectif. Le premier exemple est [VSTO](/slides/fr/net/create-a-new-presentation/); [le deuxième exemple](/slides/fr/net/create-a-new-presentation/) utilise Aspose.Slides.
### **Exemple VSTO**
**La sortie VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Note : PowerPoint est un espace de noms qui a été défini ci-dessus ainsi
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtenir la disposition de la diapositive titre
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Ajouter une diapositive de titre.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Définir le texte du titre
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Définir le texte du sous-titre
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Écrire la sortie sur le disque
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemple Aspose.Slides for .NET**
**La sortie d’Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//Créer une présentation
Presentation pres = new Presentation();

//Ajouter la diapositive de titre
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Définir le texte du titre
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Définir le texte du sous-titre
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Écrire la sortie sur le disque
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
