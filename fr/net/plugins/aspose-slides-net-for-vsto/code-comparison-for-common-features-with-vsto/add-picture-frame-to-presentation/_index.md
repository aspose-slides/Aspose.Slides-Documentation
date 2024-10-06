---
title: Ajouter un cadre photo à la présentation
type: docs
weight: 50
url: /net/add-picture-frame-to-presentation/
---

## **VSTO**
Voici le code pour ajouter une image dans la présentation VSTO :

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Pour ajouter un cadre photo simple à votre diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Créez un objet Image en ajoutant une image à la collection Images associée à l'objet Presentation qui sera utilisé pour remplir la forme.
1. Calculez la largeur et la hauteur de l'image.
1. Créez un PictureFrame selon la largeur et la hauteur de l'image en utilisant la méthode AddPictureFrame exposée par l'objet Shapes associé à la diapositive référencée.
1. Ajoutez un cadre photo (contenant l'image) à la diapositive.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Les étapes ci-dessus sont mises en œuvre dans l'exemple donné ci-dessous.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instanciez la classe Prseetation qui représente le PPTX

  Presentation pres = new Presentation();

  //Obtenez la première diapositive

  ISlide sld = pres.Slides[0];

  //Instanciez la classe ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Ajoutez un cadre photo avec une hauteur et une largeur équivalentes à la photo

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Télécharger le code exécutable**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code exemple**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Ajouter un cadre photo/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Ajouter%20un%20cadre%20photo)