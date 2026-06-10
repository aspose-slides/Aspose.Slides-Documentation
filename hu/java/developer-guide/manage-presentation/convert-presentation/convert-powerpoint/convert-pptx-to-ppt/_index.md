---
title: PPTX konvertálása PPT-re Java-ban
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPTX konvertálása
- PPTX PPT-re
- PPTX mentése PPT-ként
- PPTX exportálása PPT-re
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén konvertálja a PPTX-et PPT-re az Aspose.Slides for Java segítségével — biztosítsa a zökkenőmentes kompatibilitást a PowerPoint formátumokkal, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ebben a cikkben bemutatjuk, hogyan lehet a PowerPoint‑prezentációt PPTX formátumból PPT formátumba konvertálni Java‑val. A következő téma kerül tárgyalásra.

- PPTX konvertálása PPT-re Java-ban

## **PPTX konvertálása PPT-re Java‑ban**

A Java mintakódhoz, amely PPTX‑et PPT‑re konvertál, lásd az alábbi részt, azaz [PPTX konvertálása PPT-re](#convert-pptx-to-ppt). Ez egyszerűen betölti a PPTX fájlt és PPT formátumban menti. Különböző mentési formátumok megadásával a PPTX fájlt más formátumokba is mentheted, például PDF, XPS, ODP, HTML stb., ahogy ezekben a cikkekben tárgyaljuk.

- [PPTX konvertálása PDF‑re Java‑ban](/slides/hu/java/convert-powerpoint-to-pdf/)
- [PPTX konvertálása XPS‑re Java‑ban](/slides/hu/java/convert-powerpoint-to-xps/)
- [PPTX konvertálása HTML‑re Java‑ban](/slides/hu/java/convert-powerpoint-to-html/)
- [PPTX konvertálása ODP‑re Java‑ban](/slides/hu/java/save-presentation/)
- [PPTX konvertálása PNG‑re Java‑ban](/slides/hu/java/convert-powerpoint-to-png/)

## **PPTX konvertálása PPT-re**
Ahhoz, hogy egy PPTX‑et PPT‑re konvertálj, egyszerűen add meg a fájl nevét és a mentési formátumot a **Save** metódusnak a [**Presentation**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályban. Az alábbi Java kódminta egy prezentációt konvertál PPTX‑ről PPT‑re az alapértelmezett beállításokkal.

```java
// hozza létre egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation("template.pptx");

// mentse a prezentációt PPT-ként
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **GYIK**

**Minden PPTX‑effekt és funkció megmarad‑e, amikor a régi PPT (97–2003) formátumba mentünk?**

Nem mindig. A PPT formátum hiányzik néhány újabb képességből (például bizonyos effektusok, objektumok és viselkedések), ezért a funkciók konverzió során egyszerűsödhetnek vagy raszteresítve lehetnek.

**Konvertálhatok csak a kiválasztott diákra PPT‑t a teljes prezentáció helyett?**

A közvetlen mentés a teljes prezentációt célozza. Kiválasztott diák konvertálásához hozd létre egy új prezentációt csak az adott diákkal, majd mentsd PPT‑kén; alternatívaként használj olyan szolgáltatást/API‑t, amely per‑dia konverziós paramétereket támogat.

**Támogatottak a jelszóval védett prezentációk?**

Igen. Fel tudod ismerni, hogy egy fájl jelszóval védett‑e, megnyithatod jelszó megadásával, és a mentett PPT‑hez is beállíthatod a [védelem/kódolás beállításait](/slides/hu/java/password-protected-presentation/).