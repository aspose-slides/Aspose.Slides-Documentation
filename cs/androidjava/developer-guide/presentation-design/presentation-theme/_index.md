---
title: Správa témat prezentace na Androidu
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/androidjava/presentation-theme/
keywords:
- téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
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
description: "Hlavní témata prezentací v Aspose.Slides pro Android pomocí Javy pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotným firemním vzhledem."
---
## **Úvod**

Téma prezentace definuje koordinovaný soubor barev, fontů, stylů pozadí, výplní, čar a efektů. Objektům, které jsou „tema‑aware“, se odkazuje na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Prezentace může také obsahovat přepisování tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní téma pro snímek vyřešeno tímto řetězcem dědičnosti: téma prezentace, přepisování masteru, přepisování rozložení a přepisování snímku.

![Komponenty tématu: barvy, fonty, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prohlédnout téma, změnit barvy a fonty, zkopírovat nebo použít téma, aktualizovat styly pozadí a efektů a načíst efektivní hodnoty po vyřešení dědičnosti a přepisování.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) zveřejňuje schéma barev, schéma fontů a schéma formátů tématu pomocí [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte si master přiřazený ke snímku a použijte workflow efektivního tématu ukázané níže v tomto článku, když mohou být přítomny přepsání rozložení nebo snímku.

## **Změna barev tématu**

Tema‑aware výplně, čáry a text mohou odkazovat na logickou barvu ze výčtu [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neaplikuje.

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte schématickou barvu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použít barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides zveřejňuje tyto transformace pomocí výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije transformace luminance a výsledek uloží:

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

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/) zveřejňuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevně dané:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které se dynamicky převádějí z jedné podoby do druhé.

## **Změna fontů tématu**

Schéma fontů tématu obsahuje hlavní sadu fontů pro nadpisy a vedlejší sadu pro text těla. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) zpřístupňují tyto sady.

Identifikátory fontů kompatibilní s PowerPoint mohou být použity při formátování textu:

* `+mn-lt` – Tělo font Latin (Minor Latin Font)
* `+mj-lt` – Nadpis font Latin (Major Latin Font)
* `+mn-ea` – Tělo font East Asian (Minor East Asian Font)
* `+mj-ea` – Nadpis font East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinský font tématu a jeden řádek těla používající vedlejší latinský font. Poté změní fonty tématu a výsledek uloží:

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

Nadpis sleduje hlavní font a text těla sleduje vedlejší font. Text, který má explicitní název fontu místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma fontů tématu.

{{% alert color="info" title="Tip" %}}
Pro více informací o fontech v prezentacích viz [PowerPoint Fonts](/slides/cs/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopírovat nebo použít téma**

Existují dva běžné pracovní postupy, a řeší různé problémy.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/), poté naklonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) a naklonovaného masteru. Tím se přenesou master, jeho rozložení i přiřazené téma.

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

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouze klonování obsahu na nesouvisející cílový master může změnit barvy, fonty, pozadí a efekty řízené tématem.

### **Použít hodnoty tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozložení, inicializujte přepisování na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepisu.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Chcete‑li odstranit místní přepis a vrátit se k zděděným hodnotám, zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/).

### **Použít přepis tématu na rozložení**

Přepis na úrovni rozložení se vztahuje na snímky, které používají dané rozložení, pokud konkrétní snímek nemá vlastní přepis. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Použijte master nebo téma na úrovni prezentace, když má mnoho rozložení a snímků sdílet stejný základní design, přepis rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). PowerPoint může v UI nabídnout více možností pozadí, než kolik výplňových definic je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/). Index stylu `0` znamená žádnou výplň z tématu; kladné hodnoty jsou odkazy na styly pozadí tématu. To se liší od indexování Java kolekce přímo, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí počet dostupných výplní pozadí, přiřadí tematický odkaz na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte index stylu jako index kolekce začínající od nuly. Také se vyhněte hard‑codování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylu tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/androidjava/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátů tématu obsahuje samostatné kolekce výplní, čar a efektů, které jsou zpřístupněny pomocí [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). Typické Office témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl každou kolekci prohlížet místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když přistupujete k těmto kolekcím v Javě, index kolekce je nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, zpřístupněný přes [IShapeStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane plnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, na které sloty každý tvar odkazuje a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Načtení efektivních hodnot tématu**

Surové objekty tématu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), můžete přehlédnout master, rozložení, snímek nebo přepis tvaru, který mění konečný vzhled.

## **Často kladené otázky**

**Mohu použít téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepisované téma. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále zdědit své existující témata.

**Jaký je nejbezpečnější způsob, jak převést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování vzhledu zdroje naklonujte zdrojový master do cíle a naklonujte snímek s tímto masterem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/). Tím se master, rozložení i téma přenesou společně.

**Jak mohu vidět efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/) pro téma snímku nebo rozložení a odpovídající metody efektivních dat pro objekty formátu, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.