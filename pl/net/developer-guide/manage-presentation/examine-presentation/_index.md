---
title: Pobieranie i aktualizacja informacji o prezentacji w .NET
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/net/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczytywanie właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- badanie PPTX
- badanie PPT
- badanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu .NET, aby szybciej uzyskać wgląd i inteligentniej audytować zawartość."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, tworzyć inwentaryzację lub sprawdzać właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekkie sprawdzanie za pomocą [PresentationFactory](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/) i [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/), a także ukierunkowane aktualizacje za pomocą [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/) aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Właściwość [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/loadformat/) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Utwórz lekką inwentaryzację prezentacji**

Podczas przetwarzania wielu plików prezentacji możesz potrzebować zwartej inwentaryzacji do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/) aby uzyskać obiekt [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/), a następnie wywołaj [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/) zapewniają następujące wartości inwentaryzacji:

| Właściwość | Wartość inwentaryzacji |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/slides/pl/) | Łączna liczba slajdów. |
| [HiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/hiddenslides/) | Liczba ukrytych slajdów. |
| [Notes](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/notes/) | Liczba slajdów zawierających notatki. |
| [Paragraphs](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/paragraphs/) | Łączna liczba akapitów, jeśli dostępna. |
| [Words](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/words/) | Łączna liczba słów. |
| [MultimediaClips](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/multimediaclips/) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i drukuje zwartą inwentaryzację. Łączy również [HeadingPairs](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/headingpairs/) z [TitlesOfParts](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/titlesofparts/), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Każdy [IHeadingPair](https://reference.aspose.com/slides/pl/net/aspose.slides/iheadingpair/) dostarcza nazwę grupy i liczbę elementów w tej grupie. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/titlesofparts/) jest płaską, uporządkowaną tablicą, więc pobieraj liczbę kolejnych tytułów określoną przez każdy nagłówek.

### **Przechowywane metadane i ograniczenia formatu**

Właściwości inwentaryzacji zwracane przez [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości dla tego wywołania. Brakujące właściwości są reprezentowane przez wartości domyślne, a przechowywane wartości mogą być przestarzałe, jeśli aplikacja, która ostatnio zapisała plik, nie zaktualizowała ich właściwości dokumentu.

- **PPTX:** Format zapewnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej przechowywaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują się na wszystkie właściwości rozszerzone specyficzne dla PowerPointa. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie traktuj zerowej wartości ani pustej tablicy jako ostatecznego dowodu na brak odpowiadającej zawartości.

Używaj lekkiego podejścia opartego na metadanych do inwentaryzacji i wstępnych kontroli. Ładuj prezentację i analizuj jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy konieczne jest zweryfikowanie rzeczywistej zawartości prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Zastosuj zmiany przy użyciu [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), a następnie zapisz powiązaną prezentację przy użyciu [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Poniższy obraz przedstawia oryginalne właściwości dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

Poniższy przykład zmienia tytuł i czas ostatniego zapisu oraz zapisuje wynik do nowego pliku:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Poniższy obraz przedstawia zaktualizowane właściwości dokumentu.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Przydatne linki**

Aby uzyskać informacje o powiązanych sprawdzaniach bezpieczeństwa i ustawieniach ochrony, zobacz następujące artykuły:

- [Password-Protect Presentations](/slides/pl/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pl/net/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i jakie to są czcionki?**

Załaduj prezentację i użyj [Presentation.FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/). Wywołaj [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts/), aby uzyskać osadzone czcionki, oraz [FontsManager.GetFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getfonts/), aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki potrzebne do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/hiddenslides/) przez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/) i [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/readdocumentproperties/). To rozwiązanie jest odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być brakujące lub nieaktualne, lub jeśli potrzebujesz zweryfikować bieżące wartości, przeiteruj [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) i sprawdź właściwość [Slide.Hidden](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru slajdu i orientacji oraz czy różnią się od domyślnych?**

Tak. Załaduj prezentację i odczytaj [Presentation.SlideSize](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slidesize/). Sprawdź [ISlideSize.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/size/) oraz [ISlideSize.Orientation](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/orientation/), aby porównać bieżące ustawienia z oczekiwanymi presetami i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/) i sprawdź [ChartData.DataSourceType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/datasourcetype/). W przypadku zewnętrznego skoroszytu odczytaj [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/). Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego pliku wymaga osobnego sprawdzenia zasobów.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość określająca złożoność. Przejdź przez [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) i kolekcję [IBaseSlide.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/shapes/) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako sygnałów ostrzegawczych i zmierz reprezentatywne renderowanie lub eksport, zanim uznasz slajd za potwierdzony wąski gardło wydajności.