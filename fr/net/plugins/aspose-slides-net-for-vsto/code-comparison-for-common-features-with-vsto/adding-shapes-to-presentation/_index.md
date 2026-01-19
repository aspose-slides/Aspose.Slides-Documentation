---
title: Ajout de formes à la présentation
type: docs
weight: 30
url: /fr/net/adding-shapes-to-presentation/
---

## **VSTO**
Voici l'extrait de code pour ajouter une forme de ligne :

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son Index
- Ajouter une AutoShape de type Line en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Enregistrer la présentation modifiée sous forme de fichier PPTX

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Télécharger le code en cours d'exécution**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)