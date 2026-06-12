---
title: WordArt-effecten maken en toepassen in PHP
linktitle: WordArt
type: docs
weight: 110
url: /nl/php-java/wordart/
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
- PHP
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor PHP via Java. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verrijken met professionele tekst."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatisch WordArt maken, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe u teksttransformaties, vulstijlen, omtrekken, schaduwen en andere opmaakopties toepast om uw presentatietekst meer expressief en boeiend te maken. WordArt behandelt tekst als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Een eenvoudige WordArt‑sjabloon maken en toepassen op tekst**

**Met Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze PHP‑code:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Nu stellen we de letterhoogte van de tekst in op een grotere waarde om het effect beter zichtbaar te maken via deze code:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);
```

**Met Microsoft PowerPoint**

Ga naar het WordArt‑effectenmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

In het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. In het menu aan de linkerkant kunt u de instellingen voor een nieuw WordArt opgeven. 

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Met Aspose.Slides**

Hier passen we het [SmallGrid](https://reference.aspose.com/slides/nl/php-java/aspose.slides/patternstyle/#SmallGrid) patroonkleur toe op de tekst en voegen we een 1‑punt dikke zwarte tekstrand toe met deze code:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Andere WordArt‑effecten toepassen**

**Met Microsoft PowerPoint**

Via de gebruikersinterface van het programma kunt u deze effecten toepassen op een tekst, tekstblok, vorm of soortgelijk element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, schaduw‑, reflectie‑ en gloed‑effecten kunnen op tekst worden toegepast; 3D‑opmaak‑ en 3D‑rotatie‑effecten kunnen op een tekstblok worden toegepast; de eigenschap Soft Edges kan op een Shape‑object worden toegepast (het heeft nog steeds effect wanneer er geen 3D‑opmaak‑eigenschap is ingesteld). 

### **Schaduw‑effecten toepassen**

Hier willen we alleen de eigenschappen voor tekst instellen. We passen het schaduw‑effect toe op een tekst met deze code:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```

Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow. 

Met PresetShadow kunt u een schaduw voor tekst toepassen (met vooraf ingestelde waarden). 

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hier is een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides maakt het zelfs mogelijk om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast. 
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende of toegepaste effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. Maar in PowerPoint 2007 wordt het OuterShadow‑effect toegepast. 

### **Reflectie‑effecten toepassen op tekst**

We voegen een weergave toe aan de tekst via dit code‑voorbeeld:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Gloed‑effecten toepassen op tekst**

We passen het gloed‑effect toe op de tekst zodat deze straalt of opvalt met deze code:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

U kunt de parameters voor schaduw, weergave en gloed aanpassen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk deel van de tekst. 

{{% /alert %}} 

### **Transformaties gebruiken in WordArt**

We gebruiken de Transform‑eigenschap (inherent op het hele tekstblok) met deze code:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor PHP via Java bieden een aantal vooraf gedefinieerde transformatietypen.

{{% /alert %}} 

**Met PowerPoint**

Om toegang te krijgen tot vooraf gedefinieerde transformatietypen, gaat u naar: **Format** -> **TextEffect** -> **Transform**

**Met Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de enum TextShapeType. 

### **3D‑effecten toepassen op tekst en vormen**

We stellen een 3D‑effect in op een tekstvorm met deze voorbeeldcode:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze PHP‑code:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

De toepassing van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten zijn gebaseerd op bepaalde regels. 

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect omvat de 3D‑objectrepresentatie en de scène waarop het object is geplaatst. 

- Wanneer de scène is ingesteld voor zowel de figuur als de tekst, krijgt de figuur‑scène de hogere prioriteit—de tekst‑scène wordt genegeerd. 
- Wanneer de figuur geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt. 
- Anders—wanneer de vorm oorspronkelijk geen 3D‑effect heeft—blijft de vorm plat en wordt het 3D‑effect alleen op de tekst toegepast. 

Deze beschrijvingen hebben betrekking op de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera().

{{% /alert %}} 

## **OuterShadow‑effecten toepassen op tekst**
Aspose.Slides voor PHP via Java biedt de [OuterShadow](https://reference.aspose.com/slides/nl/php-java/aspose.slides/outershadow/) en [InnerShadow](https://reference.aspose.com/slides/nl/php-java/aspose.slides/innershadow/) klassen die u in staat stellen schaduw‑effecten toe te passen op tekst die zich bevindt in een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/). Doorloop de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse. 
2. Verkrijg de referentie van een dia door het index‑nummer te gebruiken. 
3. Voeg een AutoShape van het type Rectangle toe aan de dia. 
4. Toegang tot het TextFrame dat bij de AutoShape hoort. 
5. Stel de FillType van de AutoShape in op NoFill. 
6. Instantieer de OuterShadow‑klasse 
7. Stel de BlurRadius van de schaduw in. 
8. Stel de Direction van de schaduw in 
9. Stel de Distance van de schaduw in. 
10. Stel de RectanglelAlign in op TopLeft. 
11. Stel de PresetColor van de schaduw in op Black. 
12. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. 

Deze voorbeeldcode — een implementatie van de bovenstaande stappen — laat zien hoe u het outer shadow‑effect op tekst kunt toepassen:

```php
  $pres = new Presentation();
  try {
    # Haal referentie van de dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van het type Rechthoek toe
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Voeg een TextFrame toe aan de rechthoek
    $ashp->addTextFrame("Aspose TextBox");
    # Schakel vormvulling uit voor het geval we de schaduw van de tekst willen krijgen
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Voeg een buitenschaduw toe en stel alle benodigde parameters in
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Schrijf de presentatie naar schijf
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **InnerShadow‑effecten toepassen op vormen**
Doorloop de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse. 
2. Verkrijg een referentie van de dia. 
3. Voeg een AutoShape van het type Rectangle toe. 
4. Schakel InnerShadowEffect in. 
5. Stel alle benodigde parameters in. 
6. Stel de ColorType in op Scheme. 
7. Stel de Scheme‑kleur in. 
8. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. 

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) toont hoe u een connector tussen twee vormen toevoegt:

```php
  $pres = new Presentation();
  try {
    # Haal referentie van de dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van het type Rechthoek toe
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Voeg een TextFrame toe aan de Rechthoek
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Schakel InnerShadowEffect in
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Stel alle benodigde parameters in
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Stel ColorType in op Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Stel Scheme-kleur in
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Sla presentatie op
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en omtrek kunnen worden toegepast, ongeacht de taal, hoewel beschikbaarheid van lettertypen en weergave afhankelijk kunnen zijn van de systeembreed geïnstalleerde lettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen in master‑dia’s, inclusief titel‑placeholders, voetteksten of achtergrondtekst. Wijzigingen in de master‑indeling worden doorgevoerd naar alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte lichtjes verhogen door extra opmaak‑metadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met de `getImage`‑methode van de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) of [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) klassen. Hiermee kunt u het resultaat in‑memory of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.