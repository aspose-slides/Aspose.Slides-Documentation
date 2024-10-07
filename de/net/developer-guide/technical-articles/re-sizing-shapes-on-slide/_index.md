---
title: Größenanpassung von Formen auf Folien
type: docs
weight: 130
url: /net/re-sizing-shapes-on-slide/
---

## **Größenanpassung von Formen auf Folien**
Eine der häufigsten Fragen, die von den Kunden von Aspose.Slides für .NET gestellt wird, ist, wie man Formen so anpasst, dass die Daten beim Ändern der Foliengröße nicht abgeschnitten werden. Dieser kurze technische Tipp zeigt, wie man das erreicht.

Um eine Desorientierung der Formen zu vermeiden, muss jede Form auf der Folie gemäß der neuen Foliengröße aktualisiert werden.

```c#
 //Lade eine Präsentation
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//Alte Foliengröße
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Ändern der Foliengröße
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//Neue Foliengröße
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//Größenanpassung der Position
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//Größenanpassung der Form falls erforderlich
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Wenn sich eine Tabelle auf der Folie befindet, funktioniert der obige Code nicht einwandfrei. In diesem Fall muss jede Zelle der Tabelle angepasst werden.

{{% /alert %}} 

Sie müssen den folgenden Code verwenden, wenn Sie die Folien mit Tabellen anpassen möchten. Das Festlegen der Breite oder Höhe einer Tabelle ist ein Sonderfall bei Formen, bei dem Sie die individuelle Höhe der Zeilen und die Breite der Spalten ändern müssen, um die Höhe und Breite der Tabelle zu beeinflussen.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//Alte Foliengröße
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Ändern der Foliengröße
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//Neue Foliengröße
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;


float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //Größenanpassung der Position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Größenanpassung der Form falls erforderlich
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //Größenanpassung der Position
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //Größenanpassung der Form falls erforderlich
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //Größenanpassung der Position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Größenanpassung der Form falls erforderlich
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;
        if (shape is ITable)
        {
            ITable table = (ITable)shape;
            foreach (IRow row in table.Rows)
            {
                row.MinimalHeight = row.MinimalHeight * ratioHeight;
                //   row.Height = row.Height * ratioHeight;
            }
            foreach (IColumn col in table.Columns)
            {
                col.Width = col.Width * ratioWidth;

            }
        }

    }
}

presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);
```