---
title: Konwertuj PPT do PPTX w .NET
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konwertuj starsze pliki PPT na PPTX w .NET przy użyciu Aspose.Slides. Zawiera przykłady w C# dla konwersji jednoplikowej i wsadowej, obsługę błędów oraz uwagi na temat wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for .NET może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować jeden plik lub katalog plików oraz wyjaśnia, co należy sprawdzić po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Załaduj plik źródłowy przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) . Następnie wywołaj [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Deklaracja `using` zwalnia prezentację i uwalnia jej zasoby po zakończeniu zakresu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Załaduj starszą prezentację PPT.
using var presentation = new Presentation("presentation.ppt");

// Zapisz prezentację w formacie PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Utrzymuj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwersja wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc jedna nieudana konwersja nie zatrzymuje reszty partii.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

W środowiskach produkcyjnych należy rejestrować pełny wyjątek, zdecydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisywać nazwy nieudanych plików do kolejki ponowienia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/slides/pl/net/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje przestarzałe**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w dokładnie taki sam sposób. Funkcja przestarzała, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub połączone obiekty OLE, kontrolki ActiveX, osadzone media, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z obsługą makr, gdy VBA musi pozostać dostępne. Zweryfikuj również, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym przekonwertowana prezentacja będzie otwierana lub renderowana.

W przypadku ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) jako dowodu, że każda przestarzała funkcja ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w bieżących wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako kopię archiwalną lub przywracającą, dopóki przekonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli zamiast tego potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z instrukcji specyficznych dla formatu w artykule [Convert Presentations to Multiple Formats](/slides/pl/net/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku pojedynczego pliku lub szybkiego porównania możesz skorzystać z [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API .NET.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/net/ppt-vs-pptx/)
- [Zapis prezentacji w .NET](/slides/pl/net/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/net/supported-file-formats/)
- [Otwieranie prezentacji w .NET](/slides/pl/net/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**  

Tak. Aspose.Slides for .NET wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT na PPTX zachowa całą zawartość dokładnie?**  

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji przestarzałej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, media, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**  

Tak, jeśli podasz prawidłowe hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**  

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Zapewnia to kopię przywracającą w przypadku, gdy funkcja przestarzała zostanie skonwertowana inaczej.