---
title: PPTX konvertálása PPT‑re C++‑ban
linktitle: PPTX PPT‑re
type: docs
weight: 21
url: /hu/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPTX konvertálása
- PPTX PPT‑re
- PPTX mentése PPT‑ként
- PPTX exportálása PPT‑be
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ segítségével könnyedén konvertálhatja a PPTX‑et PPT‑re – biztosítva a PowerPoint formátumok zökkenőmentes kompatibilitását, miközben megőrzi a prezentáció elrendezését és minőségét."
---
## **Áttekintés**

Ez a cikk leírja, hogyan lehet a PowerPoint‑prezentációt PPTX formátumból PPT formátumba konvertálni C++‑ban. A következő téma kerül tárgyalásra.

- PPTX konvertálása PPT‑re C++‑ban

## **PPTX konvertálása PPT‑re C++‑ban**

A PPTX‑ről PPT‑re történő konvertáláshoz a C++ példakódot lásd az alábbi szakaszban, azaz [PPTX konvertálása PPT‑re](#convert-pptx-to-ppt). Ez egyszerűen betölti a PPTX fájlt és PPT formátumban menti. Különböző mentési formátumok megadásával a PPTX fájlt számos más formátumba is mentheted, például PDF, XPS, ODP, HTML stb., amint ezekben a cikkekben tárgyaljuk. 

- [PPTX konvertálása PDF‑re C++‑ban](/slides/hu/cpp/convert-powerpoint-to-pdf/)
- [PPTX konvertálása XPS‑re C++‑ban](/slides/hu/cpp/convert-powerpoint-to-xps/)
- [PPTX konvertálása HTML‑re C++‑ban](/slides/hu/cpp/convert-powerpoint-to-html/)
- [PPTX konvertálása ODP‑re C++‑ban](/slides/hu/cpp/save-presentation/)
- [PPTX konvertálása PNG‑re C++‑ban](/slides/hu/cpp/convert-powerpoint-to-png/)

## **PPTX konvertálása PPT‑re**
A PPTX‑t PPT‑re konvertáláshoz egyszerűen add át a fájl nevét és a mentési formátumot a [**Presentation**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztály **Save** metódusának. Az alábbi C++ kódrészlet alapértelmezett beállításokkal konvertál egy prezentációt PPTX‑ről PPT‑re.

```cpp
// Betölti a PPTX-et.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Mentés PPT formátumban.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **GYIK**

**Megmaradnak-e a PPTX összes effektusa és funkciója, amikor a régi PPT (97–2003) formátumba mentjük?**

Nem mindig. A PPT formátum hiányzik néhány újabb képességből (például bizonyos effektusok, objektumok és viselkedések), így a funkciók egyszerűsödhetnek vagy raszterizálódhatnak a konvertálás során.

**Lehet csak a kiválasztott diákot PPT‑re konvertálni a teljes prezentáció helyett?**

A közvetlen mentés a teljes prezentációt célozza. Ha csak bizonyos diákra van szükség, hozz létre egy új prezentációt csak ezekkel a diák​val, majd mentsd PPT‑ként; alternatív megoldásként használj olyan szolgáltatást/API‑t, amely per‑diapontú konvertálási paramétereket támogat.

**Támogatottak-e a jelszóval védett prezentációk?**

Igen. Fel tudod ismerni, ha egy fájl védett, megnyithatod jelszóval, és a mentett PPT‑hez [védelmi/titkosítási beállításokat is konfigurálhatsz](/slides/hu/cpp/password-protected-presentation/).