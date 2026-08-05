---
title: Osadzanie czcionek w prezentacjach przy użyciu C++
linktitle: Osadzanie czcionki
type: docs
weight: 40
url: /pl/cpp/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcinkę
- usuń osadzoną czcionkę
- skompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for C++, zapewniając dokładne renderowanie na wszystkich platformach.
---
## **Wprowadzenie**

**Czcionki osadzone w PowerPoint** pomagają zapewnić, że Twoja prezentacja zachowuje zamierzony wygląd po otwarciu na dowolnym systemie lub urządzeniu. Jest to szczególnie ważne przy używaniu własnych, zewnętrznych lub niestandardowych czcionek w celach brandingowych lub kreatywnych. Bez osadzonych czcionek tekst może być podstawiony, układy mogą się zepsuć, a znaki mogą pojawić się jako nieczytelne symbole lub prostokąty, co obniża jakość projektu.

Aspose.Slides for C++ udostępnia zestaw potężnych interfejsów API do zarządzania osadzonymi czcionkami programowo. Możesz używać klas [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/) i [FontData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontdata/) do przeglądania, dodawania lub usuwania osadzonych czcionek w plikach prezentacji. Dodatkowo klasa [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) pozwala zoptymalizować rozmiar pliku przez kompresję danych czcionek bez wpływu na jakość lub wygląd.

Te narzędzia dają pełną kontrolę nad osadzaniem czcionek, pomagając utrzymać spójną typografię na różnych platformach, jednocześnie umożliwiając zmniejszenie rozmiaru pliku w razie potrzeby.

## **Pobieranie czcionek osadzonych z prezentacji**

Aspose.Slides for C++ udostępnia metodę `GetEmbeddedFonts` w ramach klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/), która pozwala pobrać listę czcionek osadzonych w prezentacji PowerPoint. Może to być przydatne przy audycie użycia czcionek, zapewnianiu zgodności z wytycznymi brandingowymi lub weryfikacji, że wszystkie niezbędne czcionki zostały prawidłowo dołączone przed udostępnieniem pliku.

Poniższy kod C++ demonstruje, jak uzyskać osadzone czcionki z pliku prezentacji:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Wypisz nazwy osadzonych czcionek.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Dodawanie czcionek osadzonych do prezentacji**

Aspose.Slides for C++ pozwala osadzać czcionki w prezentacji PowerPoint przy użyciu metody [AddEmbeddedFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/addembeddedfont/), która posiada dwie przeciążenia dla elastycznego użycia. Możesz kontrolować, jaka część czcionki zostanie osadzona, korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedfontcharacters/) — na przykład wybierając osadzenie tylko używanych znaków lub całego zestawu czcionki. Ta funkcja jest szczególnie przydatna przy przygotowywaniu prezentacji do udostępniania lub dystrybucji, zapewniając, że własne lub niestandardowe czcionki wyświetlą się poprawnie na wszystkich systemach, nawet jeśli nie są zainstalowane.

Poniższy kod C++ sprawdza wszystkie czcionki użyte w prezentacji i osadza te, które nie są jeszcze osadzone:

```cpp
// Załaduj plik prezentacji.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Sprawdź, czy czcionka jest już osadzona.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Osadź czcionkę w prezentacji.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Zapisz prezentację na dysku.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usuwanie czcionek osadzonych z prezentacji**

Aspose.Slides for C++ udostępnia metodę `RemoveEmbeddedFont` w ramach klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/), która umożliwia usunięcie konkretnych czcionek osadzonych w prezentacji PowerPoint. Może to pomóc zmniejszyć ogólny rozmiar pliku, szczególnie gdy osadzone czcionki nie są już używane lub potrzebne. Usunięcie nieużywanych czcionek może także poprawić wydajność i zapewnić, że prezentacja zawiera tylko niezbędne zasoby.

Poniższy kod C++ demonstruje, jak usunąć osadzoną czcionkę z prezentacji:

```cpp
auto fontName = u"Calibri";

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Pobierz wszystkie osadzone czcionki.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Usuń osadzoną czcionkę.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Kompresja czcionek osadzonych**

Aspose.Slides for C++ udostępnia metodę `CompressEmbeddedFonts` w ramach klasy [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/), pozwalającą zmniejszyć całkowity rozmiar pliku prezentacji poprzez optymalizację danych osadzonych czcionek. Jest to szczególnie przydatne, gdy prezentacja zawiera duże lub liczne czcionki i chcesz utrzymać plik lekki w celach udostępniania, przechowywania lub użycia online — bez uszczerbku dla wizualnej integralności treści.

Poniższy kod C++ pokazuje, jak skompresować osadzone czcionki w prezentacji PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jak mogę sprawdzić, że określona czcionka w prezentacji nadal będzie podstawiana podczas renderowania, pomimo osadzenia?**

Sprawdź informacje o [informacje o podstawianiu](/slides/pl/cpp/font-substitution/) w menedżerze czcionek oraz [zasady zastępowania/podstawiania](/slides/pl/cpp/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zapasowa.

**Czy warto osadzać czcionki „systemowe”, takie jak Arial/Calibri?**

Zazwyczaj nie — są one prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek), osadzenie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych podstawień.