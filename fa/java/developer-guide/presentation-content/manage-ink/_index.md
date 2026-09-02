---
title: مدیریت اشیاء جوهر ارائه در جاوا
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیاب جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- صادرات جوهر
- رندرینگ جوهر
- مخفی‌کردن جوهر
- IInkOptions
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "اشیاء جوهر PowerPoint را مدیریت کنید، ردیاب‌ها و ویژگی‌های قلم‌مو را ویرایش کنید، و ظاهر جوهر را در طول خروجی PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای جاوا کنترل کنید."
---
## **معرفی**

PowerPoint قابلیت جوهر (Ink) را فراهم می‌کند که به شما امکان می‌دهد خطوط آزادانه رسم کنید. جوهر می‌تواند برای برجسته کردن اشیاء دیگر، نشان دادن ارتباطات و فرآیندها، و جلب توجه به موارد خاص در یک اسلاید استفاده شود.

Aspose.Slides انواع مورد نیاز برای کار با اشیاء جوهر را فراهم می‌کند. به عنوان مثال، اینترفیس [IInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iink/) یک شیء جوهر را روی اسلاید نشان می‌دهد.

## **تفاوت‌های اشیاء معمولی و اشیاء جوهر**

اشیاء روی یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایش داده می‌شوند. ساده‌ترین شکل یک shape، یک محفظه است که ناحیه خود شیء (قاب آن) را به همراه ویژگی‌هایی مانند اندازه محفظه، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر، به [قالب چیدمان شکل](https://docs.aspose.com/slides/fa/java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

با این حال، هنگامی که PowerPoint یک شیء جوهر را پردازش می‌کند، تمام ویژگی‌های قاب شیء (محفظه) به جز اندازه آن را نادیده می‌گیرد. اندازه ناحیه محفظه توسط متدهای استاندارد [IShape.getWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getWidth--) و [IShape.getHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getHeight--) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیاب‌های جوهر**

یک ردیاب جوهر یک عنصر پایه‌ای است که مسیر قلم را هنگام نوشتن جوهر دیجیتال ثبت می‌کند. یک ردیاب دنباله‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. زمانی که تمام نقاط متصل رندر شوند، تصویری شبیه به این تولید می‌کنند:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم مو برای رسم**

قلم مو برای رسم خطوطی استفاده می‌شود که نقاط یک ردیاب جوهر را به هم وصل می‌کند. قلم مو رنگ و اندازه خودش را دارد که توسط متدهای [IInkBrush.getColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkbrush/#getColor--) و [IInkBrush.getSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkbrush/#getSize--) نمایان می‌شود.

### **تنظیم رنگ قلم مو جوهر**

این کد Java نشان می‌دهد چگونه رنگ یک قلم مو جوهر را تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **تنظیم اندازه قلم مو جوهر**

این کد Java نشان می‌دهد چگونه اندازه یک قلم مو جوهر را تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

به‌طور کلی، عرض و ارتفاع یک قلم مو برابر نیستند، بنابراین PowerPoint اندازه قلم مو را نمایش نمی‌دهد (بخش داده مربوطه خاکستری می‌شود). هنگامی که عرض و ارتفاع قلم مو برابر باشد، PowerPoint اندازه آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را بررسی می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازه قلم موها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی نگاه کنید).

بنابراین، برای تعیین ناحیه قابل مشاهده تمام شیء جوهر، باید اندازه قلم موهای ردیاب‌های آن در نظر گرفته شود. در اینجا شیء هدف (ردیاب متن دست‌نویس) به اندازه محفظه (قاب) مقیاس‌دهی شده است. وقتی اندازه محفظه تغییر می‌کند، اندازه قلم مو ثابت می‌ماند و برعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیاء متن دارد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام خروجی و رندرینگ**

Aspose.Slides اینترفیس [IInkOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/) را برای کنترل نحوه نمایش اشیاء جوهر در خروجی یا رندرینگ فراهم می‌کند. می‌توانید از ویژگی‌های آن برای مخفی کردن کامل جوهر یا تغییر نحوه تفسیر عملیات ماسک قلم مو جوهر استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندرینگ برای چندین نوع خروجی در دسترس هستند:

| خروجی | ویژگی گزینه‌های جوهر |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| تصویر اسلاید | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

متدهای زیر از [IInkOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/) دو تنظیم یکسان را ارائه می‌دهند:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#getHideInk--) تعیین می‌کند که آیا اشیاء جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `false` است.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) تعیین می‌کند که آیا یک عملیات ماسک به عنوان شفافیت تفسیر شود هنگام رندرینگ قلم مو جوهر. مقدار پیش‌فرض آن `true` است؛ برای استفاده از عملیات ROP به جای آن، متد [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با `false` فراخوانی کنید.

### **مخفی کردن اشیاء جوهر در خروجی PDF**

به‌طور پیش‌فرض، اشیاء جوهر هنگام خروجی قابل مشاهده هستند. برای ایجاد خروجی تمیز بدون حاشیه‌نویسی‌های دست‌نویس یا سایر محتوای جوهر، متد [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) را با `true` فراخوانی کنید.

مثال زیر در Java یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیاء جوهر مخفی هستند:

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

### **مخفی کردن اشیاء جوهر هنگام رندرینگ اسلاید به تصویر**

برای مخفی کردن اشیاء جوهر هنگام رندرینگ اسلایدها به تصویر بیت‌مپ، گزینه‌های [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/#getInkOptions--) را پیکربندی کرده و گزینه‌های رندرینگ را به متد [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) پاس دهید.

مثال زیر در Java اسلاید اول را به تصویر PNG رندر می‌کند بدون اشیاء جوهر:

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

تنظیم [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) نحوه تفسیر عملیات ماسک را هنگام رندرینگ قلم موهای جوهر کنترل می‌کند. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP به جای آن، متد [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با `false` فراخوانی کنید.

مثال زیر در Java یک اسلاید را به SVG صادر می‌کند و از رندر مبتنی بر ROP برای عملیات ماسک جوهر استفاده می‌کند:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

همین تنظیم می‌تواند از طریق [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#getInkOptions--) هنگام خروجی یک ارائه یا رندر اسلاید به TIFF نیز اعمال شود.

### **انتخاب مخفی یا نگهداری جوهر**

زمانی که نیاز به نسخه‌ای تمیز از یک ارائه حاشیه‌دار برای توزیع بدون علامت‌های بررسی دارید، در زمان خروجی متد [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) را با `true` صدا بزنید.

در صورتی که حاشیه‌نویسی‌های جوهر بخشی از محتوای مورد نظر هستند (مانند نظرات بررسی، یادداشت‌های دست‌نویس، برجسته‌سازی یا طرح‌هایی که باید در نتیجه خروجی دیده شوند)، ویژگی [IInkOptions.getHideInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#getHideInk--) را با مقدار پیش‌فرض `false` بگذارید. این امکان را می‌دهد تا برنامه‌ها بدون تغییر در اشیاء جوهر منبع، خروجی‌های بررسی و نهایی جداگانه‌ای از همان ارائه تولید کنند.

## **سوالات متداول**

**آیا می‌توانم رنگ یا اندازه یک خط جوهر موجود را تغییر دهم؟**

بله. ردیاب را از [IInk.getTraces](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iink/#getTraces--) دریافت کنید، سپس قلم مو آن را تغییر دهید. برای تغییر رنگ از [IInkBrush.setColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) یا برای تغییر اندازه از [IInkBrush.setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) استفاده کنید.

**آیا مخفی کردن جوهر منبع ارائه را تغییر می‌دهد؟**

نه. فراخوانی [IInkOptions.setHideInk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) فقط بر نتیجه رندر یا خروجی تأثیر می‌گذارد؛ اشیاء جوهر در منبع ارائه حذف یا تغییر نمی‌شوند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های خروجی یا رندرینگ مربوطه که در جدول بالا نشان داده شد، پیکربندی کنید.

**خواندن بیشتر**

* برای مطالعه درباره اشکال به‌طور کلی، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/java/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/java/convert-powerpoint-to-pdf/) نگاه کنید.
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/java/convert-powerpoint-to-html/) مراجعه کنید.
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/java/render-a-slide-as-an-svg-image/) نگاه کنید.
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/java/convert-powerpoint-to-tiff/) مراجعه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/java/convert-slide/) نگاه کنید.