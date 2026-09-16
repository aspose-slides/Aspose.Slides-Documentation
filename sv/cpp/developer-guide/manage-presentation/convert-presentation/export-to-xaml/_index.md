---
title: Exportera presentationer till XAML i C++
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/cpp/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- C++
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i C++ med Aspose.Slides—snabb, Office-frî lösning som behåller din layout intakt."
---
## **Översikt**

Den här artikeln förklarar hur man exporterar PowerPoint-presentationer till XAML med hjälp av Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur man sparar en presentation till XAML med standardinställningar och demonstrerar hur man anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservteckensnitt, XAML-stackkompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett XML-baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk såsom WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML-filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande C++-exempel visar hur man exporterar en presentation till XAML med standardinställningar:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Som standard sparas de exporterade bilderna i en `pres`-undermapp i processens aktuella arbetskatalog, som returneras av [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/sv/cpp/system.io/directory/getcurrentdirectory/). Mappen skapas automatiskt och eventuella nödvändiga bilder sparas där också.

Utdatamappens namn hämtas från källfilens namn utan dess filändelse. För `pres.pptx` får utdatafilnamnen `pres/Slide_1.xaml`, `pres/Slide_2.xaml` och så vidare. Även om du anger en absolut sökväg till inmatningspresentationen skapas utdatamappen relativt till den aktuella arbetskatalogen, snarare än bredvid inmatningsfilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/ixamloptions/) för att kontrollera hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata till en anpassad plats, implementera [IXamlOutputSaver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/ixamloutputsaver/) och skicka en instans av din implementation till metoden [set_OutputSaver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) i [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/).

För att inkludera dolda bilder i XAML-utdata, skicka `true` till metoden [set_ExportHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), som visas i följande C++-exempel:

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

## **Fånga alla genererade XAML‑artefakter**

En XAML-export kan producera ett XAML-dokument för varje exporterad bild samt separata bilder och stödjande resurser. Skicka en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/ixamloutputsaver/) till [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) för att ta emot dessa artefakter istället för att använda den förinställda filsystem‑spararen. Starta exporten med den XAML‑specifika overloaden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) som accepterar XAML‑alternativ.

### **Förstå återuppringningslivscykeln**

- `path` identifierar artefakten och kan innehålla relativa kataloger. Bevara denna information eftersom XAML kan referera till resurser med relativa sökvägar.
- `data` innehåller artefaktens byte. Bilder och andra binära resurser får inte avkodas som text.
- Spararen ansvarar för att behålla eller persistera data innan den returneras. Exemplen kopierar varje byte‑array till applikationsägd minne.
- Betrakta exporten som lyckad endast när presentationssparningsoperationen returnerar och varje återuppringning har slutförts framgångsrikt. Ignorera inte lagringsfel eller påbörja oobserverade bakgrundsskrivningar. Om persistens sker i efterhand, rapportera total framgång först när även det steget lyckas.
- [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) gäller även för en anpassad sparare. Standardinställningen, `false`, utesluter XAML-dokument för dolda bilder. Att sätta den till `true` inkluderar dem samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller en fast återuppringningsordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `pres.pptx`, samlar varje artefakt i en [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/sv/cpp/system.collections.generic/dictionary/), och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubblettnamn får insamlingen att misslyckas istället för att tyst skriva över en artefakt.

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

            // Avkoda endast XAML, och endast när textuell inspektion behövs.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Anropa `InMemoryXamlExample::Run` från din applikation. Filändelsekontroller är användbara för inspektion; behåll alla artefakter, inklusive okända resurstypers. Lämna bytena oförändrade vid lagring eller överföring. Använd [Encoding::GetString](https://reference.aspose.com/slides/sv/cpp/system.text/encoding/getstring/) med UTF-8‑kodning endast för XAML som kräver textuell behandling.

### **Paketera insamlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena till ett ZIP‑arkiv. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder snedstreck och bevarar relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

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

        // Spara avslutar ZIP-katalogen; stäng filen innan framgång rapporteras.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Anropa `ZipXamlExample::Run` från din applikation. Exemplet använder `Aspose::Zip::ZipFile` från C++‑runtime för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steget för arkivskrivning med uppladdning av de insamlade byte‑arrayerna. Använd ett export‑jobb‑identifierare plus det fullständiga relativa artefaktnamnet som en blob‑nyckel, eller lagra jobb‑identifieraren, relativa namnet och binärdata i en databastrad. Publicera jobbet först när alla uppladdningar är klara eller databastransaktionen har committats. Rensa partiell output om persistensen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i applikationsminnet. Exportören samlar fortfarande alla genererade artefakter i minnet innan spararen anropas. Håll varje återuppringning synkron ur exportörens perspektiv: returnera först när destinationen har accepterat bytena, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte endast [Path::GetFileName](https://reference.aspose.com/slides/sv/cpp/system.io/path/getfilename/) såvida inte varje genererat namn är känt att vara unikt och resursreferenser förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. Vid skrivning av lösa filer, avvisa rotade sökvägar och traverseringssegment, lös destinationen med [Path::GetFullPath](https://reference.aspose.com/slides/sv/cpp/system.io/path/getfullpath/), och verifiera att den ligger under den avsedda exportkatalogen, inklusive katalogavgränsaren i kontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter normalisering av avgränsare och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, analysera varje XAML-dokument som XML och inspektera dess filbaserade resursreferenser, såsom bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den innehållande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande dictionary‑nyckel, ZIP‑post eller lagrad objekt finns. Behandla externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.
- Till exempel, om `pres/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen finnas som `pres/images/image1.png`. Att bara behålla `image1.png` skulle bryta den relationen. För objektslagring, bevara samma struktur under jobb‑prefixet och göra dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Öppna det färdiga ZIP‑arkivet igen för att verifiera postnamn och resurs‑byte, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löser sig korrekt.

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara typsnitt om originaltypsnittet inte finns på maskinen?**

Använd [set_DefaultRegularFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) i [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/) — den används som reservtypsnitt under export när originalet saknas. Detta garanterar inte att den genererade XAML:n refererar till reservtypsnittet eller att typsnittet är tillgängligt på målmaskinen. Se till att de typsnitt som XAML:n refererar till finns i den miljö där den visas.

**Är den exporterade XAML:n avsedd endast för WPF, eller kan den även användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan kontrollera detta beteende via [set_ExportHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.