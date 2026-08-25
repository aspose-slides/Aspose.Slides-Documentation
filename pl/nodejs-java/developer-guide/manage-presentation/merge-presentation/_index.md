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
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w JavaScript poprzez klonowanie slajdów, kontrolowanie masterów i układów, zmienianie rozmiaru zawartości slajdów, zachowywanie sekcji oraz obsługę plików zabezpieczonych lub dużych."
---
## **Przegląd**

Aspose.Slides for Node.js via Java scala prezentacje, kopiując slajdy z jednej [Prezentacji](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), która może zachować formatowanie slajdu źródłowego lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:
- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym kompleksowym procesie;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki oraz kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przez Ciebie wariant klonowania decyduje, jak scalony slajd zostanie włączony do prezentacji docelowej.

Użyj [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) w jednym z poniższych sposób:
- `addClone(sourceSlide)` — zachowuje układ i formatowanie slajdu źródłowego. W razie potrzeby master źródłowy może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie klonowane mastery, więc powtarzające się slajdy używające tego samego mastera źródłowego nie powodują wielokrotnego klonowania tego mastera.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego docelowego [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/). Aspose.Slides wyszukuje pasujący układ pod tym masterem na podstawie typu lub nazwy układu.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego docelowego [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scal całe prezentacje zachowując formatowanie źródłowe**

Najprostsze scalanie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. Jest to właściwy wybór, gdy zaimportowane slajdy mają zachować oryginalny motyw, master i relacje układu.

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

Powstała prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest celowo zachowywane.

## **Scal wybrane slajdy**

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

Zweryfikuj indeksy slajdów przed klonowaniem, gdy pochodzą od użytkownika lub zewnętrznej konfiguracji.

## **Scal slajdy używając mastera docelowego**

Użyj przeciążenia [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) gdy zaimportowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

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

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` ma wartość `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli ma wartość `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy używając określonego układu docelowego**

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

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie zmienia to projektu zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że dziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przekształca automatycznie jego zawartości do nowego obszaru. Kształty mogą więc być przesunięte, niespodziewanie skalowane lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/) skaluje zawartość, aby dopasować ją do żądanego rozmiaru.

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

Zmienianie rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej oryginalnej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalania.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje są istotne w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i sklonuj slajdy do nich jawnie przy użyciu [addClone(Slide, Section)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wylicz [Presentation.getSections](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSections), pobierz bieżące slajdy każdej sekcji źródłowej za pomocą [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSlidesListOfSection), odtwórz sekcje w docelowej prezentacji i sklonuj każdy zwrócony slajd do odpowiadającej mu sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/nodejs-java/slide-section/) po kompletny przykład enumeracji sekcji, w tym sekcje puste i zmiany strukturalne.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end-to-end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego kolejnego źródła, utrzymuje każde źródło otwarte tylko podczas kopiowania i zapisuje finalny plik jednorazowo.

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

Jest to przydatna podstawa do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wynik musi używać jednego motywu docelowego, zamień proste wywołanie `addClone(sourceSlide)` na odpowiednie przeciążenie destination-master lub destination-layout przedstawione wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides prowadzi wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad ich strukturą.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z zawartością slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [notatek prezentacji](/slides/pl/nodejs-java/presentation-notes/) i [komentarzy prezentacji](/slides/pl/nodejs-java/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, zweryfikuj scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W procesach przeglądu sprawdź również autorów komentarzy i komentarze wątkowe po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, dźwięk, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odnosić się do zasobów na poziomie prezentacji, takich jak obrazy, osadzony dźwięk, wideo i dane OLE. Klonuj cały slajd, a nie tylko jego widoczne kształty, aby Aspose.Slides mógł utrzymać powiązania slajdu z zasobami.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowany dźwięk, wideo, obiekt OLE lub hiperlink pozostają zależne od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i URL-e zasobów linkowanych w środowisku, w którym zostanie otwarta scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, zbadaj scalony pakiet i zmierz wynik zamiast polegać na ukrytej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność wszystkich wymaganych czcionek w środowisku docelowym. Możesz sprawdzić czcionki osadzone przy użyciu [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) oraz zarządzać osadzaniem wyraźnie, jak opisano w [Embed Fonts in Presentations](/slides/pl/nodejs-java/embedded-font/).

Upewnij się również, że masz zezwolenie na osadzanie czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi być otwarte pomyślnie, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło za pomocą [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

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

Otwieranie zaszyfrowanego źródła nie nakłada automatycznie takiej samej ochrony na prezentację docelową. Skonfiguruj ochronę wyjścia oddzielnie, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, dźwięk, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) oferuje kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/nodejs-java/manage-blob/) po strategie obsługi dużych plików.

W przypadku dużych plików, preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową natychmiast po scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że proces wymaga punktów kontrolnych.

### **Bezpieczeństwo wątkowe**

Nie ładuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) w wielu wątkach. Te operacje nie są obsługiwane w trybie wielowątkowym. Jeśli musisz równolegle wykonywać niezależne zadania scalania, użyj kilku jednowątkowych procesów, każdy z własnymi instancjami prezentacji, i postępuj zgodnie z [wytycznymi dotyczącymi wielowątkowości Aspose.Slides](/slides/pl/nodejs-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny dla zaimportowanego slajdu.

**Jak sprawić, aby zaimportowane slajdy używały motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides postara się dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy powinienem używać określonego układu docelowego zamiast mastera docelowego?**

Użyj określonego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przekształcana do wymiarów docelowych. Najpierw zmień rozmiar prezentacji źródłowej, gdy potrzebne jest przewidywalne rozmieszczenie, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalać prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj skomplikowaną zawartość po skalowaniu między formatami. Zobacz [Supported File Formats](/slides/pl/nodejs-java/supported-file-formats/).

**Czy sekcje źródłowe są automatycznie zachowywane?**

Nie, przy podstawowej pętli, która klonuje tylko slajdy. Odtwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji w [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W procesach zależnych od stylu mastera notatek, autorów komentarzy lub danych recenzji wątkowych, zweryfikuj wynik scalania, ponieważ te scenariusze obejmują struktury na poziomie prezentacji oraz treść slajdu.

**Co się dzieje z dźwiękiem, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część powiązań zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów przy wdrażaniu czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i wyraźnie zarządzaj osadzaniem czcionek lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go przy użyciu właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), a następnie sklonuj jego slajdy normalnie. Ochrona wyjścia jest konfigurowana osobno.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z podania ścieżek plików przy bardzo dużych plikach, szybko zwalniaj prezentacje źródłowe i zapisuj finalny rezultat tylko w razie potrzeby.

**Czy mogę scalać slajdy z wielu wątków?**

Nie ładuj, nie zapisuj ani nie klonuj instancji prezentacji w wielu wątkach. W przypadku równoległych zadań scalania używaj oddzielnych jednowątkowych procesów i niezależnych instancji prezentacji.