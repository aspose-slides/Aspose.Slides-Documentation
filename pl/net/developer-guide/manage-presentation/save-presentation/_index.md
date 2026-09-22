---
title: Zapisywanie prezentacji w .NET
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/net/save-presentation/
keywords:
- zapisz PowerPoint
- zapisz OpenDocument
- zapisz prezentację
- zapisz slajd
- zapisz PPT
- zapisz PPTX
- zapisz ODP
- prezentacja do pliku
- prezentacja do strumienia
- predefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- .NET
- C#
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w C# przy użyciu Aspose.Slides dla .NET oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/net/open-presentation/), użyj metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), aby zapisać wynik. Aspose.Slides for .NET może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisywania oraz dostępne opcje wyjścia PPTX.

## **Zapisz prezentacje do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/) do metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/). Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation;

// Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Zapisz prezentacje w ich oryginalnym formacie**

Przykłady wykrywania plików i strumieni, zachowania nowo tworzonych prezentacji oraz rozróżnienia między formatami źródłowymi i wyjściowymi znajdziesz w artykule [Determine the Original Presentation Format](/slides/pl/net/detect-presentation-source-format/).

W aplikacji przetwarzającej wsadowo format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego oryginalny format z właściwości [IPresentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/sourceformat/). Przekaż uzyskaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/sourceformat/) do [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/tosaveformat/), aby otrzymać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/), a następnie użyj [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/tosaveformat/) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na odpowiadające formaty zapisu prezentacji. Mapuje tylko formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu, takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/sourceformat/) powoduje zgłoszenie [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja jest ładowana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli konieczne jest zachowanie tych starszych podtypów, należy zachować oryginalną nazwę pliku lub metadane formatu osobno i wykorzystać je przy wyborze nazwy i formatu pliku wyjściowego.

## **Zapisz prezentacje do strumieni**

Aby zapisać prezentację bez korzystania z ostatecznej ścieżki pliku, przekaż zapisywalny [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/) do metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/). Takie podejście jest przydatne, gdy wynik musi zostać zwrócony z usługi sieciowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia plikowego:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Zapisz prezentacje z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisaną prezentację. Ustaw właściwość [ViewProperties.LastView](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/lastview/) na wartość [ViewType](https://reference.aspose.com/slides/pl/net/aspose.slides/viewtype/) przed zapisaniem.

Poniższy przykład konfiguruje widok Slide Master jako początkowy widok:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny ze ścisłym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/) i ustaw jej właściwość [Conformance](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/conformance/) na `Conformance.Iso29500_2008_Strict`. Następnie przekaż te opcje do metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza skompresowany i nieskompresowany rozmiar każdego wpisu, całkowity rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą odpowiednie limity rozmiaru i liczby wpisów.

Użyj właściwości [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/zip64mode/), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- `IfNecessary` używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To domyślny tryb.
- `Never` wyłącza rozszerzenia ZIP64.
- `Always` zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Jeśli `Zip64Mode` jest ustawiony na `Never` i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zrównoważyć szybkość zapisu z rozmiarem pliku, ustawiając właściwość [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/compressionlevel/). Wyliczenie [CompressionLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.export/compressionlevel/) zawiera następujące wartości:

- `None` zapisuje dane bez kompresji.
- `Level1` zapewnia najszybszą kompresję i największy skompresowany wynik.
- `Level2` do `Level5` stopniowo preferują mniejszy rozmiar wyjścia kosztem szybkości zapisu.
- `Level6` równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.
- `Level7` i `Level8` jeszcze bardziej preferują mniejszy rozmiar kosztem szybkości.
- `Level9` zapewnia najmocniejszą kompresję i wymaga najwięcej czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Zapisz prezentacje bez odświeżania miniatury**

Gdy prezentacja jest zapisywana jako PPTX, właściwość [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/refreshthumbnail/) kontroluje miniaturę dokumentu:

- `true` odtwarza miniaturę podczas operacji zapisu. To domyślna wartość.
- `false` zachowuje istniejącą miniaturę. Jeśli prezentacja nie ma miniatury, Aspose.Slides nie generuje jej.

Poniższy przykład zapisuje prezentację bez odświeżania jej miniatury:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniatury może skrócić czas zapisu pliku PPTX.
{{% /alert %}}

## **Zapisuj aktualizacje postępu w procentach**

Aby monitorować operację zapisu, zaimplementuj interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/) i przypisz implementację do właściwości [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides wywoła wtedy metodę [IProgressCallback.Reporting](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/reporting/) z wartościami postępu podczas eksportu.

Poniższy przykład raportuje postęp eksportu PDF w konsoli:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose udostępnia bezpłatny [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) zbudowany przy użyciu API Aspose.Slides. Zapisuje wybrane slajdy z prezentacji jako osobne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapisy przyrostowe lub „szybkie zapisy”?**

Nie. Każda operacja zapisu zapisuje pełny plik wyjściowy, a nie aktualizuje tylko zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) nie jest [thread-safe](/slides/pl/net/multithreading/). Dostęp i zapis każdej instancji powinien odbywać się z jednego wątku w danym czasie.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami po zapisaniu prezentacji?**

[Hyperlinki](/slides/pl/net/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje zewnętrznie powiązanych plików, więc zapisana prezentacja musi wciąż mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [właściwości dokumentu](/slides/pl/net/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.