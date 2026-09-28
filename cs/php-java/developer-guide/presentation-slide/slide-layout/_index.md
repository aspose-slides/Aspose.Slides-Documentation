---
title: Použít nebo změnit rozložení snímků v PHP
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/php-java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupce
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- titulní snímek
- titul a obsah
- hlavička sekce
- dvě oblasti obsahu
- porovnání
- pouze titul
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- titul a svislý text
- svislý titul a text
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte, vytvářejte a upravujte rozložení snímků v Aspose.Slides pro PHP pomocí Javy, přidávejte zástupce, odstraňujte nepoužitá rozložení a řiďte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje polohu a formátování zástupných objektů, jako jsou titulky, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům konzistentní strukturu a zároveň umožňuje, aby každý snímek obsahoval vlastní obsah.

Nejčastější rozložení jsou:

- **Title Slide**: Obsahuje zástupce pro název a podnázev.
- **Title and Content**: Obsahuje zástupce pro název a obecný zástupce obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty a je užitečný, když bude každý tvar umístěn ručně.

## **Pochopení dědičnosti rozložení**

Prezentace má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. A [layout slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných objektů.
1. A [normal slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadán pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí od svého masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupců jsou generovány z vybraného rozložení, zatímco obsah zadaný do těchto zástupců patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozložení před vytvořením snímků z něj. Přidání dalšího zástupce do rozložení později automaticky nepřidá odpovídající tvar zástupce do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrie existujících zástupců v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozložení, které je stále používáno snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozložení nebo odstraňte jen nepoužívaná rozložení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/php-java/slide-master/).

Pro skrytí zděděných log nebo dekorativních tvarů masteru na jednom snímku nebo prostřednictvím sdíleného rozložení viz [Control the Visibility of Master Graphics](/slides/cs/php-java/slide-master/). Příklad porovnává dva snímky používající stejný master.

## **Vyberte a použijte rozložení snímku**

Používejte typ rozložení, když prezentace následuje standardní definice rozložení PowerPointu. Názvy rozložení lze upravovat a lokalizovat, takže výběr podle názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud není toto rozložení k dispozici, vědomě přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozložení. Vybrané rozložení je pak použito na první normální snímek prostřednictvím metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#setLayoutSlide).

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

Změna rozložení snímku neodstraní běžné tvary přidané přímo na snímek. Nicméně pozice zástupců, zděděné formátování a shoda mezi existujícími zástupci a novým rozložením se mohou změnit, proto výstup při přepínání mezi značně odlišnými rozloženími pečlivě zkontrolujte.

## **Přidat rozložení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí příklad vybírá existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

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

Přidejte rozložení pouze tehdy, když šablona skutečně potřebuje další opakovaně použitelní strukturu. Pokud již existuje vhodné rozložení, vyberte ho a použijte znovu místo vytváření duplicitního.

## **Přidat zástupné objekty do rozložení snímku**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/) pro přidávání tvarů zástupců do rozložení.

| PowerPoint zástupce               | `LayoutPlaceholderManager` Method |
| --------------------------------- | --------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověřuje, že rozložení **Blank** existuje, přidá k němu čtyři zástupce a pak vytvoří normální snímek, který použije upravené rozložení. Pořadí je úmyslné: zástupci jsou přidáni před vytvořením normálního snímku, takže Aspose.Slides může na tomto snímku vygenerovat odpovídající tvary zástupců.

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

![Zástupné objekty na rozložení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupců v rozložení může ovlivnit závislé snímky. Nově přidaný zástupce rozložení se nevyplní do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozložení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, nedotčena.

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

Pro odstranění konkrétního rozložení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getDependingSlides). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#remove) přiřaďte všechny závislé snímky. Pokus o odstranění používaného rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozložení snímku**

Rozložení má vlastní zástupce zápatí, čísla snímků a data/čas. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) k řízení těchto zástupců pro jedno rozložení. To je užitečné například, když by rozložení obsahu mělo zobrazovat zápatí, ale rozložení titulku ne.

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

## **Ovládání viditelnosti zápatí na hlavním snímku a jeho podřízených rozloženích**

Pro aplikaci konzistentních nastavení zápatí napříč hierarchií masteru použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření třídy [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslideheaderfootermanager/) působí na master a jeho závislé rozložení snímků a normální snímky; necílují pouze jeden normální snímek.

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

## **FAQ**

**Jaký je rozdíl mezi Master Slide a Layout Slide?**

Master Slide definuje motiv prezentace a sdílené formátování. Layout Slide patří k masteru a určuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat Layout Slide z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte fonty, motivy, obrázky a další zdroje použité ve zdrojovém rozložení.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud lokálně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupců a zděděné styly se tak mohou najednou změnit na mnoha snímcích. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, když odstraním rozložení, které je stále používáno?**

Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky jinému rozložení, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění jen neodkazovaných rozložení.