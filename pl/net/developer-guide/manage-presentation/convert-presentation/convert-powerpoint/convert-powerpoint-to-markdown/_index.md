---
title: Konwertuj prezentacje PowerPoint na Markdown w .NET
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/net/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do MD
- prezentacja do MD
- slajd do MD
- PPT do MD
- PPTX do MD
- zapisz PowerPoint jako Markdown
- zapisz prezentację jako Markdown
- zapisz slajd jako Markdown
- zapisz PPT jako MD
- zapisz PPTX jako MD
- eksportuj PPT do MD
- eksportuj PPTX do MD
- eksport obrazów Markdown
- linki obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX na Markdown w .NET oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metafile oraz SVG."
---
## **Przegląd**

Aspose.Slides for .NET może konwertować prezentacje PPT i PPTX na Markdown dla dokumentacji, statycznych witryn, migracji treści i przepływów pracy kontroli wersji. Możesz wybrać odmianę Markdown, kontrolować sposób renderowania treści slajdów oraz zdecydować, gdzie zapisywane są wyeksportowane obrazy i jak generowany Markdown odwołuje się do nich.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować treść wizualną, ustaw właściwość [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/exporttype/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownexporttype/). `Sequential` renderuje elementy slajdu oddzielnie i w kolejności, natomiast `Visual` grupuje elementy razem, aby zachować ich relację wizualną. Wartość `TextOnly` nie generuje zasobów obrazu, więc zdarzenia zapisywania obrazu nie są wywoływane w tym trybie.

## **Konwertuj prezentację na Markdown**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), a następnie wywołaj metodę [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Wybierz odmianę Markdown**

Właściwość [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/flavor/) kontroluje specyfikację Markdown używaną w wyjściu. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/net/aspose.slides.export/flavor/) zawiera CommonMark, GitHub Flavored Markdown i inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Eksportuj obrazy przy użyciu domyślnego zachowania zapisu lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/) udostępnia dwie właściwości dla lokalnie zapisywanych obrazów:

- [BasePath](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/basepath/) określa katalog podstawowy dla dokumentu Markdown i jego zasobów.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) określa podkatalog obrazów. Jego domyślną wartością jest `Images`.

Poniższy przykład renderuje treść wizualną, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

To zachowanie służy również jako mechanizm awaryjny, gdy niestandardowy obsługujący zapis obrazu zwróci `false`.

## **Dostosuj zapisywanie obrazów i odnośniki Markdown**

Użyj zdarzenia [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/imagesaving/) dla zasobów bitmap i metafile, które nie są SVG, emitowanych podczas eksportu Markdown. Jego delegat [MarkdownImageSavingHandler](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/), jego [ImageFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/), oraz wygenerowany odnośnik Markdown jako parametr `ref string`. Zapisz lub prześlij obraz w podanym formacie i zastąp `link` odwołaniem, które ma pojawić się w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane oddzielnie. Subskrybuj zdarzenie [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), którego delegat [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) otrzymuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) oraz parametr `ref string link`. SVG nie posiada argumentu `ImageFormat`; zapisz lub prześlij jego dane XML z właściwości [ISvgImage.SvgData](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/svgdata/). W zależności od trybu eksportu i grupowania wizualnego, SVG w źródłowej prezentacji może zostać rasteryzowane lub połączone z inną treścią; wynikowy zasób nie‑SVG zostanie wtedy przekazany do `ImageSaving`. Subskrybuj oba zdarzenia, gdy każdy wyeksportowany zasób wizualny wymaga niestandardowego przetwarzania.

Wartość zwracana przez obsługujący decyduje, kto przetwarza obraz:

- Zwróć `true`, jeśli obsługujący zapisał, przesłał, przekształcił lub w inny sposób przetworzył obraz i przypisał prawidłową wartość do `link`. Aspose.Slides zapisze tę wartość w dokumencie Markdown i nie wykona domyślnego lokalnego zapisu.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować odnośnik zgodnie z [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/basepath/) oraz [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Obsługujący, który zwraca `true`, przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego odnośnika, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

### **Zapisz obrazy w katalogu pochodzenia CDN i używaj zewnętrznych URL‑i**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog pochodzenia CDN. Każdy obsługujący wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zastępuje wygenerowane lokalne odwołanie publicznym URL‑em CDN. Sam przykład nie wykonuje przesyłania sieciowego: URL staje się ważny dopiero po zamontowaniu katalogu jako pochodzenia CDN lub po opublikowaniu plików w CDN. Dla przechowywania obiektowego zamień zapis do systemu plików na operację przesyłania przy użyciu SDK magazynu i przypisz `link` dopiero po pomyślnym przesłaniu.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Obsługujący bitmapy celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` przy użyciu domyślnego zachowania. Większe zasoby bitmap i metafile, a także zasoby SVG, są obsługiwane przez kod niestandardowy. Na przykład wygenerowane lokalne odwołanie `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obsługujący używają ścieżek systemu operacyjnego wyłącznie przy zapisie plików; odnośniki zapisywane w Markdown używają ukośników i znaków URL‑escaped w nazwach plików. Stosuj tę samą zasadę przy budowaniu względnych odnośników: używaj `/`, a nie separatora specyficznego dla platformy.

## **FAQ**

**Czy jeden obsługujący może przetwarzać zarówno obrazy rastrowe, jak i SVG?**

Nie. Użyj [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/imagesaving/) dla emitowanych bitmap i metafile oraz [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) dla zasobów emitowanych jako SVG. Pierwszy dostarcza obiekt [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) i [ImageFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/); drugi dostarcza obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) którego dane SVG można odczytać z [ISvgImage.SvgData](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/svgdata/). Źródłowy SVG, który jest rasteryzowany podczas eksportu, jest przetwarzany przez `ImageSaving`.

**Co się dzieje, gdy obsługujący zapis obrazu zwróci `false`?**

Aspose.Slides używa domyślnego zachowania zapisu lokalnego. Lokalizacja obrazu i wygenerowane odwołanie są kontrolowane przez [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/basepath/) oraz [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/pl/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Czy obsługujący może podać URL bez zapisywania obrazu lokalnie?**

Tak. Obsługujący może przesłać obraz do magazynu obiektowego lub przekazać go innemu serwisowi, przypisać wynikowy URL do `link` i zwrócić `true`. Obsługujący musi w pełni zakończyć przetwarzanie; zwrócenie `true` zapobiega domyślnemu lokalnemu zapisowi.

**Dlaczego eksport Markdown rzuca `InvalidOperationException` z obsługującego?**

Ten wyjątek występuje, gdy obsługujący zwróci `true`, ale nie dostarczy prawidłowego odnośnika. Przypisz względną ścieżkę lub zewnętrzny URL, który ma być zapisany w Markdown, przed zwróceniem `true`.

**Jakiego separatora ścieżek powinny używać odnośniki do obrazów?**

Używaj ukośników (`/`) w odnośnikach Markdown i URL‑ach. `Path.Combine` stosuj wyłącznie do ścieżek systemowych, a odnośnik Markdown twórz lub normalizuj osobno.

**Czy hiperlinki są zachowywane podczas eksportu do Markdown?**

Tak. Tekstowe [hyperlinks](/slides/pl/net/manage-hyperlinks/) są zachowywane jako standardowe odnośniki Markdown. [Transitions](/slides/pl/net/slide-transition/) i [animations](/slides/pl/net/powerpoint-animation/) slajdów nie są konwertowane.

**Czy prezentacje można konwertować do Markdown równolegle?**

Można przetwarzać różne pliki prezentacji równolegle, ale nie należy udostępniać tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) między wątkami. Postępuj zgodnie z [multithreading guidelines](/slides/pl/net/multithreading/) i używaj osobnej instancji dla każdego pliku.