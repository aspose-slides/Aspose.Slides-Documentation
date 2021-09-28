---
title: Shape Formatting
type: docs
weight: 20
url: /java/shape-formatting/
---


## **Format Lines**
Using Aspose.Slides for Java developers can add different kinds of shapes to their slides like line, rectangle. All of these shapes are made up of lines and Aspose.Slides for Java allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic. One such line style is the Join Style supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for Java. It is possible to change the format settings of the lines with which a shape is obtained. For example, you can change the width of the line, modify the color of the line, apply different kinds of styles on the lines etc. To understand the use of this feature, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- Set the Color of the shape lines.
- Set the Width of the shape lines.
- Set the [Line Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineStyle) of the shape lines to one of the styles offered by Aspose.Slides for Java.
- Set the [Dash Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) of the shape lines to one of the styles offered by Aspose.Slides for Java.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected an AutoShape of Rectangle type whose lines are formatted using Aspose.Slides for Java .

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add AutoShape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);
    
    // Set the fill color of the rectangle shape
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Apply some formatting on the line of the rectangle
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);
    
    // set the color of the line of rectangle
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Write the PPTX file to disk
    pres.save("RectShpLn.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Format Join Styles**
[Join Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineJoinStyle) is the style of the outer corners of the shape. They are of three types.

- [Mitter](https://apireference.aspose.com/slides/java/com.aspose.slides/LineJoinStyle#Miter)
- [Bevel](https://apireference.aspose.com/slides/java/com.aspose.slides/LineJoinStyle#Bevel)
- [Round](https://apireference.aspose.com/slides/java/com.aspose.slides/LineJoinStyle#Round)

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add three AutoShapes of rectangle type
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);
    
    // Set the fill color of the rectangle shape
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Set the line width
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);
    
    // Set the color of the line of rectangle
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Set the Join Style
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);
    
    // Add text to each rectangle
    ((IAutoShape) shp1).getTextFrame().setText("This is Miter Join Style");
    ((IAutoShape) shp2).getTextFrame().setText("This is Bevel Join Style");
    ((IAutoShape) shp3).getTextFrame().setText("This is Round Join Style");
    
    // Write the PPTX file to disk
    pres.save("RectShpLnJoin.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gradient Fill**
Aspose.Slides for Java supports different features while filling shapes in slides in topics in upcoming topics we will cover how we can Filling Shapes with pattern, gradient, pictures , solid colors. In this topic, we will discuss about gradient effects by describing the use of two colors with gradient effects offered by Aspose.Slides for Java. To fill a shape with a gradient of two colors, GradientStops can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected the ellipse shape for the demonstration purpose.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);
    
    // Apply some Gradient formatting to ellipse shape
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    
    // Set the Gradient Direction
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);
    
    // Add two Gradient Stops
    shp.getFillFormat().getGradientFormat().getGradientStops().add((float) 1.0, Color.pink);
    shp.getFillFormat().getGradientFormat().getGradientStops().add((float) 0, Color.red);
    
    // Write the PPTX file to disk
    pres.save("EllipseShpGrad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pattern Fill**
This topic covers about patterns that can also be used by developers to fill their shapes in more attractive styles. Aspose.Slides for Java offers more than 45 pre-defined pattern styles that can be used by developers to enrich their presentations. To fill a shape with some pattern using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- Set the [Fill Type](https://apireference.aspose.com/slides/java/com.aspose.slides/FillType) of the Shape to [Pattern](https://apireference.aspose.com/slides/java/com.aspose.slides/FillType#Pattern).
- Set the [Pattern Style](https://apireference.aspose.com/slides/java/com.aspose.slides/PatternStyle) of the Shape.
- Set the [Background Color](https://apireference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) of the [PatternFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
- Set the [Foreground Color](https://apireference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) of the [PatternFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add AutoShape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Set the fill type to Pattern
    shp.getFillFormat().setFillType(FillType.Pattern);
    
    // Set the pattern style
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    
    // Set the pattern back and fore colors
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);
    
    // Write the PPTX file to disk
    pres.save("RectShpPatt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Picture Fill**
In our previous topics, we have discussed about using pre-defined gradient and pattern styles to fill shapes. But, what if a developer needs to fill a shape with an image of his own choice? Well, to answer this question, Aspose.Slides for Java gives full freedom to its users to fill a shape with any desired image. In this topic, we will discuss that how can this be achieved. To fill a shape with a picture using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- Set the Fill Type of the Shape to Picture.
- Set the [Picture Fill Mode](https://apireference.aspose.com/slides/java/com.aspose.slides/PictureFillMode) to [Tile](https://apireference.aspose.com/slides/java/com.aspose.slides/PictureFillMode#Tile).
- Create an IPPImage object using an image that will be used to fill the Shape.
- Set the [Picture.Image](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlidesPicture#setImage-com.aspose.slides.IPPImage-) property of the PictureFillFormat object to the [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object created in above step.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add AutoShape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Set the fill type to Picture
    shp.getFillFormat().setFillType(FillType.Picture);
    
    // Set the picture fill mode
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);
    
    // Set the picture
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("aspose1.jpg")));
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Write the PPTX file to disk
    pres.save("RectShpPic.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Solid Color Fill**
In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for Java provides the simplest API to perform this task. To fill a shape with some solid color using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- Set the [Fill Type](https://apireference.aspose.com/slides/java/com.aspose.slides/FillType) of the Shape to [Solid](https://apireference.aspose.com/slides/java/com.aspose.slides/FillType#Solid).
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Set the fill type to Solid
    shp.getFillFormat().setFillType(FillType.Solid);

    // Set the color of the rectangle
    shp.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Write the PPTX file to disk
    pres.save("RectShpSolid.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rotate Shapes**
Aspose.Slides for Java allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for Java is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add a [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) to the slide.
- [Rotate the Shape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#setRotation-float-) to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add autoshape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rotate the shape to 90 degree
    shp.setRotation(90);

    // Write the PPTX file to disk
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add 3D Bevel Effects**
Aspose.Slides for Java now supports adding 3D bevel effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. [Add a shape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) on slide.
1. Set ThreeDFormat properties of shape.
1. Write the presentation to disk.
   
In the example given below, we have applied 3D bevel effects on a shape.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add a shape on slide
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);
    
    // Set ThreeDFormat properties of shape
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    
    // Write the presentation as a PPTX file
    pres.save("Bavel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add 3D Rotation Effect**
Aspose.Slides for Java now supports adding 3D Rotation effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Rotation Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. [Add a shape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) on slide.
1. Set ThreeDFormat properties of [CameraType](https://apireference.aspose.com/slides/java/com.aspose.slides/IThreeDFormat#getCamera--) and [LightType](https://apireference.aspose.com/slides/java/com.aspose.slides/IThreeDFormat#getLightRig--) properties to shape.
1. Write the presentation to disk.

In the example given below, we have applied 3D Rotation effects on a shape.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    
    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```