---
title: Automatisera lokalisering av presentationer med Python
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/python-net/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- undertryck stavningskontroll
- korrekturspråk
- språk-id
- flerspråkig text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Ange korrekturspråk för PowerPoint- och OpenDocument-presentationstext i Python med Aspose.Slides, inklusive standardinställningar och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides for Python via .NET låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [BasePortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/) för att identifiera korrekturspråket, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/spell_check/) för att tillåta eller undertrycka stavningskontroller och [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/proof_disabled/) för att styra det bredare ingen‑korrigering‑tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Den här artikeln förklarar hur du tilldelar ett språk till specifik text, anger standardspråk för ny text med [LoadOptions.default_text_language](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/default_text_language/), bygger flerspråkiga stycken, väljer mellan `spell_check` och `proof_disabled` och bevarar de avsedda inställningarna när du använder [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ställ in korrekturspråket för text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/), nå den önskade textdelen via [Portion.portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/portion_format/), och tilldela dess språk‑identifierare. Följande exempel skapar en form, anger brittisk engelska som korrekturspråk och sparar resultatet med [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in standardspråk för ny text**

Använd [LoadOptions.default_text_language](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/default_text_language/) för att ange vilket korrekturspråk Aspose.Slides ska tilldela ny skapad text. Denna inställning är användbar när det mesta eller all ny text i en presentation använder samma språk. Den ändrar inte språk‑metadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd flera språk i ett stycke**

Ett [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) för varje språk och ange dess `language_id` oberoende.

Detta exempel skapar ett stycke med engelska och franska delar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivera eller undertryck stavningskontroll för enskilda delar**

[PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/) ärver de gemensamma textegenskaperna som definieras av [BasePortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/). Åtkomst en parts format via [Portion.portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/portion_format/) och ställ in [BasePortionFormat.spell_check](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/spell_check/) för att styra om ett presentationsprogram får kontrollera stavning för den delen. Standardvärdet är `False`: `True` tillåter stavningskontroll, medan `False` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför ha olika värden. [BasePortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/) och `spell_check` har kompletterande syften: `language_id` identifierar korrekturspråket, medan `spell_check` avgör om stavningskontroller är tillåtna för delen.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/proof_disabled/) styr också korrektur, men det representerar det bredare ”do not proof”-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/). Använd `spell_check` när du behöver en direkt Boolesk växel specifikt för stavningskontroller. Använd `proof_disabled` när du vill bevara eller uttryckligen kontrollera presentationens ingen‑korrigering‑metadata, inklusive dess `NOT_DEFINED`‑tillstånd. Om du ställer in båda egenskaperna, håll deras värden konsistenta; kombinera inte `spell_check = True` med `proof_disabled = slides.NullableBool.TRUE`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att köra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, läser in den, tilldelar olika stavningskontroll‑inställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) sammanslår intilliggande delar som har samma formatering. En skillnad i `spell_check` ensam hindrar inte sådana delar från att slås ihop; efter sammanslagning behåller den resulterande delen `spell_check`‑värdet från den första delen. Om delar behöver olika stavningskontroll‑inställningar, anropa `join_portions_with_same_formatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `language_id`‑värden förblir separata eftersom deras korrekturspråksformatering skiljer sig.

## **FAQ**

**Översätter ett språk‑ID texten?**

Nej. [BasePortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och ange sedan lämplig språk‑identifierare för varje översatt del.

**Styr korrekturspråket teckensnitt, avstavning eller radbrytning?**

Nej. Språk‑identifieraren är avsedd för korrektur. Textåtergivning och layout beror främst på tillgängliga [fonts](/slides/sv/python-net/powerpoint-fonts/), skriftsystemet och inställningarna för textramen. För pålitlig återgivning, tillhandahåll de nödvändiga teckensnitten, konfigurera [font substitution](/slides/sv/python-net/font-substitution/) eller [embed fonts](/slides/sv/python-net/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet med flerspråkigt stycke.

**Ska jag använda `default_text_language` eller `language_id`?**

Använd [LoadOptions.default_text_language](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/default_text_language/) när du vill ha ett standardvärde för ny skapad text. Använd [BasePortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.