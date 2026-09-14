---
title: Renderowanie prezentacji z czcionkami alternatywnymi w Pythonie przez Java
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/python-java/render-presentation-with-fallback-font/
keywords:
- czcionka alternatywna
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami alternatywnymi w Aspose.Slides dla Pythona przez Java – zapewnij spójny tekst w PPT, PPTX i ODP dzięki szczegółowym przykładom kodu w Pythonie."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł czcionek alternatywnych. Ten artykuł pokazuje, jak utworzyć kolekcję reguł czcionek alternatywnych, modyfikować jej reguły poprzez usuwanie lub dodawanie czcionek alternatywnych oraz przypisać kolekcję przy użyciu metody [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Po przypisaniu kolekcji reguł czcionek alternatywnych do [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu JPEG.

## **Renderowanie slajdu przy użyciu reguł czcionek alternatywnych**

Poniższy przykład obejmuje te kroki:

1. [Utwórz kolekcję reguł czcionek alternatywnych](/slides/pl/python-java/create-fallback-fonts-collection/).
2. [Usuń](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/#remove) czcionkę alternatywną z reguły i [dodaj czcionki alternatywne](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) do innej reguły.
3. Przypisz kolekcję reguł przy użyciu [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) na menedżerze czcionek zwróconym przez [getFontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getFontsManager).
4. Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) aby zapisać prezentację w tym samym formacie lub w innym formacie. Po przypisaniu kolekcji reguł czcionek alternatywnych do [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/), reguły są stosowane podczas operacji na prezentacji: zapisywanie, renderowanie, konwertowanie i tak dalej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Utwórz nową kolekcję reguł.
fallback_rules = FontFallBackRulesCollection()

# Utwórz kilka reguł.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Spróbuj usunąć czcionkę alternatywną "Tahoma" z reguł.
    fallback_rule.remove("Tahoma")

    # Zaktualizuj reguły dla określonego zakresu.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Usuń istniejącą regułę, zachowując przynajmniej jedną regułę do renderowania.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Przypisz przygotowaną kolekcję reguł.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Renderuj miniaturę przy użyciu skonfigurowanej kolekcji reguł.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Zapisz obraz na dysku w formacie JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Przeczytaj więcej o tym, jak [przekonwertować PPT i PPTX na JPG w Pythonie za pomocą Java](/slides/pl/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}