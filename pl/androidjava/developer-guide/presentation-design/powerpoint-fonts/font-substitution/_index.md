---
title: Konfiguracja podstawiania czcionek w prezentacjach na Androidzie
linktitle: Podstawianie czcionek
type: docs
weight: 70
url: /pl/androidjava/font-substitution/
keywords:
- czcionka
- zastąpienie czcionki
- podstawianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła podstawiania
- reguła zastąpienia
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Włącz optymalne podstawianie czcionek w Aspose.Slides dla Androida przy użyciu Javy podczas konwersji prezentacji PowerPoint i OpenDocument do innych formatów plików."
---
## **Przegląd**

Podstawianie czcionek umożliwia Aspose.Slides użycie innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały podstawione, używając metody `getSubstitutions` z interfejsu `IFontsManager`.

Aspose.Slides umożliwia także definiowanie reguł podstawiania czcionek. Na przykład możesz określić, że niedostępna czcionka ma zostać zastąpiona inną dostępną czcionką i zastosować te reguły za pośrednictwem menedżera czcionek prezentacji.

## **Ustaw reguły podstawiania czcionek**

Aspose.Slides pozwala ustawić reguły dla czcionek, które określają, co należy zrobić w określonych sytuacjach (na przykład, gdy czcionka nie jest dostępna) w następujący sposób:

1. Załaduj odpowiednią prezentację.  
2. Załaduj czcionkę, która ma zostać zastąpiona.  
3. Załaduj nową czcionkę.  
4. Dodaj regułę zastąpienia.  
5. Dodaj regułę do kolekcji reguł zastąpień czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zobaczyć efekt.

Ten kod Java demonstruje proces podstawiania czcionek:

```java
// Ładuje prezentację
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Ładuje czcionkę źródłową, która zostanie zastąpiona
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Ładuje nową czcionkę
    IFontData destFont = new FontData("Arial");
    
    // Dodaje regułę czcionki dla zastąpienia czcionki
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Dodaje regułę do kolekcji reguł podstawiania czcionek
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Dodaje kolekcję reguł czcionek do listy reguł
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy ta ostatnia jest niedostępna
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Zapisuje obraz na dysk w formacie JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Możesz chcieć zobaczyć [**Zastępowanie czcionek**](/slides/pl/androidjava/font-replacement/).
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły podstawiania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla zwykłych scenariuszy tekstowych, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby poprawnie obliczyć i wyrenderować układ równania. Z tego powodu podstawianie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może skutkować wyjątkkiem wskazującym, że **Cambria Math** jest wymagana.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [zewnętrzną czcionkę](/slides/pl/androidjava/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły podstawiania czcionek opisane powyżej nadal obowiązują dla zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zastępowaniem czcionki a podstawianiem czcionki?**

[Zastąpienie](/slides/pl/androidjava/font-replacement/) to wymuszone nadpisanie jednej czcionki drugą w całej prezentacji. Podstawianie to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka awaryjna.

**Kiedy dokładnie stosowane są reguły podstawiania?**

Reguły uczestniczą w standardowej kolejności [wyboru czcionki](/slides/pl/androidjava/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub podstawienie.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zastąpienia, ani podstawienia i czcionka brakuję w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałaby się PowerPoint.

**Czy mogę dołączyć własne zewnętrzne czcionki w czasie wykonywania, aby uniknąć podstawiania?**

Tak. Możesz [dodać zewnętrzne czcionki](/slides/pl/androidjava/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; czcionki dodajesz i używasz na własną odpowiedzialność.

**Czy istnieją różnice w zachowaniu podstawiania na Windows, Linux i macOS?**

Tak. Wykrywanie czcionek zaczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek i ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę podstawiania.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwane podstawianie podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [dodaj wymagane zewnętrzne czcionki](/slides/pl/androidjava/custom-font/) do dokumentów wyjściowych oraz [osadź czcionki](/slides/pl/androidjava/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.