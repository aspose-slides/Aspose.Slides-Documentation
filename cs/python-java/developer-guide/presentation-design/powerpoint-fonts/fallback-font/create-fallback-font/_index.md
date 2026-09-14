---
title: Určete náhradní písma pro prezentace v Pythonu přes Java
linktitle: Náhradní písmo
type: docs
weight: 10
url: /cs/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Ovládněte Aspose.Slides pro Python přes Java a nastavte náhradní písma v souborech PPT, PPTX a ODP, čímž zajistíte jednotné zobrazení textu na jakémkoli zařízení nebo operačním systému."
---
## **Přehled**

Aspose.Slides vám umožňuje určit náhradní písma pro vykreslování prezentací a exportní operace. Náhradní písma se používají, když primární písmo neobsahuje glyfy pro konkrétní znaky.

Chování náhrad se konfiguruje pomocí pravidel náhrad. Každé pravidlo přiřadí rozsah Unicode k jednomu nebo více písmům, která mohou obsahovat požadované glyfy. Můžete definovat pravidla pro různé rozsahy znaků, přidávat nebo odebírat náhradní písma z existujících pravidel a uspořádat více pravidel v kolekci pravidel náhradních písem.

Pravidla náhrad jsou nastaveními vykreslování za běhu. Nemění samotný soubor prezentace a nejsou uložena v souboru PPTX.

## **Pravidla náhradních písem**

Aspose.Slides poskytuje třídu [FontFallBackRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/) k určení pravidel pro použití náhradních písem. Tato třída představuje asociaci mezi rozsahem Unicode používaným pro vyhledávání chybějících glyfů a seznamem písem, která mohou požadované glyfy obsahovat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Použijte více způsobů, jak zadat seznam písem.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Můžete také odebrat náhradní písmo pomocí [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/#remove) nebo přidat náhradní písma pomocí [addFallBackFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) v existujícím objektu [FontFallBackRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrulescollection/) může uspořádat seznam objektů [FontFallBackRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/), pokud potřebujete určit pravidla náhrady náhradních písem pro více rozsahů Unicode.

{{% alert color="info" title="Viz také" %}} 
- [Vytvořit kolekci náhradních písem](/slides/cs/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradním písmem, substitucí písma a vložením písma?**

Náhradní písmo se používá pouze pro znaky chybějící v primárním písmu. [Substituce písma](/slides/cs/python-java/font-substitution/) nahrazuje celé zadané písmo jiným písmem. [Vkládání písma](/slides/cs/python-java/embedded-font/) zabaluje písma do výstupního souboru, aby příjemci mohli zobrazit text tak, jak bylo zamýšleno.

**Používají se náhradní písma při exportech, jako jsou PDF, PNG nebo SVG, nebo pouze při vykreslování na obrazovce?**

Ano. Náhradní písmo ovlivňuje všechny [vykreslovací a exportní operace](/slides/cs/python-java/convert-presentation/), kde je potřeba vykreslit znaky, které ve zdrojovém písmu chybí.

**Mění konfigurace náhrad samotný soubor prezentace a bude nastavení přetrvávat při budoucích otevřeních?**

Ne. Pravidla náhrad jsou nastaveními vykreslování za běhu ve vašem kódu; nejsou uložena v souboru .pptx a v PowerPointu se neukáží.

**Ovlivňuje výběr náhrad operační systém (Windows/Linux/macOS) a sada adresářů s fonty?**

Ano. Engine vyhledává písma v dostupných systémových složkách a v libovolných [dalších cestách](/slides/cs/python-java/custom-font/), které poskytnete. Pokud písmo fyzicky neexistuje, pravidlo na něj odkazující nemůže být uplatněno.

**Funguje náhrada také pro WordArt, SmartArt a grafy?**

Ano. Když tyto objekty obsahují text, použije se stejný mechanismus substituce glyfů k vykreslení chybějících znaků.