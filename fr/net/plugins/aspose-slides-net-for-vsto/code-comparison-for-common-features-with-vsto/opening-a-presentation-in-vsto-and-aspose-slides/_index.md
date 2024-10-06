---
title: Ouvrir une présentation dans VSTO et Aspose.Slides
type: docs
weight: 120
url: /net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Ci-dessous se trouve l'extrait de code pour ouvrir une présentation :

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);

``` 
## **Aspose.Slides**
Aspose.Slides pour .NET fournit la classe **Presentation** qui est utilisée pour ouvrir une présentation existante. Elle offre quelques constructeurs surchargés et nous pouvons utiliser l'un des constructeurs appropriés de la classe **Presentation** pour créer son objet en fonction d'une présentation existante. Dans l'exemple donné ci-dessous, nous avons passé le nom du fichier de présentation (à ouvrir) au constructeur de la classe Presentation. Après que le fichier soit ouvert, nous obtenons le nombre total de diapositives présentes dans la présentation à afficher à l'écran.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Télécharger le Code Exécuté**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Télécharger le Code Exemple**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)