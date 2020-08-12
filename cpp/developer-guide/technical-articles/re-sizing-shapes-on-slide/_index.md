---
title: Re-sizing Shapes on Slide
type: docs
weight: 100
url: /cpp/re-sizing-shapes-on-slide/
---

#### **Resizing Shapes on Slide**
One of the most frequent questions asked by the Aspose.Slides for C++ customers is how to resize shapes so that when Slide size is changed the data does not cut off. This short technical tip shows how to achieve that. 

To avoid shapes disorientation, each shape on the slide needs to be updated according to new slide size.

**C#**

```

      //Load a presentation

     Presentation presentation = new Presentation(@"D:\TestResize.ppt");



     //Old slide size

     float currentHeight = presentation.SlideSize.Size.Height;

     float currentWidth = presentation.SlideSize.Size.Width;

     //Changing slide size

     presentation.SlideSize.Type = SlideSizeType.A4Paper;

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

     presentation.Save("Resize.pptx",SaveFormat.Pptx);

```

{{% alert color="primary" %}} 

If there is any table in the slide then above code would not work perfect. In that case, every cell of the table needs to be resized.

{{% /alert %}} 

You need to use following code on your end if you need to re-size the slides with tables. Setting table width or height is a special case in shapes where you need to alter the individual row height and column width to alter the table height and width.

**C#**

```

     Presentation presentation = new Presentation("D:\\Test.pptx");

    //Old slide size

    float currentHeight = presentation.SlideSize.Size.Height;

    float currentWidth = presentation.SlideSize.Size.Width;

    //Changing slide size

    presentation.SlideSize.Type = SlideSizeType.A4Paper;

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

    presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);

```
