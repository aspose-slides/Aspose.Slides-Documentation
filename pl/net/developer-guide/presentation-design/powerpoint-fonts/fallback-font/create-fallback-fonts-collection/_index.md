---
title: Konfiguracja kolekcji czcionek zastępczych w .NET
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/net/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Skonfiguruj kolekcję czcionek zastępczych w Aspose.Slides dla .NET, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala skonfigurować kolekcję reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`, które implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do właściwości `FontFallBackRulesCollection` obiektu `FontsManager` prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjalizowany kolekcją zastępczych czcionek, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule) mogą być zorganizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrulescollection), które implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontfallbackrulescollection). Możliwe jest dodawanie i usuwanie reguł z kolekcji.

Następnie tę kolekcję można przypisać do właściwości [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) ma właściwość [FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/fontsmanager) z własną instancją klasy `FontsManager`.

Poniżej znajduje się przykład, jak stworzyć kolekcję reguł zastępczych czcionek i przypisać ją do `FontsManager` konkretnej prezentacji:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Po zainicjowaniu `FontsManager` kolekcją zastępczych czcionek, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Przeczytaj więcej o tym, jak [Renderowanie prezentacji z czcionką zastępczą](/slides/pl/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w programie PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie działania; nie są serializowane do pliku PPTX i nie pojawią się w interfejsie PowerPointa.

**Czy zastępcze czcionki mają zastosowanie do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podstawiania glifów jest używany dla wszelkiego tekstu w tych obiektach.

**Czy Aspose udostępnia jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie, ponosząc za nie pełną odpowiedzialność.

**Czy zastępowanie/podstawianie brakujących czcionek oraz zastępcze czcionki dla brakujących glifów mogą być używane razem?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik określa dostępność czcionek ([zastąpienie](/slides/pl/net/font-replacement/)/[podstawienie](/slides/pl/net/font-substitution/)), potem zastępcze czcionki wypełniają luki dla brakujących glifów w dostępnych czcionkach.