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
- czytanie właściwości
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
description: "Eksploruj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Pythona, aby szybciej uzyskać wgląd i inteligentniej audytować zawartość."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/), i demonstrują typowe operacje związane z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Przed przystąpieniem do pracy z prezentacją, możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i innych) aktualnie znajduje się prezentacja.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod w języku Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Uzyskaj właściwości prezentacji**

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

## **Aktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z poniżej pokazanymi właściwościami dokumentu.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Wyniki zmiany właściwości dokumentu przedstawiono poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, przydatne mogą być następujące linki:

- [Prezentacje zabezpieczone hasłem](/slides/pl/python-net/password-protected-presentation/)
- [Prezentacje zabezpieczone przed zapisem](/slides/pl/python-net/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj informacji o [osadzonych czcionkach](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek rzeczywiście używanych w treści](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/), aby zidentyfikować, które czcionki są kluczowe dla renderowania.

**Jak szybko sprawdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Przejdź iteracyjnie przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) i sprawdź [flagę widoczności](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od domyślnych?**

Tak. Porównaj aktualny [rozmiar slajdu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slide_size/) i orientację ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) i zanotuj, czy dane są wewnętrzne czy połączone poprzez link, włączając wszelkie uszkodzone linki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu policz liczbę obiektów i poszukaj dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.