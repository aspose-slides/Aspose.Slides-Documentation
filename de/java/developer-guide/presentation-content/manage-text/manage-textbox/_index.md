---
title: Textfeld verwalten
type: docs
weight: 20
url: /de/java/manage-textbox/
description: Erstellen Sie ein Textfeld auf PowerPoint-Folien mit Java. Fügen Sie eine Spalte in das Textfeld oder den Textcontainer auf PowerPoint-Folien mit Java ein. Fügen Sie ein Textfeld mit Hyperlink auf PowerPoint-Folien mit Java hinzu.
---


Texte auf Folien existieren typischerweise in Textfeldern oder Formen. Daher müssen Sie, um einen Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann einen Text in das Textfeld einfügen. Aspose.Slides für Java bietet das [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) -Interface, mit dem Sie eine Form mit Text hinzufügen können.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet auch das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) -Interface, mit dem Sie Formen zu Folien hinzufügen können. Nicht alle Formen, die über das `IShape` -Interface hinzugefügt werden, können jedoch Text halten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) -Interface hinzugefügt werden, können Text enthalten.

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, überprüfen und bestätigen, dass sie über das `IAutoShape` -Interface gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) arbeiten, das eine Eigenschaft unter `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/java/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) -Klasse. 
2. Erhalten Sie eine Referenz auf die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) -Objekt mit [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) als `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape` -Objekt. 
4. Fügen Sie dem `IAutoShape` -Objekt eine `TextFrame` -Eigenschaft hinzu, die einen Text enthalten wird. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` -Objekt.

Dieser Java-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```java
// Instantiates Presentation
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Creates a Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Sets Text
    portion.setText("Aspose TextBox");

    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Auf Textfeldform prüfen**

Aspose.Slides bietet die [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) -Eigenschaft (aus der [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) -Klasse), um Formen zu untersuchen und Textfelder zu finden.

![Textfeld und Form](istextbox.png)

Dieser Java-Code zeigt Ihnen, wie Sie überprüfen können, ob eine Form als Textfeld erstellt wurde: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "Form ist ein Textfeld" : "Form ist kein Textfeld");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides bietet die [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) Eigenschaften (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) -Interface und der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) -Klasse), die es Ihnen ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Code in Java demonstriert die beschriebene Operation: 

```java
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape with type set as Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Add TextFrame to the Rectangle
    aShape.addTextFrame("Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textcontainers zu bleiben -- " +
            "Sie können Text hinzufügen oder löschen und der neue oder verbleibende Text passt sich automatisch " +
            "an, um innerhalb des Containers zu fließen. Sie können nicht haben, dass Text von einem Container " +
            "zu einem anderen fließt -- wir haben Ihnen gesagt, dass die Spaltenoptionen für Texte in PowerPoint begrenzt sind!");

    // Gets the text format of TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specifies the number of columns in TextFrame
    format.setColumnCount(3);

    // Specifies the spacing between columns
    format.setColumnSpacing(10);

    // Saves the presentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Spalte im Textframe hinzufügen**
Aspose.Slides für Java bietet die [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) -Eigenschaft (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) -Interface), die es Ihnen ermöglicht, Spalten in Textfeldern hinzuzufügen. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textfeld angeben.

Dieser Java-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textfeldes hinzufügen:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Alle diese Spalten sind gezwungen, innerhalb eines einzelnen Textcontainers zu bleiben -- " +
            "Sie können Text hinzufügen oder löschen - und der neue oder verbleibende Text passt sich automatisch " +
            "an, um im Container zu bleiben. Sie können nicht haben, dass Text von einem Container " +
            "zu einem anderen überläuft, da die Spaltenoptionen für Texte in PowerPoint begrenzt sind!");
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

Aspose.Slides ermöglicht es Ihnen, den Text, der in einem Textfeld oder alle Texte, die in einer Präsentation enthalten sind, zu ändern oder zu aktualisieren.

Dieser Java-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Überprüft, ob die Form das Textfeld (IAutoShape) unterstützt. 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Durchläuft die Absätze im Textfeld
                {
                    for (IPortion portion : paragraph.getPortions()) //Durchläuft jedes Portion im Absatz
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Ändert den Text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Ändert das Format
                    }
                }
            }
        }
    }

    //Speichert die modifizierte Präsentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer aufgefordert, den Link zu öffnen.

 Um ein Textfeld mit einem Link hinzuzufügen, befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse. 
2. Erhalten Sie eine Referenz auf die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape` -Objekt mit `ShapeType` als `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape-Objekts.
4. Fügen Sie dem `AutoShape` -Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager` -Klasse. 
6. Weisen Sie das `IHyperlinkManager` -Objekt der [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) -Eigenschaft zu, die mit dem von Ihnen bevorzugten Teil des `TextFrame` verbunden ist. 
7. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` -Objekt. 

Dieser Java-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```java
// Instantiates a Presentation class that represents a PPTX
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds an AutoShape object with type set as Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Casts the shape to AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accesses the ITextFrame property associated with the AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Adds some text to the frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Sets the Hyperlink for the portion text
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Saves the PPTX Presentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```