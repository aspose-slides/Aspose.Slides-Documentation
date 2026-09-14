---
title: Konfiguracja kolekcji czcionek zastępczych w Pythonie przy użyciu Java
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/python-java/create-fallback-fonts-collection/
keywords:
  - czcionka zastępcza
  - reguła zastępcza
  - kolekcja czcionek
  - konfigurowanie czcionki
  - ustawianie czcionki
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Python
  - Java
  - Aspose.Slides
description: "Ustaw kolekcję czcionek zastępczych w Aspose.Slides dla Pythona przy użyciu Java, aby zachować spójny i wyraźny tekst w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/) i może być dodana do [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrulescollection/).

Po utworzeniu kolekcji możesz przypisać ją przy użyciu metody [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/). [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) kontroluje czcionki w całej prezentacji, a każda instancja [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) ma własny [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/).

Gdy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) zostanie zainicjowany kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrulescollection/). Możesz dodawać lub usuwać reguły z kolekcji.

Ta kolekcja może być następnie przypisana przy użyciu metody [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/), która kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getFontsManager), która zwraca jej własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/).

Poniższy przykład pokazuje, jak utworzyć kolekcję reguł czcionek zastępczych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Po zainicjowaniu [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="info" title="Uwaga" %}}
Więcej informacji o tym, jak [renderować prezentację z czcionką zastępczą](/slides/pl/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

**Czy zastępcze zastosowanie dotyczy tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podmiany glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy zamiana/podstawienie brakujących czcionek i zastępcze dla brakujących glifów mogą być używane razem?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/python-java/font-replacement/)/[substitution](/slides/pl/python-java/font-substitution/)), a następnie zastępcze wypełnia luki brakujących glifów w dostępnych czcionkach.