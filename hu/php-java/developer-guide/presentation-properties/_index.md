---
title: Prezentáció tulajdonságainak kezelése PHP-ben
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/php-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Mesteri prezentáció tulajdonságok kezelése az Aspose.Slides for PHP via Java segítségével, a keresés, márkázás és munkafolyamat egyszerűsítése PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét típusú tulajdonsághoz könnyedén hozzáférhet és kezelheti az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példányát a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDocumentProperties) metódus adja vissza. A következő példák bemutatják, hogyan olvashatja, módosíthatja és kezelheti ezeket a tulajdonságokat.

{{% alert color="primary" %}} 
Kérjük vegye figyelembe, hogy a **Application** és **Producer** mezők nem módosíthatók, mivel ezek a mezők mindig az "Aspose Ltd." és az "Aspose.Slides for PHP via Java x.x.x" értékeket fogják mutatni.
{{% /alert %}} 

## **Prezentáció Tulajdonságainak Kezelése**

A Microsoft PowerPoint lehetőséget biztosít néhány tulajdonság hozzáadására a prezentációs fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (prezentációs fájlokkal) együtt. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, mint például a dokumentum címe, a szerző neve, a dokumentum statisztikái stb. **Egyéni** tulajdonságok azok, amelyeket a felhasználók **Név/Érték** párok formájában definiálnak, ahol a név és az érték is a felhasználó által van megadva. Az Aspose.Slides for PHP via Java használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit.

## **PowerPointban lévő Dokumentumtulajdonságok**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentációs fájlok dokumentumtulajdonságainak kezelését. Ehhez csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben, ahogy az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Miután kiválasztotta az **Advanced Properties** menüpontot, megjelenik egy párbeszédablak, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogyan az alábbi ábrán is látható:

|**Tulajdonságok párbeszédablak**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Properties Dialog** ablakban látható, hogy több lap is létezik, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különféle, a PowerPoint fájlokhoz kapcsolódó információk beállítását teszik lehetővé. Az **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

### Dokumentumtulajdonságok kezelése az Aspose.Slides for PHP via Java használatával

Ahogy korábban leírtuk, az Aspose.Slides for PHP via Java támogatja a **Beépített** és **Egyéni** dokumentumtulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for PHP via Java API használatával. Az Aspose.Slides for PHP via Java egy [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties) osztályt biztosít, amely a **Presentation.DocumentProperties** tulajdonság révén képviseli egy prezentációs fájlhoz kapcsolódó dokumentumtulajdonságokat.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektum által kitetts **DocumentProperties** tulajdonságot használhatják a prezentációs fájlok dokumentumtulajdonságainak eléréséhez, ahogy az alább látható:

## **Beépített tulajdonságok elérése**

Ezek a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties) objektum által elérhető tulajdonságok: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott több producer között?), **PresentationFormat**, **Subject** és **Title**

```php
  # Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre egy hivatkozást a prezentációhoz kapcsolódó IDocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # Jelenítse meg a beépített tulajdonságokat
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Beépített tulajdonságok módosítása**

A prezentációs fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat bármely kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutatjuk, hogyan módosíthatjuk a prezentációs fájl beépített dokumentumtulajdonságait az Aspose.Slides for PHP via Java segítségével.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre egy hivatkozást a prezentációhoz kapcsolódó IDocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # Állítsa be a beépített tulajdonságokat
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Mentse a prezentációt egy fájlba
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ez a példa a prezentáció beépített tulajdonságait módosítja, a módosítás után az alábbiakban látható:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak hozzá a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állíthatók be egyéni tulajdonságok egy prezentációhoz.

```php
  $pres = new Presentation();
  try {
    # Dokumentumtulajdonságok lekérése
    $dProps = $pres->getDocumentProperties();
    # Egyéni tulajdonságok hozzáadása
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Tulajdonság nevének lekérése adott indexnél
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Kiválasztott tulajdonság eltávolítása
    $dProps->removeCustomProperty($getPropertyName);
    # Prezentáció mentése
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Egyéni dokumentumtulajdonságok hozzáadva**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre egy hivatkozást a prezentációhoz társított DocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # Hozzáférés és egyéni tulajdonságok módosítása
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Egyéni tulajdonságok nevének és értékeinek megjelenítése
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Egyéni tulajdonságok értékeinek módosítása
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Mentse a prezentációt egy fájlba
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Haladó dokumentumtulajdonságok**

{{% alert color="primary" %}} 
Új módszerek: [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) és [writeBindedPresentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#setLastSavedTime) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

A két új metódus, a [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) és az [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo) osztályhoz lettek hozzáadva. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy az egész prezentációt betöltenék.

A tipikus forgatókönyv a tulajdonságok betöltése, egy érték módosítása és a dokumentum frissítése a következő módon valósítható meg:

```php
  # olvassa be a prezentáció információit
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # szerezze be a jelenlegi tulajdonságokat
  $props = $info->readDocumentProperties();
  # állítsa be az Szerző és Cím mezők új értékeit
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # frissítse a prezentációt új értékekkel
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Létezik egy másik módja is annak, hogy egy adott prezentáció tulajdonságait sablonként használjuk más prezentációk tulajdonságainak frissítéséhez:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Új sablon hozható létre a semmiből, majd több prezentáció frissítésére használható:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja a LanguageId tulajdonságot (a PortionFormat osztály által kitetts), amely lehetővé teszi a proofing nyelv beállítását egy PowerPoint dokumentumhoz. A proofing nyelv az a nyelv, amelyen a PowerPoint helyesírása és nyelvtana ellenőrzésre kerül.

Ez a PHP kód megmutatja, hogyan állíthatja be a proofing nyelvet egy PowerPointhoz: xxx Miért hiányzik a LanguageId a Java PortionFormat osztályból?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// állítsa be a helyesírási nyelv azonosítóját

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alapértelmezett nyelv beállítása**

Ez a PHP kód megmutatja, hogyan állíthatja be az alapértelmezett nyelvet egy teljes PowerPoint prezentációhoz:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Új téglalap alakzat hozzáadása szöveggel
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Ellenőrzi az első rész nyelvét
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Élő példa**

Próbálja ki az [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részét képezik, és nem távolíthatók el teljesen. Azonban módosíthatja értéküket, vagy – ha a konkrét tulajdonság megengedi – üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő értéke felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen, a prezentáció tulajdonságaihoz anélkül is hozzáférhet, hogy a teljes prezentációt betöltené, a `getPresentationInfo` metódus használatával a [PresentationFactory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) osztályból. Ezután a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) osztály `readDocumentProperties` metódusával olvashatja a tulajdonságokat hatékonyan, memóriát takarítva meg és javítva a teljesítményt.