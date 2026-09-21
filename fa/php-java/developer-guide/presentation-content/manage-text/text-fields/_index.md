---
title: مدیریت فیلدهای متنی در ارائه‌های پاورپوینت در PHP
linktitle: فیلدهای متنی
type: docs
weight: 52
url: /fa/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "ایجاد، بازرسی، ویرایش و حذف فیلدهای متنی در ارائه‌های پاورپوینت با Aspose.Slides برای PHP از طریق Java. حفظ قالب‌بندی و تأیید فایل‌های PPTX و PPT ذخیره‌شده."
---
## **مرور کلی**

یک پاراگراف متنی شامل بخش‌هایی است. یک ‎[Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/)‎ معمولی شامل متن ثابت است؛ یک بخش فیلد همچنین دارای یک ‎[Field](https://reference.aspose.com/slides/fa/php-java/aspose.slides/field/)‎ است که نوع آن مقدار به‑روز شده خودکاری مانند شماره اسلاید یا تاریخ را شناسایی می‌کند. دو بخش می‌توانند همان کاراکترها را نمایش دهند در حالی که تنها یکی شامل فیلد است.

از ‎[Portion::getField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getField)‎ برای تمایز آن‌ها استفاده کنید: برای متن معمولی مقدار ‎`null`‎ برگردانده می‌شود. ‎[Portion::addField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#addField)‎ یک بخش موجود را به فیلد تبدیل می‌کند. برچسب و مقدار پویا آن را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار، برچسب را نیز جایگزین نکند.

این راهنما به فیلدها در متن، قالب‌بندی آن‌ها و ذخیره‌سازی در ‎PPTX‎ و ‎PPT‎ می‌پردازد. برای فریم‌ها و پاراگراف‌های متنی، به ‎[Manage Text](/slides/fa/php-java/manage-text/)‎ نگاه کنید.

## **ایجاد فیلد شماره اسلاید**

مثال کامل زیر یک جعبه متن حاوی برچسب ثابت ‎`Slide `‎ و عددی که به‑صورت خودکار به‌روزرسانی می‌شود، می‌سازد. پیش از افزودن فیلد، اندازه، وزن و رنگ عدد را تنظیم می‌کند، سپس ارائه ذخیره‑شده را باز می‌کند و نوع فیلد، متن و قالب‌بندی را بررسی می‌کند. فایل ورودی نیاز نیست.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

ارائه جدید با شماره اسلاید ۱ شروع می‌شود، بنابراین متن ‎`Slide 1`‎ است و هر دو بررسی ‎`true`‎ چاپ می‌شود. پس از بازگشایی، عدد همچنان یک فیلد باقی می‌ماند؛ این یک ‎`1`‎ ثابت نیست. شاخص‌های موجود در تأیید، به شکل و بخش‌های ایجاد شده توسط این مثال اشاره دارند.

## **انتخاب نوع فیلد**

‏‎[FieldType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/)‎ روش‌های زیر را برای دریافت مقادیر پیش‌تعریف‌شده فراهم می‌کند. مقدار مناسب را به ‎[addField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#addField)‎ منتقل کنید.

| روش | هدف |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getSlideNumber) | شماره اسلاید جاری. |
| [getDateTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime) | تاریخ/زمان در قالب پیش‌فرض برنامه رندر. |
| [getDateTime1](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime9) | قالب‌های پیش‌تعریف‌شده تاریخ یا ترکیبی تاریخ/زمان. |
| [getDateTime10](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime13) | قالب‌های پیش‌تعریف‌شده زمان، با گزینه‌های ثانیه و ساعت ۱۲ ساعته. |
| [getHeader](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getHeader) | فیلد سرصفحه؛ محدودیت‌های جای‌نما و قالب در ادامه را ببینید. |
| [getFooter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getFooter) | فیلد پاورقی. |

به عنوان مثال، ‎[getDateTime3](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getDateTime3)‎ نمایانگر روز، نام کامل ماه و سال به زبان انگلیسی است. این‌ها قالب‌های پیش‌تعریف‌شده فیلد هستند، نه رشته‌های دلخواه ‎PHP‎. زبانی که با ‎[setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId)‎ تنظیم می‌شود و برنامه‌ای که ارائه را پردازش می‌کند می‌توانند نتیجه نمایش داده‌شده را تحت تأثیر قرار دهند.

## **ایجاد فیلد از رشته داخلی**

بارگذاری رشته‌ای ‎[addField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#addField)‎ شناساگر فیلد داخلی را می‌پذیرد. زمانی استفاده می‌شود که شناساگری توسط برنامه دیگری تأمین شده باشد و مقدار پیش‌تعریف‌شده‌ای نداشته باشد. همچنین می‌توانید ‎[FieldType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#FieldType)‎ را از این شناساگر بسازید. ‎[FieldType::getInternalString](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fieldtype/#getInternalString)‎ این شناساگر را برای بررسی در اختیار می‌گذارد.

این مثال فیلد ‎`custom-report-id`‎ مخصوص برنامه را همراه با متن پیش‌فرض ‎`Report-042`‎ ذخیره می‌کند. شناساگر محاسبه‌ای را ثبت نمی‌کند: ‎Aspose.Slides‎ برای نوع ناشناخته شناساگرهای گزارش تولید نمی‌کند. برنامه‌ای که این شناساگر را می‌داند باید معنایش را فراهم کرده و مقدار آن را به‌روز کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

پس از این دور کاری ‎PPTX‎، نوع فیلد ‎`custom-report-id`‎ و متن ‎`Report-042`‎ باقی می‌مانند. عبور یک رشته مانند ‎`Y-m-d`‎ تنها نامی برای نوع فیلد می‌سازد؛ قالب تاریخ سفارشی را پیکربندی نمی‌کند. برای تاریخ ثابت در قالب دلخواه، از متن عادی استفاده کنید.

## **بازرسی، تغییر و حذف فیلدهای تاریخ/زمان**

فیلد موجود را از طریق ‎[Field::setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/field/#setType)‎ تغییر دهید. قبل از دسترسی به نوع فیلد، وجود آن را بررسی کنید. برای قطع به‌روزرسانی خودکار، ‎[Portion::removeField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#removeField)‎ را صدا بزنید. این کار بخش و متن فعلی را حفظ می‌کند در حالی که ارتباط فیلد را حذف می‌نماید. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد متن مورد نظر را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش فیلدهای تاریخ/زمان، به ‎[Presentation::setCurrentDateTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#setCurrentDateTime)‎ مراجعه کنید. مثال زیر از یک تاریخ تأیید صریح هنگام تبدیل فیلد به متن عادی استفاده می‌کند.

‏‎[sample.pptx](sample.pptx)‎ را دانلود کنید و در پوشه کاری ‎JavaBridge‎ قرار دهید یا مسیر مطلق آن را به سازنده ارائه بدهید. این فایل شامل دو شکل متنی نام‌گذاری شده ‎`UpdatedAt`‎ و ‎`ApprovedDate`‎ است که هر کدام دارای فیلد تاریخ/زمان هستند، به‌علاوه برچسب‌های متن عادی. مثال زیر شکل‌های متنی سطح بالا در اسلایدهای معمولی را پیمایش می‌کند. فیلدهای تاریخ/زمان را به قالب تاریخ‑طول تبدیل می‌کند و ایتالیک می‌سازد، در حالی که قالب‌بندی دیگرشان را حفظ می‌کند. فقط فیلدهای موجود در ‎`ApprovedDate`‎ به متن ثابت تبدیل می‌شوند.

نمونه، شناساگرهای داخلی پیش‌ساخت ‎`datetime`‎ و ‎`datetime1`‎ تا ‎`datetime13`‎ را تشخیص می‌دهد. گروه‌ها، جداول، یادداشت‌ها، طرح‌بندی‌ها و مسترها نیاز به پیمایش مخازن متنی خود دارند و در حوزه این مثال قرار ندارند.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

پس از بازگشایی، ‎`UpdatedAt`‎ نوع ‎`datetime3`‎ دارد و پویا می‌ماند. ‎`ApprovedDate`‎ فیلدی ندارد و شامل ‎`05 April 2030`‎ است. هر دو بخش تاریخ ایتالیک هستند و اندازه قلم، تنظیم بولد و رنگ اصلی آنها دست نخورده می‌ماند. برچسب‌های متن عادی تغییر نمی‌کنند. تأیید، اولین بخش دو شکل شناخته‌شده در نمونهٔ ارائه شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن فیلد، تغییر نوع آن یا حذف، با بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر فقط ویژگی‌های مورد نیاز، از ‎[Portion::getPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getPortionFormat)‎ استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازسازی کل فریم متنی فقط برای به‌روزرسانی یک فیلد خودداری کنید: این کار می‌تواند مرزهای بخش‌های اصلی و قالب‌بندی فردی آن‌ها را از دست بدهد. همچنین قالب‌بندی صریح تنظیم‌شده را از قالب‌بندی به‌دست آمده از پاراگراف، طرح‌بندی یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی، به ‎[Text Formatting](/slides/fa/php-java/text-formatting/)‎ مراجعه کنید.

## **فیلدها و جای‌نماهای سرصفحه/پاورقی**

یک فیلد بخشی از یک بخش متنی است. یک جای‌نما شکل با نقش ارائه‌ای است، مانند پاورقی یا شماره اسلاید. افزودن فیلد به یک جعبه متن معمولی، آن شکل را به جای‌نما تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن جای‌نما و قابلیت نمایش آن را در اسلایدها، طرح‌بندی‌ها و مسترها، همراه با انتشار به اسلایدهای وابسته، کنترل می‌کنند. بنابراین یک فیلد شماره در جعبه متن سفارشی می‌تواند حتی زمانی که از جای‌نمای شماره اسلاید استفاده نمی‌کنید مفید باشد. برعکس، تغییر قابلیت مشاهده جای‌نما فیلدی را از جعبه متن نامرتبط حذف نمی‌کند.

انواع سرصفحه و پاورقی پیش‌تعریف‌شده، جای‌نماهای متناظر را ایجاد یا محتوا را فراهم نمی‌کنند. به‌ویژه یک اسلاید پاورپوینت عادی جای‌نمای سرصفحه ندارد؛ سرصفحه‌ها به صفحات یادداشت و برگه‌های توزیع تعلق دارند. فرض نکنید فیلد سرصفحه یا پاورقی در یک شکل دلخواه، متن پیکربندی‌شده از طریق مدیر جای‌نما را به‌طور خودکار دریافت می‌کند. برای این جریان کاری، ‎[Presentation Headers and Footers](/slides/fa/php-java/presentation-header-and-footer/)‎ را ببینید.

## **محدودیت‌های PPTX و PPT**

بعد از ذخیره و بازگشایی، هم نوع فیلد و هم متن حاصل آن را بررسی کنید. حفظ یک شناساگر، ثابت نمی‌کند برنامه می‌تواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار فیلد و محدودیت‌ها |
|---|---|
| PPTX | شناساگرهای فیلد داخلی همراه با متن فیلد ذخیره می‌شوند. در بررسی‌های دور کاری، انواع پیش‌تعریف‌شده و شناساگر سفارشی استفاده‌شده در مثال بالا پس از ذخیره و بازگشت پابرجا بودند. نوع سفارشی ناشناخته متن پیش‌فرض خود را حفظ کرد؛ منطق محاسبه خودکار اضافه نشد. برنامه دیگری ممکن است شناساگرهای پشتیبانی‌نشده را به شکل متفاوتی رفتار کند. |
| PPT | از نمایندگی‌های فیلد قدیمی استفاده می‌کند و سازگاری محدودتری دارد. در بررسی‌های دور کاری، فیلدهای شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازگشت حفظ شدند. یک فیلد سفارشی در جعبه متن اسلاید عادی پس از بازگشت شناساگر خود را داشت اما متن آن ‎`*`‎ بود؛ فیلد سرصفحه در همان زمینه نیز متن ‎`*`‎ تولید کرد. بر متن قابل مشاهده فیلدهای سفارشی یا زمینه‌های پشتیبانی‌نشده حساب نکنید. |

برای خروجی قابل حمل و ثابت، فیلدهای نامطمئن را به متن عادی تبدیل کنید و مقدار مورد نظر را پیش از ذخیره به‌صورت صریح اختصاص دهید. این کار متن انتخابی را حفظ می‌کند و به‌روزرسانی خودکار را متوقف می‌سازد. همچنین هنگام استفاده از برنامه هدف، اگر محاسبه فیلد بخشی از جریان کاری شماست، آن را نیز آزمایش کنید.

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم که عدد یا تاریخ نمایش داده‌شده فیلد است؟**

‏‎[Portion::getField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getField)‎ را بررسی کنید. مقدار غیر ‎`null`‎ یک فیلد را نشان می‌دهد؛ متن نمایش داده‌شده به تنهایی نمی‌تواند این را مشخص کند.

**آیا حذف فیلد متن یا قالب‌بندی آن را هم حذف می‌کند؟**

نه. ‎[removeField](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#removeField)‎ بخش موجود را به متن عادی تبدیل می‌کند. در صورتی که به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد آن متن را اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

نه. این رشته فقط نوع فیلد را شناسایی می‌کند. شناساگر ناشناخته ارزیاب یا الگوی قالب تاریخ ‎PHP‎ ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شده پشتیبانی‌شده استفاده کنید یا مقدار را به‌صورت متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی مجدداً ارائه را بررسی می‌کنیم؟**

شناساگرهای فیلد، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای هستند که باید تأیید شوند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی اگر شناساگر فیلد همچنان موجود باشد.