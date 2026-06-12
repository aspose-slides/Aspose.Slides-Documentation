---
title: Tisk prezentace
type: docs
url: /cs/net/print-the-presentation/
---
Aspose.Slides for .NET poskytuje čtyři přetížené metody pro tisk prezentací. Tyto metody jsou dostatečně flexibilní k tisku prezentace na výchozí tiskárnu nebo na libovolnou dostupnou tiskárnu s přizpůsobeným nastavením. Stačí vybrat vhodnou tiskovou metodu podle požadavku.
## **Print to the Default Printer**
Tisk prezentace na výchozí tiskárnu je v Aspose.Slides for .NET poměrně jednoduchý. Proveďte následující kroky k tisku prezentace na výchozí tiskárnu:

- Vytvořte instanci třídy Presentation pro načtení prezentace, která má být vytisknuta
- Zavolejte metodu Print bez parametrů, jak je poskytována objektem Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Načtěte prezentaci
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Zavolejte metodu Print k tisku celé prezentace na výchozí tiskárnu
    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Načtěte prezentaci
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Zavolejte metodu Print k tisku celé prezentace na požadovanou tiskárnu
    asposePresentation.Print("LaserJet1100");


``` 
## **Print to a Specific Printer**
Tisk prezentace na konkrétní tiskárnu vyžaduje název tiskárny jako parametr metody Print třídy Presentation. Proveďte následující kroky k tisku prezentace na požadovanou tiskárnu:

- Vytvořte instanci třídy Presentation pro načtení prezentace, která má být vytisknuta
- Zavolejte metodu Print třídy Presentation s názvem tiskárny jako řetězcovým parametrem metody Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Načtěte prezentaci
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Zavolejte metodu Print k tisku celé prezentace na požadovanou tiskárnu
    asposePresentation.Print("LaserJet1100");

}

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)