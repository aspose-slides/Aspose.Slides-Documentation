---
title: Konfiguracja zastępowania czcionek w prezentacjach w C++
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/cpp/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- zastępowanie czcionek
- zastąpienie czcionki
- zamiana czcionki
- reguła zastępowania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Skonfiguruj reguły zastępowania czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla C++ podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wyjście renderowane; nie zmienia ono czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, która zostanie użyta, gdy konkretna czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyników w środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanego pogrubionego kroju, zobacz [Obsługa czcionek bez dedykowanego pogrubionego kroju](/slides/pl/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ten rozdział wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Pobieranie zastąpień czcionek**

Użyj metody [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w C++ wypisuje wszystkie zastąpienia czcionek w prezentacji:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Pobieranie zastąpień czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) z argumentem `System::ArrayPtr<int32_t> slides`, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów liczone od 1: `1` identyfikuje pierwszy slajd. Natomiast metoda [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) używa indeksu zerowego, więc ten sam slajd jest dostępny jako `presentation->get_Slide(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów „off‑by‑one”.

Wywołaj przeciążenie za pośrednictwem metody [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik to obiekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), zawierający oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane zasady awaryjne, zasady zastąpień przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie załadowane czcionki](/slides/pl/cpp/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Interfejs [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Użyj, gdy |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) z `System::ArrayPtr<int32_t> slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustawianie reguł zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) ze warunkiem [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję przy użyciu metody [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w C++ zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Uwaga" %}}
Dla bezwarunkowej zmiany czcionek używanych w całej prezentacji zobacz [Zastąpienie czcionek](/slides/pl/cpp/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną czcionkę określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować dokładnie tej czcionki do obliczenia i wyrenderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać potrzebę **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/cpp/custom-font/).

To ograniczenie dotyczy układu równań. Reguły zastępowania opisane powyżej nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a jej zamianą?**

[Zastąpienie czcionki](/slides/pl/cpp/font-replacement/) zmienia jedną czcionkę na inną w całej prezentacji. Zastąpienie wybiera czcionkę dla wyjścia renderowanego, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/cpp/font-selection-sequence/) podczas renderowania i konwersji. Z warunkiem `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastępowania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować czcionki zewnętrzne, aby uniknąć zastąpienia?**

Tak. Możesz [załadować czcionki zewnętrzne](/slides/pl/cpp/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczenie czcionek i przestrzeganie ich licencji spoczywa na Tobie.

**Czy wyniki zastąpienia mogą się różnić między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje ich wyszukiwania różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednej maszynie może wymagać zastąpienia na innej.

**Jak zapewnić spójność wyboru czcionek w konwersjach wsadowych?**

Używaj tych samych plików i wersji czcionek na każdej maszynie lub w kontenerze, [załaduj wymagane czcionki zewnętrzne](/slides/pl/cpp/custom-font/), oraz [osadź czcionki](/slides/pl/cpp/embedded-font/), gdy licencja na to zezwala. Możesz także wywołać [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.