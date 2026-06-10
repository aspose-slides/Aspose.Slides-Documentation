---
title: Prezentáció megnyitása VSTO-val és az Aspose.Slides használatával
type: docs
weight: 120
url: /hu/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Az alábbi kódrészlet a prezentáció megnyitásához:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET a **Presentation** osztályt biztosítja, amely egy meglévő prezentáció megnyitására használható. Néhány túlterhelt konstruktorral rendelkezik, és a **Presentation** osztály megfelelő konstruktorainak valamelyikét felhasználhatjuk, hogy egy meglévő prezentáció alapján példányosítsuk. Az alábbi példában a megnyitandó prezentációfájl nevét adjuk át a Presentation osztály konstruktorának. A fájl megnyitása után lekérdezzük a prezentációban található diák teljes számát, és kiírjuk a képernyőre.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Futó kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)