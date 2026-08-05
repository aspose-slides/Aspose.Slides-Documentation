---
title: Konfiguracja zastępowania czcionek w prezentacjach przy użyciu C++
linktitle: Zastępowanie czcionek
type: docs
weight: 70
url: /pl/cpp/font-substitution/
keywords:
- czcionka
- zastąpienie czcionki
- zastępowanie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła zastępowania
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Włącz optymalne zastępowanie czcionek w Aspose.Slides dla C++ podczas konwertowania prezentacji PowerPoint i OpenDocument do innych formatów plików."
---
## **Przegląd**

Zastępowanie czcionek umożliwia Aspose.Slides użycie innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały zastąpione, korzystając z metody `GetSubstitutions` z interfejsu `IFontsManager`.

Aspose.Slides pozwala również zdefiniować reguły zastępowania czcionek. Na przykład możesz określić, że niedostępna czcionka ma być zamieniona na inną dostępną czcionkę i zastosować te reguły poprzez menedżera czcionek prezentacji.

## **Ustawianie reguł zastępowania czcionek**

Aspose.Slides umożliwia ustawienie reguł dla czcionek, które określają, co należy zrobić w określonych warunkach (na przykład, gdy czcionka nie jest dostępna) w następujący sposób:

1. Załaduj odpowiednią prezentację.  
2. Załaduj czcionkę, która ma zostać zastąpiona.  
3. Załaduj nową czcionkę.  
4. Dodaj regułę zastąpienia.  
5. Dodaj regułę do kolekcji reguł zastępowania czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zobaczyć efekt.

Ten kod C++ demonstruje proces zastępowania czcionek:

```c++
// Ścieżka do katalogu z dokumentami.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Ładuje prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definiuje czcionkę, która zostanie zastąpiona oraz nową czcionkę
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Dodaje regułę czcionki dla zastąpienia czcionki
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Dodaje regułę do kolekcji reguł zastępowania czcionek
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Dodaje kolekcję reguł czcionek do listy reguł
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Zapisuje PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="UWAGA"  color="warning"   %}} 

Możesz chcieć zobaczyć [**Zastąpienie czcionek**](/slides/pl/cpp/font-replacement/). 

{{% /alert %}}

## **Ograniczenia dotyczące czcionek równań matematycznych**

Reguły zastępowania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla zwykłych scenariuszy tekstowych, w których Aspose.Slides może zamienić niedostępną czcionkę na inną dostępną czcionkę zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math** do poprawnego obliczenia i renderowania układu równania. Z tego powodu zamiana **Cambria Math** na inną czcionkę matematyczną, taką jak **STIX Two Math**, nie jest obsługiwana przy renderowaniu równań i może skutkować wyjątkiem wskazującym, że wymagana jest **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [zewnętrzną czcionkę](/slides/pl/cpp/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionek podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły zastępowania czcionek opisane powyżej nadal obowiązują dla regularnego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zastąpieniem czcionki a jej podmianą?**

[Zastąpienie](/slides/pl/cpp/font-replacement/) to wymuszone nadpisanie jednej czcionki drugą w całej prezentacji. Podmiana to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wybrana czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły podmiany?**

Reguły uczestniczą w standardowej kolejności [wyboru czcionki](/slides/pl/cpp/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub podmiana.

**Jakie jest zachowanie domyślne, jeśli nie skonfigurowano ani zastąpienia, ani podmiany, a czcionka nie istnieje w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałby się PowerPoint.

**Czy mogę dołączyć własne zewnętrzne czcionki w czasie wykonywania, aby uniknąć podmiany?**

Tak. Możesz [dodać zewnętrzne czcionki](/slides/pl/cpp/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, także przy kolejnych konwersjach.

**Czy Aspose dystrybuuje jakieś czcionki wraz z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionki według własnego uznania i odpowiedzialności.

**Czy istnieją różnice w zachowaniu podmiany na systemach Windows, Linux i macOS?**

Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek oraz ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę podmiany.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwaną podmianę podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek pomiędzy maszynami lub kontenerami, [dodaj zewnętrzne czcionki](/slides/pl/cpp/custom-font/) wymagane dla dokumentów wyjściowych oraz [wbuduj czcionki](/slides/pl/cpp/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.