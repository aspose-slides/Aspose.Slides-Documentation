---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در جاوا
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/java/convert-powerpoint-to-word/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به Word
- ارائه به Word
- اسلاید به Word
- PPT به Word
- PPTX به Word
- PowerPoint به DOCX
- ارائه به DOCX
- اسلاید به DOCX
- PPT به DOCX
- PPTX به DOCX
- PowerPoint به DOC
- ارائه به DOC
- اسلاید به DOC
- PPT به DOC
- PPTX به DOC
- ذخیره PPT به صورت DOCX
- ذخیره PPTX به صورت DOCX
- صدور PPT به DOCX
- صدور PPTX به DOCX
- جاوا
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint PPT و PPTX به اسناد Word قابل ویرایش در جاوا با استفاده از Aspose.Slides، به‌صورت دقیق، چیدمان، تصاویر و قالب‌بندی حفظ می‌شود."
---
## **بررسی کلی**

این مقاله راه‌حلی برای توسعه‌دهندگان در تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word با استفاده از Aspose.Slides و Aspose.Words ارائه می‌دهد. راهنمای گام به گام شما را در هر مرحله از فرآیند تبدیل هدایت می‌کند.

## **تبدیل PowerPoint به Word**

دستورات زیر را برای تبدیل یک ارائه PowerPoint یا OpenDocument به سند Word انجام دهید:

1. کتابخانه‌های [Aspose.Slides for Java](https://downloads.aspose.com/slides/fa/java) و [Aspose.Words for Java](https://downloads.aspose.com/words/java) را دانلود کنید.
2. *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* را به CLASSPATH خود اضافه کنید.
3. از این قطعه کد برای تبدیل PowerPoint به Word استفاده کنید:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // یک تصویر اسلاید را به صورت جریان بایت آرایه تولید می‌کند
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // متن‌های اسلاید را وارد می‌کند
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **سوالات متداول**

**برای تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word چه اجزایی باید نصب شوند؟**

تنها کافی است بسته مربوطه برای [Aspose.Slides for Java](https://releases.aspose.com/slides/fa/java/) و [Aspose.Words for Java](https://releases.aspose.com/words/java/) را به پروژه‌ خود اضافه کنید. هر دو کتابخانه به‌صورت APIهای مستقل عمل می‌کنند و نیازی به نصب Microsoft Office نیست.

**آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟**

Aspose.Slides [تمام فرمت‌های ارائه را پشتیبانی می‌کند](/slides/fa/java/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر فرمت‌های رایج. این امکان را می‌دهد تا با ارائه‌های ایجاد شده در نسخه‌های مختلف Microsoft PowerPoint کار کنید.