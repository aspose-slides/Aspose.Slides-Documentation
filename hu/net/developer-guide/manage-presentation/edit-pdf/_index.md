---
title: PDF dokumentumok szerkesztése .NET-ben
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/net/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF → PPTX
- PPTX → PDF
- .NET
- C#
- Aspose.Slides
description: "PDF dokumentumok szerkesztése C#-ban az Aspose.Slides-be való importálással, szövegcserével és a módosított bemutató PDF‑ként való mentésével."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi a PDF tartalom szerkesztését az oldalak diaként való importálásával, a bemutató módosításával és a visszaexportálással PDF formátumba. Ez a cikk egy egyszerű szövegcserét mutat be. A bemutató a memóriában marad, így a köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF‑ben**

Használja az [AddFromPdf](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addfrompdf/) metódust az oldalak importálásához, a [ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replacetext/) metódust a szöveg frissítéséhez, és a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust az eredmény exportálásához.

A következő példa azt várja, hogy a `input.pdf` tartalmazza a "Draft" szót szerkeszthető szövegként az importálás után. Lecseréli ezt a szót a "Final" szóra, és a `edited.pdf` fájlba írja. Az első dia törlése az importálás előtt megakadályoz egy extra üres oldalt a kimenetben. A keresés teljes szavakat egyező betűmérettel keres; a `null` azt jelenti, hogy nincs szükség eredmény‑callback‑re.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

További beállításokért tekintse meg a [Search and Replace Text](/slides/hu/net/search-and-replace-text/) és a [Convert PowerPoint to PDF](/slides/hu/net/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere az importált szövegen működik, nem a beolvasott képekben lévő szövegen. A konverzió befolyásolhatja a layoutot és a formázást, ezért ellenőrizze a kimenetet, különösen akkor, ha a csere‑szöveg hosszabb, mint az eredeti.
{{% /alert %}}

## **GYIK**

**Szükséges PPTX fájlt menteni a PDF exportálása előtt?**

Nem. A bemutatót a memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor mentse, ha továbbra is PowerPointban szeretné szerkeszteni; lásd a [Save Presentations](/slides/hu/net/save-presentation/) oldalt.

**Miért maradhat egyes szövegek változatlanul?**

A példa a teljes "Draft" szót pontos betűmérettel keres. A képként importált vagy különálló szövegkeretekre osztott szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumához.