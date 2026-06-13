---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در Android
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/androidjava/convert-powerpoint-to-word/
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
- ذخیره PPT به عنوان DOCX
- ذخیره PPTX به عنوان DOCX
- صادرات PPT به DOCX
- صادرات PPTX به DOCX
- اندروید
- جاوا
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT و PPTX) به اسناد Word قابل ویرایش در جاوا با استفاده از Aspose.Slides برای Android، با حفظ دقیق چیدمان، تصاویر و قالب‌بندی."
---
## **نمای کلی**

این مقاله راه‌حلی برای توسعه‌دهندگان در تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word با استفاده از Aspose.Slides و Aspose.Words فراهم می‌کند. راهنمای گام به گام شما را در هر مرحله از فرآیند تبدیل راهنمایی می‌کند.

## **Aspose.Slides و Aspose.Words**

برای تبدیل فایل PowerPoint (PPTX یا PPT) به Word (DOCX یا DOCX)، به هر دو [Aspose.Slides برای Android از طریق Java](https://products.aspose.com/slides/fa/androidjava/) و [Aspose.Words برای Android از طریق Java](https://products.aspose.com/words/android-java/) نیاز دارید.

به عنوان یک API مستقل، [Aspose.Slides](https://products.aspose.app/slides) برای java توابعی را فراهم می‌کند که به شما اجازه می‌دهد متن‌ها را از ارائه‌ها استخراج کنید. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) یک API پیشرفته پردازش اسناد است که به برنامه‌ها امکان می‌دهد فایل‌ها را تولید، ویرایش، تبدیل، رندر، چاپ کنند و وظایف دیگر را روی اسناد انجام دهند بدون اینکه از Microsoft Word استفاده کنند.

## **تبدیل PowerPoint به Word**

1. کتابخانه‌های [Aspose.Slides برای Android از طریق Java](https://downloads.aspose.com/slides/fa/java) و [Aspose.Words برای Java](https://downloads.aspose.com/words/java) را دانلود کنید.
2. *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* را به CLASSPATH خود اضافه کنید.
3. از این قطعه کد برای تبدیل PowerPoint به Word استفاده کنید:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // یک تصویر اسلاید را به صورت جریان آرایه بایت تولید می‌کند
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

## **پرسش‌های متداول**

**چه مؤلفه‌هایی باید نصب شوند تا بتوان PowerPoint و ارائه‌های OpenDocument را به اسناد Word تبدیل کرد؟**

شما فقط کافی است بسته مربوط به [Aspose.Slides برای Android از طریق Java](https://releases.aspose.com/slides/fa/androidjava/) و [Aspose.Words برای Android از طریق Java](https://releases.aspose.com/words/androidjava/) را به پروژه خود اضافه کنید. هر دو کتابخانه به عنوان APIهای مستقل عمل می‌کنند و نیازی به نصب Microsoft Office نیست.

**آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟**

Aspose.Slides [همه فرمت‌های ارائه را پشتیبانی می‌کند](/slides/fa/androidjava/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر فرمت‌های رایج. این اطمینان می‌دهد که می‌توانید با ارائه‌هایی که در نسخه‌های مختلف Microsoft PowerPoint ایجاد شده‌اند کار کنید.