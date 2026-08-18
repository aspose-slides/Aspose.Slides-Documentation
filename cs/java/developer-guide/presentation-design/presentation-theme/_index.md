---
title: Správa témat prezentací v Javě
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/java/presentation-theme/
keywords:
- téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- barva tématu
- dodatečná paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro Java pro vytváření, přizpůsobování a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektu citlivé na téma odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace přes [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat své zděděné téma přes [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). V praxi je efektivní téma snímku vyřešeno touto dědickou řetěznicí: téma prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: kontrola tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Kontrola tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) poskytuje schéma barev, schéma písem a schéma formátování tématu pomocí [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mastertheme/). Kontrola těchto kolekcí před jejich změnou je obzvláště užitečná, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Zkontrolujte master spojený se snímkem a použijte pracovní postup s efektivním tématem, který je ukázán později v článku, pokud mohou být přítomny přepsání rozvržení nebo snímku.

## **Změna barev tématu**

Výplně, čáry a text citlivé na téma mohou odkazovat na logickou barvu ze **enumerace** [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/). Když změníte odpovídající položku v [ IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neprojeví.

Následující komplexní příklad vytvoří tvar používající `Accent4`, změní barvu tématu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, po změně tématu se jeho viditelná barva změní na červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, další změny `Accent4` už tento výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tuto transformaci vystavuje prostřednictvím **enumerace** [ColorTransformOperation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy vygenerované z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje transformaci jasu a výsledek uloží:

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

**enumerace** [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) tyto sady vystavují.

Identifikátory písem kompatibilní s PowerPoint lze použít ve formátování textu:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo. Poté změní písma tématu a výsledek uloží:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

{{% alert color="info" title="Tip" %}}
Pro více informací o písmech v prezentacích viz [PowerPoint Fonts](/slides/cs/java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace tématu**

Existují dva běžné pracovní postupy, které řeší různé problémy.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/), poté naklonujte snímek s tímto masterem pomocí [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/). Tím se přenesou master, jeho rozvržení a přidružené téma.

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

Tento postup je upřednostňovaný, když musí zdrojový snímek v cílovém souboru vypadat stejně. Jednoduché klonování obsahu na nesouvisející master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikovat hodnoty tématu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepsání.

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

### **Aplikovat přepsání tématu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky používající toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když má mnoho rozvržení a snímků sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). PowerPoint může v uživatelském rozhraní zobrazit více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí zkontrolujte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na tematické styly pozadí. To se liší od indexování samotné Java kolekce, kde `get_Item(0)` značí první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí tematický odkaz na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek ovlivnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátování tématu obsahuje samostatné kolekce výplní, čar a efektů, které jsou vystaveny přes [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/) a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iformatscheme/). Typické kancelářské témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v Javě je index kolekce nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatným konceptem, vystaveným přes [IShapeStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které odkazují na tento styl; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu změní na červený, třetí styl výplně tématu se změní na plnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá figura odkazuje a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Surové objekty tématu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty ukazují, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a srovnání. Pokud kontrolujete jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), můžete přehlédnout přepsání masteru, rozvržení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí svá stávající témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu naklonujte zdrojový master do cílové destinace a naklonujte snímek s tímto masterem pomocí [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslidecollection/) a [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/). Tím se zachová master, rozvržení i téma společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseoverridethememanager/) pro téma snímku nebo rozvržení a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.