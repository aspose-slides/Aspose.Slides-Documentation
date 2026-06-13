---
title: صادرات معادلات ریاضی از ارائه‌ها در Java
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "صادرات یکپارچه معادلات ریاضی از PowerPoint به MathML با استفاده از Aspose.Slides برای Java را فعال کنید—قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **مقدمه**

Aspose.Slides اجازه می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به‌عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کنید و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 

شما می‌توانید معادلات را به MathML، یک فرمت یا استاندارد محبوب برای معادلات ریاضی و محتوای مشابه که در وب و بسیاری از برنامه‌ها مشاهده می‌شود، صادر کنید.

{{% /alert %}}

## **ذخیره معادلات ریاضی به صورت MathML**

در حالی که انسان‌ها به‌راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، نوشتن کد برای MathML دشوار است زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به‌راحتی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در قالب XML است، بنابراین MathML به‌طور رایج به‌عنوان فرمت خروجی و چاپ در بسیاری از زمینه‌ها استفاده می‌شود.

این نمونه کد نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول منفرد؟**

شما می‌توانید کل پاراگراف ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/)) یا یک بلوک فردی ([MathBlock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی معمولی بدون [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مخصوص PowerPoint است یا یک استاندارد؟**

اهداف صادرات، MathML استاندارد (XML) است. Aspose از Presentation MathML—زیرمجموعه ارائه‌ای استاندارد استفاده می‌کند که به‌صورت گسترده در برنامه‌ها و وب استفاده می‌شود.

**آیا صادر کردن فرمول‌ها داخل جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML تغییراتی در ارائه اصلی ایجاد می‌کند؟**

خیر. نوشتن MathML تنها یک سریال‌سازی محتوای فرمول است؛ هیچ تغییری در فایل ارائه ایجاد نمی‌کند.