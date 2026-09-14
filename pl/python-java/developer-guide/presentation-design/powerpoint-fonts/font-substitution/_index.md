---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu Pythona via Java
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "Skonfiguruj reguły zastępowania czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla Pythona w środowisku Java podczas renderowania lub konwersji prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na renderowany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, która ma być używana, gdy konkretna czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyników w różnych środowiskach z różnymi zainstalowanymi czcionkami.

## **Pobieranie zastąpień czcionek**

Użyj metody [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions), aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstitutioninfo/), które identyfikują pierwotne i zastąpione nazwy czcionek.

Poniższy przykład w Pythonie wypisuje wszystkie zastąpienia czcionek dla prezentacji:

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

## **Uzyskiwanie zastąpień czcionek dla wybranych slajdów**

Użyj przeciążenia [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions) z argumentem będącym tablicą liczb całkowitych języka Java, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów numerowane od jedynki: `1` identyfikuje pierwszy slajd. Dla porównania, akcesor kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) używa indeksowania zerowego, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie przez metodę [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getFontsManager). Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstitutioninfo/), zawierającym pierwotną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastępowania przechowywane w [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstrulecollection/) oraz [zewnętrznie załadowane czcionki](/slides/pl/python-java/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Klasa [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Użyj, gdy |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions) z tablicą liczb całkowitych Java | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustawianie reguł zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję, używając metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w Pythonie zastępuje czcionkę `SomeRareFont` czcionką `Arial`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Czcionka zastępująca musi być dostępna dla Aspose.Slides.

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
Aby wprowadzić bezwarunkową zmianę czcionek używanych w całej prezentacji, zobacz [Zamianę czcionek](/slides/pl/python-java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła zamieniająca inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/python-java/custom-font/).

Ograniczenie dotyczy układu równań. Reguły zastępowania opisane powyżej nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionek a zastępowaniem czcionek?**

[Font replacement](/slides/pl/python-java/font-replacement/) świadomie zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionek wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy pierwotna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**

Reguły uczestniczą w [ciągu wyboru czcionki](/slides/pl/python-java/font-selection-sequence/) podczas renderowania i konwersji. Przy warunku `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastępowania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionki. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować czcionki zewnętrzne, aby uniknąć zastępowania?**

Tak. Możesz [załadować czcionki zewnętrzne](/slides/pl/python-java/custom-font/), aby Aspose.Slides mogła ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczanie czcionek i przestrzeganie ich licencji spoczywa na Tobie.

**Czy wyniki zastępowania mogą się różnić między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje ich wyszukiwania różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików czcionek i wersji na każdej maszynie lub w kontenerze, [ładuj wymagane czcionki zewnętrzne](/slides/pl/python-java/custom-font/), oraz [osadzaj czcionki](/slides/pl/python-java/embedded-font/), jeśli licencje na to pozwalają. Możesz także wywołać [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.