---
title: SmartArt grafikák kezelése prezentációkban JavaScript használatával
linktitle: SmartArt grafikák
type: docs
weight: 20
url: /hu/nodejs-java/manage-smartart-shape/
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
- SmartArt elrendezés típus
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stílusozását JavaScriptben az Aspose.Slides segítségével, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy programozott módon hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adhat hozzá egy SmartArt alakzatot egy diára, hogyan érheti el a meglévő SmartArt alakzatokat, hogyan találhat meg egy SmartArt‑ot egy adott elrendezéstípus alapján, és hogyan frissítheti megjelenését a SmartArt stílus vagy színstílus módosításával.

A példák bemutatják, hogyan dolgozhat a SmartArt alakzatokkal a prezentáció dia alakzatgyűjteményén keresztül, hogyan ellenőrizheti, hogy egy alakzat SmartArt-e, majd módosíthatja vagy ellenőrizheti annak tulajdonságait.

## **SmartArt alakzat létrehozása**
Aspose.Slides for Node.js via Java API-t biztosít a SmartArt alakzatok létrehozásához. Egy SmartArt alakzat létrehozásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia hivatkozását az Index használatával.
1. [SmartArt alakzat hozzáadása](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) a [LayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtLayoutType) beállításával.
1. Mentse a módosított prezentációt PPTX fájlként.

```javascript
// Presentation osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Smart Art alakzat hozzáadása
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Prezentáció mentése
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat hozzáadva a diára**|

## **SmartArt alakzat elérése a dián**
A következő kódot a prezentáció diáján hozzáadott SmartArt alakzatok elérésére használjuk. A példakódban végigjárjuk a dia minden alakzatát, és ellenőrizzük, hogy [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) alakzat-e. Ha az alakzat SmartArt típusú, akkor átkonvertáljuk [**SmartArt**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) példánnyá.

```javascript
// A kívánt prezentáció betöltése
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Az első dia minden alakzatának bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat átkonvertálása SmartArtEx típusra
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt alakzat elérése egy adott elrendezéstípussal**
A következő példakód segít elérni a [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) alakzatot egy adott LayoutType használatával. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType-ját nem lehet módosítani, mivel csak olvasható, és csak a [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) alakzat hozzáadásakor állítható be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Járja be az első dia minden alakzatát.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt példánnyá.
1. Ellenőrizze a SmartArt alakzatot az adott LayoutType használatával, és végezze el a szükséges lépéseket.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Az első dia minden alakzatának bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat átkonvertálása SmartArtEx típusra
            var smart = shape;
            // SmartArt elrendezés ellenőrzése
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt alakzat stílusának módosítása**
Ebben a példában megtanuljuk, hogyan módosítsuk a gyors stílust bármely SmartArt alakzatnál.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Járja be az első dia minden alakzatát.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt példánnyá.
1. Keresse meg a SmartArt alakzatot a megadott stílussal.
1. Állítsa be az új stílust a SmartArt alakzatra.
1. Mentse a prezentációt.

```javascript
// Presentation osztály példányosítása
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Az első dia minden alakzatának bejárása
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat átkonvertálása SmartArtEx típusra
            var smart = shape;
            // SmartArt stílus ellenőrzése
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // SmartArt stílusának módosítása
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Prezentáció mentése
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat módosított stílussal**|

## **SmartArt alakzat színstílusának módosítása**
Ebben a példában megtanuljuk, hogyan módosítsuk a színstílust bármely SmartArt alakzatnál. A következő példakódban hozzáférünk a SmartArt alakzathoz egy adott színstílussal, és megváltoztatjuk annak stílusát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Járja be az első dia minden alakzatát.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt példánnyá.
1. Keresse meg a SmartArt alakzatot a megadott színstílussal.
1. Állítsa be az új színstílust a SmartArt alakzatra.
1. Mentse a prezentációt.

```javascript
// Presentation osztály példányosítása
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Az első dia minden alakzatának bejárása
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat átkonvertálása SmartArtEx típusra
            var smart = shape;
            // SmartArt szín típusának ellenőrzése
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // SmartArt szín típusának módosítása
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Prezentáció mentése
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Ábra: SmartArt alakzat módosított színstílussal**|

## **GYIK**

**Animálhatom a SmartArt-ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, így a [standard animations](/slides/hu/nodejs-java/powerpoint-animation/) API segítségével (bevezető, kilépő, hangsúlyos, mozgási útvonal) ugyanúgy alkalmazható, mint más alakzatokra.

**Hogyan találhatok meg egy konkrét SmartArt-ot a dián, ha nem ismerem annak belső azonosítóját?**

Állítsa be és használja az Alternatív Szöveget (AltText), majd keresse meg az alakzatot ezen az értéken — ez a javasolt módja a cél alakzat megtalálásának.

**Csoportosíthatom a SmartArt-ot más alakzatokkal?**

Igen. A SmartArt-ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/nodejs-java/group/).

**Hogyan kapok képet egy konkrét SmartArt-ról (pl. előnézethez vagy jelentéshez)?**

Exportáljon egy bélyegképet/képet az alakzatról; a könyvtár képes [render individual shapes](/slides/hu/nodejs-java/create-shape-thumbnails/) raszteres fájlokba (PNG/JPG/TIFF) konvertálni.

**Megmarad a SmartArt megjelenése, ha az egész prezentációt PDF-be konvertálom?**

Igen. A renderelő motor a magas pontosságot célozza a [PDF export](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) során, különféle minőség- és kompatibilitási beállításokkal.