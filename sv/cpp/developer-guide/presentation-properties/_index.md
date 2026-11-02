---
title: Hantera presentationsegenskaper i C++
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/cpp/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för C++ och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för C++ stöder **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författaren, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" title="Obs" %}}

Aspose.Slides hanterar program‑ och producentmetadata när presentationer sparas; dessa fält identifierar programvaran som skapade utdata.

{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information tillsammans med presentationsinnehållet. De faller in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde‑par.

Aspose.Slides för C++ ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att inspektera dokumentmetadata. Dialogrutan grupperar information i flikar som **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läsa offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras genom att skicka `false` till [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), förblir dess dokumentegenskaper offentliga. En applikation kan då skicka `true` till [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) och läsa den offentliga metadata utan att ange öppningslösenordet.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) styr vad Aspose.Slides laddar; den dekrypterar inget. Om egenskaperna inkluderades i krypteringen misslyckas laddning utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Exemplet kräver en krypterad presentation där dokumentegenskaperna lämnades offentliga. Det verifierar laddningsläget via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) och läser sedan inbyggda egenskaper via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

I detta läge laddas inte bildinnehållet. Bilder, master‑bilder, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Säkerhet" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas genom att skicka `true` till [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det metadata‑endast‑objektet eftersom de offentliga egenskaperna måste förbli konsistenta med motsvarande data i den krypterade presentationen. Att uppdatera dem kräver därför korrekt öppningslösenord och en fullständig laddning.

Exemplet kräver en krypterad PPTX‑presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter använder det [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata utan lösenord för att kontrollera de nya värdena:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Om en applikation inte har behörighet att dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) exponerar inbyggd metadata via typade getters, inklusive [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) och [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Detta exempel öppnar en befintlig presentation och skriver dess lagrade metadata till konsolen. Värdena beror på indata‑presentationen; vissa fält kan vara tomma.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Modifiera inbyggda egenskaper**

För att uppdatera inbyggd metadata, använd set‑metoderna på objektet som returneras av [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Detta exempel öppnar en befintlig presentation, anropar [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), och [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), och sparar sedan den uppdaterade presentationen med [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Den sparade PPTX‑filen innehåller den nya metadata.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Hantera hyperlänkbasen**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) läser den dokument‑nivåbas för relativa hyperlänkar. Detta är användbart när en presentation och dess länkade filer flyttas till en annan plats. Det är skilt från en enskild hyperlänks [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): att ändra basen skriver inte om de lagrade länkadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, t.ex. `target.html`, och en absolut länk, t.ex. `https://example.org/absolute.html`. Det läser den befintliga basen, tilldelar en ny basadress med [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), och sparar och öppnar sedan presentationen igen för att kontrollera värdet. Därefter rensar det basen med `u""` och verifierar det tomma värdet i en separat sparad fil. Ersätt exempel‑basadressen med platsen för dina länkade filer.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

De två verifieringsmeddelandena bör skriva ut `True`. Att rensa basen lämnar de individuella hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på mappen `old`. Efter att ha ändrat basen till mappen `new`, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttat presentationen eller förändrat dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som saknar motsvarande inbyggt fält. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) låter dig tilldela ett värde med egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde, och sparar presentationen med [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Att tilldela ett värde till ett befintligt namn ersätter det egenskapens värde.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Åtkomst och modifiering av anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) för att iterera över dem. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) accepterar ett nollbaserat index och returnerar namnet som används av [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) och [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Exemplet skriver ut varje originalnamn och -värde, ersätter varje värde med en numrerad sträng oavsett ursprunglig typ, och sparar ändringarna. Om det inte finns några anpassade egenskaper gör loopen inga förändringar.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Live‑exempel**

Prova den online‑appen [**Visa och redigera PowerPoint‑metadata**](https://products.aspose.app/slides/metadata) för att se hur du arbetar med dokumentegenskaper via Aspose.Slides‑API‑t:

[![Visa och redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) och sedan [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/cpp/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats genom att skicka `false` till [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), och den måste laddas genom att skicka `true` till [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Kan jag uppdatera en krypterad PPTX‑fil i läge med endast dokumentegenskaper?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så för att uppdatera en krypterad PPTX‑fil krävs att hela presentationen laddas med korrekt öppningslösenord.