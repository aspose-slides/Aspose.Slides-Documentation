---
title: Získání a aktualizace informací o prezentaci v JavaScriptu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/nodejs-java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- načíst vlastnosti
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
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí JavaScriptu pro rychlejší poznatky a inteligentnější audity obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prohlížet informace o prezentaci v Aspose.Slides. Vysvětluje, jak zjistit aktuální formát prezentace, aniž byste načítali celý soubor, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací můžete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a další) je prezentace právě nyní.

Formát prezentace můžete zkontrolovat, aniž byste prezentaci načítali. Viz tento JavaScript kód:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Získat vlastnosti prezentace**

Tento JavaScript kód vám ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Můžete se podívat na [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), která vám umožní provádět změny vlastností prezentace.

Řekněme, že máme PowerPoint prezentaci s dokumentovými vlastnostmi zobrazenými níže.

![Původní dokumentové vlastnosti PowerPoint prezentace](input_properties.png)

Tento příklad kódu vám ukazuje, jak upravit některé vlastnosti prezentace:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Výsledky změny dokumentových vlastností jsou zobrazeny níže.

![Změněné dokumentové vlastnosti PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání více informací o prezentaci a jejích bezpečnostních atributech mohou být tyto odkazy užitečné:

- [Zabezpečit prezentace heslem](/slides/cs/nodejs-java/password-protected-presentation/)
- [Zabránit zápisu prezentací](/slides/cs/nodejs-java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou fonty vloženy a které jsou?**

Hledejte [informace o vložených fontech](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a poté porovnejte tyto položky se sadou [fontů skutečně používaných v obsahu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/), abyste určili, které fonty jsou pro renderování kritické.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) a zkontrolujte [vlajku viditelnosti](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/gethidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku, a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslidesize/) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Projděte všechny [grafy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), a zjistěte, zda jsou data interní nebo odkazována, včetně případných poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit renderování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné hodnocení složitosti, abyste označili potenciální úzká místa výkonu.