---
title: Export prezentací do XAML v C++
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/cpp/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentace do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- C++
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v C++ pomocí Aspose.Slides — rychlé řešení bez Office, které zachovává rozvržení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním při exportu skrytých snímků.

## **O XAML**

XAML je jazyk značkování založený na XML, který se používá k popisu uživatelských rozhraní v rámcích jako jsou WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním návrháři nebo psát a upravovat značkování přímo.

## **Exportování prezentací do XAML s výchozími možnostmi**

Následující příklad v C++ ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Ve výchozím nastavení jsou exportované snímky uloženy v podsložce `pres` aktuálního pracovního adresáře procesu, jak vrací [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/cs/cpp/system.io/directory/getcurrentdirectory/). Složka je vytvořena automaticky a všechny potřebné obrázky jsou také uloženy tam.

Název výstupní složky je odvozen od názvu zdrojového souboru bez přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když předáte absolutní cestu k vstupní prezentaci, výstupní složka je vytvořena relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

## **Exportování prezentací do XAML s vlastními možnostmi**

Použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/ixamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Pro uložení výstupu na vlastní umístění implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/ixamloutputsaver/) a předávejte instanci vaší implementace metodě [set_OutputSaver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) třídy [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/).

Pro zahrnutí skrytých snímků do výstupu XAML předávejte `true` metodě [set_ExportHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), jak je ukázáno v následujícím příkladu v C++:

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

## **Zachycení všech vygenerovaných XAML artefaktů**

Export do XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Předávejte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/ixamloutputsaver/) metodě [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/), abyste získali tyto artefakty místo výchozího ukladače souborového systému. Export zahajte pomocí specifické přetížení [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/), které přijímá XAML možnosti.

### **Porozumění životnímu cyklu zpětných volání**

Exportér volá [IXamlOutputSaver::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a jiné binární zdroje nesmí být dekódovány jako text.
- Ukladač je zodpovědný za zachování nebo trvalé uložení dat před návratem. Příklady kopírují každé pole bajtů do paměti vlastněné aplikací.
- Považujte export za úspěšný pouze tehdy, když operace uložení prezentace vrátí a všechny zpětné volání byly úspěšně dokončeny. Neukrývejte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se perzistence provádí později, nahlaste celkový úspěch až po úspěšném dokončení tohoto kroku.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) se také vztahuje na vlastní ukladač. Výchozí nastavení `false` vylučuje XAML dokumenty skrytých snímků. Nastavením na `true` je zahrne spolu se všemi potřebnými zdroji pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden zpětný volání na snímek ani pevné pořadí volání.

### **Export do paměti a inspekce artefaktů**

Tento kompletní příklad načte `pres.pptx`, shromáždí všechny artefakty do [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/cs/cpp/system.collections.generic/dictionary/), a vypíše jejich název, typ a počet bajtů. Přesně zachovává poskytnuté názvy. Duplicitní názvy způsobí selhání sběru místo tichého přepsání artefaktu.

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

            // Dekódujte pouze XAML a pouze když je potřeba textová inspekce.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Zavolejte `InMemoryXamlExample::Run` z vaší aplikace. Kontroly přípon jsou užitečné při inspekci; uchovávejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu nechte bajty beze změny. Používejte [Encoding::GetString](https://reference.aspose.com/slides/cs/cpp/system.text/encoding/getstring/) s kódováním UTF-8 pouze pro XAML, který vyžaduje textové zpracování.

### **Zabalení shromážděných artefaktů do ZIP archivu**

Tento samostatný příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu. Jedinečný název archivu odděluje souběžné úlohy exportu. ZIP položky používají dopředná lomítka a zachovávají relativní adresáře. Nebezpečné názvy nebo názvy kolidující po normalizaci odmítnou celý balíček před jeho zápisem.

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

        // Uložení dokončuje ZIP adresář; zavřete soubor před hlášením úspěchu.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Zavolejte `ZipXamlExample::Run` z vaší aplikace. Příklad používá `Aspose::Zip::ZipFile` z C++ runtime k zápisu lokálního archivu; samotný export neukládá volně XAML nebo soubory obrázků. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním shromážděných polí bajtů. Použijte identifikátor exportní úlohy plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení transakce databáze. Vyčistěte částečný výstup, pokud perzistence selže.

Pro velké prezentace může vlastní ukladač perzistentně ukládat každý artefakt přímo do úložiště aplikace, aby se předešlo uchování další kopie celého exportu v paměti aplikace. Exportér i tak shromažďuje všechny generované artefakty v paměti před voláním ukladače. Udržujte každé zpětné volání synchronní z pohledu exportéru: vraťte se až po přijetí bajtů cílem a umožněte selhání, aby dosáhla volajícího.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovávejte relativní adresáře. Nepoužívejte pouze [Path::GetFileName](https://reference.aspose.com/slides/cs/cpp/system.io/path/getfilename/), pokud není každému generovanému názvu známa jedinečnost a odkazy na zdroje zůstávají platné.
- Aplikujte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítněte kořenové cesty a segmenty traversalu, vyřešte cíl pomocí [Path::GetFullPath](https://reference.aspose.com/slides/cs/cpp/system.io/path/getfullpath/), a ověřte, že zůstává pod zamýšleným výstupním adresářem, včetně oddělovače adresáře v kontrolě obsahování. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Používejte samostatný ukladač a jmenný prostor úložiště pro každou úlohu exportu. Detekujte kolize po normalizaci oddělovačů a v souladu s pravidly rozlišování velikosti písmen cíle.
- Před publikováním analyzujte každý XAML dokument jako XML a kontrolujte jeho souborové odkazy na zdroje, jako jsou atributy `Source` nebo `ImageSource` obrázku. Vyřešte každou relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte vzniklý název úložiště a potvrďte, že odpovídající klíč slovníku, ZIP položka nebo uložený objekt existuje. Zpracovávejte externí URI a XAML markup výrazy odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být dostupný jako `pres/images/image1.png`. Uchování pouze `image1.png` by toto spojení přerušilo. Pro ukládání objektů zachovejte stejnou strukturu pod prefixem úlohy a zajistěte, aby tyto URL zdrojů byly přístupné pro spotřebitele XAML. Znovu otevřete dokončený ZIP a ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, aby se potvrdilo, že obrázky jsou správně řešeny.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud původní font není na stroji dostupný?**

Použijte [set_DefaultRegularFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) v [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/) — je používán jako náhradní font během exportu, když původní chybí. To však nezaručuje, že vygenerovaný XAML bude odkazovat na náhradní font nebo že font bude dostupný na cílovém zařízení. Zajistěte, aby fonty, na které XAML odkazuje, byly dostupné v prostředí, kde je zobrazován.

**Je exportovaný XAML určen jen pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML pomocí svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerované značky ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [set_ExportHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/) — nechte jej zakázáno, pokud je nepotřebujete exportovat.