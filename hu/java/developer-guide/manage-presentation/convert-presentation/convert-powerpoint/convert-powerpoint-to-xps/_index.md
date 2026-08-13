---
title: PowerPoint Prezentációk konvertálása XPS-re Java-ban
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/java/convert-powerpoint-to-xps/
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
- PPT exportálása XPS-re
- PPTX exportálása XPS-re
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, platformfüggetlen XPS formátumba Java-ban az Aspose.Slides használatával. Szerezz részletes útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi PowerPoint‑prezentációk XPS‑formátumba történő konvertálását úgy, hogy egy PPT vagy PPTX fájlt XPS‑ként mentünk. Ez a cikk bemutatja, mikor lehet hasznos az XPS formátum, és megmutatja, hogyan végezhető el a konvertálás az Aspose.Slides segítségével alapértelmezett beállításokkal vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/) beállításokkal.

## **Az XPS‑ról**
A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot fejlesztette ki alternatívaként a [PDF](https://docs.fileformat.com/pdf/)-hez. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez nagyon hasonló fájl kimenetével. Az XPS formátum XML‑alapú. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón megegyezik.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="info" %}} 

Azt szeretné megtudni, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, tekintse meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, konvertálhatja Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebb lesz menteni, megosztani és nyomtatni a dokumentumait.

A Microsoft továbbra is erős XPS‑támogatást biztosít a Windowsban (még a Windows 10‑ben is), ezért érdemes lehet ezen a formátumon menteni a fájlokat. Ha Windows 8.1, Windows 8, Windows 7 vagy Windows Vista rendszert használ, az XPS akár a legjobb lehetőség is lehet bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS a eredeti XPS formátum szabványosított változata. A Windows 8 jobban támogatja az XPS fájlokat, mint a PDF fájlokat. 
  - **XPS:** Beépített XPS‑néző/olvasó és XPS‑nyomtatási funkció elérhető. 
  - **PDF:** PDF‑olvasó elérhető, de nincs PDF‑nyomtatási funkció. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használja. Ezek az operációs rendszerek szintén jobban támogatják az XPS fájlokat, mint a PDF‑eket. 
  - **XPS:** Beépített XPS‑néző és XPS‑nyomtatási funkció elérhető. 
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑nyomtatási funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási funkciót a Windows 10‑ben, így a dokumentumok nyomtatása már PDF‑ként is lehetséges. Korábban a felhasználók az XPS formátumon keresztül nyomtatták a dokumentumokat.

## **XPS átalakítás Aspose.Slides segítségével**

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/java/) for Java-ban a [**Save**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódust használhatja a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, hogy az egész prezentációt XPS dokumentummá konvertálja.

XPS‑re történő konvertáláskor a prezentációt az alábbi beállítások egyikével kell menteni:

- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions) nélkül)
- Egyedi beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions) használatával)

### **Prezentációk konvertálása XPS‑re alapértelmezett beállításokkal**

Ez a Java mintakód megmutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá standard beállításokkal:

```java
import com.aspose.slides.*;

// Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Prezentációk konvertálása XPS‑re egyedi beállításokkal**
Ez a mintakód azt mutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá egyedi beállításokkal Java‑ban:

```java
import com.aspose.slides.*;

// Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Az XpsOptions osztály példányosítása
    XpsOptions options = new XpsOptions();

    // Meta fájlok mentése PNG formátumban
    options.setSaveMetafilesAsPng(true);

    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gyakran Ismételt Kérdések**

### Menthetek XPS‑t stream‑be fájl helyett?

Igen – az Aspose.Slides lehetővé teszi a közvetlen exportálást stream‑be, ami ideális web‑API‑k, szerveroldali folyamatok vagy bármilyen olyan forgatókönyv esetén, ahol a XPS‑t a fájlrendszer érintése nélkül szeretné küldeni.

### A rejtett diák átkerülnek az XPS‑be, és kizárhatom őket?

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [export beállítások](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/) segítségével [belefoglalhatja vagy kizárhatja a rejtett diákat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-), mielőtt XPS‑be mentené, biztosítva, hogy a kimenet pontosan a kívánt oldalakat tartalmazza.