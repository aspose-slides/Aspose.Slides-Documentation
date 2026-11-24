---
title: Správa témat prezentací na Androidu
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/androidjava/presentation-theme/
keywords:
- Téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- externí téma
- THMX
- barva tématu
- další paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro Android pomocí Javy pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotným značkováním."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si vědomy tématu, se místo uložení každé vizuální vlastnosti jako pevné hodnoty odkazuje na tyto sdílené definice, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace přes [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat své zděděné téma přes [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní téma pro snímek vyřešeno touto řetězovou dědičností: téma prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní toky s tématy: prozkoumání tématu, změna barev a písem, kopírování nebo použití tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prozkoumat téma**

Objekt [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) zpřístupňuje schéma barev tématu, schéma písem a schéma formátů přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Prozkoumání těchto kolekcí před jejich změnou je obzvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a nahlásí, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master spojený se snímkem a použijte pracovní tok efektivního tématu uvedený později v tomto článku, když mohou být přítomny přepsání rozvržení nebo snímku.

## **Změnit barvy tématu**

Výplně, čáry a text, které jsou si vědomy tématu, mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou rozděleny podle nové hodnoty. Objekty, které používají přímou RGB barvu, nejsou změněny aktualizací barvy tématu.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu tématu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, po změně tématu se jeho viditelná barva změní na červenou. Pokud nahradíte schématickou barvu přímou barvou na tvaru, pozdější změny `Accent4` již tuto výplň neovlivní.

### **Používat barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides zpřístupňuje tyto transformace přes výčet [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, aplikuje na pět z nich transformace jasu a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Namapovat hodnoty `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) zveřejňuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které se dynamicky převádějí z jedné podoby do druhé.

## **Změnit písma tématu**

Schéma fontů tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) tyto sady zpřístupňují.

Identifikátory fontů kompatibilních s PowerPoint lze použít při formátování textu:

* `+mn-lt` – Tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – Nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – Tělo písmo Východní Asie (Minor East Asian Font)
* `+mj-ea` – Nadpis písmo Východní Asie (Major East Asian Font)
* `+mn-cs` – Tělo písmo Složený skript (Minor Complex Script Font)
* `+mj-cs` – Nadpis písmo Složený skript (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo tématu, a jeden řádek těla, který používá vedlejší latinské písmo tématu. Poté změní písma tématu a uloží výsledek:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitní název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma fontů tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Pro více informací o písech prezentace viz [PowerPoint Fonts](/slides/cs/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **Rozpoznat odkazy na písmo tématu**

Při prozkoumávání textu může [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) vrátit odkaz na téma, například `+mn-lt`, místo názvu rodiny písma. Zavolejte [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) s vhodným [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) pro rozpoznání tohoto odkazu. Předpony `+mj` a `+mn` vybírají hlavní a vedlejší sady písem; přípony `-lt`, `-ea` a `-cs` vybírají jejich latinská, východoasijská a složená skriptová písma.

Získejte efektivní téma pomocí [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) na objektu, jehož téma se vztahuje k prozkoumanému textu. Pro obyčejný text na snímku zavolejte tuto metodu na snímku, aby kontext zahrnoval zděděné téma snímku i lokální přepsání. Při prozkoumávání rozvržení nebo samotného masteru použijte jeho vlastní efektivní téma. Nepředpokládejte, že téma prvního masteru platí pro každý snímek.

Následující příklad vytvoří část textu, která explicitně odkazuje na vedlejší latinské písmo. Inicializuje schéma písem snímku přes [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) a nastaví hlavní a vedlejší latinské rodiny na `Arial` a `Calibri`, což umožní reprodukovat výsledek bez vstupního souboru.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Výstup je `+mn-lt -> Calibri` následováno `Verdana -> Verdana`. Uložený odkaz zůstává beze změny, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby část použila `+mj-lt`, rozpoznala by se na `Arial` v tomto tématu.

Rozpoznání odkazu na téma identifikuje rodinu písem určenou tématem. Nekontroluje dostupnost písma ani neurčuje, který soubor písma je nakonec použit po substituci nebo náhradě glyfů během renderování. Viz [Font Selection Sequence](/slides/cs/androidjava/font-selection-sequence/) a [Font Substitution](/slides/cs/androidjava/font-substitution/) pro tyto samostatné kroky.

## **Kopírovat nebo použít téma**

Níže uvedené pracovní toky řeší různé problémy související s tématy.

### **Použít externí téma na snímky závislé na masteru**

Použijte [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) kdy máte soubor tématu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), a předejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master‑snímek založený na vybraném masteru.
1. Aplikuje externí téma na nový master.
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním masteru, a uloží prezentaci:

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

Neplatné, poškozené nebo nepodporované téma může způsobit [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Ověřujte cesty poskytnuté uživateli, řešte selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném použití tématu.

Pouze snímky, které závisely na vybraném masteru, jsou přeřazeny. Snímky spjaté s jinými mastery zachovávají své stávající mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty citlivé na téma jsou rozděleny vůči externímu tématu. Přímě přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní renderování a export nainstalujte požadovaná písma, poskytněte je přes [custom font sources](/slides/cs/androidjava/custom-font/), nebo nastavte [font substitution](/slides/cs/androidjava/font-substitution/).

Jedná se o přímý pracovní tok na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů tématu na úrovni snímku nebo rozvržení.

### **Použít různé externí témata v prezentaci s více mastery**

Když není master znám předem, získejte jej ze reprezentativního snímku pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Uchovávejte původní reference masterů před aplikací jakýchkoli témat, protože každé volání vytvoří další master v prezentaci.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiné externí téma:

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

První volání ovlivní jen snímky, které závisí na `firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisí na `secondGroupMaster`. Snímky patřící k jinému masteru nebudou přestylovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), poté naklonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) a naklonovaného masteru. Tím se přenese master, jeho rozvržení i související téma.

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

Toto je preferovaný pracovní tok, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Použít hodnoty tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozvržení, inicializujte přepis na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepisu.

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

Tím se změní téma použité tímto snímkem bez změny tématu zděděného ostatními snímky. Pro odebrání lokálního přepisu a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Použít přepis tématu na rozvržení**

Přepis na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud nemá konkrétní snímek svůj vlastní přepis. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když mají mnoho rozvržení a snímků sdílet stejný základní design, přepis rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují pozdější globální změny tématu.

<!-- visual-explanation:presentation-theme:start -->
[![Master téma napájí dva rozvržení; přepis rozvržení ovlivňuje jeho snímky kromě snímku s lokálnějším přepisem.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Přepis rozvržení se vztahuje na snímky používající toto rozvržení, pokud snímek neposkytuje vlastní přepis. Hodnoty založené na tématu následují jejich rozpoznané schéma; explicitně formátované objekty mohou zachovat svůj lokální vzhled. Uchovávejte přepisy tak úzké, jak je zamýšlená výjimka designu.*
<!-- visual-explanation:presentation-theme:end -->

## **Aktualizovat styly pozadí tématu**

Styl výplní pozadí tématu je uložen v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint může v rozhraní uživatele nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na tematické styly pozadí. To se liší od indexování Java kolekce přímo, kde `get_Item(0)` značí první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí odkaz na tematické pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na tématické položce, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}

Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/androidjava/presentation-background/).

{{% /alert %}}

## **Aktualizovat efekty tématu**

Schéma formátů tématu obsahuje samostatné kolekce výplní, čar a efektů zpřístupněné přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Typická kancelářská témata často obsahují tři hlavní položky stylů, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu použité na stejném tvaru](presentation-design_10.png)

Při přístupu k těmto kolekcím v Java je index kolekce nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` třetí. Indexy odkazů stylů tvaru jsou samostatný koncept, zpřístupněný přes [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylů existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane pevnou lesní zelenou a třetí styl efektu získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Vybrat výplň a styl čáry tématu pro tvar**

Tvar může nezávisle vybrat svou výplň a obrys pomocí [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) a [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Pro obě metody index `1` vybírá první položku v odpovídající kolekci tématu (`get_Item(0)`), index `2` vybírá druhou (`get_Item(1)`).

Následující příklad nastaví dva styly výplně (zlatý a nebesky modrý) a dva styly čáry (tmavě modré 6 pt a tmavě červené 12 pt) v výchozím tématu nové prezentace. Uloží snímek ve třech fázích, abyste mohli porovnat výsledky v PowerPointu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Úvodní styly | Změna pravého obrysu | Úprava první výplně tématu |
|:---:|:---:|:---:|
| ![Zlaté a nebesky modré obdélníky s odpovídajícími tenkými tmavě modrými obrysy](theme-style-initial.png) | ![Nebešky modrý obdélník má nyní silný tmavě červený obrys](theme-style-line-changed.png) | ![Levý obdélník je teď zelený a oba obrysy zůstaly beze změny](theme-style-fill-changed.png) |

Výběr jiného stylu čáry mění pouze obrys pravého obdélníku. Úprava první výplně tématu aktualizuje každý tvar, který ji používá. Zde se pouze levý obdélník zbarví zeleně.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat tuto část stylu tématu. Pokud změna indexu stylu nemá viditelný účinek, zkontrolujte [direct formatting](/slides/cs/androidjava/shape-formatting/) tvaru.

## **Zjistit, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) pro rozlišení této hierarchie do neměnného [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Pouze když je `FillType.Solid`, byste měli číst vlastnosti pevné výplně.

Pro pevnou výplň [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) vrací konečnou renderovanou RGB hodnotu po dědičnosti, vyhledání v tématu a aplikaci transformací barev. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/), například `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní pevná výplň není založena na schématické barvě. V pracovním toku, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte pouze lokální hodnotu [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) k zařazení výplně. Například část textu může nemít lokálně definovanou schématickou barvu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň dědí barvu tématu a rozpozná ji jako `Text1` nebo `Accent6`. Naopak, `getSolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně částí textu, vytiskne každou konečnou RGB hodnotu a související schématickou barvu a označí pevné výplně, které nebudou sledovat změny barvy tématu:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Větev `NotDefined` poskytuje auditní seznam pevných výplní, které nebudou reagovat na změny ve slotech barvy tématu. Projděte tyto objekty, když musí prezentace sledovat novou firemní paletu. Nahlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled propojen s tématem.

Objekty efektivního formátu jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli děděného formátování znovu zavolejte `getEffective` a načtěte nový objekt `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Číst efektivní hodnoty tématu**

Syrové objekty tématu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku renderování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), můžete přehlédnout přepis masteru, rozvržení, snímku nebo tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Mění aplikace externího tématu každý snímek v prezentaci?**

Ne. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery zachovají své stávající témata.

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepis tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cílové prezentace a naklonujte snímek s tímto masterem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Tím se master, rozvržení a téma udrží společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) pro téma snímku nebo rozvržení a odpovídající metody efektivních dat pro objekty formátu, jako jsou [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Tyto API vrací rozpoznané hodnoty po aplikaci dědičnosti a přepisů.