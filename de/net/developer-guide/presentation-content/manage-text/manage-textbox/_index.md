---
title: TextBox verwalten
type: docs
weight: 20
url: /net/manage-textbox/
keywords: "Textbox, Textfeld, Textbox hinzufügen, Textbox mit Hyperlink, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie Textbox oder Textfeld zu PowerPoint-Präsentationen in C# oder .NET hinzu"
---

Text auf Folien befindet sich typischerweise in Textboxen oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, zuerst eine Textbox hinzufügen und dann Text in die Textbox einfügen.

Um eine Form, die Text aufnehmen kann, hinzuzufügen, bietet Aspose.Slides für .NET die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) Schnittstelle.

{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides bietet auch die [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Schnittstelle, um Ihnen das Hinzufügen von Formen zu Folien zu ermöglichen. Allerdings können nicht alle Formen, die über die `IShape` Schnittstelle hinzugefügt werden, Text halten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) Schnittstelle hinzugefügt werden, enthalten typischerweise Text.

Daher sollten Sie bei der Arbeit mit einer bestehenden Form, der Sie Text hinzufügen möchten, überprüfen und bestätigen, dass sie über die `IAutoShape` Schnittstelle castet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/net/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Textbox auf Folie erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich die Referenz zur ersten Folie über ihren Index.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) Objekt mit dem [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype), das auf `Rectangle` gesetzt ist, an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape` Objekt.
4. Fügen Sie dem `IAutoShape` Objekt eine `TextFrame` Eigenschaft hinzu, die einen Text enthält. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich speichern Sie die PPTX-Datei über das `Presentation` Objekt.

Dieser C#-Code, eine Implementierung der oben genannten Schritte, zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```c#
// Instantiates PresentationEx
using (Presentation pres = new Presentation())
{

    // Gets the first slide in the presentation
    ISlide sld = pres.Slides[0];

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.AddTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.TextFrame;

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.Paragraphs[0];

    // Creates a Portion object for the paragraph
    IPortion portion = para.Portions[0];

    // Sets the text
    portion.Text = "Aspose TextBox";

    // Saves the presentation to disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Überprüfung auf Textfeldform**

Aspose.Slides bietet die [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) Eigenschaft (aus der [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) Klasse), um Ihnen zu ermöglichen, Formen zu untersuchen und Textboxen zu finden.

![Texfeld und Form](istextbox.png)

Dieser C#-Code zeigt Ihnen, wie Sie überprüfen können, ob eine Form als Textbox erstellt wurde:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "Form ist Textbox" : "Form ist Text, kein Feld");
        }
    });
}
```

## **Spalte in Textbox hinzufügen**

Aspose.Slides bietet die [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) und [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) Eigenschaften (aus der [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) Schnittstelle und [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse), um Ihnen zu ermöglichen, Spalten zu Textboxen hinzuzufügen. Sie können die Anzahl der Spalten in einer Textbox angeben und dann den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Code in C# demonstriert die beschriebene Operation:

```c#
using (Presentation presentation = new Presentation())
{
	// Gets the first slide in the presentation
	ISlide slide = presentation.Slides[0];

	// Add an AutoShape with type set as Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Add TextFrame to the Rectangle
	aShape.AddTextFrame("Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textcontainers zu bleiben -- " +
	"Sie können Text hinzufügen oder löschen und der neue oder verbleibende Text passt sich automatisch an " +
	"an, um innerhalb des Containers zu fließen. Sie können jedoch keinen Text von einem Container " +
	"zum anderen fließen lassen -- wir haben Ihnen gesagt, dass die Spaltenoptionen von PowerPoint für Text begrenzt sind!");

	// Gets the text format of TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specifies the number of columns in TextFrame
	format.ColumnCount = 3;

	// Specifies the spacing between columns
	format.ColumnSpacing = 10;

	// Saves the presentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides für .NET bietet die [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) Eigenschaft (aus der [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) Schnittstelle), die es Ihnen ermöglicht, Spalten in Textfeldern hinzuzufügen. Über diese Eigenschaft können Sie Ihre bevorzugte Anzahl von Spalten in einem Textfeld angeben.

Dieser C#-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textfelds hinzufügen:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "Alle diese Spalten sind gezwungen, innerhalb eines einzigen Textcontainers zu bleiben -- " +
                                "Sie können Text hinzufügen oder löschen - und der neue oder verbleibende Text passt sich automatisch an " +
                                "an, um innerhalb des Containers zu bleiben. Sie können jedoch keinen Text von einem Container " +
                                "zum anderen fließen lassen, denn die Spaltenoptionen von PowerPoint für Text sind begrenzt!";
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

Aspose.Slides ermöglicht es Ihnen, den Text in einer Textbox oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren.

Dieser C#-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Überprüft, ob die Form ein Textfeld unterstützt (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Durchläuft die Absätze im Textfeld
               {
                   foreach (IPortion portion in paragraph.Portions) //Durchläuft jeden Teil des Absatzes
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Ändert den Text
                       portion.PortionFormat.FontBold = NullableBool.True; //Ändert die Formatierung
                   }
               }
           }
       }
   }

   //Speichert die modifizierte Präsentation
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Textbox mit Hyperlink hinzufügen**

Sie können einen Link in eine Textbox einfügen. Wenn die Textbox angeklickt wird, werden die Benutzer aufgefordert, den Link zu öffnen.

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Holen Sie sich die Referenz zur ersten Folie über ihren Index.
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` auf `Rectangle` gesetzt an einer bestimmten Position auf der Folie hinzu und erhalten Sie eine Referenz auf das neu hinzugefügte AutoShape-Objekt.
4. Fügen Sie ein `TextFrame` zum `AutoShape` Objekt hinzu, das *Aspose TextBox* als Standardtext enthält.
5. Instanziieren Sie die Klasse `IHyperlinkManager`.
6. Weisen Sie das `IHyperlinkManager` Objekt der [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) Eigenschaft zu, die mit dem gewünschten Teil des `TextFrame` verknüpft ist.
7. Schließlich speichern Sie die PPTX-Datei über das `Presentation` Objekt.

Dieser C#-Code, eine Implementierung der oben genannten Schritte, zeigt Ihnen, wie Sie eine Textbox mit einem Hyperlink zu einer Folie hinzufügen:

```c#
// Instantiates a Presentation class that represents a PPTX
Presentation pptxPresentation = new Presentation();

// Gets the first slide in the presentation
ISlide slide = pptxPresentation.Slides[0];

// Adds an AutoShape object with type set as Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Casts the shape to AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accesses the ITextFrame property associated with the AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adds some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Sets the Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Saves the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```