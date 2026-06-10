---
title: PowerPoint prezentációk XPS-be konvertálása .NET-ben
linktitle: PowerPoint XPS-be
type: docs
weight: 70
url: /hu/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint XPS-be
- prezentáció XPS-be
- dia XPS-be
- PPT XPS-be
- PPTX XPS-be
- PPT mentése XPS-ként
- PPTX mentése XPS-ként
- PPT exportálása XPS-be
- PPTX exportálása XPS-be
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS-re .NET-ben az Aspose.Slides használatával. Kapjon lépésről-lépésre útmutatót és mintakódot C#-ban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi PowerPoint prezentációk XPS formátumba történő konvertálását úgy, hogy a PPT vagy PPTX fájlt XPS formátumban menti. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre a konverzió az Aspose.Slides‑el alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/) beállítások használatával.

## **Az XPS-ről**

Microsoft fejlesztette ki a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként. Lehetővé teszi a tartalom nyomtatását egy a PDF-hez nagyon hasonló fájl előállításával. Az XPS formátum XML alapú. Az XPS fájl elrendezése vagy felépítése minden operációs rendszeren és nyomtatón ugyanaz.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 
Ahhoz, hogy megtudja, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, megtekintheti [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, konvertálhatja a Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebb lesz menteni, megosztani és nyomtatni a dokumentumait. 

A Microsoft továbbra is erős támogatást biztosít az XPS-hez a Windowsban (akár a Windows 10-ben is), ezért érdemes megfontolni a fájlok ebbe a formátumba mentését. Ha a Windows 8.1, Windows 8, Windows 7 és Windows Vista rendszerekkel dolgozik, akkor az XPS valójában a legjobb választás lehet bizonyos műveletekhez. 

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum standardizált változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS néző/olvasó és XPS nyomtatási funkció elérhető. 
  - **PDF**: PDF olvasó elérhető, de PDF nyomtatási funkció nincs. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF-ekhez. 
  - **XPS**: Beépített XPS néző és XPS nyomtatási funkció elérhető. 
  - **PDF**: Nincs PDF olvasó. Nincs PDF nyomtatási funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Windows 10 Print to PDF funkciójával. Korábban a felhasználók a dokumentumok nyomtatását az XPS formátumon keresztül végezték. 

## **XPS konvertálás az Aspose.Slides‑el**

A .NET-hez elérhető [**Aspose.Slides**](https://products.aspose.com/slides/hu/net/) esetén a [**Save**](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save/index) metódust használhatja a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, hogy az egész prezentációt XPS dokumentummá konvertálja. 

A prezentáció XPS‑re konvertálásakor a prezentációt az alábbi beállítások egyikével kell menteni:
- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions) nélkül)
- Egyedi beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions) használatával)

### **Prezentációk konvertálása XPS‑re alapértelmezett beállítások használatával**

Ez a C# mintakód bemutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá szabványos beállítások használatával:

```c#
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // A prezentáció XPS dokumentumba mentése
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Prezentációk konvertálása XPS‑re egyedi beállítások használatával**

Ez a mintakód bemutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá egyedi beállításokkal C#‑ban:

```c#
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Hozzon létre egy TiffOptions osztályt
    XpsOptions options = new XpsOptions();

    // Mentse a MetaFiles-okat PNG-ként
    options.SaveMetafilesAsPng = true;

    // Mentse a prezentációt XPS dokumentumba
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **GYIK**

**Menthetek XPS‑t adatfolyamba fájl helyett?**

Igen – az Aspose.Slides lehetővé teszi közvetlen exportálást adatfolyamba, ami ideális web‑API‑khoz, szerver‑oldali csővezetékekhez vagy bármely olyan helyzethez, ahol a XPS‑t a fájlrendszer érintése nélkül szeretné elküldeni.

**A rejtett diák átkerülnek az XPS‑be, és kihagyhatom őket?**

Alapértelmezés szerint csak a rendszeres (látható) diák kerülnek renderelésre. A [rejtett diák be vagy kizárásával](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/showhiddenslides/) az [export beállításokon](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/) keresztül a mentés előtt XPS‑be, biztosíthatja, hogy a kimenet pontosan a kívánt oldalakat tartalmazza.