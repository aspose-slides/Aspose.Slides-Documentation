---
title: Imprimer la présentation
type: docs
url: /fr/net/print-the-presentation/
---

Aspose.Slides for .NET propose quatre surcharges de méthodes pour l'impression des présentations. Ces méthodes sont suffisamment flexibles pour imprimer la présentation sur l'imprimante par défaut ou sur n'importe quelle imprimante disponible avec des paramètres personnalisés. Vous n'avez qu'à sélectionner la méthode d'impression appropriée en fonction du besoin.
## **Imprimer sur l'imprimante par défaut**
L'impression de la présentation sur l'imprimante par défaut est très simple avec Aspose.Slides for .NET. Suivez les étapes suivantes pour imprimer la présentation sur l'imprimante par défaut :

- Créer une instance de la classe Presentation pour charger la présentation à imprimer
- Appeler la méthode Print sans paramètres telle qu'exposée par l'objet Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the default printer

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");


``` 
## **Imprimer sur une imprimante spécifique**
L'impression de la présentation sur une imprimante spécifique nécessite le nom de l'imprimante en paramètre de la méthode Print de la classe Presentation. Suivez les étapes suivantes pour imprimer la présentation sur l'imprimante souhaitée :

- Créer une instance de la classe Presentation pour charger la présentation à imprimer
- Appeler la méthode Print de la classe Presentation avec le nom de l'imprimante comme paramètre chaîne

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)