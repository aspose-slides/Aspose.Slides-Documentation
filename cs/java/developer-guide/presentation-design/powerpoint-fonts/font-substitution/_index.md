---
title: Konfigurace substituce písma v prezentacích pomocí Javy
linktitle: Substituce písma
type: docs
weight: 70
url: /cs/java/font-substitution/
keywords:
- písmo
- nahrazení písma
- substituce písma
- nahrazení písma
- nahrazení písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: Umožněte optimální substituci písma v Aspose.Slides pro Javu při převodu prezentací PowerPoint a OpenDocument do jiných formátů souborů.
---
## **Přehled**

Substituce písma umožňuje Aspose.Slides použít jiné písmo, pokud původní písmo prezentace není během vykreslování nebo konverze k dispozici. Můžete zjistit, která písma byla nahrazena, pomocí metody `getSubstitutions` z rozhraní `IFontsManager`.

Aspose.Slides také umožňuje definovat pravidla substituce písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a pak tato pravidla aplikovat prostřednictvím správce písem prezentace.

## **Nastavení pravidel pro substituci písma**

Aspose.Slides umožňuje nastavit pravidla pro písma, která určují, co se má udělat v určitých podmínkách (například když písmo nelze získat) následujícím způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte písmo, které bude nahrazeno.  
3. Načtěte nové písmo.  
4. Přidejte pravidlo pro náhradu.  
5. Přidejte pravidlo do kolekce pravidel nahrazení písem prezentace.  
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento Java kód ukazuje proces substituce písma:

```java
// Načte prezentaci
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Načte zdrojové písmo, které bude nahrazeno
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Načte nové písmo
    IFontData destFont = new FontData("Arial");
    
    // Přidá pravidlo pro nahrazení písma
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Přidá pravidlo do kolekce pravidel substituce písma
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Přidá kolekci pravidel písma do seznamu pravidel
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Písmo Arial bude použito místo SomeRareFont, pokud je to písmo nedostupné
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Uloží obrázek na disk ve formátu JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="POZNÁMKA"  color="warning"   %}} 

Možná budete chtít zobrazit [**Nahrazení písma**](/slides/cs/java/font-replacement/). 

{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla substituce písma se podílejí na standardním procesu výběru písma používaném během vykreslování a konverze. Jsou vhodná pro běžné textové scénáře, kdy Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nakonfigurovaného pravidla.

Nicméně u rovnic Office Math existuje důležité omezení. Pokud byla rovnice vytvořena s **Cambria Math**, Aspose.Slides může i nadále vyžadovat původní písmo **Cambria Math** pro správný výpočet a vykreslení rozložení rovnice. Z tohoto důvodu není podporována substituce **Cambria Math** jiným matematickým písmem, jako je **STIX Two Math**, pro vykreslování rovnic a může stále vést k výjimce označující, že je vyžadováno **Cambria Math**.

Pro úspěšnou konverzi takových prezentací se ujistěte, že **Cambria Math** je pro Aspose.Slides v době běhu k dispozici. Můžete písmo nainstalovat do operačního systému nebo jej poskytnout jako [externí písmo](/slides/cs/java/custom-font/), aby se mohl podílet na běžném procesu výběru písma během vykreslování a konverze.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla substituce písma uvedená výše stále platí pro běžný text prezentace, když je původní písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a substitucí písma?**

[Replacement](/slides/cs/java/font-replacement/) (nahrazení) je vynucený zásah, který nahradí jedno písmo druhým v celé prezentaci. Substituce je pravidlo, které se aktivuje za specifické podmínky, například když je původní písmo nedostupné, a pak se použije určené náhradní písmo.

**Kdy přesně jsou pravidla substituce aplikována?**

Pravidla se podílejí na standardní [font selection](/slides/cs/java/font-selection-sequence/) (sekvenci výběru písma), která je vyhodnocována během načítání, vykreslování a konverze; pokud je vybrané písmo nedostupné, je použita náhrada nebo substituce.

**Jaké je výchozí chování, pokud není ani nahrazení, ani substituce nakonfigurována a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako to dělá PowerPoint.

**Mohu za běhu připojit vlastní externí písma, aby se zabránilo substituci?**

Ano. Můžete [add external fonts](/slides/cs/java/custom-font/) (přidat externí písma) za běhu, aby je knihovna zohlednila při výběru a vykreslování, včetně následných konverzí.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Aspose nešíří placená ani volně dostupná písma; písma přidáváte a používáte podle své vlastní uvážení a odpovědnosti.

**Jsou rozdíly v chování substituce na Windows, Linuxu a macOS?**

Ano. Objevování písem začíná v adresářích písem operačního systému. Soubor výchozích dostupných písem a vyhledávací cesty se liší mezi platformami, což ovlivňuje dostupnost a potřebu substituce.

**Jak připravit prostředí, aby se minimalizovala neočekávaná substituce během hromadných konverzí?**

Synchronizujte sadu písem mezi stroji nebo kontejnery, [add the external fonts](/slides/cs/java/custom-font/) (přidejte externí písma) vyžadovaná pro výstupní dokumenty a [embed fonts](/slides/cs/java/embedded-font/) (vložit písma) do prezentací, pokud je to možné, aby byla vybraná písma během vykreslování k dispozici.