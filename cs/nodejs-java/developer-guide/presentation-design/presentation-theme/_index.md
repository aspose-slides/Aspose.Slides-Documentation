---
title: Správa témat prezentací v JavaScriptu
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/nodejs-java/presentation-theme/
keywords:
- téma PowerPoint
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
description: "Ovládejte témata prezentací v JavaScriptu pomocí Aspose.Slides pro Node.js a vytvářejte, přizpůsobujte a převádějte soubory PowerPoint s konzistentním brandováním."
---
## **Úvod**

Téma prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou „tema‑vědomé“, se místo uložení každé vizuální vlastnosti jako pevné hodnoty odkazuje na tyto sdílené definice, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné pomocí [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). V praxi je efektivní téma pro snímek určeno tímto řetězcem dědičnosti: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Níže jsou uvedeny nejčastější pracovní postupy s tématy: inspekce tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Kontrola tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) vystavuje barevné schéma, schéma písem a schéma formátů tématu pomocí [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). Prohlížení těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a nahlásí, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Zkontrolujte master přidružený k snímku a použijte pracovní postup s efektivním tématem uvedený dále v tomto článku, pokud mohou být přítomny přepsání rozložení nebo snímku.

## **Změna barev tématu**

Tema‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/). Když změníte příslušnou položku v [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou rozřešeny vůči nové hodnotě. Objekty, které používají přímou RGB barvu, nejsou změněny aktualizací barvy tématu.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu `Accent4` tématu na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte schématickou barvu přímou barvou na tvaru, pozdější změny `Accent4` již tuto výplň neovlivní.

### **Použití barev z dalších palet**

PowerPoint vytváří světlejší a tmavší varianty z barvy tématu pomocí barevných transformací. Aspose.Slides tyto transformace vystavuje skrze výčet [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty odvozené od hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, u pěti z nich použije transformace luminance a výsledek uloží:

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

Výčet [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejedná se o hodnoty, které se dynamicky převádějí z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo tématu, a jeden řádek těla, který používá vedlejší latinské písmo tématu. Potom změní písma tématu a výsledek uloží:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne při změně schématu písem.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro kontrolu, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmech v prezentacích viz [PowerPoint Fonts](/slides/cs/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

### **Rozpoznání odkazů na písmo v tématu**

Při prohlížení textu může [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) vrátit odkaz na téma, například `+mn-lt`, místo názvu rodiny písma. Zavolejte [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) s příslušným efektivním tématem, aby se odkaz rozpoznal. Prefixy `+mj` a `+mn` vybírají hlavní a vedlejší sadu písem; přípony `-lt`, `-ea` a `-cs` vybírají jejich latinské, východoasijské a komplexní skripty.

Získejte efektivní téma pomocí [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) na objektu, jehož téma se vztahuje k prohlíženému textu. Pro běžný text na snímku zavolejte tuto metodu na snímku, aby kontext zahrnoval zděděné téma snímku i místní přepsání. Při prohlížení rozložení nebo samotného masteru použijte jeho vlastní efektivní téma. Nepředpokládejte, že téma prvního masteru platí pro každý snímek.

Následující příklad vytvoří část textu, která explicitně odkazuje na vedlejší latinské písmo. Inicializuje schéma písem snímku pomocí [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) a nastaví hlavní a vedlejší latinské rodiny na `Arial` a `Calibri`, což dělá výsledek reprodukovatelný bez vstupního souboru.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Výstup je `+mn-lt -> Calibri` následovaný `Verdana -> Verdana`. Uložený odkaz zůstává nezměněn, zatímco explicitní název rodiny je vrácen beze změny. Kdyby část používala `+mj-lt`, rozpoznala by se jako `Arial` v tomto tématu.

Rozpoznání odkazu na téma určuje rodinu písma, kterou téma specifikuje. Nepřekontroluje dostupnost písma ani neurčuje soubor písma, který je nakonec použit po substituci nebo fallbacku během vykreslování. Viz [Font Selection Sequence](/slides/cs/nodejs-java/font-selection-sequence/) a [Font Substitution](/slides/cs/nodejs-java/font-substitution/) pro tyto samostatné kroky.

## **Kopírování nebo aplikace tématu**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Aplikace externího tématu na snímky závislé na masteru**

Použijte [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) když máte soubor tématu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), která je reprezentována pomocí [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), a předejte cestu k souboru tématu metodě.

Metoda provede následující operace:

1. Vytvoří nový master slide na základě vybraného masteru.  
1. Aplikuje externí téma na nový master.  
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).

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

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/). Ověřujte cesty předané uživateli, ošetřete selhání přístupu k souborovému systému a prezentaci uložte až po úspěšné aplikaci tématu.

Přesměrovány jsou jen snímky, které závisely na vybraném masteru. Snímek přiřazený k jiným masterům si zachová své existující master a témata. Barvy, písma, výplně, čáry, pozadí a efekty závislé na tématu jsou rozřešeny vůči externímu tématu. Přímě přidělené barvy, písma, výplně a další explicitní formátování může zůstat nezměněno. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou dostupná v běhovém prostředí. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je pomocí [custom font sources](/slides/cs/nodejs-java/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/nodejs-java/font-substitution/).

Toto je přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů na úrovni snímku nebo rozložení.

### **Aplikace různých externích témat v multi‑master prezentaci**

Když není znám konkrétní master předem, získejte jej z reprezentativního snímku pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). Před aplikací jakýchkoli témat uložte původní odkazy na mastery, protože každé volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiné externí téma:

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jiným masterům nejsou přestylovány.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, zkopírujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), poté zkopírujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) a klonovaného masteru. Tím se přenese master, jeho rozložení i související téma.

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

Toto je preferovaný postup, když má zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na cizí master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikace hodnot tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozložení, inicializujte lokální přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odstranění lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/).

### **Aplikace přepsání tématu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají dané rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když má mnoho rozložení a snímků sdílet stejný základní design; přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování; a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání budoucích globálních změn tématu.


<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Přepsání rozložení se vztahuje na snímky používající dané rozložení, pokud snímek neposkytuje vlastní přepsání. Hodnoty řízené tématem sledují jejich rozřešené schéma; explicitně formátované objekty mohou zachovat svůj lokální vzhled. Udržujte přepsání co nejsužší, aby odpovídalo zamýšlené výjimece designu.*
<!-- visual-explanation:presentation-theme:end -->

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). PowerPoint může v UI nabízet více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na tematické styly pozadí. To se liší od indexování samotné JavaScriptové kolekce, kde `0` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí tematický odkaz na pozadí prvému masteru a uloží prezentaci:

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

Viditelný výsledek závisí na tématu, na které odkazuje master, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) pokud potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nezpracovávejte index stylu jako nulovou indexaci kolekce. Také se vyhněte hard‑kódu čísel stylů z jednoho souboru a předpokladu, že budou mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/nodejs-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátů tématu obsahuje samostatné kolekce výplní, čar a efektů vystavené pomocí [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). Typické Office téma často obsahuje tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokladu pevného počtu.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Při přístupu k těmto kolekcím v JavaScriptu je index kolekce nulový: index `0` je první uložený styl a index `2` je třetí. Indexy odkazů stylu tvaru jsou samostatný pojem, vystavený pomocí [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat beze změny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně a povolí vnější stín ve třetím stylu efektu, a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se změní na plnou lesní zelenou a třetí styl efektu získá vnější stín se vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar referencuje a zda přímé formátování nepřepisuje téma.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Výběr výplní a čar tématu pro tvar**

Tvar může nezávisle vybrat výplň a obrys pomocí [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) a [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). Pro obě metody index `1` vybírá první položku v odpovídající kolekci tématu (`get_Item(0)`), index `2` vybírá druhou (`get_Item(1)`).

Následující příklad nastaví dva styly výplně (zlato a nebe modrá) a dva styly čáry (tmavě modrá 6 pt a tmavě červená 12 pt) v výchozím tématu nové prezentace. Uloží snímek ve třech fázích, abyste mohli porovnat výsledky v PowerPointu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Počáteční styly | Změnit pravý obrys | Upravit první výplň tématu |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Výběr jiného stylu čáry mění jen obrys pravého obdélníku. Úprava první výplně tématu aktualizuje všechny tvary, které ji používají. Zde se pouze levý obdélník změní na zelenou.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat danou část stylu tématu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [direct formatting](/slides/cs/nodejs-java/shape-formatting/) tvaru.

## **Zjištění, zda efektivní výplň typu Solid používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) pro rozřešení této hierarchie do neměnného snímku efektivní výplně. Nejprve zkontrolujte hodnotu `getFillType`. Pouze když je `FillType.Solid`, čtěte vlastnosti výplně Solid.

Pro výplň typu Solid `getSolidFillColor` vrací finální renderovanou RGB hodnotu po dědičnosti, vyhledání v tématu a aplikaci barevných transformací. Metoda `getSolidFillSchemeColor` vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní výplň Solid není založena na schématické barvě. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nezávisle použijte lokální hodnotu [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) k určení typu výplně. Například část textu může nemít lokálně definovanou schématickou barvu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí barvu tématu a rozřeší se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozložení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně částí textu, vypíše každou finální RGB hodnotu a přidruženou schématickou barvu a označí výplně typu Solid, které nebudou sledovat změny barvy tématu:

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

Větev `NotDefined` poskytuje auditní seznam výplní typu Solid, které nebudou reagovat na změny slotů barvy tématu. Přezkoumejte tyto objekty, když prezentace musí následovat novou paletu značky. Nahlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco schématická hodnota vysvětluje, zda je tento vzhled spojen s tématem.

Objekty efektivního formátu jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli zděděného formátování zavolejte `getEffective` znovu a načtěte nový objekt efektivní výplně před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot tématu**

Surové objekty tématu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud kontrolujete pouze [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/), můžete přehlédnout master, rozložení, snímek nebo přepis tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího tématu každý snímek v prezentaci?**

Ne. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své existující témata.

**Mohu aplikovat téma jen na jeden snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky i nadále zdědí svá existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Když přesouváte snímek a zachováváte jeho původní vzhled, klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) a [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). Tím se zachová master, rozložení i téma společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) pro téma snímku nebo rozložení a odpovídající metody efektivních dat pro formátové objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). Tyto API vrací rozřešené hodnoty po aplikaci dědičnosti a přepisů.