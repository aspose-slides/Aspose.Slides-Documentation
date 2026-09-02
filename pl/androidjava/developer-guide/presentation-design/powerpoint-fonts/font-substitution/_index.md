---
title: Konfigurowanie podstawiania czcionek w prezentacjach na Androidzie
linktitle: Podstawianie czcionek
type: docs
weight: 70
url: /pl/androidjava/font-substitution/
keywords:
- czcionka
- czcionka zamienna
- podstawianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła podstawienia
- reguła zastąpienia
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konfiguruj reguły podstawiania czcionek i sprawdzaj podstawione czcionki w Aspose.Slides dla Androida przy użyciu Javy podczas renderowania lub konwersji prezentacji."
---
## **Przegląd**

Podstawianie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, której nie można uzyskać podczas renderowania lub konwersji prezentacji. Podstawienie dotyczy wyjściowego renderowanego wyniku; nie zmienia ono czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, której używać, gdy dana czcionka jest niedostępna, oraz możesz sprawdzić podstawienia, które Aspose.Slides wykona podczas renderowania. Pomaga to utrzymać spójność wyjścia na różnych urządzeniach z Androidem i w środowiskach z różnymi dostępnymi czcionkami.

## **Pobieranie podstawień czcionek**

Użyj metody [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aby określić, które czcionki zostaną podstawione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstitutioninfo/), które określają nazwy oryginalnej i podstawionej czcionki.

Przykład poniżej w języku Java wyświetla wszystkie podstawienia czcionek dla prezentacji:

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

## **Pobieranie podstawień czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z argumentem `int[] slides`, aby sprawdzić tylko podstawienia niezbędne do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację partiami, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla aplikacji Android lub diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów numerowane od jedynki: `1` oznacza pierwszy slajd. Natomiast dostęp do kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--) używa indeksowania zerowego, więc ten sam slajd można uzyskać jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy tworzeniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie za pomocą metody [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getFontsManager--). Zwraca ona tylko podstawienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstitutioninfo/), zawierającym nazwę oryginalnej i podstawionej czcionki. Wynik odzwierciedla aktualne środowisko czcionek, skonfigurowane reguły awaryjne, reguły podstawień zapisane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie ładowane czcionki](/slides/pl/androidjava/custom-font/).

To samo podstawienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników podczas tworzenia inwentaryzacji czcionek lub raportu wstępnego. Poniższy przykład wyświetla każde zwrócone podstawienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz odpowiednie w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentów | Potrzebujesz podstawień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z `int[] slides` | Potrzebujesz podstawień dla wybranego zakresu, kontroli przyrostowej lub częściowego eksportu. |

## **Ustawianie reguł podstawień czcionek**

Aby określić czcionkę, której Aspose.Slides powinien używać, gdy czcionka źródłowa jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i podstawiającej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję przy użyciu metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w Java podstawia `Arial` zamiast `SomeRareFont`, gdy `SomeRareFont` jest niedostępny, a następnie renderuje pierwszy slajd, aby zweryfikować wynik. Czcionka podstawiająca musi być dostępna dla Aspose.Slides.

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
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/androidjava/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły podstawień czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają one dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę czcionką wskazaną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować dokładnie tej czcionki do obliczenia i renderowania układu równania. Reguła podstawiająca inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Wczytaj ją jako [zewnętrzną czcionkę](/slides/pl/androidjava/custom-font/), aby aplikacja mogła jej używać podczas renderowania i konwersji.

To ograniczenie dotyczy układu równań. Opisane powyżej reguły podstawień nadal obowiązują dla zwykłego tekstu prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a podstawianiem czcionki?**

[Font replacement](/slides/pl/androidjava/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Podstawianie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły podstawień?**

Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/androidjava/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły podstawienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku wykonawczym.

**Czy mogę wczytać zewnętrzne czcionki, aby uniknąć podstawień?**

Tak. Możesz [wczytać zewnętrzne czcionki](/slides/pl/androidjava/custom-font/), aby Aspose.Slides mógł ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki razem z biblioteką?**

Nie. To Ty jesteś odpowiedzialny za dostarczenie czcionek i przestrzeganie ich licencji.

**Czy wyniki podstawień mogą różnić się między urządzeniami z Androidem?**

Tak. Dostępne czcionki systemowe mogą się różnić w zależności od wersji Androida, urządzenia i producenta, więc czcionka dostępna w jednym środowisku może wymagać podstawienia w innym.

**Jak zapewnić spójny wybór czcionek na różnych urządzeniach z Androidem?**

Dołącz te same wymagane pliki czcionek do aplikacji, [wczytaj je jako zewnętrzne czcionki](/slides/pl/androidjava/custom-font/) i [osadź czcionki](/slides/pl/androidjava/embedded-font/), gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) przed eksportem, aby wykryć nieoczekiwane podstawienia.