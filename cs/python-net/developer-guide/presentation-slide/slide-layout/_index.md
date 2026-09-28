---
title: "Použít nebo změnit rozložení snímků v Pythonu"
linktitle: "Rozložení snímku"
type: docs
weight: 60
url: /cs/python-net/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupce
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- titulní snímek
- nadpis a obsah
- záhlaví sekce
- dvě oblasti obsahu
- srovnání
- pouze nadpis
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte, vytvořte a upravte rozložení snímků v Aspose.Slides pro Python pomocí .NET, přidejte zástupce, odstraňte nepoužitá rozložení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje polohy a formátování zástupců, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozložení dává snímkům konzistentní strukturu a přitom umožňuje každému snímku mít vlastní obsah.

Nejčastější rozložení zahrnují:

- **Title Slide**: Obsahuje zástupce pro nadpis a podnadpis.
- **Title and Content**: Obsahuje zástupce nadpisu a obecný zástupce pro obsah.
- **Blank**: Neobsahuje žádné zástupce obsahu a je užitečné, když bude každý tvar umístěn ručně.

## **Pochopit dědičnost rozložení**

Prezentace má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. A [layout slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/) patří k masteru a určuje konkrétní uspořádání zástupců.
1. A [normal slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadáný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí z masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je vytvořen normální snímek, jeho tvary zástupců jsou generovány ze zvoleného rozložení, zatímco obsah zadaný do těchto zástupců patří k normálnímu snímku.

Přidejte požadované zástupce do rozložení před vytvořením snímků z něj. Přidání dalšího zástupce do rozložení později automaticky nepřidá odpovídající tvar zástupce do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupců v rozložení může aktualizovat každý snímek, který na něj závisí. Před úpravou rozložení, které už je používáno, prověřte jeho závislé snímky a zkontrolujte výslednou prezentaci.
- Rozložení, které je stále používáno nějakým snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozložení, nebo odstraňte jen nepoužívaná rozložení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/python-net/slide-master/).

Pro skrytí zděděných log nebo dekorativních objektů masteru na jednom snímku nebo skrze sdílené rozložení viz [Control the Visibility of Master Graphics](/slides/cs/python-net/slide-master/). Příklad porovnává dva snímky používající stejný master.

## **Vybrat a použít rozložení snímku**

Používejte typ rozložení, když prezentace následuje standardní definice rozložení PowerPointu. Názvy rozložení jsou upravitelná uživatelem a mohou být lokalizována, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud není toto rozložení k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozložení. Vybrané rozložení je pak použito na první normální snímek přes vlastnost [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Změna rozložení snímku neodstraňuje obyčejné tvary přidané přímo na snímek. Nicméně pozice zástupců, zděděné formátování a shoda mezi existujícími zástupci a novým rozložením se mohou změnit, proto výstup při přepínání mezi výrazně odlišnými rozloženími pečlivě prověřte.

## **Přidat rozložení snímku**

Výběr a vytváření jsou samostatné operace. Předchozí příklad vybírá existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterlayoutslidecollection/add/) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** pojmenované `Report Title and Content`, pak přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Přidávejte rozložení jen tehdy, když šablona skutečně potřebuje další opakovaně použitelné uspořádání. Pokud již vhodné rozložení existuje, vyberte a použijte ho místo vytváření duplicitního.

## **Přidat zástupce do rozložení snímku**

Vlastnost [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/placeholder_manager/) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/) pro přidání tvarů zástupců do rozložení.

| Zástupce PowerPoint               | `LayoutPlaceholderManager` Metoda |
| --------------------------------- | --------------------------------- |
| ![Content](content.png)           | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                 | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)     | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)           | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)               | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)         | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)               | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)  | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Následující příklad ověřuje, že rozložení **Blank** existuje, přidá k němu čtyři zástupce a poté vytvoří normální snímek, který používá upravené rozložení. Pořadí je záměrné: zástupci jsou přidáni před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupců na tomto snímku.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zástupci na rozložení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupců v rozložení může ovlivnit závislé snímky. Nově přidaný zástupce rozložení se nepropíše do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a prověřte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozložení snímků**

Použijte metodu [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) k odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, beze změny.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Pro odstranění konkrétního rozložení nejprve použijte jeho vlastnost [has_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/has_depending_slides/) nebo metodu [get_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/get_depending_slides/). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/remove/) přesuňte všechny závislé snímky. Pokus o odstranění použitého rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozložení snímku**

Rozložení má své vlastní zástupce zápatí, čísla snímku a data‑času. Použijte vlastnost [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/header_footer_manager/) k řízení těchto zástupců pro jedno rozložení. To je užitečné například, když by obsahová rozložení měla zobrazovat zápatí, zatímco rozložení nadpisu ne.

Následující příklad bezpečně vybere rozložení a učiní jeho prvky zápatí viditelnými:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Ovládání viditelnosti zápatí na masteru a jeho podřízených rozloženích**

Pro aplikaci konzistentních nastavení zápatí napříč hierarchií masteru použijte vlastnost [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/header_footer_manager/). Metody šíření [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslideheaderfootermanager/) působí na master a jeho závislé rozložení snímků i normální snímky; necílí jen na jeden normální snímek.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaký je rozdíl mezi master snímkem a rozložením snímku?**

Master snímek definuje motiv prezentace a sdílené formátování. Rozložení snímku patří k masteru a určuje jedno opakované uspořádání zástupců. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat rozložení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce metodou [add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další prostředky použité zdrojovým rozložením.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud nepřepíšou ovlivněné formátování nebo objekty lokálně. Geometrie zástupců a zděděný styl se tak mohou změnit na mnoha snímcích najednou. Použijte [get_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/get_depending_slides/) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, pokud odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky jinému rozložení, nebo použijte [remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) k odstranění jen neodkazovaných rozložení.