---
title: Konfiguracja kolekcji czcionek zastępczych w C++
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/cpp/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Skonfiguruj kolekcję czcionek zastępczych w Aspose.Slides dla C++, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może zostać dodana do `FontFallBackRulesCollection`, która implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz ją przypisać za pomocą metody `set_FontFallBackRulesCollection` menedżera czcionek prezentacji (`FontsManager`). `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` posiada własny `FontsManager`.

Gdy `FontsManager` jest zainicjowany kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrulescollection/), która implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrulescollection/). Możliwe jest dodawanie i usuwanie reguł z kolekcji.

Następnie ta kolekcja może zostać przekazana do metody [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/). `FontsManager` kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) posiada metodę [get_FontsManager()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/), która zwraca własną instancję klasy `FontsManager`.

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek zastępczych i przypisać ją do `FontsManager` określonej prezentacji:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Po zainicjowaniu `FontsManager` kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Dowiedz się więcej, jak [Renderowanie prezentacji z zastępczą czcionką](/slides/pl/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą wyświetlane w interfejsie PowerPoint.

**Czy zastępcze czcionki mają zastosowanie do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podmiany glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose udostępnia jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy zamiana/zastąpienie brakujących czcionek i mechanizm zastępczy dla brakujących glifów mogą być używane razem?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/cpp/font-replacement/)/[substitution](/slides/pl/cpp/font-substitution/)), a następnie mechanizm zastępczy wypełnia luki brakujących glifów w dostępnych czcionkach.