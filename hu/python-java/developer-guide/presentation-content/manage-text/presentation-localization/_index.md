---
title: Automatizálja a prezentáció lokalizálását Pythonon keresztül Java-val
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/python-java/presentation-localization/
keywords:
- nyelvváltás
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- bizonyítási nyelv
- nyelvazonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Állítson be bizonyítási nyelveket a PowerPoint és OpenDocument prezentáció szövegéhez Pythonban Java-val az Aspose.Slides segítségével, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Aspose.Slides for Python via Java lehetővé teszi, hogy egyes szövegrészek bizonyítási metaadatait konfigurálja. Használja a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) metódust a bizonyítási nyelv azonosításához, a [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) metódust a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setProofDisabled) metódust a tágabb „nem bizonyítás” állapot vezérléséhez. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző bizonyítási szabályokat is tartalmazhat.

Ez a cikk bemutatja, hogyan lehet egy nyelvet hozzárendelni a konkrét szöveghez, hogyan állítható be az új szöveg alapértelmezett nyelve a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) segítségével, hogyan építhető többnyelvű bekezdés, hogyan választható a [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) és a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setProofDisabled) között, valamint hogyan őrizhetők meg a kívánt beállítások a [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) használata során. Ezek a tulajdonságok metaadatot tárolnak a prezentációs alkalmazások számára; nem fordítják le a szöveget, nem végeznek szótár alapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **Állítsa be a bizonyítási nyelvet a szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/), érje el a szükséges szövegrészt a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getPortionFormat) segítségével, és rendelje hozzá a nyelvazonosítót. A következő példa egy alakzatot hoz létre, brit angolt állít be bizonyítási nyelvként, majd az eredményt a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódussal menti:

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

## **Állítsa be az alapértelmezett nyelvet az új szöveghez**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a bizonyítási nyelv megadásához, amelyet az Aspose.Slides az újonnan létrehozott szöveghez rendel. Ez a beállítás akkor hasznos, ha a prezentáció legtöbb vagy összes új szövege ugyanazt a nyelvet használja. Nem változtatja meg a már kifejezett nyelvvel rendelkező szöveg nyelvi metaadatait.

A következő példa egy olyan prezentációt hoz létre, amelynek új szövege német bizonyítási szabályokat használ:

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

## **Használjon több nyelvet egy bekezdésben**

Egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) szövegrészek gyűjteményét tartalmazza. Hozzon létre minden nyelvhez külön [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) elemet, és állítsa be a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) értékét önállóan.

Ez a példa egy bekezdést hoz létre angol és francia szövegrészekkel:

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

## **Engedélyezze vagy tiltja a helyesírás-ellenőrzést egyedi szövegrészeknél**

A [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) örökli a [BasePortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/) által meghatározott közös szövegtulajdonságokat. A szövegrész formátumához a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getPortionFormat) segítségével férhet hozzá, és a [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) használatával szabályozhatja, hogy egy prezentációs alkalmazás ellenőrizze-e a helyesírást az adott részben. Az alapértelmezett érték `False`: a `True` engedélyezi a helyesírás-ellenőrzést, míg a `False` letiltja azt.

A beállítás egyedi szövegrészekre vonatkozik. Ezért a ugyanabban a bekezdésben lévő különböző részek különböző értékeket használhatnak. A [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) és a [setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) kiegészítő célokat szolgálnak: a [setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) határozza meg a bizonyítási nyelvet, míg a [setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) meghatározza, hogy a részhez engedélyezett-e a helyesírás-ellenőrzés.

A [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setProofDisabled) is szabályozza a bizonyítást, de a tágabb „ne bizonyítsa” állapotot egy [NullableBool](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/) segítségével ábrázolja. Használja a [setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) metódust, ha közvetlen Boolean kapcsolóra van szüksége kifejezetten a helyesírás-ellenőrzéshez. Használja a [setProofDisabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setProofDisabled) metódust, ha a prezentáció „nem bizonyítás” metaadatait szeretné megőrizni vagy kifejezetten vezérelni, beleértve a [NullableBool.NotDefined](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#NotDefined) állapotot is. Ha mindkét tulajdonságot beállítja, tartsa értékeiket konzisztensen; ne kombinálja a [setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) `True` értékét a [setProofDisabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setProofDisabled) [NullableBool.True](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#True) állapotával.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt bizonyítási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótár alapú helyesírás-ellenőrzéshez vagy hibás szavak listájának visszaadásához.

A következő teljes példa egy bemeneti prezentációt hoz létre, betölti, két szövegrésznek a ugyanabban a bekezdésben különböző helyesírás-ellenőrzési beállításokat és bizonyítási nyelveket rendel, elmenti az eredményt, újra megnyitja, és ellenőrzi a tárolt értékeket:

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

A [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) összevonja az egymás melletti, azonos formázású szövegrészeket. A [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) különbsége önmagában nem tartja szét ezeket a részeket; összefűzés után az eredményrészlet megtartja az első rész [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpellCheck) értékét. Ha a részeknek különböző helyesírás-ellenőrzési beállításokra van szüksége, hívja meg a [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) metódust a beállítások hozzárendelése előtt, vagy ellenőrizze az eredményes részlet határait, és később alkalmazza újra a beállításokat. A különböző [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) értékkel rendelkező részek továbbra is különállóak maradnak, mivel a bizonyítási nyelv formázása eltér.

## **GYIK**

**Átfordítja-e a nyelvazonosító a szöveget?**

Nem. A [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) metaadatot tárol a helyesírás és nyelvtan ellenőrzéséhez; nem módosítja a szövegtartalmat. A szöveget külön kell lefordítani, majd a megfelelő nyelvazonosítót beállítani minden lefordított szövegrészhez.

**A bizonyítási nyelv befolyásolja a betűtípusokat, szótagolást vagy a sortörést?**

Nem. A nyelvazonosító a bizonyításra szolgál. A szöveg renderelése és elrendezése elsősorban a rendelkezésre álló [fonts](/slides/hu/python-java/powerpoint-fonts/), a írásrendszer és a szövegkeret beállításai függvénye. A megbízható rendereléshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/python-java/font-substitution/) vagy [embed fonts](/slides/hu/python-java/embedded-font/) beállításokat a prezentációban.

**Használhat-e egy bekezdés több bizonyítási nyelvet?**

Igen. Rendeljen minden nyelvet egy külön szövegrészhez, ahogy a többnyelvű bekezdés példájában látható.

**Használnom kell a [setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) vagy a [setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) metódust?**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust, amikor alapértelmezettet szeretne az újonnan létrehozott szövegre. Használja a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) metódust, amikor egy adott szövegrésznek explicit bizonyítási nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.