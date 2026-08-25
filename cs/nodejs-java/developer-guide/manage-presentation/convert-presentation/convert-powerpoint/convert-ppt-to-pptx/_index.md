---
title: Převod PPT na PPTX v Node.js
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/nodejs-java/convert-ppt-to-pptx/
keywords:
- převod PowerPointu
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v Node.js pomocí Aspose.Slides. Obsahuje příklady v JavaScriptu pro převod jednoho souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Node.js přes Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po převodu.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/). Blok `finally` uvolní prezentaci a její prostředky.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Načíst starší PPT prezentaci.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Uložit prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přípona souboru sama o sobě nevybírá výstupní formát; argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) to provádí. Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován samostatně, takže jeden neúspěšný převod nepozastaví zbytek dávky.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Pro produkční zátěže zaznamenejte úplnou chybu, rozhodněte, zda lze existující výstupní soubor přepsat, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou všechny způsobit selhání převodu. Viz [Password-Protected Presentations](/slides/cs/nodejs-java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Převod obvykle zachovává snímky, mastery, rozvržení, text, tvary, obrázky, tabulky a grafy. Avšak PPT a PPTX nereprezentují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ovládací prvky ActiveX, vložená média, neobvyklá písma nebo VBA makra. Prostý soubor PPTX není formát podporující makra, proto použijte vhodný workflow podporující makra, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou v prostředí, kde bude převedená prezentace otevřena nebo renderována.

Pro důležité dokumenty znovu načtěte vygenerovaný PPTX programově a zkontrolujte počet snímků a jejich obsah, poté porovnejte jeho vzhled a chování při promítání v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

Použijte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo uložena ve formátu, který je snazší prohlížet a obnovovat než starší binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formáty v [Convert Presentations to Multiple Formats](/slides/cs/nodejs-java/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované převody, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte API Node.js přes Java.

## **Související články**

- [PPT vs PPTX](/slides/cs/nodejs-java/ppt-vs-pptx/)
- [Uložit prezentace v Node.js](/slides/cs/nodejs-java/save-presentation/)
- [Podporované formáty souborů](/slides/cs/nodejs-java/supported-file-formats/)
- [Otevřít prezentace v Node.js](/slides/cs/nodejs-java/open-presentation/)

## **FAQ**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro Node.js přes Java načítá a ukládá soubory prezentací, aniž by byl vyžadován Microsoft PowerPoint.

**Zachová převod PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítání.

**Mám po převodu smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.