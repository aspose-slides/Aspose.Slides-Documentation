---
title: Pobieranie i aktualizacja informacji o prezentacji w Pythonie
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/python-net/examine-presentation/
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
- Python
- Aspose.Slides
description: "Przeglądaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Pythona, aby szybciej uzyskać wgląd i inteligentniej audytować zawartość."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania pełnego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na API [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/) oraz demonstrują typowe operacje związane z metadanymi prezentacji.

## **Sprawdzanie formatu prezentacji**

Przed rozpoczęciem pracy z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się ona w danej chwili.

Można sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod w języku Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Pobieranie właściwości prezentacji**

Ten kod w języku Python pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/#properties).

## **Aktualizacja właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Original document properties of the PowerPoint presentation](input_properties.png)

Ten przykład kodu pokazuje, jak edytować wybrane właściwości prezentacji:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Wyniki zmiany właściwości dokumentu przedstawiono poniżej.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, przydatne mogą być następujące linki:

- [Sprawdzanie, czy prezentacja jest zaszyfrowana](https://docs.aspose.com/slides/pl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sprawdzanie, czy prezentacja jest zabezpieczona przed zapisem (tylko do odczytu)](https://docs.aspose.com/slides/pl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem](https://docs.aspose.com/slides/pl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potwierdzanie hasła użytego do ochrony prezentacji](https://docs.aspose.com/slides/pl/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj informacji o [embedded-font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek rzeczywiście używanych w treści](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/), aby zidentyfikować krytyczne czcionki dla renderowania.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Przejdź przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) i sprawdź flagę [visibility](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdu oraz czy różnią się od wartości domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slide_size/) i orientację ze standardowymi ustawieniami; pomoże to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejrzyj wszystkie [wykresy](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/), i zanotuj, czy dane są wewnętrzne, czy oparte na łączu, w tym ewentualne uszkodzone linki.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu zlicz liczbę obiektów i zwróć uwagę na duże obrazy, przezroczystość, cienie, animacje oraz multimedia; przydziel przybliżoną punktację złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.