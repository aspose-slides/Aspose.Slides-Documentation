---
title: Hantera presentationsteman på Android
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/androidjava/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
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
- Android
- Java
- Aspose.Slides
description: "Behärska presentations-teman i Aspose.Slides för Android via Java för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations tema definierar en koordinerad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt refererar till dessa gemensamma definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/). En presentation kan också innehålla temaunderlag på lägre nivåer. En master kan åsidosätta presentationstemat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effekstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mastertheme/) exponerar temats färgschema, teckensnittsschema och format-schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtemabets egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden, och använd arbetsflödet för effektiva teman som visas senare i denna artikel när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/schemecolor/). När du ändrar motsvarande post i [IColorScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schema‑färgen med en direkt färg på formen, kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformationer. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter producerade från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformationer på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Kartlägg `SchemeColor`‑värden till `IColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Kartläggningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller ett huvudteckensnitt för rubriker och ett mindre teckensnitt för brödtext. Metoderna [IFontScheme.getMajor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontscheme/) och [IFontScheme.getMinor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontscheme/) exponerar dessa uppsättningar.

PowerPoint‑kompatibla temateckensnittsidenterare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrikfont Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasiatisk (Minor East Asian Font)
* `+mj-ea` – Rubrikfont Östasiatisk (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtextlinje som använder det mindre Latin‑temateckensnittet. Därefter ändras temateckensnitten och resultatet sparas:

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

Rubriken följer huvudteckensnittet och brödtexten följer det mindre teckensnittet. Text som har ett uttryckligt teckensnittsnamn istället för en tematid kan inte automatiskt bytas när temateckensnittsschemat ändras.

Huvud‑ och mindre teckensnittssamlingarna kan också innehålla teckensnitts­mappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema när bilder flyttas**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern till mål‑presentationen med [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/), klona sedan bilden med [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/) och den klonade mastern. Detta för med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll på en orelaterad destinations‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste stanna på sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från källtemat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att förändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/overridetheme/).

### **Tillämpa en temåsåsidosättning på en layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen åsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma basdesign, en layout‑åsidosättning när en layoutfamilj behöver annan stil, och en bild‑åsidosättning endast för sanna undantag. Överdrivna bild‑nivå‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan visa fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint‑bakgrundsgalleri för ett presentations‑tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/background/). Ett stil‑index på `0` betyder ingen tematisk fyllning; positiva värden är referenser till temabakgrundsstilar. Detta skiljer sig från att indexera Java‑samlingen direkt, där `get_Item(0)` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en tematisk bakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av mastern och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund, kanske en förändring av endast master‑bakgrunden inte påverkar den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/background/) när du behöver den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}

Behandla inte stil‑indexet som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/androidjava/presentation-background/).

{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temas format‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effektstilar som exponeras via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iformatscheme/) och [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iformatscheme/). Vanliga Office‑teman innehåller ofta tre huvudstil‑poster som visuellt motsvarar subtil, medel och intensiv formatering, men kod bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, medel och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Java är samlings‑indexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En forms stil‑referens‑index är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar ett yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skogsgrün, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje‑, fyllnings‑ och skugga‑inställningar](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temobjekt berättar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/), kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidethememanager/) och initiera dess åsidosättningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona käll‑mastern till destinationen och klona bilden med den mastern via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/) och [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema och motsvarande effektiva‑data‑metoder för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.