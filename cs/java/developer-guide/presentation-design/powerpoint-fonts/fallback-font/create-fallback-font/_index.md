---
title: Zadejte náhradní písma pro prezentace v Javě
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/java/create-fallback-font/
keywords:
- náhradní písmo
- náhradní pravidlo
- použít písmo
- nahradit písmo
- rozsah Unicode
- chybějící glyf
- správný glyf
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro Javu a nastavte náhradní písma v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje určit náhradní písma pro vykreslování prezentací a operace exportu. Náhradní písma jsou používána, když primární písmo neobsahuje glyfy pro konkrétní znaky.

Chování náhradních písem je konfigurováno pomocí pravidel náhrad. Každé pravidlo přiřazuje rozsah Unicode k jednomu nebo více písmům, která mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní písma z existujících pravidel a organizovat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) k určení pravidel pro použití náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) představuje asociaci mezi zadaným rozsahem Unicode, který se používá pro hledání chybějících glyfů, a seznamem písem, která mohou obsahovat správné glyfy:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Pomocí různých způsobů můžete přidat seznam písem:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Je také možné [remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) náhradní písmo nebo [addFallBackFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) přidat do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection) lze použít k organizaci seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule), pokud je potřeba specifikovat pravidla náhradního písma pro více rozsahů Unicode.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním písmem, font substitution a font embedding?**

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/java/font-substitution/) nahrazuje celé určené písmo jiným písmem. [Font embedding](/slides/cs/java/embedded-font/) zabaluje písma do výstupního souboru, aby příjemci mohli text zobrazit tak, jak bylo zamýšleno.

**Používají se náhradní písma při exportech, jako jsou PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhradní písmo ovlivňuje všechny [rendering and export operations](/slides/cs/java/convert-presentation/), kde je potřeba vykreslit znaky, které ve zdrojovém písmu chybí.

**Mění konfigurace náhradní fonty samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevírání?**

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena v souboru .pptx a nebudou se zobrazovat v PowerPointu.

**Ovlivňuje výběr náhradní fonty operační systém (Windows/Linux/macOS) a množina adresářů s fonty?**

Ano. Engine hledá písma v dostupných systémových složkách a v jakýchkoli [additional paths](/slides/cs/java/custom-font/), které zadáte. Pokud písmo není fyzicky dostupné, pravidlo na něj odkazující nemůže být použito.

**Funguje náhradní písmo pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.