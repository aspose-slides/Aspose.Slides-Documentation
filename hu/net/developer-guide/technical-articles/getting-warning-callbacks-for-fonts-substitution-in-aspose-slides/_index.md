---
title: Figyelmeztető visszahívások lekérése a betűtípuscsere esetén .NET-ben
type: docs
weight: 120
url: /hu/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztető visszahívás
- betűtípuscsere
- renderelési folyamat
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan kapjon figyelmeztető visszahívásokat a betűtípuscsere esetén az Aspose.Slides for .NET-ben, és pontosan jelenítse meg a PowerPoint és OpenDocument prezentációkat."
---
## **Bevezetés**

Az Aspose.Slides for .NET lehetővé teszi, hogy figyelmeztető visszahívásokat kapjon a betűtípuscsere esetén, ha a szükséges betűtípus nem érhető el a gépen a megjelenítés során. Ezek a visszahívások segítenek a hiányzó vagy elérhetetlen betűtípusok problémáinak diagnosztizálásában.

## **Figyelmeztető visszahívások engedélyezése**

Az Aspose.Slides for .NET egyszerű API-kat biztosít a figyelmeztető visszahívások fogadásához a prezentációs diák renderelése során. Kövesse ezeket a lépéseket a figyelmeztető visszahívások konfigurálásához:

1. Hozzon létre egy egyedi visszahívásosztályt, amely megvalósítja az [IWarningCallback](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iwarningcallback/) interfészt a figyelmeztetések kezeléséhez.
2. Állítsa be a figyelmeztető visszahívást olyan opcióosztályok használatával, mint a [RenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/), a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) és egyéb.
3. Töltsön be egy prezentációt, amely olyan betűtípust használ, amely nem érhető el a célgépen.
4. Generáljon egy dia bélyegképet vagy exportálja a prezentációt a hatás megfigyeléséhez.

**Egyedi figyelmeztető visszahívásosztály:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Példa kimenet:
//
// A betűtípus XYZ helyett a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}-ra lesz cserélve
```

**Dia bélyegkép generálása:**

```c#
 // Állítsa be a figyelmeztető visszahívást a betűtípusokkal kapcsolatos figyelmeztetések kezeléséhez a dia renderelése során.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

 // Töltse be a prezentációt a megadott fájlútvonalról.
using var presentation = new Presentation("sample.pptx");

 // Generáljon bélyegképet minden diára a prezentációban.
foreach (var slide in presentation.Slides)
{
     // Szerezze be a dia bélyegképét a megadott renderelési beállítások használatával.
    using var image = slide.GetImage(options);
    // ...
}
```

**Export PDF formátumba:**

```c#
// Állítsa be a figyelmeztető visszahívást a PDF exportálása során a betűtípusokkal kapcsolatos figyelmeztetések kezeléséhez.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Töltse be a prezentációt a megadott fájlútvonalról.
using var presentation = new Presentation("sample.pptx");

// Exportálja a prezentációt PDF formátumban.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Export HTML formátumba:**

```c#
// Állítsa be a figyelmeztető visszahívást a HTML exportálása során a betűtípusokkal kapcsolatos figyelmeztetések kezeléséhez.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Töltse be a prezentációt a megadott fájlútvonalról.
using var presentation = new Presentation("sample.pptx");

// Exportálja a prezentációt HTML formátumban.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```