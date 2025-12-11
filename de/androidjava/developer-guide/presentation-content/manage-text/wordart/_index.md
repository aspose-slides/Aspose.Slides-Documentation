---
title: Erstellen und Anwenden von WordArt-Effekten auf Android
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
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Android. Diese schrittweise Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Java zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, mit der Sie Texteffekte anwenden können, um sie hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umranden oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 

WordArt ermöglicht es, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Änderungen an Texten, um sie attraktiver oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Android via Java 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Releases für Android via Java verbessert.

Mit Aspose.Slides für Android via Java können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in Java erstellen und auf Texte anwenden.

## **Einfaches WordArt‑Template erstellen und auf Text anwenden**

**Using Aspose.Slides** 

Zuerst erstellen wir mit diesem Java‑Code einen einfachen Text: 
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

Nun setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt deutlicher zu machen, mittels dieses Codes:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Using Microsoft PowerPoint**

Öffnen Sie das WordArt‑Effektmenü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Hier wenden wir die Musterfarbe [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen mit Breite 1 hinzu:
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

## **Andere WordArt‑Effekte anwenden**

**Using Microsoft PowerPoint**

Über die Programmoberfläche können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte können auf einen Textblock angewendet werden; die Eigenschaft „Weiche Kanten“ kann auf ein Shape‑Objekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneﬀekte anwenden**

Hier möchten wir ausschließlich die Eigenschaften eines Textes festlegen. Wir wenden den Schatteneffekt auf einen Text mit diesem Java‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einem Text einen Schatten mit voreingestellten Werten zuweisen. 

**Using Microsoft PowerPoint**

In PowerPoint können Sie einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides ermöglicht es tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Notes:**
- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wird OuterShadow zusammen mit InnerShadow verwendet, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, während in PowerPoint 2007 der OuterShadow‑Effekt angewendet wird. 

### **Reflexionseffekte auf Text anwenden**

Wir fügen dem Text durch dieses Java‑Beispiel eine Reflexion hinzu:
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

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Strahlen zu bringen, mittels dieses Codes:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Reflexion und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat festgelegt. 

{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Transform‑Eigenschaft (die den gesamten Textblock betrifft) mit diesem Code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Android via Java bieten eine Reihe vordefinierter Transformationsarten.

{{% /alert %}} 

**Using PowerPoint**

Um vordefinierte Transformationsarten zu nutzen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Um eine Transformationsart auszuwählen, verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Formen anwenden**

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

Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die den Text enthält. Der 3D‑Effekt beinhaltet die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert ist. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figurenszene höhere Priorität – die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Textszene verwendet. 
- Andernfalls, wenn die Form ursprünglich keinen 3D‑Effekt hat, ist sie flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Außenschatten‑Effekte auf Text anwenden**
Aspose.Slides für Android via Java stellt die [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) und [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) Klassen bereit, mit denen Sie Schatteneffekte auf einen Text anwenden können, der von einem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) getragen wird. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.  
2. Holen Sie sich die Referenz einer Folie mittels ihres Index.  
3. Fügen Sie der Folie ein AutoShape vom Typ Rechteck hinzu.  
4. Greifen Sie auf das mit dem AutoShape verbundene TextFrame zu.  
5. Setzen Sie den FillType des AutoShape auf NoFill.  
6. Instanziieren Sie die Klasse OuterShadow  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Richtung des Schattens  
9. Setzen Sie den Abstand des Schattens.  
10. Setzen Sie RectanglelAlign auf TopLeft.  
11. Setzen Sie die PresetColor des Schattens auf Black.  
12. Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  

Dieses Beispiel in Java — eine Umsetzung der oben genannten Schritte — zeigt, wie Sie den Außenschatten‑Effekt auf einen Text anwenden:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie holen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");

    // Formfüllung deaktivieren, falls wir den Textschatten erhalten möchten
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Außenschatten hinzufügen und alle erforderlichen Parameter festlegen
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Präsentation auf Festplatte schreiben
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Innenschatten‑Effekte auf Formen anwenden**
Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.  
2. Holen Sie sich eine Referenz der Folie.  
3. Fügen Sie ein AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle erforderlichen Parameter.  
6. Setzen Sie ColorType auf Scheme.  
7. Setzen Sie die Scheme‑Farbe.  
8. Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  

Dieses Beispiel (basierend auf den obigen Schritten) zeigt, wie Sie in Java einen Connector zwischen zwei Formen hinzufügen:
```java
Presentation pres = new Presentation();
try {
    // Referenz der Folie holen
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

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Schriften (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Umriss können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von der jeweiligen Systemschrift abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Folienmastern anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtexten. Änderungen am Master‑Layout wirken sich dann auf alle zugehörigen Folien aus.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten gespeichert werden, der Unterschied ist jedoch in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mit der `getImage`‑Methode der [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑ bzw. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)‑Schnittstelle in Bildformate (z. B. PNG, JPEG) rendern. So lässt sich das Ergebnis im Speicher oder auf dem Bildschirm betrachten, bevor die komplette Präsentation gespeichert oder exportiert wird.