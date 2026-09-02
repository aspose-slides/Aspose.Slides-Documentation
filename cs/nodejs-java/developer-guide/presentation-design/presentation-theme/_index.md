---
title: Spravovat témata prezentací v JavaScriptu
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/nodejs-java/presentation-theme/
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
- dodatečná paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte témata prezentací v JavaScriptu pomocí Aspose.Slides pro Node.js k vytváření, přizpůsobení a převodu souborů PowerPoint se sjednoceným brandováním."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou „theme‑aware“, stačí odkazovat na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma úrovně prezentace k dispozici prostřednictvím [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). V praxi je efektivní téma snímku vypočteno řetězcem dědičnosti: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prozkoumání tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prozkoumat téma**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) vystavuje schéma barev, schéma písem a schéma formátů prostřednictvím [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/). Prozkoumání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master přiřazený ke snímku a použijte pracovní postup efektivního tématu uvedený později v tomto článku, pokud mohou existovat přepsání na úrovni rozložení nebo snímku.

## **Změna barev tématu**

Theme‑aware výplně, čáry a text mohou odkazovat na logickou barvu ze výčtu [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou barvu RGB, změna barvy tématu neovlivní.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu `Accent4` v tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojen s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahrajete barvu schématu přímou barvou na tvar, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použít barvy z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje transformace luminance a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapovat hodnoty `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro běžný text. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn‑lt` – tělo textu Latin (Minor Latin Font)
* `+mj‑lt` – nadpis Latin (Major Latin Font)
* `+mn‑ea` – tělo East Asian (Minor East Asian Font)
* `+mj‑ea` – nadpis East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo. Pak změní písma tématu a výsledek uloží:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitně uvedeno jméno písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, např. cyrilici, arabštinu, japonštinu, gruzínštinu a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písech v prezentaci viz [PowerPoint Fonts](/slides/cs/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírovat nebo použít téma**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Použít externí téma na snímky závislé na hlavním snímku**

Použijte [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/), když máte soubor tématu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), která je reprezentována [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/), a předejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master slide na základě vybraného masteru.  
2. Aplikuje externí téma na nový master.  
3. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
4. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním masteru, a uloží prezentaci:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxreadexception/). Ověřte cesty zadávané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném aplikování tématu.

Přesunou se jen snímky, které závisely na vybraném masteru. Snímky spojené s jinými mastery si zachovají své stávající mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty „theme‑aware“ jsou vyhodnoceny vůči externímu tématu. Přímé barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou k dispozici v běhovém prostředí. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je prostřednictvím [custom font sources](/slides/cs/nodejs-java/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/nodejs-java/font-substitution/).

Jedná se o přímý pracovně‑úrovňový postup: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů tématu na úrovni snímku nebo rozložení.

### **Použít různá externí témata v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/). Před aplikací jakýchkoli témat uložte původní reference masterů, protože každé volání vytvoří další master v prezentaci.

Následující příklad použije snímky ze dvou sekcí k určení jejich masterů a aplikuje každé skupině jiné externí téma:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

První volání ovlivní jen snímky, které závisí na `firstGroupMaster`, a druhé volání jen snímky, které závisí na `secondGroupMaster`. Snímky patřící k jakémukoli jinému masteru nebudou přeformátovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/), poté naklonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) a naklonovaného masteru. Tím se přenese master, jeho rozložení i přidružené téma.

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

Jedná se o preferovaný postup, když musí zdrojový snímek v cílovém souboru vypadat stejně. Pouhé klonování obsahu na nesouvisející master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikovat hodnoty tématu na existující snímek**

Pokud má cílový snímek zůstat na svém aktuálním masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k děděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/).

### **Aplikovat přepsání tématu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když mají mnoho rozložení a snímků sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání následných globálních změn tématu.

## **Aktualizovat styly pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabízet více možností pozadí, než kolik výplňových definic je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty představují odkazy na styl pozadí tématu. To se liší od indexování JavaScriptové kolekce přímo, kde `0` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplně pozadí.

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

Viditelný výsledek závisí na položce tématu, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze master pozadí nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte pevně zakódovanému číslu stylu z jednoho souboru a předpokladu, že bude vypadat stejně v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/nodejs-java/presentation-background/).
{{% /alert %}}

## **Aktualizovat efekty tématu**

Schéma formátů tématu obsahuje samostatné kolekce výplní, čar a efektů vystavené prostřednictvím [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). Typické kancelářské téma často obsahuje tři hlavní položky stylů, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl každou kolekci prozkoumat místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v JavaScriptu je index kolekce nulový: index `0` je první uložený styl a index `2` je třetí. Indexy odkazů stylů tvaru jsou samostatný koncept, vystavený přes [ShapeStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapestyle/). Úprava tématického stylu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylů existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první tematická čára stane červenou, třetí tematická výplň se změní na plnou lesní zelenou a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá figura používá a zda přímé formátování nepřepíše téma.

![Styly efektů tématu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Zjištění, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/), aby se tato hierarchie vyřešila do neměnné snímkové výplně. Nejprve zkontrolujte hodnotu `getFillType`. Pouze pokud je `FillType.Solid`, měli byste číst vlastnosti plné výplně.

U plné výplně `getSolidFillColor` vrací finální vykreslenou hodnotu RGB po aplikaci dědičnosti, vyhledání v tématu a transformací barev. Metoda `getSolidFillSchemeColor` vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní plná výplň není založena na barvě schématu. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé barvy RGB, tato hodnota identifikuje přímou RGB výplň.

Nenavazujte pouze na lokální hodnotu [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorformat/). Například část textu může nemít lokálně definovanou barvu schématu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí tematickou barvu a vyřeší se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozložení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně částí textu, vytiskne každou finální hodnotu RGB a související barvu schématu a označí plné výplně, které nebudou sledovat změny barev tématu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Větve `NotDefined` poskytují auditní seznam plných výplní, které nebudou reagovat na změny v slotách barvy tématu. Přezkoumejte tyto objekty, když musí prezentace odpovídat nové paletě značky. Hlásená hodnota RGB stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s tématem.

Efektivní objekty jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli zděděného formátování opět zavolejte `getEffective` a přečtěte nový objekt efektivní výplně před porovnáním nebo hlášením barev.

## **Číst efektivní hodnoty tématu**

Raw objekty tématu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a srovnání. Pokud prozkoumáte pouze [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/), můžete postrádat přepsání v masteru, rozložení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího tématu každý snímek v prezentaci?**

Ne. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své stávající témata.

**Mohu aplikovat téma na jeden snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit své stávající témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu naklonujte zdrojový master do cílové prezentace a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/) a [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/). Tím se master, rozložení i téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/) pro téma snímku nebo rozložení a příslušné metody efektivních dat pro formátové objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/). Tyto API vracejí vyřešené hodnoty po aplikaci dědičnosti a přepisů.