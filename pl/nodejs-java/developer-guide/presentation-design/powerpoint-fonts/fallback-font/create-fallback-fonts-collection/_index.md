---
title: Konfiguracja kolekcji czcionek zapasowych w JavaScript
linktitle: Kolekcja czcionek zapasowych
type: docs
weight: 20
url: /pl/nodejs-java/create-fallback-fonts-collection/
keywords:
- czcionka zapasowa
- reguła zapasowa
- kolekcja czcionek
- konfiguracja czcionki
- ustawianie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Utwórz kolekcję czcionek zapasowych w JavaScript przy użyciu Aspose.Slides dla Node.js, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Omówienie**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł czcionek zapasowych dla prezentacji. Każda reguła zapasowa jest reprezentowana przez klasę `FontFallBackRule` i może zostać dodana do `FontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz ją przypisać za pomocą metody `setFontFallBackRulesCollection` obiektu `FontsManager` prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek zapasowych, określone czcionki zapasowe są stosowane podczas renderowania prezentacji.

## **Zastosuj reguły zapasowe**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRulesCollection), który implementuje klasę [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRulesCollection). Dodawanie i usuwanie reguł z kolekcji jest możliwe.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każdy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getFontsManager--) zwracającą własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager).

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek zapasowych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getFontsManager--) konkretnej prezentacji:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Po zainicjowaniu `FontsManager` kolekcją czcionek zapasowych, czcionki zapasowe są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Przeczytaj więcej o tym, jak [Render Presentation with Fallback Font](/slides/pl/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zapasowe zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?**

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

**Czy reguły zapasowe mają zastosowanie do tekstu w elementach SmartArt, WordArt, wykresach i tabelach?**

Tak. Ten sam mechanizm podstawiania glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy można jednocześnie używać zastąpienia/substytucji brakujących czcionek oraz reguł zapasowych dla brakujących glifów?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik określa dostępność czcionek ([replacement](/slides/pl/nodejs-java/font-replacement/)/[substitution](/slides/pl/nodejs-java/font-substitution/)), potem reguły zapasowe uzupełniają brakujące glify w dostępnych czcionkach.