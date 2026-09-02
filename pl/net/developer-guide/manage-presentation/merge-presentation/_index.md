---
title: Efektywne scalanie prezentacji w .NET
linktitle: Scal prezentacje
type: docs
weight: 40
url: /pl/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w .NET, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując pliki chronione lub duże."
---
## **Przegląd**

Aspose.Slides for .NET łączy prezentacje poprzez klonowanie slajdów z jednej [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub layoutu w docelowej prezentacji.

Ten artykuł opisuje najczęstsze scenariusze łączenia:

- połącz wszystkie slajdy, zachowując ich formatowanie źródłowe;
- połącz wybrane slajdy;
- zastosuj master z docelowej prezentacji;
- zastosuj konkretny layout z docelowej prezentacji;
- znormalizuj różne rozmiary slajdów przed łączeniem;
- dodaj sklonowane slajdy do sekcji;
- połącz kilka prezentacji w jednym kompletnym przepływie pracy;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i layouty**

Slajd dziedziczy dużą część wyglądu z swojego layoutu i mastera. Z tego powodu wybrany przeciążony operator klonowania określa, w jaki sposób połączony slajd zostanie zintegrowany z docelową prezentacją.

Użyj [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) w jeden z poniższych sposobów:

- `AddClone(sourceSlide)` — zachowuje layout i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do docelowej prezentacji. Aspose.Slides śledzi automatycznie sklonowane mastery, więc powtarzające się slajdy używające tego samego źródłowego mastera nie powodują wielokrotnego klonowania tego mastera.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/). Aspose.Slides wyszukuje pasujący layout pod tym masterem według typu layoutu lub nazwy.
- `AddClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/).

Master lub layout przekazany do przeciążenia `AddClone` musi należeć do **docelowej** prezentacji, a nie do źródłowej.

## **Scalanie całych prezentacji i zachowanie formatowania źródłowego**

Najprostsze scalanie kopiuje każdy slajd ze źródłowej prezentacji do docelowej. Jest to właściwy wybór, gdy importowane slajdy mają zachować oryginalny motyw, master i zależności layoutu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Wynikowa prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest celowo zachowywane.

## **Scalanie wybranych slajdów**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Sprawdź poprawność indeksów slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z konfiguracji zewnętrznej.

## **Scalanie slajdów przy użyciu docelowego mastera**

Użyj przeciążenia [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) gdy importowane slajdy mają korzystać z mastera, który już należy do docelowej prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides wybiera odpowiedni layout pod określonym masterem, dopasowując typ lub nazwę layoutu źródłowego. Jeśli nie istnieje odpowiedni layout i `allowCloneMissingLayout` ma wartość `true`, layout źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli ma wartość `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się błędem zamiast wprowadzania dodatkowego layoutu do docelowego mastera.

## **Scalanie slajdów przy użyciu konkretnego docelowego layoutu**

Użyj przeciążenia [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) gdy dokładnie wiesz, którego docelowego layoutu mają używać importowane slajdy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Zastosowanie docelowego layoutu zmienia dziedziczoną relację layoutu; nie przerysowuje treści slajdu źródłowego. Jeśli layouty źródłowy i docelowy mają różne struktury placeholderów, sprawdź rezultat, aby potwierdzić, że dziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze slajdu nie przerysowuje automatycznie jego treści na nowym płótnie. Kształty mogą więc być przesunięte, skalowane nieoczekiwanie lub znajdować się poza widocznym obszarem slajdu.

Praktycznym podejściem jest zmiana rozmiaru źródłowej prezentacji przed klonowaniem. Metoda [SlideSize.SetSize](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesize/setsize/) może skalować istniejącą treść przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/) skaluje treść, aby pasowała do żądanego rozmiaru.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Zmiana rozmiaru modyfikuje obiekt źródłowej prezentacji w pamięci. Jeśli potrzebujesz niezmienionej oryginalnej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalania.

## **Scalanie slajdów w sekcję prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w źródłowej prezentacji. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w docelowej prezentacji i klonuj slajdy do nich wyraźnie przy użyciu [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz te sekcje w docelowej prezentacji i mapuj każdy slajd źródłowy do odpowiedniej sekcji docelowej.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end-to-end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego dodatkowego źródła, utrzymuje każde źródło otwarte tylko w czasie kopiowania i zapisuje finalny plik jednorazowo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Jest to przydatna podstawa do zachowania formatowania źródłowego importowanych slajdów. Jeśli wynik musi używać jednego tematu docelowego, zastąp proste wywołanie `AddClone(slide)` odpowiednim przeciążeniem destination-master lub destination-layout pokazanym wcześniej.

## **Praktyczne uwagi**

### **Mastery, layouty i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do docelowej prezentacji. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub layouty o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować końcowy wygląd, wybierz wyraźnie docelowy master lub layout i zweryfikuj rezultat po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [notatek prezentacji](https://docs.aspose.com/slides/pl/net/presentation-notes/) i [komentarzy prezentacji](https://docs.aspose.com/slides/pl/net/presentation-comments/).

Jeśli formatowanie strony notatek jest ważne, zweryfikuj scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W procesach przeglądu zweryfikuj również autorów komentarzy i komentarze wątkowe po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Sklonuj sam slajd, a nie tylko jego widoczne kształty, aby Aspose.Slides mógł utrzymać relacje slajdu do jego zasobów.

Zasoby osadzone i linkowane należy traktować odrębnie. Linkowane audio, wideo, obiekt OLE lub hiperlink pozostają zależne od zewnętrznego celu; klonowanie slajdu nie przekształca linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides explicite śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych źródeł będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przejrzyj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że samo klonowanie slajdów zapewnia dostępność każdej wymaganej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki za pomocą [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać osadzaniem explicite, jak opisano w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/net/embedded-font/).

Sprawdź również, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło poprzez [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Otwieranie zaszyfrowanego źródła nie stosuje automatycznie takiej samej ochrony do docelowej prezentacji. Skonfiguruj ochronę wyjściową osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/blobmanagementoptions/) zapewnia kontrolę nad obsługą BLOB-ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/net/manage-blob/) w celu strategii na duże pliki.

W przypadku dużych plików, w miarę możliwości wczytuj z ścieżek plików, zwalniaj każdą źródłową prezentację natychmiast po scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ pracy wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie wczytuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji ograniczoną do jednej operacji scalania. Jeśli równolegle wykonujesz niezależne zadania, używaj niezależnych instancji prezentacji i postępuj zgodnie z [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/net/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej źródłowej prezentacji?**

Użyj [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) bez podawania mastera lub layoutu docelowego. Aspose.Slides może automatycznie sklonować źródłowy master, gdy jest potrzebny dla importowanego slajdu.

**Jak sprawić, by importowane slajdy używały motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z docelowej prezentacji, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego layoutu pod tym masterem.

**Kiedy używać konkretnego layoutu docelowego zamiast mastera docelowego?**

Użyj konkretnego layoutu, gdy każdy importowany slajd ma korzystać z jednego znanego layoutu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród layoutów tego mastera na podstawie typu lub nazwy layoutu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów można scalać?**

Tak, ale zawartość slajdu nie jest automatycznie przerysowywana do wymiarów docelowych. Zmień rozmiar źródłowej prezentacji najpierw, gdy potrzebujesz przewidywalnego rozmieszczenia, na przykład przy użyciu [SlideSize.SetSize](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą źródłową prezentację, sklonuj wymagane slajdy do jednej docelowej i zapisz docelową w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scalaniu międzyformatowym. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/net/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli, która tylko klonuje slajdy. Odtwórz wymagane sekcje w docelowej prezentacji i użyj przeciążenia sekcji [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowane?**

Są kopiowane wraz ze sklonowanym slajdem. Dla przepływów pracy zależnych od stylizacji mastera notatek, autorów komentarzy lub danych recenzji wątkowych, zweryfikuj wynik scalania, ponieważ te scenariusze obejmują struktury na poziomie prezentacji oraz treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów przy wdrażaniu czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i explicite zarządzaj osadzaniem czcionek lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalać plik zabezpieczony hasłem?**

Otwórz go z poprawnym [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/), a następnie normalnie sklonuj jego slajdy. Ochrona wyjścia jest konfigurowana osobno.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB, gdy duże obiekty binarne dominują w zużyciu pamięci, preferuj wczytywanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj źródłowe prezentacje i zapisuj ostateczny wynik tylko w razie potrzeby.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą operację scalania izolowaną w osobnych instancjach prezentacji.