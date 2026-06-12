---
title: Určete náhradní písma pro prezentace v .NET
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro .NET a nastavte náhradní písma v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides umožňuje zadat náhradní písma pro vykreslování prezentací a operace exportu. Náhradní písma se používají, když primární písmo neobsahuje glify pro určité znaky.

Chování náhrady se konfiguruje pomocí pravidel náhrady. Každé pravidlo spojuje rozsah Unicode s jedním nebo více písmy, která mohou obsahovat požadované glify. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní písma z existujících pravidel a organizovat několik pravidel v kolekci pravidel náhradních písem.

Pravidla náhrady jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhrady**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/iFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) pro určení pravidel aplikace náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) představuje spojení mezi zadaným rozsahem Unicode, který se používá pro hledání chybějících glifů, a seznamem písem, která mohou obsahovat správné glyfy:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Používáním různých způsobů můžete přidat seznam písem:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Je také možné [Remove()](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontfallbackrule/methods/remove) náhradní písmo nebo [AddFallBackFonts()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrulescollection)[ ] can be used to organize a list of [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?**

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/net/font-substitution/) nahradí celé určené písmo jiným písmem. [Font embedding](/slides/cs/net/embedded-font/) zabalení písem do výstupního souboru, aby příjemci mohli text zobrazit podle zamýšleného vzhledu.

**Používají se náhradní písma při exportech jako PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhrada ovlivňuje všechny [operace vykreslování a exportu](/slides/cs/net/convert-presentation/), kde je potřeba vykreslit znaky, které ve zdrojovém písmu chybí.

**Změní konfigurace náhrady samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevírání?**

Ne. Pravidla náhrady jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena v souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje výběr náhrady operační systém (Windows/Linux/macOS) a sada adresářů s písmy?**

Ano. Engine vyhledává písma v dostupných systémových složkách a v jakýchkoli [dalších cestách](/slides/cs/net/custom-font/), které zadáte. Pokud písmo fyzicky není k dispozici, pravidlo na něj odkazující nemůže být použito.

**Funguje náhrada i pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glifů pro vykreslení chybějících znaků.