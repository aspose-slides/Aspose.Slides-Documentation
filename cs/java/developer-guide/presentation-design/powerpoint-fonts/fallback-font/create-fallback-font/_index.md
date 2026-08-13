---
title: "Určete náhradní fonty pro prezentace v Javě"
linktitle: "Náhradní font"
type: docs
weight: 10
url: /cs/java/create-fallback-font/
keywords:
  - "náhradní font"
  - "pravidlo náhrady"
  - "použít font"
  - "nahradit font"
  - "rozsah Unicode"
  - "chybějící glyf"
  - "správný glyf"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentace"
  - "Java"
  - "Aspose.Slides"
description: "Ovládněte Aspose.Slides pro Java k nastavení náhradních fontů v souborech PPT, PPTX a ODP, což zajišťuje konzistentní zobrazování textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides umožňuje určit náhradní fonty pro vykreslování prezentací a operace exportu. Náhradní fonty se používají, když primární font neobsahuje glyfy pro konkrétní znaky.

Chování náhrad je konfigurováno pomocí pravidel náhrad. Každé pravidlo spojuje rozsah Unicode s jedním nebo více fonty, které mohou požadované glyfy obsahovat. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní fonty z existujících pravidel a organizovat více pravidel v kolekci pravidel náhradních fontů.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena uvnitř souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) pro určení pravidel aplikace náhradního fontu. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) představuje asociaci mezi zadaným rozsahem Unicode, který se používá pro vyhledávání chybějících glyfů, a seznamem fontů, které mohou obsahovat správné glyfy:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Použitím různých způsobů můžete přidat seznam fontů:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Je také možné [remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) náhradní font nebo [addFallBackFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule).

[Třída FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection) může být použita k organizaci seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule), když je potřeba určit pravidla nahrazení náhradních fontů pro více rozsahů Unicode.

{{% alert color="info" title="See also" %}} 
- [Vytvořit kolekci náhradních fontů](/slides/cs/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

### Jaký je rozdíl mezi náhradním fontem, substitucí fontu a vložením fontu?

Náhradní font se používá jen pro znaky chybějící v primárním fontu. [Font substitution](/slides/cs/java/font-substitution/) nahrazuje celý určený font jiným fontem. [Font embedding](/slides/cs/java/embedded-font/) zabaluje fonty do výstupního souboru, aby je příjemci mohli zobrazit podle záměru.

### Aplikují se náhradní fonty během exportů, jako jsou PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?

Ano. Náhrada ovlivňuje všechny [rendering and export operations](/slides/cs/java/convert-presentation/), kde je nutné vykreslit znaky, které ve zdrojovém fontu chybí.

### Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevírání?

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena uvnitř souboru .pptx a neobjeví se v PowerPointu.

### Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a sada adresářů s fonty?

Ano. Engine řeší fonty z dostupných systémových složek a jakýchkoli [additional paths](/slides/cs/java/custom-font/), které zadáte. Pokud font fyzicky neexistuje, pravidlo na něj odkazující nemůže být uplatněno.

### Funguje náhrada pro WordArt, SmartArt a grafy?

Ano. Když tyto objekty obsahují text, použije se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.