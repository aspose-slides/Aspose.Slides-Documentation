---
title: PHP használatával címkék és egyéni adatok kezelése a prezentációkban
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/php-java/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, olvashat, frissíthet és távolíthat el címkéket és egyéni adatokat az Aspose.Slides for PHP via Java használatával, példákkal a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és az egyéni adatokkal a PowerPoint‑prezentációkban. Röviden ismerteti, hogyan tárolódnak az adatok a PPTX‑fájlokban, megjegyzi, hogy a bemutató‑specifikus adatok címkék és egyéni XML‑részek formájában létezhetnek, és leírja a címkéket mint kulcs‑érték karakterlánc párokat.

A cikk azt is bemutatja, hogyan olvashatók ki a címkeértékek, illetve hogyan adhatók hozzá címkék egy prezentációhoz, egy adott diára vagy egy alakzathoz. Emellett a cikk tárgyalja a gyakori címke‑kezelési feladatokat, például az összes címke törlését, egy címke nevének szerinti eltávolítását és a címkenevek listájának lekérését.

## **Adattárolás a prezentációs fájlokban**

A PPTX‑fájlok – a .pptx kiterjesztésű elemek – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum határozza meg a prezentációkban lévő adatok szerkezetét.

A *dia* a prezentációk egyik eleme, a *diarész* egyetlen dia tartalmát tartalmazza. A diarésznek megengedett, hogy kifejezett kapcsolatokkal rendelkezzen számos részhez – például a felhasználó által definiált címkékhez –, amelyeket az ISO/IEC 29500 határoz meg.

Az egyéni adatok (egy prezentációra jellemző) vagy felhasználó létezhetnek címkékként ([TagCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/)) és CustomXmlParts‑ként ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
A címkék lényegében karakterlánc kulcs‑érték párok.
{{% /alert %}} 

## **Címkeértékek lekérése**

A diákban egy címke a [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getKeywords) és a [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#setKeywords) metódusoknak felel meg. Ez a mintakód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for PHP via Java segítségével a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) esetén:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyéni tulajdonság neve – `MyTag`
- az egyéni tulajdonság értéke – `My Tag Value`

Ha bizonyos prezentációkat egy adott szabály vagy tulajdonság alapján szeretnél besorolni, akkor előnyös lehet címkék hozzáadása ezekhez a prezentációkhoz. Például, ha a Észak‑Amerikai országokból származó prezentációkat szeretnéd csoportosítani, létrehozhatsz egy „Észak‑Amerikai” címkét, és a releváns országokat (az USA‑t, Mexikót és Kanadát) értékként rendelheted hozzá.

Ez a mintakód bemutatja, hogyan adhatunk hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) használatával az Aspose.Slides for PHP via Java segítségével:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

A címkék beállíthatók a [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) esetén is:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Vagy bármely egyedi [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Korlátozások**

A `getCustomData()->getTags()` segítségével a saját adatcímke‑gyűjteménybe hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. Amikor a prezentációt PDF‑be exportálják, ezek **nem** kerülnek át a PDF‑címkeszerkezetbe. Ennek következtében egy címkéként hozzárendelt egyéni azonosító nem kérhető le a címkézett PDF‑ből.

**Megoldás**: Egy egyéni azonosítót tárolhatsz az objektum **Alt Text**‑ében (például `$shape->setAlternativeText("MyId")`). PDF‑re exportálás után az Alt Text megjelenhet a PDF‑címkeszerkezetben.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egyetlen műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevének megadásával anélkül, hogy végig iterálnék a teljes gyűjteményen?**

Használd a [remove(name)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/remove/) műveletet a [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/) esetén a címke kulcs szerinti törléséhez.

**Hogyan kérhetem le a címkék teljes nevének listáját elemzéshez vagy szűréshez?**

Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/); ez egy tömböt ad vissza az összes címkenévvel.