---
title: Správa značek a vlastních dat v prezentacích v .NET
linktitle: Značky a vlastní data
type: docs
weight: 300
url: /cs/net/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní XML část
- XML metadata
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat značky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro .NET, včetně přidání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastním daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota typu string, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikací specifické XML náklady.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata shody, data vazby šablon nebo další strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

PPTX soubory — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k uložení obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí propojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k jiným částem definovaným v ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/itagcollection)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection)). Oba jsou dostupné prostřednictvím rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přiřazeny k prezentaci, snímku nebo tvaru.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Vlastnost [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomdata/customxmlparts/) vrací kolekci vlastních XML částí spojených s konkrétním objektem prezentace. Například:

- `presentation.CustomData.CustomXmlParts` obsahuje vlastní XML části spojené s samotnou prezentací.
- `slide.CustomData.CustomXmlParts` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `shape.CustomData.CustomXmlParts` obsahuje vlastní XML části spojené s konkrétním tvarem.

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) když potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/add/) k přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat úrovně prezentace:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add automaticky přiřadí identifikátor. Nastavte konkrétní GUID pouze v případě potřeby.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Metoda `Add` může také přijímat XML jako pole bajtů nebo proud, což je užitečné, když je XML obsah již k dispozici v binární formě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data lze přiřadit ke konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Úroveň, na které je část přidána, určuje, ve které kolekci `CustomData.CustomXmlParts` daného objektu se vztah k této části nachází. Data na úrovni prezentace jsou vhodná pro metadat a dokument‑rozsáhlé informace, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Výpis a audit všech vlastních XML částí**

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) k získání všech vlastních XML částí z prezentace. Každý [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/) vystavuje svůj identifikátor, XML obsah a související schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/namespaceschemas/) vrací XML schémata přiřazená k vlastnímu XML dílu. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace obsahu XML a ItemId**

Použijte [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/xmlasstring/) k práci s XML jako UTF‑8 řetězcem, nebo [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/xmldata/) k práci s čistými bajty XML. Obě vlastnosti lze číst i měnit.

Vlastnost [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/itemid/) obsahuje GUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Lze jej také změnit, pokud integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah a identifikátor:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Přečtěte aktuální XML jako text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Aktualizujte XML jako řetězec UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData poskytuje stejný obsah XML jako surové bajty.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Nahraďte identifikátor, když to vyžaduje integrace.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Při přiřazování `XmlAsString` nebo `XmlData` použijte platné, ne‑prázdné XML. Zvolte jednu reprezentaci nebo druhou podle toho, zda aplikace pracuje převážně s řetězci nebo s bajtovými daty.

### **Odebrání vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odebrat vlastní XML data:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/remove/) odstraňuje vlastní XML část z prezentace.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/remove/) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/removeat/) odstraňuje část na zadaném indexu kolekce.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/clear/) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část úrovně prezentace podle reference:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Pokud již máte objekt `ICustomXmlPart` a chcete tuto část odebrat z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart.Remove()`.

Můžete také odstranit položku podle indexu:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Vymazání všech vlastních XML částí ze sbírky**

Použijte `Clear`, když mají být odstraněny všechny vlastní XML části spojené s konkrétním objektem prezentace.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` ovlivňuje pouze vybranou sbírku. Například vymazání sbírky snímku nevymaže sbírky na úrovni prezentace nebo tvaru.

Pro odebrání každé vlastní XML části v prezentaci projděte `AllCustomXmlParts` a odstraňte každou část:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Zpracování propojených nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z několika snímků nebo tvarů ke stejné podkladové vlastní XML části.

Sdílenou část je třeba považovat za jediný datový objekt s více odkazy:

- Aktualizace `XmlAsString`, `XmlData` nebo `ItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `ItemId` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektu.
- Odebrání části z konkrétní kolekce `CustomXmlParts` ji odebere pouze z této kolekce. Použijte `ICustomXmlPart.Remove()` pokud má být samotná část odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektu, abyste zjistili, zda na ni stále odkazují jiné snímky nebo tvary.

Přetížení `Add` vytváří novou vlastní XML část z XML obsahu; nepřijímá existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji nahlíženy při načítání prezentací, které je již obsahují.

Následující příklad audituje kolekce úrovně prezentace, snímku a tvaru podle `ItemId` a hlásí části odkazované z více míst:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou participovat v více vztazích.

## **Získání hodnot tagů**

V Slides odpovídá tag vlastnosti `IDocumentProperties.Keywords`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro .NET pro [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Přidání tagů do prezentací**

Aspose.Slides umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete pro tento účel přidávat tagy. Například pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit tag `NorthAmerican` a přiřadit jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat tag k [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) pomocí Aspose.Slides pro .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Omezení**

Tagy přidané přes kolekci `CustomData.Tags` jsou uloženy jen v souboru PowerPoint. **Nejsou** přeneseny do struktury tagů PDF při exportu prezentace do PDF. Výsledkem je, že vlastní identifikátor přiřazený jako tag nelze získat z PDF s tagy.

**Obejití**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape.AlternativeText = "MyId"`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru jedním operací?**

Ano. Kolekce [tagů](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/) podporuje operaci [Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jediný tag podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte `Remove(name)` na [TagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/) k odstranění tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analytiku nebo filtrování?**

Použijte `GetNamesOfTags` na kolekci tagů; vrátí pole se všemi názvy tagů.

**Jak mohu najít všechny vlastní XML části, bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) k získání všech vlastních XML částí v prezentaci.

**Mám použít `XmlAsString` nebo `XmlData` pro aktualizaci vlastní XML části?**

Použijte `XmlAsString`, když aplikace pracuje s UTF‑8 XML textem. Použijte `XmlData`, když je XML již k dispozici jako pole bajtů nebo když je zpracování na úrovni bajtů výhodnější. Obě vlastnosti představují stejný XML obsah vlastní XML části.