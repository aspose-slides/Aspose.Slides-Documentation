---
title: "Verwalten von Präsentationsformen auf Android"
linktitle: "Formenbearbeitung"
type: docs
weight: 40
url: /de/androidjava/shape-manipulations/
keywords:
- "PowerPoint-Form"
- "Präsentationsform"
- "Form auf Folie"
- "Form finden"
- "Form klonen"
- "Form entfernen"
- "Form ausblenden"
- "Formreihenfolge ändern"
- "Interop-Form-ID erhalten"
- "Alternativtext der Form"
- "Form-Layout-Formate"
- "Form als SVG"
- "Form zu SVG"
- "Form ausrichten"
- "Form spiegeln"
- "PowerPoint"
- "Präsentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Android via Java identifizieren, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Android via Java stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die am weitesten hinten liegende Form, während der letzte Index die am weitesten vorne liegende Form ist.

Dieser Artikel folgt diesem Modell. Zunächst wird erklärt, wie man eine Form zuverlässig identifiziert, dann wird gezeigt, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Formatierung auf Layout‑Ebene, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Operationen verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuanordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner abhängig davon, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlbereich von PowerPoint einsehen. Namen können bearbeitet werden und sind nicht zwingend eindeutig, daher sollten Sie ein Namenskonzept festlegen, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getAlternativeText--) ist hilfreich, wenn eine barrierefreie Beschreibung oder ein vom Autor vergebenes Tag die Form bereits identifiziert. Der Text ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit neu formuliert werden und ist ebenfalls nicht eindeutig. Verwenden Sie nicht stillschweigend bedeutungsvollen Barrierefreiheitstext als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der Form‑ID entspricht, die von PowerPoint‑Interop verwendet wird. Nutzen Sie ihn bei der Integration mit PowerPoint oder wenn Sie während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält eine eigene ID.

Die zugehörige Methode [getUniqueId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getUniqueId--) liefert einen Bezeichner mit Präsentations­umfang, ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität erforderlich ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch vorhanden ist.

Das folgende Beispiel sucht nach Namen mit einem exakten Vergleich und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, gibt der Code dieses Ergebnis aus, anstatt mit dem falschen Objekt fortzufahren.

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

Wenn eine Operation speziell für einen Formtyp ist, prüfen Sie das Interface, bevor Sie typspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt eine [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) ist.

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

## **Die Formensammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn eine Operation die Anzahl oder Reihenfolge der Formen ändert, sollten Sie nicht weiter auf zuvor ermittelte Indizes vertrauen.

### **Eine Form klonen**

[addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) erzeugt eine unabhängige Kopie und fügt sie am Ende der Ziel‑Collection hinzu. [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) erzeugt ebenfalls eine Kopie, legt sie jedoch an einem angegebenen Z‑Order‑Index ab. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel­folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone beeinflussen nicht die Ausgangsform.

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

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich Name und Alternativtext. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Element der Sammlung mit einer neuen Form‑Identität.

### **Formen entfernen**

[remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollten Sie von hinten nach vorne traversieren, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die Form am aktuellen Index, nicht ein festes Sammlungselement, und castet die Form nicht unnötig.

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

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes der nachfolgenden Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die sich auf das entfernte Objekt beziehen können; das Entfernen einer sichtbaren Form kann mehr verändern als nur das Aussehen der Folie.

### **Eine Form ausblenden**

Setzt man [Hidden](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) auf `true`, bleibt die Form in der Sammlung, erscheint jedoch nicht in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für den Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden ist kein Löschen und keine Sicherheitsmaßnahme. Das Objekt kann weiterhin gefunden und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Die Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [reorder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verschiebt eine bestehende Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `size() - 1` ist vorne.

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

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Stimmen Sie die Z‑Reihenfolge erst nach dem Hinzufügen oder Klonen aller zugehörigen Formen ab, da diese Operationen neue Elemente in die Sammlung einfügen bzw. anfügen und die beabsichtigte Stapelung verändern können.

## **Formen auf Layout‑Folien untersuchen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen eigene Formensammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Untersuchen Sie Layout‑Formen, wenn Sie die von einem Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getFillFormat--) und das [LineFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getLineFormat--) aus, ohne anzunehmen, dass jede Form eine `AutoShape` ist.

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

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, prüfen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

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

Die Methode [SlideUtil.alignShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hat Überladungen, die entweder alle Formen oder ausgewählte Sammlungsindizes ausrichten. [ShapesAlignmentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapesalignmenttype/) gibt die Kante, die Mittellinie oder den Verteilungsmodus an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

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

Ausrichten ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genug Formen zum Definieren von Abständen braucht. Berechnen Sie die Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre `getFlipH`‑ und `getFlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie und `NotDefined` bewahrt den nicht definierten/Standard‑Zustand.

Die Eingabe‑Präsentation unten enthält eine nicht gespiegelt­e Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel bewahrt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) den gesamten Frame überschreibt.

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

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Drehung erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Sammlung sich nicht ändert, bevor der Index verwendet wird. Bevorzugen Sie ein validiertes `Name`‑ oder `AlternativeText`‑Konzept für erstellte Vorlagen oder `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`addClone` fügt den Klon am Ende der Sammlung hinzu, was die vorderste Position in der Z‑Reihenfolge bedeutet. Verwenden Sie `insertClone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.