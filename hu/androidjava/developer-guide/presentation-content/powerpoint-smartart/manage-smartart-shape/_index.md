---
title: SmartArt grafika kezelése prezentációkban Androidon
linktitle: SmartArt grafika
type: docs
weight: 20
url: /hu/androidjava/manage-smartart-shape/
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
- Android
- Java
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stílusozását az Aspose.Slides for Android segítségével, tömör Java kódpéldákkal és teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adjon SmartArt alakzatot egy diára, hogyan érjen el létező SmartArt alakzatokat, hogyan keressen SmartArt‑ot egy adott elrendezéstípus szerint, és hogyan frissítse a megjelenését a SmartArt stílus vagy színstílus megváltoztatásával.

A példák bemutatják, hogyan dolgozzunk SmartArt alakzatokkal a prezentációdia alakzategyűjteményén keresztül, hogyan ellenőrizzük, hogy egy alakzat SmartArt‑e, majd módosítsuk vagy vizsgáljuk meg a tulajdonságait.

## **SmartArt alakzat létrehozása**
Aspose.Slides for Android via Java biztosít API‑t SmartArt alakzatok létrehozásához. SmartArt alakzat létrehozásához egy dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciáját a Index használatával.  
1. [Adjon hozzá SmartArt alakzatot](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) a [LayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType) beállításával.  
1. Mentse a módosított prezentációt PPTX fájlként.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat hozzáadása
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Prezentáció mentése
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat hozzáadva a diára**|

## **SmartArt alakzat elérése egy dián**
A következő kódot a prezentációdiára hozzáadott SmartArt alakzatok elérésére használjuk. A példakódban végigjárjuk a dia minden alakzatát, és ellenőrizzük, hogy [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) alakzat‑e. Ha az alakzat SmartArt típusú, akkor átkonvertáljuk egy [**SmartArt**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) példányra.

```java
// Töltsük be a kívánt prezentációt
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Bejárjuk az első dián lévő minden alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ellenőrizzük, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt)
        {
            // Átkonvertáljuk az alakzatot SmartArtEx‑re
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt alakzat elérése adott elrendezéstípussal**
A következő mintakód segít hozzáférni a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) alakzathoz egy adott LayoutType használatával. Vegye figyelembe, hogy a SmartArt LayoutType‑ját nem módosíthatja, mivel csak olvasható, és csak a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) alakzat hozzáadása során állítódik be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dián lévő minden alakzatot.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) típusú‑e, és ha igen, konvertálja a kijelölt alakzatot SmartArt‑ra.  
1. Ellenőrizze a SmartArt alakzatot a megadott LayoutType‑nal, majd hajtsa végre a szükséges műveleteket.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Bejárjuk az első dián lévő minden alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ellenőrizzük, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt)
        {
            // Átkonvertáljuk az alakzatot SmartArtEx-re
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt elrendezés ellenőrzése
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt alakzat stílusának módosítása**
Ebben a példában megtanuljuk, hogyan módosítsuk a gyors stílust bármely SmartArt alakzaton.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt Shape‑tal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dián lévő minden alakzatot.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) típusú‑e, és ha igen, konvertálja a kijelölt alakzatot SmartArt‑ra.  
1. Keresse meg a SmartArt alakzatot a megadott Stílussal.  
1. Állítsa be az új Stílust a SmartArt alakzatra.  
1. Mentse a prezentációt.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bejárjuk az első dián lévő minden alakzatot
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizzük, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átkonvertáljuk az alakzatot SmartArtEx-re
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt stílus ellenőrzése
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt stílusának módosítása
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Prezentáció mentése
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat módosított Stílussal**|

## **SmartArt alakzat színstílusának módosítása**
Ebben a példában megtanuljuk, hogyan változtassuk meg a színstílust bármely SmartArt alakzaton. A következő mintakódban hozzáférünk a SmartArt alakzathoz egy adott színstílussal, és módosítjuk a stílusát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt Shape‑tal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dián lévő minden alakzatot.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) típusú‑e, és ha igen, konvertálja a kijelölt alakzatot SmartArt‑ra.  
1. Keresse meg a SmartArt alakzatot a megadott Színstílussal.  
1. Állítsa be az új Színstílust a SmartArt alakzatra.  
1. Mentse a prezentációt.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bejárjuk az első dián lévő minden alakzatot
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizzük, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átkonvertáljuk az alakzatot SmartArtEx-re
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt szín típusának ellenőrzése
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt szín típusának módosítása
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Prezentáció mentése
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Ábra: SmartArt alakzat módosított Színstílussal**|

## **GYIK**

**Animálhatom a SmartArt‑ot egyetlen objektumként?**  
Igen. A SmartArt egy alakzat, így a [standard animációkat](/slides/hu/androidjava/powerpoint-animation/) alkalmazhatja az animációs API‑n keresztül (belépés, kilépés, hangsúly, mozgási pályák), akárcsak más alakzatoknál.

**Hogyan találhatok meg egy adott SmartArt‑ot egy dián, ha nem ismerem a belső azonosítóját?**  
Állítsa be és használja a Alternatív szöveget (AltText), ezután keresse meg az alakzatot ezzel az értékkel – ez a javasolt módja a cél alakzat megtalálásának.

**Csoportosíthatom a SmartArt‑ot más alakzatokkal?**  
Igen. A SmartArt‑ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/androidjava/group/).

**Hogyan kapok képet egy adott SmartArt‑ról (pl. előnézethez vagy jelentéshez)?**  
Exportáljon egy miniatűr képet/thumbnail‑t az alakzatról; a könyvtár képes [egyes alakzatok renderelésére](/slides/hu/androidjava/create-shape-thumbnails/) raszteres fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha a teljes prezentációt PDF‑be konvertáljuk?**  
Igen. A renderelő motor magas pontosságra törekszik a [PDF export](/slides/hu/androidjava/convert-powerpoint-to-pdf/) során, különböző minőség‑ és kompatibilitási beállításokkal.