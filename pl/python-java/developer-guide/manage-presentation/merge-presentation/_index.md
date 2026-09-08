---
title: Efektywne scalanie prezentacji w Pythonie przy użyciu Java
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/python-java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Pythonie za pomocą Java, kopiując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for Python via Java scala prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym pełnym przepływie pracy;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony metodę klonowania decyduje, jak scalony slajd zostanie wstawiony do prezentacji docelowej.

Użyj [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) w jeden z następujących sposobów:

- `addClone(source_slide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, więc powtarzające się slajdy korzystające z tego samego źródłowego mastera nie powodują wielokrotnego klonowania tego mastera.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — dołącza sklonowany slajd do określonego docelowego [MasterSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/). Aspose.Slides wyszukuje pasujący układ pod tym masterem na podstawie typu układu lub nazwy.
- `addClone(source_slide, destination_layout)` — dołącza sklonowany slajd bezpośrednio do określonego docelowego [LayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do prezentacji **docelowej**, a nie źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródłowe**

Najprostsze scalenie kopiuje każdy slajd ze źródłowej prezentacji do prezentacji docelowej. Jest to odpowiedni wybór, gdy zaimportowane slajdy mają zachować oryginalny motyw, master i zależności układu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Wynikowa prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest zachowywane zamierzenie.

## **Scal wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Sprawdź poprawność indeksów slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy używając mastera docelowego**

Użyj przeciążenia [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy zaimportowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides wybiera odpowiedni układ pod podanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allow_clone_missing_layout` ma wartość `True`, układ źródłowy jest klonowany, aby można było dodać slajd. Jeśli ma wartość `False`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/).

Ustaw `False`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy używając określonego układu docelowego**

Użyj przeciążenia [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy dokładnie znasz, którego układu docelowego mają używać zaimportowane slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przetwarza treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że dziedziczone formatowanie i zachowanie placeholderów są właściwe.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przetwarza automatycznie jego treści do nowego obszaru. Kształty mogą więc wyglądać jakby były przesunięte, skalowane nieoczekiwanie lub znajdowały się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setSize) może skalować istniejącą treść przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/) skaluje treść tak, aby pasowała do żądanego rozmiaru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej oryginalnej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalenia.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich jawnie przy użyciu [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Sklonowane slajdy są dodawane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wyenumeruj [Presentation.getSections](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSections), pobierz aktualne slajdy każdej sekcji źródłowej za pomocą [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection), odtwórz sekcje w prezentacji docelowej i sklonuj każdy zwrócony slajd do odpowiadającej mu sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/python-java/slide-section/) po kompletny przykład enumeracji sekcji, w tym puste sekcje i zmiany strukturalne.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład od początku do końca używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego kolejnego źródła, utrzymuje każde źródło otwarte tylko podczas kopiowania i zapisuje finalny plik raz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

Jest to przydatna baza do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wynik musi używać jednego tematu docelowego, zastąp prostą wywołanie `addClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego pokazanym wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o takiej samej nazwie są wizualnie równe. Jeśli szablon korporacyjny musi kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdu są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia również dedykowane API dla [presentation notes](/slides/pl/python-java/presentation-notes/) i [presentation comments](/slides/pl/python-java/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W procesach przeglądu sprawdź także autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj sam slajd zamiast kopiować tylko widoczne kształty, aby Aspose.Slides mógł utrzymać powiązania slajdu z jego zasobami.

Osadzone i powiązane zasoby powinny być traktowane odrębnie. Powiązany audio, wideo, obiekt OLE lub hiperlink pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL powiązanych zasobów w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niezależnych prezentacji źródłowych zawsze będą deduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, sprawdź scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych komputerach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność każdej wymaganej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki za pomocą [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) i zarządzać osadzaniem w sposób explicite, jak opisano w [Embed Fonts in Presentations](/slides/pl/python-java/embedded-font/).

Sprawdź także, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło przez [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Pracuj z odszyfrowaną prezentacją.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie takiej samej ochrony na prezentację docelową. Skonfiguruj ochronę wyjściową osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) oferuje kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/python-java/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików, gdy to możliwe, wczytuj z ścieżek do plików, zwalniaj każdą prezentację źródłową natychmiast po scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ pracy wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie wczytuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w ramach jednej operacji scalenia. Jeśli równolegle przetwarzasz niezależne zadania, używaj oddzielnych instancji prezentacji i stosuj się do [Aspose.Slides multithreading guidance](/slides/pl/python-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny zaimportowanemu slajdowi.

**Jak sprawić, aby zaimportowane slajdy używały tematu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje przyporządkować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy powinienem używać określonego układu docelowego zamiast mastera docelowego?**

Użyj określonego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów mogą być scalane?**

Tak, ale treść slajdu nie jest automatycznie przearanżowywana do wymiarów docelowych. Zmien rozmiar prezentacji źródłowej najpierw, gdy potrzebne jest przewidywalne rozmieszczenie, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setSize) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalić prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, sprawdź złożoną treść po scalaniu międzyformatowym. Zobacz [Supported File Formats](/slides/pl/python-java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli, która jedynie klonuje slajdy. Odtwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane razem ze sklonowanym slajdem. W przepływach pracy zależnych od stylizacji mastera notatek, autorów komentarzy lub danych przeglądu wątkowego, zweryfikuj wynik scalania, ponieważ scenariusze te obejmują zarówno struktury na poziomie prezentacji, jak i treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Treść osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w zakresie wdrażania czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go za pomocą właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword), a następnie klonuj jego slajdy standardowo. Ochrona wyjściowa jest konfigurowana osobno.

**Jak obsługiwać bardzo duże prezentacje?**

Użyj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują w zużyciu pamięci, preferuj wczytywanie z ścieżek plików przy bardzo dużych plikach, szybko zwalniaj prezentacje źródłowe i zapisuj ostateczny wynik tylko w razie potrzeby.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą operację scalania w odrębnych instancjach prezentacji.