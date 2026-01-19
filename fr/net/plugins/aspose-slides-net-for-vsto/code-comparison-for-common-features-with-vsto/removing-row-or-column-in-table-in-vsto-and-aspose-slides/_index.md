---
title: Suppression d'une ligne ou d'une colonne dans un tableau avec VSTO et Aspose.Slides
type: docs
weight: 130
url: /fr/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Ci-dessous le code pour supprimer des lignes ou des colonnes d'un tableau à l'aide de VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides pour .NET propose l'API la plus simple pour créer des tableaux de la manière la plus facile. Pour créer un tableau dans une diapositive et effectuer des opérations de base sur le tableau, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son index
- Définir un tableau de colonnes avec la largeur
- Définir un tableau de lignes avec la hauteur
- Ajouter un tableau à la diapositive en utilisant la méthode AddTable exposée par l'objet IShapes
- Supprimer une ligne du tableau
- Supprimer une colonne du tableau
- Enregistrer la présentation modifiée au format PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

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
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)