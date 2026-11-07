---
title: Dostosuj czcionki PowerPoint w .NET
linktitle: Własna czcionka
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

Aspose.Slides pozwala używać własnych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Można ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójny wygląd prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides i jak wyczyścić pamięć podręczną czcionek po pracy ze zewnętrznymi czcionkami.

Rejestrowanie własnych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz samej prezentacji, należy używać funkcji osadzania czcionek explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Czcionki tematyczne specyficzne dla skryptu](/slides/pl/net/script-specific-font-mappings/), aby zarządzać mapowaniami, i użyj poniższych opcji ładowania, aby udostępnić odwoływane czcionki do spójnego renderowania.

{{% alert color="info" title="Note" %}}

Aspose Slides pozwala ładować te czcionki przy użyciu metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) i kolekcje TrueType (.ttc) czcionki. Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) czcionki. Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides pozwala ładować czcionki używane w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/eksportuj prezentację.
4. Wywołaj metodę [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Zdefiniuj foldery zawierające własne pliki czcionek.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Załaduj własne czcionki z określonych folderów.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Pobierz własne foldery czcionek**
Aspose.Slides udostępnia metodę [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), aby umożliwić znalezienie folderów czcionek. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod C# pokazuje, jak używać [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Ten wiersz wyświetla foldery sprawdzane pod kątem plików czcionek.
// Są to foldery dodane za pośrednictwem metody LoadExternalFonts oraz systemowe foldery czcionek.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Określ własne czcionki używane w prezentacji**
Aspose.Slides udostępnia właściwość [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), aby umożliwić określenie zewnętrznych czcionek, które będą używane w prezentacji.

Poniższy kod C# pokazuje, jak używać właściwości [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

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

Aspose.Slides udostępnia metodę [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), aby umożliwić ładowanie zewnętrznych czcionek z danych binarnych.

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
        // zewnętrzna czcionka załadowana podczas życia prezentacji
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Aby pozwolić zarejestrowanej czcionce o dopasowaniu mieć pierwszeństwo podczas eksportu bez usuwania osadzonej czcionki, zobacz [Prefer Registered Fonts over Embedded Fonts](/slides/pl/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 lub później).

## **FAQ**

**Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy własne czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz używać explicite [funkcji osadzania](/slides/pl/net/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy własna czcionka nie zawiera niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/net/font-substitution/), [reguły zamiany](/slides/pl/net/font-replacement/) i [zestawy awaryjne](/slides/pl/net/fallback-font/), aby dokładnie określić, która czcionka jest używana, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalowania ich systemowo?**

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Dzięki temu nie ma zależności od systemowych katalogów czcionek w obrazie kontenera.

> **Uwaga dla Linux/Docker**: Podczas wywoływania `FontsLoader.LoadExternalFonts` upewnij się, że każdy element w tablicy `directories` zawiera niepustą ścieżkę do istniejącego katalogu. Jeśli zmienna środowiskowa użyta do skonstruowania ścieżki czcionki jest niezdefiniowana lub pusta, Aspose.Slides może próbować rozwiązać pustą wartość jako pełną ścieżkę, co skutkuje `System.ArgumentException`.

**Co z licencjonowaniem — czy mogę osadzać dowolną własną czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za zgodność z licencją czcionki. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze przeglądaj EULA czcionki przed dystrybucją wyników.