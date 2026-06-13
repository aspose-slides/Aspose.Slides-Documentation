---
title: مدیریت SmartArt در ارائه‌های PowerPoint در .NET
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/net/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح‌بندی
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای .NET SmartArt پاورپوینت را با نمونه‌های کد واضح C# بسازید و ویرایش کنید تا طراحی اسلاید و خودکارسازی را تسریع کنید."
---
## **مرور کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره‌ها و یک طرح‌بندی ساخته می‌شود. با Aspose.Slides برای .NET می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی نمودارهای سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری بسازید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن قابل مشاهده، از طریق [ISmartArt.AllNodes](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartart/allnodes/) پیمایش کنید، سپس [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) برگشتی توسط [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartartshape/textframe/) را بخوانید.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt تعیین می‌کند گره‌ها چگونه چینیده و به هم متصل می‌شوند. مثال زیر یک شیء SmartArt با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است یا خیر**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartartnode/ishidden/) نشان می‌دهد آیا گره در مدل داده SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخاب شده آن‌ها را به عنوان عناصر نموداری قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به یک شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره را بررسی می‌نماید.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) تعیین می‌کند گره‌های فرزند تحت یک گره والد چگونه چینیده شوند. برای مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو سمت آویزان شوند، بسته به مقدار انتخاب شده در [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/organizationchartlayouttype/).

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` تنظیم می‌نماید.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌نگهدارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` را استفاده کنید.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**آیا SmartArt از آینه‌سازی یا معکوس کردن برای زبان‌های راست‌به‌چپ (RTL) پشتیبانی می‌کند؟**

بله. ویژگی [IsReversed](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartart/isreversed/) جهت نمودار را از چپ به راست به راست به چپ یا بالعکس تغییر می‌دهد، هنگامی که طرح‌بندی SmartArt انتخاب شده از معکوس کردن پشتیبانی کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائه دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید با استفاده از [کلون کردن شکل SmartArt](/slides/fa/net/shape-manipulations/) با [ShapeCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/shapecollection/addclone/) یا با [کلون کردن کل اسلاید](/slides/fa/net/clone-slides/) که شامل SmartArt است، اقدام کنید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌نمایند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا خروجی وب رندر کنم؟**

[رندر اسلاید](/slides/fa/net/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

یک مقدار متمایز برای [AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/alternativetext/) یا [Name](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/name/) بر روی شکل SmartArt تنظیم کنید، آن مقدار را در [Slide.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide/shapes/) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartart/) باشد.