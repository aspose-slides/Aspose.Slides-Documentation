---
title: Verwalten von Präsentationsthemen in Java
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/java/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- Themenfarbe
- zusätzliche Palette
- Themen-Schrift
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Java erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenidentität konvertieren."
---
Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Thema‑Farbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themfarbe zu ermöglichen, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/SchemeColor) bereit.

Dieser Java‑Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:

```java
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
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Um den Farbwechsel weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus dem ersten Vorgang) zu. Anschließend ändern wir die Farbe im Thema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Die neue Farbe wird automatisch auf beiden Elementen angewendet.

### **Thema‑Farbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanztransformationen auf die Hauptthemenfarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Themenfarben dann festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemenfarben

**2** - Farben aus der zusätzlichen Palette.

Dieser Java‑Code demonstriert einen Vorgang, bei dem Farben der zusätzlichen Palette aus der Hauptthemenfarbe gewonnen und anschließend in Formen verwendet werden:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akzent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akzent 4, Aufgehellt 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, Aufgehellt 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, Aufgehellt 40%
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` auf `IColorScheme`‑Farben abbilden**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) arbeiten, fällt Ihnen vielleicht auf, dass es die folgenden Themenfarbwerte enthält:

`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings gibt `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/) zurück, das die entsprechenden Farben wie folgt bereitstellt:

`Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themenfarbplätze und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Konvertierung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Bezeichnungen für dieselben Themenfarben.

Diese Benennungsunterschiede stammen aus der Microsoft‑Office‑Terminologie. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Thema‑Schrift ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Kennungen (ähnlich denen in PowerPoint):

* **+mn-lt** – Textschrift Latein (Minor Latin Font)
* **+mj-lt** – Überschriftschrift Latein (Major Latin Font)
* **+mn-ea** – Textschrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Überschriftschrift Ostasiatisch (Major East Asian Font)

Dieser Java‑Code zeigt, wie Sie die lateinische Schrift einem Thema‑Element zuweisen:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Dieser Java‑Code zeigt, wie Sie die Präsentationsthema‑Schrift ändern:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint-Schriften](/slides/de/java/powerpoint-fonts/) sehen.
{{% /alert %}}

## **Thema‑Hintergrundstil ändern**

Standardmäßig bietet die PowerPoint‑App 12 vordefinierte Hintergründe, aber in einer typischen Präsentation werden nur 3 dieser 12 Hintergründe gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen Java‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen. 
{{% /alert %}} 

Dieser Java‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index‑Hinweis**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint‑Hintergrund](/slides/de/java/presentation-background/) sehen.
{{% /alert %}}

## **Thema‑Effekt ändern**

Ein PowerPoint‑Thema enthält in der Regel 3 Werte für jedes Stilmuster. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme#getEffectStyles--)) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/FormatScheme) können Sie die Elemente in einem Thema ändern (noch flexibler als die Optionen in PowerPoint).

Dieser Java‑Code zeigt, wie Sie einen Thema‑Effekt ändern, indem Sie Teile von Elementen anpassen:

```java
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

Die daraus resultierenden Änderungen in Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne das Master‑Thema zu ändern?**

Ja. Aspose.Slides unterstützt thema‑bezogene Überschreibungen auf Folienebene, sodass Sie ein lokales Thema nur für diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidethememanager/)).

**Was ist der sicherste Weg, ein Thema von einer Präsentation zu einer anderen zu übertragen?**

[Folien klonen](/slides/de/java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch werden der ursprüngliche Master, Layouts und das zugehörige Thema erhalten, sodass das Erscheinungsbild konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die ['effektiven' Ansichten](/slides/de/java/shape-effective-properties/) der API für Thema/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften nach Anwendung des Masters sowie aller lokalen Überschreibungen zurück.