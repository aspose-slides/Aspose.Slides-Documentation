---
title: Konfigurace nahrazování písma v prezentacích pomocí Pythonu
linktitle: Nahrazování písma
type: docs
weight: 70
url: /cs/python-net/font-substitution/
keywords:
- písmo
- nahrazení písma
- nahrazování písma
- nahraďte písmo
- nahrazení písma
- pravidlo nahrazování
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Umožněte optimální nahrazování písma v Aspose.Slides pro Python pomocí .NET při konverzi prezentací PowerPoint a OpenDocument do jiných formátů souborů."
---
## **Přehled**

Nahrazení písma umožňuje Aspose.Slides použít jiné písmo, pokud původní písmo prezentace není během vykreslování nebo konverze k dispozici. Můžete zjistit, která písma byla nahrazena, pomocí metody `get_substitutions` ze třídy `FontsManager`.

Aspose.Slides také umožňuje definovat pravidla nahrazování písem. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a poté tato pravidla použít přes správce písem prezentace.

## **Nastavení pravidel substituce**

Aspose.Slides vám umožňuje nastavit pravidla pro písma, která určují, co se má provést v určitých podmínkách (například když není písmo přístupné), tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo.
4. Přidejte pravidlo pro nahrazení.
5. Přidejte pravidlo do kolekce pravidel nahrazování písem prezentace.
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento Python kód demonstruje proces nahrazování písem:

```python
import aspose.slides as slides

# Načte prezentaci
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Načte zdrojové písmo, které bude nahrazeno
    sourceFont = slides.FontData("SomeRareFont")

    # Načte nové písmo
    destFont = slides.FontData("Arial")

    # Přidá pravidlo pro nahrazení písma
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Přidá pravidlo do kolekce pravidel nahrazení písem
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Přidá kolekci pravidel písem do seznamu pravidel
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial písmo bude použito místo SomeRareFont, když je poslední nedostupné
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Uloží obrázek na disk ve formátu JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
Možná se budete chtít podívat na [**Font Replacement**](/slides/cs/python-net/font-replacement/). 
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla nahrazování písem se podílejí na standardním procesu výběru písma používaném při vykreslování a konverzi. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může podle nastaveného pravidla nahradit nedostupné písmo jiným dostupným písmem.

Nicméně rovnice Office Math mají důležité omezení. Pokud byla rovnice vytvořena pomocí **Cambria Math**, Aspose.Slides může i nadále vyžadovat originální písmo **Cambria Math** pro správný výpočet a vykreslení rozvržení rovnice. Kvůli tomu není nahrazení **Cambria Math** jiným matematickým písmem, například **STIX Two Math**, při vykreslování rovnic podporováno a může stále vést k výjimce, která uvádí, že **Cambria Math** je vyžadováno.

Pro úspěšnou konverzi takových prezentací se ujistěte, že **Cambria Math** je pro Aspose.Slides k dispozici během běhu. Můžete písmo nainstalovat do operačního systému nebo jej poskytnout jako [external font](/slides/cs/python-net/custom-font/), aby se mohl podílet na standardním procesu výběru písma během vykreslování a konverze.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla nahrazování písem popsaná výše se i nadále vztahují na běžný text prezentace, pokud je původní písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a jeho substitucí?**  
[Replacement](/slides/cs/python-net/font-replacement/) je vynucený přepsání jednoho písma druhým v celé prezentaci. Substituce je pravidlo, které se spustí za konkrétní podmínky, například když není původní písmo dostupné, a pak se použije určené náhradní písmo.

**Kdy jsou pravidla substituce přesně použita?**  
Pravidla se podílejí na standardní sekvenci [font selection](/slides/cs/python-net/font-selection-sequence/), která je vyhodnocována během načítání, vykreslování a konverze; pokud zvolené písmo není dostupné, použije se nahrazení nebo substituce.

**Jaké je výchozí chování, pokud není nastaveno ani nahrazení ani substituce a písmo chybí v systému?**  
Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by to udělal PowerPoint.

**Mohu během běhu připojit vlastní externí písma, abych se vyhnul substituci?**  
Ano. Můžete během běhu [add external fonts](/slides/cs/python-net/custom-font/), aby je knihovna zohlednila při výběru a vykreslování, včetně následujících konverzí.

**Distribuuje Aspose s knihovnou nějaká písma?**  
Ne. Aspose nešíří placená ani volně dostupná písma; písma přidáváte a používáte na své vlastní uvážení a odpovědnost.

**Existují rozdíly v chování substituce na Windows, Linuxu a macOS?**  
Ano. Vyhledávání písem začíná v adresářích písem operačního systému. Sada výchozích dostupných písem a cesty pro hledání se liší mezi platformami, což ovlivňuje dostupnost a potřebu substituce.

**Jak bych měl připravit prostředí, aby se minimalizovala neočekávaná substituce během dávkových konverzí?**  
Synchronizujte sadu písem mezi stroji nebo kontejnery, [add the external fonts](/slides/cs/python-net/custom-font/) potřebné pro výstupní dokumenty a pokud je to možné, [embed fonts](/slides/cs/python-net/embedded-font/) v prezentacích, aby byla vybraná písma během vykreslování k dispozici.