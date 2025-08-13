---
title: Re-sizing Shapes on Slide
type: docs
weight: 130
url: /net/re-sizing-shapes-on-slide/
---

## **Resizing Shapes on Slide**
One of the most frequent questions asked by the Aspose.Slides for .NET customers is how to resize shapes so that when Slide size is changed the data does not cut off. This short technical tip shows how to achieve that. 

To avoid shapes disorientation, each shape on the slide needs to be updated according to new slide size.

```c#
 //Load a presentation
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//Old slide size
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Changing slide size
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//New slide size
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//Resize position
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//Resize shape size if required 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

If there is any table in the slide then above code would not work perfect. In that case, every cell of the table needs to be resized.

{{% /alert %}} 

You need to use following code on your end if you need to re-size the slides with tables. Setting table width or height is a special case in shapes where you need to alter the individual row height and column width to alter the table height and width.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//Old slide size
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Changing slide size
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//New slide size
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;


float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //Resize position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Resize shape size if required 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //Resize position
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //Resize shape size if required 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //Resize position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Resize shape size if required 
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

presentation.Save("resize.pptx", SaveFormat.Pptx);
```

## FAQ

**Q: Why are shapes distorted or cut off after resizing a slide?**
When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Q: Does the provided code work for all shape types?**
The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**Q: How do I resize tables when resizing a slide?**
You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Q: Will this resizing work for master slides and layout slides?**
Yes, but you should also loop through [`Masters`](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) and [`LayoutSlides`](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Q: Can I change the orientation of a slide (portrait/landscape) along with the resizing?**
Yes. You can set [`presentation.SlideSize.Orientation`](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Q: Is there a limit to the slide size I can set?**
Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**Q: How can I prevent fixed aspect ratio shapes from becoming distorted?**
You can check the `LockAspectRatio` property of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.

