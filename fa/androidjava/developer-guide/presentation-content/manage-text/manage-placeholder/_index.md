---
title: مدیریت نگهدارنده‌های ارائه در اندروید
linktitle: مدیریت نگهدارنده‌ها
type: docs
weight: 10
url: /fa/androidjava/manage-placeholder/
keywords:
- نگهدارنده
- نگهدارنده متن
- نگهدارنده تصویر
- نگهدارنده نمودار
- متن راهنما
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌راحتی نگهدارنده‌ها را در Aspose.Slides برای Android از طریق Java مدیریت کنید: متن را جایگزین کنید، راهنماها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم نمایید."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد تا نگهدارنده‌های ارائه را به‌صورت برنامه‌نویسی مدیریت کنید. این مقاله نحوه یافتن نگهدارنده‌ها بر روی اسلایدها و تغییر متن آن‌ها، تنظیم متن راهنمای سفارشی برای طرح‌های نگهدارنده، و تنظیم شفافیت تصویری که به‌عنوان پس‌زمینه نگهدارنده استفاده می‌شود را توضیح می‌دهد. همچنین شامل یک بخش کوتاه پرسش و پاسخ است که تفاوت بین نگهدارنده‌های پایه و اشیای محلی را روشن می‌سازد، توضیح می‌دهد چگونه تغییرات نگهدارنده می‌تواند از طریق طرح‌ها یا مسترها اعمال شود، و به مدیریت نگهدارنده‌های سرصفحه و پاورقی اشاره می‌کند.

## **تغییر متن در یک نگهدارنده**
با استفاده از [Aspose.Slides for Android via Java](/slides/fa/androidjava/)، می‌توانید نگهدارنده‌ها را در اسلایدهای ارائه پیدا کرده و آن‌ها را اصلاح کنید. Aspose.Slides به شما اجازه می‌دهد تا متن موجود در یک نگهدارنده را تغییر دهید.

**Prerequisite**: شما به یک ارائه‌ای نیاز دارید که شامل یک نگهدارنده باشد. می‌توانید چنین ارائه‌ای را با برنامه استاندارد Microsoft PowerPoint ایجاد کنید.

این نحوه استفاده از Aspose.Slides برای جایگزینی متن در نگهدارنده‌ی آن ارائه است:

1. یک نمونه از کلاس [`Presentation`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را به‌عنوان آرگومان پاس دهید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. از میان اشکال (shapes) عبور کنید تا نگهدارنده را پیدا کنید.
4. شکل نگهدارنده را به یک [`AutoShape`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AutoShape) تبدیل (typecast) کنید و با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrame) مربوط به آن، متن را تغییر دهید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه متن در یک نگهدارنده را تغییر دهید:

```java
// یک کلاس Presentation را نمونه‌سازی می‌کند
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // از طریق اشکال عبور می‌کند تا نگهدارنده را پیدا کند
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // متن هر نگهدارنده را تغییر می‌دهد
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم متن راهنما در یک نگهدارنده**
طرح‌های استاندارد و پیش‌ساخته شامل متن‌های راهنمایی مانند ***Click to add a title*** یا ***Click to add a subtitle*** هستند. با استفاده از Aspose.Slides می‌توانید متن‌های راهنمای دلخواه خود را در طرح‌های نگهدارنده وارد کنید.

این کد Java نشان می‌دهد چگونه متن راهنما را در یک نگهدارنده تنظیم کنید:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // از طریق اسلاید پیمایش می‌کند
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint نمایش می‌دهد "Click to add title" 
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

## **تنظیم شفافیت تصویر نگهدارنده**

Aspose.Slides به شما اجازه می‌دهد تا شفافیت تصویر پس‌زمینه در یک نگهدارندهٔ متنی را تنظیم کنید. با تنظیم شفافیت تصویر در چنین قاب‌یه‌ای، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد Java نشان می‌دهد چگونه شفافیت پس‌زمینهٔ تصویر (درون یک شکل) را تنظیم کنید:

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

## **سوالات متداول**

**یک نگهدارندهٔ پایه چیست و چطور با یک شکل محلی روی اسلاید متفاوت است؟**

یک نگهدارندهٔ پایه، شکل اصلی موجود در یک layout یا master است که شکل اسلاید از آن ارث می‌برد—نوع، موقعیت و برخی فرمت‌بندی‌ها از آن می‌آیند. یک شکل محلی مستقل است؛ اگر نگهدارندهٔ پایه‌ای وجود نداشته باشد، وراثت اعمال نمی‌شود.

**چگونه می‌توانم تمام عناوین یا زیرنویس‌ها را در یک ارائه به‌روز کنم بدون این‌که بر روی هر اسلاید پیمایش کنم؟**

نگهدارندهٔ مربوطه را در layout یا master ویرایش کنید. اسلایدهایی که بر پایه آن layoutها/masterها ساخته شده‌اند، به‌طور خودکار تغییر را دریافت می‌کنند.

**چگونه می‌توانم نگهدارنده‌های استاندارد سرصفحه/پاورقی—تاریخ و زمان، شماره اسلاید و متن پاورقی—را کنترل کنم؟**

از مدیران HeaderFooter در سطح مناسب (اسلایدهای عادی، layoutها، master، یادداشت‌ها/پاورقی‌ها) استفاده کنید تا این نگهدارنده‌ها را فعال یا غیرفعال کنید و محتوای آن‌ها را تنظیم نمایید.