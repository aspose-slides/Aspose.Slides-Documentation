---
title: ODP konvertálása PPTX-re .NET-ben
linktitle: ODP → PPTX
type: docs
weight: 10
url: /hu/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertálja az ODP-t PPTX-re az Aspose.Slides for .NET segítségével. Tiszta C# kódrészletek, kötegelt tippek és magas minőségű eredmények — nincs szükség PowerPoint-ra."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet egy ODP prezentációt PPTX formátumba konvertálni az Aspose.Slides használatával.

## **ODP → PPTX konverzió**

Az Aspose.Slides for .NET a Presentation osztályt kínálja, amely egy prezentáció fájlt képvisel. [**Presentation**](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály most már a Presentation konstruktoron keresztül is hozzáférhet az ODP-hez, amikor az objektum példányosítva van. A következő példa bemutatja, hogyan lehet egy ODP prezentációt PPTX prezentációvá konvertálni.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Lépések: ODP konvertálása PPTX-re C#-ban</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Lépések: ODP konvertálása PowerPoint-ra C#-ban</strong></a>

```c#
// Az ODP fájl megnyitása
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Az ODP prezentáció mentése PPTX formátumba
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Élő példa**

Megtekintheti a [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hu/conversion/) webalkalmazást, amely az **Aspose.Slides API**-val készült. Az alkalmazás bemutatja, hogyan valósítható meg az ODP → PPTX konverzió az Aspose.Slides API segítségével.

## **FAQ**

**Szükséges-e Microsoft PowerPoint vagy LibreOffice telepítése az ODP PPTX-re konvertálásához?**

Nem. Az Aspose.Slides önállóan működik, és nem igényel harmadik féltől származó alkalmazásokat az ODP/PPTX olvasásához vagy írásához.

**Megmaradnak-e a mester diák, elrendezések és témák a konverzió során?**

Igen. A könyvtár egy teljes prezentációs objektummodellt használ, és megőrzi a struktúrát, beleértve a mester diákat és elrendezéseket, így a tervezés a konverzió után is helyes marad.

**Konvertálhatok jelszóval védett ODP fájlokat?**

Igen. Az Aspose.Slides képes felismerni a védelmet, megnyitni és dolgozni a [védett prezentációkkal](/slides/hu/net/password-protected-presentation/) (beleértve az ODP-t), ha megadja a jelszót, valamint konfigurálni a titkosítást és a dokumentumtulajdonságok elérését.

**Alkalmas-e az Aspose.Slides felhő vagy REST-alapú konverziós szolgáltatásokhoz?**

Igen. Használhatja a helyi könyvtárat a saját háttérrendszerében vagy az [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hu/family/) (REST API) szolgáltatást; mindkét lehetőség támogatja az ODP → PPTX konverziót.