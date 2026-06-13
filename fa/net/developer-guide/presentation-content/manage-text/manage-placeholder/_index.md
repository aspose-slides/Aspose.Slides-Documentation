---
title: "مدیریت نگهدارنده‌های ارائه در .NET"
linktitle: "مدیریت نگهدارنده‌ها"
type: docs
weight: 10
url: /fa/net/manage-placeholder/
keywords:
- نگهدارنده
- نگهدارنده متن
- نگهدارنده تصویر
- نگهدارنده نمودار
- متن راهنما
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی نگهدارنده‌ها را در Aspose.Slides برای .NET مدیریت کنید: متن را جایگزین کنید، راهنماها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم نمایید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا نگهدارنده‌های ارائه را به‌صورت برنامه‌نویسی مدیریت کنید. این مقاله توضیح می‌دهد که چگونه نگهدارنده‌ها را در اسلایدها پیدا کنید و متن آنها را تغییر دهید، متن راهنمای سفارشی برای طرح‌های نگهدارنده تنظیم کنید و شفافیت تصویر استفاده‌شده به‌عنوان پس‌زمینهٔ نگهدارنده را تنظیم کنید. همچنین شامل یک بخش کوتاه سؤالات متداول است که تفاوت بین نگهدارنده‌های پایه و شکل‌های محلی را روشن می‌کند، نحوهٔ اعمال تغییرات نگهدارنده از طریق طرح‌ها یا استادها را شرح می‌دهد و به مدیریت نگهدارنده‌های سرصفحه و پاورقی اشاره می‌کند.

## **تغییر متن در یک نگهدارنده**
با استفاده از [Aspose.Slides for .NET](/slides/fa/net/)، می‌توانید نگهدارنده‌ها را در اسلایدهای ارائه پیدا کنید و آنها را اصلاح کنید. Aspose.Slides به شما امکان می‌دهد تا متن موجود در یک نگهدارنده را تغییر دهید.

**پیش‌نیاز**: شما به ارائه‌ای نیاز دارید که حاوی یک نگهدارنده باشد. می‌توانید چنین ارائه‌ای را با استفاده از برنامهٔ استاندارد Microsoft PowerPoint ایجاد کنید.

این روش استفاده از Aspose.Slides برای جایگزینی متن در نگهدارندهٔ آن ارائه است:

1. یک نمونه از کلاس [`Presentation`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید و ارائه را به‌عنوان آرگومان پاس دهید.
2. از طریق ایندکس آن، یک مرجع اسلاید دریافت کنید.
3. از طریق اشکال، برای یافتن نگهدارنده مرور کنید.
4. نگهدارندهٔ شکل را به یک [`AutoShape`](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) تبدیل کنید و متن را با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) مرتبط با [`AutoShape`](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) تغییر دهید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه متن در یک نگهدارنده را تغییر دهید:

```c#
 // یک شی از کلاس Presentation را ایجاد می‌کند
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.Slides[0];

    // از طریق اشکال مرور می‌کند تا نگهدارنده را پیدا کند
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // متن هر نگهدارنده را تغییر می‌دهد
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // ارائه را در دیسک ذخیره می‌کند
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تنظیم متن راهنما در یک نگهدارنده**
طرح‌های استاندارد و پیش‌ساخته شامل متن‌های راهنمای نگهدارنده‌ای مانند ***Click to add a title*** یا ***Click to add a subtitle*** هستند. با استفاده از Aspose.Slides، می‌توانید متن‌های راهنمای مورد علاقهٔ خود را در طرح‌های نگهدارنده درج کنید.

این کد C# نشان می‌دهد چگونه متن راهنما را در یک نگهدارنده تنظیم کنید:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // در اسلاید مرور می‌کند
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint متن «Click to add title» را نمایش می‌دهد
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // زیرعنوان را اضافه می‌کند
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **تنظیم شفافیت تصویر نگهدارنده**

Aspose.Slides به شما امکان می‌دهد تا شفافیت تصویر پس‌زمینه در یک نگهدارندهٔ متنی را تنظیم کنید. با تنظیم شفافیت تصویر در چنین قاب‌ایی، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد C# نشان می‌دهد چگونه شفافیت پس‌زمینهٔ تصویر (درون یک شکل) را تنظیم کنید:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **سوالات متداول**

**نگهدارنده پایه چیست و چگونه با شکل محلی روی اسلاید متفاوت است؟**

نگهدارندهٔ پایه، شکل اصلی در یک طرح یا استاد است که شکل اسلاید از آن نوع، موقعیت و برخی قالب‌بندی‌ها را به ارث می‌برد. شکل محلی مستقل است؛ اگر نگهدارندهٔ پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توان تمام عناوین یا توضیحات را در سرتاسر یک ارائه به‌روز کرد بدون اینکه بر روی هر اسلاید به‌صورت جداگانه پیمایش کنم؟**

نگهدارنده مربوطه را در طرح یا استاد ویرایش کنید. اسلایدهایی که بر پایهٔ آن طرح‌ها/استاد ساخته شده‌اند، به‌صورت خودکار تغییر را دریافت می‌کنند.

**چگونه می‌توانم نگهدارنده‌های استاندارد سرصفحه/پاورقی—تاریخ و زمان، شماره اسلاید و متن پاورقی—را کنترل کنم؟**

از مدیران HeaderFooter در سطح مناسب (اسلایدهای عادی، طرح‌ها، استاد، یادداشت‌ها/پراست‌نویسی‌ها) استفاده کنید تا آن نگهدارنده‌ها را روشن یا خاموش کنید و محتوای آنها را تنظیم نمایید.