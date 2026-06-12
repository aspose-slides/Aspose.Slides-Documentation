---
title: Použít nebo změnit rozvržení snímků v Pythonu
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/python-net/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupce
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- úvodní snímek
- nadpis a obsah
- záhlaví sekce
- dva obsahy
- srovnání
- pouze nadpis
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- nadpis a vertikální text
- vertikální nadpis a text
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat a přizpůsobovat rozvržení snímků v Aspose.Slides pro Python pomocí .NET. Prozkoumejte typy rozvržení, řízení zástupců, viditelnost zápatí a manipulaci s rozvržením prostřednictvím ukázkových kódů v Pythonu."
---
## **Úvod**

Rozvržení snímku určuje uspořádání zástupných polí a formátování obsahu na snímku. Řídí, které zástupce jsou k dispozici a kde se zobrazují. Rozvržení snímků vám pomáhá rychle a konzistentně navrhovat prezentace – ať už vytváříte něco jednoduchého nebo složitějšího. Mezi nejčastější rozvržení snímků v PowerPointu patří:

**Rozvržení úvodního snímku** – Obsahuje dvě textová zástupná pole: jedno pro nadpis a jedno pro podnadpis.

**Rozvržení titulek a obsah** – Obsahuje menší zástupce nadpisu nahoře a větší pod ním pro hlavní obsah (např. text, odrážky, grafy, obrázky a další).

**Prázdné rozvržení** – Neobsahuje žádné zástupce, což vám dává plnou kontrolu nad tvorbou snímku od začátku.

Rozvržení snímků je součástí master snímku, což je nejvyšší úroveň snímku, která definuje styly rozvržení pro celou prezentaci. Přístup k rozvržením snímků a jejich úpravy můžete provádět přes master snímek – podle typu, názvu nebo jedinečného ID. Případně můžete konkrétní rozvržení snímku upravit přímo v prezentaci.

Pro práci s rozvržením snímků v Aspose.Slides pro Python můžete použít:

- Vlastnosti jako [layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/layout_slides/) a [masters](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/masters/) ve třídě [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)
- Typy jako [LayoutSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/) a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Chcete-li se dozvědět více o práci s master snímky, podívejte se na článek [Manage PowerPoint Slide Masters in Python](/slides/cs/python-net/slide-master/).
{{% /alert %}}

## **Přidání rozvržení snímků do prezentací**

Chcete‑li přizpůsobit vzhled a strukturu svých snímků, možná budete potřebovat přidat nová rozvržení snímků do prezentace. Aspose.Slides pro Python umožňuje zjistit, zda konkrétní rozvržení již existuje, případně jej přidat a použít k vložení snímků založených na tomto rozvržení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte přístup k [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterlayoutslidecollection/).
1. Ověřte, zda požadované rozvržení snímku v kolekci již existuje. Pokud ne, přidejte potřebné rozvržení.
1. Přidejte prázdný snímek založený na novém rozvržení.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak přidat rozvržení snímku do PowerPointové prezentace:

```python
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Go through the layout slide types to select a layout slide.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
        layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Situace, kdy prezentace neobsahuje všechny typy rozvržení.
        # Soubor prezentace obsahuje pouze typy rozvržení Blank a Custom.
        # Nicméně rozvržení snímků s vlastním typem mohou mít rozpoznatelné názvy,
        # jako "Title", "Title and Content" atd., které lze použít pro výběr rozvržení snímku.
        # Můžete také spoléhat na sadu typů tvarů zástupců.
        # Například snímek Title by měl mít pouze typ zástupce Title a tak dále.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Přidejte prázdný snímek pomocí přidaného rozvržení snímku.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Uložte prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranění nepoužívaných rozvržení snímků**

Aspose.Slides poskytuje metodu [remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) třídy [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/), která umožňuje smazat nechtěná a nepoužívaná rozvržení snímků.

Následující kód v Pythonu ukazuje, jak odstranit rozvržení snímku z PowerPointové prezentace:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání zástupců do rozvržení snímků**

Aspose.Slides poskytuje vlastnost [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/placeholder_manager/), která umožňuje přidávat nové zástupce do rozvržení snímku.

Tento správce obsahuje metody pro následující typy zástupců:

| PowerPoint zástupce                | Metoda [LayoutPlaceholderManager] |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png)                   | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png)       | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png)             | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png)                 | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png)                 | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)           | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                 | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png)    | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Následující kód v Pythonu ukazuje, jak přidat nové tvary zástupců do prázdného rozvržení snímku:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Získat prázdné rozvržení snímku.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Získat správce zástupců rozvržení snímku.
    placeholder_manager = layout.placeholder_manager

    # Přidat různé zástupce do prázdného rozvržení snímku.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Přidat nový snímek s prázdným rozvržením.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zástupci na rozvržení snímku](add_placeholders.png)

## **Nastavení viditelnosti zápatí pro rozvržení snímku**

V PowerPointových prezentacích lze prvky zápatí, jako je datum, číslo snímku a vlastní text, zobrazovat nebo skrývat podle rozvržení snímku. Aspose.Slides pro Python umožňuje řídit viditelnost těchto zástupců zápatí. To je užitečné, pokud chcete, aby některá rozvržení zobrazovala informace v zápatí, zatímco jiná zůstala čistá a minimalistická.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte referenci na rozvržení snímku podle jeho indexu.
1. Nastavte zástupce zápatí snímku jako viditelný.
1. Nastavte zástupce čísla snímku jako viditelný.
1. Nastavte zástupce data‑času jako viditelný.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak nastavit viditelnost zápatí snímku a provést související úkoly:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Nastavení viditelnosti zápatí potomků pro snímek**

V PowerPointových prezentacích lze prvky zápatí, jako je datum, číslo snímku a vlastní text, řídit na úrovni master snímku, aby byla zajištěna konzistence napříč všemi rozvrženími snímků. Aspose.Slides pro Python umožňuje nastavit viditelnost a obsah těchto zástupců zápatí na master snímku a propagovat tato nastavení do všech potomků rozvržení. Tento přístup zajišťuje jednotné informace v zápatí po celé prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte referenci na master snímek podle jeho indexu.
1. Nastavte všechny master a potomky zápatí jako viditelné.
1. Nastavte všechny master a potomky čísel snímků jako viditelné.
1. Nastavte všechny master a potomky datum‑časové zástupce jako viditelné.
1. Uložte prezentaci.

Následující kód v Pythonu demonstruje tuto operaci:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaký je rozdíl mezi master snímkem a rozvržením snímku?**

Master snímek definuje celkový motiv a výchozí formátování, zatímco rozvržení snímků určuje konkrétní uspořádání zástupců pro různé typy obsahu.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano, můžete klonovat rozvržení snímku z kolekce [layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/layout_slides/) jedné prezentace a vložit jej do jiné pomocí metody `add_clone`.

**Co se stane, když smažu rozvržení snímku, které je stále používáno?**

Pokud se pokusíte smazat rozvržení snímku, které je stále odkazováno alespoň jedním snímkem v prezentaci, Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/). Abyste se tomuto předešli, použijte [remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), který bezpečně odstraní jen rozvržení snímků, která nejsou v používání.