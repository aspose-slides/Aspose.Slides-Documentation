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
description: "Aspose.Slides für .NET erleichtert das Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher musst du, um Text zu einer Folie hinzuzufügen, zuerst ein Textfeld hinzufügen und anschließend Text in das Textfeld einfügen. 

Um dir zu ermöglichen, eine Form hinzuzufügen, die Text enthalten kann, stellt Aspose.Slides für .NET die Schnittstelle [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) bereit. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stellt außerdem die Schnittstelle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) bereit, mit der du Formen zu Folien hinzufügen kannst. Allerdings können nicht alle über die `IShape`‑Schnittstelle hinzugefügten Formen Text enthalten. Über die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‑Schnittstelle hinzugefügte Formen enthalten typischerweise Text. 

Daher solltest du, wenn du einer bestehenden Form Text hinzufügen möchtest, prüfen und bestätigen, dass sie über die `IAutoShape`‑Schnittstelle gecastet wurde. Nur dann kannst du mit [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) arbeiten, einer Eigenschaft von `IAutoShape`. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Textfeld auf Folie erstellen**

1. Erstelle eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Hole die Referenz der ersten Folie über deren Index. 
3. Füge ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‑Objekt mit [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalte die Referenz für das neu hinzugefügte `IAutoShape`‑Objekt. 
4. Füge dem `IAutoShape`‑Objekt die Eigenschaft `TextFrame` hinzu, die einen Text enthält. Im nachfolgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox* 
5. Schließlich schreibe die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt, wie man Text zu einer Folie hinzufügt:
```c#
// Instanziiert PresentationEx
using (Presentation pres = new Presentation())
{

    // Holt die erste Folie in der Präsentation
    ISlide sld = pres.Slides[0];

    // Fügt ein AutoShape mit Typ Rectangle hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügt dem Rechteck ein TextFrame hinzu
    ashp.AddTextFrame(" ");

    // Greift auf das TextFrame zu
    ITextFrame txtFrame = ashp.TextFrame;

    // Erstellt das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.Paragraphs[0];

    // Erstellt ein Portion-Objekt für den Paragraphen
    IPortion portion = para.Portions[0];

    // Setzt den Text
    portion.Text = "Aspose TextBox";

    // Speichert die Präsentation auf die Festplatte
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Überprüfen, ob es sich um ein Textfeld handelt**

Aspose.Slides stellt die Eigenschaft [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) von der [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)‑Schnittstelle bereit, mit der du Formen untersuchen und Textfelder identifizieren kannst.

![Text box and shape](istextbox.png)

Dieser C#‑Code zeigt, wie man prüft, ob eine Form als Textfeld erstellt wurde: 
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


Beachte, dass das `IsTextBox`‑Attribut einer AutoShape, die lediglich mit der Methode `AddAutoShape` aus der [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/)‑Schnittstelle hinzugefügt wird, `false` zurückgibt. Nachdem jedoch Text über die Methode `AddTextFrame` oder die Eigenschaft `Text` hinzugefügt wurde, gibt das `IsTextBox`‑Attribut `true` zurück.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox ist falsch
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox ist wahr

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox ist falsch
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox ist wahr

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox ist falsch
    shape3.AddTextFrame("");
    // shape3.IsTextBox ist falsch

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox ist falsch
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox ist falsch
}
```


## **Spalte im Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) und [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)‑Schnittstelle und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) bereit, um Spalten zu Textfeldern hinzuzufügen. Du kannst die Anzahl der Spalten in einem Textfeld festlegen und anschließend den Abstand in Punkten zwischen den Spalten bestimmen. 

Dieser Code in C# demonstriert die beschriebene Vorgehensweise: 
```c#
using (Presentation presentation = new Presentation())
{
	// Holt die erste Folie in der Präsentation
	ISlide slide = presentation.Slides[0];

	// Fügt ein AutoShape mit Typ Rectangle hinzu
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


## **Spalte im Textframe hinzufügen**

Aspose.Slides für .NET stellt die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)‑Schnittstelle) bereit, mit der du Spalten in Textframes hinzufügen kannst. Über diese Eigenschaft kannst du die gewünschte Spaltenanzahl in einem Textframe festlegen. 

Dieser C#‑Code zeigt, wie du eine Spalte innerhalb eines Textframes hinzufügst:
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

Aspose.Slides ermöglicht es dir, den Text in einem Textfeld oder sämtlichen Texten einer Präsentation zu ändern oder zu aktualisieren. 

Dieser C#‑Code demonstriert einen Vorgang, bei dem alle Texte einer Präsentation aktualisiert bzw. geändert werden:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Prüft, ob die Form Textframe unterstützt (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteriert durch die Absätze im Textframe
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteriert durch jeden Portion im Absatz
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


## **Textfeld mit Hyperlink hinzufügen** 

Du kannst einen Link in ein Textfeld einfügen. Beim Klicken auf das Textfeld wird der Link geöffnet. 

1. Erstelle eine Instanz der Klasse `Presentation`. 
2. Hole die Referenz der ersten Folie über deren Index.  
3. Füge ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalte eine Referenz des neu hinzugefügten AutoShape‑Objekts. 
4. Füge dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziiere die Klasse `IHyperlinkManager`. 
6. Weise das `IHyperlinkManager`‑Objekt der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) zu, die mit dem gewünschten Teil des `TextFrame` verknüpft ist. 
7. Schließlich schreibe die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt, wie du ein Textfeld mit Hyperlink zu einer Folie hinzufügst:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX darstellt
Presentation pptxPresentation = new Presentation();

// Holt die erste Folie in der Präsentation
ISlide slide = pptxPresentation.Slides[0];

// Fügt ein AutoShape-Objekt mit dem Typ Rectangle hinzu
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Wandelt die Form in AutoShape um
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Greift auf die ITextFrame-Eigenschaft zu, die mit dem AutoShape verknüpft ist
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Fügt dem Frame etwas Text hinzu
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Setzt den Hyperlink für den Portion-Text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Speichert die PPTX-Präsentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter beim Arbeiten mit Masterfolien?**

Ein [Platzhalter](/slides/de/net/manage-placeholder/) übernimmt Stil/Position vom [Master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn du das Layout wechselst.

**Wie kann ich einen massenhaften Textaustausch in der gesamten Präsentation durchführen, ohne den Text in Diagrammen, Tabellen und SmartArt zu verändern?**

Beschränke deine Iteration auf Auto‑Shapes, die TextFrames besitzen, und schließe eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) aus, indem du deren Sammlungen separat durchgehst oder diese Objekttypen überspringst.