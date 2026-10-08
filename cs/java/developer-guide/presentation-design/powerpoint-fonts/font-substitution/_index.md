---
title: Konfigurace náhrady písem v prezentacích pomocí jazyka Java
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/java/font-substitution/
keywords:
- písmo
- nahrazovací písmo
- náhrada písma
- nahrazení písma
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písem a kontrolujte nahrazená písma v Aspose.Slides pro Java při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Nahrazení písma umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze získat při vykreslování nebo konverzi prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete zkontrolovat náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

Pokud je písmo dostupné, ale nemá oddělený tučný řez, viz [Zvládání písem bez odděleného tučného řezu](/slides/cs/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato část vysvětluje, jak rasterizovat dotčený text během exportu do PDF a jaké má důsledky pro výběr textu, vyhledávání a škálování.

## **Získání náhrad písem**

Použijte metodu [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) k určení, která písma budou nahrazena při vykreslování prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující příklad v Javě vypíše všechny náhrady písem pro prezentaci:

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

Použijte přetížení [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s argumentem `int[] slides` k inspekci pouze náhrad potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, provádíte inkrementální kontrolu velké prezentace, hledáte snímky závislé na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování, aniž byste zpracovávali nesouvisející snímky.

Pole `slides` obsahuje jednorázové indexy snímků: `1` označuje první snímek. Na rozdíl od toho kolekční přístup [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) používá nulové indexování, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při vytváření pole, abyste se vyhnuli chybám o jednu.

Zavolejte přetížení přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), který obsahuje původní a nahrazené názvy písem. Výsledek odráží aktuální písmo‑prostředí, nakonfigurovaná pravidla záložních písem a [externě načtená písma](/slides/cs/java/custom-font/). Pravidla náhrady uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) jsou aplikována při vykreslování prezentace, ale výsledek je neuvádí; zkontrolujte písma ve výstupním souboru.

Stejná náhrada může být požadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo předběžné zprávy výsledky deduplikujte. Následující příklad vypíše každou vrácenou náhradu a poté vytvoří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písma**

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a náhradní písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Vykreslete nebo převeďte prezentaci.

Následující příklad v Javě nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

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
Pro neomezenou změnu písem použitých v celé prezentaci, viz [Náhrada písem](/slides/cs/java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písem používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Matematické rovnice v Office Math mají dodatečnou podmínku. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže **Cambria Math** v těchto případech nahradit, a vykreslování může i nadále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí písmo](/slides/cs/java/custom-font/).

Toto omezení se vztahuje jen na rozvržení rovnic. Pravidla náhrady popsaná výše se i nadále vztahují na běžný text v prezentaci.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou písma a nahrazením (substitucí) písma?**

[Náhrada písem](/slides/cs/java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma (substituce) vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se aplikují pravidla substituce?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/java/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WhenInaccessible` se pravidlo použije jen když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se zabránilo substituci?**

Ano. Můžete [načíst externí písma](/slides/cs/java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste zodpovědní vy.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Nainstalovaná písma a umístění pro vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom stroji může na jiném vyžadovat náhradu.

**Jak zajistit konzistentní výběr písma při hromadných konverzích?**

Používejte stejné soubory písem a jejich verze na každém stroji nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/java/custom-font/), a [vložte písma](/slides/cs/java/embedded-font/), pokud to licence umožňuje. Můžete také před exportem zavolat [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) a identifikovat neočekávané náhrady.