---
title: API korlátozások
type: docs
weight: 210
url: /hu/python-net/api-limitations/
keywords:
- API korlátozások
- export formátum
- alkalmazás
- előállító
- dokumentumtulajdonságok
- metaadatok
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be a PPT, PPTX, ODP és PDF fájlokban - ez segít a integrációk tervezésében meglepetések nélkül."
---
## **Áttekintés**

Amikor prezentációkat hoznak létre vagy exportálnak az Aspose.Slides használatával, bizonyos technikai metaadatok kerülnek beírásra a kimeneti fájlba. Ez a cikk ismerteti a `Application`, `Creator` és `Producer` metaadatmezőkre vonatkozó korlátozásokat a PPTX és PDF fájlokban.

## **Alkalmazás és Producer**

Amikor prezentációkat hoz létre vagy exportál az Aspose.Slides for Python via .NET használatával, bizonyos technikai metaadatok kerülnek beírásra a fájlba. Két mező gyakran felmerülő kérdéseket vet fel:

**Application** azonosítja azt a programot, amely létrehozta vagy legutóbb mentette a **PPTX** prezentációt. Az Aspose.Slides for Python via .NET esetén ez az érték rögzített, és a könyvtár gyártóját mutatja a saját alkalmazás neve helyett, még akkor is, ha beállítja a [DocumentProperties.name_of_application](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** azonosítja a renderelő motorját, amely a végleges fájlt generálta exportálás során. **PDF** exportoknál a metaadat a **Creator** és **Producer** mezőket használja. Az Aspose.Slides for Python via .NET esetén mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozva van**

Ezeket a mezőket nem lehet felülírni az API-n keresztül a fenti formátumok esetén. **PPTX** esetén az Application tulajdonság értéke "Aspose.Slides for Python via .NET". **PDF** esetén a Creator és Producer tulajdonságok értéke "Aspose.Slides for Python via .NET x.x.x". Ez a viselkedés szándékos, és függetlenül attól, hogy hogyan tölti be vagy menti a fájlt, illetve függetlenül a [DocumentProperties.name_of_application](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/name_of_application/) értékétől.