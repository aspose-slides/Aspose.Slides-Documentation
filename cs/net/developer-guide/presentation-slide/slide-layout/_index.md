---
title: Použít nebo změnit rozvržení snímků v .NET
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/net/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- název a obsah
- záhlaví sekce
- dvě oblasti obsahu
- srovnání
- pouze název
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- název a vertikální text
- vertikální název a text
- PowerPoint
- OpenDocument
- prezentace
- C#
- .NET
- Aspose.Slides
description: "Spravujte a přizpůsobujte rozvržení snímků v Aspose.Slides pro .NET. Prozkoumejte typy rozvržení, řízení zástupných objektů a viditelnost zápatí pomocí ukázek kódu v C#."
---
## **Úvod**

Rozvržení snímku určuje uspořádání míst pro obsah a formátování obsahu na snímku. Řídí, které zástupné objekty jsou k dispozici a kde se zobrazují. Rozvržení snímků vám pomáhá rychle a jednotně navrhovat prezentace – ať už vytváříte něco jednoduchého nebo složitějšího. Mezi nejčastější rozvržení snímků v PowerPointu patří:

**Rozvržení titulního snímku** – Obsahuje dva textové zástupce: jeden pro název a jeden pro podtitul.

**Rozvržení název a obsah** – Obsahuje menší zástupce pro název v horní části a větší pod ním pro hlavní obsah (jako je text, odrážky, grafy, obrázky a další).

**Prázdné rozvržení** – Neobsahuje žádné zástupce, což vám dává plnou kontrolu nad návrhem snímku od nuly.

Rozvržení snímků jsou součástí hlavního snímku, který je nejvyšší úrovní snímku definujícího styly rozvržení pro celou prezentaci. K rozvrhům snímků můžete přistupovat a upravovat je přes hlavní snímek — buď podle jejich typu, názvu nebo unikátního ID. Případně můžete konkrétní rozvržení snímku upravit přímo v prezentaci.

Pro práci s rozvrženími snímků v Aspose.Slides pro .NET můžete použít:

- Vlastnosti jako [LayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/layoutslides/) a [Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/) pod třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) 
- Typy jako [ILayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutplaceholdermanager/), a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pro další informace o práci s hlavními snímky si přečtěte článek [Slide Master](/slides/cs/net/slide-master/).
{{% /alert %}}

## **Přidání rozvržení snímků do prezentací**

Pro přizpůsobení vzhledu a struktury vašich snímků možná budete potřebovat přidat nová rozvržení snímků do prezentace. Aspose.Slides pro .NET vám umožňuje zkontrolovat, zda konkrétní rozvržení již existuje, v případě potřeby přidat nové a použít jej k vložení snímků založených na tomto rozvržení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte přístup k [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterlayoutslidecollection/).
1. Zkontrolujte, zda požadované rozvržení snímku již existuje ve sbírce. Pokud ne, přidejte potřebné rozvržení snímku.
1. Přidejte prázdný snímek založený na novém rozvržení snímku.
1. Uložte prezentaci.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Procházejte typy rozvržení snímků a vyberte požadované rozvržení.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Situace, kdy prezentace neobsahuje všechny typy rozvržení.
        // Soubor prezentace obsahuje jen typy rozvržení Blank a Custom.
        // Nicméně rozvržení s vlastními typy mohou mít rozpoznatelné názvy,
        // například "Title", "Title and Content", atd., které lze použít pro výběr rozvržení snímku.
        // Můžete se také spolehnout na sadu typů tvarů zástupných objektů.
        // Například titulní snímek by měl mít jen typ zástupce Title, a podobně.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Přidejte prázdný snímek pomocí přidaného rozvržení snímku.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Uložte prezentaci na disk.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Odstranění nepoužívaných rozvržení snímků**

Aspose.Slides poskytuje metodu [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) třídy [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/), která vám umožní smazat nechtěná a nepoužívaná rozvržení snímků.

Níže uvedený kód C# ukazuje, jak odstranit rozvržení snímku z prezentace PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Přidání zástupných objektů do rozvržení snímků**

Aspose.Slides poskytuje vlastnost [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/placeholdermanager/), která umožňuje přidávat nové zástupce do rozvržení snímku.

Tento správce obsahuje metody pro následující typy zástupců:

| PowerPoint zástupce | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutplaceholdermanager/) metoda |
| ------------------- | ------------------------------------------------------------ |
| ![Obsah](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Obsah (vertikální)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikální)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obrázek](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Graf](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabulka](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online obrázek](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Níže uvedený kód C# ukazuje, jak přidat nové tvary zástupců do prázdného rozvržení snímku:

```cs
using (var presentation = new Presentation())
{
    // Získat prázdné rozvržení snímku.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Získat správce zástupných objektů rozvržení snímku.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Přidat různé zástupce do prázdného rozvržení snímku.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Přidat nový snímek s prázdným rozvržením.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Zástupci na rozvržení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozvržení snímku**

V prezentacích PowerPoint lze prvky zápatí, jako je datum, číslo snímku a vlastní text, zobrazit nebo skrýt podle rozvržení snímku. Aspose.Slides pro .NET vám umožňuje řídit viditelnost těchto zástupců zápatí. To je užitečné, když chcete, aby některá rozvržení zobrazovala informace v zápatí, zatímco jiná zůstávají čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte referenci na rozvržení snímku podle jeho indexu.
1. Nastavte zástupce zápatí snímku jako viditelný.
1. Nastavte zástupce čísla snímku jako viditelný.
1. Nastavte zástupce data/času jako viditelný.
1. Uložte prezentaci.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Nastavení viditelnosti zápatí pro podřízené snímky**

V prezentacích PowerPoint lze prvky zápatí, jako je datum, číslo snímku a vlastní text, řídit na úrovni hlavního snímku, aby byla zajištěna konzistence napříč všemi rozvrženími snímků. Aspose.Slides pro .NET vám umožňuje nastavit viditelnost a obsah těchto zástupců zápatí na hlavním snímku a tyto nastavení propagovat do všech podřízených rozvržení snímků. Tento přístup zajišťuje jednotné informace v zápatí v celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte referenci na hlavní snímek podle jeho indexu.
1. Nastavte zástupce zápatí na hlavním snímku i na všech podřízených jako viditelné.
1. Nastavte zástupce čísla snímku na hlavním snímku i na všech podřízených jako viditelné.
1. Nastavte zástupce data/času na hlavním snímku i na všech podřízených jako viditelné.
1. Uložte prezentaci.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Často kladené dotazy**

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek určuje celkový motiv a výchozí formátování, zatímco rozvržení snímků definují konkrétní uspořádání zástupců pro různé typy obsahu.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozvržení snímku z kolekce [LayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/layoutslides/) jedné prezentace a vložit jej do jiné pomocí metody `AddClone`.

**Co se stane, když smažu rozvržení snímku, které je stále používáno nějakým snímkem?**

Pokud se pokusíte smazat rozvržení snímku, na který odkazuje alespoň jeden snímek v prezentaci, Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception/). Pro odstranění takových situací použijte [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), která bezpečně odstraní pouze rozvržení snímků, která nejsou používána.