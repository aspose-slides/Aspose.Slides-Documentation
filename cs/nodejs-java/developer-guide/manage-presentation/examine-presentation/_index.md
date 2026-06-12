---
title: "Načíst a aktualizovat informace o prezentaci v JavaScriptu"
linktitle: "Informace o prezentaci"
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
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí JavaScriptu pro rychlejší přehledy a chytřejší kontrolu obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace, aniž byste načetli celý soubor, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a další) je prezentace momentálně.

Formát prezentace můžete zkontrolovat, aniž byste ji načetli. Viz tento JavaScriptový kód:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Získat vlastnosti prezentace**

Tento JavaScriptový kód vám ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Možná budete chtít zobrazit [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), která vám umožní provádět změny ve vlastnostech prezentace.

Řekněme, že máme PowerPointovou prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPointové prezentace](input_properties.png)

Tento příklad kódu vám ukazuje, jak upravit některé vlastnosti prezentace:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPointové prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech můžete najít tyto odkazy užitečné:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna proti zápisu (jen pro čtení)](https://docs.aspose.com/slides/cs/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před jejím načtením](https://docs.aspose.com/slides/cs/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potvrzení hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mohu zkontrolovat, zda jsou písma vložena, a která to jsou?**

Hledejte [informace o vložených písmenech](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a poté porovnejte tyto položky se sadou [přesně použitých písem v obsahu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/). Tím zjistíte, která písma jsou pro vykreslování kritická.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [kolekci snímků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) a zkontrolujte [vlajku viditelnosti](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/gethidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímků, a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslidesize/) a orientaci s výchozími přednastaveními; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/), zkontrolujte jejich [zdroj dat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), a zaznamenejte, zda jsou data interní nebo odkazována, včetně jakýchkoli poškozených odkazů.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte hrubé skóre složitosti, abyste označili potenciální úzká místa výkonnosti.