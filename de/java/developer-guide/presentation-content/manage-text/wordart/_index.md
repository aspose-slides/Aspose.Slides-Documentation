---
title: Erstellen und Anwenden von WordArt-Effekten in Java
linktitle: WordArt
type: docs
weight: 110
url: /de/java/wordart/
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
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Java. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Java zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist ein Feature, das es Ihnen ermöglicht, Texte mit Effekten zu versehen, damit sie hervorgehoben werden. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3‑D‑Effekte hinzufügen usw. Sie können zudem die Form eines Textes kippen, biegen und strecken.

{{% alert color="primary" %}} 

WordArt lässt Sie einen Text wie ein grafisches Objekt behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, der auf einen Text oder dessen Form angewendet wird. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Java 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in späteren Aspose.Slides‑Versionen weiter verbessert. 

Mit Aspose.Slides für Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in Java erstellen und auf Texte anwenden. 

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text**

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

Nun setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mit diesem Code:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter bzw. Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir das Muster **SmallGrid** auf den Text an und fügen mit folgendem Code einen schwarzen Textrahmen mit Breite 1 hinzu:
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

## **Anwenden weiterer WordArt‑Effekte**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3‑D‑Format‑ und 3‑D‑Drehungseffekte auf einen Textblock; die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie wirkt weiterhin, wenn keine 3‑D‑Format‑Eigenschaft gesetzt ist). 

### **Anwenden von Schatteneffekten**

Hier setzen wir ausschließlich Eigenschaften, die einen Text betreffen. Wir wenden den Schatten‑Effekt mit folgendem Java‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: **OuterShadow**, **InnerShadow** und **PresetShadow**. 

Mit **PresetShadow** können Sie einen vordefinierten Schatten auf einen Text anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint steht nur ein Schatten‑Typ zur Verfügung. Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht tatsächlich das gleichzeitige Anwenden von zwei Schattenarten: **InnerShadow** und **PresetShadow**.

**Hinweise:**

- Wenn **OuterShadow** und **PresetShadow** zusammen verwendet werden, wird nur der **OuterShadow**‑Effekt angewendet. 
- Wenn **OuterShadow** und **InnerShadow** gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der **OuterShadow**‑Effekt angewendet. 

### **Anwenden von Leuchteffekten auf Texte**

Wir fügen dem Text mit folgendem Java‑Beispiel einen Leuchteffekt hinzu:
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


### **Anwenden von Leuchteffekten auf Texte**

Wir wenden mit folgendem Code den Leuchteffekt an, damit der Text strahlt oder hervorsticht:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Leuchten und Glühen ändern. Die Eigenschaften der Effekte werden für jeden Teil des Textes separat gesetzt. 

{{% /alert %}} 

### **Verwendung von Transformationen in WordArt**

Wir nutzen die **Transform**‑Eigenschaft (die den gesamten Textblock betrifft) mit folgendem Code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Java bieten eine Reihe vordefinierter Transformationstypen. 

{{% /alert %}} 

**Verwendung von PowerPoint**

Um vordefinierte Transformationstypen zu erreichen, gehen Sie über: **Format** → **TextEffect** → **Transform**  

**Verwendung von Aspose.Slides**

Zum Auswählen eines Transformationstyps verwenden Sie das **TextShapeType**‑Enum. 

### **Anwenden von 3‑D‑Effekten auf Texte und Formen**

Wir setzen einen 3‑D‑Effekt für eine Textform mit folgendem Beispielcode:
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

Wir wenden einen 3‑D‑Effekt mit diesem Java‑Code auf den Text an:
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

Die Anwendung von 3‑D‑Effekten auf Texte oder deren Formen sowie die Wechselwirkungen zwischen Effekten folgen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3‑D‑Effekt beinhaltet die 3‑D‑Objektdarstellung und die Szene, in der das Objekt platziert ist. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figur‑Szene höhere Priorität — die Text‑Szene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3‑D‑Darstellung besitzt, wird die Text‑Szene verwendet. 
- Andernfalls — wenn die Form ursprünglich keinen 3‑D‑Effekt hat — ist die Form flach und der 3‑D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden **ThreeDFormat.getLightRig()** und **ThreeDFormat.getCamera()**. 

{{% /alert %}} 

## **Anwenden von Outer‑Shadow‑Effekten auf Texte**
Aspose.Slides für Java stellt die Klassen **IOuterShadow** und **IInnerShadow** bereit, mit denen Sie Schatteneffekte auf einen Text anwenden können, der sich in einem **TextFrame** befindet. Gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse **Presentation**.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie ein **AutoShape** vom Typ Rectangle hinzu.  
4. Greifen Sie auf das **TextFrame** des **AutoShape** zu.  
5. Setzen Sie den **FillType** des **AutoShape** auf **NoFill**.  
6. Instanziieren Sie die Klasse **OuterShadow**.  
7. Setzen Sie den **BlurRadius** des Schattens.  
8. Setzen Sie die **Direction** des Schattens.  
9. Setzen Sie den **Distance** des Schattens.  
10. Setzen Sie **RectanglelAlign** auf **TopLeft**.  
11. Setzen Sie die **PresetColor** des Schattens auf **Black**.  
12. Schreiben Sie die Präsentation als **PPTX**‑Datei.

Dieser Beispielcode in Java — eine Umsetzung der oben genannten Schritte — zeigt, wie Sie den Outer‑Shadow‑Effekt auf einen Text anwenden:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // Eine AutoShape vom Typ Rechteck hinzufügen
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


## **Anwenden von Inner‑Shadow‑Effekten auf Formen**
Gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse **Presentation**.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie ein **AutoShape** vom Typ Rectangle hinzu.  
4. Aktivieren Sie **InnerShadowEffect**.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie **ColorType** auf **Scheme**.  
7. Setzen Sie die **Scheme Color**.  
8. Schreiben Sie die Präsentation als **PPTX**‑Datei.

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt, wie Sie in Java einen Connector zwischen zwei Formen hinzufügen:
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

    // Alle erforderlichen Parameter festlegen
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType auf Scheme setzen
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme-Farbe setzen
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Präsentation speichern
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung der Schriftart vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster‑Vorlage anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Masterfolien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtexten. Änderungen am Master‑Layout werden dann in allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße aufgrund zusätzlicher Formatierungs‑Metadaten geringfügig erhöhen, der Unterschied ist jedoch in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten prüfen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die Methode **getImage** aus den Schnittstellen **IShape** oder **ISlide** verwenden. So lässt sich das Ergebnis im Speicher oder auf dem Bildschirm anzeigen, bevor die komplette Präsentation gespeichert oder exportiert wird.