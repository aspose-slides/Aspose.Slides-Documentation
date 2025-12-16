---
title: Verwalten von Präsentationsformen unter Android
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
- Interop-Form-ID abrufen
- Form-Alternativtext
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für Android via Java erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint‑Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne deren interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige ID. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen ID zu finden. Alle Formen, die zu den Folien hinzugefügt werden, besitzen einen Alt-Text. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den Alternativtext für Objekte zu definieren, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für Android via Java öffnen und durch alle zu einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die von Ihnen gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode erstellt, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), die das Finden einer bestimmten Form in einer Folie übernimmt und dann einfach diese Form zurückgibt.
```java
// Instanziieren einer Presentation-Klasse, die die Präsentationsdatei repräsentiert
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
// Methodenimplementierung zum Finden einer Form in einer Folie anhand ihres Alternativtexts
public static IShape findShape(ISlide slide, String alttext)
{
    // Durchlaufen aller Formen in der Folie
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Wenn der Alternativtext der Folie mit dem gewünschten übereinstimmt, dann
        // Rückgabe der Form
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Eine Form klonen**
Um eine Form zu einer Folie zu klonen, verwenden Sie Aspose.Slides für Android via Java:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie über deren Index.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Klonen Sie Formen aus der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppierung von Formen hinzu.
```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX-Datei auf die Festplatte schreiben
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form entfernen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Entfernen jeder Form. Um eine Form von einer Folie zu entfernen, befolgen Sie bitte die folgenden Schritte:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Erstelle Presentation-Objekt
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Füge Autoform vom Typ Rechteck hinzu
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

    // Speichere Präsentation auf die Festplatte
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form ausblenden**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Ausblenden jeder Form. Um eine Form auf einer Folie auszublenden, befolgen Sie bitte die folgenden Schritte:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziieren der Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Füge Autoform vom Typ Rechteck hinzu
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

    // Speichere die Präsentation auf die Festplatte
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Reihenfolge einer Form ändern**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Neuanordnen von Formen. Das Neuanordnen bestimmt, welche Form im Vordergrund und welche im Hintergrund liegt. Um die Reihenfolge von Formen auf einer Folie zu ändern, befolgen Sie bitte die folgenden Schritte:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie etwas Text im Textfeld der Form hinzu.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu.
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


## **Interop Shape ID abrufen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Abrufen eines eindeutigen Form-Identifiers im Folienbereich im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) , die einen eindeutigen Identifier im Präsentationsbereich liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) wurde zu den Schnittstellen [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) und der Klasse [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id-Wert des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Nachfolgend wird ein Beispielcode gezeigt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Abrufen des eindeutigen Form-Identifiers im Folienbereich
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Alternativtext für eine Form festlegen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Festlegen von AlternateText für jede Form.
Formen in einer Präsentation können über die Methoden [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) oder [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) unterschieden werden.
Die Methoden [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen oder gesetzt werden.
Mit dieser Methode können Sie eine Form kennzeichnen und verschiedene Vorgänge ausführen, wie das Entfernen einer Form,
das Ausblenden einer Form oder das Neuanordnen von Formen auf einer Folie.
Um den AlternateText einer Form festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine bestimmte Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziieren der Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Füge Autoform vom Typ Rechteck hinzu
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

    // Speichere die Präsentation auf die Festplatte
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Layoutformate für eine Form zugreifen**
Aspose.Slides für Android via Java bietet eine einfache API zum Zugreifen auf Layoutformate für eine Form. Dieser Artikel zeigt, wie Sie auf Layoutformate zugreifen können.

Nachfolgend wird ein Beispielcode gezeigt.
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
Jetzt unterstützt Aspose.Slides für Android via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde zur Klasse [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) und zur Schnittstelle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG-Datei. Der nachstehende Codeausschnitt zeigt, wie die Form einer Folie in eine SVG-Datei exportiert wird.
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
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.
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


**Beispiel 2**

Das nachstehende Beispiel zeigt, wie die gesamte Sammlung von Formen relativ zur untersten Form in der Sammlung ausgerichtet wird.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Spiegeleigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) Steuerungsmöglichkeiten für horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften sind vom Typ `byte` und erlauben Werte von `1` für ein Spiegeln, `0` für kein Spiegeln oder `-1` für das Standardverhalten. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) einer Form zugänglich.

Um die Spiegeleinstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch Zuweisung dieser Instanz zum [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) der Form und dem Speichern der Präsentation werden die Spiegelungen angewendet und in die Ausgabedatei geschrieben.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit Standard‑Spiegeleinstellungen enthält, wie unten gezeigt.

![Die zu spiegelnde Form](shape_to_be_flipped.png)

Der folgende Codebeispiel ruft die aktuellen Spiegeleigenschaften der Form ab und spiegelt sie sowohl horizontal als auch vertikal.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Horizontale Flip‑Eigenschaft der Form abrufen.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Vertikale Flip‑Eigenschaft der Form abrufen.
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


![Die gespiegelte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Überschneidung/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst konstruieren – z. B. die resultierende Geometrie (über [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) berechnen und eine neue Form mit dieser Kontur erstellen, optional die Originalformen entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, damit eine Form immer "oben" bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie den Z‑Order nach allen anderen Folienänderungen finalisieren.

**Kann ich eine Form "sperren", um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie die [shape-level protection flags](/slides/de/androidjava/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf spiegeln Sie die Beschränkungen auf die Master‑ oder Layout‑Folien wider. Beachten Sie, dass dies ein UI‑basierter Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit dateibezogenen Einschränkungen wie [Leseempfehlungen oder Passwörtern](/slides/de/androidjava/password-protected-presentation/).