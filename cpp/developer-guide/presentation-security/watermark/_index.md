---
title: Watermark
type: docs
weight: 40
url: /cpp/watermark/
keywords: "watermark in presentation"
description: "Use watermark in PowerPoint with Aspose.Slides. Add watermark in ppt presentation or remove watermark. Insert image watermark or text watermark."
---


## **About Watermark**
**Watermark** in presentation is a text or image stamp, used upon a slide or all presentation slides. Usually, watermark is used to indicate that the presentation is a draft (e.g. "Draft" watermark); that it contains confidential information (e.g. "Confidential" watermak); specify which company it belongs to (e.g. "Company name" watermark); identify presentation author, etc. Watermark helps to prevent presentation copyrights violation, indicating that the presentation should not be copied. Watermarks are used with both PowerPoint and OpenOffice presentation formats. In Aspose.Slides you can add watermark to PowerPoint PPT, PPTX and OpenOffice ODP file formats.

In [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) there are various ways you can create watermark in PowerPoint or OpenOffice, to wrap it into different shapes, to change the design and behavior., etc  The common things is, that to add text watermarks you should use [**TextFrame** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame)class and to add image watermark - [**PictureFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame). PictureFrame implements [IShape ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)interface and can use all the power of flexible settings of shape object. TextFrame is not a shape and its settings are limited. Therefore, it is advised to wrap TextFrame into [IShape ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)object.

There are two ways watermark can be applied: to a single slide and to all presentation slides. Slide Master is used to apply watermark to all presentation slides - watermark is added into Slide Master, completely designed there and applied to all slides without modifying a permission to modify watermark on slides.

Watermark is usually considered not to be available for editing by other users. To prevent editing watermark (or rather watermark parent shape), Aspose.Slides provides shape locking functionality. A certain shape can be locked on a normal slide or on a Slide Master. When locking watermark shape on a Slide Master - it will be locked on all presentation slides.

You can set the name of watermark, so in future, if you want to delete the watermark, you may find it in slide shapes by name.

You can design watermark in any way however there are usually attend common features within watermarks, like: center alignment, rotation, front position, etc. We will consider how to use them in the examples below.
## **Text Watermark**
### **Add Text Watermark to Slide**
To add text watermark in PPT, PPTX or ODP you can first add a shape into the slide, then add a text frame into this shape. Text frame is represented with [**TextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) type. This type is not inherited from [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape), which has a wide set of properties to settle the watermark in a flexible way. Therefore, it is advised to wrap [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) object into [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) object. To add watermark into the shape, use [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) method with watermark text passed into it:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Watermark");
```


{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/cpp/slide-master/)[TextFrame](/slides/cpp/adding-and-formatting-text/)
{{% /alert %}}

### **Add Text Watermark to Presentation**
If you want to add watermark in presentation (means, all slides at once), 
add it into [**MasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.master_slide). 
All the other logic is the same as in adding watermark into a single slide - create an 
[IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 
object and then add watermark into it with
 [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) method:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Watermark");
```


{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/cpp/slide-master/)[Slide Master](/slides/cpp/slide-master/)
{{% /alert %}}

### **Set Font of Text Watermark**
You can change the font of text watermark:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->set_FontHeight(52.0f);
```


### **Set Text Watermark Transparency**
To set the transparency of text watermark use this code:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);

watermarkPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Center Text Watermark**
It is possible to center watermark on a slide and for that you can do the following:

``` cpp
PointF center(presentation->get_SlideSize()->get_Size().get_Width() / 2, presentation->get_SlideSize()->get_Size().get_Height() / 2);

float width = 300.0f;
float height = 300.0f;

float x = center.get_X() - width / 2;
float y = center.get_Y() - height / 2;

//...

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, x, y, width, height);
```


## **Image Watermark**
### **Add Image Watermark to Presentation**
To add image watermark into all presentation slides, you may do the following:

``` cpp
auto image = presentation->get_Images()->AddImage(:File::ReadAllBytes(u"watermark.png"));

// ...

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```




## **Lock Watermark from Editing**
If its needed to prevent watermark from editing, use [**AutoShape::get_AutoShapeLock()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape#a3493d7814106e74ef2213707f64135a8)method on the shape, that wraps its. With this method you can protect shape from selection, resize, change position, grouping with other elements, lock its text from editing and many others:

``` cpp
// Lock Shapes from modifying
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```



{{% alert color="primary" title="See also" %}} 
- [How to Lock Shapes from Editing](/slides/cpp/presentation-locking/)
{{% /alert %}}

## **Bring Watermark to Front**
In Aspose.Slides the Z-Order of shapes can be set via [**SlideCollection::Reorder()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad9bc39c557ea8ea3d67e8cec53363c40)method. For that, you need to call this method from presentation slides list and pass shape reference and its order number into the method. This way its possible to put shape to the front or back of the slide. This feature is especially useful if you need to place watermark on front of presentation:

``` cpp
slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, watermarkShape);
```


## **Set Watermark Rotation**
Here is an example how to set the rotation of watermark (and its parent shape):

``` cpp
int32_t calculateRotation(float height, float width)
{
    double pageHeight = Convert::ToDouble(height);
    double pageWidth = Convert::ToDouble(width);
    
    double rotation = Math::Atan((pageHeight / pageWidth)) * 180 / Math::PI;
    
    return Convert::ToInt32(rotation);
}
```

``` cpp
float h = presentation->get_SlideSize()->get_Size().get_Height();
float w = presentation->get_SlideSize()->get_Size().get_Width();

watermarkShape->set_X(static_cast<float>(System::Convert::ToInt32((w - watermarkShape->get_Width()) / 2)));

watermarkShape->set_Y(static_cast<float>(System::Convert::ToInt32((h - watermarkShape->get_Height()) / 2)));

watermarkShape->set_Rotation(static_cast<float>(calculateRotation(h, w)));
```


## **Set Name to Watermark**
Aspose.Slides allows to set the name of shape. By shape name you can access it in future to modify or delete. To set the name of watermark parent shape - set it into [**AutoShape::set_Name()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#ab3df67c6a42fb153d84f58ee69e8b221) method:

``` cpp
watermarkShape->set_Name(u"watermark");
```


## **Remove Watermark**
To remove watermark shape and its child controls from slide, use [AutoShape.get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#a3de41f504e4f9a728c3801159773487e) method to find it in slide shapes. Then pass watermark shape into [**ShapeCollection::Remove()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape_collection#a78968527e6f86cced3ffa5c2accab3fc) method:

``` cpp
for (int32_t i = 0; i < slide->get_Shapes()->get_Count(); i++)
{
	auto shape = DynamicCast<AutoShape>(slide->get_Shapes()->idx_get(i));
	if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
	{
		slide->get_Shapes()->Remove(watermarkShape);
	}
}
```


## **Live Example**
You may want to check out **Aspose.Slides** **free** [**Add Watermark** ](https://products.aspose.app/slides/watermark) and [**Remove Watermark**](https://products.aspose.app/slides/watermark/remove-watermark) online tools. 

![todo:image_alt_text](slides-watermark.png)