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
- binnenste schaduw-effect
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en personaliseer WordArt-effecten in Aspose.Slides voor Android. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verbeteren met professionele tekst in Java."
---
## **Overzicht**

WordArt-effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatically WordArt creëren, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief het toepassen van teksttransformaties, opvullingsstijlen, omtrekken, schaduwen en andere opmaakopties om de inhoud van uw presentatie expressiever en aantrekkelijker te maken. WordArt laat u tekst behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Maak een eenvoudige WordArt‑sjabloon en pas deze toe op tekst**

**Met Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze Java‑code: 

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
Vervolgens stellen we de letterhoogte van de tekst in op een grotere waarde om het effect beter zichtbaar te maken met deze code:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Met Microsoft PowerPoint**

Ga naar het WordArt‑effectmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

In het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. In het menu aan de linkerkant kunt u de instellingen voor een nieuw WordArt opgeven. 

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Met Aspose.Slides**

Hier passen we het [SmallGrid](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PatternStyle#SmallGrid) patroonkleur toe op de tekst en voegen we een zwarte tekstomranding van 1 breedte toe met deze code:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Pas andere WordArt‑effecten toe**

**Met Microsoft PowerPoint**

Via de interface van het programma kunt u deze effecten toepassen op een tekst, tekstvak, vorm of vergelijkbaar element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, schaduw‑, reflectie‑ en gloed‑effecten kunnen op een tekst worden toegepast; 3D‑opmaak‑ en 3D‑rotatie‑effecten kunnen op een tekstblok worden toegepast; de eigenschap Soft Edges kan op een Shape‑object worden toegepast (deze blijft effect hebben wanneer er geen 3D‑opmaak‑eigenschap is ingesteld). 

### **Schaduw‑effecten toepassen**

Hier willen we alleen de eigenschappen voor een tekst instellen. We passen het schaduw‑effect toe op een tekst met deze Java‑code:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow. 

Met PresetShadow kunt u een vooraf ingestelde schaduw op een tekst toepassen. 

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hieronder een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides maakt het zelfs mogelijk om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast. 
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende of toegepaste effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. Maar in PowerPoint 2007 wordt het OuterShadow‑effect toegepast. 

### **Reflectie‑effecten toepassen op tekst**

We voegen een reflectie toe aan de tekst met dit Java‑codevoorbeeld:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Gloed‑effecten toepassen op tekst**

We passen het gloed‑effect toe op de tekst zodat deze schittert of opvalt met deze code:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

U kunt de parameters voor schaduw, reflectie en gloed wijzigen. De eigenschappen van de effecten worden afzonderlijk op elk deel van de tekst ingesteld. 

{{% /alert %}} 

### **Transformaties gebruiken in WordArt**

We gebruiken de Transform‑eigenschap (van toepassing op het volledige tekstblok) met deze code:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor Android via Java bieden een bepaald aantal vooraf gedefinieerde transformatietypen.

{{% /alert %}} 

**Met PowerPoint**

Om toegang te krijgen tot vooraf gedefinieerde transformatietypen, gaat u via: **Format** → **TextEffect** → **Transform**

**Met Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de TextShapeType‑enum. 

### **3D‑effecten toepassen op tekst en vormen**

We stellen een 3D‑effect in op een tekstopmaak met deze voorbeeldcode:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze Java‑code:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Het toepassen van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten zijn gebaseerd op bepaalde regels. 

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect bevat een 3D‑objectrepresentatie en de scène waarop het object geplaatst is. 

- Wanneer de scène is ingesteld voor zowel de vorm als de tekst, krijgt de vorm‑scène hogere prioriteit — de tekst‑scène wordt genegeerd. 
- Wanneer de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt. 
- Anders — wanneer de vorm oorspronkelijk geen 3D‑effect heeft — is de vorm vlak en wordt het 3D‑effect alleen op de tekst toegepast. 

Deze beschrijvingen zijn gerelateerd aan de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera().

{{% /alert %}} 

## **Outer Shadow‑effecten toepassen op tekst**
Aspose.Slides voor Android via Java biedt de [**IOuterShadow**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioutershadow/) en [**IInnerShadow**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinnershadow/) klassen die u in staat stellen schaduw‑effecten toe te passen op een tekst die zich bevindt in een [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/). Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.
2. Verkrijg de referentie van een slide door het indexnummer te gebruiken.
3. Voeg een AutoShape van het type Rectangle toe aan de slide.
4. Open de TextFrame die bij de AutoShape hoort.
5. Stel de FillType van de AutoShape in op NoFill.
6. Instantieer de OuterShadow‑klasse.
7. Stel de BlurRadius van de schaduw in.
8. Stel de Direction van de schaduw in.
9. Stel de Distance van de schaduw in.
10. Stel de RectangleAlign in op TopLeft.
11. Stel de PresetColor van de schaduw in op Black.
12. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode in Java — een implementatie van de bovenstaande stappen — laat zien hoe u het outer shadow‑effect op een tekst toepast:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Verkrijg referentie naar de dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rechthoek toe
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voeg een TextFrame toe aan de rechthoek
    ashp.addTextFrame("Aspose TextBox");

    // Schakel vormvulling uit voor het geval we de schaduw van de tekst willen krijgen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een buitenste schaduw toe en stel alle benodigde parameters in
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

## **Inner Shadow‑effecten toepassen op vormen**
Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.
2. Haal een referentie van de slide op.
3. Voeg een AutoShape van het type Rectangle toe.
4. Schakel InnerShadowEffect in.
5. Stel alle noodzakelijke parameters in.
6. Stel de ColorType in op Scheme.
7. Stel de Scheme‑kleur in.
8. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe u het inner shadow‑effect op een tekst toepast in Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Verkrijg referentie naar de dia
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

### Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle belangrijke lettertypen en scripts. WordArt‑effecten zoals schaduw, opvulling en omtrek kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en de weergave kunnen afhangen van de systeem‑fonts.

### Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?

Ja, u kunt WordArt‑effecten toepassen op vormen op de master‑slides, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen die op de master‑lay‑out worden aangebracht, worden doorgevoerd naar alle bijbehorende slides.

### Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?

Een beetje. WordArt‑effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte enigszins verhogen door extra opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

### Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?

Ja, u kunt slides die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met de `getImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) interfaces. Hiermee kunt u het resultaat in‑memory of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.