---
title: Použít nebo změnit rozvržení snímků v Pythonu
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/python-net/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- úvodní snímek
- název a obsah
- hlavička sekce
- dvě oblasti obsahu
- porovnání
- pouze název
- prázdné rozvržení
- obsah s titulkem
- obrázek s titulkem
- název a svislý text
- svislý název a text
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Použijte, vytvořte a upravte rozvržení snímků v Aspose.Slides pro Python pomocí .NET, přidejte zástupné objekty, odstraňte nepoužitá rozvržení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku určuje polohy a formátování zástupných objektů, jako jsou názvy, text, obrázky, grafy a tabulky. Použití rozvržení dodává snímkům konzistentní strukturu a zároveň umožňuje, aby každý snímek obsahoval vlastní obsah.

Nejčastější rozvržení zahrnují:

- **Úvodní snímek**: Obsahuje zástupné objekty názvu a podnadpisu.
- **Název a obsah**: Obsahuje zástupný objekt názvu a obecný zástupný objekt obsahu.
- **Prázdný**: Neobsahuje žádné zástupné objekty a je užitečný, když budou všechny tvary umístěny ručně.

## **Pochopení dědičnosti rozvržení**

Prezentace má tři související úrovně:

1. [hlavní snímek](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) určuje motiv, sdílené formátování, pozadí a společné objekty.
2. [rozvržení snímku](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/) patří k hlavnímu snímku a definuje konkrétní uspořádání zástupných objektů.
3. [normální snímek](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozvržení a rozvržení dědí z hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je vytvořen normální snímek, jeho tvary zástupných objektů jsou generovány z vybraného rozvržení, zatímco obsah zadaný do těchto zástupných objektů patří k normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před tím, než z něj budete vytvářet snímky. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dvě důležité důsledky:

- Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozvržení, které je stále používáno snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozvržení nebo odstraňte pouze nepoužívaná rozvržení.

Další informace o nejvyšší úrovni této hierarchie najdete v [Slide Master](/slides/cs/python-net/slide-master/).

## **Výběr a použití rozvržení snímku**

Použijte typ rozvržení, když prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou editovatelné uživatelem a mohou být lokalizovány, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Název a obsah** na prvním hlavním snímku. Pokud není toto rozvržení k dispozici, úmyslně přejde na **Prázdný**. Druhá kontrola na null je nutná, protože prezentace může obsahovat pouze vlastní rozvržení. Vybrané rozvržení je pak použito na prvním normálním snímku pomocí vlastnosti [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/).

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

Změna rozvržení snímku neodstraňuje obyčejné tvary přidané přímo do snímku. Avšak pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se mohou změnit, takže výstup zkontrolujte při přepínání mezi výrazně odlišnými rozvrženími.

## **Přidání rozvržení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí příklad vybírá existující rozvržení; nevytváří ho. Pro vytvoření rozvržení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterlayoutslidecollection/add/) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Název a obsah** pojmenované `Report Title and Content` a následně přidá normální snímek založený na něm. Názvy rozvržení musí být v kolekci jedinečné.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Přidávejte rozvržení pouze tehde, když šablona skutečně potřebuje další opakovaně použitelnou strukturu. Pokud již existuje vhodné rozvržení, vyberte jej a znovu použijte místo vytváření duplikátu.

## **Přidání zástupných objektů do rozvržení snímku**

Vlastnost [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/placeholder_manager/) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| Placeholder PowerPointu            | Metoda `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Následující příklad ověří, že rozvržení **Prázdný** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který použije upravené rozvržení. Pořadí je záměrné: zástupné objekty jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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

![Zástupné objekty na rozvržení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení není automaticky doplněn do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a zkontrolujte každý závislý snímek.

{{% /alert %}}

## **Odstranění nepoužívaných rozvržení snímků**

Použijte metodu [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) k odstranění rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, nedotčena.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Pro odstranění konkrétního rozvržení nejprve použijte jeho vlastnost [has_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/has_depending_slides/) nebo metodu [get_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/get_depending_slides/). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/remove/) přiřaďte všechny závislé snímky. Pokus o odstranění používaného rozvržení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí na rozvržení snímku**

Rozvržení má vlastní zástupné objekty zápatí, číslo snímku a datum/čas. Pomocí vlastnosti [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/header_footer_manager/) můžete řídit tyto zástupné objekty pro jedno rozvržení. To je užitečné, například když rozvržení obsahu má zobrazovat zápatí, ale rozvržení titulku ne.

Následující příklad bezpečně vybere rozvržení a zobrazí jeho prvky zápatí:

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

## **Řízení viditelnosti zápatí na hlavním snímku a jeho podřízených rozvrženích**

Pro aplikaci jednotných nastavení zápatí v celé hierarchii hlavního snímku použijte vlastnost [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/header_footer_manager/). Metody šíření třídy [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslideheaderfootermanager/) působí na hlavní snímek, jeho závislá rozvržení a normální snímky; nezasahují jen jeden konkrétní normální snímek.

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

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek určuje motiv prezentace a sdílené formátování. Rozvržení snímku patří k hlavnímu snímku a definuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro jednotlivé snímky.

**Mohu kopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Při kopírování mezi prezentacemi také ověřte fonty, motivy, obrázky a další prostředky používané zdrojovým rozvržením.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky zdědí změny rozvržení, pokud lokálně nepřepíšou postižené formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou najednou změnit na mnoha snímcích. Použijte [get_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/get_depending_slides/) k identifikaci ovlivněných snímků před úpravou rozvržení.

**Co se stane, když odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky, nebo použijte [remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) k odstranění pouze neodkazovaných rozvržení.