---
title: PPTX konvertálása PPT-re JavaScript-ben
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja egyszerűen a PPTX-et PPT-re az Aspose.Slides segítségével — biztosítsa a zökkenőmentes kompatibilitást a PowerPoint formátumokkal, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan konvertálható a PowerPoint‑prezentáció PPTX formátumból PPT formátumba JavaScript segítségével. A következő téma kerül bemutatásra.

- PPTX konvertálása PPT‑re JavaScript‑ben

## **JavaScript PPTX konvertálása PPT‑re**

A PPTX‑ről PPT‑re történő konvertáláshoz tartozó JavaScript‑mintakódért lásd az alábbi részt, vagyis [Convert PPTX to PPT](#convert-pptx-to-ppt). A kód csak betölti a PPTX fájlt, és PPT formátumban menti. A mentési formátum megadásával a PPTX fájlt más formátumokba is elmentheted, például PDF, XPS, ODP, HTML stb., amint ez a **cikkek**ben szerepel.

- [Convert PPTX to PDF in JavaScript](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in JavaScript](/slides/hu/nodejs-java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in JavaScript](/slides/hu/nodejs-java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in JavaScript](/slides/hu/nodejs-java/save-presentation/)
- [Convert PPTX to PNG in JavaScript](/slides/hu/nodejs-java/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**

A PPTX‑t PPT‑re konvertáláshoz egyszerűen add át a fájl nevét és a mentési formátumot a [**Presentation**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály **Save** metódusának. Az alábbi JavaScript‑példa alapértelmezett opciókkal konvertál egy prezentációt PPTX‑ről PPT‑re.

```javascript
// példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
var presentation = new aspose.slides.Presentation("template.pptx");
// save the presentation as PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **GYIK**

**Minden PPTX‑effektus és funkció megmarad, amikor a régi PPT (97–2003) formátumba mentjük?**

Nem mindig. A PPT formátum nem támogatja az újabb képességeket (például bizonyos effektusokat, objektumokat és viselkedéseket), ezért a funkciók egyszerűsödhetnek vagy raszterizálódhatnak a konvertálás során.

**Lehet csak a kiválasztott diákat konvertálni PPT‑re a teljes prezentáció helyett?**

A közvetlen mentés az egész prezentációt célozza. Kiválasztott diák konvertálásához hozz létre egy új prezentációt csak az adott diákkal, és mentsd PPT‑ként; alternatív megoldásként használj olyan szolgáltatást/API‑t, amely per‑dia konvertálási paramétereket támogat.

**Támogatottak a jelszóval védett prezentációk?**

Igen. Fel tudod ismerni, ha egy fájl védett, megnyithatod jelszóval, és a [védelem/titkosítás beállításait](/slides/hu/nodejs-java/password-protected-presentation/) is konfigurálhatod a mentett PPT‑nél.