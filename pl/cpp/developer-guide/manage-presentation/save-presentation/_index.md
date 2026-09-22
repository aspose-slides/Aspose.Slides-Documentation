---
title: Zapis prezentacji w C++
linktitle: Zapis prezentacji
type: docs
weight: 80
url: /pl/cpp/save-presentation/
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
- zdefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- C++
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w C++ przy użyciu Aspose.Slides oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/cpp/open-presentation/), użyj metody [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/), aby zapisać wynik. Aspose.Slides for C++ może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje wyjścia PPTX.

## **Zapis prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/) metodzie [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/). Wartość formatu określa typ pliku tworzonego przez Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapis prezentacji w ich oryginalnym formacie**

Aby poznać przykłady wykrywania formatu pliku i strumienia, zachowanie nowo utworzonych prezentacji oraz różnicę między formatem źródłowym a wyjściowym, zobacz [Determine the Original Presentation Format](/slides/pl/cpp/detect-presentation-source-format/).

W aplikacji przetwarzającej wsadowo format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego oryginalny format przy użyciu [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_sourceformat/). Przekaż otrzymaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sourceformat/) do [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/tosaveformat/), aby uzyskać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/), a następnie użyj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) do zapisania zmodyfikowanej prezentacji.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

`SlideUtil::ToSaveFormat` mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na ich odpowiednie formaty zapisu prezentacji. Mapuje wyłącznie formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanego lub nieprawidłowego wartości [SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sourceformat/) skutkuje zgłoszeniem [ArgumentException](https://reference.aspose.com/slides/pl/cpp/system/argumentexception/).

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja jest ładowana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać rozpoznany jako PPT. Jeśli wymagane jest zachowanie tych starszych podtypów, zachowaj oryginalną nazwę pliku lub metadane formatu osobno i użyj ich przy wyborze nazwy i formatu wyjściowego.

## **Zapis prezentacji do strumieni**

Aby zapisać prezentację bez korzystania z ostatecznej ścieżki pliku, przekaż zapisywalny [Stream](https://reference.aspose.com/slides/pl/cpp/system.io/stream/) oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/) metodzie [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/). To podejście jest przydatne, gdy wynik ma zostać zwrócony z usługi internetowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia pliku:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Zapis prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisany plik początkowo. Wywołaj [ViewProperties::set_LastView](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/set_lastview/) z wartością [ViewType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Slide Master jako widok początkowy:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Zapis prezentacji w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny ze ścisłym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/) i wywołaj [PptxOptions::set_Conformance](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/set_conformance/) z wartością `Conformance::Iso29500_2008_Strict`. Następnie przekaż te opcje metodzie [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza rozmiar skompresowanego i nieskompresowanego wpisu, łączny rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby wpisów.

Użyj [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/set_zip64mode/), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- `IfNecessary` używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To tryb domyślny.  
- `Never` wyłącza rozszerzenia ZIP64.  
- `Always` zawsze zapisuje rozszerzenia ZIP64.  

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla wyjściowej prezentacji:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Ostrzeżenie" %}}
Jeśli `Zip64Mode` jest ustawiony na `Never` i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapis prezentacji w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz wyważyć szybkość zapisu względem rozmiaru pliku, wywołując [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Wyliczenie [CompressionLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/compressionlevel/) oferuje następujące wartości:

- `None` przechowuje dane bez kompresji.  
- `Level1` zapewnia najszybszą kompresję i największy skompresowany rozmiar.  
- `Level2` do `Level5` stopniowo faworyzują mniejszy rozmiar wyjściowy kosztem szybkości zapisu.  
- `Level6` równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.  
- `Level7` i `Level8` jeszcze bardziej faworyzują mniejszy rozmiar kosztem szybkości.  
- `Level9` zapewnia najsilniejszą kompresję i wymaga najwięcej czasu przetwarzania.  

Poniższy przykład zapisuje prezentację bez kompresji:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zapis prezentacji bez odświeżania miniatury**

Podczas zapisu prezentacji jako PPTX, metoda [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) steruje miniaturą dokumentu:

- `true` regeneruje miniaturę podczas operacji zapisu. To wartość domyślna.  
- `false` zachowuje istniejącą miniaturę. Jeśli prezentacja nie ma miniatury, Aspose.Slides nie generuje jej.  

Poniższy przykład zapisuje prezentację bez odświeżania miniatury:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Uwaga" %}}
Wyłączenie odświeżania miniatury może skrócić czas potrzebny na zapis pliku PPTX.
{{% /alert %}}

## **Zapisywanie aktualizacji postępu w procentach**

Aby monitorować operację zapisu, zaimplementuj interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprogresscallback/) i przekaż implementację do [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides wywoła [IProgressCallback::Reporting](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprogresscallback/reporting/) z wartościami postępu podczas eksportu.

Poniższy przykład raportuje postęp eksportu PDF w konsoli:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Uwaga" %}}
Aspose udostępnia bezpłatny [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) zbudowany w oparciu o API Aspose.Slides. Zapisuje wybrane slajdy z prezentacji jako oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapisy przyrostowe lub „szybki zapis”?**  
Nie. Każda operacja zapisu tworzy pełny plik wyjściowy, a nie aktualizuje jedynie zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**  
Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) **nie jest wątkowo‑bezpieczna**. Dostęp i zapis każdej instancji powinny odbywać się jednocześnie tylko w jednym wątku.

**Co się dzieje z hiperlinkami i zewnętrznie powiązanymi plikami przy zapisie prezentacji?**  
[Hyperlinki](/slides/pl/cpp/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje plików powiązanych zewnętrznie, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**  
Tak. Ustaw odpowiednie [właściwości dokumentu](/slides/pl/cpp/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.