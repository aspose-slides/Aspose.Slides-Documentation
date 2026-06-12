---
title: Nastavení náhrady písma v prezentacích pomocí PHP
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/php-java/font-substitution/
keywords:
- písmo
- náhrada písma
- substituce písma
- nahrazení písma
- nahrazení písma
- pravidlo substituce
- pravidlo náhrady
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Umožněte optimální substituci písma v Aspose.Slides pro PHP přes Java při převodu prezentací PowerPoint a OpenDocument do jiných formátů souborů."
---
## **Úvod**

Náhrada písma umožňuje Aspose.Slides použít jiné písmo, pokud původní písmo prezentace není během vykreslování nebo konverze k dispozici. Můžete zjistit, která písma byla nahrazena, pomocí metody `getSubstitutions` ze třídy `FontsManager`.

Aspose.Slides také umožňuje definovat pravidla náhrady písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a poté tato pravidla použít prostřednictvím správce písma prezentace.

## **Nastavení pravidel náhrady písma**

Aspose.Slides vám umožňuje nastavit pravidla pro písma, která určují, co se má provést za určitých podmínek (například když není písmo přístupné), tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo.
4. Přidejte pravidlo pro nahrazení.
5. Přidejte pravidlo do kolekce pravidel nahrazení písma prezentace.
6. Vygenerujte obrázek snímku a pozorujte výsledek.

Tento PHP kód demonstruje proces náhrady písma:

```php
  # Načte prezentaci
  $pres = new Presentation("Fonts.pptx");
  try {
    # Načte zdrojové písmo, které bude nahrazeno
    $sourceFont = new FontData("SomeRareFont");
    # Načte nové písmo
    $destFont = new FontData("Arial");
    # Přidá pravidlo pro nahrazení písma
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Přidá pravidlo do kolekce pravidel náhrady písma
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Přidá kolekci pravidel písma do seznamu pravidel
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Písmo Arial bude použito místo SomeRareFont, pokud je to druhé nedostupné
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Uloží obrázek na disk ve formátu JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 
Možná budete chtít zobrazit [**Náhrada písma**](/slides/cs/php-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písma se podílejí na standardním procesu výběru písma používaném během vykreslování a konverze. Jsou vhodná pro běžné scénáře textu, kde Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nastaveného pravidla.

Nicméně rovnice Office Math mají důležité omezení. Pokud byla rovnice vytvořena pomocí **Cambria Math**, Aspose.Slides může stále vyžadovat originální písmo **Cambria Math** k výpočtu a vykreslení rozložení rovnice správně. Kvůli tomu není podporována náhrada **Cambria Math** jiným matematickým písmem, jako je **STIX Two Math**, při vykreslování rovnic a může stále dojít k výjimce, která uvádí, že je vyžadováno **Cambria Math**.

Pro úspěšnou konverzi takových prezentací se ujistěte, že **Cambria Math** je během běhu k dispozici pro Aspose.Slides. Můžete písmo nainstalovat v operačním systému nebo jej poskytnout jako [externí písmo](/slides/cs/php-java/custom-font/), aby se mohlo podílet na běžném procesu výběru písma během vykreslování a konverze.

Toto omezení se vztahuje konkrétně na vykreslování rovnic. Standardní pravidla náhrady písma popsaná výše stále platí pro běžný text prezentace, pokud je originální písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou písma a jeho substitucí?**

[Náhrada](/slides/cs/php-java/font-replacement/) je vynucená přepsání jednoho písma jiným v celé prezentaci. Substituce je pravidlo, které se spustí za konkrétní podmínky, například když není originální písmo k dispozici, a poté se použije určené náhradní písmo.

**Kdy jsou pravidla substituce aplikována?**

Pravidla se podílejí na standardní sekvenci [výběru písma](/slides/cs/php-java/font-selection-sequence/), která je vyhodnocována během načítání, vykreslování a konverze; pokud je vybrané písmo nedostupné, použije se náhrada nebo substituce.

**Jaké je výchozí chování, pokud není nakonfigurována ani náhrada ani substituce a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by to udělal PowerPoint.

**Mohu za běhu připojit vlastní externí písma, aby se zabránilo substituci?**

Ano. Můžete během běhu [přidat externí písma](/slides/cs/php-java/custom-font/), aby je knihovna brala v úvahu při výběru a vykreslování, včetně následných konverzí.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Aspose nešíří placená ani volně dostupná písma; písma přidáváte a používáte na vlastní uvážení a odpovědnost.

**Existují rozdíly v chování substituce na Windows, Linuxu a macOS?**

Ano. Vyhledávání písma začíná v adresářích písma operačního systému. Sada výchozích dostupných písem a vyhledávací cesty se liší mezi platformami, což ovlivňuje jejich dostupnost a potřebu substituce.

**Jak mám připravit prostředí, aby se minimalizovala neočekávaná substituce během hromadných konverzí?**

Synchronizujte sadu písem mezi stroji nebo kontejnery, [přidejte externí písma](/slides/cs/php-java/custom-font/) potřebná pro výstupní dokumenty a pokud je to možné, [vložte písma](/slides/cs/php-java/embedded-font/) do prezentací, aby byla vybraná písma během vykreslování k dispozici.