---
title: Správa tagů a vlastních dat v prezentacích pomocí C++
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/cpp/managing-tags-and-custom-data/
keywords:
  - vlastnosti dokumentu
  - tag
  - vlastní data
  - vlastní XML
  - vlastní XML část
  - XML metadata
  - ItemId
  - přidat tag
  - párové hodnoty
  - PowerPoint
  - prezentace
  - C++
  - Aspose.Slides
description: "Naučte se, jak spravovat tagy a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro C++, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry řetězcových klíč‑hodnota, zatímco vlastní XML části mohou ukládat strukturovaná metadata a XML payloady specifické pro aplikaci.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, audit a odstranění vlastních XML částí na úrovni prezentace, snímku a objektu. Vlastní XML části jsou užitečné pro integrace, které ukládají informace, jako jsou identifikátory správy dokumentů, stav pracovního postupu, metadata související s shodou, data vazby šablon nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí propojených pomocí vztahů. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k dalším částem definovaným normou ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itagcollection/)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/)). Obě jsou přístupné prostřednictvím rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomdata/).

{{% alert color="primary" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přiřazeny k prezentaci, snímku nebo objektu.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomdata/get_customxmlparts/) vrací kolekci vlastních XML částí přiřazených k danému objektu prezentace. Například:

- `presentation->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené přímo k prezentaci.
- `slide->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené k určitému snímku.
- `shape->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené k určitému objektu.

Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) pokud potřebujete prohlédnout všechny vlastní XML části v prezentaci, bez ohledu na to, k čemu jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/add/) k přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

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

// Metoda Add přiřadí identifikátor automaticky. Nastavte konkrétní GUID pouze v případě potřeby.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Metoda `Add` může také přijímat XML jako pole bajtů nebo proud, což je užitečné, když je obsah XML již dostupný v binární podobě.

### **Přidání vlastní XML části do snímku nebo objektu**

Vlastní XML data lze přiřadit k určitému snímku nebo objektu místo celé prezentace. To je užitečné, když metadata popisují pouze jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informační vazbu.

Následující příklad přidává jednu vlastní XML část do snímku a další do objektu:

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

Úroveň, na které je část přidána, určuje, která kolekce objektu `get_CustomData()->get_CustomXmlParts()` obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata platná pro celý dokument, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni objektu pro metadata vázaná na konkrétní objekt.

### **Výpis a audit všech vlastních XML částí**

Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) k získání všech vlastních XML částí z prezentace. Každá [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/) poskytuje svůj identifikátor, XML obsah a přidružené schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

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

`ICustomXmlPart::get_NamespaceSchemas` vrací XML schémata přidružená k vlastní XML části. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) a `set_XmlAsString` pro práci s XML jako řetězcem UTF‑8, nebo [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_xmldata/) a `set_XmlData` pro práci s čistými bajty XML. Obě reprezentace lze číst i aktualizovat.

Metoda [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_itemid/) vrací GUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Identifikátor lze také změnit pomocí `set_ItemId`, když integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah a identifikátor:

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

// Přečtěte aktuální XML jako text.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Aktualizujte XML jako řetězec UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData poskytuje stejný obsah XML jako surové bajty.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Nahraďte identifikátor, pokud to vyžaduje integrace.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Při přiřazování XML pomocí `set_XmlAsString` nebo `set_XmlData` poskytněte platné, ne‑prázdné XML. Použijte jednu nebo druhou reprezentaci podle toho, zda aplikace pracuje primárně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odstranit vlastní XML data:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/remove/) odstraňuje vlastní XML část z prezentace.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/remove/) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/removeat/) odstraňuje část na zadaném indexu kolekce.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/clear/) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle reference:

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

Pokud již máte `ICustomXmlPart` a chcete odstranit tuto část z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart->Remove()`.

Můžete také odstranit položku podle indexu:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Vymazání všech vlastních XML částí z kolekce**

Použijte `Clear`, když je potřeba odstranit všechny vlastní XML části přiřazené k určitému objektu prezentace.

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

`Clear` ovlivňuje pouze vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace nebo objektu.

Pro odstranění všech vlastních XML částí v prezentaci projděte `get_AllCustomXmlParts()` a odstraňte každou část:

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

### **Zpracování propojených nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo objektů ke stejné podkladové vlastní XML části.

Sdílená část by měla být považována za jeden datový objekt s více odkazy:

- Aktualizace pomocí `set_XmlAsString`, `set_XmlData` nebo `set_ItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `get_ItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektu.
- Odstranění části ze specifické kolekce `get_CustomXmlParts()` ji odstraní z této kolekce. Použijte `ICustomXmlPart::Remove()`, když má být samotná část odstraněna z prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektu, abyste zjistili, zda na ni stále odkazují jiné snímky nebo objekty.

Přetížení `Add` vytvoří novou vlastní XML část z XML obsahu; nepřijímají existující `ICustomXmlPart`. Proto se sdílené vztahy nejčastěji vyskytují při načítání prezentací, které je již obsahují.

Následující příklad auditně kontroluje kolekce na úrovni prezentace, snímku a objektu podle `ItemId` a hlásí části, na které se odkazuje více než jedno místo:

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

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata část může být součástí více než jednoho vztahu.

## **Získání hodnot tagů**

V slides tag odpovídá vlastnosti `IDocumentProperties::get_Keywords`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro C++ pro [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete třídit prezentace podle konkrétního pravidla nebo vlastnosti, můžete pro tento účel přidat tagy. Například pokud chcete kategorizovat prezentace ze severoamerických zemí, můžete vytvořit tag North American a přiřadit mu příslušnou zemi jako hodnotu.

Tento ukázkový kód ukazuje, jak přidat tag k [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) pomocí Aspose.Slides pro C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/):

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

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/):

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

### **Omezení**

Tagy přidané přes kolekci `get_CustomData()->get_Tags()` jsou uloženy pouze v souboru PowerPoint. Není **přeneseno** do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho není možné získat vlastní identifikátor přiřazený jako tag z označeného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (například `shape->set_AlternativeText(u\"MyId\")`). Po exportu do PDF se může Alt Text objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu v jedné operaci odstranit všechny tagy z prezentace, snímku nebo objektu?**  
Ano. [tag collection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) podporuje operaci [Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu, aniž bych procházel celou kolekci?**  
Použijte [Remove(name)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) pro smazání tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analytiku nebo filtrování?**  
Použijte [GetNamesOfTags](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/); vrátí pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části, bez ohledu na to, kde jsou uloženy?**  
Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) k získání všech vlastních XML částí v prezentaci.

**Mám pro aktualizaci vlastní XML části použít `get_XmlAsString`/`set_XmlAsString` či `get_XmlData`/`set_XmlData`?**  
Použijte `get_XmlAsString` a `set_XmlAsString`, pokud aplikace pracuje s textem XML v UTF‑8. Použijte `get_XmlData` a `set_XmlData`, pokud je XML již k dispozici jako pole bajtů nebo je vhodnější binární zpracování. Obě reprezentace odkazují na stejný XML obsah vlastní části.