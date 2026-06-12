---
title: Konfigurace náhrady písma v prezentacích pomocí JavaScriptu
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/nodejs-java/font-substitution/
keywords:
- písmo
- náhradní písmo
- nahrazení písma
- vyměnit písmo
- náhrada písma
- pravidlo nahrazení
- pravidlo výměny
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Umožněte optimální nahrazení písma v Aspose.Slides pro Node.js při převodu prezentací PowerPoint a OpenDocument do jiných formátů souborů v JavaScriptu."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít jiné písmo, když originální písmo prezentace není během vykreslování nebo konverze dostupné. Můžete zkontrolovat, která písma byla nahrazena, pomocí metody `getSubstitutions` ze třídy `FontsManager`.

Aspose.Slides také umožňuje definovat pravidla náhrady písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a pak tato pravidla použít prostřednictvím správce písma prezentace.

## **Nastavení pravidel náhrady písma**

Aspose.Slides vám umožňuje nastavit pravidla pro písma, která určují, co se má provést v určitých podmínkách (například když není možné písmo získat), tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo.
4. Přidejte pravidlo pro náhradu.
5. Přidejte pravidlo do kolekce pravidel náhrady písma prezentace.
6. Vygenerujte obrázek snímku a sledujte výsledek.

Tento JavaScript kód demonstruje proces náhrady písma:

```javascript
// Načte prezentaci
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Načte zdrojové písmo, které bude nahrazeno
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Načte nové písmo
    var destFont = new aspose.slides.FontData("Arial");
    // Přidá pravidlo písma pro náhradu písma
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Přidá pravidlo do kolekce pravidel náhrady písma
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Přidá kolekci pravidel písma do seznamu pravidel
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Písmo Arial bude použito místo SomeRareFont, pokud je to poslední nedostupné
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Uloží obrázek na disk ve formátu JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Možná budete chtít zobrazit [**Náhrada písma**](/slides/cs/nodejs-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písma se podílejí na standardním procesu výběru písma, který se používá během vykreslování a konverze. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nastaveného pravidla.

Nicméně rovnice Office Math mají důležité omezení. Pokud byla rovnice vytvořena s **Cambria Math**, Aspose.Slides může i nadále vyžadovat původní písmo **Cambria Math** pro výpočet a správné vykreslení rozvržení rovnice. Kvůli tomu není podporována náhrada **Cambria Math** jiným matematickým písmem, jako je **STIX Two Math**, pro vykreslování rovnic a může stále dojít k výjimce, která uvádí, že je vyžadováno **Cambria Math**.

Pro úspěšnou konverzi takových prezentací se ujistěte, že **Cambria Math** je pro Aspose.Slides k dispozici v době běhu. Písmo můžete nainstalovat do operačního systému nebo ho poskytnout jako [externí písmo](/slides/cs/nodejs-java/custom-font/), aby se mohlo podílet na běžném procesu výběru písma během vykreslování a konverze.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla náhrady písma popsaná výše se i nadále vztahují na běžný text prezentace, pokud je originální písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a substitucí písma?**

[Nahrazení](/slides/cs/nodejs-java/font-replacement/) je vynucený přepis jednoho písma jiným v celé prezentaci. Substituce je pravidlo, které se spustí za konkrétní podmínky, například když není originální písmo dostupné, a potom se použije určené náhradní písmo.

**Kdy jsou pravidla substituce přesně aplikována?**

Pravidla se podílejí na standardní sekvenci [výběru písma](/slides/cs/nodejs-java/font-selection-sequence/), která je vyhodnocována během načítání, vykreslování a konverze; pokud je vybrané písmo nedostupné, použije se nahrazení nebo substituce.

**Jaké je výchozí chování, pokud není nakonfigurováno ani nahrazení, ani substituce a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by to udělal PowerPoint.

**Mohu během běhu připojit vlastní externí písma, aby se předešlo substituci?**

Ano. Během běhu můžete [přidat externí písma](/slides/cs/nodejs-java/custom-font/), aby je knihovna zohlednila při výběru a vykreslování, včetně následných konverzí.

**Distribuuje Aspose s knihovnou nějaká písma?**

Ne. Aspose nešíří placená ani zdarma dostupná písma; písma přidáváte a používáte na vlastní uvážení a odpovědnost.

**Existují rozdíly v chování substituce na Windows, Linuxu a macOS?**

Ano. Vyhledávání písem začíná v adresářích písem operačního systému. Sada výchozích dostupných písem a vyhledávací cesty se liší mezi platformami, což ovlivňuje jejich dostupnost a potřebu substituce.

**Jak mám připravit prostředí, aby se minimalizovala nečekaná substituce během hromadných konverzí?**

Synchronizujte sadu písem napříč počítači nebo kontejnery, [přidejte externí písma](/slides/cs/nodejs-java/custom-font/) potřebná pro výstupní dokumenty a pokud je to možné, [vložte písma](/slides/cs/nodejs-java/embedded-font/) do prezentací, aby byla vybraná písma během vykreslování dostupná.