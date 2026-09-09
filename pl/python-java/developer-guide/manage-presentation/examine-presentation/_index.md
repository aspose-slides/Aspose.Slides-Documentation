---
title: Pobieranie i aktualizacja informacji o prezentacji w Pythonie przy użyciu Javy
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/python-java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobierz właściwości
- odczytaj właściwości
- zmień właściwości
- modyfikuj właściwości
- zaktualizuj właściwości
- badanie PPTX
- badanie PPT
- badanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument, korzystając z Pythona poprzez Javę, aby szybciej uzyskać wnioski i inteligentniej audytować zawartość."
---
## **Przegląd**

Aspose.Slides może zidentyfikować format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba sklasyfikować pliki, utworzyć inwentaryzację lub sprawdzić właściwości przed podjęciem decyzji o wczytaniu i przetworzeniu zawartości prezentacji.

Przykłady wymagają Aspose.Slides for Python via Java oraz kompatybilnego środowiska uruchomieniowego Java. Każdy przykład uruchamia JVM, jeśli nie jest już uruchomiona. Dostarcz istniejące pliki prezentacji w ścieżkach używanych w przykładach.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/), a także ukierunkowane aktualizacje przy użyciu [DocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo), aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#getLoadFormat) zgłasza wykryty format, taki jak PPTX, PPT lub ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Zbuduj lekką inwentaryzację prezentacji**

Podczas przetwarzania wielu plików prezentacji może być potrzebna kompaktowa inwentaryzacja w celu walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/) dostarczają następujących wartości inwentaryzacyjnych:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getSlides) | Łączna liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getNotes) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getParagraphs) | Łączna liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getWords) | Łączna liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation] i wypisuje kompaktową inwentaryzację. Łączy również [getHeadingPairs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getHeadingPairs) z [getTitlesOfParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getTitlesOfParts), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/python-java/aspose.slides/headingpair/) dostarcza nazwę grupy i liczbę elementów w tej grupie. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getTitlesOfParts) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy heading pair.

### **Zapisane metadane i ograniczenia formatu**

Właściwości inwentaryzacyjne zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są przedstawiane jako wartości domyślne, a zapisane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała swoich właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także dla par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez autora dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez autora dokumentu, Aspose.Slides zwraca jej zapisaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują się na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacyjne mogą zwracać wartości domyślne. Nie traktuj zerowej wartości ani pustej tablicy jako ostatecznego dowodu na brak odpowiadającej zawartości.

Użyj podejścia opartego na lekkich metadanych do inwentaryzacji i wstępnych kontroli. Wczytaj prezentację i sprawdź jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy potrzebujesz zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) mogą być również zmienione bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Zastosuj zmiany przy użyciu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), a następnie zapisz powiązaną prezentację przy użyciu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Poniższy obrazek pokazuje oryginalne właściwości dokumentu.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł oraz czas ostatniego zapisu i zapisuje wynik do nowego pliku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Poniższy obrazek pokazuje zaktualizowane właściwości dokumentu.

![Zaktualizowane właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

W celu uzyskania informacji o powiązanych kontrolach bezpieczeństwa i ustawieniach ochrony, zobacz następujące artykuły:

- [Prezentacje zabezpieczone hasłem](/slides/pl/python-java/password-protected-presentation/)
- [Prezentacje zabezpieczone przed zapisem](/slides/pl/python-java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i jakie to są czcionki?**

Wczytaj prezentację i użyj [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getFontsManager). Wywołaj [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts), aby uzyskać osadzone czcionki oraz [FontsManager.getFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFonts), aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko stwierdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy zapisane metadane dokumentu są wystarczające, odczytaj [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getHiddenSlides) poprzez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) i [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties). To rozwiązanie jest odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, zapisane metadane mogą być niekompletne lub nieaktualne, lub gdy trzeba zweryfikować bieżące wartości, przeiteruj [Presentation.getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) i sprawdź metodę [Slide.getHidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getHidden) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru slajdu i orientacji oraz czy różnią się od domyślnych?**

Tak. Wczytaj prezentację i wywołaj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlideSize). Użyj [SlideSize.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#getSize) oraz [SlideSize.getOrientation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#getOrientation), aby porównać bieżące ustawienia z oczekiwanymi presetami i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/) i wywołaj [ChartData.getDataSourceType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getDataSourceType). Dla zewnętrznego skoroszytu wywołaj [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego zasobu wymaga osobnej kontroli.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość określająca złożoność. Przejrzyj [Presentation.getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) oraz kolekcję [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getShapes) każdego slajdu. Zwróć uwagę na liczbę kształtów oraz obecność dużych obrazów, efektów, animacji lub multimediów jako sygnały ostrzegawcze, i zmierz reprezentacyjne renderowanie lub eksport przed uznaniem slajdu za potwierdzony wąskie gardło wydajności.