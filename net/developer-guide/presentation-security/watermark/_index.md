---
title: Watermark
type: docs
weight: 30
url: /net/watermark/
keywords: "watermark in presentation"
description: "Use watermark in PowerPoint with Aspose.Slides. Add watermark in ppt presentation or remove watermark. Insert image watermark or text watermark."
---


## **About Watermark**
**Watermark** in presentation is a text or image stamp, used upon a slide or all presentation slides. Usually, watermark is used to indicate that the presentation is a draft (e.g. "Draft" watermark); that it contains confidential information (e.g. "Confidential" watermak); specify which company it belongs to (e.g. "Company name" watermark); identify presentation author, etc. Watermark helps to prevent presentation copyrights violation, indicating that the presentation should not be copied. Watermarks are used with both PowerPoint and OpenOffice presentation formats. In Aspose.Slides you can add watermark to PowerPoint PPT, PPTX and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/net) there are various ways you can create watermark in PowerPoint or OpenOffice, to wrap it into different shapes, to change the design and behavior., etc  The common things is, that to add text watermarks you should use [**TextFrame** ](https://apireference.aspose.com/net/slides/aspose.slides/textframe)class and to add image watermark - [**PictureFrame**](https://apireference.aspose.com/net/slides/aspose.slides/pictureframe/). PictureFrame implements [IShape ](https://apireference.aspose.com/net/slides/aspose.slides/ishape)interface and can use all the power of flexible settings of shape object. TextFrame is not a shape and its settings are limited. Therefore, it is advised to wrap TextFrame into [IShape ](https://apireference.aspose.com/net/slides/aspose.slides/ishape)object.

There are two ways watermark can be applied: to a single slide and to all presentation slides. Slide Master is used to apply watermark to all presentation slides - watermark is added into Slide Master, completely designed there and applied to all slides without modifying a permission to modify watermark on slides.

Watermark is usually considered not to be available for editing by other users. To prevent editing watermark (or rather watermark parent shape), Aspose.Slides provides shape locking functionality. A certain shape can be locked on a normal slide or on a Slide Master. When locking watermark shape on a Slide Master - it will be locked on all presentation slides.

You can set the name of watermark, so in future, if you want to delete the watermark, you may find it in slide shapes by name.

You can design watermark in any way however there are usually attend common features within watermarks, like: center alignment, rotation, front position, etc. We will consider how to use them in the examples below.
## **Text Watermark**
### **Add Text Watermark to Slide**
To add text watermark in PPT, PPTX or ODP you can first add a shape into the slide, then add a text frame into this shape. Text frame is represented with [**TextFrame**](https://apireference.aspose.com/net/slides/aspose.slides/textframe) type. This type is not inherited from [IShape](https://apireference.aspose.com/net/slides/aspose.slides/ishape/), which has a wide set of properties to settle the watermark in a flexible way. Therefore, it is advised to wrap [TextFrame](https://apireference.aspose.com/net/slides/aspose.slides/textframe) object into [IAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape/) object. To add watermark into the shape, use [**AddTextFrame**](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape/methods/addtextframe) method with watermark text passed into it:

``` csharp

 using (var presentation = new Presentation())

{

	ISlide slide = presentation.Slides[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Watermark");

}

``` 



{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/net/slide-master/)[TextFrame](/slides/net/adding-and-formatting-text/)
{{% /alert %}}

### **Add Text Watermark to Presentation**
If you want to add watermark in presentation (means, all slides at once), 
add it into [**MasterSlide**](https://apireference.aspose.com/net/slides/aspose.slides/masterslide/). 
All the other logic is the same as in adding watermark into a single slide - create an 
[IAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape/) 
object and then add watermark into it with
 [**AddTextFrame**](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape/methods/addtextframe) method:

``` csharp

 using (var presentation = new Presentation())

{

	IMasterSlide master = pres.Masters[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Watermark");

}

``` 


{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/net/slide-master/)[Slide Master](/slides/net/slide-master/)
{{% /alert %}}

### **Set Font of Text Watermark**
You can change the font of text watermark:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FontHeight = 52;

``` 


### **Set Text Watermark Transparency**
To set the transparency of text watermark use this code:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FillFormat.FillType = FillType.Solid;

watermarkPortion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(alpha, red, green, blue);

``` 


### **Center Text Watermark**
It is possible to center watermark on a slide and for that you can do the following:



``` csharp

 PointF center = new PointF(presentation.SlideSize.Size.Width / 2, presentation.SlideSize.Size.Height / 2);

float width = 300;

float height = 300;

float x = center.X - width / 2;

float y = center.Y - height / 2;



//...



IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, x, y, width, height);

``` 


## **Image Watermark**
### **Add Image Watermark to Presentation**
To add image watermark into all presentation slides, you may do the following:

``` csharp

 IPPImage image = presentation.Images.AddImage(File.ReadAllBytes("watermark.png"));



// ...



watermarkShape.FillFormat.FillType = FillType.Picture;

watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;

watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

``` 




## **Lock Watermark from Editing**
If its needed to prevent watermark from editing, use [**AutoShape.ShapeLock** ](https://apireference.aspose.com/net/slides/aspose.slides/autoshape/properties/shapelock)property on the shape, that wraps its. With this property you can protect shape from selection, resize, change position, grouping with other elements, lock its text from editing and many others:

``` csharp

 // Lock Shapes from modifying

watermarkShape.ShapeLock.SelectLocked = true;

watermarkShape.ShapeLock.SizeLocked = true;

watermarkShape.ShapeLock.TextLocked = true;

watermarkShape.ShapeLock.PositionLocked = true;

watermarkShape.ShapeLock.GroupingLocked = true;

``` 



{{% alert color="primary" title="See also" %}} 
- [How to Lock Shapes from Editing](/slides/net/presentation-locking/)
{{% /alert %}}

## **Bring Watermark to Front**
In Aspose.Slides the Z-Order of shapes can be set via [**SlideCollection.Reorder** ](https://apireference.aspose.com/net/slides/aspose.slides.slidecollection/reorder/methods/1)method. For that, you need to call this method from presentation slides list and pass shape reference and its order number into the method. This way its possible to put shape to the front or back of the slide. This feature is especially useful if you need to place watermark on front of presentation:

``` csharp

 slide.Shapes.Reorder(slide.Shapes.Count - 1, watermarkShape);

``` 


## **Set Watermark Rotation**
Here is an example how to set the rotation of watermark (and its parent shape):

``` csharp

 float h = presentation.SlideSize.Size.Height;

float w = presentation.SlideSize.Size.Width;

watermarkShape.X = Convert.ToInt32((w - watermarkShape.Width) / 2);

watermarkShape.Y = Convert.ToInt32((h - watermarkShape.Height) / 2);

watermarkShape.Rotation = calculateRotation(h, w);



private int calculateRotation(float height, float width)

{

	double pageHeight = Convert.ToDouble(height);

	double pageWidth = Convert.ToDouble(width);

	double rotation = Math.Atan((pageHeight / pageWidth)) * 180 / Math.PI;

	return Convert.ToInt32(rotation);

}

``` 


## **Set Name to Watermark**
Aspose.Slides allows to set the name of shape. By shape name you can access it in future to modify or delete. To set the name of watermark parent shape - set it into [**AutoShape.Name**](https://apireference.aspose.com/net/slides/aspose.slides/ishape/properties/name) property:



``` csharp

 watermarkShape.Name = "watermark";

``` 


## **Remove Watermark**
To remove watermark shape and its child controls from slide, use [AutoShape.Name](https://apireference.aspose.com/net/slides/aspose.slides/ishape/properties/name) property to find it in slide shapes. Then pass watermark shape into [**ShapeCollection.Remove**](https://apireference.aspose.com/net/cells/aspose.cells.drawing/shapecollection/methods/remove) method:

``` csharp

 for (int i = 0; i < slide.Shapes.Count; i++)

{

	AutoShape shape = (AutoShape)slide.Shapes[i];

	if (String.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)

	{

		slide.Shapes.Remove(watermarkShape);

	}

}

``` 


## **Live Example**
To see alive how watermark feature works in Aspose.Slides, try [**Aspose.Slides Watermark** ](https://products.aspose.app/slides/watermark)online free demo:

[](https://products.aspose.app/slides/watermark)

[![todo:image_alt_text](slides-watermark.png)](https://products.aspose.app/slides/watermark)
