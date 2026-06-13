---
title: دریافت محدوده پاراگراف‌ها از ارائه‌ها در جاوا
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/java/paragraph/
keywords:
- محدوده پاراگراف
- محدوده بخش متن
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متن
- قاب متن
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده پاراگراف و بخش‌های متنی را در Aspose.Slides برای جاوا بازیابی کنید تا موقعیت متن را در ارائه‌های PowerPoint بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها و بخش‌های متنی در Aspose.Slides را به دست آورید. نشان می‌دهد چگونه با استفاده از `getRect()` مستطیل پاراگراف در یک `TextFrame` را بازیابی کنید، چگونه مختصات پاراگراف و بخش را در داخل فریم متنی سلول جدول دریافت کنید، و جزئیات مهمی همچون واحدهای اندازه‌گیری، تأثیر پیچش متن بر مرزها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در TextFrame**
با استفاده از Aspose.Slides for Java، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی پاراگراف را در مجموعه پاراگراف‌های TextFrame به دست آورند. همچنین امکان دریافت [the coordinates of portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getCoordinates--) در مجموعه بخش‌های یک پاراگراف را فراهم می‌کند. در این بخش، با کمک یک مثال نشان می‌دهیم چگونه مختصات مستطیلی پاراگراف همراه با موقعیت بخش در داخل پاراگراف را دریافت کنیم.

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
با استفاده از [**getRect()**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IParagraph#getRect--) می‌توانید مستطیل مرزهای پاراگراف را به دست آورید.

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

## **دریافت اندازه یک پاراگراف و بخش داخل TextFrame سلول جدول**
برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Portion) یا [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Paragraph) در یک فریم متنی سلول جدول، می‌توانید از روش‌های [IPortion.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getRect--) و [IParagraph.getRect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IParagraph#getRect--) استفاده کنید.

این کد نمونه عملیات شرح داده‌شده را نشان می‌دهد:

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

## **سوالات متداول**

**در چه واحدهایی مختصات برگردانده شده برای پاراگراف و بخش‌های متن اندازه‌گیری می‌شود؟**  
در نقاط (points)، به‌طوری که 1 اینچ = 72 نقطه. این واحد برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا پیچش کلمه بر مرزهای پاراگراف تأثیر می‌گذارد؟**  
بله. اگر [wrapping](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setWrapText-byte-) در [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) فعال باشد، متن برای انطباق با عرض ناحیه شکسته می‌شود که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا مختصات پاراگراف می‌تواند به‌طور قابل اعتماد به پیکسل‌ها در تصویر خروجی تبدیل شود؟**  
بله. نقاط را به پیکسل تبدیل کنید با استفاده از: pixels = points × (DPI / 72). نتیجه به DPI انتخابی برای رندر/خروجی وابسته است.

**چگونه می‌توانم پارامترهای قالب‌بندی "مؤثر" پاراگراف را به‌دست آورم که وراثت سبک را در نظر بگیرد؟**  
از [effective paragraph formatting data structure](/slides/fa/java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی ترکیبی برای تو رفتگی‌ها، فاصله‌ها، پیچش، RTL و موارد دیگر را برمی‌گرداند.