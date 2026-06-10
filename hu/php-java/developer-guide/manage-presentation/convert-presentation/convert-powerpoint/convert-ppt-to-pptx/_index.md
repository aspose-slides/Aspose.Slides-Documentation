---
title: PPT konvertálása PPTX-re PHP-ben
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálás
- prezentáció konvertálás
- dia konvertálás
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Konvertálja a régi PPT prezentációkat modern PPTX-re gyorsan az Aspose.Slides for PHP via Java segítségével - könnyű útmutató, ingyenes kódminták, Microsoft Office függőség nélkül."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan konvertálhatók a PowerPoint-prezentációk PPT formátumról PPTX formátumra PHP használatával és egy online PPT‑től PPTX‑re konvertáló alkalmazással. A következő téma kerül tárgyalásra.

- PPT konvertálása PPTX-be

## **PPT konvertálása PPTX-be PHP‑ben**

A PPT PPTX‑re konvertálásához Java minta kódért lásd az alábbi szekciót, azaz [PPT konvertálása PPTX‑be](#convert-ppt-to-pptx). Ez csak betölti a PPT fájlt és PPTX formátumban menti. Különböző mentési formátumok megadásával a PPT fájlt több más formátumba is mentheted, például PDF, XPS, ODP, HTML stb., amint ezekben a cikkekben tárgyaltuk.

- [PPT konvertálása PDF‑re PHP‑ben](/slides/hu/php-java/convert-powerpoint-to-pdf/)
- [PPT konvertálása XPS‑re PHP‑ben](/slides/hu/php-java/convert-powerpoint-to-xps/)
- [PPT konvertálása HTML‑re PHP‑ben](/slides/hu/php-java/convert-powerpoint-to-html/)
- [PPT konvertálása ODP‑re PHP‑ben](/slides/hu/php-java/save-presentation/)
- [PPT konvertálása PNG‑re PHP‑ben](/slides/hu/php-java/convert-powerpoint-to-png/)

## **A PPT‑től PPTX‑re konverzióról**

Konvertálja a régi PPT formátumot PPTX‑re az Aspose.Slides API‑val. Ha több ezer PPT prezentációt kell PPTX formátumba alakítani, a legjobb megoldás a programozott konvertálás. Az Aspose.Slides API‑val ez csak néhány kódsorral megvalósítható. Az API teljes kompatibilitást biztosít a PPT prezentációk PPTX‑re konvertálásához, és lehetővé teszi a következőket:
- A mester-, elrendezés- és diaképek összetett struktúráinak konvertálása.
- Diagramokkal rendelkező prezentációk konvertálása.
- Csoportos alakzatokkal, automatikus alakzatokkal (például négyzetek és ellipszisek), egyedi geometriai alakzatokkal rendelkező prezentációk konvertálása.
- Textúrákat és képeket kitöltő stílusokkal rendelkező automatikus alakzatokkal ellátott prezentációk konvertálása.
- Helyettesítőkkel, szövegdobozokkal és szövegtárolókkal rendelkező prezentációk konvertálása.

{{% alert color="primary" %}} 
Nézze meg a [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) alkalmazást:

[](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx)

Ez az alkalmazás az [**Aspose.Slides API**](https://products.aspose.com/slides/hu/php-java/) alapján készült, így élő példát lát a PPT‑től PPTX‑re történő alapvető konvertálási lehetőségekre. Az Aspose.Slides Conversion egy webalkalmazás, amely lehetővé teszi PPT formátumú prezentáció feltöltését, és a konvertált PPTX letöltését. Keresse meg a többi élő [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hu/conversion/) példát.
{{% /alert %}} 

## **PPT konvertálása PPTX‑be**

Az Aspose.Slides for PHP via Java most lehetővé teszi a fejlesztőknek, hogy a PPT‑hez hozzáférjenek a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztálypéldány használatával, és azt a megfelelő [PPTX](https://docs.fileformat.com/presentation/pptx/) formátumba konvertálják. Jelenleg részleges konverziót támogat a [PPT ](https://docs.fileformat.com/presentation/ppt/) és PPTX között. A PPT‑től PPTX‑re konvertálás támogatott és nem támogatott funkcióiról további információkért tekintse meg ezt a dokumentációt [link](/slides/hu/php-java/ppt-to-pptx-conversion/).

Az Aspose.Slides for PHP via Java egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályt kínál, amely egy **PPTX** prezentációs fájlt képviseli. A Presentation osztály most már a **PPT**‑hez is hozzáférhet a példányosításkor. Az alábbi példa bemutatja, hogyan konvertálható egy PPT prezentáció PPTX prezentációvá.

```php
  # Létrehoz egy Presentation objektumot, amely egy PPTX fájlt képvisel
  $pres = new Presentation("Aspose.ppt");
  try {
    # PPTX prezentáció mentése PPTX formátumba
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Ábra : Forrás PPT prezentáció**|

A fenti kódrészlet a következő PPTX prezentációt generálta a konvertálás után:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Ábra: Generált PPTX prezentáció a konvertálás után**|

## **GYIK**

**Mi a különbség a PPT és a PPTX formátumok között?**

A PPT a Microsoft PowerPoint által használt régebbi bináris fájlformátum, míg a PPTX az újabb, XML‑alapú formátum, amelyet a Microsoft Office 2007 vezetett be. A PPTX fájlok jobb teljesítményt, kisebb fájlméretet és fejlettebb adat‑helyreállítást biztosítanak.

**Támogatja az Aspose.Slides a több PPT fájl kötegelt PPTX‑re konvertálását?**

Igen, az Aspose.Slides‑t egy ciklusban használva programozottan több PPT fájlt is konvertálhat PPTX‑re, így alkalmas kötegelt konvertálási esetekre.

**Megmarad a tartalom és a formázás a konvertálás után?**

Az Aspose.Slides magas hűséggel konvertálja a prezentációkat. A diák elrendezései, animációi, alakzatai, diagramjai és egyéb tervezési elemei megmaradnak a PPT‑től PPTX‑re konvertálás során.

**Konvertálhatok más formátumokat, például PDF‑et vagy HTML‑t PPT fájlokból?**

Igen, az Aspose.Slides támogatja a PPT fájlok konvertálását [több formátumba](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/), többek között PDF, XPS, HTML, ODP, valamint képformátumok, mint a PNG és a JPEG.

**Lehetséges PPT‑t PPTX‑re konvertálni a Microsoft PowerPoint telepítése nélkül?**

Igen, az Aspose.Slides egy önálló API, amely nem igényel Microsoft PowerPoint‑ot vagy semmilyen harmadik féltől származó szoftvert a konvertáláshoz.

**Elérhető online eszköz PPT‑t PPTX‑re konvertáláshoz?**

Igen, a ingyenes [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) webalkalmazást használva a konvertálást közvetlenül a böngészőben végezheti kód írása nélkül.