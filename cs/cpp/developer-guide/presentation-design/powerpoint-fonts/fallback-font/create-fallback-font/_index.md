---
title: Určete rezervní písma pro prezentace v C++
linktitle: Rezervní písmo
type: docs
weight: 10
url: /cs/cpp/create-fallback-font/
keywords:
- rezervní písmo
- pravidlo rezervního písma
- použít písmo
- nahradit písmo
- rozsah Unicode
- chybějící glyf
- správný glyf
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zvládněte Aspose.Slides pro C++ a nastavte rezervní písma v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat rezervní písma pro vykreslování prezentací a exportní operace. Rezervní písma se používají, když primární písmo neobsahuje glify pro konkrétní znaky.

Chování rezervních písem se konfiguruje pomocí pravidel rezervních písem. Každé pravidlo přiřazuje rozsah Unicode k jednomu nebo více písmům, která mohou obsahovat požadované glify. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat rezervní písma z existujících pravidel a organizovat více pravidel ve sbírce pravidel rezervních písem.

Pravidla rezervních písem jsou nastaveními vykreslování v době běhu. Nemodifikují samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla rezervních písem**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) pro určení pravidel, která použijí rezervní písmo. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) představuje asociaci mezi zadaným rozsahem Unicode, používaným pro vyhledávání chybějících glyphů, a seznamem písem, která mohou obsahovat správné glyfy:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Pomocí různých způsobů můžete přidat seznam písem:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Je také možné [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/remove/) rezervní písmo nebo [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) do existujícího [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) objektu.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/) lze použít k uspořádání seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/), pokud je potřeba specifikovat pravidla nahrazení rezervních písem pro více rozsahů Unicode.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci rezervních písem](/slides/cs/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi rezervním písmem, náhradou písma a vkládáním písma?**

Rezervní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/cpp/font-substitution/) nahradí celé určené písmo jiným písmem. [Font embedding](/slides/cs/cpp/embedded-font/) zabalení písem do výstupního souboru, aby příjemci mohli text zobrazit podle zamýšleného vzhledu.

**Používají se rezervní písma během exportu jako PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Rezervní písmo ovlivňuje všechny [operace vykreslování a exportu](/slides/cs/cpp/convert-presentation/), kde je třeba vykreslit znaky, které chybí v původním písmu.

**Změní konfigurace rezervních písem samotný soubor prezentace a bude nastavení přetrvávat při budoucích otevřeních?**

Ne. Pravidla rezervních písem jsou nastaveními vykreslování v době běhu ve vašem kódu; nejsou uložena v souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje výběr rezervních písem operační systém (Windows/Linux/macOS) a sada adresářů s písmy?**

Ano. Engine vyhledává písma v dostupných systémových složkách a v jakýchkoli [dalších cestách](/slides/cs/cpp/custom-font/), které poskytnete. Pokud písmo není fyzicky dostupné, pravidlo na něj odkazující nemůže být použito.

**Funguje rezervní písmo pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyphů k vykreslení chybějících znaků.