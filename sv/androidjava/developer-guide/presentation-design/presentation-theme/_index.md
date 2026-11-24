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
- ange tema
- ändra tema
- hantera tema
- externt tema
- THMX
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska presentationsteman i Aspose.Slides för Android via Java för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt refererar till dessa gemensamma definitioner i stället för att lagra varje visuell egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). En presentation kan också innehålla temaarbeten på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentations­tema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, typsnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter arv och åsidosättningar.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) exponerar temats färgschema, typsnittsschema och formatschema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera master‑bilder, anta inte att varje bild har samma effektiva tema. Inspektera master‑bilden som är associerad med bilden, och använd arbetsflödet för effektivt tema som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). När du ändrar motsvarande post i [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln fortfarande är länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemat färgen med en direkt färg på formen, kommer senare ändringar av `Accent4` inte längre påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare och mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** - Huvudtemafärger.  
**2** - Ljusa och mörka varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare, beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)‑uppräkningen använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) exponerar samma temasporter som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dessa är alternativa namn för samma temasporter; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssamling för rubriker och en mindre typsnittssamling för brödtext. Metoderna [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) och [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) exponerar dessa samlingar.

PowerPoint‑kompatibla tematypsnittidentifierare kan användas i textformatering:

* `+mn-lt` - Kroppsfont Latin (Litet latin‑typsnitt)
* `+mj-lt` - Rubrikfont Latin (Stort latin‑typsnitt)
* `+mn-ea` - Kroppsfont East Asian (Litet östasiatiskt typsnitt)
* `+mj-ea` - Rubrikfont East Asian (Stort östasiatiskt typsnitt)
* `+mn-cs` - Kroppsfont Complex Script (Litet komplext skript‑typsnitt)
* `+mj-cs` - Rubrikfont Complex Script (Stort komplext skript‑typsnitt)

Följande exempel skapar en rubrik som använder det stora latin‑tematypsnittet och en brödtext som använder det lilla latin‑tematypsnittet. Det ändrar sedan tematypsnitten och sparar resultatet:

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

Rubriken följer det stora typsnittet och brödtexten följer det lilla typsnittet. Text som har ett explicit typsnittsnamn istället för en temabetydelse kommer inte automatiskt att bytas när tematypsnittsschemat ändras.

De stora och små typsnittssamlingarna kan också innehålla typsnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script-Specific Theme Fonts](/slides/sv/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tips" %}}
För mer information om presentations‑typsnitt, se [PowerPoint Fonts](/slides/sv/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **Lös tematypsnittsreferenser**

När du inspekterar text kan [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) returnera en temareferens såsom `+mn-lt` istället för ett typsnittsfamiljenamn. Anropa [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) med lämplig [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) för att lösa den referensen. Prefixen `+mj` och `+mn` väljer de stora respektive små typsnittssatserna; suffixen `-lt`, `-ea` och `-cs` väljer deras Latin‑, östasiatiska‑ och komplexa skript‑typsnitt respektive.

Få det effektiva temat via [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) på det objekt vars tema gäller för den inspekterade texten. För vanlig text på en bild, anropa denna metod på bilden så att kontexten inkluderar bildens ärvda tema och lokala åsidosättningar. När du inspekterar en layout eller en master själv, använd dess eget effektiva tema. Anta inte att den första master‑temat gäller för alla bilder.

Följande exempel skapar en textdel som explicit refererar till det lilla latin‑typsnittet. Det initierar en bild‑typsnittsschema via [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) och sätter de stora och små latin‑familjerna till `Arial` och `Calibri`, vilket gör resultatet reproducerbart utan en indatafil.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Utdata är `+mn-lt -> Calibri` följt av `Verdana -> Verdana`. Den lagrade referensen förblir oförändrad, medan ett explicit familjenamn returneras som det är. Om delen använde `+mj-lt` skulle den lösas till `Arial` i detta tema.

Att lösa en temareferens identifierar den typsnittsfamilj som angivits av temat. Den kontrollerar inte typsnittstillgänglighet eller bestämmer vilken typsnittfil som slutligen används efter ersättning eller teckenfallback vid rendering. Se [Font Selection Sequence](/slides/sv/androidjava/font-selection-sequence/) och [Font Substitution](/slides/sv/androidjava/font-substitution/) för dessa separata steg.

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj master‑bilden från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda master‑bilden.
2. Tillämpar det externa temat på den nya master‑bilden.
3. Tilldelar den nya master‑bilden till alla bilder som tidigare berodde på den valda master‑bilden.
4. Returnerar den nyss skapade [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första master‑bilden och sparar presentationen:

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

Ett ogiltigt, skadat eller ej stödjt tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Validera sökvägar som tillhandahålls av användare, hantera fel vid filsystemstillgång och spara presentationen först efter att temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda master‑bilden omfördelas. Bilder som är associerade med andra master‑bilder behåller sina befintliga master‑bilder och teman. Temamedvetna färger, typsnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, typsnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya master‑bilden.

Temat kan referera till typsnitt som inte är tillgängliga i körmiljön. För konsekvent rendering och export, installera de nödvändiga typsnitten, tillhandahåll dem via [custom font sources](/slides/sv/androidjava/custom-font/), eller konfigurera [font substitution](/slides/sv/androidjava/font-substitution/).

Detta är ett direkt arbetsflöde på masternivå: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att man manuellt skapar temåsåsidosättningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en presentation med flera master‑bilder**

När den relevanta master‑bilden inte är känd i förväg, hämta den från en representativ bild via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) och [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

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

Det första anropet påverkar endast de bilder som berodde på `firstGroupMaster`, och det andra anropet påverkar endast de bilder som berodde på `secondGroupMaster`. Bilder som tillhör någon annan master‑bild omstylas inte.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑master‑bilden till mål‑presentationen med [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), klona sedan bilden med [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) och den klonade master‑bilden. Detta överför master‑bilden, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i målet. Att bara klona innehåll till en orelaterad destination‑master kan ändra temastyrda färger, typsnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål­bilden ska behålla sin nuvarande master‑ och layout, initiera en bild‑nivå‑åsåsidosättning från källtemat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Tillämpa en temåsåsidosättning på en layout**

En åsidosättning på layout‑nivå gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen åsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentationsnivå‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layoutfamilj behöver annan stil, och en bild‑åsidosättning endast för verkliga undantag. Överdrivna bild‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

<!-- visual-explanation:presentation-theme:start -->
[![Ett master‑tema matar två layouter; en layout‑åsidosättning påverkar dess bilder förutom en bild med en mer lokal åsidosättning.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*En layout‑åsidosättning gäller för bilder som använder den layouten såvida inte en bild har en egen åsidosättning. Temabaserade värden följer deras lösta schema; explicit formaterade objekt kan behålla sitt lokala utseende. Håll åsidosättningar så begränsade som den avsedda design‑undantaget.*
<!-- visual-explanation:presentation-theme:end -->

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan erbjuda fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint‑bakgrundsstilsgalleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Ett stilindex på `0` betyder ingen temafyllning; positiva värden är temabakgrundsstil‑referenser. Detta skiljer sig från att indexera Java‑samlingen direkt, där `get_Item(0)` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en tematisk bakgrundsreferens till den första master‑bilden och sparar presentationen:

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

Det synliga resultatet beror på temaposteringen som refereras av master‑bilden och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av endast master‑bakgrunden ha ingen effekt på den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Varning" %}}
Behandla inte stilindexet som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tips" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/androidjava/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temafor‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effektstilar som exponeras via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) och [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter applicerade på samma form](presentation-design_10.png)

När du åtkommer till dessa samlingar i Java är samlingsindexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En formes stilreferensindex är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de erforderliga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkt. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje, fyllning och skuggegenskaper](presentation-design_11.png)

## **Välj temafyllnings- och linjestilar för en form**

En form kan välja sin fyllning och kontur oberoende via [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) och [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). För båda metoderna väljer index `1` den första posten i den motsvarande temasamlingen (`get_Item(0)`), och index `2` väljer den andra (`get_Item(1)`).

Följande exempel ställer in två fyllningsstilar (guld och himmelsblå) och två linjestilar (mörkblå på 6 pt och mörkröd på 12 pt) i standardtemat för en ny presentation. Det sparar bilden i tre steg så att du kan jämföra resultaten i PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Initiala stilar | Ändra högra konturen | Redigera första temafyllningen |
|:---:|:---:|:---:|
| ![Gyllene och himmelsblå rektanglar med matchande tunna mörkblå konturer](theme-style-initial.png) | ![Den himmelsblå rektangeln har nu en tjock mörkröd kontur](theme-style-line-changed.png) | ![Den vänstra rektangeln är nu grön och båda konturerna är oförändrade](theme-style-fill-changed.png) |

Att välja en annan linjestil ändrar endast den högra rektangelns kontur. Att redigera den första temafyllningen uppdaterar varje form som använder den. Här blir endast den vänstra rektangeln grön.

På en befintlig form kan en lokal fyllningsfärg, linjefärg eller linjebredd åsidosätta den delen av temastilen. Om en ändring av stilindexet inte ger någon synlig effekt, kontrollera formens [direct formatting](/slides/sv/androidjava/shape-formatting/).

## **Bestäm om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, en layout, en master, en temastil eller en annan formateringsnivå. Anropa [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) för att lösa den hierarkin till en oföränderlig [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Kontrollera först [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Endast när den är `FillType.Solid` bör du läsa egenskaperna för solid fyllning.

För en solid fyllning returnerar [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) det slutgiltiga renderade RGB‑värdet efter att arv, temauppslagning och färgtransformeringar har tillämpats. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)‑plats, såsom `Text1` eller `Accent6`. Ett värde på `SchemeColor.NotDefined` betyder att den effektiva solida fyllningen inte baseras på en schemafärg. I ett arbetsflöde där fyllningar är antingen temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte det lokala [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/)‑värdet ensamt för att klassificera en fyllning. Till exempel kan en textdel sakna en lokalt definierad schemafärg, så dess lokala värde är `NotDefined`, medan dess effektiva fyllning ärver en temafärg och löser upp till `Text1` eller `Accent6`. Omvänt visar `getSolidFillSchemeColor` vilken logisk temaplatsslot som producerade den effektiva färgen, men den säger inte om den slotten kommer från objektet, stycket, layouten, mastern eller en annan nivå i formateringshierarkin.

Följande exempel laddar en presentation, granskar både formfyllningar och textdel‑fyllningar, skriver ut varje slutgiltigt RGB‑värde och associerad schemafärg, och markerar solida fyllningar som inte kommer att följa temafärgsändringar:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined`‑grenen ger en granskningslista över solida fyllningar som inte kommer att reagera på förändringar i temafärgs‑platser. Granska dessa objekt när en presentation måste följa en ny varumärkespalett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schemavärdet förklarar om det utseendet är kopplat till temat.

Effektiva formateringsobjekt är ögonblicksbilder. Efter att ha ändrat presentationens tema, en temåsåsidosättning eller någon ärvd formatering, anropa `getEffective` igen och läs ett nytt `IFillFormatEffectiveData`‑objekt innan du jämför eller rapporterar färger.

## **Läs effektiva temavärden**

Råa temobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **Vanliga frågor**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) omfördelar endast de bilder som beror på den valda master‑bilden. Bilder som använder andra master‑bilder behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master‑bilden?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) och initiera dess åsåsidosättning. Ändringen förblir lokal till den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att överföra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona käll‑master‑bilden till destinationen och klona bilden med den master‑bilden med hjälp av [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) och [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Detta behåller master‑bilden, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) för ett bild‑ eller layout‑tema och de motsvarande effektiva‑datametoderna för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.