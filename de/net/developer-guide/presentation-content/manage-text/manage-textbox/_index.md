---
title: Textfelder in Präsentationen in .NET
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
description: "Aspose.Slides für .NET ermöglicht das einfache Erstellen, Bearbeiten und Duplizieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert so die Automatisierung Ihrer Präsentationen."
---
## **Einleitung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher muss man, um Text zu einer Folie hinzuzufügen, zunächst ein Textfeld hinzufügen und anschließend Text in das Textfeld einfügen. 

Um Ihnen das Hinzufügen einer Form zu ermöglichen, die Text enthalten kann, stellt Aspose.Slides für .NET das [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) Interface zur Verfügung. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stellt außerdem das [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape) Interface zur Verfügung, um Formen zu Folien hinzuzufügen. Allerdings können nicht alle über das `IShape` Interface hinzugefügten Formen Text enthalten. Durch das [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) Interface hinzugefügte Formen enthalten typischerweise Text. 

Daher sollten Sie, wenn Sie mit einer bestehenden Form arbeiten, der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über das `IAutoShape` Interface gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/properties/textframe) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/de/net/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Erstellen eines Textfelds auf einer Folie**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation). 
2. Rufen Sie die Referenz der ersten Folie über ihren Index ab. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) Objekt mit [ShapeType](https://reference.aspose.com/slides/de/net/aspose.slides/igeometryshape/properties/shapetype) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz des neu hinzugefügten `IAutoShape` Objekts. 
4. Fügen Sie dem `IAutoShape` Objekt die Eigenschaft `TextFrame` hinzu, die einen Text enthalten wird. Im nachstehenden Beispiel haben wir folgenden Text hinzugefügt: *Aspose TextBox*
5. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```c#
using Aspose.Slides;

// Instanziiert PresentationEx
using (Presentation pres = new Presentation())
{

    // Ruft die erste Folie in der Präsentation ab
    ISlide sld = pres.Slides[0];

    // Fuegt eine AutoShape mit dem Typ Rectangle hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fuegt dem Rechteck ein TextFrame hinzu
    ashp.AddTextFrame(" ");

    // Greift auf den Textrahmen zu
    ITextFrame txtFrame = ashp.TextFrame;

    // Erstellt das Paragraph-Objekt fuer den Textrahmen
    IParagraph para = txtFrame.Paragraphs[0];

    // Erstellt ein Portion-Objekt fuer den Absatz
    IPortion portion = para.Portions[0];

    // Setzt den Text
    portion.Text = "Aspose TextBox";

    // Speichert die Präsentation auf dem Datentraeger
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Eigenschaft [IsTextBox](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/istextbox/) aus dem [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) Interface bereit, mit der Sie Formen prüfen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser C#‑Code zeigt Ihnen, wie Sie prüfen, ob eine Form als Textfeld erstellt wurde: 

```c#
using Aspose.Slides;

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

Beachten Sie, dass wenn Sie einfach eine AutoShape über die `AddAutoShape` Methode des [IShapeCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/) Interface hinzufügen, die `IsTextBox` Eigenschaft der AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zur AutoShape mit der `AddTextFrame` Methode oder der `Text` Eigenschaft hinzugefügt haben, gibt die `IsTextBox` Eigenschaft `true` zurück.

```cs
using Aspose.Slides;

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

## **Ermitteln der Form, die einen Textrahmen besitzt**

In generischem Textverarbeitungscode können Sie ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) erhalten, ohne bereits zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die Eigenschaft [ITextFrame.ParentShape](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentshape/), um zum besitzenden [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) zurückz navigieren.

Für einen Textrahmen, der zu einer [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) oder einer anderen text‑enthält‑Form gehört, ist [ITextFrame.ParentShape](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentshape/) gesetzt und [ITextFrame.ParentCell](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentcell/) ist `null`. Beide Eigenschaften sind schreibgeschützte Navigations‑Properties, sodass das Auslesen sie keinen Besitz ändert. Überprüfen Sie stets den zurückgegebenen Wert auf `null`, bevor Sie auf die Form zugreifen.

Für ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Besitzer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, siehe [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/columncount) und [ColumnSpacing](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/properties/columnspacing) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat) Interface und der [TextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat) Klasse) bereit, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und anschließend den Abstand in Punkten zwischen den Spalten festlegen. 

Dieser C#‑Code demonstriert die beschriebene Vorgabe: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Ruft die erste Folie in der Präsentation ab
	ISlide slide = presentation.Slides[0];

	// Fügt eine AutoShape mit dem Typ Rectangle hinzu
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Fügt dem Rechteck ein TextFrame hinzu
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Ruft das Textformat des TextFrames ab
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

Aspose.Slides für .NET stellt die Eigenschaft [ColumnCount](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/columncount) (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat) Interface) bereit, mit der Sie Spalten in Textrahmen hinzufügen können. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textrahmen festlegen. 

Dieser C#‑Code zeigt Ihnen, wie Sie einer Textrahmen eine Spalte hinzufügen:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

Aspose.Slides ermöglicht es Ihnen, den in einem Textfeld enthaltenen Text bzw. alle in einer Präsentation enthaltenen Texte zu ändern oder zu aktualisieren. 

Dieser C#‑Code demonstriert einen Vorgang, bei dem alle Texte in einer Präsentation aktualisiert bzw. geändert werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Überprüft, ob die Form einen Textrahmen unterstützt (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteriert durch Absätze im Textrahmen
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteriert durch jeden Teilabschnitt im Absatz
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Benutzer zum Öffnen des Links weitergeleitet. 

1. Erstellen Sie eine Instanz der Klasse `Presentation`. 
2. Rufen Sie die Referenz der ersten Folie über ihren Index ab.  
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape‑Objekts.
4. Fügen Sie dem `AutoShape` Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die Klasse `IHyperlinkManager`. 
6. Weisen Sie das `IHyperlinkManager` Objekt der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/shape/properties/hyperlinkclick) zu, die mit dem gewünschten Abschnitt des `TextFrame` verknüpft ist. 
7. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt. 

Dieser C#‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:

```c#
using Aspose.Slides;

// Instanziiert eine Presentation-Klasse, die eine PPTX darstellt
Presentation pptxPresentation = new Presentation();

// Ruft die erste Folie in der Präsentation ab
ISlide slide = pptxPresentation.Slides[0];

// Fügt ein AutoShape-Objekt mit dem Typ Rectangle hinzu
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Wandelt die Form in AutoShape um
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Greift auf die ITextFrame-Eigenschaft der AutoShape zu
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Fügt dem Rahmen etwas Text hinzu
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Setzt den Hyperlink für den Portion-Text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Speichert die PPTX-Präsentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [placeholder](/slides/de/net/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/de/net/aspose.slides/masterslide/) und kann auf [layouts](https://reference.aspose.com/slides/de/net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/de/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.