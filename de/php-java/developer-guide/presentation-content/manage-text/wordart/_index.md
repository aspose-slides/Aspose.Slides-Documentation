---
title: WordArt-Effekte in PHP erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/php-java/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Anzeigeeffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- äußerer Schatteneffekt
- innerer Schatteneffekt
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für PHP via Java. Diese schrittweise Anleitung hilft Entwicklern, Präsentationen mit professionellem Text zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist ein Feature, das es Ihnen ermöglicht, Texteffekte anzuwenden, damit sie hervorstechen. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder seine Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für PHP via Java 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Releases für PHP via Java verbessert.

Mit Aspose.Slides für PHP via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) erstellen und sie auf Texte anwenden.

## **Erstellen Sie eine einfache WordArt‑Vorlage und wenden Sie sie auf Text an**

**Using Aspose.Slides** 

Zuerst erstellen wir mit folgendem PHP‑Code einen einfachen Text:
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

Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, damit der Effekt deutlicher wird, mit folgendem Code:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Using Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Hier wenden wir die Musterfarbe [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/patternstyle/#SmallGrid) auf den Text an und fügen mit folgendem Code einen 1‑Pixel breiten schwarzen Textrahmen hinzu:
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```


Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Weitere WordArt‑Effekte anwenden**

**Using Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Shadow, Reflection und Glow auf einen Text angewendet werden; 3D‑Format und 3D‑Rotation auf einen Textblock; die Eigenschaft Soft Edges kann auf ein Shape‑Objekt angewendet werden (sie hat weiterhin Wirkung, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneffekte anwenden**

Hier wollen wir nur Eigenschaften für einen Text festlegen. Wir wenden den Schatteneffekt mit folgendem Code an :
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung voreingestellter Werte). 

**Using Microsoft PowerPoint**

In PowerPoint können Sie einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides erlaubt tatsächlich, zwei Schattenarten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Notes:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende bzw. angewendete Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der OuterShadow‑Effekt angewendet. 

### **Reflexionseffekte auf Text anwenden**

Wir fügen dem Text eine Reflexion hinzu mit folgendem Code‑Beispiel :
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


### **Leuchteeffekte auf Text anwenden**

Wir wenden den Leuchteffekt auf den Text an, damit er strahlt oder hervorsticht, mit folgendem Code:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Reflexion und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 

{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Transform‑Eigenschaft (die für den gesamten Textblock gilt) mit folgendem Code:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für PHP via Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen. 

{{% /alert %}} 

**Using PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie über: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit folgendem Beispielcode:
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


Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem PHP‑Code an:
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


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt enthält die 3D‑Objektrepräsentation und die Szene, auf der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figurenszene höhere Priorität – die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Repräsentation besitzt, wird die Textszene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Äußere Schatteneffekte auf Text anwenden**
Aspose.Slides für PHP via Java stellt die Klassen [OuterShadow](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/) und [InnerShadow](https://reference.aspose.com/slides/php-java/aspose.slides/innershadow/) bereit, die das Anwenden von Schatteneffekten auf einen Text ermöglichen, der von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) getragen wird. Gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rectangle hinzu.  
4. Greifen Sie auf das TextFrame zu, das mit der AutoShape verknüpft ist.  
5. Setzen Sie den FillType der AutoShape auf NoFill.  
6. Instanziieren Sie die Klasse OuterShadow.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie den Distance des Schattens.  
10. Setzen Sie das RectanglelAlign auf TopLeft.  
11. Setzen Sie das PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode — eine Umsetzung der oben genannten Schritte — zeigt, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:
```php
  $pres = new Presentation();
  try {
    # Referenz der Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Ein AutoShape vom Typ Rechteck hinzufügen
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("Aspose TextBox");
    # Formfüllung deaktivieren, falls wir den Schatten des Textes erhalten wollen
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Äußeren Schatten hinzufügen und alle erforderlichen Parameter festlegen
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Präsentation auf die Festplatte schreiben
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Innere Schatteneffekte auf Formen anwenden**
Gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie eine AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie den ColorType auf Scheme.  
7. Setzen Sie die Scheme‑Farbe.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieses Beispielcode (basierend auf den obigen Schritten) zeigt, wie man einen Verbinder zwischen zwei Formen hinzufügt :
```php
  $pres = new Presentation();
  try {
    # Referenz der Folie erhalten
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # InnerShadowEffect aktivieren
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Alle erforderlichen Parameter festlegen
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # ColorType als Scheme festlegen
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Scheme-Farbe festlegen
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Präsentation speichern
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und arbeitet mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrund‑Texten. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑ oder [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)‑Klassen verwenden. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm ansehen, bevor Sie die komplette Präsentation speichern oder exportieren.