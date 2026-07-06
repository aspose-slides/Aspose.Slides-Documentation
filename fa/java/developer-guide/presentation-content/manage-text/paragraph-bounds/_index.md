---
title: دریافت مرزهای پاراگراف از ارائه‌ها در جاوا
linktitle: مرزهای پاراگراف
type: docs
weight: 43
url: /fa/java/paragraph-bounds/
keywords:
- مرزهای پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- قاب متن
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه در Aspose.Slides برای جاوا مرزهای پاراگراف را بازیابی کنید تا موقعیت متن را در ارائه‌های PowerPoint بهینه کنید."
---
## **نمای کلی**

این مقاله نحوه دریافت مرزها، اندازه و مختصات پاراگراف‌ها در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه با استفاده از [IParagraph.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IParagraph#getRect--) یک مستطیل پاراگراف را از یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) بازیابی کنید، چگونه مختصات پاراگراف را داخل فریم متن سلول جدول دریافت کنید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، اثر بسته شدن متن بر مرزها، تبدیل پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [IParagraph.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IParagraph#getRect--) برای دریافت مستطیل محدوده یک پاراگراف استفاده کنید.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **دریافت اندازه یک پاراگراف داخل فریم متن سلول جدول**

برای دریافت اندازه و مختصات یک [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) در فریم متن سلول جدول، از [IParagraph.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IParagraph#getRect--) استفاده کنید. مستطیل برگردانده شده نسبت به فریم متن سلول جدول است، بنابراین هنگام نیاز به مختصات سطح اسلاید موقعیت جدول و جابجایی سلول را اضافه کنید.

مثال زیر مرزهای پاراگراف داخل یک سلول جدول را دریافت کرده و مستطیل‌هایی بر روی اسلاید می‌کشد تا این مرزها را به تصویر بکشند:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**مختصات پاراگراف بر چه واحدی اندازه‌گیری می‌شوند؟**

آنها بر حسب پوینت اندازه‌گیری می‌شوند، به‌طوری‌که 1 اینچ برابر 72 پوینت است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته شدن متن بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) برای [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) فعال باشد، متن برای تناسب با عرض ناحیه شکسته می‌شود که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اطمینان به پیکسل‌ها در تصویر خروجی تبدیل کرد؟**

بله. با استفاده از این فرمول پوینت‌ها را به پیکسل تبدیل کنید: pixels = points x (DPI / 72). نتیجه بسته به DPI انتخابی برای رندر یا خروجی متفاوت است.

**چگونه پارامترهای قالب‌بندی «موثر» پاراگراف را دریافت کنم که وراثت سبک را نیز در نظر می‌گیرد؟**

از [effective paragraph formatting data structure](/slides/fa/java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، بسته شدن متن، راست به چپ و موارد دیگر را بر می‌گرداند.