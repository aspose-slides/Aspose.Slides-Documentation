---
title: Určete náhradní fonty pro prezentace na Androidu
linktitle: Náhradní font
type: docs
weight: 10
url: /cs/androidjava/create-fallback-font/
keywords:
- náhradní font
- pravidlo náhrady
- použít font
- nahradit font
- rozsah Unicode
- chybějící glyf
- správný glyf
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro Android pomocí Javy a nastavte náhradní fonty v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat náhradní fonty pro vykreslování prezentací a exportní operace. Náhradní fonty se používají, když primární font neobsahuje glyfy pro konkrétní znaky.

Chování náhradních fontů se konfiguruje pomocí pravidel náhrad. Každé pravidlo spojuje rozsah Unicode s jedním nebo více fonty, které mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní fonty z existujících pravidel a organizovat více pravidel v kolekci pravidel náhradních fontů.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemodifikují samotný soubor prezentace a nejsou uložena uvnitř souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) pro určení pravidel, která použijí náhradní font. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) představuje asociaci mezi určeným rozsahem Unicode, používaným pro hledání chybějících glyfů, a seznamem fontů, které mohou obsahovat správné glyfy:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Také je možné [odstranit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) náhradní font nebo [přidat náhradní fonty](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection) lze použít k organizaci seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule), pokud je potřeba specifikovat pravidla nahrazení náhradních fontů pro více rozsahů Unicode.

{{% alert color="info" title="Viz také" %}} 
- [Vytvořit kolekci náhradních fontů](/slides/cs/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

### Jaký je rozdíl mezi náhradním fontem, substitucí fontu a vložením fontu?

Náhradní font se používá pouze pro znaky chybějící v primárním fontu. [Substituce fontu](/slides/cs/androidjava/font-substitution/) nahrazuje celý určený font jiným fontem. [Vložení fontu](/slides/cs/androidjava/embedded-font/) zabaluje fonty do výstupního souboru, aby příjemci mohli zobrazit text tak, jak byl zamýšlen.

### Používají se náhradní fonty při exportech jako PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?

Ano. Náhrada ovlivňuje všechny [operace vykreslování a exportu](/slides/cs/androidjava/convert-presentation/), kde je třeba vykreslit znaky, které ve zdrojovém fontu chybí.

### Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucích otevřeních?

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena uvnitř .pptx a neobjeví se v PowerPointu.

### Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a množina adresářů s fonty?

Ano. Engine načítá fonty z dostupných systémových složek a jakýchkoli [dalších cest](/slides/cs/androidjava/custom-font/), které zadáte. Pokud font fyzicky není k dispozici, pravidlo na něj odkazující nemůže nabýt účinku.

### Funguje náhrada u WordArtu, SmartArtu a grafů?

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.