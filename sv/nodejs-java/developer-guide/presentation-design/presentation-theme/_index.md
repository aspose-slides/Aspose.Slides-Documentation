---
title: Hantera presentations-teman i JavaScript
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/nodejs-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ange tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- temateckensnitt
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

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuell egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/). En presentation kan också innehålla temaarbeten på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). I praktiken löses det faktiska temat för en bild genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbeten: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa faktiska värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) exponerar temats färgschema, teckensnittsschema och format‑schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposterna kan variera.

Följande exempel läser de huvudsakliga temaparametrarna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters bör du inte anta att varje bild har samma faktiska tema. Inspektera den master som är kopplad till bilden och använd arbetsflödet för faktiska teman som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan hänvisa till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/). När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/) löses alla objekt som fortfarande refererar den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den faktiska fyllningsfärgen:

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schema‑färgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

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

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittsuppsättning för rubriker och en sekundär teckensnittsuppsättning för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) exponerar dessa uppsättningar.

PowerPoint‑kompatibla temateckensnittsidenterare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrik Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasiatiskt (Minor East Asian Font)
* `+mj-ea` – Rubrik Östasiatiskt (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtext‑rad som använder sekundärt Latin‑temateckensnitt. Det ändrar sedan temateckensnitten och sparar resultatet:

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

Rubriken följer huvudteckensnittet och brödtexten följer sekundärt teckensnitt. Text som har ett explicit teckensnittsnamn istället för en temaidenterare byter inte automatiskt när temateckensnittsschemat ändras.

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern till mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) och den klonade master‑instansen. Detta för med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att enbart klona innehåll till en orelaterad måldestination‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste förbli på sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från käll‑temat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att förändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/overridetheme/).

### **Tillämpa en temåsåsidosättning på en layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder den layouten, såvida inte en viss bild har sin egen åsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma basdesign, en layout‑åsidosättning när en layoutfamilj behöver annan formatering, och en bild‑åsidosättning endast för egentliga undantag. Överdrivna bild‑nivå‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temabakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan visa fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som faktiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint‑bakgrundsgalleri för ett presentations‑tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och det aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/). Ett stilindex på `0` betyder ingen temafyllning; positiva värden är referenser till temats bakgrundsstil. Detta skiljer sig från att indexera JavaScript‑samlingen direkt, där index `0` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temareferens till den första master‑instansen och sparar presentationen:

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

Det synliga resultatet beror på vilken temapost som master‑instansen refererar till samt eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en förändring av bara master‑bakgrunden lämna bilden oförändrad. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter arv.

{{% alert color="warning" title="Warning" %}}
Behandla inte stilindex som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/nodejs-java/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temaformat‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effektstilar som exponeras via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/) och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/formatscheme/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter applicerade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i JavaScript är samlingsindexet nollbaserat: index `0` är den första lagrade stilen och index `2` är den tredje. En formes stilreferens‑index är ett separat begrepp, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapestyle/). Att modifiera en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

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

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med avstånd 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje‑, fyllnings‑ och skuggeinställningar](presentation-design_11.png)

## **Läsa faktiska temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Faktiska värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/).

Följande exempel läser det faktiska temat, bakgrunden och den första formens fyllning från en bild:

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

Använd faktiska data för diagnos av rendering, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/) kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidethememanager/) och initiera dess åsidosättningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess ursprungliga utseende, klona käll‑mastern till destinationen och klona bilden med den mastern via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslidecollection/) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de faktiska värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseoverridethememanager/) för en bild‑ eller layouttema och motsvarande faktiska‑data‑metoder för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/). Dessa API‑er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.