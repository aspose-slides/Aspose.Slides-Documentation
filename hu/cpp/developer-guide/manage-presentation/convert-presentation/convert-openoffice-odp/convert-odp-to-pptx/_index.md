---
title: ODP PPTX-re konvertálása C++-ban
linktitle: ODP PPTX-re
type: docs
weight: 10
url: /hu/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- ODP konvertálása
- OpenDocument PPTX-re
- ODP PPTX-re
- ODP mentése PPTX-ként
- ODP exportálása PPTX-be
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "ODP PPTX-re konvertálása az Aspose.Slides for C++ segítségével. Tiszta kód példák, kötegelt tippek és magas minőségű eredmények - nincs szükség PowerPointra."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet ODP bemutatót PPTX formátumba konvertálni az Aspose.Slides használatával.

## **ODP → PPTX átalakítás**

Az Aspose.Slides for .NET egy Presentation osztályt biztosít, amely egy prezentációs fájlt képvisel. [**Presentation**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály most már az ODP fájlokhoz is hozzáférhet a Presentation konstruktoron keresztül az objektum példányosításakor. Az alábbi példa bemutatja, hogyan lehet ODP prezentációt PPTX prezentációvá konvertálni.

``` cpp
// A dokumentumok könyvtárának elérési útja.
String dataDir = GetDataPath();

// ODP fájl megnyitása
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODP prezentáció PPTX formátumba mentése
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Élő példa**

Látogathat el a [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hu/conversion/) webalkalmazásra, amely az **Aspose.Slides API** használatával készült. Az alkalmazás bemutatja, hogyan lehet az ODP → PPTX átalakítást megvalósítani az Aspose.Slides API-val.

## **GYIK**

**Szükséges-e a Microsoft PowerPoint vagy a LibreOffice telepítése az ODP PPTX formátumba konvertálásához?**

Nem. Az Aspose.Slides önállóan működik, és nem igényel harmadik fél alkalmazásokat az ODP/PPTX olvasásához vagy írásához.

**Megmaradnak-e a mesterdiák, elrendezések és témák a konverzió során?**

Igen. A könyvtár egy teljes prezentációs objektummodellt használ, és megőrzi a struktúrát, beleértve a mesterdiákat és elrendezéseket, így a dizájn a konverzió után is helyes marad.

**Konvertálhatok jelszóval védett ODP fájlokat?**

Igen. Az Aspose.Slides képes felismerni a védelmet, megnyitni és dolgozni a [protected presentations](/slides/hu/cpp/password-protected-presentation/) (beleértve az ODP-t) esetén, ha megadja a jelszót, valamint konfigurálni a titkosítást és a dokumentumtulajdonságokhoz való hozzáférést.

**Alkalmas-e az Aspose.Slides felhő- vagy REST-alapú konverziós szolgáltatásokra?**

Igen. Használhatja a helyi könyvtárat saját háttérrendszerében vagy az [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hu/family/) (REST API)-t; mindkét lehetőség támogatja az ODP → PPTX konverziót.