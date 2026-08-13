---
title: PowerPoint Prezentációk konvertálása XPS-re .NET-ben
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint XPS-re
- prezentáció XPS-re
- dia XPS-re
- PPT XPS-re
- PPTX XPS-re
- PPT mentése XPS-ként
- PPTX mentése XPS-ként
- PPT exportálása XPS-be
- PPTX exportálása XPS-be
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat nagy minőségű, platformfüggetlen XPS-re .NET-ben az Aspose.Slides használatával. Kapjon lépésről-lépésre útmutatót és példakódot C#-ban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint prezentációk XPS formátumba konvertálását úgy, hogy a PPT vagy PPTX fájlt XPS formátumban menti. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre a konverzió az Aspose.Slides segítségével alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/) beállításokkal.

## **Az XPS-ről**
A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként fejlesztette ki. Lehetővé teszi a tartalom nyomtatását egy, a PDF-hez nagyon hasonló fájl kimenettel. Az XPS formátum XML-alapú. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón változatlan marad.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="info" %}} 

Ha szeretnéd megnézni, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, tekintsd meg [ezt az ingyenes online konvertáló alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretnéd a tárolási költségeket, konvertálhatod a Microsoft PowerPoint prezentációdat XPS formátumba. Így könnyebb lesz menteni, megosztani és nyomtatni a dokumentumokat.

A Microsoft továbbra is erős XPS támogatást épít be a Windowsba (akár a Windows 10-ben is), ezért érdemes lehet ezt a formátumot választani. Ha Windows 8.1, Windows 8, Windows 7 vagy Windows Vista rendszerekkel dolgozol, az XPS valójában a legjobb opció lehet bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb XPS‑támogatást nyújt, mint a PDF‑t.
  - **XPS:** Beépített XPS megjelenítő/olvasó és XPS‑nyomtatás elérhető. 
  - **PDF:** PDF‑olvasó elérhető, de PDF‑nyomtatás nem lehetséges. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek is jobb XPS‑támogatást nyújtanak, mint a PDF‑eket.
  - **XPS:** Beépített XPS megjelenítő és XPS‑nyomtatás elérhető. 
  - **PDF:** PDF‑olvasó nincs. PDF‑nyomtatás nem lehetséges. 

|<p>**Bemeneti PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft idővel beépítette a PDF nyomtatási funkciót a Windows 10 Print to PDF funkciójával. Korábban a felhasználóknak XPS formátummal kellett nyomtatniuk a dokumentumokat.

## **XPS konverzió Aspose.Slides segítségével**

A .NET‑es [**Aspose.Slides**](https://products.aspose.com/slides/hu/net/) használatával a [**Save**](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save/index) metódust a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályban hívhatod meg, hogy az egész prezentációt XPS dokumentummá konvertáld.

XPS‑re konvertáláskor a prezentációt az alábbi beállítások egyikével kell menteni:

- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions) nélkül)
- Egyedi beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions) használatával)

### **Prezentációk konvertálása XPS-be alapértelmezett beállításokkal**

Ez a C#‑os minta kód megmutatja, hogyan konvertálj egy prezentációt XPS dokumentummá standard beállításokkal:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // A prezentáció mentése XPS dokumentumba
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Prezentációk konvertálása XPS-be egyedi beállításokkal**
Ez a minta kód megmutatja, hogyan konvertálj egy prezentációt XPS dokumentummá egyedi beállításokkal C#‑ban:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Példányosítja a TiffOptions osztályt
    XpsOptions options = new XpsOptions();

    // MetaFájlok mentése PNG formátumban
    options.SaveMetafilesAsPng = true;

    // A prezentáció mentése XPS dokumentumba
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **GYIK**

### Menthetek XPS-t egy adatfolamba egy fájl helyett?

Igen — az Aspose.Slides lehetővé teszi, hogy közvetlenül adatfolamba exportálj, ami ideális web‑API‑k, szerveroldali folyamatok vagy bármely olyan eset számára, amikor az XPS‑t a fájlrendszer érintése nélkül szeretnéd elküldeni.

### Átvitele a rejtett diáknak az XPS‑be, és kizárhatom‑e őket?

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák be‑ vagy kizárásához](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/showhiddenslides/) használj [export beállításokat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/) a mentés előtt, így a kimenet pontosan az általad kívánt oldalakat tartalmazza.