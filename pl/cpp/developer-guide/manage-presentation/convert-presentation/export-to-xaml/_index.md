---
title: Eksportowanie prezentacji do XAML w C++
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w C++ przy użyciu Aspose.Slides—szybkie, wolne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań dotyczących czcionek awaryjnych, kompatybilności stosu XAML oraz zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML to język znaczników oparty na XML, używany do opisywania interfejsów użytkownika w takich frameworkach jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin.Forms.

Pliki XAML można edytować w wizualnym projektancie lub pisać i modyfikować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z domyślnymi opcjami**

Poniższy przykład w C++ pokazuje, jak wyeksportować prezentację do XAML przy użyciu ustawień domyślnych:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego procesu, zwracanego przez [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/pl/cpp/system.io/directory/getcurrentdirectory/). Folder jest tworzony automatycznie, a wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla `pres.pptx` pliki wynikowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli podasz bezwzględną ścieżkę do prezentacji wejściowej, folder wyjściowy jest tworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z niestandardowymi opcjami**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/ixamloptions/), aby kontrolować, jak Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, zaimplementuj [IXamlOutputSaver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/ixamloutputsaver/) i przekaż instancję swojej implementacji do metody [set_OutputSaver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) klasy [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, przekaż `true` do metody [set_ExportHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), jak pokazano w poniższym przykładzie C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Zbieranie wszystkich wygenerowanych artefaktów XAML**

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz oddzielne obrazy i zasoby pomocnicze. Przekaż własny [IXamlOutputSaver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/ixamloutputsaver/) do [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/), aby odbierać te artefakty zamiast używać domyślnego zapisu do systemu plików. Rozpocznij eksport przy użyciu przeciążenia [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) przyjmującego opcje XAML.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje [IXamlOutputSaver::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) osobno dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zapisywacz jest odpowiedzialny za zachowanie lub trwałe zapisanie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów do pamięci własnościowej aplikacji.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zakończy się sukcesem i wszystkie wywołania zwrotne zakończyły się pomyślnie. Nie ukrywaj błędów przechowywania ani nie rozpoczynaj niewidocznych zapisów w tle. Jeśli trwałość następuje później, zgłoś ogólny sukces dopiero po pomyślnym zakończeniu tego kroku.

Metoda [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) ma również zastosowanie do własnego zapisywacza. Domyślne ustawienie, `false`, wyklucza dokumenty XAML ukrytych slajdów. Ustawienie `true` powoduje ich dołączenie oraz wszelkich zasobów potrzebnych do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, zbiera każdy artefakt w [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/pl/cpp/system.collections.generic/dictionary/), i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje podane nazwy w dokładności. Powtórne nazwy powodują niepowodzenie kolekcji zamiast cichego nadpisania artefaktu.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest analiza tekstowa.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Wywołaj `InMemoryXamlExample::Run` ze swojej aplikacji. Kontrole rozszerzeń są przydatne do inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Nie zmieniaj bajtów podczas przechowywania lub transmisji. Używaj [Encoding::GetString](https://reference.aspose.com/slides/pl/cpp/system.text/encoding/getstring/) z kodowaniem UTF-8 wyłącznie dla XAML, które wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten niezależny przykład zbiera eksport, weryfikuje jego nazwy i zapisuje oryginalne bajty w archiwum ZIP. Unikalna nazwa archiwum oddziela jednoczesne zadania eksportu. Pozycje ZIP używają ukośników i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed zapisem.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finalizuje katalog ZIP; zamknij plik przed zgłoszeniem sukcesu.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Wywołaj `ZipXamlExample::Run` ze swojej aplikacji. Przykład używa `Aspose::Zip::ZipFile` z środowiska uruchomieniowego C++ do zapisu jednego lokalnego archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku zdalnego przechowywania zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob, lub zapisz identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesyłek lub zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli trwałość się nie powiedzie.

W przypadku dużych prezentacji własny zapisywacz może trwale zapisywać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć utrzymywania dodatkowej kopii całego eksportu w pamięci aplikacji. Eksporter wciąż gromadzi wszystkie wygenerowane artefakty w pamięci przed wywołaniem zapisywacza. Trzymaj każde wywołanie zwrotne synchroniczne z perspektywy eksportera: zwracaj jedynie po przyjęciu bajtów przez docelowy punkt, i pozwól na propagację błędów do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatory ścieżek, gdy docelowy system tego wymaga, ale zachowaj katalogi względne. Nie używaj wyłącznie [Path::GetFileName](https://reference.aspose.com/slides/pl/cpp/system.io/path/getfilename/), chyba że każda wygenerowana nazwa jest znana jako unikalna i odwołania zasobów pozostają ważne.
- Stosuj walidację nazw specyficzną dla miejsca docelowego. Przy zapisie luźnych plików odrzuć ścieżki bezwzględne i segmenty traversalu, rozwiąż docelową ścieżkę za pomocą [Path::GetFullPath](https://reference.aspose.com/slides/pl/cpp/system.io/path/getfullpath/), i sprawdź, czy pozostaje pod zamierzonym katalogiem eksportu, uwzględniając separator katalogu w kontroli zawierania. Używaj katalogu kontrolowanego przez aplikację, bez linków symbolicznych mogących przekierowywać zapisy.
- Używaj oddzielnego zapisywacza i przestrzeni nazw przechowywania dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatorów i zgodnie z regułami czułości na wielkość liter w miejscu docelowym.
- Przed publikacją parsuj każdy dokument XAML jako XML i sprawdzaj jego odwołania do zasobów plikowych, takie jak atrybuty `Source` lub `ImageSource` obrazów. Rozwiązuj każdy względny URI względem katalogu zawierającego artefakt XAML, normalizuj otrzymaną nazwę magazynową i potwierdzaj istnienie odpowiadającego klucza w słowniku, wpisu ZIP lub przechowywanego obiektu. Traktuj zewnętrzne URI i wyrażenia znaczników XAML oddzielnie od względnych nazw plików.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, zapisanemu zasobowi musi odpowiadać ścieżka `pres/images/image1.png`. Przechowywanie jedynie `image1.png` przerwie tę zależność. W przypadku przechowywania obiektowego zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie gotowe archiwum ZIP, aby zweryfikować nazwy wpisów i bajty zasobów, oraz załaduj reprezentatywne slajdy w docelowym środowisku XAML, aby potwierdzić poprawność rozwiązywania obrazów.

## **FAQ**

**Jak zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na maszynie?**

Użyj [set_DefaultRegularFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) w [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/) — jest używany jako czcionka awaryjna podczas eksportu, gdy oryginał jest nieobecny. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki awaryjnej lub że czcionka będzie dostępna na maszynie docelowej. Upewnij się, że czcionki odwoływane w XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF poprzez publiczne API. Kompatybilność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz sterować tym zachowaniem za pomocą [set_ExportHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.