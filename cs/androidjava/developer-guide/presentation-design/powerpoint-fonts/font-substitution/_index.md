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
- výměna písma
- pravidlo náhrady
- pravidlo výměny
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a prohlédněte si náhradní písma v Aspose.Slides pro Android pomocí Javy při vykreslování nebo konverzi prezentací."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze při vykreslování nebo konverzi prezentace získat. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete prohlédnout náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč Android zařízeními a prostředími s různými dostupnými písmy.

Pokud je písmo dostupné, ale nemá samostatnou tučnou variantu, podívejte se na [Zpracování písem bez samostatné tučné varianty](/slides/cs/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato část vysvětluje, jak během exportu do PDF rasterizovat postižený text a jaké jsou následky pro výběr textu, vyhledávání a škálování.

## **Získání náhrad písem**

Použijte metodu [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) k určení, která písma budou při vykreslování prezentace nahrazena. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), které identifikují původní a náhradní názvy písem.

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

Použijte přetížení [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s argumentem `int[] slides` k prohlédnutí pouze náhrad potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, postupně kontrolujete velkou prezentaci, hledáte snímky závislé na nedostupných písmech, připravujete minimální balíček písem pro Android aplikaci nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

`Pole `slides` obsahuje jednojmenné (one‑based) indexy snímků: `1` označuje první snímek. Naopak přístup k kolekci [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) používá nulové (zero‑based) indexování, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při vytváření pole, aby nedošlo k chybě o jednu.

Vyvolejte přetížení přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), který obsahuje původní a náhradní název písma. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla náhrad, pravidla náhrad uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), a [externě načtená písma](/slides/cs/androidjava/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo preflight zprávy výsledek deduplikujte. Následující příklad hlásí každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písma**

Jak specifikovat písmo, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v jazyce Java nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupný, a poté vykresluje první snímek k ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

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
Pro nepodmíněnou změnu písem použitých v celé prezentaci se podívejte na [Nahrazení písem](/slides/cs/androidjava/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písem používaného během vykreslování a konverze. Fungují pro běžný text, pokud Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozložení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může i nadále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Načtěte jej jako [externí písmo](/slides/cs/androidjava/custom-font/), aby jej aplikace mohla použít během vykreslování a konverze.

Toto omezení se vztahuje na rozložení rovnic. Výše popsaná pravidla náhrady se i nadále vztahují na běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**  
[Nahrazení písma](/slides/cs/androidjava/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady aplikují?**  
Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/androidjava/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**  
Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmenech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se zabránilo náhradě?**  
Ano. Můžete [načíst externí písma](/slides/cs/androidjava/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**  
Ne. Za poskytování písem a dodržování jejich licencí jste odpovědní vy.

**Mohou se výsledky náhrady lišit mezi Android zařízeními?**  
Ano. Dostupná systémová písma se mohou lišit mezi verzemi Androidu, zařízeními a výrobci, takže písmo dostupné v jednom prostředí může v jiném vyžadovat náhradu.

**Jak mohu zajistit konzistentní výběr písem napříč Android zařízeními?**  
Zabalte stejné požadované soubory písem do aplikace, [načtěte je jako externí písma](/slides/cs/androidjava/custom-font/) a [vložte písma](/slides/cs/androidjava/embedded-font/) když licence dovolí. Můžete také před exportem zavolat [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) k identifikaci neočekávaných náhrad.