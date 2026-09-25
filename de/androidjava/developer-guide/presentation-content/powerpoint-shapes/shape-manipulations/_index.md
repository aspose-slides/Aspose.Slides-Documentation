---
title: Verwalten von Präsentationsformen auf Android
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/androidjava/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID erhalten
- alternativer Text der Form
- Form-Anpassungspunkt
- vordefinierte Formanpassung
- Formgeometrie
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Android via Java identifizieren, anpassen, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Überblick**

Aspose.Slides for Android via Java stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zunächst wird erklärt, wie man eine Form zuverlässig identifiziert und vordefinierte Formanpassungspunkte ändert, danach wird gezeigt, wie man Formen dupliziert, entfernt, ausblendet und neu anordnet. Die letzten Abschnitte behandeln Layout‑Formatierung, SVG‑Export, Ausrichtung und Spiegel‑Einstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Identifizieren und Finden von Formen**

Sammlungsindizes sind praktisch beim Verarbeiten einer bekannten Datei, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner je nach Art und Pflege der Präsentation:

- [Name](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahl‑Bereich von PowerPoint inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollte eine Namenskonvention etabliert werden, wenn Code davon abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getAlternativeText--) ist nützlich, wenn eine Barrierefreiheits‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Er ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht eindeutig. Verwenden Sie keinen bedeutungsvollen Barrierefreiheits‑Text stillschweigend als Datenbank‑Schlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Verwenden Sie ihn bei der Integration mit PowerPoint oder wenn Sie während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine duplizierte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [getUniqueId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getUniqueId--)‑Methode gibt einen Bezeichner mit Präsentations‑Geltungsbereich zurück, der jedoch für Add‑Ins gedacht ist und neu zugewiesen werden kann. Er sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität erforderlich ist, halten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Für ein praktisches Beispiel zum Lesen und Aktualisieren sowohl des alternativen Text‑Titels als auch der Beschreibung siehe [Manage Alternative Text Titles and Descriptions](/slides/de/androidjava/presentation-accessibility/). Verwenden Sie alternativen Text, um die Bedeutung der Grafik für Leser zu erklären, und halten Sie ihn getrennt von Formnamen, die vom Code zum Suchen von Formen verwendet werden.

Das folgende Beispiel sucht nach Namen mit exaktem Vergleich und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage nicht die erwartete Form enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie das Interface, bevor Sie typspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und alternativen Text nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) ist.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifizieren und Ändern vordefinierter Formanpassungen**

Vordefinierte Geometrieformen können Anpassungspunkte expose, die Merkmale wie Eckgröße, Pfeil‑Proportionen oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--)‑Sammlung darauf zu. Die Sammlung wird von der Form bereitgestellt, aber jedes [IAdjustValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/) enthält einen änderbaren Wert.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungs‑Index. Durchlaufen Sie die Anpassungen und inspizieren Sie die schreibgeschützte [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getType--)‑Methode, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapeadjustmenttype/)‑Wert beschreibt, was die Anpassung steuert. Die schreibgeschützte [getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getName--)‑Methode liefert zusätzlichen Identifikations‑Informationen und ist besonders nützlich, wenn ein Preset mehr als eine Anpassung desselben semantischen Typs enthält.

Verwenden Sie die Wert‑Methode, die der Bedeutung der Anpassung entspricht:

| Anpassungstyp | Zweck | Wert zum Ändern |
|---|---|---|
| `CornerSize` | Größe der abgerundeten Ecken | [setRawValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Dicke eines Pfeilschafts | `setRawValue` |
| `ArrowheadLength` | Länge einer Pfeilspitze | `setRawValue` |
| `ArrowheadWidth` | Breite einer Pfeilspitze | `setRawValue` |
| `StartAngle` | Startwinkel eines Kreisabschnitts oder Bogens | [setAngleValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Endwinkel eines Kreisabschnitts oder Bogens | `setAngleValue` |

`getType` und `getName` geben schreibgeschützte Informationen zurück. `getRawValue` und `setRawValue` arbeiten mit einem Integer in den nativen Geometrie‑Einheiten des Presets, während `getAngleValue` und `setAngleValue` mit einem Winkel in Grad arbeiten. Zahl, Reihenfolge, Bedeutung und gültiger Wertebereich der Anpassungen hängen vom Preset‑[ShapeType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) ab. Ein für ein Preset gültiger Wert kann für ein anderes ungültig sein oder eine andere Wirkung haben.

Wenn `getType` `ShapeAdjustmentType.Custom` zurückgibt, erkennt die API keine standardmäßige semantische Bedeutung. Prüfen Sie `getName`, den Preset‑Typ und den vorhandenen Wert und lassen Sie die Anpassung unverändert, sofern die erwartete Bedeutung und der Wertebereich nicht bekannt sind. Selbst bei anerkannten Typen prüfen Sie, ob derselbe Typ mehr als einmal vorkommt, bevor Sie einen Wert auswählen. Der Artikel [Connector](/slides/de/androidjava/connector/) zeigt diese Situation mit Biege‑Anpassungen von Verbindungslinien.

Das folgende vollständige Beispiel erstellt Standard‑ und modifizierte Versionen von drei Preset‑Formen. Es durchläuft jede Anpassung, gibt deren Namen und Typ aus, ändert größenbezogene Werte über `setRawValue`, ändert Winkel über `setAngleValue` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den vier‑weg‑Pfeil und das Kuchen‑Diagramm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt Überschriften für die Standard‑ und angepassten Formspalten hinzu.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Prüfen des semantischen Typs vor einer Wertänderung macht den Code explizit hinsichtlich seiner Absicht und vermeidet Annahmen, dass ein bestimmter Sammlungs‑Index dieselbe Bedeutung bei unterschiedlichen Preset‑Formen hat.

## **Ändern der Formensammlung**

Die Methoden zum Hinzufügen, Duplizieren, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge von Formen ändert, verlassen Sie sich nicht mehr auf vor dem Vorgang erfasste Indizes.

### **Form duplizieren**

[addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection‑Ende an. [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Zielfolie, dupliziert ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem Klon beeinflussen nicht die Quellform.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Duplizieren kopiert den Inhalt und die Formatierung der Form, einschließlich Name und alternativem Text. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Collection‑Element mit einer neuen Form‑Identität.

### **Formen entfernen**

[remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration von hinten traversieren, sodass jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die Form am aktuellen Index, nicht ein festes Collection‑Element, und castet die Form nicht unnötig.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nach dem Entfernen ändern sich die Formanzahl und die Indizes späterer Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbindungslinien, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen können; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) auf `true` behält die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für den Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ausblenden ist kein Löschen oder ein Sicherheitsmechanismus. Das Objekt kann weiterhin entdeckt und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gemalt. [reorder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu duplizieren. Index `0` ist hinten; `size() - 1` ist vorne.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder dupliziert haben, da diese Vorgänge neue Collection‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung ändern können.

## **Formen in Layoutfolien prüfen**

Normale Folien, Layoutfolien und Masterfolien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Prüfen Sie Layout‑Formen, wenn Sie das von einem Layout bereitgestellte Format verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getFillFormat--) und das [LineFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getLineFormat--) ohne anzunehmen, dass jede Form ein `AutoShape` ist.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Form in SVG exportieren**

[writeAsSvg](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Halten Sie die Präsentation während des Renderns geöffnet. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die Methode [SlideUtil.alignShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) überlädt, um entweder alle Formen oder ausgewählte Collection‑Indizes auszurichten. [ShapesAlignmentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapesalignmenttype/) gibt die Kante, Mittelachse oder Verteilungs‑Modus an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ausrichten ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung benötigt normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung ausreichend Formen zur Definition des Abstands erfordert. Berechnen Sie Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode verändern.

## **Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre Werte `getFlipH` und `getFlipV` verwenden [NullableBool](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht spezifizierten/Standard‑Zustand.

Die Eingabepräsentation unten enthält eine nicht gespiegelt Form.

![The shape before flipping](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) den gesamten Frame ersetzt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Drehung unverändert bleiben.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Sollte ich einen Sammlungs‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Sammlung vor der Verwendung des Index nicht geändert wird. Bevorzugen Sie ein validiertes `Name`‑ oder `AlternativeText`‑Konzept für erstellte Vorlagen oder `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine duplizierte Form vor einer anderen Form?**

`addClone` hängt den Klon an das Ende der Sammlung, was die Vorderseite der Z‑Reihenfolge ist. Verwenden Sie `insertClone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index verwenden, um eine vordefinierte Formanpassung zu identifizieren?**

Nur nach Validierung des genauen Presets und des Sammlungs‑Layouts. Bevorzugen Sie das Durchlaufen von `IGeometryShape.getAdjustments` und das Prüfen von `IAdjustValue.getType`; verwenden Sie `IAdjustValue.getName` als zusätzliche Information, wenn derselbe semantische Typ mehr als einmal vorkommt.