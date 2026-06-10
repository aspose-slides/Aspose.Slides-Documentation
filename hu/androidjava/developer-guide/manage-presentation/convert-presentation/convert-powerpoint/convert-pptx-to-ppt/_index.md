---
title: PPTX konvertálása PPT-re Androidon
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/androidjava/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPTX konvertálása
- PPTX PPT-re
- PPTX mentése PPT-ként
- PPTX exportálása PPT-be
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android Java-val egyszerűen konvertálja a PPTX-t PPT-re - biztosítsa a PowerPoint formátumok zökkenőmentes kompatibilitását, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációt PPTX formátumból PPT formátumba konvertálni Java segítségével. A következő téma kerül bemutatásra.

- PPTX konvertálása PPT-re Java‑ban

## **PPTX konvertálása PPT-re Androidon**

A PPTX‑ről PPT‑re konvertáló Java példakódhoz tekintse meg az alábbi részt, azaz a [Convert PPTX to PPT](#convert-pptx-to-ppt) szakaszt. Ez egyszerűen betölti a PPTX fájlt, és PPT formátumban menti el. Különböző mentési formátumok megadásával a PPTX fájlt számos más formátumba is elmentheti, például PDF, XPS, ODP, HTML stb., amint ezekben a cikkekben tárgyaltuk.

- [PPTX konvertálása PDF-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-pdf/)
- [PPTX konvertálása XPS-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-xps/)
- [PPTX konvertálása HTML-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-html/)
- [PPTX konvertálása ODP-re Androidon](/slides/hu/androidjava/save-presentation/)
- [PPTX konvertálása PNG-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-png/)

## **PPTX konvertálása PPT-re**
A PPTX‑t PPT‑re konvertáláshoz egyszerűen adja át a fájl nevét és a mentési formátumot a [**Presentation**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály **Save** metódusának. Az alábbi Java kódrészlet a Presentation‑t PPTX‑ről PPT‑re konvertálja az alapértelmezett beállítások használatával.

```java
// példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation("template.pptx");

// elmenti a prezentációt PPT formátumban
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **GYIK**

**Megmaradnak-e minden PPTX hatás és funkció, amikor a régi PPT (97–2003) formátumba mentünk?**

Nem mindig. A PPT formátum hiányzik bizonyos újabb képességekből (például egyes hatások, objektumok és viselkedések), így a funkciók egyszerűsödhetnek vagy raszterizálódhatnak a konverzió során.

**Konvertálhatok csak kiválasztott diákat PPT‑re a teljes prezentáció helyett?**

A közvetlen mentés az egész prezentációra vonatkozik. Kiválasztott diák konvertálásához hozzon létre egy új prezentációt csak azokkal a diákal, majd mentse PPT‑ként; alternatívaként használhat olyan szolgáltatást/API‑t, amely per‑dia konverziós paramétereket támogat.

**Támogatottak a jelszóval védett prezentációk?**

Igen. Fel tudja ismerni, ha egy fájl védett, megnyithatja jelszóval, és a mentett PPT‑hez is beállíthatja a [védelmi/kódolási beállításokat](/slides/hu/androidjava/password-protected-presentation/).