---
title: PowerPoint-prezentációk konvertálása XPS-re Pythonban
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint XPS-re
- prezentáció XPS-re
- PPT XPS-re
- PPTX XPS-re
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS-re Pythonban az Aspose.Slides segítségével. Kapjon lépésről lépésre útmutatót és példakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat XPS‑be konvertálja egy PPT vagy PPTX fájl XPS formátumban történő mentésével. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan végezhető el a konverzió az Aspose.Slides használatával alapértelmezett beállításokkal vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/xpsoptions/) beállításokkal.

## **Az XPS‑ról**
A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot fejlesztette ki alternatívaként a [PDF](https://docs.fileformat.com/pdf/) helyett. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez nagyon hasonló fájl kimenetével. Az XPS formátum XML‑alapú. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón ugyanaz marad. 

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Ha szeretné látni, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, tekintse meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, konvertálhatja a Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebb lesz menteni, megosztani és nyomtatni a dokumentumokat. 

A Microsoft továbbra is erős XPS‑támogatást valósít meg a Windowsban (még a Windows 10‑ben is), ezért érdemes lehet ebbe a formátumba menteni a fájlokat. Ha Windows 8.1, Windows 8, Windows 7 és Windows Vista‑val dolgozik, akkor az XPS valójában a legjobb lehetőség bizonyos műveletekhez. 

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított verziója. A Windows 8 jobban támogatja az XPS fájlokat, mint a PDF fájlokat. 
  - **XPS:** Beépített XPS megjelenítő/olvasó és XPS‑re nyomtatás funkció elérhető. 
  - **PDF**: PDF olvasó elérhető, de nincs PDF‑re nyomtatás funkció. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobban támogatják az XPS fájlokat, mint a PDF‑eket. 
  - **XPS**: Beépített XPS megjelenítő és XPS‑re nyomtatás funkció elérhető. 
  - **PDF**: Nincs PDF olvasó. Nincs PDF‑re nyomtatás funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül a PDF nyomtatási műveletekhez is bevezette a Print to PDF funkciót a Windows 10‑ben. Korábban a felhasználók a dokumentumok nyomtatását az XPS formátumon keresztül kellett végezniük. 

## **XPS konvertálás az Aspose.Slides‑szel**

.NET‑hez készült [**Aspose.Slides**](https://products.aspose.com/slides/hu/python-net/) esetén a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály által biztosított [**Save**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) metódussal konvertálhatja az egész prezentációt XPS dokumentummá. 

Az XPS‑re történő konverzió során a prezentációt az alábbi beállítások egyikével kell menteni:
- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/xpsoptions/) nélkül)
- Egyéni beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/xpsoptions/) használatával)

### **Prezentációk XPS‑re konvertálása alapértelmezett beállításokkal**

Ez a Python példa bemutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá alapértelmezett beállításokkal:

```py
import aspose.slides as slides

# Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
pres = slides.Presentation("Convert_XPS.pptx")

# A prezentáció mentése XPS dokumentumba
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Prezentációk XPS‑re konvertálása egyéni beállításokkal**

Ez a példa bemutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá egyéni beállításokkal Pythonban:

```py
import aspose.slides as slides

# Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Példányosítja a TiffOptions osztályt
options = slides.export.XpsOptions()

# Metafájlok mentése PNG-ként
options.save_metafiles_as_png = True

# A prezentáció mentése XPS dokumentumba
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **GYIK**

**Menthetünk XPS‑t adatfolyamra a fájl helyett?**

Igen — az Aspose.Slides lehetővé teszi az XPS közvetlen adatfolyamba exportálását, ami ideális webes API‑k, szerveroldali folyamatok vagy bármely olyan eset számára, ahol a fájlrendszert megkerülve szeretné elküldeni az XPS‑t. 

**Átkerülnek a rejtett diák az XPS‑be, és kizárhatók?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák felvételét vagy kizárását](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) az [export beállítások](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/xpsoptions/) használatával a XPS‑be mentés előtt szabályozhatja, így a kimenet pontosan az általad kívánt oldalakat tartalmazza.