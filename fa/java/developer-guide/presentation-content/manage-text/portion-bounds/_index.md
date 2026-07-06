---
title: دریافت مرزهای بخش متن از ارائه‌ها در جاوا
linktitle: مرزهای بخش
type: docs
weight: 47
url: /fa/java/portion-bounds/
keywords:
- مرزهای بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای بخش متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای جاوا بازیابی کنید."
---
## **مروری کلی**

یک بخش متن نمایانگر یک قطعه خاص از متن درون یک پاراگراف است و به شما اجازه می‌دهد تا به‌صورت مستقل از محتویات اطراف بر روی آن قطعه کار کنید. در Aspose.Slides، بخش‌ها زمانی مفید هستند که نیاز به بازیابی مرزهای یک قطعه متن، اعمال قالب‌بندی فقط بر بخش خاصی از پاراگراف یا کنترل رفتار متن در سطح دقیق‌تری داشته باشید.

این مقاله نشان می‌دهد چگونه می‌توان مستطیل محدود کننده یک بخش را با استفاده از [IPortion.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getRect--) دریافت کرد. همچنین چگونگی دریافت مختصات شروع یک بخش با استفاده از [IPortion.getCoordinates](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getCoordinates--) را نشان می‌دهد. علاوه بر این، سناریوهای متداول مرتبط با بخش‌ها همچون اختصاص پیوند به یک قطعه متن واحد، درک چگونگی حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و ارث‌بری تم، و برخورد با مواردی که فونت مشخص شده در دسترس نیست را برجسته می‌کند.

## **دریافت مستطیل محدود کننده یک بخش متن**

برای دریافت مستطیل محدود کننده یک بخش متن از [IPortion.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getRect--) استفاده کنید:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مختصات شروع یک بخش متن**

برای دریافت مختصات شروع یک بخش متن از [IPortion.getCoordinates](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getCoordinates--) استفاده کنید:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم فقط بخشی از متن داخل یک پاراگراف واحد را به‌صورت پیوند اختصاص دهم؟**

بله، می‌توانید [اختصاص یک پیوند](/slides/fa/java/manage-hyperlinks/) را به یک بخش فردی بدهید؛ فقط همان قطعه قابل کلیک خواهد بود و نه کل پاراگراف.

**ارث‌بری سبک چگونه عمل می‌کند: یک بخش چه چیزی را نادیده می‌گیرد و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

خصوصیات سطح بخش بالاترین اولویت را دارند. اگر یک خصوصیت در [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) تنظیم نشده باشد، Aspose.Slides آن را از [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) می‌گیرد. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) یا [theme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/theme/) استفاده می‌کند.

**اگر فونت مشخص شده برای یک بخش در دستگاه یا سرور هدف موجود نباشد چه می‌شود؟**

قواعد جایگزینی فونت [/slides/fa/java/font-selection-sequence/] اعمال می‌شود. متن ممکن است دوباره قالب‌بندی شود: متریک‌ها، تقسیم‌بندی و عرض ممکن است تغییر کنند که برای موقعیت‌یابی دقیق اهمیت دارد.

**آیا می‌توانم شفافیت یا گرادیان پر متن را به‌صورت مستقل برای یک بخش تنظیم کنم بدون اینکه به بقیه پاراگراف اثر بگذارد؟**

بله، رنگ متن، پر و شفافیت در سطح [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) می‌تواند متفاوت از قطعات همسایه باشد.