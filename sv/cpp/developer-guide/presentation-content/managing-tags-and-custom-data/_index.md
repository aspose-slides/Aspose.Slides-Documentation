---
title: Hantera taggar och anpassad data i presentationer med C++
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/cpp/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- parvärden
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassad XML‑data i PowerPoint‑presentationer med Aspose.Slides för C++, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint‑presentationer. Presentationsspecifik data kan lagras som taggar eller anpassade XML‑delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML‑delar kan lagra strukturerad metadata och applikationsspecifik XML‑payload.

Aspose.Slides tillhandahåller API‑er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar på presentations‑, bild‑ och formnivå. Anpassade XML‑delar är användbara för integrationer som lagrar information såsom dokumenthanterings‑identifierare, arbetsflödes‑status, efterlevnadsmetadata, mallbindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datainlagring i presentationsfiler**

PPTX‑filer – filer med filändelsen `.pptx` – lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar kopplade med relationer. Till exempel innehåller en bilddel innehållet i en enda bild och kan ha explicita relationer till andra delar som definieras av ISO/IEC 29500.

Anpassad data kan lagras som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itagcollection/)) eller anpassade XML‑delar ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/)). Båda är tillgängliga via [`ICustomData`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomdata/)‑gränssnittet.

{{% alert color="info" %}}
Taggar lagrar enkla sträng‑nyckel‑värde‑par. Anpassade XML‑delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML‑delar**

Metoden [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomdata/get_customxmlparts/) returnerar samlingen av anpassade XML‑delar som är kopplade till ett visst presentationsobjekt. Till exempel:

- `presentation->get_CustomData()->get_CustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till själva presentationen.
- `slide->get_CustomData()->get_CustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till en specifik bild.
- `shape->get_CustomData()->get_CustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till en specifik form.

Använd [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_allcustomxmlparts/) när du behöver inspektera alla anpassade XML‑delar i presentationen oavsett var de är kopplade.

### **Lägg till en anpassad XML‑del i en presentation**

Använd [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/add/) för att lägga till XML‑data i en samling av anpassade XML‑delar. XML‑innehållet måste vara giltigt och icke‑tomt.

Följande exempel lägger till strukturerad metadata i presentationsnivåns anpassade datainsamling:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add tilldelar en identifierare automatiskt. Ange ett specifikt GUID endast när det krävs.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add`‑metoden kan också ta emot XML som en byte‑array eller ström, vilket är användbart när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML‑del i en bild eller form**

Anpassad XML‑data kan associeras med en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata beskriver endast ett objekt, t.ex. en mallnyckel, extern post‑identifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML‑del i en bild och en annan i en form:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Nivån där en del läggs till bestämmer vilken objekts `get_CustomData()->get_CustomXmlParts()`‑samling som innehåller relationen till den delen. Data på presentationsnivå är lämplig för dokumentomfattande metadata, bildnivå för information som tillhör en särskild bild och formnivå för metadata kopplad till en enskild form.

### **Lista och granska alla anpassade XML‑delar**

Använd [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_allcustomxmlparts/) för att hämta alla anpassade XML‑delar från en presentation. Varje [`ICustomXmlPart`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/) exponerar sitt identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML‑delar och deras namnrymdsscheman:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) returnerar XML‑schemana som är associerade med den anpassade XML‑delen. Informationen kan vara användbar vid granskning av presentationer som innehåller XML producerad av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) och `set_XmlAsString` för att arbeta med XML som en UTF‑8‑sträng, eller [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/get_xmldata/) och `set_XmlData` för att arbeta med de råa XML‑bytena. Båda representationerna kan läsas och uppdateras.

Metoden [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/get_itemid/) returnerar GUID‑en som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Identifieraren kan också ändras med `set_ItemId` när en integration kräver ett nytt ID.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Läs den aktuella XML som text.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Uppdatera XML som en UTF-8-sträng.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData tillhandahåller samma XML-innehåll som råa byte.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Ersätt identifieraren när integrationen kräver det.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

När du tilldelar XML med `set_XmlAsString` eller `set_XmlData`, ange giltig, icke‑tom XML. Använd den ena eller den andra representationen beroende på om applikationen primärt arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML‑del**

Aspose.Slides erbjuder flera sätt att ta bort anpassad XML‑data:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpart/remove/) tar bort den anpassade XML‑delen från presentationen.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/remove/) tar bort en specifik del från en samling av anpassade XML‑delar.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/removeat/) tar bort delen på ett angivet index i samlingen.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/clear/) tar bort alla delar från en specifik samling.

Följande exempel tar bort en anpassad XML‑del på presentationsnivå genom referens:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Om du redan har ett `ICustomXmlPart` och vill ta bort den delen från presentationen snarare än att rikta in dig på en viss samling, anropa `customXmlPart->Remove()`.

Du kan också ta bort ett objekt efter index:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Rensa alla anpassade XML‑delar i en samling**

Använd `Clear` när alla anpassade XML‑delar som är kopplade till ett visst presentationsobjekt ska tas bort.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` påverkar endast den valda samlingen. Att rensa en bilds samling rensar t.ex. inte samlingarna på presentations‑ eller formnivå.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom `get_AllCustomXmlParts()` och ta bort varje del:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Hantera länkade eller delade anpassade XML‑delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från fler än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande anpassade XML‑del.

En delad del bör behandlas som ett dataobjekt med flera referenser:

- Att uppdatera den med `set_XmlAsString`, `set_XmlData` eller `set_ItemId` ändrar den underliggande anpassade XML‑delen, så ändringen gäller överallt där delen refereras.
- `get_ItemId()` kan användas för att identifiera samma anpassade XML‑del vid granskning av objekt‑nivå‑samlingar.
- Att ta bort en del från en specifik `get_CustomXmlParts()`‑samling tar bort den endast från den samlingen. Använd `ICustomXmlPart::Remove()` när själva delen ska tas bort från presentationen.
- Innan du raderar eller ersätter en delad del, inspektera objekt‑nivå‑samlingarna för att avgöra om andra bilder eller former fortfarande refererar den.

`Add`‑överlagringarna skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte en befintlig `ICustomXmlPart`. Därför möts delade relationer oftast när presentationer som redan innehåller dem laddas.

Följande exempel granskar presentations‑, bild‑ och form‑samlingar efter `ItemId` och rapporterar delar som refereras från mer än ett ställe:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Denna typ av granskning är användbar innan du modifierar eller tar bort anpassad XML‑data i presentationer som skapats av externa system, eftersom samma metadata‑del kan delta i fler än en relation.

## **Hämta taggvärden**

I Slides motsvarar en tagg egenskapen `IDocumentProperties::get_Keywords`. Detta exempel visar hur man får taggvärdet med Aspose.Slides för C++ för [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egenskap, t.ex. `MyTag`;
- värdet för den anpassade egenskapen, t.ex. `My Tag Value`.

Om du behöver klassificera presentationer enligt en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från nordamerikanska länder, kan du skapa en nordamerikansk tagg och tilldela det respektive landet som värde.

Detta exempel visar hur man lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) med Aspose.Slides för C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/):

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Begränsningar**

Taggar som läggs till via samlingen `get_CustomData()->get_Tags()` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som sparats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape->set_AlternativeText(u"MyId")`). Efter export till PDF kan Alt‑Texten visas i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en enda operation?**

Ja. [tag collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/) stödjer en [Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/clear/)‑operation som raderar alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd [Remove(name)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/remove/) på [TagCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/) för att radera taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan över taggnamn för analys eller filtrering?**

Använd [GetNamesOfTags](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/getnamesoftags/) på [tag collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur hittar jag alla anpassade XML‑delar oavsett var de lagras?**

Använd [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_allcustomxmlparts/) för att hämta alla anpassade XML‑delar i presentationen.

**Ska jag använda `get_XmlAsString`/`set_XmlAsString` eller `get_XmlData`/`set_XmlData` för att uppdatera en anpassad XML‑del?**

Använd `get_XmlAsString` och `set_XmlAsString` när applikationen arbetar med UTF‑8‑XML‑text. Använd `get_XmlData` och `set_XmlData` när XML redan finns som en byte‑array eller när binär‑orienterad behandling är mer bekväm. Båda representationerna refererar till XML‑innehållet i samma anpassade XML‑del.