---
title: "Konfiguracja podstawiania czcionek w prezentacjach przy użyciu Javy"
linktitle: "Podstawianie czcionek"
type: docs
weight: 70
url: /pl/java/font-substitution/
keywords:
- czcionka
- czcionka zastępcza
- podstawianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła podstawiania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Konfiguruj reguły podstawiania czcionek i sprawdzaj podstawione czcionki w Aspose.Slides dla Javy podczas renderowania lub konwersji prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Podstawianie czcionek umożliwia Aspose.Slides użycie dostępnej czcionki zamiast czcionki, której nie można uzyskać podczas renderowania lub konwersji prezentacji. Substytucja wpływa na renderowany wynik; nie zmienia czcionki przypisanej do treści prezentacji.

Możesz określić czcionkę, którą należy użyć, gdy dana czcionka jest niedostępna, oraz sprawdzić podstawienia, które Aspose.Slides wykona podczas renderowania. Pomaga to zachować spójność wyniku w środowiskach o różnych zainstalowanych czcionkach.

## **Uzyskaj podstawienia czcionek**

Użyj metody [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aby określić, które czcionki zostaną podstawione podczas renderowania prezentacji. Metoda zwraca obiekty [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstitutioninfo/), które identyfikują pierwotne i podstawione nazwy czcionek.

Poniższy przykład w Javie wyświetla wszystkie podstawienia czcionek dla prezentacji:

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

## **Uzyskaj podstawienia czcionek dla wybranych slajdów**

Użyj przeciążenia [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z argumentem `int[] slides`, aby sprawdzić tylko podstawienia wymagane do renderowania wybranych slajdów. Jest to przydatne, gdy renderujesz lub eksportujesz część prezentacji, sprawdzasz dużą prezentację stopniowo, lokalizujesz slajdy zależne od niedostępnych czcionek, przygotowujesz minimalny pakiet czcionek dla serwera lub kontenera albo diagnozujesz różnice w renderowaniu bez przetwarzania niepowiązanych slajdów.

Tablica `slides` zawiera indeksy slajdów liczone od 1: `1` identyfikuje pierwszy slajd. Natomiast dostęp do kolekcji [Presentation.getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--) używa indeksowania od 0, więc ten sam slajd uzyskuje się jako `presentation.getSlides().get_Item(0)`. Pamiętaj o tej różnicy przy budowaniu tablicy, aby uniknąć błędów „off‑by‑one”.

Wywołaj przeciążenie przez metodę [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getFontsManager--) . Zwraca ona tylko podstawienia określone podczas renderowania wybranych slajdów. Każdy wynik jest obiektem [FontSubstitutionInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstitutioninfo/), zawierającym pierwotną i podstawioną nazwę czcionki. Wynik odzwierciedla bieżące środowisko czcionek, skonfigurowane reguły awaryjne, reguły podstawiania zapisane w [IFontSubstRuleCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsubstrulecollection/), oraz [zewnętrznie załadowane czcionki](/slides/pl/java/custom-font/).

Ta sama podstawienie może być wymagane przez więcej niż jeden wybrany slajd. Usuń duplikaty, gdy tworzysz inwentaryzację czcionek lub raport wstępny. Poniższy przykład raportuje każde zwrócone podstawienie, a następnie tworzy posortowaną listę unikalnych mapowań czcionek:

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

Interfejs [IFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/) udostępnia oba przeciążenia. Wybierz jedno zgodnie z zakresem operacji renderowania:

| Przeciążenie | Kiedy używać |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentów | Potrzebujesz podstawień dla całej prezentacji. |
| [getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) z `int[] slides` | Potrzebujesz podstawień dla wybranego zakresu, sprawdzenia przyrostowego lub częściowego eksportu. |

## **Ustaw reguły podstawiania czcionek**

Aby określić czcionkę, której Aspose.Slides powinien używać, gdy czcionka źródłowa jest niedostępna:

1. Załaduj prezentację.  
2. Utwórz definicje czcionek dla czcionki źródłowej i podstawiającej.  
3. Utwórz obiekt [FontSubstRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrule/) z warunkiem [WhenInaccessible](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstcondition/).  
4. Dodaj regułę do [FontSubstRuleCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrulecollection/).  
5. Przypisz kolekcję, używając metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Renderuj lub konwertuj prezentację.

Poniższy przykład w Javie podmienia `Arial` na `SomeRareFont`, gdy `SomeRareFont` jest niedostępna, a następnie renderuje pierwszy slajd w celu weryfikacji wyniku. Czcionka podstawiająca musi być dostępna dla Aspose.Slides.

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
Aby bezwarunkowo zmienić czcionki używane w całej prezentacji, zobacz [Font Replacement](/slides/pl/java/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły podstawiania czcionek są częścią standardowego procesu wyboru czcionki używanego podczas renderowania i konwersji. Działają dla zwykłego tekstu, gdy Aspose.Slides może zastąpić niedostępną czcionkę czcionką określoną w regule.

Równania Office Math mają dodatkowy wymóg. Jeśli równanie używa **Cambria Math**, Aspose.Slides może potrzebować tej właśnie czcionki do obliczenia i renderowania układu równania. Reguła, która podmienia inną czcionkę matematyczną, np. **STIX Two Math**, nie może zastąpić **Cambria Math** w tym celu i renderowanie może nadal zgłaszać wymóg **Cambria Math**.

Aby renderować lub konwertować taką prezentację, udostępnij **Cambria Math** Aspose.Slides. Zainstaluj ją w systemie operacyjnym lub załaduj jako [zewnętrzną czcionkę](/slides/pl/java/custom-font/).

Ograniczenie dotyczy układu równań. Opisane wyżej reguły podstawiania nadal obowiązują dla zwykłego tekstu w prezentacji.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a podstawianiem czcionki?**  
[Font replacement](/slides/pl/java/font-replacement/) celowo zmienia jedną czcionkę na inną w całej prezentacji. Podstawianie czcionki wybiera czcionkę dla wyjścia renderowanego, gdy spełniony jest skonfigurowany warunek, np. gdy oryginalna czcionka jest niedostępna.

**Kiedy stosowane są reguły podstawiania?**  
Reguły uczestniczą w [sekwencji wyboru czcionki](/slides/pl/java/font-selection-sequence/) podczas renderowania i konwersji. Z warunkiem `WhenInaccessible` reguła jest używana tylko wtedy, gdy Aspose.Slides nie może uzyskać dostępu do czcionki źródłowej.

**Co się dzieje, gdy czcionka jest brakująca i nie skonfigurowano reguły podstawiania?**  
Aspose.Slides wybiera najbliższą dostępną czcionkę zgodnie ze swoim procesem wyboru czcionki. Wynik zależy od czcionek dostępnych w środowisku uruchomieniowym.

**Czy mogę załadować zewnętrzne czcionki, aby uniknąć podstawiania?**  
Tak. możesz [załadować zewnętrzne czcionki](/slides/pl/java/custom-font/), aby Aspose.Slides mogło ich używać podczas renderowania i konwersji.

**Czy Aspose dystrybuuje czcionki wraz z biblioteką?**  
Nie. Odpowiadasz za dostarczenie czcionek i przestrzeganie ich licencji.

**Czy wyniki podstawiania mogą się różnić między systemami Windows, Linux i macOS?**  
Tak. Zainstalowane czcionki i miejsca ich wyszukiwania różnią się w zależności od systemu operacyjnego, więc czcionka dostępna na jednym komputerze może wymagać podstawienia na innym.

**Jak zapewnić spójny wybór czcionek przy konwersjach wsadowych?**  
Używaj tych samych plików i wersji czcionek na każdym komputerze lub w kontenerze, [załaduj wymagane zewnętrzne czcionki](/slides/pl/java/custom-font/), oraz [osadz czcionki](/slides/pl/java/embedded-font/) gdy licencja na to pozwala. Możesz również wywołać [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) przed eksportem, aby zidentyfikować nieoczekiwane podstawienia.