---
title: Verwalten von Präsentationsformen in Java
linktitle: Formenmanipulation
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
- Form-Alternativtext
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für Java erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Alle Formen, die zu den Folien hinzugefügt werden, besitzen einen Alternativtext. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides for Java öffnen und über alle zu einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die von Ihnen gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode erstellt, [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), die das Auffinden einer bestimmten Form in einer Folie ermöglicht und dann einfach diese Form zurückgibt.
```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternativtext der zu findenden Form
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Methodenimplementierung zum Finden einer Form in einer Folie mithilfe ihres Alternativtexts
public static IShape findShape(ISlide slide, String alttext)
{
    // Durchlaufen aller Formen innerhalb der Folie
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Wenn der Alternativtext der Folie mit dem benötigten übereinstimmt, dann
        // Rückgabe der Form
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Klonen einer Form**
Um eine Form auf einer Folie mit Aspose.Slides for Java zu klonen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie über deren Index.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Klonen Sie Formen aus der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierungsform hinzu.
```java
// Instanziiere Presentation-Klasse
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form entfernen**
Aspose.Slides for Java ermöglicht es Entwicklern, jede Form zu entfernen. Um die Form von einer Folie zu entfernen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Presentation-Objekt erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide sld = pres.getSlides().get_Item(0);

    // Autoform vom Typ Rechteck hinzufügen
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Präsentation auf die Festplatte speichern
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form ausblenden**
Aspose.Slides for Java ermöglicht es Entwicklern, jede Form auszublenden. Um die Form auf einer Folie auszublenden, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziiere Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide sld = pres.getSlides().get_Item(0);

    // Autoform vom Typ Rechteck hinzufügen
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Präsentation auf die Festplatte speichern
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Reihenfolge von Formen ändern**
Aspose.Slides for Java ermöglicht es Entwicklern, die Reihenfolge der Formen zu ändern. Das Ändern der Reihenfolge legt fest, welche Form im Vordergrund und welche im Hintergrund steht. Um die Reihenfolge der Formen auf einer Folie zu ändern, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie dem Textfeld der Form Text hinzu.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ändern Sie die Reihenfolge der Formen.
1. Speichern Sie die Datei auf dem Datenträger.
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Interop‑Shape‑ID abrufen**
Aspose.Slides for Java ermöglicht es Entwicklern, einen eindeutigen Form‑Bezeichner im Folien‑Scope zu erhalten, im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--) , die einen eindeutigen Bezeichner im Präsentations‑Scope liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) wurde den Schnittstellen [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) und der Klasse [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Nachfolgend wird ein Beispielcode gezeigt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Abrufen der eindeutigen Formkennung im Folienbereich
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Alternativtext für eine Form festlegen**
Aspose.Slides for Java ermöglicht es Entwicklern, den AlternateText einer beliebigen Form festzulegen. Formen in einer Präsentation können über die Methode [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) oder [Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-) unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen oder gesetzt werden. Mithilfe dieser Methode können Sie einer Form ein Tag zuweisen und verschiedene Vorgänge ausführen, wie das Entfernen einer Form, das Ausblenden einer Form oder das Ändern der Reihenfolge von Formen auf einer Folie. Um den AlternateText einer Form festzulegen, gehen Sie bitte wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie der Folie eine beliebige Form hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchsuchen Sie die Formen, um eine Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziiere Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide sld = pres.getSlides().get_Item(0);

    // Autoform vom Typ Rechteck hinzufügen
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Präsentation auf die Festplatte speichern
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Layout‑Formate für eine Form zugreifen**
Aspose.Slides for Java bietet eine einfache API, um Layout‑Formate für eine Form zuzugreifen. Dieser Artikel zeigt, wie Sie auf Layout‑Formate zugreifen können.

Im Folgenden wird ein Beispielcode angezeigt.
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form als SVG rendern**
Jetzt unterstützt Aspose.Slides for Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde der Klasse [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) und dem Interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzugefügt. Diese Methode ermöglicht es, den Inhalt der Form als SVG‑Datei zu speichern. Das nachfolgende Code‑Snippet zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form ausrichten**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Example 1**

Der Quellcode unten richtet Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**Example 2**

Das folgende Beispiel zeigt, wie die gesamte Formensammlung relativ zur untersten Form in der Sammlung ausgerichtet wird.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Flip‑Eigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) Kontrolle über die horizontale und vertikale Spiegelung von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften vom Typ `byte` erlauben die Werte `1` für eine Spiegelung, `0` für keine Spiegelung oder `-1` für das Standardverhalten. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch Zuordnen dieser Instanz zum [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) der Form und dem Speichern der Präsentation werden die Spiegelungs‑Transformationen angewendet und in die Ausgabedatei übernommen.

Nehmen wir an, wir haben eine Datei sample.pptx, bei der die erste Folie eine einzelne Form mit den Standard‑Flip‑Einstellungen enthält, wie unten dargestellt.

![The shape to be flipped](shape_to_be_flipped.png)

Das folgende Code‑Beispiel ermittelt die aktuellen Flip‑Eigenschaften der Form und spiegelt sie sowohl horizontal als auch vertikal.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Abrufen der horizontalen Flip‑Eigenschaft der Form.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Abrufen der vertikalen Flip‑Eigenschaft der Form.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Horizontal spiegeln.
    byte flipV = NullableBool.True; // Horizontal spiegeln.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnittmenge/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die entstehende Geometrie über [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originale entfernen.

**Wie kann ich die Stapelreihenfolge (z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüg‑/Verschiebereihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die z‑Order nach allen anderen Folienänderungen abschließen.

**Kann ich eine Form „sperren“, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [shape-level protection flags](/slides/de/java/applying-protection-to-presentation/) (z. B. Auswahl, Verschiebung, Größenänderung, Textbearbeitung sperren). Bei Bedarf spiegeln Sie die Beschränkungen im Master oder Layout. Beachten Sie, dass dies ein UI‑basiertes Schutzmittel ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie es mit Dateischutz‑Beschränkungen wie [Leseempfehlungen oder Passwörtern](/slides/de/java/password-protected-presentation/).