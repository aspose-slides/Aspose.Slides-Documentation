---
title: Ouverture d'une présentation dans VSTO et Aspose.Slides
type: docs
weight: 120
url: /fr/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Voici l'extrait de code pour ouvrir une présentation :

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET fournit la classe **Presentation** qui est utilisée pour ouvrir une présentation existante. Il propose plusieurs constructeurs surchargés et nous pouvons utiliser l'un des constructeurs appropriés de la classe **Presentation** pour créer son objet à partir d'une présentation existante. Dans l'exemple ci‑dessous, nous avons passé le nom du fichier de présentation (à ouvrir) au constructeur de la classe Presentation. Après l'ouverture du fichier, nous obtenons le nombre total de diapositives présentes dans la présentation pour l'afficher à l'écran.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)