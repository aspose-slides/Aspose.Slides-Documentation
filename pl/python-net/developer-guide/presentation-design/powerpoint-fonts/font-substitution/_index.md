---
title: "Konfiguracja zastępowania czcionek w prezentacjach przy użyciu Pythona"
linktitle: "Zastępowanie czcionek"
type: docs
weight: 70
url: /pl/python-net/font-substitution/
keywords:
- czcionka
- zastąpienie czcionki
- zastąpianie czcionek
- zamiana czcionki
- zastąpienie czcionki
- reguła zastąpienia
- reguła zamiany
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Umożliw optymalne zastępowanie czcionek w Aspose.Slides dla Pythona za pośrednictwem .NET przy konwertowaniu prezentacji PowerPoint i OpenDocument na inne formaty plików."
---
## **Przegląd**

Zastępowanie czcionek pozwala Aspose.Slides używać innej czcionki, gdy oryginalna czcionka prezentacji nie jest dostępna podczas renderowania lub konwersji. Możesz sprawdzić, które czcionki zostały zastąpione, używając metody `get_substitutions` z klasy `FontsManager`.

Aspose.Slides umożliwia również definiowanie reguł zastępowania czcionek. Na przykład możesz określić, że niedostępna czcionka powinna zostać zamieniona na inną dostępną czcionkę i zastosować te reguły poprzez menedżer czcionek prezentacji.

## **Ustaw reguły zastępowania**

Aspose.Slides pozwala ustawić reguły dla czcionek, które określają, co należy zrobić w określonych warunkach (na przykład gdy czcionka nie jest dostępna) w następujący sposób:

1. Załaduj odpowiednią prezentację.  
2. Załaduj czcionkę, która ma zostać zastąpiona.  
3. Załaduj nową czcionkę.  
4. Dodaj regułę zastąpienia.  
5. Dodaj regułę do kolekcji reguł zastępowania czcionek prezentacji.  
6. Wygeneruj obraz slajdu, aby zaobserwować efekt.

Ten kod w języku Python demonstruje proces zastępowania czcionek:

```python
import aspose.slides as slides

# Ładuje prezentację
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Ładuje źródłową czcionkę, która ma zostać zastąpiona
    sourceFont = slides.FontData("SomeRareFont")

    # Wczytuje nową czcionkę
    destFont = slides.FontData("Arial")

    # Dodaje regułę czcionki dla zamiany czcionki
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Dodaje regułę do kolekcji reguł zastępowania czcionek
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Dodaje kolekcję reguł czcionki do listy reguł
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy ta ostatnia jest niedostępna
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Zapisuje obraz na dysku w formacie JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 

Możesz chcieć zobaczyć [**Font Replacement**](/slides/pl/python-net/font-replacement/). 

{{% /alert %}}

## **Ograniczenia dla czcionek równań matematycznych**

Reguły zastępowania czcionek uczestniczą w standardowym procesie wyboru czcionki używanym podczas renderowania i konwersji. Są odpowiednie dla typowych scenariuszy tekstowych, w których Aspose.Slides może zamienić niedostępną czcionkę na inną dostępną czcionkę zgodnie z skonfigurowaną regułą.

Jednak równania matematyczne w Office mają istotne ograniczenie. Jeśli równanie zostało utworzone przy użyciu **Cambria Math**, Aspose.Slides może nadal wymagać oryginalnej czcionki **Cambria Math**, aby poprawnie obliczyć i wyrenderować układ równania. Z tego powodu zastąpienie **Cambria Math** inną czcionką matematyczną, taką jak **STIX Two Math**, nie jest obsługiwane przy renderowaniu równań i może nadal skutkować wyjątkiem wskazującym, że wymagana jest **Cambria Math**.

Aby pomyślnie konwertować takie prezentacje, upewnij się, że **Cambria Math** jest dostępna dla Aspose.Slides w czasie wykonywania. Możesz zainstalować czcionkę w systemie operacyjnym lub udostępnić ją jako [external font](/slides/pl/python-net/custom-font/), aby mogła uczestniczyć w normalnym procesie wyboru czcionki podczas renderowania i konwersji.

To ograniczenie dotyczy wyłącznie renderowania równań. Standardowe reguły zastępowania czcionek opisane powyżej nadal obowiązują dla zwykłego tekstu prezentacji, gdy oryginalna czcionka jest niedostępna.

## **FAQ**

**Jaka jest różnica między zamianą czcionki a jej zastępowaniem?**

[Replacement](/slides/pl/python-net/font-replacement/) to wymuszone nadpisanie jednej czcionki drugą w całej prezentacji. Zastępowanie to reguła, która uruchamia się w określonym warunku, na przykład gdy oryginalna czcionka jest niedostępna, i wtedy używana jest wyznaczona czcionka zapasowa.

**Kiedy dokładnie stosowane są reguły zastępowania?**

Reguły uczestniczą w standardowej sekwencji [font selection](/slides/pl/python-net/font-selection-sequence/), która jest oceniana podczas ładowania, renderowania i konwersji; jeśli wybrana czcionka jest niedostępna, stosowane jest zastąpienie lub podmiana.

**Jakie jest domyślne zachowanie, jeśli nie skonfigurowano ani zamiany, ani zastąpienia, a czcionka brakuję w systemie?**

Biblioteka spróbuje wybrać najbliższą dostępną czcionkę systemową, podobnie jak zachowałoby się PowerPoint.

**Czy mogę dołączyć własne czcionki zewnętrzne w czasie wykonywania, aby uniknąć zastąpienia?**

Tak. Możesz [add external fonts](/slides/pl/python-net/custom-font/) w czasie wykonywania, aby biblioteka brała je pod uwagę przy wyborze i renderowaniu, w tym przy późniejszych konwersjach.

**Czy Aspose dystrybuuje jakieś czcionki z biblioteką?**

Nie. Aspose nie dystrybuuje płatnych ani darmowych czcionek; dodajesz i używasz czcionki na własną odpowiedzialność i według własnego uznania.

**Czy istnieją różnice w zachowaniu zastępowania na Windows, Linux i macOS?**

Tak. Wykrywanie czcionek rozpoczyna się od katalogów czcionek systemu operacyjnego. Zestaw domyślnie dostępnych czcionek i ścieżki wyszukiwania różnią się w zależności od platformy, co wpływa na dostępność i potrzebę zastępowania.

**Jak przygotować środowisko, aby zminimalizować nieoczekiwane zastąpienia podczas konwersji wsadowych?**

Zsynchronizuj zestaw czcionek między maszynami lub kontenerami, [add the external fonts](/slides/pl/python-net/custom-font/) wymagane dla dokumentów wyjściowych oraz [embed fonts](/slides/pl/python-net/embedded-font/) w prezentacjach, gdy to możliwe, aby wybrane czcionki były dostępne podczas renderowania.