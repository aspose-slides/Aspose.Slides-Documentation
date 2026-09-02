---
title: Dostosuj czcionki PowerPoint w .NET
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint za pomocą Aspose.Slides dla .NET, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia użycie niestandardowych czcionek w prezentacjach bez ich instalacji w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, dostarczać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyników prezentacji w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz samej prezentacji, należy użyć funkcji osadzania czcionek.

{{% alert color="primary" %}} 

Aspose Slides umożliwia ładowanie tych czcionek przy użyciu metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie niestandardowych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez ich instalacji w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc otrzymane dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/eksportuj prezentację.
4. Wywołaj [FontsLoader.ClearCache](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Załaduj niestandardowe czcionki z określonych folderów.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek. Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskiwanie niestandardowych folderów czcionek**
Aspose.Slides udostępnia metodę [GetFontFolders](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/getfontfolders/), aby umożliwić znalezienie folderów czcionek. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod C# pokazuje, jak używać [GetFontFolders](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Ta linia wyświetla foldery, które są sprawdzane pod kątem plików czcionek.
// Są to foldery dodane poprzez metodę LoadExternalFonts oraz systemowe foldery czcionek.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Określanie niestandardowych czcionek używanych w prezentacji**
Aspose.Slides udostępnia właściwość [DocumentLevelFontSources](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/documentlevelfontsources/), aby umożliwić określenie zewnętrznych czcionek, które będą używane w prezentacji.

Poniższy kod C# pokazuje, jak używać właściwości [DocumentLevelFontSources](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Pracuj z prezentacją
    // CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne dla prezentacji
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [LoadExternalFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), aby umożliwić ładowanie zewnętrznych czcionek z danych binarnych.

Poniższy kod C# demonstruje proces ładowania czcionki z tablicy bajtów:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // zewnętrzna czcionka załadowana podczas działania prezentacji
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Powiązane czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w wygenerowanym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co jej osadzenie w PPTX. Jeśli potrzebujesz, aby czcionka była zawarta wewnątrz pliku prezentacji, musisz użyć explicite [embedding features](/slides/pl/net/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie zawiera niektórych glifów?**

Tak. Skonfiguruj [font substitution](/slides/pl/net/font-substitution/), [replacement rules](/slides/pl/net/font-replacement/) i [fallback sets](/slides/pl/net/fallback-font/), aby dokładnie określić, która czcionka zostanie użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji ich systemowo?**

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Usuwa to zależność od systemowych katalogów czcionek w obrazie kontenera.

> **Uwaga dla Linux/Docker**: Podczas wywoływania `FontsLoader.LoadExternalFonts` upewnij się, że każdy element w tablicy `directories` zawiera niepustą ścieżkę do istniejącego katalogu. Jeśli zmienna środowiskowa użyta do zbudowania ścieżki czcionki jest niezdefiniowana lub pusta, Aspose.Slides może próbować rozwiązać pustą wartość jako pełną ścieżkę, co skutkuje `System.ArgumentException`.

**Co z licencjonowaniem—czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za zgodność z licencjami czcionek. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.