---
title: Konfigurace náhrady písma v prezentacích pomocí С++
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/cpp/font-substitution/
keywords:
- písmo
- nahrazení písma
- náhrada písma
- výměna písma
- náhrada písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- С++
- Aspose.Slides
description: "Umožněte optimální náhradu písma v Aspose.Slides pro С++ při konverzi prezentací PowerPoint a OpenDocument do jiných formátů souborů."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít jiné písmo, když původní písmo prezentace není během vykreslování nebo konverze k dispozici. Můžete zkontrolovat, která písma byla nahrazena, pomocí metody `GetSubstitutions` z rozhraní `IFontsManager`.

Aspose.Slides také umožňuje definovat pravidla pro náhradu písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem a poté tato pravidla použít prostřednictvím správce písma prezentace.

## **Nastavení pravidel náhrady písma**

Aspose.Slides umožňuje nastavit pravidla pro písma, která určují, co se má provést za určitých podmínek (například když není možné získat přístup k písmu) tímto způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte písmo, které bude nahrazeno.  
3. Načtěte nové písmo.  
4. Přidejte pravidlo pro nahrazení.  
5. Přidejte pravidlo do kolekce pravidel náhrady písma prezentace.  
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento C++ kód demonstruje proces náhrady písma:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Načte prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definuje písmo, které bude nahrazeno, a nové písmo
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Přidá pravidlo písma pro nahrazení písma
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Přidá pravidlo do kolekce pravidel náhrady písma
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Přidá kolekci pravidel písma do seznamu pravidel
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Uloží PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Možná budete chtít zobrazit [**Nahrazení písma**](/slides/cs/cpp/font-replacement/). 
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písma se účastní standardního procesu výběru písma používaného během vykreslování a konverze. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nakonfigurovaného pravidla.

Avšak matematické rovnice v Office mají důležité omezení. Pokud byla rovnice vytvořena pomocí **Cambria Math**, Aspose.Slides může stále vyžadovat původní písmo **Cambria Math** k vypočítání a správnému vykreslení rozvržení rovnice. Kvůli tomu není podporována náhrada **Cambria Math** jiným matematickým písmem, například **STIX Two Math**, pro vykreslování rovnic a může stále dojít k výjimce, která naznačuje, že je vyžadováno **Cambria Math**.

Aby bylo možné takové prezentace úspěšně převést, ujistěte se, že **Cambria Math** je pro Aspose.Slides v čase běhu dostupné. Písmo můžete nainstalovat do operačního systému nebo jej poskytnout jako [externí písmo](/slides/cs/cpp/custom-font/), aby se mohlo podílet na běžném výběru písma během vykreslování a konverze.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla náhrady písma popsaná výše stále platí pro běžný text prezentace, pokud je původní písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[**Nahrazení**](/slides/cs/cpp/font-replacement/) je vynucený přepis jednoho písma jiným v celé prezentaci. Náhrada je pravidlo, které se spustí za konkrétní podmínky, například když není původní písmo k dispozici, a pak se použije určené náhradní písmo.

**Kdy přesně jsou pravidla náhrady aplikována?**

Pravidla se účastní standardní [sekvence výběru písma](/slides/cs/cpp/font-selection-sequence/), která se vyhodnocuje během načítání, vykreslování a konverze; pokud je vybrané písmo nedostupné, použije se nahrazení nebo náhrada.

**Jaké je výchozí chování, pokud není nakonfigurováno ani nahrazení ani náhrada a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by to udělal PowerPoint.

**Mohu za běhu připojit vlastní externí písma, aby se zabránilo náhradě?**

Ano. Můžete [přidat externí písma](/slides/cs/cpp/custom-font/) za běhu, aby je knihovna zohlednila při výběru a vykreslování, včetně následných konverzí.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Aspose nešíří placená ani zdarma dostupná písma; písma přidáváte a používáte na vlastní odpovědnost.

**Existují rozdíly v chování náhrady na Windows, Linuxu a macOS?**

Ano. Vyhledávání písma začíná v adresářích písma operačního systému. Sada výchozích dostupných písem a vyhledávací cesty se liší napříč platformami, což ovlivňuje dostupnost a potřebu náhrady.

**Jak připravit prostředí, aby se minimalizovala nečekaná náhrada během hromadných konverzí?**

Synchronizujte sadu písem mezi stroji nebo kontejnery, [přidejte externí písma](/slides/cs/cpp/custom-font/) požadovaná pro výstupní dokumenty a [vložená písma](/slides/cs/cpp/embedded-font/) v prezentacích, pokud je to možné, aby vybraná písma byla během vykreslování dostupná.