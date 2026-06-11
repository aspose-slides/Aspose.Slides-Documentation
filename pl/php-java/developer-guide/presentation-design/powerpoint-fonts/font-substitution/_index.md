---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu PHP
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/php-java/font-substitution/
keywords:
- czcionka
- zastępowanie czcionki
- zastępowanie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła zastępowania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Umożliw optymalne zastępowanie czcionek w Aspose.Slides dla PHP przy użyciu Javy podczas konwertowania prezentacji PowerPoint i OpenDocument na inne formaty plików."
---
## **Wprowadzenie**

Zastępowanie czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały zastąpione, używając metody `getSubstitutions` z klasy `FontsManager`.

Aspose.Slides umożliwia również definiowanie reguł zastępowania czcionek. Na przykład możesz określić, że niedostępna czcionka ma zostać zastąpiona inną dostępną czcionką i następnie zastosować te reguły za pośrednictwem menedżera czcionek prezentacji.

## **Ustaw reguły zastępowania czcionek**

Aspose.Slides pozwala ustawić reguły dla czcionek, które określają, co należy zrobić w określonych warunkach (na przykład, gdy czcionka nie jest dostępna) w następujący sposób:

1. Wczytaj odpowiednią prezentację.
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę.
4. Dodaj regułę zastąpienia.
5. Dodaj regułę do kolekcji reguł zastępowania czcionek prezentacji.
6. Wygeneruj obraz slajdu, aby zobaczyć efekt.

Ten kod PHP demonstruje proces zastępowania czcionek:

```php
  # Ładuje prezentację
  $pres = new Presentation("Fonts.pptx");
  try {
    # Ładuje czcionkę źródłową, która zostanie zastąpiona
    $sourceFont = new FontData("SomeRareFont");
    # Ładuje nową czcionkę
    $destFont = new FontData("Arial");
    # Dodaje regułę zamiany czcionki
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Dodaje regułę do kolekcji reguł zastępowania czcionek
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Dodaje kolekcję reguł czcionek do listy reguł
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy ta ostatnia jest niedostępna
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Zapisuje obraz na dysku w formacie JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 
Możesz chcieć zobaczyć [**Font Replacement**](/slides/pl/php-java/font-replacement/).

{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastępowania czcionek biorą udział w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla scenariuszy zwykłego tekstu, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają istotne ograniczenie. Jeśli równanie zostało stworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby prawidłowo obliczyć i wyrenderować układ równania. Z tego powodu zastąpienie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może nadal skutkować wyjątkiem wskazującym, że wymagana jest **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [zewnętrzną czcionkę](/slides/pl/php-java/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły zastępowania czcionek opisane powyżej nadal obowiązują w przypadku zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a jej zastąpieniem?**  
[Replacement](/slides/pl/php-java/font-replacement/) to wymuszona zamiana jednej czcionki na inną w całej prezentacji. Zastąpienie (substitution) jest regułą, która uruchamia się w określonych warunkach, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły zastępowania?**  
Reguły biorą udział w standardowej sekwencji [wyboru czcionki](/slides/pl/php-java/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub zamiana.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zamiany, ani zastąpienia oraz czcionka jest nieobecna w systemie?**  
Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałby się PowerPoint.

**Czy mogę dołączyć własne zewnętrzne czcionki w czasie działania, aby uniknąć zamiany?**  
Tak. Możesz [dodać zewnętrzne czcionki](/slides/pl/php-java/custom-font/) w czasie działania, aby biblioteka uwzględniała je przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki razem z biblioteką?**  
Nie. Aspose nie dystrybuuje żadnych czcionek, płatnych ani darmowych; dodajesz i używasz czcionki według własnego uznania i odpowiedzialności.

**Czy istnieją różnice w zachowaniu zamiany na systemach Windows, Linux i macOS?**  
Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek oraz ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę zamiany.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwaną zamianę podczas konwersji wsadowych?**  
Zsynchronizuj zestaw czcionek pomiędzy maszynami lub kontenerami, [dodaj zewnętrzne czcionki](/slides/pl/php-java/custom-font/) wymagane dla dokumentów wyjściowych oraz [osadź czcionki](/slides/pl/php-java/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.