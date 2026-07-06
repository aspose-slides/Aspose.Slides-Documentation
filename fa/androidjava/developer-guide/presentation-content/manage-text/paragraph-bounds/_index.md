---
title: دریافت حدود پاراگراف از ارائه‌ها در Android
linktitle: حدود پاراگراف
type: docs
weight: 43
url: /fa/androidjava/paragraph-bounds/
keywords:
- حدود پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- فریم متن
- پاورپوینت
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه حدود پاراگراف را در Aspose.Slides برای Android از طریق Java بازیابی کنید تا موقعیت متن را در ارائه‌های پاورپوینت بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه حدود، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides به دست آورید. نشان می‌دهد چگونه یک مستطیل پاراگراف را از یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) با استفاده از [IParagraph.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getRect--) بازیابی کنید، چگونه مختصات پاراگراف را داخل یک فریم متن سلول جدول به دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته‌بندی متن بر حدود، تبدیل به پیکسل، و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [IParagraph.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getRect--) برای دریافت مستطیل محدود کننده یک پاراگراف استفاده کنید.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **دریافت اندازه یک پاراگراف داخل TextFrame سلول جدول**

برای دریافت اندازه و مختصات یک [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) در یک TextFrame سلول جدول، از [IParagraph.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getRect--) استفاده کنید. مستطیل بازگردانده شده نسبت به TextFrame سلول جدول است، بنابراین زمانی که به مختصات سطح اسلاید نیاز دارید، موقعیت جدول و جابجایی سلول را اضافه کنید.

مثال زیر حدود پاراگراف را داخل یک سلول جدول دریافت می‌کند و مستطیل‌هایی را بر روی اسلاید می‌کشد تا این حدود را به تصویر بکشد:

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

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

**مختصات پاراگراف بر چه واحدی اندازه‌گیری می‌شود؟**

آنها به نقطه (point) اندازه‌گیری می‌شوند، به‌طوری که 1 اینچ معادل 72 نقطه است. این برای تمام مختصات و ابعاد در اسلاید اعمال می‌شود.

**آیا بسته‌بندی متن بر حدود پاراگراف تأثیر می‌گذارد؟**

بله. اگر [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) برای [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود که باعث تغییر حدود واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اعتماد به پیکسل‌ها در تصویر صادرشده تبدیل کرد؟**

بله. نقاط را با استفاده از این فرمول به پیکسل تبدیل کنید: پیکسل = نقطه × (DPI / 72). نتیجه بستگی به DPI انتخابی برای رندر یا صادرات دارد.

**چگونه پارامترهای قالب‌بندی «موثر» پاراگراف را که وراثت سبک را در نظر می‌گیرد به‌دست آورم؟**

از [effective paragraph formatting data structure](/slides/fa/androidjava/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.