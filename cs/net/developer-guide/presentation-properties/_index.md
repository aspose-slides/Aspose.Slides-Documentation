---
title: Správa vlastností prezentace v .NET
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/net/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Rozšířené vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk korektury
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zvládněte vlastnosti prezentací v Aspose.Slides pro .NET a zjednodušte vyhledávání, značkování a pracovní postup ve svých souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides for .NET podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides for .NET.

Aspose.Slides umožňuje pracovat s vlastnostmi prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/). Instance tohoto rozhraní je vrácena vlastností [Presentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/documentproperties/). Následující příklady ukazují, jak tyto vlastnosti číst, měnit a spravovat.

{{% alert color="info" %}} 

Všimněte si, že pole **Application** a **Producer** nelze upravit, protože tato pole vždy zobrazí „Aspose Ltd.“ a „Aspose.Slides for .NET x.x.x“.

{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidávání vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu se soubory. Existují dva typy vlastností dokumentu:

- Systémově definované (vestavěné) vlastnosti
- Uživatelem definované (vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a další.

**Vlastní** vlastnosti jsou definovány uživateli jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou zadány uživatelem.

Pomocí Aspose.Slides for .NET mohou vývojáři získat a upravit jak vestavěné, tak vlastní vlastnosti.

Microsoft PowerPoint umožňuje uživatelům spravovat vlastnosti dokumentu kliknutím na ikonu Office a následným výběrem **Soubor → Informace → Vlastnosti**. Po zvolení **Upřesněné vlastnosti** se zobrazí dialog, ve kterém můžete spravovat všechny vlastnosti dokumentu souboru prezentace.

V dialogu **Vlastnosti** jsou k dispozici různé záložky, například **Obecné**, **Shrnutí**, **Statistiky**, **Obsah** a **Vlastní**.  
Každá záložka poskytuje možnosti konfigurace konkrétních typů informací souvisejících se souborem PowerPointu. Záložka **Vlastní** slouží k správě uživatelem definovaných vlastností.

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, jak je vystavuje rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **SharedDoc** (označuje, zda je dokument sdílen mezi různými producenty), **PresentationFormat**, **Subject**, **Title** a další.

```cs
using Aspose.Slides;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Úprava vestavěných vlastností**

Upravit vestavěné vlastnosti souborů prezentace je stejně snadné jako k nim přistupovat. Jednoduše přiřadíte řetězcovou hodnotu k libovolné požadované vlastnosti a hodnota vlastnosti bude aktualizována. V příkladu níže ukazujeme, jak upravit vestavěné vlastnosti dokumentu prezentace.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Získejte odkaz na objekt typu IDocumentProperties přidružený k prezentaci.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Nastavte vestavěné vlastnosti.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Uložte prezentaci do souboru.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Přidání vlastních vlastností prezentace**

Vlastní vlastnosti prezentace umožňují vývojářům uložit další metadata nebo specifické informace v souboru prezentace. Aspose.Slides to usnadňuje vytvořením a správou těchto vlastních vlastností programově. Následující příklady ukazují, jak přidat vlastní vlastnosti do vašich prezentací.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using Presentation presentation = new Presentation();

// Získejte odkaz na objekt typu IDocumentProperties přidružený k prezentaci.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Přidejte vlastní vlastnosti.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Uložte prezentaci do souboru.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Přístup k vlastním vlastnostem a jejich úprava**

Aspose.Slides také umožňuje vývojářům přistupovat k existujícím vlastním vlastnostem a snadno měnit jejich hodnoty. Tato funkčnost pomáhá udržovat přesná metadata a podporuje dynamické aktualizace na základě vstupu uživatele nebo obchodní logiky. Níže uvedené příklady ilustrují, jak načíst a aktualizovat hodnoty vlastních vlastností v prezentaci.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Získejte odkaz na objekt typu IDocumentProperties přidružený k prezentaci.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Získejte přístup a upravte vlastní vlastnosti.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Zobrazte název a hodnotu vlastní vlastnosti.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Upravte hodnotu vlastní vlastnosti.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Uložte prezentaci do souboru.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Zobrazit a upravit metadata PowerPointu**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![Zobrazit a upravit metadata PowerPointu](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***Často kladené otázky**

### Jak mohu odstranit vestavěnou vlastnost z prezentace?

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to daná vlastnost umožňuje.

### Co se stane, když přidám vlastní vlastnost, která již existuje?

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstranit nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

### Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?

Ano, můžete získat přístup k vlastnostem prezentace bez úplného načtení pomocí metody `GetPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/). Poté využijte metodu `ReadDocumentProperties` rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/) k efektivnímu načtení vlastností, čímž šetříte paměť a zvyšujete výkon.