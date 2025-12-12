---
title: WordArt-Effekte auf Android erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/androidjava/wordart/
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
- Außenschatten-Effekt
- Innenschatten-Effekt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Android. Diese schrittweise Anleitung unterstützt Entwickler dabei, Präsentationen mit professionellem Text in Java zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, mit der Sie Texteffekte anwenden können, damit Texte hervorstechen. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die auf Texte angewendet werden, um sie attraktiver oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder seine Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides for Android via Java 20.10 haben wir Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides for Android via Java‑Versionen verbessert.

Mit Aspose.Slides for Android via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein Effekt oder eine Kombination von Effekten) in Java erstellen und auf Texte anwenden.

## **Eine einfache WordArt‑Vorlage erstellen und auf Text anwenden**

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit folgendem Java‑Code: 
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

Nun setzen wir die Schriftgröße des Textes auf einen größeren Wert, damit der Effekt auffälliger wird, mit diesem Code:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid)‑Musterfarbe auf den Text an und fügen mit diesem Code einen 1‑Pixel‑breiten schwarzen Textrahmen hinzu:
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Weitere WordArt‑Effekte anwenden**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, ein Shape oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten‑, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte auf einen Textblock; die Eigenschaft „Weiche Kanten“ kann auf ein Shape‑Objekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneinstellungen anwenden**

Hier wollen wir nur die Eigenschaften eines Textes setzen. Wir wenden den Schatteneffekt auf einen Text mit diesem Java‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anhand vordefinierter Werte anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint steht nur eine Schattenart zur Verfügung. Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides erlaubt tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der OuterShadow‑Effekt angewendet. 

### **Reflexionseffekte auf Text anwenden**

Wir fügen dem Text über dieses Java‑Beispiel eine Anzeige hinzu:
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


### **Leuchteffekte auf Text anwenden**

Wir wenden den Leuchteffekt auf den Text an, damit er glänzt oder hervorsticht, mit diesem Code:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Anzeige und Leuchten ändern. Die Eigenschaften der Effekte werden für jede Textportion separat gesetzt. 

{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Transform‑Eigenschaft (die für den gesamten Textblock gilt) mit diesem Code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides for Android via Java bieten eine Reihe vordefinierter Transformationstypen. 

{{% /alert %}} 

**Verwendung von PowerPoint**

Um vordefinierte Transformationstypen aufzurufen, gehen Sie zu: **Format** → **TextEffect** → **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Shapes anwenden**

Wir setzen einen 3D‑Effekt auf ein Text‑Shape mit diesem Beispielcode:
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


Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem Java‑Code an:
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


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Die Anwendung von 3D‑Effekten auf Texte oder deren Shapes und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und das Shape, das diesen Text enthält. Der 3D‑Effekt enthält die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figurenszene höhere Priorität – die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Textszene verwendet. 
- Andernfalls – wenn das Shape ursprünglich keinen 3D‑Effekt hat – ist das Shape flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Outer‑Shadow‑Effekte auf Text anwenden**
Aspose.Slides for Android via Java stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) und [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) bereit, mit denen Sie Schatteneffekte auf einen Text anwenden können, der von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) getragen wird. Gehen Sie dabei folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Fügen Sie der Folie ein AutoShape vom Typ Rectangle hinzu.  
4. Greifen Sie auf das TextFrame des AutoShape zu.  
5. Setzen Sie den FillType des AutoShape auf NoFill.  
6. Instanziieren Sie die Klasse OuterShadow.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie den Distance des Schattens.  
10. Setzen Sie das RectanglelAlign auf TopLeft.  
11. Setzen Sie den PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Der folgende Beispielcode in Java – eine Implementierung der oben genannten Schritte – zeigt, wie Sie den Outer‑Shadow‑Effekt auf einen Text anwenden:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rectangle hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");

    // Füllung der Form deaktivieren, falls wir den Schatten des Textes erhalten wollen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Äußeren Schatten hinzufügen und alle notwendigen Parameter festlegen
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Präsentation auf die Festplatte schreiben
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Inner‑Shadow‑Effekte auf Shapes anwenden**
Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie ein AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie den ColorType auf Scheme.  
7. Setzen Sie die Scheme‑Farbe.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt, wie Sie in Java einen Connector zwischen zwei Shapes hinzufügen:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect aktivieren
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Alle notwendigen Parameter festlegen
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType auf Scheme setzen
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme-Farbe festlegen
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Präsentation speichern
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Shapes in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtexten. Änderungen am Master‑Layout werden auf allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, weil zusätzliche Formatierungs‑Metadaten gespeichert werden, der Unterschied ist jedoch meist vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten sehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑ oder [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)‑Schnittstelle verwenden. Damit lassen sich die Ergebnisse im Speicher oder auf dem Bildschirm prüfen, bevor die komplette Präsentation gespeichert oder exportiert wird.