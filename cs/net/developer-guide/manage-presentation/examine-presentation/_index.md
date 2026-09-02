---
title: Získání a aktualizace informací o prezentaci v .NET
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
- měnit vlastnosti
- modifikovat vlastnosti
- aktualizovat vlastnosti
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v PowerPoint a OpenDocument prezentacích pomocí .NET pro rychlejší přehledy a chytřejší audit obsahu."
---
## **Přehled**

Aspose.Slides dokáže rozpoznat formát prezentace a přečíst její metadata dokumentu, aniž by vytvořil kompletní objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventuru nebo zkontrolovat vlastnosti, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/), stejně jako cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/).

## **Zkontrolovat formát prezentace**

Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) k prozkoumání souboru bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Vlastnost [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/loadformat/) uvádí detekovaný formát, například PPTX, PPT nebo ODP.

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

## **Vytvořit lehkou inventuru prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventuru pro validaci, indexování nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) k přečtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) ani nevyžaduje procházení kompletního objektového modelu prezentace.

Rozšířené vlastnosti vystavené [IDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/) poskytují následující hodnoty inventáře:

| Vlastnost | Hodnota inventáře |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/slides/cs/) | Celkový počet snímků. |
| [HiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/hiddenslides/) | Počet skrytých snímků. |
| [Notes](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/notes/) | Počet snímků, které obsahují poznámky. |
| [Paragraphs](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [Words](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/words/) | Celkový počet slov. |
| [MultimediaClips](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/multimediaclips/) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty bez vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a vytiskne kompaktní inventuru. Také kombinuje [HeadingPairs](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/headingpairs/) s [TitlesOfParts](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/titlesofparts/) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

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

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/net/aspose.slides/iheadingpair/) poskytuje název skupiny a počet položek v této skupině. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/titlesofparts/) je ploché, seřazené pole, takže spotřebujte počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace, aby pro tento hovor přepočítal tyto hodnoty. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počet snímků, poznámek, skrytých snímků, odstavců, slov a multimediálních klipů, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány producentem dokumentu.
- **PPT:** Binární formát může ukládat odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost nepřítomna nebo ji producent dokumentu neaktualizoval, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu z snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty se nepřevádějí na všechny rozšířené vlastnosti specifické pro PowerPoint. Metadata pro skryté snímky, poznámkové snímky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nepovažujte nulovou hodnotu nebo prázdné pole za autoritativní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventury a předběžné kontroly. Načtěte prezentaci a prověřte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/) mohou být také změněny bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Aplikujte změny pomocí [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) a poté zapište vázanou prezentaci pomocí [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Následující obrázek zobrazuje původní vlastnosti dokumentu PowerPoint prezentace.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad změní název a čas posledního uložení a výsledek zapíše do nového souboru:

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

Následující obrázek zobrazuje změněné vlastnosti dokumentu PowerPoint prezentace.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Prezentace chráněné heslem](/slides/cs/net/password-protected-presentation/)
- [Prezentace chráněné proti zápisu](/slides/cs/net/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložená a která to jsou?**

Načtěte prezentaci a použijte [Presentation.FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/). Zavolejte [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) pro získání vložených písem a [FontsManager.GetFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/) pro získání písem používaných v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložená.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Pokud jsou uložená metadata dokumentu dostačující, přečtěte [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/hiddenslides/) pomocí [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/readdocumentproperties/). To je vhodné pro lehkou inventuru. Pokud byla prezentace změněna v paměti, uložená metadata mohou chybět nebo být zastaralá, nebo pokud potřebujete ověřit živé hodnoty, projděte [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) a zkontrolujte vlastnost [Slide.Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/) u každého snímku.

**Mohu zjistit, zda jsou použity vlastní rozměry a orientace snímků, a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation.SlideSize](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slidesize/). Prozkoumejte [ISlideSize.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/size/) a [ISlideSize.Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/orientation/) a porovnejte aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/) a prohlédněte [ChartData.DataSourceType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/). Pro externí sešit přečtěte [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdrojů.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Procházejte [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) a každou kolekci [IBaseSlide.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/shapes/). Používejte počty tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály, a změřte reprezentativní vykreslení nebo export, než označíte snímek za potvrzený úzký bod výkonu.