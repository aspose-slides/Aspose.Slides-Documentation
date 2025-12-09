---
title: Präsentationsthema
type: docs
weight: 10
url: /de/nodejs-java/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js über Java"
description: "PowerPoint-Präsentationsthema in JavaScript"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/nodejs-java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/nodejs-java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Damit Sie eine neue Themafarbe auswählen können, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor) bereit.

Dieser JavaScript‑Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


So können Sie den effektiven Wert der resultierenden Farbe bestimmen:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Um den Farbwechsel weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Dann ändern wir die Farbe im Thema:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themafarbe aus zusätzlicher Palette festlegen**

Wenn Sie Luminanztransformationen auf die Hauptthemafarbe(1) anwenden, entstehen Farben aus der zusätzlichen Palette(2). Sie können diese Themenfarben dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hauptthemafarben  
**2** – Farben aus der zusätzlichen Palette.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem zusätzliche Palettenfarben aus der Hauptthemafarbe gewonnen und dann in Formen verwendet werden:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Akzent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Akzent 4, Heller 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Akzent 4, Heller 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Akzent 4, Heller 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Akzent 4, Dunkler 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Akzent 4, Dunkler 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Thema-Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** – Körper‑Schriftart Latein (Minor Latin Font)
* **+mj-lt** – Überschriften‑Schriftart Latein (Major Latin Font)
* **+mn-ea** – Körper‑Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Körper‑Schriftart Ostasiatisch (Major East Asian Font)

Dieser JavaScript‑Code zeigt, wie Sie die lateinische Schrift einer Themenelement zuweisen:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


Dieser JavaScript‑Code zeigt, wie Sie die Präsentationsthema‑Schriftart ändern:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Sie können sich die [PowerPoint-Schriften](/slides/de/nodejs-java/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Thema-Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen jedoch nur 3 in einer typischen Präsentation gespeichert werden.

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen JavaScript‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen.
{{% /alert %}} 

Dieser JavaScript‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Index‑Hinweis**: 0 bedeutet keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Sie können sich [PowerPoint-Hintergrund](/slides/de/nodejs-java/presentation-background/) ansehen.
{{% /alert %}}

## **Thema‑Effekt ändern**

Ein PowerPoint‑Thema enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu 3 Effekten kombiniert: subtil, moderat und intensiv. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) können Sie die Elemente in einem Thema ändern (noch flexibler als die Optionen in PowerPoint).

Dieser JavaScript‑Code zeigt, wie Sie einen Themeneffekt ändern, indem Sie Teile von Elementen anpassen:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Die resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne die Masterfolie zu ändern?**

Ja. Aspose.Slides unterstützt thema‑spezifische Überschreibungen auf Folienebene, sodass Sie ein lokales Thema nur auf diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)).

**Was ist der sicherste Weg, ein Thema von einer Präsentation zur anderen zu übertragen?**

[Folien klonen](/slides/de/nodejs-java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben das ursprüngliche Master‑Layout, die Layouts und das zugehörige Thema erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die "effektiven" Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die "effektiven" Ansichten der API [/slides/nodejs-java/shape-effective-properties/] für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem das Master‑Thema sowie etwaige lokale Überschreibungen angewendet wurden.