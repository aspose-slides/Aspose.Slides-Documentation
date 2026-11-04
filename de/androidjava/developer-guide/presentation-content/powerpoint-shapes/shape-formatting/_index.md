---
title: "PowerPoint-Formen auf Android formatieren"
linktitle: "Formformatierung"
type: docs
weight: 20
url: /de/androidjava/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Kanteneffekt
- 3D-Rotationseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen auf Android mit Aspose.Slides formatieren – Füll‑, Linien‑ und Effekt‑Stile für PPT‑ und PPTX‑Dateien präzise und vollständig steuern."
---
## **Einführung**

Formatiere Formen in PowerPoint, indem du ihre Konturen, Füllungen und Effekte anpasst. Aspose.Slides für Android via Java ermöglicht es dir, diese Einstellungen programmgesteuert zu steuern, einschließlich Transparenz, Drehung und 3D‑Formatierung.

![Formformatierungsoptionen in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für Android via Java stellt Schnittstellen und Methoden bereit, die es ermöglichen, Formen mit denselben Optionen zu formatieren, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Verwenden Sie [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) , um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht gefülltes Rechteck mit einer blauen, gestrichelten Kontur. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) wählt eine dick‑dünn Verbundlinie, während [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) die Breite auf 7 Punkte setzt und [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) das Strichmuster auswählt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

### **Benutzerdefinierte Strichmuster für Linien festlegen**

Verwenden Sie [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) , wenn vordefinierte Linienstile nicht die benötigten Strichlängen und Lücken bereitstellen, beispielsweise für Marken‑Konturen oder technische Diagramme. Das Zuweisen eines Musters ändert den Linienstil automatisch zu [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Array‑Einträge wechseln abwechselnd zwischen Strich‑ und Lückenlängen, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `{ 4, 2 }` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkte‑Strich gefolgt von einer 6‑Punkte‑Lücke. Verwenden Sie Paare endlicher, nicht‑negativer Werte, um vollständige Strich‑und‑Lückensegmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite und verdoppelt damit sowohl Strich‑ als auch Längen. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Setze die letzte Linie auf einen durchgezogenen Stil zurück.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um stattdessen zu einem vordefinierten Strichstil zurückzukehren, übergeben Sie [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) an [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Der ausgewählte Stil kontrolliert das Aussehen der Linie.

Das Ergebnis in PowerPoint, von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie mit dem ersten Muster und eine Konturlinie in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwenden Sie [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) , um die Enden einer offenen Linie festzulegen. Die Klasse [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) bietet drei explizite End‑Stile:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Ein halbkreisförmiges Ende erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.
- `Square`: Ein quadratisches Ende erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.

Die Klasse enthält außerdem `NotDefined`, was bedeutet, dass kein End‑Stil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungs‑Stilen, die Ecken zwischen Linienstücken steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) und [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-), sodass nur die End‑Formen verglichen werden.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint, von oben nach unten: **Flat**, **Round** und **Square**.

![Flache, runde und quadratische Enden auf identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizzen‑Effekte auf Formlinien anwenden**

Ein Skizzen‑Effekt lässt eine Formlinie handgezeichnet wirken. Verwenden Sie [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) , um die Linieneinstellungen zu erhalten, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) , um die Skizzen‑Einstellungen zu erhalten, und [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) , um einen Wert aus der Klasse [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) auszuwählen.

Der folgende Java‑Code zeigt, wie ein [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)‑Effekt angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) entfernt wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) zurückgegebene Wert repräsentiert die direkt der Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) , greifen Sie auf [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) zu und lesen Sie [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) . Der effektive Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird. Dieses Beispiel benötigt eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Verbindungs‑Stile formatieren**

* Round
* Miter
* Bevel

Der Verbindungs‑Stil steuert, wie zwei Kontursegmente an einer Ecke zusammentreffen. Verwenden Sie **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen von 15 Punkten Breite. Es verwendet [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) , um die Werte miter, bevel und round der Klasse [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) jeweils anzuwenden und zu vergleichen, wie die Ecken gezeichnet werden.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Miter‑Verbindungen an scharfen Ecken begrenzen**

Verwenden Sie [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) zusammen mit [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) auf [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) , um zu begrenzen, wie weit eine scharfe Ecke ausgedehnt werden kann.

Der Grenzwert ist das Verhältnis des Abstandes zwischen innerer und äußerer Ecke des Verbindungs‑\nsegments zur Linienbreite. Ein Wert von `8` erlaubt beispielsweise eine Miter‑Länge von bis zu achtfacher Linienbreite; es handelt sich nicht um eine Messung in Punkten. Überschreitet die Ecke den Grenzwert, verwendet PowerPoint an dieser Stelle eine abgeschrägte Verbindung. Ein größerer Grenzwert erlaubt spitzere Punkte. Die Einstellung wirkt nur auf Miter‑Verbindungen und hat keinen sichtbaren Effekt, solange die Ecke innerhalb beider Grenzen bleibt.

Dieses Beispiel erstellt zwei identische, nicht gefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, wodurch das Verhältnis von Miter‑Länge zu Linienbreite an der oberen Ecke etwa `4.12` beträgt. Folglich wird PowerPoint die linke Spitze abschrägen und die rechte Spitze beibehalten.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint: **Miter‑Grenzwert 2** links und **Miter‑Grenzwert 8** rechts.

![Ein abgeschrägter Scheitel mit Miter‑Limit 2 und ein spitzer Scheitel mit Miter‑Limit 8 in PowerPoint](miter-limits.png)

## **Verlaufsfüllung**

Eine Verlaufsfüllung mischt Farben über eine Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf im Winkel von 45 Grad von Rot nach Lila mithilfe von [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Die Methode [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) legt die Farb­stopps bei 0 und 1, also am Anfang und Ende des Farbverlaufs, fest. Das Löschen der vorhandenen Stopps stellt sicher, dass nur diese beiden Farben verwendet werden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Renderstil auswählen, ohne die im Dokument gespeicherte Verlauf‑Füllung zu ändern.

### **Den Winkel des linearen Farbverlaufs festlegen**

Verwenden Sie [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) , um die Orientierung einer [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)‑Füllung zu steuern. Der Winkel wird in Grad gemessen und steigt im Uhrzeigersinn: `0` läuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteile von Grad werden unterstützt. Endliche Winkel außerhalb von `[0, 360)` werden zu einer Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen Rot‑, Grün‑ und Blau‑Stopps an den Positionen `0`, `0.5` und `1`. Die Skalierung ist deaktiviert, damit der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts sind in der ersten Zeile `0`, `45` und `90`, in der zweiten Zeile `135`, `180` und `270`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint:

![Lineare Verläufe bei 0°, 45° und 90° in der oberen Reihe sowie 135°, 180° und 270° in der unteren Reihe](linear-gradient-angles.png)

### **Einen linearen Farbverlauf mit der Form skalieren**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Setzen Sie ihn explizit auf `False`, um den geometrischen Verlauf‑Winkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True`, um den Verlauf mit der Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann der sichtbare Winkel von dem zugewiesenen Winkel abweichen, wenn die Form nicht quadratisch ist.

Das folgende Beispiel verwendet einen Winkel von `45` Grad und dieselben Farb‑Stopps wie im Winkel‑Vergleich. Die linke Spalte verwendet `False`; die rechte Spalte verwendet `True`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufseinstellungen zu ändern.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint, links ohne Skalierung und rechts mit Skalierung:

![Breite und hohe Rechtecke mit 45‑Grad‑Verlauf, Vergleich LinearGradientScaled False links und True rechts](linear-gradient-scaling.png)

Bei deaktivierter Skalierung behalten die diagonalen Farb­bänder in beiden Rechtecken dieselbe Ausrichtung. Bei aktivierter Skalierung strecken sich die Bänder mit den Proportionen der Form. Das hilft, den Verlauf einer Vorlage zu reproduzieren, wenn eine Form auf eine andere Größe angepasst wird. Bei einem Quadrat ändert das Aktivieren der Skalierung das Aussehen dieses `45`‑Grad‑Verlaufs nicht.

Der Winkel‑ und Skalierungs‑Einstellung gelten nur für lineare Verläufe. Sie steuern nicht [GradientShape.Radial] oder [GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)‑Füllungen.

### **Winkel mit Verlauf‑Richtung kombinieren**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) wählt einen Verlaufs‑Stil aus der Klasse [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) aus; er ersetzt keinen numerischen Winkel. Bei einem linearen Verlauf können die Eck‑Stile den Bereich verändern, über den die Farben verteilt werden, ohne den über [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) zugewiesenen Winkel zu ändern. Lassen Sie die Richtung unverändert, wenn Sie Winkel oder Skalierung vergleichen.

Das folgende Beispiel wendet dieselben Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen identisch aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Musterfüllung**

Eine Musterfüllung wendet ein zweifarbiges Design, wie Punkte, Streifen oder Karos, an. Dieses Beispiel verwendet [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) , um ein Gitter‑Muster auszuwählen. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) liefert den hellgrauen Hintergrund, und [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) liefert die gelbe Musterfarbe.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und verwendet [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) , um es in die Bildsammlung der Präsentation zu laden. Durch Setzen von [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) auf den Kachel‑Modus wird das Bild im Rechteck wiederholt. Das hier verwendete Quellbild ist unten zu sehen:

![Das Lotus‑Bild](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild als Textur kacheln**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Legt den Bildfüllungs‑Modus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Steuert, ob die Kachel horizontal, vertikal oder in beiden Richtungen gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) so, dass es bei 50 % seiner Originalgröße wiederholt wird. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beiden Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung gibt einer Form eine einheitliche Farbe. Dieses Beispiel verwendet [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) , um den einfarbigen Füllungs‑Modus auszuwählen und weist Gelb über [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) zu, bevor das Rechteck in einer Präsentation gespeichert wird.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Folienhintergrund als Formfüllung verwenden**

Verwenden Sie [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) , wenn eine Form dem Folienhintergrund entsprechen soll, zum Beispiel in einer Präsentations‑Vorlage. Verwenden Sie zuerst [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) mit [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) , um jegliche explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer Stil‑Füllung. Das Setzen des Flags allein entfernt keine bereits vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): Die Hintergrund‑Füllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während keine Füllung diese Objekte sichtbar lässt. Ein Verlauf bleibt dabei an der Folie ausgerichtet und startet nicht innerhalb jeder Form neu.

Das folgende Beispiel erzeugt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert ein magentafarbenes Band hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere Rechteck hat keine Füllung, und das rechte Rechteck wechselt von Hintergrund‑Füllung zu einer expliziten orangefarbenen Füllung.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Den Verlauf vom Master erben.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Dieses Objekt zuerst hinzufügen, damit es hinter den Rechtecken erscheint.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Hintergrundfüllung deaktivieren, bevor eine explizite Füllung angewendet wird.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis, von links nach rechts: **background fill**, **no fill** und **explicit fill**. Das magentafarbene Band wird von den linken und rechten Rechtecken verdeckt, bleibt jedoch durch das mittlere Rechteck sichtbar.

![Hintergrundfüllung, keine Füllung und explizite orange Füllung über einem magentafarbenen Band](background-fill.png)

Das gleiche Verhalten gilt für einen direkt auf der Folie definierten Hintergrund oder einen von einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folien‑Hintergrund; das Beispiel lässt sowohl den Folien‑ als auch den Layout‑Hintergrund undefiniert, sodass der Master ihn bereitstellt.

## **Transparenz festlegen**

Bei einer einfarbigen Füllung steuert die Alpha‑Komponente der Farbe die Undurchsichtigkeit: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent wird, sodass das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) zugewiesen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Verwenden Sie [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) , um eine Form in der Folien‑Ebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) , um einer Form Tiefe und abgeflachte Kanten zu verleihen. Dieses Beispiel erstellt eine grüne Ellipse mit orangefarbener Kontur, verwendet [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) , um die Tiefe auf 4 Punkte zu setzen, und wendet über [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) eine kreisförmige obere Abschrägung mit Breite und Höhe von 6 Punkten an. Eine frontale orthografische Kamera und Drei-Punkt‑Beleuchtung machen die Abschrägung sichtbar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Kanteneffekt](3D-bevel-effect.png)

## **3D‑Rotations‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch ihre Kamera‑Einstellungen gesteuert. Dieses Beispiel verwendet [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) mit Breitengrad‑, Längengrad‑ und Revolutions‑Winkeln von 40, 35 bzw. 20 Grad. Es wählt über [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) eine isometrische Kamera und über [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) eine ausgewogene Beleuchtung, bevor das formatierte Rechteck gespeichert wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Rotations‑Effekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung für Formen steuern**

Die Methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) gibt an, wie eine einzelne Form gerendert wird, wenn eine Präsentation in Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht von selbst und ändert die Füllung, Kontur oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graufärbung, `BlackWhite` verwendet nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbgebung, und `Hidden` lässt die Form im Schwarz‑weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Dieses Beispiel erstellt ein oranges Rechteck und verwendet [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) , um graue Farbgebung zu wählen. Die gespeicherte Form behält ihre orangefarbene Füllung für die normale Farbanzeige bei und fordert graue Farbgebung von Anwendungen an, die Schwarz‑weiß‑Anzeige‑Einstellungen berücksichtigen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑weiß‑Workflow verwendet es graue Farbgebung, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Vollfarbe‑Folie beibehalten und gleichzeitig ein separates Aussehen für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwenden Sie [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) , um Position, Größe und Formatierung von Folien‑Platzhaltern aus den entsprechenden Layout‑Platzhaltern wiederherzustellen. Dieses Beispiel benötigt eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie vor dem Speichern zurück. Formen ohne entsprechenden Layout‑Platzhalter werden nicht zurückgesetzt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wirkt sich die Formatierung von Formen auf die endgültige Dateigröße der Präsentation aus?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Vergleich zu eingebetteten Bildern und Medien nur wenig Daten hinzu. Bildfüllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung teilen, damit ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Format‑Eigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie ihre Stile als identisch und gruppieren Sie die Formen logisch, was das spätere Stil‑Management vereinfacht.

**Kann ich ein Set benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestalteten Formen und wenden deren Formatierung dort an, wo sie nötig ist.