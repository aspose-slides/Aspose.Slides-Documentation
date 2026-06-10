---
title: PowerPoint-prezentációk konvertálása XPS-be C++-ban
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, platformfüggetlen XPS-re C++-ban az Aspose.Slides használatával. Kapjon lépésről‑lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk XPS‑be konvertálását úgy, hogy egy PPT vagy PPTX fájlt XPS formátumban mentünk. Ez a cikk azt mutatja be, mikor lehet hasznos az XPS formátum, és hogyan hajtható végre a konvertálás az Aspose.Slides segítségével alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/) beállításokkal.

## **Az XPS-ről**
A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot fejlesztette ki a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez nagyon hasonló fájl kimenetével. Az XPS formátum XML‑en alapul. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón azonos marad.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Azt szeretné megtekinteni, hogy az Aspose.Slides hogyan konvertálja a PPT vagy PPTX prezentációkat XPS formátumba, látogassa meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, konvertálhatja a Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebben mentheti, oszthatja meg és nyomtathatja a dokumentumait.

A Microsoft továbbra is erős XPS‑támogatást biztosít a Windowsban (még a Windows 10‑ben is), ezért érdemes megfontolni a fájlok ebbe a formátumba történő mentését. Ha Windows 8.1‑et, Windows 8‑at, Windows 7‑et vagy Windows Vista‑t használ, az XPS valójában a legjobb lehetőség lehet bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb XPS‑támogatást nyújt, mint a PDF‑et. 
  - **XPS:** Beépített XPS‑megtekintő/olvasó és XPS‑nyomtatás elérhető. 
  - **PDF:** PDF‑olvasó érhető el, de nincs PDF‑nyomtatás. 

- **Windows 7** és **Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb XPS‑támogatást nyújtanak, mint a PDF‑t. 
  - **XPS:** Beépített XPS‑megtekintő és XPS‑nyomtatás elérhető. 
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑nyomtatás. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási funkciót a Windows 10‑ben. Korábban a felhasználók a dokumentumok nyomtatását az XPS formátumon keresztül végezték.

## **XPS konvertálás az Aspose.Slides‑el**

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/) C++‑hoz a [**Save**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust használhatja, amely a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályban érhető el, a teljes prezentáció XPS dokumentummá konvertálásához.

XPS‑re történő konvertáláskor a prezentációt a következő beállítások egyikével kell menteni:

- Alapértelmezett beállítások ([**XPSOptions**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xps_options) nélkül)
- Egyedi beállítások ([**XPSOptions**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xps_options) használatával)

### **Prezentációk XPS‑be konvertálása alapértelmezett beállításokkal**

Ez a C++‑kódrészlet megmutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá szabványos beállításokkal:

``` cpp
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// A prezentáció mentése XPS dokumentumba
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Prezentációk XPS‑be konvertálása egyedi beállításokkal**
Ez a kódrészlet megmutatja, hogyan konvertálhat egy prezentációt XPS dokumentummá egyedi beállításokkal C++‑ban:

``` cpp
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Hozzon létre egy TiffOptions osztályt
auto options = System::MakeObject<XpsOptions>();

// Metafájlok mentése PNG-ként
options->set_SaveMetafilesAsPng(true);

// A prezentáció mentése XPS dokumentumba
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **GYIK**

**Menthetek XPS‑t egy adatfolyamba a fájl helyett?**

Igen — az Aspose.Slides lehetővé teszi a közvetlen exportálást adatfolyamba, ami ideális web API‑k, szerver‑oldali folyamatok vagy bármely olyan scenárió számára, ahol a XPS‑t a fájlrendszer érintése nélkül szeretné elküldeni.

**A rejtett diák átmennek XPS‑be, és kizárhatom őket?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. [Elrejtheti vagy kizárhatja a rejtett diákot](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) a [export beállítások](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/xpsoptions/) segítségével mentés előtt, így a kimenet pontosan azokat az oldalakat tartalmazza, amelyeket szeretne.