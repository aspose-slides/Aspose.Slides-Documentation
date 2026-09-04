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
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro .NET a zjednodušte vyhledávání, branding a workflow ve svých souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides for .NET podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides for .NET.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/). Instanci tohoto rozhraní vrací [IPresentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/documentproperties/). Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Poznámka" %}}
Všimněte si, že pole **Application** a **Producer** nelze upravit, protože tato pole vždy zobrazí „Aspose Ltd.“ a „Aspose.Slides for .NET x.x.x“.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidávání vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují ukládat užitečné informace spolu se soubory. Existují dva typy vlastností dokumentu:

- Systémově definované (vestavěné) vlastnosti
- Uživatelem definované (vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a další.

**Vlastní** vlastnosti jsou definovány uživateli jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou zadány uživatelem.

Pomocí Aspose.Slides pro .NET mohou vývojáři získávat a upravovat jak vestavěné, tak vlastní vlastnosti.

Microsoft PowerPoint umožňuje uživatelům spravovat vlastnosti dokumentu kliknutím na ikonu Office a následným výběrem **Soubor → Informace → Vlastnosti**. Po zvolení **Rozšířené vlastnosti** se zobrazí dialogové okno, kde můžete spravovat všechny vlastnosti dokumentu souboru prezentace.

V dialogovém okně **Vlastnosti** je několik záložek, jako jsou **Obecné**, **Shrnutí**, **Statistiky**, **Obsah** a **Vlastní**. Každá záložka poskytuje možnosti pro konfiguraci konkrétních typů informací souvisejících se souborem PowerPoint. Záložka **Vlastní** slouží ke správě uživatelem definovaných vlastností.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována s nastavením [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) na `false`, její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může nastavit [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true` a číst veřejná metadata bez zadání otevíracího hesla.

`OnlyLoadDocumentProperties` určuje, co Aspose.Slides načte; neprovádí žádné dešifrování. Pokud byly vlastnosti zahrnuty do šifrování, jejich načtení bez hesla selže. Pokud prezentace není šifrována, volba je ignorována a načte se celá prezentace.

Následující příklad ověřuje režim načítání pomocí [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) a poté čte vestavěné vlastnosti pomocí [IPresentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

V tomto režimu není načten obsah snímků. Snímky, předlohy, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat `IsOnlyDocumentPropertiesLoaded` před provedením operace, která vyžaduje kompletní objektový model prezentace.

{{% alert color="warning" title="Bezpečnost" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti společně s prezentací. Udržujte je veřejné pouze tehdy, když indexování, klasifikace, vyhledávání nebo systémy pro správu dokumentů vyžadují specifický přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená s `OnlyLoadDocumentProperties` určena pouze pro čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu jen s metadaty, protože veřejné vlastnosti musí zůstat konzistentní s odpovídajícími daty uvnitř šifrované prezentace. Proto jejich aktualizace vyžaduje správné otevírací heslo a úplné načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/), aktualizuje veřejné vestavěné vlastnosti a výsledek uloží. Poté použije [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/isencrypted/) k ověření, že šifrování je zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které jsou zpřístupněny rozhraním [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **SharedDoc** (indikátor, zda je dokument sdílen mezi různými producenty), **PresentationFormat**, **Subject**, **Title** a další.

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

Úprava vestavěných vlastností souborů prezentace je stejně snadná jako jejich získávání. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude aktualizována. V níže uvedeném příkladu ukazujeme, jak upravit vestavěné vlastnosti dokumentu prezentace.

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

Vlastní vlastnosti prezentace umožňují vývojářům ukládat další metadata nebo konkrétní informace do souboru prezentace. Aspose.Slides usnadňuje vytváření a správu těchto vlastních vlastností programově. Následující příklady ukazují, jak přidat vlastní vlastnosti do vašich prezentací.

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

Aspose.Slides také umožňuje vývojářům snadno získat existující vlastní vlastnosti a upravit jejich hodnoty. Tato funkce pomáhá udržovat přesná metadata a podporuje dynamické aktualizace na základě vstupu uživatele nebo obchodní logiky. Níže uvedené příklady ilustrují, jak získat a aktualizovat hodnoty vlastních vlastností v prezentaci.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Získejte odkaz na objekt typu IDocumentProperties spojený s prezentací.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Získejte a upravte vlastní vlastnosti.
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

## **Živý příklad**

Vyzkoušejte online aplikaci [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odebrat vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte předtím vlastnost odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez kompletního načtení prezentace?**

Ano. Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) a poté [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) k načtení uložených metadat dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/net/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musí být šifrována s nastavením `EncryptDocumentProperties` na `false` a musí být načtena s nastavením `OnlyLoadDocumentProperties` na `true`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, proto aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevíracím heslem.