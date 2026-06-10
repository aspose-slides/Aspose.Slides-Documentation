---
title: Prezentációs információk lekérése és frissítése PHP-ben
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/php-java/examine-presentation/
keywords:
- prezentáció formátuma
- prezentáció tulajdonságai
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP használatával, a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentáció információkat az Aspose.Slides-ban. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma anélkül, hogy a teljes fájlt betöltenénk, hogyan olvashatók a dokumentumtulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) API-kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadatok kezeléséhez.

## **A prezentáció formátumának ellenőrzése**

Mielőtt dolgozna egy prezentáción, szeretné megtudni, hogy milyen formátumban (PPT, PPTX, ODP és mások) van a prezentáció jelenleg.

Ellenőrizheti egy prezentáció formátumát anélkül, hogy betöltené azt. Lásd a következő PHP kódot:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **A prezentáció tulajdonságainak lekérése**

Ez a PHP kód megmutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Érdemes megtekinteni a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#DocumentProperties--) osztály alatti tulajdonságokat.

## **A prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy egy PowerPoint prezentációnk van az alább bemutatott dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet megmutatja, hogyan szerkeszthet néhány prezentációs tulajdonságot:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

A dokumentumtulajdonságok módosításának eredményei az alábbiak.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért a prezentációról és annak biztonsági attribútumairól, az alábbi hivatkozások lehetnek hasznosak:

- [A prezentáció titkosításának ellenőrzése](https://docs.aspose.com/slides/hu/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [A prezentáció írásvédettségének ellenőrzése (csak olvasható)](https://docs.aspose.com/slides/hu/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [A prezentáció jelszóval védett állapotának ellenőrzése betöltés előtt](https://docs.aspose.com/slides/hu/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védésére használt jelszó megerősítése](https://docs.aspose.com/slides/hu/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva és melyek azok?**

Keresse a beágyazott betűtípusok információját a prezentáció szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a ténylegesen a tartalomban használt betűtípusok halmazával, hogy azonosítsa, mely betűkészletek kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákat és hány van belőlük?**

Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/gethidden/).

**Felderíthetem-e, hogy egyéni dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze az aktuális [dia méretét](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getslidesize/) és tájolását a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatásra és exportálásra vonatkozó viselkedést.

**Van gyors mód arra, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/), és jegyezze fel, hogy az adatok belsőek vagy hivatkozáson alapulnak-e, beleértve az esetleges törött hivatkozásokat.

**Hogyan értékelhetem a 'nehéz' diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diánál számolja össze az objektumok számát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; rendeljen hozzá egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítményproblémákat.