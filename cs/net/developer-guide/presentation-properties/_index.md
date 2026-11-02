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
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
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

Aspose.Slides pro .NET podporuje **vestavěné** a **vlastní** vlastnosti dokumentu. Použijte tyto vlastnosti k načtení a aktualizaci metadat prezentace, jako je autor, název a uživatelem definované hodnoty.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena pomocí [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Note" %}}
Aspose.Slides spravuje metadata aplikace a výrobce při ukládání prezentací; tato pole identifikují software, který výstup vytvořil.
{{% /alert %}}

## **Správa vlastností prezentace**

Vlastnosti dokumentu ukládají popisné informace vedle obsahu prezentace. Rozdělují se do dvou kategorií:

- **Vestavěné vlastnosti** obsahují standardní metadata, jako je název, autor a statistiky dokumentu.
- **Vlastní vlastnosti** ukládají páry název/hodnota definované uživatelem.

Aspose.Slides pro .NET poskytuje přístup k oběma kategoriím. V PowerPointu vyberte **File → Info → Properties → Advanced Properties** pro prohlédnutí metadat dokumentu. Dialog seskupuje informace do záložek jako **Summary**, **Statistics**, **Contents** a **Custom**. Použijte záložku **Custom** pro správu uživatelem definovaných vlastností.

## **Čtení veřejných vlastností z šifrované prezentace**

Cílové heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována pomocí [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) nastaveného na `false`, zůstávají její vlastnosti dokumentu veřejné. Aplikace pak může nastavit [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true` a číst veřejná metadata bez zadání otevíracího hesla.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) řídí, co Aspose.Slides načítá; neprovádí žádné dešifrování. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Příklad vyžaduje šifrovanou prezentaci, jejíž vlastnosti dokumentu byly ponechány veřejné. Ověřuje režim načítání pomocí [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) a poté čte vestavěné vlastnosti pomocí [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

V tomto režimu se nenačítá obsah snímků. Snímky, předlohy, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/), než provádějí operaci vyžadující kompletní model objektů prezentace.

{{% alert color="warning" title="Security" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Nechte je veřejné pouze tehdy, když indexování, klasifikace, vyhledávání nebo systémy pro správu dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená pomocí [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) určena pro čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu obsahujícího pouze metadata, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace tedy vyžaduje správné otevírací heslo a úplné načtení.

Příklad vyžaduje šifrovanou PPTX prezentaci s veřejnými vlastnostmi dokumentu a známým otevíracím heslem. Otevře kompletní prezentaci pomocí [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), aktualizuje veřejné vestavěné vlastnosti a uloží výsledek. Poté použije [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) , aby ověřil, že šifrování bylo zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Pokud aplikace není oprávněna dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Rozhraní [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) poskytuje vestavěná metadata prostřednictvím typovaných vlastností, včetně [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), a [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Tento příklad otevře existující prezentaci a vypíše její uložená metadata do konzole. Hodnoty závisí na vstupní prezentaci; některá pole mohou být prázdná.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **Úprava vestavěných vlastností**

Pro aktualizaci vestavěných metadat přiřaďte hodnoty zapisovatelným vlastnostem poskytovaným prostřednictvím [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Tento příklad otevře existující prezentaci, nastaví [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), a [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), poté uloží aktualizovanou prezentaci pomocí [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Uložený PPTX obsahuje nová metadata.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Správa základní adresy hypertextových odkazů**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) ukládá úroveň dokumentu jako základ pro relativní hypertextové odkazy. To je užitečné při přesunu prezentace a souvisejících souborů na jiné místo. Je oddělený od individuálního odkazu [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/): změna základu nepřepíše uložené adresy odkazů ani nezmění absolutní cíle.

Příklad vyžaduje prezentaci obsahující jak relativní odkaz, například `target.html`, tak absolutní odkaz, například `https://example.org/absolute.html`. Načte existující základ, přiřadí novou základní adresu a uloží a znovu otevře prezentaci pro kontrolu hodnoty. Poté vymaže základ pomocí `string.Empty` a ověří prázdnou hodnotu v samostatném uloženém souboru. Nahraďte ukázkovou základní adresu umístěním vašich odkazovaných souborů.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Dvě ověřovací zprávy by měly vypsat `True`. Vymazání základu ponechá jednotlivé adresy hypertextových odkazů nedotčeny.

Relativní odkaz na `target.pptx` otevřel `old/target.pptx`, když základ ukazoval na složku `old`. Po změně základu na složku `new`, uložení a znovu otevření prezentace otevřel stejný odkaz `new/target.pptx`. Absolutní odkaz nadále otevíral stejný soubor. Otestujte své relativní odkazy v PowerPointu před a po přesunu prezentace nebo změně jejího základu.

## **Přidání vlastních vlastností prezentace**

Vlastní vlastnosti ukládají metadata, která nemají odpovídající vestavěné pole. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) vám umožňuje přiřadit hodnotu podle názvu vlastnosti. Tento příklad vytvoří prezentaci, přidá dva textové hodnoty a celočíselnou verzi a uloží prezentaci pomocí [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Přiřazení hodnoty k existujícímu názvu nahradí hodnotu této vlastnosti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Přístup a úprava vlastních vlastností**

Tento příklad otevře prezentaci obsahující vlastní vlastnosti a použije [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) , aby je iteroval. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) přijímá index od nuly a vrací název použitý [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Příklad vytiskne každý původní název a hodnotu, nahradí každou hodnotu číslovaným řetězcem bez ohledu na původní typ a uloží změny. Pokud neexistují žádné vlastní vlastnosti, smyčka neprovede žádné změny.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Zobrazit a upravit metadata PowerPoint**](https://products.aspose.app/slides/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je úplně odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje její hodnotu.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) a poté [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/), abyste načetli uložená metadata dokumentu, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/net/examine-presentation/) pro kompletní ukázku reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez otevíracího hesla?**

Ano. Prezentace musí být šifrována pomocí [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) nastaveného na `false` a musí být načtena s [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) nastaveným na `true`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení kompletní prezentace se správným otevíracím heslem.