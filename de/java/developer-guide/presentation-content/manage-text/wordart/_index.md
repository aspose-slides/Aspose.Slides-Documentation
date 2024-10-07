---
title: WordArt
type: docs
weight: 110
url: /java/wordart/
---


## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, die es Ihnen ermöglicht, Effekte auf Texte anzuwenden, um sie hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umreißen oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D-Effekte hinzufügen usw. Sie können auch die Form eines Textes verzerren, biegen und strecken.

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die auf Texte angewendet werden, um sie attraktiver oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt-Vorlagen auswählen. Eine WordArt-Vorlage ist eine Sammlung von Effekten, die auf einen Text oder seine Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für Java 20.10 haben wir die Unterstützung für WordArt implementiert und Verbesserungen an der Funktion in den nachfolgenden Versionen von Aspose.Slides für Java vorgenommen.

Mit Aspose.Slides für Java können Sie ganz einfach Ihre eigene WordArt-Vorlage (ein Effekt oder eine Kombination von Effekten) in Java erstellen und auf Texte anwenden.

## Erstellen einer einfachen WordArt-Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides**

Zuerst erstellen wir einen einfachen Text mit diesem Java-Code:

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
Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt durch diesen Code auffälliger zu machen:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt-Effekte-Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Aus dem Menü rechts können Sie einen vordefinierten WordArt-Effekt auswählen. Aus dem Menü links können Sie die Einstellungen für eine neue WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid)-Musterfarbe auf den Text an und fügen einen 1 Pixel breiten schwarzen Textumriss mit diesem Code hinzu:

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

## Anwenden anderer WordArt-Effekte

**Verwendung von Microsoft PowerPoint**

Über die Schnittstelle des Programms können Sie diese Effekte auf einen Text, einen Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Zum Beispiel können Schatten-, Reflexions- und Leuchteffekte auf einen Text angewendet werden; 3D-Format- und 3D-Rotations-Effekte können auf einen Textblock angewendet werden; Weiche Kanten-Eigenschaften können auf ein Formobjekt angewendet werden (es hat immer noch einen Effekt, wenn kein 3D-Format-Eigenschaft festgelegt ist).

### Anwenden von Schatteneffekten

Hier beabsichtigen wir, die Eigenschaften, die sich nur auf einen Text beziehen, festzulegen. Wir wenden den Schatteneffekt auf einen Text mit diesem Code in Java an:

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

Die Aspose.Slides-API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow.

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung vordefinierter Werte).

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Schattenstyp verwenden. Hier ist ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es tatsächlich, zwei Arten von Schatten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow gemeinsam verwendet werden, wird nur der OuterShadow-Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende oder angewendete Effekt von der Version von PowerPoint ab. Zum Beispiel wird in PowerPoint 2013 der Effekt verdoppelt. In PowerPoint 2007 wird jedoch nur der OuterShadow-Effekt angewendet.

### Anwenden von Reflexionen auf Texte

Wir fügen durch dieses Java-Codebeispiel dem Text eine Reflexion hinzu:

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

### Anwenden von Leuchteffekten auf Texte

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Strahlen oder Hervorheben zu bringen, mithilfe dieses Codes:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Reflexion und Glühen ändern. Die Eigenschaften der Effekte werden für jeden Teil des Textes separat festgelegt. 

{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir verwenden die Transform-Eigenschaft (die im gesamten Textblock vorhanden ist) durch diesen Code:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Java bieten eine bestimmte Anzahl vordefinierter Transformationsarten. 

{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationsarten zuzugreifen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das TextShapeType-Enum. 

### Anwenden von 3D-Effekten auf Texte und Formen

Wir setzen einen 3D-Effekt auf eine Textform mit diesem Beispielcode:

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

Wir wenden einen 3D-Effekt auf den Text mit diesem Java-Code an:

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

Die Anwendung von 3D-Effekten auf Texte oder deren Formen und die Interaktionen zwischen den Effekten basieren auf bestimmten Regeln.

Berücksichtigen Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D-Effekt enthält die 3D-Objekt-Darstellung und die Szene, auf der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figurenszene die höhere Priorität – die Textszene wird ignoriert.
- Wenn die Figur keine eigene Szene hat, aber eine 3D-Darstellung hat, wird die Textszene verwendet.
- Andernfalls – wenn die Form ursprünglich keinen 3D-Effekt hat – ist die Form flach und der 3D-Effekt wird nur auf den Text angewendet.

Diese Beschreibungen beziehen sich auf die Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera().

{{% /alert %}} 

## **Äußere Schatteneffekte auf Texte anwenden**
Aspose.Slides für Java bietet die [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) und [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) Klassen, die es Ihnen ermöglichen, Schatteneffekte auf einen Text, der von [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) getragen wird, anzuwenden. Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Greifen Sie auf den mit der AutoShape verbundenen TextFrame zu.
5. Setzen Sie den FillType der AutoShape auf NoFill.
6. Instanziieren Sie die OuterShadow-Klasse.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Richtung des Schattens.
9. Setzen Sie die Distanz des Schattens.
10. Setzen Sie das RectangleAlign auf TopLeft.
11. Setzen Sie die PresetColor des Schattens auf Schwarz.
12. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.

Dieser Beispielcode in Java – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:

```java
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Disable shape fill in case we want to get shadow of text
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Add outer shadow and set all necessary parameters
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Write the presentation to disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Inner Shadow Effect auf Formen anwenden**
Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse.
2. Holen Sie sich eine Referenz der Folie.
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
4. Aktivieren Sie den InnerShadowEffect.
5. Setzen Sie alle erforderlichen Parameter.
6. Setzen Sie den ColorType auf Scheme.
7. Setzen Sie die Farbschema-Farbe.
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt Ihnen, wie Sie einen Verbindungselement zwischen zwei Formen in Java hinzufügen:

```java
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Enable InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Set all necessary parameters
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Set ColorType as Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Set Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Save Presentation
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```