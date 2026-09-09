---
title: Automatyzacja lokalizacji prezentacji w Pythonie za pośrednictwem Java
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/python-java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w Pythonie za pośrednictwem Java przy użyciu Aspose.Slides, w tym wartości domyślne i wielojęzyczne akapity."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia konfigurowanie metadanych korekty dla poszczególnych fragmentów tekstu. Użyj [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) aby określić język korekty, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) aby zezwolić lub zablokować sprawdzanie pisowni oraz [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setProofDisabled) aby kontrolować szerszy stan „bez korekty”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różne zasady korekty.

Ten artykuł wyjaśnia, jak przypisać język do konkretnego tekstu, ustawić domyślny język dla nowego tekstu przy użyciu [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), tworzyć wielojęzyczne akapity, wybierać pomiędzy [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setProofDisabled) oraz zachować zamierzone ustawienia przy użyciu [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Te właściwości przechowują metadane dla aplikacji prezentacji; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słowniku ani nie zwracają błędnie napisanych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu poprzez [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getPortionFormat), i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save):

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

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), aby określić język korekty, który Aspose.Slides przypisuje nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już posiada explicite określony język.

Następujący przykład tworzy prezentację, w której nowy tekst używa niemieckich reguł korekty:

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

## **Użyj wielu języków w jednym akapicie**

[Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/) zawiera kolekcję fragmentów tekstu. Utwórz osobny [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) dla każdego języka i ustaw jego [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) niezależnie.

Ten przykład tworzy jeden akapit z fragmentami w języku angielskim i francuskim:

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

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane w [BasePortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/). Uzyskaj dostęp do formatu fragmentu poprzez [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getPortionFormat) i użyj [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck), aby kontrolować, czy aplikacja prezentacji może sprawdzać pisownię tego fragmentu. Wartość domyślna to `False`: `True` zezwala na sprawdzanie pisowni, natomiast `False` je wyłącza.

Ustawienie dotyczy poszczególnych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc używać różnych wartości. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) i [setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) pełnią uzupełniające się funkcje: [setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) identyfikuje język korekty, natomiast [setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) określa, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setProofDisabled) również kontroluje korektę, ale reprezentuje szerszy stan „nie koryguj” jako [NullableBool](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/). Użyj [setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck), gdy potrzebujesz bezpośredniego przełącznika Boolean specjalnie dla sprawdzania pisowni. Użyj [setProofDisabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setProofDisabled), gdy potrzebujesz zachować lub wyraźnie kontrolować metadane niekorygowania prezentacji, w tym jej stan [NullableBool.NotDefined](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#NotDefined). Jeśli ustawisz obie właściwości, zachowaj ich wartości spójne; nie łącz [setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) ustawionego na `True` z [setProofDisabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setProofDisabled) ustawionym na stan [NullableBool.True](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#True).

Te właściwości konfigurowują metadane korekty używane przez PowerPoint i inne aplikacje prezentacyjne. Aspose.Slides nie wykorzystuje ich do wykonywania sprawdzania pisowni opartego na słowniku ani do zwracania listy błędnie napisanych słów.

Następujący kompletny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty do dwóch fragmentów w tym samym akapicie, zapisuje wynik, ponownie go otwiera i weryfikuje zapisane wartości:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) łączy sąsiadujące fragmenty, które mają takie samo formatowanie. Różnica w [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) sama w sobie nie utrzymuje tych fragmentów oddzielnie; po ich połączeniu wynikowy fragment zachowuje wartość [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setSpellCheck) pierwszego fragmentu. Jeśli fragmenty wymagają różnych ustawień sprawdzania pisowni, wywołaj [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) przed przypisaniem tych ustawień lub sprawdź granice wynikowych fragmentów i ponownie zastosuj ustawienia później. Fragmenty o różnych wartościach [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) pozostają oddzielne, ponieważ ich formatowanie języka korekty różni się.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) przechowuje metadane korekty dla ortografii i gramatyki; nie zmienia treści tekstu. Przetłumacz tekst oddzielnie, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty kontroluje czcionki, dzielenie wyrazów lub zawijanie linii?**

Nie. Identyfikator języka służy do korekty. Renderowanie i układ tekstu zależą głównie od dostępnych [fonts](/slides/pl/python-java/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [font substitution](/slides/pl/python-java/font-substitution/) lub [embed fonts](/slides/pl/python-java/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do osobnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać [setDefaultTextLanguage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) czy [setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), gdy chcesz ustawić domyślny język dla nowo tworzonego tekstu. Użyj [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId), gdy konkretny fragment wymaga explicite określonego języka korekty lub gdy akapit zawiera wiele języków.