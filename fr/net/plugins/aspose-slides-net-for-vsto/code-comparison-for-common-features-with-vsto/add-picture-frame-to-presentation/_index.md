---
title: Ajouter un cadre d'image à la présentation
type: docs
weight: 50
url: /fr/net/add-picture-frame-to-presentation/
---

## **VSTO**
Voici le code pour ajouter une image dans une présentation VSTO :

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Pour ajouter un cadre d'image simple à votre diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.  
2. Obtenez la référence d’une diapositive en utilisant son indice.  
3. Créez un objet Image en ajoutant une image à la collection Images associée à l'objet Presentation qui sera utilisé pour remplir la forme.  
4. Calculez la largeur et la hauteur de l'image.  
5. Créez un PictureFrame selon la largeur et la hauteur de l'image en utilisant la méthode AddPictureFrame exposée par l'objet Shapes associé à la diapositive référencée.  
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.  
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Les étapes ci‑dessus sont implémentées dans l'exemple ci‑dessous.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Télécharger le code d'exécution**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)