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
description: "Ustaw kolekcję czcionek zastępczych w Aspose.Slides dla Androida przy użyciu Javy, aby tekst był spójny i wyraźny w prezentacjach PowerPoint oraz OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł czcionek zastępczych dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może zostać dodana do `FontFallBackRulesCollection`, które implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do właściwości `FontFallBackRulesCollection` obiektu `FontsManager` prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` posiada własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule) mogą być organizowane w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection), które implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Można dodawać lub usuwać reguły z kolekcji.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każda [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--) zwracającą własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager).

Poniżej przykład, jak utworzyć kolekcję reguł czcionek zastępczych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--) określonej prezentacji:  

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
Przeczytaj więcej o tym, jak [Renderować prezentację z czcionką zastępczą](/slides/pl/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Czy moje reguły zastępcze zostaną osadzone w pliku PPTX i będą widoczne w PowerPoint po zapisaniu?

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie będą widoczne w interfejsie PowerPoint.

### Czy reguły zastępcze mają zastosowanie do tekstu w SmartArt, WordArt, wykresach i tabelach?

Tak. Ten sam mechanizm zamiany glifów jest używany dla wszelkiego tekstu w tych obiektach.

### Czy Aspose dystrybuuje jakieś czcionki wraz z biblioteką?

Nie. Czcionki dodajesz i używasz we własnym środowisku i na własną odpowiedzialność.

### Czy zamiana/substitucja brakujących czcionek oraz reguły zastępcze dla brakujących glifów mogą być używane jednocześnie?

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik określa dostępność czcionek ([replacement](/slides/pl/androidjava/font-replacement/)/[substitution](/slides/pl/androidjava/font-substitution/)), a następnie reguły zastępcze wypełniają luki dla brakujących glifów w dostępnych czcionkach.