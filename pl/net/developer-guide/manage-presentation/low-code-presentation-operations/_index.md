---
title: Operacje prezentacji Low-Code w .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /pl/net/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- łączenie prezentacji
- iterowanie slajdów
- iterowanie kształtów
- iterowanie tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów wzorca
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w .NET, aby konwertować i scalać prezentacje, iterować zawartość, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) udostępnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te klasy upraszczają często używane przepływy pracy modelu obiektowego, więc możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocnicy low‑code są najprzydatniejsi, gdy operacja dotyczy całego pliku lub prezentacji, a domyślny przepływ pracy spełnia Twoje wymagania. Używaj pełnego modelu obiektowego [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/), gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, wzorami, układami, kształtami, ustawieniami eksportu lub zależnościami między elementami prezentacji.

Poniższa tabela podsumowuje dostępnych pomocników:

| Pomocnik | Do czego służy |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Konwersja prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik‑do‑pliku. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych wzorów/układów, redukcja osadzonych danych czcionek oraz kompresja obrazów. |

## **Konwertuj prezentację**

Użyj [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą wersję z ścieżki wyjściowej i zapisuje wynik.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) udostępnia także dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Skorzystaj z pełnego modelu obiektowego, gdy potrzebujesz sprawdzić lub zmodyfikować prezentację przed eksportem albo skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/slides/pl/net/convert-presentation/) po szczegółowe przepływy i opcje formatów.

## **Scal prezentacje**

Użyj [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) aby połączyć pełne pliki prezentacji jednym wywołaniem. Pliki wejściowe muszą mieć ten sam format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego rezultatu bez indywidualnego wybierania lub przemapowywania. Skorzystaj z pełnego modelu obiektowego, gdy musisz scalić wybrane slajdy, zastosować docelowy wzór lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/slides/pl/net/merge-presentation/) dla tych scenariuszy.

## **Iteruj po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania obejmujących całą prezentację.

Poniższy przykład używa [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) i [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) do inspekcji odpowiednich elementów:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje slajdy zwykłe, wzory i układy. Przeciążenia z parametrem `includeNotes` mogą także przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy kolejność przeglądania, wczesne wyjście, filtrowanie przed wywołaniem zwrotnym lub szczegółowa kontrola rodzic‑dziecko są istotne.

## **Zbieraj kształty**

Użyj [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego z nich. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Użyj [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) zamiast, gdy każdy kształt może być obsłużony od razu i nie musisz zachowywać zebranego wyniku.

## **Kompresuj zawartość prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) może usuwać nieużywane elementy strukturalne i redukować dane osadzonych czcionek:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) usuwa slajdy układów, które nie są referencjonowane przez żaden zwykły slajd.  
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) usuwa nieużywane slajdy wzorów.  
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) usuwa nieużywane znaki z osadzonych czcionek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Najpierw usuń nieużywane układy, a potem nieużywane wzory, aby wzór, który po czyszczeniu układów przestanie być referencjonowany, również mógł zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych wzorów, układów lub pełnych danych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/net/slide-master/) oraz [Embedded Font](/slides/pl/net/embedded-font/).

### **Kompresja całej prezentacji**

Aspose.Slides dla .NET 26.11 wprowadza [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Łączy usuwanie nieużywanych slajdów układów/wzorów, podzbiór osadzonych czcionek do używanych znaków oraz kompresję obrazów przy 150 DPI. Używaj poszczególnych operacji powyżej, gdy potrzebujesz kontrolować, które zmiany zostaną zastosowane.

Zainstaluj [Aspose.Slides dla .NET](/slides/pl/net/installation/) w wersji 26.11 lub nowszej i podaj `input.pptx`. Zapisz do osobnego pliku: usunięte układy, znaki czcionek i przycięte piksele obrazów mogą być potrzebne przy późniejszej edycji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Kompresuj obrazy w wybranej rozdzielczości**

Użyj [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) aby przetworzyć kwalifikujące się obrazy bez jednoczesnego usuwania układów czy podzbiorem czcionek. W przykładzie użyto 96 DPI; wybierz inną wartość [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) dla swoich potrzeb wyjściowych.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Oba pomocniki stosują następujący zakres przetwarzania obrazów:

| Zawartość | Traktowanie |
| --- | --- |
| Obrazy rastrowe i wypełnienia obrazami w kształtach na slajdach normalnych, wzorów i układów, w tym grupowane kształty | Kwalifikowane do kompresji. |
| Obrazy już o żądanej lub niższej rozdzielczości | Nie są powiększane. Obszary przycięte mogą być nadal usuwane. |
| Przycięte fragmenty obrazów | Ukryte piksele są trwale usuwane, a offsety przycięcia resetowane. |
| Tła slajdów i wypełnienia komórek tabel | Nie są przetwarzane przez te pomocniki. |
| Wewnętrzne elementy wykresów/SmartArt, GIF oraz formaty wektorowe takie jak SVG, EMF i WMF | Poza zakresem udokumentowanej kompresji obrazów. |

W wersji 26.11 [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) zapobiega downsamplingowi obrazów nieprzyciętych na podstawie rozdzielczości, ale **nie zachowuje przyciętych pikseli**. Przycięty obraz może nadal zostać zapisany z usuniętymi ukrytymi obszarami. Żaden z pomocników nie udostępnia opcji zachowania przycięcia. Po indywidualną kontrolę zobacz [przykład kompresji per‑obraz](/slides/pl/net/examples/optimization-batch/compression/).

Porównaj wygląd i rozmiar pliku wyjściowego przed zastąpieniem oryginału. Oszczędności zależą od źródłowych obrazów, ich wyświetlanej wielkości i nieużywanej zawartości; kompresja nie gwarantuje mniejszego pliku. Zobacz [Embedded Fonts](/slides/pl/net/embedded-font/) po implikacje podzbioru czcionek.

## **FAQ**

**Kiedy powinienem używać API low‑code zamiast pełnego modelu obiektowego?**

Używaj pomocników low‑code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Korzystaj z pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować relacje wzorów i układów, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) wymaga, aby prezentacje wejściowe miały ten sam format. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), a następnie scal przekonwertowane pliki.

**Czy ForEach przetwarza slajdy wzoru, układu i notatek?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iteruje po normalnych slajdach prezentacji. Operacje [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) i [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) obejmują domyślnie normalne, wzory i układy. Użyj ich przeciążeń z `includeNotes` ustawionym na `true`, aby włączyć slajdy notatek.

**Jaka jest różnica między ForEach.Shape a Collect.Shapes?**

Użyj [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), aby przetwarzać każdy kształt od razu w ramach funkcji zwrotnej. Użyj [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz wyniku wyliczalnego, który można zachować, filtrować, liczyć lub przeglądać wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Oszczędności zależą od nieużywanych układów/wzorów, osadzonych czcionek z nieużywanymi znakami oraz obrazów, które korzystają z kompresji. Pomocnicy [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) mogą pozostawić rozmiar bez zmian lub nawet zwiększyć go przy niektórych danych wejściowych. Porównaj zarówno rozmiar, jak i jakość wizualną oraz zachowaj oryginał.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na wczytanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), wywołaj [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/slides/pl/net/convert-presentation/)
- [Merge Presentations](/slides/pl/net/merge-presentation/)
- [Slide Master](/slides/pl/net/slide-master/)
- [Manage Text Box](/slides/pl/net/manage-textbox/)
- [Embedded Font](/slides/pl/net/embedded-font/)