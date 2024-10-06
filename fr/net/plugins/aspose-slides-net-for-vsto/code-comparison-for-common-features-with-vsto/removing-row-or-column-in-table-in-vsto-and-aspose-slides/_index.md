---
title: Suppression de ligne ou de colonne dans un tableau dans VSTO et Aspose.Slides
type: docs
weight: 130
url: /net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Voici le code pour supprimer des lignes ou des colonnes d'un tableau en utilisant la présentation VSTO :

``` csharp

    string FileName = "Suppression de ligne ou de colonne dans un tableau.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtenir la première diapositive

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides pour .NET a fourni la plus simple API pour créer des tableaux de la manière la plus facile. Pour créer un tableau dans une diapositive et réaliser quelques opérations de base sur le tableau, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d'une diapositive en utilisant son index
- Définissez un tableau de colonnes avec largeur
- Définissez un tableau de lignes avec hauteur
- Ajoutez un tableau à la diapositive en utilisant la méthode AddTable exposée par l'objet IShapes
- Supprimez une ligne du tableau
- Supprimez une colonne du tableau
- Écrivez la présentation modifiée en tant que fichier PPTX

``` csharp

   string FileName = "Suppression de ligne ou de colonne dans un tableau.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Obtenir la première diapositive

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Télécharger le code en cours d'exécution**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Suppression de ligne ou de colonne dans un tableau/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Suppression%20de%20ligne%20ou%20de%20colonne%20dans%20un%20tableau)