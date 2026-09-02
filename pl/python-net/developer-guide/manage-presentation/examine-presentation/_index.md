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
- odczytywanie właściwości
- zmiana właściwości
- modyfikowanie właściwości
- aktualizacja właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Eksploruj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Pythona, aby uzyskać szybsze wnioski i bardziej inteligentne kontrole treści."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, budować inwentarz lub sprawdzać właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/), a także celowe aktualizacje przy użyciu [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) , aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Właściwość [PresentationInfo.load_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/load_format/) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Zbuduj lekki inwentarz prezentacji**

Podczas przetwarzania wielu plików prezentacji może być potrzebny kompaktowy inwentarz do walidacji, indeksacji lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) , aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) , aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/) dostarczają następujące wartości inwentarza:

| Właściwość | Wartość inwentarzu |
| --- | --- |
| [slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/slides/pl/) | Całkowita liczba slajdów. |
| [hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/hidden_slides/) | Liczba ukrytych slajdów. |
| [notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/notes/) | Liczba slajdów zawierających notatki. |
| [paragraphs](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/paragraphs/) | Całkowita liczba akapitów, gdy dostępna. |
| [words](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/words/) | Całkowita liczba słów. |
| [multimedia_clips](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/multimedia_clips/) | Całkowita liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wypisuje kompaktowy inwentarz. Łączy także [heading_pairs](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/heading_pairs/) z [titles_of_parts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/titles_of_parts/), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

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

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/python-net/aspose.slides/headingpair/) dostarcza nazwę grupy oraz liczbę elementów w tej grupie. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/titles_of_parts/) jest płaską, uporządkowaną kolekcją, więc pobierz liczbę kolejnych tytułów określoną przez każdą parę nagłówkową.

### **Zapisane metadane i ograniczenia formatu**

Właściwości inwentarza zwracane przez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane przez wartości domyślne, a zapisane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała swoich właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej zapisaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentarza mogą zwracać wartości domyślne. Nie traktuj zera ani pustej kolekcji jako ostatecznego dowodu, że odpowiadająca zawartość jest nieobecna.

Używaj lekkiego podejścia do metadanych przy tworzeniu inwentarzy i wstępnych kontroli. Ładuj prezentację i przeglądaj jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy trzeba zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Zastosuj zmiany za pomocą [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/update_document_properties/) i następnie zapisz powiązaną prezentację przy użyciu [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Poniższy obrazek przedstawia oryginalne właściwości dokumentu.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł oraz czas ostatniego zapisu i zapisuje wynik do nowego pliku:

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

Poniższy obrazek przedstawia zmienione właściwości dokumentu.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Po więcej informacji o sprawdzaniu bezpieczeństwa i ustawieniach ochrony, zobacz następujące artykuły:

- [Prezentacje zabezpieczone hasłem](/slides/pl/python-net/password-protected-presentation/)
- [Prezentacje zabezpieczone przed zapisem](/slides/pl/python-net/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation.fonts_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/). Wywołaj [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) , aby uzyskać osadzone czcionki oraz [FontsManager.get_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/) , aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy zapisane metadane dokumentu są wystarczające, odczytaj [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/hidden_slides/) poprzez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) i [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/). To podejście nadaje się do lekkiego inwentarza. Jeśli prezentacja została zmodyfikowana w pamięci, zapisane metadane mogą być niekompletne lub nieaktualne, lub gdy trzeba zweryfikować wartości w czasie rzeczywistym, przeiteruj [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) i sprawdź właściwość [Slide.hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru slajdu i orientacji, oraz czy różnią się od wartości domyślnych?**

Tak. Załaduj prezentację i odczytaj [Presentation.slide_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slide_size/). Sprawdź [SlideSize.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/size/) i [SlideSize.orientation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/orientation/), aby porównać bieżące ustawienia z oczekiwanymi presetami i wymiarami.

**Czy istnieje szybki sposób, aby zobaczyć, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/) i sprawdź [ChartData.data_source_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/). Dla zewnętrznego skoroszytu odczytaj [ChartData.external_workbook_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego zasobu wymaga osobnego sprawdzenia.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość określająca złożoność. Przejdź przez [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) i kolekcję [BaseSlide.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/shapes/) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników, a także zmierz reprezentatywne renderowanie lub eksport przed uznaniem slajdu za potwierdzony wąskie gardło wydajności.