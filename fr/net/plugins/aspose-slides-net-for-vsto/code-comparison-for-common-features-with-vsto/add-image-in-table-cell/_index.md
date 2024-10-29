---
title: Ajouter une image dans une cellule de tableau
type: docs
weight: 10
url: /fr/net/add-image-in-table-cell/
---

## **VSTO**
Voici le code pour ajouter une image dans une cellule de tableau :

``` csharp

    //Ouvrir la classe Présentation qui contient le tableau

   string FileName = "Ajouter une image dans une cellule de tableau.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtenir la première diapositive

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides pour .NET a fourni la plus simple API pour créer des tableaux de la manière la plus facile. Pour ajouter une image dans une cellule de tableau lors de la création d'un nouveau tableau, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Présentation
- Obtenir la référence d'une diapositive en utilisant son index
- Définir un tableau de colonnes avec largeur
- Définir un tableau de lignes avec hauteur
- Ajouter un tableau à la diapositive en utilisant la méthode AddTable exposée par l'objet IShapes
- Créer un objet Bitmap pour contenir le fichier image
- Ajouter l'image Bitmap à l'objet IPPImage
- Définir le format de remplissage de la cellule du tableau comme image
- Ajouter l'image à la première cellule du tableau
- Enregistrer la présentation modifiée en tant que fichier PPTX

``` csharp

   string FileName = "Ajouter une image dans une cellule de tableau.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation MyPresentation = new Presentation(FileName);

   //Obtenir la première diapositive

   ISlide sld = MyPresentation.Slides[0];

   //Créer un objet d'image Bitmap pour contenir le fichier image

   using IImage image = Images.FromFile(ImageFile);

   //Créer un objet IPPImage en utilisant l'objet bitmap

   IPPImage imgx1 = MyPresentation.Images.AddImage(image);

   foreach (IShape shp in sld.Shapes)

   if (shp is ITable)

   {

     ITable tbl = (ITable)shp;

     //Ajouter l'image à la première cellule du tableau

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Sauvegarder le PPTX sur le disque

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Télécharger le code en cours d'exécution**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code exemple**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Ajouter une image dans une cellule de tableau/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Comparison%20de%20code%20des%20fonctions%20communes/Ajouter%20une%20image%20dans%20une%20cellule%20de%20tableau)