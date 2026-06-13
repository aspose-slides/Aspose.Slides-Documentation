---
title: دریافت محدوده پاراگراف‌ها از ارائه‌ها در اندروید
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/androidjava/paragraph/
keywords:
- محدوده پاراگراف
- محدوده بخش متن
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متن
- فریم متن
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های پاراگراف و بخش متن را در Aspose.Slides برای اندروید از طریق جاوا بازیابی کنید تا موقعیت متن در ارائه‌های پاورپوینت بهینه شود."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه محدوده‌ها، اندازه و مختصات پاراگراف‌ها و بخش‌های متن را در Aspose.Slides به دست آورید. نشان می‌دهد چگونه مستطیل یک پاراگراف را در `TextFrame` با استفاده از `getRect()` دریافت کنید، چگونه مختصات پاراگراف و بخش را درون قاب متن سلول جدول به دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته‌بندی متن بر محدوده‌ها، تبدیل به پیکسل و مقادیر فرمت‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در TextFrame**
با استفاده از Aspose.Slides برای Android از طریق Java، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی پاراگراف را در مجموعه پاراگراف‌های TextFrame به دست آورند. همچنین امکان دریافت [مختصات بخش](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getCoordinates--) در مجموعه بخش‌های یک پاراگراف را فراهم می‌کند. در این موضوع، با کمک یک مثال نشان می‌دهیم چگونه مختصات مستطیلی پاراگراف را همراه با موقعیت بخش داخل پاراگراف به دست آوریم.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **دریافت مختصات مستطیلی یک پاراگراف**
با استفاده از متد [**getRect()**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getRect--) توسعه‌دهندگان می‌توانند مستطیل محدوده پاراگراف را به دست آورند.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت اندازه یک پاراگراف و بخش درون TextFrame سلول جدول**

برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Portion) یا [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Paragraph) در یک TextFrame سلول جدول، می‌توانید از متدهای [IPortion.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getRect--) و [IParagraph.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getRect--) استفاده کنید.

این کد نمونه عملیات توصیف‌شده را نشان می‌دهد:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**مختصات پاراگراف و بخش‌های متن به چه واحدهایی بر می‌گردند؟**

در نقاط (points)، جایی که 1 اینچ = 72 نقطه است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته‌بندی کلمات بر محدوده پاراگراف تأثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) در [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه باز می‌شکند که محدوده واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌صورت قابل اطمینان به پیکسل در تصویر خروجی تبدیل کرد؟**

بله. نقاط را به پیکسل تبدیل کنید با استفاده از: pixels = points × (DPI / 72). نتیجه به DPI انتخاب‌شده برای رندر/صادرات وابسته است.

**چگونه می‌توان پارامترهای فرمت‌بندی «موثر» پاراگراف را که وراثت سبک را در نظر می‌گیرد، دریافت کرد؟**

از [ساختار داده‌های فرمت‌بندی مؤثر پاراگراف](/slides/fa/androidjava/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی ترکیبی برای تورفتگی‌ها، فاصله‌ها، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.