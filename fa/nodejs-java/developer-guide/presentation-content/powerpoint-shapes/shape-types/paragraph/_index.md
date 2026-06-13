---
title: "دریافت مرزهای پاراگراف از ارائه‌ها در JavaScript"
linktitle: "پاراگراف"
type: docs
weight: 60
url: /fa/nodejs-java/paragraph/
keywords:
- "مرزهای پاراگراف"
- "مرزهای بخش متن"
- "مختصات پاراگراف"
- "مختصات بخش"
- "اندازه پاراگراف"
- "اندازه بخش متن"
- "قاب متن"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "با استفاده از Aspose.Slides برای Node.js، نحوه بازیابی مرزهای پاراگراف و بخش‌های متن در JavaScript را بیاموزید تا موقعیت‌گذاری متن را در ارائه‌های PowerPoint بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها و بخش‌های متن در Aspose.Slides به دست آید. نشان می‌دهد چگونه با استفاده از `getRect()` مستطیل یک پاراگراف در `TextFrame` را بازیابی کنید، چگونه مختصات پاراگراف و بخش داخل قاب متن سلول جدول را دریافت کنید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، اثر بسته‌بندی متن بر مرزها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در TextFrame**
با استفاده از Aspose.Slides for Node.js در Java، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی پاراگراف داخل مجموعه پاراگراف‌های TextFrame را به‌دست آورند. همچنین امکان دریافت [مختصات بخش](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion#getCoordinates--) داخل مجموعه بخش‌های یک پاراگراف را فراهم می‌کند. در این موضوع، با کمک یک مثال نشان می‌دهیم که چگونه مختصات مستطیلی پاراگراف را همراه با موقعیت بخش داخل پاراگراف به‌دست آوریم.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **دریافت مختصات مستطیلی پاراگراف**
با استفاده از روش [**getRect()**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Paragraph#getRect--) توسعه‌دهندگان می‌توانند مستطیل مرزهای پاراگراف را به‌دست آورند.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دریافت اندازه پاراگراف و بخش داخل قاب متن سلول جدول**

برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion) یا [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Paragraph) در یک قاب متن سلول جدول، می‌توانید از روش‌های [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion#getRect--) و [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Paragraph#getRect--) استفاده کنید.

این کد نمونه عملیات توضیح داده شده را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**مختصات پاراگراف و بخش‌های متن به چه واحدی بازگردانده می‌شوند؟**

در واحد نقاط (points) که 1 اینچ = 72 نقطه است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته‌بندی کلمه بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/) در [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌صورت قابل اعتماد به پیکسل در تصویر استخراج‌شده تبدیل کرد؟**

بله. نقاط را به پیکسل با استفاده از فرمول: pixels = points × (DPI / 72) تبدیل کنید. نتیجه به DPI انتخاب‌شده برای رندر/اِکسپورت بستگی دارد.

**چگونه می‌توان پارامترهای قالب‌بندی «موثر» پاراگراف را با در نظر گرفتن وراثت سبک به‌دست آورد؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/nodejs-java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی ادغام‌شده برای تورفتگی‌ها، فواصل، بسته‌بندی، RTL و موارد دیگر را برمی‌گرداند.