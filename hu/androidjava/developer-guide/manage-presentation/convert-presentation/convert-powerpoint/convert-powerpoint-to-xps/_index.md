---
title: PowerPoint-prezentációk konvertálása XPS-re Androidon
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS formátumba Java-ban az Aspose.Slides for Android használatával. Szerezze meg a lépésről-lépésre útmutatót és a mintakódot."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy PowerPoint‑prezentációkat XPS‑formátumba konvertáljon egy PPT vagy PPTX fájl XPS‑ként való mentésével. Ez a cikk bemutatja, mikor lehet hasznos az XPS‑formátum, és megmutatja, hogyan hajtható végre a konverzió az Aspose.Slides‑kel alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/) beállítások használatával.

## **Az XPS-ről**

A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként fejlesztette ki. Lehetővé teszi a tartalom nyomtatását egy a PDF‑hez hasonló fájl kimenetével. Az XPS formátum XML‑alapú. Egy XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón ugyanaz marad.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="info" %}} 
Azt szeretnéd látni, hogy az Aspose.Slides hogyan konvertál PPT vagy PPTX prezentációt XPS formátumba? Tekintsd meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}} 

Ha csökkenteni szeretnéd a tárolási költségeket, konvertálhatod a Microsoft PowerPoint prezentációdat XPS formátumba. Így egyszerűbbé válik a dokumentumok mentése, megosztása és nyomtatása.

A Microsoft folyamatosan erős támogatást épít be az XPS‑hez a Windowsban (még a Windows 10‑ben is), ezért érdemes megfontolni a fájlok ebben a formátumban való mentését. Ha Windows 8.1, Windows 8, Windows 7 vagy Windows Vista rendszerrel dolgozol, az XPS valójában a legjobb választás lehet bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS‑megjelenítő/olvasó és XPS‑nyomtatási funkció elérhető. 
  - **PDF:** PDF‑olvasó elérhető, de PDF‑nyomtatási funkció nincs. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF‑ekhez. 
  - **XPS:** Beépített XPS‑megjelenítő és XPS‑nyomtatási funkció elérhető. 
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑nyomtatási funkció. 

|<p>**Bemeneti PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Windows 10‑es „Print to PDF” funkcióval. Korábban a felhasználók az XPS formátumon keresztül nyomtatták a dokumentumokat.

## **XPS konverzió az Aspose.Slides használatával**

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/androidjava/) Java változatában a [**Save**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódust használhatod, amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály biztosít, a teljes prezentáció XPS dokumentummá konvertálásához.

XPS‑re konvertáláskor a prezentációt az alábbi beállítások egyikével kell menteni:

- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions) nélkül)  
- Egyedi beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions) használatával)

### **Prezentációk konvertálása XPS-re alapértelmezett beállításokkal**

Ez a Java példa megmutatja, hogyan konvertálj egy prezentációt XPS dokumentummá szabványos beállításokkal:

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Prezentációk konvertálása XPS-re egyéni beállításokkal**

Ez a példa bemutatja, hogyan konvertálj egy prezentációt XPS dokumentummá egyéni beállításokkal Java nyelven:

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Hozzon létre egy XpsOptions osztályt
    XpsOptions options = new XpsOptions();

    // MetaFájlok mentése PNG-ként
    options.setSaveMetafilesAsPng(true);

    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Menthetek XPS‑t adatfolyamba a fájl helyett?

Igen — az Aspose.Slides lehetővé teszi, hogy közvetlenül adatfolyamba exportálj, ami ideális web‑API‑k, szerver‑oldali folyamatok vagy bármely olyan eset számára, amikor a XPS‑t a fájlrendszer érintése nélkül szeretnéd továbbküldeni.

### Átvitelre kerülnek a rejtett diák az XPS‑be, és kizárhatom‑e őket?

Alapértelmezés szerint csak a szabályos (látható) diák kerülnek renderelésre. A [export beállítások](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/) segítségével [belefoglalhatod vagy kizárhatod a rejtett diákat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-), így biztosíthatod, hogy a kimenet pontosan az általad kívánt oldalakat tartalmazza.