---
title: Správa značek a vlastních dat v prezentacích pomocí C++
linktitle: Značky a vlastní data
type: docs
weight: 300
url: /cs/cpp/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní XML část
- metadata XML
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak spravovat značky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro C++, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje se značkami a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako značky nebo vlastní XML části. Značky jsou jednoduché páry klíč‑hodnota ve formě řetězců, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikací specifické XML užitečné části.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, audit a odstraňování vlastních XML částí na úrovních prezentace, snímku a objektu. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata shody, data vazby na šablonu nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentace**

Soubory PPTX – soubory s příponou `.pptx` – jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí spojených pomocí vztahů. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k jiným částem definovaným podle ISO/IEC 29500.

Vlastní data lze uložit jako značky ([ITagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itagcollection/)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/)). Oba jsou k dispozici přes rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Značky ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přiřazeny k prezentaci, snímku nebo objektu.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomdata/get_customxmlparts/) vrací kolekci vlastních XML částí přiřazených konkrétnímu objektu prezentace. Například:

- `presentation->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené samotné prezentaci.
- `slide->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené konkrétnímu snímku.
- `shape->get_CustomData()->get_CustomXmlParts()` obsahuje vlastní XML části přiřazené konkrétnímu objektu.

Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) když potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

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

// Přidání automaticky přiřadí identifikátor. Specifický GUID nastavte pouze v případě potřeby.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Metoda `Add` může také přijímat XML jako pole bajtů nebo proud, což je užitečné, když jsou XML data již dostupná v binární podobě.

### **Přidání vlastní XML části do snímku nebo objektu**

Vlastní XML data mohou být přiřazena konkrétnímu snímku nebo objektu místo celé prezentaci. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

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

Úroveň, na které je část přidána, určuje, která kolekce `get_CustomData()->get_CustomXmlParts()` daného objektu obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata platná pro celý dokument, data na úrovni snímku pro informace, které patří k určitému snímku, a data na úrovni objektu pro metadata spjatá s konkrétním objektem.

### **Výpis a audit všech vlastních XML částí**

Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) k načtení všech vlastních XML částí z prezentace. Každá [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/) poskytuje svůj identifikátor, XML obsah a související schémata jmenných prostorů.

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) vrací XML schémata spojená s vlastní XML částí. Tato informace může být užitečná při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) a `set_XmlAsString` k práci s XML jako řetězcem UTF‑8, nebo [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_xmldata/) a `set_XmlData` k práci s čistými bajty XML. Obě reprezentace lze číst i aktualizovat.

Metoda [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/get_itemid/) vrací GUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Identifikátor může být také změněn pomocí `set_ItemId`, pokud integraci vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah i identifikátor:

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

// XmlData poskytuje stejný XML obsah jako surové bajty.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Nahraďte identifikátor, když to požaduje integrace.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Při přiřazování XML pomocí `set_XmlAsString` nebo `set_XmlData` poskytujte platné, ne‑prázdné XML. Používejte buď textovou, nebo binární reprezentaci podle toho, zda aplikace pracuje převážně s řetězci nebo s bajtovými daty.

### **Odebrání vlastní XML části**

Aspose.Slides nabízí několik způsobů, jak odebrat vlastní XML data:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpart/remove/) odebere vlastní XML část z prezentace.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/remove/) odebere konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/removeat/) odebere část na zadaném indexu kolekce.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/clear/) odebere všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace pomocí reference:

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

Pokud již máte objekt `ICustomXmlPart` a chcete odebrat tuto část z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart->Remove()`.

Můžete také odstranit položku podle indexu:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Vyprázdnění všech vlastních XML částí z kolekce**

Použijte `Clear`, když je potřeba odstranit všechny vlastní XML části spojené s konkrétním objektem prezentace.

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

`Clear` ovlivní jen vybranou kolekci. Například vyprázdnění kolekce snímku nevyprázdní kolekce na úrovni prezentace ani objektu.

Chcete‑li odstranit každou vlastní XML část v prezentaci, projděte `get_AllCustomXmlParts()` a odeberte každou část:

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

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo objektů na stejnou podkladovou vlastní XML část.

Sdílenou část je třeba považovat za jeden datový objekt s více odkazy:

- Aktualizací pomocí `set_XmlAsString`, `set_XmlData` nebo `set_ItemId` měníte podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `get_ItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `get_CustomXmlParts()` ji odebere jen z této kolekce. Použijte `ICustomXmlPart::Remove()`, pokud má být část samotná odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části prověřte kolekce na úrovni objektů, abyste zjistili, zda na ni ještě odkazují další snímky nebo objekty.

Přetížení `Add` vytváří novou vlastní XML část z XML obsahu; neakceptuje existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji setkávány při načítání prezentací, které je již obsahují.

Následující příklad auditu kolekcí na úrovni prezentace, snímku a objektu podle `ItemId` a hlásí části odkazované z více míst:

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

Tento typ auditu je užitečný před modifikací nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou participovat ve více vztazích.

## **Získání hodnot značek**

V Slides odpovídá značka vlastnosti `IDocumentProperties::get_Keywords`. Tento ukázkový kód ukazuje, jak získat hodnotu značky pomocí Aspose.Slides pro C++ pro [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Přidání značek do prezentací**

Aspose.Slides umožňuje přidávat značky do prezentací. Značka typicky sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete pro tento účel přidat značky. Například pokud chcete kategorizovat prezentace ze severoamerických zemí, můžete vytvořit značku „North American“ a přiřadit jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat značku do [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) pomocí Aspose.Slides pro C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Značky lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/):

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

Značky přidané prostřednictvím kolekce `get_CustomData()->get_Tags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury značek PDF při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako značka získat z označeného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **Alternativního textu** objektu (například `shape->set_AlternativeText(u"MyId")`). Po exportu do PDF se Alternativní text může objevit ve struktuře značek PDF.

## **Často kladené otázky**

**Mohu odstranit všechny značky z prezentace, snímku nebo objektu najednou?**

Ano. Kolekce [tag collection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) podporuje operaci [Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jedinou značku podle jejího názvu, aniž bych procházel celou kolekci?**

Použijte [Remove(name)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) pro smazání značky podle jejího klíče.

**Jak mohu získat úplný seznam názvů značek pro analytiku nebo filtrování?**

Použijte [GetNamesOfTags](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/); vrací pole všech názvů značek.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_allcustomxmlparts/) k načtení všech vlastních XML částí v prezentaci.

**Mám použít `get_XmlAsString`/`set_XmlAsString` nebo `get_XmlData`/`set_XmlData` pro aktualizaci vlastní XML části?**

Použijte `get_XmlAsString` a `set_XmlAsString`, když aplikace pracuje s UTF‑8 XML textem. Použijte `get_XmlData` a `set_XmlData`, když je XML již k dispozici jako pole bajtů nebo je výhodnější binární zpracování. Obě reprezentace odkazují na XML obsah téže vlastní XML části.