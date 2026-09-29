---
title: "Konfiguracja zastąpienia czcionki w prezentacjach przy użyciu Javy"
linktitle: "Zastąpienie czcionki"
type: docs
weight: 70
url: /pl/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Konfiguruj reguły zastąpienia czcionek i przeglądaj zastąpione czcionki w Aspose.Slides dla Javy podczas renderowania lub konwertowania prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastąpienie czcionki umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na renderowany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, którą należy używać, gdy dana czcionka jest niedostępna, oraz możesz sprawdzić zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyniku w różnych środowiskach z różnymi zainstalowanymi czcionkami.

## **Uzyskaj zastąpienia czcionek**

Użyj metody [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aby określić, które czcionki będą zastępowane podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstitutioninfo/), które identyfikują pierwotne i zastąpione nazwy czcionek.

Poniższy przykład w języku Java wymienia wszystkie zastąpienia czcionek dla prezentacji:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Uzyskaj zastąpienia czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z argumentem `int[] slides`, aby sprawdzić tylko te zastąpienia, które są wymagane do renderowania konkretnych slajdów. Jest to przydatne podczas renderowania lub eksportu części prezentacji, stopniowego sprawdzania dużej prezentacji, znajdowania slajdów zależnych od niedostępnych czcionek, przygotowywania minimalnego pakietu czcionek dla serwera lub kontenera, lub diagnozowania różnic w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów zaczynające się od jedynki: `1` identyfikuje pierwszy slajd. Natomiast dostępnik kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--) używa indeksowania zerowego, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów off-by-one.

Wywołaj przeciążenie za pomocą metody [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getFontsManager--). Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstitutioninfo/), zawierającym pierwotną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne oraz [zewnętrznie wczytane czcionki](/slides/pl/java/custom-font/). Reguły zastąpienia przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsubstrulecollection/) są stosowane podczas renderowania prezentacji, lecz wynik ich nie wymienia; zamiast tego sprawdź czcionki w pliku wyjściowym.

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Interfejs [IFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzania przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastąpienia czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję przy użyciu metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) .
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w języku Java zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastąpienia czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę dostępną czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować dokładnie tej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu, a renderowanie może nadal zgłaszać, że potrzebna jest **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** dla Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub wczytaj jako [zewnętrzną czcionkę](/slides/pl/java/custom-font/).

To ograniczenie dotyczy układu równań. Opisane powyżej reguły zastąpienia nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a zastąpieniem czcionki?**

[Font replacement](/slides/pl/java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastąpienie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony zostanie skonfigurowany warunek, np. gdy pierwotna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastąpienia?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/java/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku wykonawczym.

**Czy mogę wczytać zewnętrzne czcionki, aby uniknąć zastąpienia?**

Tak. Możesz [wczytać zewnętrzne czcionki](/slides/pl/java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. To Ty jesteś odpowiedzialny za dostarczanie czcionek i przestrzeganie ich licencji.

**Czy wyniki zastąpienia mogą się różnić między Windows, Linux i macOS?**

Tak. Zainstalowane czcionki i lokalizacje wyszukiwania czcionek różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójną selekcję czcionek w konwersjach wsadowych?**

Używaj tych samych plików czcionek i wersji na każdym komputerze lub w kontenerze, [wczytuj wymagane zewnętrzne czcionki](/slides/pl/java/custom-font/) oraz [osadzaj czcionki](/slides/pl/java/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.