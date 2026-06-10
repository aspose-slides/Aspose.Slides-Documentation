---
title: Diaelrendezések alkalmazása vagy módosítása PHP-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/php-java/slide-layout/
keywords:
- diaelrendezés
- tartalom elrendezés
- helyettesítő
- prezentáció tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakasz fejléc
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
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje és testreszabja a diaelrendezéseket az Aspose.Slides for PHP-ban Java használatával. Fedezze fel az elrendezéstípusokat, a helyettesítők vezérlését és a lábléc láthatóságát kódpéldákon keresztül."
---
## **Bevezetés**

A diaelrendezés meghatározza a helyettesítő dobozok elrendezését és a dia tartalmának formázását. Ez szabályozza, mely helyettesítők állnak rendelkezésre és hol jelennek meg. A diák elrendezései segítenek gyorsan és konzisztensen tervezni a prezentációkat – legyen szó egyszerű vagy összetettebb anyagról. A PowerPointban a leggyakoribb diák elrendezései a következők:

**Címdiára elrendezés** – Két szöveges helyettesítőt tartalmaz: egyet a címnek és egyet az alcímmnek.

**Cím és tartalom elrendezés** – Tartalmaz egy kisebb címhelyettesítőt a tetején és egy nagyobbat alatta a fő tartalomhoz (például szöveg, felsorolás, diagramok, képek, stb.).

**Üres elrendezés** – Nem tartalmaz helyettesítőket, teljes ellenőrzést biztosít a dia nulláról való tervezéséhez.

A diák elrendezései a dia-mester részei, amely a legfelső szintű dia, és meghatározza a prezentáció elrendezési stílusait. A diák elrendezéseihez a dia-mesteren keresztül férhet hozzá és módosíthatja őket – típus, név vagy egyedi azonosító alapján. Alternatívaként egy adott elrendezési diát közvetlenül a prezentáción belül is szerkeszthet.

A slide elrendezésekkel való munkához az Aspose.Slides for PHP-ban használhatja:
- A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban található [getLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getLayoutSlides) és [getMasters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasters) metódusok
- Olyan típusok, mint a [LayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/), a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterlayoutslidecollection/), a [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/), és a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
A mesterdiák használatáról további információkért tekintse meg a [Slide Master](/slides/hu/php-java/slide-master/) cikket.
{{% /alert %}}

## **Diák elrendezésének hozzáadása a prezentációkhoz**

A diák megjelenésének és szerkezetének testreszabásához előfordulhat, hogy új elrendezési diákat kell hozzáadni egy prezentációhoz. Az Aspose.Slides for PHP lehetővé teszi, hogy ellenőrizze, létezik-e már egy adott elrendezés, szükség esetén hozzáadjon újat, és azt használja a diák beillesztéséhez.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Hozzáférés a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterlayoutslidecollection/) gyűjteményhez.
1. Ellenőrizze, hogy a kívánt elrendezési dia már létezik-e a gyűjteményben. Ha nem, adja hozzá a szükséges elrendezési diát.
1. Adjon hozzá egy üres diát az új elrendezési diára alapozva.
1. Mentse a prezentációt.

```php
// Példányosítja a Presentation osztályt, amely egy PowerPoint fájlt reprezentál.
$presentation = new Presentation("Sample.pptx");
try {
    // Végigmegy a diák elrendezés típusain a megfelelő elrendezési dia kiválasztásához.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Egy olyan helyzet, amikor a prezentáció nem tartalmaz minden elrendezés típust.
        // A prezentációfájl csak Üres és Egyéni elrendezés típusokat tartalmaz.
        // Azonban az egyéni típusú elrendezési diák felismert nevekkel rendelkezhetnek,
        // "Cím", "Cím és tartalom", stb., amelyeket fel lehet használni az elrendezési dia kiválasztására.
        // Használhatja továbbá a helyettesítő alakzat típusok halmazát.
        // Például egy Cím dia csak a Cím helyettesítő típust tartalmazza, és így tovább.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Üres diát ad hozzá a hozzáadott elrendezési dia használatával.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // A prezentációt lemezre menti.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Használaton kívüli elrendezési diák eltávolítása**

Az Aspose.Slides a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztályból a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust biztosítja, amely lehetővé teszi a nem kívánt és használaton kívüli elrendezési diák törlését.

Az alábbi PHP kód bemutatja, hogyan lehet eltávolítani egy elrendezési diát egy PowerPoint prezentációból:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Helyettesítők hozzáadása a diák elrendezéséhez**

Az Aspose.Slides a [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getPlaceholderManager) metódust biztosítja, amely lehetővé teszi új helyettesítők hozzáadását egy elrendezési diához.

Ez a kezelő a következő helyettesítő típusokhoz tartalmaz metódusokat:

| PowerPoint helyettesítő | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/) metódus |
| ----------------------- | ------------------------------------------------------------ |
| ![Tartalom](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Tartalom (függőleges)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Szöveg](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Szöveg (függőleges)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Kép](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Táblázat](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online kép](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Az alábbi PHP kód bemutatja, hogyan adhatunk új helyettesítő alakzatokat az Üres elrendezésű diához:

```php
$presentation = new Presentation();
try {
    // Szerezze be az Üres elrendezési diát.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Szerezze be az elrendezési dia helyettesítőkezelőjét.
    $placeholderManager = $layout->getPlaceholderManager();

    // Különböző helyettesítőket ad az Üres elrendezési diához.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Új diát ad hozzá az Üres elrendezéssel.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A helyettesítők az elrendezési diámon](add_placeholders.png)

## **Lábléc láthatóságának beállítása egy elrendezési dián**

PowerPoint prezentációkban a lábléc elemei, mint a dátum, a dia száma és az egyéni szöveg, a diák elrendezésétől függően megjeleníthetők vagy elrejthetők. Az Aspose.Slides for PHP lehetővé teszi ezen lábléc helyettesítők láthatóságának vezérlését. Ez akkor hasznos, ha egyes elrendezéseknek láblécinformációt szeretne megjeleníteni, míg mások tiszták és minimalizáltak maradnak.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen be egy elrendezési dia hivatkozást a indexe alapján.
1. Állítsa be a dia lábléc helyettesítőt láthatóvá.
1. Állítsa be a dia szám helyettesítőt láthatóvá.
1. Állítsa be a dátum‑idő helyettesítőt láthatóvá.
1. Mentse a prezentációt.

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Gyermek lábléc láthatóságának beállítása egy dián**

PowerPoint prezentációkban a lábléc elemei, mint a dátum, a dia száma és az egyéni szöveg, a mesterdia szintjén is szabályozhatók, hogy egységességet biztosítsanak minden elrendezési dián. Az Aspose.Slides for PHP lehetővé teszi ezen lábléc helyettesítők láthatóságának és tartalmának beállítását a mesterdian, és ezen beállítások propagálását az összes gyermek elrendezési diára. Ez a megközelítés egységes láblécinformációt biztosít a teljes prezentációban.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a mesterdiára az indexe alapján.
1. Állítsa a mester és az összes gyermek lábléc helyettesítőt láthatóvá.
1. Állítsa a mester és az összes gyermek dia szám helyettesítőt láthatóvá.
1. Állítsa a mester és az összes gyermek dátum‑idő helyettesítőt láthatóvá.
1. Mentse a prezentációt.

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Mi a különbség a mesterdia és az elrendezési dia között?**

A mesterdia meghatározza az általános témát és az alapértelmezett formázást, míg az elrendezési diák meghatározzák a helyettesítők konkrét elrendezését a különböző tartalomtípusok számára.

**Másolhatok elrendezési diát egy prezentációból egy másikba?**

Igen, klónozhat egy elrendezési diát egy prezentáció elrendezési dia gyűjteményéből, amely a [getLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getLayoutSlides) metóduson keresztül érhető el, és beillesztheti egy másik prezentációba az `addClone` metódus használatával.

**Mi történik, ha egy elrendezési diát törlök, amely még egy diához van rendelve?**

Ha megpróbál törölni egy elrendezési diát, amelyet még legalább egy dia használ, az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülése érdekében használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, amely biztonságosan csak a nem használt elrendezési diát távolítja el.