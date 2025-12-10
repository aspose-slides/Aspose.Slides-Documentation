---
title: Textfelder in Präsentationen in .NET verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/net/manage-textbox/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides für .NET ermöglicht das einfache Erstellen, Bearbeiten und Duplizieren von Textfeldern in PowerPoint- und OpenDocument‑Dateien und verbessert Ihre Präsentationsautomatisierung."
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, zuerst ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. 

Um Ihnen das Hinzufügen einer Form zu ermöglichen, die Text enthalten kann, stellt Aspose.Slides für .NET die Schnittstelle [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) bereit. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides bietet außerdem die Schnittstelle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) an, um Formen zu Folien hinzuzufügen. Allerdings können nicht alle über die `IShape`-Schnittstelle hinzugefügten Formen Text enthalten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)-Schnittstelle hinzugefügt werden, enthalten typischerweise Text. 

Daher sollten Sie, wenn Sie einer vorhandenen Form Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `IAutoShape`-Schnittstelle gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Rufen Sie die Referenz der ersten Folie über ihren Index ab. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)-Objekt mit dem [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape`-Objekt. 
4. Fügen Sie dem `IAutoShape`-Objekt die Eigenschaft `TextFrame` hinzu, die einen Text enthalten wird. Im nachstehenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox* 
5. Schließlich schreiben Sie die PPTX-Datei über das `Presentation`-Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:
```c#
// Instanziiert PresentationEx
using (Presentation pres = new Presentation())
{

    // Holt die erste Folie in der Präsentation
    ISlide sld = pres.Slides[0];

    // Fügt eine AutoShape mit dem Typ Rectangle hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt dem Rechteck ein TextFrame hinzu
    ashp.AddTextFrame(" ");

    // Greift auf das TextFrame zu
    ITextFrame txtFrame = ashp.TextFrame;

    // Erstellt das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.Paragraphs[0];

    // Erstellt ein Portion-Objekt für den Paragraph
    IPortion portion = para.Portions[0];

    // Setzt den Text
    portion.Text = "Aspose TextBox";

    // Speichert die Präsentation auf die Festplatte
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Eigenschaft [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) der Schnittstelle [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) bereit, mit der Sie Formen prüfen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser C#‑Code zeigt Ihnen, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```


Beachten Sie, dass wenn Sie einfach eine AutoShape mit der Methode `AddAutoShape` der Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) hinzufügen, die `IsTextBox`-Eigenschaft der AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zur AutoShape mit der Methode `AddTextFrame` oder der Eigenschaft `Text` hinzugefügt haben, gibt die `IsTextBox`-Eigenschaft `true` zurück.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox ist false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox ist true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox ist false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox ist true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox ist false
    shape3.AddTextFrame("");
    // shape3.IsTextBox ist false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox ist false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox ist false
}
```


## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) und [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (aus der Schnittstelle [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) bzw. der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) zur Verfügung, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld festlegen und anschließend den Abstand in Punkten zwischen den Spalten angeben. 

Dieser C#‑Code demonstriert die beschriebene Vorgehensweise: 
```c#
using (Presentation presentation = new Presentation())
{
	// Holt die erste Folie in der Präsentation
	ISlide slide = presentation.Slides[0];

	// Fügt eine AutoShape mit dem Typ Rectangle hinzu
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Fügt dem Rechteck ein TextFrame hinzu
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Holt das Textformat des TextFrames
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Gibt die Anzahl der Spalten im TextFrame an
	format.ColumnCount = 3;

	// Gibt den Abstand zwischen den Spalten an
	format.ColumnSpacing = 10;

	// Speichert die Präsentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Spalten zu einem Textrahmen hinzufügen**

Aspose.Slides für .NET bietet die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (aus der Schnittstelle [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) an, die es ermöglicht, Spalten in Textframes hinzuzufügen. Mit dieser Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textframe festlegen. 

Dieser C#‑Code zeigt, wie Sie einer Textframe eine Spalte hinzufügen können:
```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```


## **Text aktualisieren**

Aspose.Slides ermöglicht es, den Text in einem Textfeld oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren. 

Dieser C#‑Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Überprüft, ob die Form einen Textrahmen unterstützt (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteriert über die Absätze im Textrahmen
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteriert über jeden Teil im Absatz
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Ändert den Text
                       portion.PortionFormat.FontBold = NullableBool.True; //Ändert die Formatierung
                   }
               }
           }
       }
   }
  
   //Speichert die geänderte Präsentation
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **Ein Textfeld mit Hyperlink hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Nutzer zum Öffnen des Links geleitet. 

1. Erstellen Sie eine Instanz der Klasse `Presentation`. 
2. Rufen Sie die Referenz der ersten Folie über ihren Index ab.  
3. Fügen Sie ein `AutoShape`-Objekt mit `ShapeType` `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape-Objekts. 
4. Fügen Sie dem `AutoShape`-Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die Klasse `IHyperlinkManager`. 
6. Weisen Sie das `IHyperlinkManager`-Objekt der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) zu, die mit dem gewünschten Teil des `TextFrame` verknüpft ist. 
7. Schließlich schreiben Sie die PPTX-Datei über das `Presentation`-Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:
```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX darstellt
Presentation pptxPresentation = new Presentation();

// Holt die erste Folie in der Präsentation
ISlide slide = pptxPresentation.Slides[0];

// Fügt ein AutoShape‑Objekt mit dem Typ Rectangle hinzu
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Castet die Form zu AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Greift auf die ITextFrame‑Eigenschaft der AutoShape zu
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Fügt dem Frame etwas Text hinzu
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Setzt den Hyperlink für den Portion‑Text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Speichert die PPTX‑Präsentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/net/manage-placeholder/) übernimmt Stil/Position vom [Master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) und kann auf [Layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein eigenständiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massenhaften Text‑Austausch in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu verändern?**

Beschränken Sie die Iteration auf AutoShapes, die Textframes besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen getrennt durchlaufen oder diese Objekttypen überspringen.