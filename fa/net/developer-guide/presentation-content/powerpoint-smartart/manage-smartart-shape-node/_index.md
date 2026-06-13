---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با .NET
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/net/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره دستیار
- قالب پر کردن
- رندر گره
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای .NET. نمونه‌های کد واضح و نکات برای بهینه‌سازی ارائه‌های خود را دریافت کنید."
---
## **بررسی کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن را شامل می‌شوند و ساختار دیاگرام را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد تا به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: گره‌ها و گره‌های فرزند جدید اضافه کنید، گره‌های فرزند را در موقعیت خاصی وارد کنید، به گره‌های موجود دسترسی پیدا کنید و متن، سطح و موقعیت آن‌ها را بخوانید.

این مقاله توضیح می‌دهد چگونه گره‌های شکل SmartArt را مدیریت کنید. در این مقاله نحوه حذف گره‌ها، کار با گره‌های فرزند بر اساس شاخص یا موقعیت، تغییر گره دستیار به گره عادی، تنظیم موقعیت، اندازه و چرخش شکل‌های گره SmartArt، تعیین قالب‌های پر کردن گره و تولید تصویر بندانگشتی برای یک گره فرزند SmartArt نشان داده می‌شود.

## **افزودن یک گره SmartArt**
Aspose.Slides for .NET ساده‌ترین API را برای مدیریت اشکال SmartArt به راحت‌ترین روش فراهم کرده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را داخل شکل SmartArt اضافه کنید.

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArt تبدیل (Typecast) کنید.
- یک گره جدید در NodeCollection شکل SmartArt اضافه کنید و متن را در TextFrame تنظیم کنید.
- حالا یک گره فرزند در گره SmartArt تازه اضافه‌شده اضافه کنید و متن را در TextFrame تنظیم کنید.
- ارائه را ذخیره کنید.

```c#
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddNodes.pptx");

// پیمایش تمام اشکال داخل اسلاید اول
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // بررسی کنید آیا شکل از نوع SmartArt است
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تبدیل نوع شکل به SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // افزودن گره جدید SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // افزودن متن
        TemNode.TextFrame.Text = "Test";

        // افزودن گره فرزند جدید به گره والد. این گره در انتهای مجموعه اضافه می‌شود
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // افزودن متن
        newNode.TextFrame.Text = "New Node Added";

    }
}

// ذخیره‌سازی ارائه
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **افزودن گره SmartArt در موقعیت خاص**
در کد نمونه زیر نحوه افزودن گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt در موقعیت خاص توضیح داده شده است.

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- یک شکل SmartArt از نوع StackedList در اسلاید دسترسی‑یافته اضافه کنید.
- گره اول در شکل SmartArt اضافه‌شده را دسترسی پیدا کنید.
- حالا گره فرزند برای گره انتخاب‌شده را در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
- ارائه را ذخیره کنید.

```c#
// ایجاد یک نمونه ارائه
Presentation pres = new Presentation();

// دسترسی به اسلاید ارائه
ISlide slide = pres.Slides[0];

// افزودن IShape Smart Art
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// دسترسی به گره SmartArt در شاخص 0
ISmartArtNode node = smart.AllNodes[0];

// افزودن گره فرزند جدید در موقعیت 2 در گره والد
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// افزودن متن
chNode.TextFrame.Text = "Sample Text Added";

// ذخیره‌سازی ارائه
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **دسترسی به گره SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType گره SmartArt را تغییر دهید زیرا فقط در زمان افزودن شکل SmartArt قابل تنظیم است و به صورت فقط‑خواندنی است.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArt تبدیل کنید.
- در تمام گره‌های داخل شکل SmartArt پیمایش کنید.
- اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```c#
  // بارگذاری ارائه مورد نظر
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // پیمایش تمام اشکال داخل اسلاید اول
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // بررسی کنید آیا شکل از نوع SmartArt است
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // تبدیل نوع shape به SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // پیمایش تمام گره‌های داخل SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // دسترسی به گره SmartArt در شاخص i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // چاپ پارامترهای گره SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **دسترسی به گره فرزند SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt دسترسی پیدا کنید.

- یک نمونه از کلاس PresentationEx ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArtEx تبدیل کنید.
- در تمام گره‌های داخل شکل SmartArt پیمایش کنید.
- برای هر گره شکل SmartArt انتخاب‌شده، در گره خاص مربوطه تمام گره‌های فرزند را پیمایش کنید.
- اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را دسترسی و نمایش دهید.

```c#
 // بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AccessChildNodes.pptx");

// پیمایش تمام اشکال داخل اسلاید اول
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // بررسی کنید آیا شکل از نوع SmartArt است
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تبدیل نوع shape به SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // پیمایش تمام گره‌های داخل SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // دسترسی به گره SmartArt در شاخص i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // پیمایش گره‌های فرزند در گره SmartArt با شاخص i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // دسترسی به گره فرزند در گره SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // چاپ پارامترهای گره فرزند SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **دسترسی به گره فرزند SmartArt در موقعیت خاص**
در این مثال، نحوه دسترسی به گره‌های فرزند در موقعیت خاصی که متعلق به گره‌های مختلف شکل SmartArt هستند را می‌آموزیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- یک شکل SmartArt از نوع StackedList اضافه کنید.
- به شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
- گره‌ای با شاخص 0 برای شکل SmartArt دسترسی‑یافته را دسترسی پیدا کنید.
- حالا گره فرزند را در موقعیت 1 برای گره SmartArt دسترسی‑یافته با استفاده از متد GetNodeByPosition() دسترسی پیدا کنید.
- اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را دسترسی و نمایش دهید.

```c#
 // ایجاد نمونه ارائه
Presentation pres = new Presentation();

 // دسترسی به اسلاید اول
ISlide slide = pres.Slides[0];

 // افزودن شکل SmartArt در اسلاید اول
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // دسترسی به گره SmartArt  در شاخص 0
ISmartArtNode node = smart.AllNodes[0];

 // دسترسی به گره فرزند در موقعیت 1 در گره والد
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // چاپ پارامترهای گره فرزند SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **حذف گره SmartArt**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt را می‌آموزیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArt تبدیل کنید.
- بررسی کنید آیا SmartArt بیش از 0 گره دارد.
- گره SmartArt مورد نظر برای حذف را انتخاب کنید.
- حالا گره انتخاب شده را با استفاده از متد RemoveNode() حذف کنید و ارائه را ذخیره کنید.

```c#
// بارگذاری ارائه مورد نظر
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // پیمایش تمام اشکال داخل اسلاید اول
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape is ISmartArt)
        {
            // تبدیل نوع shape به SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // دسترسی به گره SmartArt در شاخص 0
                ISmartArtNode node = smart.AllNodes[0];

                // حذف گره انتخاب‌شده
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // ذخیره‌سازی ارائه
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **حذف گره SmartArt در موقعیت خاص**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt در موقعیت خاص را می‌آموزیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید اول را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArt تبدیل کنید.
- گره شکل SmartArt را در شاخص 0 انتخاب کنید.
- حالا بررسی کنید آیا گره SmartArt انتخاب‌شده بیش از 2 گره فرزند دارد.
- حالا گره را در موقعیت 1 با استفاده از متد RemoveNodeByPosition() حذف کنید.
- ارائه را ذخیره کنید.

```c#
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// پیمایش تمام اشکال داخل اسلاید اول
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // بررسی کنید آیا شکل از نوع SmartArt است
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // تبدیل نوع shape به SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // دسترسی به گره SmartArt در شاخص 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // حذف گره فرزند در موقعیت 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// ذخیره‌سازی ارائه
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **تنظیم موقعیت سفارشی برای گره فرزند در شیء SmartArt**
در حال حاضر Aspose.Slides for .NET از تنظیم ویژگی‌های X و Y برای SmartArtShape پشتیبانی می‌کند. قطعه کد زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی SmartArtShape را تنظیم کنید؛ همچنین توجه داشته باشید که افزودن گره‌های جدید باعث محاسبه مجدد موقعیت‌ها و اندازه‌های تمام گره‌ها می‌شود.

```c#
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// جابه‌جایی شکل SmartArt به موقعیت جدید
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// تغییر عرض‌های شکل SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// تغییر ارتفاع شکل SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// تغییر چرخش شکل SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **بررسی گره دستیار**
در کد نمونه زیر بررسی می‌کنیم چگونه گره‌های دستیار را در مجموعه گره‌های SmartArt شناسایی و تغییر دهیم.

- یک نمونه از کلاس PresentationEx ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- با استفاده از Index، مرجع اسلاید دوم را بدست آورید.
- در تمام اشکال داخل اسلاید اول جستجو کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و اگر هست شکل انتخاب شده را به SmartArtEx تبدیل کنید.
- در تمام گره‌های داخل شکل SmartArt پیمایش کنید و بررسی کنید آیا گره‌ها دستیار هستند.
- وضعیت گره دستیار را به گره عادی تغییر دهید.
- ارائه را ذخیره کنید.

```c#
// ایجاد یک نمونه ارائه
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // پیمایش تمام اشکال داخل اسلاید اول
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // تبدیل نوع shape به SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // پیمایش تمام گره‌های شکل SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // بررسی کنید آیا گره یک گره دستیار است
                if (node.IsAssistant)
                {
                    // تنظیم گره دستیار به false و تبدیل آن به گره عادی
                    node.IsAssistant = false;
                }
            }
        }
    }
    // ذخیره‌سازی ارائه
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تنظیم قالب پر کردن گره**
Aspose.Slides for .NET امکان افزودن اشکال سفارشی SmartArt و تنظیم قالب پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد و دسترسی یافته و قالب پر کردن آن‌ها را با استفاده از Aspose.Slides for .NET تنظیم کنیم.

لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- با استفاده از شاخص، مرجع یک اسلاید را بدست آورید.
- یک شکل SmartArt با تنظیم LayoutType اضافه کنید.
- قالب FillFormat را برای گره‌های شکل SmartArt تنظیم کنید.
- ارائه اصلاح‌شده را به عنوان فایل PPTX بنویسید.

```c#
using (Presentation presentation = new Presentation())
{
    // دسترسی به اسلاید
    ISlide slide = presentation.Slides[0];

    // افزودن شکل SmartArt و گره‌ها
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // تنظیم رنگ پر کردن گره
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // ذخیره‌سازی ارائه
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **تولید تصویر بندانگشتی از گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با انجام مراحل زیر تصویر بندانگشتی از گره فرزند SmartArt تولید کنند:

1. یک نمونه از کلاس `Presentation` که نمایانگر فایل PPTX است، ایجاد کنید.
1. SmartArt را اضافه کنید.
1. با استفاده از Index، مرجع یک گره را بدست آورید.
1. تصویر بندانگشتی را دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویری دلخواهی ذخیره کنید.

مثال زیر یک تصویر بندانگشتی از گره فرزند SmartArt تولید می‌کند

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **سوالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به عنوان یک شکل معمولی در نظر گرفته می‌شود، بنابراین می‌توانید [apply standard animations](/slides/fa/net/shape-animation/) (ورودی، خروجی، تاکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم نمایید. همچنین در صورت نیاز می‌توانید شکل‌های داخل گره‌های SmartArt را نیز انیمیت کنید.

**چگونه می‌توانم یک SmartArt خاص را در اسلاید به‌صورت قابل اطمینان پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با استفاده از [alternative text](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/alternativetext/) جستجو کنید. تنظیم AltText متمایزی بر روی SmartArt به شما امکان می‌دهد آن را به‌صورت برنامه‌نویسی پیدا کنید بدون اینکه به شناسه‌های داخلی وابسته باشید.

**آیا ظاهر SmartArt در هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides SmartArt را با دقت بصری بالا در طول [PDF export](/slides/fa/net/convert-powerpoint-to-pdf/) رندر می‌کند و طرح، رنگ‌ها و افکت‌ها را حفظ می‌کند.

**آیا می‌توانم تصویر کامل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟**

بله. می‌توانید یک شکل SmartArt را به [raster formats](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage/) یا به [SVG](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) رندر کنید تا خروجی برداری مقیاس‌پذیر داشته باشید، که برای بندانگشتی‌ها، گزارش‌ها یا استفاده در وب مناسب است.