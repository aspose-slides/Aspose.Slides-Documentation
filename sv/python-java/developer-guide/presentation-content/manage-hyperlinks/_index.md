---
title: Hantera presentationshyperlänkar i Python via Java
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/python-java/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- text‑hyperlänk
- bild‑hyperlänk
- form‑hyperlänk
- bild‑hyperlänk
- video‑hyperlänk
- ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java, med Python-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller ett mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides for Python via Java låter dig lägga till dessa länkar, styra deras utseende och ljud, uppdatera deras egenskaper samt ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du kommer åt hyperlänkar på presentations-, bild‑ eller text‑ram‑nivå.

{{% alert color="info" title="Note" %}}

Du kan också redigera presentationer med den [gratis online Aspose PowerPoint-redigeraren](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller ett mediaram. Det element du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ett ram länkar bildobjektet.

För presentationer som innehåller relativa hyperlänkar, se [Manage the Hyperlink Base](/slides/sv/python-java/presentation-properties/#manage-the-hyperlink-base) för att läsa, ändra eller rensa dokumentnivåns bas.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, skicka en [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) till textdelens [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick)-metod, som visas nedan. Endast den delen av texten blir klickbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ett ram klickbart, anropa dess [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick)-metod. Hyperlänken tillhör själva objektet snarare än en textdel inuti det.

Samma tillvägagångssätt gäller för bild-, ljud‑ och video‑ramar: tilldela hyperlänken till ramen och anropa [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) vid behov.

Följande exempel gör en rektangel klickbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) för att länka texten “Page 2” på den första bilden till den andra bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatera hyperlänkar**

### **Färg**

Metoden [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) för [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textdelens formatering. För att använda en anpassad textfärg, välj [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) och ange delens fyllningsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

Följande exempel lägger till två text‑hyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standard‑hyperlänkfärgen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Ljud**

En hyperlänk kan spela upp ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande metoder för att konfigurera dessa beteenden:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) specificerar ljudfilen som är associerad med hyperlänken.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) styr om aktivering av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänkljud**

Följande exempel läser in `sampleaudio.wav` och kopplar den till en knapp på den första bilden. När knappen klickas spelas ljudet och de går till nästa bild. En andra form på samma bild stoppar föregående ljud vid klick, utan att navigera någonstans.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extrahera hyperlänkljud**

Följande exempel öppnar presentationen som skapades ovan och läser hyperlänkljudet från den första formens hyperlänk till minnet via [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) och [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Verktygstips och interaktionsinställningar**

Du kan anropa följande [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)-metoder efter att du tilldelat en hyperlänk till text eller en form:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) anger den text som en visare kan visa som ett verktygstips för länken.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) specificerar målramen inom ett föräldra‑HTML‑frameset, när tillämpligt.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) styr om aktivering av länken lägger till destinationen i listan över visade hyperlänkar.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) för att samla hyperlänksbehållare, inklusive text‑del‑länkar, innan du ändrar dem. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att bara ta bort en typ, anropa endast [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) eller [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); att ta bort ett klick‑beteende tar inte bort motsvarande mus‑över‑beteende.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

För villkorslös borttagning tar [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av masters, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg en komplett hyperlänkinventering**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webb‑länkar. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) returnerar hyperlänksbehållare, såsom [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) och [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) och [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) för varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på form‑nivå kan missa länkar som är fästa vid textdelar. Fråga rätt omfång istället och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation, bild och text‑ram‑omfång**

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) finns tillgänglig via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) och [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Varje omfång stöder samma frågor:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) returnerar behållare med en klick‑åtgärd.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) returnerar behållare med en mus‑över‑åtgärd.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) returnerar behållare med någon av eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klick‑länk, en fil‑mus‑över‑länk, intern bild‑navigering, en text‑mus‑över‑länk och en makro‑åtgärd. Det utför inte någon av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räknarna beskriver behållare, inte totalsummor av åtgärder. Text‑ram‑omfånget exkluderar den omgivande formens egna länkar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För detta exempel rapporterar presentations‑ och bild‑frågor var och en tre klick‑behållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Text‑ram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) omfattar mer än webbnavigering:

| Värden | Betydelse för en granskning |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; inspektera URL:en och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigation, löst i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta nuvarande show eller starta en anpassad show. |
| `StartMacro` | Köra ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webbadresser. |
| `StartStopMedia` | Starta eller stoppa mediaplayback. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer med [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) och specifika interna destinationer med [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara värdet från [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) när det skiljer sig från den normaliserade URL:en, och inkludera verktygstipset från [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) när det finns.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande Python‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna på nytt. Det samlar behållare innan de ändras och använder referens‑jämlikhet för att undvika att bearbeta samma behållare två gånger. Presentations‑frågor omfattar vanliga bilder; för en paket‑omfattande inventering frågar den också explicit masters, layouter, anteckningar samt antecknings‑ och handout‑masters när de finns.

Rapporten registrerar en ett‑baserad bild‑index och [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) där det är tillgängligt. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) ger den ägande bilden för stöd‑behållare. Masters, layouter och anteckningar har ingen vanlig bild‑index och identifieras av sitt omfång. Form‑behållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt kör‑tids‑typnamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras. Rapporten sparar åtgärdstypen som de heltals‑konstanter som definieras av Java‑enumerationen.

Denna avsiktligt restriktiva applikations‑policy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bild‑mål. Den avvisar makron, program, fil‑åtgärder, andra bildspels‑åtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policy‑beslut, inte ett säkerhets­betyg från Aspose.Slides. HTTPS ensam etablerar ingen förtroende: lägg till host‑allowlists och andra kontroller för din applikation. Både originella och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För korrigering stöder behållarens [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) och [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Här ersätts förbjudna externa klick‑länkar med en fast HTTPS‑landningssida; andra förbjudna klick‑ och mus‑över‑åtgärder tas bort oberoende. Sätt `replace_external_clicks` till `False` för att ta bort alla policy‑överträdelse​er istället. Välj en applikations‑ägd ersättningssida innan distribution.

Rapportens export‑flagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifikt bild‑hopp som potentiellt ej‑stödd. Det är en gransknings‑hint, inte ett kapabilitets‑test eller en garanti för att o‑flagade länkar överlever export. Stödda [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/python-java/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärden, export‑alternativ och visare. Raster‑[images](/slides/sv/python-java/convert-powerpoint-to-png/) och [video](/slides/sv/python-java/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd när du granskar för dessa utdata.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Med den input som skapats ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makro‑klicken tas bort, medan HTTPS‑länkarna och intern bild‑navigering kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En input som innehåller en förbjuden extern klick‑URL övar även på ersättnings‑grenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑beteende behåller sin klick‑åtgärd.

Denna selektiva rensning skiljer sig från [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar endast hyperlänk‑åtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **Vanliga frågor**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig till en enskild bild. För att skapa navigering till ett avsnitt länkar du till den första bilden i det avsnittet.

**Kan jag fästa en hyperlänk på element i mastern så att den fungerar på alla bilder?**

Ja. Element i mastern och layouten stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på de bilder som använder motsvarande master eller layout.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan inte. Se export‑överväganden i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).