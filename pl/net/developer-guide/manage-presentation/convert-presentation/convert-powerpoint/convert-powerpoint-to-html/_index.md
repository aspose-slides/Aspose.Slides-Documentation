---
title: Konwertuj prezentacje PowerPoint do HTML w .NET
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/net/convert-powerpoint-to-html/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- zapisz PowerPoint jako HTML
- zapisz prezentację jako HTML
- zapisz slajd jako HTML
- zapisz PPT jako HTML
- zapisz PPTX jako HTML
- eksportuj PPT do HTML
- eksportuj PPTX do HTML
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w .NET. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG oraz multimediów."
---
## **Przegląd**

Aspose.Slides dla .NET może zapisać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja polega na jednorazowym załadowaniu [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i wywołaniu [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) z [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) gdy potrzebujesz kontrolować układ eksportu, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksportuj całą prezentację lub wybrane slajdy.
- Generuj HTML o stałym układzie, responsywny lub oparty na SVG.
- Dołącz notatki prelegenta i komentarze.
- Kontroluj jakość obrazu i przycięte dane obrazu.
- Osadzaj czcionki lub zapisuj pliki czcionek osobno.
- Wybierz sposób zapisu i odwołań do zasobów zewnętrznych i plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Dla publikacji w sieci rozważ zasoby zewnętrzne, niższą DPI obrazów oraz osadzanie tylko tych czcionek, które nie są pewnie dostępne w środowisku docelowym.

## **Konwertuj prezentację do HTML**

Aby wyeksportować prezentację do HTML, załaduj ją przy pomocy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest zwalniany przez deklarację `using`, co zwalnia uchwyty plików i zasoby renderowania po eksporcie.

## **Użyj HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) jest główną klasą konfiguracyjną eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały pomocnicze lub inne informacje o układzie.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, na przykład jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazu.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `ShowHiddenSlides`: obejmuje ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje pokazują najczęstsze opcje osobno, aby można było łączyć jedynie te, które są potrzebne w twoim przepływie pracy.

## **Konwertuj wybrane slajdy do HTML**

Przeciążenie [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), które przyjmuje numery slajdów, używa indeksów 1‑based. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Użyj tego wzorca, gdy witryna lub aplikacja potrzebuje jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) i przekaż ją do każdego wywołania `Save`.

## **Utwórz responsywny HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/responsivehtmlcontroller/) zapewnia responsywny wynik HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Dla responsywnego układu opartego na SVG ustaw `SvgResponsiveLayout` w [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/). Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Dołącz notatki prelegenta i komentarze**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) poprzez `HtmlOptions.SlidesLayoutOptions`, aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje zawartość slajdu wraz z notatkami prelegenta pod slajdem.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Wyeksportowany HTML zawiera obszar notatek:

![Wyjście HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, na przykład na `CommentsPositions.Right` lub `CommentsPositions.Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw oba właściwości.

## **Kontroluj jakość obrazu i przycięte obszary**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/net/aspose.slides.export/picturescompression/), gdy potrzebujesz wyższej jakości obrazu.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyjścia. Zachowuj przycięte dane tylko wtedy, gdy użytkownicy muszą móc je odzyskać lub przeanalizować ukryte części obrazu. Zachowanie ich może zwiększyć rozmiar HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Dodaj CSS**

Dla prostego stylowania przekaż ciąg CSS do [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Aby dodać własny nagłówek dokumentu, powiązany plik CSS lub własny znacznik wokół slajdów i kształtów, zaimplementuj [IHtmlFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ihtmlformattingcontroller/) i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmlformatter/) przy użyciu `CreateCustomFormatter`.

## **Osadzaj czcionki**

Jeśli w środowisku docelowym czcionki użyte w prezentacji mogą nie być zainstalowane, osadź czcionki w HTML za pomocą [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Wyklucz czcionki tylko wtedy, gdy jesteś pewny, że docelowe przeglądarki lub systemy już je zapewniają. Dla czcionek firmowych lub mniej popularnych osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkuj pliki czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek w osobnych plikach WOFF i dodać reguły `@font-face` do HTML. Poniższy pomocnik rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedallfontshtmlcontroller/) i nadpisuje `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

W tym przykładzie pliki czcionek są zapisywane w `html-output/fonts`, a HTML odwołuje się do nich za pomocą adresów URL takich jak `fonts/BrandFont-normal-400.woff`. Jeśli plik HTML i czcionki są wdrażane w innym miejscu, wybierz `fontUrlPrefix`, aby pasował do wdrożonej ścieżki URL.

## **Zapisz zasoby zewnętrznie**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą sprawić, że plik będzie duży. Jeśli aplikacja potrzebuje zewnętrznych plików obrazów, zaimplementuj [ILinkEmbedController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/) i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/htmloptions/).

Kiedy externalizujesz zasoby, wybierz dwie ścieżki świadomie:

- Ścieżka wyjściowa systemu plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, którą przeglądarka używa z dokumentu HTML do ładowania tych plików.

Pełną implementację linkowania obrazów znajdziesz w [Export Presentations to HTML with Externally Linked Images](/slides/pl/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Eksportuj pliki multimedialne**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz tworzy HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Jeśli plik HTML znajduje się w `html-output/presentation.html`, a pliki multimedialne są zapisywane w `html-output/media`, `path` powinien wskazywać katalog multimediów na dysku, natomiast `baseUri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Do lokalnego podglądu możesz zbudować URI `file:///` z katalogu multimediów. Dla wdrożonej aplikacji użyj absolutnego URL opublikowanego katalogu multimediów.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML to operacja renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych multimediów. Wyższe wartości DPI w `PicturesCompression`, osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zwykle zwiększają rozmiar wyjścia.

Dla konwersji wsadowej:

- Niezwłocznie zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla poszczególnych zadań.
- Unikaj osadzania popularnych czcionek, chyba że wymaga tego wierność.
- Obniż DPI obrazów, gdy HTML służy podglądowi lub miniaturkom.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż do momentu ustalenia ostatecznych ścieżek wdrożeniowych.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściu HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie współdziel jednego [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) między wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [multithreading guidance](/slides/pl/net/multithreading/).

**Czy obiekt Presentation jest bezpieczny wątkowo?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) powinna być ładowana, modyfikowana, zapisywana i zwalniana na jednym wątku. Do pracy równoległej utwórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy wysokiej DPI, multimedia, zawartość SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz popularne czcionki z osadzania i obniż `PicturesCompression`, gdy mniejszy rozmiar jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki PowerPoint 24 pt pojawia się jako 17,999819 pt w HTML?**

Może to wynikać z różnych modeli DPI używanych przez PowerPoint i HTML. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Podczas eksportu prezentacji do HTML przez Aspose.Slides rozmiar czcionki jest przeliczany między tymi systemami, co może wprowadzić małe różnice zaokrągleń.

Wartości te nie wskazują na rzeczywistą zmianę wizualną rozmiaru czcionki. Są jedynie matematycznym skutkiem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak wybrać baseUri dla eksportu multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do lokalnego podglądu możesz go wyprowadzić z katalogu wyjściowego przy użyciu `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Dla wdrożenia użyj absolutnego URL opublikowanego katalogu multimediów. Ścieżka systemu plików `path` i przeglądarkowy `baseUri` nie muszą być tym samym ciągiem, ale muszą opisywać tę samą lokalizację zasobu.

**Czy mogę uwzględnić ukryte slajdy?**

Tak. Ustaw `ShowHiddenSlides = true` w [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/), gdy ukryte slajdy muszą być eksportowane.