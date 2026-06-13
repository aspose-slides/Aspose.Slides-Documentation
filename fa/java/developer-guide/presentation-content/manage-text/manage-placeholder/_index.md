---
title: مدیریت متغیرهای ارائه در جاوا
linktitle: مدیریت متغیرها
type: docs
weight: 10
url: /fa/java/manage-placeholder/
keywords:
- متغیر
- متغیر متنی
- متغیر تصویر
- متغیر نمودار
- متن پیش‌نمایش
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌سادگی متغیرها را در Aspose.Slides برای جاوا مدیریت کنید: متن را جایگزین کنید، پیش‌نمایش‌ها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان مدیریت متغیرهای ارائه را به‌صورت برنامه‌نویسی می‌دهد. این مقاله توضیح می‌دهد چگونه متغیرها را در اسلایدها پیدا کنید و متن آن‌ها را تغییر دهید، متن پیش‌نمایش سفارشی برای طرح‌بندی‌های متغیر تنظیم کنید و شفافیت تصویر استفاده‌شده به‌عنوان پس‌زمینه متغیر را تنظیم کنید. همچنین شامل پرسش‑و‑پاسخ کوتاهی است که تفاوت بین متغیرهای پایه و اشکال محلی را روشن می‌کند، نحوه اعمال تغییرات متغیر از طریق طرح‌بندی‌ها یا مسترها را توضیح می‌دهد و به مدیریت متغیرهای سرصفحه و پاورقی اشاره می‌کند.

## **تغییر متن در یک متغیر**
با استفاده از [Aspose.Slides for Java](/slides/fa/java/)، می‌توانید متغیرها را در اسلایدهای ارائه پیدا کرده و اصلاح کنید. Aspose.Slides به شما امکان می‌دهد تغییرات متن در یک متغیر را اعمال کنید.

**پیش‌نیاز**: شما به ارائه‌ای نیاز دارید که شامل یک متغیر باشد. می‌توانید چنین ارائه‌ای را در برنامه استاندارد Microsoft PowerPoint ایجاد کنید.

1. یک شی از کلاس [`Presentation`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه را به‌عنوان آرگومان پاس کنید.
2. یک ارجاع به اسلاید را از طریق ایندکس آن دریافت کنید.
3. از میان اشکال عبور کنید تا متغیر را پیدا کنید.
4. شکل متغیر را به یک [`AutoShape`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AutoShape) تبدیل کنید و با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrame) مرتبط با [`AutoShape`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AutoShape) متن را تغییر دهید.
5. ارائه اصلاح‌شده را ذخیره کنید.

این کد جاوا نحوه تغییر متن در یک متغیر را نشان می‌دهد:

```java
// یک شی از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // به اسلاید اول دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // برای یافتن متغیر از میان اشکال عبور می‌کند
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // متن هر متغیر را تغییر می‌دهد
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم متن پیش‌نمایش در یک متغیر**
طرح‌بندی‌های استاندارد و از پیش ساخته‌شده شامل متون پیش‌نمایش متغیر مانند ***برای افزودن عنوان کلیک کنید*** یا ***برای افزودن زیرنویس کلیک کنید*** هستند. با استفاده از Aspose.Slides، می‌توانید متون پیش‌نمایش دلخواه خود را در طرح‌بندی‌های متغیر وارد کنید.

این کد جاوا به شما نشان می‌دهد چگونه متن پیش‌نمایش را در یک متغیر تنظیم کنید:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // از طریق اسلاید عبور می‌کند
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint عبارت "Click to add title" را نشان می‌دهد 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // زیرنویس را اضافه می‌کند
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم شفافیت تصویر متغیر**

Aspose.Slides به شما امکان تنظیم شفافیت تصویر پس‌زمینه در یک متغیر متنی را می‌دهد. با تنظیم شفافیت تصویر در چنین چارچوبی، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد جاوا به شما نشان می‌دهد چگونه شفافیت پس‌زمینه تصویر (درون یک شکل) را تنظیم کنید:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**متغیر پایه چیست و چگونه با شکل محلی روی یک اسلاید متفاوت است؟**

یک متغیر پایه، شکل اصلی در یک طرح‌بندی یا مستر است که شکل اسلاید از آن به ارث می‌برد — نوع، موقعیت و برخی فرمت‌ها از آن می‌آیند. یک شکل محلی مستقل است؛ اگر متغیر پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توان تمام عناوین یا توضیح‌ها را در یک ارائه به‌روز کرد بدون اینکه بر هر اسلاید تکرار کنم؟**

متغیر مربوطه را در طرح‌بندی یا مستر ویرایش کنید. اسلایدهایی که بر پایه آن طرح‌بندی‌ها/مستر ساخته شده‌اند، به‌صورت خودکار تغییر را به‌ارث می‌برند.

**چگونه می‌توانم متغیرهای استاندارد سرصفحه/پاورقی — تاریخ و زمان، شماره اسلاید و متن پاورقی — را کنترل کنم؟**

از مدیران `HeaderFooter` در دامنه مناسب (اسلایدهای عادی، طرح‌بندی‌ها، مستر، یادداشت‌ها/پراست‌های توزیع) استفاده کنید تا این متغیرها را روشن یا خاموش کرده و محتواشان را تنظیم کنید.