---
title: WordArt
type: docs
weight: 110
url: /de/nodejs-java/wordart/
---

## **Über WordArt?**

WordArt bzw. Word Art ist ein Feature, mit dem Sie Texteffekte anwenden können, damit Texte besonders hervorgehoben werden. Mit WordArt können Sie beispielsweise einen Text umranden oder ihn mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem lässt sich die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 
WordArt ermöglicht es, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Änderungen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen. 
{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text bzw. dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Node.js via Java 20.10 haben wir Unterstützung für WordArt implementiert und die Funktion in späteren Aspose.Slides‑Releases für Node.js via Java weiter verbessert.

Mit Aspose.Slides für Node.js via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination mehrerer Effekte) in JavaScript erstellen und auf Texte anwenden.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text**

**Verwendung von Aspose.Slides** 

Zunächst erzeugen wir mit folgendem JavaScript‑Code einen einfachen Text:
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

Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mit diesem Code:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
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

Hier wenden wir das Muster **SmallGrid** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen von Breite 1 hinzu:
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Anwenden anderer WordArt‑Effekte**

**Verwendung von Microsoft PowerPoint**

Aus der Programmoberfläche können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten‑, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte auf einen Textblock; die Eigenschaft **Soft Edges** auf ein Shape‑Objekt (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Anwenden von Schatten‑Effekten**

Hier beschränken wir uns auf Eigenschaften, die nur einen Text betreffen. Wir wenden den Schatten‑Effekt auf einen Text mit folgendem JavaScript‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: **OuterShadow**, **InnerShadow** und **PresetShadow**. 

Mit **PresetShadow** können Sie einen vordefinierten Schatten auf einen Text anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur eine Schattenart verwenden. Ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides erlaubt tatsächlich, zwei Schattenarten gleichzeitig anzuwenden: **InnerShadow** und **PresetShadow**.

**Hinweise:**

- Wenn **OuterShadow** und **PresetShadow** zusammen verwendet werden, wird nur der **OuterShadow**‑Effekt angewendet. 
- Wenn **OuterShadow** und **InnerShadow** gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur **OuterShadow** angewendet. 

### **Anwenden von Anzeige‑Effekten auf Texte**

Wir fügen dem Text mit folgendem JavaScript‑Beispiel einen Anzeige‑Effekt hinzu:
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


### **Anwenden des Leuchteffekts auf Texte**

Wir wenden den Leuchteffekt auf den Text an, damit er glänzt oder hervorsticht, mit diesem Code:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Sie können die Parameter für Schatten, Anzeige und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 
{{% /alert %}} 

### **Verwendung von Transformationen in WordArt**

Wir nutzen die **Transform**‑Eigenschaft (die den gesamten Textblock betrifft) mit folgendem Code:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Node.js via Java bieten eine Reihe vordefinierter Transformationsarten. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um zu vordefinierten Transformationsarten zu gelangen, gehen Sie zu: **Format** → **TextEffect** → **Transform**

**Verwendung von Aspose.Slides**

Um eine Transformationsart auszuwählen, verwenden Sie das **TextShapeType**‑Enum. 

### **Anwenden von 3D‑Effekten auf Texte und Formen**

Wir setzen einen 3D‑Effekt auf eine Textform mit folgendem Beispielcode:
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


Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem JavaScript‑Code an:
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


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Die Anwendung von 3D‑Effekten auf Texte bzw. deren Formen und die Wechselwirkungen zwischen Effekten erfolgen nach bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt umfasst die 3D‑Objekt‑Darstellung und die Szene, in die das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Form als auch für den Text festgelegt ist, hat die Form‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Fehlt der Form eine eigene Szene, aber sie besitzt eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen hängen mit den Methoden **ThreeDFormat.getLightRig()** und **ThreeDFormat.getCamera()** zusammen. 
{{% /alert %}} 

## **Anwenden von Outer‑Shadow‑Effekten auf Texte**

Aspose.Slides für Node.js via Java stellt die Klassen **OuterShadow** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) und **InnerShadow** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow) bereit, mit denen Sie Schatteneffekte auf einen Text anwenden können, der zu einem **TextFrame** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) gehört. Gehen Sie folgendermaßen vor:

1. Erzeugen Sie eine Instanz der Klasse **Presentation** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Fügen Sie der Folie ein AutoShape vom Typ **Rectangle** hinzu. 
4. Greifen Sie auf das **TextFrame** des AutoShape zu. 
5. Setzen Sie den **FillType** des AutoShape auf **NoFill**. 
6. Instanziieren Sie die Klasse **OuterShadow**. 
7. Legen Sie den **BlurRadius** des Schattens fest. 
8. Bestimmen Sie die **Direction** des Schattens. 
9. Setzen Sie den **Distance** des Schattens. 
10. Setzen Sie **RectanglelAlign** auf **TopLeft**. 
11. Setzen Sie die **PresetColor** des Schattens auf **Black**. 
12. Schreiben Sie die Präsentation als **PPTX**‑Datei (https://docs.fileformat.com/presentation/pptx/) nieder. 

Dieser Beispielcode in Java – die Umsetzung der oben genannten Schritte – zeigt, wie Sie den Outer‑Shadow‑Effekt auf einen Text anwenden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Referenz der Folie holen
    var sld = pres.getSlides().get_Item(0);
    // Ein AutoShape vom Typ Rechteck hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");
    // Füllung der Form deaktivieren, falls wir den Textschatten erhalten wollen
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Äußeren Schatten hinzufügen und alle notwendigen Parameter setzen
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Präsentation auf die Festplatte schreiben
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Anwenden des Inner‑Shadow‑Effekts auf Formen**

Gehen Sie folgendermaßen vor:

1. Erzeugen Sie eine Instanz der Klasse **Presentation** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
2. Holen Sie die Referenz der Folie. 
3. Fügen Sie ein AutoShape vom Typ **Rectangle** hinzu. 
4. Aktivieren Sie **InnerShadowEffect**. 
5. Setzen Sie alle erforderlichen Parameter. 
6. Setzen Sie **ColorType** auf **Scheme**. 
7. Legen Sie die **Scheme Color** fest. 
8. Schreiben Sie die Präsentation als **PPTX**‑Datei (https://docs.fileformat.com/presentation/pptx/). 

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie in JavaScript einen Connector zwischen zwei Formen hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Referenz der Folie erhalten
    var slide = pres.getSlides().get_Item(0);
    // Ein AutoShape vom Typ Rechteck hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // InnerShadowEffect aktivieren
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Alle erforderlichen Parameter setzen
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType auf Scheme setzen
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme-Farbe setzen
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Präsentation speichern
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich WordArt‑Effekte mit unterschiedlichen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße durch zusätzliche Formatierungs‑Metadaten geringfügig erhöhen, der Unterschied ist jedoch in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der Klasse **Shape** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) oder **Slide** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) verwenden. Damit lässt sich das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor die komplette Präsentation gespeichert oder exportiert wird.