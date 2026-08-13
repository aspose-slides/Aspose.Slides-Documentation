---
title: Zadejte náhradní fonty pro prezentace v C++
linktitle: Náhradní font
type: docs
weight: 10
url: /cs/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "Zvládněte Aspose.Slides pro C++, abyste nastavili náhradní fonty v souborech PPT, PPTX a ODP a zajistili jednotné zobrazení textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat náhradní fonty pro vykreslování prezentace a exportní operace. Náhradní fonty se používají, když primární font neobsahuje glyfy pro konkrétní znaky.

Chování náhrad je konfigurováno pomocí pravidel náhrad. Každé pravidlo spojuje rozsah Unicode s jedním nebo více fonty, které mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní fonty v existujících pravidlech a organizovat více pravidel ve sbírce pravidel náhradních fontů.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena uvnitř souboru PPTX.

## **Pravidla náhradních fontů**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/), které určují pravidla pro použití náhradního fontu. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) představuje asociaci mezi zadaným rozsahem Unicode, používaným pro vyhledávání chybějících glyfů, a seznamem fontů, které mohou obsahovat správné glyfy:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Pomocí různých způsobů můžete přidat seznam fontů:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Je také možné [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/remove/) náhradní font nebo [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/) lze použít k organizaci seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/), když je potřeba specifikovat pravidla náhrady fontů pro více rozsahů Unicode.

{{% alert color="info" title="See also" %}} 
- [Vytvořit kolekci náhradních fontů](/slides/cs/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

### Jaký je rozdíl mezi náhradním fontem, substitucí fontu a vložením fontu?

Náhradní font se používá pouze pro znaky chybějící v primárním fontu. [Font substitution](/slides/cs/cpp/font-substitution/) nahrazuje celý určený font jiným fontem. [Font embedding](/slides/cs/cpp/embedded-font/) zabaluje fonty do výstupního souboru, aby příjemci mohli zobrazit text tak, jak byl zamýšlen.

### Aplikují se náhradní fonty během exportu, například PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?

Ano. Náhrada ovlivňuje všechny [rendering and export operations](/slides/cs/cpp/convert-presentation/), kde je potřeba vykreslit znaky, které nejsou v původním fontu.

### Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevření?

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu ve vašem kódu; nejsou uložena uvnitř .pptx a neobjeví se v PowerPointu.

### Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a sada složek fontů?

Ano. Engine načítá fonty z dostupných systémových složek a jakýchkoli [additional paths](/slides/cs/cpp/custom-font/), které zadáte. Pokud font fyzicky neexistuje, pravidlo na něj odkazující nemůže být použito.

### Funguje náhrada pro WordArt, SmartArt a grafy?

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.