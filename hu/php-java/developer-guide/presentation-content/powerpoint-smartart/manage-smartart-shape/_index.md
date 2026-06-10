---
title: SmartArt grafikák kezelése prezentációkban PHP használatával
linktitle: SmartArt grafikák
type: docs
weight: 20
url: /hu/php-java/manage-smartart-shape/
keywords:
- SmartArt objektum
- SmartArt grafika
- SmartArt stílus
- SmartArt szín
- SmartArt létrehozása
- SmartArt hozzáadása
- SmartArt szerkesztése
- SmartArt módosítása
- SmartArt elérése
- SmartArt elrendezéstípus
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stílusának beállítását PHP-ben az Aspose.Slides használatával, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatással."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy programozottan hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk elmagyarázza, hogyan adhat hozzá egy SmartArt alakzatot egy diára, hogyan érheti el a már létező SmartArt alakzatokat, hogyan találhat SmartArt‑ot egy adott elrendezéstípus alapján, és hogyan módosíthatja a megjelenését a SmartArt stílus vagy színstílus megváltoztatásával.

A példák bemutatják, hogyan dolgozhat a SmartArt alakzatokkal a prezentációdia alakzategyűjteményén keresztül, ellenőrizheti, hogy egy alakzat SmartArt‑e, majd módosíthatja vagy vizsgálhatja annak tulajdonságait.

## **SmartArt alakzat létrehozása**
Aspose.Slides for PHP via Java biztosít egy API‑t a SmartArt alakzatok létrehozásához. Egy SmartArt alakzat diára való létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze be a dia referenciáját az Indexe használatával.  
3. [SmartArt alakzat hozzáadása](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addSmartArt) az [LayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArtLayoutType) beállításával.  
4. Mentse a módosított prezentációt PPTX fájlként.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt alakzat hozzáadása
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Prezentáció mentése
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat hozzáadva a diára**|

## **SmartArt alakzat elérése egy dián**
A következő kódot fogjuk használni a prezentációs dián hozzáadott SmartArt alakzatok eléréséhez. A mintakódban végigjárjuk a dia minden alakzatát, és ellenőrizzük, hogy az [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) típusú‑e. Ha az alakzat SmartArt, akkor [**SmartArt**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) példánnyá konvertáljuk.

```php
  # A kívánt prezentáció betöltése
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Végigmenni minden alakzaton az első dián
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ellenőrizze, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Az alakzat típuskonvertálása SmartArtEx-re
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt alakzat elérése egy adott elrendezéstípussal**
A következő minta kód segít a [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) alakzat elérésében egy adott LayoutType‑szal. Vegye figyelembe, hogy a LayoutType csak olvasható, és csak a [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) alakzat hozzáadásakor állítható be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, és töltse be a SmartArt‑os alakzatot tartalmazó prezentációt.  
2. Szerezze be az első dia referenciáját az Indexe használatával.  
3. Iteráljon végig minden alakzaton az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) típusú‑e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.  
5. Ellenőrizze a SmartArt alakzatot a kívánt LayoutType‑szal, és hajtsa végre a szükséges műveleteket.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Végigmenni minden alakzaton az első dián
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ellenőrizze, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Az alakzat típuskonvertálása SmartArtEx-re
        $smart = $shape;
        # SmartArt elrendezés ellenőrzése
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt alakzat stílusának módosítása**
Ebben a példában megtanuljuk, hogyan változtassuk meg a gyors stílust bármely SmartArt alakzatra.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, és töltse be a SmartArt‑os alakzatot tartalmazó prezentációt.  
2. Szerezze be az első dia referenciáját az Indexe használatával.  
3. Iteráljon végig minden alakzaton az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) típusú‑e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.  
5. Keresse meg a kívánt Style‑nal rendelkező SmartArt alakzatot.  
6. Állítsa be az új Style‑t a SmartArt alakzatra.  
7. Mentse a prezentációt.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Végigmenni minden alakzaton az első dián
    foreach($slide->getShapes() as $shape) {
      # Ellenőrizze, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Az alakzat típuskonvertálása SmartArtEx-re
        $smart = $shape;
        # SmartArt stílus ellenőrzése
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt stílus módosítása
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Prezentáció mentése
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat megváltozott stílussal**|

## **SmartArt alakzat színstílusának módosítása**
Ebben a példában megtanuljuk, hogyan változtassuk meg a színstílust bármely SmartArt alakzatra. A következő minta kód a kívánt színstílussal rendelkező SmartArt alakzatot éri el, és megváltoztatja annak stílusát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, és töltse be a SmartArt‑os alakzatot tartalmazó prezentációt.  
2. Szerezze be az első dia referenciáját az Indexe használatával.  
3. Iteráljon végig minden alakzaton az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) típusú‑e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.  
5. Keresse meg a kívánt Color Style‑nal rendelkező SmartArt alakzatot.  
6. Állítsa be az új Color Style‑t a SmartArt alakzatra.  
7. Mentse a prezentációt.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Végigmenni minden alakzaton az első dián
    foreach($slide->getShapes() as $shape) {
      # Ellenőrizze, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Az alakzat típuskonvertálása SmartArtEx-re
        $smart = $shape;
        # SmartArt szín típusának ellenőrzése
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt szín típusának módosítása
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Prezentáció mentése
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Ábra: SmartArt alakzat megváltozott színstílussal**|

## **GYIK**

**Animálhatom a SmartArt‑ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [szabványos animációk](/slides/hu/php-java/powerpoint-animation/) (belépés, kilépés, hangsúly, mozgási útvonal) alkalmazhatók rá ugyanúgy, mint más alakzatokra.

**Hogyan találhatok egy adott SmartArt‑ot a dián, ha nem ismerem a belső azonosítóját?**

Állítsa be és használja az Alternatív Szöveget (AltText), majd keresésre a shape‑t ezzel az értékkel – ez a javasolt módja a célalakzat megtalálásának.

**Csoportosíthatom a SmartArt‑ot más alakzatokkal?**

Igen. A SmartArt‑ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [csoport manipulálása](/slides/hu/php-java/group/) lehetséges.

**Hogyan kaphatok képet egy adott SmartArt‑ról (például előnézethez vagy jelentéshez)?**

Exportáljon egy miniatűr/képet az alakzatról; a könyvtár [egyes alakzatok renderelése](/slides/hu/php-java/create-shape-thumbnails/) lehetséges raster fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha a teljes prezentációt PDF‑be konvertálom?**

Igen. A renderelő motor a [PDF export](/slides/hu/php-java/convert-powerpoint-to-pdf/) során a magas hűségre törekszik, különböző minőség‑ és kompatibilitási beállításokkal.