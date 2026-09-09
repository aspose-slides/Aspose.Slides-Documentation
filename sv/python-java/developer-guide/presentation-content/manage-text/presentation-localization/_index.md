---
title: Automatisera presentationslokalisering i Python via Java
linktitle: Presentationslokalisering
type: docs
weight: 100
url: /sv/python-java/presentation-localization/
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
- Java
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument-presentationstext i Python via Java med Aspose.Slides, inklusive standardinställningar och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för Python via Java låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) för att identifiera korrekturspråket, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) för att tillåta eller undertrycka stavningskontroller, och [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setProofDisabled) för att styra det bredare "ingen korrektur"-tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Denna artikel förklarar hur du tilldelar ett språk till specifik text, anger standardspråk för ny text med [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), bygger flerspråkiga stycken, väljer mellan [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) och [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setProofDisabled), samt bevarar de avsedda inställningarna när du använder [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ange korrekturspråk för text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), få åtkomst till den önskade textdelen via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getPortionFormat) och tilldela dess språkidentifierare. Följande exempel skapar en form, ställer in brittisk engelska som korrekturspråk och sparar resultatet med [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange standardspråk för ny text**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) för att specificera det korrekturspråk som Aspose.Slides tilldelar ny skapad text. Denna inställning är användbar när största delen eller all ny text i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Använd flera språk i ett stycke**

Ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) för varje språk och ställ in dess [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) oberoende.

Detta exempel skapar ett stycke med engelska och franska delar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktivera eller undertryck stavningskontroll för enskilda delar**

[PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/) ärver de gemensamma textegenskaper som definieras av [BasePortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/). Hämta en delens format via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getPortionFormat) och använd [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) för att styra om en presentationsapplikation får kontrollera stavning för den delen. Standardvärdet är `False`: `True` möjliggör stavningskontroll, medan `False` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför ha olika värden. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) och [setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) har kompletterande syften: [setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) identifierar korrekturspråket, medan [setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) bestämmer om stavningskontroller är tillåtna för delen.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setProofDisabled) styr också korrektur, men representerar det bredare "ingen korrektur"-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/). Använd [setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) när du behöver en direkt boolesk växel specifikt för stavningskontroller. Använd [setProofDisabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setProofDisabled) när du vill bevara eller explicit styra presentationens "ingen korrektur"-metadata, inklusive dess [NullableBool.NotDefined](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/#NotDefined)-tillstånd. Om du sätter båda egenskaperna, håll deras värden konsistenta; kombinera inte [setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) satt till `True` med [setProofDisabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setProofDisabled) satt till [NullableBool.True](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/#True)-tillståndet.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att köra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, läser in den, tilldelar olika stavningskontrollinställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kombinerar intilliggande delar som har samma formatering. En skillnad i [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) ensam håller inte sådana delar separata; efter att de har slagits ihop behåller den resulterande delen värdet för [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setSpellCheck) från den första delen. Om delar behöver olika stavningskontrollinställningar, anropa [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna därefter. Delar med olika [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId)-värden förblir separata eftersom deras korrekturspråksformatering skiljer sig.

## **Vanliga frågor**

**Översätter ett språk-ID texten?**

Nej. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och sätt sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket teckensnitt, avstavning eller radbrytning?**

Nej. Språkidentifieraren gäller endast korrektur. Textåtergivning och layout beror främst på tillgängliga [fonts](/slides/sv/python-java/powerpoint-fonts/), skriftsystemet och inställningarna för textramar. För pålitlig återgivning, tillhandahåll nödvändiga teckensnitt, konfigurera [font substitution](/slides/sv/python-java/font-substitution/) eller [embed fonts](/slides/sv/python-java/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet för flerspråkigt stycke.

**Ska jag använda [setDefaultTextLanguage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) eller [setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) när du vill ha ett standardspråk för ny skapad text. Använd [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.