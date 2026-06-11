---
title: Konfiguracja kolekcji czcionek zastępczych w języku Java
linktitle: Kolekcja czcionek zastępczych
type: docs
weight: 20
url: /pl/java/create-fallback-fonts-collection/
keywords:
- czcionka zastępcza
- reguła zastępcza
- kolekcja czcionek
- konfiguracja czcionki
- ustawienie czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Utwórz kolekcję czcionek zastępczych w Aspose.Slides dla języka Java, aby tekst w prezentacjach PowerPoint i OpenDocument był spójny i wyraźny."
---
## **Przegląd**

Aspose.Slides umożliwia skonfigurowanie kolekcji reguł zastępczych czcionek dla prezentacji. Każda reguła zastępcza jest reprezentowana przez klasę `FontFallBackRule` i może być dodana do `FontFallBackRulesCollection`, które implementuje interfejs `IFontFallBackRulesCollection`.

Po utworzeniu kolekcji możesz przypisać ją do właściwości `FontFallBackRulesCollection` obiektu `FontsManager` prezentacji. `FontsManager` kontroluje czcionki w całej prezentacji, a każda instancja `Presentation` posiada własny `FontsManager`.

Gdy `FontsManager` zostanie zainicjowany kolekcją czcionek zastępczych, określone czcionki zastępcze są stosowane podczas renderowania prezentacji.

## **Zastosowanie reguł zastępczych**

Instancje klasy [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule) można zorganizować w [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection), które implementuje interfejs [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFontFallBackRulesCollection). Można dodawać i usuwać reguły z tej kolekcji.

Następnie tę kolekcję można przypisać do metody [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection) klasy [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager). `FontsManager` kontroluje czcionki w całej prezentacji.

Każdy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) posiada metodę [getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--) zwracającą własną instancję klasy [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager).

Poniżej znajduje się przykład, jak utworzyć kolekcję reguł czcionek zastępczych i przypisać ją do [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--) określonej prezentacji:  

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

Po zainicjowaniu `FontsManager` kolekcją czcionek zastępczych, czcionki zastępcze są stosowane podczas renderowania prezentacji.

{{% alert color="primary" %}} 
Dowiedz się więcej, jak [Renderowanie prezentacji z czcionką zastępczą](/slides/pl/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Czy moje reguły zastępcze zostaną zapisane w pliku PPTX i będą widoczne w programie PowerPoint po zapisaniu?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania; nie są serializowane do pliku PPTX i nie pojawią się w interfejsie PowerPointa.

**Czy zasada zastępcza ma zastosowanie do tekstu wewnątrz SmartArt, WordArt, wykresów i tabel?**

Tak. Ten sam mechanizm podstawiania glifów jest używany dla wszelkiego tekstu w tych obiektach.

**Czy Aspose dostarcza jakiekolwiek czcionki wraz z biblioteką?**

Nie. Czcionki dodajesz i używasz po swojej stronie i na własną odpowiedzialność.

**Czy zamiana/substitucja brakujących czcionek oraz zasada zastępcza dla brakujących glifów mogą być używane jednocześnie?**

Tak. Są to niezależne etapy tego samego potoku rozwiązywania czcionek: najpierw silnik rozwiązuje dostępność czcionek ([replacement](/slides/pl/java/font-replacement/)/[substitution](/slides/pl/java/font-substitution/)), potem zasada zastępcza wypełnia luki dla brakujących glifów w dostępnych czcionkach.