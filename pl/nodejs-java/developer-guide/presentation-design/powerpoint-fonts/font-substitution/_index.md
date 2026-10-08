---
title: Konfiguracja zastąpienia czcionek w prezentacjach przy użyciu JavaScript
linktitle: Zastąpienie czcionek
type: docs
weight: 70
url: /pl/nodejs-java/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- zastąpienie czcionki
- zamiana czcionki
- wymiana czcionki
- reguła zastąpienia
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Skonfiguruj reguły zastąpienia czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla Node.js przy użyciu Javy podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastąpienie czcionki pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu w trakcie renderowania lub konwersji prezentacji. Zastąpienie dotyczy wyjścia renderowanego; nie zmienia czcionki przypisanej do zawartości prezentacji.

Można określić czcionkę, której należy używać, gdy konkretna czcionka jest niedostępna, oraz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Dzięki temu wyjście pozostaje spójne w środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanego pogrubionego kroju, zobacz [Obsługa czcionek bez dedykowanego pogrubionego kroju](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ten rozdział wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Pobierz zastąpienia czcionek**

Użyj metody [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład JavaScript wypisuje wszystkie zastąpienia czcionek dla prezentacji:

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

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj przeciążenia [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) z tablicą indeksów slajdów, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne podczas renderowania lub eksportu części prezentacji, inkrementalnego sprawdzania dużej prezentacji, lokalizowania slajdów zależnych od niedostępnych czcionek, przygotowywania minimalnego pakietu czcionek dla serwera lub kontenera oraz diagnozowania różnic w renderowaniu bez przetwarzania niepowiązanych slajdów.

Przeciążenie oczekuje japońskiego prymitywu `int[]`. Utwórz je za pomocą `java.newArray("int", [...])`; zwykła tablica JavaScript jest konwertowana na `Integer[]` i nie pasuje do tego przeciążenia.

Tablica zawiera indeksy slajdów liczone od jedynki: `1` określa pierwszy slajd. Natomiast kolektor [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) używa indeksowania od zera, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy tworzeniu tablicy, aby uniknąć błędów „off‑by‑one”.

Wywołaj przeciążenie przez [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik to obiekt [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/), zawierający oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastąpienia zapisane w [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) oraz [czcionki zewnętrzne](/slides/pl/nodejs-java/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Klasa [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) z tablicą Java `int[]` indeksów slajdów | Potrzebujesz zastąpień dla wybranego zakresu, inkrementalnego sprawdzenia lub częściowego eksportu. |

## **Ustaw reguły zastąpienia czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy źródłowa czcionka jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję używając metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład JavaScript zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

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
Aby niekondycjonalnie zmienić czcionki używane w całej prezentacji, zobacz [Zastąpienie czcionek](/slides/pl/nodejs-java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastąpienia czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę dostępną czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal wymagać **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub wczytaj jako [czcionkę zewnętrzną](/slides/pl/nodejs-java/custom-font/).

To ograniczenie dotyczy tylko układu równań. Reguły zastąpienia opisane powyżej nadal obowiązują dla regularnego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a jej zastąpieniem?**

[Zastąpienie czcionek](/slides/pl/nodejs-java/font-replacement/) zamierza zmienić jedną czcionkę na inną w całej prezentacji. Zastąpienie czcionki wybiera czcionkę dla wyjścia renderowanego, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastąpienia?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/nodejs-java/font-selection-sequence/) podczas renderowania i konwersji. Przy warunku `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę wczytać czcionki zewnętrzne, aby uniknąć zastąpienia?**

Tak. Możesz [wczytać czcionki zewnętrzne](/slides/pl/nodejs-java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczanie czcionek i przestrzeganie ich licencji spoczywa na użytkowniku.

**Czy wyniki zastąpienia mogą się różnić między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednej maszynie może wymagać zastąpienia na innej.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików czcionek i ich wersji na każdej maszynie lub w kontenerze, [wczytuj wymagane czcionki zewnętrzne](/slides/pl/nodejs-java/custom-font/), i [osadzaj czcionki](/slides/pl/nodejs-java/embedded-font/), jeśli licencja na to pozwala. Możesz również wywołać [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.