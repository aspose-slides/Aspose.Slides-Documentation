---
title: Imprimer la présentation
type: docs
url: /fr/net/print-the-presentation/
---

Aspose.Slides for .NET propose quatre surcharges de méthodes pour l’impression des présentations. Ces méthodes sont suffisamment flexibles pour imprimer la présentation sur l’imprimante par défaut ou sur n’importe quelle imprimante disponible avec des paramètres personnalisés. Vous devez simplement sélectionner la méthode d’impression appropriée en fonction du besoin.
## **Imprimer sur l’imprimante par défaut**
L’impression de la présentation sur l’imprimante par défaut est très simple dans Aspose.Slides for .NET. Effectuez les étapes suivantes pour imprimer la présentation sur l’imprimante par défaut :

- Créez une instance de la classe Presentation pour charger une présentation à imprimer
- Appelez la méthode Print sans paramètres telle qu’exposée par l’objet Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // Charger la présentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // Appeler la méthode d’impression pour imprimer toute la présentation sur l’imprimante par défaut
    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // Charger la présentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // Appeler la méthode d’impression pour imprimer toute la présentation sur l’imprimante souhaitée
    asposePresentation.Print("LaserJet1100");


``` 
## **Imprimer sur une imprimante spécifique**
L’impression de la présentation sur une imprimante spécifique nécessite le nom de l’imprimante en paramètre de la méthode Print de la classe Presentation. Effectuez les étapes suivantes pour imprimer la présentation sur l’imprimante souhaitée :

- Créez une instance de la classe Presentation pour charger une présentation à imprimer
- Appelez la méthode Print de la classe Presentation avec le nom de l’imprimante en paramètre

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // Charger la présentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // Appeler la méthode d’impression pour imprimer toute la présentation sur l’imprimante souhaitée
    asposePresentation.Print("LaserJet1100");

}

``` 
## **Télécharger le code d’exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)