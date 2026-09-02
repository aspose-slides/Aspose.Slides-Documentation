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
description: "Konwertuj starsze pliki PPT do PPTX w C++ przy użyciu Aspose.Slides. Zawiera przykłady C++ dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX jest nowszym formatem Open XML. Aspose.Slides for C++ może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertuj plik PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), a następnie wywołaj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/). Zwolnij prezentację, gdy nie jest już potrzebna, aby zwolnić jej zasoby.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; argument [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/) decyduje o tym. Utrzymuj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych.

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

W środowiskach produkcyjnych loguj pełne wyjątki, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisz nazwy nieudanych plików do kolejki ponownych prób lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwarte bez wymaganego hasła, niedostępne ścieżki i nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/slides/pl/cpp/password-protected-presentation/) w celu wczytywania zaszyfrowanych plików.

## **Wierność i funkcje dziedziczone**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w dokładnie ten sam sposób. Funkcja dziedziczona, której nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadko używane czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

W przypadku ważnych dokumentów otwórz ponownie wygenerowany plik PPTX programowo i sprawdź liczbę slajdów oraz kluczową zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) jako dowodu, że każda funkcja dziedziczona ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako archiwalną lub backupową kopię, dopóki przekonwertowana prezentacja nie przejdzie twoich testów wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego formatu wyjściowego, skorzystaj z zaleceń specyficznych dla formatów w artykule [Convert Presentations to Multiple Formats](/slides/pl/cpp/convert-presentation/) zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

Do okazjonalnego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do regularnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API C++.

## **Powiązane artykuły**

- [Zapisz prezentacje w C++](/slides/pl/cpp/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/cpp/supported-file-formats/)
- [Otwórz prezentacje w C++](/slides/pl/cpp/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for C++ ładuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji dziedziczonej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadko używane czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**

Tak, pod warunkiem podania prawidłowego hasła podczas ładowania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji ładowania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz pliku PPTX w przeglądarkach i procesach, które są dla Ciebie istotne. To zapewnia kopię zapasową na wypadek, gdyby funkcja dziedziczona została przekonwertowana inaczej.