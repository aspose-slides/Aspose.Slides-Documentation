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
description: "Dostosuj czcionki w slajdach PowerPoint za pomocą Aspose.Slides dla C++, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia użycie własnych czcionek w prezentacjach bez instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, dostarczać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to utrzymać spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie własnych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi być przechowywana wewnątrz samej prezentacji, użyj funkcji osadzania czcionek w sposób explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Script-Specific Theme Fonts](/slides/pl/cpp/script-specific-font-mappings/), aby zarządzać mapowaniami, i użyj opcji ładowania poniżej, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}

Aspose Slides umożliwia ładowanie tych czcionek przy użyciu [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Czcionki TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides pozwala ładować czcionki używane w prezentacji bez instalowania ich w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj statyczną metodę [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/), aby załadować czcionki z tych folderów.  
3. Załaduj i wyrenderuj/wyeksportuj prezentację.  
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Zdefiniuj foldery, które zawierają niestandardowe pliki czcionek.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Załaduj własne czcionki z określonych folderów.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderuj/wyeksportuj prezentację (np. do PDF, obrazów lub innych formatów) przy użyciu załadowanych czcionek.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Uwaga" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek. Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.  
1. Ścieżki załadowane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskaj foldery własnych czcionek**
Aspose.Slides udostępnia [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/getfontfolders/), aby umożliwić odnalezienie folderów czcionek. Metoda ta zwraca foldery dodane przez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Ten kod C++ pokazuje, jak używać metody [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/getfontfolders/):

```cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Ten wiersz wypisuje foldery, które są sprawdzane pod kątem plików czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Określ własne czcionki używane w prezentacji**
Aspose.Slides udostępnia właściwość [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), aby umożliwić określenie zewnętrznych czcionek, które będą używane w prezentacji.

Ten kod C++ pokazuje, jak używać właściwości [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //pracuj z prezentacją
    //CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne dla prezentacji
}
```

## **Zarządzaj czcionkami zewnętrznie**
Aspose.Slides udostępnia metodę [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfont/), aby umożliwić ładowanie zewnętrznych czcionek do tablicy bajtów.

Ten kod C++ demonstruje proces ładowania czcionki do tablicy bajtów:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy własne czcionki są automatycznie osadzane w powstałym pliku PPTX?

Nie. Rejestracja czcionki do renderowania nie jest tym samym co osadzenie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć explicite [funkcji osadzania](/slides/pl/cpp/embedded-font/).

### Czy mogę kontrolować zachowanie awaryjne, gdy własna czcionka nie zawiera niektórych glifów?

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/cpp/font-substitution/), [reguły zamiany](/slides/pl/cpp/font-replacement/) i [zestawy awaryjne](/slides/pl/cpp/fallback-font/), aby określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Usuwa to zależność od systemowych katalogów czcionek w obrazie kontenera.

### Co z licencjonowaniem — czy mogę osadzić dowolną własną czcionkę bez ograniczeń?

Jesteś odpowiedzialny za zgodność licencyjną czcionek. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj umowę licencyjną czcionki (EULA) przed dystrybucją wyników.