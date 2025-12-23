---
title: "Erstellen und Anwenden von WordArt‑Effekten in PHP"
linktitle: "WordArt"
type: docs
weight: 110
url: /de/php-java/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt‑Vorlage
- WordArt‑Effekt
- Schatteneffekt
- Anzeigeeffekt
- Leuchteffekt
- WordArt‑Transformation
- 3D‑Effekt
- Außenschatten‑Effekt
- Innenschatten‑Effekt
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für PHP via Java. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text zu verbessern."
---

## **Über WordArt?**
WordArt bzw. Word Art ist ein Feature, das es Ihnen ermöglicht, Texte mit Effekten zu versehen, damit sie hervorstechen. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes verzerren, biegen und strecken. 

{{% alert color="primary" %}} 
WordArt behandelt einen Text wie ein grafisches Objekt. Im Allgemeinen besteht WordArt aus Effekten oder Sondermodifikationen, die an Texten vorgenommen werden, um sie ansprechender oder auffälliger zu machen. 
{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für PHP via Java 20.10 haben wir die Unterstützung für WordArt implementiert und das Feature in nachfolgenden Aspose.Slides‑Releases für PHP via Java verbessert.

Mit Aspose.Slides für PHP via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) erstellen und auf Texte anwenden.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf Text**

**Verwendung von Aspose.Slides** 

Zunächst erzeugen wir einen einfachen Text mit diesem PHP‑Code:
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

Jetzt setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt deutlicher zu machen, mittels dieses Codes:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Verwendung von Microsoft PowerPoint**

Öffnen Sie das WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir das Muster **[SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid)** auf den Text an und fügen mit diesem Code einen 1‑Pixel‑breiten schwarzen Textrahmen hinzu:
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

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten‑, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungs‑Effekte können auf einen Textblock angewendet werden; die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneﬀekte anwenden**

Hier wollen wir ausschließlich die Eigenschaften eines Textes festlegen. Wir wenden den Schatteneffekt auf einen Text mit diesem Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: **OuterShadow**, **InnerShadow** und **PresetShadow**. 

Mit **PresetShadow** können Sie einen vordefinierten Schatten für einen Text anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht tatsächlich das gleichzeitige Anwenden von zwei Schattenarten: **InnerShadow** und **PresetShadow**.

**Hinweise:**

- Wenn **OuterShadow** und **PresetShadow** zusammen verwendet werden, wird nur der **OuterShadow**‑Effekt angewendet. 
- Werden **OuterShadow** und **InnerShadow** gleichzeitig eingesetzt, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur **OuterShadow** angewendet. 

### **Reflexionseffekte auf Text anwenden**

Wir fügen dem Text über dieses Codebeispiel ein Reflexionseffekt hinzu:
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


### **Leuchteffekte auf Text anwenden**

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Glänzen zu bringen, mit diesem Code:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Sie können die Parameter für Schatten, Reflexion und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 
{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Eigenschaft **Transform** (gilt für den gesamten Textblock) mit diesem Code:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für PHP via Java bieten eine Reihe vordefinierter Transformationsarten. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um vordefinierte Transformationsarten zu erreichen, navigieren Sie zu: **Format** → **TextEffect** → **Transform**

**Verwendung von Aspose.Slides**

Zur Auswahl einer Transformationsart verwenden Sie das **TextShapeType**‑Enum. 

### **3D‑Effekte auf Text und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit diesem Beispielcode:
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


Das Ergebnis:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Die Anwendung von 3D‑Effekten auf Texte bzw. deren Formen und die Wechselwirkungen zwischen Effekten folgen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt umfasst die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert ist. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figurenszene höhere Priorität – die Textszene wird ignoriert. 
- Fehlt der Figur eine eigene Szene, aber sie besitzt eine 3D‑Darstellung, wird die Textszene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – bleibt die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen beziehen sich auf die Methoden **ThreeDFormat.getLightRig()** und **ThreeDFormat.getCamera()**. 
{{% /alert %}} 

## **Außenschatte‑Effekte auf Text anwenden**
Aspose.Slides für PHP via Java stellt die Klassen **[IOuterShadow](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow)** und **[IInnerShadow](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow)** bereit, die das Anwenden von Schatteneffekten auf einen Text ermöglichen, der von **[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)** getragen wird. Vorgehensweise:

1. Erstellen Sie eine Instanz der **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)**‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.  
4. Greifen Sie auf das **TextFrame** der AutoShape zu.  
5. Setzen Sie den **FillType** der AutoShape auf **NoFill**.  
6. Instanziieren Sie die **OuterShadow**‑Klasse.  
7. Legen Sie den **BlurRadius** des Schattens fest.  
8. Bestimmen Sie die **Direction** des Schattens.  
9. Setzen Sie die **Distance** des Schattens.  
10. Setzen Sie **RectanglelAlign** auf **TopLeft**.  
11. Setzen Sie **PresetColor** des Schattens auf **Black**.  
12. Schreiben Sie die Präsentation als **[PPTX](https://docs.fileformat.com/presentation/pptx/)**‑Datei.

Dieses Beispiel‑Code‑Snippet – eine Umsetzung der obigen Schritte – zeigt, wie Sie den Außenschatten‑Effekt auf einen Text anwenden:
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
    # Außenschatten hinzufügen und alle erforderlichen Parameter festlegen
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


## **Innenschatten‑Effekte auf Formen anwenden**
Vorgehensweise:

1. Erstellen Sie eine Instanz der **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)**‑Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.  
4. Aktivieren Sie **InnerShadowEffect**.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie **ColorType** auf **Scheme**.  
7. Legen Sie die **Scheme Color** fest.  
8. Schreiben Sie die Präsentation als **[PPTX](https://docs.fileformat.com/presentation/pptx/)**‑Datei.

Dieses Beispiel‑Code‑Snippet (basierend auf den obigen Schritten) zeigt, wie Sie einen Connector zwischen zwei Formen hinzufügen:
```php
  $pres = new Presentation();
  try {
    # Referenz der Folie abrufen
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
    # ColorType auf Scheme setzen
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Scheme-Farbe setzen
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

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titelplatzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Schatten, Leuchten und Farbverlauf‑Füllungen können die Dateigröße minimal erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, der Unterschied ist jedoch in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der **[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)**‑ oder **[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)**‑Schnittstelle verwenden. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.