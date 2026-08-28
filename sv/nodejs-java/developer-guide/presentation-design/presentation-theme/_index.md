---
title: Hantera presentationsteman i JavaScript
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/nodejs-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
- ändra tema
- hantera tema
- externt tema
- THMX
- temafärg
- ytterligare palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska presentationsteman i JavaScript med Aspose.Slides för Node.js för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentations‑tema definierar en koordinerad uppsättning färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temabyte kan uppdatera många objekt samtidigt.

I Aspose.Slides är presentationens tema på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/). En presentation kan också innehålla temaunderskott på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterthememanager/), medan en layout eller enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentations‑tema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) exponerar temats färgschema, typsnittsschema och format‑schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden och använd det effektiva‑tema‑arbetsflöde som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan hänvisa till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/). När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/), löses alla objekt som fortfarande refererar den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln fortfarande är länkad till `Accent4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schemafärgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter som genereras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, applicerar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare räknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `ColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssamling för rubriker och en sekundär typsnittssamling för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) exponerar dessa samlingar.

PowerPoint‑kompatibla tematypsnittsidentifierare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubriktext Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasiatiskt (Minor East Asian Font)
* `+mj-ea` – Rubriktext Östasiatiskt (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora Latin‑tematypsnittet och en brödtextlinje som använder det lilla Latin‑tematypsnittet. Därefter ändras tematypsnitten och resultatet sparas:

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

Rubriken följer det stora typsnittet och brödtexten det lilla. Text som har ett explicit typsnittsnamn istället för en temaidentifierare byter inte automatiskt när tematypsnittsschemat ändras.

De stora och små typsnittssamlingarna kan även innehålla typsnittsmappningar för enskilda skriftsystem, såsom Kyrilliska, Arabiska, Japanska, Georgiska och Thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tips" %}}

För mer information om presentations‑typsnitt, se [PowerPoint Fonts](/slides/sv/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj mastern från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/), som representeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda mastern.
1. Tillämpar det externa temat på den nya mastern.
1. Tilldelar den nya mastern till alla bilder som tidigare berodde på den valda mastern.
1. Returnerar den nyss skapade [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första mastern och sparar presentationen:

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

Ett ogiltigt, korrupt eller ej stödjt tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxreadexception/). Validera sökvägar som anges av användare, hantera filsystem‑åtkomstfel och spara presentationen först när temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda mastern omfördelas. Bilder som är associerade med andra masters behåller sina befintliga masters och teman. Tema‑medvetna färger, typsnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, typsnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Layout‑nivå‑ och bild‑nivå‑åsidosättningar kan också ha företräde framför värden som ärvts från den nya mastern.

Temat kan referera till typsnitt som inte finns i körmiljön. För konsekvent rendering och export, installera de erforderliga typsnitten, tillhandahåll dem via [custom font sources](/slides/sv/nodejs-java/custom-font/), eller konfigurera [font substitution](/slides/sv/nodejs-java/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att man manuellt skapar bild‑ eller layout‑återsidesättningar.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta mastern inte är känd i förväg, hämta den från en representativ bild via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/) och [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras masters och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar endast de bilder som berodde på `firstGroupMaster`, och det andra anropet påverkar endast de som berodde på `secondGroupMaster`. Bilder som tillhör någon annan master återstylingas inte.

### **Bevara ett källtema när bilder flyttas**

Om du vill flytta en bild till en annan presentation och behålla dess ursprungliga design, klona källmastern till mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) och den klonade mastern. Detta tar med mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att enbart klona innehåll till en orelaterad destination‑master kan förändra temadrivna färger, typsnitt, bakgrunder och effekter.

### **Tilldela tema‑värden till en befintlig bild**

Om mål‑bilden måste stanna på sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från källtemat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/).

### **Tilldela ett temaunderskott till en layout**

Ett layout‑nivå‑underskott gäller för bilder som använder den layouten, såvida inte en viss bild har sitt eget underskott. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, ett layout‑underskott när en layoutfamilj behöver annan stil, och ett bild‑underskott endast för verkliga undantag. Överdrivna bild‑underskott gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och det aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/). Ett stilindex på `0` betyder ingen tematisk fyllning; positiva värden är referenser till temats bakgrundsstilar. Detta skiljer sig från indexering av JavaScript‑samlingen direkt, där `0` betyder det första lagrade objektet. Anta inte att varje presentation innehåller lika många bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en tematisk bakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av mastern och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kanske enbart master‑bakgrunden inte förändrar den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Varning" %}}

Behandla inte stilindexet som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.

{{% /alert %}}

{{% alert color="info" title="Tips" %}}

För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/nodejs-java/presentation-background/).

{{% /alert %}}

## **Uppdatera temats effekter**

Ett temats format‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effekstilar som exponeras via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/) och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

När du får åtkomst till dessa samlingar i JavaScript är samlingsindexeringen nollbaserad: index `0` är den första lagrade stilen och index `2` är den tredje. En forms stil‑referensindex är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapestyle/). Att modifiera en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen solid skogsgrön och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar samt om direkt formatering åsidosätter temat.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Avgör om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, en layout, en master, ett temastil eller en annan formateringsnivå. Anropa [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) för att lösa den hierarkin till ett oföränderligt effektiv‑fyllningsögonblick. Kontrollera först dess `getFillType`‑värde. Endast när det är `FillType.Solid` bör du läsa solid‑fyllningsegenskaperna.

För en solid fyllning returnerar `getSolidFillColor` det slutgiltiga renderade RGB‑värdet efter arv, temauppslagning och färgtransformeringar. Metoden `getSolidFillSchemeColor` returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/)-slot, exempelvis `Text1` eller `Accent6`. Ett värde `SchemeColor.NotDefined` betyder att den effektiva solida fyllningen inte är baserad på en schema‑färg. I ett arbetsflöde där fyllningar antingen är temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte det lokala värdet från [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorformat/) ensamt för att klassificera en fyllning. Till exempel kan en textdel sakna lokalt definierad schema‑färg, så dess lokala värde är `NotDefined`, medan dess effektiva fyllning ärvs från ett temafärg och löser till `Text1` eller `Accent6`. Omvänt visar `getSolidFillSchemeColor` vilken logisk temaplatsslot som producerade den effektiva färgen, men berättar inte varifrån slotten kom (objekt, stycke, layout, master eller annan nivå).

Följande exempel laddar en presentation, granskar både form‑fyllningar och text‑del‑fyllningar, skriver ut varje slutliga RGB‑värde och associerad schema‑färg samt flaggar solida fyllningar som inte följer temafärgsändringar:

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

Grenen `NotDefined` ger en granskningslista över solida fyllningar som inte kommer reagera på ändringar i temafärgsplatser. Granska dessa objekt när en presentation måste följa en ny varumärkespalett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schema‑värdet förklarar om det är kopplat till temat.

Effektiva‑format‑objekt är ögonblicksbilder. Efter att ha ändrat presentations‑temat, ett temaunderskott eller någon ärvd formatering, anropa `getEffective` igen och läs ett nytt effektiv‑fyllningsobjekt innan du jämför eller rapporterar färger.

## **Läs effektiva tema‑värden**

Rå tema‑objekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala underskott har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑underskott som ändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) omfördelar endast de bilder som beror på den valda mastern. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidethememanager/) och initiera dess underskottstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och vill bevara dess källutseende, klona källmastern till destinationen och klona bilden med den mastern med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och underskott?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema samt motsvarande effektiva‑data‑metoder för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och underskott har tillämpats.