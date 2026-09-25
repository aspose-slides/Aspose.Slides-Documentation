---
title: Skapa och applicera WordArt‑effekter i Java
linktitle: WordArt
type: docs
weight: 110
url: /sv/java/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för Java. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i Java."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Den här artikeln förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för Java, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt-mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på den första bilden; ingen indatalfil behövs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och dimensioner mäts i punkter:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ställ in teckensnittet till Arial Black i 36 punkter för att göra formateringen mer märkbar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Applicera ett [SmallGrid](https://reference.aspose.com/slides/sv/java/com.aspose.slides/patternstyle/#SmallGrid)-mönster med en mörkorange förgrund och en vit bakgrund, och lägg sedan till en svart textkontur med en bredd på 1 punkt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![Den enkla WordArt-mallen](WordArt_template.png)

## **Tillämpa andra WordArt-effekter**

Följande exempel visar hur du applicerar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Applicera yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpegrad, skala och skevhet.

Detta exempel anropar [enableOuterShadowEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) och ställer in en svart skugga med en oskärpa på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skala‑värden på 100 bevarar skuggans storlek, medan horisontell skevhet lutar den 20 grader. Alfa‑transformen sätter dess opacitet till 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![Den yttre skuggeffekten](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans, appliceras endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på vilken PowerPoint-version som används. Till exempel, i PowerPoint 2013 fördubblas effekten, medan i PowerPoint 2007 appliceras endast den yttre skuggan.
{{% /alert %}}

### **Applicera reflektionseffekter**

En reflektion skapar en spegelbild av texten. Justera dess position, skala, oskärpa och opacitet för att kontrollera dess utseende.

Detta exempel anropar [enableReflectionEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effectformat/#enableReflectionEffect--) och vänder reflektionen vertikalt med en skala på -100%. Det använder en oskärpa på 0.5 punkt och ett avstånd på 4.72 punkt. Opaciteten minskar från 60% till 0.9% mellan positionerna 0% och 60% längs reflektionen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![Reflektionseffekten](reflection_effect.png)

### **Applicera glöd‑effekter**

En glöd lägger till en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [enableGlowEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effectformat/#enableGlowEffect--) och tillämpar en röd glöd med 54% opacitet och en radie på 7 punkter:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![Glöd‑effekten](glow_effect.png)

### **Applicera WordArt-transformationer**

WordArt‑transformationer böjer, sträcker eller förvränger ett textblock.

Ställ in [setTransform](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setTransform-int-) till [ArchUpPour](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textshapetype/#ArchUpPour) för att böja hela textramen uppåt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![WordArt‑transformationen](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java tillhandahåller ett antal fördefinierade [transformationstyper](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Applicera 3D‑effekter på former och text**

Du kan applicera 3D‑effekter på en form eller på dess text. Avfasningar, extrudering, belysning och kamerainställningar styr det resulterande utseendet.

Följande exempel använder [ThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/) för att lägga till cirkulära avfasningar, orange extrudering och en mörkröd kontur på rektangeln. Avfasningsdimensioner, extruderingshöjd, konturbredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader runt Z‑axeln och en perspektivkamera definierar dess utseende:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Den resulterande formen:

![Formens 3D‑effekt](shape_3D_effect.png)

Detta exempel tillämpar liknande 3D‑formatering på texten via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Mindre avfasningar formar bokstavskanten, medan extrudering och belysning ger texten djup:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![Textens 3D‑effekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Tillämpningen av 3D‑effekter på text eller dess former — och interaktionen mellan dessa effekter — styrs av specifika regler. Tänk på en scen som involverar både text och formen som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och scenen där det placeras.

- Om en scen är inställd för både formen och texten, får formens scen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation, används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten appliceras endast på texten.

Detta beteende är relaterat till metoderna [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/#getLightRig--) och [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som du behåller formens 3D‑formatering, se [Keep Text Flat on a 3D Shape](/slides/sv/java/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett Java‑exempel.

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. Arabiska, Kinesiska)?**

Ja, Aspose.Slides for Java stöder Unicode och fungerar med alla vanliga teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittstillgänglighet och renderingen kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på master‑slide‑element?**

Ja, du kan applicera WordArt‑effekter på former på master‑bilder, inklusive titel‑platshållare, sidfot eller bakgrundstext. Ändringar som görs i master‑layouten kommer att återspeglas på alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är oftast försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage--), eller rendera enskilda former med [IShape.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getImage--). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.