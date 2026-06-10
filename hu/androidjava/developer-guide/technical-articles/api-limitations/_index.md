---
title: API korlátozások
type: docs
weight: 320
url: /hu/androidjava/api-limitations/
keywords:
- API korlátozások
- export formátum
- alkalmazás
- gyártó
- dokumentumtulajdonságok
- metaadatok
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Android korlátait: az exportálások rögzített Application/Producer metaadatokat állítanak be PPT, PPTX, ODP és PDF fájlokban—segítve a beintegrálás tervezését meglepetések nélkül."
---
## **Áttekintés**

When presentations are created or exported with Aspose.Slides, certain technical metadata is written to the output file. This article explains the limitations related to the `Application`, `Creator`, and `Producer` metadata fields in PPTX and PDF files.

## **Alkalmazás és Gyártó**

When you create or export presentations with Aspose.Slides for Android via Java, some technical metadata is written into the file. Two fields often raise questions:

**Application** azonosítja azt a programot, amely létrehozta vagy legutóbb mentette a **PPTX** prezentációt. Az Aspose.Slides for Android via Java esetében ez az érték rögzített, és a könyvtár szállítóját mutatja az alkalmazás neve helyett, még akkor is, ha a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) használatával állítja be.

**Producer** azonosítja azt a renderelő motorot, amely az export során előállította a végleges fájlt. A **PDF** exportoknál a metaadatok a **Creator** és **Producer** mezőket használják. Az Aspose.Slides for Android via Java esetében mindkettő rögzített, és a könyvtárat valamint annak verzióját tükrözi.

**Mi korlátozott**

Nem tudja felülírni ezeket a mezőket az API-n keresztül a fenti formátumok esetén. A **PPTX** esetén az Application tulajdonság értéke "Aspose.Slides for Android via Java". A **PDF** esetén a Creator és Producer tulajdonságok értéke "Aspose.Slides for Android via Java x.x.x." Ez a viselkedés terv szerint működik, és független attól, hogyan tölti be vagy menti a fájlt, valamint attól is, hogy milyen értékeket rendelt a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) segítségével.