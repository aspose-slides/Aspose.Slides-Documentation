---
title: Textfeld verwalten
type: docs
weight: 20
url: /de/net/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld mit Hyperlink
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Verwalten Sie ein Textfeld oder einen Textrahmen in PowerPoint-Präsentationen mit C# oder .NET"
---

Texte in Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, zunächst ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. 

Um Ihnen das Hinzufügen einer Form zu ermöglichen, die Text enthalten kann, stellt Aspose.Slides für .NET das [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)-Interface bereit. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stellt auch das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)-Interface bereit, mit dem Sie Formen zu Folien hinzufügen können. Allerdings können nicht alle über das `IShape`-Interface hinzugefügten Formen Text enthalten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)-Interface hinzugefügt werden, enthalten typischerweise Text. 

Daher sollten Sie, wenn Sie mit einer vorhandenen Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über das `IAutoShape`-Interface gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Textfeld auf Folie erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Holen Sie die Referenz der ersten Folie über ihren Index. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)-Objekt mit [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape`-Objekt. 
4. Fügen Sie dem `IAutoShape`-Objekt eine `TextFrame`-Eigenschaft hinzu, die einen Text enthält. Im nachfolgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox* 
5. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C#‑Code – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:
```c#
// Instanziiert PresentationEx
using (Presentation pres = new Presentation())
{
    // Ruft die erste Folie in der Präsentation ab
    ISlide sld = pres.Slides[0];

    // Fügt eine AutoShape mit Typ Rectangle hinzu
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


## **Überprüfen, ob Form ein Textfeld ist**

Aspose.Slides stellt die [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/)-Eigenschaft des [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-Interfaces bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

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


Beachten Sie, dass wenn Sie einfach eine AutoShape mit der `AddAutoShape`‑Methode des [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/)-Interfaces hinzufügen, die `IsTextBox`‑Eigenschaft der AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zur AutoShape mittels der `AddTextFrame`‑Methode oder der `Text`‑Eigenschaft hinzugefügt haben, gibt die `IsTextBox`‑Eigenschaft `true` zurück.
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


## **Spalte in Textfeld hinzufügen**

Aspose.Slides bietet die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) und [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)-Interface bzw. der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)), mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand in Punkten zwischen den Spalten angeben.

Dieser C#‑Code demonstriert den beschriebenen Vorgang: 
```c#
using (Presentation presentation = new Presentation())
{
	// Holt die erste Folie in der Präsentation
	ISlide slide = presentation.Slides[0];

	// Fügt eine AutoShape mit Typ Rectangle hinzu
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


## **Spalte im Textrahmen hinzufügen**

Aspose.Slides für .NET stellt die [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount)-Eigenschaft (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)-Interface) bereit, die es Ihnen ermöglicht, Spalten in Textrahmen hinzuzufügen. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textrahmen festlegen.

Dieser C#‑Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textrahmens hinzufügen:
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

Aspose.Slides ermöglicht es Ihnen, den in einem Textfeld enthaltenen Text oder alle Texte in einer Präsentation zu ändern bzw. zu aktualisieren.

Dieser C#‑Code demonstriert einen Vorgang, bei dem alle Texte in einer Präsentation aktualisiert bzw. geändert werden:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Überprüft, ob die Form ein Textframe unterstützt (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteriert durch die Absätze im Textframe
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteriert durch jeden Abschnitt im Absatz
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

Sie können einen Link in ein Textfeld einfügen. Beim Anklicken des Textfeldes wird der Link geöffnet.

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse. 
2. Holen Sie die Referenz der ersten Folie über ihren Index.  
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape‑Objekts.
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager`‑Klasse. 
6. Weisen Sie das `IHyperlinkManager`‑Objekt der [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick)-Eigenschaft zu, die dem gewünschten Teil des `TextFrame` zugeordnet ist. 
7. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie einem Slide ein Textfeld mit Hyperlink hinzufügen:
```c#
// Instanziert eine Presentation-Klasse, die ein PPTX darstellt
Presentation pptxPresentation = new Presentation();

// Holt die erste Folie in der Präsentation
ISlide slide = pptxPresentation.Slides[0];

// Fügt ein AutoShape-Objekt mit dem Typ Rechteck hinzu
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Wandelt die Form in AutoShape um
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Greift auf die ITextFrame-Eigenschaft zu, die mit dem AutoShape verknüpft ist
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Fügt dem Rahmen etwas Text hinzu
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Setzt den Hyperlink für den Abschnittstext
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Speichert die PPTX-Präsentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Masterfolien?**

Ein [Platzhalter](/slides/de/net/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.