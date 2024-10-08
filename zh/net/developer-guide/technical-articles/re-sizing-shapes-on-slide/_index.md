---
title: 在幻灯片上调整形状大小
type: docs
weight: 130
url: /zh/net/re-sizing-shapes-on-slide/
---

## **在幻灯片上调整形状大小**
Aspose.Slides for .NET 客户常问的一个问题是如何调整形状的大小，以便在改变幻灯片大小时数据不会被切割。这篇简短的技术提示展示了如何实现这一点。

为了避免形状错位，幻灯片上的每个形状需要根据新的幻灯片大小进行更新。

```c#
 //加载演示文稿
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//旧幻灯片大小
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//改变幻灯片大小
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//新幻灯片大小
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//调整位置
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//如果需要，调整形状大小 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

如果幻灯片中有表格，则以上代码将无法完美工作。在这种情况下，表格的每个单元格都需要调整大小。

{{% /alert %}} 

如果需要调整包含表格的幻灯片大小，则需要在您的端使用以下代码。设置表格的宽度或高度是形状中的特殊情况，您需要更改单独的行高和列宽以更改表格的高度和宽度。

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//旧幻灯片大小
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//改变幻灯片大小
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//新幻灯片大小
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;


float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //调整位置
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //如果需要，调整形状大小 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //调整位置
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //如果需要，调整形状大小 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //调整位置
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //如果需要，调整形状大小 
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