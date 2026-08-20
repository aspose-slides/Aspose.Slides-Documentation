---
title: Konwertuj PPT do PPTX w C++
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/cpp/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT do PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX w C++ przy użyciu Aspose.Slides. Zawiera przykłady C++ dla konwersji pojedynczego pliku i wsadowej, obsługę błędów oraz informacje o wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for C++ może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), a następnie wywołaj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/). Zwolnij prezentację, gdy nie jest już potrzebna, aby zwolnić jej zasoby.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Załaduj starszą prezentację PPT.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Zapisz prezentację w formacie PPTX.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat::Pptx]. Utrzymuj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować oryginalny plik PPT.

## **Konwertowanie wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych w partii.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

W środowiskach produkcyjnych zapisuj pełne wyjątki, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisuj nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą powodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/cpp/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje starszych formatów**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie przedstawiają każdej funkcji w dokładnie taki sam sposób. Funkcja starszego formatu, której nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, dlatego użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Upewnij się również, że wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

Dla ważnych dokumentów ponownie otwórz wygenerowany PPTX programowo i sprawdź liczbę slajdów oraz ich zawartość, a następnie porównaj wygląd i zachowanie pokazu slajdów w docelowej aplikacji. Nie traktuj udanego wywołania [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) jako dowodu, że każda funkcja starszego formatu ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do inspekcji i odzyskania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako archiwalną lub przywracalną kopię, dopóki przekonwertowana prezentacja nie przejdzie Twoich testów wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z instrukcji specyficznych dla formatu w [Convert Presentations to Multiple Formats](/cpp/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

Dla okazjonalnego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API C++.

## **Powiązane artykuły**

- [Zapis prezentacji w C++](/cpp/save-presentation/)
- [Obsługiwane formaty plików](/cpp/supported-file-formats/)
- [Otwieranie prezentacji w C++](/cpp/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for C++ wczytuje i zapisuje pliki prezentacji bez potrzeby posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji starszej wersji lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**

Tak, pod warunkiem podania prawidłowego hasła podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Zapewnia to kopię przywracania w razie innej konwersji funkcji starszej wersji.