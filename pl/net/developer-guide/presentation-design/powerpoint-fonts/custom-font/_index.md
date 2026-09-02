---
title: Dostosuj czcionki PowerPoint w .NET
linktitle: Czcionka niestandardowa
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
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla .NET, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides pozwala używać własnych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, dostarczać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są wykorzystywane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Dzięki temu wynikowa prezentacja jest spójna w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie własnych czcionek do renderowania jest odrębne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz prezentacji, należy użyć funkcji osadzania czcionek w sposób explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują tylko nazwy czcionek, nie instalują ani nie ładują plików czcionek. Zobacz [Czcionki motywu zależne od skryptu](/slides/pl/net/script-specific-font-mappings/), aby zarządzać mapowaniami, oraz użyj poniższych opcji ładowania, aby udostępnić odwołane czcionki do spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}

Aspose Slides pozwala ładować te czcionki przy użyciu metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Załaduj własne czcionki**

Aspose.Slides pozwala ładować czcionki używane w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj statyczną metodę [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/), aby załadować czcionki z tych folderów.  
3. Załaduj i renderuj/wyeksportuj prezentację.  
4. Wywołaj [FontsLoader.ClearCache](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Zdefiniuj foldery zawierające własne pliki czcionek.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Załaduj własne czcionki z określonych folderów.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderuj/wyeksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Uwaga" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.  
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.  
1. Ścieżki załadowane przez [FontsLoader](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Pobierz foldery własnych czcionek**

Aspose.Slides udostępnia metodę [GetFontFolders](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/getfontfolders/), która pozwala znaleźć foldery czcionek. Metoda zwraca foldery dodane za pomocą metody `LoadExternalFonts` oraz systemowe foldery czcionek.

Ten kod C# pokazuje, jak używać [GetFontFolders](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Ten wiersz wyświetla foldery, które są sprawdzane pod kątem plików czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Określ własne czcionki używane w prezentacji**

Aspose.Slides udostępnia właściwość [DocumentLevelFontSources](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/documentlevelfontsources/), która pozwala określić zewnętrzne czcionki, które będą używane w prezentacji.

Ten kod C# pokazuje, jak używać właściwości [DocumentLevelFontSources](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne w prezentacji
}
```

## **Zarządzaj czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [LoadExternalFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), która pozwala ładować zewnętrzne czcionki z danych binarnych.

Ten kod C# demonstruje proces ładowania czcionki z tablicy bajtów:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // zewnętrzna czcionka załadowana w trakcie życia prezentacji
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy własne czcionki są automatycznie osadzane w wynikowym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym, co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć explicite [funkcji osadzania](/slides/pl/net/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy własna czcionka nie zawiera niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/net/font-substitution/), [reguły zamiany](/slides/pl/net/font-replacement/) i [zestawy awaryjne](/slides/pl/net/fallback-font/), aby określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalowania ich systemowo?**

Tak. Wskaż własne foldery z czcionkami lub ładuj czcionki z tablic bajtów. Dzięki temu nie ma zależności od systemowych folderów czcionek w obrazie kontenera.

> **Uwaga dla Linux/Docker**: Przy wywoływaniu `FontsLoader.LoadExternalFonts` upewnij się, że każdy element tablicy `directories` zawiera niepustą ścieżkę do istniejącego katalogu. Jeśli zmienna środowiskowa używana do zbudowania ścieżki czcionki jest niezdefiniowana lub pusta, Aspose.Slides może spróbować rozwiązać pustą wartość jako pełną ścieżkę, co spowoduje `System.ArgumentException`.

**A co z licencjonowaniem — czy mogę osadzić dowolną własną czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za przestrzeganie licencji czcionki. Warunki różnią się w zależności od licencji; niektóre zakazują osadzania lub komercyjnego użycia. Zawsze zapoznaj się z EULA czcionki przed rozpowszechnianiem wyników.