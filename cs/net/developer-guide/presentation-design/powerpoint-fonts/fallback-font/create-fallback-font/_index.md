---
title: Určete náhradní písma pro prezentace v .NET
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/net/create-fallback-font/
keywords:
- náhradní písmo
- pravidlo náhrady
- aplikovat písmo
- nahradit písmo
- rozsah Unicode
- chybějící glyf
- správný glyf
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro .NET pro nastavení náhradních písem v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides umožňuje určit náhradní písma pro vykreslování prezentací a exportní operace. Náhradní písma se používají, když primární písmo neobsahuje glify pro konkrétní znaky.

Chování náhradních písem se konfiguruje pomocí pravidel náhradních písem. Každé pravidlo spojuje rozsah Unicode s jedním nebo více písmy, která mohou obsahovat požadované glify. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní písma z existujících pravidel a uspořádat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhradních písem jsou nastaveními vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhradních písem**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/iFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule), která určuje pravidla pro použití náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) představuje spojení mezi zadaným rozsahem Unicode, který se používá k vyhledání chybějících glifů, a seznamem písem, která mohou obsahovat správné glify:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Pomocí různých způsobů můžete přidat seznam písem:
string[] fontNames = new string[] { "Segoe UI Emoji, Segue UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Je také možné [Remove()](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontfallbackrule/methods/remove) náhradní písmo nebo [AddFallBackFonts()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrulescollection) může být použita k organizaci seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule), když je potřeba specifikovat pravidla náhradních písem pro více rozsahů Unicode.

{{% alert color="info" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

### Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/net/font-substitution/) nahrazuje celé určené písmo jiným písmem. [Font embedding](/slides/cs/net/embedded-font/) zabaluje písma do výstupního souboru, aby je příjemci mohli zobrazit tak, jak bylo zamýšleno.

### Používají se náhradní písma při exportech jako PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?

Ano. Náhradní písmo ovlivňuje všechny [rendering and export operations](/slides/cs/net/convert-presentation/), kde je třeba vykreslit znaky, které ve zdrojovém písmu chybí.

### Mění nastavení náhradního písma samotný soubor prezentace a bude tato volba přetrvávat při budoucích otevřeních?

Ne. Pravidla náhradních písem jsou nastaveními vykreslování za běhu ve vašem kódu; nejsou uložena v souboru .pptx a neobjeví se v PowerPointu.

### Ovlivňuje výběr náhradního písma operační systém (Windows/Linux/macOS) a množinu adresářů s fonty?

Ano. Engine vyhledává písma v dostupných systémových složkách a v libovolných [additional paths](/slides/cs/net/custom-font/), které zadáte. Pokud písmo není fyzicky k dispozici, pravidlo na něj odkazující nemůže být použito.

### Funguje náhradní písmo pro WordArt, SmartArt a grafy?

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glifů pro vykreslení chybějících znaků.