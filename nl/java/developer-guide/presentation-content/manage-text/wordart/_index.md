---
title: WordArt-effecten maken en toepassen in Java
linktitle: WordArt
type: docs
weight: 110
url: /nl/java/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- weergave-effect
- gloed-effect
- WordArt-transformatie
- 3D-effect
- buitenste schaduw-effect
- binnenste schaduw-effect
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor Java. Deze stapsgewijze gids helpt ontwikkelaars presentaties te verbeteren met professionele tekst in Java."
---
## **Overzicht**

WordArt-effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatic WordArt maken, aanpassen en beheren net zoals in Microsoft PowerPoint – zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe u teksttransformaties, vulstijlen, contouren, schaduwen en andere opmaakopties kunt toepassen om uw presentatiewaarde expressiever en boeiender te maken. WordArt laat u tekst behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Een eenvoudige WordArt‑sjabloon maken en toepassen op een tekst**

**Met Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze Java‑code: 

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
Vervolgens stellen we de lettergrootte van de tekst in op een grotere waarde om het effect beter zichtbaar te maken via deze code:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Met Microsoft PowerPoint**

Ga naar het WordArt‑effectenmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

In het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. In het menu aan de linkerkant kunt u de instellingen voor een nieuw WordArt specificeren. 

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Met Aspose.Slides**

Hier passen we het [SmallGrid](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PatternStyle#SmallGrid) patroonkleur toe op de tekst en voegen we een zwarte tekstrand van 1 punt toe met deze code:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Andere WordArt‑effecten toepassen**

**Met Microsoft PowerPoint**

Via de gebruikersinterface van het programma kunt u deze effecten toepassen op een tekst, tekstvak, vorm of soortgelijk element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, schaduw-, reflectie‑ en gloed‑effecten kunnen op een tekst worden toegepast; 3D‑opmaak‑ en 3D‑rotatie‑effecten op een tekstvak; de eigenschap Soft Edges kan op een Shape‑object worden toegepast (het behoudt een effect zelfs als er geen 3D‑opmaak is ingesteld). 

### **Schaduweffecten toepassen**

Hier willen we alleen eigenschappen voor tekst instellen. We passen het schaduweffect toe op een tekst met deze Java‑code:

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

Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow. 

Met PresetShadow kunt u een schaduw op een tekst toepassen (met vooraf ingestelde waarden). 

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hier is een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides staat u zelfs toe om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast. 
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. In PowerPoint 2007 wordt alleen OuterShadow toegepast. 

### **Weergave toepassen op teksten**

We voegen weergave toe aan de tekst via dit Java‑voorbeeld:

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

### **Gloeieffect toepassen op teksten**

We passen het gloeieffect toe op de tekst zodat deze schittert of opvalt met deze code:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

U kunt de parameters voor schaduw, weergave en gloed aanpassen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk deel van de tekst. 

{{% /alert %}} 

### **Transformaties gebruiken in WordArt**

We gebruiken de Transform‑eigenschap (van toepassing op het gehele tekstblok) via deze code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor Java bieden een bepaald aantal vooraf gedefinieerde transformatietypen. 

{{% /alert %}} 

**Met PowerPoint**

Om toegang te krijgen tot vooraf gedefinieerde transformatietypen, gaat u naar: **Formaat** → **Teksteffect** → **Transformatie**

**Met Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de enum TextShapeType. 

### **3D‑effecten toepassen op teksten en vormen**

We stellen een 3D‑effect in voor een tekstvorm met deze voorbeeldcode:

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

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze Java‑code:

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

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

De toepassing van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten volgen bepaalde regels. 

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect omvat de 3D‑objectrepresentatie en de scène waarop het object is geplaatst. 

- Wanneer de scène zowel voor de vorm als voor de tekst is ingesteld, krijgt de scène van de vorm hogere prioriteit – de scènes van de tekst wordt genegeerd. 
- Wanneer de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scènes van de tekst gebruikt. 
- Anders – wanneer de vorm oorspronkelijk geen 3D‑effect heeft – is de vorm plat en wordt het 3D‑effect alleen op de tekst toegepast. 

Deze beschrijvingen zijn gerelateerd aan de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera().

{{% /alert %}} 

## **Outer‑Shadow‑effecten toepassen op teksten**
Aspose.Slides voor Java biedt de [**IOuterShadow**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioutershadow/) en [**IInnerShadow**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinnershadow/) klassen die u in staat stellen schaduweffecten toe te passen op een tekst in een [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/). Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Haal de referentie van een slide op door gebruik te maken van zijn index.  
3. Voeg een AutoShape van het type Rectangle toe aan de slide.  
4. Verkrijg het TextFrame dat bij de AutoShape hoort.  
5. Stel de FillType van de AutoShape in op NoFill.  
6. Instantieer de OuterShadow‑klasse.  
7. Stel de BlurRadius van de schaduw in.  
8. Stel de Direction van de schaduw in.  
9. Stel de Distance van de schaduw in.  
10. Stel de RectanglelAlign in op TopLeft.  
11. Stel de PresetColor van de schaduw in op Black.  
12. Sla de presentatie op als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode in Java—een implementatie van de bovenstaande stappen—toont hoe u het outer‑shadow‑effect op een tekst toepast:

```java
Presentation pres = new Presentation();
try {
    // Verkrijg referentie van de dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rectangle toe
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voeg TextFrame toe aan de Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Schakel vormvulling uit voor het geval we de schaduw van de tekst willen krijgen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Voeg buitenste schaduw toe en stel alle benodigde parameters in
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Write de presentatie naar schijf
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Inner‑Shadow‑effect toepassen op vormen**
Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Haal de referentie van de slide op.  
3. Voeg een AutoShape van het type Rectangle toe.  
4. Schakel InnerShadowEffect in.  
5. Stel alle benodigde parameters in.  
6. Stel de ColorType in op Scheme.  
7. Stel de Scheme‑kleur in.  
8. Sla de presentatie op als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe u een connector tussen twee vormen toevoegt in Java:

```java
Presentation pres = new Presentation();
try {
    // Verkrijg referentie van de dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rectangle toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Voeg TextFrame toe aan de Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Schakel InnerShadowEffect in
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Stel alle benodigde parameters in
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Stel ColorType in op Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Stel Scheme-kleur in
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Sla presentatie op
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en omtrek kunnen worden toegepast, ongeacht de taal, hoewel de beschikbaarheid van lettertypen en de weergave afhankelijk kunnen zijn van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen op een master‑slide, inclusief titel‑placeholders, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay‑out worden doorgevoerd op alle gekoppelde dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, glows en gradient‑vullingen kunnen de bestandsgrootte marginalement verhogen door toegevoegde opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met de `getImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) interfaces. Zo kunt u het resultaat in‑memory of op het scherm bekijken vóór het opslaan of exporteren van de volledige presentatie.