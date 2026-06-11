---
title: Konfiguracja kolekcji czcionek zastępczych na Androidzie
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/androidjava/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Skonfiguruj kolekcję czcionek zastępczych w Aspose.Slides dla Androida przy użyciu Javy, aby tekst w prezentacjach PowerPoint i OpenDocument był spójny i wyraźny."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może zostać dodana do `FontFallBackRulesCollection`, który implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do właściwości `FontFallBackRulesCollection` menedżera czcionek (`FontsManager`) prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Po zainicjowaniu `FontsManager` z kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosuj reguły zastępcze**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule) mogą być zorganizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection), który implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Możliwe jest dodawanie lub usuwanie reguł z kolekcji.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--) zwracającą własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager).

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek zastępczych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--) określonej prezentacji:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Po zainicjowaniu `FontsManager` z kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Przeczytaj więcej o tym, jak [Render Presentation with Fallback Font](/slides/pl/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

**Czy reguły zastępcze dotyczą tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podmiany glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose dostarcza jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz samodzielnie, na własną odpowiedzialność.

**Czy zamiana/substitucja brakujących czcionek oraz zastępcze czcionki dla brakujących glifów mogą być używane razem?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/androidjava/font-replacement/)/[substitution](/slides/pl/androidjava/font-substitution/)), a następnie reguły zastępcze wypełniają luki brakujących glifów w dostępnych czcionkach.