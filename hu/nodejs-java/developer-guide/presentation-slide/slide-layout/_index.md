---
title: Diaelrendezések alkalmazása vagy módosítása JavaScriptben
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/nodejs-java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutatótervezés
- diatervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szakaszcím
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje és testreszabja a diaelrendezéseket az Aspose.Slides for Node.js-ben. Fedezze fel az elrendezéstípusokat, a helyőrző vezérlést és a lábléc láthatóságát kódpéldákon keresztül."
---
## **Bevezetés**

A diaelrendezés meghatározza a helyőrződobozok elrendezését és a dia tartalmának formázását. Ez szabályozza, hogy mely helyőrzők érhetők el és hol jelennek meg. A diaelrendezések segítenek gyorsan és következetesen megtervezni a bemutatókat – akár egyszerű, akár összetettebb anyagot hozol létre. A PowerPointban a leggyakrabban használt diaelrendezések a következők:

**Címdia elrendezés** – Két szöveghelyőrzőt tartalmaz: egyet a címhez és egyet az alcímhez.

**Cím és tartalom elrendezés** – Kisebb címhelyőrzőt mutat a tetején, és alatta egy nagyobbat a fő tartalomhoz (például szöveg, felsorolás, diagramok, képek és egyéb).

**Üres elrendezés** – Nem tartalmaz helyőrzőket, így teljesen saját kezűleg tervezheted meg a diát.

A diaelrendezések a dia mester részei, amely a legfelső szintű dia, és meghatározza a bemutató elrendezési stílusait. A dia mesteren keresztül érheted el és módosíthatod az elrendezési diát – típus, név vagy egyedi azonosító alapján. Alternatívaként közvetlenül a bemutatóban szerkeszthetsz egy konkrét elrendezési diát.

A Diaelrendezésekkel való munkához az Aspose.Slides for Node.js-ben használhatod a következőket:

- Olyan metódusok, mint a [getLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getLayoutSlides) és a [getMasters](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getMasters) a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban
- Olyan típusok, mint a [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/), a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterlayoutslidecollection/), a [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/), és a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
A mesterdiák kezelésével kapcsolatos további információkért tekintsd meg a [Slide Master](/slides/hu/nodejs-java/slide-master/) cikket.
{{% /alert %}}

## **Diaelrendezések hozzáadása a bemutatókhoz**

A diák megjelenésének és szerkezetének testreszabásához új elrendezési diák hozzáadására lehet szükség a bemutatóba. Az Aspose.Slides for Node.js lehetővé teszi, hogy ellenőrizd, létezik-e már egy adott elrendezés, szükség esetén újat adj hozzá, és ezzel elrendezésen alapuló diákat szúrj be.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
2. Érj hozzá a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterlayoutslidecollection/) gyűjteményhez.  
3. Ellenőrizd, hogy a kívánt elrendezési dia már létezik-e a gyűjteményben. Ha nem, add hozzá a szükséges elrendezési diát.  
4. Adj egy üres diát az új elrendezési dia alapján.  
5. Mentsd el a bemutatót.

Az alábbi JavaScript kód bemutatja, hogyan adhatunk hozzá egy diaelrendezést egy PowerPoint bemutatóhoz:

```js
// Példányosítsa a Presentation osztályt, amely egy PowerPoint fájlt képvisel.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Végigjárja az elrendezési diatípusokat egy elrendezési dia kiválasztásához.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Olyan helyzet, amikor a bemutató nem tartalmazza az összes elrendezési típust.
        // A bemutató fájl csak Üres és Egyéni elrendezéstípusokat tartalmaz.
        // Azonban az egyéni típusú elrendezési diák felismerhető nevekkel rendelkezhetnek,
        // például "Title", "Title and Content" stb., amelyeket fel lehet használni az elrendezési dia kiválasztásához.
        // Egy helyőrző alakzat típusok készletére is támaszkodhat.
        // Például egy címdiának csak a Title helyőrző típusa kell, hogy legyen, és így tovább.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Üres diát ad hozzá a hozzáadott elrendezési diával.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Mentse a bemutatót a lemezen.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Használaton kívüli elrendezési diák eltávolítása**

Az Aspose.Slides a [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) osztályból a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust biztosítja, amely lehetővé teszi a nem kívánt és nem használt elrendezési diák törlését.

Az alábbi JavaScript kód bemutatja, hogyan távolítható el egy elrendezési dia egy PowerPoint bemutatóból:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Helyőrzők hozzáadása a diaelrendezésekhez**

Az Aspose.Slides a [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) metódust biztosítja, amely lehetővé teszi új helyőrzők hozzáadását egy elrendezési diához.

Ez a kezelő a következő helyőrző típusokhoz tartalmaz metódusokat:

| PowerPoint helyőrző | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/) metódus |
| ------------------- | --------------------------------------- |
| Tartalom | addContentPlaceholder(float x, float y, float width, float height) |
| Tartalom (függőleges) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| Szöveg | addTextPlaceholder(float x, float y, float width, float height) |
| Szöveg (függőleges) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| Kép | addPicturePlaceholder(float x, float y, float width, float height) |
| Diagram | addChartPlaceholder(float x, float y, float width, float height) |
| Táblázat | addTablePlaceholder(float x, float y, float width, float height) |
| SmartArt | addSmartArtPlaceholder(float x, float y, float width, float height) |
| Média | addMediaPlaceholder(float x, float y, float width, float height) |
| Online kép | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Az alábbi JavaScript kód bemutatja, hogyan adhatunk új helyőrző alakzatokat az Üres elrendezési diához:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az Üres elrendezési diát.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Szerezze meg az elrendezési dia helyőrzőkezelőjét.
    let placeholderManager = layout.getPlaceholderManager();

    // Különböző helyőrzőket ad az Üres elrendezési diához.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Új diát ad hozzá az Üres elrendezéssel.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helyőrzők az elrendezési dián](add_placeholders.png)

## **Lábléc láthatóságának beállítása egy elrendezési dián**

PowerPoint bemutatókban a lábléc elemek, mint a dátum, dia száma és egyéni szöveg megjeleníthetők vagy elrejthetők a diaelrendezéstől függően. Az Aspose.Slides for Node.js lehetővé teszi ezen lábléchez tartozó helyőrzők láthatóságának szabályozását. Ez akkor hasznos, ha bizonyos elrendezéseknek lábléc információt kell mutatniuk, míg mások tiszták és minimálisak maradnak.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
2. Szerezz egy elrendezési dia hivatkozást az indexe alapján.  
3. Állítsd a dia lábléc helyőrzőt láthatóvá.  
4. Állítsd a dia száma helyőrzőt láthatóvá.  
5. Állítsd a dátum-idő helyőrzőt láthatóvá.  
6. Mentsd el a bemutatót.

Az alábbi JavaScript kód bemutatja, hogyan állítható be egy dia láblécének láthatósága és a kapcsolódó feladatok:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Gyermek lábléc láthatóságának beállítása egy diához**

PowerPoint bemutatókban a lábléc elemek, mint a dátum, dia száma és egyéni szöveg a mesterdia szintjén szabályozhatók, hogy következetességet biztosítsanak az összes elrendezési dián. Az Aspose.Slides for Node.js lehetővé teszi ezen lábléc helyőrzők láthatóságának és tartalmának beállítását a mesterdian, majd ezen beállítások terjesztését az összes gyermek elrendezési diára. Ez a megközelítés egységes lábléc információt biztosít a teljes bemutatóban.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
2. Szerezz egy hivatkozást a mesterdiára az indexe alapján.  
3. Állítsd a mester és az összes gyermek lábléc helyőrzőt láthatóvá.  
4. Állítsd a mester és az összes gyermek dia szám helyőrzőt láthatóvá.  
5. Állítsd a mester és az összes gyermek dátum-idő helyőrzőt láthatóvá.  
6. Mentsd el a bemutatót.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség a mesterdia és az elrendezési dia között?**  
A mesterdia határozza meg a teljes témát és az alapértelmezett formázást, míg az elrendezési diák a különböző tartalomtípusokhoz tartozó helyőrzők konkrét elrendezését definiálják.

**Másolhatok elrendezési diát egyik bemutatóból a másikba?**  
Igen, egy bemutató elrendezési dia gyűjteményéből (amely a [getLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getLayoutSlides) metóduson keresztül érhető el) klónozhatsz egy elrendezési diát, és a `addClone` metódussal beillesztheted egy másik bemutatóba.

**Mi történik, ha törlök egy elrendezési diát, amelyet még egy dia használ?**  
Ha megpróbálsz törölni egy olyan elrendezési diát, amelyre a bemutatóban legalább egy dia hivatkozik, az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülése érdekében használd a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, amely biztonságosan csak a nem használt elrendezési diákat távolítja el.