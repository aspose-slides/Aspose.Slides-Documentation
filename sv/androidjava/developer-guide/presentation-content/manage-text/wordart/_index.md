---
title: Skapa och tillämpa WordArt-effekter på Android
linktitle: WordArt
type: docs
weight: 110
url: /sv/androidjava/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt-mall
- WordArt-effekt
- skuggeffekt
- visningseffekt
- glöd-effekt
- WordArt-transformation
- 3D-effekt
- ytterskuggeffekt
- innerskuggeffekt
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt-effekter i Aspose.Slides för Android. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med professionell text i Java."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva Office installerat. Den här artikeln ger en översikt över hur man arbetar med WordArt, inklusive hur man tillämpar texttransformationer, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt-mall och tillämpa den på text**

**Med Aspose.Slides** 

Först skapar vi en enkel text med den här Java‑koden: 

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
Nu sätter vi textens teckenhöjd till ett större värde för att göra effekten mer märkbar med följande kod:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Med Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Detta är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Med Aspose.Slides**

Här applicerar vi färgmönstret [SmallGrid](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PatternStyle#SmallGrid) på texten och lägger till en 1‑pixels svart textkant med följande kod:

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

**Med Microsoft PowerPoint**

Från programmets gränssnitt kan du tillämpa dessa effekter på en text, textblock, form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan skugga‑, reflektion‑ och glöd‑effekter appliceras på en text; 3D‑format‑ och 3D‑rotations‑effekter kan appliceras på ett textblock; egenskapen Soft Edges kan appliceras på ett Shape‑objekt (den har fortfarande effekt när ingen 3D‑Format‑egenskap är inställd). 

### **Tillämpa skuggeffekter**

Här avser vi att endast sätta egenskaper som rör en text. Vi applicerar skuggeffekten på en text med följande Java‑kod:

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

Aspose.Slides‑API stödjer tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 

Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Med Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Med Aspose.Slides**

Aspose.Slides låter faktiskt dig applicera två typer av skuggor samtidigt: InnerShadow och PresetShadow.

**Anteckningar:**

- När OuterShadow och PresetShadow används tillsammans, appliceras bara OuterShadow‑effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller tillämpade effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow‑effekten. 

### **Tillämpa reflektions‑effekter på text**

Vi lägger till reflektion på texten med detta kodexempel i Java:

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

### **Tillämpa glöd‑effekter på text**

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

Du kan ändra parametrarna för skugga, reflektion och glöd. Effekternas egenskaper sätts på varje del av texten separat. 

{{% /alert %}} 

### **Använd transformationer i WordArt**

Vi använder Transform‑egenskapen (inbyggd i hela textblocket) med följande kod:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Både Microsoft PowerPoint och Aspose.Slides för Android via Java erbjuder ett antal fördefinierade transformationstyper.

{{% /alert %}} 

**Med PowerPoint**

För att komma åt fördefinierade transformationstyper, gå via: **Format** -> **TextEffect** -> **Transform**

**Med Aspose.Slides**

För att välja en transformationstyp, använd enum‑värdet TextShapeType. 

### **Tillämpa 3D‑effekter på text och former**

Vi sätter en 3D‑effekt på en textform med detta exempel på kod:

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

Vi applicerar en 3D‑effekt på texten med denna Java‑kod:

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

Appliceringen av 3D‑effekter på texter eller deras former samt interaktioner mellan effekter bygger på vissa regler.

Tänk på en scen för en text och den form som innehåller texten. 3D‑effekten innehåller en 3D‑objektrepresentation och den scen där objektet placerades.

- När scenen är inställd för både figur och text får figur‑scenen högre prioritet – text‑scenen ignoreras. 
- När figuren saknar egen scen men har 3D‑representation används text‑scenen. 
- Annars – när formen ursprungligen inte har någon 3D‑effekt – är formen platt och 3D‑effekten appliceras bara på texten. 

Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Tillämpa yttre skuggeffekter på text**
Aspose.Slides för Android via Java tillhandahåller klasserna [**IOuterShadow**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioutershadow/) och [**IInnerShadow**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinnershadow/) som låter dig applicera skuggeffekter på text som finns i en [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).  
2. Hämta referensen till en bild genom att använda dess index.  
3. Lägg till en AutoShape av typen Rectangle på bilden.  
4. Åtkomst till TextFrame som är kopplad till AutoShape.  
5. Ställ in FillType för AutoShape till NoFill.  
6. Instansiera klassen OuterShadow  
7. Ställ in BlurRadius för skuggan.  
8. Ställ in Direction för skuggan  
9. Ställ in Distance för skuggan.  
10. Ställ in RectanglelAlign till TopLeft.  
11. Ställ in PresetColor för skuggan till Black.  
12. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.  

Det här exempelprogrammet i Java—en implementering av stegen ovan—visar hur du applicerar yttre skuggeffekten på en text:

```java
Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");

    // Inaktivera formens fyllning ifall vi vill få skugga av texten
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Lägg till yttre skugga och sätt alla nödvändiga parametrar
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Skriv presentationen till disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tillämpa inre skuggeffekter på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).  
2. Hämta en referens till bilden.  
3. Lägg till en AutoShape av typen Rectangle.  
4. Aktivera InnerShadowEffect.  
5. Ställ in alla nödvändiga parametrar.  
6. Ställ in ColorType till Scheme.  
7. Ställ in Scheme‑färgen.  
8. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.  

Det här exempelprogrammet (baserat på stegen ovan) visar hur du lägger till en anslutning mellan två former i Java:

```java
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

    // Sätt alla nödvändiga parametrar
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Sätt ColorType till Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Sätt Scheme-färg
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Spara presentationen
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. Arabiska, Kinesiska)?**

Ja, Aspose.Slides stödjer Unicode och fungerar med alla vanliga teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om tillgänglighet och rendering av teckensnitt kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på element i bildbakgrunden (slide master)?**

Ja, du kan applicera WordArt‑effekter på former på master‑bilder, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar som görs i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter filstorleken på presentationen?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bildfiler (t.ex. PNG, JPEG) med hjälp av metoden `getImage` från gränssnitten [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) eller [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärm innan du sparar eller exporterar hela presentationen.