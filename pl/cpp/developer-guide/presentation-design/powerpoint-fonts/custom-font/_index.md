---
title: Dostosuj czcionki PowerPoint w C++
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/cpp/custom-font/
keywords:
- czcionka
- czcionka niestandardowa
- czcionka zewnętrzna
- ładowanie czcionki
- zarządzanie czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla C++, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji za pomocą źródeł czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to utrzymać spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi być przechowywana wewnątrz samej prezentacji, użyj funkcji osadzania czcionek wyraźnie.

{{% alert color="primary" %}} 
Aspose Slides umożliwia ładowanie tych czcionek przy użyciu [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) czcionki. Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez instalowania ich w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/) aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/eksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/clearcache/) aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```cpp
// Zdefiniuj foldery zawierające własne pliki czcionek.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Załaduj niestandardowe czcionki z określonych folderów.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskanie folderów czcionek**

Aspose.Slides udostępnia [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/getfontfolders/), aby umożliwić znalezienie folderów czcionek. Metoda ta zwraca foldery dodane przez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Ten kod C++ pokazuje, jak używać metody [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Ten wiersz wypisuje foldery, które są sprawdzane pod kątem plików czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Określenie własnych czcionek używanych w prezentacji**

Aspose.Slides udostępnia właściwość [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), aby umożliwić określenie czcionek zewnętrznych, które będą używane w prezentacji.

Ten kod C++ pokazuje, jak używać właściwości [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //pracuj z prezentacją
    //CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne w prezentacji
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfont/), aby umożliwić ładowanie czcionek zewnętrznych do tablicy bajtów.

Ten kod C++ demonstruje proces ładowania czcionki do tablicy bajtów:

```cpp
// Ścieżka do katalogu dokumentów
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez silnik renderujący we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć explicite [embedding features](/slides/pl/cpp/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie posiada niektórych glifów?**

Tak. Skonfiguruj [font substitution](/slides/pl/cpp/font-substitution/), [replacement rules](/slides/pl/cpp/font-replacement/) i [fallback sets](/slides/pl/cpp/fallback-font/), aby dokładnie określić, która czcionka ma być użyta, gdy brakujący glif jest żądany.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?**

Tak. Wskaż własne foldery czcionek lub załaduj czcionki z tablic bajtów. Dzięki temu nie ma zależności od katalogów czcionek systemowych w obrazie kontenera.

**A co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za zgodność z licencją czcionki. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.