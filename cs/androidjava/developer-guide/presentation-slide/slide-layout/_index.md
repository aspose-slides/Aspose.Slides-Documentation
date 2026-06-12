---
title: Použít nebo změnit rozvržení snímků na Androidu
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/androidjava/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupné pole
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- titulek a obsah
- záhlaví sekce
- dvě oblasti obsahu
- porovnání
- pouze titulek
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- titulek a svislý text
- svislý titulek a text
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte a přizpůsobujte rozvržení snímků v Aspose.Slides pro Android. Prozkoumejte typy rozvržení, řízení zástupných polí a viditelnost zápatí pomocí Java ukázek kódu."
---
## **Úvod**

Rozvržení snímku určuje uspořádání zástupných polí a formátování obsahu na snímku. Řídí, která zástupná pole jsou k dispozici a kde se zobrazují. Rozvržení snímků vám pomáhá rychle a konzistentně navrhovat prezentace — ať už vytváříte něco jednoduchého nebo složitějšího. Mezi nejčastější rozvržení snímků v PowerPointu patří:

**Rozvržení titulního snímku** – Obsahuje dvě textová zástupná pole: jedno pro název a druhé pro podnadpis.

**Rozvržení titulku a obsahu** – Má menší zástupné pole pro titulek nahoře a větší pod ním pro hlavní obsah (např. text, odrážky, grafy, obrázky a další).

**Prázdné rozvržení** – Neobsahuje žádná zástupná pole, takže máte plnou kontrolu nad návrhem snímku od nuly.

Rozvržení snímků jsou součástí hlavního snímku (master), který na nejvyšší úrovni definuje styly rozvržení pro celou prezentaci. K rozvržení snímků můžete přistupovat a upravovat je přes hlavní snímek – podle typu, názvu nebo jedinečného ID. Alternativně můžete konkrétní rozvržení upravit přímo v prezentaci.

Pro práci s rozvržením snímků v Aspose.Slides pro Android můžete použít:

- Metody jako [getLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) a [getMasters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getMasters--) ze třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/)
- Typy jako [ILayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Chcete-li se dozvědět více o práci s hlavními snímky, podívejte se na článek [Slide Master](/slides/cs/androidjava/slide-master/).
{{% /alert %}}

## **Přidání rozvržení snímků do prezentací**

Chcete‑li přizpůsobit vzhled a strukturu svých snímků, možná budete potřebovat přidat nová rozvržení snímků do prezentace. Aspose.Slides pro Android umožňuje zkontrolovat, zda konkrétní rozvržení již existuje, případně jej přidat a použít k vložení snímků na základě tohoto rozvržení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Ověřte, zda požadované rozvržení snímku v kolekci již existuje. Pokud ne, přidejte potřebné rozvržení.
1. Přidejte prázdný snímek založený na novém rozvržení.
1. Uložte prezentaci.

Následující kód v jazyce Java ukazuje, jak přidat rozvržení snímku do prezentace PowerPoint:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Procházejte typy rozvržení snímků a vyberte rozvržení snímku.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Situace, kdy prezentace neobsahuje všechny typy rozvržení.
        // Soubor prezentace obsahuje pouze typy rozvržení Blank a Custom.
        // Nicméně rozvržení snímků s vlastními typy mohou mít rozpoznatelné názvy,
        // např. "Title", "Title and Content" atd., které lze použít pro výběr rozvržení snímku.
        // Můžete se také spolehnout na sadu typů tvarů zástupných polí.
        // Například titulek snímku by měl mít jen typ zástupného pole Title a tak dále.
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

    // Přidejte prázdný snímek pomocí přidaného rozvržení snímku.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Uložte prezentaci na disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odstranění nepoužívaných rozvržení snímků**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ze třídy [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/), která umožňuje smazat nechtěná a nepoužívaná rozvržení snímků.

Následující kód v jazyce Java ukazuje, jak odstranit rozvržení snímku z prezentace PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání zástupců do rozvržení snímků**

Aspose.Slides poskytuje metodu [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , která umožňuje přidávat nová zástupná pole do rozvržení snímku.

Tento manažer obsahuje metody pro následující typy zástupců:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Metoda |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Následující kód v jazyce Java demonstruje, jak přidat nová zástupná tvaru do prázdného rozvržení snímku:

```java
Presentation presentation = new Presentation();
try {
    // Získejte prázdné rozvržení snímku.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Získejte správce zástupných polí rozvržení snímku.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Přidejte různá zástupná pole do prázdného rozvržení snímku.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Přidejte nový snímek s prázdným rozvržením.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The placeholders on the layout slide](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozvržení snímku**

V prezentacích PowerPoint lze prvky zápatí, jako jsou datum, číslo snímku a vlastní text, zobrazovat nebo skrývat podle rozvržení snímku. Aspose.Slides pro Android umožňuje ovládat viditelnost těchto zástupných polí zápatí. To je užitečné, pokud chcete, aby některá rozvržení zobrazovala informace v zápatí, zatímco jiná zůstala čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na rozvržení snímku podle jeho indexu.
1. Nastavte zástupce zápatí snímku jako viditelný.
1. Nastavte zástupce čísla snímku jako viditelný.
1. Nastavte zástupce data‑času jako viditelný.
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

## **Nastavení viditelnosti zápatí u podřízených snímků**

V prezentacích PowerPoint lze prvky zápatí, jako jsou datum, číslo snímku a vlastní text, řídit na úrovni hlavního snímku, aby byla zajištěna konzistence napříč všemi rozvrženími. Aspose.Slides pro Android umožňuje nastavit viditelnost a obsah těchto zástupných polí zápatí na hlavním snímku a propůjčit tato nastavení všem podřízeným rozvržením. Tento přístup zajišťuje jednotné informace v zápatí po celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na hlavní snímek podle jeho indexu.
1. Nastavte hlavní a všechna podřízená zástupná pole zápatí jako viditelná.
1. Nastavte hlavní a všechna podřízená zástupná pole čísla snímku jako viditelná.
1. Nastavte hlavní a všechna podřízená zástupná pole data‑času jako viditelná.
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

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek určuje celkové téma a výchozí formátování, zatímco rozvržení snímku definuje konkrétní uspořádání zástupných polí pro různé typy obsahu.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozvržení snímku z kolekce rozvržení jedné prezentace pomocí metody [getLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) a vložit jej do jiné prezentace metodou `addClone`.

**Co se stane, pokud smažu rozvržení snímku, které je stále používáno?**

Pokud se pokusíte smazat rozvržení snímku, na které odkazuje alespoň jeden snímek v prezentaci, Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/). Abyste tomu předešli, použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), která bezpečně odstraní pouze rozvržení snímků, která nejsou použita.