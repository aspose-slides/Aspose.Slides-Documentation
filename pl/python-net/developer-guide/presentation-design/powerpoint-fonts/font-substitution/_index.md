---
title: Konfiguracja zastąpień czcionek w prezentacjach w języku Python
linktitle: Zastąpienie czcionek
type: docs
weight: 70
url: /pl/python-net/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- zastąpienie czcionki
- zamiana czcionki
- zamiana czcionki
- reguła zastąpienia
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Skonfiguruj reguły zastąpień czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla Pythona za pośrednictwem .NET podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wynik renderowania; nie zmienia czcionki przypisanej do zawartości prezentacji.

Można określić czcionkę, która ma być używana, gdy dana czcionka jest niedostępna, oraz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyniku w środowiskach z różnymi zainstalowanymi czcionkami.

## **Pobieranie zastąpień czcionek**

Użyj metody [FontsManager.get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) aby określić, które czcionki zostaną zastąpione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w Pythonie wyświetla wszystkie zastąpienia czcionek dla prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Pobieranie zastąpień czcionek dla wybranych slajdów**

Użyj [FontsManager.get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) z listą indeksów slajdów, aby sprawdzić tylko te zastąpienia, które są wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację etapowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Lista zawiera indeksy slajdów liczone od 1: `1` identyfikuje pierwszy slajd. Natomiast kolekcja [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) jest zerowo‑indeksowana, więc ten sam slajd jest dostępny jako `presentation.slides[0]`. Pamiętaj o tej różnicy przy tworzeniu listy, aby uniknąć błędów off‑by‑one.

Wywołaj metodę przez właściwość [Presentation.fonts_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/). Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstitutioninfo/), zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastąpień zapisane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie wczytane czcionki](/slides/pl/python-net/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników przy tworzeniu inwentarza czcionek lub raportu wstępnej kontroli. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Klasa [FontsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/) udostępnia obie formy metody. Wybierz jedną w zależności od zakresu operacji renderowania:

| Wywołanie metody | Kiedy używać |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) z listą indeksów slajdów | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustawianie reguł zastąpień czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstrule/) z warunkiem [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję do właściwości [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w Pythonie zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Czcionka zastępcza musi być dostępna dla Aspose.Slides.

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
Dla bezwarunkowej zmiany czcionek używanych w całej prezentacji zobacz [Zamianę czcionek](/slides/pl/python-net/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastąpień czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną czcionkę określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i wyrenderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, np. **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/python-net/custom-font/).

Ograniczenie dotyczy układu równań. Opisane wyżej reguły zastąpień nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a zastąpieniem czcionki?**

[Zamiana czcionki](/slides/pl/python-net/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastąpienie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastąpień?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/python-net/font-selection-sequence/) podczas renderowania i konwersji. Przy warunku `WHEN_INACCESSIBLE` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionki. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastąpienia?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/python-net/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiada Pan/Pani za udostępnienie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastąpień mogą się różnić między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednej maszynie może wymagać zastąpienia na innej.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików czcionek i ich wersji na każdej maszynie lub w kontenerze, [ładuj wymagane zewnętrzne czcionki](/slides/pl/python-net/custom-font/), oraz [osadzaj czcionki](/slides/pl/python-net/embedded-font/), jeśli licencja na to pozwala. Możesz również wywołać [FontsManager.get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.