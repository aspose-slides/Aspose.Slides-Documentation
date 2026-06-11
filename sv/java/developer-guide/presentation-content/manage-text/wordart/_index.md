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
- display‑effekt
- glöd‑effekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för Java. Den här steg‑för‑steg‑guiden hjälper utvecklare att förbättra presentationer med professionell text i Java."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att Office behöver vara installerat. Denna artikel ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar textomvandlingar, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på texten för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

**Using Aspose.Slides** 

Först skapar vi en enkel text med följande Java‑kod: 

``` java
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
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Detta är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Här applicerar vi mönsterfärgen [SmallGrid](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PatternStyle#SmallGrid) på texten och lägger till en 1‑breddig svart textkontur med följande kod:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## **Tillämpa andra WordArt‑effekter**

**Using Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på en text, en textruta, en form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan skugga-, reflektion- och glöd‑effekter appliceras på text; 3D‑format‑ och 3D‑rotations‑effekter kan appliceras på en textruta; egenskapen Mjuka kanter kan appliceras på ett Form‑objekt (den har fortfarande effekt när ingen 3D‑format‑egenskap är angiven). 

### **Tillämpa skuggeffekter**

Här avser vi att sätta egenskaper som endast gäller för text. Vi applicerar skuggeffekten på en text med följande Java‑kod:

``` java
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
```

Aspose.Slides‑API stöder tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 

Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Using Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides låter dig faktiskt applicera två typer av skuggor samtidigt: InnerShadow och PresetShadow.

**Obs:**

- När OuterShadow och PresetShadow används tillsammans appliceras endast OuterShadow‑effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller applicerade effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow‑effekten. 

### **Tillämpa display på texter**

Vi lägger till display på texten med detta kodexempel i Java:

``` java
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
```

### **Tillämpa glöd‑effekt på texter**

Vi applicerar glöd‑effekten på texten för att få den att lysa eller sticka ut med följande kod:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Du kan ändra parametrarna för skugga, display och glöd. Effektens egenskaper sätts separat för varje del av texten. 

{{% /alert %}} 

### **Använda transformationer i WordArt**

Vi använder Transform‑egenskapen (gäller hela textblocket) med följande kod:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Både Microsoft PowerPoint och Aspose.Slides för Java erbjuder ett visst antal fördefinierade transformationstyper. 

{{% /alert %}} 

**Using PowerPoint**

För att komma åt fördefinierade transformationstyper, gå till: **Format** → **TextEffect** → **Transform**

**Using Aspose.Slides**

För att välja en transformationstyp, använd enum‑värdet TextShapeType. 

### **Tillämpa 3D‑effekter på texter och former**

Vi sätter en 3D‑effekt på en textform med detta exempel:

``` java
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
```

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med följande Java‑kod:

``` java
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
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Applicering av 3D‑effekter på texter eller deras former samt interaktioner mellan effekter följer vissa regler. 

Tänk dig en scen för en text och den form som innehåller texten. 3D‑effekten består av en 3D‑objektrepresentation och den scen där objektet placerats. 

- När scenen är angiven både för figuren och för texten får figurscenen högre prioritet – texts‑scenen ignoreras. 
- När figuren saknar egen scen men har 3D‑representation används texts‑scenen. 
- Annars – när formen ursprungligen inte har någon 3D‑effekt – är formen platt och 3D‑effekten appliceras endast på texten. 

Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera().

{{% /alert %}} 

## **Applicera Outer Shadow‑effekter på texter**
Aspose.Slides för Java tillhandahåller klasserna [**IOuterShadow**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioutershadow/) och [**IInnerShadow**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iinnershadow/) som låter dig applicera skuggeffekter på text som finns i en [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).  
2. Hämta referensen till en bild genom att använda dess index.  
3. Lägg till en AutoShape av typen Rectangle på bilden.  
4. Åtkom TextFrame som är kopplad till AutoShape.  
5. Ställ in FillType för AutoShape till NoFill.  
6. Instansiera OuterShadow‑klassen.  
7. Ange BlurRadius för skuggan.  
8. Ange Direction för skuggan.  
9. Ange Distance för skuggan.  
10. Ställ in RectanglelAlign till TopLeft.  
11. Ange PresetColor för skuggan till Black.  
12. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta Java‑exempel – en implementering av stegen ovan – visar hur du applicerar Outer Shadow‑effekten på en text:

```java
Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen rektangel
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");

    // Inaktivera formens fyllning om vi vill få skugga på texten
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Lägg till yttre skugga och ange alla nödvändiga parametrar
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Write presentationen till disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicera Inner Shadow‑effekt på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).  
2. Hämta referensen till bilden.  
3. Lägg till en AutoShape av typen Rectangle.  
4. Aktivera InnerShadowEffect.  
5. Ställ in alla nödvändiga parametrar.  
6. Ställ in ColorType till Scheme.  
7. Ange Scheme‑färgen.  
8. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel (baserat på stegen ovan) visar hur du lägger till en connector mellan två former i Java:

```java
Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen rektangel
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

    // Ställ in ColorType till Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ställ in Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Spara presentationen
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides stödjer Unicode och fungerar med alla vanliga teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittstillgänglighet och rendering kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på master‑bilder?**

Ja, du kan applicera WordArt‑effekter på former i master‑bilder, inklusive titel‑platshållare, sidfot eller bakgrundstext. Ändringar i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter filstorleken på presentationen?**

Lite. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligen försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bildformat (t.ex. PNG, JPEG) med metoden `getImage` från gränssnitten [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) eller [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.