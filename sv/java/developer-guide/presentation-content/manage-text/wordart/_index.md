---
title: Skapa och tillämpa WordArt‑effekter i Java
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
- visningseffekt
- glöd‑effekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för Java. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i Java."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Den här artikeln ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformationer, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt gör att du kan behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt‑mall och tillämpa den på en text**

**Using Aspose.Slides** 

Först skapar vi en enkel text med denna Java‑kod: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Nu sätter vi textens teckenhöjd till ett större värde för att göra effekten mer märkbar med denna kod:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Using Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Detta är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Här applicerar vi [SmallGrid](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PatternStyle#SmallGrid)‑mönsterfärgen på texten och lägger till en 1‑breddig svart textram med denna kod:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## **Tillämpa andra WordArt‑effekter**

**Using Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på en text, en textblock, en form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan Shadow-, Reflection- och Glow‑effekter appliceras på en text; 3D‑Format‑ och 3D‑Rotations‑effekter kan appliceras på ett textblock; egenskapen Soft Edges kan appliceras på ett Shape‑objekt (den har fortfarande en effekt när ingen 3D‑Format‑egenskap är inställd). 

### **Tillämpa skuggeffekter**

Här avser vi att bara ställa in egenskaper som gäller en text. Vi applicerar skuggeffekten på en text med denna Java‑kod:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides‑API stöder tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 

Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Using Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides tillåter faktiskt att två typer av skuggor appliceras samtidigt: InnerShadow och PresetShadow.

**Obs:**

- När OuterShadow och PresetShadow används tillsammans, appliceras endast OuterShadow‑effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller tillämpade effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow‑effekten. 

### **Tillämpa Display på texter**

Vi lägger till display på texten med detta kodexempel i Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **Tillämpa Glow‑effekt på texter**

Vi applicerar glow‑effekten på texten för att få den att glöda eller sticka ut med denna kod:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Du kan ändra parametrarna för skugga, display och glow. Effektens egenskaper sätts för varje del av texten separat. 
{{% /alert %}} 

### **Använda transformationer i WordArt**

Vi använder Transform‑egenskapen (inbyggd i hela textblocket) med denna kod:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Både Microsoft PowerPoint och Aspose.Slides för Java erbjuder ett antal fördefinierade transformationstyper. 
{{% /alert %}} 

**Using PowerPoint**

För att komma åt fördefinierade transformationstyper, gå via: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

För att välja en transformationstyp, använd enum‑en TextShapeType. 

### **Tillämpa 3D‑effekter på texter och former**

Vi ställer in en 3D‑effekt på en textform med detta kodexempel:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med denna Java‑kod:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
Tillämpningen av 3D‑effekter på texter eller deras former samt interaktioner mellan effekter baseras på vissa regler. 

Tänk på en scen för en text och formen som innehåller den texten. 3D‑effekten innehåller en 3D‑objektrepresentation och scenen där objektet placerats. 

- När scenen är inställd för både figuren och texten får figurscenen högre prioritet — texts cenen ignoreras. 
- När figuren saknar egen scen men har 3D‑representation används textscenen. 
- Annars — när formen ursprungligen saknar 3D‑effekt — är formen platt och 3D‑effekten appliceras endast på texten. 

Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Tillämpa yttre skuggeffekter på texter**
Aspose.Slides för Java tillhandahåller klasserna [**IOuterShadow**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioutershadow/) och [**IInnerShadow**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinnershadow/) som låter dig applicera skuggeffekter på en text i [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation). 
2. Hämta referensen till en bild genom att använda dess index. 
3. Lägg till en AutoShape av typen Rectangle på bilden. 
4. Få åtkomst till TextFrame som är associerad med AutoShape. 
5. Ställ in FillType för AutoShape till NoFill. 
6. Instansiera klassen OuterShadow 
7. Ställ in BlurRadius för skuggan. 
8. Ställ in Direction för skuggan 
9. Ställ in Distance för skuggan. 
10. Ställ in RectanglelAlign till TopLeft. 
11. Ställ in PresetColor för skuggan till Black. 
12. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil. 

Detta exempel på Java‑kod — en implementation av stegen ovan — visar hur du applicerar den yttre skuggeffekten på en text:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");

    // Inaktivera formens fyllning ifall vi vill ha textens skugga
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Lägg till yttre skugga och ange alla nödvändiga parametrar
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Skriv presentationen till disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tillämpa inre skuggeffekt på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation). 
2. Hämta en referens till bilden. 
3. Lägg till en AutoShape av typen Rectangle. 
4. Aktivera InnerShadowEffect. 
5. Ställ in alla nödvändiga parametrar. 
6. Ställ in ColorType till Scheme. 
7. Ställ in Scheme‑färgen. 
8. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil. 

Detta exempel på kod (baserat på stegen ovan) visar hur du applicerar inre skuggeffekten på texten i en form i Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Aktivera InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Ange alla nödvändiga parametrar
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Ställ in ColorType som Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ställ in Scheme-färg
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Spara presentationen
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

### Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. arabiska, kinesiska)?

Ja, Aspose.Slides stödjer Unicode och fungerar med alla vanliga teckensnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om tillgänglighet av teckensnitt och rendering kan bero på systemets teckensnitt.

### Kan jag applicera WordArt‑effekter på master‑bildens element?

Ja, du kan applicera WordArt‑effekter på former på master‑bilder, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar som görs i master‑layouten kommer att återspeglas i alla associerade bilder.

### Påverkar WordArt‑effekter presentationens filstorlek?

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

### Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av `getImage`‑metoden från [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) eller [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/)‑gränssnitten. Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.