---
title: Konwertuj prezentacje PowerPoint do Markdown w C++
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/cpp/convert-powerpoint-to-markdown/
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
- linki do obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX do Markdown w C++ oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metafile i SVG."
---
## **Przegląd**

Aspose.Slides for C++ może konwertować prezentacje PPT i PPTX do formatu Markdown w celu dokumentacji, statycznych witryn, migracji treści i przepływów pracy kontroli wersji. Można wybrać odmianę Markdown, kontrolować sposób renderowania treści slajdów oraz zdecydować, gdzie przechowywane są wyeksportowane obrazy i jak generowany Markdown je odwołuje.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować treść wizualną, ustaw metodę [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownexporttype/). `Sequential` renderuje elementy slajdu osobno i w kolejności, natomiast `Visual` utrzymuje grupowane elementy razem, aby zachować ich relację wizualną. Wartość `TextOnly` nie generuje zasobów obrazu, więc zdarzenia zapisywania obrazów nie są wywoływane w tym trybie.

## **Konwertuj prezentację do Markdown**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), a następnie wywołaj metodę [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Wybierz odmianę Markdown**

Metoda [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) kontroluje specyfikację Markdown używaną w wyjściu. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/flavor/) zawiera CommonMark, GitHub Flavored Markdown oraz inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Eksportuj obrazy przy użyciu domyślnego zachowania zapisywania lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/) udostępnia dwie metody konfigurowania lokalnie zapisywanych obrazów:

- [set_BasePath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) określa katalog bazowy dla dokumentu Markdown i jego zasobów.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) określa podkatalog obrazów. Jego domyślna wartość to `Images`.

Poniższy przykład renderuje treść wizualną, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

To zachowanie służy również jako rozwiązanie awaryjne, gdy niestandardowy handler zapisywania obrazu zwraca `false`.

## **Dostosuj zapisywanie obrazów i linki Markdown**

Użyj zdarzenia `MarkdownSaveOptions::ImageSaving` dla zasobów bitmap i metafile niebędących SVG generowanych podczas eksportu Markdown. Jego delegat [MarkdownImageSavingHandler](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/), jego [ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/), oraz wygenerowany link Markdown jako parametr `System::String&`. Zapisz lub prześlij obraz w podanym formacie i zamień `link` na odwołanie, które ma pojawić się w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane oddzielnie. Subskrybuj zdarzenie `MarkdownSaveOptions::SvgImageSaving`, którego delegat [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) otrzymuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) oraz parametr `System::String& link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub prześlij jego dane XML z metody [ISvgImage::get_SvgData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/get_svgdata/). W zależności od trybu eksportu i grupowania wizualnego, SVG w źródłowej prezentacji może być rasteryzowane lub łączone z inną treścią; powstały zasób nie‑SVG jest następnie przekazywany do `ImageSaving`. Subskrybuj oba zdarzenia, gdy każdy wyeksportowany zasób wizualny wymaga niestandardowego przetwarzania.

Wartość zwracana przez handler określa, kto przetwarza obraz:

- Zwróć `true` po tym, jak handler zapisał, przesłał, przekształcił lub w inny sposób przetworzył obraz i przypisał prawidłową wartość do `link`. Aspose.Slides zapisuje tę wartość w dokumencie Markdown i nie wykonuje domyślnego lokalnego zapisu.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować jego link zgodnie z [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) oraz [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Handler zwracający `true` przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego linku, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

### **Zapisz obrazy do katalogu pochodzenia CDN i użyj zewnętrznych URL**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog pochodzenia CDN. Każdy handler wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia wygenerowane lokalne odwołanie na publiczny URL CDN. Sam przykład nie wykonuje żadnego przesyłania sieciowego: URL staje się ważny dopiero po zamontowaniu katalogu jako pochodzenie CDN lub opublikowaniu jego plików w CDN. W przypadku przechowywania obiektowego, zastąp zapis do systemu plików operacją uploadu SDK przechowywania i przypisz `link` dopiero po pomyślnym przesłaniu.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Handler bitmapów celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` przy użyciu domyślnego zachowania. Większe zasoby bitmap i metafile, a także zasoby SVG, są obsługiwane przez kod niestandardowy. Na przykład wygenerowane lokalne odwołanie takie jak `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery używają ścieżek systemu operacyjnego wyłącznie przy zapisywaniu plików; linki zapisywane w Markdown używają ukośników (`/`) i znaków URL‑escape w nazwach plików. Stosuj tę samą zasadę przy budowaniu względnych linków: używaj `/`, a nie separatora specyficznego dla platformy.

## **FAQ**

**Czy jeden handler może przetwarzać zarówno obrazy rastrowe, jak i SVG?**

Nie. Użyj `MarkdownSaveOptions::ImageSaving` dla emitowanych zasobów bitmap i metafile oraz `MarkdownSaveOptions::SvgImageSaving` dla zasobów emitowanych jako SVG. Pierwszy zwraca obiekt [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) i [ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/); drugi zwraca obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/), którego dane SVG można odczytać za pomocą [ISvgImage::get_SvgData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/get_svgdata/). Źródłowy SVG rasteryzowany podczas eksportu jest przetwarzany przez `ImageSaving`.

**Co się dzieje, gdy handler zapisywania obrazu zwraca `false`?**

Aspose.Slides używa domyślnego zachowania zapisywania lokalnego. Lokalizacja obrazu i wygenerowane odwołanie są kontrolowane przez [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) oraz [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Czy handler może podać URL bez zapisywania obrazu lokalnie?**

Tak. Handler może przesłać obraz do przechowywania obiektowego lub przekazać go innemu serwisowi, przypisać powstały URL do `link` i zwrócić `true`. Handler musi samodzielnie zakończyć przetwarzanie; zwrócenie `true` uniemożliwia domyślne zapisywanie lokalne.

**Dlaczego eksport Markdown rzuca `InvalidOperationException` z handlera?**

Ten wyjątek występuje, gdy handler zwraca `true`, ale nie podaje prawidłowego linku. Przypisz względną ścieżkę lub zewnętrzny URL, który ma być zapisany w Markdown, przed zwróceniem `true`.

**Jakiego separatora ścieżki powinny używać linki do obrazów?**

Używaj ukośników (`/`) w linkach Markdown i URL‑ach. `Path::Combine` używaj wyłącznie do ścieżek systemu plików, a odwołanie w Markdown buduj lub normalizuj osobno.

**Czy hiperłącza są zachowywane podczas eksportu do Markdown?**

Tak. Tekst [hiperlącza](/slides/pl/cpp/manage-hyperlinks/) jest zachowany jako standardowe linki Markdown. [Przejścia](/slides/pl/cpp/slide-transition/) i [animacje](/slides/pl/cpp/powerpoint-animation/) slajdów nie są konwertowane.

**Czy prezentacje mogą być konwertowane do Markdown równolegle?**

Można przetwarzać różne pliki prezentacji równolegle, ale nie należy współdzielić tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) między wątkami. Postępuj zgodnie z [wytycznymi wielowątkowości](/slides/pl/cpp/multithreading/) i używaj osobnej instancji dla każdego pliku.