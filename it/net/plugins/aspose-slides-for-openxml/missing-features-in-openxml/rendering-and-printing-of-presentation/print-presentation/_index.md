---
title: Stampa della presentazione
type: docs
url: /it/net/print-the-presentation/
---
Aspose.Slides per .NET offre quattro metodi sovraccaricati per la stampa delle presentazioni. Questi metodi sono sufficientemente flessibili per stampare la presentazione sulla stampante predefinita o su qualsiasi stampante disponibile con impostazioni personalizzate. È sufficiente selezionare il metodo di stampa appropriato in base al requisito.
## **Stampa sulla stampante predefinita**
- Crea un'istanza della classe Presentation per caricare una presentazione da stampare
- Chiama il metodo Print senza parametri così come è esposto dall'oggetto Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carica la presentazione

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chiama il metodo di stampa per stampare l'intera presentazione sulla stampante predefinita

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carica la presentazione

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chiama il metodo di stampa per stampare l'intera presentazione sulla stampante desiderata

    asposePresentation.Print("LaserJet1100");
``` 
## **Stampa su una stampante specifica**
- Crea un'istanza della classe Presentation per caricare una presentazione da stampare
- Chiama il metodo Print della classe Presentation passando il nome della stampante come parametro stringa al metodo Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carica la presentazione

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chiama il metodo di stampa per stampare l'intera presentazione sulla stampante desiderata

    asposePresentation.Print("LaserJet1100");

}
``` 
## **Scarica il codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)