---
title: Určete náhradní písma pro prezentace v Pythonu
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Zvládněte Aspose.Slides pro Python pomocí .NET a nastavte náhradní písma v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazení textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides vám umožňuje určit náhradní písma pro vykreslování a export prezentací. Náhradní písma se používají, když primární písmo neobsahuje glyfy pro konkrétní znaky.

Chování náhradních písem se konfiguruje pomocí pravidel náhrad. Každé pravidlo spojuje rozsah Unicode s jedním nebo více písmy, která mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní písma z existujících pravidel a uspořádat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Určete náhradní písma**

Aspose.Slides podporuje třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/FontFallBackRule/) pro určení pravidel aplikace náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/FontFallBackRule/) představuje asociaci mezi zadaným rozsahem Unicode, který se používá k vyhledávání chybějících glyfů, a seznamem písem, která mohou obsahovat správné glyfy:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Použitím různých způsobů můžete přidat seznam písem:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Je také možné [odebrat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrule/remove/) náhradní písmo nebo [add_fall_back_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrulescollection/) lze použít k uspořádání seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/FontFallBackRule/), když je potřeba určit pravidla nahrazování náhradních písem pro více rozsahů Unicode.

{{% alert color="primary" title="See also" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?**

Náhradní písmo se používá jen pro znaky chybějící v primárním písmu. [Substituce písma](/slides/cs/python-net/font-substitution/) nahradí celé specifikované písmo jiným písmem. [Vložení písma](/slides/cs/python-net/embedded-font/) vloží písma do výstupního souboru, aby příjemci mohli zobrazit text tak, jak byl zamýšlen.

**Používají se náhradní písma při exportu, například PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhrada ovlivňuje všechny [operace vykreslování a exportu](/slides/cs/python-net/convert-presentation/), kde je třeba vykreslit znaky, které chybí ve zdrojovém písmu.

**Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucích otevřeních?**

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu v kódu; nejsou uložena v souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a množina složek s fonty?**

Ano. Engine vyhledává písma v dostupných systémových složkách a v jakýchkoli [další cesty](/slides/cs/python-net/custom-font/), které poskytnete. Pokud písmo fyzicky neexistuje, pravidlo na něj odkazující nemůže být použito.

**Fungují náhrady i pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, použije se stejný mechanismus substituce glyfů pro vykreslení chybějících znaků.