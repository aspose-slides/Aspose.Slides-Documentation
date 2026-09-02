---
title: Efektywne scalanie prezentacji w Pythonie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/python-net/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- Python
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Pythonie, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar treści slajdów, zachowując sekcje oraz obsługując pliki zabezpieczone lub duże."
---
## **Przegląd**

Aspose.Slides for Python via .NET scala prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) do drugiej. Główna operacja to [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scalenie wszystkich slajdów przy zachowaniu ich formatowania źródłowego;
- scalenie wybranych slajdów;
- zastosowanie mastera z prezentacji docelowej;
- zastosowanie konkretnego układu z prezentacji docelowej;
- normalizacja różnych rozmiarów slajdów przed scalam;
- dodanie sklonowanych slajdów do sekcji;
- scalenie kilku prezentacji w jednym kompleksowym przepływie pracy;
- obsługa masterów, zasobów, notatek, komentarzy, multimediów, czcionek, haseł, dużych plików i zagadnień związanych z wielowątkowością.

## **Jak Klonowanie Slajdów Wpływa na Mastery i Układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony metodę klonowania określa, w jaki sposób scalony slajd zostanie wstawiony do prezentacji docelowej.

Użyj [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) w jednej z następujących postaci:

- `add_clone(source_slide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, więc powtarzające się slajdy korzystające z tego samego mastera źródłowego nie powodują wielokrotnego klonowania tego mastera.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — dołącza sklonowany slajd do konkretnego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `add_clone(source_slide, destination_layout)` — dołącza sklonowany slajd bezpośrednio do konkretnego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `add_clone` musi należeć do **docelowej** prezentacji, a nie do prezentacji źródłowej.

## **Scalanie Pełnych Prezentacji i Zachowanie Formatowania Źródłowego**

Najprostsze scalenie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. Jest to właściwy wybór, gdy importowane slajdy mają zachować pierwotny motyw, master i zależności układów.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Wynikowa prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest celowo zachowywane.

## **Scalanie Wybranych Slajdów**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Sprawdzaj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scalanie Slajdów przy użyciu Mastera Docelowego**

Użyj przeciążenia [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) gdy importowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje pasujący układ i `allow_clone_missing_layout` jest `True`, układ źródłowy zostaje sklonowany, aby slajd mógł zostać dodany. Jeśli jest `False`, zostaje wyrzucony [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/).

Użyj `False`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scalanie Slajdów przy użyciu Konkretnego Układu Docelowego**

Użyj przeciążenia [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) gdy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Zastosowanie układu docelowego zmienia odziedziczoną relację układu; nie przekształca zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów jest właściwe.

## **Scalanie Prezentacji o Różnych Rozmiarach Slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przerysowuje automatycznie jego zawartości pod nowym płótnem. Kształty mogą więc wyglądać na przesunięte, przeskalowane nieoczekiwanie lub znajdować się poza widocznym obszarem slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.set_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/set_size/) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/) skaluje zawartość, aby pasowała do żądanego rozmiaru.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz pozostawić oryginalną prezentację źródłową niezmienioną dla innych operacji, otwórz osobną instancję dla scalenia.

## **Scalanie Slajdów do Sekcji Prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i jawnie klonuj slajdy do nich przy użyciu [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, przeiteruj [Presentation.sections](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sections/), pobierz bieżące slajdy każdej sekcji źródłowej przy pomocy [Section.get_slides_list_of_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/get_slides_list_of_section/), odtwórz sekcje w docelowej prezentacji i sklonuj każdy zwrócony slajd do odpowiadającej sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/python-net/slide-section/) po kompletny przykład enumeracji sekcji, w tym sekcje puste i zmiany strukturalne.

## **Bezpieczne Scalanie Wielu Prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej prezentacji źródłowej, trzyma każdą prezentację otwartą tylko podczas kopiowania i zapisuje ostateczny plik jednorazowo.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Jest to przydatna podstawa do zachowania formatowania źródłowego importowanych slajdów. Jeśli Twój wynik musi używać jednego motywu docelowego, zastąp proste wywołanie `add_clone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego pokazanym wcześniej.

## **Praktyczne Rozważania**

### **Mastery, Układy i Wierność Formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebna jest explicite kontrola nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny musi kontrolować ostateczny wygląd, wybierz explicitnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i Komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane podczas klonowania slajdu. Aspose.Slides udostępnia również dedykowane API dla [presentation notes](/slides/pl/python-net/presentation-notes/) i [presentation comments](/slides/pl/python-net/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą różnić się między plikami źródłowymi. W przepływach recenzji sprawdzaj także autorów komentarzy i wątki komentarzy po łączeniu plików od różnych autorów lub szablonów.

### **Obrazy, Dźwięk, Wideo, Obiekty OLE i Linki Zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, wideo oraz dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować zależności slajdu do jego zasobów.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowane audio, wideo, obiekt OLE lub hiperłącze pozostaje zależne od zewnętrznego docelowego zasobu; klonowanie slajdu nie przekształca linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne pliki binarne z niepowiązanych prezentacji będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone Czcionki i Dostępność Czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność wszystkich potrzebnych czcionek w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) i zarządzać osadzaniem explicite, jak opisano w [Embed Fonts in Presentations](/slides/pl/python-net/embedded-font/).

Również sprawdź, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje Zabezpieczone Hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Przekaż hasło przez [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Otworzenie zaszyfrowanego źródła nie nakłada automatycznie tego samego zabezpieczenia na prezentację docelową. Skonfiguruj ochronę wyjściową oddzielnie, gdy jest wymagana.

### **Duże Prezentacje i Zużycie Pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą pochłaniać znaczną ilość pamięci. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/blob_management_options/) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/python-net/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, zamykaj każdą prezentację źródłową natychmiast po scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych. Użycie `with slides.Presentation(...)` zapewnia zwolnienie zasobów prezentacji po wyjściu z kontekstu.

### **Bezpieczeństwo Wątkowe**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) jednocześnie w wielu wątkach. Trzymaj każdą operację scalenia w jednym wątku. Jeśli równolegle przetwarzasz niezależne zadania scalenia, użyj oddzielnych jednowątkowych procesów i niezależnych instancji prezentacji, jak opisano w [Aspose.Slides multithreading guidance](/slides/pl/python-net/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest wymagany przez importowany slajd.

**Jak sprawić, by importowane slajdy korzystały z motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów mogą być scalane?**

Tak, ale zawartość slajdu nie jest automatycznie przerysowywana do wymiarów docelowych. Zmierz najpierw rozmiar prezentacji źródłowej, na przykład przy pomocy [SlideSize.set_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/set_size/) i [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/).

**Czy mogę scalić prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz docelowy plik w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie wspierają dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scaleniach międzypformatowych. Zobacz [Supported File Formats](/slides/pl/python-net/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, w podstawowej pętli, która tylko klonuje slajdy, nie są. Utwórz wymagane sekcje w docelowej prezentacji i użyj przeciążenia sekcji w [add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Tak, są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylu mastera notatek, autorów komentarzy lub danych recenzji wątkowych, zweryfikuj scalony wynik, ponieważ te scenariusze obejmują zarówno struktury na poziomie prezentacji, jak i treść slajdu.

**Co się dzieje z dźwiękiem, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część zależności zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Sprawdź osadzone czcionki w dokumencie docelowym i explicite zarządzaj osadzaniem czcionek lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik chroniony hasłem?**

Otwórz go przy użyciu poprawnego [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/), a następnie normalnie sklonuj jego slajdy. Ochrona wyjściowa jest konfigurowana osobno.

**Jak obsługiwać bardzo duże prezentacje?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, zamykaj prezentacje źródłowe niezwłocznie po ich scaleniu i zapisuj ostateczny wynik tylko wtedy, gdy jest to potrzebne.

**Czy mogę scalić slajdy z wielu wątków?**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) w wielu wątkach jednocześnie. Trzymaj każdą operację scalenia w jednym wątku; użyj oddzielnych jednowątkowych procesów, jeśli musisz równolegle przetwarzać osobne zadania scalenia.