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
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Pythonie przy użyciu Java, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując pliki chronione lub duże."
---
## **Przegląd**

Aspose.Slides for Python via Java łączy prezentacje poprzez klonowanie slajdów z jednej [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scal wszystkie slajdy zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scalaniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym przepływie end-to-end;
- obsłuż mastery, zasoby, notatki, komentarze, media, czcionki, hasła, duże pliki i problemy wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część wyglądu z układu i mastera. Z tego powodu wybrane przeciążenie klonowania określa, w jaki sposób scalony slajd zostanie włączony do prezentacji docelowej.

Użyj [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) w jednej z następujących form:

- `addClone(source_slide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może być automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, więc powtarzające się slajdy używające tego samego mastera nie powodują wielokrotnego klonowania.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — dołącza sklonowany slajd do określonego [MasterSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `addClone(source_slide, destination_layout)` — dołącza sklonowany slajd bezpośrednio do określonego [LayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do prezentacji **docelowej**, a nie źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródłowe**

Najprostsze scalenie kopiuje każdy slajd ze źródłowej prezentacji do prezentacji docelowej. To odpowiedni wybór, gdy importowane slajdy powinny zachować oryginalny motyw, master i powiązania układów.

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

Powstała prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest celowo zachowywane.

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

Sprawdzaj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu mastera docelowego**

Użyj przeciążenia [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy importowane slajdy mają używać mastera, który już należy do prezentacji docelowej.

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

Aspose.Slides wybiera odpowiedni układ pod podanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allow_clone_missing_layout` ma wartość `True`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli ma wartość `False`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/).

Użyj `False`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy przy użyciu konkretnego układu docelowego**

Użyj przeciążenia [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

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

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przetwarza zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalone, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przeskalowuje automatycznie jego zawartości do nowego płótna. Kształty mogą więc występować przesunięte, nieoczekiwanie przeskalowane lub poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setSize) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/) skaluje zawartość, aby pasowała do żądanego rozmiaru.

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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz pozostawić oryginalną prezentację źródłową niezmienioną dla innych operacji, otwórz osobną instancję do scalenia.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i jawnie klonuj slajdy do nich przy użyciu [SlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone).

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

Sklonowane slajdy są dopisywane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, enumeruj [Presentation.getSections](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSections), pobierz bieżące slajdy każdej sekcji źródłowej metodą [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection), odtwórz sekcje w prezentacji docelowej i klonuj każdy zwrócony slajd do odpowiadającej sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/python-java/slide-section/) po pełny przykład enumeracji sekcji, w tym sekcje puste i zmiany strukturalne.

## **Scal wiele prezentacji bezpiecznie**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego dodatkowego źródła, otwiera każde źródło tylko w czasie kopiowania i zapisuje ostateczny plik na koniec.

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

Jest to przydatna podstawa do zachowania formatowania źródłowego importowanych slajdów. Jeśli wynik ma używać jednego tematu docelowego, zastąp proste wywołanie `addClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego, jak pokazano wyżej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Mastery sklonowane ręcznie nie są rejestrowane, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad ich strukturą.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny musi kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj rezultat po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z zawartością slajdu i są kopiowane wraz z jego klonowaniem. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](/slides/pl/python-java/presentation-notes/) i [presentation comments](/slides/pl/python-java/presentation-comments/).

Jeśli ważne jest formatowanie strony notatek, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą różnić się między plikami źródłowymi. W przepływach recenzji zweryfikuj także autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub z różnych szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować relacje slajdu do jego zasobów.

Zasoby osadzone i linkowane należy traktować odrębnie. Linkowany audio, wideo, obiekt OLE lub hiperlink pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w zawartość osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne binarne zasoby z niepowiązanych prezentacji zawsze zostaną odduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna między maszynami, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność wszystkich wymaganych czcionek w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) i zarządzać ich osadzaniem zgodnie z instrukcją w [Embed Fonts in Presentations](/slides/pl/python-java/embedded-font/).

Upewnij się również, że masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać ich osadzanie.

### **Prezentacje chronione hasłem**

Prezentacja chroniona hasłem musi zostać otwarta pomyślnie, zanim jej slajdy będą mogły być klonowane. Przekaż hasło przy pomocy [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword).

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

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie tej samej ochrony na prezentację docelową. Skonfiguruj ochronę wyjściową osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą pochłaniać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/python-java/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową natychmiast po jej scałowaniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątkowe**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) równocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w jednym zadaniu scalenia. Jeśli równolegle przetwarzasz niezależne zadania, używaj niezależnych instancji prezentacji i postępuj zgodnie z [Aspose.Slides multithreading guidance](/slides/pl/python-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny dla importowanego slajdu.

**Jak sprawić, by importowane slajdy używały motywu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał odpowiedni układ z tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przeskalowywana do wymiarów docelowych. Zmniejsz najpierw rozmiar prezentacji źródłowej, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setSize) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie oferują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scałowaniu między formatami. Zobacz [Supported File Formats](/slides/pl/python-java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli klonującej jedynie slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji w [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone), gdy struktura sekcji musi zostać zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Tak, są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub wątków recenzji, zweryfikuj wynik scalania, ponieważ te scenariusze obejmują również struktury na poziomie prezentacji.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają linkami zewnętrznymi, więc ich docelowe pliki lub adresy URL muszą nadal być dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalić plik chroniony hasłem?**

Otwórz go przy użyciu właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword), a następnie klonuj slajdy tak jak zwykle. Ochrona wyjściowa jest konfigurowana osobno.

**Jak obsługiwać bardzo duże prezentacje?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, zwalniaj prezentacje źródłowe niezwłocznie po ich scałowaniu i zapisuj ostateczny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) jednocześnie w wielu wątkach. Trzymaj każde zadanie scalenia w odrębnych instancjach prezentacji.