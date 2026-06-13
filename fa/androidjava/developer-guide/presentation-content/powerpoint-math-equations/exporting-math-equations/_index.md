---
title: صادر کردن معادلات ریاضی از ارائه‌ها در Android
linktitle: صادر کردن معادلات
type: docs
weight: 30
url: /fa/androidjava/exporting-math-equations/
keywords:
- صادر کردن معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "قابلیت صدور یکپارچهٔ معادلات ریاضی از PowerPoint به MathML را با استفاده از Aspose.Slides برای Android از طریق Java فعال کنید—قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **معرفی**

Aspose.Slides برای Android از طریق Java به شما امکان صادرات معادلات ریاضی از ارائه‌ها را می‌دهد. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
می‌توانید معادلات را به MathML صادر کنید، قالب یا استانداردی محبوب برای معادلات ریاضی و محتوای مشابه که در وب و بسیاری از برنامه‌ها دیده می‌شود. 
{{% /alert %}}

## **صادرات معادلات ریاضی از ارائه‌ها**

در حالی که انسان‌ها به راحتی می‌توانند کد برخی فرمت‌های معادله مانند LaTeX را بنویسند، برای نوشتن کد MathML دچار مشکل می‌شوند، زیرا این فرمت به‌صورت خودکار توسط برنامه‌ها تولید می‌شود. برنامه‌ها می‌توانند MathML را به‌راحتی بخوانند و تجزیه کنند، زیرا کد آن در XML است، بنابراین MathML به‌عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها مورد استفاده قرار می‌گیرد.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:
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

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

می‌توانید یا یک پاراگراف ریاضی کامل ([MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است یا متن یا تصویر معمولی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی معمولی که [MathParagraph] ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا خاص PowerPoint است یا استاندارد؟**

صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعهٔ ارائه‌ای استاندارد که به‌ طور گسترده در برنامه‌ها و وب استفاده می‌شود.

**آیا صادرات فرمول‌ها درون جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph] (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر فرمول به‌عنوان تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائهٔ اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML سریال‌سازی محتوای فرمول است؛ این کار فایل ارائه را تغییر نمی‌دهد.