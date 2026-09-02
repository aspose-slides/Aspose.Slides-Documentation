---
title: Prezentáció információinak lekérése és frissítése PHP-ben
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/php-java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
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
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentációs információkat az Aspose.Slides-ben. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók ki a dokumentum tulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) API-kon alapulnak, és bemutatják a prezentáció metaadatokkal végzett tipikus műveleteket.

## **Egy prezentáció formátumának ellenőrzése**

Mielőtt egy prezentáción dolgozna, előfordulhat, hogy meg szeretné tudni, melyik formátumban (PPT, PPTX, ODP és mások) van a prezentáció jelenleg.

A prezentáció formátuma betöltés nélkül is ellenőrizhető. Lásd ezt a PHP kódot:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Prezentáció tulajdonságainak lekérése**

Ez a PHP kód megmutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Érdemes megtekinteni a [properties under the DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#DocumentProperties--) osztályban található tulajdonságokat.

## **Prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció a lenti dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

A dokumentumtulajdonságok módosításának eredményei alább láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért a prezentációról és biztonsági attribútumairól ezek a hivatkozások lehetnek hasznosak:

- [Jelszóval védett prezentációk](/slides/hu/php-java/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/php-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva és melyek?**

Keresse a [embedded-font information](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getembeddedfonts/) információt a prezentáció szintjén, majd hasonlítsa össze ezeket a [fonts actually used across content](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getfonts/) listával, hogy azonosítsa, mely betűtípusok kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diák tartalmaz-e, és ha igen, hány darab?**

Iteráljon a [slide collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) elemein, és ellenőrizze minden dia [visibility flag](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/gethidden/) attribútumát.

**Felderíthetem-e, hogy egyedi dia méret és orientáció van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [slide size](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getslidesize/) és orientációt a szabványos előbeállításokkal; ez segít a nyomtatás és exportálás viselkedésének előrejelzésében.

**Van gyors mód arra, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [charts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) elemet, ellenőrizze a [data source](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) típusát, és jegyezze fel, hogy az adatok belsőek vagy hivatkozáson alapulnak, beleértve a törött hivatkozásokat is.

**Hogyan értékelhetem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diánál számolja meg az objektumok mennyiségét, és keresse a nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítménybeli problémákat.