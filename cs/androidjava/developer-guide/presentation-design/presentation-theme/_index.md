---
title: Správa motivů prezentací na Androidu
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
- Barva motivu
- Další paleta
- Font motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- Prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte hlavní motivy prezentací v Aspose.Slides pro Android pomocí Javy, abyste vytvářeli, přizpůsobovali a konvertovali soubory PowerPoint s jednotnou značkou."
---
## **Úvod**

Motiv prezentace definuje koordinovanou sadu barev, fontů, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si vědomy motivu, se odkazuje na tyto sdílené definice místo toho, aby ukládaly každou vizuální vlastnost jako pevnou hodnotu, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní motiv pro snímek řešený tímto řetězcem dědičnosti: motiv prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty motivu: barvy, fonty, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejběžnější pracovní postupy s motivem: prohlédnout motiv, změnit barvy a fonty, kopírovat nebo použít motiv, aktualizovat styly pozadí a efektů a číst efektivní hodnoty po vyřešení dědičnosti a přepsání.

## **Prohlédněte motiv**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) vystavuje schéma barev motivu, schéma fontů a schéma formátování přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mastertheme/). Prohlížení těchto kolekcí před jejich změnou je obzvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a nahlásí, kolik stylů pozadí, výplně, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte master přiřazený ke snímku a použijte pracovní postup s efektivním motivem, který je uveden později v tomto článku, pokud mohou být přítomna přepsání rozložení nebo snímku.

## **Změňte barvy motivu**

Motiv‑svědomé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyhodnoceny proti nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy motivu neprojeví.

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použijte barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barvy. Aspose.Slides vystavuje tyto transformace přes výčtový typ [ColorTransformOperation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vygenerované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije transformace jasu a uloží výsledek:

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

### **Mapujte hodnoty `SchemeColor` na sloty `IColorScheme`**

Výčtový typ [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty dynamicky převáděné z jedné podoby do druhé.

## **Změňte fonty motivu**

Schéma fontů motivu obsahuje hlavní sadu fontů pro nadpisy a sekundární sadu fontů pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) vystavují tyto sady.

Identifikátory fontů kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělo fontu Latin (Minor Latin Font)
* `+mj-lt` – nadpisový font Latin (Major Latin Font)
* `+mn-ea` – tělo fontu East Asian (Minor East Asian Font)
* `+mj-ea` – nadpisový font East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinský font motivu, a jeden řádek těla, který používá sekundární latinský font motivu. Poté změní fonty motivu a uloží výsledek:

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

Nadpis následuje hlavní font a tělo textu následuje sekundární font. Text, který má explicitní název fontu místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma fontů motivu.

Hlavní a sekundární kolekce fontů mohou také obsahovat mapování fontů pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o fontech v prezentacích viz [PowerPoint Fonts](/slides/cs/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopírujte nebo aplikujte motiv**

Existují dva běžné pracovní postupy a řeší různé problémy.

### **Zachovejte zdrojový motiv při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/), poté klonujte snímek pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) a klonovaný master. Tím se přenesou master, jeho rozložení a související motiv společně.

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

Toto je preferovaný pracovní postup, když musí snímek ve zdroji vypadat stejně i v cíli. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, fonty, pozadí a efekty řízené motivem.

### **Aplikujte hodnoty motivu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozložení, inicializujte úroveň přepsání snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv používaný tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání místního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/overridetheme/).

### **Aplikujte přepsání motivu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Použijte motiv na úrovni masteru nebo prezentace, když mají mnoho rozložení a snímků sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídat pozdější globální změny motivu.

## **Aktualizujte styly pozadí motivu**

Výplně pozadí motivu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí motivu. To se liší od indexování Java kolekce přímo, kde `get_Item(0)` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

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

Viditelný výsledek závisí na položce motivu, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna jen master pozadí tento snímek nemusí změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte pevně zakódovanému číslu stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/androidjava/presentation-background/).
{{% /alert %}}

## **Aktualizujte efekty motivu**

Schéma formátování motivu obsahuje samostatné kolekce výplní, čar a efektů vystavené přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iformatscheme/). Typické Office motivy často obsahují tři hlavní položky stylů, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když v Javě přistupujete k těmto kolekcím, index kolekce je nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylů existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se stane plnou lesní zelení a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá forma odkazuje a zda přímé formátování přepíše motiv.

![Styly efektů motivu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtěte efektivní hodnoty motivu**

Surové objekty motivu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/), a pro výplň použijte [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), můžete přehlédnout master, rozložení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Mohu použít motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále zdědí své stávající motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/). Tím se udrží master, rozložení i motiv společně.

**Jak si mohu prohlédnout efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseoverridethememanager/) pro motiv snímku nebo rozložení a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.