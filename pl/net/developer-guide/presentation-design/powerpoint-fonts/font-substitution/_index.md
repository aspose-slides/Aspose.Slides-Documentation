---
title: Skonfiguruj zamianę czcionek w prezentacjach w .NET
linktitle: Zamiana czcionek
type: docs
weight: 70
url: /pl/net/font-substitution/
keywords:
- czcionka
- czcionka zamienna
- zamiana czcionek
- zamień czcionkę
- zastępowanie czcionek
- reguła zamiany
- reguła wymiany
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Skonfiguruj reguły zamiany czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla .NET podczas renderowania lub konwersji prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, której nie można odczytać podczas renderowania lub konwertowania prezentacji. Zastąpienie dotyczy renderowanego wyniku; nie zmienia czcionki przypisanej do treści prezentacji.

Można określić czcionkę, której należy używać, gdy dana czcionka jest niedostępna, oraz można sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyjścia w środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanego wariantu pogrubionego, zobacz [Obsługa czcionek bez dedykowanego wariantu pogrubionego](/slides/pl/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ta sekcja wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Uzyskaj zastąpienia czcionek**

Użyj metody [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w C# wymienia wszystkie zastąpienia czcionek dla prezentacji:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) z argumentem `int[] slides`, aby sprawdzić tylko zastąpienia wymagane do renderowania określonych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację etapami, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera lub diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

`slides` tablica zawiera indeksy slajdów numerowane od 1: `1` identyfikuje pierwszy slajd. Natomiast indeksator kolekcji [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) jest zerowy, więc ten sam slajd jest dostępny jako `presentation.Slides[0]`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów off-by-one.

Wywołaj przeciążenie przez własność [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek oraz [zewnętrznie wczytane czcionki](/slides/pl/net/custom-font/). Zasady zastępowania przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) zmieniają renderowany wynik, ale nie są odzwierciedlane w wyniku.

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników podczas tworzenia inwentarza czcionek lub raportu wstępnego. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz odpowiednie w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides powinien używać, gdy źródłowa czcionka jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla źródłowej i zastępczej czcionki.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję do właściwości [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w C# zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

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
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Zamiana czcionek](/slides/pl/net/font-replacement/).
{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę dostępną czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że wymagana jest **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub wczytaj jako [zewnętrzną czcionkę](/slides/pl/net/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej reguły zastępowania nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a zastępowaniem czcionki?**

[Zamiana czcionek](/slides/pl/net/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionek wybiera czcionkę dla renderowanego wyjścia, gdy spełniony jest skonfigurowany warunek, na przykład gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/net/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do źródłowej czcionki.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku wykonawczym.

**Czy mogę wczytać zewnętrzne czcionki, aby uniknąć zastępowania?**

Tak. Możesz [wczytać zewnętrzne czcionki](/slides/pl/net/custom-font/), aby Aspose.Slides mógł je używać podczas renderowania i konwersji.

**Czy Aspose dostarcza czcionki razem z biblioteką?**

Nie. Odpowiadasz za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastępowania mogą różnić się między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików i wersji czcionek na każdym komputerze lub kontenerze, [wczytaj wymagane zewnętrzne czcionki](/slides/pl/net/custom-font/) oraz [osadź czcionki](/slides/pl/net/embedded-font/) gdy licencje na to pozwalają. Możesz także wywołać [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.