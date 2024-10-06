---
title: Impression de présentation
type: docs
url: /net/impression-de-la-presentation/
---

Aspose.Slides pour .NET fournit quatre méthodes de surcharge pour l'impression des présentations. Ces méthodes sont suffisamment flexibles pour imprimer la présentation sur l'imprimante par défaut ou sur n'importe quelle imprimante disponible avec des paramètres personnalisés. Il vous suffit de sélectionner la méthode d'impression appropriée en fonction de vos besoins.
## **Impression sur l'imprimante par défaut**
L'impression de la présentation sur l'imprimante par défaut est assez simple dans Aspose.Slides pour .NET. Effectuez les étapes suivantes pour imprimer la présentation sur l'imprimante par défaut :

- Créez une instance de la classe Presentation pour charger une présentation à imprimer
- Appelez la méthode Print sans paramètres telle qu'exposée par l'objet Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Fichiers d'exemple\";

    //Charger la présentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Appeler la méthode d'impression pour imprimer l'ensemble de la présentation sur l'imprimante par défaut

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Fichiers d'exemple\";

    //Charger la présentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Appeler la méthode d'impression pour imprimer l'ensemble de la présentation sur l'imprimante désirée

    asposePresentation.Print("LaserJet1100");


``` 
## **Impression sur une imprimante spécifique**
L'impression de la présentation sur une imprimante spécifique nécessite le nom de l'imprimante comme paramètre de la méthode Print de la classe Presentation. Effectuez les étapes suivantes pour imprimer la présentation sur l'imprimante désirée :

- Créez une instance de la classe Presentation pour charger une présentation à imprimer
- Appelez la méthode Print de la classe Presentation avec le nom de l'imprimante comme paramètre de chaîne pour la méthode Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Fichiers d'exemple\";

    //Charger la présentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Appeler la méthode d'impression pour imprimer l'ensemble de la présentation sur l'imprimante désirée

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)