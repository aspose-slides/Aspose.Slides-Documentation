---
title: PowerPoint prezentációk konvertálása XPS-be PHP-ban
linktitle: PowerPoint → XPS
type: docs
weight: 70
url: /hu/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, platformfüggetlen XPS formátumba az Aspose.Slides for PHP segítségével Java-on keresztül. Kapjon lépésről‑lépésre útmutatót és mintakódot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint bemutatók XPS formátumba történő konvertálását a PPT vagy PPTX fájl XPS formátumban való mentésével. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS formátum, és bemutatja, hogyan hajtható végre a konvertálás az Aspose.Slides segítségével alapértelmezett vagy egyedi [XpsOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xpsoptions/) beállításokkal.

## **Az XPS-ről**

A Microsoft a [XPS](https://docs.fileformat.com/page-description-language/xps/) formátumot a [PDF](https://docs.fileformat.com/pdf/) alternatívájaként fejlesztette ki. Lehetővé teszi a tartalom nyomtatását egy PDF-hez nagyon hasonló fájl előállításával. Az XPS formátum XML-en alapul. Az XPS fájl elrendezése vagy felépítése minden operációs rendszeren és nyomtatón ugyanaz marad.

## **Mikor használjuk a Microsoft XPS formátumot**

{{% alert color="primary" %}} 

Ahhoz, hogy megtekintse, hogyan konvertálja az Aspose.Slides a PPT vagy PPTX bemutatót XPS formátumba, tekintse meg [ezt az ingyenes online konverter alkalmazást](https://products.aspose.app/slides/hu/conversion). 

{{% /alert %}} 

Ha csökkenteni szeretné a tárolási költségeket, a Microsoft PowerPoint bemutatóját átalakíthatja XPS formátumba. Így egyszerűbbé válik a dokumentumok mentése, megosztása és nyomtatása.

A Microsoft folyamatosan erős XPS támogatást valósít meg a Windowsban (még a Windows 10-ben is), ezért érdemes megfontolni a fájlok ebben a formátumban történő mentését. Ha Windows 8.1, Windows 8, Windows 7 és Windows Vista rendszerekkel dolgozik, az XPS valójában a legjobb választás lehet bizonyos műveletekhez.

- **Windows 8** az OXPS (Open XPS) formátumot használja az XPS fájlokhoz. Az OXPS az eredeti XPS formátum szabványosított változata. A Windows 8 jobb XPS‑támogatást nyújt, mint a PDF fájlok esetében.
  - **XPS:** Beépített XPS‑néző/olvasó és XPS‑re nyomtatás funkció elérhető.
  - **PDF:** PDF‑olvasó elérhető, de PDF‑re nyomtatás funkció nincs.

- **Windows 7 és Windows Vista** az eredeti XPS formátumot használja. Ezek az operációs rendszerek is jobb XPS‑támogatást nyújtanak, mint a PDF‑eket.
  - **XPS:** Beépített XPS‑néző és XPS‑re nyomtatás funkció elérhető.
  - **PDF:** Nincs PDF‑olvasó. Nincs PDF‑re nyomtatás funkció.

|<p>**Bemenet PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Kimenet XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft végül bevezette a PDF nyomtatási műveletek támogatását a Windows 10-ben lévő Print to PDF funkción keresztül. Korábban a felhasználók a dokumentumok nyomtatását az XPS formátumon keresztül végezték.

## **XPS konverzió az Aspose.Slides segítségével**

A Java számára készült [**Aspose.Slides**](https://products.aspose.com/slides/hu/php-java/) esetén a [**Save**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódust használhatja, amelyet a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztály biztosít, hogy a teljes bemutatót XPS dokumentummá konvertálja.

Az XPS-re való konvertálás során a bemutatót a következő beállítások egyikével kell menteni:

- Alapértelmezett beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xpsoptions) nélkül)
- Egyedi beállítások (az [**XPSOptions**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xpsoptions) használatával)

### **Bemutatók konvertálása XPS-re alapértelmezett beállításokkal**

Ez a példa kód bemutatja, hogyan konvertálhat egy bemutatót XPS dokumentummá szabványos beállítások használatával:

```php
  # Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # A bemutató mentése XPS dokumentumba
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Bemutatók konvertálása XPS-re egyedi beállításokkal**

Ez a példa kód bemutatja, hogyan konvertálhat egy bemutatót XPS dokumentummá egyedi beállítások használatával :

```php
  # Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Hozzon létre egy TiffOptions osztályt
    $options = new XpsOptions();
    # MetaFile-okat PNG-ként menti
    $options->setSaveMetafilesAsPng(true);
    # A bemutató mentése XPS dokumentumba
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Menthetek XPS-t stream-be ahelyett, hogy fájlba írnám?**

Igen—az Aspose.Slides lehetővé teszi a közvetlen exportálást stream-be, ami ideális web‑API‑k, szerver‑oldali folyamatok vagy bármely olyan eset számára, ahol a XPS‑t a fájlrendszer érintése nélkül szeretné elküldeni.

**A rejtett diák átkerülnek az XPS‑be, és kizárhatom őket?**

Alapértelmezés szerint csak a normál (látható) diák kerülnek renderelésre. A [rejtett diák felvételével vagy kihagyásával](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) a [exportálási beállításokon](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xpsoptions/) keresztül, XPS‑ként mentés előtt, biztosítható, hogy a kimenet pontosan azokat az oldalakat tartalmazza, amelyeket kíván.