---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu Pythona
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/python-net/font-substitution/
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
- Aspose.Slides
description: "Konfiguruj reguły zastępowania czcionek i sprawdzaj zastąpione czcionki w Aspose.Slides dla Pythona za pośrednictwem .NET podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wyświetlany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę do użycia, gdy konkretna czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyjścia w środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanej pogrubionej wersji, zobacz [Obsługa czcionek bez dedykowanej pogrubionej czcionki](/slides/pl/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ta sekcja wyjaśnia, jak rastrować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Uzyskaj zastąpienia czcionek**

Użyj metody [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) , aby określić, które czcionki będą zastępowane podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) , które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w Pythonie wyświetla wszystkie zastąpienia czcionek dla prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) z listą indeksów slajdów, aby sprawdzić tylko zastąpienia wymagane do renderowania określonych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację przyrostowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Lista zawiera indeksy slajdów liczone od jedynki: `1` identyfikuje pierwszy slajd. Natomiast kolekcja [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) jest zerowa, więc ten sam slajd dostępny jest jako `presentation.slides[0]`. Pamiętaj o tej różnicy przy budowaniu listy, aby uniknąć błędów o jeden.

Wywołaj metodę przez właściwość [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) . Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) , zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla aktualne środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastąpienia przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) , oraz [zewnątrzładowane czcionki](/slides/pl/python-net/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników przy tworzeniu inwentarza czcionek lub raportu wstępnego. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Klasa [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) udostępnia oba warianty metody. Wybierz jedną w zależności od zakresu operacji renderowania:

| Method call | Use it when |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) z warunkiem [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję do właściwości [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Renderuj lub konwertuj prezentację.  

Poniższy przykład w Pythonie zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Jeśli chcesz bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Zastąpienie czcionek](/slides/pl/python-net/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną czcionkę określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu, a renderowanie może nadal zgłaszać, że wymagana jest **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnątrzładowaną czcionkę](/slides/pl/python-net/custom-font/).

To ograniczenie dotyczy układu równań. Opisane wyżej reguły zastępowania nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a jej zastępowaniem?**  
[Zastąpienie czcionek](/slides/pl/python-net/font-replacement/) świadomie zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionek wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**  
Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/python-net/font-selection-sequence/) podczas renderowania i konwersji. Przy `WHEN_INACCESSIBLE` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastępowania?**  
Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastępowania?**  
Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/python-net/custom-font/) , aby Aspose.Slides mogła ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**  
Nie. Odpowiadasz za udostępnianie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastępowania mogą różnić się między Windows, Linux i macOS?**  
Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**  
Używaj tych samych plików i wersji czcionek na każdej maszynie lub w kontenerze, [ładować wymagane zewnętrzne czcionki](/slides/pl/python-net/custom-font/) oraz [osadzać czcionki](/slides/pl/python-net/embedded-font/) gdy licencja na to pozwala. Możesz również wywołać [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.