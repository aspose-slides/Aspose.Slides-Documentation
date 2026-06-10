---
title: API korlátozások
type: docs
weight: 320
url: /hu/net/api-limitations/
keywords:
- API korlátozások
- export formátum
- alkalmazás
- előállító
- dokumentum tulajdonságok
- metaadatok
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje az Aspose.Slides for .NET korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF formátumokban - segítve a zökkenőmentes integráció tervezését előre."
---
## **Áttekintés**

Amikor prezentációkat hoznak létre vagy exportálnak az Aspose.Slides segítségével, bizonyos technikai metaadatok kerülnek a kimeneti fájlba. Ez a cikk ismerteti a `Application`, `Creator` és `Producer` metaadatmezőkre vonatkozó korlátozásokat a PPTX és PDF fájlokban.

## **Alkalmazás és Producer**

Amikor prezentációkat hozol létre vagy exportálsz az Aspose.Slides for .NET használatával, néhány technikai metaadat kerül a fájlba. Két mező gyakran felvet kérdéseket:

**Application** azonosítja azt a programot, amely létrehozta vagy legutóbb mentette a **PPTX** prezentációt. Az Aspose.Slides for .NET esetében ez az érték rögzített, és a könyvtár szállítóját mutatja, nem az alkalmazásod nevét, még akkor sem, ha beállítod a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/nameofapplication/)-t.

**Producer** azonosítja az exportálás során a végső fájlt előállító renderelő motorot. **PDF** exportoknál a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for .NET esetében mindkét mező rögzített, és a könyvtárat és annak verzióját tükrözi.

**Mi korlátozott**

Nem tudod felülírni ezeket a mezőket az API-n keresztül a fenti formátumoknál. **PPTX** esetén az Application tulajdonság értéke „Aspose.Slides for .NET”. **PDF** esetén a Creator és Producer tulajdonságok értéke „Aspose.Slides for .NET x.x.x”. Ez a viselkedés tervezett, és akkor is érvényes, ha a fájlt más módon töltöd be vagy mented, illetve függetlenül a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/nameofapplication/)-nek adott értéktől.