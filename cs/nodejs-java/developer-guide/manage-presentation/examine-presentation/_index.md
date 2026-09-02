---
title: Načtení a aktualizace informací o prezentaci v JavaScriptu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/nodejs-java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získání vlastností
- čtení vlastností
- změna vlastností
- modifikace vlastností
- aktualizace vlastností
- prozkoumání PPTX
- prozkoumání PPT
- prozkoumání ODP
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí JavaScriptu pro rychlejší přehled a chytřejší audit obsahu."
---
## **Přehled**

Aspose.Slides dokáže zjistit formát prezentace a přečíst metadata dokumentu, aniž by vytvořilo úplný objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, sestavit inventář nebo prozkoumat vlastnosti před tím, než se rozhodnete prezentaci načíst a zpracovat.

Tento článek ukazuje lehkou kontrolu pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/), a také cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/).

## **Kontrola formátu prezentace**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) k inspekci souboru bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/getloadformat/) uvádí zjištěný formát, například PPTX, PPT nebo ODP.

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

## **Vytvoření lehkého inventáře prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexování nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) a poté zavolejte [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) ani nevyžaduje procházení kompletním objektovým modelem prezentace.

Rozšířené vlastnosti exponované třídou [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getSlides) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getNotes) | Počet snímků, které obsahují poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getWords) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty bez vytváření objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a vypíše kompaktní inventář. Kombinuje také [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) s [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

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

Každý [HeadingPair](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/) poskytuje název skupiny pomocí [HeadingPair.getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/#getName) a počet položek ve skupině pomocí [HeadingPair.getCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) vrací ploché, uspořádané pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace za účelem přepočítání těchto hodnot při tomto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může ukládat odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost chybí nebo nebyla aktualizována výrobcem dokumentu, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu z snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako je počet stránek, odstavců a slov, ale tyto hodnoty se nepřekrývají se všemi rozšířenými vlastnostmi specifickými pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nepovažujte nulu nebo prázdné pole za důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) lze také změnit bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Použijte [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) k aplikaci změn a poté zapište svázanou prezentaci pomocí [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Následující obrázek zobrazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad změní název a čas posledního uložení a zapíše výsledek do nového souboru:

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

Následující obrázek zobrazuje změněné vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany si přečtěte následující články:

- [Password-Protect Presentations](/slides/cs/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/)

## **FAQ**

**Jak mohu zkontrolovat, zda jsou písma vložena, a která to jsou?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getfontsmanager/). Zavolejte [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) pro získání vložených písem a [FontsManager.getFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/) pro získání písem používaných v prezentaci. Porovnejte oba výsledky, abyste našli písma, která jsou potřebná pro vykreslování, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) skrze [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). To je vhodné pro lehký inventář. Pokud byla prezentace upravena v paměti, uložená metadata mohou chybět nebo být zastaralá, nebo potřebujete ověřit živé hodnoty – iterujte přes [Presentation.getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) a zkontrolujte každou snímek pomocí [Slide.getHidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/gethidden/).

**Mohou být detekovány vlastní rozměry a orientace snímků a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslidesize/). Použijte [SlideSize.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/getsize/) a [SlideSize.getOrientation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/getorientation/) pro porovnání aktuálního nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Vyhledejte každý [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/) a zavolejte [ChartData.getDataSourceType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Pro externí sešit zavolejte [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Typ zdroje a cesta identifikují externí odkaz, ale ověření dostupnosti cíle vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost komplexnosti. Projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) a kolekci [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getShapes) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály pro výběr, a změřte reprezentativní render nebo export, než považujete snímek za potvrzený úzký tah výkonnosti.