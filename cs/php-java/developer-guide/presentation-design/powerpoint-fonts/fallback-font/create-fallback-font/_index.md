---
title: Určete náhradní písma pro prezentace v PHP
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/php-java/create-fallback-font/
keywords:
- náhradní písmo
- pravidlo náhrady
- použít písmo
- nahradit písmo
- rozsah Unicode
- chybějící glif
- správný glif
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládejte Aspose.Slides pro PHP přes Java a nastavte náhradní písma v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazení textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides umožňuje určit náhradní písma pro vykreslování prezentací a operace exportu. Náhradní písma se používají, když primární písmo neobsahuje glify pro určité znaky.

Chování náhradních písem se konfiguruje pomocí pravidel náhrady. Každé pravidlo přiřazuje rozsah Unicode k jednomu nebo více písmům, která mohou obsahovat požadované glify. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odstraňovat náhradní písma z existujících pravidel a organizovat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhrady jsou nastavení vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena uvnitř souboru PPTX.

## **Pravidla náhradních písem**

Aspose.Slides podporuje třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule) pro určení pravidel aplikace náhradního písma. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule) představuje asociaci mezi určeným rozsahem Unicode, používaným pro hledání chybějících glyphů, a seznamem písem, která mohou obsahovat vhodné glify:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Používáním různých způsobů můžete přidat seznam písem:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Je také možné [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontfallbackrule/remove/) náhradní písmo nebo [addFallBackFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) do existujícího [FontFallBackRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule) objektu.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRulesCollection) lze použít k uspořádání seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule), když je potřeba specifikovat pravidla náhrady písem pro více Unicode rozsahů.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?**

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Font substitution](/slides/cs/php-java/font-substitution/) nahradí celé určené písmo jiným písmem. [Font embedding](/slides/cs/php-java/embedded-font/) zabalení písem do výstupního souboru, aby je příjemci mohli zobrazit tak, jak je zamýšleno.

**Používají se náhradní písma při exportech, jako jsou PDF, PNG nebo SVG, nebo jen při vykreslování na obrazovce?**

Ano. Náhrada ovlivňuje všechny [rendering and export operations](/slides/cs/php-java/convert-presentation/), kde je nutné vykreslit znaky, které v zdrojovém písmu chybí.

**Mění konfigurace náhrady samotný soubor prezentace a bude nastavení přetrvávat při budoucím otevření?**

Ne. Pravidla náhrady jsou nastavení vykreslování za běhu ve vašem kódu; neukládají se do souboru .pptx a nebudou se zobrazovat v PowerPointu.

**Ovlivňuje výběr náhrady operační systém (Windows/Linux/macOS) a sada adresářů s fonty?**

Ano. Engine vyhledává písma v dostupných systémových složkách a v jakýchkoli [additional paths](/slides/cs/php-java/custom-font/), které zadáte. Pokud písmo fyzicky neexistuje, pravidlo na něj odkazující nemůže být použito.

**Funguje náhrada pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyphů pro vykreslení chybějících znaků.