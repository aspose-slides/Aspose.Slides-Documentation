---
title: Verwalten von Präsentationsdesigns in JavaScript
linktitle: Präsentationsdesign
type: docs
weight: 10
url: /de/nodejs-java/presentation-theme/
keywords:
- PowerPoint-Design
- Präsentationsdesign
- Folien-Design
- Design festlegen
- Design ändern
- Design verwalten
- Designfarbe
- zusätzliche Palette
- Designschriftart
- Designstil
- Designeffekt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Präsentationsdesigns in JavaScript mit Aspose.Slides für Node.js, um PowerPoint-Dateien mit einheitlicher Markenführung zu erstellen, anzupassen und zu konvertieren."
---
Ein Präsentationsdesign definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsdesign auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Design aus Farben, [Schriften](/slides/de/nodejs-java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/nodejs-java/presentation-background/) und Effekten.

![Themenbestandteile](theme-constituents.png)

## **Designfarbe ändern**

Ein PowerPoint-Design verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Design anwenden. Um ein neues Designfarb auswählen zu ermöglichen, stellt Aspose.Slides Werte aus der [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SchemeColor) Aufzählung bereit.

Dieser JavaScript-Code zeigt, wie Sie die Akzentfarbe für ein Design ändern:

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

Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ursprünglichen Operation) zu. Anschließend ändern wir die Farbe im Design:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Designfarbe aus zusätzlicher Palette setzen**

Wenn Sie Luminanztransformationen auf die Hauptdesignfarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Designfarben dann setzen und abrufen.

![Farben der zusätzlichen Palette](additional-palette-colors.png)

**1** – Hauptdesignfarben  
**2** – Farben aus der zusätzlichen Palette.

Dieser JavaScript-Code demonstriert eine Operation, bei der Farben der zusätzlichen Palette aus der Hauptdesignfarbe gewonnen und anschließend in Formen verwendet werden:

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

### **`SchemeColor` auf `ColorScheme`-Farben abbilden**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Designfarbwerte enthält:

`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings liefert `Presentation.getMasterTheme().getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) , das die entsprechenden Farben wie folgt bereitstellt:

`Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Designfarbplätze und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Umwandlung zwischen `Text`/`Background` und `Dark`/`Light`. Es handelt sich lediglich um alternative Bezeichnungen für dieselben Designfarben.

Dieser Benennungsunterschied stammt aus der Terminologie von Microsoft Office. Ältere Office-Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI-Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Designschriftart ändern**

Um die Auswahl von Schriften für Designs und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** – Körper‑Schriftart Latin (Minor Latin Font)
* **+mj-lt** – Überschriftschrift Latin (Major Latin Font)
* **+mn-ea** – Körper‑Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Körper‑Schriftart Ostasiatisch (Major East Asian Font)

Dieser JavaScript-Code zeigt, wie Sie die Latin‑Schrift einer Designelement zuweisen:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Dieser JavaScript-Code zeigt, wie Sie die Präsentationsdesignschriftart ändern:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Sie möchten vielleicht [PowerPoint‑Schriften](/slides/de/nodejs-java/powerpoint-fonts/) sehen. 
{{% /alert %}}

## **Design‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint-App 12 vordefinierte Hintergründe bereit, aber in einer typischen Präsentation werden nur 3 dieser 12 Hintergründe gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in der PowerPoint-App diesen JavaScript-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

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
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint-Design hinzufügen oder darauf zugreifen. 
{{% /alert %}} 

Dieser JavaScript-Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index‑Leitfaden**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Sie möchten vielleicht [PowerPoint‑Hintergrund](/slides/de/nodejs-java/presentation-background/) sehen. 
{{% /alert %}}

## **Design‑Effekt ändern**

Ein PowerPoint-Design enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten „subtle“, „moderate“ und „intense“ kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/FormatScheme) können Sie die Elemente in einem Design ändern (noch flexibler als die Optionen in PowerPoint).

Dieser JavaScript-Code zeigt, wie Sie einen Design‑Effekt ändern, indem Sie Teile von Elementen verändern:

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

**Kann ich ein Design auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Aspose.Slides unterstützt Design‑Überschreibungen auf Folienebene, sodass Sie ein lokales Design nur auf dieser Folie anwenden können, während das Master‑Design unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidethememanager/)).

**Was ist der sicherste Weg, ein Design von einer Präsentation zur anderen zu übertragen?**

[Folien klonen](/slides/de/nodejs-java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, Layouts und das zugehörige Design erhalten, sodass das Erscheinungsbild konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die ["effektiven" Ansichten](/slides/de/nodejs-java/shape-effective-properties/) für Design/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie etwaige lokale Überschreibungen angewendet wurden.