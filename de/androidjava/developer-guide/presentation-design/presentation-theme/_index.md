---
title: Präsentationsthemen auf Android verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/androidjava/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- Themenfarbe
- Zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Master‑Präsentationsthemen in Aspose.Slides für Android über Java erstellen, anpassen und PowerPoint‑Dateien mit konsistenter Markenidentität konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriftarten](/slides/de/androidjava/powerpoint-fonts/), [Hintergrundformaten](/slides/de/androidjava/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Farbe des Themas ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie sie ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themafarbe zu ermöglichen, stellt Aspose.Slides Werte in der [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SchemeColor)-Aufzählung bereit.

Dieser Java‑Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:

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

So können Sie den effektiven Wert der resultierenden Farbe bestimmen:

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

Um die Farbwechsel‑Operation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themenfarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Hauptthemenfarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Themenfarben können Sie anschließend festlegen und abrufen. 

![additional-palette-colors](additional-palette-colors.png)

**1** – Hauptthemenfarben

**2** – Farben aus der zusätzlichen Palette.

Dieser Java‑Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Hauptthemenfarbe gewonnen und anschließend in Formen verwendet werden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akzent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akzent 4, Heller 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, Heller 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, Heller 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akzent 4, Dunkler 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akzent 4, Dunkler 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Zuordnung von `SchemeColor` zu `IColorScheme`‑Farben**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass sie die folgenden Themenfarbwerte enthält:

`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings gibt `Presentation.getMasterTheme().getColorScheme()` ein [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) zurück, das die entsprechenden Farben wie folgt bereitstellt:

`Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themenfarbplätze und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Konvertierung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Bezeichnungen für dieselben Themenfarben.

Diese Benennungsunterschiede stammen aus der Microsoft‑Office‑Terminologie. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Schriftart des Themas ändern**

Um Ihnen die Auswahl von Schriftarten für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese Sonderkennungen (ähnlich denen in PowerPoint):

* **+mn-lt** – Körperschrift Latein (Minor Latin Font)
* **+mj-lt** – Überschrift‑schrift Latein (Major Latin Font)
* **+mn-ea** – Körper‑schrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Überschrift‑schrift Ostasiatisch (Major East Asian Font)

Dieser Java‑Code zeigt, wie Sie die lateinische Schrift einem Themeelement zuweisen:

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

Dieser Java‑Code zeigt, wie Sie die Schrift des Präsentationsthemas ändern:

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
Vielleicht möchten Sie sich die [PowerPoint-Schriftarten](/slides/de/androidjava/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Hintergrundformat des Themas ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, aber in einer typischen Präsentation werden nur 3 dieser 12 Hintergründe gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen Java‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

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
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen.
{{% /alert %}} 

Dieser Java‑Code zeigt, wie Sie den Hintergrund einer Präsentation festlegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Index‑Hinweis**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="info" title="TIP" %}} 
Vielleicht möchten Sie sich den [PowerPoint‑Hintergrund](/slides/de/androidjava/presentation-background/) ansehen.
{{% /alert %}}

## **Themen‑Effekt ändern**

Ein PowerPoint‑Thema enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel sieht das Ergebnis aus, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FormatScheme) können Sie die Elemente eines Themas ändern (sogar flexibler als die Optionen in PowerPoint).

Dieser Java‑Code zeigt, wie Sie einen Themen‑Effekt ändern, indem Sie Teile von Elementen anpassen:

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

Die resultierenden Änderungen in Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?

Ja. Aspose.Slides unterstützt Folien‑Ebene‑Themen‑Überschreibungen, sodass Sie ein lokales Thema nur für diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidethememanager/)).

### Was ist die sicherste Methode, ein Thema von einer Präsentation in eine andere zu übertragen?

[Folien klonen](/slides/de/androidjava/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben Master, Layouts und das zugehörige Thema erhalten, sodass das Erscheinungsbild konsistent bleibt.

### Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?

Verwenden Sie die API‑„[effektiven](/slides/de/androidjava/shape-effective-properties/)“‑Ansichten für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften nach Anwendung des Masters und etwaiger lokaler Überschreibungen zurück.