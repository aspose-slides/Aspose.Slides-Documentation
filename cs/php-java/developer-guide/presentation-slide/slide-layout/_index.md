---
title: Použití nebo změna rozložení snímků v PHP
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/php-java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný symbol
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- titulní snímek
- nadpis a obsah
- hlavička sekce
- dvě oblasti
- porovnání
- pouze nadpis
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- nadpis a vertikální text
- vertikální nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Používejte, vytvářejte a upravujte rozložení snímků v Aspose.Slides pro PHP pomocí Javy, přidávejte zástupné symboly, odstraňujte nepoužitá rozložení a říďte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku definuje polohy a formátování zástupných symbolů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použitím rozložení získají snímky konzistentní strukturu a zároveň může každý snímek obsahovat vlastní obsah.

Nejčastější rozložení zahrnují:

- **Title Slide**: Obsahuje zástupné symboly nadpisu a podnadpisu.
- **Title and Content**: Obsahuje zástupný symbol nadpisu a obecný zástupný symbol obsahu.
- **Blank**: Neobsahuje žádné zástupné symboly a je užitečné, když bude každý tvar umístěn ručně.

## **Pochopení dědičnosti rozvržení**

Prezentace má tři související úrovně:

1. A [master snímek](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) určuje motiv, sdílené formátování, pozadí a společné objekty.
1. A [snímek rozložení](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/) patří k masteru a definuje konkrétní uspořádání zástupných symbolů.
1. A [normální snímek](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí z masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je vytvořen normální snímek, jeho tvary zástupných symbolů jsou generovány ze zvoleného rozložení, zatímco obsah zadaný do těchto symbolů patří k normálnímu snímku.

Přidejte požadované zástupné symboly do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného symbolu do rozložení později automaticky nepřidá odpovídající tvar zástupného symbolu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupných symbolů v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozložení, které je stále používáno nějakým snímkem, nelze odstranit. Nejprve přesuňte jeho závislé snímky na jiné rozložení nebo odstraňte jen nepoužívaná rozložení.

Další informace o nejvyšší úrovni této hierarchie najdete v [Slide Master](/slides/cs/php-java/slide-master/).

## **Vyberte a použijte rozložení snímku**

Používejte typ rozložení, když prezentace používá standardní definice rozložení PowerPointu. Názvy rozložení jsou upravitelné uživatelem a mohou být lokalizovány, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Title and Content** v prvním masteru. Pokud není toto rozložení k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozložení. Vybrané rozložení je pak použito na první normální snímek pomocí metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#setLayoutSlide).

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

Změna rozložení snímku neodstraňuje běžné tvary přidané přímo do snímku. Nicméně pozice zástupných symbolů, zděděné formátování a shoda mezi existujícími zástupnými symboly a novým rozložením se mohou změnit, proto při přepínání mezi podstatně odlišnými rozloženími zkontrolujte výstup.

## **Přidání snímku rozložení**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybere existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

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

Přidejte rozložení jen tehdy, když šablona skutečně potřebuje další znovupoužitelnou strukturu. Pokud již existuje vhodné rozložení, vyberte a použijte jej místo vytváření duplikátu.

## **Přidání zástupných symbolů do snímku rozložení**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje objekt [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/) pro přidání tvarů zástupných symbolů do rozložení.

| PowerPoint zástupný symbol          | `LayoutPlaceholderManager` metoda |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověřuje, že rozložení **Blank** existuje, přidá k němu čtyři zástupné symboly a poté vytvoří normální snímek, který používá upravené rozložení. Pořadí je záměrné: zástupné symboly jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných symbolů na tomto snímku.

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

Výsledek:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných symbolů rozložení může ovlivnit závislé snímky. Nově přidaný zástupný symbol rozložení se nevyplní do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranění nepoužívaných snímků rozložení**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) pro odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, nedotčena.

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

Chcete‑li odstranit konkrétní rozložení, nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getDependingSlides). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#remove) přesuňte všechny závislé snímky. Pokus o odstranění používaného rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí na snímku rozložení**

Rozložení má své vlastní zástupné symboly zápatí, čísla snímku a data‑času. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) pro řízení těchto symbolů u jednoho rozložení. To je užitečné například tehdy, když by obsahová rozložení měla zobrazovat zápatí, ale nadpisová ne.

Následující příklad bezpečně vybere rozložení a učiní jeho prvky zápatí viditelnými:

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

## **Řízení viditelnosti zápatí v Masteru a jeho podřízených rozloženích**

Pro jednotné nastavení zápatí v celé hierarchii masteru použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření třídy [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslideheaderfootermanager/) působí na master a jeho závislé snímky rozložení i normální snímky; neomezuje se jen na jeden normální snímek.

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

## **Často kladené otázky**

**Jaký je rozdíl mezi master snímkem a snímkem rozložení?**

Master snímek určuje motiv prezentace a sdílené formátování. Snímek rozložení patří k masteru a definuje jedno znovupoužitelné uspořádání zástupných symbolů. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu kopírovat snímek rozložení z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce metodou [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité ve zdrojovém rozložení.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud lokálně nepřepisují ovlivněné formátování nebo objekty. Geometrie zástupných symbolů a zděděné stylování se tak mohou najednou změnit na mnoha snímcích. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, pokud odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění pouze neodkazovaných rozložení.