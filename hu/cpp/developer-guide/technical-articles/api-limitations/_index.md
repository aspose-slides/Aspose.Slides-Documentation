---
title: API korlátok
type: docs
weight: 320
url: /hu/cpp/api-limitations/
keywords:
- API korlátozások
- exportálási formátum
- alkalmazás
- producer
- dokumentum tulajdonságok
- metaadatok
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for C++ korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF formátumokban – ezáltal segítve a integrációk tervezését meglepetések nélkül."
---
## **Áttekintés**

Amikor prezentációkat hoz létre vagy exportál az Aspose.Slides for C++ segítségével, bizonyos technikai metaadatok kerülnek a fájlba. Két mező gyakran vet fel kérdéseket:

**Application** azonosítja a programot, amely létrehozta vagy utoljára mentette a **PPTX** prezentációt. Az Aspose.Slides for C++ esetében ez az érték rögzített, és a könyvtár gyártóját mutatja, nem az Ön alkalmazásának nevét, még akkor is, ha a [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/hu/cpp/aspose.slides/documentproperties/set_nameofapplication/) használja.

**Producer** azonosítja a renderelő motorot, amely az exportálás során előállította a végső fájlt. **PDF** exportok esetében a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for C++ esetében mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozott**

Ezeket a mezőket nem lehet felülírni az API-n keresztül a fent említett formátumoknál. **PPTX** esetén az Application tulajdonság értéke „Aspose.Slides for C++”. **PDF** esetén a Creator és Producer tulajdonságok értéke „Aspose.Slides for C++ x.x.x”. Ez a viselkedés tervezési szándék, és független attól, hogyan tölti be vagy menti a fájlt, illetve attól, milyen értékeket ad meg a [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/hu/cpp/aspose.slides/documentproperties/set_nameofapplication/).