---
title: Správa témat prezentací v JavaScriptu
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
- další paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte hlavní témata prezentací v JavaScriptu pomocí Aspose.Slides pro Node.js k vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou téma‑vědomé, jsou přiřazeny tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné pomocí [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). V praxi je efektivní téma snímku řešeno touto řetězovou dědičností: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější workflow s tématy: prohlédnutí tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) vystavuje schéma barev, schéma písem a schéma formátů tématu pomocí [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vykáže, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a použijte workflow s efektivním tématem uvedený později v tomto článku, pokud mohou existovat přepsání na úrovni rozložení nebo snímku.

## **Změna barev tématu**

Téma‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neprojeví.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu `Accent4` tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již nebudou tento výplň ovlivňovat.

### **Použití barev z další palety**

PowerPoint vytváří světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides vystavuje tyto transformace pomocí výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy vygenerované z další palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, aplikuje na pět z nich luminanční transformace a výsledek uloží:

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

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevně dané:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty dynamicky převáděné z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a pomocnou sadu pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – Tělo písma Latin (Minor Latin Font)
* `+mj-lt` – Nadpis písma Latin (Major Latin Font)
* `+mn-ea` – Tělo písma Východní Asie (Minor East Asian Font)
* `+mj-ea` – Nadpis písma Východní Asie (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající pomocní latinský font. Pak změní písma tématu a výsledek uloží:

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

Nadpis následuje hlavní písmo a tělo textu následuje pomocní font. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a pomocní kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentaci viz [PowerPoint Fonts](/slides/cs/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace tématu**

Níže uvedené workflow řeší různé problémy související s tématem.

### **Aplikovat externí téma na snímky závislé na masteru**

Použijte [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) když máte soubor tématu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), která je reprezentována objektem [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/), a předejte cestu k souboru tématu metodě.

Metoda provede následující operace:

1. Vytvoří nový master‑snímek na základě vybraného masteru.  
2. Aplikuje externí téma na nový master.  
3. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
4. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na první masteru, a uloží prezentaci:

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

Neplatné, poškozené nebo nepodporované téma může způsobit [PptxReadException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxreadexception/). Ověřujte cesty dodané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšné aplikaci tématu.

Přesunuty jsou pouze snímky, které závisely na vybraném masteru. Snímky přiřazené k jiným masterům si zachovají své existující mastery a témata. Téma‑vědomé barvy, písma, výplně, čáry, pozadí a efekty jsou vyhodnoceny vůči externímu tématu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat beze změny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytujte je přes [custom font sources](/slides/cs/nodejs-java/custom-font/) nebo nakonfigurujte [font substitution](/slides/cs/nodejs-java/font-substitution/).

Toto je přímý workflow na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů tématu na úrovni snímku nebo rozložení.

### **Aplikovat různá externí témata v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/). Před aplikací jakýchkoli témat uložte původní reference masterů, protože každé volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje odlišné externí téma na každou skupinu:

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

První volání ovlivní pouze snímky, které závisely na `firstGroupMaster`, a druhé volání pouze snímky, které závisely na `secondGroupMaster`. Snímky patřící k nějakému jinému masteru nebudou přestylovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, klonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/), potom klonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) a klonovaného masteru. Tím se přenese master, jeho rozložení i přidružené téma.

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

Toto je doporučený workflow, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikovat hodnoty tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozložení, inicializujte přepisování na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepisu.

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

Tím se změní téma používané tímto snímkem, aniž by došlo ke změně tématu zděděného ostatními snímky. Pro odebrání lokálního přepisu a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/overridetheme/).

### **Aplikovat přepis tématu na rozložení**

Přepis na úrovni rozložení se použije na snímky, které používají toto rozložení, pokud nemá konkrétní snímek vlastní přepis. Stejné metody inicializace lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když má mnoho rozložení a snímků sdílet stejný základní návrh, přepis rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují předvídání následných globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Pozadí tématu jsou uložena v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou reference na styl pozadí tématu. To se liší od indexování samotné JavaScript kolekce, kde `0` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí tematickou referenci pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek ovlivnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nezpracovávejte index stylu jako nulový index kolekce. Také se vyhněte hard‑codování čísla stylu z jednoho souboru a předpokládejte, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/nodejs-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátů tématu obsahuje oddělené kolekce výplní, čar a efektů, které jsou vystaveny přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/formatscheme/). Typické Office téma často obsahuje tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a výraznému formátování, ale kód by měl prozkoumat každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a výrazné efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v JavaScriptu je index kolekce nulový: index `0` je první uložený styl a index `2` je třetí. Indexy reference stylu tvaru jsou samostatným konceptem, který vystavuje [ShapeStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat beze změny.

Následující příklad ověří, že požadované položky stylu existují, změní první čárový styl, změní třetí výplňový styl, povolí vnější stín ve třetím efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první čárový styl tématu změní na červený, třetí výplňový styl tématu se stane plnou lesní zelení a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty styly každého tvaru používají a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Surové objekty tématu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/), můžete přehlédnout přepis masteru, rozložení, snímku nebo tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího tématu každý snímek v prezentaci?**

Ne. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají svá existující témata.

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepis tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále zdědí svá existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslidecollection/) a [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/). Tím se master, rozložení a téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseoverridethememanager/) pro snímek nebo rozložení tématu a odpovídající metody efektivních dat pro formátové objekty jako [Background.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.