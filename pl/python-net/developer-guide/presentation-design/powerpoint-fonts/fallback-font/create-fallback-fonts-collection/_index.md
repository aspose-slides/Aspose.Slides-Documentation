---
title: Konfiguracja kolekcji czcionek rezerwowych w Pythonie
linktitle: Kolekcja czcionek rezerwowych
type: docs
weight: 20
url: /pl/python-net/create-fallback-fonts-collection/
keywords:
- czcionka rezerwowa
- reguła rezerwowa
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Utwórz kolekcję czcionek rezerwowych w Aspose.Slides dla Pythona poprzez .NET, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala skonfigurować kolekcję reguł czcionek rezerwowych dla prezentacji. Każda reguła rezerwowa jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do właściwości `font_fall_back_rules_collection` prezentacji `fonts_manager`. `fonts_manager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` posiada własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek rezerwowych, określone czcionki rezerwowe są stosowane podczas renderowania prezentacji.

## **Zastosuj reguły rezerwowe**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/FontFallBackRule/) można organizować w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrulescollection/). Można dodawać lub usuwać reguły z kolekcji.

Następnie tę kolekcję można przypisać do właściwości [font_fall_back_rules_collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) klasy [FontsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/). FontsManager kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) ma właściwość [fonts_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/) z własną instancją klasy FontsManager.

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek rezerwowych i przypisać ją do FontsManager określonej prezentacji:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Po zainicjowaniu FontsManager kolekcją czcionek rezerwowych, czcionki rezerwowe są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Przeczytaj więcej o tym, jak [Render Presentation with Fallback Font](/slides/pl/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły rezerwowe zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły rezerwowe są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

**Czy rezerwowe stosują się do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm zamiany glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose dostarcza jakieś czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz samodzielnie, na własną odpowiedzialność.

**Czy zamiana/substitucja brakujących czcionek oraz rezerwowe dla brakujących glifów mogą być używane jednocześnie?**

Tak. Są to niezależne etapy tego samego pipeline'u rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/python-net/font-replacement/)/[substitution](/slides/pl/python-net/font-substitution/)), a następnie rezerwowe wypełnia luki brakujących glifów w dostępnych czcionkach.