---
title: WordArt
type: docs
weight: 110
url: /de/php-java/wordart/
---


## **Was ist WordArt?**
WordArt oder Word Art ist eine Funktion, die es ermöglicht, Effekte auf Texte anzuwenden, um sie hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umreißen oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D-Effekte hinzufügen usw. Sie können auch die Form eines Textes verzerren, biegen und strecken.

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu gestalten.

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt-Vorlagen auswählen. Eine WordArt-Vorlage ist eine Sammlung von Effekten, die auf einen Text oder seine Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für PHP über Java 20.10 haben wir die Unterstützung für WordArt implementiert und in den nachfolgenden Versionen von Aspose.Slides für PHP über Java Verbesserungen an dieser Funktion vorgenommen.

Mit Aspose.Slides für PHP über Java können Sie ganz einfach Ihre eigene WordArt-Vorlage (einen Effekt oder eine Kombination von Effekten) erstellen und auf Texte anwenden.

## Erstellen einer einfachen WordArt-Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides**

Zunächst erstellen wir einen einfachen Text mit diesem PHP-Code:

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
Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt durch diesen Code auffälliger zu machen:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt-Effekte-Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Aus dem Menü auf der rechten Seite können Sie einen vordefinierten WordArt-Effekt auswählen. Aus dem Menü auf der linken Seite können Sie die Einstellungen für eine neue WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) Musterfarbe auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen mit einer Breite von 1 hinzu:

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

## Anwendung anderer WordArt-Effekte

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, Form oder ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions- und Glüheffekte auf einen Text angewendet werden; 3D-Format und 3D-Drehungseffekte können auf einen Textblock angewendet werden; Die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie hat immer noch einen Effekt, wenn keine 3D-Format-Eigenschaft festgelegt ist).

### Anwenden von Schatteneffekten

Hier beabsichtigen wir, die Eigenschaften zu setzen, die sich nur auf einen Text beziehen. Wir wenden den Schatteneffekt auf einen Text mit diesem Code an:

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

Die Aspose.Slides-API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung vordefinierter Werte). 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Schatten vom Typ verwenden. Hier ist ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen tatsächlich, zwei Arten von Schatten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow-Effekt angewendet.
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende oder angewendete Effekt von der PowerPoint-Version ab. Zum Beispiel wird in PowerPoint 2013 der Effekt verdoppelt. Aber in PowerPoint 2007 wird der OuterShadow-Effekt angewendet.

### Anwendung von Darstellung auf Texte

Wir fügen dem Text durch dieses Codebeispiel eine Darstellung hinzu:

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

### Glow-Effekt auf Texte anwenden

Wir wenden den Glow-Effekt auf den Text an, um ihn zum Leuchten oder Hervorheben zu bringen, mit diesem Code:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Darstellung und Glühen ändern. Die Eigenschaften der Effekte werden für jeden Teil des Textes separat festgelegt.

{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir verwenden die Transform-Eigenschaft (die für den gesamten Textblock gilt) durch diesen Code:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für PHP über Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen.

{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie die TextShapeType-Enum. 

### Anwendung von 3D-Effekten auf Texte und Formen

Wir setzen einen 3D-Effekt auf eine Textform mit diesem Beispielcode:

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

Wir wenden einen 3D-Effekt auf den Text mit diesem PHP-Code an:

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

Die Anwendung von 3D-Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D-Effekt enthält die 3D-Objekt-Representation und die Szene, auf der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figur-Szene die höhere Priorität – die Textszene wird ignoriert.
- Wenn die Figur keine eigene Szene hat, aber eine 3D-Darstellung hat, wird die Textszene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D-Effekt hat – ist die Form flach und der 3D-Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen sind mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera() verbunden.

{{% /alert %}} 

## **Anwenden von äußeren Schatteneffekten auf Texte**
Aspose.Slides für PHP über Java bietet die [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) und [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) Klassen, die es Ihnen ermöglichen, Schatteneffekte auf einen Text anzuwenden, der von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) getragen wird. Gehen Sie folgende Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Greifen Sie auf das mit der AutoShape verknüpfte TextFrame zu.
5. Setzen Sie den FillType der AutoShape auf NoFill.
6. Instanziieren Sie die OuterShadow-Klasse.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Richtung des Schattens.
9. Setzen Sie den Abstand des Schattens.
10. Setzen Sie die RectangleAlign auf TopLeft.
11. Setzen Sie die PresetColor des Schattens auf Schwarz.
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Dieser Beispielcode – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie den äußeren Schattierungseffekt auf einen Text anwenden:

```php
  $pres = new Presentation();
  try {
    # Erhalten Sie die Referenz der Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Fügen Sie das TextFrame zum Rechteck hinzu
    $ashp->addTextFrame("Aspose TextBox");
    # Deaktivieren Sie die Füllung der Form, falls wir den Schatten des Textes erhalten möchten
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Fügen Sie einen äußeren Schatten hinzu und setzen Sie alle notwendigen Parameter
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Anwenden des inneren Schattierungseffekts auf Formen**
Gehen Sie folgende Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
2. Erhalten Sie eine Referenz der Folie.
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
4. Aktivieren Sie den InnerShadowEffect.
5. Setzen Sie alle notwendigen Parameter.
6. Setzen Sie den ColorType auf Scheme.
7. Setzen Sie die Scheme-Farbe.
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt Ihnen, wie Sie einen Verbinder zwischen zwei Formen hinzufügen:

```php
  $pres = new Presentation();
  try {
    # Erhalten Sie die Referenz der Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Fügen Sie das TextFrame zum Rechteck hinzu
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Aktivieren Sie den InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Setzen Sie alle notwendigen Parameter
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Setzen Sie ColorType auf Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Setzen Sie die Scheme-Farbe
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Präsentation speichern
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```