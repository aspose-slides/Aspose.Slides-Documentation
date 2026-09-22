---
title: Načtení a aktualizace informací o prezentaci v .NET
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/net/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- zkontrolovat PPTX
- zkontrolovat PPT
- zkontrolovat ODP
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí .NET pro rychlejší poznání a chytřejší audit obsahu."
---
## **Přehled**

Aspose.Slides může identifikovat formát prezentace a načíst její metadata dokumentu, aniž by vytvářelo kompletní objektový model prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo prověřit vlastnosti před rozhodnutím, zda načíst a zpracovat obsah prezentace.

Tento článek demonstruje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/), a také cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/).

## **Kontrola formátu prezentace**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/net/detect-presentation-source-format/) pro detekci po načtení a omezení legacy formátů PPT, PPS a POT.

Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) k inspekci souboru, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Vlastnost [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/loadformat/) uvádí detekovaný formát, například PPTX, PPT nebo ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Vytvoření lehkého inventáře prezentací**

Když zpracováváte mnoho souborů s prezentacemi, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) ani nevyžaduje procházení kompletním objektovým modelem prezentace.

Rozšířené vlastnosti zpřístupněné přes [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/) poskytují následující hodnoty inventáře:

| Vlastnost | Hodnota inventáře |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/slides/cs/) | Celkový počet snímků. |
| [HiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/hiddenslides/) | Počet skrytých snímků. |
| [Notes](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/notes/) | Počet snímků obsahujících poznámky. |
| [Paragraphs](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [Words](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/words/) | Celkový počet slov. |
| [MultimediaClips](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/multimediaclips/) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty bez vytváření objektu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a vytiskne kompaktní inventář. Kombinuje také [HeadingPairs](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/headingpairs/) s [TitlesOfParts](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/titlesofparts/) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/net/aspose.slides/iheadingpair/) poskytuje název skupiny a počet položek v této skupině. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/titlesofparts/) je ploché, uspořádané pole, takže zpracujte počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátů**

Vlastnosti inventáře vrácené metodou [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace, aby pro tento hovor přepočítalo tyto hodnoty. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající souhrnné vlastnosti dokumentu. Pokud je vlastnost nepřítomna nebo nebyla výrobcem dokumentu obnovena, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecnou statistiku dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nepovažujte nulovou hodnotu ani prázdné pole za definitní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prohlédněte její živý objektový model, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) lze také změnit bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Proveďte změny pomocí [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) a poté zapište svázanou prezentaci pomocí [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Následující obrázek ukazuje původní vlastnosti dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

Následující příklad mění název a čas posledního uložení a zapisuje výsledek do nového souboru:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Následující obrázek ukazuje aktualizované vlastnosti dokumentu.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany se podívejte na následující články:

- [Zabezpečit prezentace heslem](/slides/cs/net/password-protected-presentation/)
- [Zabezpečit prezentace proti zápisu](/slides/cs/net/write-protected-presentation/)

## **Časté dotazy**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/). Zavolejte [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) k získání vložených fontů a [FontsManager.GetFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/) k získání fontů používaných v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostačující, přečtěte [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/hiddenslides/) prostřednictvím [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/). To je vhodné pro lehký inventář. Pokud byla prezentace změněna v paměti, uložená metadata mohou chybět nebo být zastaralá, nebo potřebujete ověřit živé hodnoty – projděte [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) a prozkoumejte vlastnost [Slide.Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní rozměry a orientace snímků a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation.SlideSize](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slidesize/). Prohlédněte [ISlideSize.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/size/) a [ISlideSize.Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/orientation/) a porovnejte aktuální nastavení s očekávanými přednastaveními a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/) a prohlédněte [ChartData.DataSourceType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/). Pro externí sešit načtěte [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediné měřítko složitosti. Projděte [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) a kolekci [IBaseSlide.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/shapes/) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací či multimédií jako signály pro výběr, a změřte reprezentativní render nebo export, než označíte snímek za potvrzený úzký tah výkonu.