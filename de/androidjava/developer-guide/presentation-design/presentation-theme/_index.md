---
title: Präsentationsthema
type: docs
weight: 10
url: /de/androidjava/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "PowerPoint-Präsentationsthema in Java"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz von visuellen Elementen und deren Eigenschaften aus.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/androidjava/powerpoint-fonts/), [Hintergrundstilen](/slides/de/androidjava/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Themenfarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie die Farben ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themenfarbe zu ermöglichen, stellt Aspose.Slides Werte unter der [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor) Enumeration bereit.

Dieser Java-Code zeigt Ihnen, wie Sie die Akzentfarbe für ein Thema ändern:

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

System.out.println(String.format("Farbe [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Um den Vorgang der Farbänderung weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus dem vorherigen Vorgang) zu. Dann ändern wir die Farbe im Thema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themenfarbe aus zusätzlicher Palette setzen**

Wenn Sie Helligkeitstransformationen auf die Hauptthemenfarbe(1) anwenden, werden Farben aus der zusätzlichen Palette(2) gebildet. Sie können dann diese Themenfarben festlegen und abrufen. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemenfarben

**2** - Farben aus der zusätzlichen Palette.

Dieser Java-Code demonstriert einen Vorgang, bei dem zusätzliche Palettenfarben aus der Hauptthemenfarbe abgerufen und dann in Formen verwendet werden:

```java
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Themenfont ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich wie die in PowerPoint verwendeten):

* **+mn-lt** - Schriftart für den Haupttext Latein (Minor Latin Font)
* **+mj-lt** - Schriftart für Überschriften Latein (Major Latin Font)
* **+mn-ea** - Schriftart für den Haupttext Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Schriftart für Überschriften Ostasiatisch (Major East Asian Font)

Dieser Java-Code zeigt Ihnen, wie Sie die lateinische Schriftart einem Themenelement zuordnen:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Themen-Textformat");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Dieser Java-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise die [PowerPoint-Schriften](/slides/de/androidjava/powerpoint-fonts/) sehen.

{{% /alert %}}

## **Themenhintergrundstil ändern**

Standardmäßig bietet die PowerPoint-App 12 vordefinierte Hintergründe, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Wenn Sie beispielsweise eine Präsentation in der PowerPoint-App speichern, können Sie diesen Java-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Anzahl der Hintergrundfüllstile für das Thema ist " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Durch die Verwendung der [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) Eigenschaft der [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) Klasse können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen.

{{% /alert %}} 

Dieser Java-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index-Leitfaden**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise den [PowerPoint-Hintergrund](/slides/de/androidjava/presentation-background/) sehen.

{{% /alert %}}

## **Themenwirkung ändern**

Ein PowerPoint-Thema enthält in der Regel 3 Werte für jedes Stil-Array. Diese Arrays werden in diese 3 Effekte kombiniert: subtil, moderat und intensiv. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) aus der [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) Klasse können Sie die Elemente in einem Thema (sogar flexibler als die Optionen in PowerPoint) ändern.

Dieser Java-Code zeigt Ihnen, wie Sie einen Themeneffekt ändern, indem Sie Teile der Elemente ändern:

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

Die resultierenden Änderungen in Füllfarbe, Fülltyp, Schattierungseffekt usw.:

![todo:image_alt_text](presentation-design_11.png)