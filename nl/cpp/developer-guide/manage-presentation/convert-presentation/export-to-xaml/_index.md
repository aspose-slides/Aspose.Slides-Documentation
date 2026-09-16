---
title: Presentaties exporteren naar XAML in C++
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/cpp/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- C++
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in C++ met Aspose.Slides - snelle, Office-vrije oplossing die uw lay-out onveranderd behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties exporteert naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat als XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia’s. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, XAML‑stack‑compatibiliteit en het gedrag bij het exporteren van verborgen dia’s.

## **Over XAML**

XAML is een XML‑gebaseerde opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visueel ontwerpprogramma of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende C++‑voorbeeld toont hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Standaard worden de geëxporteerde dia’s opgeslagen in een submap `pres` van de huidige werkmap van het proces, zoals geretourneerd door [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/nl/cpp/system.io/directory/getcurrentdirectory/). De map wordt automatisch aangemaakt en eventuele benodigde afbeeldingen worden daar eveneens opgeslagen.

De outputmapnaam wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` krijgen de outputbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs wanneer u een absoluut pad doorgeeft naar de invoerpresentatie, wordt de outputmap relatief ten opzichte van de huidige werkmap aangemaakt, niet naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de interface [IXamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/ixamloptions/) om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de output op een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/ixamloutputsaver/) en geeft een instantie van uw implementatie door aan de methode [set_OutputSaver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) van [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/).

Om verborgen dia’s op te nemen in de XAML‑output, geeft u `true` door aan de methode [set_ExportHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), zoals getoond in het volgende C++‑voorbeeld:

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

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan een XAML‑document voor elke geëxporteerde dia produceren, plus afzonderlijke afbeeldingen en ondersteunende bronnen. Geef een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/ixamloutputsaver/) door aan [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) om deze artefacten te ontvangen in plaats van de standaard bestandsysteem‑saver. Start de export met de XAML‑specifieke overload van [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) die XAML‑opties accepteert.

### **De levenscyclus van de callback begrijpen**

De exporter roept [IXamlOutputSaver::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) afzonderlijk aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML bronnen kan refereren via relatieve paden.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire bronnen mogen niet worden gedecodeerd als tekst.
- De saver is verantwoordelijk voor het behouden of persisteren van de data voordat deze retourneert. De voorbeelden kopiëren elke byte‑array naar geheugen dat eigendom is van de applicatie.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑opslaactie heeft geretourneerd en elke callback succesvol is afgerond. Negeer geen opslag‑fouten en start geen onwaargenomen achtergrond‑schrijfbewerkingen. Als de persisting later plaatsvindt, rapporteer dan het algehele succes pas nadat die stap ook geslaagd is.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) geldt ook voor een aangepaste saver. De standaardwaarde, `false`, sluit XAML‑documenten van verborgen dia’s uit. Instelling op `true` neemt ze op, evenals alle benodigde bronnen. Het aantal bronnen hangt af van de presentatie; neem niet aan dat er één callback per dia is of dat de callbacks in een vaste volgorde komen.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artefact in een [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/nl/cpp/system.collections.generic/dictionary/), en print de naam, het type en het aantal bytes. Het behoudt de opgegeven namen exact. Duplicaatnamen veroorzaken een falende verzameling in plaats van stilletjes een artefact te overschrijven.

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

            // Decode alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Roep `InMemoryXamlExample::Run` aan vanuit uw applicatie. Extensieve controles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende type bronnen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik [Encoding::GetString](https://reference.aspose.com/slides/nl/cpp/system.text/encoding/getstring/) met UTF‑8‑encoding uitsluitend voor XAML dat tekstuele verwerking vereist.

### **Verzamelde artefacten verpakken in een ZIP‑archief**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen, en schrijft de oorspronkelijke bytes naar een ZIP‑archief. Een unieke archiefnaam scheidt gelijktijdige export‑taken. ZIP‑items gebruiken forward slashes en behouden relatieve mappen. Onveilige namen of namen die na normalisatie botsen, leiden tot afwijzing van het gehele pakket voordat het wordt weggeschreven.

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

        // Save finaliseert de ZIP-directory; sluit het bestand voordat succes wordt gerapporteerd.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Roep `ZipXamlExample::Run` aan vanuit uw applicatie. Het voorbeeld maakt gebruik van `Aspose::Zip::ZipFile` uit de C++‑runtime om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor opslag op afstand vervangt u de stap die het archief maakt door het uploaden van de verzamelde byte‑arrays. Gebruik een export‑taak‑identifier plus de volledige relatieve artefact‑naam als blob‑sleutel, of sla de taak‑identifier, relatieve naam en binaire data op in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de database‑transactie gecommitteerd is. Ruim gedeeltelijke output op wanneer persisting mislukt.

Voor grote presentaties kan een aangepaste saver elk artefact rechtstreeks naar applicatie‑opslag persisteren om te voorkomen dat een extra kopie van de volledige export in het applicatie‑geheugen wordt bewaard. De exporter verzamelt nog steeds alle gegenereerde artefacten in het geheugen voordat de saver wordt aangeroepen. Houd elke callback synchronisch vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft geaccepteerd, en laat fouten doorstromen naar de aanroeper.

### **Bron‑namen behouden en referenties verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dat vereist, maar behoud relatieve mappen. Gebruik niet alleen [Path::GetFileName](https://reference.aspose.com/slides/nl/cpp/system.io/path/getfilename/) tenzij elke gegenereerde naam uniek is en bron‑referenties geldig blijven.
- Pas bestemmingsspecifieke naam‑validatie toe. Bij het wegschrijven van losse bestanden, wijs wortelpaden en traversalsegmenten af, los de bestemming op met [Path::GetFullPath](https://reference.aspose.com/slides/nl/cpp/system.io/path/getfullpath/), en controleer dat deze onder de beoogde exportmap blijft, inclusief scheidingsteken in de containment‑check. Gebruik een door de applicatie gecontroleerde map zonder symbolische links die schrijfbewerkingen kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke exporttaak. Detecteer botsingen na normalisatie van scheidingstekens en volgens de case‑sensitivity regels van de bestemming.
- Voordat u publiceert, parse elk XAML‑document als XML en inspecteer de bestand‑gebaseerde bron‑referenties, zoals de `Source`‑ of `ImageSource`‑attributen van afbeeldingen. Los elk relatief URI op ten opzichte van de map van het bijbehorende XAML‑artefact, normaliseer de resulterende opslagnaam, en bevestig dat de overeenkomstige sleutel in het woordenboek, ZIP‑item of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies afzonderlijk van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen bron beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde structuur onder de taak‑prefix en maakt u die bron‑URL’s toegankelijk voor de XAML‑gebruiker. Open het voltooide ZIP‑bestand opnieuw om item‑namen en bron‑bytes te verifiëren, en laad representatieve dia’s in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgezocht.

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Gebruik [set_DefaultRegularFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens export wanneer het origineel ontbreekt. Dit garandeert niet dat de gegenereerde XAML het fallback‑lettertype referereert of dat het lettertype beschikbaar is op de doelsysteem. Zorg ervoor dat de door de XAML gerefereerde lettertypen aanwezig zijn in de omgeving waarin het wordt weergegeven.

**Is de geëxporteerde XAML uitsluitend bedoeld voor WPF, of kan het ook in andere XAML‑stacks gebruikt worden?**

Aspose.Slides exporteert WPF‑XAML via zijn openbare API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in uw doelomgeving.

**Worden verborgen dia’s ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia’s niet meegenomen. U kunt dit gedrag regelen via [set_ExportHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/) — houd het uitgeschakeld als u ze niet wilt exporteren.