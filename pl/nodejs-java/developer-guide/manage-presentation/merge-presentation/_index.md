---
title: Efektywne scalanie prezentacji w JavaScript
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w JavaScript, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for Node.js via Java scala prezentacje, klonując slajdy z jednej [Prezentacji](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w docelowej prezentacji.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scalenie wszystkich slajdów przy zachowaniu ich pierwotnego formatowania;
- scalenie wybranych slajdów;
- zastosowanie mastera z prezentacji docelowej;
- zastosowanie określonego układu z prezentacji docelowej;
- normalizacja różnych rozmiarów slajdów przed scalaniem;
- dodanie sklonowanych slajdów do sekcji;
- scalenie kilku prezentacji w jednym przepływie end‑to‑end;
- obsługa masterów, zasobów, notatek, komentarzy, multimediów, czcionek, haseł, dużych plików i zagadnień wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, w jaki sposób scałowany slajd zostanie włączony do prezentacji docelowej.

Użyj [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) w jednej z następujących form:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, aby powtarzające się slajdy korzystające z tego samego mastera nie powodowały wielokrotnego klonowania.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scalanie całych prezentacji i zachowanie formatowania źródła**

Najprostsze scalenie kopiowania wszystkich slajdów z prezentacji źródłowej do prezentacji docelowej. Jest to właściwy wybór, gdy zaimportowane slajdy powinny zachować oryginalny motyw, master i zależności układów.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

W wyniku prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródła jest celowo zachowywane.

## **Scalanie wybranych slajdów**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Waliduj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scalanie slajdów przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) gdy zaimportowane slajdy mają podążać za masterem, który już należy do prezentacji docelowej.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje pasujący układ i `allowCloneMissingLayout` jest `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli jest `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/).

Ustaw `false`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scalanie slajdów przy użyciu konkretnego układu docelowego**

Użyj przeciążenia [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) gdy dokładnie wiesz, którego układu docelowego mają używać zaimportowane slajdy.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przetwarza on zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że dziedziczone formatowanie i zachowanie placeholderów są właściwe.

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przetwarza automatycznie jego zawartości na nową powierzchnię. Kształty mogą więc zostać przesunięte, nieoczekiwanie przeskalowane lub znajdować się poza widocznym obszarem slajdu.

Praktyczne podejście to zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/) skaluje zawartość, aby dopasować ją do żądanego rozmiaru.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz oryginalnej prezentacji źródłowej niezmienionej dla innych operacji, otwórz osobną instancję dla scalenia.

## **Scalanie slajdów do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i jawnie klonuj slajdy do nich przy użyciu [addClone(Slide, Section)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sklonowane slajdy są dołączane do wskazanej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz te sekcje w docelowej prezentacji i przypisz każdy slajd źródłowy do odpowiedniej sekcji docelowej.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej prezentacji źródłowej, utrzymuje otwartą każdą źródłową tylko w czasie kopiowania i zapisuje ostateczny plik jednorazowo.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Jest to przydatna podstawa do zachowania formatowania źródła zaimportowanych slajdów. Jeśli wyjściowy plik ma korzystać z jednego motywu docelowego, zastąp prostą instrukcję `addClone(sourceSlide)` odpowiednim przeciążeniem mastera lub układu docelowego, pokazanym wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są rejestrowane, więc unikaj ich wstępnego klonowania, chyba że potrzebna jest pełna kontrola nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z zawartością slajdu i są kopiowane przy jego klonowaniu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/nodejs-java/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/nodejs-java/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, zweryfikuj połączoną prezentację, ponieważ mastery notatek są obiektami poziomu prezentacji i mogą różnić się pomiędzy plikami źródłowymi. W przepływach recenzji sprawdź także autorów komentarzy oraz wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować powiązania slajdu z jego zasobami.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowane audio, wideo, obiekt OLE lub hiperłącze pozostają zależne od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie połączona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przeanalizuj połączony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność każdej potrzebnej czcionki w środowisku docelowym. Czcionki osadzone możesz sprawdzić metodą [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) i zarządzać osadzaniem zgodnie z opisem w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/nodejs-java/embedded-font/).

Sprawdź także, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać ich osadzanie.

### **Prezentacje chronione hasłem**

Źródło chronione hasłem musi zostać pomyślnie otwarte, zanim jego slajdy zostaną sklonowane. Hasło podaje się za pomocą [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    source.dispose();
}
```

Otworzenie zaszyfrowanego źródła nie stosuje automatycznie tego samego zabezpieczenia do prezentacji docelowej. Ochronę wyjścia konfiguruje się osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/nodejs-java/manage-blob/) po szczegółowe strategie dla dużych plików.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową natychmiast po jej scałowaniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątkowe**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) w wielu wątkach. Te operacje nie są obsługiwane w środowisku wielowątkowym. Jeśli musisz równolegle przetwarzać niezależne zadania scalania, użyj kilku jednowątkowych procesów, każdy z własnym zestawem instancji prezentacji, i stosuj się do [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/nodejs-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny wygląd każdej prezentacji źródłowej?**

Użyj [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest wymagany przez zaimportowany slajd.

**Jak sprawić, by zaimportowane slajdy używały motywu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj określonego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał układ spośród dostępnych w tym masterze na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przystosowywana do wymiarów docelowych. Najpierw zmień rozmiar prezentacji źródłowej, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj potrzebne slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, po scaleniu międzyformatowym zweryfikuj złożoną zawartość. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/nodejs-java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli, która tylko klonuje slajdy, sekcje nie są zachowywane. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), gdy struktura sekcji musi zostać zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane razem ze sklonowanym slajdem. W przepływach zależnych od stylu mastera notatek, autorów komentarzy lub danych przeglądu wątkowego, zweryfikuj połączony wynik, ponieważ scenariusze te obejmują zarówno struktury na poziomie prezentacji, jak i zawartość slajdów.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w połączonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w kwestii wdrożenia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia ma znaczenie.

**Jak scalać plik chroniony hasłem?**

Otwórz go przy użyciu właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), a następnie normalnie klonuj jego slajdy. Ochrona wyjścia jest konfigurowana osobno.

**Jak radzić sobie z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, niezwłocznie zwalniaj prezentacje źródłowe i zapisuj ostateczny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy w wielu wątkach?**

Nie ładuj, nie zapisuj ani nie klonuj instancji prezentacji w wielu wątkach. Dla równoległych zadań scalania używaj oddzielnych jednowątkowych procesów i niezależnych instancji prezentacji.