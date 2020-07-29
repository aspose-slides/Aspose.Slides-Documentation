---
title: Add Images in Slides using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/add-images-in-slides-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Add Images in Slide**
Below mentioned example shows how different images and autoshapes can be added to presentation slides using Aspose.Slides.

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation(dataDir + "presentation.ppt");

//Accessing a slide using its slide position

ISlide slide = pres.getSlides().get_Item(0);

//===========================================================

// Plain Line

//===========================================================

//Adding a line shape into the slide with its start and end points

slide.getShapes().addAutoShape(ShapeType.Line, 50, 50, 400, 0);

//===========================================================

// Adding Simple Ellipse in the Slide

//============================================================

//Adding an ellipse shape into the slide by defining its X,Y postion, width and height

slide.getShapes().addAutoShape(ShapeType.Ellipse, 270, 150, 350, 50);

//============================================================

// Adding Simple Rectangle in the Slide

//============================================================

//Adding a rectangle shape into the slide by defining its X,Y position, width and height

slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 200, 100);

//===========================================================

// Arrow Shaped Line

//============================================================

///Add an autoshape of type line

IAutoShape shp = slide.getShapes().addAutoShape(ShapeType.Line, 50, 130, 300, 0);

//Apply some formatting on the line

shp.getLineFormat().setStyle (LineStyle.ThickBetweenThin);

shp.getLineFormat().setWidth ( 10);

shp.getLineFormat().setDashStyle  (LineDashStyle.DashDot);

shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);

shp.getLineFormat().setBeginArrowheadStyle (LineArrowheadStyle.Oval);

shp.getLineFormat().setEndArrowheadLength (LineArrowheadLength.Long);

shp.getLineFormat().setEndArrowheadStyle (LineArrowheadStyle.Triangle);

shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);

shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(com.aspose.slides.PresetColor.Maroon));

//===========================================================

// Adding Formatted Ellipse in the Slide

//============================================================

//Add autoshape of ellipse type

shp = slide.getShapes().addAutoShape(ShapeType.Ellipse, 270, 350, 350, 50);

//Apply some formatting to ellipse shape

shp.getFillFormat().setFillType(FillType.Solid);

shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

//Apply some formatting to the line of Ellipse

shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);

shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

shp.getLineFormat().setWidth(5);

//============================================================

// Adding Formatted Rectangle to Slide

//============================================================

//Adding a rectangle shape into the slide by defining its X,Y position, width and height

shp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 350, 200, 100);

//Apply some formatting to ellipse shape

shp.getFillFormat().setFillType(FillType.Solid);

shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

//Apply some formatting to the line of Ellipse

shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);

shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

shp.getLineFormat().setWidth(5);

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Add Images in Slide**
Below mentioned example shows how different images and autoshapes can be added to presentation slides using Apache POI SL.

**Java**

{{< highlight java >}}

 SlideShow ppt = new SlideShow();

Slide slide = ppt.createSlide();

// Line shape

Line line = new Line();

line.setAnchor(new java.awt.Rectangle(50, 50, 100, 20));

line.setLineColor(new Color(0, 128, 0));

line.setLineStyle(Line.LINE_DOUBLE);

slide.addShape(line);

// TextBox

TextBox txt = new TextBox();

txt.setText("Hello, World!");

txt.setAnchor(new java.awt.Rectangle(300, 100, 300, 50));

// use RichTextRun to work with the text format

RichTextRun rt = txt.getTextRun().getRichTextRuns()[0];

rt.setFontSize(32);

rt.setFontName("Arial");

rt.setBold(true);

rt.setItalic(true);

rt.setUnderlined(true);

rt.setFontColor(Color.red);

rt.setAlignment(TextBox.AlignRight);

slide.addShape(txt);

// Autoshape

// 32-point star

AutoShape sh1 = new AutoShape(ShapeTypes.Star32);

sh1.setAnchor(new java.awt.Rectangle(50, 50, 100, 200));

sh1.setFillColor(Color.red);

slide.addShape(sh1);

// Trapezoid

AutoShape sh2 = new AutoShape(ShapeTypes.Trapezoid);

sh2.setAnchor(new java.awt.Rectangle(150, 150, 100, 200));

sh2.setFillColor(Color.blue);

slide.addShape(sh2);

FileOutputStream out = new FileOutputStream(dataDir + "ImageInSlides_Apache.ppt");

ppt.write(out);

out.close();

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/slides/addimages/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/addimages)

{{% alert color="primary" %}} 

For more details, visit [Working with Shapes](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Shapes).

{{% /alert %}}
