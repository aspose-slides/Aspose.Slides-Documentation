---
title: "Verwalten von Präsentationsthemen in Java"
linktitle: "Präsentationsthema"
type: docs
weight: 10
url: /de/java/presentation-theme/
keywords:
  - "PowerPoint-Thema"
  - "Präsentationsthema"
  - "Folienthema"
  - "Theme festlegen"
  - "Theme ändern"
  - "Theme verwalten"
  - "Theme-Farbe"
  - "Zusätzliche Palette"
  - "Theme-Schriftart"
  - "Theme-Stil"
  - "Theme-Effekt"
  - "PowerPoint"
  - "OpenDocument"
  - "Präsentation"
  - "Java"
  - "Aspose.Slides"
description: "Master-Präsentationsthemen in Aspose.Slides für Java, um PowerPoint-Dateien mit konsistenter Markenidentität zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Theme‑Farbe ändern**

Ein PowerPoint‑Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Damit Sie eine neue Theme‑Farbe auswählen können, stellt Aspose.Slides Werte aus der [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/SchemeColor)‑Aufzählung bereit.

Dieser Java‑Code zeigt, wie Sie die Akzentfarbe für ein Theme ändern:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Sie können den effektiven Wert der resultierenden Farbe auf diese Weise bestimmen:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Um die Farbänderungs‑Operation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Theme:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Theme‑Farbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Haupt‑Theme‑Farbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Theme‑Farben können Sie dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** – Haupt‑Theme‑Farben  

**2** – Farben aus der zusätzlichen Palette.

Dieser Java‑Code demonstriert eine Operation, bei der Farben der zusätzlichen Palette aus der Haupt‑Theme‑Farbe gewonnen und anschließend in Formen verwendet werden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akzent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akzent 4, 80% heller
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, 60% heller
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, 40% heller
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akzent 4, 25% dunkler
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akzent 4, 50% dunkler
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Abbildung von `SchemeColor` auf `IColorScheme`‑Farben**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Theme‑Farbwerte enthält:

`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings liefert `Presentation.getMasterTheme().getColorScheme()` ein [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/), das die entsprechenden Farben als Folgende bereitstellt:

`Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Theme‑Farbplätze und die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Umwandlung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Bezeichnungen für dieselben Theme‑Farben.

Diese Namensunterschiede stammen aus der Microsoft‑Office‑Terminologie. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Theme‑Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themes und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** – Body Font Latin (Minor Latin Font)
* **+mj-lt** – Heading Font Latin (Major Latin Font)
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)
* **+mj-ea** – Body Font East Asian (Major East Asian Font)

Dieser Java‑Code zeigt, wie Sie die lateinische Schrift einer Theme‑Komponente zuweisen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Dieser Java‑Code zeigt, wie Sie die Präsentations‑Theme‑Schriftart ändern:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="info" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint‑Schriften](/slides/de/java/powerpoint-fonts/). 
{{% /alert %}}

## **Theme‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen in einer typischen Präsentation nur 3 dieser 12 Hintergründe gespeichert werden.

![todo:image_alt_text](presentation-design_8.png)

Wenn Sie beispielsweise eine Präsentation in der PowerPoint‑App speichern, können Sie diesen Java‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Durch die Verwendung der [BackgroundFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--)‑Eigenschaft der [FormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme)‑Klasse können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}} 

Dieser Java‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Index‑Leitfaden**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="info" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint‑Hintergrund](/slides/de/java/presentation-background/). 
{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten kombiniert: dezent, moderat und intensiv. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getEffectStyles--)) der [FormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme)‑Klasse können Sie die Elemente eines Themes ändern (noch flexibler als die Optionen in PowerPoint).

Dieser Java‑Code zeigt, wie Sie einen Theme‑Effekt ändern, indem Sie Teile von Elementen anpassen:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Die resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kann ich ein Theme auf eine einzelne Folie anwenden, ohne das Master‑Theme zu ändern?

Ja. Aspose.Slides unterstützt themenbezogene Überschreibungen auf Folien‑Ebene, sodass Sie ein lokales Theme nur auf dieser Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidethememanager/)).

### Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übernehmen?

[Clone slides](/slides/de/java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation übernehmen. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Theme erhalten, sodass das Aussehen konsistent bleibt.

### Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?

Verwenden Sie die API‑„["effective"]“-Ansichten](/slides/de/java/shape-effective-properties/) für Theme/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem das Master‑Theme sowie etwaige lokale Überschreibungen angewendet wurden.