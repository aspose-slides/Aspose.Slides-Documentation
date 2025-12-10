---
title: Präsentationsthemen in Java verwalten
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
- Zusätzliche Palette
- Themenschrift
- Themenstil
- Themeneffekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Java erstellen, anpassen und PowerPoint-Dateien mit einheitlicher Markenidentität konvertieren."
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen ein bestimmtes Set visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/java/powerpoint-fonts/), [Hintergrundstile](/slides/de/java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Themefarbe ändern**

Ein PowerPoint-Thema verwendet ein bestimmtes Set von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themefarbe zu ermöglichen, stellt Aspose.Slides Werte aus der [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor)-Aufzählung bereit.

Dieser Java-Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:
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


Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themefarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanztransformationen auf die Haupt-Themefarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Themefarben dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Haupt-Themefarben

**2** - Farben aus der zusätzlichen Palette.

Dieser Java-Code demonstriert einen Vorgang, bei dem zusätzliche Palettenfarben aus der Haupt-Themefarbe gewonnen und anschließend in Formen verwendet werden:
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


## **Theme‑Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** - Fließtextschrift Latin (Minor Latin Font)
* **+mj-lt** - Überschriftenschrift Latin (Major Latin Font)
* **+mn-ea** - Fließtextschrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Überschriftenschrift Ostasiatisch (Major East Asian Font)

Dieser Java-Code zeigt, wie Sie die Latin‑Schrift einem Theme‑Element zuweisen:
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


Dieser Java-Code zeigt, wie Sie die Präsentations‑Theme‑Schrift ändern:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich die [PowerPoint‑Schriften](/slides/de/java/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Theme‑Hintergrundstil ändern**

Standardmäßig liefert die PowerPoint‑App 12 vordefinierte Hintergründe, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen Java-Code ausführen, um die Anzahl vordefinierter Hintergründe in der Präsentation zu ermitteln:
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

Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) der Klasse [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 

{{% /alert %}} 

Dieser Java-Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Index‑Hinweis**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 

Vielleicht möchten Sie sich den [PowerPoint‑Hintergrund](/slides/de/java/presentation-background/) ansehen.

{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält in der Regel 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)) der Klasse [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) können Sie die Elemente in einem Theme ändern (noch flexibler als die Optionen in PowerPoint).

Dieser Java-Code zeigt, wie Sie einen Theme‑Effekt ändern, indem Sie Teile von Elementen anpassen:
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

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne das Master‑Theme zu ändern?**

Ja. Aspose.Slides unterstützt Theme‑Überschreibungen auf Folienebene, sodass Sie ein lokales Theme nur auf dieser Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/)).

**Was ist der sicherste Weg, ein Theme von einer Präsentation zur anderen zu übertragen?**

[Klone Folien](/slides/de/java/clone-slides/) zusammen mit ihrem Master in die Zieldatei. Dadurch bleiben der ursprüngliche Master, Layouts und das zugehörige Theme erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die [\"effektiven\" Ansichten](/slides/de/java/shape-effective-properties/) der API für Theme/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie alle lokalen Überschreibungen angewendet wurden.