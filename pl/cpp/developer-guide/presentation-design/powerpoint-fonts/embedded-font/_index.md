---
title: Osadzanie czcionek w prezentacjach przy użyciu С++
linktitle: Osadzanie czcionki
type: docs
weight: 40
url: /pl/cpp/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- skompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- С++
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla С++, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

**Osadzone czcionki w PowerPoint** pomagają zapewnić, że prezentacja zachowuje zamierzony wygląd po otwarciu na dowolnym systemie lub urządzeniu. Jest to szczególnie ważne przy używaniu własnych, zewnętrznych lub niestandardowych czcionek w celach brandingowych lub kreatywnych. Bez osadzonych czcionek tekst może być zastąpiony, układy mogą się popsuć, a znaki mogą wyświetlać się jako nieczytelne symbole lub prostokąty, co osłabia ogólny projekt.

Aspose.Slides for C++ udostępnia zestaw potężnych interfejsów API do zarządzania osadzonymi czcionkami programowo. Możesz używać klas [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/) i [FontData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontdata/) do przeglądania, dodawania lub usuwania osadzonych czcionek w plikach prezentacji. Dodatkowo klasa [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) pozwala zoptymalizować rozmiar pliku, kompresując dane czcionek bez wpływu na jakość ani wygląd.

Te narzędzia dają pełną kontrolę nad osadzaniem czcionek, pomagając utrzymać spójną typografię na różnych platformach, jednocześnie redukując rozmiar pliku w razie potrzeby.

## **Pobieranie osadzonych czcionek z prezentacji**

Aspose.Slides for C++ udostępnia metodę `GetEmbeddedFonts` za pośrednictwem klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/), która pozwala pobrać listę czcionek osadzonych w prezentacji PowerPoint. Może to być przydatne przy audycie użycia czcionek, zapewnianiu zgodności z wytycznymi brandingu lub weryfikacji, że wszystkie niezbędne czcionki zostały poprawnie dołączone przed udostępnieniem pliku.

Poniższy kod C++ pokazuje, jak pobrać osadzone czcionki z pliku prezentacji:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Pobierz wszystkie osadzone czcionki.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Wyświetl nazwy osadzonych czcionek.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Dodawanie osadzonych czcionek do prezentacji**

Aspose.Slides for C++ umożliwia osadzanie czcionek w prezentacji PowerPoint przy użyciu metody [AddEmbeddedFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/addembeddedfont/), która posiada dwa przeciążenia dla elastycznego użycia. Możesz kontrolować, jaka część czcionki jest osadzona, korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedfontcharacters/) — na przykład wybierając osadzenie tylko używanych znaków lub całego zestawu czcionek. Ta funkcja jest szczególnie przydatna przy przygotowywaniu prezentacji do udostępniania lub dystrybucji, zapewniając, że własne lub niestandardowe czcionki wyświetlają się prawidłowo na wszystkich systemach, nawet jeśli nie są zainstalowane.

Poniższy kod C++ sprawdza wszystkie czcionki użyte w prezentacji i osadza te, które nie zostały jeszcze osadzone.

```cpp
// Wczytaj plik prezentacji.
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

## **Usuwanie osadzonych czcionek z prezentacji**

Aspose.Slides for C++ udostępnia metodę `RemoveEmbeddedFont` za pośrednictwem klasy [FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/), co pozwala usunąć określone czcionki osadzone w prezentacji PowerPoint. Może to pomóc zmniejszyć ogólny rozmiar pliku, zwłaszcza jeśli osadzone czcionki nie są już używane lub potrzebne. Usunięcie nieużywanych czcionek może również poprawić wydajność i zapewnić, że prezentacja zawiera tylko niezbędne zasoby.

Poniższy kod C++ pokazuje, jak usunąć osadzoną czcionkę z prezentacji:

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

## **Kompresja osadzonych czcionek**

Aspose.Slides for C++ udostępnia metodę `CompressEmbeddedFonts` za pośrednictwem klasy [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/), co pozwala zmniejszyć ogólny rozmiar pliku prezentacji poprzez optymalizację danych osadzonych czcionek. Jest to szczególnie przydatne, gdy prezentacja zawiera duże lub liczne czcionki i chcesz utrzymać plik lekki w celu udostępniania, przechowywania lub użycia online — bez uszczerbku na wizualnej jakości treści.

Poniższy kod C++ pokazuje, jak skompresować osadzone czcionki w prezentacji PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jak mogę sprawdzić, że konkretna czcionka w prezentacji zostanie nadal zastąpiona podczas renderowania mimo osadzenia?**

Sprawdź informacje o [substitution information](/slides/pl/cpp/font-substitution/) w menedżerze czcionek i [fallback/substitution rules](/slides/pl/cpp/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zastępcza.

**Czy warto osadzać czcionki systemowe, takie jak Arial/Calibri?**

Zazwyczaj nie — są prawie zawsze dostępne. Jednak przy pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych podstawień.