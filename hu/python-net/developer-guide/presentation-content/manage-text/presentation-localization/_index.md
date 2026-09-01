---
title: Prezentációk lokalizációjának automatizálása Pythonban
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/python-net/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- javítási nyelv
- nyelvi azonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Állítsa be a javítási nyelveket a PowerPoint és OpenDocument prezentációk szövegéhez Pythonban az Aspose.Slides használatával, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi a javítási metaadatok konfigurálását egyedi szövegrészekhez. Használja a [BasePortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/) a javítási nyelv azonosításához, a [BasePortionFormat.spell_check](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/spell_check/) a helyesírás-ellenőrzés engedélyezéséhez vagy tiltásához, valamint a [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/proof_disabled/) a szélesebb körű „ne javíts” állapot szabályozásához. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző javítási szabályokat is tartalmazhat.

Ez a cikk bemutatja, hogyan rendeljen nyelvet egy adott szöveghez, hogyan állítsa be az új szöveg alapértelmezett nyelvét a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/) segítségével, hogyan építsen többnyelvű bekezdéseket, hogyan válasszon a `spell_check` és a `proof_disabled` között, és hogyan őrizze meg a kívánt beállításokat a [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) használata esetén. Ezek a tulajdonságok metaadatot tárolnak a prezentációs alkalmazások számára; nem fordítják le a szöveget, nem végeznek szótári alapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **A szöveg javítási nyelvének beállítása**

Hozzon létre vagy töltön be egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, érje el a kívánt szövegrészt a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/) segítségével, és adja meg a nyelvazonosítót. Az alábbi példa egy alakzatot hoz létre, brit angolt állít be javítási nyelvként, majd az eredményt a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódussal menti:

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

## **Az új szöveg alapértelmezett nyelvének beállítása**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/) beállítást a javítási nyelv megadására, amelyet az Aspose.Slides az újonnan létrehozott szövegekhez rendel. Ez a beállítás akkor hasznos, ha a prezentáció nagy részén vagy egészében ugyanaz a nyelv használatos. Nem változtatja meg a már expliciten nyelvet megadott szöveg metaadatait.

Az alábbi példa egy olyan prezentációt hoz létre, amelyben az új szöveg német javítási szabályokat követ:

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

## **Több nyelv használata egy bekezdésben**

Egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) szövegrészek gyűjteményét tartalmazza. Hozzon létre minden nyelvhez külön [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot, és állítsa be annak `language_id` értékét önállóan.

Ez a példa egy bekezdést hoz létre angol és francia részekkel:

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

## **Helyesírás-ellenőrzés engedélyezése vagy letiltása egyedi részeknél**

A [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) örökli a [BasePortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/) által definiált közös szövegtulajdonságokat. Egy rész formátumát a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/) segítségével érheti el, és a [BasePortionFormat.spell_check](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/spell_check/) beállításával szabályozhatja, hogy a prezentációs alkalmazás ellenőrizze-e a helyesírást azon a részen. Az alapértelmezett érték `False`: a `True` engedélyezi a helyesírás-ellenőrzést, míg a `False` letiltja azt.

A beállítás egyedi szövegrészekre vonatkozik. Így ugyanabban a bekezdésben különböző részek különböző értékeket használhatnak. A [BasePortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/) és a `spell_check` kiegészítő célt szolgálnak: a `language_id` azonosítja a javítási nyelvet, míg a `spell_check` határozza meg, hogy a helyesírás-ellenőrzés engedélyezett‑e a részen.

A [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/proof_disabled/) szintén a javítást szabályozza, de egy szélesebb körű „ne javíts” állapotot ábrázol, amely egy [NullableBool](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/). Használja a `spell_check`‑et, ha közvetlen Boolean kapcsolóra van szüksége a helyesírás-ellenőrzéshez. Használja a `proof_disabled`‑et, ha a prezentáció „nem javított” metaadatait, beleértve a `NOT_DEFINED` állapotot, meg szeretné őrizni vagy kifejezetten vezérelni. Ha mindkét tulajdonságot beállítja, tartsa konzisztensen az értékeket; ne kombinálja a `spell_check = True`‑t a `proof_disabled = slides.NullableBool.TRUE`‑nal.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt javítási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótári alapú helyesírás-ellenőrzésre, és nem ad vissza hibás szavak listáját.

Az alábbi teljes példa egy bemeneti prezentációt hoz létre, betölti, különböző helyesírás-ellenőrzési beállításokat és javítási nyelveket rendel két részhez ugyanabban a bekezdésben, elmenti az eredményt, újra megnyitja, majd ellenőrzi a tárolt értékeket:

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

A [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) összevonja a szomszédos részeket, ha azok ugyanazzal a formázással rendelkeznek. Egyetlen `spell_check` különbség önmagában nem tartja szét ezeket a részeket; az összevonás után a kapott rész megtartja az első rész `spell_check` értékét. Ha a részeknek eltérő helyesírás-ellenőrzési beállításokra van szüksége, hívja meg a `join_portions_with_same_formatting` metódust a beállítások alkalmazása előtt, vagy ellenőrizze a keletkezett részhatárokat, és állítsa be a beállításokat újra ezután. A különböző `language_id` értékekkel rendelkező részek különállóak maradnak, mivel a javítási nyelv formázása eltér.

## **GYIK**

**A nyelvi azonosító lefordítja a szöveget?**

Nem. A [BasePortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/) a helyesírás‑ és nyelvtani javításhoz szükséges metaadatot tárol, nem módosítja a szöveg tartalmát. A szöveget külön kell lefordítani, majd minden lefordított részhez a megfelelő nyelvi azonosítót kell beállítani.

**A javítási nyelv szabályozza a betűtípusokat, a szóelválasztást vagy a sortörést?**

Nem. A nyelvi azonosító kizárólag a javításhoz kapcsolódik. A szöveg renderelése és elrendezése elsősorban a rendelkezésre álló [fonts](/slides/hu/python-net/powerpoint-fonts/), a írásrendszer és a szövegkeret beállításai függvényében történik. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/python-net/font-substitution/) lehetőséget, vagy ágyazza be a betűtípusokat a [embed fonts](/slides/hu/python-net/embedded-font/) útmutató szerint.

**Használhat egy bekezdés több javítási nyelvet?**

Igen. Rendeljen minden nyelvet egy külön részhez, ahogy azt a többnyelvű bekezdés példában is bemutatjuk.

**Használjam a `default_text_language`‑t vagy a `language_id`‑t?**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/)‑t, ha alapértelmezett nyelvet szeretne az újonnan létrehozott szövegekhez. Használja a [BasePortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/)‑t, ha egy konkrét résznek explicit javítási nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.