---
title: Použít nebo změnit rozvržení snímků v C++
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/cpp/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupce
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- titul a obsah
- hlavička sekce
- dva obsah
- srovnání
- pouze titulek
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- titulek a vertikální text
- vertikální titulek a text
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte a přizpůsobujte rozvržení snímků v Aspose.Slides pro C++. Prozkoumejte typy rozvržení, řízení zástupců a viditelnost zápatí pomocí ukázek kódu v C++."
---
## **Úvod**

Rozvržení snímku určuje uspořádání míst pro zástupce a formátování obsahu na snímku. Řídí, které zástupce jsou k dispozici a kde se zobrazují. Rozvržení snímků vám pomáhá rychle a konzistentně vytvářet prezentace – ať už jde o něco jednoduchého nebo složitějšího. Mezi nejčastější rozvržení snímků v PowerPointu patří:

**Rozvržení titulního snímku** – Obsahuje dva textové zástupce: jeden pro titulek a jeden pro podtitulek.

**Rozvržení titulek a obsah** – Má menší zástupce titulku nahoře a větší pod ním pro hlavní obsah (jako text, odrážky, grafy, obrázky a další).

**Prázdné rozvržení** – Neobsahuje žádné zástupce, což vám dává plnou kontrolu nad návrhem snímku od základu.

Rozvržení snímků jsou součástí základního snímku (slide master), který je nejvyšší úrovní snímku definující styl rozvržení pro celou prezentaci. Přístup k rozvržením a jejich úpravy můžete provést přes základní snímek – podle typu, názvu nebo unikátního ID. Nebo můžete konkrétní rozvržení upravit přímo v prezentaci.

Pro práci s rozvržením snímků v Aspose.Slides pro Android můžete použít:

- Metody jako [get_LayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_layoutslides/) a [get_Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/) ve třídě [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)
- Typy jako [ILayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/) a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Chcete-li se dozvědět více o práci se základními snímky, podívejte se na článek [Slide Master](/slides/cs/cpp/slide-master/).

{{% /alert %}}

## **Přidání rozvržení snímků do prezentací**

Chcete‑li přizpůsobit vzhled a strukturu svých snímků, možná budete potřebovat přidat nová rozvržení do prezentace. Aspose.Slides pro Android vám umožňuje zjistit, zda konkrétní rozvržení již existuje, přidat jej v případě potřeby a použít jej k vkládání snímků na základě tohoto rozvržení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte kolekci [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Ověřte, zda požadovaný rozvržení snímku již v kolekci existuje. Pokud ne, přidejte potřebné rozvržení.
1. Přidejte prázdný snímek založený na novém rozvržení.
1. Uložte prezentaci.

Níže uvedený C++ kód ukazuje, jak přidat rozvržení snímku do PowerPointové prezentace:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Situace, kdy prezentace neobsahuje všechny typy rozvržení.
    // Soubor prezentace obsahuje jen typy rozvržení Blank a Custom.
    // Nicméně rozvržení snímků s vlastními typy mohou mít rozpoznatelné názvy,
    // např. "Title", "Title and Content" a další, které lze použít pro výběr rozvržení snímku.
    // Můžete také spoléhat na sadu typů tvarů zástupců.
    // Například titulní snímek by měl mít jen typ zástupce Title, atd.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Přidejte prázdný snímek pomocí přidaného rozvržení snímku.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Uložte prezentaci na disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Odstranění nepoužívaných rozvržení snímků**

Aspose.Slides poskytuje metodu [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ze třídy [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/), která vám umožní smazat nežádoucí a nepoužívaná rozvržení snímků.

Následující C++ kód ukazuje, jak odstranit rozvržení snímku z PowerPointové prezentace:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Přidání zástupců do rozvržení snímků**

Aspose.Slides poskytuje metodu [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/), která vám umožní přidávat nové zástupce do rozvržení snímku.

Tento manažer obsahuje metody pro následující typy zástupců:

| Zástupce PowerPointu | Metoda [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/) |
| -------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Následující C++ kód ukazuje, jak přidat nové tvary zástupců do prázdného rozvržení snímku:

```cpp
auto presentation = MakeObject<Presentation>();

// Získat prázdné rozvržení snímku.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Získat správce zástupců rozvržení snímku.
auto placeholderManager = layout->get_PlaceholderManager();

// Přidat různé zástupce do prázdného rozvržení snímku.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Přidat nový snímek s prázdným rozvržením.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Zástupci na rozvržení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozvržení snímku**

V PowerPointových prezentacích lze prvky zápatí – datum, číslo snímku a vlastní text – zobrazovat nebo skrývat podle rozvržení snímku. Aspose.Slides pro Android vám umožňuje řídit viditelnost těchto zástupců zápatí. To je užitečné, když chcete, aby některá rozvržení zobrazovala informace v zápatí, zatímco jiná zůstala čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na rozvržení snímku podle jeho indexu.
1. Nastavte viditelnost zástupce zápatí snímku na **visible**.
1. Nastavte viditelnost zástupce čísla snímku na **visible**.
1. Nastavte viditelnost zástupce data/času na **visible**.
1. Uložte prezentaci.

Následující C++ kód ukazuje, jak nastavit viditelnost zápatí snímku a provést související úkony:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení viditelnosti zápatí pro podřízené snímky**

​V PowerPointových prezentacích lze prvky zápatí – datum, číslo snímku a vlastní text – řídit na úrovni základního snímku, aby byla zajištěna konzistence napříč všemi rozvrženími snímků. Aspose.Slides pro Android umožňuje nastavit viditelnost a obsah těchto zástupců zápatí na základním snímku a propagovat tato nastavení do všech podřízených rozvržení snímků. Tento přístup zajišťuje jednotné informace v zápatí v celé prezentaci.​

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na základní snímek podle jeho indexu.
1. Nastavte viditelnost všech zástupců zápatí základního i podřízených snímků na **visible**.
1. Nastavte viditelnost všech zástupců čísel snímků základního i podřízených snímků na **visible**.
1. Nastavte viditelnost všech zástupců data/času základního i podřízených snímků na **visible**.
1. Uložte prezentaci.

Následující C++ kód demonstruje tuto operaci:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jaký je rozdíl mezi základním snímkem a rozvržením snímku?**

Základní snímek určuje celkové téma a výchozí formátování, zatímco rozvržení snímku definují konkrétní uspořádání zástupců pro různé typy obsahu.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozvržení snímku z kolekce rozvržení jedné prezentace (přístupné metodou [get_LayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_layoutslides/)) a vložit jej do jiné prezentace pomocí metody `AddClone`.

**Co se stane, když smažu rozvržení snímku, které je stále používáno?**

Pokud se pokusíte smazat rozvržení snímku, na které odkazuje alespoň jeden snímek v prezentaci, Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxeditexception/). Pro zamezení tomu použijte [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), která bezpečně odstraní jen nepoužívaná rozvržení.