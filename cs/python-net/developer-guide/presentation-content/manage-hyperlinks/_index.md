---
title: Správa hypertextových odkazů v prezentacích v Pythonu
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/python-net/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- textový hypertextový odkaz
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přidejte, formátujte, aktualizujte a odstraňte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for Python via .NET s ukázkami v Pythonu."
---
## **Úvod**

Hyperlink spojuje obsah prezentace s webovou stránkou nebo umístěním v prezentaci. V PowerPointu hypertextové odkazy obvykle slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides for Python via .NET vám umožňuje přidávat tyto odkazy, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}}

## **Přidání URL hypertextových odkazů**

Můžete přiřadit adresu URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu propojí vybraný text, zatímco tvar nebo rámec propojí objekt snímku.

### **Přidání URL hypertextových odkazů do textu**

Chcete-li propojit text s webovou stránkou, přiřaďte [Hyperlink](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/) do vlastnosti [hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/hyperlink_click/) části textu, jak je ukázáno níže. Pouze tato část textu se stane klikací.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Přidání URL hypertextových odkazů do tvarů a mediálních rámců**

Chcete-li učinit tvar nebo rámec klikacím, nastavte jeho vlastnost [hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/hyperlink_click/). Hypertextový odkaz patří objektu samotnému, nikoli části textu uvnitř něj.

Stejný postup platí pro obrázkové, audio a video rámce: přiřaďte hypertextový odkaz k rámci a v případě potřeby nastavte [tooltip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/tooltip/) odkazu.

Následující příklad učiní obdélník klikacím:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití hypertextových odkazů k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [set_internal_hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) k propojení textu „Page 2“ na prvním snímku s druhým snímkem.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formátování hypertextových odkazů**

### **Barva**

Vlastnost [color_source](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/color_source/) objektu [Hyperlink](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/) určuje, zda hypertextový odkaz používá barvu hypertextových odkazů prezentace nebo formátování části textu. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkcolorsource/) a nastavte výplň barvu části. Tato funkce byla zavedena v PowerPointu 2019; starší verze toto nastavení nepoužívají.

Následující příklad přidává dva textové hypertextové odkazy do stejného snímku. První používá červenou výplň textu, zatímco druhý zachovává výchozí barvu hypertextového odkazu.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit zvuk, který již přehrává. K nastavení těchto chování použijte následující vlastnosti:

- [Hyperlink.sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/sound/) určuje audio spojené s hypertextovým odkazem.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/stop_sound_on_click/) řídí, zda aktivace hypertextového odkazu zastaví předchozí zvuk.

#### **Přidání zvuku k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutím na tlačítko se přehraje zvuk a přejde na další snímek. Druhý tvar na tomto snímku při kliknutí zastaví předchozí zvuk, aniž by provedl akci navigace.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Extrahování zvuku z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hypertextového odkazu prvního tvaru do paměti pomocí [sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/sound/) a [binary_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Nastavení popisu (tooltip) a interakce**

Můžete aktualizovat následující vlastnosti [Hyperlink](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/) po přiřazení hypertextového odkazu k textu nebo tvaru:

- [tooltip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/tooltip/) nastavuje text, který může uživatel zobrazit jako nápovědu k odkazu.
- [target_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/target_frame/) určuje cílový rámec v nadřazeném HTML framesetu, pokud je to relevantní.
- [history](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/history/) určuje, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hypertextových odkazů.
- [highlight_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/highlight_click/) řídí, zda je hypertextový odkaz zvýrazněn po kliknutí.

## **Odstranění hypertextových odkazů z prezentací**

Použijte [get_any_hyperlinks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) k sesbírání kontejnerů hypertextových odkazů, včetně odkazů na části textu, před jejich úpravou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Chcete-li odstranit pouze jeden typ, zavolejte pouze [remove_hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) nebo [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); odstranění akce kliknutí neodstraní odpovídající akci při najetí myší.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Pro bezpodmínečné odstranění [remove_all_hyperlinks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) odstraní oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní čištění a pokrytí hlavních snímků, rozvržení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvoření kompletního inventáře hypertextových odkazů**

Před distribucí prezentace si proveďte inventuru jejích interaktivních akcí i webových odkazů. [get_any_hyperlinks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prohlédněte si jak [hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) tak [hyperlink_mouse_over](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) na každém kontejneru. Jsou nezávislé: stejný kontejner může obsahovat obě akce, takže kompletní zpráva potřebuje až dva řádky na kontejner.

Skenování pouze hypertextových odkazů na úrovni tvaru může přehlédnout odkazy připojené k částem textu. Místo toho dotazujte příslušný rozsah a uchovejte vrácené kontejnery, abyste je později mohli aktualizovat nebo odstranit jejich akce.

### **Dotazování na rozsahy prezentace, snímku a textového rámce**

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/) je k dispozici přes [Presentation.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/hyperlink_queries/) a [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/hyperlink_queries/). Každý rozsah podporuje stejné dotazy:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) vrací kontejnery s akcí kliknutí.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) vrací kontejnery s akcí při najetí myší.
- [get_any_hyperlinks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem na kliknutí, odkazem souboru při najetí myší, interní navigací mezi snímky, textovým odkazem při najetí myší a akcí makra. Neprovádí žádnou z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje vlastní odkazy obklopujícího tvaru.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

V tomto příkladu dotazy na prezentaci a snímek uvádějí tři kontejnery s kliknutím, dva kontejnery s najetím myší a tři kontejnery s jednou z akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikace akcí a cílů**

Použijte [Hyperlink.action_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/action_type/) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkactiontype/) zahrnují více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `HYPERLINK` | Externí hypertextový odkaz; prověřte URL a jeho schéma. |
| `JUMP_SPECIFIC_SLIDE` | Interní navigace na konkrétní snímek. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Vestavěná navigace v prezentaci, vyhodnocována v kontextu prezentace. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Ukončení aktuálního představení nebo spuštění vlastního představení. |
| `START_MACRO` | Spuštění makra. |
| `START_PROGRAM` | Spuštění programu. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Otevře soubor nebo další prezentaci; posuzujte odděleně od webových URL. |
| `START_STOP_MEDIA` | Spuštění nebo zastavení přehrávání média. |
| `NO_ACTION`, `UNKNOWN` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující revizi. |

Externí cíle čtěte z [external_url](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/external_url/) a specifické interní cíle z [target_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/target_slide/). Interní akce a vestavěné příkazy mohou nemít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Uchovávejte [external_url_original](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/external_url_original/), pokud se liší od normalizované URL, a zahrňte [tooltip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/tooltip/), pokud je k dispozici.

### **Zpráva, sanitace a ověření hypertextových odkazů**

Následující příklad v Pythonu načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu ji otevře k opětovné kontrole obou typů aktivace. Před úpravou sbírá kontejnery a dotazuje každý rozsah snímků jednou, aby se předešlo duplicitnímu zpracování. Dotazy na prezentaci zahrnují běžné snímky; pro inventuru celého balíčku příklad dotazuje běžné snímky, hlavní snímky, rozvržení, poznámky a hlavní a podklady poznámek, pokud jsou přítomny.

Zpráva zaznamenává číslování snímků od jedné a [slide_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/slide_id/) , pokud je k dispozici. Sběrač uchovává vlastní snímek a rozsah spolu s každým vráceným kontejnerem. Hlavní snímky, rozvržení a poznámky nemají běžné číslování snímků a jsou identifikovány svým rozsahem. Kontejnery tvarů a kontejnery formátování částí textu jsou označeny samostatně; ostatní typy kontejnerů si zachovávají svůj název typ během běhu. Každý kontejner získá ID lokální zprávy, aby jeho dvě akce mohly být propojeny.

Tato úmyslně restriktivní aplikační politika povoluje pouze absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, akce souborů, jiné akce prezentace, neznámé akce a další schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoli bezpečnostní verdikt Aspose.Slides. Pouze HTTPS nezaručuje důvěru: přidejte seznam povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez sledování odkazů nebo spouštění akcí.

Pro nápravu kontejnerů [hyperlink_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) podporuje [set_external_hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Zde jsou zakázané externí odkazy na kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí myší jsou odstraňovány nezávisle. Nastavte `replace_external_clicks` na `False`, pokud chcete místo toho odstranit všechna porušení politiky. Vyberte náhradní stránku spravovanou aplikací před nasazením.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označte akce při najetí myší a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o vodítko k revizi, ne o test schopnosti nebo záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [obrázky](/slides/cs/python-net/convert-powerpoint-to-png/) a [video](/slides/cs/python-net/convert-powerpoint-to-video/) nemohou zachovat interaktivní hypertextové odkazy; označte každou akci při auditu pro tyto výstupy.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Proveď dotaz na každý rozsah snímku jednou a uchovej jeho vlastníka u každého kontejneru.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

S vytvořeným vstupem výše zpráva obsahuje pět řádků akcí. Odkaz na soubor při najetí myší a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a interní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázaný externí odkaz na kliknutí také testuje větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím myší si ponechá svou akci kliknutí.

Toto selektivní čištění se liší od [remove_all_hyperlinks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty nebo jiný aktivní obsah a neověřuje exportovaný soubor PDF nebo HTML.

## **Často kladené otázky**

**Jak mohu propojit sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na jednotlivý snímek. Pro vytvoření navigace do sekce odkazujte na první snímek v dané sekci.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku tak, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou dostupné během prezentace na snímcích, které používají odpovídající hlavní snímek nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video ne. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).