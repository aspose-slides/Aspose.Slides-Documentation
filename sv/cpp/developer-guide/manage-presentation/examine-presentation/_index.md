---
title: Hämta och uppdatera presentationsinformation i C++
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/cpp/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med C++ för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformats format och läsa dess dokumentmetadata utan att skapa en komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du beslutar om du ska ladda och bearbeta presentationsinnehållet.

Den här artikeln demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/) och [IPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/), samt riktade uppdateringar via [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/).

## **Kontrollera ett presentationsformat**

Använd [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instans. Metoden [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_loadformat/) rapporterar det upptäckta formatet, såsom PPTX, PPT eller ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Bygg ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I det här scenariot använder du [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) för att få ett [IPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/) objekt, och sedan anropar du [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar inte en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instans eller kräver att du traverserar den fullständiga presentationsobjektmodellen.

De utökade egenskaperna som exponeras av [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/) tillhandahåller följande inventarievärden:

| Metod | Inventarievärde |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_slides/) | Totalt antal bilder. |
| [get_HiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Antal dolda bilder. |
| [get_Notes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_notes/) | Antal bilder som innehåller anteckningar. |
| [get_Paragraphs](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Totalt antal stycken, när tillgängligt. |
| [get_Words](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_words/) | Totalt antal ord. |
| [get_MultimediaClips](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Totalt antal ljud- och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) objekt och skriver ut ett kompakt inventarium. Det kombinerar också [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_headingpairs/) med [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) för att visa innehållsgrupper såsom typsnitt, teman och bildrubriker.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Varje [IHeadingPair](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iheadingpair/) tillhandahåller ett gruppnamn via [IHeadingPair::get_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iheadingpair/get_name/) och antalet objekt i den gruppen via [IHeadingPair::get_Count](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) returnerar en platt, ordnad array, så konsumera antalet på varandra följande titlar som anges av varje rubrikpar.

### **Lagrad metadata och formatbegränsningar**

Inventarieegenskaperna som returneras av [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjektmodellen för att omräkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild, anteckning, dold bild, stycke, ord och multimediaantal, samt rubrikpar och deltitlar. Tillgänglighet beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterades av dokumentproducenten returnerar Aspose.Slides dess lagrade eller standardvärde istället för att beräkna det från bilderna.
- **ODP:** OpenDocument‑metadata ger allmänna dokumentstatistik, såsom sid-, stycke- och ordantal, men dessa värden motsvarar inte alla PowerPoint‑specifika utökade egenskaper. Metadata för dolda bilder, anteckningsbilder, multimedia, rubrikpar och deltitlar kan vara otillgängliga, och inventarieegenskaperna kan returnera standardvärden. Behandla inte ett nollvärde eller en tom array som bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste återspegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

Egenskaperna som returneras av [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) kan även ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instans. Tillämpa förändringarna med [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), och skriv sedan den bundna presentationen med [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Följande bild visar de ursprungliga dokumentegenskaperna.

![Originala dokumentegenskaper för PowerPoint‑presentationen](input_properties.png)

Följande exempel ändrar titeln och senast sparad tid och skriver resultatet till en ny fil:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Följande bild visar de uppdaterade dokumentegenskaperna.

![Ändrade dokumentegenskaper för PowerPoint‑presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/cpp/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/cpp/write-protected-presentation/)

## **FAQ**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Ladda presentationen och använd [Presentation::get_FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/). Anropa [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getembeddedfonts/) för att hämta de inbäddade teckensnitten och [FontsManager::GetFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getfonts/) för att hämta de teckensnitt som används av presentationen. Jämför de två resultaten för att hitta teckensnitt som krävs för rendering men som inte är inbäddade.

**Hur kan jag snabbt ta reda på om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) via [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) och [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har ändrats i minnet kan den lagrade metadata saknas eller vara föråldrad, eller så behöver du verifiera aktuella värden genom att iterera över [Presentation::get_Slides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slides/) och inspektera varje bilds [Slide::get_Hidden](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/get_hidden/) metod istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Ladda presentationen och läs [Presentation::get_SlideSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slidesize/). Inspektera [ISlideSize::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidesize/get_size/), och [ISlideSize::get_Orientation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidesize/get_orientation/) för att jämföra de aktuella inställningarna med den förväntade förinställningen och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Hitta varje [Chart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/) och inspektera [ChartData::get_DataSourceType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). För en extern arbetsbok, läs [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Datakälltyp och sökväg identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resursskontroll.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ned rendering eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation::get_Slides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slides/) och varje bilds [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_shapes/) samling. Använd antalet former och närvaron av stora bilder, effekter, animationer eller multimedia som indikatorer, och mät en representativ rendering eller export innan du betraktar en bild som en bekräftad prestandaflaskhals.