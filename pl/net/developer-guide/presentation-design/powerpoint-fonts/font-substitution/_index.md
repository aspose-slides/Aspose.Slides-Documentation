---
title: Konfiguracja zastępowania czcionek w prezentacjach w .NET
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Skonfiguruj reguły zastępowania czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla .NET podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, której nie można odczytać podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wynik renderowania; nie zmienia on czcionki przypisanej do treści prezentacji.

Możesz zdefiniować czcionkę, która ma być używana, gdy konkretna czcionka jest niedostępna, oraz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyników w środowiskach z różnymi zainstalowanymi czcionkami.

## **Uzyskiwanie zastąpień czcionek**

Użyj metody [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstitutioninfo/), które identyfikują pierwotne i zastąpione nazwy czcionek.

Poniższy przykład w języku C# wymienia wszystkie zastąpienia czcionek dla prezentacji:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Uzyskiwanie zastąpień czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) z argumentem `int[] slides`, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację krok po kroku, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera lub diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów numerowane od jedynki: `1` określa pierwszy slajd. Natomiast indeksator kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) jest zerowo‑numerowany, więc ten sam slajd jest dostępny jako `presentation.Slides[0]`. Pamiętaj o tej różnicy przy tworzeniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie przez właściwość [Presentation.FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/). Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstitutioninfo/) zawierającym pierwotną i zastąpioną nazwę czcionki. Wynik odzwierciedla aktualne środowisko czcionek oraz [zewnętrznie załadowane czcionki](/slides/pl/net/custom-font/). Reguły zastąpienia przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsubstrulecollection/) zmieniają wynik renderowania, ale nie są odzwierciedlane w wyniku.

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników podczas tworzenia inwentarza czcionek lub raportu wstępnego. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno zgodnie z zakresem operacji renderowania:

| Przeciążenie | Użyj, gdy |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) z `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastąpienia czcionek**

Aby określić czcionkę, którą Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję do właściwości [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderuj lub skonwertuj prezentację.

Poniższy przykład w języku C# zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Zastępująca czcionka musi być dostępna dla Aspose.Slides.

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

Reguły zastąpienia czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę czcionką dostępną określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować dokładnie tej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zamienić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że wymagana jest **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/net/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej reguły zastąpienia nadal mają zastosowanie do zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a zastąpieniem czcionki?**

[Font replacement](/slides/pl/net/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastąpienie czcionki wybiera czcionkę do wyniku renderowania, gdy spełniony jest skonfigurowany warunek, na przykład gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastąpienia?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/net/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastąpienia?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/net/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dostarcza czcionki wraz z biblioteką?**

Nie. To Ty jesteś odpowiedzialny za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastąpienia mogą się różnić pomiędzy Windows, Linux i macOS?**

Tak. Zainstalowane czcionki oraz lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików i wersji czcionek na każdym komputerze lub w kontenerze, [załaduj wymagane czcionki zewnętrzne](/slides/pl/net/custom-font/) oraz [osadź czcionki](/slides/pl/net/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.