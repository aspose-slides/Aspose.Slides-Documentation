---
title: Konfiguracja kolekcji czcionek zastępczych w Javie
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/java/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawianie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Ustaw kolekcję czcionek zastępczych w Aspose.Slides dla Javy, aby tekst był spójny i wyraźny w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie zbioru reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`, który implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji można ją przypisać do właściwości `FontFallBackRulesCollection` menedżera czcionek prezentacji `FontsManager`. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` ma własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany z kolekcją zastępczych czcionek, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection), który implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFontFallBackRulesCollection). Można dodać lub usunąć reguły z kolekcji.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każdy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--) zwracającą własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager).

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł zastępczych czcionek i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--) określonej prezentacji:  

```java
import com.aspose.slides.*;

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

Po zainicjowaniu `FontsManager` kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="info" %}} 
Przeczytaj więcej o tym, jak [Renderować prezentację z czcionką zastępczą](/slides/pl/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do PPTX i nie będą widoczne w interfejsie PowerPoint.

### Czy zastępstwo dotyczy tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?

Tak. Ten sam mechanizm podmiany glifów jest używany dla wszelkiego tekstu w tych obiektach.

### Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

### Czy zastąpienie/podmiana brakujących czcionek oraz zastępstwo brakujących glifów można stosować jednocześnie?

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/java/font-replacement/)/[substitution](/slides/pl/java/font-substitution/)), a następnie zastępstwo wypełnia luki brakujących glifów w dostępnych czcionkach.