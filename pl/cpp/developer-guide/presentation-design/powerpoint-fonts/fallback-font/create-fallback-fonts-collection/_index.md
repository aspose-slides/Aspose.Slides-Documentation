---
title: Konfiguracja kolekcji czcionek awaryjnych w C++
linktitle: Kolekcja czcionek awaryjnych
type: docs
weight: 20
url: /pl/cpp/create-fallback-fonts-collection/
keywords:
- czcionka awaryjna
- reguła awaryjna
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Skonfiguruj kolekcję czcionek awaryjnych w Aspose.Slides dla C++, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł czcionek awaryjnych dla prezentacji. Każda reguła awaryjna jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`, która implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz ją przypisać przy użyciu metody `set_FontFallBackRulesCollection` menedżera czcionek (`FontsManager`) prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek awaryjnych, określone czcionki awaryjne są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł awaryjnych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrulescollection/), które implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrulescollection/). Można dodawać i usuwać reguły z kolekcji.

Następnie tę kolekcję można przekazać do metody [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/). `FontsManager` kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) posiada metodę [get_FontsManager()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/), która zwraca własną instancję klasy `FontsManager`.

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek awaryjnych i przypisać ją do `FontsManager` konkretnej prezentacji:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Po zainicjowaniu `FontsManager` kolekcją czcionek awaryjnych, czcionki awaryjne są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Dowiedz się więcej, jak [Renderowanie prezentacji z czcionką awaryjną](/slides/pl/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły awaryjne zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły awaryjne są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPointa.

**Czy awaryjne czcionki mają zastosowanie do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podmiany glifów jest używany dla wszelkiego tekstu w tych obiektach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy zamiana/podstawienie brakujących czcionek oraz awaryjne czcionki dla brakujących glifów mogą być używane jednocześnie?**

Tak. Są to niezależne etapy tego samego pipeline’u rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/cpp/font-replacement/)/[substitution](/slides/pl/cpp/font-substitution/)), a następnie awaryjne czcionki wypełniają luki dla brakujących glifów w dostępnych czcionkach.