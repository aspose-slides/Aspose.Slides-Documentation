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
- Zabudované vlastnosti
- Vlastní vlastnosti
- Rozšířené vlastnosti
- Spravovat vlastnosti
- Upravit vlastnosti
- Metadata dokumentu
- Upravit metadata
- Jazyk korektury
- Výchozí jazyk
- PowerPoint
- OpenDocument
- Prezentace
- .NET
- C#
- Aspose.Slides
description: "Ovládněte vlastnosti prezentace v Aspose.Slides pro .NET a zjednodušte vyhledávání, značkování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro .NET podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí rozhraní Aspose.Slides pro .NET API.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/). Instance tohoto rozhraní je vrácena vlastností [Presentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/documentproperties/). Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Note" %}}
Vezměte prosím na vědomí, že pole **Application** a **Producer** nelze upravit, protože tato pole vždy zobrazí „Aspose Ltd.“ a „Aspose.Slides for .NET x.x.x“.
{{% /alert %}}

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidávání vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu se soubory. Existují dva typy vlastností dokumentu:

- Systémově definované (built-in) vlastnosti
- Uživatelem definované (custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a další.

**Custom** vlastnosti jsou definovány uživateli jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou určeny uživatelem.

Pomocí Aspose.Slides pro .NET mohou vývojáři získat a upravit jak built-in, tak custom vlastnosti.

Microsoft PowerPoint umožňuje uživatelům spravovat vlastnosti dokumentu kliknutím na ikonu Office a poté výběrem **File → Info → Properties**. Po zvolení **Advanced Properties** se zobrazí dialog, ve kterém můžete spravovat všechny vlastnosti dokumentu souboru prezentace.

V dialogu **Properties** je několik záložek, například **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Každá záložka poskytuje možnosti pro konfiguraci konkrétních typů informací souvisejících se souborem PowerPoint. Záložka **Custom** slouží ke správě uživatelem definovaných vlastností.

## **Přístup k built-in vlastnostem**

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

## **Úprava built-in vlastností**

Upravit built-in vlastnosti souborů prezentace je stejně snadné jako k nim přistupovat. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se aktualizuje. V níže uvedeném příkladu ukazujeme, jak upravit built-in vlastnosti dokumentu prezentace.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Získejte odkaz na objekt typu IDocumentProperties spojený s prezentací.
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

Vlastní vlastnosti prezentace umožňují vývojářům uložit další metadata nebo specifické informace v souboru prezentace. Aspose.Slides usnadňuje programové vytváření a správu těchto vlastních vlastností. Následující příklady ukazují, jak přidat vlastní vlastnosti do vašich prezentací.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using Presentation presentation = new Presentation();

// Získejte odkaz na objekt typu IDocumentProperties spojený s prezentací.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Přidejte vlastní vlastnosti.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Uložte prezentaci do souboru.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Přístup a úprava vlastních vlastností**

Aspose.Slides také umožňuje vývojářům přistupovat k existujícím vlastním vlastnostem a snadno měnit jejich hodnoty. Tato funkčnost pomáhá udržovat přesná metadata a podporuje dynamické aktualizace na základě vstupu uživatele nebo obchodní logiky. Níže uvedené příklady ilustrují, jak získat a aktualizovat hodnoty vlastních vlastností v rámci prezentace.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Získejte odkaz na objekt typu IDocumentProperties spojený s prezentací.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Přístup a úprava vlastních vlastností.
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

Vyzkoušejte online aplikaci [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/cs/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odebrat built-in vlastnost z prezentace?**

Built-in vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která už existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Není nutné vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat vlastnosti prezentace, aniž bych načetl celou prezentaci?**

Ano. Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) a následně [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) k načtení uložených metadat dokumentu, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/net/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formáty.