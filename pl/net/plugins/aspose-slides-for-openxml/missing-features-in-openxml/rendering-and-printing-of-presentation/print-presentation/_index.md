---
title: Drukowanie prezentacji
type: docs
url: /pl/net/print-the-presentation/
---
Aspose.Slides for .NET udostępnia cztery przeciążone metody drukowania prezentacji. Metody te są wystarczająco elastyczne, aby wydrukować prezentację na drukarce domyślnej lub na dowolnej dostępnej drukarce z niestandardowymi ustawieniami. Wystarczy wybrać odpowiednią metodę drukowania zgodnie z wymaganiami.

## **Drukowanie na drukarce domyślnej**
Drukowanie prezentacji na drukarce domyślnej jest bardzo proste w Aspose.Slides for .NET. Wykonaj następujące kroki, aby wydrukować prezentację na drukarce domyślnej:

- Utwórz instancję klasy Presentation, aby załadować prezentację, którą ma zostać wydrukowana
- Wywołaj metodę Print bez parametrów, udostępnioną przez obiekt Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Wczytaj prezentację

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Wywołaj metodę drukowania, aby wydrukować całą prezentację na drukarce domyślnej

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Wczytaj prezentację

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Wywołaj metodę drukowania, aby wydrukować całą prezentację na wybranej drukarce

    asposePresentation.Print("LaserJet1100");


``` 
## **Drukowanie na wybranej drukarce**
Drukowanie prezentacji na konkretnej drukarce wymaga podania nazwy drukarki jako parametru metody Print klasy Presentation. Wykonaj następujące kroki, aby wydrukować prezentację na wybranej drukarce:

- Utwórz instancję klasy Presentation, aby załadować prezentację, którą ma zostać wydrukowana
- Wywołaj metodę Print klasy Presentation, przekazując nazwę drukarki jako parametr typu string

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Wczytaj prezentację

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Wywołaj metodę drukowania, aby wydrukować całą prezentację na wybranej drukarce

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)