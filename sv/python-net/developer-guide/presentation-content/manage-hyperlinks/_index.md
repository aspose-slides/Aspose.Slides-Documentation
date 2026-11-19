---
title: Hantera presentationshyperlänkar i Python
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/python-net/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, med Python‑exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides för Python via .NET låter dig lägga till dessa länkar, kontrollera deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textramnivå.

{{% alert color="info" title="Note" %}}
Du kan också redigera presentationer med den [gratis online Aspose PowerPoint‑redigeraren](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element som du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ram länkar bildobjektet.

För presentationer som innehåller relativa hyperlänkar, se [Hantera hyperlänkbasen](/slides/sv/python-net/presentation-properties/#manage-the-hyperlink-base) för att läsa, ändra eller rensa dokumentnivåbasen.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, tilldela en [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) till textdelens [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/)‑egenskap, som visas nedan. Endast den delen av texten blir klickbar.

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

Tilldela en URL till rektangelns [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/)‑egenskap för att göra hela området klickbart. [Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ger läsaren en ledtråd om destinationen när de håller musen över rektangeln. Samma egenskaper gäller för bild-, ljud‑ och videoram.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) för att länka texten “Page 2” på den första bilden till den andra bilden.

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

Du kan ändra färgen på länkad text, spela upp eller stoppa ett ljud när en läsare aktiverar en länk, och ange den verktygstips som visas vid musöver.

### **Färg**

Egenskapen [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) för [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textdelens formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) och ange delens fyllnadsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

I detta exempel gör inställning av [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) på den första länken att dess text visas röd. Den andra länken behåller presentationens hyperlänkfärg.

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

En hyperlänk kan spela upp ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande egenskaper för att konfigurera detta beteende:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) angiver det ljud som är associerat med hyperlänken.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) kontrollerar om aktivering av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Knappen på den första bilden använder [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) för att spela upp ljud från en WAV‑fil när läsaren klickar för att gå vidare. På den andra bilden använder en separat knapp [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) för att stoppa uppspelning och låta läsaren stanna på den bilden.

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

Följande exempel öppnar presentationen som skapades ovan och läser den första formens hyperlänksljud till minnet via [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) och [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

### **Verktygstips‑ och interaktionsinställningar**

Du kan uppdatera följande [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)‑egenskaper efter att ha tilldelat en hyperlänk till text eller en form:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) anger den text som en betraktare kan visa som en ledtråd för länken.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) anger målramen inom ett överordnat HTML‑frameset, när tillämpligt.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) styr om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) för att samla hyperlänksbehållare, inklusive länkar för textdelar, innan du ändrar dem. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att ta bort endast en typ, anropa bara [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) eller [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); att ta bort en klickåtgärd tar inte bort motsvarande mus‑över‑åtgärd.

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

För ovillkorlig borttagning tar [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) bort båda aktiveringstyperna i den valda omfattningen i ett anrop. För selektiv rensning och täckning av master‑bilder, layouter och anteckningar, se [Rapportera, sanera och verifiera hyperlänkar](#report-sanitize-and-verify-hyperlinks).

### **Rensa hyperlänkar innan du ersätter SmartArt‑text**

När du ersätter ett stycke i en befintlig SmartArt‑nod, kan rensning av dess textdelar lämna en gammal hyperlänk i kraft. Hämta stycket via [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Innan du rensar dess delar, anropa [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) via [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) på textramen för nodformen som visar stycket. Detta tar bort varje hyperlänk i den ramen, inklusive länkar i dess andra stycken.

I `SmartArtHyperlink.pptx` är den tredje formen på den första bilden en SmartArt‑grafik. Exemplet ersätter det första stycket i dess fjärde nod. I denna presentation visar nodens första form det stycket.

Efter att ha lagt till båda delarna läser exemplet deras effektiva formatering med [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Den effektiva [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/)‑egenskapen returnerar den nya hyperlänken för den första delen och `None` för den andra.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # Ingen
```

## **Bygg en komplett hyperlänksinventering**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webblänkar. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) och [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) på varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på formnivå kan missa länkar som är fästa vid textdelar. Fråga den lämpliga omfattningen i stället, och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation, bild och textram‑omfattningar**

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) är tillgänglig via [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) och [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Varje omfattning stödjer samma frågor:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) returnerar behållare med en klickåtgärd.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) returnerar behållare med en mus‑över‑åtgärd.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returnerar behållare med antingen eller båda åtgärderna.

Detta exempel tilldelar klick‑ och mus‑över‑åtgärder till en form och dess text, samt en makroåtgärd till en separat knapp. Det jämför de behållare som returneras av [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) med antalen för varje aktiveringstyp. En textram‑fråga räknar endast länkar i texten. Formens egna åtgärder visas i bild‑ och presentationsfrågor.

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

För detta exempel rapporterar presentation‑ och bildfrågor vardera tre klickbehållare, två mus‑över‑behållare och tre behållare med antingen åtgärd. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) täcker mer än webbnavigering:

| Värden | Betydelse för en granskning |
| --- | --- |
| `HYPERLINK` | Extern hyperlänk; granska URL:en och dess schema. |
| `JUMP_SPECIFIC_SLIDE` | Intern navigering till en specifik bild. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Inbyggd bildspelsnavigering, löst i bildspelskontext. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Avsluta det aktuella bildspelet eller starta ett anpassat bildspel. |
| `START_MACRO` | Kör ett makro. |
| `START_PROGRAM` | Starta ett program. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Öppna en fil eller en annan presentation; granska separat från webb‑URL:er. |
| `START_STOP_MEDIA` | Starta eller stoppa medias uppspelning. |
| `NO_ACTION`, `UNKNOWN` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) och specifika interna destinationer från [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) när den skiljer sig från den normaliserade URL:en, och inkludera [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) när den finns.

### **Rapportera, sanera och verifiera hyperlänkar**

Detta exempel öppnar presentationen från föregående exempel och skriver en JSON‑post per åtgärd. Det använder [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) för att samla behållare på vanliga bilder, master‑bilder, layouter och anteckningar, inklusive antecknings‑ och handout‑master‑bilder när de finns. Det frågar varje omfattning en gång för att undvika dubblerad bearbetning, tillämpar policyn som beskrivs nedan, och öppnar den sparade presentationen igen för att kontrollera både klick‑ och mus‑över‑åtgärder.

Rapporten registrerar ett en‑baserat bildindex och [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) där det finns. Samlaren behåller den ägande bilden och omfattning tillsammans med varje returnerad behållare. Master‑bilder, layouter och anteckningar har inget vanligt bildindex och identifieras av sin omfattning. Formbehållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt runtime‑typsnamn. Varje behållare får ett lokalt rapport‑ID så att dess två åtgärder kan korreleras.

Denna medvetet restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, filåtgärder, andra bildspelsåtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policysbeslut, inte ett säkerhetsmål för Aspose.Slides. HTTPS ensamt etablerar inte förtroende: lägg till värd‑allowlists och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För återställning stöder behållarens [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) och [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick och förbjudna mus‑över‑åtgärder tas bort oberoende. Sätt `replace_external_clicks` till `False` för att ta bort alla policy‑brott istället. Välj en applikationsägd ersättningssida innan distribution.

Exportflaggan för rapporten använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifik bildhoppruttning som potentiellt icke‑stödd. Det är en granskningshint, inte ett kapacitetstest eller en garanti för att oflagade länkar överlever export. Stödda [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/python-net/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärden, exportalternativ och visare. Raster‑[images](/slides/sv/python-net/convert-powerpoint-to-png/) och [video](/slides/sv/python-net/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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
    # Fråga varje bildomfång en gång och behåll ägaren för varje behållare.
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

Med den indata som skapats ovan innehåller rapporten fem åtgärdsrader. Filens mus‑över‑länk och makroklick tas bort, medan HTTPS‑länkarna och intern bildnavigering kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En indata som innehåller en förbjuden extern klick‑URL övar också ersättningsgrenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑åtgärd behåller sin klickåtgärd.

Denna selektiva rensning skiljer sig från [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), som tar bort båda aktiveringstyperna i hela den valda omfattningen oavsett policy. Verifieringen här kontrollerar endast hyperlänksåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig till en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i avsnittet.

**Kan jag bifoga en hyperlänk till master‑bildselement så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelsläget på bilder som använder motsvarande master eller layout.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan inte. Se exportaspekterna i [Rapportera, sanera och verifiera hyperlänkar](#report-sanitize-and-verify-hyperlinks).