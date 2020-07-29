---
title: Insert Auto Shapes in Presentation using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/insert-auto-shapes-in-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Insert Auto Shapes in Presentation**
Aspose.Slides for Java supports adding different kinds of shapes to the slides. Using Aspose.Slides for Java , developers can not only create simple lines , but some fancy lines can also be drawn on the slides.

**Java**

{{< highlight java >}}

 //Get the first slide

ISlide sld = pres.getSlides().get_Item(0);

for (int i = 1 ; i <= ShapeType.ChartPlus ; i++)

{

	System.out.println(i + ". Done.");

	//Add an auto shape of type line

	sld.getShapes().addAutoShape(i, 50, 100, 150, 100);

	sld = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

}

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Insert Auto Shapes in Presentation**
AutoShape class is available to insert various type of shapes in presentation using Apache POI SL - HSLF XSLF

**Java**

{{< highlight java >}}

 //Line shape

Line line = new Line();

line.setAnchor(new java.awt.Rectangle(50, 50, 100, 20));

line.setLineColor(new Color(0, 128, 0));

line.setLineStyle(Line.LINE_DOUBLE);

slide.addShape(line);

//TextBox

TextBox txt = new TextBox();

txt.setText("Hello, World!");

txt.setAnchor(new java.awt.Rectangle(300, 100, 300, 50));

//use RichTextRun to work with the text format

RichTextRun rt = txt.getTextRun().getRichTextRuns()[0];

rt.setFontSize(32);

rt.setFontName("Arial");

rt.setBold(true);

rt.setItalic(true);

rt.setUnderlined(true);

rt.setFontColor(Color.red);

rt.setAlignment(TextBox.AlignRight);

slide.addShape(txt);

//Autoshape

//32-point star

AutoShape sh1 = new AutoShape(ShapeTypes.Star32);

sh1.setAnchor(new java.awt.Rectangle(50, 50, 100, 200));

sh1.setFillColor(Color.red);

slide.addShape(sh1);

//Trapezoid

AutoShape sh2 = new AutoShape(ShapeTypes.Trapezoid);

sh2.setAnchor(new java.awt.Rectangle(150, 150, 100, 200));

sh2.setFillColor(Color.blue);

slide.addShape(sh2);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createautoshapes/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createautoshapes)

{{% alert color="primary" %}} 

For more details, visit [Working with Shapes](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Shapes).

{{% /alert %}}
