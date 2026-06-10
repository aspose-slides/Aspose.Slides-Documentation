---
title: PPTX konvertálása PPT-re .NET-ben
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Könnyedén konvertálja a PPTX‑t PPT‑re az Aspose.Slides for .NET segítségével—biztosítsa a zökkenőmentes kompatibilitást a PowerPoint formátumokkal, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhat PowerPoint‑prezentációt PPTX formátumból PPT formátumba C# használatával. A következő téma tárgyalt.

- PPTX konvertálása PPT-re C#-ban

## **PPTX konvertálása PPT-re .NET-ben**

A C# példakódhoz a PPTX PPT-re konvertálásához lásd az alábbi szekciót, vagyis [Convert PPTX to PPT](#convert-pptx-to-ppt). Ez egyszerűen betölti a PPTX fájlt és PPT formátumban menti. Különböző mentési formátumok megadásával a PPTX fájlt más formátumokba is mentheted, például PDF, XPS, ODP, HTML stb., amint az ezekben a cikkekben tárgyalt.

- [PPTX konvertálása PDF-re .NET-ben](/slides/hu/net/convert-powerpoint-to-pdf/)
- [PPTX konvertálása XPS-re .NET-ben](/slides/hu/net/convert-powerpoint-to-xps/)
- [PPTX konvertálása HTML-re .NET-ben](/slides/hu/net/convert-powerpoint-to-html/)
- [PPTX konvertálása ODP-re .NET-ben](/slides/hu/net/save-presentation/)
- [PPTX konvertálása PNG-re .NET-ben](/slides/hu/net/convert-powerpoint-to-png/)

## **PPTX konvertálása PPT-re**
A PPTX PPT-re konvertálásához egyszerűen add meg a fájl nevét és a mentési formátumot a [**Save**](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódusnak a [**Presentation**](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban. Az alábbi C# kódpélda a Presentation‑t PPTX‑ről PPT‑re konvertálja az alapértelmezett beállításokkal.

```c#
// PPTX fájlt képviselő Presentation objektum példányosítása
Presentation pres = new Presentation("presentation.pptx");

// A PPTX prezentáció mentése PPT formátumba
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **GYIK**

**Minden PPTX effektus és funkció megmarad‑e, amikor a régi PPT (97–2003) formátumba mentünk?**

Nem mindig. A PPT formátum hiányolja a legújabb képességeket (például bizonyos effektusokat, objektumokat és viselkedéseket), ezért a funkciók a konverzió során egyszerűsödhetnek vagy raszterizálódhatnak.

**Konvertálhatok csak kiválasztott dia(k)‑t PPT‑re a teljes prezentáció helyett?**

A közvetlen mentés a teljes prezentációt célozza. A konkrét diák konvertálásához hozz létre egy új prezentációt csak az adott diákkal, majd mentsd PPT‑ként; alternatívaként használj olyan szolgáltatást/API‑t, amely támogatja a diánkénti konverziós paramétereket.

**Támogatottak a jelszóval védett prezentációk?**

Igen. Fel tudod ismerni, ha egy fájl védett, megnyithatod jelszóval, és a mentett PPT‑hez is [beállíthatod a védelem/kódolás beállításait](/slides/hu/net/password-protected-presentation/).