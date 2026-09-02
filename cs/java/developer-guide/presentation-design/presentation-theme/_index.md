---
title: Správa témat prezentací v Javě
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/java/presentation-theme/
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
- Java
- Aspose.Slides
description: Hlavní témata prezentací v Aspose.Slides pro Javu pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotným brandem.
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si tématu vědomy, odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné prostřednictvím [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní téma pro snímek vyřešeno pomocí tohoto řetězce dědičnosti: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prozkoumání tématu, změnu barev a písem, kopírování nebo použití tématu, aktualizaci stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prozkoumat téma**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) exponuje barevné schéma, schéma písem a schéma formátování tématu prostřednictvím [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/). Prozkoumání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v téma uloženo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master přidružený k snímku a použijte pracovní postup pro efektivní téma, který je uveden později v článku, pokud mohou být přítomny přepsání rozložení nebo snímku.

## **Změnit barvy tématu**

Vyplněné oblasti, čáry a text, které jsou si tématu vědomy, mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyřešeny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neprojeví.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu `Accent4` v tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Protože obdélník zůstává propojen s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použít barvy z další palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides poskytuje tyto transformace prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy vygenerované z další palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, u pěti z nich aplikuje transformace luminance a uloží výsledek:

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

### **Mapovat hodnoty `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/) exponuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevně dané:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejedná se o hodnoty, které se dynamicky převádějí z jedné podoby do druhé.

## **Změnit písma tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) exponují tyto sady.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělo textu Latin (Minor Latin Font)  
* `+mj-lt` – nadpis Latin (Major Latin Font)  
* `+mn-ea` – tělo textu Východní Asie (Minor East Asian Font)  
* `+mj-ea` – nadpis Východní Asie (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo tématu, a jeden řádek těla, který používá vedlejší latinské písmo. Poté změní písma tématu a uloží výsledek:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odstranění těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírovat nebo použít téma**

Níže uvedené pracovní postupy řeší různé problémy související s tématem.

### **Použít externí téma na snímky závislé na masteru**

Použijte [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) když máte soubor tématu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/), a předajte cestu k souboru tématu metodě.

Metoda provádí následující kroky:

1. Vytvoří nový master‑snímek založený na vybraném masteru.  
1. Aplikuje externí téma na nový master.  
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/).

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

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxreadexception/). Ověřujte cesty zadávané uživateli, ošetřujte selhání přístupu k souborovému systému a prezentaci ukládejte až po úspěšném použití tématu.

Překopírovány jsou jen snímky, které závisely na vybraném masteru. Snímky přidružené k jiným masterům zachovají své stávající mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty, které jsou si tématem vědomé, jsou vyřešeny vůči externímu tématu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte potřebná písma, poskytněte je přes [vlastní zdroje písem](/slides/cs/java/custom-font/), nebo nakonfigurujte [náhradu písem](/slides/cs/java/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů na úrovni snímku nebo rozložení.

### **Použít různá externí témata v prezentaci s více mastery**

Když není master znám předem, získáte jej ze vzorového snímku pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/). Před aplikací jakýchkoli témat uložte původní odkazy na mastery, protože každý volání vytvoří v prezentaci další master.

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/), poté klonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/) a klonovaný master. Tím se přenese master, jeho rozložení i přidružené téma.

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

Toto je preferovaný pracovní postup, když musí zdrojový snímek vypadat stejně v cíli. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikovat hodnoty tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozložení, inicializujte přepis na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepisu.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Tím se změní téma používané tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání místního přepisu a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/).

### **Aplikovat přepis tématu na rozložení**

Přepis na úrovni rozložení se aplikuje na snímky, které používají dané rozložení, pokud konkrétní snímek nemá svůj vlastní přepis. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Použijte master nebo téma na úrovni prezentace, když má mnoho rozložení a snímků sdílet stejný základní design; použijte přepis rozložení, když jedna rodina rozložení potřebuje odlišné stylování; a použijte přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizovat styly pozadí tématu**

Výplně pozadí tématu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/). Index stylu `0` znamená žádnou výplň z témy; kladné hodnoty jsou reference na styl pozadí tématu. To se liší od přímého indexování Java kolekce, kde `get_Item(0)` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí tematickou referenci pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na téma položce, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze master pozadí nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nevnímejte index stylu jako nulově‑založený index kolekce. Také se vyhněte pevně kódovanému číslu stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/java/presentation-background/).
{{% /alert %}}

## **Aktualizovat efekty tématu**

Schéma formátování tématu obsahuje samostatné kolekce výplní, čar a efektů exposované přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). Typická kancelářská témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají decentnímu, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když přistupujete k těmto kolekcím v Javě, index kolekce je nulově‑založený: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný pojem, exposovaný přes [IShapeStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se změní na pevnou barvu lesní zeleně a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, který slot stylu každý tvar odkazuje, a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Zjistit, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [IFillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformat/) pro vyřešení této hierarchie do neměnitelného [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/). Pouze když je `FillType.Solid`, měli byste číst vlastnosti pevné výplně.

Pro pevnou výplň [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/) vrací konečnou vykreslenou RGB hodnotu po aplikaci dědičnosti, vyhledání v tématu a transformací barev. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/), například `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní pevná výplň není založena na barvě schématu. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte jen lokální hodnotu [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorformat/) k klasifikaci výplně. Například část textu může mít žádnou lokálně definovanou barvu schématu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí barvu tématu a vyřeší se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozložení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně částí textu, vytiskne každou konečnou RGB hodnotu a přiřazenou barvu schématu a označí pevné výplně, které nebudou sledovat změny barvy tématu:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

Větev `NotDefined` poskytuje auditní seznam pevných výplní, které nebudou reagovat na změny v slotech barvy tématu. Přezkoumejte tyto objekty, když musí prezentace následovat novou paletu značky. Nahlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s tématem.

Objekty s efektivním formátem jsou snímky. Po změně tématu prezentace, přepisu tématu nebo jakéhokoli zděděného formátování znovu zavolejte `getEffective` a načtěte nový objekt `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Číst efektivní hodnoty tématu**

Surové objekty tématu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/), a pro výplň použijte [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), můžete přehlédnout master, rozložení, snímek nebo přepis tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího tématu všechny snímky v prezentaci?**

Ne. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) přiřadí pouze snímky, které závisí na vybraném masteru. Snímky používající jiné mastery zachovají své stávající témata.

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepis tématu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále zdědit své stávající témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/). Tím se zachová master, rozložení i téma společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/) pro snímek nebo rozložení tématu a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.