---
title: "Použití nebo změna rozvržení snímků v JavaScriptu"
linktitle: "Rozvržení snímku"
type: docs
weight: 60
url: /cs/nodejs-java/slide-layout/
keywords:
- "rozvržení snímku"
- "rozvržení obsahu"
- "zástupce"
- "návrh prezentace"
- "návrh snímku"
- "nepoužité rozvržení"
- "viditelnost zápatí"
- "titulní snímek"
- "název a obsah"
- "hlavička sekce"
- "dvouobsažný"
- "srovnání"
- "pouze název"
- "prázdné rozvržení"
- "obsah s titulkem"
- "obrázek s titulkem"
- "název a svislý text"
- "svislý název a text"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Spravujte a přizpůsobujte rozvržení snímků v Aspose.Slides pro Node.js. Prozkoumejte typy rozvržení, řízení zástupců a viditelnost zápatí pomocí ukázkových kódů."
---
## **Úvod**

Rozvržení snímku určuje uspořádání míst pro zástupce a formátování obsahu na snímku. Řídí, které zástupce jsou k dispozici a kde se zobrazují. Rozvržení snímků vám pomáhá rychle a jednotně vytvářet prezentace – ať už vytváříte něco jednoduchého nebo složitějšího. Mezi nejčastější rozvržení snímků v PowerPointu patří:

**Rozvržení titulního snímku** – obsahuje dva textové zástupce: jeden pro název a jeden pro podnadpis.

**Rozvržení Název a obsah** – obsahuje menší zástupce názvu v horní části a větší pod ním pro hlavní obsah (např. text, odrážky, grafy, obrázky a další).

**Prázdné rozvržení** – neobsahuje žádné zástupce, což vám dává plnou kontrolu nad návrhem snímku od nuly.

Rozvržení snímků jsou součástí hlavního snímku, což je nejvyšší úroveň snímku, která definuje styly rozvržení pro celou prezentaci. K rozvržením snímků můžete přistupovat a upravovat je prostřednictvím hlavního snímku – ať už podle typu, názvu nebo jedinečného ID. Případně můžete konkrétní rozvržení snímku upravit přímo v prezentaci.

Pro práci s rozvrženími snímků v Aspose.Slides pro Node.js můžete použít:

- Metody jako [getLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getLayoutSlides) a [getMasters](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getMasters) ve třídě [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/)
- Typy jako [LayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/), a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Chcete-li se dozvědět více o práci s hlavními snímky, podívejte se na článek [Slide Master](/slides/cs/nodejs-java/slide-master/).
{{% /alert %}}

## **Přidání rozvržení snímků do prezentací**

Pro přizpůsobení vzhledu a struktury vašich snímků může být potřeba přidat nová rozvržení snímků do prezentace. Aspose.Slides pro Node.js vám umožňuje zjistit, zda konkrétní rozvržení již existuje, případně ho přidat a použít k vložení snímků založených na tomto rozvržení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte kolekci [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterlayoutslidecollection/).
3. Ověřte, zda požadovaný rozvržení snímku již v kolekci existuje. Pokud ne, přidejte potřebné rozvržení.
4. Přidejte prázdný snímek založený na novém rozvržení.
5. Uložte prezentaci.

Následující JavaScriptový kód ukazuje, jak přidat rozvržení snímku do PowerPointové prezentace:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Projděte typy rozvržení snímků, abyste vybrali rozvržení snímku.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Situace, kdy prezentace neobsahuje všechny typy rozvržení.
        // Soubor prezentace obsahuje pouze typy rozvržení Blank a Custom.
        // Nicméně rozvržení snímků s vlastními typy mohou mít rozpoznatelné názvy,
        // například "Title", "Title and Content" atd., které lze použít k výběru rozvržení snímku.
        // Můžete se také spolehnout na sadu typů tvarů zástupců.
        // Například titulní snímek by měl mít pouze typ zástupce Title a tak dále.
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

    // Přidejte prázdný snímek pomocí přidaného rozvržení snímku.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Uložte prezentaci na disk.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odstranění nepoužívaných rozvržení snímků**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) ze třídy [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/), která umožňuje smazat nechtěná a nepoužívaná rozvržení snímků.

Následující JavaScriptový kód ukazuje, jak odstranit rozvržení snímku z PowerPointové prezentace:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání zástupců do rozvržení snímků**

Aspose.Slides poskytuje metodu [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), která umožňuje přidat nové zástupce do rozvržení snímku.

Tento správce obsahuje metody pro následující typy zástupců:

| Zástupce PowerPoint              | Metoda LayoutPlaceholderManager |
| -------------------------------- | -------------------------------- |
| ![Obsah](content.png)            | addContentPlaceholder(float x, float y, float width, float height) |
| ![Obsah (vertikální)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikální)](textV.png)  | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obrázek](picture.png)          | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Graf](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabulka](table.png)            | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)        | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png)              | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online obrázek](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Následující JavaScriptový kód ukazuje, jak přidat nové tvary zástupců do prázdného rozvržení snímku:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Získat prázdné rozvržení snímku.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Získat správce zástupců rozvržení snímku.
    let placeholderManager = layout.getPlaceholderManager();

    // Přidat různé zástupce do prázdného rozvržení snímku.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Přidat nový snímek s prázdným rozvržením.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zástupci na rozvržení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozvržení snímku**

V PowerPointových prezentacích lze elementy zápatí, jako je datum, číslo snímku a vlastní text, zobrazovat nebo skrývat podle rozvržení snímku. Aspose.Slides pro Node.js umožňuje řídit viditelnost těchto zástupců zápatí. To je užitečné, když chcete, aby některá rozvržení zobrazovala informace v zápatí, zatímco jiná zůstala čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na rozvržení snímku podle jeho indexu.
3. Nastavte zástupce zápatí snímku jako viditelný.
4. Nastavte zástupce čísla snímku jako viditelný.
5. Nastavte zástupce data a času jako viditelný.
6. Uložte prezentaci.

Následující JavaScriptový kód ukazuje, jak nastavit viditelnost zápatí snímku a provést související úkony:

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

## **Nastavení viditelnosti zápatí u podřízených snímků**

V PowerPointových prezentacích lze elementy zápatí, jako je datum, číslo snímku a vlastní text, řídit na úrovni hlavního snímku, aby byla zajištěna konzistence napříč všemi rozvrženími snímků. Aspose.Slides pro Node.js umožňuje nastavit viditelnost a obsah těchto zástupců zápatí na hlavním snímku a propagovat tato nastavení na všechny podřízené rozvržení snímků. Tento přístup zajišťuje jednotné informace v zápatí po celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na hlavní snímek podle jeho indexu.
3. Nastavte všechny hlavní a podřízené zástupce zápatí jako viditelné.
4. Nastavte všechny hlavní a podřízené zástupce čísla snímku jako viditelné.
5. Nastavte všechny hlavní a podřízené zástupce data a času jako viditelné.
6. Uložte prezentaci.

Následující JavaScriptový kód demonstruje tuto operaci:

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

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek definuje celkové téma a výchozí formátování, zatímco rozvržení snímků určuje konkrétní uspořádání zástupců pro různé typy obsahu.

**Mohu kopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozvržení snímku z kolekce rozvržení jedné prezentace (přístupné pomocí metody [getLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getLayoutSlides)) a vložit jej do jiné prezentace pomocí metody `addClone`.

**Co se stane, když smažu rozvržení snímku, které je stále používáno nějakým snímkem?**

Pokud se pokusíte odstranit rozvržení snímku, které je stále použito alespoň jedním snímkem v prezentaci, Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/). Aby se tomu předešlo, použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), který bezpečně odstraní jen ty rozvržení snímků, která nejsou používána.