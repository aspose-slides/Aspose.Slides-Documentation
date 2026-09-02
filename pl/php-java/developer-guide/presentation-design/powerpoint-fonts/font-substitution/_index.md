---
title: "Konfiguracja zastępowania czcionek w prezentacjach przy użyciu PHP"
linktitle: "Zastępowanie czcionek"
type: docs
weight: 70
url: /pl/php-java/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- zastępowanie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła zastępowania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Konfiguruj reguły zastępowania czcionek i przeglądaj zastąpione czcionki w Aspose.Slides dla PHP poprzez Java podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, której nie można uzyskać podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wyjściowy renderowany dokument; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, którą należy używać, gdy konkretna czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyniku w różnych środowiskach z odmiennie zainstalowanymi czcionkami.

## **Uzyskaj zastąpienia czcionek**

Użyj metody [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład PHP wymienia wszystkie zastąpienia czcionek dla prezentacji:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj przeciążenia [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/) z argumentem `int[] slides`, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera, lub diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów liczone od jedynki: `1` identyfikuje pierwszy slajd. Natomiast akcesor kolekcji [Presentation::getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlides) używa indeksowania od zera, więc ten sam slajd jest dostępny jako `$presentation->getSlides()->get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów off-by-one.

Wywołaj przeciążenie poprzez metodę [Presentation::getFontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getFontsManager). Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstitutioninfo/), zawierającym oryginalne i zastąpione nazwy czcionek. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane zasady awaryjne, zasady zastępowania przechowywane w [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstrulecollection/) oraz [zewnętrznie załadowane czcionki](/slides/pl/php-java/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników przy tworzeniu inwentarza czcionek lub raportu wstępnego. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Klasa [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Użyj, gdy |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw zasady zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides powinien używać, gdy źródłowa czcionka jest niedostępna:

1. Załaduj prezentację.
2. Utwórz definicje czcionek dla źródłowej i zastępczej czcionki.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję, używając metody [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład PHP zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Czcionka zastępcza musi być dostępna dla Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aby dokonać bezwarunkowej zmiany czcionek używanych w całej prezentacji, zobacz [Zastąpienie czcionek](/slides/pl/php-java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Zasady zastępowania czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę dostępną czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu, a renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/php-java/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej zasady zastępowania nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a zastępowaniem czcionki?**

[Zastąpienie czcionki](/slides/pl/php-java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionki wybiera czcionkę dla renderowanego wyjścia, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są zasady zastępowania?**

Zasady uczestniczą w [sekwencji wyboru czcionek](/slides/pl/php-java/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastępowania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastępowania?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/php-java/custom-font/), aby Aspose.Slides mógł je używać podczas renderowania i konwersji.

**Czy Aspose dostarcza czcionki wraz z biblioteką?**

Nie. To Ty jesteś odpowiedzialny za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastępowania mogą różnić się pomiędzy Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek przy konwersjach wsadowych?**

Używaj tych samych plików czcionek i wersji na każdej maszynie lub w kontenerze, [załaduj wymagane zewnętrzne czcionki](/slides/pl/php-java/custom-font/) oraz [osadź czcionki](/slides/pl/php-java/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.