---
title: Konfigurowanie zastępowania czcionek w prezentacjach przy użyciu JavaScript
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/nodejs-java/font-substitution/
keywords:
- czcionka
- zastępcza czcionka
- zastępowanie czcionek
- zamiana czcionki
- zamiana czcionek
- reguła zastąpienia
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfiguruj reguły zastępowania czcionek i sprawdzaj zastąpione czcionki w Aspose.Slides dla Node.js przy użyciu Java podczas renderowania lub konwersji prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, której nie można uzyskać podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na renderowany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, która ma być użyta, gdy dana czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyniku w różnych środowiskach z różnymi zainstalowanymi czcionkami.

## **Pobieranie zastąpień czcionek**

Użyj metody [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład JavaScript wyświetla wszystkie zastąpienia czcionek dla prezentacji:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Pobieranie zastąpień czcionek dla wybranych slajdów**

Użyj przeciążenia [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) z tablicą indeksów slajdów, aby sprawdzić tylko te zastąpienia potrzebne do renderowania konkretnych slajdów. Jest to przydatne podczas renderowania lub eksportowania części prezentacji, inkrementalnego sprawdzania dużej prezentacji, lokalizowania slajdów zależnych od niedostępnych czcionek, przygotowywania minimalnego pakietu czcionek dla serwera lub kontenera albo diagnozowania różnic w renderowaniu bez przetwarzania niepowiązanych slajdów.

Przeciążenie oczekuje prymitywu Javy `int[]`. Utwórz je za pomocą `java.newArray("int", [...])`; zwykła tablica JavaScript jest konwertowana na `Integer[]` i nie pasuje do tego przeciążenia.

Tablica zawiera indeksy slajdów zaczynające się od jedynki: `1` identyfikuje pierwszy slajd. Natomiast dostęp do kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) używa indeksowania od zera, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy tworzeniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie przez [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Zwraca ono tylko te zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstitutioninfo/), zawierającym oryginalne i zastąpione nazwy czcionek. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane zasady awaryjne, zasady zastępowania przechowywane w [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstrulecollection/) oraz [zewnętrznie załadowane czcionki](/slides/pl/nodejs-java/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników podczas tworzenia inwentarza czcionek lub raportu weryfikacyjnego. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Klasa [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/) udostępnia oba przeciążenia. Wybierz odpowiednie w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Potrzebujesz zastąpień dla wybranego zakresu, inkrementalnego sprawdzenia lub częściowego eksportu. |

## **Ustawianie reguł zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy źródłowa czcionka jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję przy użyciu metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład JavaScript zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Czcionka zastępcza musi być dostępna dla Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/nodejs-java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na czcionkę dostępną określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować dokładnie tej czcionki, aby obliczyć i wyrenderować układ równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać wymóg **Cambria Math**.

Aby wyrenderować lub skonwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/nodejs-java/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej reguły zastępowania nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a zastępowaniem czcionki?**

[Font replacement](/slides/pl/nodejs-java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy pierwotna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/nodejs-java/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie jest skonfigurowana żadna reguła zastępowania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastępowania?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/nodejs-java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. To Ty jesteś odpowiedzialny za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastępowania mogą się różnić pomiędzy Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek przy konwersjach wsadowych?**

Używaj tych samych plików czcionek i ich wersji na każdej maszynie lub w kontenerze, [ładuj wymagane czcionki zewnętrzne](/slides/pl/nodejs-java/custom-font/) oraz [osadzaj czcionki](/slides/pl/nodejs-java/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.