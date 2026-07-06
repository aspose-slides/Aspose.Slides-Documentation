---
title: دریافت مرزهای پاراگراف از ارائه‌ها در JavaScript
linktitle: مرزهای پاراگراف
type: docs
weight: 43
url: /fa/nodejs-java/paragraph-bounds/
keywords:
- مرزهای پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- قاب متن
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نحوه بازیابی مرزهای پاراگراف در Aspose.Slides برای Node.js از طریق Java را برای بهینه‌سازی موقعیت متن در ارائه‌های پاورپوینت بیاموزید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه مرزها، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides به‌دست آورید. همچنین نشان می‌دهد چگونه با استفاده از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) یک مستطیل پاراگراف را از یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) بازیابی کنید، چگونه مختصات پاراگراف را داخل فریم متن سلول جدول به‌دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته‌بندی متن بر مرزها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) برای دریافت مستطیل محاط‌کننده یک پاراگراف استفاده کنید.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **دریافت اندازهٔ پاراگراف داخل فریم متن سلول جدول**

برای به‌دست آوردن اندازه و مختصات یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) در فریم متن سلول جدول، از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) استفاده کنید. مستطیل بازگردانده‌شده نسبت به فریم متن سلول جدول است، بنابراین برای دریافت مختصات سطح اسلاید، موقعیت جدول و جابه‌جایی سلول را اضافه کنید.

مثال زیر مرزهای پاراگراف را داخل یک سلول جدول دریافت می‌کند و مستطیل‌هایی بر روی اسلاید می‌کشد تا آن مرزها را به‌صورت تصویری نمایش دهد:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**در چه واحدهایی مختصات پاراگراف اندازه‌گیری می‌شوند؟**

آنها بر حسب پوینت (نقطه) اندازه‌گیری می‌شوند، به‌طوری که 1 اینچ برابر 72 پوینت است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته‌بندی متن بر مرزهای پاراگراف تأثیر دارد؟**

بله. اگر [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/) برای [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) فعال باشد، متن برای پر کردن عرض ناحیه شکست می‌خورد که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل‌اعتمادی به پیکسل‌ها در تصویر صادر شده تبدیل کرد؟**

بله. پوینت‌ها را به پیکسل با استفاده از این فرمول تبدیل کنید: پیکسل = پوینت × (DPI / 72). نتیجه به DPI انتخاب شده برای رندر یا صادرات بستگی دارد.

**چگونه می‌توانم پارامترهای قالب‌بندی «مؤثر» پاراگراف را دریافت کنم که ارث‌بری سبک را در نظر بگیرد؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/nodejs-java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی ترکیب‌شده برای تو رفتگی‌ها، فواصل، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.