---
title: Kimeneti metaadat-korlátozások
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
- generátor
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET rögzített alkalmazás, létrehozó és producer metaadatokat ír a mentett PPTX, PDF és ODP fájlokba, függetlenül attól, hogy milyen alkalmazásnevet állított be."
---
## **Áttekintés**

Amikor a prezentációkat az Aspose.Slides-szel hozod létre vagy exportálod, bizonyos technikai metaadatok kerülnek bele az eredményfájlba. Ez a cikk ismerteti a `Application`, `Creator`, `Producer` és a generator metaadatmezőkkel kapcsolatos korlátozásokat PPTX, PDF és ODP fájlok esetén.

## **Alkalmazás és Producer**

Amikor az Aspose.Slides for .NET segítségével hozol létre vagy exportálsz prezentációkat, néhány technikai metaadat kerül a fájlba. Két mező gyakran kérdéseket vet fel:

**Application** azonosítja azt a programot, amelyik létrehozta vagy utoljára mentette a **PPTX** prezentációt. Az Aspose.Slides for .NET esetében ez az érték rögzített, és a könyvtár nevét mutatja az alkalmazásod neve helyett, még akkor is, ha beállítod a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** azonosítja azt a renderelő motort, amely a végső fájlt az exportálás során létrehozta. **PDF** exportok esetén a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for .NET esetében mindkettő rögzített, és a könyvtárat és annak verzióját tükrözi.

**Mi van korlátozva**

Nem tudod felülírni ezeket a mezőket az API-n keresztül a fenti formátumoknál. **PPTX** esetén az Application tulajdonság „Aspose.Slides for .NET” értékkel kerül beírásra. **PDF** esetén a Creator és Producer tulajdonságok „Aspose.Slides for .NET” és a könyvtár verziója értékkel kerülnek beírásra. **ODP** esetén a generator mező „Aspose.Slides for .NET” és a könyvtár verziója értékkel kerül beírásra. Ez a viselkedés szándékos, és független attól, hogyan töltöd vagy mented a fájlt, valamint független a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) értékétől.

Ez a korlátozás **PPT** fájlokra nem vonatkozik: egy PPT fájlban a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/)‑ben beállított alkalmazásnevet menti el a rendszer.