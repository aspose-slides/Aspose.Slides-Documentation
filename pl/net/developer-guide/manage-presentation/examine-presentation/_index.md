---
title: Pobieranie i aktualizacja informacji o prezentacji w .NET
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/net/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczyt właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu .NET, aby szybciej uzyskać informacje i przeprowadzić inteligentne audyty treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez wczytywania całego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/), i demonstrują typowe operacje pracy z metadanymi prezentacji.

## **Sprawdzenie formatu prezentacji**

Przed rozpoczęciem pracy z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się obecnie prezentacja.

Możesz sprawdzić format prezentacji bez jej wczytywania. Zobacz ten kod C#:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Pobieranie właściwości prezentacji**

Ten kod C# pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/#properties).

## **Aktualizacja właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), która pozwala wprowadzać zmiany we właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu są pokazane poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach zabezpieczeń, możesz uznać te linki za przydatne:

- [Zabezpiecz prezentacje hasłem](/slides/pl/net/password-protected-presentation/)
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/net/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są czcionki?**

Poszukaj informacji o [osadzonych czcionkach](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek rzeczywiście używanych w treści](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getfonts/), aby określić, które czcionki są kluczowe dla renderowania.

**Jak szybko sprawdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/) i sprawdź [flagę widoczności](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od wartości domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slidesize/) i orientację ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/datasourcetype/) i zanotuj, czy dane są wewnętrzne czy połączone poprzez link, uwzględniając ewentualne uszkodzone linki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu zlicz liczbę obiektów i sprawdź, czy występują duże obrazy, przezroczystość, cienie, animacje oraz multimedia; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.