---
title: Správa motivů prezentace na Androidu
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/androidjava/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Externí motiv
- THMX
- Barva motivu
- Dodatečná paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro Android pomocí Javy pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentace má motiv, který definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které berou v úvahu motiv, se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Hlavní snímek může přepsat motiv prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní motiv pro snímek vyřešen touto řadou dědičnosti: motiv prezentace, přepsání hlavního snímku, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejběžnější pracovní postupy s motivem: prohlédnout motiv, změnit barvy a písma, kopírovat nebo aplikovat motiv, aktualizovat styly pozadí a efektů a přečíst efektivní hodnoty po vyřešení dědičnosti a přepisů.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) poskytuje schéma barev motivu, schéma písem a schéma formátu prostřednictvím [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Pokud soubor používá více hlavních snímků, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte hlavní snímek přiřazený ke snímku a použijte pracovní postup s efektivním motivem zobrazený později v tomto článku, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Vyplněné oblasti, čáry a text, které berou v úvahu motiv, mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou barvu RGB, změna barvy motivu neovlivní.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Protože obdélník zůstává spojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tuto výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu použitím transformací barev. Aspose.Slides tyto transformace zpřístupňuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlé a tmavé barvy generované z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  

**2** – Světlejší a tmavší varianty odvozené od hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije transformace jasu a výsledek uloží:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/) představuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy stejných slotů motivu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna fontů motivu**

Schéma fontů motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) tyto sady zpřístupňují.

Kompatibilní identifikátory fontů motivu lze použít při formátování textu:

* `+mn-lt` – Tělo písma Latin (Menší latinské písmo)
* `+mj-lt` – Nadpisové písmo Latin (Hlavní latinské písmo)
* `+mn-ea` – Tělo písma East Asian (Menší východoasijské písmo)
* `+mj-ea` – Nadpisové písmo East Asian (Hlavní východoasijské písmo)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo motivu a jeden řádek těla používající menší latinské písmo motivu. Poté změní písma motivu a výsledek uloží:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nadpis používá hlavní písmo a tělo textu používá menší písmo. Text, který má explicitní název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma fontů motivu.

Hlavní a vedlejší kolekce fontů mohou také obsahovat mapování fontů pro jednotlivé psací systémy, například Cyriliku, Arabštinu, Japonštinu, Gruzínštinu a Thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o fontách prezentace viz [PowerPoint Fonts](/slides/cs/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivem.

### **Použití externího motivu na snímky závislé na hlavním snímku**

Použijte [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/) když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním hlavním snímku. Vyberte hlavní snímek ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/), a předejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový hlavní snímek na základě vybraného hlavního snímku.
2. Aplikuje externí motiv na nový hlavní snímek.
3. Přiřadí nový hlavní snímek všem snímkům, které dříve závisely na vybraném hlavním snímku.
4. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxreadexception/). Ověřujte cesty dodané uživateli, řešte selhání přístupu k souborovému systému a prezentaci uložte až po úspěšném aplikování motivu.

Přesouvají se pouze snímky, které závisely na vybraném hlavním snímku. Snímky spojené s jinými hlavními snímky si zachovají své stávající hlavní snímky a motivy. Barvy, písma, výplně, čáry, pozadí a efekty, které berou v úvahu motiv, jsou vyhodnoceny vůči externímu motivu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat beze změny. Přepsání na úrovni rozvržení a snímku může také získat přednost před hodnotami zděděnými z nového hlavního snímku.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je prostřednictvím [custom font sources](/slides/cs/androidjava/custom-font/) nebo nakonfigurujte [font substitution](/slides/cs/androidjava/font-substitution/).

Jedná se o přímý pracovní postup na úrovni hlavního snímku: metoda přijímá cestu k souboru `.thmx` a nevyžaduje manuální vytváření přepisů motivu na úrovni snímku nebo rozvržení.

### **Aplikace různých externích motivů v prezentaci s více hlavními snímky**

Když není relevantní hlavní snímek znám předem, získejte jej z reprezentativního snímku pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/). Uložte původní reference hlavních snímků před aplikací motivů, protože každý volání vytvoří další hlavní snímek v prezentaci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

První volání ovlivní pouze snímky, které závisely na `firstGroupMaster`, a druhé volání ovlivní pouze snímky, které závisely na `secondGroupMaster`. Snímky patřící k jinému hlavnímu snímku nejsou přeformátovány.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový hlavní snímek do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/), poté klonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) a klonovaný hlavní snímek. Tím se přenese hlavní snímek, jeho rozvržení i související motiv.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Jedná se o preferovaný pracovní postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvislý cílový hlavní snímek může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikace hodnot motivu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním hlavním snímku a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty motivu do přepsání.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Tím se změní motiv použitý tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/).

### **Aplikace přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Použijte motiv na úrovni hlavního snímku nebo prezentace, když má mnoho rozvržení a snímků sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). PowerPoint může v uživatelském rozhraní nabízet více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/). Index stylu `0` znamená žádnou výplň motivu; kladné hodnoty jsou reference na styl pozadí motivu. Toto se liší od indexování samotné Java kolekce, kde `get_Item(0)` značí první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí referenci na motivované pozadí prvnímu hlavnímu snímku a uloží prezentaci:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Viditelný výsledek závisí na položce motivu, na kterou odkazuje hlavní snímek, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí hlavního snímku nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nesprávně nepřistupujte k indexu stylu jako k indexu kolekce založenému na nule. Rovněž se vyhněte tvrdému zakódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/androidjava/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje samostatné kolekce stylů výplní, čar a efektů, které jsou zpřístupněny přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když v Javě přistupujete k těmto kolekcím, index kolekce je založený na nule: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy referencí stylu tvaru jsou samostatným konceptem, zpřístupněným přes [IShapeStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se změní na plnou lesní zelenou a třetí styl efektu získá vnější stín s rozsahem 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar používá a zda přímé formátování přepíše motiv.

## **Čtení efektivních hodnot motivu**

Syrové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar ve skutečnosti používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/).

Následující příklad přečte efektivní motiv, pozadí a první výplň tvaru ze snímku:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Používejte efektivní data pro diagnostiku vykreslování, validaci a srovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), můžete přehlédnout přepsání motivu na úrovni hlavního snímku, rozvržení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje aplikace externího motivu každý snímek v prezentaci?**

Ne. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/) přidělí pouze snímky, které závisí na vybraném hlavním snímku. Snímky používající jiné hlavní snímky si zachovají své existující motivy.

**Mohu aplikovat motiv na jediný snímek bez změny hlavního snímku?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky budou i nadále zdědit své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový hlavní snímek do cílové prezentace a klonujte snímek s tímto hlavním snímkem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/). Tím se zachová hlavní snímek, rozvržení i motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/) pro snímek nebo motiv rozvržení a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/). Tyto API vracejí vyřešené hodnoty po aplikaci dědičnosti a přepisů.