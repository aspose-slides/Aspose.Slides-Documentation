---
title: Použít nebo změnit rozložení snímků v Javě
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupná položka
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- titulní snímek
- titul a obsah
- hlavička sekce
- dvě oblasti obsahu
- srovnání
- pouze titulek
- prázdné rozložení
- obsah s titulkem
- obrázek s titulkem
- titulek a svislý text
- svislý titulek a text
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Spravujte a přizpůsobujte rozložení snímků v Aspose.Slides pro Java. Prozkoumejte typy rozložení, řízení zástupných položek a viditelnost zápatí pomocí příkladů kódu v Javě."
---
## **Úvod**

Rozložení snímku určuje uspořádání boxů zástupných položek a formátování obsahu na snímku. Řídí, které zástupné položky jsou k dispozici a kde se zobrazují. Rozložení snímků vám pomáhají rychle a konzistentně navrhovat prezentace – ať už vytváříte něco jednoduchého nebo složitějšího. Některá z nejčastějších rozložení snímků v PowerPointu zahrnují:

**Rozložení titulního snímku** – Obsahuje dva textové zástupné položky: jednu pro název a jednu pro podnadpis.

**Rozložení titulek a obsah** – Obsahuje menší zástupnou položku titulu nahoře a větší pod ní pro hlavní obsah (jako je text, odrážky, grafy, obrázky a další).

**Prázdné rozložení** – Neobsahuje žádné zástupné položky, což vám dává plnou kontrolu nad navržením snímku od začátku.

Rozložení snímků jsou součástí hlavního snímku (slide master), který je nejvyšším úrovní snímku definujícím styly rozložení pro prezentaci. K rozložení snímků můžete přistupovat a upravovat je prostřednictvím hlavního snímku – ať už podle jejich typu, názvu nebo jedinečného ID. Případně můžete konkrétní rozložení snímku upravit přímo v prezentaci.

Pro práci s rozloženími snímků v Aspose.Slides pro Java můžete použít:

- Metody jako [getLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getLayoutSlides--) a [getMasters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasters--) ve třídě [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) 
- Typy jako [ILayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/), a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Chcete-li se dozvědět více o práci s hlavními snímky, podívejte se na článek [Slide Master](/slides/cs/java/slide-master/).
{{% /alert %}}

## **Přidání rozložení snímků do prezentací**

Chcete-li přizpůsobit vzhled a strukturu svých snímků, může být potřeba přidat do prezentace nová rozložení snímků. Aspose.Slides pro Java vám umožňuje zjistit, zda konkrétní rozložení již existuje, případně přidat nové a použít jej k vložení snímků založených na tomto rozložení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte přístup k [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Zkontrolujte, zda požadované rozložení snímku již v kolekci existuje. Pokud ne, přidejte potřebné rozložení snímku.
1. Přidejte prázdný snímek založený na novém rozložení snímku.
1. Uložte prezentaci.

Následující kód v jazyce Java ukazuje, jak přidat rozložení snímku do prezentace PowerPoint:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Projděte typy rozložení snímků pro výběr rozložení snímku.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Situace, kdy prezentace neobsahuje všechny typy rozložení.
        // Soubor prezentace obsahuje pouze typy rozložení Blank a Custom.
        // Nicméně rozložení snímků s vlastními typy mohou mít rozpoznatelné názvy,
        // například "Title", "Title and Content", atd., které lze použít pro výběr rozložení snímku.
        // Můžete také spoléhat na sadu typů tvarů zástupných položek.
        // Například titulek snímku by měl mít pouze typ zástupné položky Title a podobně.
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

    // Přidejte prázdný snímek pomocí přidaného rozložení snímku.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Uložte prezentaci na disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odstranění nepoužívaných rozložení snímků**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ze třídy [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/), která vám umožní smazat nechtěná a nepoužívaná rozložení snímků.

Následující kód v jazyce Java ukazuje, jak odstranit rozložení snímku z prezentace PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání zástupných položek do rozložení snímků**

Aspose.Slides poskytuje metodu [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , která vám umožní přidat nové zástupné položky do rozložení snímku.

Tento správce obsahuje metody pro následující typy zástupných položek:

| PowerPoint zástupná položka | Metoda [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/) |
| --------------------------- | ------------------------------------------------------------ |
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

Následující kód v jazyce Java ukazuje, jak přidat nové tvary zástupných položek do prázdného rozložení snímku:

```java
Presentation presentation = new Presentation();
try {
    // Získat prázdné rozložení snímku.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Získat správce zástupných položek rozložení snímku.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Přidat různé zástupné položky do prázdného rozložení snímku.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Přidat nový snímek s prázdným rozložením.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zástupné položky na rozložení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozložení snímku**

V prezentacích PowerPoint lze prvky zápatí, jako je datum, číslo snímku a vlastní text, zobrazovat nebo skrývat v závislosti na rozložení snímku. Aspose.Slides pro Java vám umožňuje řídit viditelnost těchto zástupných položek zápatí. To je užitečné, pokud chcete, aby některá rozložení zobrazovala informace v zápatí, zatímco jiná zůstávají čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na rozložení snímku podle jeho indexu.
1. Nastavte zástupnou položku zápatí snímku jako viditelnou.
1. Nastavte zástupnou položku čísla snímku jako viditelnou.
1. Nastavte zástupnou položku data a času jako viditelnou.
1. Uložte prezentaci.

Následující kód v jazyce Java ukazuje, jak nastavit viditelnost zápatí snímku a provést související úkoly:

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

## **Nastavení viditelnosti podřízených zápatí pro snímek**

V prezentacích PowerPoint lze prvky zápatí, jako je datum, číslo snímku a vlastní text, řídit na úrovni hlavního snímku, aby byla zajištěna konzistence napříč všemi rozloženími snímků. Aspose.Slides pro Java vám umožňuje nastavit viditelnost a obsah těchto zástupných položek zápatí na hlavním snímku a tyto nastavení propagovat do všech podřízených rozložení snímků. Tento přístup zajišťuje jednotné informace v zápatí po celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na hlavní snímek podle jeho indexu.
1. Nastavte zástupné položky zápatí na hlavním snímku i ve všech podřízených jako viditelné.
1. Nastavte zástupné položky čísla snímku na hlavním i ve všech podřízených jako viditelné.
1. Nastavte zástupné položky data a času na hlavním i ve všech podřízených jako viditelné.
1. Uložte prezentaci.

Následující kód v jazyce Java demonstruje tuto operaci:

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

## **FAQ**

**Jaký je rozdíl mezi hlavním snímkem a rozložením snímku?**

Hlavní snímek určuje celkové téma a výchozí formátování, zatímco rozložení snímků definují konkrétní uspořádání zástupných položek pro různé typy obsahu.

**Mohu zkopírovat rozložení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozložení snímku z kolekce rozložení snímků jedné prezentace, která je přístupná pomocí metody [getLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getLayoutSlides--) , a vložit jej do jiné prezentace pomocí metody `addClone`.

**Co se stane, když smažu rozložení snímku, které je stále používáno snímkem?**

Pokud se pokusíte smazat rozložení snímku, na které stále odkazuje alespoň jeden snímek v prezentaci, Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/). Abyste tomu předešli, použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , která bezpečně odstraní pouze rozložení snímků, která nejsou používána.