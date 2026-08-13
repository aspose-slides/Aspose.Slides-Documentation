---
title: PowerPoint prezentációk konvertálása XPS-be C++-ban
linktitle: PowerPoint XPS-be
type: docs
weight: 70
url: /hu/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, platformfüggetlen XPS formátumba C++-ban az Aspose.Slides segítségével. Kapjon lépésről-lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat XPS‑be konvertálja egy PPT vagy PPTX fájl XPS formátumban történő mentésével. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre a konvertálás az Aspose.Slides‑sel alapértelmezett vagy egyéni [XpsOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/) beállítások használatával.

## **Az XPS‑ről**

A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/)‑t a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként fejlesztette ki. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez nagyon hasonló fájl kimenetével. Az XPS formátum XML‑en alapul. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón ugyanaz marad. 

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="info" %}} 

Az Aspose.Slides hogyan konvertálja a PPT vagy PPTX prezentációt XPS formátumba, megtekinthető a [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, átkonvertálhatja a Microsoft PowerPoint‑prezentációját XPS formátumba. Így könnyebbé válik a dokumentumok mentése, megosztása és nyomtatása. 

Microsoft továbbra is erőteljes támogatást biztosít az XPS‑hez Windowsban (még a Windows 10‑ben is), ezért érdemes lehet ebbe a formátumba menteni a fájlokat. Ha Windows 8.1, Windows 8, Windows 7 vagy Windows Vista rendszerekkel dolgozik, akkor az XPS valójában a legjobb lehetőség bizonyos műveletekhez. 

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS néző/olvasó és XPS‑re nyomtatás funkció elérhető. 
  - **PDF:** PDF‑olvasó elérhető, de nincs PDF‑re nyomtatás funkció. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF‑ekhez. 
  - **XPS:** Beépített XPS néző és XPS‑re nyomtatás funkció elérhető. 
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑re nyomtatás funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Windows 10‑ben elérhető Nyomtatás PDF‑be funkción keresztül. Korábban a felhasználók a dokumentumokat az XPS formátumon keresztül nyomtatták. 

## **XPS konvertálás az Aspose.Slides‑szel**

A C++‑os [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/)‑ban a [**Save**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust használhatja a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, hogy az egész prezentációt XPS dokumentummá konvertálja. 

Az XPS‑re történő konvertáláskor a prezentációt a következő beállítások egyikével kell menteni:

- Alapértelmezett beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xps_options) nélkül)
- Egyéni beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xps_options) használatával)

### **Prezentációk konvertálása XPS‑re alapértelmezett beállításokkal**

Ez a C++‑os példakód bemutatja, hogyan konvertálhat prezentációt XPS dokumentummá szabványos beállítások használatával:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Példányosít egy Presentation objektumot, amely egy prezentáció fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// A prezentáció mentése XPS dokumentumba
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Prezentációk konvertálása XPS‑re egyéni beállításokkal**

Ez a példakód bemutatja, hogyan konvertálhat prezentációt XPS dokumentummá egyéni beállításokkal C++‑ban:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Létrehozza az XpsOptions osztályt
auto options = System::MakeObject<XpsOptions>();

// Metafájlok mentése PNG formátumban
options->set_SaveMetafilesAsPng(true);

// A prezentáció mentése XPS dokumentumba
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **GYIK**

### Menthetek XPS‑t adatfolamba fájl helyett?

**Igen**—az Aspose.Slides lehetővé teszi a közvetlen exportot adatfolamba, ami ideális web‑API‑k, szerveroldali feldolgozási láncok vagy bármely olyan esetben, amikor az XPS‑t a fájlrendszer érintése nélkül szeretnénk elküldeni.

### A rejtett diák átkerülnek XPS‑be, és kizárhatom őket?

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák felvételét vagy kizárását](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) a [export beállítások](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/) segítségével állíthatja be mentés előtt XPS‑be, biztosítva, hogy a kimenet pontosan a kívánt oldalakat tartalmazza.