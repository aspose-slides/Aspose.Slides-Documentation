---
title: Alkalmazza vagy módosítsa a diák elrendezéseit Java-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/java/slide-layout/
keywords:
- dia elrendezés
- tartalom elrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
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
- Java
- Aspose.Slides
description: "Kezelje és testreszabja a diák elrendezéseit az Aspose.Slides for Java-ban. Fedezze fel az elrendezéstípusokat, a helyőrzők vezérlését és a lábléc láthatóságát Java kódpéldákon keresztül."
---
## **Bevezetés**

A diák elrendezése meghatározza a helyőrző dobozok elrendezését és a dián lévő tartalom formázását. Szabályozza, hogy mely helyőrzők állnak rendelkezésre, és hol jelennek meg. A diák elrendezései segítenek gyorsan és egységesen tervezni a bemutatókat – legyen szó egyszerű vagy összetettebb anyagról. A PowerPoint leggyakoribb diák elrendezései:

**Címlap elrendezés** – Két szöveghelyőrzőt tartalmaz: egyet a címnek és egyet az alcímnek.

**Cím és Tartalom elrendezés** – Kisebb címhelyőrző a tetején, valamint egy nagyobb fő tartalomhelyőrző alatta (például szöveg, felsorolás, diagram, kép és egyebek).

**Üres elrendezés** – Nem tartalmaz helyőrzőket, teljes szabadságot biztosít a dia tervezéséhez.

A diák elrendezései a dia mester részei, amely a bemutató stílusait meghatározó legfelső szintű dia. A mesteren keresztül érheti el és módosíthatja az elrendezési diákat – legyen szó típusról, névről vagy egyedi azonosítóról. Alternatívaként közvetlenül szerkeszthet egy adott elrendezési diát a bemutatóban.

A slide layoutok kezeléséhez az Aspose.Slides for Java-ban használhatja:

- Olyan metódusok, mint a [getLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getLayoutSlides--) és a [getMasters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasters--) a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályban
- Típusok, például az [ILayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/), az [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterlayoutslidecollection/), az [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/) és az [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
A master diákok használatáról további információkért tekintse meg a [Slide Master](/slides/hu/java/slide-master/) cikket.
{{% /alert %}}

## **Diákelrendezések hozzáadása a bemutatókhoz**

A diák megjelenésének és szerkezetének testreszabásához új elrendezési diákot adhat a bemutatóhoz. Az Aspose.Slides for Java lehetővé teszi, hogy ellenőrizze, létezik‑e már egy adott elrendezés, szükség esetén újat adjon hozzá, majd ezen elrendezés alapján diát szúrjon be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Érje el az [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterlayoutslidecollection/) gyűjteményt.
1. Ellenőrizze, hogy a kívánt elrendezési dia már létezik‑e a gyűjteményben. Ha nem, adja hozzá a szükséges elrendezést.
1. Hozzon létre egy üres diát az új elrendezés alapján.
1. Mentse el a bemutatót.

Az alábbi Java‑kód bemutatja, hogyan adjon elrendezést egy PowerPoint‑bemutatóhoz:

```java
// Példányosítja a Presentation osztályt, amely egy PowerPoint fájlt képvisel.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Végigjárja az elrendezési diák típusait egy elrendezési dia kiválasztásához.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Olyan helyzet, amikor a bemutató nem tartalmaz minden elrendezési típust.
        // A bemutató fájl csak Üres és Egyéni elrendezési típusokat tartalmaz.
        // Azonban az egyéni típusú elrendezési diák felismerhető nevekkel rendelkezhetnek,
        // mint például a "Title", "Title and Content" stb., amelyeket felhasználhatunk az elrendezési dia kiválasztásához.
        // Emellett támaszkodhat egy helyőrző alakzat típusok halmazára.
        // Például egy Címdia csak a Title helyőrző típussal rendelkezik, és így tovább.
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

    // Üres diát ad hozzá a hozzáadott elrendezési diával.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Elmenti a bemutatót a lemezre.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nem használt diákelrendezések eltávolítása**

Az Aspose.Slides a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) osztályból biztosítja, amely lehetővé teszi a nem kívánt és nem használt elrendezési diák törlését.

Az alábbi Java‑kód megmutatja, hogyan távolítson el egy elrendezési diát egy PowerPoint‑bemutatóból:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Helyőrzők hozzáadása diákelrendezésekhez**

Az Aspose.Slides a [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódust kínálja, amely lehetővé teszi új helyőrzők hozzáadását egy elrendezési diához.

Ez a kezelő a következő helyőrző típusokra tartalmaz metódusokat:

| PowerPoint helyőrző                | ILayoutPlaceholderManager metódus |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Az alábbi Java‑kód bemutatja, hogyan adjon új helyőrzőalakzatokat az Üres elrendezési diához:

```java
Presentation presentation = new Presentation();
try {
    // A Blank elrendezési dia lekérése.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Az elrendezési dia helyőrzőkezelőjének lekérése.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Különböző helyőrzők hozzáadása a Blank elrendezési diához.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Új dia hozzáadása a Blank elrendezéssel.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helyőrzők az elrendezési dián](add_placeholders.png)

## **Lábléc láthatóság beállítása egy diákelrendezésnél**

PowerPoint‑bemutatókban a lábléc elemek – például dátum, dia száma és egyéni szöveg – a diák elrendezésétől függően megjeleníthetők vagy elrejthetők. Az Aspose.Slides for Java lehetővé teszi ezen lábléchelyőrzők láthatóságának vezérlését. Ez akkor hasznos, ha egyes elrendezések láblécinformációt jelenítenek meg, míg mások tiszták és minimalista megjelenést igényelnek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen be egy elrendezési dia hivatkozást a indexe alapján.
1. Állítsa a dia lábléc helyőrzőt láthatóvá.
1. Állítsa a dia szám helyőrzőt láthatóvá.
1. Állítsa a dátum‑idő helyőrzőt láthatóvá.
1. Mentse el a bemutatót.

Az alábbi Java‑kód megmutatja, hogyan állítsa be egy dia láblécének láthatóságát és végrehajtson kapcsolódó feladatokat:

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

PowerPoint‑bemutatókban a lábléc elemek – például dátum, dia száma és egyéni szöveg – a master dia szintjén is szabályozhatók, így biztosítható az egységes megjelenés az összes elrendezési dian. Az Aspose.Slides for Java lehetővé teszi ezeknek a lábléchelyőrzőknek a láthatóságát és tartalmát a master dián beállítani, majd ezeket a beállításokat minden gyermek elrendezési diára továbbítani. Ez a megközelítés biztosítja a láblécinformációk egységes megjelenését a teljes bemutatóban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen be egy hivatkozást a master diára a indexe alapján.
1. Állítsa a master és az összes gyermek lábléc helyőrzőt láthatóvá.
1. Állítsa a master és az összes gyermek dia szám helyőrzőt láthatóvá.
1. Állítsa a master és az összes gyermek dátum‑idő helyőrzőt láthatóvá.
1. Mentse el a bemutatót.

Az alábbi Java‑kód demonstrálja ezt a műveletet:

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

**Mi a különbség egy master dia és egy diákelrendezés között?**

A master dia határozza meg az általános sablont és az alapértelmezett formázást, míg a diákelrendezések konkrét helyőrző‑elrendezéseket definiálnak a különböző tartalomtípusokhoz.

**Másolhatok egy diákelrendezést egy bemutatóból egy másikba?**

Igen, a [getLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getLayoutSlides--) metódussal elérhető elrendezési dia‑gyűjteményből klónozhat egy diákelrendezést, majd a `addClone` metódussal beillesztheti egy másik bemutatóba.

**Mi történik, ha egy diákelrendezést törlök, amelyet még egy dia használ?**

Ha egy olyan elrendezési diát próbál törölni, amelyet legalább egy másik dia még hivatkozik, az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülése érdekében használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust, amely biztonságosan csak a nem használt elrendezési diákot távolítja el.