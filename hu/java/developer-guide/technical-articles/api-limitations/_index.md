---
title: Kimeneti metaadat-korlátozások
type: docs
weight: 320
url: /hu/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java rögzített alkalmazás-, létrehozó- és producer-metaadatokat ír a mentett PPTX, PDF és ODP fájlokba, függetlenül attól, milyen alkalmazásnevet állít be."
---
## **Áttekintés**

Amikor a prezentációkat az Aspose.Slides-szel hozza létre vagy exportálja, bizonyos műszaki metaadatok kerülnek a kimeneti fájlba. Ez a cikk bemutatja a `Application`, `Creator`, `Producer` és a generator metaadatmezőkre vonatkozó korlátozásokat PPTX, PDF és ODP fájlok esetén.

## **Application és Producer**

Az Aspose.Slides for Java-val történő prezentációk létrehozásakor vagy exportálásakor bizonyos műszaki metaadatok kerülnek a fájlba. Két mező gyakran felvet kérdéseket:

**Application** azonosítja azt a programot, amely létrehozta vagy legutóbb mentette a **PPTX** prezentációt. Az Aspose.Slides for Java esetén ez az érték rögzített, és a könyvtár nevét mutatja a saját alkalmazás neve helyett, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) metódust használja.

**Producer** azonosítja azt a renderelő motorvet, amely az exportálás során létrehozta a végleges fájlt. **PDF** exportáláskor a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for Java esetén mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozott**

Ezeket a mezőket nem lehet felülírni az API-n keresztül a fenti formátumok esetén. **PPTX** esetén az Application tulajdonság értéke az „Aspose.Slides for Java”. **PDF** esetén a Creator és Producer tulajdonságok értéke az „Aspose.Slides for Java”, amelyet a könyvtár verziója követ. **ODP** esetén a generator mező értéke az „Aspose.Slides for Java”, amelyet a könyvtár verziója követ. Ez a viselkedés tervezett, és független attól, hogyan tölti be vagy menti a fájlt, valamint független a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) által beállított értékektől.

Ez a korlátozás nem vonatkozik **PPT** fájlokra: PPT fájl esetén a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) által beállított alkalmazás neve mentésre kerül.