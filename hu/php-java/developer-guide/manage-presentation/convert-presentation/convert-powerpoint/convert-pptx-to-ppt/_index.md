---
title: PPTX konvertálása PPT-re PHP-ban
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPTX konvertálása
- PPTX PPT-re
- PPTX mentése PPT‑ként
- PPTX exportálása PPT‑be
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Könnyedén konvertálhatja a PPTX-et PPT‑re az Aspose.Slides segítségével — biztosítva a zökkenőmentes kompatibilitást a PowerPoint formátumokkal, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációt PPTX formátumból PPT formátumba konvertálni PHP‑val. Az alábbi téma kerül bemutatásra.

- PPTX konvertálása PPT‑re

## **PPTX konvertálása PPT‑re PHP‑ban**

A PPTX PPT‑re konvertálására vonatkozó Java mintakódot lásd az alábbi részben, azaz [Convert PPTX to PPT](#convert-pptx-to-ppt). A kód egyszerűen betölti a PPTX fájlt és PPT formátumban menti. Különböző mentési formátumok megadásával a PPTX fájlt más formátumokba is elmentheted, mint például PDF, XPS, ODP, HTML stb., ahogyan ezekben a cikkekben szerepel.

- [PPTX konvertálása PDF‑re PHP‑ban](/slides/hu/php-java/convert-powerpoint-to-pdf/)
- [PPTX konvertálása XPS‑re PHP‑ban](/slides/hu/php-java/convert-powerpoint-to-xps/)
- [PPTX konvertálása HTML‑re PHP‑ban](/slides/hu/php-java/convert-powerpoint-to-html/)
- [PPTX konvertálása ODP‑re PHP‑ban](/slides/hu/php-java/save-presentation/)
- [PPTX konvertálása PNG‑re PHP‑ban](/slides/hu/php-java/convert-powerpoint-to-png/)

## **PPTX konvertálása PPT‑re**
Ahhoz, hogy PPTX‑et PPT‑re konvertálj, egyszerűen add át a fájl nevét és a mentési formátumot a [**Presentation**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztály **Save** metódusának. Az alábbi PHP kódrészlet a Presentation‑t PPTX‑ről PPT‑re konvertálja az alapértelmezett beállításokkal.

```php
  # hozza létre a Presentation objektumot, amely egy PPTX fájlt képvisel
  $presentation = new Presentation("template.pptx");
  # menti a prezentációt PPT‑ként
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **GYIK**

**Megmaradnak-e minden PPTX hatás és funkció a régi PPT (97–2003) formátumba mentéskor?**

Nem mindig. A PPT formátum hiányzik néhány újabb képességből (például bizonyos hatások, objektumok és viselkedések), ezért a funkciók egyszerűsödhetnek vagy raszterizálódhatnak a konverzió során.

**Konvertálhatok csak kiválasztott diákat PPT‑re a teljes prezentáció helyett?**

A közvetlen mentés a teljes prezentációt célozza. A konkrét diák konvertálásához hozz létre egy új prezentációt csak azokkal a diákokkal, majd mentsd PPT‑ként; alternatívaként használj olyan szolgáltatást/API‑t, amely per‑diás konverziós paramétereket támogat.

**Támogatottak a jelszóval védett prezentációk?**

Igen. Fel tudod ismerni, hogy egy fájl védett‑e, megnyithatod jelszóval, valamint beállíthatod a [védelem/encryption beállításait](/slides/hu/php-java/password-protected-presentation/) a mentett PPT‑hez.