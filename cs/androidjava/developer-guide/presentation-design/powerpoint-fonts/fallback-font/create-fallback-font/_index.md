---
title: Určete náhradní fonty pro prezentace na Androidu
linktitle: Náhradní font
type: docs
weight: 10
url: /cs/androidjava/create-fallback-font/
keywords:
- náhradní font
- náhradní pravidlo
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
description: "Ovládněte Aspose.Slides pro Android pomocí jazyka Java a nastavte náhradní fonty v souborech PPT, PPTX a ODP, čímž zajistíte konzistentní zobrazování textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat náhradní fonty pro vykreslování prezentací a operace exportu. Náhradní fonty se používají, když primární font neobsahuje glyfy pro konkrétní znaky.

Chování náhradních fontů se konfiguruje pomocí pravidel náhrad. Každé pravidlo přiřadí rozsah Unicode k jednomu nebo více fontům, které mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odebírat náhradní fonty z existujících pravidel a uspořádat několik pravidel v kolekci pravidel náhradních fontů.

Pravidla náhrad jsou nastaveními vykreslování během běhu. Nemodifikují samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhrad**

Aspose.Slides podporuje rozhraní [IFontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFontFallBackRule) a třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) pro určení pravidel použití náhradního fontu. Třída [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) představuje spojení mezi určeným rozsahem Unicode, který se používá pro vyhledávání chybějících glyfů, a seznamem fontů, které mohou obsahovat odpovídající glyfy:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Pomocí různých způsobů můžete přidat seznam fontů:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Je také možné [odstranit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) náhradní font nebo [addFallBackFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do existujícího objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection) lze použít k uspořádání seznamu objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule), když je potřeba specifikovat pravidla náhradních fontů pro více rozsahů Unicode.

{{% alert color="primary" title="Viz také" %}} 
- [Vytvořit kolekci náhradních fontů](/slides/cs/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním fontem, substitucí fontu a vložením fontu?**

Náhradní font se používá jen pro znaky chybějící v primárním fontu. [Font substitution](/slides/cs/androidjava/font-substitution/) nahradí celý zadaný font jiným fontem. [Font embedding](/slides/cs/androidjava/embedded-font/) zabalení fontů do výstupního souboru, aby příjemci mohli zobrazit text podle zamýšleného vzhledu.

**Používají se náhradní fonty při exportech, jako jsou PDF, PNG nebo SVG, nebo pouze při vykreslování na obrazovce?**

Ano. Náhradní fonty ovlivňují všechny [operace vykreslování a exportu](/slides/cs/androidjava/convert-presentation/), kde je potřeba vykreslit znaky, které nejsou přítomny v původním fontu.

**Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucích otevřeních?**

Ne. Pravidla náhrad jsou nastavení vykreslování během běhu ve vašem kódu; neukládají se do souboru .pptx a neobjeví se v PowerPointu.

**Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a sada fontových adresářů?**

Ano. Engine vyhledává fonty v dostupných systémových složkách a v jakýchkoli [dalších cestách](/slides/cs/androidjava/custom-font/), které zadáte. Pokud font fyzicky není k dispozici, pravidlo na něj odkazující nemůže být použito.

**Fungují náhradní fonty pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, používá se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.