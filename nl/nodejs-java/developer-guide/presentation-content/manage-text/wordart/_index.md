---
title: WordArt-effecten maken en toepassen in JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /nl/nodejs-java/wordart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor Node.js. Deze stapsgewijze handleiding helpt ontwikkelaars om presentaties te verbeteren met professionele tekst."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmeermatig WordArt maken, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief het toepassen van teksttransformaties, opvullingsstijlen, contouren, schaduwen en andere opmaakopties om de inhoud van uw presentatie expressiever en boeiender te maken. WordArt maakt het mogelijk om tekst te behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Een eenvoudige WordArt‑sjabloon maken en toepassen op tekst**

**Met Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze JavaScript‑code:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Vervolgens stellen we de lettergrootte van de tekst in op een hogere waarde om het effect beter zichtbaar te maken met deze code:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
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

Hier passen we het [SmallGrid](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PatternStyle#SmallGrid)‑patroonkleur toe op de tekst en voegen we een zwarte tekstrand van 1‑pixel breed toe met deze code:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Andere WordArt‑effecten toepassen**

**Met Microsoft PowerPoint**

Vanuit het programma‑menu kunt u deze effecten toepassen op een tekst, tekstblok, vorm of een vergelijkbaar element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, schaduw‑, reflectie‑ en gloed‑effecten kunnen op tekst worden toegepast; 3D‑opmaak‑ en 3D‑rotatie‑effecten kunnen op een tekstblok worden toegepast; de eigenschap Soft Edges kan op een Shape‑object worden toegepast (deze heeft nog steeds effect wanneer er geen 3D‑opmaak is ingesteld).  

### **Schaduw‑effecten toepassen**

Hier beperken we ons tot eigenschappen die alleen op tekst van toepassing zijn. We passen het schaduweffect toe op een tekst met deze JavaScript‑code:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow.  

Met PresetShadow kunt u een schaduw op tekst toepassen (met vooraf ingestelde waarden).  

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hieronder een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides maakt het zelfs mogelijk om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast.  
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. In PowerPoint 2013 wordt het effect bijvoorbeeld verdubbeld, terwijl in PowerPoint 2007 alleen OuterShadow wordt toegepast.  

### **Weergave op teksten toepassen**

We voegen weergave toe aan de tekst met dit JavaScript‑voorbeeld:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Gloed‑effect op teksten toepassen**

We passen het gloed‑effect toe op de tekst zodat deze opvallend straalt met deze code:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

U kunt de parameters voor schaduw, weergave en gloed aanpassen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk deel van de tekst. 

{{% /alert %}} 

### **Transformaties gebruiken in WordArt**

We gebruiken de eigenschap Transform (van toepassing op het volledige tekstblok) met deze code:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor Node.js via Java bieden een aantal vooraf gedefinieerde transformatie­typen. 

{{% /alert %}} 

**Met PowerPoint**

Om toegang te krijgen tot vooraf gedefinieerde transformatie­typen, gaat u via: **Format** → **TextEffect** → **Transform**

**Met Aspose.Slides**

Om een transformatie­type te selecteren, gebruikt u de enum TextShapeType.  

### **3D‑effecten op teksten en vormen toepassen**

We stellen een 3D‑effect in voor een tekstvorm met dit voorbeeld:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze JavaScript‑code:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

De toepassing van 3D‑effecten op teksten of hun vormen en de interactie tussen effecten volgen bepaalde regels.  

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect omvat een 3D‑objectrepresentatie en de scène waarop het object is geplaatst.  

- Wanneer de scène zowel voor de vorm als voor de tekst is ingesteld, heeft de scenenaam van de vorm de hoogste prioriteit – de scenenaam van de tekst wordt genegeerd.  
- Wanneer de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekstscène gebruikt.  
- Anders – wanneer de vorm oorspronkelijk geen 3D‑effect heeft – is de vorm plat en wordt het 3D‑effect alleen op de tekst toegepast.  

Deze beschrijvingen zijn gekoppeld aan de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera().  

{{% /alert %}} 

## **OuterShadow‑effecten op teksten toepassen**

Aspose.Slides voor Node.js via Java biedt de [**OuterShadow**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/outershadow/) en [**InnerShadow**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/innershadow/)‑klassen waarmee u schaduweffecten op tekst in een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) kunt toepassen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.  
2. Verkrijg de verwijzing naar een dia via de index.  
3. Voeg een AutoShape van het type Rectangle toe aan de dia.  
4. Toegang tot het TextFrame dat aan de AutoShape is gekoppeld.  
5. Stel de FillType van de AutoShape in op NoFill.  
6. Instantieer de OuterShadow‑klasse.  
7. Stel de BlurRadius van de schaduw in.  
8. Stel de Direction van de schaduw in.  
9. Stel de Distance van de schaduw in.  
10. Stel de RectanglelAlign in op TopLeft.  
11. Stel de PresetColor van de schaduw in op Black.  
12. Sla de presentatie op als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  

Deze voorbeeldcode in Java—een implementatie van de bovenstaande stappen—toont hoe u het OuterShadow‑effect op een tekst toepast:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Verkrijg een referentie naar de dia
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type Rectangle toe
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Voeg een TextFrame toe aan de rechthoek
    ashp.addTextFrame("Aspose TextBox");
    // Schakel de vormvulling uit voor het geval we de tekstschaduw willen krijgen
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Voeg een buitenste schaduw toe en stel alle benodigde parameters in
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Schrijf de presentatie naar schijf
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **InnerShadow‑effect op vormen toepassen**

Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.  
2. Verkrijg een verwijzing naar de dia.  
3. Voeg een AutoShape van het type Rectangle toe.  
4. Schakel InnerShadowEffect in.  
5. Stel alle benodigde parameters in.  
6. Stel de ColorType in op Scheme.  
7. Stel de Scheme‑kleur in.  
8. Sla de presentatie op als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe u een verbinding tussen twee vormen maakt in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Verkrijg een referentie naar de dia
    var slide = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type Rectangle toe
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Voeg een TextFrame toe aan de rechthoek
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Schakel InnerShadowEffect in
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Stel alle benodigde parameters in
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Stel ColorType in als Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Stel Scheme-kleur in
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Sla de presentatie op
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en contour kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid en weergave van lettertypen kunnen afhangen van de systeem‑fonts.

**Kan ik WordArt‑effecten toepassen op elementen in de slide‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen in de master‑slides, inclusief titel‑place‑holders, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay‑out worden dan automatisch doorgevoerd naar alle gekoppelde dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Enigszins. WordArt‑effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte licht verhogen door extra opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met de `getImage`‑methode van de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) of [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/)‑klassen. Hiermee kunt u het resultaat in‑memory of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.