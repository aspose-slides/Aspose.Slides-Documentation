---
title: Transitions de diapositives
type: docs
weight: 80
url: /fr/net/slide-transitions/
---

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides for .NET pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositives, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Appliquer un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for .NET via l'énumération **TransitionType**
- Enregistrer le fichier de présentation modifié.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Télécharger l'exemple fonctionnel**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Pour plus de détails, consultez [Gestion des transitions de diapositives](/slides/fr/net/slide-transition/).
{{% /alert %}}