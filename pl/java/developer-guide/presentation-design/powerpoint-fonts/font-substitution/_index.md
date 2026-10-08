---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu języka Java
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Skonfiguruj reguły zastępowania czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla języka Java podczas renderowania lub konwersji prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, do której nie można uzyskać dostępu podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na wyjściowy rendering; nie zmienia ono czcionki przypisanej do zawartości prezentacji.

Można określić czcionkę, która ma być użyta, gdy konkretna czcionka jest niedostępna, oraz można przejrzeć zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyniku w środowiskach z różnymi zainstalowanymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanego pogrubionego kroju, zobacz [Obsługa czcionek bez dedykowanego pogrubionego kroju](/slides/pl/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ta sekcja wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF oraz konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Uzyskaj zastąpienia czcionek**

Użyj metody [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aby określić, które czcionki będą zastępowane podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

Poniższy przykład w języku Java wypisuje wszystkie zastąpienia czcionek dla prezentacji:

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

Użyj przeciążenia [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z argumentem `int[] slides`, aby przejrzeć tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów liczone od 1: `1` identyfikuje pierwszy slajd. Natomiast metoda dostępu do kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) używa indeksowania zerowego, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów o jeden element.

Wywołaj przeciążenie przez metodę [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) . Zwraca ono tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne oraz [zewnętrznie ładowane czcionki](/slides/pl/java/custom-font/). Reguły zastępowania przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) są stosowane podczas renderowania prezentacji, ale wynik ich nie wymienia; sprawdź czcionki w pliku wyjściowym.

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników, gdy tworzysz inwentaryzację czcionek lub raport weryfikacyjny. Poniższy przykład raportuje każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentów | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły zastępowania czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy źródłowa czcionka jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.  
3. Utwórz obiekt [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję przy użyciu metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w języku Java zastępuje `Arial` czcionką `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Zastępcza czcionka musi być dostępna dla Aspose.Slides.

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

{{% alert color="info" title="Uwaga" %}}

Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Zastąpienie czcionek](/slides/pl/java/font-replacement/).

{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną czcionkę określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu, a renderowanie nadal może zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/java/custom-font/).

To ograniczenie dotyczy układu równań. Reguły zastępowania opisane powyżej nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a zastępowaniem czcionki?**

[Zastąpienie czcionek](/slides/pl/java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastępowanie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastępowania?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/java/font-selection-sequence/) podczas renderowania i konwersji. Przy warunku `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastępowania?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastępowania?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczanie czcionek i przestrzeganie ich licencji spoczywa na Tobie.

**Czy wyniki zastępowania mogą się różnić między systemami Windows, Linux i macOS?**

Tak. Zainstalowane czcionki oraz lokalizacje ich wyszukiwania różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać zastąpienia na innym.

**Jak zapewnić spójny wybór czcionek w konwersjach wsadowych?**

Używaj tych samych plików czcionek i wersji na każdym komputerze lub w kontenerze, [załaduj wymagane zewnętrzne czcionki](/slides/pl/java/custom-font/), oraz [osadz czcionki](/slides/pl/java/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) przed eksportem, aby zidentyfikować nieoczekiwane zastąpienia.