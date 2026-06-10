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
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS formátumba Java-ban az Aspose.Slides for Android használatával. Kapjon lépésről-lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat XPS‑re konvertálja a PPT vagy PPTX fájl XPS formátumban történő mentésével. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre a konvertálás az Aspose.Slides használatával alapértelmezett vagy egyéni [XpsOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/) beállításokkal.

## **Az XPS‑ról**
A Microsoft fejlesztette a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot, mint alternatívát a [PDF](https://docs.fileformat.com/pdf/) mellett. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez hasonló fájl előállításával. Az XPS formátum XML‑en alapul. Egy XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón ugyanaz marad.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Az Aspose.Slides által a PPT vagy PPTX prezentáció XPS formátumba történő konvertálás megtekintéséhez látogasson el a [ez az ingyenes online konverter alkalmazás](https://products.aspose.app/slides/hu/conversion) oldalra. 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, konvertálhatja a Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebb lesz a dokumentumok mentése, megosztása és nyomtatása.

A Microsoft továbbra is erős támogatást nyújt az XPS‑nek a Windowsban (még a Windows 10‑ben is), ezért érdemes lehet ebbe a formátumba menteni a fájlokat. Ha Windows 8.1, Windows 8, Windows 7 vagy Windows Vista felhasználója, az XPS valójában a legjobb választás bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS‑megtekintő/olvasó és XPS‑nyomtatás funkció elérhető. 
  - **PDF:** PDF‑olvasó elérhető, de PDF‑nyomtatás funkció nincs. 

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF‑ekhez. 
  - **XPS:** Beépített XPS‑megtekintő és XPS‑nyomtatás funkció elérhető. 
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑nyomtatás funkció. 

|<p>**Bemeneti PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



A Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Windows 10‑es Print to PDF funkción keresztül. Korábban a felhasználók a dokumentumokat az XPS formátumon keresztül nyomtatták.

## **XPS konverzió az Aspose.Slides‑el**

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/androidjava/) Java‑változatában a [**Save**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódust használhatja, amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály biztosít, hogy a teljes prezentációt XPS dokumentummá konvertálja.

A prezentáció XPS‑re konvertálásakor a következő beállítások egyikével kell menteni a prezentációt:

- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions) nélkül)
- Egyéni beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions) használatával)

### **Prezentációk konvertálása XPS‑re alapértelmezett beállításokkal**

Ez a Java‑mintakód bemutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá szabványos beállításokkal:

```java
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Prezentációk konvertálása XPS‑re egyéni beállításokkal**
Ez a mintakód bemutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá egyéni beállításokkal Java‑ban:

```java
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Példányosítja a TiffOptions osztályt
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

**Menthetek XPS‑t adatfolyamba a fájl helyett?**

Igen — az Aspose.Slides lehetővé teszi, hogy közvetlenül adatfolyamba exportáljon, ami ideális web‑API‑k, szerver‑oldali csővezetékek vagy bármely olyan forgatókönyv esetén, amikor az XPS‑t a fájlrendszer érintése nélkül kívánja küldeni.

**A rejtett diák átkerülnek az XPS‑be, és el lehet-e őket hagyni?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák felvételét vagy kihagyását](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) a [export beállításokon](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xpsoptions/) keresztül szabályozhatja mentés előtt, így a kimenet pontosan az Ön által kívánt oldalakat tartalmazza.