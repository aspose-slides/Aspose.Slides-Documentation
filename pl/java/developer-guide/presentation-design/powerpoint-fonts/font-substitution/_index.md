---
title: Konfiguracja substitucji czcionek w prezentacjach przy użyciu Javy
linktitle: Substitucja czcionek
type: docs
weight: 70
url: /pl/java/font-substitution/
keywords:
- czcionka
- zastąpienie czcionki
- substitucja czcionki
- zamiana czcionki
- zastąpienie czcionki
- reguła substitucji
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Włącz optymalną substitucję czcionek w Aspose.Slides dla Javy podczas konwersji prezentacji PowerPoint i OpenDocument do innych formatów plików."
---
## **Przegląd**

Substitucja czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji jest niedostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały zastąpione, używając metody `getSubstitutions` z interfejsu `IFontsManager`.

Aspose.Slides umożliwia również definiowanie reguł substitucji czcionek. Na przykład możesz określić, że niedostępna czcionka ma być zastąpiona inną dostępną czcionką i zastosować te reguły poprzez menedżera czcionek prezentacji.

## **Ustawianie reguł substitucji czcionek**

Aspose.Slides pozwala ustawić reguły dla czcionek określające, co należy zrobić w określonych warunkach (na przykład gdy czcionka nie jest dostępna) w następujący sposób:

1. Załaduj odpowiednią prezentację.  
2. Załaduj czcionkę, która ma zostać zastąpiona.  
3. Załaduj nową czcionkę.  
4. Dodaj regułę zastąpienia.  
5. Dodaj regułę do kolekcji reguł zastąpienia czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zaobserwować efekt.

Ten kod Java demonstruje proces substitucji czcionek:

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
    
    // Dodaje regułę do kolekcji reguł zastąpienia czcionek
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Dodaje kolekcję reguł czcionek do listy reguł
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Czcionka Arial będzie użyta zamiast SomeRareFont, gdy ta będzie niedostępna
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Zapisuje obraz na dysku w formacie JPEG
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

Możesz chcieć zobaczyć [**Zastąpienie czcionki**](/slides/pl/java/font-replacement/). 

{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły substitucji czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla zwykłych scenariuszy tekstowych, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math** do poprawnego obliczenia i wyrenderowania układu równania. Z tego powodu zastąpienie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równania i może skutkować wyjątkiem wskazującym, że wymagana jest **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [czcionkę zewnętrzną](/slides/pl/java/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły substitucji czcionek opisane powyżej nadal mają zastosowanie do zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a substitucją czcionki?**

[Zastąpienie](/slides/pl/java/font-replacement/) to wymuszone nadpisanie jednej czcionki drugą w całej prezentacji. Substitucja to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły substitucji?**

Reguły uczestniczą w standardowej kolejności [wyboru czcionki](/slides/pl/java/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub substitucja.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zastąpienia, ani substitucji i czcionka jest nieobecna w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowywałby się PowerPoint.

**Czy mogę dołączyć własne czcionki zewnętrzne w czasie wykonywania, aby uniknąć substitucji?**

Tak. Możesz [dodać czcionki zewnętrzne](/slides/pl/java/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionki na własną odpowiedzialność.

**Czy istnieją różnice w zachowaniu substitucji na Windows, Linux i macOS?**

Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek oraz ścieżki wyszukiwania różnią się między platformami, co wpływa na dostępność i potrzebę substitucji.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwaną substitucję podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [dodaj wymagane czcionki zewnętrzne](/slides/pl/java/custom-font/) do dokumentów wyjściowych oraz [osadź czcionki](/slides/pl/java/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.