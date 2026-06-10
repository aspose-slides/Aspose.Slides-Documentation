---
title: PowerPoint prezentációk XPS-re konvertálása Java-ban
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
- PPT exportálása XPS-be
- PPTX exportálása XPS-be
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS-re Java nyelven az Aspose.Slides segítségével. Szerezzen lépésről‑lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk XPS‑formátumba történő átalakítását úgy, hogy egy PPT vagy PPTX fájlt XPS formátumban mentünk. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre az átalakítás az Aspose.Slides segítségével alapértelmezett beállítások vagy egyéni [XpsOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/) beállítások használatával.

## **Az XPS‑ről**

A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/)‑t fejlesztette ki alternatívaként a [PDF](https://docs.fileformat.com/pdf/). Lehetővé teszi a tartalom nyomtatását egy nagyon hasonló PDF‑hez fájl kimenettel. Az XPS formátum XML‑alapú. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszer és nyomtató esetén ugyanaz marad. 

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Ahhoz, hogy lásd, hogyan alakítja át az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, megnézheted [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretnéd a tárolási költségeket, konvertálhatod a Microsoft PowerPoint prezentációdat XPS formátumba. Így könnyebben mentheted, megoszthatod és nyomtathatod a dokumentumaidat. 

Microsoft továbbra is erőteljes XPS‑támogatást valósít meg a Windowsban (még a Windows 10‑ben is), ezért érdemes lehet erre a formátumra menteni a fájlokat. Ha Windows 8.1, Windows 8, Windows 7 és Windows Vista rendszerekkel dolgozol, akkor az XPS valójában a legjobb opció lehet bizonyos műveletekhez. 

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS megjelenítő/olvasó és az XPS‑be nyomtatás funkció elérhető. 
  - **PDF**: PDF‑olvasó elérhető, de nincs PDF‑be nyomtatás funkció. 

-  **Windows 7 és Windows Vista** az eredeti XPS formátumot használja. Ezek az operációs rendszerek is jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF‑ekhez. 
  - **XPS**: Beépített XPS megjelenítő és az XPS‑be nyomtatás funkció elérhető. 
  - **PDF**: Nincs PDF‑olvasó. Nincs PDF‑be nyomtatás funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Print to PDF funkción keresztül a Windows 10‑ben. Korábban a felhasználók a dokumentumokat az XPS formátumon keresztül nyomtatták. 

## **XPS átalakítás az Aspose.Slides segítségével**

A Java‑ra készült [**Aspose.Slides**](https://products.aspose.com/slides/hu/java/) esetében használhatod a [**Save**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódust, amelyet a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály biztosít, az egész prezentáció XPS dokumentummá konvertálásához. 

XPS‑re konvertáláskor a prezentációt a következő beállítások egyikével kell menteni:

- Alapértelmezett beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions) nélkül)
- Egyéni beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions) használatával)

### **Prezentációk konvertálása XPS‑re alapértelmezett beállításokkal**

Ez a Java mintakód bemutatja, hogyan konvertálj egy prezentációt XPS dokumentummá szabványos beállítások használatával:

```java
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // A prezentáció XPS dokumentumba mentése
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Prezentációk konvertálása XPS‑re egyéni beállításokkal**
Ez a mintakód bemutatja, hogyan konvertálj egy prezentációt XPS dokumentummá egyéni beállításokkal Java‑ban:

```java
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Hozzon létre egy TiffOptions osztályt
    XpsOptions options = new XpsOptions();

    // Metafájlok mentése PNG-ként
    options.setSaveMetafilesAsPng(true);

    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Menthetek XPS‑t streamba fájl helyett?**

Igen—az Aspose.Slides lehetővé teszi a közvetlen exportálást streamba, ami ideális web‑API‑k, szerver‑oldali csővezetékek vagy bármilyen olyan esetben, amikor a fájlrendszert érintés nélkül szeretnéd elküldeni az XPS‑t.

**A rejtett diák átkerülnek XPS‑be, és kizárhatom őket?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák felvételét vagy kizárását](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) a [exportálási beállítások](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xpsoptions/) segítségével a XPS‑be mentés előtt végezheted el, így a kimenet pontosan a kívánt oldalakat tartalmazza.