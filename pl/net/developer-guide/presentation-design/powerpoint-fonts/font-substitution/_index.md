---
title: "Konfiguracja podstawiania czcionek w prezentacjach w .NET"
linktitle: "Podstawianie czcionek"
type: docs
weight: 70
url: /pl/net/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- podstawianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła podstawiania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Konfiguruj reguły podstawiania czcionek i sprawdzaj podstawione czcionki w Aspose.Slides dla .NET podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Podstawianie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, której nie można odczytać podczas renderowania lub konwertowania prezentacji. Zastąpienie wpływa na wyjściowy render, nie zmienia jednak czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, która ma być użyta, gdy konkretna czcionka jest niedostępna, oraz możesz sprawdzić podstawienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyniku w różnych środowiskach z odmiennie zainstalowanymi czcionkami.

## **Uzyskaj podstawienia czcionek**

Użyj metody [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/), aby określić, które czcionki zostaną podstawione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i podstawione nazwy czcionek.

Poniższy przykład w C# wymienia wszystkie podstawienia czcionek dla prezentacji:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Uzyskaj podstawienia czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) z argumentem `int[] slides`, aby sprawdzić tylko podstawienia niezbędne do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację etapami, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów zaczynające się od 1: `1` identyfikuje pierwszy slajd. Natomiast indeksator kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) jest zerowy, więc ten sam slajd dostępny jest jako `presentation.Slides[0]`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów „off‑by‑one”.

Wywołaj przeciążenie przez właściwość [Presentation.FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/). Zwróci ono tylko podstawienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstitutioninfo/), zawierającym oryginalną i podstawioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły podstawiania przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie wczytane czcionki](/slides/pl/net/custom-font/).

Ta sama podstawowa czcionka może być wymagana przez więcej niż jeden wybrany slajd. Usuń duplikaty, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład wypisuje każde zwrócone podstawienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Interfejs [IFontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Potrzebujesz podstawień dla całej prezentacji. |
| [GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Potrzebujesz podstawień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły podstawiania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy źródłowa czcionka jest niedostępna:

1. Załaduj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję do właściwości [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w C# podstawia `Arial` zamiast `SomeRareFont`, gdy `SomeRareFont` jest niedostępny, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/net/font-replacement/).
{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły podstawiania czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i wyrenderowania układu równania. Reguła, która podmienia inną czcionkę matematyczną, np. **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub wczytaj jako [zewnętrzną czcionkę](/slides/pl/net/custom-font/).

To ograniczenie dotyczy układu równań. Reguły podstawiania opisane powyżej nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a podstawianiem czcionki?**

[Font replacement](/slides/pl/net/font-replacement/) celowo zmienia jedną czcionkę na drugą w całej prezentacji. Podstawianie czcionki wybiera czcionkę dla wyjściowego renderu, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły podstawiania?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/net/font-selection-sequence/) podczas renderowania i konwersji. Przy warunku `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły podstawiania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę wczytać czcionki zewnętrzne, aby uniknąć podstawiania?**

Tak. Możesz [wczytać czcionki zewnętrzne](/slides/pl/net/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczenie czcionek i przestrzeganie ich licencji spoczywa na użytkowniku.

**Czy wyniki podstawiania mogą różnić się między Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednej maszynie może wymagać podstawienia na innej.

**Jak zapewnić spójny wybór czcionek przy konwersjach wsadowych?**

Używaj tych samych plików czcionek i ich wersji na każdej maszynie lub w kontenerze, [wczytuj wymagane czcionki zewnętrzne](/slides/pl/net/custom-font/), i [osadzaj czcionki](/slides/pl/net/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane podstawienia.