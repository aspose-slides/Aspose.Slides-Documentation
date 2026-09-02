---
title: Verwalten von Textfeldern in Präsentationen mit Java
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
description: "Aspose.Slides für Java ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert so die Automatisierung Ihrer Präsentationen."
---
## **Einleitung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides for Java stellt die [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) Schnittstelle bereit, die es ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt zudem die [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShape) Schnittstelle bereit, die es ermöglicht, Formen zu Folien hinzuzufügen. Nicht alle über die `IShape` Schnittstelle hinzugefügten Formen können Text enthalten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) Schnittstelle hinzugefügt werden, können jedoch Text enthalten. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `IAutoShape` Schnittstelle gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/de/java/manage-textbox/#update-text) auf dieser Seite. 
{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation). 
2. Erhalten Sie eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape)‑Objekt mit [ShapeType](https://reference.aspose.com/slides/de/java/com.aspose.slides/IGeometryShape#setShapeType-int-) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte `IAutoShape`‑Objekt. 
4. Fügen Sie dem `IAutoShape`‑Objekt die Eigenschaft `TextFrame` hinzu, die Text enthalten wird. Im nachfolgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie Text zu einer Folie hinzufügen:

```java
import com.aspose.slides.*;

// Instanziiert eine Präsentation
Presentation pres = new Presentation();
try {
    // Erhält die erste Folie in der Präsentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit dem Typ Rechteck hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt dem Rechteck einen Textrahmen hinzu
    ashp.addTextFrame(" ");

    // Greift auf den Textrahmen zu
    ITextFrame txtFrame = ashp.getTextFrame();

    // Erstellt das Paragraph-Objekt für den Textrahmen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellt ein Portion-Objekt für das Paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Setzt den Text
    portion.setText("Aspose TextBox");

    // Speichert die Präsentation auf der Festplatte
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Methode [isTextBox](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/#isTextBox--) aus der [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) Schnittstelle bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Textfeld und Form](istextbox.png)

Dieser Java‑Code zeigt, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde: 

```java
import com.aspose.slides.*;

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

Beachten Sie, dass wenn Sie einfach eine Autoform mit der Methode `addAutoShape` aus der [IShapeCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/) Schnittstelle hinzufügen, die `isTextBox`‑Methode der Autoform `false` zurückgibt. Nachdem Sie jedoch Text zur Autoform mit der Methode `addTextFrame` oder der Methode `setText` hinzugefügt haben, gibt die `isTextBox`‑Eigenschaft `true` zurück.

```java
import com.aspose.slides.*;

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

## **Die Form finden, die einen Textrahmen besitzt**

In generischem Textverarbeitungscode können Sie ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die Methode [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) , um zurück zur besitzenden [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) zu navigieren.

Für einen Textrahmen, der zu einer [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) oder einer anderen text‑enthält‑Form gehört, gibt [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) den Eigentümer zurück und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentCell--) gibt `null` zurück. Beide Methoden bieten nur Lese‑Navigation, sodass ihr Aufruf das Eigentum nicht ändert. Überprüfen Sie stets, ob der zurückgegebene Wert `null` ist, bevor Sie auf die Form zugreifen.

Ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Eigentümer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, finden Sie unter [Text suchen und ersetzen](/slides/de/java/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormat)‑Schnittstelle und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/TextFrameFormat)) zur Verfügung, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand in Punkt zwischen den Spalten einstellen. 

Dieser Java‑Code demonstriert die beschriebene Vorgehensweise: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Erhält die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape hinzu, deren Typ auf Rechteck gesetzt ist
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Fügt dem Rechteck einen Textrahmen hinzu
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Erhält das Textformat des Textrahmens
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Legt die Anzahl der Spalten im Textrahmen fest
    format.setColumnCount(3);

    // Legt den Abstand zwischen den Spalten fest
    format.setColumnSpacing(10);

    // Speichert die Präsentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spalten zu einem Textrahmen hinzufügen**
Aspose.Slides for Java stellt die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormat)‑Schnittstelle) bereit, mit der Sie Spalten in Textrahmen hinzufügen können. Mit dieser Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textrahmen festlegen. 

Dieser Java‑Code zeigt, wie Sie einer Textframe eine Spalte hinzufügen:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because Powerpoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text aktualisieren**

Aspose.Slides ermöglicht das Ändern oder Aktualisieren des in einem Textfeld enthaltenen Textes oder aller Texte in einer Präsentation. 

Dieser Java‑Code demonstriert eine Operation, bei der alle Texte einer Präsentation aktualisiert oder geändert werden:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Prüft, ob die Form einen Textrahmen unterstützt (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Durchläuft die Absätze im Textrahmen
                {
                    for (IPortion portion : paragraph.getPortions()) // Durchläuft jede Portion im Absatz
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Ändert den Text
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Ändert die Formatierung
                    }
                }
            }
        }
    }

    // Speichert die geänderte Präsentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ein Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer zum Öffnen des Links geleitet. 

Um ein Textfeld mit einem Link hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse `Presentation`. 
2. Erhalten Sie eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz auf das neu hinzugefügte AutoShape‑Objekt.
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die Klasse `IHyperlinkManager`. 
6. Weisen Sie das `IHyperlinkManager`‑Objekt der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/Shape#getHyperlinkClick--) zu, die mit dem gewünschten Abschnitt des `TextFrame` verknüpft ist. 
7. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie einem Folie ein Textfeld mit Hyperlink hinzufügen:

```java
import com.aspose.slides.*;

// Instanziiert eine Presentation-Klasse, die eine PPTX darstellt
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt ein AutoShape-Objekt hinzu, dessen Typ auf Rechteck gesetzt ist
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Castet die Form zu AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Greift auf die ITextFrame-Eigenschaft der AutoShape zu
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Fügt dem Rahmen etwas Text hinzu
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

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/java/manage-placeholder/) übernimmt Stil/Position vom [Master](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf Autoformen, die Textfelder besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/), [Tabellen](https://reference.aspose.com/slides/de/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.