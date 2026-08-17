---
title: Diaelrendezések alkalmazása vagy módosítása PHP-ben
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/php-java/slide-layout/
keywords:
  - diaelrendezés
  - tartalomelrendezés
  - helyőrző
  - prezentáció tervezés
  - dia tervezés
  - nem használt elrendezés
  - lábléc láthatóság
  - cím dia
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
  - prezentáció
  - PHP
  - Aspose.Slides
description: "Alkalmazzon, hozzon létre és módosítson diaelrendezéseket az Aspose.Slides for PHP (Java) segítségével, adjon hozzá helyőrzőket, távolítson el nem használt elrendezéseket, és szabályozza a lábléc láthatóságát."
---
## **Áttekintés**

A diavetítés elrendezése meghatározza a helyőrzők, például címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása egységes szerkezetet ad a diáknak, miközben lehetővé teszi, hogy minden dia a saját tartalmát tartalmazza.

A leggyakoribb elrendezések a következők:

- **Title Slide**: Tartalmaz cím és alcím helyőrzőket.
- **Title and Content**: Tartalmaz egy cím helyőrzőt és egy általános célú tartalom helyőrzőt.
- **Blank**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Megérteni az elrendezés öröklődését**

Egy prezentációnak három kapcsolódó szintje van:

1. A [mester dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös objektumokat.
1. A [elrendezés dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) a mesterhez tartozik, és egy adott helyőrző elrendezést definiál.
1. A [normál dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) egy elrendezést használ, és a diára beírt tartalmat tárolja.

Egy normál dia a témát és a formázást az elrendezéséből örökli, az elrendezés pedig a mesterétől örököl. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát hoznak létre, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál dia része.

Adjon hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diát hozna létre belőle. Egy helyőrző későbbi hozzáadása az elrendezéshez nem ad automatikusan hozzá megfelelő helyőrző alakzatot a már létező normál diákhoz.

Ez a kapcsolat két fontos következménnyel jár:

- Az örökölt formázás vagy a meglévő helyőrző geometria módosítása egy elrendezésen minden olyan diát frissíthet, amely attól függ. Mielőtt szerkesztené egy már használt elrendezést, ellenőrizze a függő diák listáját, és tekintse át a keletkező prezentációt.
- Egy elrendezést, amelyet még használ egy dia, nem lehet eltávolítani. Először rendelje át a függő diákot egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsa el.

További információkért a hierarchia legfelső szintjéről lásd a [Slide Master](/slides/hu/php-java/slide-master/).

## **Elrendezés kiválasztása és alkalmazása**

Használjon elrendezéstípusú megközelítést, ha a prezentáció a standard PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a név alapján történő kiválasztás kevésbé megbízható, hacsak nem a forrás sablont felügyeli.

Az alábbi példa az **Title and Content** elrendezést keresi az első mesterben. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre tér vissza. A második null‑ellenőrzés szükséges, mert egy prezentáció tartalmazhat csak egyedi elrendezéseket. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzák az első normál diára.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Egy dia elrendezésének módosítása nem távolítja el a diára közvetlenül hozzáadott szokásos alakzatokat. Azonban a helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés változhat, ezért ellenőrizze a kimenetet, ha lényegesen eltérő elrendezések között vált.

## **Elrendezés dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy új elrendezés létrehozásához hívja meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterlayoutslidecollection/#add) metódust a cél mester elrendezésgyűjteményén.

Az alábbi példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd egy normál diát hoz létre ezen alapulva. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Csak akkor adjon hozzá elrendezést, ha a sablon valóban szükségelteti egy új, újrahasznosítható struktúrát. Ha már létezik megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezés diához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/) objektumot ad vissza helyőrző alakzatok hozzáadásához egy elrendezéshez.

| PowerPoint helyőrző               | `LayoutPlaceholderManager` metódus |
| --------------------------------- | ---------------------------------- |
| ![Tartalom](content.png)          | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Tartalom (Függőleges)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Szöveg](text.png)               | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Szöveg (Függőleges)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Kép](picture.png)               | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)             | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Táblázat](table.png)            | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online kép](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Az alábbi példa ellenőrzi, hogy a **Blank** elrendezés létezik‑e, négy helyőrzőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides képes a megfelelő helyőrző alakzatokat generálni azon a diasoron.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A helyőrzők az elrendezésen](add_placeholders.png)

{{% alert color="warning" title="Figyelmeztetés" %}}

Az örökölt formázás vagy a meglévő elrendezés helyőrzőinek geometriája módosítása befolyásolhatja a függő diákot. Egy újonnan hozzáadott elrendezéshelyőrző nem kerül utólagos kitöltésre a már létező normál diákba. Tesztelje az elrendezésváltozásokat egy másolat prezentáción, és ellenőrizze minden függő diát.

{{% /alert %}}

## **Nem használt elrendezés diák eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a nem hivatkozott elrendezések eltávolításához. A metódus érintetlenül hagyja a még használt elrendezéseket.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Egy konkrét elrendezés eltávolításához előbb ellenőrizze a [hasDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#hasDependingSlides) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getDependingSlides) metódus visszatérési értékét. Minden függő diát rendelje át, mielőtt meghívná a [LayoutSlide.remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#remove) metódust. Egy használt elrendezés eltávolítására kísérlet [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) hibát vált ki.

## **Lábléc láthatóságának vezérlése egy elrendezés dián**

Egy elrendezés saját lábléc, dia‑sorszám és dátum‑idő helyőrzőkkel rendelkezik. Használja a [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódust ezen helyőrzők vezérléséhez egyetlen elrendezésnél. Ez akkor hasznos, ha például a tartalomelrendezéseknek láblécet kell mutatniuk, míg a címelrendezéseknek nem.

Az alábbi példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a láblécelemeket:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lábléc láthatóságának vezérlése egy mester és annak alá‑rendelt elrendezései között**

Az egységes láblécbeállítások alkalmazásához a mesterhierarchiában használja a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a mesteren, annak függő elrendezés‑diáin és normál diáin is működnek; nem csak egyetlen normál diát céloznak.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Mi a különbség a Mester dia és az Elrendezés dia között?**

A mester dia meghatározza a prezentáció témáját és a megosztott formázást. Az elrendezés dia a mesterhez tartozik, és egy újrahasznosítható helyőrző‑elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és a dia‑specifikus tartalmat tárolják.

**Másolhatok elrendezés diát egy prezentációból a másikba?**

Igen. Használja az [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/globallayoutslidecollection/#addClone) metódust a célgyűjteményhez való másoláshoz. Másoláskor ellenőrizze a betűtípusokat, témákat, képeket és egyéb forrás‑elrendezés által használt erőforrásokat.

**Mi történik, ha egy már használatban lévő elrendezést módosítok?**

A függő diák öröklik az elrendezés változásait, kivéve, ha a formázást vagy az objektumokat lokálisan felülírják. Így a helyőrző geometria és az örökölt stílus sok dián egyszerre megváltozhat. A módosítás előtt használja a [getDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getDependingSlides) metódust a érintett diák azonosításához.

**Mi történik, ha egy még használatban lévő elrendezést eltávolítok?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) hibát dob. Először rendelje át a függő diákot, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a csak nem hivatkozott elrendezések eltávolításához.