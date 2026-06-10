---
title: Diaelrendezések alkalmazása vagy módosítása Androidon
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/androidjava/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szakaszfejléc
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Kezelje és testreszabja a diaelrendezéseket az Aspose.Slides for Android alkalmazásban. Fedezze fel az elrendezéstípusokat, a helyőrzők kezelését és a lábléc láthatóságát Java kódpéldákon keresztül."
---
## **Bevezetés**

A diákialakítás meghatározza a helyőrződobozok elrendezését és a dián megjelenő tartalom formázását. Szabályozza, hogy mely helyőrzők állnak rendelkezésre, és hol jelennek meg. A diákialakítások segítenek gyorsan és egységesen elkészíteni a bemutatókat – legyen szó egyszerű vagy összetettebb anyagról. A PowerPoint leggyakoribb diákialakításai a következők:

**Címdia elrendezés** – Két szöveghelyőrzőt tartalmaz: az egyiket a cím, a másikat az alcím számára.

**Cím és tartalom elrendezés** – Kisebb címhelyőrző található felül, míg alatta nagyobb helyőrző a fő tartalom (például szöveg, felsorolás, diagramok, képek stb.) számára.

**Üres elrendezés** – Nem tartalmaz helyőrzőket, teljes irányítást biztosít a dia teljesen az elejétől történő megtervezéséhez.

A diákialakítások a dia‑mester részei, amely a legfelső szintű dia, és meghatározza a bemutató elrendezésstílusait. A diákialakításokhoz a dia‑mesteren keresztül férhet hozzá és módosíthatja őket – típusa, neve vagy egyedi azonosítója alapján. Alternatív megoldásként egy adott diákialakítást közvetlenül a bemutatóban szerkeszthet.

A slide layoutok kezeléséhez az Aspose.Slides for Android‑ban használhatja a következőket:

- Az olyan metódusok, mint a [getLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) és a [getMasters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getMasters--) a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályban
- Olyan típusok, mint az [ILayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/), az [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterlayoutslidecollection/), az [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), és az [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
További információkért a mesterdiák használatáról tekintse meg a [Dia mester](/slides/hu/androidjava/slide-master/) cikket.
{{% /alert %}}

## **Diákialakítások hozzáadása a bemutatókhoz**

A diák megjelenésének és szerkezetének testreszabásához új diákialakításokat kell hozzáadnia a bemutatóhoz. Az Aspose.Slides for Android lehetővé teszi, hogy ellenőrizze, létezik‑e már egy adott elrendezés, ha szükséges, hozzáadjon egy újat, és azt használja a diák beszúrásához az adott elrendezés alapján.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Érje el az [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterlayoutslidecollection/).  
1. Ellenőrizze, hogy a kívánt diákialakítás már létezik‑e a gyűjteményben. Ha nem, adja hozzá a szükséges diákialakítást.  
1. Adjon hozzá egy üres diát az új diákialakítás alapján.  
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja, hogyan adhat hozzá egy diákialakítást a PowerPoint bemutatóhoz:

```java
// Hozzon létre egy Presentation osztály példányt, amely egy PowerPoint fájlt képvisel.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Végigmenni a diákialakítás típusokon a megfelelő diákialakítás kiválasztásához.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Olyan helyzet, amikor a bemutató nem tartalmazza az összes diákialakítás típust.
        // A bemutató fájl csak Üres és Egyéni elrendezéstípusokat tartalmaz.
        // Azonban az egyéni típusú diákialakítások felismerhető nevekkel rendelkezhetnek,
        // például "Title", "Title and Content", stb., amelyek felhasználhatók diákialakítás kiválasztásához.
        // Emellett támaszkodhat egy halmaz helyőrző alakzat típusra.
        // Például egy Címdiának csak a Cím helyőrző típussal kell rendelkeznie, stb.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Üres dia hozzáadása a hozzáadott diákialakítás segítségével.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // A bemutató mentése lemezre.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Használaton kívüli diákialakítások eltávolítása**

Az Aspose.Slides a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) osztályban biztosítja, amely lehetővé teszi a nem kívánt és használaton kívüli diákialakítások törlését.

Az alábbi Java kód bemutatja, hogyan távolítható el egy diákialakítás a PowerPoint bemutatóból:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Helyőrzők hozzáadása diákialakításokhoz**

Az Aspose.Slides a [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódust biztosítja, amely lehetővé teszi új helyőrzők hozzáadását egy diákialakításhoz.

Ez a kezelő a következő helyőrző típusokhoz tartozó metódusokat tartalmazza:

| PowerPoint helyőrző               | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) metódus |
| --------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)           | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                 | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)     | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)           | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)         | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)               | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)  | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Az alábbi Java kód bemutatja, hogyan lehet új helyőrző alakzatokat hozzáadni az Üres diákialakításhoz:

```java
Presentation presentation = new Presentation();
try {
    // Az Üres elrendezés diát lekéri.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // A diákialakítás helyőrzőkezelőjét lekéri.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Különböző helyőrzőket ad az Üres diákialakításhoz.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Új diát ad hozzá az Üres elrendezéssel.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helyőrzők a diákialakításon](add_placeholders.png)

## **Lábléc láthatóság beállítása egy diákialakításnál**

PowerPoint‑bemutatókban a lábléc elemek (dátum, dia‑szám, egyéni szöveg) megjeleníthetők vagy elrejthetők a diákialakítástól függően. Az Aspose.Slides for Android lehetővé teszi ezen lábléc‑helyőrzők láthatóságának vezérlését. Ez akkor hasznos, ha bizonyos elrendezéseknél lábléc‑információkat akar megjeleníteni, míg másoknál tiszta, minimalista megjelenést szeretne.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezze be a diákialakítás hivatkozását az indexe alapján.  
1. Állítsa be a dia lábléc helyőrzőt láthatóvá.  
1. Állítsa be a dia szám helyőrzőt láthatóvá.  
1. Állítsa be a dátum‑idő helyőrzőt láthatóvá.  
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja, hogyan állítható be egy dia lábléc láthatósága és végezhetők el a kapcsolódó feladatok:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Gyermek lábléc láthatóság beállítása egy dián**

PowerPoint‑bemutatókban a lábléc elemek (dátum, dia‑szám, egyéni szöveg) a mesterdia szintjén vezérelhetők, ezáltal egységesítve az összes diákialakítást. Az Aspose.Slides for Android lehetővé teszi, hogy a mesterdián állítsa be ezen lábléc‑helyőrzők láthatóságát és tartalmát, majd ezek a beállítások automatikusan átkerülnek az összes gyermek‑diákialakításra. Ez biztosítja az egységes lábléc‑információkat a teljes bemutatóban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen hivatkozást a mesterdiára az indexe alapján.  
1. Állítsa be a mester és az összes gyermek lábléc helyőrzőt láthatóvá.  
1. Állítsa be a mester és az összes gyermek dia szám helyőrzőt láthatóvá.  
1. Állítsa be a mester és az összes gyermek dátum‑idő helyőrzőt láthatóvá.  
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja ezt a műveletet:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség a mesterdia és a diákialakítás között?**

A mesterdia határozza meg a teljes témát és az alapértelmezett formázást, míg a diákialakítások specifikus helyőrző‑elrendezéseket definiálnak a különböző tartalomtípusokhoz.

**Másolhatok egy diákialakítást egy bemutatóból a másikba?**

Igen, egy diákialakítást klónozhat a forrás‑bemutató diákialakítás‑gyűjteményéből (a [getLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) metódus segítségével), majd a `addClone` metódussal beillesztheti egy másik bemutatóba.

**Mi történik, ha törlök egy diákialakítást, amelyet még egy dia használ?**

Ha megpróbál törölni egy olyan diákialakítást, amelyet legalább egy dia még hivatkozik, az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülése érdekében használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust, amely csak a nem használt diákialakításokat távolítja el biztonságosan.