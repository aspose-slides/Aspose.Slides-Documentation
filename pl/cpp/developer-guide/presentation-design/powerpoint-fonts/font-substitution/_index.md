---
title: Konfiguracja podstawiania czcionek w prezentacjach przy użyciu C++
linktitle: Podstawianie czcionek
type: docs
weight: 70
url: /pl/cpp/font-substitution/
keywords:
- czcionka
- zastępowanie czcionki
- podstawianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła podstawiania
- reguła zastąpienia
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Umożliw optymalne podstawianie czcionek w Aspose.Slides dla C++ podczas konwertowania prezentacji PowerPoint i OpenDocument na inne formaty plików."
---
## **Przegląd**

Podstawianie czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały podstawione, używając metody `GetSubstitutions` z interfejsu `IFontsManager`.

Aspose.Slides umożliwia również definiowanie reguł podstawiania czcionek. Na przykład możesz określić, że niedostępna czcionka ma zostać zastąpiona inną dostępną czcionką i zastosować te reguły poprzez menedżer czcionek prezentacji.

## **Ustaw reguły podstawiania czcionek**

Aspose.Slides pozwala ustawiać reguły dla czcionek, które określają, co należy zrobić w określonych warunkach (na przykład, gdy nie można uzyskać dostępu do czcionki) w następujący sposób:

1. Załaduj odpowiednią prezentację.  
2. Załaduj czcionkę, która ma zostać zastąpiona.  
3. Załaduj nową czcionkę.  
4. Dodaj regułę zastąpienia.  
5. Dodaj regułę do kolekcji reguł zastąpienia czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zaobserwować efekt.

Ten kod w C++ demonstruje proces podstawiania czcionek:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Ładuje prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definiuje czcionkę, która zostanie zastąpiona oraz nową czcionkę
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Dodaje regułę czcionki dla zastąpienia czcionki
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Dodaje regułę do kolekcji reguł podstawiania czcionek
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Dodaje kolekcję reguł czcionek do listy reguł
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Zapisuje PPTX na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="UWAGA"  color="warning"   %}} 

Możesz chcieć zobaczyć [**Zastąpienie czcionek**](/slides/pl/cpp/font-replacement/). 

{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły podstawiania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla zwykłych scenariuszy tekstowych, w których Aspose.Slides może zastąpić niedostępną czcionkę inną dostępną czcionką zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają ważne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby obliczyć i poprawnie wyrenderować układ równania. Z tego powodu podstawienie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może skutkować wyjątkiem wskazującym, że wymagana jest **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [zewnętrzną czcionkę](/slides/pl/cpp/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły podstawiania czcionek opisane powyżej nadal obowiązują dla zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a jej podstawieniem?**

[Zastąpienie](/slides/pl/cpp/font-replacement/) to wymuszone nadpisanie jednej czcionki drugą w całej prezentacji. Podstawienie to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły podstawiania?**

Reguły uczestniczą w standardowej kolejności [wyboru czcionki](/slides/pl/cpp/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub podstawienie.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zastąpienia, ani podstawienia i czcionka brak jest w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałby się PowerPoint.

**Czy mogę dołączyć własne zewnętrzne czcionki w czasie wykonywania, aby uniknąć podstawienia?**

Tak. Możesz [dodać zewnętrzne czcionki](/slides/pl/cpp/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakiekolwiek czcionki razem z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionki według własnego uznania i odpowiedzialności.

**Czy istnieją różnice w zachowaniu podstawiania na systemach Windows, Linux i macOS?**

Tak. Wykrywanie czcionek zaczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek i ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę podstawiania.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwane podstawianie podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [dodaj wymagane zewnętrzne czcionki](/slides/pl/cpp/custom-font/) do dokumentów wyjściowych oraz [osadz czcionki](/slides/pl/cpp/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.