---
title: Eksportowanie prezentacji do XAML w .NET
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/net/export-to-xaml/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- konwersja PowerPoint
- konwersja OpenDocument
- konwersja prezentacji
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksport PPT do XAML
- eksport PPTX do XAML
- eksport ODP do XAML
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w .NET przy użyciu Aspose.Slides — szybkie, niezależne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/), w tym eksport ukrytych slajdów. Artykuł odpowiada także na kilka często zadawanych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML i zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML jest językiem znaczników opartym na XML, używanym do opisywania interfejsów użytkownika w frameworkach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) i Xamarin.Forms.

Można pracować z plikami XAML w wizualnym projektancie lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z ustawieniami domyślnymi**

Poniższy przykład w C# pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego procesu, zwracanego przez [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Folder jest tworzony automatycznie, a wszelkie wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla `pres.pptx` pliki wyjściowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli przekażesz bezwzględną ścieżkę do prezentacji wejściowej, folder wyjściowy zostanie utworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloptions/), aby kontrolować sposób, w jaki Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, zaimplementuj [IXamlOutputSaver](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloutputsaver/) i przypisz instancję swojej implementacji do właściwości [OutputSaver](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/outputsaver/) klasy [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/).

Aby uwzględnić ukryte slajdy w wyniku XAML, ustaw właściwość [ExportHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) na `true`, jak pokazano w poniższym przykładzie w C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Zbierz wszystkie wygenerowane artefakty XAML**

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz własny [IXamlOutputSaver](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloutputsaver/) do [XamlOptions.OutputSaver](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/outputsaver/), aby otrzymać te artefakty zamiast domyślnego zapisu do systemu plików. Rozpocznij eksport przy użyciu przeciążenia [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), które przyjmuje opcje XAML.

### **Zrozum cykl życia wywołań zwrotnych**

Eksporter wywołuje [IXamlOutputSaver.Save](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloutputsaver/save/) oddzielnie dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu względnych ścieżek.
- `data` zawiera bajty artefaktu. Obrazy i inne binarne zasoby nie powinny być dekodowane jako tekst.
- Zapisywacz jest odpowiedzialny za zachowanie lub utrwalenie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów do pamięci kontrolowanej przez aplikację.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zwróci wynik i każdy wywołanie zwrotne zakończy się pomyślnie. Nie tłumacz błędów przechowywania ani nie rozpoczynaj nieobserwowanych zapisu w tle. Jeśli utrwalenie nastąpi później, zgłoś sukces ogólny dopiero po pomyślnym zakończeniu tego kroku.

[​XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) ma również zastosowanie do własnego zapisywacza. Jego domyślna wartość, `false`, wyklucza dokumenty XAML ukrytych slajdów. Ustawienie jej na `true` powoduje ich dołączenie oraz wszystkich zasobów niezbędnych do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, zbiera każdy artefakt w [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje dokładnie podane nazwy. Powielone nazwy powodują niepowodzenie kolekcji zamiast cichego nadpisania artefaktu.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest tekstowa inspekcja.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Wywołaj `InMemoryXamlExample.Run` z aplikacji. Kontrole rozszerzeń są przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy ich przechowywaniu lub transmisji. Używaj [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) wyłącznie dla XAML, które wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten niezależny przykład zbiera eksport, waliduje nazwy i zapisuje oryginalne bajty w archiwum ZIP. Unikalna nazwa archiwum rozdziela równoczesne zadania eksportu. Wpisy ZIP używają ukośników i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed jego zapisem.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Katalog ZIP został sfinalizowany po zwolnieniu zasobów przed zgłoszeniem powodzenia.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Wywołaj `ZipXamlExample.Run` z aplikacji. Przykład używa [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) do zapisania jednego lokalnego archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. Dla zdalnego przechowywania zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob lub przechowuj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesłań lub po zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli utrwalenie się nie powiedzie.

Dla dużych prezentacji własny zapisywacz może utrwalać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć przechowywania dodatkowej kopii całego eksportu w pamięci aplikacji. Eksporter nadal zbiera wszystkie wygenerowane artefakty w pamięci przed wywołaniem zapisywacza. Traktuj każde wywołanie zwrotne jako synchroniczne z perspektywy eksporter: zwróć jedynie po zaakceptowaniu bajtów przez docelowy system i pozwól, aby błędy docierały do wywołującego.

### **Zachowaj nazwy zasobów i zweryfikuj odwołania**

- Normalizuj separatory ścieżek, gdy docelowy system tego wymaga, ale zachowuj katalogi względne. Nie używaj wyłącznie [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename), chyba że każdy wygenerowany wpis jest znany jako unikalny i odwołania do zasobów pozostają poprawne.
- Zastosuj walidację nazw specyficzną dla miejsca docelowego. Przy zapisie luźnych plików odrzucaj ścieżki bezwzględne i segmenty traversujące, rozwiąż docelową ścieżkę przy użyciu [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) i sprawdź, czy pozostaje pod zamierzonym katalogiem eksportu, włączając separator katalogu w kontroli przynależności. Używaj kontrolowanego przez aplikację katalogu bez linków symbolicznych, które mogłyby przekierować zapisy.
- Używaj oddzielnego zapisywacza i przestrzeni nazw przechowywania dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatorów i zgodnie z zasadami rozróżniania wielkości znaków w miejscu docelowym.
- Przed publikacją przeanalizuj każdy dokument XAML jako XML i sprawdź odwołania do zasobów opartych na plikach, takie jak atrybuty `Source` lub `ImageSource` obrazów. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj wynikową nazwę przechowywania i potwierdź, że odpowiadający klucz słownika, wpis ZIP lub przechowywany obiekt istnieje. Traktuj zewnętrzne URI i wyrażenia markup XAML osobno od nazw plików względnych.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie jedynie `image1.png` przerwałoby tę zależność. Dla przechowywania obiektowego zachowaj taką samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie ukończony ZIP, aby zweryfikować nazwy wpisów i bajty zasobów, oraz wczytaj reprezentatywne slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozwiązywanie obrazów.

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na maszynie?**

Ustaw [DefaultRegularFont](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/defaultregularfont/) w [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/) — jest on używany jako czcionka zapasowa podczas eksportu, gdy oryginalna czcionka jest brakująca. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki zapasowej lub że czcionka będzie dostępna na docelowej maszynie. Upewnij się, że czcionki odwoływane przez XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF poprzez publiczne API. Kompatybilność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są włączone. Możesz kontrolować to zachowanie za pomocą [ExportHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/) — pozostaw tę opcję wyłączoną, jeśli nie potrzebujesz ich eksportować.