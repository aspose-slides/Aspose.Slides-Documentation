---
title: صادرات معادلات ریاضی از ارائه‌ها در جاوااسکریپت
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/nodejs-java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "صادرات بی‌وقفه معادلات ریاضی از پاورپوینت به MathML را با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js فراهم کنید—قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **معرفی**

Aspose.Slides به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید. 

{{% alert color="primary" %}} 
می‌توانید معادلات را به MathML صادر کنید، که فرمتی محبوب یا استاندارد برای معادلات ریاضی و محتوای مشابه است که در وب و بسیاری از برنامه‌ها مشاهده می‌شود. 
{{% /alert %}}

## **ذخیرهٔ معادلات ریاضی به عنوان MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، نوشتن کد برای MathML دشوار است زیرا این فرمت به‌صورت خودکار توسط برنامه‌ها تولید می‌شود. برنامه‌ها به‌سادگی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در XML است، به‌طوری که MathML به‌طور معمول به‌عنوان فرمت خروجی و چاپ در بسیاری از زمینه‌ها استفاده می‌شود. 

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

شما می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را فراهم می‌کنند. 

**چگونه می‌توانم تشخیص دهم یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathportion/) قرار دارد و یک [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) دارد. تصاویر و بخش‌های متن عادی که بدون [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) هستند، فرمول‌های قابل استخراج نیستند. 

**MathML در یک ارائه از کجا می‌آید—آیا مختص PowerPoint است یا یک استاندارد؟**

صادر کردن به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد—که به‌طور گسترده‌ای در برنامه‌ها و وب استفاده می‌شود. 

**آیا صادر کردن فرمول‌ها درون جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیا حاوی بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود. 

**آیا صادر کردن به MathML فایل ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML سریال‌سازی محتوای فرمول است؛ این کار فایل ارائه را تغییر نمی‌دهد.