---
title: WordArt-Effekte in JavaScript erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/nodejs-java/wordart/
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
- Außenschatteneffekt
- Innenschatteneffekt
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für Node.js. Dieser schrittweise Leitfaden hilft Entwicklern, Präsentationen mit professionellem Text zu verbessern."
---

## **Über WordArt?**

WordArt oder Word Art ist ein Feature, das es ermöglicht, Texte mit Effekten zu versehen, damit sie hervorstechen. Mit WordArt können Sie z. B. einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Sie können zudem die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 

WordArt ermöglicht es, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie ansprechender oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Node.js via Java 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Versionen für Node.js via Java verbessert.

Mit Aspose.Slides für Node.js via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in JavaScript erstellen und auf Texte anwenden.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text**

**Verwenden von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit folgendem JavaScript‑Code:
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

Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mittels dieses Codes:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Verwenden von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Aus dem Menü rechts können Sie einen vordefinierten WordArt‑Effekt auswählen. Aus dem Menü links können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwenden von Aspose.Slides**

Hier wenden wir die [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid)‑Musterfarbe auf den Text an und fügen mit diesem Code einen ein‑Pixel‑breiten schwarzen Textrahmen hinzu:
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

**Verwenden von Microsoft PowerPoint**

Aus der Klassenpalette des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions- und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte können auf einen Textblock angewendet werden; die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Anwenden von Schatteneffekten**

Hier wollen wir nur die Eigenschaften eines Textes setzen. Wir wenden den Schatteneffekt auf einen Text mit diesem JavaScript‑Code an:
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


Aspose.Slides‑API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text (unter Verwendung voreingestellter Werte) anwenden. 

**Verwenden von Microsoft PowerPoint**

In PowerPoint können Sie einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwenden von Aspose.Slides**

Aspose.Slides erlaubt tatsächlich das gleichzeitige Anwenden von zwei Schattenarten: InnerShadow und PresetShadow.

Hinweise:

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende bzw. angewandte Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der OuterShadow‑Effekt angewendet. 

### **Anwenden von Anzeige auf Texte**

Wir fügen dem Text eine Anzeige hinzu mittels dieses JavaScript‑Codebeispiels:
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

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Leuchten zu bringen bzw. hervorzuheben, mithilfe dieses Codes:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Anzeige und Leuchteffekt ändern. Die Eigenschaften der Effekte werden jeweils für jeden Textabschnitt separat gesetzt. 

{{% /alert %}} 

### **Verwenden von Transformationen in WordArt**

Wir verwenden die Transform‑Eigenschaft (die dem gesamten Textblock zugrunde liegt) mit diesem Code:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Node.js via Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen.

{{% /alert %}} 

**Verwenden von PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie zu: **Format** → **TextEffect** → **Transform**

**Verwenden von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das TextShapeType‑Enum. 

### **Anwenden von 3D‑Effekten auf Texte und Formen**

Wir setzen einen 3D‑Effekt auf eine Textform mit diesem Beispielcode:
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

Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten unterliegen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt enthält die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figurenszene höhere Priorität – die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Textszene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen hängen mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera() zusammen.

{{% /alert %}} 

## **Außen­schatten‑Effekte auf Texte anwenden**

Aspose.Slides für Node.js via Java bietet die [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/) und [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/innershadow/) Klassen, die es ermöglichen, Schatteneffekte auf einen Text anzuwenden, der von [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) getragen wird. Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.  
4. Greifen Sie auf das TextFrame zu, das mit der AutoShape verknüpft ist.  
5. Setzen Sie den FillType der AutoShape auf NoFill.  
6. Instanziieren Sie die OuterShadow‑Klasse.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie die Distance des Schattens.  
10. Setzen Sie die RectanglelAlign auf TopLeft.  
11. Setzen Sie die PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.  

Dieser Beispielcode in Java – eine Umsetzung der oben genannten Schritte – zeigt, wie der Außen­schatten‑Effekt auf einen Text angewendet wird:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Referenz der Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Ein AutoShape vom Typ Rechteck hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");
    // Füllung der Form deaktivieren, falls wir den Schatten des Textes erhalten möchten
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Äußeren Schatten hinzufügen und alle erforderlichen Parameter festlegen
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


## **Innen­schatten‑Effekt auf Formen anwenden**

Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle erforderlichen Parameter.  
6. Setzen Sie den ColorType auf Scheme.  
7. Setzen Sie die Scheme‑Farbe.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.  

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie in JavaScript einen Verbinder zwischen zwei Formen hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Referenz der Folie abrufen
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
    // Alle erforderlichen Parameter festlegen
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType auf Scheme setzen
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme-Farbe festlegen
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

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Masterfolien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Masterlayout werden auf alle zugehörigen Folien übertragen.

**Wirken sich WordArt‑Effekte auf die Dateigröße der Präsentation aus?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße leicht erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten sehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mit der `getImage`‑Methode aus der [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑ oder [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)‑Klasse in Bilder (z. B. PNG, JPEG) rendern. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die komplette Präsentation speichern oder exportieren.