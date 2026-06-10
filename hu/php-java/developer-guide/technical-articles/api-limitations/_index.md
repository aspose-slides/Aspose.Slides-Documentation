---
title: API korlátok
type: docs
weight: 320
url: /hu/php-java/api-limitations/
keywords:
- API korlátok
- export formátum
- alkalmazás
- gyártó
- dokumentum tulajdonságok
- metaadatok
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF esetén – segítve a beintegrációk tervezését meglepetések nélkül."
---
## **Áttekintés**

Amikor prezentációkat hoznak létre vagy exportálnak az Aspose.Slides használatával, bizonyos technikai metaadatok kerülnek a kimeneti fájlba. Ez a cikk a PPTX és PDF fájlok `Application`, `Creator` és `Producer` metaadatmezőire vonatkozó korlátozásokat magyarázza.

## **Alkalmazás és Gyártó**

Amikor prezentációkat hoz létre vagy exportál az Aspose.Slides for PHP via Java segítségével, néhány technikai metaadat kerül a fájlba. Két mező gyakran felvet kérdéseket:

**Application** azonosítja azt a programot, amely létrehozta vagy utoljára mentette a **PPTX** prezentációt. Az Aspose.Slides for PHP via Java esetében ez az érték rögzített, és a könyvtár szállítóját mutatja az alkalmazás neve helyett, még akkor is, ha a [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/setnameofapplication/) metódust használja.

**Producer** azonosítja azt a renderelő motorot, amely az exportálás során generálta a végleges fájlt. **PDF** exportoknál a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for PHP via Java esetében mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

## **Mi korlátozott**

Nem lehet felülírni ezeket a mezőket az API-n keresztül a fent említett formátumoknál. **PPTX** esetén az Application tulajdonság a "Aspose.Slides for PHP via Java" értékkel kerül beírásra. **PDF** esetén a Creator és a Producer tulajdonságok a "Aspose.Slides for PHP via Java x.x.x." értékkel kerülnek beírásra. Ez a viselkedés a tervezés része, és független attól, hogyan töltöd be vagy mented a fájlt, valamint független a [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/setnameofapplication/) metódussal megadott értékektől.