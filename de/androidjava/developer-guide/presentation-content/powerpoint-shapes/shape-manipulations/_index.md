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
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für Android via Java erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, um es Entwicklern zu erleichtern, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es erscheint schwierig für Entwickler, eine Form anhand ihrer internen eindeutigen Id zu finden. Allen Formen, die zu den Folien hinzugefügt werden, ist ein Alternativtext zugewiesen. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint nutzen, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für Android via Java öffnen und alle Formen auf einer Folie durchlaufen. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem übereinstimmenden Alternativtext ist die gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) erstellt, die das Auffinden einer bestimmten Form in einer Folie übernimmt und einfach diese Form zurückgibt.
```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
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
    // Durchlaufen aller Formen innerhalb der Folie
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Wenn der Alternativtext der Folie mit dem gewünschten übereinstimmt dann
        // Gibt die Form zurück
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Eine Form duplizieren**
Um eine Form zu einer Folie zu duplizieren mit Aspose.Slides für Android via Java:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
1. Holen Sie die Referenz einer Folie über deren Index.  
1. Greifen Sie auf die Formsammlung der Quellfolie zu.  
1. Fügen Sie der Präsentation eine neue Folie hinzu.  
1. Duplizieren Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das nachstehende Beispiel fügt einer Folie ein Gruppierungsobjekt hinzu.
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

    // PPTX-Datei auf Festplatte schreiben
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form entfernen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Entfernen jeder Form. Um eine Form von einer Folie zu entfernen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Finden Sie die Form mit einem bestimmten AlternativeText.  
1. Entfernen Sie die Form.  
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Präsentationsobjekt erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
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

    // Präsentation auf Festplatte speichern
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine Form ausblenden**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Ausblenden jeder Form. Um eine Form von einer Folie auszublenden, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Finden Sie die Form mit einem bestimmten AlternativeText.  
1. Blenden Sie die Form aus.  
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziieren der Presentation-Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
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

    // Präsentation auf Festplatte speichern
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Reihenfolge einer Form ändern**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Neuanordnen von Formen. Das Neuanordnen legt fest, welche Form im Vordergrund bzw. im Hintergrund liegt. Um die Reihenfolge einer Form auf einer Folie zu ändern, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie eine Form hinzu.  
1. Fügen Sie Text im Textfeld der Form ein.  
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


## **Interop‑Form‑ID erhalten**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Abrufen einer eindeutigen Form‑Kennung im Folien‑Umfang im Gegensatz zur [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--)‑Methode, die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) wurde zu den [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)-Schnittstellen und der [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape)-Klasse hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Im Folgenden finden Sie ein Beispiel.
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
Aspose.Slides für Android via Java ermöglicht Entwicklern das Festlegen von AlternateText für jede Form. Formen in einer Präsentation können über die [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-)‑ oder [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-)‑Methode unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen bzw. gesetzt werden. Mit dieser Methode können Sie einer Form ein Tag zuweisen und verschiedene Vorgänge ausführen, z. B. das Entfernen, Ausblenden oder Neuanordnen von Formen auf einer Folie. Um den AlternateText einer Form festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie der Folie eine beliebige Form hinzu.  
1. Arbeiten Sie mit der neu hinzugefügten Form.  
1. Durchlaufen Sie die Formen, um eine bestimmte Form zu finden.  
1. Setzen Sie den AlternativeText.  
1. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanziieren der Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
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

    // Präsentation auf Festplatte speichern
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Layout‑Formate einer Form abrufen**
Aspose.Slides für Android via Java bietet eine einfache API zum Abrufen von Layout‑Formaten einer Form. Dieser Artikel zeigt, wie Sie auf Layout‑Formate zugreifen können.

Im Folgenden finden Sie Beispielcode.
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
Jetzt unterstützt Aspose.Slides für Android via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde zur [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape)-Klasse und zur [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)-Schnittstelle hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Der nachstehende Code‑Auszug zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
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

Der Quellcode unten richtet die Formen mit den Indizes 1, 2 und 4 entlang der oberen Folienkante aus.
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

Das nachstehende Beispiel zeigt, wie die gesamte Formsammlung relativ zur untersten Form der Sammlung ausgerichtet wird.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Flip‑Eigenschaften**

In Aspose.Slides stellt die Klasse [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) die Kontrolle über die horizontale und vertikale Spiegelung von Formen über die Eigenschaften `flipH` und `flipV` bereit. Beide Eigenschaften sind vom Typ `byte` und akzeptieren `1` für eine Spiegelung, `0` für keine Spiegelung oder `-1` für das Standardverhalten. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird ein neues [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/)‑Objekt mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Dieses Objekt wird dem [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) der Form zugewiesen und das Dokument wird gespeichert, wodurch die Spiegeltransformationen angewendet und in die Ausgabedatei übernommen werden.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Flip‑Einstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Der folgende Code‑Auszug ruft die aktuellen Flip‑Eigenschaften der Form ab und spiegelt sie sowohl horizontal als auch vertikal.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Abrufen der horizontalen Flip-Eigenschaft der Form.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Abrufen der vertikalen Flip-Eigenschaft der Form.
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

**Kann ich Formen (Vereinen/Überschneiden/Subtrahieren) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Eine integrierte Boolesche‑Operation‑API gibt es nicht. Sie können sie annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originalformen entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die Z‑Order nach allen anderen Folienbearbeitungen finalisieren.

**Kann ich eine Form „sperren“, damit Nutzer sie in PowerPoint nicht bearbeiten können?**

Ja. Setzen Sie schutzbezogene Flags auf Form‑Ebene (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf können Sie die Beschränkungen auf dem Master‑ oder Layout‑Folientyp spiegeln. Beachten Sie, dass dies ein UI‑Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz‑Optionen wie Lese‑Only‑Empfehlungen oder Passwörtern [/slides/androidjava/password-protected-presentation/](#/slides/androidjava/password-protected-presentation/).