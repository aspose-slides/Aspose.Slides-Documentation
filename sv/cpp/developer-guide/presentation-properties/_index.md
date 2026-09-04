---
title: Hantera presentationsegenskaper i C++
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/cpp/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för C++ och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_documentproperties/). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att du inte kan sätta värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides för C++ x.x.x kommer att visas i dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfiler. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper:

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**-par, där både namn och värde anges av användaren. Med Aspose.Slides för C++ kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper. Microsoft PowerPoint 2007 låter dig hantera dokumentegenskaperna i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007. När du väljer menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna i PowerPoint‑filen. I **Properties Dialog** kan du se flera flikar såsom **General, Summary, Statistics, Contents och Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper i PowerPoint‑filerna.

## **Läsa offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras genom att skicka `false` till [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), förblir dess dokumentegenskaper offentliga. En applikation kan då skicka `true` till [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) och läsa den offentliga metadata utan att ange öppningslösenordet.

`set_OnlyLoadDocumentProperties` styr vad Aspose.Slides laddar; den dekrypterar ingenting. Om egenskaperna var inkluderade i krypteringen misslyckas laddningen utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) och läser sedan inbyggda egenskaper via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

I detta läge laddas inte bildinnehållet. Bilder, master‑bilder, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera `get_IsOnlyDocumentPropertiesLoaded` innan en operation som kräver hela presentationsobjektmodellen utförs.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper i en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas efter anropet `set_OnlyLoadDocumentProperties(true)` avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från ett sådant metadata‑endast‑objekt eftersom de offentliga egenskaperna måste förbli i samklang med motsvarande data i den krypterade presentationen. Uppdatering kräver därför rätt öppningslösenord och en fullständig laddning.

Följande exempel öppnar presentationen med [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter används [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) för att verifiera att krypteringen bevaras och den offentliga metadata öppnas utan lösenord för att verifiera de nya värdena:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Om en applikation inte får dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Komma åt inbyggda egenskaper**

Dessa egenskaper som exponeras av **IDocumentProperties**‑objektet inkluderar: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så modifieras egenskapsvärdet. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna i presentationsfilen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides för C++ låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel visas nedan som visar hur man sätter anpassade egenskaper för en presentation.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Skapa ett Presentation-objekt
auto presentation = System::MakeObject<Presentation>();

// Hämtar dokumentegenskaper
auto documentProperties = presentation->get_DocumentProperties();

// Lägger till anpassade egenskaper
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Hämtar egenskapsnamn på ett visst index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Tar bort vald egenskap
documentProperties->RemoveCustomProperty(getPropertyName);

// Sparar presentationen
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Komma åt och ändra anpassade egenskaper**

Aspose.Slides för C++ låter också utvecklare komma åt värdena för anpassade egenskaper. Ett exempel visas nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen [LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) (exponeras av klassen [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/)) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk för vilket stavning och grammatik kontrolleras i PowerPoint.

Denna C++‑kod visar hur du ställer in korrekturläsningsspråket för en PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ställ in standardspråk**

Denna C++‑kod visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Lägg till en ny rektangelform med text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kontrollerar det första portionsspråket
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑app för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **Vanliga frågor**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egendom som redan finns?**

Om du lägger till en anpassad egendom som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egendomen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egendomens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) och sedan [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/cpp/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats genom att skicka `false` till `set_EncryptDocumentProperties`, och den måste laddas genom att skicka `true` till `set_OnlyLoadDocumentProperties`.

**Kan jag uppdatera en krypterad PPTX‑fil i läge som endast läser dokumentegenskaper?**

Nej. Offentliga och krypterade egenskapsdata måste förbli i samklang, så uppdatering av en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.