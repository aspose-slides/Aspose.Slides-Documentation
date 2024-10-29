---
title: Transitions de Diapositive
type: docs
weight: 80
url: /fr/net/slide-transitions/
---

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour .NET pour gérer de simples transitions de diapositive. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

- Créez une instance de la classe Presentation
- Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides pour .NET via l'énumération **TransitionType**
- Écrivez le fichier de présentation modifié.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Fichiers d'exemple\";

string FileName = FilePath + "Gérer les Transitions de Diapositives.pptx";

//Instancier la classe Presentation qui représente un fichier de présentation

using (Presentation pres = new Presentation(FileName))

{

    //Appliquer une transition de type cercle sur la diapositive 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Appliquer une transition de type peigne sur la diapositive 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Appliquer une transition de type zoom sur la diapositive 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Enregistrer la présentation sur le disque

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Télécharger l'Exemple Exécutable**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Gérer les Transitions de Diapositives](/slides/fr/net/slide-transition/).

{{% /alert %}}