---
title: Efektywne scalanie prezentacji w Pythonie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/python-net/merge-presentation/
keywords:
- scala PowerPoint
- scala prezentacje
- scala slajdy
- scala PPT
- scala PPTX
- scala ODP
- łączenie PowerPoint
- łączenie prezentacji
- łączenie slajdów
- łączenie PPT
- łączenie PPTX
- łączenie ODP
- Python
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Pythonie, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar treści slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for Python via .NET łączy prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/), która może zachować formatowanie slajdu źródłowego lub dołączyć sklonowany slajd do mastera lub układu w docelowej prezentacji.

Ten artykuł opisuje najczęstsze scenariusze łączenia:

- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj konkretny układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scalaniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym, kompleksowym przepływie pracy;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki oraz zagadnienia związane z wielowątkowością.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy znaczną część swojego wyglądu z układu i mastera. Z tego powodu wybrana przez Ciebie przeciążona metoda klonowania decyduje, jak scalony slajd zostanie zintegrowany w prezentacji docelowej.

Użyj [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) w jednej z następujących wersji:

- `add_clone(source_slide)` — zachowuje układ i formatowanie slajdu źródłowego. W razie potrzeby master źródłowy może być automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie klonowane mastery, więc powtarzające się slajdy używające tego samego mastera nie powodują wielokrotnego klonowania tego mastera.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — dołącza sklonowany slajd do konkretnego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu układu lub nazwy.
- `add_clone(source_slide, destination_layout)` — dołącza sklonowany slajd bezpośrednio do konkretnego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `add_clone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródła**

Najprostsze scalenie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. To właściwy wybór, gdy importowane slajdy powinny zachować oryginalny motyw, master i zależności układów.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Powstała prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, kiedy formatowanie źródła jest celowo zachowywane.

## **Scal wybrane slajdy**

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

Sprawdź indeksy slajdów przed klonowaniem, gdy pochodzą od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy używając mastera docelowego**

Użyj przeciążenia [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) kiedy importowane slajdy mają podążać za masterem, który już należy do prezentacji docelowej.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allow_clone_missing_layout` jest `True`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli jest `False`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/).

Użyj `False`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy używając konkretnego układu docelowego**

Użyj przeciążenia [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) kiedy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Zastosowanie układu docelowego zmienia odziedziczoną relację układu; nie przekształca treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przekształca automatycznie jego zawartości do nowego płótna. Kształty mogą więc wyglądać na przesunięte, nieoczekiwanie skalowane lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.set_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/set_size/) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/) skaluje zawartość, aby zmieściła się w żądanym rozmiarze.

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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej wersji źródła do innych operacji, otwórz osobną instancję w celu scalenia.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje są istotne w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich jawnie przy pomocy [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz je w destynacji przy użyciu [SectionCollection.append_empty_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/append_empty_section/) i przypisz każdy slajd źródłowy do odpowiadającej sekcji docelowej.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego kolejnego źródła, utrzymuje każde źródło otwarte tylko podczas kopiowania i zapisuje końcowy plik jednorazowo.

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

Jest to przydatna podstawa do zachowania formatowania źródłowego importowanych slajdów. Jeśli wynik ma używać jednego tematu docelowego, zamień prostą wywołanie `add_clone(slide)` na odpowiednie przeciążenie mastera lub układu docelowego, pokazane wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie wprowadzić wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebna jest jawna kontrola nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli korporacyjny szablon ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/python-net/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/python-net/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, zweryfikuj scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W przepływach recenzji sprawdzaj również autorów komentarzy i wątki komentarzy po łączeniu plików od różnych autorów lub szablonów.

### **Obrazy, dźwięk, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzony dźwięk, osadzone wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować powiązania slajdu z jego zasobami.

Osadzone i linkowane zasoby należy traktować odmiennie. Linkowany dźwięk, wideo, obiekt OLE lub hiperlink pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji będą zawsze deduplifikowane. Jeśli rozmiar pliku wyjściowego jest istotny, zbadaj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi być spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów gwarantuje dostępność każdej wymaganej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) i zarządzać osadzaniem explicitnie, jak opisano w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/python-net/embedded-font/).

Sprawdź także, czy masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać możliwość osadzania.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać otwarte pomyślnie, zanim jego slajdy będą mogły być klonowane. Podaj hasło poprzez [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie tego samego zabezpieczenia na prezentację docelową. Ochronę wyjściową skonfiguruj oddzielnie, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, dźwięk, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/blob_management_options/) oferuje kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/python-net/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, zamykaj każdą prezentację źródłową natychmiast po scalceniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych. Użycie `with slides.Presentation(...)` zapewnia zwolnienie zasobów prezentacji po zakończeniu bloku.

### **Bezpieczeństwo wątków**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) jednocześnie z wielu wątków. Każdą operację scalenia wykonuj jednowątkowo. Jeśli równolegle przetwarzasz niezależne zadania scalania, używaj oddzielnych jednowątkowych procesów i niezależnych instancji prezentacji, jak opisano w [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/python-net/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [`add_clone(source_slide)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny importowanemu slajdowi.

**Jak sprawić, by importowane slajdy używały motywu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy powinienem użyć konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego, znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał odpowiedni układ spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przekształcana do wymiarów docelowych. Zmniejsz rozmiar prezentacji źródłowej najpierw, np. przy pomocy [SlideSize.set_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/set_size/) i [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jedną prezentację?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz wynik w obsługiwanym formacie. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scalceniu międzyformatowym. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/python-net/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie w podstawowej pętli, która tylko klonuje slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub wątków recenzji sprawdź wynik, ponieważ scenariusze te obejmują także struktury na poziomie prezentacji.

**Co się dzieje z dźwiękiem, wideo, obiektami OLE i hiperłączami?**

Treść osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być nadal dostępne po scalceniu.

**Czy osadzone czcionki ze wszystkich źródeł są zagwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Zbadaj osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go z odpowiednim [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/), a następnie klonuj slajdy jak zwykle. Ochronę wyjściową konfiguruje się osobno.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, zamykaj prezentacje źródłowe niezwłocznie po scalceniu i zapisuj finalny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) w wielu wątkach. Trzymaj każdą operację scalenia w jednym wątku; używaj niezależnych jednowątkowych procesów, jeśli potrzebujesz równolegle wykonywać oddzielne zadania scalania.