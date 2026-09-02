---
title: Hantera presentations-teman i JavaScript
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/nodejs-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentations-tema
- bildtema
- ange tema
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
description: "Behärska presentations-teman i JavaScript med Aspose.Slides för Node.js för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations‑tema definierar en koordinerad samling av färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt attribut som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/). En presentation kan också innehålla temaisöverskrivningar på lägre nivåer. En master kan överskriva presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan överskriva sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentations‑tema, master‑överskrivning, layout‑överskrivning och bild‑överskrivning.

![Temakomponenter: färger, typsnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa av effektiva värden efter att arv och överskrivningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) exponerar temats färgschema, typsnittsschema och format­schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa, eftersom antalet och innehållet i stil‑posterna kan variera.

Följande exempel läser huvudtema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden och använd arbetsflödet för effektiva teman som visas senare i artikeln när layout‑ eller bild‑överskrivningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/). När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schemafärgen med en direkt färg på formen, kommer senare förändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via [ColorTransformOperation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colortransformoperation/)-enumerationen.

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** - Huvudtemafärger.

**2** - Ljusa och mörka varianter producerade från huvudtemafärgerna.

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` förändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Kartlägg `SchemeColor`‑värden till `ColorScheme`‑platser**

[SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/)-enumerationen använder `Text1`, `Background1`, `Text2` och `Background2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/)-klassen exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som omvandlas dynamiskt från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssamling för rubriker och en sekundär typsnittssamling för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) exponerar dessa samlingar.

PowerPoint‑kompatibla tematypsnittsidentifierare kan användas i textformatering:

* `+mn-lt` - Kroppsteckensnitt Latin (Minor Latin Font)
* `+mj-lt` - Rubrikteckensnitt Latin (Major Latin Font)
* `+mn-ea` - Kroppsteckensnitt East Asian (Minor East Asian Font)
* `+mj-ea` - Rubrikteckensnitt East Asian (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑tematypsnittet och en brödtextlinje som använder sekundärt Latin‑tematypsnitt. Det ändrar sedan tematypsnitten och sparar resultatet:

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

Rubriken följer huvudtypsnittet och brödtexten följer sekundärt typsnitt. Text som har ett explicit typsnittnamn i stället för en temabetäkt identifierare kommer inte automatiskt att bytas när tematypsnittsschemat ändras.

De huvud‑ och sekundära typsnittssamlingarna kan även innehålla typsnittskarteringar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa kartläggningar, se [Script‑Specific Theme Fonts](/slides/sv/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑typsnitt, se [PowerPoint‑typsnitt](/slides/sv/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på slides som är beroende av en master**

Använd [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som är beroende av en viss master. Välj mastern från [Presentation.getMasters](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-samlingen, som representeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda mastern.
2. Tillämpar det externa temat på den nya mastern.
3. Tilldelar den nya mastern till alla bilder som tidigare var beroende av den valda mastern.
4. Returnerar den nyskapade [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/).

Följande exempel tillämpar ett externt tema på de bilder som är beroende av den första mastern och sparar presentationen:

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

Ett ogiltigt, korrupt eller ej‑stödd tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxreadexception/). Validera sökvägar som tillhandahålls av användare, hantera fel i filsystemet och spara presentationen först när temat har tillämpats korrekt.

Endast de bilder som var beroende av den valda mastern omplaceras. Bilder som är kopplade till andra masters behåller sina befintliga masters och teman. Tema‑medvetna färger, typsnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, typsnitt, fyllningar och andra explicita formateringar kan förbli oförändrade. Överskrivningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya mastern.

Temat kan referera till typsnitt som inte är tillgängliga i körmiljön. För konsekvent rendering och export, installera de nödvändiga typsnitten, tillhandahåll dem via [custom font sources](/slides/sv/nodejs-java/custom-font/), eller konfigurera [font substitution](/slides/sv/nodejs-java/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en sökväg till en `.thmx`‑fil och kräver inte att man manuellt skapar temaisöverskrivningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en presentation med flera masters**

När den relevanta mastern inte är känd i förväg, erhåll den från ett representativt bildobjekt via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/) och [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/). Spara de ursprungliga master‑referenserna innan du applicerar några teman eftersom varje anrop skapar en ny master i presentationen.

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

Det första anropet påverkar endast de bilder som var beroende av `firstGroupMaster`, och det andra anropet påverkar endast de bilder som var beroende av `secondGroupMaster`. Bilder som tillhör någon annan master omstylas inte.

### **Bevara ett källtema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern till mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) och den klonade mastern. Detta tar med master, dess layouter och det associerade temat.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destinations‑master kan förändra temadrivna färger, typsnitt, bakgrunder och effekter.

### **Tilldela temavärden till en befintlig bild**

Om mål‑bilden måste förbli på sin nuvarande master och layout, initiera en bild‑nivå‑överskrivning från käll‑temat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till överskrivningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvt av andra bilder. För att ta bort den lokala överskrivningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/).

### **Tilldela ett temaisöverskrivning till en layout**

En layout‑nivå‑överskrivning gäller för bilder som använder den layouten, såvida inte en viss bild har sin egen överskrivning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑överskrivning när en layoutfamilj behöver annan styling, och en bild‑överskrivning endast för verkliga undantag. Överdrivna bild‑nivå‑överskrivningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan visa fler bakgrundsalternativ i sitt användargränssnitt än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstils galleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/). En stil‑index på `0` betyder ingen temafylldning; positiva värden är temabakgrund‑stilreferenser. Detta skiljer sig från att indexera JavaScript‑samlingen direkt, där index `0` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antal tillgängliga bakgrundsfyllningar, tilldelar en temabaserad bakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som mastern refererar till samt eventuella bakgrundsöverskrivningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av endast master‑bakgrunden vara utan effekt på den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter arv.

{{% alert color="warning" title="Warning" %}}
Behandla inte stil‑indexet som ett nollbaserat samlingsindex. Undvik även att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/nodejs-java/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temats format­schema innehåller separata samlingar för fyllnings‑, linje‑ och effektstilar som exponeras via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/), och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). Vanliga Office‑teman innehåller ofta tre huvudstilsposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du åtkommer dessa samlingar i JavaScript är samlingsindexet nollbaserat: index `0` är den första lagrade stilen och index `2` är den tredje. En formes stil‑referensindex är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli orörda.

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen solid skogsgrön och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering överskrider temat.

![Temaeffektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temobjekt berättar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala överskrivningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑överskrivning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) omfördelar bara de bilder som är beroende av den valda mastern. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidethememanager/) och initiera dess överskrivningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

När du flyttar en bild och vill bevara dess ursprungliga utseende, klona käll‑mastern till destinationen och klona bilden med den mastern via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/). Detta bevarar master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och överskrivningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑data‑metoderna för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och överskrivningar har tillämpats.