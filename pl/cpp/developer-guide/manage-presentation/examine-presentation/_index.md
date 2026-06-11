---
title: Pobieranie i aktualizacja informacji o prezentacji w C++
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/cpp/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczytywanie właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- analizowanie PPTX
- analizowanie PPT
- analizowanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Przeglądaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu C++ dla szybszych wglądów i inteligentnych audytów treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu i zaktualizować je w razie potrzeby.

Przykłady oparte są na API [PresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/documentproperties/) oraz demonstrują typowe operacje związane z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Zanim rozpoczniesz pracę nad prezentacją, możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się prezentacja w danym momencie.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz poniższy kod C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Pobierz właściwości prezentacji**

Ten kod C++ pokazuje, jak pobrać właściwości prezentacji (informacje o prezentacji):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationinfo/updatedocumentproperties/), która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu są pokazane poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, przydatne mogą być następujące linki:

- [Sprawdzanie, czy prezentacja jest zaszyfrowana](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sprawdzanie, czy prezentacja jest chroniona przed zapisem (tylko do odczytu)](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potwierdzanie hasła użytego do ochrony prezentacji](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj [informacji o osadzonych czcionkach](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getfonts/), aby zidentyfikować, które czcionki są kluczowe dla renderowania.

**Jak szybko określić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/) i sprawdzaj [flagi widoczności](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/get_hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdów oraz czy różnią się od domyślnych?**

Tak. Porównaj bieżący [rozmiar i orientację slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slidesize/) ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby zobaczyć, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejrzyj wszystkie [wykresy](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) i zanotuj, czy dane są wewnętrzne, czy oparte na linkach, w tym ewentualne uszkodzone linki.

**Jak ocenić „ciężkie” slajdy, które mogą spowolnić renderowanie lub eksport do PDF?**

Dla każdego slajdu policz liczbę obiektów i poszukaj dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.