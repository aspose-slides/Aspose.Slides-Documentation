---
title: Prezentáció tulajdonságok kezelése PHP-ben
linktitle: Prezentációs tulajdonságok
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
- javító nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP via Java segítségével kezelje a prezentáció tulajdonságait, és optimalizálja a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét típusú tulajdonság könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságaival a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánya a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDocumentProperties) metódus által kerül visszaadásra. A következő példák bemutatják, hogyan kell ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Megjegyzés" %}}
Felhívjuk a figyelmet, hogy a **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, így egy mentett prezentáció mindig azt jelenti, hogy “Aspose.Slides for PHP via Java”, valamint a könyvtár verzióját, amely azt előállította. A `setNameOfApplication`‑nak átadott bármely érték eldobásra kerül a prezentáció írásakor.
{{% /alert %}} 

## **Prezentáció Tulajdonságok Kezelése**

A Microsoft PowerPoint lehetővé teszi, hogy bizonyos tulajdonságokat adjunk a prezentáció fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (prezentáció fájlokkal) együtt. Kétféle dokumentumtulajdonság létezik, a következők szerint:

- Rendszer által meghatározott (Beépített) tulajdonságok
- Felhasználó által meghatározott (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, mint például a dokumentum címe, a szerző neve, a dokumentum statisztikái stb. **Egyéni** tulajdonságok azok, amelyeket a felhasználók **Név/Érték** párok formájában definiálnak, ahol mind a név, mind az érték a felhasználó által van meghatározva. Az Aspose.Slides for PHP via Java segítségével a fejlesztők hozzáférhetnek és módosíthatják a beépített és egyéni tulajdonságok értékeit.

## **PowerPoint Dokumentumtulajdonságok**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben, az alábbiak szerint:

|**Haladó tulajdonságok menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Miután kiválasztotta a **Advanced Properties** menüpontot, megjelenik egy párbeszédpanel, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédpanel**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Properties Dialog**‑ban látható, hogy számos lap található, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különböző típusú információk konfigurálását teszik lehetővé a PowerPoint fájlokhoz kapcsolódóan. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

### Dokumentumtulajdonságok kezelése az Aspose.Slides for PHP via Java használatával

Amint korábban leírtuk, az Aspose.Slides for PHP via Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for PHP via Java API használatával. Az Aspose.Slides for PHP via Java egy [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties) osztályt biztosít, amely a prezentáció fájlhoz társított dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektum által biztosított **DocumentProperties** tulajdonságot használhatják a prezentáció fájlok dokumentumtulajdonságainak eléréséhez, az alábbiak szerint:

## **Beépített tulajdonságok elérése**

Ezek a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties) objektum által biztosított tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott különböző előállítók között?), **PresentationFormat**, **Subject** és **Title**

```php
  # A Presentation osztály példányosítása, amely a prezentációt képviseli
  $pres = new Presentation("Presentation.pptx");
  try {
    # Egy hivatkozás létrehozása az IDocumentProperties objektumra, amely a Presentation-hez kapcsolódik
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

A beépített tulajdonságok módosítása olyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat bármely kívánt tulajdonságnak, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan módosíthatjuk a prezentáció fájl beépített dokumentumtulajdonságait az Aspose.Slides for PHP via Java segítségével.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hivatkozás létrehozása az IDocumentProperties objektumra, amely a Presentation-hez kapcsolódik
    $dp = $pres->getDocumentProperties();
    # Beépített tulajdonságok beállítása
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Prezentáció mentése fájlba
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ez a példa módosítja a prezentáció beépített tulajdonságait, amely az alábbiakban látható:

|**Módosítás után a beépített dokumentumtulajdonságok**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for PHP via Java azt is lehetővé teszi, hogy a fejlesztők egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa azt mutatja, hogyan kell beállítani egyéni tulajdonságokat egy prezentációhoz.

```php
  $pres = new Presentation();
  try {
    # Dokumentumtulajdonságok lekérése
    $dProps = $pres->getDocumentProperties();
    # Egyéni tulajdonságok hozzáadása
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Tulajdonság nevének lekérdezése adott indexnél
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

|**Hozzáadott egyéni dokumentumtulajdonságok**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for PHP via Java azt is lehetővé teszi, hogy a fejlesztők hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa azt mutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hivatkozás létrehozása a Presentation-hez kapcsolódó DocumentProperties objektumra
    $dp = $pres->getDocumentProperties();
    # Egyéni tulajdonságok elérése és módosítása
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Egyéni tulajdonságok neveinek és értékeinek megjelenítése
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Egyéni tulajdonságok értékeinek módosítása
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Prezentáció mentése fájlba
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ez a példa módosítja a [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Haladó dokumentumtulajdonságok**

{{% alert color="info" title="Megjegyzés" %}}
Új módszerek a [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), a [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) és a [writeBindedPresentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#setLastSavedTime) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

Az újonnan hozzáadott két módszer, a [readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) és a [updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), kerültek a [PresentationInfo] osztályba. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy teljes prezentációt betöltenénk.

A tipikus forgatókönyv, amely betölti a tulajdonságokat, módosít egy értéket, majd frissíti a dokumentumot, a következő módon valósítható meg:

```php
  # olvasd be a prezentáció adatait
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # szerezzd meg a jelenlegi tulajdonságokat
  $props = $info->readDocumentProperties();
  # állítsd be az Author és Title mezők új értékeit
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # frissítsd a prezentációt új értékekkel
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Egy másik módja annak, hogy egy adott prezentáció tulajdonságait sablonként használjuk a más prezentációk tulajdonságainak frissítéséhez:

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

Új sablon hozható létre a semmiből, majd használható több prezentáció frissítésére:

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

## **Javító nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által biztosított) kínálja, amely lehetővé teszi a javító nyelv beállítását egy PowerPoint dokumentumhoz. A javító nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a PHP kód bemutatja, hogyan állítható be a javító nyelv egy PowerPointhoz: xxx Miért hiányzik a LanguageId a Java PortionFormat osztályból?

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
    $portionFormat->setLanguageId("zh-CN");// a javító nyelv azonosítójának beállítása

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

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy beállíthatja őket üresre, ha a konkrét tulajdonság ezt megengedi.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust, majd a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/php-java/examine-presentation/) oldalt a teljes jelentési példa és a formátumspecifikus korlátok megtekintéséhez.