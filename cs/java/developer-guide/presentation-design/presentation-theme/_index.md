---
title: Správa témat prezentací v Javě
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/java/presentation-theme/
keywords:
- Téma PowerPointu
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
description: "Hlavní témata prezentací v Aspose.Slides pro Javu pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotným vzhledem."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si téma vědomé, odkazuje na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). V praxi se efektivní téma pro snímek určuje podle tohoto řetězce dědičnosti: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prohlédnutí tématu, změna barev a písem, kopírování nebo použití tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) zpřístupňuje schéma barev, schéma písem a schéma formátů tématu přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a nahlásí, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a použijte pracovní postup pro efektivní téma, který je ukázán později v tomto článku, pokud mohou být přítomna přepsání rozložení nebo snímku.

## **Změna barev tématu**

Vyplnění, čáry a text, které jsou si vědomy tématu, mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou přepočítány podle nové hodnoty. Objekty, které používají přímou barvu RGB, nejsou změněny aktualizací barvy tématu.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu `Accent4` tématu na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstane propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace zpřístupňuje přes výčet [ColorTransformOperation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy vytvořené z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje transformace jasu a výsledek uloží:

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

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/) zpřístupňuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) tyto sady zpřístupňují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn‑lt` – tělesné písmo Latin (menší latinové písmo)
* `+mj‑lt` – nadpisové písmo Latin (větší latinové písmo)
* `+mn‑ea` – tělesné písmo East Asian (menší východoasijské písmo)
* `+mj‑ea` – nadpisové písmo East Asian (větší východoasijské písmo)

Následující příklad vytvoří jeden nadpis používající hlavní latinové písmo tématu a jeden řádek těla používající vedlejší latinové písmo tématu. Pak změní písma tématu a výsledek uloží:

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

Nadpis používá hlavní písmo a text těla používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne při změně schématu písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}Pro více informací o písech v prezentaci viz [PowerPoint Fonts](/slides/cs/java/powerpoint-fonts/).{{% /alert %}}

## **Kopírování nebo použití tématu**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Použití externího tématu na snímky závislé na hlavním snímku**

Použijte [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) když máte soubor tématu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který je závislý na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/), a předávejte metodě cestu k souboru tématu.

Metoda provádí následující operace:

1. Vytvoří nový master snímek založený na vybraném masteru.  
2. Použije externí téma na nový master.  
3. Přiřadí nový master všem snímkům, které předtím závisely na vybraném masteru.  
4. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/).

Následující příklad použije externí téma na snímky, které závisí na prvním masteru, a prezentaci uloží:

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

Neplatné, poškozené nebo nepodporované téma může způsobit [PptxReadException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxreadexception/). Ověřujte cesty zadávané uživateli, ošetřujte selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném použití tématu.

Přiděleny jsou jen snímky, které závisely na vybraném masteru. Snímky spojené s jinými mastery si zachovávají své existující mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty, které jsou si vědomy tématu, jsou přepočítány vůči externímu tématu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může mít také přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte potřebná písma, poskytněte je pomocí [vlastních zdrojů písem](/slides/cs/java/custom-font/) nebo nakonfigurujte [náhradu písem](/slides/cs/java/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání tématu na úrovni snímku nebo rozložení.

### **Použití různých externích témat v prezentaci s více mastery**

Když není relevantní master znám předem, získejte jej z reprezentativního snímku pomocí [ISlide.getLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/). Uložte původní odkazy na mastery před aplikací jakýchkoli témat, protože každý volání vytvoří v prezentaci další master.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich masterů a na každou skupinu použije jiné externí téma:

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

První volání ovlivní jen snímky, které závisí na `firstGroupMaster`, a druhé volání jen snímky, které závisí na `secondGroupMaster`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/), poté naklonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/) a naklonovaného masteru. Tím se přenese master, jeho rozložení i související téma.

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

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Použití hodnot tématu na existujícím snímku**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/).

### **Použití přepsání tématu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když mnoho rozložení a snímků má sdílet stejný základní návrh, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné formátování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Styly výplní pozadí tématu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). PowerPoint může ve svém uživatelském rozhraní nabídnout více možností pozadí, než je počet fyzicky uložených definic výplní v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styl.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/). Index stylu `0` znamená žádnou výplň tématu; kladné hodnoty jsou odkazy na styl pozadí tématu. To se liší od indexování Java kolekce přímo, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí počet dostupných výplní pozadí, přiřadí odkaz na výplň tématu prvnímu masteru a prezentaci uloží:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}Treat the style index as a zero‑based collection index. Also avoid hard‑coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation‑specific.{{% /alert %}}

{{% alert color="info" title="Tip" %}}Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/java/presentation-background/).{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátů tématu obsahuje samostatné kolekce výplní, čar a efektových stylů zpřístupněné přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). Typická office témata často obsahují tři hlavní položky stylů, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prozkoumat každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty tématu použité na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v Javě je index kolekce nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazující na styl tvaru jsou samostatný pojem, zpřístupněný přes [IShapeStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím efektovém stylu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí výplň tématu se změní na plnou lesní zelenou a třetí efektový styl získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek nadále závisí na tom, které sloty stylu každá forma používá a zda přímé formátování přepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Surové objekty tématu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a srovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), můžete přehlédnout přepsání masteru, rozložení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené dotazy**

**Ovlivní použití externího tématu všechny snímky v prezentaci?**

Ne. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) přidělí pouze snímkům, které jsou závislé na vybraném masteru. Snímky používající jiné mastery si zachovají své existující témata.

**Mohu použít téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující témata.

**Jaký je nejbezpečnější způsob přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/) a naklonujte snímek s tímto masterem pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/). Tím se master, rozložení a téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/) pro snímek nebo rozložení tématu a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/). Tyto API vrací rozpoznané hodnoty po aplikaci dědičnosti a přepsání.