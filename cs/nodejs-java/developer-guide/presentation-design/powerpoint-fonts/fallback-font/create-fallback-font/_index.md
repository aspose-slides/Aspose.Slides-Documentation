---
title: Určete náhradní písma pro prezentace v JavaScriptu
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/nodejs-java/create-fallback-font/
keywords:
- náhradní písmo
- pravidlo náhrady
- použít písmo
- nahradit písmo
- rozsah Unicode
- chybějící glyf
- správný glyf
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro Node.js a nastavte náhradní písma v souborech PPT, PPTX a ODP pomocí JavaScriptu, čímž zajistíte konzistentní zobrazení textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje určit náhradní písma pro vykreslování prezentace a exportní operace. Náhradní písma se používají, když primární písmo neobsahuje glyfy pro konkrétní znaky.

Chování náhrady se konfiguruje pomocí pravidel náhradních písem. Každé pravidlo spojuje rozsah Unicode s jedním nebo více písmy, která mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odebírat náhradní písma z existujících pravidel a organizovat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule) a [FontFallBackRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule) k určení pravidel pro použití náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule) představuje spojení mezi určeným rozsahem Unicode, použitým pro hledání chybějících glyfů, a seznamem písem, která mohou obsahovat správné glyfy:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Používáním více způsobů můžete přidat seznam písem:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Je také možné [remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) náhradní písmo nebo [addFallBackFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do existujícího [FontFallBackRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule) objektu.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRulesCollection) lze použít k uspořádání seznamu objektů FontFallBackRule, když je potřeba specifikovat pravidla náhrady písem pro více rozsahů Unicode.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?**

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/nodejs-java/font-substitution/) nahrazuje celé specifikované písmo jiným písmem. [Font embedding](/slides/cs/nodejs-java/embedded-font/) zabalí písma do výstupního souboru, aby příjemci mohli zobrazit text tak, jak je zamýšlen.

**Používají se náhradní písma při exportech jako PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhrada ovlivňuje všechny [vykreslování a exportní operace](/slides/cs/nodejs-java/convert-presentation/), kde je potřeba vykreslit znaky, které chybí ve zdrojovém písmu.

**Mění konfigurace náhrady samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevření?**

Ne. Pravidla náhrady jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena v souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje výběr náhrady operační systém (Windows/Linux/macOS) a sada adresářů s fonty?**

Ano. Engine načítá písma z dostupných systémových složek a jakýchkoli [dodatečných cest](/slides/cs/nodejs-java/custom-font/), které poskytnete. Pokud písmo fyzicky není k dispozici, pravidlo, které na něj odkazuje, nemůže nabýt účinku.

**Funguje náhrada pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů pro vykreslení chybějících znaků.