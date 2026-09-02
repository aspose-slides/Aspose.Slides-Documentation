---
title: Verwalten von Textfeldern in Präsentationen auf Android
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides für Android via Java erleichtert das Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---
## **Einleitung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher muss man, um Text zu einer Folie hinzuzufügen, zunächst ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Android via Java stellt das Interface [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape) bereit, das das Hinzufügen einer Form mit Text ermöglicht.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem das Interface [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape) bereit, mit dem Formen zu Folien hinzugefügt werden können. Allerdings können nicht alle über das `IShape`‑Interface hinzugefügten Formen Text enthalten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape)‑Interface hinzugefügt werden, können jedoch Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Deshalb, wenn Sie mit einer Form arbeiten, der Sie Text hinzufügen möchten, sollten Sie prüfen und bestätigen, dass sie über das `IAutoShape`‑Interface gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/de/androidjava/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, führen Sie diese Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape)‑Objekt mit [ShapeType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape`‑Objekt.
4. Fügen Sie die Eigenschaft `TextFrame` dem `IAutoShape`‑Objekt hinzu, das Text enthalten wird. Im nachfolgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java‑Code — eine Implementierung der oben genannten Schritte — zeigt, wie Text zu einer Folie hinzugefügt wird:

```java
import com.aspose.slides.*;

// Instanziert die Präsentation
Presentation pres = new Presentation();
try {
    // Erhält die erste Folie in der Präsentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit dem Typ Rechteck hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt dem Rechteck einen TextFrame hinzu
    ashp.addTextFrame(" ");

    // Greift auf den TextFrame zu
    ITextFrame txtFrame = ashp.getTextFrame();

    // Erstellt das Paragraph-Objekt für den TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellt ein Portion-Objekt für den Absatz
    IPortion portion = para.getPortions().get_Item(0);

    // Setzt den Text
    portion.setText("Aspose TextBox");

    // Speichert die Präsentation auf der Festplatte
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides bietet die Methode [isTextBox](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#isTextBox--) des [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)‑Interface, mit der Sie Formen untersuchen und Textfelder identifizieren können.

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

Beachten Sie, dass wenn Sie einfach eine Autoform über die Methode `addAutoShape` des [IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/)‑Interface hinzufügen, die Methode `isTextBox` der Autoform `false` zurückgibt. Nachdem Sie jedoch Text zur Autoform über die Methode `addTextFrame` oder die Methode `setText` hinzugefügt haben, gibt die Eigenschaft `isTextBox` `true` zurück.

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

In generischem Text‑Verarbeitungscode können Sie ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) erhalten, ohne bereits zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die Methode [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) um zum zugehörigen [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) zurückz navigieren.

Für einen Textrahmen, der zu einem [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) oder einer anderen text‑enthält‑Form gehört, gibt [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) den Eigentümer zurück und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) gibt `null` zurück. Beide Methoden bieten nur Lese‑Navigation, sodass ihr Aufruf die Besitzverhältnisse nicht ändert. Prüfen Sie immer, ob der zurückgegebene Wert `null` ist, bevor Sie auf die Form zugreifen.

Ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Eigentümer identifiziert, einschließlich Formen, die zu SmartArt‑Knoten gehören, finden Sie unter [Suchen und Ersetzen von Text](/slides/de/androidjava/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrameFormat)‑Interface und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/TextFrameFormat)) bereit, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkt zwischen den Spalten festlegen.

Dieser Java‑Code demonstriert den beschriebenen Vorgang: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Erhält die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape mit dem Typ Rechteck hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Fügt dem Rechteck einen TextFrame hinzu
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Erhält das Textformat des TextFrames
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Legt die Anzahl der Spalten im TextFrame fest
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
Aspose.Slides für Android via Java bietet die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrameFormat)‑Interface), mit der Sie Spalten in Textrahmen hinzufügen können. Über diese Eigenschaft können Sie die gewünschte Spaltenanzahl in einem Textrahmen festlegen.

Dieser Java‑Code zeigt, wie Sie eine Spalte innerhalb eines Textrahmens hinzufügen:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

Aspose.Slides ermöglicht es Ihnen, den in einem Textfeld enthaltenen Text oder alle Texte in einer Präsentation zu ändern bzw. zu aktualisieren. 

Dieser Java‑Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

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
                    for (IPortion portion : paragraph.getPortions()) // Durchläuft jeden Teil im Absatz
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Link geöffnet. 

Um ein Textfeld mit einem Link hinzuzufügen, führen Sie diese Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse. 
2. Holen Sie eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz des neu hinzugefügten AutoShape‑Objekts.
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu und setzen Sie den Text des ersten Abschnitts. Im Beispiel unten haben wir diesen Text verwendet: *Aspose.Slides*
5. Holen Sie das [IHyperlinkManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/)‑Objekt aus dem `PortionFormat` des gewünschten Abschnitts des `TextFrame`.
6. Rufen Sie [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) auf diesem Objekt auf, um den Link festzulegen, der beim Klicken auf den Text geöffnet wird.
7. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser Java‑Code — eine Implementierung der oben genannten Schritte — zeigt, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:

```java
import com.aspose.slides.*;

// Instanziert eine Presentation‑Klasse, die eine PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt ein AutoShape‑Objekt mit dem Typ Rechteck hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Castet die Form zu AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Greift auf die ITextFrame‑Eigenschaft der AutoShape zu
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Fügt dem Frame etwas Text hinzu
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Setzt den Hyperlink für den Portion‑Text
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Speichert die PPTX‑Präsentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/androidjava/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massenhaften Text‑Austausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Begrenzen Sie Ihre Iteration auf Autoformen, die Textrahmen besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/), [Tabellen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.