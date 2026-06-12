---
title: Konfigurace substituce písma v prezentacích v .NET
linktitle: Substituce písma
type: docs
weight: 70
url: /cs/net/font-substitution/
keywords:
- písmo
- substituce písma
- substituce písma
- nahrazení písma
- nahrazení písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Povolte optimální substituci písma v Aspose.Slides pro .NET při konverzi prezentací PowerPoint a OpenDocument do jiných formátů souborů."
---
## **Přehled**

Substituce písma umožňuje Aspose.Slides použít jiné písmo, pokud původní písmo prezentace není během vykreslování nebo konverze k dispozici. Můžete zkontrolovat, která písma byla substituována pomocí metody `GetSubstitutions` z rozhraní `IFontsManager`.

Aspose.Slides také umožňuje definovat pravidla substituce písma. Například můžete určit, že nedostupné písmo má být nahrazeno jiným dostupným písmem, a poté tato pravidla aplikovat pomocí správce písma prezentace.

## **Získání substitucí písma**

Pro zjištění, která písma prezentace jsou během procesu vykreslování substituována, poskytuje Aspose.Slides metodu [GetSubstitution](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getsubstitutions/) z rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/).

Kód v C# ukazuje, jak získat všechny substituce písma, které jsou provedeny při vykreslení prezentace:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Nastavení pravidel substituce písma**

Aspose.Slides vám umožňuje nastavit pravidla pro písma, která určují, co je třeba udělat v určitých podmínkách (například když k písmu nelze přistupovat), následujícím způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo.
4. Přidejte pravidlo pro nahrazení.
5. Přidejte pravidlo do kolekce pravidel nahrazování písma v prezentaci.
6. Vygenerujte obrázek snímku, abyste pozorovali efekt.

Tento kód v C# demonstruje proces substituce písma:
```c#
 //Načte prezentaci
Presentation presentation = new Presentation("Fonts.pptx");

//Načte zdrojové písmo, které bude nahrazeno
IFontData sourceFont = new FontData("SomeRareFont");

//Načte nové písmo
IFontData destFont = new FontData("Arial");

//Přidá pravidlo pro nahrazení písma
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

//Přidá pravidlo do kolekce pravidel substituce písma
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

//Přidá kolekci pravidel písma do seznamu pravidel
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    //Uloží obrázek na disk ve formátu JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Můžete se podívat na [**Nahrazení písma**](/slides/cs/net/font-replacement/). 
{{% /alert %}}

## **Omezení pro písmo matematických rovnic**

Pravidla substituce písma se podílejí na standardním procesu výběru písma, který se používá během vykreslování a konverze. Jsou vhodná pro běžné textové scénáře, kde Aspose.Slides může nahradit nedostupné písmo jiným dostupným písmem podle nakonfigurovaného pravidla.

Nicméně rovnice v Office mají důležité omezení. Pokud byla rovnice vytvořena pomocí **Cambria Math**, Aspose.Slides může i nadále vyžadovat původní písmo **Cambria Math** pro výpočet a vykreslení rozložení rovnice správně. Z tohoto důvodu není podporována substituce **Cambria Math** jiným matematickým písmem, například **STIX Two Math**, pro vykreslování rovnic a může stále dojít k výjimce, která uvádí, že je vyžadováno **Cambria Math**.

Pro úspěšnou konverzi takových prezentací se ujistěte, že **Cambria Math** je v době běhu k dispozici pro Aspose.Slides. Písmo můžete nainstalovat do operačního systému nebo jej poskytnout jako [externí písmo](/slides/cs/net/custom-font/), aby se mohlo podílet na běžném procesu výběru písma během vykreslování a konverze.

Toto omezení se týká výhradně vykreslování rovnic. Standardní pravidla substituce písma popsaná výše se stále vztahují na běžný text v prezentaci, pokud je původní písmo nedostupné.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a substitucí písma?**

[Replacement](/slides/cs/net/font-replacement/) je vynucený přepis jednoho písma jiným v celé prezentaci. Substituce je pravidlo, které se aktivuje za specifické podmínky, například když není původní písmo k dispozici, a poté se použije určené náhradní písmo.

**Kdy jsou pravidla substituce aplikována?**

Pravidla se podílejí na standardní sekvenci [výběru písma](/slides/cs/net/font-selection-sequence/), která se vyhodnocuje během načítání, vykreslování a konverze; pokud není vybrané písmo dostupné, použije se nahrazení nebo substituce.

**Jaké je výchozí chování, pokud není nakonfigurováno ani nahrazení ani substituce a písmo chybí v systému?**

Knihovna se pokusí vybrat nejbližší dostupné systémové písmo, podobně jako by to udělal PowerPoint.

**Mohu při běhu připojit vlastní externí písma, aby se zabránilo substituci?**

Ano. Můžete při běhu [přidat externí písma](/slides/cs/net/custom-font/), aby je knihovna zohledňovala při výběru a vykreslování, včetně následných konverzí.

**Distribuuje Aspose nějaká písma s knihovnou?**

Ne. Aspose nešíří žádná placená ani volně dostupná písma; písma přidáváte a používáte na vlastní uvážení a odpovědnost.

**Existují rozdíly v chování substituce na Windows, Linuxu a macOS?**

Ano. Vyhledávání písma začíná v adresářích písma operačního systému. Sada výchozích dostupných písem a vyhledávací cesty se liší mezi platformami, což ovlivňuje dostupnost a potřebu substituce.

**Jak připravit prostředí, aby se minimalizovala neočekávaná substituce během dávkových konverzí?**

Synchronizujte sadu písem mezi stroji nebo kontejnery, [přidejte externí písma](/slides/cs/net/custom-font/) potřebná pro výstupní dokumenty a pokud je to možné, [vložte písma](/slides/cs/net/embedded-font/) do prezentací, aby byla vybraná písma během vykreslování k dispozici.