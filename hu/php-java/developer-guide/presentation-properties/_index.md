---
title: Prezentációs tulajdonságok kezelése PHP-vel
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/php-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- fejlett tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás-ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a prezentációs tulajdonságokat az Aspose.Slides for PHP via Java segítségével, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánya a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDocumentProperties) metódus által kerül visszaadásra. A következő példák bemutatják, hogyan lehet olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}
Kérjük, vegye figyelembe, hogy a **Application** és **AppVersion** mezők nem módosíthatók. Az Aspose.Slides minden mentéskor újraírja őket, így egy mentett prezentáció mindig azt a jelentést adja, hogy "Aspose.Slides for PHP via Java" és a könyvtár verzióját, amely előállította. A `setNameOfApplication`‑nak átadott bármely érték elvetésre kerül, amikor a prezentációt írásra kerül.
{{% /alert %}} 

## **Prezentációs tulajdonságok kezelése**

A Microsoft PowerPoint egy funkciót biztosít a prezentációs fájlokhoz néhány tulajdonság hozzáadásához. Ezek a dokumentumtulajdonságok lehetővé teszik, hogy hasznos információkat tároljanak a dokumentumok (prezentációs fájlok) mellett. Kétféle dokumentumtulajdonság létezik, a következők:

- Rendszer által meghatározott (Beépített) tulajdonságok
- Felhasználó által meghatározott (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit stb. **Egyéni** tulajdonságok azok, amelyeket a felhasználók **Név/Érték** párokként definiálnak, ahol mind a név, mind az érték a felhasználó által van megadva. Az Aspose.Slides for PHP via Java segítségével a fejlesztők hozzáférhetnek és módosíthatják a beépített tulajdonságok értékeit, valamint az egyéni tulajdonságokat.

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentációs fájlok dokumentumtulajdonságainak kezelését. Mindössze arra van szükség, hogy rákattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben, ahogy az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Az **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogyan az alább látható a képen:

|**Tulajdonságok párbeszédablak**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Tulajdonságok párbeszédablakban** látható, hogy számos lapfül létezik, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapfülek lehetővé teszik a PowerPoint fájlokkal kapcsolatos különböző információk konfigurálását. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

A dokumentumtulajdonságok kezelése az Aspose.Slides for PHP via Java használatával

Ahogy korábban leírtuk, az Aspose.Slides for PHP via Java kétféle dokumentumtulajdonságot támogat, a **Beépített** és az **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típust elérhetik az Aspose.Slides for PHP via Java API használatával. Az Aspose.Slides for PHP via Java biztosít egy [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) osztályt, amely a prezentációs fájlhoz kapcsolódó dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

Fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektum által biztosított **DocumentProperties** tulajdonságot használhatják a prezentációs fájlok dokumentumtulajdonságainak eléréséhez, az alább leírt módon:

## **Publikus tulajdonságok olvasása titkosított prezentációból**

A nyitó jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentáció titkosításra kerül a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak `false` érték átadásával, a dokumentumtulajdonságai nyilvánosak maradnak. Egy alkalmazás ezután `true`‑t adhat át a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódusnak, és a nyitó jelszó megadása nélkül olvashatja a nyilvános metaadatokat.

A csak dokumentumtulajdonságok betöltése opció azt szabályozza, hogy az Aspose.Slides mit tölt be; nem titkosít fel semmit. Ha a tulajdonságok a titkosítás részét képezték, a jelszó nélkül történő betöltés meghiúsul. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyják, és a teljes prezentáció betöltődik.

A következő példa a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) metódussal ellenőrzi a betöltési módot, majd a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDocumentProperties) segítségével olvassa a beépített tulajdonságokat:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Ebben a módban a dia tartalma nem töltődik be. A diák, a mester-diák, az elrendezések, az alakzatok, a média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) metódust, mielőtt olyan műveletet végeznének, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Figyelmeztetés" %}}
Nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrét követelménye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a dokumentumtulajdonságok‑csak módjában betöltött prezentáció célja a nyilvános metaadatok olvasása. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a metaadat‑csak objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentációban lévő megfelelő adatokkal. Ennek frissítése ezért a helyes nyitó jelszót és a teljes betöltést igényli.

A következő példa a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) segítségével megnyitja a prezentációt, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isEncrypted) metódust használja annak ellenőrzésére, hogy a titkosítás megmaradt-e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Ha egy alkalmazás nem jogosult a prezentáció tartalmának dekódolására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvasásra használhatja.

## **Beépített tulajdonságok elérése**

Ezeket a tulajdonságokat a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties) objektum teszi elérhetővé, és a következőket tartalmazzák: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Közös használat különböző előállítók között?), **PresentationFormat**, **Subject** és **Title**

```php
  # Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre hivatkozást a Presentation-hez tartozó IDocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # A beépített tulajdonságok megjelenítése
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

A prezentációs fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alább bemutatott példában azt mutattuk be, hogyan módosíthatjuk a prezentációs fájl beépített dokumentumtulajdonságait az Aspose.Slides for PHP via Java használatával.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre hivatkozást a Presentation-hez tartozó IDocumentProperties objektumra
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, amelyek az alább láthatók:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állíthatók be az egyéni tulajdonságok egy prezentációhoz.

```php
  $pres = new Presentation();
  try {
    # Dokumentum tulajdonságok lekérése
    $dProps = $pres->getDocumentProperties();
    # Egyéni tulajdonságok hozzáadása
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Tulajdonság név lekérése adott indexen
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

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan férhet hozzá és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hozzon létre hivatkozást a Presentation-hez tartozó DocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # Egyéni tulajdonságok elérése és módosítása
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Egyéni tulajdonságok nevének és értékeinek megjelenítése
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Egyéni tulajdonságok értékeinek módosítása
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # A prezentáció mentése egy fájlba
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

## **Fejlett dokumentumtulajdonságok**

{{% alert color="info" title="Megjegyzés" %}}
Új módszerek, a [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), a [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), és a [writeBindedPresentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#setLastSavedTime) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

Két új metódust, a [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) és a [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) adtak a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo) osztályhoz. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását a teljes prezentáció betöltése nélkül.

Egy tipikus forgatókönyv, amely betölti a tulajdonságokat, módosít egy értéket, majd frissíti a dokumentumot, a következő módon valósítható meg:

```php
  # olvassa be a prezentáció információit
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # szerezze be az aktuális tulajdonságokat
  $props = $info->readDocumentProperties();
  # állítsa be a Szerző és a Cím mezők új értékeit
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # frissítse a prezentációt új értékekkel
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Van egy másik mód is, hogy egy adott prezentáció tulajdonságait sablonként használva frissítsük más prezentációk tulajdonságait:

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

Egy új sablon létrehozható a semmiből, majd több prezentáció frissítésére használható:

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

## **Helyesírás-ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja a LanguageId tulajdonságot (a PortionFormat osztályban elérhető) a PowerPoint dokumentum helyesírás-ellenőrző nyelvének beállításához. A helyesírás-ellenőrző nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a PHP kód bemutatja, hogyan állítható be a helyesírás-ellenőrző nyelv egy PowerPointhoz: xxx Miért hiányzik a LanguageId a Java PortionFormat osztályból?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// állítsa be a helyesírás-ellenőrző nyelv azonosítóját

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alapértelmezett nyelv beállítása**

Ez a PHP kód bemutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **FAQ**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentációs tulajdonságokat anélkül, hogy a teljes prezentációt betölteném?**

Igen. Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust, majd a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/php-java/examine-presentation/) oldalt egy teljes jelentési példaért és formátum-specifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a nyitó jelszó nélkül?**

Igen. A dokumentumtulajdonságok titkosítását le kell tiltani a prezentáció titkosítása előtt, és a prezentációt a csak dokumentumtulajdonságok módjában kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítése a helyes nyitó jelszóval történő teljes betöltést igényli.