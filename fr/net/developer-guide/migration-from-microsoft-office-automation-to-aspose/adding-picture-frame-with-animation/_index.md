---
title: Ajout de cadre photo avec animation
type: docs
weight: 60
url: /net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

Les cadres photo sont appliqués aux formes ou aux images dans Microsoft PowerPoint pour encadrer les images dans une présentation. Cet article montre comment créer un cadre photo et appliquer une animation dessus par programmation en utilisant d'abord [VSTO 2008](/slides/net/adding-picture-frame-with-animation/) puis [Aspose.Slides for .NET](/slides/net/adding-picture-frame-with-animation/). Tout d'abord, nous vous montrons comment appliquer un cadre et une animation en utilisant VSTO 2008. Nous vous montrons ensuite comment effectuer les mêmes étapes en utilisant Aspose.Slides pour .NET.

{{% /alert %}} 
## **Ajout de cadres photo avec animation**
Les exemples de code ci-dessous créent une présentation avec une diapositive, ajoutent une image avec un cadre photo et appliquent une animation à celui-ci.
### **Exemple VSTO 2008**
En utilisant VSTO 2008, suivez les étapes suivantes :

1. Créer une présentation.
1. Ajouter une diapositive vide.
1. Ajouter une forme d'image à la diapositive.
1. Appliquer une animation à l'image.
1. Écrire la présentation sur le disque.

**La présentation de sortie, créée avec VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Création d'une présentation vide
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Ajouter une diapositive vide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Ajouter un cadre photo
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Appliquer une animation sur le cadre photo
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Sauvegarder la présentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemple Aspose.Slides pour .NET**
En utilisant Aspose.Slides pour .NET, effectuez les étapes suivantes :

1. Créer une présentation.
1. Accéder à la première diapositive.
1. Ajouter une image à une collection d'images.
1. Ajouter une forme d'image à la diapositive.
1. Appliquer une animation à l'image.
1. Écrire la présentation sur le disque.

**La présentation de sortie, créée avec Aspose.Slides** 

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

    // Ajouter un cadre photo dont la hauteur et la largeur correspondent à la hauteur et à la largeur de l'image
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Obtenir la séquence d'animation principale de la diapositive
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ajouter l'effet d'animation "Vol à partir de la gauche" au cadre photo
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Sauvegarder la présentation
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```