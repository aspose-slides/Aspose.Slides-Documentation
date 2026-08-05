---
title: Konfigurace nahrazování fontů v prezentacích pomocí C++
linktitle: Nahrazování fontů
type: docs
weight: 70
url: /cs/cpp/font-substitution/
keywords:
- font
- nahrazení fontu
- nahrazování fontu
- nahrazení fontu
- nahrazení fontu
- pravidlo nahrazování
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Umožněte optimální nahrazování fontů v Aspose.Slides pro C++ při převodu prezentací PowerPoint a OpenDocument do jiných formátů souborů."
---
## **Přehled**

Nahrazování fontů umožňuje Aspose.Slides použít jiný font, pokud není původní font prezentace během vykreslování nebo převodu dostupný. Můžete zjistit, které fonty byly nahrazeny, pomocí metody `GetSubstitutions` z rozhraní `IFontsManager`.

Aspose.Slides také umožňuje definovat pravidla nahrazování fontů. Například můžete určit, že nedostupný font má být nahrazen jiným dostupným fontem, a poté tato pravidla použít prostřednictvím správce fontů prezentace.

## **Nastavení pravidel nahrazování fontů**

Aspose.Slides umožňuje nastavit pravidla pro fonty, která určují, co se má provést v určitých podmínkách (například když není font přístupný), takto:

1. Načtěte příslušnou prezentaci.
2. Načtěte font, který bude nahrazen.
3. Načtěte nový font.
4. Přidejte pravidlo pro náhradu.
5. Přidejte pravidlo do kolekce pravidel nahrazování fontů prezentace.
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento C++ kód demonstruje proces nahrazování fontů:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Načte prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definuje font, který bude nahrazen, a nový font
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Přidá pravidlo pro nahrazení fontu
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Přidá pravidlo do kolekce pravidel nahrazování fontů
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Přidá kolekci pravidel fontu do seznamu pravidel
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Uloží PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Možná budete chtít zobrazit [**Nahrazení fontů**](/slides/cs/cpp/font-replacement/). 
{{% /alert %}}

## **Omezení pro fonty matematických rovnic**

Pravidla nahrazování fontů se podílejí na standardním procesu výběru fontu používaném během vykreslování a převodu. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může nahradit nedostupný font jiným dostupným fontem podle nastaveného pravidla.

Nicméně rovnice v Office mají důležité omezení. Pokud byla rovnice vytvořena pomocí **Cambria Math**, Aspose.Slides může i nadále vyžadovat původní font **Cambria Math** pro výpočet a správné vykreslení rozvržení rovnice. Z tohoto důvodu není podporováno nahrazování **Cambria Math** jiným matematickým fontem, například **STIX Two Math**, při vykreslování rovnic a může se stále objevit výjimka, která uvádí, že je vyžadován **Cambria Math**.

Chcete‑li takové prezentace úspěšně převést, ujistěte se, že **Cambria Math** je pro Aspose.Slides dostupný za běhu. Font můžete nainstalovat do operačního systému nebo jej poskytnout jako [externí font](/slides/cs/cpp/custom-font/), aby se mohl podílet na běžném procesu výběru fontu během vykreslování a převodu.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla nahrazování fontů popsaná výše stále platí pro běžný text prezentace, pokud je původní font nedostupný.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením fontu a nahrazováním fontu?**  
[Nahrazení](/slides/cs/cpp/font-replacement/) je vynucený přepis jednoho fontu jiným v celé prezentaci. Nahrazování je pravidlo, které se spustí za specifické podmínky, například když je původní font nedostupný, a poté se použije určený náhradní font.

**Kdy přesně jsou pravidla nahrazování aplikována?**  
Pravidla se podílejí na standardní sekvenci [výběru fontu](/slides/cs/cpp/font-selection-sequence/), která je vyhodnocována během načítání, vykreslování a převodu; pokud je zvolený font nedostupný, použije se nahrazení nebo nahrazování.

**Jaké je výchozí chování, pokud není nakonfigurováno ani nahrazení ani nahrazování a font chybí v systému?**  
Knihovna se pokusí vybrat nejbližší dostupný systémový font, podobně jako by to udělal PowerPoint.

**Mohu během běhu připojit vlastní externí fonty, abych se vyhnul nahrazování?**  
Ano. Můžete během běhu [přidat externí fonty](/slides/cs/cpp/custom-font/), aby je knihovna zohlednila při výběru a vykreslování, včetně následných převodů.

**Distribuuje Aspose nějaké fonty spolu s knihovnou?**  
Ne. Aspose nešíří placené ani volně dostupné fonty; fonty přidáváte a používáte na vlastní uvážení a odpovědnost.

**Existují rozdíly v chování nahrazování na Windows, Linuxu a macOS?**  
Ano. Zjišťování fontů začíná v adresářích fontů operačního systému. Sada výchozích dostupných fontů a vyhledávací cesty se liší mezi platformami, což ovlivňuje dostupnost a potřebu nahrazování.

**Jak bych měl připravit prostředí, aby se minimalizovalo neočekávané nahrazování během hromadných převodů?**  
Synchronizujte sadu fontů napříč stroji nebo kontejnery, [přidejte externí fonty](/slides/cs/cpp/custom-font/) potřebné pro výstupní dokumenty a [vložte fonty](/slides/cs/cpp/embedded-font/) do prezentací, pokud je to možné, aby byly vybrané fonty během vykreslování k dispozici.