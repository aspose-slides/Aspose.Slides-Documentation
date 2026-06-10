---
title: WordArt hatások létrehozása és alkalmazása PHP-ben
linktitle: WordArt
type: docs
weight: 110
url: /hu/php-java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyék hatás
- megjelenítési hatás
- ragyogás hatás
- WordArt transzformáció
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for PHP via Java segítségével. Ez a lépésről-lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat."
---
## **Áttekintés**

A WordArt‑effektek lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk PowerPoint‑prezentációinkhoz. Az Aspose.Slides‑el a fejlesztők programozottan hozhatnak létre, testreszabhatnak és kezelhetnek WordArt‑ot, pont úgy, mint a Microsoft PowerPoint‑ben – anélkül, hogy az Office‑ot telepíteni kellene. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegátalakítások, kitöltési stílusok, vonalrajzok, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a prezentáció tartalma kifejezőbb és figyelemfelkeltőbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Olyan effektusokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Az Aspose.Slides használatával** 

Először egy egyszerű szöveget hozunk létre a következő PHP‑kóddal:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Ezután a szöveg betűméretét nagyobbra állítjuk, hogy az effektus jobban észrevehető legyen, a következő kóddal:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**A Microsoft PowerPoint használatával**

Nyissa meg a WordArt‑effektek menüt a Microsoft PowerPoint‑ben:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat előre definiált WordArt‑effektust. A bal oldali menüből adhatja meg az újszerű WordArt beállításait.

Az elérhető paraméterek vagy lehetőségek néhány példája:

![todo:image_alt_text](image-20200930114015-3.png)

**Az Aspose.Slides használatával**

Itt a [SmallGrid](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternstyle/#SmallGrid) minta színét alkalmazzuk a szövegre, és egy 1‑pixeles fekete szövegszegélyt adunk hozzá a következő kóddal:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Az eredményül kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt‑effektek alkalmazása**

**A Microsoft PowerPoint használatával**

A program felületéről ezeket az effektusokat alkalmazhatja egy szövegre, szövegtömbre, alakzatra vagy hasonló elemre:

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, Tükörképezés és Ragyogás effektusok szövegre, a 3D Formátum és 3D Rotáció effektusok szövegtömbre, a Lágy szegély tulajdonság alakzatobjektumra (akár akkor is hat, ha nincs 3D Formátum beállítva) alkalmazható.

### **Árnyék‑effektusok alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat állítjuk be. Az árnyék‑effektust a szövegre a következő kóddal alkalmazzuk:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

Az Aspose.Slides API három típusú árnyékot támogat: OuterShadow, InnerShadow és PresetShadow.

A PresetShadow‑dal előre definiált értékekkel alkalmazhat árnyékot a szövegre.

**A Microsoft PowerPoint használatával**

A PowerPointben egyetlen árnyék típus áll rendelkezésre. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Az Aspose.Slides használatával**

Az Aspose.Slides valójában egyszerre két árnyék típus alkalmazását teszi lehetővé: InnerShadow és PresetShadow.

**Megjegyzések:**

- Ha OuterShadow és PresetShadow együtt van használva, csak az OuterShadow‑effektus lesz alkalmazva.  
- Ha OuterShadow és InnerShadow egyszerre van használva, a ténylegesen alkalmazott effektus a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban az effektus duplázódik, míg a PowerPoint 2007‑ben csak az OuterShadow‑t alkalmazzák.

### **Tükrözési effektusok alkalmazása szövegre**

A következő kódrészlettel adunk megjelenést a szövegnek:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);

```

### **Ragyogás‑effektusok alkalmazása szövegre**

A szöveget a következő kóddal ragyogóvá vagy kiemelkedővé tesszük:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

Az eredmény:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Az árnyék, megjelenés és ragyogás paramétereit egyenként állíthatja be a szöveg minden részére külön-külön. 

{{% /alert %}} 

### **Transformációk használata a WordArt‑ban**

A Transform tulajdonságot (amely az egész szövegtömbre vonatkozik) a következő kóddal alkalmazzuk:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Mind a Microsoft PowerPoint, mind az Aspose.Slides for PHP via Java biztosít egy sor előre definiált transformációtípust.

{{% /alert %}} 

**PowerPoint használatával**

Az előre definiált transformációkhoz a következő úton juthat el: **Formátum** → **Szövegeffektus** → **Transformálás**

**Az Aspose.Slides használatával**

A transformáció típusának kiválasztásához használja a TextShapeType enumerációt. 

### **3D‑effektusok alkalmazása szövegre és alakzatokra**

A szövegalakzatra a következő mintakóddal állítunk be 3D‑effektust:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

Az eredményül kapott szöveg és alakzat:

![todo:image_alt_text](image-20200930114816-9.png)

A szövegre 3D‑effektust a következő PHP‑kóddal alkalmazunk:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

Az eredmény:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A 3D‑effektusok szövegre vagy azok alakzataira történő alkalmazása, valamint az effektusok közötti kölcsönhatások meghatározott szabályokon alapulnak. 

Képzeljen el egy jelenetet a szöveghez és a szöveget tartalmazó alakzathoz. A 3D‑effektus tartalmazza a 3D‑objektum ábrázolását és a jelenetet, amelyre az objektum helyeződik. 

- Ha a jelenet mind a alakzatra, mind a szövegre be van állítva, akkor az alakzat jelenetére nagyobb prioritás jut – a szöveg jelenete figyelmen kívül marad.  
- Ha az alakzatnak nincs saját jelenete, de van 3D‑ábrázolása, akkor a szöveg jelenete kerül felhasználásra.  
- Ellenkező esetben – ha az alakzat eredetileg nincs 3D‑effektussal – az alakzat sík, és a 3D‑effektus csak a szövegre lesz alkalmazva.  

Ezek a leírások kapcsolódnak a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusokhoz.

{{% /alert %}} 

## **Külső árnyék‑effektusok alkalmazása szövegre**
Az Aspose.Slides for PHP via Java a [OuterShadow](https://reference.aspose.com/slides/hu/php-java/aspose.slides/outershadow/) és [InnerShadow](https://reference.aspose.com/slides/hu/php-java/aspose.slides/innershadow/) osztályokat biztosítja, amelyek lehetővé teszik árnyék‑effektusok alkalmazását a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-hez tartozó szövegre. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze be a diára mutató referenciát az index alapján.  
3. Adjon hozzá egy Rectangle típusú AutoShape‑t a diára.  
4. Hozzáférés a AutoShape‑hez tartozó TextFrame‑hez.  
5. Állítsa be az AutoShape FillType‑ját NoFill‑ra.  
6. Hozzon létre egy OuterShadow példányt.  
7. Állítsa be az árnyék BlurRadius‑át.  
8. Állítsa be az árnyék Direction‑ját.  
9. Állítsa be az árnyék Distance‑át.  
10. Állítsa be a RectanglelAlign‑t TopLeft‑ra.  
11. Állítsa be a PresetColor‑t Black‑re.  
12. Írja ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Ez a mintakód – a fenti lépések megvalósítása – megmutatja, hogyan alkalmazza a külső árnyék‑effektust egy szövegre:

```php
  $pres = new Presentation();
  try {
    # A dia referenciájának lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle típusú AutoShape hozzáadása
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # TextFrame hozzáadása a Rectangle-hez
    $ashp->addTextFrame("Aspose TextBox");
    # Alap alakzat kitöltésének letiltása, ha a szöveg árnyékát szeretnénk
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Külső árnyék hozzáadása és minden szükséges paraméter beállítása
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Prezentáció mentése a lemezen
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belső árnyék‑effektusok alkalmazása alakzatokra**
Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze be a diára mutató referenciát.  
3. Adjon hozzá egy Rectangle típusú AutoShape‑t.  
4. Engedélyezze az InnerShadowEffect‑et.  
5. Állítsa be az összes szükséges paramétert.  
6. Állítsa be a ColorType‑ot Scheme‑re.  
7. Állítsa be a Scheme Color‑t.  
8. Írja ki a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Ez a mintakód (a fenti lépések alapján) megmutatja, hogyan adjon hozzá egy csatlakozót két alakzat között:

```php
  $pres = new Presentation();
  try {
    # A dia referenciájának lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle típusú AutoShape hozzáadása
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame hozzáadása a Rectangle-hez
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Belső árnyék hatás engedélyezése
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Az összes szükséges paraméter beállítása
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Szín típusa beállítása Scheme-re
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Sémaszín beállítása
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Prezentáció mentése
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Használhatok‑e WordArt‑effektusokat különböző betűtípusokkal vagy írásrendszerekkel (például arab, kínai)?**

Igen, az Aspose.Slides támogatja a Unicode‑ot és minden főbb betűtípussal és írásrendszerrel működik. A WordArt‑effektusok, mint például árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípus elérhetősége és a renderelés a rendszer betűtípusaitól függhet.

**Alkalmazhatok‑e WordArt‑effektusokat a dia master elemeire?**

Igen, a WordArt‑effektusokat alkalmazhatja a master diákon lévő alakzatokra, ideértve a cím helyőrzőket, lábléceket vagy háttér‑szöveget. A master elrendezésén végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt‑effektusok befolyásolják a prezentáció fájlméretét?**

Enyhén. Az olyan effektek, mint árnyék, ragyogás és színátmenetes kitöltés, kissé növelhetik a fájlméretet a formázási metaadatok hozzáadása miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt‑effektusok eredményét anélkül, hogy a prezentációt menteném?**

Igen, a WordArt‑ot tartalmazó diákat képekké (például PNG, JPEG) renderelheti a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) vagy [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) osztály `getImage` metódusával. Így a teljes prezentáció mentése vagy exportálása előtt memóriában vagy képernyőn előnézheti az eredményt.