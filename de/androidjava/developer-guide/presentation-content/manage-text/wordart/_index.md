---
title: Erstellen und Anwenden von WordArt‑Effekten unter Android
linktitle: WordArt
type: docs
weight: 110
url: /de/androidjava/wordart/
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
- äußerer Schatteneffekt
- innerer Schatteneffekt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für Android. Diese schrittweise Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Java zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, visuell ansprechenden, stilisierten Text zu Ihren PowerPoint‑Präsentationen hinzuzufügen. Mit Aspose.Slides können Entwickler programmgesteuert WordArt erstellen, anpassen und verwalten, genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel bietet einen Überblick über die Arbeit mit WordArt, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihre Präsentationsinhalte ausdrucksvoller und ansprechender zu gestalten. WordArt ermöglicht es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder Sondermodifikationen, die auf den Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Erstellen Sie eine einfache WordArt‑Vorlage und wenden Sie sie auf Text an**

**Verwenden von Aspose.Slides** 

Zunächst erstellen wir einen einfachen Text mit diesem Java‑Code: 

``` java
import com.aspose.slides.*;

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
Jetzt setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt deutlicher zu machen, mit diesem Code:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Verwendung von Microsoft PowerPoint**

Öffnen Sie das WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter bzw. Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwenden von Aspose.Slides**

Hier wenden wir die Musterfarbe [SmallGrid](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PatternStyle#SmallGrid) auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen mit Breite 1 hinzu:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Weitere WordArt‑Effekte anwenden**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf Text, Textblock, Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Zum Beispiel können Schatten-, Reflexions‑ und Leuchteffekte auf Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte können auf einen Textblock angewendet werden; Die Eigenschaft Weiche Kanten kann auf ein Form‑Objekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Formateigenschaft festgelegt ist). 

### **Schatteneffekte anwenden**

Hier beabsichtigen wir, ausschließlich die Eigenschaften für einen Text festzulegen. Wir wenden den Schatteneffekt auf einen Text mit diesem Java‑Code an:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Die Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung voreingestellter Werte). 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende bzw. angewendete Effekt von der PowerPoint‑Version ab. Beispielsweise wird in PowerPoint 2013 der Effekt verdoppelt, während in PowerPoint 2007 der OuterShadow‑Effekt angewendet wird. 

### **Reflexionseffekte auf Text anwenden**

Wir fügen dem Text durch dieses Java‑Beispiel eine Reflexion hinzu:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Leuchteffekte auf Text anwenden**

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Glänzen zu bringen oder hervorzuheben, mit diesem Code:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Sie können die Parameter für Schatten, Reflexion und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Teil des Textes separat festgelegt. 

{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Transform‑Eigenschaft (die für den gesamten Textblock gilt) mit diesem Code:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Android via Java bieten eine Reihe vordefinierter Transformationstypen.

{{% /alert %}} 

**Verwendung von PowerPoint**

Zur Auswahl vordefinierter Transformationstypen gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit diesem Beispielcode:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem Java‑Code an:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen den Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt umfasst die 3D‑Objektdarstellung und die Szene, in die das Objekt eingefügt wird. 

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figur‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen hängen mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera() zusammen. 

{{% /alert %}} 

## **Äußere Schatteneffekte auf Text anwenden**
Aspose.Slides für Android via Java bietet die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioutershadow/) und [**IInnerShadow**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinnershadow/) an, mit denen Sie Schatteneffekte auf einen Text anwenden können, der in einem [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) enthalten ist. Folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) .
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Greifen Sie auf das TextFrame zu, das mit der AutoShape verknüpft ist.
5. Setzen Sie den FillType der AutoShape auf NoFill.
6. Instanziieren Sie die Klasse OuterShadow
7. Legen Sie den BlurRadius des Schattens fest.
8. Legen Sie die Direction des Schattens fest
9. Legen Sie die Distance des Schattens fest.
10. Setzen Sie RectangleAlign auf TopLeft.
11. Setzen Sie PresetColor des Schattens auf Black.
12. Schreiben Sie die Präsentation als eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode in Java – eine Umsetzung der obigen Schritte – zeigt, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Referenz der Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("Aspose TextBox");

    // Formfüllung deaktivieren, falls wir den Schatten des Textes erhalten wollen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Außenschatten hinzufügen und alle notwendigen Parameter festlegen
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Präsentation auf Festplatte speichern
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Innere Schatteneffekte auf Formen anwenden**
Folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) .
2. Holen Sie die Referenz der Folie.
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
4. Aktivieren Sie InnerShadowEffect.
5. Setzen Sie alle erforderlichen Parameter.
6. Setzen Sie ColorType auf Scheme.
7. Setzen Sie die Scheme‑Farbe.
8. Schreiben Sie die Präsentation als eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie den inneren Schatteneffekt auf einen Text in Java anwenden:

```java
import com.aspose.slides.*;

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

### Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit von Schriftarten und die Darstellung vom System abhängen können.

### Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

### Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße aufgrund zusätzlicher Formatierungs‑Metadaten geringfügig erhöhen, doch der Unterschied ist in der Regel vernachlässigbar.

### Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)‑ oder [ISlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/)‑Schnittstelle verwenden. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.