---
title: Efektywne scalanie prezentacji na Androidzie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument na Androidzie poprzez klonowanie slajdów, kontrolowanie masterów i układów, zmianę rozmiaru zawartości slajdów, zachowanie sekcji oraz obsługę chronionych lub dużych plików."
---
## **Przegląd**

Aspose.Slides for Android via Java scala prezentacje poprzez klonowanie slajdów z jednej [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), która może zachować formatowanie slajdu źródłowego lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- skaluj wszystkie slajdy, zachowując ich formatowanie źródłowe;
- skaluj wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym przepływie end-to-end;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki oraz kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd odziedzicza dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, jak scentralizowany slajd zostanie włączony do prezentacji docelowej.

Użyj [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) w jeden z następujących sposobów:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie slajdu źródłowego. W razie potrzeby master źródłowy może być automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, więc powtarzające się slajdy korzystające z tego samego mastera nie powodują jego kolejnych klonowań.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego mastera docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides wyszukuje pasujący układ pod tym masterem według typu układu lub nazwy.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego układu docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do prezentacji **docelowej**, a nie do prezentacji źródłowej.

## **Scal całą prezentację i zachowaj formatowanie źródła**

Najprostsze scalenie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. Jest to właściwy wybór, gdy zaimportowane slajdy powinny zachować oryginalny motyw, master i powiązania układu.

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

Wynikowa prezentacja może zawierać wiele masterów, gdy źródło i docelowa używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródła jest zachowywane celowo.

## **Scal wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów z prezentacji źródłowej.

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

Sprawdź poprawność indeksów slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) gdy zaimportowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

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

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` jest `true`, układ źródłowy jest klonowany, aby można było dodać slajd. Jeśli jest `false`, zostaje wyrzucony [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalenie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy przy użyciu określonego układu docelowego**

Użyj przeciążenia [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) gdy dokładnie wiesz, którego układu docelowego mają używać zaimportowane slajdy.

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

Zastosowanie układu docelowego zmienia odziedziczoną relację układu; nie przerysowuje zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są właściwe.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przerysowuje automatycznie jego zawartości na nowym płótnie. Kształty mogą więc wyglądać na przesunięte, nieoczekiwanie skalowane lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/) skaluje zawartość, aby pasowała do żądanego rozmiaru.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalenia.

## **Scal slajdy w sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich jawnie przy użyciu [addClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz te sekcje w docelowej i przypisz każdy slajd źródłowy do odpowiedniej sekcji docelowej.

## **Bezpiecznie scal wiele prezentacji**

Poniższy przykład end-to-end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdów każdego dodatkowego źródła, utrzymuje każde źródło otwarte tylko podczas kopiowania i zapisuje ostateczny plik jednorazowo.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Jest to przydatna podstawa do zachowania formatowania źródła zaimportowanych slajdów. Jeśli wynik musi używać jednego motywu docelowego, zastąp prostą wywołanie `addClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego, jak wcześniej pokazano.

## **Praktyczne rozważania**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides prowadzi wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są śledzone przez ten rejestr, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz explicitnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia również dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/androidjava/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/androidjava/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą różnić się między plikami źródłowymi. W procesach przeglądu, zweryfikuj także autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mogło utrzymać powiązania slajdu z jego zasobami.

Zasoby osadzone i powiązane należy traktować odrębnie. Powiązany audio, wideo, obiekt OLE lub hiperlink pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie przekształca linku zewnętrznego w zawartość osadzoną. Testuj ścieżki zasobów powiązanych i adresy URL w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych zawsze będą deduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, sprawdź scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i ich dostępność**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność każdej potrzebnej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) i zarządzać osadzaniem explicite, jak opisano w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/androidjava/embedded-font/).

Sprawdź również, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje chronione hasłem**

Źródło chronione hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło za pomocą [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Otworzenie zaszyfrowanego źródła nie nakłada automatycznie takiej samej ochrony na prezentację docelową. Skonfiguruj ochronę wyjściową oddzielnie, gdy jest to wymagane.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) zapewnia kontrolę nad obsługą BLOB-ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/androidjava/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików, w miarę możliwości wczytuj z ścieżek plików, zwalniaj każdą prezentację źródłową zaraz po jej scałowaniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie wczytuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji ograniczoną do jednej operacji scalania. Jeśli równolegle przetwarzasz niezależne zadania, używaj niezależnych instancji prezentacji i stosuj się do [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/androidjava/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny dla zaimportowanego slajdu.

**Jak sprawić, aby zaimportowane slajdy korzystały z motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać określonego układu docelowego zamiast mastera docelowego?**

Użyj określonego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrało spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów mogą być scalane?**

Tak, ale zawartość slajdu nie jest automatycznie przystosowywana do wymiarów docelowych. Zmniejsz rozmiar prezentacji źródłowej wcześniej, np. przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/).

**Czy mogę scalić prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie wspierają dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scałowaniu między formatami. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/androidjava/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie w podstawowej pętli, która tylko klonuje slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. Dla przepływów zależnych od stylu mastera notatek, autorów komentarzy lub wątków przeglądu, zweryfikuj scałowany wynik, ponieważ te scenariusze obejmują struktury na poziomie prezentacji oraz treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Osadzona zawartość jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki z każdego źródła są zagwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest ważna.

**Jak scalić plik chroniony hasłem?**

Otwórz go przy pomocy właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), a następnie normalnie klonuj jego slajdy. Ochrona wyjściowa jest konfigurowana oddzielnie.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB-ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj wczytywanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj prezentacje źródłowe i zapisuj ostateczny wynik tylko wtedy, gdy jest to potrzebne.

**Czy mogę scalić slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation] jednocześnie w wielu wątkach. Trzymaj każdą operację scalania w odrębnych instancjach prezentacji.