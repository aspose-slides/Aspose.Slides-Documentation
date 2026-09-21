---
title: مدیریت فیلدهای متنی در ارائه‌های پاورپوینت در اندروید
linktitle: فیلدهای متنی
type: docs
weight: 52
url: /fa/androidjava/text-fields/
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
- اندروید
- جاوا
- Aspose.Slides
description: "ایجاد، بازرسی، اصلاح و حذف فیلدهای متنی در ارائه‌های پاورپوینت با Aspose.Slides برای اندروید از طریق جاوا. حفظ قالب‌بندی و تأیید فایل‌های ذخیره‌شده PPTX و PPT."
---
## **بررسی کلی**

یک پاراگراف متنی از بخش‌ها تشکیل شده است. یک [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) عادی شامل متن ساده است؛ یک بخش فیلد همچنین یک [IField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifield/) دارد که نوع آن مقدار به‌صورت خودکار به‌روز شده‌ای را شناسایی می‌کند، مانند شماره اسلاید یا تاریخ. دو بخش می‌توانند همان کاراکترها را نمایش دهند در حالی که فقط یکی شامل یک فیلد است.

از [IPortion.getField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getField--) برای تشخیص آن‌ها استفاده کنید: برای متن عادی `null` است. [IPortion.addField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) یک بخش موجود را به فیلد تبدیل می‌کند. برچسب و مقدار پویا آن را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار باعث جایگزینی برچسب نشود.

این راهنما به فیلدهای داخل متن، قالب‌بندی آن‌ها و ذخیره‌سازی در PPTX و PPT می‌پردازد. برای فریم‌ها و پاراگراف‌های متنی، به [Manage Text](/slides/fa/androidjava/manage-text/) مراجعه کنید.

## **ایجاد فیلد شماره اسلاید**

مثال کامل زیر یک جعبه متن ایجاد می‌کند که شامل برچسب متنی `Slide ` به‌همراه عددی به‌صورت خودکار به‌روز شده است. قبل از افزودن فیلد، اندازه، ضخامت و رنگ عدد تنظیم می‌شود، سپس ارائه ذخیره‌شده باز شده و نوع فیلد، متن و قالب‌بندی آن بررسی می‌شود. هیچ فایل ورودی‌ای لازم نیست.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

ارائه جدید با شماره اسلاید ۱ آغاز می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی مقدار `true` را چاپ می‌کنند. عدد پس از باز شدن مجدد همچنان یک فیلد می‌ماند؛ این یک مقدار متنی `1` نیست. تبدیل‌ها و ایندکس‌های موجود در تأیید به شکل و بخش‌های ایجاد شده توسط این مثال اشاره دارند.

## **انتخاب نوع فیلد**

[FieldType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/) رابط [IFieldType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifieldtype/) را پیاده‌سازی می‌کند و روش‌های زیر را برای دریافت مقادیر پیش‌تعریف‌شده فراهم می‌سازد. مقدار مناسب را به [addField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) پاس دهید.

| روش | هدف |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | شماره اسلاید فعلی. |
| [getDateTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | تاریخ/زمان در قالب پیش‌فرض برنامه رندر کننده. |
| [getDateTime1](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | قالب‌های تاریخ پیش‌تعریف‌شده یا ترکیبی تاریخ/زمان. |
| [getDateTime10](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | قالب‌های زمان پیش‌تعریف‌شده، با گزینه‌های ثانیه و ساعت ۱۲ ساعته. |
| [getHeader](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getHeader--) | یک فیلد سرصفحه؛ محدودیت‌های placeholder و قالب در زیر را ببینید. |
| [getFooter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getFooter--) | یک فیلد پاورقی. |

به عنوان مثال، [getDateTime3](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) روز، نام کامل ماه و سال را به زبان انگلیسی نمایش می‌دهد. این‌ها قالب‌های فیلد پیش‌تعریف‌شده هستند و نه رشته‌های دلخواه قالب تاریخ جاوا. زبانی که با [setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) تنظیم می‌شود و برنامه‌ای که ارائه را پردازش می‌کند می‌تواند بر نتیجه نمایش‌شده تاثیر بگذارد.

## **ایجاد فیلد از یک رشته داخلی**

نسخهٔ رشته‌ای [addField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) یک شناسهٔ فیلد داخلی را می‌پذیرد. زمانی که می‌خواهید شناسه‌ای را که توسط برنامهٔ دیگری فراهم شده و مقدار پیش‌تعریف‌شده‌ای ندارد، حفظ کنید، از آن استفاده کنید. می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) را نیز از این شناسه بسازید. [IFieldType.getInternalString](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) این شناسه را برای بازرسی نمایش می‌دهد.

این مثال فیلد `custom-report-id` مخصوص برنامه را با متن پیش‌فرض `Report-042` ذخیره می‌کند. این شناسه محاسبه‌ای را ثبت نمی‌کند: Aspose.Slides شناسه‌های گزارش برای نوع ناشناخته تولید نمی‌کند. برنامه‌ای که این شناسه را می‌داند باید معنای آن را فراهم کرده و مقدار آن را به‌روز کند.

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

پس از این دور زدن PPTX، نوع فیلد `custom-report-id` و متن `Report-042` باقی می‌ماند. عبور یک رشته مانند `yyyy-MM-dd` یک نوع فیلد را نام‌گذاری می‌کند؛ قالب تاریخ دلخواهی تنظیم نمی‌کند. برای تاریخ ثابت در قالب دلخواه، از متن ساده استفاده کنید.

## **بازرسی، اصلاح و حذف فیلدهای تاریخ/زمان**

یک فیلد موجود را از طریق [IField.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) تغییر دهید. پیش از دسترسی به نوع فیلد، وجود آن را بررسی کنید. برای متوقف کردن به‌روز‌رسانی خودکار، [IPortion.removeField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#removeField--) را فراخوانی کنید. این کار بخش و متن فعلی آن را حفظ می‌کند در حالی که ارتباط فیلد را حذف می‌نماید. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد آن متن را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش فیلدهای تاریخ/زمان، به [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) مراجعه کنید. مثال زیر از تاریخ تأیید صریحی هنگام تبدیل فیلد به متن عادی استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. این فایل شامل دو شکل متنی با نام‌های `UpdatedAt` و `ApprovedDate` است که هر کدام یک فیلد تاریخ/زمان دارند، به‌علاوه برچسب‌های متن عادی. مثال زیر شکل‌های متنی سطح‑بالا را در اسلایدهای عادی مرور می‌کند. فیلدهای تاریخ/زمان را به قالب تاریخ طولانی تغییر می‌دهد و آنها را ایتالیک می‌کند، در حالی که سایر قالب‌بندی‌هایشان حفظ می‌شود. فقط فیلدهای موجود در `ApprovedDate` به متن ثابت تبدیل می‌شوند.

نمونه شناسه‌های داخلی از پیش ساختهٔ `datetime` و `datetime1` تا `datetime13` را شناسایی می‌کند. گروه‌ها، جدول‌ها، یادداشت‌ها، لایه‌ها و مسترها نیاز به پیمایش کانتینرهای متنی خود دارند و در حوزهٔ این مثال نیستند.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

پس از باز کردن مجدد، `UpdatedAt` دارای نوع `datetime3` است و پویا باقی می‌ماند. `ApprovedDate` فیلدی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازهٔ فونت اصلی، تنظیم بولد و رنگ آنها دست نخورده باقی می‌ماند. برچسب‌های متن عادی تغییر نکرده‌اند. تأیید اولین بخش دو شکل شناخته‌شده در نمونهٔ ارائه شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن فیلد، تغییر نوع آن یا حذف آن، با بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر تنها ویژگی‌های مورد نیاز، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند، از [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getPortionFormat--) استفاده کنید.

از بازساخت یک فریم متن کامل صرفاً برای به‌روزرسانی یک فیلد خودداری کنید: این کار می‌تواند مرزهای بخش‌های اصلی و قالب‌بندی‌های فردی آنها را از دست بدهد. همچنین قالب‌بندی صراحتاً تنظیم‌شده را از قالب‌بندی به‌دست آمده از پاراگراف، لایه یا تم متمایز کنید. برای گزینه‌های قالب‌بندی گسترده‌تر به [Text Formatting](/slides/fa/androidjava/text-formatting/) مراجعه کنید.

## **فیلدها و جای‌گیرهای سرصفحه/پاورقی**

یک فیلد بخشی از یک بخش متنی است. یک placeholder یک شکل با نقش ارائه مانند پاورقی یا شماره اسلاید است. افزودن فیلد به یک جعبه متن عادی، آن شکل را به placeholder تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن placeholder و قابلیت مشاهده آن را در اسلایدها، لایه‌ها و مسترها کنترل می‌کنند، از جمله انتشار به اسلایدهای وابسته. بنابراین یک فیلد عددی در یک جعبه متن سفارشی می‌تواند حتی اگر از placeholder شماره اسلاید استفاده نکنید مفید باشد. برعکس، تغییر قابلیت مشاهده placeholder فیلدی را از جعبه متن نامرتبط حذف نمی‌کند.

انواع سرصفحه و پاورقی پیش‌تعریف‌شده placeholderهای مربوطه را ایجاد نمی‌کنند و محتوا را فراهم نمی‌سازند. به‌ویژه یک اسلاید PowerPoint معمولی placeholder سرصفحه ندارد؛ سرصفحه‌ها به صفحات یادداشت و جزوات تعلق دارند. فرض نکنید فیلد سرصفحه یا پاورقی در یک شکل دلخواه به‌صورت خودکار متنی که از طریق مدیر placeholder تنظیم شده است، دریافت می‌کند. برای این جریان کار، به [Presentation Headers and Footers](/slides/fa/androidjava/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و باز کردن مجدد، هم نوع فیلد و هم متن حاصل آن را بررسی کنید. حفظ یک شناسه اثباتی نیست بر این که برنامه بتواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار فیلد و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های داخلی فیلد را همراه با متن فیلد ذخیره می‌کند. در بررسی‌های دور‑زنی، انواع پیش‌تعریف‌شده و شناسهٔ سفارشی استفاده‌شده در بالا پس از ذخیره و باز کردن باقی مانده‌اند. نوع سفارشی ناشناخته متن پیش‌فرض خود را حفظ کرد؛ منطق محاسبه خودکار به‌دست نیاورد. برنامهٔ دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌ شکل متفاوتی رفتار کند. |
| PPT | از نمایش‌های فیلد قدیمی استفاده می‌کند و سازگاری محدودتری دارد. در بررسی‌های دور‑زنی، فیلدهای شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و باز کردن باقی مانده‌اند. یک فیلد سفارشی در جعبه متن اسلاید عادی با شناسه‌اش باز می‌شود اما متن آن `*` است؛ فیلد سرصفحه در همان زمینه نیز `*` تولید می‌کند. به حفظ متن قابل مشاهده فیلدهای سفارشی یا زمینه‌های فیلد پشتیبانی‌نشده اطمینان نکنید. |

برای خروجی قابل حمل و ثابت، فیلدهای پشتیبانی‌نشده را به متن عادی تبدیل کنید و قبل از ذخیره‌سازی مقدار مورد نظر را به‌صورت صریح اختصاص دهید. این کار متن انتخاب‌شده را حفظ می‌کند اما به‌صورت عمدی به‌روزرسانی خودکار را متوقف می‌سازد. همچنین برنامه هدف را تست کنید وقتی محاسبه مجدد فیلدهای خود آن بخشی از جریان کار شماست.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که عدد یا تاریخ نمایش داده شده یک فیلد است؟**  
به [IPortion.getField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getField--) نگاه کنید. مقدار غیر‑null نشان‌دهنده یک فیلد است؛ تنها متن نمایش داده شده نمی‌تواند این را تشخیص دهد.

**آیا حذف فیلد متن یا قالب‌بندی آن را حذف می‌کند؟**  
خیر. [removeField](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#removeField--) بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد مقدار صریحی را اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ جدید یا فرمولی تعریف کند؟**  
خیر. این رشته نوع فیلد را شناسایی می‌کند. یک شناسه ناشناخته ارزیاب یا الگوی قالب تاریخ جاوا ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شدهٔ پشتیبانی‌شده استفاده کنید یا مقدار را خودتان به‌صورت متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی یک ارائه دوباره آن را بررسی کنیم؟**  
شناسه‌های فیلد، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای برای تأیید هستند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی اگر شناسهٔ فیلد همچنان وجود داشته باشد.