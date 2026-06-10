---
title: PowerPoint prezentációk konvertálása XPS formátumba JavaScriptben
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/nodejs-java/convert-powerpoint-to-xps/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, platformfüggetlen XPS-be JavaScriptben az Aspose.Slides for Node.js használatával. Kapjon lépésről lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi PowerPoint‑prezentációk XPS‑formátumba való konvertálását egy PPT vagy PPTX fájl XPS‑formátumban történő mentésével. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS‑formátum, és bemutatja, hogyan végezhető a konverzió az Aspose.Slides‑szel alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xpsoptions/) beállításokkal.

## **Az XPS‑ról**

A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/)‑t fejlesztette ki alternatívaként a [PDF](https://docs.fileformat.com/pdf/)‑hez. Lehetővé teszi a tartalom nyomtatását egy PDF‑hez nagyon hasonló fájl kiadásával. Az XPS formátum XML‑alapú. Az XPS fájl elrendezése vagy szerkezete minden operációs rendszeren és nyomtatón ugyanaz marad. 

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Ahhoz, hogy megtudja, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX prezentációt XPS formátumba, tekintse meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, átkonvertálhatja a Microsoft PowerPoint prezentációját XPS formátumba. Így könnyebben mentheti, megoszthatja és nyomtathatja a dokumentumokat. 

A Microsoft továbbra is erős támogatást biztosít az XPS‑nek a Windowsban (még a Windows 10‑ben is), ezért érdemes lehet fájlokat ebbe a formátumba menteni. Ha Windows 8.1‑et, Windows 8‑at, Windows 7‑et vagy Windows Vista‑t használ, az XPS valójában a legjobb megoldás lehet bizonyos műveletekhez. 

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb támogatást nyújt az XPS fájlokhoz, mint a PDF fájlokhoz. 
  - **XPS:** Beépített XPS megjelenítő/olvasó és nyomtatás XPS‑re funkció elérhető. 
  - **PDF:** PDF olvasó elérhető, de nincs nyomtatás PDF‑re funkció. 

- **Windows 7** és **Windows Vista** az eredeti XPS formátumot használják. Ezek az operációs rendszerek szintén jobb támogatást nyújtanak az XPS fájlokhoz, mint a PDF‑ekhez. 
  - **XPS:** Beépített XPS megjelenítő és nyomtatás XPS‑re funkció elérhető. 
  - **PDF:** Nincs PDF olvasó. Nincs nyomtatás PDF‑re funkció. 

|<p>**Bemeneti PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimeneti XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft végül a Windows 10‑es Print to PDF funkcióval valósította meg a nyomtatási műveletek PDF‑be való támogatását. Korábban a felhasználók a dokumentumok nyomtatását az XPS formátumon keresztül végezték. 

## **XPS konvertálás az Aspose.Slides‑szel**

A [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hu/nodejs-java/)‑ban használhatja a [**save**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) metódust, amelyet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály biztosít, a teljes prezentáció XPS dokumentummá konvertálásához.

XPS‑re konvertáláskor a prezentációt az alábbi beállítások egyikével kell menteni:

- Alapértelmezett beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xpsoptions) nélkül)
- Egyedi beállítások (a [**XPSOptions**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xpsoptions) használatával)

### **Prezentációk XPS‑re konvertálása alapértelmezett beállításokkal**

Ez a JavaScript‑mintakód megmutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá szabványos beállításokkal:

```javascript
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt reprezentál
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // A prezentáció mentése XPS dokumentumba
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Prezentációk XPS‑re konvertálása egyedi beállításokkal**
Ez a mintakód megmutatja, hogyan konvertáljon egy prezentációt XPS dokumentummá egyedi beállításokkal JavaScript‑ben:

```javascript
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt reprezentál
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Létrehozza a TiffOptions osztályt
    var options = new aspose.slides.XpsOptions();
    // Mentse a MetaFiles-t PNG-ként
    options.setSaveMetafilesAsPng(true);
    // Mentse a prezentációt XPS dokumentumba
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Menthetek XPS‑t stream‑be a fájl helyett?**

Igen — az Aspose.Slides lehetővé teszi a közvetlen exportálást stream‑be, ami ideális web‑API‑k, szerver‑oldali folyamatok vagy bármely olyan forgatókönyv számára, ahol az XPS‑t a fájlrendszer érintése nélkül szeretné átadni.

**A rejtett diák átkerülnek XPS‑be, és kizárhatók?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [exportálási beállítások](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xpsoptions/) segítségével [belevehet vagy kizárhat rejtett diákot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) a mentés előtt, így a kimenet pontosan azokat az oldalakat tartalmazza, amelyeket szeretne.