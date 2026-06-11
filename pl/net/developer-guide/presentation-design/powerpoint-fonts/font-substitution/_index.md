---
title: Konfiguracja podstawiania czcionek w prezentacjach w .NET
linktitle: Podstawianie czcionek
type: docs
weight: 70
url: /pl/net/font-substitution/
keywords:
- czcionka
- podstawianie czcionki
- podstawianie czcionki
- zastąpienie czcionki
- zastąpienie czcionki
- reguła podstawiania
- reguła zastąpienia
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Umożliw optymalne podstawianie czcionek w Aspose.Slides dla .NET podczas konwertowania prezentacji PowerPoint i OpenDocument do innych formatów plików."
---
## **Przegląd**

Podstawianie czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały podstawione, używając metody `GetSubstitutions` z interfejsu `IFontsManager`.

Aspose.Slides umożliwia również definiowanie reguł podstawiania czcionek. Na przykład możesz określić, że niedostępna czcionka ma zostać zastąpiona inną dostępną czcionką, a następnie zastosować te reguły za pośrednictwem menedżera czcionek prezentacji.

## **Uzyskaj podstawienia czcionek**

Aby umożliwić Ci ustalenie, które czcionki w prezentacji są podstawiane podczas procesu renderowania, Aspose.Slides udostępnia metodę [GetSubstitution](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getsubstitutions/) z interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/).

Kod C# pokazuje, jak uzyskać wszystkie podstawienia czcionek wykonywane podczas renderowania prezentacji:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Ustaw reguły podstawiania czcionek**

Aspose.Slides pozwala ustawić reguły dla czcionek, które określają, co należy zrobić w określonych warunkach (na przykład, gdy czcionka nie jest dostępna) w następujący sposób:

1. Załaduj odpowiednią prezentację.
2. Załaduj czcionkę, która ma zostać zastąpiona.
3. Załaduj nową czcionkę.
4. Dodaj regułę zastąpienia.
5. Dodaj regułę do kolekcji reguł zastępowania czcionek prezentacji.
6. Wygeneruj obraz slajdu, aby zobaczyć efekt.

Ten kod C# demonstruje proces podstawiania czcionek:
```c#
// Ładuje prezentację
Presentation presentation = new Presentation("Fonts.pptx");

// Ładuje czcionkę źródłową, która zostanie zastąpiona
IFontData sourceFont = new FontData("SomeRareFont");

// Ładuje nową czcionkę
IFontData destFont = new FontData("Arial");

// Dodaje regułę czcionki dla zastąpienia czcionki
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Dodaje regułę do kolekcji reguł podstawiania czcionek
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Dodaje kolekcję reguł czcionek do listy reguł
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Zapisuje obraz na dysku w formacie JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Możesz chcieć zobaczyć [**Zastąpienie czcionek**](/slides/pl/net/font-replacement/). 
{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły podstawiania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla typowych scenariuszy tekstowych, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby poprawnie obliczyć i renderować układ równania. Z tego powodu podstawianie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może skutkować wyjątkiem wskazującym, że wymagana jest czcionka **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [zewnętrzną czcionkę](/slides/pl/net/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły podstawiania czcionek opisane powyżej nadal obowiązują w przypadku zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **Najczęściej zadawane pytania**

**Jaka jest różnica między zastąpieniem czcionki a podstawieniem czcionki?**

[Replacement](/slides/pl/net/font-replacement/) to wymuszone zastąpienie jednej czcionki inną w całej prezentacji. Podstawienie to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest określona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły podstawiania?**

Reguły uczestniczą w standardowej sekwencji [wyboru czcionki](/slides/pl/net/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub podstawienie.

**Jakie jest domyślne zachowanie, gdy nie skonfigurowano ani zastąpienia, ani podstawienia, a czcionka jest nieobecna w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałby się PowerPoint.

**Czy mogę dołączyć własne zewnętrzne czcionki w czasie działania, aby uniknąć podstawienia?**

Tak. Możesz [dodać zewnętrzne czcionki](/slides/pl/net/custom-font/) w czasie działania, aby biblioteka uwzględniała je przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki wraz z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionki na własną odpowiedzialność i według własnego uznania.

**Czy istnieją różnice w zachowaniu podstawiania na systemach Windows, Linux i macOS?**

Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek oraz ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę podstawiania.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwane podstawienia podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [dodaj zewnętrzne czcionki](/slides/pl/net/custom-font/) wymagane dla dokumentów wyjściowych oraz [osadź czcionki](/slides/pl/net/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.