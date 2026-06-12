---
title: Použití nebo změna rozložení snímků v PHP
linktitle: Rozložení snímků
type: docs
weight: 60
url: /cs/php-java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný prvek
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- titulní snímek
- název a obsah
- hlavička sekce
- dvousloupcový obsah
- porovnání
- pouze nadpis
- prázdné rozložení
- obsah s titulkem
- obrázek s titulkem
- název a svislý text
- svislý název a text
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte a přizpůsobujte rozložení snímků v Aspose.Slides pro PHP pomocí Javy. Prozkoumejte typy rozložení, řízení placeholderů a viditelnost zápatí pomocí ukázek kódu."
---
## **Úvod**

Rozložení snímku určuje uspořádání polí placeholderů a formátování obsahu na snímku. Řídí, které placeholdery jsou dostupné a kde se zobrazují. Rozložení snímků vám pomáhají navrhovat prezentace rychle a konzistentně – ať už vytváříte něco jednoduchého nebo složitějšího. Mezi nejčastěji používaná rozložení snímků v PowerPointu patří:

**Rozložení titulního snímku** – obsahuje dva textové placeholdery: jeden pro nadpis a druhý pro podnadpis.

**Rozložení Název a obsah** – obsahuje menší placeholder pro název v horní části a větší pod ním pro hlavní obsah (například text, odrážky, grafy, obrázky a další).

**Prázdné rozložení** – neobsahuje žádné placeholdery, což vám dává plnou kontrolu nad návrhem snímku od nuly.

Rozložení snímků jsou součástí hlavního snímku, který je nejvyšším úrovní snímku definujícím styly rozložení pro prezentaci. K rozložení snímků můžete získat přístup a upravovat je prostřednictvím hlavního snímku – buď podle jejich typu, názvu nebo unikátního ID. Případně můžete konkrétní rozložení snímku upravit přímo v prezentaci.

Pro práci s rozloženími snímků v Aspose.Slides for PHP můžete použít:

- Metody jako [getLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getLayoutSlides) a [getMasters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasters) ve třídě [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) 
- Typy jako [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/), a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Chcete-li se dozvědět více o práci s hlavními snímky, podívejte se na článek [Hlavní snímek](/slides/cs/php-java/slide-master/).
{{% /alert %}}

## **Přidání rozložení snímků do prezentací**

Chcete-li přizpůsobit vzhled a strukturu svých snímků, může být nutné přidat do prezentace nová rozložení snímků. Aspose.Slides for PHP vám umožňuje zkontrolovat, zda konkrétní rozložení již existuje, přidat nové podle potřeby a použít jej k vložení snímků založených na tomto rozložení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte přístup ke [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterlayoutslidecollection/).
3. Ověřte, zda požadovaný rozložení snímku již v kolekci existuje. Pokud ne, přidejte potřebné rozložení snímku.
4. Přidejte prázdný snímek založený na novém rozložení snímku.
5. Uložte prezentaci.

Následující kód v PHP ukazuje, jak přidat rozložení snímku do prezentace PowerPoint:

```php
// Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Projde typy rozložení snímků a vybere rozložení snímku.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Situace, kdy prezentace neobsahuje všechny typy rozložení.
        // Soubor prezentace obsahuje pouze typy rozložení Blank a Custom.
        // Avšak rozložení snímků s vlastními typy mohou mít rozpoznatelné názvy,
        // například "Title", "Title and Content" atd., které lze použít pro výběr rozložení snímku.
        // Můžete se také spolehnout na sadu typů tvarů placeholderů.
        // Například snímek Title by měl mít pouze placeholder typu Title, a tak dále.
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

    // Přidej prázdný snímek pomocí přidaného rozložení snímku.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Ulož prezentaci na disk.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Odstranění nepoužívaných rozložení snímků**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) třídy [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/), která vám umožní smazat nežádoucí a nepoužívaná rozložení snímků.

Následující kód v PHP ukazuje, jak odstranit rozložení snímku z prezentace PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Přidání placeholderů do rozložení snímků**

Aspose.Slides poskytuje metodu [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getPlaceholderManager), která vám umožní přidat nové placeholdery do rozložení snímku.

Tento manažer obsahuje metody pro následující typy placeholderů:

| Placeholder v PowerPointu | [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutplaceholdermanager/) Metoda |
| -------------------------- | ------------------------------------------------------------ |
| ![Obsah](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Obsah (vertikální)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikální)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obrázek](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Graf](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabulka](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online obrázek](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Následující kód v PHP ukazuje, jak přidat nové tvary placeholderů do prázdného rozložení snímku:

```php
$presentation = new Presentation();
try {
    // Získá prázdné rozložení snímku.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Získá správce placeholderů rozložení snímku.
    $placeholderManager = $layout->getPlaceholderManager();

    // Přidá různé placeholdery do prázdného rozložení snímku.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Přidá nový snímek s prázdným rozložením.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Placeholdery na rozložení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozložení snímku**

V prezentacích PowerPoint mohou být prvky zápatí, jako datum, číslo snímku a vlastní text, zobrazeny nebo skryty v závislosti na rozložení snímku. Aspose.Slides for PHP vám umožňuje řídit viditelnost těchto placeholderů zápatí. To je užitečné, když chcete, aby některá rozložení zobrazovala informace v zápatí, zatímco jiná zůstávají čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na rozložení snímku podle jeho indexu.
3. Nastavte placeholder zápatí snímku jako viditelný.
4. Nastavte placeholder čísla snímku jako viditelný.
5. Nastavte placeholder data a času jako viditelný.
6. Uložte prezentaci.

Následující kód v PHP ukazuje, jak nastavit viditelnost zápatí snímku a provést související úkoly:

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

## **Nastavení viditelnosti zápatí pro podřízený snímek**

V prezentacích PowerPoint lze prvky zápatí, jako datum, číslo snímku a vlastní text, řídit na úrovni hlavního snímku, aby byla zajištěna konzistence napříč všemi rozloženími snímků. Aspose.Slides for PHP vám umožňuje nastavit viditelnost a obsah těchto placeholderů zápatí na hlavním snímku a propagovat tato nastavení ke všem podřízeným rozložení snímků. Tento přístup zajišťuje jednotné informace v zápatí po celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na hlavní snímek podle jeho indexu.
3. Nastavte placeholdery zápatí hlavního snímku i všech podřízených jako viditelné.
4. Nastavte placeholdery čísel snímků hlavního snímku i všech podřízených jako viditelné.
5. Nastavte placeholdery data a času hlavního snímku i všech podřízených jako viditelné.
6. Uložte prezentaci.

Následující kód v PHP demonstruje tuto operaci:

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

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozložením snímku?**

Hlavní snímek určuje celkový motiv a výchozí formátování, zatímco rozložení snímků definují konkrétní uspořádání placeholderů pro různé typy obsahu.

**Mohu zkopírovat rozložení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozložení snímku z kolekce rozložení snímků jedné prezentace (přístupné metodou [getLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getLayoutSlides)) a vložit jej do jiné prezentace pomocí metody `addClone`.

**Co se stane, když smažu rozložení snímku, které stále používá nějaký snímek?**

Pokud se pokusíte smazat rozložení snímku, na který odkazuje alespoň jeden snímek v prezentaci, Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/). Abyste tomu předešli, použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), která bezpečně odstraní pouze rozložení snímků, která nejsou používána.