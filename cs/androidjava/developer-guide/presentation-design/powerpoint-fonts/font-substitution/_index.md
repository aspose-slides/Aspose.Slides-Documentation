---
title: Konfigurace náhrady písma v prezentacích na Androidu
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/androidjava/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- nahrazení písma
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a kontrolujte nahrazená písma v Aspose.Slides pro Android pomocí jazyka Java při vykreslování nebo převodu prezentací."
---
## **Přehled**

Náhrada písma umožňuje aplikaci Aspose.Slides použít dostupné písmo místo písma, které nelze při vykreslování nebo převodu prezentace získat. Náhrada ovlivňuje výstupní vykreslený obsah; nemění písmo přiřazené obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete prozkoumat náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč Android zařízeními a prostředími s různými dostupnými písmy.

## **Získání náhrad písma**

Použijte metodu [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) k určení, která písma budou při vykreslení prezentace nahrazena. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstitutioninfo/), které identifikují původní a náhradní názvy písem.

Následující Java příklad vypíše všechny náhrady písem pro prezentaci:

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

## **Získání náhrad písma pro vybrané snímky**

Použijte přetížení [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s argumentem `int[] slides` k prozkoumání pouze náhrad potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci po částech, hledáte snímky závislé na nedostupných písmech, připravujete minimální balíček písem pro Android aplikaci nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků začínající od 1: `1` označuje první snímek. Na rozdíl od toho kolekční přístup [Presentation.getSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) používá nulové indexování, takže stejný snímek se získá jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při vytváření pole, aby nedošlo k chybě o jeden.

Volání přetížení provedete přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getFontsManager--). Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstitutioninfo/), který obsahuje původní a náhradní název písma. Výsledek odráží aktuální písmenové prostředí, nakonfigurovaná pravidla záložních písem, pravidla náhrady uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsubstrulecollection/), a [externě načtená písma](/slides/cs/androidjava/custom-font/).

Stejná náhrada může být požadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo předběžné zprávy odstraňte duplicitní výsledky. Následující příklad vypíše každou vrácenou náhradu a poté vytvoří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písma**

Pro určení písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a náhradní písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Vykreslete nebo převádějte prezentaci.

Následující Java příklad nahradí `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

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

{{% alert color="info" title="Poznámka" %}}
Pro neomezenou změnu písem používaných v celé prezentaci viz [Font Replacement](/slides/cs/androidjava/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písma jsou součástí standardního procesu výběru písma používaného během vykreslování a převodu. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem definovaným pravidlem.

Matematické rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, může Aspose.Slides potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, např. **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo převod takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Načtěte jej jako [externí písmo](/slides/cs/androidjava/custom-font/), aby aplikace mohla použít jej během vykreslování a převodu.

Toto omezení se vztahuje na rozvržení rovnice. Pravidla náhrady popsaná výše stále platí pro běžný text v prezentaci.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**  
[Font replacement](/slides/cs/androidjava/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna konfigurací definovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady aplikují?**  
Pravidla se podílejí na [font selection sequence](/slides/cs/androidjava/font-selection-sequence/) během vykreslování a převodu. S podmínkou `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat zdrojové písmo.

**Co se stane, když písmo chybí a není nastaveno žádné pravidlo náhrady?**  
Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písech dostupných v runtime prostředí.

**Mohu načíst externí písma, abych se vyhnul náhradě?**  
Ano. Můžete [načíst externí písma](/slides/cs/androidjava/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a převodu.

**Distribuuje Aspose písma spolu s knihovnou?**  
Ne. Za poskytování písem a dodržování jejich licencí jste odpovědní vy.

**Mohou se výsledky náhrady lišit mezi Android zařízeními?**  
Ano. Dostupná systémová písma se mohou lišit podle verze Androidu, zařízení a výrobce, takže písmo dostupné v jednom prostředí může vyžadovat náhradu v jiném.

**Jak mohu zajistit konzistentní výběr písem napříč Android zařízeními?**  
Zabalte stejné požadované soubory písem s aplikací, [načtěte je jako externí písma](/slides/cs/androidjava/custom-font/) a [vložená písma](/slides/cs/androidjava/embedded-font/) pokud licence dovolí. Můžete také před exportem vyvolat [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) a identifikovat neočekávané náhrady.