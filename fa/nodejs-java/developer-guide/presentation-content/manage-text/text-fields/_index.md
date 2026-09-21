---
title: مدیریت میدانی‌های متنی در ارائه‌های PowerPoint با JavaScript
linktitle: میدانی‌های متنی
type: docs
weight: 52
url: /fa/nodejs-java/text-fields/
keywords:
- میدان متنی
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سرصفحه
- پاورقی
- بخش متنی
- پاورپوینت
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد، بررسی، ویرایش و حذف میدانی‌های متنی در ارائه‌های PowerPoint با Aspose.Slides برای Node.js از طریق Java. حفظ قالب‌بندی و تأیید فایل‌های ذخیره‌شدهٔ PPTX و PPT."
---
## **نمای کلی**

یک پاراگراف متن از بخش‌ها تشکیل شده است. یک [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) معمولی شامل متن صرفاً است؛ یک بخش میدانی همچنین دارای یک [Field](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/field/) است که نوع آن مقدار به‌روزرسانی خودکار مانند شماره اسلاید یا تاریخ را شناسایی می‌کند. دو بخش می‌توانند همان کاراکترها را نمایش دهند در حالی که فقط یکی شامل میدانی است.

از [Portion.getField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getField) برای تشخیص آن‌ها استفاده کنید: برای متن عادی مقدار آن `null` است. [Portion.addField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#addField) یک بخش موجود را به میدانی تبدیل می‌کند. برچسب و مقدار پویا را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار باعث جایگزینی برچسب نشود.

این راهنما به میدانی‌های داخل متن، قالب‌بندی آن‌ها و ذخیره‌سازی در PPTX و PPT می‌پردازد. برای فریم‌های متنی و پاراگراف‌ها، به [Manage Text](/slides/fa/nodejs-java/manage-text/) مراجعه کنید.

## **ایجاد میدانی برای شماره اسلاید**

مثال کامل زیر یک جعبه متن ایجاد می‌کند که شامل برچسب متنی `Slide ` به‌همراه یک شماره به‌روزرسانی خودکار است. قبل از افزودن میدانی، اندازه، وزن و رنگ شماره تنظیم می‌شود، سپس ارائه ذخیره‌شده باز می‌شود و نوع میدانی، متن و قالب‌بندی آن بررسی می‌گردد. هیچ فایل ورودی‌ای مورد نیاز نیست.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ارائه جدید با شماره اسلاید 1 شروع می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی `true` را چاپ می‌کنند. پس از بازگشایی، عدد همچنان میدانی است؛ مقدار آن یک `1` متنی نیست. ایندکس‌های موجود در تأیید، به شکل و بخش‌هایی که این مثال ایجاد کرده است اشاره دارد.

## **انتخاب نوع میدانی**

[FieldType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/) روش‌های زیر را برای دریافت مقادیر پیش‌تعریف‌شده فراهم می‌کند. مقدار مناسب را به [addField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#addField) بدهید.

| متد | هدف |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | شماره اسلاید جاری. |
| [getDateTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime) | تاریخ/زمان در قالب پیش‌فرض برنامهٔ رندرکننده. |
| [getDateTime1](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | قالب‌های پیش‌تعریف‌شدهٔ تاریخ یا ترکیب تاریخ/زمان. |
| [getDateTime10](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | قالب‌های پیش‌تعریف‌شدهٔ زمان، با گزینه‌های ثانیه و ساعت 12 ساعته. |
| [getHeader](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getHeader) | میدانی سرصفحه؛ به محدودهٔ متغیرها و قالب‌های زیر نگاه کنید. |
| [getFooter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getFooter) | میدانی پاورقی. |

به‌عنوان مثال، [getDateTime3](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getDateTime3) نمایانگر «روز، نام کامل ماه و سال» به زبان انگلیسی است. این‌ها قالب‌های پیش‌تعریف‌شدهٔ میدانی هستند، نه رشته‌های دلخواه قالب‌ تاریخ. زبانی که با [setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) تنظیم می‌کنید و برنامهٔ پردازش‌کنندهٔ ارائه می‌توانند نتیجهٔ نمایش‌شده را تحت تأثیر قرار دهند.

## **ایجاد میدانی از یک رشته داخلی**

بارگذاری رشته‌ای [addField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#addField) یک شناسهٔ میدانی داخلی می‌پذیرد. هنگامی که می‌خواهید شناسه‌ای که توسط برنامهٔ دیگری تامین شده است را حفظ کنید و مقدار پیش‌تعریف‌شده‌ای ندارید، از این روش استفاده کنید. می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/) نیز از این شناسه بسازید. [FieldType.getInternalString](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fieldtype/#getInternalString) این شناسه را برای بازرسی در دسترس می‌گذارد.

این مثال یک میدانی برنامه‌خاص `custom-report-id` را با متن پیش‌فرض `Report-042` ذخیره می‌کند. شناسه محاسبه‌ای تولید نمی‌کند: Aspose.Slides برای انواع ناشناخته شناسه‌ای تولید نمی‌کند. برنامه‌ای که این شناسه را می‌داند باید معنای آن را فراهم کرده و مقدارش را به‌روزرسانی کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

پس از این دور‌گردی PPTX، نوع میدانی `custom-report-id` و متن `Report-042` باقی می‌مانند. ارسال رشته‌ای مانند `yyyy-MM-dd` فقط یک نوع میدانی ایجاد می‌کند؛ قالب تاریخ دلخواه را پیکربندی نمی‌کند. برای تاریخ ثابت با قالب دلخواه، از متن عادی استفاده کنید.

## **بازرسی، تغییر و حذف میدانی‌های تاریخ/زمان**

یک میدانی موجود را از طریق [Field.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/field/#setType) تغییر دهید. قبل از دسترسی به نوع میدانی، وجود آن را بررسی کنید. برای قطع به‌روزرسانی خودکار، [Portion.removeField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#removeField) را فراخوانی کنید. این کار بخش را به متن فعلی‌اش تبدیل می‌کند در حالی که میدانی را حذف می‌نماید. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف میدانی آن متن را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش میدانی‌های تاریخ/زمان، به [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#setCurrentDateTime) مراجعه کنید. مثال زیر از تاریخ تأیید صریح هنگام تبدیل میدانی به متن عادی استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. این فایل دو شکل متنی نام‌دار `UpdatedAt` و `ApprovedDate` دارد که هر کدام دارای میدانی تاریخ/زمان هستند، به‌اضافه برچسب‌های متن عادی. مثال زیر شکل‌های متنی سطح بالای اسلایدهای عادی را بررسی می‌کند. میدانی‌های تاریخ/زمان را به قالب «تاریخ طولانی» تغییر می‌دهد و آن‌ها را ایتالیک می‌کند، در حالی که قالب‌بندی‌های دیگر حفظ می‌شود. فقط میدانی‌های موجود در `ApprovedDate` به متن ثابت تبدیل می‌شوند.

تاریخ تأیید 5 آوریل 2030 است؛ ایندکس‌های ماه در جاوااسکریپت از صفر شروع می‌شود، بنابراین آوریل `3` است. برای هم‌زمانی، از UTC برای ساخت و قالب‌بندی استفاده می‌شود تا تاریخ مستقل از منطقهٔ زمانی محلی باشد.

نمونه شناسه‌های داخلی ساخته‌شدهٔ `datetime` و `datetime1` تا `datetime13` را تشخیص می‌دهد. گروه‌ها، جداول، یادداشت‌ها، طرح‌بندی‌ها و الگوها نیاز به عبور از محفظه‌های متنی خود دارند و در محدودهٔ این مثال قرار نمی‌گیرند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

پس از بازگشایی، `UpdatedAt` نوع `datetime3` دارد و پویا باقی می‌ماند. `ApprovedDate` میدانی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازه قلم، حالت پررنگ و رنگ اصلی آن‌ها دست نخورده می‌ماند. برچسب‌های متن عادی تغییر نمی‌کنند. تأیید با خواندن اولین بخش از دو شکل شناخته‌شده در نمونهٔ ارائه‌شده انجام می‌شود.

## **حفظ قالب‌بندی متن**

هنگام افزودن میدانی، تغییر نوع آن یا حذف، با همان بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر فقط ویژگی‌های مورد نیاز، از [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getPortionFormat) استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازسازی تمام فریم متنی صرفاً برای به‌روزرسانی یک میدانی خودداری کنید: این کار می‌تواند مرزهای بخش‌ها و قالب‌بندی‌های فردی آن‌ها را از دست بدهد. همچنین قالب‌بندی صریح تنظیم‌شده را از قالب‌بندی وارثتی از پاراگراف، طرح‌بندی یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی، به [Text Formatting](/slides/fa/nodejs-java/text-formatting/) مراجعه کنید.

## **میدانی‌ها و محل‌دارهای سرصفحه/پاورقی**

یک میدانی بخشی از یک بخش متنی است. یک محل‌دار یک شکل با نقش ارائه است، مانند پاورقی یا شماره اسلاید. افزودن میدانی به یک جعبه متن عادی، آن شکل را به محل‌دار تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن محل‌دار و قابلیت مشاهده را در اسلایدها، طرح‌بندی‌ها و الگوها کنترل می‌کنند، از جمله انتشار به اسلایدهای وابسته. بنابراین یک میدانی شماره در یک جعبه متن سفارشی حتی زمانی که از محل‌دار شماره اسلاید استفاده نمی‌کنید می‌تواند مفید باشد. برعکس، تغییر قابلیت مشاهدهٔ محل‌دار میدانی را از جعبهٔ متنی نامرتبط حذف نمی‌کند.

انواع پیش‌تعریف‌شدهٔ سرصفحه و پاورقی محل‌دارهای متناظر را ایجاد نمی‌کنند یا محتوا را فراهم نمی‌سازند. به‌طور خاص، یک اسلاید PowerPoint معمولی محل‌دار سرصفحه ندارد؛ سرصفحه‌ها به صفحات یادداشت و برگه‌های توزیع تعلق دارند. فرض نکنید که میدانی سرصفحه یا پاورقی در یک شکل دلخواه به‌صورت خودکار متن پیکربندی‌شده از طریق مدیر محل‌دار را دریافت می‌کند. برای این جریان کار، به [Presentation Headers and Footers](/slides/fa/nodejs-java/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و بازگشایی، هم نوع میدانی و هم متن حاصل را بررسی کنید. حفظ یک شناسه اثبات نمی‌کند که برنامه‌ای بتواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار میدانی و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های میدانی داخلی همراه با متن میدانی ذخیره می‌شوند. در بررسی‌های دور‌گردی، انواع پیش‌تعریف‌شده و شناسه سفارشی استفاده‌شده در بالا پس از ذخیره و بازگشایی باقی می‌مانند. نوع سفارشی ناشناخته متن پیش‌فرض خود را حفظ می‌کند؛ محاسبهٔ خودکار اضافه نمی‌شود. برنامهٔ دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌صورت متفاوتی مدیریت کند. |
| PPT | از نماینده‌های میدانی قدیمی استفاده می‌کند و سازگاری محدودی دارد. در بررسی‌های دور‌گردی، میدانی‌های شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازگشایی باقی می‌مانند. میدانی سفارشی در یک جعبه متن اسلاید عادی پس از بازگشایی شناسه خود را دارد اما متن آن `*` است؛ میدانی سرصفحه در همان زمینه نیز `*` را تولید می‌کند. برای متن ثابت و قابل حمل، میدانی‌های پشتیبانی‌نشده را به متن عادی تبدیل کنید و مقدار دلخواه را پیش از ذخیره صریحاً اختصاص دهید. این کار متن انتخاب‌شده را حفظ می‌کند ولی به‌روزرسانی خودکار را متوقف می‌نماید. همچنین برنامهٔ هدف را هنگام استفاده از بازمحاسبهٔ میدانی تست کنید. |

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم که یک عدد یا تاریخ نشان‌داده‌شده میدانی است؟**

[Portion.getField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getField) را بررسی کنید. مقدار غیر‑null نشان‌دهنده وجود میدانی است؛ متن نمایش داده‌شده به تنهایی نمی‌تواند تشخیص دهد.

**آیا حذف میدانی متن یا قالب‌بندی آن را حذف می‌کند؟**

نه. [removeField](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#removeField) بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار خاصی نیاز دارید، پس از حذف میدانی مقدار صریح را اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

نه. این رشته تنها نوع میدانی را شناسایی می‌کند. شناسهٔ ناشناخته ارزیاب یا الگوی قالب تاریخ ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شدهٔ پشتیبانی‌شده استفاده کنید یا مقدار را به‌صورت متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی باید ارائه را دوباره بررسی کنم؟**

شناسه‌های میدانی، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای هستند که باید تأیید شوند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی اگر شناسهٔ میدانی همچنان موجود باشد.