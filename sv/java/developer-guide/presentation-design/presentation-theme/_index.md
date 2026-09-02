---
title: Hantera presentationsteman i Java
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Mästerteman för presentationer i Aspose.Slides för Java för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt refererar till dessa gemensamma definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides är presentationsnivåtemat tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). En presentation kan också innehålla temaundantag på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild ut genom denna arvskedja: presentationstema, master‑överlagring, layout‑överlagring och bild‑överlagring.

![Temakomponenter: färger, typsnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mastertheme/) exponerar temats färgschema, typsnittsschema och format‑schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stil‑poster kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera master‑bilder får du inte anta att varje bild har samma effektiva tema. Inspektera master‑bilden som är kopplad till bilden och använd arbetsflödet för effektiva teman som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/schemecolor/). När du ändrar motsvarande post i [IColorScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln fortsatt är länkat till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schema‑färgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den tilläggspalett**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformationer. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare och mörkare färger genererade från den tilläggspaletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, applicerar luminans‑transformationer på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare räknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Koppla `SchemeColor`‑värden till `IColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssats för rubriker och en sekundär typsnittssats för brödtext. Metoderna [IFontScheme.getMajor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontscheme/) och [IFontScheme.getMinor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontscheme/) exponerar dessa satser.

PowerPoint‑kompatibla tematypsnitts‑identifierare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrikfont Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasien (Minor East Asian Font)
* `+mj-ea` – Rubrikfont Östasien (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑tematypsnittet och en brödtext‑rad som använder sekundärt Latin‑tematypsnitt. Därefter ändras tematypsnitten och resultatet sparas:

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

Rubriken följer huvudtypsnittet och brödtexten följer sekundärt typsnitt. Text som har ett explicit typsnittnamn i stället för ett tema‑identifierare kommer inte automatiskt att bytas när tematypsnittsschemat ändras.

De stora och små typsnittssamlingarna kan också innehålla typsnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/java/script-specific-font-mappings/).

{{% alert color="info" title="Tips" %}}
För mer information om presentationstypsnitt, se [PowerPoint Fonts](/slides/sv/java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj master‑bilden från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda master‑bilden.
1. Tillämpar det externa temat på den nya master‑bilden.
1. Tilldelar den nya master‑bilden till alla bilder som tidigare berodde på den valda master‑bilden.
1. Returnerar den nyskapade [IMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på bilderna som beror på den första master‑bilden och sparar presentationen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ett ogiltigt, korrupt eller ej stödjat tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxreadexception/). Validera sökvägar som anger användare, hantera misslyckade filsystemsåtkomster och spara presentationen först när temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda master‑bilden omfördelas. Bilder som är kopplade till andra master‑bilder behåller sina befintliga master‑bilder och teman. Temamedvetna färger, typsnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, typsnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Layout‑ och bild‑åsidosättningar kan också ha företräde framför värden som ärvts från den nya master‑bilden.

Temat kan referera till typsnitt som inte finns i körmiljön. För enhetlig rendering och export, installera de nödvändiga typsnitten, tillhandahåll dem via [custom font sources](/slides/sv/java/custom-font/), eller konfigurera [font substitution](/slides/sv/java/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver ingen manuell skapelse av bild‑ eller layout‑åsåsidosättningar.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta master‑bilden inte är känd på förhand, hämta den från en representativ bild via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/) och [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras master‑bilder och tillämpar ett annat externt tema på varje grupp:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Det första anropet påverkar endast bilder som beror på `firstGroupMaster`, och det andra anropet påverkar endast bilder som beror på `secondGroupMaster`. Bilder som tillhör någon annan master‑bild omstylas inte.

### **Bevara ett källtema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑master‑bilden till mål‑presentationen med [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/), klona sedan bilden med [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidecollection/) och den klonade master‑bilden. Detta bär med sig master‑bilden, dess layouter och det associerade temat.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destinations‑master kan förändra temadrivna färger, typsnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste förbli på sin nuvarande master‑ och layout‑bild, initiera en bild‑nivå‑åsåsidosättning från käll‑temat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/overridetheme/) kopierar de tre huvudtemakomponenterna till åsåsidosättningen.

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

Detta ändrar temat som används av den bilden utan att förändra temat som ärvt av andra bilder. För att ta bort den lokala åsåsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/overridetheme/).

### **Tillämpa en temåsåsidosättning på en layout**

En layout‑nivå‑åsåsidosättning gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen åsåsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsåsidosättning när en layout‑familj behöver annan stil, och en bild‑åsåsidosättning endast för egentliga undantag. Överdrivna bild‑åsåsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iformatscheme/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt finns i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint‑bakgrundsstils­galleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/background/). Ett stil‑index på `0` betyder ingen temafyllning; positiva värden är referenser till temabakgrundsstilar. Detta skiljer sig från att indexera Java‑samlingen direkt, där `get_Item(0)` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första master‑bilden och sparar presentationen:

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

Det synliga resultatet beror på temaposten som master‑bilden refererar till samt eventuella bakgrundsåsåsidosättningar på layout‑ eller bildnivå. Om en bild har sin egen bakgrund kan enbart master‑bakgrundens förändring eventuellt inte påverka den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Varning" %}}
Behandla inte stil‑indexet som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tips" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/java/presentation-background/).
{{% /alert %}}

## **Uppdatera temats effekter**

Ett temats format‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effektstilar som exponeras via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iformatscheme/) och [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iformatscheme/). Vanliga Office‑teman innehåller ofta tre huvudstilsposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter applicerade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Java är samlings‑indexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En formes stil‑referens‑index är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de erforderliga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skogsgrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsåsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), kan du missa en master‑, layout‑, bild‑ eller form‑åsåsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/) omfördelar endast de bilder som beror på den valda master‑bilden. Bilder som använder andra master‑bilder behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master‑bilden?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidethememanager/) och initiera dess åsåsidosättning. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och vill bevara dess ursprungliga utseende, klona käll‑master‑bilden till destinationen och klona bilden med den master‑bilden via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/) och [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidecollection/). Detta behåller master‑bilden, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsåsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑data‑metoderna för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/). Dessa API‑er returnerar de lösta värdena efter att arv och åsåsidosättningar har tillämpats.