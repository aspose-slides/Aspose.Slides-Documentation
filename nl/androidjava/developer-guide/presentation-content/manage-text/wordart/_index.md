---
title: WordArt-effecten maken en toepassen op Android
linktitle: WordArt
type: docs
weight: 110
url: /nl/androidjava/wordart/
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
- interne schaduw-effect
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor Android. Deze stapsgewijze gids helpt ontwikkelaars om presentaties te verbeteren met professionele tekst in Java."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatic WordArt maken, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe u teksttransformaties, vulstijlen, contouren, schaduwen en andere opmaakopties toepast om uw presentatie‑inhoud expressiever en boeiender te maken. WordArt laat u tekst behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Een eenvoudige WordArt‑template maken en toepassen op tekst**

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
Nu stellen we de letterhoogte van de tekst in op een hogere waarde om het effect beter zichtbaar te maken met deze code:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Met Microsoft PowerPoint**

Ga naar het WordArt‑effectmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

In het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. In het menu aan de linkerkant kunt u de instellingen voor een nieuw WordArt opgeven.

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Met Aspose.Slides**

Hier passen we het [SmallGrid](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PatternStyle#SmallGrid)‑patroonkleur toe op de tekst en voegen we een zwarte tekstrand van 1‑punt toe met deze code:

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

Via de gebruikersinterface van het programma kunt u deze effecten toepassen op een tekst, tekstblok, vorm of een vergelijkbaar element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, Schaduw-, Reflectie‑ en Gloed‑effecten kunnen op een tekst worden toegepast; 3D‑Opmaak‑ en 3D‑Rotatie‑effecten kunnen op een tekstblok worden toegepast; de eigenschap Zachte randen kan op een Vorm‑object worden toegepast (het blijft effect hebben wanneer geen 3D‑Opmaak‑eigenschap is ingesteld).

### **Schaduw‑effecten toepassen**

Hier willen we alleen eigenschappen voor een tekst instellen. We passen het schaduw‑effect toe op een tekst met deze Java‑code:

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

Met PresetShadow kunt u een schaduw voor een tekst toepassen (met vooraf ingestelde waarden).

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hier is een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides staat u eigenlijk toe om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast.  
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende of toegepaste effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. Maar in PowerPoint 2007 wordt het OuterShadow‑effect toegepast.

### **Reflectie‑effecten op tekst toepassen**

We voegen een reflectie toe aan de tekst met dit Java‑voorbeeld:

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

### **Gloed‑effecten op tekst toepassen**

We passen het gloed‑effect toe op de tekst zodat deze straalt of opvalt met deze code:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

U kunt de parameters voor schaduw, reflectie en gloed aanpassen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk deel van de tekst. 

{{% /alert %}} 

### **Transformaties gebruiken in WordArt**

We gebruiken de Transform‑eigenschap (van toepassing op het gehele tekstblok) met deze code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor Android via Java bieden een bepaald aantal vooraf gedefinieerde transformatietypen.

{{% /alert %}} 

**Met PowerPoint**

Om de vooraf gedefinieerde transformatietypen te benaderen, gaat u via: **Opmaak** → **Teksteffect** → **Transformeren**

**Met Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de enum TextShapeType. 

### **3D‑effecten toepassen op tekst en vormen**

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

Het toepassen van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten zijn gebaseerd op bepaalde regels.

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect omvat een 3D‑objectrepresentatie en de scène waarop het object is geplaatst.

- Wanneer de scène is ingesteld voor zowel de vorm als de tekst, krijgt de vorm‑scène de hogere prioriteit — de tekst‑scène wordt genegeerd.  
- Wanneer de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt.  
- Anders — wanneer de vorm oorspronkelijk geen 3D‑effect heeft — is de vorm vlak en wordt het 3D‑effect alleen op de tekst toegepast.

Deze beschrijvingen zijn verbonden met de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera().

{{% /alert %}} 

## **Outer‑Shadow‑effecten toepassen op tekst**
Aspose.Slides voor Android via Java biedt de [**IOuterShadow**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioutershadow/) en [**IInnerShadow**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinnershadow/) klassen waarmee u schaduweffecten kunt toepassen op een tekst die zich bevindt in een [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/). Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
2. Verkrijg de referentie van een dia via de index.  
3. Voeg een AutoShape van het type Rectangle toe aan de dia.  
4. Benader het TextFrame dat aan de AutoShape is gekoppeld.  
5. Stel de FillType van de AutoShape in op NoFill.  
6. Instantieer de OuterShadow‑klasse.  
7. Stel de BlurRadius van de schaduw in.  
8. Stel de Direction van de schaduw in.  
9. Stel de Distance van de schaduw in.  
10. Stel de RectanglelAlign in op TopLeft.  
11. Stel de PresetColor van de schaduw in op Black.  
12. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode in Java — een implementatie van de bovenstaande stappen — toont hoe u het outer‑shadow‑effect op een tekst toepast:

```java
Presentation pres = new Presentation();
try {
    // Verkrijg referentie van de dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rechthoek toe
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voeg een TextFrame toe aan de rechthoek
    ashp.addTextFrame("Aspose TextBox");

    // Schakel vormvulling uit voor het geval we een schaduw van de tekst willen krijgen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een buitenste schaduw toe en stel alle nodige parameters in
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Schrijf de presentatie naar schijf
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Inner‑Shadow‑effecten toepassen op vormen**
Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
2. Verkrijg een referentie van de dia.  
3. Voeg een AutoShape van het type Rectangle toe.  
4. Schakel InnerShadowEffect in.  
5. Stel alle benodigde parameters in.  
6. Stel de ColorType in op Scheme.  
7. Stel de Scheme‑kleur in.  
8. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe u een connector tussen twee vormen toevoegt in Java:

```java
Presentation pres = new Presentation();
try {
    // Verkrijg referentie van de dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rechthoek toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een TextFrame toe aan de rechthoek
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Schakel InnerShadowEffect in
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Stel alle noodzakelijke parameters in
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Stel ColorType in als Scheme
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

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en contour kunnen worden toegepast, ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave kan afhangen van de systeembrede fonts.

**Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen op master‑dia's, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay-out worden doorgevoerd in alle gekoppelde dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

In beperkte mate. WordArt‑effecten zoals schaduwen, gloed en kleurverlopen kunnen de bestandsgrootte iets verhogen door extra opmaak‑metadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia ‘s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met de `getImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) interfaces. Hiermee kunt u het resultaat in‑memory of op‑scherm bekijken voordat u de volledige presentatie opslaat of exporteert.