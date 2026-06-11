---
title: Skapa och tillämpa WordArt‑effekter i PHP
linktitle: WordArt
type: docs
weight: 110
url: /sv/php-java/wordart/
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
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för PHP via Java. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med professionell text."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva Office installerat. Denna artikel ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformationer, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt gör att du kan behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt-mall och tillämpa den på text**

**Använda Aspose.Slides** 

Först skapar vi en enkel text med denna PHP‑kod:

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
Nu ställer vi in textens teckensnittshöjd till ett större värde för att göra effekten mer märkbar med hjälp av denna kod:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Använda Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Det här är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Använda Aspose.Slides**

Här applicerar vi färgmönstret [SmallGrid](https://reference.aspose.com/slides/sv/php-java/aspose.slides/patternstyle/#SmallGrid) på texten och lägger till en 1‑bred svart textram med hjälp av denna kod:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applicera andra WordArt-effekter**

**Använda Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på text, textblock, form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan skugga-, reflektion- och glöd‑effekter appliceras på en text; 3D‑format‑ och 3D‑roterings‑effekter kan appliceras på ett textblock; egenskapen Mjuka kanter kan appliceras på ett Form‑objekt (den har fortfarande en effekt när ingen 3D‑format‑egenskap är inställd). 

### **Applicera skuggeffekter**

Här avser vi att endast ställa in egenskaper som rör en text. Vi applicerar skuggeffekten på en text med denna kod :

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

Aspose.Slides API stödjer tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 

Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Använda Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Använda Aspose.Slides**

Aspose.Slides låter faktiskt dig applicera två typer av skuggor samtidigt: InnerShadow och PresetShadow.

Anteckningar:
- När OuterShadow och PresetShadow används tillsammans, appliceras endast OuterShadow‑effekten.
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller applicerade effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2008 appliceras OuterShadow‑effekten.

### **Applicera reflektionseffekter på text**

Vi lägger till reflektion på texten med detta kodexempel :

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

### **Applicera glöd‑effekter på text**

Vi applicerar glöd‑effekten på texten för att få den att glänsa eller sticka ut med denna kod:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Du kan ändra parametrarna för skugga, reflektion och glöd. Effektens egenskaper ställs in för varje del av texten separat. 
{{% /alert %}} 

### **Använd transformationer i WordArt**

Vi använder Transform‑egenskapen (inneboende i hela textblocket) med denna kod:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Både Microsoft PowerPoint och Aspose.Slides för PHP via Java erbjuder ett antal fördefinierade transformationstyper. 
{{% /alert %}} 

**Använda PowerPoint**

För att komma åt fördefinierade transformationstyper, gå via: **Format** -> **TextEffect** -> **Transform**

**Använda Aspose.Slides**

För att välja en transformationstyp, använd enumen TextShapeType. 

### **Applicera 3D‑effekter på text och former**

Vi ställer in en 3D‑effekt på en textform med detta exempel på kod:

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

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med denna PHP‑kod:

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

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Tillämpningen av 3D‑effekter på texter eller deras former samt interaktionerna mellan effekter bygger på vissa regler.

Tänk på en scen för en text och formen som innehåller den texten. 3D‑effekten innehåller en 3D‑objektrepresentation och scenen där objektet placerades.

- När scenen är inställd för både figur och text får figur‑scenen högre prioritet – texts‑scenen ignoreras.
- När figuren saknar egen scen men har 3D‑representation används texts‑scenen.
- Annars – när formen ursprungligen inte har någon 3D‑effekt – är formen platt och 3D‑effekten appliceras endast på texten.

Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera().
{{% /alert %}} 

## **Applicera yttre skuggeffekter på text**
Aspose.Slides för PHP via Java tillhandahåller klasserna [OuterShadow](https://reference.aspose.com/slides/sv/php-java/aspose.slides/outershadow/) och [InnerShadow](https://reference.aspose.com/slides/sv/php-java/aspose.slides/innershadow/) som låter dig applicera skuggeffekter på text som finns i en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
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

Denna exempel­kod —en implementering av stegen ovan— visar hur du applicerar yttre skuggeffekten på en text:

```php
  $pres = new Presentation();
  try {
    # Hämta referens till bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av typen Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Lägg till TextFrame i rektangeln
    $ashp->addTextFrame("Aspose TextBox");
    # Inaktivera formens fyllning ifall vi vill ha textens skugga
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Lägg till yttre skugga och ange alla nödvändiga parametrar
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Spara presentationen till disk
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicera inre skuggeffekter på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
2. Hämta en referens till bilden.
3. Lägg till en AutoShape av typen Rectangle.
4. Aktivera InnerShadowEffect.
5. Ställ in alla nödvändiga parametrar.
6. Ställ in ColorType till Scheme.
7. Ställ in Scheme‑färgen.
8. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Denna exempel­kod (baserad på stegen ovan) visar hur du lägger till en förbindelse mellan två former :

```php
  $pres = new Presentation();
  try {
    # Hämta referens till bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av typen Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Lägg till TextFrame i rektangeln
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Aktivera InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Ange alla nödvändiga parametrar
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Ställ in ColorType som Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Ställ in Scheme-färg
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Spara presentationen
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides stödjer Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittstillgänglighet och rendering kan bero på systemteckensnitten.

**Kan jag applicera WordArt‑effekter på element i bildbakgrunden?**

Ja, du kan applicera WordArt‑effekter på former i bildbakgrunder, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar som görs i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lätt. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbart.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av `getImage`‑metoden från klasserna [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) eller [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.