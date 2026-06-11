---
title: "Konfiguracja kolekcji czcionek zastępczych w PHP"
linktitle: "Kolekcja czcionek zastępczych"
type: docs
weight: 20
url: /pl/php-java/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawianie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Utwórz kolekcję czcionek zastępczych w Aspose.Slides dla PHP przy użyciu Java, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł fontów zastępczych dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją przy użyciu metody `setFontFallBackRulesCollection` menedżera czcionek prezentacji `FontsManager`. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany z kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosuj reguły zastępcze**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRulesCollection). Możliwe jest dodawanie i usuwanie reguł z kolekcji.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager). FontsManager kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) ma metodę [getFontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#getFontsManager) z własną instancją klasy [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager).

Poniżej znajduje się przykład, jak stworzyć kolekcję reguł czcionek zastępczych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#getFontsManager) wybranej prezentacji:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Po zainicjowaniu FontsManagera z kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Przeczytaj więcej, jak [Renderowanie prezentacji z czcionką zastępczą](/slides/pl/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze będą osadzone w pliku PPTX i widoczne w programie PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

**Czy zastępstwo dotyczy tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podstawiania glifów jest używany dla dowolnego tekstu w tych obiektach.

**Czy Aspose dostarcza jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy zamiana/substitucja brakujących czcionek i zastępstwo brakujących glifów mogą być używane jednocześnie?**

Tak. Są to niezależne etapy tego samego pipeline'u rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/php-java/font-replacement/)/[substitution](/slides/pl/php-java/font-substitution/)), potem zastępstwo wypełnia luki brakujących glifów w dostępnych czcionkach.