---
title: Konfiguracja zastąpień czcionek w prezentacjach na Androidzie
linktitle: Zastąpienie czcionki
type: docs
weight: 70
url: /pl/androidjava/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- zastąpienie czcionki
- zamiana czcionki
- wymiana czcionki
- reguła zastąpienia
- reguła wymiany
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Skonfiguruj reguły zastąpień czcionek i sprawdź zastąpione czcionki w Aspose.Slides dla Androida za pomocą Javy podczas renderowania lub konwertowania prezentacji."
---
## **Przegląd**

Zastąpienie czcionki pozwala Aspose.Slides używać dostępnej czcionki zamiast czcionki, której nie można uzyskać podczas renderowania lub konwersji prezentacji. Zastąpienie wpływa na renderowany wynik; nie zmienia czcionki przypisanej do zawartości prezentacji.

Możesz zdefiniować czcionkę, którą należy używać, gdy dana czcionka jest niedostępna, oraz możesz przeglądać zastąpienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyjścia na różnych urządzeniach z systemem Android i w środowiskach z różnymi dostępnymi czcionkami.

Jeśli czcionka jest dostępna, ale nie ma dedykowanej pogrubionej odmiany, zobacz [Obsługa czcionek bez dedykowanej pogrubionej odmiany](/slides/pl/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ta sekcja wyjaśnia, jak rasteryzować dotknięty tekst podczas eksportu do PDF i konsekwencje dla zaznaczania tekstu, wyszukiwania i skalowania.

## **Uzyskiwanie zastąpień czcionek**

Użyj metody [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aby określić, które czcionki będą zastępowane podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), które identyfikują oryginalne i zastąpione nazwy czcionek.

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

## **Uzyskiwanie zastąpień czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z argumentem `int[] slides`, aby sprawdzić tylko zastąpienia wymagane do renderowania konkretnych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację iteracyjnie, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla aplikacji Android lub diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów liczone od jedynki: `1` określa pierwszy slajd. Natomiast dostęp do kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) używa indeksowania zerowego, więc ten sam slajd jest dostępny jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów o jeden.

Wywołaj przeciążenie za pomocą metody [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Zwraca ona tylko zastąpienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), zawierającym oryginalną i zastąpioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły zastąpień przechowywane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie załadowane czcionki](/slides/pl/androidjava/custom-font/).

To samo zastąpienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty wyników podczas tworzenia inwentarza czcionek lub raportu przedprodukcyjnego. Poniższy przykład zgłasza każde zwrócone zastąpienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno w zależności od zakresu operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Potrzebujesz zastąpień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Potrzebujesz zastąpień dla wybranego zakresu, sprawdzenia iteracyjnego lub częściowego eksportu. |

## **Ustaw reguły zastąpień czcionek**

Aby określić czcionkę, której Aspose.Slides ma używać, gdy czcionka źródłowa jest niedostępna:

1. Wczytaj prezentację.
2. Utwórz definicje czcionek dla czcionki źródłowej i zastępczej.
3. Utwórz [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Przypisz kolekcję za pomocą metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
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
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/androidjava/font-replacement/).
{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastąpień czcionek są częścią standardowego procesu wyboru czcionek używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zamienić niedostępną czcionkę na dostępną czcionkę określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej dokładnej czcionki do obliczenia i renderowania układu równania. Reguła, która zastępuje inną czcionkę matematyczną, taką jak **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu, a renderowanie może nadal zgłaszać, że **Cambria Math** jest wymagana.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Załaduj ją jako [zewnętrzną czcionkę](/slides/pl/androidjava/custom-font/), aby aplikacja mogła używać jej podczas renderowania i konwersji.

Ograniczenie to dotyczy układu równań. Opisane powyżej reguły zastąpień nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a zastąpieniem czcionki?**

[Font replacement](/slides/pl/androidjava/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Zastąpienie czcionki wybiera czcionkę dla renderowanego wyniku, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły zastąpień?**

Reguły uczestniczą w [font selection sequence](/slides/pl/androidjava/font-selection-sequence/) podczas renderowania i konwersji. Przy `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły zastąpienia?**

Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionek. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć zastąpienia?**

Tak. Możesz [załadować zewnętrzne czcionki](/slides/pl/androidjava/custom-font/) aby Aspose.Slides mógł ich używać podczas renderowania i konwersji.

**Czy Aspose dostarcza czcionki wraz z biblioteką?**

Nie. Odpowiedzialność za dostarczanie czcionek i przestrzeganie ich licencji spoczywa na Tobie.

**Czy wyniki zastąpień mogą się różnić między urządzeniami z Androidem?**

Tak. Dostępne czcionki systemowe mogą się różnić w zależności od wersji Androida, urządzeń i producentów, więc czcionka dostępna w jednym środowisku może wymagać zastąpienia w innym.

**Jak zapewnić spójny wybór czcionek na różnych urządzeniach z Androidem?**

Zaprojektuj tę samą wymaganą paczkę czcionek w aplikacji, [załadować je jako zewnętrzne czcionki](/slides/pl/androidjava/custom-font/) i [osadzić czcionki](/slides/pl/androidjava/embedded-font/) gdy licencja na to pozwala. Możesz także wywołać [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) przed eksportem, aby wykryć nieoczekiwane zastąpienia.