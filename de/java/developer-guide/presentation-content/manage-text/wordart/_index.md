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
- 3D‑Effekt
- Außenschatten‑Effekt
- Innenschatten‑Effekt
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Java. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Java zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, die es Ihnen ermöglicht, Texteffekte anzuwenden, damit Texte hervorstechen. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Sie können außerdem die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 
WordArt ermöglicht es, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen. 
{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Java 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Releases weiter verbessert. 

Mit Aspose.Slides für Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (einen Effekt oder eine Kombination von Effekten) in Java erstellen und auf Texte anwenden. 

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

Jetzt setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt deutlicher zu machen, mittels dieses Codes:
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

Hier wenden wir die [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid)‑Musterfarbe auf den Text an und fügen mit diesem Code einen 1‑Pixel breiten schwarzen Textrahmen hinzu:
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

## **Anwenden anderer WordArt‑Effekte**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte auf einen Textblock; die Eigenschaft „Weiche Kanten“ kann auf ein Shape‑Objekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Anwenden von Schatteneffekten**

Hier wollen wir nur Eigenschaften für einen Text setzen. Wir wenden den Schatteneffekt auf einen Text mit diesem Java‑Code an:
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


Aspose.Slides‑API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text (unter Verwendung voreingestellter Werte) anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Schatten‑Typ verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht tatsächlich das gleichzeitige Anwenden von zwei Schattenarten: InnerShadow und PresetShadow. 

**Hinweise:**
- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende bzw. angewendete Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der OuterShadow‑Effekt angewendet. 

### **Anzeige auf Texte anwenden**

Wir fügen dem Text über dieses Java‑Beispiel Anzeige hinzu:
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


### **Leuchteffekt auf Texte anwenden**

Wir wenden den Leuchteffekt auf den Text an, damit er glänzt oder hervorsticht, mittels dieses Codes:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Sie können die Parameter für Schatten, Anzeige und Leuchteffekt ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 
{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Transform‑Eigenschaft (die den gesamten Textblock betrifft) mit diesem Code:
``` java
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie über: **Format** -> **TextEffect** -> **Transform** 

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das Enum `TextShapeType`. 

### **3D‑Effekte auf Texte und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit diesem Beispielcode:
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
Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten folgen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt beinhaltet die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figur‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden `ThreeDFormat.getLightRig()` und `ThreeDFormat.getCamera()`. 
{{% /alert %}} 

## **Außenschatten‑Effekte auf Texte anwenden**
Aspose.Slides für Java stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) und [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) bereit, mit denen Sie Schatteneffekte auf einen über ein `TextFrame` getragenen Text anwenden können. Gehen Sie dabei wie folgt vor:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie ein `AutoShape` vom Typ Rectangle hinzu.  
4. Greifen Sie auf das `TextFrame` zu, das dem `AutoShape` zugeordnet ist.  
5. Setzen Sie den `FillType` des `AutoShape` auf `NoFill`.  
6. Instanziieren Sie die Klasse `OuterShadow`.  
7. Setzen Sie den `BlurRadius` des Schattens.  
8. Setzen Sie die `Direction` des Schattens.  
9. Setzen Sie den `Distance` des Schattens.  
10. Setzen Sie `RectanglelAlign` auf `TopLeft`.  
11. Setzen Sie die `PresetColor` des Schattens auf `Black`.  
12. Schreiben Sie die Präsentation als `PPTX`‑Datei.  

Dieser Java‑Beispielcode – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie den Außenschatten‑Effekt auf einen Text anwenden:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");

    // Formfüllung deaktivieren, falls wir den Schatten des Textes erhalten wollen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Außenschatten hinzufügen und alle notwendigen Parameter setzen
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


## **Innenschatten‑Effekt auf Formen anwenden**
Gehen Sie dabei wie folgt vor:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie ein `AutoShape` vom Typ Rectangle hinzu.  
4. Aktivieren Sie `InnerShadowEffect`.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie `ColorType` auf `Scheme`.  
7. Setzen Sie die `Scheme Color`.  
8. Schreiben Sie die Präsentation als `PPTX`‑Datei.  

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt Ihnen, wie Sie in Java einen Connector zwischen zwei Formen hinzufügen:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rechteck hinzufügen
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

    // Alle notwendigen Parameter setzen
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

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung der Schriftart vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen im Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten gespeichert werden, doch der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt zu Bildern (z. B. PNG, JPEG) rendern, indem Sie die Methode `getImage` aus den Schnittstellen `IShape` oder `ISlide` verwenden. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm vor dem Speichern oder Exportieren der gesamten Präsentation prüfen.