---
title: Nastavení náhrady písma v prezentacích na Androidu
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/androidjava/font-substitution/
keywords:
- písmo
- nahrazení písma
- náhrada písma
- vyměnit písmo
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Povolte optimální náhradu písma v Aspose.Slides pro Android pomocí Javy při převodu prezentací PowerPoint a OpenDocument do dalších formátů souborů."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít jiné písmo, když původní písmo prezentace není během vykreslování nebo převodu k dispozici. Můžete zjistit, která písma byla nahrazena, pomocí metody `getSubstitutions` z rozhraní `IFontsManager`.

Aspose.Slides také umožňuje definovat pravidla náhrady písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a poté tato pravidla použít prostřednictvím správce písma prezentace.

## **Nastavení pravidel náhrady písma**

Aspose.Slides vám umožňuje nastavit pravidla pro písma, která určují, co se má v určitých podmínkách provést (například když není možné písmo získat) tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo.
4. Přidejte pravidlo pro nahrazení.
5. Přidejte pravidlo do kolekce pravidel náhrady písma v prezentaci.
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento kód v jazyce Java demonstruje proces náhrady písma:

```java
// Načte prezentaci
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Načte zdrojové písmo, které bude nahrazeno
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Načte nové písmo
    IFontData destFont = new FontData("Arial");
    
    // Přidá pravidlo písma pro náhradu písma
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Přidá pravidlo do kolekce pravidel náhrady písma
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Přidá kolekci pravidel písma do seznamu pravidel
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Písmo Arial bude použito místo SomeRareFont, když je toto nedostupné
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

{{%  alert title="NOTE"  color="warning"   %}} 
Možná budete chtít zobrazit [**Náhrada písma**](/slides/cs/androidjava/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písma se podílejí na standardním procesu výběru písma používaném během vykreslování a převodu. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nastaveného pravidla.

Nicméně rovnice Office Math mají důležité omezení. Pokud byla rovnice vytvořena s **Cambria Math**, Aspose.Slides může i nadále vyžadovat původní písmo **Cambria Math** k výpočtu a správnému vykreslení rozložení rovnice. Z tohoto důvodu není podporována náhrada **Cambria Math** jiným matematickým písmem, například **STIX Two Math**, pro vykreslení rovnice a může stále vést k výjimce, která uvádí, že je vyžadováno písmo **Cambria Math**.

Pro úspěšný převod takových prezentací zajistěte, aby **Cambria Math** bylo dostupné pro Aspose.Slides za běhu. Písmo můžete nainstalovat do operačního systému nebo jej poskytnout jako [externí písmo](/slides/cs/androidjava/custom-font/), aby se mohlo podílet na běžném procesu výběru písma během vykreslování a převodu.

Toto omezení se týká konkrétně vykreslování rovnic. Standardní pravidla náhrady písma popsaná výše se nadále vztahují na běžný text prezentace, když je původní písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[**Náhrada**](/slides/cs/androidjava/font-replacement/) je vynucené přepsání jednoho písma jiným v celé prezentaci. Substituce je pravidlo, které se aktivuje za specifické podmínky, například když není původní písmo dostupné, a poté se použije určené záložní písmo.

**Kdy jsou pravidla substituce přesně použita?**

Pravidla se podílejí na standardní sekvenci [výběru písma](/slides/cs/androidjava/font-selection-sequence/), která je vyhodnocována během načítání, vykreslování a převodu; pokud není vybrané písmo dostupné, použije se náhrada nebo substituce.

**Jaké je výchozí chování, pokud není nastaveno ani nahrazení ani substituce a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by postupoval PowerPoint.

**Mohu za běhu připojit vlastní externí písma, aby se předešlo substituci?**

Ano. Můžete za běhu [přidat externí písma](/slides/cs/androidjava/custom-font/), aby je knihovna zohlednila při výběru a vykreslování, včetně následných převodů.

**Distribuuje Aspose nějaká písma s knihovnou?**

Ne. Aspose nerozděluje placená ani zdarma písma; písma přidáváte a používáte na vlastní odpovědnost a podle vlastního uvážení.

**Existují rozdíly v chování substituce na Windows, Linuxu a macOS?**

Ano. Vyhledávání písem začíná v adresářích písem operačního systému. Sada výchozích dostupných písem a vyhledávací cesty se liší mezi platformami, což ovlivňuje dostupnost a potřebu substituce.

**Jak připravit prostředí, aby se minimalizovala nečekaná substituce během hromadných konverzí?**

Synchronizujte sadu písem mezi stroji nebo kontejnery, [přidejte externí písma](/slides/cs/androidjava/custom-font/) potřebná pro výstupní dokumenty a pokud je to možné, [vložit písma](/slides/cs/androidjava/embedded-font/) v prezentacích, aby byla vybraná písma během vykreslování k dispozici.