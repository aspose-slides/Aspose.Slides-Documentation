---
title: Efektywne łączenie prezentacji w Javie
linktitle: Łączenie prezentacji
type: docs
weight: 40
url: /pl/java/merge-presentation/
keywords:
- scalanie PowerPoint
- scalanie prezentacji
- scalanie slajdów
- scalanie PPT
- scalanie PPTX
- scalanie ODP
- łączenie PowerPoint
- łączenie prezentacji
- łączenie slajdów
- łączenie PPT
- łączenie PPTX
- łączenie ODP
- Java
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Javie, kopiując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując zabezpieczone lub duże pliki."
---
## **Przegląd**

Aspose.Slides for Java łączy prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze łączenia:

- połączenie wszystkich slajdów przy zachowaniu ich formatowania źródłowego;
- połączenie wybranych slajdów;
- zastosowanie mastera z prezentacji docelowej;
- zastosowanie konkretnego układu z prezentacji docelowej;
- normalizacja różnych rozmiarów slajdów przed połączeniem;
- dodanie sklonowanych slajdów do sekcji;
- połączenie kilku prezentacji w jednym przepływie end‑to‑end;
- obsługa masterów, zasobów, notatek, komentarzy, multimediów, czcionek, haseł, dużych plików i zagadnień wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, w jaki sposób połączony slajd zostanie włączony do prezentacji docelowej.

Użyj [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/) w jeden z następujących sposobów:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, więc powtarzające się slajdy korzystające z tego samego mastera nie powodują wielokrotnego klonowania tego mastera.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do konkretnego [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu układu lub nazwy.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do konkretnego [ILayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/).

Master lub układ przekazywany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do źródłowej.

## **Połącz całe prezentacje i zachowaj formatowanie źródła**

Najprostsze połączenie kopiuje każdy slajd ze źródłowej prezentacji do prezentacji docelowej. To właściwy wybór, gdy zaimportowane slajdy mają zachować pierwotny motyw, master i powiązania układów.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

W rezultacie prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych motywów. Jest to oczekiwane, gdy formatowanie źródła jest celowo zachowywane.

## **Połącz wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sprawdzaj indeksy slajdów przed klonowaniem, gdy pochodzą z danych wejściowych użytkownika lub zewnętrznej konfiguracji.

## **Połącz slajdy przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-), gdy zaimportowane slajdy mają podążać za masterem, który już należy do prezentacji docelowej.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` jest `true`, układ źródłowy zostaje sklonowany, aby slajd mógł zostać dodany. Jeśli jest `false`, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby połączenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Połącz slajdy przy użyciu konkretnego układu docelowego**

Użyj przeciążenia [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) wtedy, gdy dokładnie wiesz, którego układu docelowego mają używać zaimportowane slajdy.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przetwarza treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury pól zastępczych, sprawdź wynik, aby potwierdzić, że dziedziczone formatowanie i zachowanie pól zastępczych są odpowiednie.

## **Połącz prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być łączone, ale klonowanie slajdu do prezentacji o innym rozmiarze nie redesignuje automatycznie jego treści do nowego płótna. Kształty mogą więc pojawić się przesunięte, skalowane nieoczekiwanie lub poza widoczną część slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą treść przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/) skaluje treść, aby pasowała do żądanego rozmiaru.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienioną prezentację źródłową do innych operacji, otwórz osobną instancję na potrzeby łączenia.

## **Połącz slajdy w sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i wyraźnie klonuj slajdy do nich przy użyciu [addClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wylicz [Presentation.getSections](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSections--), pobierz bieżące slajdy każdej sekcji źródłowej przy użyciu [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSlidesListOfSection--), odtwórz sekcje w docelowej prezentacji i sklonuj każdy zwrócony slajd do odpowiadającej mu sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/java/slide-section/) po kompletny przykład enumeracji sekcji, w tym pustych sekcji i zmian strukturalnych.

## **Bezpieczne łączenie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej prezentacji źródłowej, trzyma każdą prezentację otwartą tylko podczas kopiowania i zapisuje ostateczny plik jednorazowo.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Jest to przydatna podstawa do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wyjściowy plik ma używać jednego motywu docelowego, zamień prostą wywołanie `addClone(slide)` na odpowiednie przeciążenie mastera lub układu docelowego pokazane wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie wprowadzić wymaganego mastera źródłowego do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są rejestrowane, więc unikaj wstępnego klonowania masterów, chyba że potrzebna jest jawna kontrola nad ich strukturą.

Nie zakładaj, że dwa mastery lub układy o takiej samej nazwie są wizualnie równoważne. Jeśli szablon firmowy musi kontrolować ostateczny wygląd, wybierz jawnie master lub układ docelowy i zweryfikuj rezultat po połączeniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](/slides/pl/java/presentation-notes/) i [presentation comments](/slides/pl/java/presentation-comments/).

Jeśli formatowanie strony notatek jest ważne, sprawdź połączoną prezentację, ponieważ mastery notatek są obiektami poziomu prezentacji i mogą się różnić między plikami źródłowymi. W przepływach recenzji sprawdzaj także autorów komentarzy oraz wątki komentarzy po połączeniu plików od różnych autorów lub z różnych szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów poziomu prezentacji, takich jak obrazy, osadzone audio, wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować powiązania slajdu z jego zasobami.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowany dźwięk, wideo, obiekt OLE lub hiperłącze pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i URL‑e zasobów linkowanych w środowisku, w którym otwierana będzie połączona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych zawsze zostaną zduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przeanalizuj połączony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność wszystkich potrzebnych czcionek w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) i zarządzać osadzaniem tak, jak opisano w [Embed Fonts in Presentations](/slides/pl/java/embedded-font/).

Upewnij się także, że masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje chronione hasłem**

Zabezpieczone hasłem źródło musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło poprzez [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    source.dispose();
}
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie takiej samej ochrony na prezentację docelową. Skonfiguruj ochronę wyjściową osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) daje kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/java/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową zaraz po jej połączeniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątkowe**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) równocześnie w wielu wątkach. Trzymaj każdą instancję prezentacji w ramach jednego zadania łączenia. Jeśli równolegle przetwarzasz niezależne zadania, używaj odrębnych instancji prezentacji i stosuj się do [Aspose.Slides multithreading guidance](/slides/pl/java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny zaimportowanemu slajdowi.

**Jak sprawić, by zaimportowane slajdy używały motywu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał układ spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów można połączyć?**

Tak, ale treść slajdu nie jest automatycznie redesignowana do wymiarów docelowych. Zmniejsz rozmiar prezentacji źródłowej najpierw, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/).

**Czy mogę połączyć pliki PPT, PPTX i ODP w jedną prezentację?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj potrzebne slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, po połączeniach międzyformatowych sprawdź złożoną treść. Zobacz [Supported File Formats](/slides/pl/java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli klonującej tylko slajdy. Odzyskaj wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Tak, są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych recenzji wątkowych, zweryfikuj połączony wynik, ponieważ te scenariusze obejmują struktury na poziomie prezentacji oraz treść slajdów.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą nadal być dostępne po połączeniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w połączonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w kwestii wdrażania czcionek. Sprawdź czcionki osadzone w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak połączyć plik chroniony hasłem?**

Otwórz go przy użyciu odpowiedniego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), a następnie normalnie klonuj jego slajdy. Ochrona wyjściowa jest konfigurowana osobno.

**Jak radzić sobie z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują w zużyciu pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj prezentacje źródłowe i zapisuj ostateczny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę łączyć slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) jednocześnie w wielu wątkach. Trzymaj każde zadanie łączenia w oddzielnych instancjach prezentacji.