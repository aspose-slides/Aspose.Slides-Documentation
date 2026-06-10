---
title: SmartArt grafika kezelése prezentációkban Java használatával
linktitle: SmartArt grafika
type: docs
weight: 20
url: /hu/java/manage-smartart-shape/
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
- Java
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stilizálását Java-ban az Aspose.Slides használatával, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozott módon hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ebben a cikkben bemutatjuk, hogyan lehet SmartArt alakzatot hozzáadni egy diára, elérni a meglévő SmartArt alakzatokat, megtalálni a SmartArtot egy adott elrendezéstípus szerint, és frissíteni a megjelenését a SmartArt stílus vagy színstílus megváltoztatásával.

Az példák bemutatják, hogyan dolgozhatunk SmartArt alakzatokkal a prezentáció diájának alakzatgyűjteményén keresztül, hogyan ellenőrizhetjük, hogy egy alakzat SmartArt‑e, majd módosíthatjuk vagy vizsgálhatjuk meg annak tulajdonságait.

## **SmartArt alakzat létrehozása**

Az Aspose.Slides for Java biztosítja az API‑t a SmartArt alakzatok létrehozásához. Egy SmartArt alakzat létrehozásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciáját az Index használatával.  
1. [SmartArt alakzat hozzáadása](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) a [Elrendezéstípus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType) beállításával.  
1. Mentse a módosított prezentációt PPTX fájlként.

```java
// Példányosítsa a Presentation osztályt
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
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

Az alábbi kód a prezentáció diájára hozzáadott SmartArt alakzatok elérésére szolgál. A mintakódban végigjárjuk a dia minden alakzatát, és ellenőrizni fogjuk, hogy egy alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) típusú‑e. Ha igen, akkor a [**SmartArt**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) példányra konvertáljuk.

```java
// Töltse be a kívánt prezentációt
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Járja be az első dia minden alakzatát
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt)
        {
            // Alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt alakzat elérése egy adott elrendezéstípussal**

Az alábbi mintakód segít hozzáférni a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) alakzathoz egy adott Elrendezéstípussal. Kérjük, vegye figyelembe, hogy a SmartArt Elrendezéstípusa nem módosítható, mivel csak olvasható, és csak a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) alakzat hozzáadásakor állítódik be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dia minden alakzatát.  
1. Ellenőrizze, hogy az alakzat [SmartArt] típusú‑e, és ha igen, akkor alakítsa át a kijelölt alakzatot SmartArt‑ra.  
1. Ellenőrizze a SmartArt alakzatot a megadott Elrendezéstípussal, és hajtsa végre a szükséges műveleteket azt követően.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Járja be az első dia minden alakzatát
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt)
        {
            // Alakzat típuskonvertálása SmartArtEx-re
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

Ebben a példában megtanuljuk, hogyan változtassuk meg a gyors stílust egy SmartArt alakzaton.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dia minden alakzatát.  
1. Ellenőrizze, hogy az alakzat [SmartArt] típusú‑e, és ha igen, akkor alakítsa át a kijelölt alakzatot SmartArt‑ra.  
1. Keresse meg a SmartArt alakzatot a megadott Stílussal.  
1. Állítsa be az új Stílust a SmartArt alakzatra.  
1. Mentse a prezentációt.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dia minden alakzatát bejárja
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakzat típuskonvertálása SmartArtEx-re
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

Ebben a példában megtanuljuk, hogyan változtassuk meg egy SmartArt alakzat színstílusát. A következő mintakódban elérjük a SmartArt alakzatot egy adott színstílussal, és módosítjuk annak stílusát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.  
1. Szerezze meg az első dia referenciáját az Index használatával.  
1. Járja be az első dia minden alakzatát.  
1. Ellenőrizze, hogy az alakzat [SmartArt] típusú‑e, és ha igen, akkor alakítsa át a kijelölt alakzatot SmartArt‑ra.  
1. Keresse meg a SmartArt alakzatot a megadott Színstílussal.  
1. Állítsa be az új Színstílust a SmartArt alakzatra.  
1. Mentse a prezentációt.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dia minden alakzatát bejárja
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt szín típus ellenőrzése
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

**Animálhatom a SmartArtot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [standard animációkat](/slides/hu/java/powerpoint-animation/) alkalmazhatja az animációs API‑val (belépés, kilépés, hangsúlyozás, mozgási útvonalak), akárcsak más alakzatoknál.

**Hogyan találhatok meg egy adott SmartArtot a dián, ha nem ismerem a belső ID‑jét?**

Állítsa be és használja az alternatív szöveget (AltText), majd keresse az alakzatot ezen az értéken – ez a javasolt módszer a cél alakzat megtalálására.

**Csoportosíthatom a SmartArtot más alakzatokkal?**

Igen. A SmartArtot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/java/group/).

**Hogyan szerezhetek képet egy adott SmartArtról (pl. előnézethez vagy jelentéshez)?**

Exportáljon egy bélyegkép/képet az alakzatról; a könyvtár képes [egyedi alakzatok renderelésére](/slides/hu/java/create-shape-thumbnails/) raszteres fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha az egész prezentációt PDF‑be konvertáljuk?**

Igen. A renderelő motor a magas hűségre törekszik a [PDF export](/slides/hu/java/convert-powerpoint-to-pdf/) során, különböző minőség- és kompatibilitási beállításokkal.