---
title: Určete náhradní fonty pro prezentace v C++
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
description: "Ovládněte Aspose.Slides pro C++ pro nastavení náhradních fontů v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazení textu na jakémkoli zařízení nebo OS."
---
## **Přehled**

Aspose.Slides vám umožňuje určit náhradní fonty pro vykreslování prezentací a operace exportu. Náhradní fonty se používají, pokud primární font neobsahuje glyfy pro konkrétní znaky.

Chování náhradních fontů se konfiguruje pomocí pravidel náhrad. Každé pravidlo přiřazuje rozsah Unicode jednomu nebo více fontům, které mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odebírat náhradní fonty z existujících pravidel a uspořádat více pravidel v kolekci pravidel náhradních fontů.

Pravidla náhrad jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a neukládají se do souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/) a [třídu FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) pro určení pravidel použití náhradního fontu. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) představuje asociaci mezi určeným rozsahem Unicode, který se používá k vyhledání chybějících glyfů, a seznamem fontů, které mohou obsahovat správné glyfy:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Pomocí více způsobů můžete přidat seznam fontů:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Je také možné [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/remove/) náhradní font nebo [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) do existujícího [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) objektu.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/) lze použít k uspořádání seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) , pokud je potřeba specifikovat pravidla náhrady fontů pro více rozsahů Unicode.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních fontů](/slides/cs/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním fontem, substitucí fontu a vložením fontu?**

Náhradní font se používá pouze pro znaky chybějící v primárním fontu. [Substituce fontu](/slides/cs/cpp/font-substitution/) nahradí celý určený font jiným fontem. [Vložení fontu](/slides/cs/cpp/embedded-font/) zabaluje fonty do výstupního souboru, aby je příjemci mohli zobrazit podle zamýšleného vzhledu.

**Používají se náhradní fonty při exportu, např. do PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhrada ovlivňuje všechny [operace vykreslování a exportu](/slides/cs/cpp/convert-presentation/), kde je nutné vykreslit znaky, které chybí v původním fontu.

**Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevření?**

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu ve vašem kódu; neukládají se do souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje operační systém (Windows/Linux/macOS) a sada složek s fonty výběr náhrad?**

Ano. Engine načítá fonty z dostupných systémových složek a jakýchkoli [dalších cest](/slides/cs/cpp/custom-font/), které zadáte. Pokud font fyzicky neexistuje, nelze použít pravidlo, které na něj odkazuje.

**Funguje náhrada i pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.