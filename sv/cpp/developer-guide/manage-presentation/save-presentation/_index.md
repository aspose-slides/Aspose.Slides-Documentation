---
title: Spara presentationer i C++
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/cpp/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- spara framsteg
- C++
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i C++ med Aspose.Slides – exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Open Presentations in C++](/slides/sv/cpp/open-presentation/) beskrev hur man använder [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från grunden eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för C++ kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassens `Save`‑metod. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Gör lite arbete här...

// Spara presentationen till en fil.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utgångsström till [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassens `Save`‑metod. En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Spara presentationen till strömmen.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ställa in den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/)‑klassen. Använd [set_LastView](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/set_lastview/)‑metoden med ett värde från [ViewType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewtype/)‑enumerationen.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Spara presentationer i strikt Office Open XML‑format**

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML‑formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/)‑klassen och sätt dess **conformance**‑egenskap när du sparar. Om du sätter `Conformance.Iso29500_2008_Strict` sparas utdatafilen i det strikta Office Open XML‑formatet.

Exemplet nedan skapar en presentation och sparar den i det strikta Office Open XML‑formatet.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Spara presentationen i det Strikta Office Open XML-formatet.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har en gräns på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala arkivstorleken, samt en gräns på 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa begränsningar till 2^64.

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/)‑metoden låter dig välja när ZIP64‑formatutökningar ska användas vid sparning av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- `IfNecessary` använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- `Never` använder aldrig ZIP64‑formatutökningar.
- `Always` använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur man sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med `Zip64Mode.Never` kastas ett [PptxException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyren**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/)‑metoden kontrollerar miniatyrgenerering när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyren under sparning. Detta är standard.
- Om den är satt till `false` bevaras den befintliga miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att miniatyren uppdateras.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara framstegsuppdateringar i procent**

[IProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/)‑gränssnittet används via `set_ProgressCallback`‑metoden som exponeras av [ISaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isaveoptions/)‑gränssnittet och den abstrakta [SaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/)‑klassen. Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/)‑implementation med `set_ProgressCallback` för att ta emot sparnings‑framstegsuppdateringar i procent.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Använd procentvärdet för framsteg här.
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
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds "snabbspara" (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell "snabbspara" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans är inte trådsäker; spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/cpp/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt—se till att de refererade sökvägarna fortfarande är tillgängliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standarddokumentegenskaper stöds och kommer att skrivas till filen vid sparning.