---
title: Presentaties opslaan in C++
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/cpp/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang bij opslaan
- C++
- Aspose.Slides
description: "Ontdek hoe u presentaties in C++ kunt opslaan met Aspose.Slides - exporteer naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open presentaties in C++](/slides/nl/cpp/open-presentation/) beschrijft hoe u de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse kunt gebruiken om een presentatie te openen. Dit artikel legt uit hoe u presentaties kunt maken en opslaan. De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of u nu een presentatie vanaf nul maakt of een bestaande wijzigt, wilt u hem opslaan wanneer u klaar bent. Met Aspose.Slides voor C++ kunt u opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `Save`‑methode van de [Presentation] klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het onderstaande voorbeeld laat zien hoe u een presentatie opslaat met Aspose.Slides.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Doe hier wat werk...

// Sla de presentatie op naar een bestand.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Presentaties opslaan naar streams**

U kunt een presentatie opslaan naar een stream door een uitvoer‑stream door te geven aan de `Save`‑methode van de [Presentation] klasse. Een presentatie kan naar verschillende soorten streams worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Sla de presentatie op naar de stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides stelt u in staat om de initiële weergave die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend, in te stellen via de [ViewProperties] klasse. Gebruik de [set_LastView] methode met een waarde uit de [ViewType] enumeratie.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Presentaties opslaan in het Strict Office Open XML-formaat**

Aspose.Slides stelt u in staat om een presentatie op te slaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions] klasse en stel de eigenschap `Conformance` in bij het opslaan. Als u `Conformance.Iso29500_2008_Strict` instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Sla de presentatie op in het Strict Office Open XML-formaat.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Presentaties opslaan in Office Open XML-formaat in Zip64-modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en het beperkt het archief bovendien tot 65 535 (2^16‑1) bestanden. ZIP64‑formaatextensies verhogen deze limieten tot 2^64.

De [IPptxOptions::set_Zip64Mode] methode laat u kiezen wanneer u ZIP64‑formaatextensies wilt gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan worden gebruikt met de volgende modi:

- `IfNecessary` gebruikt ZIP64‑formaatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- `Never` gebruikt nooit ZIP64‑formaatextensies.
- `Always` gebruikt altijd ZIP64‑formaatextensies.

De onderstaande code toont hoe u een presentatie als PPTX opslaat met ingeschakelde ZIP64‑formaatextensies:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Wanneer u opslaat met `Zip64Mode.Never`, wordt er een [PptxException] gegooid als de presentatie niet kan worden opgeslagen in ZIP32‑formaat.
{{% /alert %}}

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions::set_RefreshThumbnail] methode regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als ingesteld op `true`, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaardwaarde.
- Als ingesteld op `false`, blijft de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen als PPTX zonder de miniatuur te vernieuwen.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Deze optie helpt de tijd die nodig is om een presentatie op te slaan in PPTX‑formaat te verkorten.
{{% /alert %}}

## **Voortgangsupdates bij opslaan in percentage**

De [IProgressCallback] interface wordt gebruikt via de `set_ProgressCallback` methode die wordt blootgesteld door de [ISaveOptions] interface en de abstracte [SaveOptions] klasse. Wijs een [IProgressCallback] implementatie toe met `set_ProgressCallback` om voortgangsupdates bij het opslaan te ontvangen als percentage.

De onderstaande code‑fragmenten laten zien hoe u `IProgressCallback` gebruikt.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Gebruik hier de voortgangspercentagewaarde.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint Splitter-app] ontwikkeld met behulp van zijn eigen API. De app stelt u in staat een presentatie op te splitsen in meerdere bestanden door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “fast save” (incrementaal opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand aan; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑veilig om dezelfde Presentation‑instantie vanaf meerdere threads op te slaan?**

Nee. Een [Presentation] instantie is niet thread‑veilig; sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden bij het opslaan?**

[Hyperlinks] worden behouden. Extern gekoppelde bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de verwijzende paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [document properties] worden ondersteerd en worden bij het opslaan naar het bestand geschreven.