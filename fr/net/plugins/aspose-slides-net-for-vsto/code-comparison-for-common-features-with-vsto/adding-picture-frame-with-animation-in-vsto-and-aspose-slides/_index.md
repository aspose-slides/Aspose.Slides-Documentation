---
title: Ajouter un Cadre d'Image avec Animation dans VSTO et Aspose.Slides
type: docs
weight: 20
url: /fr/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

Les exemples de code ci-dessous créent une présentation avec une diapositive, ajoutent une image avec un cadre d'image et appliquent une animation à celle-ci.
## **VSTO**
En utilisant VSTO, suivez les étapes suivantes :

1. Créer une présentation.
1. Ajouter une diapositive vide.
1. Ajouter une forme d'image à la diapositive.
1. Appliquer une animation à l'image.
1. Écrire la présentation sur le disque.

``` csharp

 //Création d'une présentation vide

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Ajouter une diapositive vide

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Ajouter un Cadre d'Image

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Application d'une animation sur le cadre d'image

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Enregistrement de la Présentation

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
En utilisant Aspose.Slides pour .NET, procédez comme suit :

1. Créer une présentation.
1. Accéder à la première diapositive.
1. Ajouter une image à une collection d'images.
1. Ajouter une forme d'image à la diapositive.
1. Appliquer une animation à l'image.
1. Écrire la présentation sur le disque.

``` csharp

 //Création d'une présentation vide

Presentation pres = new Presentation();

//Accéder à la première diapositive

Slide slide = pres.GetSlideByPosition(1);

//Ajout de l'objet image à la collection d'images de la présentation

Picture pic = new Picture(pres, "pic.jpeg");

//Après l'ajout de l'objet image, l'image reçoit un identifiant d'image unique

int picId = pres.Pictures.Add(pic);

//Ajouter un Cadre d'Image

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Application d'une animation sur le cadre d'image

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Enregistrement de la Présentation

pres.Write("AsposeAnim.ppt");

``` 
## **Télécharger le Code d'Exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)