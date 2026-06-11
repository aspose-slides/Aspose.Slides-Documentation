---
title: Konfiguracja podstawiania czcionek w prezentacjach przy użyciu JavaScript
linktitle: Podstawianie czcionek
type: docs
weight: 70
url: /pl/nodejs-java/font-substitution/
keywords:
- czcionka
- podstawianie czcionki
- podstawianie czcionki
- zamiana czcionki
- zamiana czcionki
- reguła podstawiania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Włącz optymalne podstawianie czcionek w Aspose.Slides dla Node.js podczas konwertowania prezentacji PowerPoint i OpenDocument na inne formaty plików w języku JavaScript."
---
## **Przegląd**

Podstawianie czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały podstawione, używając metody `getSubstitutions` z klasy `FontsManager`.

Aspose.Slides umożliwia także definiowanie reguł podstawiania czcionek. Na przykład możesz określić, że niedostępna czcionka ma być zastąpiona inną dostępną czcionką i następnie zastosować te reguły za pomocą menedżera czcionek prezentacji.

## **Ustaw reguły podstawiania czcionek**

Aspose.Slides pozwala ustawić reguły dla czcionek określające, co należy zrobić w określonych warunkach (na przykład, gdy czcionka nie jest dostępna) w następujący sposób:

1. Wczytaj odpowiednią prezentację.  
2. Wczytaj czcionkę, która ma zostać zastąpiona.  
3. Wczytaj nową czcionkę.  
4. Dodaj regułę zamiany.  
5. Dodaj regułę do kolekcji reguł zamiany czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zobaczyć efekt.

Ten kod JavaScript demonstruje proces podstawiania czcionek:

```javascript
// Ładuje prezentację
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Ładuje czcionkę źródłową, która ma zostać zastąpiona
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Ładuje nową czcionkę
    var destFont = new aspose.slides.FontData("Arial");
    // Dodaje regułę czcionki dla zamiany czcionki
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Dodaje regułę do kolekcji reguł podstawiania czcionek
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Dodaje kolekcję reguł czcionek do listy reguł
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Czcionka Arial będzie używana zamiast SomeRareFont, gdy ta ostatnia będzie niedostępna
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Zapisuje obraz na dysk w formacie JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Możesz chcieć zobaczyć [**Font Replacement**](/slides/pl/nodejs-java/font-replacement/).

{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły podstawiania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla zwykłych scenariuszy tekstowych, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby prawidłowo obliczyć i wyrenderować układ równania. Z tego powodu podstawianie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może skutkować wyjątkiem informującym, że wymagana jest czcionka **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [external font](/slides/pl/nodejs-java/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły podstawiania czcionek opisane powyżej nadal obowiązują dla zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **Najczęściej zadawane pytania**

**Jaka jest różnica między zamianą czcionki a podstawianiem czcionki?**

[Replacement](/slides/pl/nodejs-java/font-replacement/) to wymuszone zastąpienie jednej czcionki inną w całej prezentacji. Substitution to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły podstawiania?**

Reguły uczestniczą w standardowej [font selection](/slides/pl/nodejs-java/font-selection-sequence/) kolejności ocenianej podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowana jest zamiana lub podstawienie.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zamiany, ani podstawienia i czcionka jest brakująca w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałby się PowerPoint.

**Czy mogę dołączyć własne czcionki zewnętrzne w czasie wykonywania, aby uniknąć podstawienia?**

Tak. Możesz [add external fonts](/slides/pl/nodejs-java/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionek na własną odpowiedzialność i według własnego uznania.

**Czy istnieją różnice w zachowaniu podstawiania na Windows, Linux i macOS?**

Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek i ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę podstawiania.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwane podstawianie podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [add the external fonts](/slides/pl/nodejs-java/custom-font/) wymagane dla dokumentów wyjściowych oraz [embed fonts](/slides/pl/nodejs-java/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.