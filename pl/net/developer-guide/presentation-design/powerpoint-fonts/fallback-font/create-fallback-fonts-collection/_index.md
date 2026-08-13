---
title: Konfiguracja kolekcji czcionek awaryjnych w .NET
linktitle: Kolekcja czcionek awaryjnych
type: docs
weight: 20
url: /pl/net/create-fallback-fonts-collection/
keywords:
- czcionka awaryjna
- reguła awaryjna
- kolekcja czcionek
- konfiguracja czcionki
- ustawianie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ustaw kolekcję czcionek awaryjnych w Aspose.Slides dla .NET, aby tekst był spójny i ostry w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł czcionek awaryjnych dla prezentacji. Każda reguła czcionki awaryjnej jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`, które implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do własności `FontFallBackRulesCollection` klasy `FontsManager` prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek awaryjnych, określone czcionki awaryjne są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł awaryjnych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrulescollection), który implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontfallbackrulescollection). Można dodawać lub usuwać reguły z kolekcji.

Następnie tę kolekcję można przypisać do własności [FontFallBackRulesCollection ](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager). FontsManager kontroluje czcionki w całej prezentacji.

Każda [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) ma własność [FontsManager ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/fontsmanager) z własną instancją klasy FontsManager.

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek awaryjnych i przypisać ją do FontsManager określonej prezentacji:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Po zainicjowaniu FontsManagera kolekcją czcionek awaryjnych, czcionki awaryjne są stosowane podczas renderowania prezentacji.

{{% alert color="info" %}} 
Przeczytaj więcej, jak [Renderowanie prezentacji z czcionką awaryjną](/slides/pl/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Czy moje reguły awaryjne zostaną osadzone w pliku PPTX i będą widoczne w programie PowerPoint po zapisaniu?

Nie. Reguły awaryjne są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie pojawią się w interfejsie PowerPoint.

### Czy reguły awaryjne mają zastosowanie do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?

Tak. Ten sam mechanizm podmiany glifów jest używany dla dowolnego tekstu w tych obiektach.

### Czy Aspose dostarcza jakiekolwiek czcionki wraz z biblioteką?

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

### Czy zamiana/substytucja brakujących czcionek i awaryjne uzupełnianie brakujących glifów mogą być używane jednocześnie?

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/net/font-replacement/)/[substitution](/slides/pl/net/font-substitution/)), a następnie awaryjne uzupełnianie wypełnia luki brakujących glifów w dostępnych czcionkach.