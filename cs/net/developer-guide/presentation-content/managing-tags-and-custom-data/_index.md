---
title: Správa tagů a vlastních dat v prezentacích v .NET
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/net/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- část vlastního XML
- metadata XML
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat tagy a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro .NET, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota řetězců, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikačně specifické XML náklady.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata souladu, data vázaná na šablonu nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentace**

PPTX soubory — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML stanoví strukturu balíčku a vztahy použité k uložení obsahu prezentace a souvisejících dat.

Prezentace obsahuje několik částí propojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k dalším částem definovaným podle ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/itagcollection)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection)). Oba jsou dostupné prostřednictvím rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Tagy ukládají jednoduché páry klíč‑hodnota jako řetězce. Vlastní XML části ukládají strukturovaná XML data a lze je přiřadit k prezentaci, snímku nebo tvaru.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Vlastnost [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomdata/customxmlparts/) vrací kolekci vlastních XML částí přiřazených k danému objektu prezentace. Například:

- `presentation.CustomData.CustomXmlParts` obsahuje vlastní XML části přiřazené k samotné prezentaci.
- `slide.CustomData.CustomXmlParts` obsahuje vlastní XML části přiřazené k konkrétnímu snímku.
- `shape.CustomData.CustomXmlParts` obsahuje vlastní XML části přiřazené k konkrétnímu tvaru.

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) , pokud potřebujete prohlédnout všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/add/) , aby jste přidali XML data do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

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

// Add přiřadí identifikátor automaticky. Nastavte konkrétní GUID pouze v případě potřeby.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Metoda `Add` může také přijímat XML jako pole bajtů nebo stream, což je užitečné, když je XML obsah již dostupný v binární formě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data mohou být přiřazena k určitému snímku nebo tvaru místo celé prezentace. To je užitečné, když metadata popisují pouze jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

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

Úroveň, na které je část přidána, určuje, která kolekce `CustomData.CustomXmlParts` objektu obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata celého dokumentu, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni tvaru pro metadata vázaná na konkrétní tvar.

### **Vylistování a audit všech vlastních XML částí**

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) , abyste získali všechny vlastní XML části z prezentace. Každý [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/) odhaluje svůj identifikátor, XML obsah a přidružené schémata jmenných prostorů.

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/namespaceschemas/) vrací XML schémata přidružená k vlastní XML části. Tato informace může být užitečná při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/xmlasstring/) , abyste pracovali s XML jako UTF‑8 řetězcem, nebo [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/xmldata/) , pro práci s raw bajty XML. Obě vlastnosti lze číst i aktualizovat.

Vlastnost [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/itemid/) obsahuje GUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Může být také změněna, pokud integrace vyžaduje nový identifikátor.

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

// XmlData poskytuje stejný XML obsah jako surové bajty.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Nahraďte identifikátor, pokud to vyžaduje integrace.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Při přiřazování `XmlAsString` nebo `XmlData` poskytujte platné, neprázdné XML. Použijte jednu nebo druhou reprezentaci v závislosti na tom, zda aplikace pracuje především s řetězci nebo binárními daty.

### **Odstranění vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odstranit vlastní XML data:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpart/remove/) odstraňuje vlastní XML část z prezentace.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/remove/) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/removeat/) odstraňuje část na zadaném indexu kolekce.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection/clear/) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle reference:

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

Pokud již máte `ICustomXmlPart` a chcete odstranit tuto část z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart.Remove()`.

Můžete také odstranit položku podle indexu:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Vymazání všech vlastních XML částí z kolekce**

Použijte `Clear`, když je potřeba odstranit všechny vlastní XML části přiřazené k určitému objektu prezentace.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` ovlivňuje pouze vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace nebo tvaru.

Chcete‑li odstranit každou vlastní XML část v prezentaci, projděte `AllCustomXmlParts` a odstraňte každou část:

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

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo tvarů ke stejné podkladové vlastní XML části.

Sdílenou část je třeba považovat za jeden datový objekt s více odkazy:

- Aktualizace jejího `XmlAsString`, `XmlData` nebo `ItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je tato část odkazována.
- `ItemId` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `CustomXmlParts` ji odebere z této kolekce. Použijte `ICustomXmlPart.Remove()`, pokud má být samotná část odstraněna z prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektů, abyste zjistili, jestli ji stále odkazují jiné snímky nebo tvary.

Přetížení `Add` vytváří novou vlastní XML část z XML obsahu; nepřijímají existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji zaznamenány při načítání prezentací, které je již obsahují.

Následující příklad provádí audit kolekcí na úrovni prezentace, snímku a tvaru podle `ItemId` a hlásí části, na které se odkazuje z více než jednoho místa:

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

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata část může být součástí více než jednoho vztahu.

## **Získání hodnot tagů**

V prezentacích odpovídá tag vlastnosti `IDocumentProperties.Keywords`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro .NET pro [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat tagy pro tento účel. Například pokud chcete kategorizovat prezentace z severoamerických zemí, můžete vytvořit tag North American a přiřadit mu jako hodnotu příslušnou zemi.

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

Tagy přidané přes kolekci `CustomData.Tags` jsou uloženy pouze v souboru PowerPoint. Není **přeneseno** do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako tag získat z tagovaného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (například `shape.AlternativeText = "MyId"`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru jedním krokem?**

Ano. [kolekce tagů](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/) podporuje operaci [Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu bez iterace celou kolekcí?**

Použijte [Remove(name)](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/), abyste smazali tag podle jeho klíče.

**Jak mohu získat kompletní seznam názvů tagů pro analytiku nebo filtrování?**

Použijte [GetNamesOfTags](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/getnamesoftags/) na [kolekci tagů](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/); vrátí pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/allcustomxmlparts/) , abyste získali všechny vlastní XML části v prezentaci.

**Mám pro aktualizaci vlastní XML části použít `XmlAsString` nebo `XmlData`?**

Použijte `XmlAsString`, pokud aplikace pracuje s UTF‑8 XML textem. Použijte `XmlData`, pokud je XML již dostupné jako pole bajtů nebo je vhodnější binární zpracování. Obě vlastnosti představují XML obsah téže vlastní XML části.