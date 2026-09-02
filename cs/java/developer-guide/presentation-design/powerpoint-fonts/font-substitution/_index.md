---
title: Konfigurace substituce písem v prezentacích pomocí Javy
linktitle: Substituce písma
type: docs
weight: 70
url: /cs/java/font-substitution/
keywords:
- písmo
- nahrazující písmo
- substituce písem
- nahrazení písma
- náhrada písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Konfigurujte pravidla substituce písem a prohlédněte substituovaná písma v Aspose.Slides pro Javu při vykreslování nebo převodu prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Nahrazení písma umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze získat při vykreslování nebo převodu prezentace. Substituce ovlivňuje jen vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete si prohlédnout substituce, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různě nainstalovanými písmy.

## **Získání substitucí písma**

Použijte metodu [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) k určení, která písma budou substituována při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstitutioninfo/), které identifikují původní a substituované názvy písem.

Následující příklad v jazyce Java vypisuje všechny substituce písem pro prezentaci:

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

## **Získání substitucí písma pro vybrané snímky**

Použijte přetížení [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s argumentem `int[] slides` k prozkoumání pouze substitucí potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci inkrementálně, hledáte snímky závislé na nedostupných písmách, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků počínaje jedničkou: `1` označuje první snímek. Naproti tomu kolekční přístup [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) používá indexování od nuly, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při sestavování pole, aby nedošlo k chybám o jeden.

Volání přetížení proveďte přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getFontsManager--). Vrací pouze substituce určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstitutioninfo/), který obsahuje původní a substituovaný název písma. Výsledek odráží aktuální prostředí písem, nastavená pravidla záložního výběru, substituční pravidla uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsubstrulecollection/) a [externě načtená písma](/slides/cs/java/custom-font/).

Stejnou substituci může vyžadovat více než jeden vybraný snímek. Odstraňte duplicitní výsledky, když vytváříte inventář písem nebo preflight report. Následující příklad uvádí každou vrácenou substituci a poté vytváří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu operace vykreslování:

| Přetížení | Použít, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentů | Potřebujete substituce pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s `int[] slides` | Potřebujete substituce pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel substituce písem**

Pro specifikaci písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Vykreslete nebo převést prezentaci.

Následující příklad v jazyce Java substituuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být dostupné pro Aspose.Slides.

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
Pro neomezenou změnu písem používaných v celé prezentaci viz [Náhrada písem](/slides/cs/java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla substituce písem jsou součástí standardního procesu výběru písma používaného během vykreslování a převodu. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Matematické rovnice v Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, může Aspose.Slides potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které substituuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo převod takové prezentace zajistěte, aby **Cambria Math** bylo dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Pravidla substituce popsaná výše se i nadále vztahují na běžný text v prezentaci.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou písem a substitucí písma?**

[Náhrada písem](/slides/cs/java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Substituce písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se aplikují pravidla substituce?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/java/font-selection-sequence/) během vykreslování a převodu. S podmínkou `WhenInaccessible` se pravidlo použije jen tehdy, když Aspose.Slides nemůže získat zdrojové písmo.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písma. Výsledek závisí na pímech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se předešlo substituci?**

Ano. Můžete [načíst externí písma](/slides/cs/java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a převodu.

**Distribuuje Aspose písma s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste odpovědní vy.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat substituci na jiném.

**Jak zajistit konzistentní výběr písem při hromadných převodech?**

Používejte stejné soubory písem a jejich verze na každém stroji nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/java/custom-font/), a [vložená písma](/slides/cs/java/embedded-font/), pokud licence umožňuje. Také můžete před exportem zavolat [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) pro identifikaci neočekávaných substitucí.