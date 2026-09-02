---
title: "مدیریت اشیاء جوهر ارائه در اندروید"
linktitle: "مدیریت جوهر"
type: docs
weight: 95
url: /fa/androidjava/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیاب جوهر
- مدیریت جوهر
- رسم جوهر
- نقاشی
- صادرات جوهر
- رندرینگ جوهر
- مخفی کردن جوهر
- IInkOptions
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint، ویرایش ردیاب‌ها و ویژگی‌های قلم، و کنترل ظاهر جوهر در طول صادرات PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای Android."
---
## **معرفی**

PowerPoint ویژگی جوهر (ink) را فراهم می‌کند که به شما امکان رسم خطوط آزادانه را می‌دهد. جوهر می‌تواند برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها، و جلب توجه به موارد خاص در یک اسلاید استفاده شود.

Aspose.Slides انواع مورد نیاز برای کار با اشیاء جوهر را فراهم می‌کند. به عنوان مثال، رابط [IInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iink/) نمایانگر یک شیء جوهر در یک اسلاید است.

## **تفاوت‌های اشیاء معمولی و اشیاء جوهر**

اشیاء در یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایش داده می‌شوند. در ساده‌ترین شکل، یک shape یک محفظه است که ناحیه خود اشیاء (قاب آن) را به همراه ویژگی‌هایی مانند اندازهٔ محفظه، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر، https://docs.aspose.com/slides/fa/androidjava/shape-manipulations/#access-layout-formats-for-shape را ببینید.

با این حال، زمانی که PowerPoint یک شیء جوهر را مدیریت می‌کند، تمام ویژگی‌های قاب شیء (محفظه) به جز اندازهٔ آن را نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه با استفاده از روش‌های استاندارد [IShape.getWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getWidth--) و [IShape.getHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getHeight--) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیاب‌های جوهر**

یک ردیاب جوهر یک عنصر پایه‌ای است که مسیر حرکت قلم را هنگام نوشتن جوهر دیجیتال ثبت می‌کند. یک ردیاب توالی‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین نوع کدگذاری مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مشابه این تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم برای رسم**

یک قلم برای رسم خطوطی که نقاط یک ردیاب جوهر را به هم متصل می‌کند، استفاده می‌شود. قلم دارای رنگ و اندازهٔ خاص خود است که توسط روش‌های [IInkBrush.getColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkbrush/#getColor--) و [IInkBrush.getSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkbrush/#getSize--) نمایان می‌شود.

### **تنظیم رنگ قلم جوهر**

این کد Java نشان می‌دهد چگونه رنگ یک قلم جوهر تنظیم شود:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **تنظیم اندازهٔ قلم جوهر**

این کد Java نشان می‌دهد چگونه اندازهٔ یک قلم جوهر تنظیم شود:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

به‌طور کلی، عرض و ارتفاع یک قلم یکسان نیستند، بنابراین PowerPoint اندازهٔ قلم را نمایش نمی‌دهد (بخش دادهٔ مربوطه خاکستری می‌شود). وقتی عرض و ارتفاع قلم با هم مطابقت داشته باشد، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ قلم‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی رجوع کنید).

بنابراین برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ قلم‌های ردیاب‌های آن در نظر گرفته شود. در اینجا، شیء هدف (ردیاب متن دست‌نویس) به اندازهٔ محفظه (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ محفظه تغییر می‌کند، اندازهٔ قلم ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیاء متن دارد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر در زمان صادرات و رندرینگ**

Aspose.Slides رابط [IInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/) را برای کنترل نحوهٔ نمایش اشیاء جوهر در خروجی‌های صادراتی یا رندر شده فراهم می‌کند. می‌توانید از ویژگی‌های آن برای مخفی کردن کامل جوهر یا تغییر تفسیر عملیات ماسک قلم جوهر استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های صادرات یا رندرینگ برای چندین نوع خروجی در دسترس هستند:

| خروجی | ویژگی گزینه‌های جوهر |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| تصویر اسلاید | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

روش‌های زیر از رابط [IInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/) دو تنظیم یکسان را افشا می‌کنند:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) تعیین می‌کند که آیا اشیاء جوهر در خروجی گنجانده شوند یا خیر. مقدار پیش‌فرض آن `false` است.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) تعیین می‌کند که آیا یک عملیات ماسک به عنوان شفافیت تفسیر شود هنگام رندر قلم جوهر. مقدار پیش‌فرض آن `true` است؛ برای استفاده از عملیات ROP، [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با مقدار `false` فراخوانی کنید.

### **مخفی کردن اشیاء جوهر در خروجی PDF**

به‌صورت پیش‌فرض، اشیاء جوهر در طول صادرات قابل مشاهده باقی می‌مانند. برای ایجاد خروجی تمیز بدون حاشیه‌نویسی‌های دست‌نویس یا سایر محتویات جوهر، [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) را با مقدار `true` صدا بزنید.

مثال Java زیر یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیاء جوهر مخفی هستند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **مخفی کردن اشیاء جوهر هنگام رندر اسلاید به عنوان تصویر**

برای مخفی کردن اشیاء جوهر هنگام رندر اسلایدها به عنوان تصاویر بیت‌مپ، [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) را پیکربندی کنید و گزینه‌های رندرینگ را به [ISlide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) پاس دهید.

مثال Java زیر اولین اسلاید را به عنوان تصویر PNG بدون اشیاء جوهر رندر می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **کنترل رندر ماسک جوهر**

تنظیم [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) کنترل می‌کند که عملیات ماسک هنگام رندر قلم‌های جوهر چگونه تفسیر شود. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP، [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با `false` فراخوانی کنید.

مثال Java زیر یک اسلاید را به SVG صادر می‌کند و از رندر مبتنی بر ROP برای عملیات ماسک جوهر استفاده می‌کند:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

همین تنظیم می‌تواند از طریق [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) هنگام صادرات یک ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب مخفی یا حفظ جوهر**

هنگامی که به نسخهٔ تمیزی از ارائه حاوی حاشیه‌نویسی برای توزیع بدون علامت‌های مرور نیاز دارید، در طول صادرات [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) را با مقدار `true` صدا بزنید.

در صورتی که حاشیه‌نویسی‌های جوهر بخشی از محتوای مورد نظر هستند (مانند نظرات مرور، یادداشت‌های دست‌نویس، هایلایت‌ها یا تصویرهای باید به‌صورت قابل مشاهده باقی بمانند)، [IInkOptions.getHideInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) را با مقدار پیش‌فرض `false` رها کنید. این امکان را می‌دهد تا برنامه‌ها خروجی‌های مرور و نهایی را از همان ارائه بدون تغییر اشیاء جوهر منبع تولید کنند.

## **سوالات متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**

بله. ردیاب را از طریق [IInk.getTraces](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iink/#getTraces--) دریافت کنید، سپس قلم آن را با [IInkTrace.getBrush](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinktrace/#getBrush--) تغییر دهید. برای تغییر رنگ از [IInkBrush.setColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) و برای تغییر اندازه از [IInkBrush.setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) استفاده کنید.

**آیا مخفی کردن جوهر منبع ارائه را تغییر می‌دهد؟**

خیر. فراخوانی [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) فقط بر نتیجهٔ رندر یا صادرات تأثیر می‌گذارد؛ اشیاء جوهر در منبع ارائه حذف یا تغییر نمی‌یابند.

**کدام فرمت‌های صادراتی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های صادرات یا رندرینگ مربوطه که در بالا نشان داده شده‌اند، پیکربندی کنید.

**مطالعات بیشتر**

* برای مطالعه دربارهٔ شکل‌ها به بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/androidjava/powerpoint-shapes/) مراجعه کنید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/androidjava/shape-effective-properties/#get-effective-font-height-value) نگاه کنید.
* برای جزئیات صادرات PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/androidjava/convert-powerpoint-to-pdf/) مراجعه کنید.
* برای جزئیات صادرات HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/androidjava/convert-powerpoint-to-html/) نگاه کنید.
* برای جزئیات صادرات SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/androidjava/render-a-slide-as-an-svg-image/) مراجعه کنید.
* برای جزئیات صادرات TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/androidjava/convert-powerpoint-to-tiff/) نگاه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/androidjava/convert-slide/) مراجعه کنید.