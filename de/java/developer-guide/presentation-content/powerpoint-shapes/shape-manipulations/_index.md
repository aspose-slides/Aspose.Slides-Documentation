---
title: Formenmanipulationen
type: docs
weight: 40
url: /de/java/shape-manipulations/
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne ihre interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit bieten, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige ID. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen ID zu finden. Alle Formen, die zu den Folien hinzugefügt werden, haben einen alternativen Text. Wir empfehlen Entwicklern, den alternativen Text zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den alternativen Text für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den alternativen Text für eine gewünschte Form festgelegt haben, können Sie diese Präsentation mit Aspose.Slides für Java öffnen und durch alle Formen iterieren, die einer Folie hinzugefügt wurden. Bei jeder Iteration können Sie den alternativen Text der Form überprüfen, und die Form mit dem übereinstimmenden alternativen Text wäre die von Ihnen benötigte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), erstellt, die den Trick ausführt, um eine bestimmte Form in einer Folie zu finden und diese Form dann einfach zurückzugeben.

```java
// Instanzieren einer Präsentationsklasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternativtext der zu findenden Form
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Formname: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Methodenimplementierung zum Finden einer Form in einer Folie anhand ihres alternativen Texts
public static IShape findShape(ISlide slide, String alttext)
{
    // Iteration durch alle Formen innerhalb der Folie
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Wenn der alternative Text der Folie mit dem benötigten übereinstimmt
        // Geben Sie die Form zurück
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Form klonen**
Um eine Form mit Aspose.Slides für Java in eine Folie zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie eine neue Folie zur Präsentation hinzu.
1. Klonen Sie Formen von der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierung hinzu.

```java
// Instanzieren der Präsentationsklasse
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Form entfernen**
Aspose.Slides für Java ermöglicht es Entwicklern, jede Form zu entfernen. Um die Form von einer Folie zu entfernen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem Alternativtext.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie das Präsentationsobjekt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine Autoshape der Rechteckform hinzu
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "Benutzer definiert";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Speichern Sie die Präsentation auf der Festplatte
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Form ausblenden**
Aspose.Slides für Java ermöglicht es Entwicklern, jede Form auszublenden. Um die Form von einer Folie auszublenden, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem Alternativtext.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf der Festplatte.

```java
// Instanzieren Sie die Präsentationsklasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine Autoshape der Rechteckform hinzu
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "Benutzer definiert";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Speichern Sie die Präsentation auf der Festplatte
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formenreihenfolge ändern**
Aspose.Slides für Java ermöglicht es Entwicklern, die Formen neu anzuordnen. Die Neuanordnung der Form gibt an, welche Form vorne oder hinten ist. Um die Form von einer Folie neu anzuordnen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie etwas Text in den Textbereich der Form hinzu.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu an.
1. Speichern Sie die Datei auf der Festplatte.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Wasserzeichen Text Wasserzeichen Text Wasserzeichen Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop-Form-ID abrufen**
Aspose.Slides für Java ermöglicht es Entwicklern, eine eindeutige Form-ID im Folienkontext abzurufen, im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--), die es ermöglicht, eine eindeutige ID im Präsentationskontext abzurufen. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) wurde zu den Interfaces [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) und [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) hinzugefügt. Der Wert, der von der Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegeben wird, entspricht dem Wert der ID des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Unten ist ein Beispielcode gegeben.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Eindeutige Form-ID im Folienkontext abrufen
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Alternativtext für Form festlegen**
Aspose.Slides für Java ermöglicht es Entwicklern, den Alternativtext für jede Form festzulegen. 
Formen in einer Präsentation können durch die Methoden [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) oder [Formname](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-) unterschieden werden.
Die Methoden [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) können sowohl über Aspose.Slides als auch Microsoft PowerPoint gelesen oder festgelegt werden.
Durch die Verwendung dieser Methode können Sie eine Form kennzeichnen und verschiedene Operationen wie das Entfernen einer Form, das Ausblenden einer Form oder das Neuanordnen von Formen auf einer Folie durchführen.
Um den Alternativtext einer Form festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form zur Folie hinzu.
1. Führen Sie einige Arbeiten mit der neu hinzugefügten Form aus.
1. Durchlaufen Sie die Formen, um eine Form zu finden.
1. Setzen Sie den Alternativtext.
1. Speichern Sie die Datei auf der Festplatte.

```java
// Instanzieren Sie die Präsentationsklasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine Autoshape der Rechteckform hinzu
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("Benutzer definiert");
        }
    }

    // Speichern Sie die Präsentation auf der Festplatte
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Layoutformate für Form zugreifen**
Aspose.Slides für Java bietet eine einfache API zum Zugreifen auf Layoutformate für eine Form. Dieser Artikel zeigt, wie Sie auf Layoutformate zugreifen können.

Unten ist ein Beispielcode gegeben.

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

## **Form als SVG rendern**
Jetzt unterstützt Aspose.Slides für Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladungen) wurde hinzugefügt zur [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) Klasse und [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) Schnittstelle. Diese Methode ermöglicht es, den Inhalt der Form als SVG-Datei zu speichern. Der folgende Codeausschnitt zeigt, wie man die Form der Folie in eine SVG-Datei exportiert.

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

## **Ausrichtung von Formen**
Aspose.Slides ermöglicht die Ausrichtung von Formen, entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der Quellcode unten richtet die Formen mit den Indizes 1, 2 und 4 entlang der oberen Grenze der Folie aus.

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

Das folgende Beispiel zeigt, wie man die gesamte Sammlung von Formen relativ zur ganz unteren Form in der Sammlung ausrichtet.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```