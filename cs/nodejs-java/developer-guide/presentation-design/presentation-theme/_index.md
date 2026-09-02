---
title: Spravovat motivy prezentace v JavaScriptu
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/nodejs-java/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- nastavit motiv
- změnit motiv
- spravovat motiv
- barva motivu
- doplňková paleta
- písmo motivu
- styl motivu
- efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte motivy prezentací v JavaScriptu pomocí Aspose.Slides pro Node.js k vytváření, přizpůsobení a převodu souborů PowerPoint se jednotným brandováním."
---
## **Úvod**

Prezentace‑téma definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou „theme‑aware“, odkazují na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat prezentaci‑motiv pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). V praxi je efektivní motiv pro snímek vyřešený touto dědickou řetězcem: motiv prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže jsou uvedeny nejčastější pracovní postupy s motivem: prohlédnutí motivu, změna barev a písem, kopírování nebo použití motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) vystavuje schému barev motivu, schému písem a schému formátů přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je obzvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte si master přidružený ke snímku a použijte workflow efektivního motivu uvedené později v tomto článku, pokud mohou existovat přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Motiv‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyřešeny vůči nové hodnotě. Objektům, které používají přímou barvu RGB, změna barvy motivu neovlivní.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu ze schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint získává světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje přes výčtový typ [ColorTransformOperation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vygenerované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, aplikuje na pět z nich luminanční transformace a uloží výsledek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčtový typ [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy stejných slotů motivu; nejsou to hodnoty dynamicky převáděné z jedné podoby do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPoint lze použít při formátování textu:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo motivu a jeden řádek těla používající vedlejší latinské písmo motivu. Pak změní písma motivu a uloží výsledek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nadpis používá hlavní písmo a tělo používá vedlejší písmo. Text, který má explicitně uvedený název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psané systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidávání, nahrazování nebo odstraňování těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití motivu**

Existují dva běžné pracovní postupy a řeší různé problémy.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/), poté naklonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) a naklonovaného masteru. Tím se přenesou master, jeho rozvržení a související motiv dohromady.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Jednoduché klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Použití hodnot motivu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) kopírují tři hlavní komponenty motivu do přepsání.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Tím se změní motiv používaný tímto snímkem bez změny motivu zděděného ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/).

### **Použití přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Použijte motiv na úrovni masteru nebo prezentace, když má mnoho rozvržení a snímků sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku pouze pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí motivu. To se liší od indexování JavaScriptové kolekce přímo, kde `0` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše počet dostupných výplní pozadí, přiřadí tematický odkaz na pozadí prvnímu masteru a uloží prezentaci:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Viditelný výsledek závisí na položce motivu, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze master‑pozadí nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/nodejs-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátů motivu obsahuje samostatné kolekce výplní, čar a efektových stylů vystavené přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl každou kolekci prozkoumat místo předpokládání pevného počtu.

![Jemné, střední a intenzivní motivové efekty aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v JavaScriptu je index kolekce nulový: index `0` je první uložený styl a index `2` je třetí. Indexy odkazů stylů tvaru jsou samostatný koncept, vystavený přes [ShapeStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapestyle/). Úprava motivového stylu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím efektovém stylu a uloží výsledek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro tvary, které odkazují na tyto sloty, se první motivová čára stane červenou, třetí motivová výplň se stane plnou lesní zelení a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá figura odkazuje a zda přímé formátování přepisuje motiv.

![Motivové efektové styly po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Čtení efektivních hodnot motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnávání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/), můžete přehlédnout přepsání na úrovni masteru, rozvržení, snímku nebo tvaru, které mění finální vzhled.

## **FAQ**

**Mohu použít motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále zdědí své stávající motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cílové prezentace a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/) a [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/). Tím se master, rozvržení i motiv přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/) pro motiv snímku nebo rozvržení a odpovídající metody pro efektivní data formátových objektů, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.