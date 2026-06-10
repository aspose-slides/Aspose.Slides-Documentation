---
title: API korlátozások
type: docs
weight: 320
url: /hu/java/api-limitations/
keywords:
- API korlátozások
- export formátum
- alkalmazás
- előállító
- dokumentum tulajdonságok
- metaadat
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje az Aspose.Slides for Java korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF formátumokban — segítve a integrációk megtervezését meglepetések nélkül."
---
## **Áttekintés**

Amikor a prezentációkat az Aspose.Slides segítségével hozza létre vagy exportálja, bizonyos technikai metaadatok kerülnek a kimeneti fájlba. Ez a cikk bemutatja a PPTX és PDF fájlok `Application`, `Creator` és `Producer` metaadatmezőire vonatkozó korlátozásokat.

## **Alkalmazás és Producer**

Amikor az Aspose.Slides for Java segítségével hoz létre vagy exportál prezentációkat, néhány technikai metaadat kerül a fájlba. Két mező gyakran felmerülő kérdéseket vet fel:

**Application** azonosítja azt a programot, amely létrehozta vagy utoljára mentette a **PPTX** prezentációt. Az Aspose.Slides for Java esetén ez az érték rögzített, és a könyvtár szállítóját jeleníti meg az alkalmazás neve helyett, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) metódust használja.

**Producer** azonosítja a renderelő motorot, amely az exportálás során generálta a végső fájlt. **PDF** exportoknál a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for Java esetén mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozott**

Nem írhatja felül ezeket a mezőket az API-n keresztül a fent említett formátumok esetén. **PPTX** esetén az Application tulajdonság értéke „Aspose.Slides for Java”. **PDF** esetén a Creator és Producer tulajdonságok értéke „Aspose.Slides for Java x.x.x.”. Ez a viselkedés szándékos, és független attól, hogyan tölti be vagy menti a fájlt, valamint attól, milyen értékeket ad meg a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).