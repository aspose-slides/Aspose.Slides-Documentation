---
title: Konfigurace náhrady písma v prezentacích pomocí Javy
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/java/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- výměna písma
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a prověřte nahrazená písma v Aspose.Slides pro Javu při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písem umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze získat při vykreslování nebo konverzi prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete prozkoumat náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

## **Získání náhrad písem**

Použijte metodu [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) k určení, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstitutioninfo/) , které identifikují původní a nahrazené názvy písem.

Následující příklad v jazyce Java vypisuje všechny náhrady písem pro prezentaci:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Získání náhrad písem pro vybrané snímky**

Použijte přetížení [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s argumentem `int[] slides` k prozkoumání pouze náhrad nutných k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci po částech, hledáte snímky, které závisejí na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

`Pole slides` obsahuje indexy snímků číslované od jedné: `1` označuje první snímek. Naopak přístup k kolekci [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) používá nulové indexování, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při vytváření pole, abyste se vyhnuli chybám o jednu.

Zavolejte přetížení prostřednictvím metody [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getFontsManager--) . Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstitutioninfo/) , který obsahuje původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložních písem a [externě načtená písma](/slides/cs/java/custom-font/). Pravidla náhrady uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsubstrulecollection/) jsou použita při vykreslení prezentace, ale výsledek je neuvádí; místo toho zkontrolujte písma v výstupním souboru.

Stejná náhrada může být požadována více než jedním vybraným snímkem. Při vytváření inventáře písem nebo preflight zprávy duplicitní výsledky odstraňte. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte jedno podle rozsahu vykreslovací operace:

| Přetížení | Použijte, pokud |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) s žádnými argumenty | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, kontrolu po částech nebo částečný export. |

## **Nastavení pravidel náhrady písem**

Pro specifikaci písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a náhradní písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v jazyce Java nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykresluje první snímek k ověření výsledku. Náhradní písmo musí být pro Aspose.Slides k dispozici.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pro neomezenou změnu písem použitých v celé prezentaci viz [Font Replacement](/slides/cs/java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písma používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat přesně toto písmo pro výpočet a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby **Cambria Math** bylo dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Pravidla náhrady popsaná výše stále platí pro běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a substitucí písma?**

[Font replacement](/slides/cs/java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Substituce písma vybírá písmo pro výstupní vykreslení, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy jsou pravidla substituce aplikována?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/java/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WhenInaccessible` je pravidlo použito pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmech dostupných v runtime prostředí.

**Mohu načíst externí písma, abych se vyhnul substituci?**

Ano. Můžete [načíst externí písma](/slides/cs/java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste zodpovědní.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může na jiném vyžadovat substituci.

**Jak mohu zajistit konzistentní výběr písem při dávkových konverzích?**

Používejte stejné soubory písem a jejich verze na každém počítači nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/java/custom-font/) a [vložená písma](/slides/cs/java/embedded-font/) pokud licence dovoluje. Můžete také volat [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) před exportem, abyste identifikovali nečekané substituce.