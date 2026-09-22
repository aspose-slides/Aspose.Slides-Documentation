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
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Pythona, aby szybciej uzyskać wnioski i efektywniej przeprowadzać audyty treści."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba sklasyfikować pliki, utworzyć inwentaryzację lub sprawdzić właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł pokazuje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/), a także ukierunkowane aktualizacje przy użyciu [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Jeśli masz już załadowaną prezentację, zobacz [Określ oryginalny format prezentacji](/slides/pl/python-net/detect-presentation-source-format/) w celu wykrycia po załadowaniu oraz ograniczeń strumieni starszych formatów PPT, PPS i POT.

Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Właściwość [PresentationInfo.load_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/load_format/) zwraca wykryty format, np. PPTX, PPT lub ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Utwórz lekką inwentaryzację prezentacji**

Kiedy przetwarzasz wiele plików prezentacji, możesz potrzebować zwartej inwentaryzacji do weryfikacji, indeksowania lub systemu zarządzania dokumentami. W tym scenariuszu użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) ani nie wymaga przechodzenia przez pełny model obiektowy prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/) zapewniają następujące wartości inwentaryzacji:

| Właściwość | Wartość inwentaryzacji |
| --- | --- |
| [slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/slides/pl/) | Łączna liczba slajdów. |
| [hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/hidden_slides/) | Liczba ukrytych slajdów. |
| [notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/notes/) | Liczba slajdów zawierających notatki. |
| [paragraphs](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/paragraphs/) | Łączna liczba akapitów, jeśli dostępna. |
| [words](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/words/) | Łączna liczba słów. |
| [multimedia_clips](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/multimedia_clips/) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wypisuje zwartą inwentaryzację. Łączy także [heading_pairs](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/heading_pairs/) z [titles_of_parts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/titles_of_parts/), aby wyświetlić grupy treści, takie jak czcionki, motywy i tytuły slajdów.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/python-net/aspose.slides/headingpair/) dostarcza nazwę grupy i liczbę elementów w tej grupie. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/titles_of_parts/) jest płaską, uporządkowaną kolekcją, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy heading pair.

### **Przechowywane metadane i ograniczenia formatu**

Właściwości inwentaryzacyjne zwracane przez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) odzwierciedlają metadane dostępne w dokumencie źródłowym. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane wartościami domyślnymi, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała jego właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowujące dokument. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej przechowywaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólnych statystyk dokumentu, takich jak liczba stron, akapitów i słów, ale te wartości nie mapują się na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacyjne mogą zwracać wartości domyślne. Nie traktuj wartości zero ani pustej kolekcji jako ostatecznego dowodu na brak odpowiadającej treści.

Używaj podejścia opartego na lekkich metadanych przy tworzeniu inwentaryzacji i wstępnych kontroli. Załaduj prezentację i przejrzyj jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy trzeba zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Zastosuj zmiany za pomocą [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/update_document_properties/), a następnie zapisz powiązaną prezentację przy użyciu [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Poniższy obraz pokazuje oryginalne właściwości dokumentu prezentacji PowerPoint.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł i czas ostatniego zapisu oraz zapisuje wynik do nowego pliku:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Poniższy obraz pokazuje zmienione właściwości dokumentu prezentacji PowerPoint.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać informacje o powiązanych kontrolach bezpieczeństwa i ustawieniach ochrony, zobacz następujące artykuły:

- [Zabezpiecz prezentacje hasłem](/slides/pl/python-net/password-protected-presentation/)
- [Zabezpiecz przed zapisem prezentacje](/slides/pl/python-net/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation.fonts_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/). Wywołaj [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) aby uzyskać osadzone czcionki oraz [FontsManager.get_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/) aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko stwierdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/hidden_slides/) przez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) i [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/). To rozwiązanie nadaje się do lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być nieobecne lub nieaktualne, lub jeśli potrzebujesz zweryfikować bieżące wartości, przeiteruj [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) i sprawdź właściwość [Slide.hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru slajdu i orientacji oraz czy różnią się od domyślnych?**

Tak. Załaduj prezentację i odczytaj [Presentation.slide_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slide_size/). Sprawdź [SlideSize.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/size/) i [SlideSize.orientation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/orientation/), aby porównać bieżące ustawienia z oczekiwanymi wartościami domyślnymi i wymiarami.

**Czy istnieje szybki sposób sprawdzenia, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/) i sprawdź [ChartData.data_source_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/). Dla zewnętrznego skoroszytu odczytaj [ChartData.external_workbook_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego pliku wymaga osobnego sprawdzenia zasobów.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie ma jednej właściwości określającej złożoność. Przejdź przez [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) i kolekcję [BaseSlide.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/shapes/) każdego slajdu. Użyj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników, zmierz reprezentatywne renderowanie lub eksport i dopiero wtedy uznaj slajd za potwierdzony wąski gardło wydajności.