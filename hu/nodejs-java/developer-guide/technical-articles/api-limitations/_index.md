---
title: API korlátozások
type: docs
weight: 320
url: /hu/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje az Aspose.Slides for Node.js korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF formátumokban – segítve a integrációk tervezését meglepetések nélkül."
---
## **Áttekintés**

Amikor prezentációkat hozunk létre vagy exportálunk az Aspose.Slides segítségével, bizonyos technikai metaadatok kerülnek a kimeneti fájlba. Ez a cikk a PPTX és PDF fájlokban található `Application`, `Creator` és `Producer` metaadatmezőkre vonatkozó korlátozásokat magyarázza.

## **Alkalmazás és előállító**

Amikor az Aspose.Slides for Node.js via Java használatával készít vagy exportál prezentációkat, technikai metaadatok íródnak a fájlba. Két mező gyakran felvet kérdéseket:

**Application** azonosítja azt a programot, amely a **PPTX** prezentációt létrehozta vagy utoljára mentette. Az Aspose.Slides for Node.js via Java esetében ez az érték rögzített, és a könyvtár szállítóját mutatja az alkalmazás neve helyett, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) metódust használja.

**Producer** azonosítja azt a renderelő motort, amely az exportálás során létrehozta a végleges fájlt. **PDF** exportok esetén a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for Node.js via Java esetében mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozva van**

Ezeket a mezőket nem lehet felülírni az API-n keresztül a fent említett formátumoknál. **PPTX** esetén az Application tulajdonság „Aspose.Slides for Node.js via Java” értékkel kerül beírásra. **PDF** esetén a Creator és Producer tulajdonságok „Aspose.Slides for Node.js via Java x.x.x.” értékkel íródnak. Ez a viselkedés a tervezés része, és független attól, hogy hogyan tölti be vagy menti a fájlt, illetve attól is, hogy milyen értékeket ad meg a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).