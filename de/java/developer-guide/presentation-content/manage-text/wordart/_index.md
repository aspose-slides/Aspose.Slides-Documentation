---
title: "Erstellen und Anwenden von WordArt‑Effekten in Java"
linktitle: "WordArt"
type: docs
weight: 110
url: /de/java/wordart/
keywords:
- "WordArt"
- "WordArt erstellen"
- "WordArt‑Vorlage"
- "WordArt‑Effekt"
- "Schatteneffekt"
- "Anzeigeeffekt"
- "Leuchteffekt"
- "WordArt‑Transformation"
- "3D‑Effekt"
- "äußerer Schatteneffekt"
- "innerer Schatteneffekt"
- "PowerPoint"
- "Präsentation"
- "Java"
- "Aspose.Slides"
description: "WordArt‑Effekte in Aspose.Slides für Java erstellen und anpassen. Diese Schritt‑für‑Schritt‑Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Java zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, visuell ansprechenden, stilisierten Text zu Ihren PowerPoint‑Präsentationen hinzuzufügen. Mit Aspose.Slides können Entwickler WordArt programmgesteuert erstellen, anpassen und verwalten – genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel gibt einen Überblick über die Arbeit mit WordArt, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihren Präsentationsinhalt ausdrucksstärker und ansprechender zu gestalten. WordArt erlaubt es, Text wie ein grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Modifikationen, die auf Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text**

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit diesem Java‑Code: 

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
Nun setzen wir die Schriftgröße auf einen größeren Wert, um den Effekt deutlicher zu machen, über diesen Code:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effektmenü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter bzw. Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir das Muster „[SmallGrid](https://reference.aspose.com/slides/de/java/com.aspose.slides/PatternStyle#SmallGrid)“ auf den Text an und fügen einen 1‑Pixel breiten schwarzen Textrahmen mit folgendem Code hinzu:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

## **Anwenden anderer WordArt‑Effekte**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, ein Diagramm oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten‑, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Dreh‑Effekte können auf einen Textblock angewendet werden; die Eigenschaft „Weiche Kanten“ kann auf ein Shape‑Objekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Anwenden von Schatten‑Effekten**

Hier wollen wir nur Eigenschaften für einen Text festlegen. Wir wenden den Schatten‑Effekt auf einen Text mit diesem Java‑Code an:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Mit PresetShadow können Sie einen Schatten für einen Text (unter Verwendung vordefinierter Werte) anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schatten‑Typ verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende bzw. angewendete Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt beispielsweise verdoppelt, in PowerPoint 2007 wird nur der OuterShadow‑Effekt angewendet. 

### **Anwenden von Anzeige‑Effekten auf Texte**

Wir fügen dem Text über dieses Java‑Beispiel einen Anzeige‑Effekt hinzu:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Anwenden des Leuchteffekts auf Texte**

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Strahlen zu bringen, mit folgendem Code:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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
Sie können die Parameter für Schatten, Anzeige und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat festgelegt. 
{{% /alert %}} 

### **Verwendung von Transformationen in WordArt**

Wir nutzen die Transform‑Eigenschaft (die dem gesamten Textblock zugrunde liegt) mit folgendem Code:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um vordefinierte Transformationstypen aufzurufen, gehen Sie zu: **Format** → **TextEffect** → **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das enum TextShapeType. 

### **Anwenden von 3D‑Effekten auf Texte und Shapes**

Wir setzen einen 3D‑Effekt auf eine Text‑Shape mit diesem Beispielcode:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Der resultierende Text und seine Shape:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem Java‑Code an:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
Die Anwendung von 3D‑Effekten auf Texte oder deren Shapes sowie die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und das Shape, das diesen Text enthält. Der 3D‑Effekt umfasst die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert ist. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figur‑Szene die höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn das Shape ursprünglich keinen 3D‑Effekt hat – ist das Shape flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen im Zusammenhang mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Anwenden von Outer‑Shadow‑Effekten auf Texte**
Aspose.Slides für Java stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioutershadow/) und [**IInnerShadow**](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinnershadow/) bereit, mit denen Sie Schatten‑Effekte auf einen Text anwenden können, der von [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) getragen wird. Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie ein AutoShape vom Typ Rectangle hinzu.  
4. Greifen Sie auf das TextFrame zu, das dem AutoShape zugeordnet ist.  
5. Setzen Sie den FillType des AutoShape auf NoFill.  
6. Instanziieren Sie die OuterShadow‑Klasse.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie die Distance des Schattens.  
10. Setzen Sie RectanglelAlign auf TopLeft.  
11. Setzen Sie die PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Der folgende Beispielcode in Java – eine Umsetzung der obigen Schritte – zeigt, wie Sie den Outer‑Shadow‑Effekt auf einen Text anwenden:

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

    // Füllung der Form deaktivieren, falls wir den Schatten des Textes erhalten wollen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aussenschatten hinzufügen und alle erforderlichen Parameter festlegen
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

## **Anwenden von Inner‑Shadow‑Effekten auf Shapes**
Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie ein AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle erforderlichen Parameter.  
6. Setzen Sie ColorType auf Scheme.  
7. Setzen Sie die Scheme Color.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Der folgende Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie den Inner‑Shadow‑Effekt auf den Text in einem Shape in Java anwenden:

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

### Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen können.

### Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?

Ja, Sie können WordArt‑Effekte auf Shapes im Master‑Slide anwenden, einschließlich Titelfeld‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

### Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, weil zusätzliche Formatierungs‑Metadaten hinzugefügt werden, doch der Unterschied ist in der Regel vernachlässigbar.

### Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?

Ja, Sie können Folien, die WordArt enthalten, als Bilder (z. B. PNG, JPEG) rendern, indem Sie die `getImage`‑Methode der [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)‑ oder [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/)‑Schnittstelle verwenden. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.