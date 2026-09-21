---
title: مدیریت فیلدهای متنی در ارائه‌های پاورپوینت با جاوا
linktitle: فیلدهای متنی
type: docs
weight: 52
url: /fa/java/text-fields/
keywords:
- فیلد متنی
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سرصفحه
- پاورقی
- بخش متنی
- پاورپوینت
- PPT
- PPTX
- جاوا
- Aspose.Slides
description: "ایجاد، بررسی، اصلاح و حذف فیلدهای متنی در ارائه‌های پاورپوینت با Aspose.Slides برای جاوا. حفظ قالب‌بندی و اعتبارسنجی فایل‌های ذخیره‌شده PPTX و PPT."
---
## **بررسی کلی**

یک پاراگراف متنی شامل بخش‌ها است. یک [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) معمولی شامل متن لغوی است؛ یک بخش میدانی همچنین یک [IField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifield/) دارد که نوع آن یک مقدار به‌روزرسانی خودکار را شناسایی می‌کند، مانند شماره اسلاید یا تاریخ. دو بخش می‌توانند همان کاراکترها را نشان دهند در حالی که فقط یکی دارای میدانی است.

از [IPortion.getField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getField--) برای تمایز آن‌ها استفاده کنید: برای متن معمولی `null` برمی‌گرداند. [IPortion.addField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) یک بخش موجود را به میدانی تبدیل می‌کند. برچسب و مقدار پویا را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار، برچسب را نیز جایگزین نکند.

این راهنما به میدانی‌های داخل متن، قالب‌بندی آن‌ها و ذخیره‌سازی در فرمت‌های PPTX و PPT می‌پردازد. برای فریم‌ها و پاراگراف‌های متنی، به [Manage Text](/slides/fa/java/manage-text/) مراجعه کنید.

## **ایجاد میدانی برای شماره اسلاید**

مثال کامل زیر یک جعبه متن ایجاد می‌کند که شامل برچسب لغوی `Slide ` و سپس یک شماره به‌صورت خودکار به‌روز شده است. قبل از افزودن میدانی، اندازه، وزن و رنگ عدد را تنظیم می‌کند، سپس ارائه ذخیره‌شده را دوباره باز می‌کند و نوع میدانی، متن و قالب‌بندی آن را بررسی می‌کند. نیازی به فایل ورودی نیست.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ارائه جدید با شماره اسلاید 1 آغاز می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی مقدار `true` را چاپ می‌کنند. پس از باز کردن مجدد، عدد همچنان به‌صورت میدانی باقی می‌ماند؛ این یک `1` لغوی نیست. تبدیل‌های نوعی و شاخص‌های موجود در تأیید به شکل و بخش‌های ایجاد شده توسط این مثال اشاره دارند.

## **انتخاب نوع میدانی**

[FieldType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/) رابط [IFieldType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifieldtype/) را پیاده‌سازی می‌کند و روش‌های زیر را برای دریافت مقادیر پیش‌تعریف‌شده فراهم می‌سازد. مقدار مناسب را به [addField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) پاس بدهید.

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getSlideNumber--) | شماره اسلاید فعلی. |
| [getDateTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime--) | تاریخ/زمان در قالب پیش‌فرض برنامه رندرکننده. |
| [getDateTime1](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime9--) | فرمت‌های پیش‌تعریف‌شده تاریخ یا ترکیب تاریخ/زمان. |
| [getDateTime10](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime13--) | فرمت‌های پیش‌تعریف‌شده زمان، با گزینه‌های ثانیه و ساعت 12‑ساعته. |
| [getHeader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getHeader--) | یک میدانی هدر؛ محدودیت‌های جایگزینگر و قالب در ادامه آمده است. |
| [getFooter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getFooter--) | میدانی پاورقی. |

به عنوان مثال، [getDateTime3](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#getDateTime3--) روز، نام کامل ماه و سال را به زبان انگلیسی نشان می‌دهد. این‌ها فرمت‌های پیش‌تعریف‌شده میدانی هستند، نه رشته‌های دلخواه قالب تاریخ جاوا. زبانی که با [setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) تنظیم می‌شود و برنامه‌ای که ارائه را پردازش می‌کند می‌توانند بر نتیجه نمایش تأثیر بگذارند.

## **ایجاد میدانی از رشته داخلی**

بارگذاری رشته‌ای [addField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#addField-java.lang.String-) یک شناسه میدانی داخلی را می‌پذیرد. وقتی می‌خواهید شناسه‌ای را که برنامه‌ای دیگر ارائه داده و مقدار پیش‌تعریف‌شده‌ای ندارد حفظ کنید، از آن استفاده کنید. همچنین می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) از این شناسه بسازید. [IFieldType.getInternalString](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifieldtype/#getInternalString--) این شناسه را برای بازرسی نشان می‌دهد.

این مثال میدانی `custom-report-id` خاص برنامه را با متن جایگزین `Report-042` ذخیره می‌کند. این شناسه هیچ محاسبه‌ای ثبت نمی‌کند: Aspose.Slides برای نوع ناشناخته شناسه‌های گزارشی تولید نمی‌کند. برنامه‌ای که این شناسه را می‌داند باید معنای آن را فراهم کرده و مقدارش را به‌روز کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

پس از این دور‌گردی PPTX، نوع `custom-report-id` و متن `Report-042` باقی می‌مانند. ارسال رشته‌ای مانند `yyyy-MM-dd` یک نوع میدانی را نام‌گذاری می‌کند؛ اما قالب تاریخ سفارشی را پیکربندی نمی‌کند. برای تاریخ ثابت در قالب دلخواه، از متن معمولی استفاده کنید.

## **بازرسی، تغییر و حذف میدانی‌های تاریخ/زمان**

یک میدانی موجود را با استفاده از [IField.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) تغییر دهید. قبل از دسترسی به نوع میدانی، وجود آن را بررسی کنید. برای متوقف کردن به‌روزرسانی خودکار، [IPortion.removeField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#removeField--) را فراخوانی کنید. این کار بخش و متن فعلی را نگه می‌دارد و ارتباط میدانی را حذف می‌کند. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف میدانی متن موردنظر را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش میدانی‌های تاریخ/زمان، به [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) مراجعه کنید. مثال زیر از تاریخ تأیید صریح هنگام تبدیل میدانی به متن عادی استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کنید و در پوشه کاری قرار دهید. این فایل دو شکل متنی با نام‌های `UpdatedAt` و `ApprovedDate` دارد که هر یک میدانی تاریخ/زمان دارند، به‌علاوه برچسب‌های متن معمولی. مثال زیر به شکل‌های متنی سطح بالای اسلایدهای معمولی می‌پردازد. میدانی‌های تاریخ/زمان را به قالب تاریخ طولانی تغییر می‌دهد و آن‌ها را ایتالیک می‌کند، در حالی که قالب‌بندهای دیگرشان را حفظ می‌کند. فقط میدانی‌های موجود در `ApprovedDate` به متن ثابت تبدیل می‌شوند.

نمونه شناسه‌های داخلی ساخته‌شده `datetime` و `datetime1` تا `datetime13` را تشخیص می‌دهد. گروه‌ها، جداول، یادداشت‌ها، طرح‌بندی‌ها و مسترها نیاز به پیمایش مخازن متنی خود دارند و در دامنه این مثال نیستند.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

پس از باز کردن مجدد، `UpdatedAt` نوع `datetime3` دارد و پویا می‌ماند. `ApprovedDate` میدانی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازه فونت، تنظیم بولد و رنگ اصلی آن‌ها حفظ شده است. برچسب‌های متن معمولی تغییر نکرده‌اند. تأیید، اولین بخش دو شکل شناخته‌شده در نمونه ارائه‌شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن میدانی، تغییر نوع آن یا حذف آن، با بخش موجود کار کنید. این عملیات‌ها قالب‌بندی بخش را حفظ می‌کنند. برای تغییر فقط ویژگی‌های مورد نیاز، از [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getPortionFormat--) استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازساخت کامل یک فریم متنی فقط برای به‌روزرسانی یک میدانی جلوگیری کنید؛ این کار می‌تواند مرزهای بخش اصلی و قالب‌بندی‌های منفرد آن را از دست بدهد. همچنین قالب‌بندی صریح تنظیم شده را از قالب‌بندی‌های به‌ارث‌برده از پاراگراف، طرح‌بندی یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی، به [Text Formatting](/slides/fa/java/text-formatting/) مراجعه کنید.

## **میادین و جایگزینگرهای سرصفحه/پاورقی**

یک میدانی بخشی از یک بخش متنی است. یک جایگزینگر (placeholder) یک شکل با نقش ارائه، مانند پاورقی یا شماره اسلاید، است. افزودن میدانی به یک جعبه متن معمولی آن شکل را به جایگزینگر تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن جایگزینگر و قابلیت مشاهده آن را در اسلایدها، طرح‌بندی‌ها و مسترها کنترل می‌کنند، شامل انتشار به اسلایدهای وابسته. بنابراین یک میدانی شماره در جعبه متن سفارشی می‌تواند مفید باشد حتی اگر از جایگزینگر شماره اسلاید استفاده نکنید. برعکس، تغییر قابلیت مشاهده جایگزینگر میدانی را از یک جعبه متن نامربط حذف نمی‌کند.

انواع پیش‌تعریف‌شده سرصفحه و پاورقی، جایگزینگرهای متناظر را ایجاد یا محتویات آن‌ها را فراهم نمی‌کنند. به‌خصوص، یک اسلاید پاورپوینت معمولی جایگزینگر سرصفحه ندارد؛ سرصفحه‌ها به صفحات یادداشت و جزوات تعلق دارند. فرض نکنید که میدانی سرصفحه یا پاورقی در یک شکل دلخواه به‌صورت خودکار متن تنظیم‌شده توسط مدیر جایگزینگر را دریافت می‌کند. برای این روند کاری، به [Presentation Headers and Footers](/slides/fa/java/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و بازگشایی، هر دو نوع میدانی و متن حاصل آن را بررسی کنید. حفظ یک شناسه نشان نمی‌دهد که برنامه می‌تواند مقدار آن را محاسبه یا نمایش دهد.

| Format | Field behavior and limitations |
|---|---|
| PPTX | شناسه‌های داخلی میدانی را همراه با متن میدانی ذخیره می‌کند. در بررسی‌های دور‌گردی، انواع پیش‌تعریف‌شده و شناسه سفارشی استفاده‌شده در بالا پس از ذخیره و بازگشایی باقی مانده‌اند. نوع سفارشی ناشناخته متن جایگزین خود را حفظ کرد؛ منطق محاسبه خودکار به‌دست نیاورد. برنامه دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌طرز متفاوتی پردازش کند. |
| PPT | از نمایش‌های میدانی قدیمی استفاده می‌کند و سازگاری محدودتری دارد. در بررسی‌های دور‌گردی، میدانی‌های شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازگشایی حفظ شدند. یک میدانی سفارشی در جعبه متن اسلاید معمولی با شناسه خود باز شد اما متن آن `*` بود؛ میدانی سرصفحه در همان زمینه نیز `*` تولید کرد. به نگهداری متن قابل مشاهده میدانی‌های سفارشی یا زمینه‌های میدانی پشتیبانی‌نشده اعتماد نکنید. |

برای خروجی قابل حمل و ثابت، میدانی‌های پشتیبانی‌نشده را به متن عادی تبدیل کنید و مقدار دلخواه را به‌صورت صریح قبل از ذخیره‌سازی اختصاص دهید. این کار متن انتخاب‌شده را حفظ می‌کند اما به‌طور عمدی به‌روزرسانی خودکار را متوقف می‌سازد. همچنین هنگامی که محاسبه مجدد میدانی خود برنامه هدف بخشی از جریان کاری شماست، آن برنامه را نیز تست کنید.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که عدد یا تاریخ نمایش داده‌شده یک میدانی است؟**

[IPortion.getField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getField--) را بررسی کنید. مقدار غیرnull نشان‌دهنده میدانی است؛ متن نمایش داده‌شده به‌تنهایی نمی‌تواند این را تشخیص دهد.

**آیا حذف میدانی متن یا قالب‌بندی آن را نیز حذف می‌کند؟**

خیر. [removeField](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#removeField--) بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار ثابت خاصی مانند تاریخ یا متن جایگزین نیاز دارید، پس از آن مقدار صریحی اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

خیر. این رشته فقط نوع میدانی را شناسایی می‌کند. شناسه ناشناخته ارزیاب یا الگوی قالب تاریخ جاوا ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شده پشتیبانی‌شده استفاده کنید یا مقدار را به‌صورت متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی ارائه را دوباره بررسی می‌کنیم؟**

شناسه‌های میدانی، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای برای تأیید هستند. تبدیل قالب می‌تواند نتیجه قابل مشاهده را تغییر دهد حتی اگر شناسه میدانی هنوز موجود باشد.