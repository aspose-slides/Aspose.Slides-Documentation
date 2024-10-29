---
title: تغيير حجم الأشكال على الشريحة
type: docs
weight: 130
url: /ar/net/re-sizing-shapes-on-slide/
---

## **تغيير حجم الأشكال على الشريحة**
واحدة من أكثر الأسئلة شيوعاً التي يطرحها عملاء Aspose.Slides لـ .NET هي كيفية تغيير حجم الأشكال بحيث عندما يتغير حجم الشريحة لا يتم قطع البيانات. تعرض هذه النصيحة الفنية القصيرة كيفية تحقيق ذلك.

لتجنب تشويه الأشكال، يجب تحديث كل شكل على الشريحة وفقاً لحجم الشريحة الجديد.

```c#
 //تحميل عرض تقديمي
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//حجم الشريحة القديم
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//تغيير حجم الشريحة
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//حجم الشريحة الجديد
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//تغيير حجم الموقع
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//تغيير حجم الشكل إذا لزم الأمر 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

إذا كان هناك أي جدول في الشريحة، فإن الكود أعلاه لن يعمل بشكل جيد. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.

{{% /alert %}} 

تحتاج إلى استخدام الكود التالي على الجانب الخاص بك إذا كنت بحاجة إلى تغيير حجم الشرائح مع الجداول. تعديل عرض أو ارتفاع الجدول هو حالة خاصة في الأشكال حيث تحتاج إلى تغيير ارتفاع الصف الفردي وعرض العمود لتغيير ارتفاع الجدول وعرضه.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//حجم الشريحة القديم
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//تغيير حجم الشريحة
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//حجم الشريحة الجديد
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //تغيير حجم الموقع
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //تغيير حجم الشكل إذا لزم الأمر 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //تغيير حجم الموقع
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //تغيير حجم الشكل إذا لزم الأمر 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //تغيير حجم الموقع
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //تغيير حجم الشكل إذا لزم الأمر 
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