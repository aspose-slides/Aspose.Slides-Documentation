---
title: Ajouter des formes à la présentation
type: docs
weight: 30
url: /fr/net/adding-shapes-to-presentation/
---

## **VSTO**
Voici le fragment de code pour ajouter une forme de ligne :

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d'une diapositive en utilisant son index
- Ajoutez une forme automatique de type ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Écrivez la présentation modifiée en tant que fichier PPTX

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

``` csharp

   //Instancier la classe Presentation qui représente le PPTX

  Presentation pres = new Presentation();

  //Obtenez la première diapositive

  ISlide slide = pres.Slides[0];

  //Ajouter une forme automatique de type ligne

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Télécharger le code en cours d'exécution**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)