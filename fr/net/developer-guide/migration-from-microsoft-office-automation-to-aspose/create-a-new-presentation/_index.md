---
title: Créer une nouvelle présentation
type: docs
weight: 10
url: /fr/net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO a été développé pour permettre aux développeurs de créer des applications pouvant fonctionner à l'intérieur de Microsoft Office. VSTO est basé sur COM mais il est encapsulé dans un objet .NET afin qu'il puisse être utilisé dans des applications .NET. VSTO nécessite un support du framework .NET ainsi qu'un runtime basé sur CLR de Microsoft Office. Bien qu'il puisse être utilisé pour créer des compléments Microsoft Office, il est pratiquement impossible à utiliser comme composant côté serveur. Il présente également de sérieux problèmes de déploiement.

Aspose.Slides pour .NET est un composant qui peut être utilisé pour manipuler des présentations Microsoft PowerPoint, tout comme VSTO, mais il a plusieurs avantages :

- Aspose.Slides contient uniquement du code managé et ne nécessite pas l'installation du runtime Microsoft Office.
- Il peut être utilisé comme un composant côté client ou comme un composant côté serveur.
- Le déploiement est facile puisque Aspose.Slides est contenu dans une seule DLL.

{{% /alert %}} 
## **Création d'une présentation**
Voici deux exemples de code qui illustrent comment VSTO et Aspose.Slides pour .NET peuvent être utilisés pour atteindre le même objectif. Le premier exemple est [VSTO](/slides/fr/net/create-a-new-presentation/) ; [le deuxième exemple](/slides/fr/net/create-a-new-presentation/) utilise Aspose.Slides.
### **Exemple VSTO**
**La sortie VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Note : PowerPoint est un espace de noms qui a été défini ci-dessus comme ceci
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtenir la mise en page de la diapositive titre
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Ajouter une diapositive titre.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Définir le texte du titre
slide.Shapes.Title.TextFrame.TextRange.Text = "Titre de la diapositive";

//Définir le texte du sous-titre
slide.Shapes[2].TextFrame.TextRange.Text = "Sous-titre de la diapositive";

//Écrire la sortie sur le disque
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemple Aspose.Slides pour .NET**
**La sortie d'Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Créer une présentation
Presentation pres = new Presentation();

//Ajouter la diapositive titre
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Définir le texte du titre
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Titre de la diapositive";

//Définir le texte du sous-titre
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Sous-titre de la diapositive";

//Écrire la sortie sur le disque
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```