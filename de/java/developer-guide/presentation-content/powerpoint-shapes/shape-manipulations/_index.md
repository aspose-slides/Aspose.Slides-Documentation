---
title: Verwalten von Präsentationsformen in Java
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Alternativtext der Form
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Java identifizieren, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Java stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zuerst wird erklärt, wie man eine Form zuverlässig identifiziert, dann wird gezeigt, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑Ebene‑Formatierung, SVG‑Export, Ausrichtung und Spiegel‑Einstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Identifizieren und Finden von Formen**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner gemäß der Art und Weise, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getName--) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahl‑Bereich von PowerPoint inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention etablieren, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getAlternativeText--) ist nützlich, wenn eine Barrierefreiheits‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Er ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie keinen bedeutungsvollen Barrierefreiheits‑Text stillschweigend als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der Shape‑ID entspricht, die von PowerPoint‑Interop verwendet wird. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form eine eindeutige Referenz benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [getUniqueId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getUniqueId--)‑Methode gibt einen Bezeichner mit Präsentations‑Scope zurück, dieser ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Er sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn langfristige Identität entscheidend ist, halten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch vorhanden ist.

Das folgende Beispiel sucht nach Namen mit einem exakten Vergleich und gibt die interop‑ID im Folien‑Scope aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt weiterzumachen.

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

Wenn ein Vorgang einer bestimmten Formart zugeordnet ist, prüfen Sie das Interface, bevor Sie typ­spezifische Member verwenden. Dieses Beispiel aktualisiert Text und Alternativ‑Text nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) ist.

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

## **Formensammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge der Formen ändert, dürfen Sie nicht weiterhin auf zuvor erfasste Indizes vertrauen.

### **Form duplizieren**

[addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection‑Ende an. [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel‑Folien, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone beeinflussen nicht die Quell‑Form.

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

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativ‑Texts. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Collection‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration traversieren Sie von hinten, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die Form am aktuellen Index, nicht ein festes Collection‑Element, und wirft die Form nicht unnötig.

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

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes späterer Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen könnten; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setHidden-boolean-) auf `true` lässt die Form in der Sammlung, verhindert jedoch ihr Erscheinen in einer normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden ist weder Löschung noch Sicherheit. Das Objekt kann weiterhin von einem Benutzer oder Code entdeckt und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [reorder](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verschiebt eine bestehende Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `size() - 1` ist vorne.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Collection‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung ändern können.

## **Formen auf Layout-Folien prüfen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Prüfen Sie Layout‑Formen, wenn Sie Formatierungen verstehen oder ändern müssen, die von einem Layout bereitgestellt werden.

Das folgende Beispiel liest das [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getFillFormat--) und [LineFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getLineFormat--) jeder Layout‑Form, ohne anzunehmen, dass jede Form eine `AutoShape` ist.

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

Das Bearbeiten eines Layouts kann mehrere Folien betreffen, die es verwenden. Bevor Sie eine Layout‑Form ändern, ermitteln Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Form als SVG exportieren**

[writeAsSvg](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schreibt den gerenderten Inhalt einer Form in einen Stream. Das Ergebnis enthält die Form, nicht den gesamten Folien‑Hintergrund oder benachbarte Formen.

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

Halten Sie die Präsentation beim Rendern offen. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die Methode [SlideUtil.alignShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) überlädt entweder alle Formen oder ausgewählte Collection‑Indizes. [ShapesAlignmentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapesalignmenttype/) bestimmt die Kante, Mittellinie oder den Verteilungsmodus. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes konvertiert.

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

Ausrichtung ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen benötigt, um Abstände zu definieren. Berechnen Sie die Indizes erneut, wenn Sie die Sammlung vor dem Aufruf der Methode modifizieren.

## **Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre `getFlipH`‑ und `getFlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/java/com.aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` behält den undefinierten/Standard‑Zustand bei.

Die untenstehende Eingabe‑Präsentation enthält eine nicht gespiegelte Form.

![The shape before flipping](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) den gesamten Frame ersetzt.

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

**Soll ich einen Collection‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Collection vor der Verwendung des Index nicht geändert wird. Bevorzugen Sie ein geprüftes `Name`‑ oder `AlternativeText`‑Konzept für erstellte Vorlagen oder `OfficeInteropShapeId` für slide‑bezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Collection am selben Index. Sie kann gefunden, neu sortiert, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`addClone` hängt den Klon an das Ende der Collection an, das die Vorderseite der Z‑Reihenfolge ist. Verwenden Sie `insertClone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.