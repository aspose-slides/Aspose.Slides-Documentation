---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu Pythona i Java
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/python-java/font-substitution/
keywords:
- czcionka
- zastępcza czcionka
- zastępowanie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła zastępowania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Skonfiguruj reguły zastępowania czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla Pythona przez Java podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwertowania prezentacji. Zastąpienie wpływa na renderowany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz zdefiniować czcionkę, której używać, gdy określona czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyniku w różnych środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanego kroju pogrubionego, zobacz [Obsługa czcionek bez dedykowanego kroju pogrubionego](/slides/pl/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ta sekcja wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Pobierz zastąpienia czcionek**

Użyj metody [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions), aby określić, które czcionki będą zastępowane podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w Pythonie wymienia wszystkie zastąpienia czcionek dla prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj przeciążenia [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) z argumentem będącym tablicą liczb całkowitych Java, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów zaczynające się od 1: `1` identyfikuje pierwszy slajd. Natomiast dostęp do kolekcji przy użyciu [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) używa indeksowania zerowego, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie za pośrednictwem metody [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/), zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastępowania przechowywane w [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) oraz [zewnętrznie wczytane czcionki](/slides/pl/python-java/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników przy tworzeniu inwentarza czcionek lub raportu wstępnego. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Klasa [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) udostępnia oba przeciążenia. Wybierz jedną w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides powinno używać, gdy źródłowa czcionka jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz obiekt [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję przy użyciu metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w Pythonie zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/python-java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę dostępną czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie nadal może zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub wczytaj ją jako [zewnętrzną czcionkę](/slides/pl/python-java/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej reguły zastępowania nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionek a zastępowaniem czcionek?**  
[Font replacement](/slides/pl/python-java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionek wybiera czcionkę dla renderowanego wyjścia, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**  
Reguły biorą udział w [sekwencji wyboru czcionek](/slides/pl/python-java/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie jest skonfigurowana żadna reguła zastępowania?**  
Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę wczytać zewnętrzne czcionki, aby uniknąć zastępowania?**  
Tak. Możesz [wczytać zewnętrzne czcionki](/slides/pl/python-java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**  
Nie. To Ty jesteś odpowiedzialny za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastąpień mogą różnić się między systemami Windows, Linux i macOS?**  
Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**  
Używaj tych samych plików czcionek i wersji na każdym komputerze lub w kontenerze, [wczytaj wymagane zewnętrzne czcionki](/slides/pl/python-java/custom-font/) oraz [osadź czcionki](/slides/pl/python-java/embedded-font/) gdy licencja na to pozwala. Możesz również wywołać [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.