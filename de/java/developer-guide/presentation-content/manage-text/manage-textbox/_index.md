---
title: Textfelder in Präsentationen mit Java verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/java/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Aspose.Slides für Java ermöglicht das einfache Erstellen, Bearbeiten und Kopieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert Ihre Präsentationsautomatisierung."
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides for Java stellt das [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) Interface bereit, das es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}

Aspose.Slides stellt außerdem das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) Interface bereit, das es Ihnen ermöglicht, Formen zu Folien hinzuzufügen. Allerdings können nicht alle über das `IShape` Interface hinzugefügten Formen Text enthalten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) Interface hinzugefügt werden, können jedoch Text enthalten. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über das `IAutoShape` Interface gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/java/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Textfeld auf Folie erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)‑Objekt mit [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte `IAutoShape`‑Objekt. 
4. Fügen Sie dem `IAutoShape`‑Objekt die Eigenschaft `TextFrame` hinzu, die einen Text enthalten wird. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java-Code – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:
```java
// Erstellt eine Presentation
Presentation pres = new Presentation();
try {
    // Holt die erste Folie in der Präsentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit Typ Rectangle hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame(" ");

    // Greift auf das TextFrame zu
    ITextFrame txtFrame = ashp.getTextFrame();

    // Erstellt das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellt ein Portion-Objekt für den Paragraphen
    IPortion portion = para.getPortions().get_Item(0);

    // Setzt den Text
    portion.setText("Aspose TextBox");

    // Speichert die Präsentation auf die Festplatte
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Überprüfen, ob es sich um ein Textfeld handelt**

Aspose.Slides stellt die Methode [isTextBox](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) aus dem [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) Interface bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser Java-Code zeigt Ihnen, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde: 
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


Beachten Sie, dass wenn Sie einfach eine AutoShape mit der Methode `addAutoShape` aus dem [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) Interface hinzufügen, die `isTextBox`‑Methode der AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zur AutoShape mit der Methode `addTextFrame` oder `setText` hinzugefügt haben, gibt die `isTextBox`‑Eigenschaft `true` zurück.
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() gibt false zurück
shape1.addTextFrame("shape 1");
// shape1.isTextBox() gibt true zurück

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() gibt false zurück
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() gibt true zurück

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() gibt false zurück
shape3.addTextFrame("");
// shape3.isTextBox() gibt false zurück

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() gibt false zurück
shape4.getTextFrame().setText("");
// shape4.isTextBox() gibt false zurück
```


## **Spalte im Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) Interface und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) bereit, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand in Punkten zwischen den Spalten einstellen. 

Dieser Java-Code demonstriert die beschriebene Vorgehensweise: 
```java
Presentation pres = new Presentation();
try {
    // Holt die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit Typ Rectangle hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Fügt dem Rechteck ein TextFrame hinzu
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Holt das Textformat des TextFrames
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Gibt die Anzahl der Spalten im TextFrame an
    format.setColumnCount(3);

    // Gibt den Abstand zwischen den Spalten an
    format.setColumnSpacing(10);

    // Speichert die Präsentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **Spalte im Textrahmen hinzufügen**

Aspose.Slides for Java stellt die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) Interface) bereit, mit der Sie Spalten in Textframes hinzufügen können. Mit dieser Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textframe angeben. 

Dieser Java-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textframes hinzufügen:
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren. 

Dieser Java-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Überprüft, ob die Form einen Textrahmen unterstützt (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iteriert über die Absätze im Textrahmen
                {
                    for (IPortion portion : paragraph.getPortions()) //Iteriert über jede Portion im Absatz
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Ändert den Text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Ändert die Formatierung
                    }
                }
            }
        }
    }

    //Speichert die geänderte Präsentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer zum Öffnen des Links weitergeleitet. 

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse `Presentation`. 
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz auf das neu hinzugefügte AutoShape‑Objekt.
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die Klasse `IHyperlinkManager`. 
6. Weisen Sie das `IHyperlinkManager`‑Objekt der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) zu, die mit dem gewünschten Teil des `TextFrame` verknüpft ist. 
7. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java-Code – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:
```java
// Instanziiert eine Presentation-Klasse, die eine PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt ein AutoShape-Objekt hinzu, dessen Typ auf Rectangle gesetzt ist
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Castet die Form zu AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Greift auf die ITextFrame-Eigenschaft der AutoShape zu
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Fügt dem Rahmen etwas Text hinzu
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Setzt den Hyperlink für den Portionstext
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Speichert die PPTX-Präsentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Masterfolien?**

Ein [Platzhalter](/slides/de/java/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/) und kann auf [Layouts](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massenhaften Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/java/com.aspose.slides/chart/), [Tabellen](https://reference.aspose.com/slides/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.