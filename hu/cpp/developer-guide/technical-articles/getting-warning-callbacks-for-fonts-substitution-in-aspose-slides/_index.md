---
title: Figyelmeztető visszahívások lekérése a betűkészlet helyettesítéséhez
type: docs
weight: 70
url: /hu/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztető visszahívás
- betűkészlet helyettesítés
- renderelési folyamat
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet figyelmeztető visszahívásokat lekérni a betűkészlet helyettesítéséhez az Aspose.Slides for C++-ban, és pontosan megjeleníteni a PowerPoint és OpenDocument bemutatókat."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy figyelmeztető visszahívásokat kapjon a betűkészlet helyettesítésére, amikor egy szükséges betűkészlet nem érhető el a gépen a renderelés során. Ezek a visszahívások segítenek a hiányzó vagy elérhetetlen betűkészletekkel kapcsolatos problémák diagnosztizálásában.

## **Figyelmeztető visszahívások engedélyezése**

Az Aspose.Slides for C++ egyszerű API-kat biztosít a figyelmeztető visszahívások fogadásához a bemutató diáknak renderelése közben. Kövesse az alábbi lépéseket a figyelmeztető visszahívások beállításához:

1. Hozzon létre egy egyéni visszahívási osztályt, amely megvalósítja a [IWarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iwarningcallback/) interfészt a figyelmeztetések kezelése érdekében.
2. Állítsa be a figyelmeztető visszahívást olyan opcióosztályok segítségével, mint a [RenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) és egyebek.
3. Töltsön be egy bemutatót, amely olyan betűkészletet használ, amely nem érhető el a célgépen.
4. Készítsen dia bélyegképet vagy exportálja a bemutatót a hatás megfigyeléséhez.

**Egyéni figyelmeztető visszahívási osztály:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Példa kimenet:
//
// A betűkészlet helyettesítésre kerül az XYZ-ről a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Dia bélyegkép generálása:**

```cpp
// Állítsa be a figyelmeztető visszahívást a betűkkel kapcsolatos figyelmeztetések kezeléséhez a dia renderelése során.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Töltse be a bemutatót a megadott fájlútról.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Készítsen bélyegkép-et a bemutató minden diájához.
for(auto&& slide : presentation->get_Slides())
{
    // Szerezze meg a dia bélyegképét a megadott renderelési opciók használatával.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Exportálás PDF formátumba:**

```cpp
// Állítsa be a figyelmeztető visszahívást a betűkkel kapcsolatos figyelmeztetések kezeléséhez a PDF exportálás során.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Töltse be a bemutatót a megadott fájlútról.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportálja a bemutatót PDF-ként.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Exportálás HTML formátumba:**

```cpp
// Állítsa be a figyelmeztető visszahívást a betűkkel kapcsolatos figyelmeztetések kezeléséhez a HTML exportálás során.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Töltse be a bemutatót a megadott fájlútról.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportálja a bemutatót HTML formátumban.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```