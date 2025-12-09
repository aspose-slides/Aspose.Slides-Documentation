---
title: Ajout de cadres d'image avec animation en utilisant VSTO et Aspose.Slides pour .NET
linktitle: Cadres d'image avec animation
type: docs
weight: 60
url: /fr/net/adding-picture-frame-with-animation/
keywords:
- cadre d'image
- ajouter image
- ajouter image
- image avec animation
- image avec animation
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Migrez de l'automatisation Microsoft Office vers Aspose.Slides pour .NET et animez les cadres d'image dans les diapositives PowerPoint (PPT, PPTX) avec du code C# propre."
---

{{% alert color="primary" %}} 
Les cadres d’image sont appliqués aux formes ou aux images dans Microsoft PowerPoint pour encadrer les images dans une présentation. Cet article montre comment créer un cadre d’image et appliquer une animation de façon programmatique en utilisant d’abord [VSTO 2008](/slides/fr/net/adding-picture-frame-with-animation/) puis [Aspose.Slides for .NET](/slides/fr/net/adding-picture-frame-with-animation/). Tout d’abord, nous vous montrons comment appliquer un cadre et une animation avec VSTO 2008. Nous vous montrons ensuite comment réaliser les mêmes étapes avec Aspose.Slides for .NET.
{{% /alert %}} 
## **Ajout de cadres d’image avec animation**
Les exemples de code ci‑dessous créent une présentation avec une diapositive, ajoutent une image avec un cadre d’image et appliquent une animation dessus.
### **Exemple VSTO 2008**
Avec VSTO 2008, suivez les étapes suivantes :

1. Créer une présentation.
1. Ajouter une diapositive vide.
1. Ajouter une forme image à la diapositive.
1. Appliquer une animation à l’image.
1. Enregistrer la présentation sur le disque.

**La présentation résultante, créée avec VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
 //Création d'une présentation vide
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

 //Ajout d'une diapositive vierge
 PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

 //Ajout d'un cadre d'image
 PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

 //Application d'une animation sur le cadre d'image
 PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

 //Enregistrement de la présentation
 pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
 Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemple Aspose.Slides for .NET**
Avec Aspose.Slides for .NET, effectuez les étapes suivantes :

1. Créer une présentation.
1. Accéder à la première diapositive.
1. Ajouter une image à une collection d’images.
1. Ajouter une forme image à la diapositive.
1. Appliquer une animation à l’image.
1. Enregistrer la présentation sur le disque.

**La présentation résultante, créée avec Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
 // Créer une présentation vide
 using (Presentation pres = new Presentation())
 {
     // Accéder à la première diapositive
     ISlide slide = pres.Slides[0];

     // Ajouter une image à la collection d'images de la présentation
     IImage image = Images.FromFile("aspose.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // Ajouter un cadre d'image dont la hauteur et la largeur correspondent à celles de l'image
     IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

     // Obtenir la séquence d'animation principale de la diapositive
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // Ajouter l'effet d'animation Voler depuis la gauche au cadre d'image
     IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

     // Enregistrer la présentation
     pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
 }
```
