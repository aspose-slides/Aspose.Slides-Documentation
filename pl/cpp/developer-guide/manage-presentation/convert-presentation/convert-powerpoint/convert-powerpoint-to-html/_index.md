---
title: Konwertuj prezentacje PowerPoint do HTML w C++
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu HTML w C++. Użyj Aspose.Slides, aby eksportować pliki PPT i PPTX, wybrane slajdy, notatki, czcionki, obrazy, SVG i multimedia."
---
## **Przegląd**

Aspose.Slides for C++ może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja to jednorazowe wczytanie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i wywołanie `Save` z [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/) gdy potrzebujesz kontrolować układ, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten poradnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksportuj całą prezentację lub wybrane slajdy.
- Generuj HTML o stałym układzie, responsywny lub oparty na SVG.
- Dołącz notatki prelegenta i komentarze.
- Kontroluj jakość obrazu i przycięte dane obrazu.
- Osadź czcionki lub zapisz pliki czcionek osobno.
- Wybierz sposób zapisu i odniesień do zasobów zewnętrznych oraz plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ zasoby zewnętrzne, niższe DPI obrazów i osadzanie tylko czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwersja prezentacji do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją przy użyciu [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i zapisz przy pomocy `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Ten przykład zapisuje jeden plik HTML. Wywołanie `Dispose` zwalnia uchwyty plików i zasoby renderowania po eksporcie.

## **Użycie HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/) jest główną klasą konfiguracyjną dla eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały pomocnicze lub inne informacje o układzie.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, np. jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazu.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `ShowHiddenSlides`: uwzględnia ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje pokazują najczęstsze opcje osobno, abyś mógł połączyć tylko te, które są potrzebne w twoim procesie.

## **Konwersja wybranych slajdów do HTML**

Przeciążenie `Presentation::Save`, które przyjmuje numery slajdów, używa pozycji slajdów numerowanych od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/) i przekaż ją do każdego wywołania `Save`.

## **Tworzenie responsywnego HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/responsivehtmlcontroller/) zapewnia responsywny wynik HTML za pośrednictwem [HtmlFormatter](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Aby uzyskać responsywny układ oparty na SVG, ustaw `SvgResponsiveLayout` w [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/). Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Dołączanie notatek prelegenta i komentarzy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/) przez `HtmlOptions.SlidesLayoutOptions`, aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich położenie.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje zawartość slajdu z notatkami prelegenta pod slajdem.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Wyeksportowany HTML zawiera obszar notatek:

![Wyjście HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, na przykład na `CommentsPositions::Right` lub `CommentsPositions::Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw oba właściwości.

## **Kontrola jakości obrazu i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/picturescompression/), gdy potrzebna jest wyższa jakość obrazu.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyniku. Zachowaj przycięte dane tylko wtedy, gdy użytkownicy muszą mieć możliwość odzyskania lub sprawdzenia ukrytych części obrazu. Zachowanie ich może zwiększyć rozmiar HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Dodawanie CSS**

Do prostej stylizacji przekaż ciąg CSS do `HtmlFormatter::CreateDocumentFormatter`. Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Aby uzyskać własny nagłówek dokumentu, powiązany plik CSS lub własny znacznik wokół slajdów i kształtów, zaimplementuj [IHtmlFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ihtmlformattingcontroller/) i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmlformatter/) przy użyciu `CreateCustomFormatter`.

## **Osadzanie czcionek**

Jeśli docelowe środowisko może nie mieć zainstalowanych czcionek użytych w prezentacji, osadź czcionki w HTML przy użyciu [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Wyklucz czcionki tylko wtedy, gdy masz pewność, że docelowe przeglądarki lub systemy już je udostępniają. Dla czcionek firmowych lub mniej popularnych osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkowanie plików czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek do osobnych plików WOFF i dodać reguły `@font-face` do HTML. Poniższy pomocnik rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedallfontshtmlcontroller/) i nadpisuje `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

W tym przykładzie pliki czcionek są zapisywane w `html-output/fonts`, a HTML odwołuje się do nich za pomocą URL, takich jak `fonts/BrandFont-normal-400.woff`. Jeśli plik HTML i czcionki są wdrażane w innym miejscu, wybierz `fontUrlPrefix`, aby pasował do ścieżki URL po wdrożeniu.

## **Zewnętrzne zapisywanie zasobów**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą zwiększyć rozmiar pliku. Jeśli aplikacja wymaga zewnętrznych plików obrazów, zaimplementuj [ILinkEmbedController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/) i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/).

Podczas eksternizacji zasobów dobierz dwa ścieżki starannie:

- Ścieżka wyjściowa systemu plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, której używa przeglądarka z dokumentu HTML do ładowania tych plików.

## **Eksport plików multimedialnych**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz zapisuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w odnośnikach HTML do plików multimedialnych.

Jeśli plik HTML to `html-output/presentation.html`, a pliki multimedialne są zapisywane w `html-output/media`, `path` powinien wskazywać katalog mediów na dysku, natomiast `baseUri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Do podglądu lokalnego możesz zbudować URI `file:///` z katalogu mediów. Dla wdrożonej aplikacji użyj absolutnego URL opublikowanego katalogu mediów.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML to operacja renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI w `PicturesCompression`, osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Dla konwersji wsadowej:

- Szybko zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla oddzielnych zadań.
- Unikaj osadzania powszechnych czcionek, chyba że wymagana jest wierność.
- Obniż DPI obrazu, gdy HTML ma służyć podglądowi lub miniaturkom.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż do ustalenia ostatecznych ścieżek wdrożenia.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściu HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie udostępniaj jednej instancji [Presentation] między wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [przewodnik po wielowątkowości](/slides/pl/cpp/multithreading/) po szczegóły.

**Czy obiekt Presentation jest bezpieczny wątkowo?**

Nie. Jedna instancja [Presentation] powinna być ładowana, modyfikowana, zapisywana i zwalniana w jednym wątku. Do pracy równoległej utwórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokim DPI, media, zawartość SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz powszechne czcionki z osadzania i obniż `PicturesCompression`, gdy mniejszy rozmiar wyjścia jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki PowerPoint, np. 24 pt, pojawia się jako 17,999819 pt w HTML?**

Może to wynikać z faktu, że PowerPoint i HTML używają różnych modeli DPI. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Gdy Aspose.Slides eksportuje prezentację do HTML, rozmiar czcionki jest przeliczany między tymi systemami i konwersja może wprowadzić niewielkie różnice zaokrąglenia.

Te wartości nie oznaczają rzeczywistej zmiany widzialnego rozmiaru czcionki. Są jedynie matematycznym skutkiem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak wybrać baseUri dla eksportu multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz uzyskać go z katalogu wyjściowego przy pomocy `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Dla wdrożenia użyj absolutnego URL opublikowanego katalogu multimediów. Ścieżka systemu plików `path` i `baseUri` przeglądarki nie muszą być tym samym ciągiem, ale muszą opisywać to samo miejsce zasobu.

**Czy mogę uwzględnić ukryte slajdy?**

Tak. Ustaw `ShowHiddenSlides` na `true` w [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/), gdy ukryte slajdy muszą być eksportowane.