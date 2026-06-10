---
title: Diaváltások
type: docs
weight: 80
url: /hu/net/slide-transitions/
---
Az érthetőség kedvéért bemutattuk az Aspose.Slides for .NET használatát egyszerű diaváltások kezelésére. A fejlesztők nem csak különböző diaváltási effektusokat alkalmazhatnak a diákon, hanem testre is szabhatják ezeknek az effektusoknak a viselkedését. Egy egyszerű diaváltási effektus létrehozásához kövesse az alábbi lépéseket:

- Hozzon létre egy Presentation osztály példányt
- Alkalmazzon egy Slide Transition Type-ot a diára az Aspose.Slides for .NET által kínált diaváltási effektusok egyikével a **TransitionType** enumeráción keresztül
- Írja ki a módosított bemutató fájlt.
## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel

using (Presentation pres = new Presentation(FileName))

{

    //Alkalmazzon kör típusú átmenetet az 1. dián

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Alkalmazzon comb típusú átmenetet a 2. dián

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Alkalmazzon zoom típusú átmenetet a 3. dián

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Mentse a bemutatót a lemezre

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Minta Kód Letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Futtatható Példa Letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

További részletekért látogassa meg a [Diaváltások Kezelése](/slides/hu/net/slide-transition/).

{{% /alert %}}