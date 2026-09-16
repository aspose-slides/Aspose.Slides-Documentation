---
title: Hantera presentationshyperlänkar i Python
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/python-net/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- videohyperlänk
- justerbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, med Python-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar oftast för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides for Python via .NET låter dig lägga till dessa länkar, styra deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textramnivå.

{{% alert color="info" title="Note" %}}

Du kan också redigera presentationer med den [gratis online Aspose PowerPoint‑editorn](https://products.aspose.app/slides/sv/editor).

{{% /alert %}}

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element som du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ram länkar bildobjektet.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, tilldela ett [Hyperlink](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/) till textdelens [hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/hyperlink_click/)‑egenskap, som visas nedan. Endast den delen av texten blir klickbar.

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

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ram klickbar, ange dess [hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/hyperlink_click/)‑egenskap. Hyperlänken tillhör själva objektet snarare än en textdel i det.

Samma tillvägagångssätt gäller för bild-, ljud- och videoram: tilldela hyperlänken till ramen och ange länkens [tooltip](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/tooltip/) om så önskas.

Följande exempel gör en rektangel klickbar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [set_internal_hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) för att länka texten “Page 2” på den första bilden till den andra bilden.

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

## **Formatera hyperlänkar**

### **Färg**

[color_source](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/color_source/)‑egenskapen för [Hyperlink](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textdelens formatering. För att använda en anpassad textfärg, välj [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkcolorsource/) och ange delens fyllnadsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

Följande exempel lägger till två texthyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standard‑hyperlänkfärgen.

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

### **Ljud**

En hyperlänk kan spela upp ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande egenskaper för att konfigurera dessa beteenden:

- [Hyperlink.sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/sound/) specificerar ljudet som är associerat med hyperlänken.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/stop_sound_on_click/) styr om aktivering av hyperlänken stoppar det föregående ljudet.

#### **Lägg till ett hyperlänksljud**

Följande exempel laddar `sampleaudio.wav` och kopplar det till en knapp på den första bilden. Klick på knappen spelar upp ljudet och navigerar till nästa bild. En andra form på samma bild stoppar det föregående ljudet när den klickas, utan att utföra någon navigationsåtgärd.

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

#### **Extrahera ett hyperlänksljud**

Följande exempel öppnar presentationen som skapades ovan och läser hyperlänkens ljud för den första formen till minnet via [sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/sound/) och [binary_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audio/binary_data/).

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

### **Verktygstips och interaktionsinställningar**

Du kan uppdatera följande [Hyperlink](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/)‑egenskaper efter att ha tilldelat en hyperlänk till text eller en form:

- [tooltip](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/tooltip/) anger den text som en tittare kan visa som ett tips för länken.
- [target_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/target_frame/) specificerar mål‑ramen inom en förälder‑HTML‑frameset, när det är tillämpligt.
- [history](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/history/) kontrollerar om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [highlight_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/highlight_click/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [get_any_hyperlinks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) för att samla in hyperlänkbehållare, inklusive länkar i textdelar, innan du ändrar dem. Följande exempel tar bort båda aktiverings typerna från den första bilden. För att bara ta bort en typ, anropa endast [remove_hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) eller [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); att ta bort en klick‑åtgärd tar inte bort dess mus‑över‑motsvarighet.

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

För ovillkorlig borttagning tar [remove_all_hyperlinks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) bort båda aktiverings typerna i det valda omfånget i ett anrop. För selektiv rensning och täckning av master‑, layout‑ och not‑bilder, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett komplett hyperlänkinventarium**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webb‑länkar. [get_any_hyperlinks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) och [hyperlink_mouse_over](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) på varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på form‑nivå kan missa länkar som är bifogade till textdelar. Fråga rätt omfång istället, och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation, bild och textram‑omfång**

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/) är tillgänglig via [Presentation.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/hyperlink_queries/) och [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/hyperlink_queries/). Varje omfång stöder samma frågor:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) returnerar behållare med en klick‑åtgärd.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) returnerar behållare med en mus‑över‑åtgärd.
- [get_any_hyperlinks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returnerar behållare med någon eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klick‑länk, en fil‑mus‑över‑länk, intern bild‑navigering, en text‑mus‑över‑länk och en makro‑åtgärd. Det utför inte någon av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räkningarna beskriver behållare, inte totala åtgärder. Textram‑omfånget utesluter den omgivande formens egna länkar.

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

I detta exempel rapporterar presentation‑ och bild‑frågor vardera tre klick‑behållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [Hyperlink.action_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/action_type/) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkactiontype/) omfattar mer än webb‑navigering:

| Värden | Betydelse för en revision |
| --- | --- |
| `HYPERLINK` | Extern hyperlänk; inspektera URL:n och dess schema. |
| `JUMP_SPECIFIC_SLIDE` | Intern navigering till en specifik bild. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Inbyggd bildspels‑navigering, löst i bildspels‑sammanhang. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Avsluta det aktuella show‑et eller starta ett anpassat show. |
| `START_MACRO` | Exekvera ett makro. |
| `START_PROGRAM` | Starta ett program. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Öppna en fil eller en annan presentation; granska separat från webb‑URL:er. |
| `START_STOP_MEDIA` | Starta eller stoppa mediaplayback. |
| `NO_ACTION`, `UNKNOWN` | Ingen navigerings‑åtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [external_url](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/external_url/) och specifika interna destinationer från [target_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/target_slide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara [external_url_original](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/external_url_original/) när den skiljer sig från den normaliserade URL:n, och inkludera [tooltip](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/tooltip/) när den är tillgänglig.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande Python‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiverings typerna igen. Det samlar behållare innan de ändras och frågar varje bild‑omfång en gång för att undvika dubbletter. Presentations‑frågor täcker vanliga bilder; för ett paket‑omfattande inventarium frågar exemplet vanliga bilder, master‑bilder, layouter, noter samt not‑ och handout‑master när de finns.

Rapporten registrerar ett index som börjar på 1 samt [slide_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/slide_id/) där det finns. Samlaren behåller den ägande bilden och omfånget tillsammans med varje returnerad behållare. Master‑, layout‑ och not‑bilder har inget vanligt bild‑index och identifieras av sitt omfång. Form‑behållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt kör‑tids‑typsnamn. Varje behållare får ett lokalt rapport‑ID så att dess två åtgärder kan koreleras.

Denna avsiktligt restriktiva applikations‑policy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bild‑mål. Den avvisar makron, program, fil‑åtgärder, andra bildspels‑åtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policy‑beslut, inte ett säkerhets‑betyg från Aspose.Slides. HTTPS ensam etablerar inte förtroende: lägg till host‑allowlists och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För korrigering stöder behållarens [hyperlink_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) och [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Här ersätts förbjudna externa klick‑länkar med en fast HTTPS‑landningssida; andra förbjudna klick‑ och mus‑över‑åtgärder tas bort oberoende. Ställ in `replace_external_clicks` till `False` för att ta bort alla policy‑överträdelser istället. Välj en applikations‑ägd ersättningssida innan distribution.

Rapportens export‑flagga använder en konservativ PDF‑gransknings‑policy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifikt bild‑hopp som potentiellt ej stödjda. Det är en gransknings‑hint, inte ett kapacitets‑test eller en garanti för att o‑flagade länkar överlever export. Stödd [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/python-net/convert-powerpoint-to-html/)‑export kan bevara hyperlänkar, beroende på åtgärd, exportalternativ och visare. Raster‑[images](/slides/sv/python-net/convert-powerpoint-to-png/) och [video](/slides/sv/python-net/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid revision för dessa utdata.

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
    # Fråga varje bildomfång en gång och behåll dess ägare för varje behållare.
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

Med den input som skapades ovan innehåller rapporten fem åtgärds‑rader. Fil‑mus‑över‑länken och makro‑klick‑åtgärden tas bort, medan HTTPS‑länkarna och intern bild‑navigering kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En input som innehåller en förbjuden extern klick‑URL demonstrerar också ersättnings­grenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑värde behåller sin klick‑åtgärd.

Denna selektiva rensning skiljer sig från [remove_all_hyperlinks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), som tar bort båda aktiverings typerna i det valda omfånget oavsett policy. Verifieringen här kontrollerar bara hyperlänk‑åtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig mot en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i avsnittet.

**Kan jag bifoga en hyperlänk till master‑bild‑element så att den fungerar på alla bilder?**

Ja. Element i master‑bilder och layouter stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på de bilder som använder motsvarande master eller layout.

**Kommer hyperlänkar bevaras vid export till PDF, HTML, bilder eller video?**

Stödd PDF‑ och HTML‑export kan bevara hyperlänkar; rasterbilder och video kan inte. Se export‑överväganden i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

---
title: Hantera presentationshyperlänkar i Python
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/python-net/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- videohyperlänk
- justerbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, med Python-exempel."
---