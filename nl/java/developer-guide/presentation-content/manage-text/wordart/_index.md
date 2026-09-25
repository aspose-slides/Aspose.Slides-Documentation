---
title: WordArt‑effecten maken en toepassen in Java
linktitle: WordArt
type: docs
weight: 110
url: /nl/java/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt‑sjabloon
- WordArt‑effect
- schaduweffect
- reflectie‑effect
- gloeieffect
- WordArt‑transformatie
- 3D‑effect
- buitenste schaduweffect
- inner schaduweffect
- Java
- Aspose.Slides
description: "Maak en pas WordArt‑effecten aan in Aspose.Slides for Java. Deze stapsgewijze gids helpt ontwikkelaars presentaties te verbeteren met professionele tekst in Java."
---
## **Overzicht**

WordArt-effecten laten u tekst opmaken met vullingen, contouren, schaduwen, reflecties, gloed, transformaties en 3D‑opmaak. Dit artikel legt uit hoe u deze effecten kunt maken en aanpassen in PowerPoint‑presentaties met behulp van Aspose.Slides for Java, zonder dat Microsoft Office geïnstalleerd is.

## **Maak een eenvoudige WordArt‑sjabloon en pas het toe op tekst**

De volgende voorbeelden maken een eenvoudige WordArt‑stijl door de tekst, het lettertype, de patroonvulling en de contour in te stellen.

Elk voorbeeld maakt een nieuwe presentatie en voegt een rechthoek toe aan de eerste dia; er is geen invoerbestand vereist. Het eerste voorbeeld zet de tekst op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

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

Stel het lettertype in op Arial Black met 36 punten om de opmaak duidelijker te maken:

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

Pas een [SmallGrid](https://reference.aspose.com/slides/nl/java/com.aspose.slides/patternstyle/#SmallGrid)-patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstcontour toe met een breedte van 1 punt:

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

De resulterende tekst:

![Het eenvoudige WordArt‑sjabloon](WordArt_template.png)

## **Pas andere WordArt‑effecten toe**

De volgende voorbeelden tonen hoe u schaduwen, reflecties, gloed, transformaties en 3D‑effecten kunt toepassen op tekst.

### **Pas buitenste schaduweffecten toe**

Een buitenste schaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. U kunt de kleur, richting, afstand, onscherpte‑straal, schaal en scheefstand aanpassen.

Dit voorbeeld roept [enableOuterShadowEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) aan en stelt een zwarte schaduw in met een onscherpte‑straal van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de grootte van de schaduw, terwijl horizontale scheefstand deze 20 graden kantelt. De alfa‑transformatie zet de dekking op 32 %:

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

De resulterende tekst:

![Het buitenste schaduweffect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer buitenste en vooraf ingestelde schaduwen samen worden gebruikt, wordt alleen de buitenste schaduw toegepast.
- Als buitenste en innerlijke schaduwen gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenste schaduw wordt toegepast.
{{% /alert %}}

### **Pas reflectie‑effecten toe**

Een reflectie maakt een gespiegeld duplicaat van de tekst. Pas de positie, schaal, onscherpte en dekking aan om het uiterlijk te regelen.

Dit voorbeeld roept [enableReflectionEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effectformat/#enableReflectionEffect--) aan en draait de reflectie verticaal met een schaal van -100 %. Het gebruikt een onscherpte‑straal van 0,5 punt en een afstand van 4,72 punt. De dekking neemt af van 60 % naar 0,9 % tussen posities 0 % en 60 % langs de reflectie:

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

De resulterende tekst:

![Het reflectie‑effect](reflection_effect.png)

### **Pas gloed‑effecten toe**

Een gloed voegt een zachte gekleurde omtrek rond de tekst toe. Pas de kleur, dekking en straal aan om het effect te regelen.

Dit voorbeeld roept [enableGlowEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effectformat/#enableGlowEffect--) aan en past een rode gloed toe met 54 % dekking en een straal van 7 punten:

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

De resulterende tekst:

![Het gloed‑effect](glow_effect.png)

### **Pas WordArt‑transformaties toe**

WordArt‑transformaties buigen, rekken of vervormen een blok tekst.

Stel [setTransform](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#setTransform-int-) in op [ArchUpPour](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textshapetype/#ArchUpPour) om het gehele tekstkader naar boven te buigen:

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

De resulterende tekst:

![De WordArt‑transformatie](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java biedt een reeks vooraf gedefinieerde [transformatie‑types](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Pas 3D‑effecten toe op vormen en tekst**

U kunt 3D‑effecten toepassen op een vorm of op de bijbehorende tekst. Afschuiningen, extrusie, verlichting en camerainstellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/) om cirkelvormige afschuiningen, oranje extrusie en een donkerrode omtrek aan de rechthoek toe te voegen. De afschuiningafmetingen, extrusiehoogte, omtrekbreedte en diepte worden gemeten in punten. Een plastic materiaal, evenwichtige verlichting die 40 graden rond de Z‑as draait, en een perspectiefcamera bepalen het uiterlijk:

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

De resulterende vorm:

![Het vorm‑3D‑effect](shape_3D_effect.png)

Dit voorbeeld past een vergelijkbare 3D‑opmaak toe op de tekst via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Kleinere afschuiningen vormen de letterranden, terwijl extrusie en verlichting de tekst diepte geven:

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

De resulterende tekst:

![Het tekst‑3D‑effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Het toepassen van 3D‑effecten op tekst of hun vormen — en de interactie tussen deze effecten — wordt beheerst door specifieke regels. Beschouw een scène waarin zowel tekst als de vorm die de tekst bevat aanwezig zijn. Een 3D‑effect omvat de 3D‑representatie van het object en de scène waarin het geplaatst is.

- Als er voor zowel de vorm als de tekst een scène is ingesteld, krijgt de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/#getLightRig--) en [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/#getCamera--) .
{{% /alert %}}

Om tekst vlak en leesbaar te houden terwijl de 3D‑opmaak van de vorm behouden blijft, zie [Keep Text Flat on a 3D Shape](/slides/nl/java/3d-presentation/) voor een vergelijking van beide instellingen en een volledig Java‑voorbeeld.

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides for Java ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en contour kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op master‑dia‑elementen?**

Ja, u kunt WordArt‑effecten toepassen op vormen op de master‑dia’s, inclusief titel‑placeholder, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay-out worden doorgevoerd naar alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, gloed en gradientvullingen kunnen de bestandsgrootte iets verhogen door extra opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage--), of afzonderlijke vormen renderen met [IShape.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getImage--). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.