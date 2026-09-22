---
title: Načíst a aktualizovat informace o prezentaci v JavaScriptu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/nodejs-java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí JavaScriptu pro rychlejší získání informací a chytré audity obsahu."
---
## **Přehled**

Aspose.Slides může rozpoznat formát prezentace a přečíst metadata dokumentu, aniž by vytvořil kompletní objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventář nebo zkontrolovat vlastnosti před rozhodnutím, zda načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/), stejně jako cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/).

## **Zkontrolovat formát prezentace**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/nodejs-java/detect-presentation-source-format/) pro detekci po načtení a omezení starších PPT, PPS a POT proudů.

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) k prohlédnutí souboru, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/getloadformat/) vrací detekovaný formát, například PPTX, PPT nebo ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Vytvořit lehkou inventuru prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexování nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) a následně zavolejte [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) k přečtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) ani nevyžaduje procházet kompletní objektový model prezentace.

Rozšířené vlastnosti zpřístupněné pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Inventární hodnota |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getSlides) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getNotes) | Počet snímků, které obsahují poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getWords) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Celkový počet audio a video klipů. |

Následující příklad přečte tyto hodnoty bez vytváření objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a vytiskne kompaktní inventář. Kombinuje také [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) s [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) k zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Každý [HeadingPair](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/) poskytuje název skupiny pomocí [HeadingPair.getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/#getName) a počet položek v této skupině pomocí [HeadingPair.getCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) vrací ploché, uspořádané pole, takže spotřebujte počet po sobě jdoucích názvů určených každým heading pair.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) odrážejí metadata dostupná v původním dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace pro přepočet těchto hodnot při tomto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako heading pairs a part titles. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost nepřítomna nebo nebyla aktualizována výrobcem dokumentu, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty se nepřekládají na všechny PowerPoint‑specifické rozšířené vlastnosti. Metadata pro skryté snímky, poznámky, multimédia, heading‑pair a part‑title mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nevnímejte nulovou hodnotu nebo prázdné pole jako autoritativní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prohlédněte její živý objektový model, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) lze také změnit bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Proveďte změny pomocí [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) a poté zapište svázanou prezentaci pomocí [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Následující obrázek zobrazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad mění název a čas posledního uložení a zapisuje výsledek do nového souboru:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Následující obrázek zobrazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Password-Protect Presentations](/slides/cs/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getfontsmanager/). Zavolejte [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) pro získání vložených písem a [FontsManager.getFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/) pro získání písem používaných v prezentaci. Porovnejte oba výsledky a zjistěte, která písma jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Pokud jsou uložená metadata dokumentu dostačující, přečtěte [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) prostřednictvím [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Toto je vhodné pro lehkou inventuru. Pokud byla prezentace upravena v paměti, mohou být uložená metadata chybějící nebo zastaralá, nebo potřebujete ověřit živé hodnoty – v takovém případě projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) a pro každý snímek zkontrolujte metodu [Slide.getHidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/gethidden/).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímků a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslidesize/). Použijte [SlideSize.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/getsize/) a [SlideSize.getOrientation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/getorientation/) k porovnání aktuálního nastavení s očekávaným předdefinovaným a s rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/) a zavolejte [ChartData.getDataSourceType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Pro externí sešit použijte [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Typ datového zdroje a cesta identifikují externí odkaz, ale ověření dostupnosti cíle vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) a u každého snímku kolekci [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getShapes). Použijte počty tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály pro screening a změřte reprezentativní vykreslení nebo export, než považujete snímek za potvrzený úzký hrnec výkonu.