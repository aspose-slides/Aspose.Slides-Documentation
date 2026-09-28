---
title: Diaelrendezések alkalmazása vagy módosítása PHP-ben
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
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for PHP Java-on keresztül, helyettesítők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának vezérlése."
---
## **Áttekintés**

Egy diaképek elrendezése meghatározza a helyettesítők, például címek, szöveg, képek, diagramok és táblák pozícióját és formázását. Az elrendezés alkalmazása egységes felépítést biztosít a diák számára, miközben minden diának lehetővé teszi saját tartalmának elhelyezését.

A leggyakoribb elrendezések a következők:

- **Címdia**: Cím és alcím helyettesítőket tartalmaz.
- **Cím és tartalom**: Cím helyettesítőt és egy általános célú tartalom helyettesítőt tartalmaz.
- **Üres**: Nem tartalmaz tartalom helyettesítőket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **Az elrendezés öröklődésének megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) meghatározza a témát, a közös formázást, a háttérképeket és a közös objektumokat.
1. A [layout dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) egy masterhez tartozik, és meghatároz egy adott helyettesítők elrendezését.
1. A [normál dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) egy elrendezést használ, és tárolja az adott diára bevitt tartalmat.

Egy normál dia a témát és a formázást örökli az elrendezéséből, az elrendezés pedig a masterből. A normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát hoznak létre, a helyettesítő alakzatok a kiválasztott elrendezésből generálódnak, míg a helyettesítőkbe bevitt tartalom a normál dia része.

Adjunk hozzá a szükséges helyettesítőket az elrendezéshez, mielőtt diákra alkalmaznánk azt. Egy másik helyettesítő későbbi hozzáadása egy elrendezéshez nem generál automatikusan helyettesítő alakzatot a már létező normál diákon.

Ennek a viszonynak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helyettesítők geometriájának módosítása egy elrendezésen frissítheti az összes tőle függő diát. Mielőtt egy már használatban lévő elrendezést szerkesztenénk, ellenőrizzük a függő diákat és tekintsük át a kapott prezentációt.
- Egy olyan elrendezést, amelyet még használ egy dia, nem lehet eltávolítani. Előbb rendeljük át a függő diákot egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsuk el.

További információkért a hierarchia felső szintjéről lásd a [Slide Master](/slides/hu/php-java/slide-master/) oldalt.

Az örökölt logók vagy díszítő master alakzatok elrejtéséhez egy dián vagy egy megosztott elrendezésen keresztül lásd a [Control the Visibility of Master Graphics](/slides/hu/php-java/slide-master/) oldalt. A példa két diát hasonlít össze, amelyek ugyanazt a mastert használják.

## **Elrendezés kiválasztása és alkalmazása**

Használjunk elrendezéstípust, ha a prezentáció a szokásos PowerPoint elrendezésdefiníciókat követi. Az elrendezésnevek felhasználó által szerkeszthetők és lokalizálhatók, ezért a névre alapozott kiválasztás kevésbé megbízható, hacsak nem kontrolláljuk a forrássablont.

Az alábbi példa a **Title and Content** elrendezést keresi az első masterben. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzuk az első normál diára.

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

Egy dia elrendezésének módosítása nem távolítja el a közvetlenül a diára hozzáadott szokásos alakzatokat. Azonban a helyettesítők pozíciója, az örökölt formázás és a meglévő helyettesítők és az új elrendezés közti megfelelés változhat, ezért érdemes ellenőrizni a kimenetet, ha jelentősen eltérő elrendezések között váltunk.

## **Elrendezés dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy létező elrendezést választ ki; nem hoz létre újat. Elrendezés létrehozásához hívjuk meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterlayoutslidecollection/#add) metódust a cél master elrendezésgyűjteményén.

Az alábbi példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd létrehoz egy rá épülő normál diát. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

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

Csak akkor adjunk hozzá elrendezést, ha a sablon valóban igényel egy új újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válasszuk ki és használjuk fel azt a duplikátum létrehozása helyett.

## **Helyettesítők hozzáadása egy elrendezés diához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/) objektumot ad vissza, amellyel helyettesítő alakzatokat adhatunk hozzá egy elrendezéshez.

| PowerPoint Placeholder              | `LayoutPlaceholderManager` metódus |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Az alábbi példa ellenőrzi, hogy a **Blank** elrendezés létezik-e, négy helyettesítőt ad hozzá, majd egy normál diát hoz létre, amely a módosított elrendezést használja. A sorrend szándékos: a helyettesítőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides a megfelelő helyettesítő alakzatokat tudja generálni azon a dián.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy az existing layout placeholders geometriájának módosítása befolyásolhatja a függő diákot. Egy újonnan hozzáadott elrendezéshelyettesítő nem kerül automatikusan a már létező normál diákba. Teszteljük az elrendezésváltozásokat a prezentáció egy másolatán, és ellenőrizzük minden függő diát.
{{% /alert %}}

## **Nem használt elrendezés diák eltávolítása**

Használjuk a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a olyan elrendezések eltávolításához, amelyekre egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja az még használatban lévő elrendezéseket.

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

Egy konkrét elrendezés eltávolításához előbb ellenőrizzük a [hasDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#hasDependingSlides) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getDependingSlides) metódus segítségével. Mielőtt meghívnánk a [LayoutSlide.remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#remove) metódust, rendeljük át a függő diákat. Egy használt elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) kivételt vált ki.

## **Lábléc láthatóságának vezérlése egy elrendezés dián**

Egy elrendezésnek saját lábléc, dia-szám és dátum-idő helyettesítői vannak. A [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódussal vezérelhetjük ezeket a helyettesítőket egy adott elrendezéshez. Ez akkor hasznos, ha például a tartalom elrendezéseknek láblécet kell mutatni, de a cím elrendezéseknek nem.

Az alábbi példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a lábléc elemeit:

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

## **Lábléc láthatóságának vezérlése egy masteren és annak gyermek elrendezésein**

Az egységes lábléc beállítások master hierarchiában történő alkalmazásához használjuk a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a masteren, annak függő elrendezés diákon és normál diákon is működnek; nem csak egyetlen normál diára vonatkoznak.

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

**Mi a különbség a master dia és az elrendezés dia között?**

A master dia meghatározza a prezentáció témáját és a közös formázást. Egy elrendezés dia a masterhez tartozik, és egy újrahasználható helyettesítő elrendezést definiál. A normál diákok ezeket az elrendezéseket használják, és a diaspecifikus tartalmat tárolják.

**Másolhatok elrendezés diát egy prezentációból a másikba?**

Igen. Adjon egy másolatot a célgyűjteményhez a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/globallayoutslidecollection/#addClone) metódussal. Másoláskor ellenőrizze a betűtípusokat, témákat, képeket és egyéb forrásokat, amelyeket a forrás elrendezés használ.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés módosításait, hacsak nem írják felül a formázást vagy az objektumokat helyileg. Így a helyettesítők geometriája és az örökölt stílusok sok dián egyszerre változhatnak. Szerkesztés előtt használja a [getDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getDependingSlides) metódust az érintett diák azonosításához.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/)-t dob. Előbb rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust csak a nem hivatkozott elrendezések eltávolításához.