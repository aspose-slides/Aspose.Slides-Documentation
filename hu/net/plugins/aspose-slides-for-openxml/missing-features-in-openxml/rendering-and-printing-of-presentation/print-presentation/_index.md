---
title: Prezentáció nyomtatása
type: docs
url: /hu/net/print-the-presentation/
---
Az Aspose.Slides for .NET négy túlterheléses metódust biztosít a prezentációk nyomtatásához. Ezek a metódusok elég rugalmasak ahhoz, hogy a prezentációt az alapértelmezett nyomtatóra vagy bármely elérhető nyomtatóra egyedi beállításokkal nyomtassák. Csak a követelménynek megfelelő nyomtatási metódust kell kiválasztania.
## **Nyomtatás az alapértelmezett nyomtatóra**
A prezentáció alapértelmezett nyomtatóra történő nyomtatása az Aspose.Slides for .NET-ben meglehetősen egyszerű. Hajtsa végre a következő lépéseket a prezentáció alapértelmezett nyomtatóra történő nyomtatásához:

- Hozzon létre egy Presentation osztálypéldányt a nyomtatandó prezentáció betöltéséhez
- Hívja meg a Print metódust paraméterek nélkül a Presentation objektumon keresztül

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Betölti a prezentációt
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Hívja a nyomtatási metódust a teljes prezentáció alapértelmezett nyomtatóra nyomtatásához
    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Betölti a prezentációt
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Hívja a nyomtatási metódust a teljes prezentáció a kívánt nyomtatóra nyomtatásához
    asposePresentation.Print("LaserJet1100");


``` 
## **Nyomtatás egy adott nyomtatóra**
A prezentáció adott nyomtatóra történő nyomtatásához a nyomtató nevét kell megadni a Presentation Print metódusának paramétereként. Hajtsa végre a következő lépéseket a prezentáció a kívánt nyomtatóra történő nyomtatásához:

- Hozzon létre egy Presentation osztálypéldányt a nyomtatandó prezentáció betöltéséhez
- Hívja meg a Presentation osztály Print metódusát a nyomtató nevének string paraméterként történő megadásával

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Betölti a prezentációt
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Hívja a nyomtatási metódust a teljes prezentáció a kívánt nyomtatóra nyomtatásához
    asposePresentation.Print("LaserJet1100");

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)