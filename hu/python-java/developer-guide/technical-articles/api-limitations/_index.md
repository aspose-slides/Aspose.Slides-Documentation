---
title: API korlátozások
type: docs
weight: 320
url: /hu/python-java/api-limitations/
keywords:
- API korlátozások
- exportálási formátum
- alkalmazás
- producer
- dokumentum tulajdonságok
- metaadat
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python via Java korlátozásait: rögzített Application, Creator és Producer metaadatok PPTX és PDF fájlokban."
---
## **Áttekintés**

Amikor prezentációkat hoznak létre vagy exportálnak az Aspose.Slides segítségével, bizonyos technikai metaadatok kerülnek kiírásra a kimeneti fájlba. Ez a cikk ismerteti a `Application`, `Creator` és `Producer` metaadatmezőkkel kapcsolatos korlátozásokat PPTX és PDF fájlok esetén.

## **Application és Producer**

Amikor prezentációkat hoz létre vagy exportál az Aspose.Slides for Python via Java segítségével, néhány technikai metaadat kerül a fájlba. Két mező gyakran felmerülő kérdéseket vet fel:

**Application** azonosítja azt a programot, amely létrehozta vagy utoljára mentette a **PPTX** prezentációt. Az Aspose.Slides for Python via Java esetében ez az érték rögzített, és a könyvtár szállítóját mutatja az alkalmazás neve helyett, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#setnameofapplication)‑t használja.

**Producer** azonosítja azt a renderelő motorot, amely az exportálás során generálta a végleges fájlt. **PDF** exportok esetén a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for Python via Java esetében mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

## **Mi korlátozott**

Ezeket a mezőket nem lehet felülírni az API-n keresztül a fent említett formátumoknál. **PPTX** esetén az Application tulajdonság értéke „Aspose.Slides for Java”. **PDF** esetén a Creator és Producer tulajdonságok értéke „Aspose.Slides for Java x.x.x.”. Ez a viselkedés tervezési szándék, és független attól, hogyan tölti be vagy menti a fájlt, valamint attól, milyen értékeket állít be a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **GYIK**

**Lecserélhetem a PPTX fájlban az Application értékét a saját alkalmazásom nevére?**

Nem. Az érték rögzített, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#setnameofapplication)‑t használja.

**Felülírhatom a Creator és Producer mezőket PDF exportokban?**

Nem. Mindkét mező rögzített, és a könyvtárat valamint annak verzióját tükrözi, függetlenül attól, hogyan töltődik be vagy mentődik a prezentáció.