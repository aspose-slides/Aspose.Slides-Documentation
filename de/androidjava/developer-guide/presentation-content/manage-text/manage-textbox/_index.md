---
title: TextBox verwalten
type: docs
weight: 20
url: /androidjava/manage-textbox/
description: Erstellen Sie ein Textfeld in PowerPoint-Folien mit Java. Fügen Sie eine Spalte in ein Textfeld oder einen Textrahmen in PowerPoint-Folien mit Java ein. Fügen Sie ein Textfeld mit Hyperlink in PowerPoint-Folien mit Java hinzu.
---


Text auf Folien existiert typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Android über Java bietet das [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) Interface, das Ihnen ermöglicht, eine Form hinzuzufügen, die Text enthält.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet auch das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) Interface, mit dem Sie Formen zu Folien hinzufügen können. Nicht alle über das `IShape` Interface hinzugefügten Formen können jedoch Text halten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) Interface hinzugefügt werden, können jedoch Text enthalten.

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, überprüfen und bestätigen, dass sie über das `IAutoShape` Interface konvertiert wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) arbeiten, das eine Eigenschaft unter `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) Objekt mit [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) hinzu, das als `Rectangle` an einer angegebenen Position auf der Folie gesetzt ist, und holen Sie sich die Referenz für das neu hinzugefügte `IAutoShape` Objekt.
4. Fügen Sie eine `TextFrame`-Eigenschaft zum `IAutoShape` Objekt hinzu, die Text enthalten wird. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt. 

Dieser Java-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```java
// Instanziiert Präsentation
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit Typ als Rectangle hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt TextFrame zum Rechteck hinzu
    ashp.addTextFrame(" ");

    // Greift auf den Textrahmen zu
    ITextFrame txtFrame = ashp.getTextFrame();

    // Erstellt das Paragraph-Objekt für den Textrahmen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellt ein Portion-Objekt für den Paragraphen
    IPortion portion = para.getPortions().get_Item(0);

    // Setzt Text
    portion.setText("Aspose TextBox");

    // Speichert die Präsentation auf der Festplatte
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Überprüfen Sie die Textfeldform**

Aspose.Slides bietet die [isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--) Eigenschaft (aus der [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) Klasse), um Formen zu untersuchen und Textfelder zu finden.

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

Aspose.Slides bietet die [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) Eigenschaften (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) Interface und der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse), mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Java-Code demonstriert die beschriebene Operation: 

```java
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit Typ als Rectangle hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Fügt TextFrame zum Rechteck hinzu
    aShape.addTextFrame("Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textcontainers zu bleiben – " +
            "Sie können Text hinzufügen oder löschen und der neue oder verbleibende Text passt sich automatisch " +
            "an, um innerhalb des Containers zu fließen. Sie können jedoch keinen Text von einem Container " +
            "zu einem anderen fließen lassen – wir haben Ihnen gesagt, dass die Spaltenoptionen für Text in PowerPoint begrenzt sind!");

    // Ruft das Textformat des Textrahmens ab
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
Aspose.Slides für Android über Java bietet die [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) Eigenschaft (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) Interface), die es Ihnen ermöglicht, Spalten in Textrahmen hinzuzufügen. Über diese Eigenschaft können Sie die von Ihnen bevorzugte Anzahl von Spalten in einem Textrahmen angeben.

Dieser Java-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textrahmens hinzufügen:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Alle diese Spalten sind gezwungen, innerhalb eines einzigen Textcontainers zu bleiben – " +
            "Sie können Text hinzufügen oder löschen - und der neue oder verbleibende Text passt sich automatisch " +
            "an, um innerhalb des Containers zu bleiben. Sie können jedoch keinen Text von einem Container " +
            "zu einem anderen überlaufen lassen – denn die Spaltenoptionen für Text in PowerPoint sind begrenzt!");
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

Aspose.Slides ermöglicht es Ihnen, den Text, der in einem Textfeld enthalten ist, oder alle Texte, die in einer Präsentation enthalten sind, zu ändern oder zu aktualisieren. 

Dieser Java-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Überprüft, ob die Form den Textrahmen unterstützt (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iteriert durch die Paragraphen im Textrahmen
                {
                    for (IPortion portion : paragraph.getPortions()) //Iteriert durch jede Portion im Paragraphen
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Ändert den Text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Ändert die Formatierung
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer zu dem Link weitergeleitet. 

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der `Presentation` Klasse. 
2. Holen Sie sich eine Referenz auf die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` als `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz auf das neu hinzugefügte AutoShape Objekt.
4. Fügen Sie ein `TextFrame` zu dem `AutoShape` Objekt hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager` Klasse. 
6. Weisen Sie das `IHyperlinkManager` Objekt der [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) Eigenschaft zu, die mit Ihrer bevorzugten Portion des `TextFrame` verknüpft ist.
7. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt. 

Dieser Java-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```java
// Instanziiert eine Präsentationsklasse, die ein PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt ein AutoShape-Objekt mit Typ als Rectangle hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Wandelt die Form in AutoShape um
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Greift auf die ITextFrame-Eigenschaft zu, die mit dem AutoShape verknüpft ist
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Fügt etwas Text zum Rahmen hinzu
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Setzt den Hyperlink für den Portion-Text
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Speichert die PPTX-Präsentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```