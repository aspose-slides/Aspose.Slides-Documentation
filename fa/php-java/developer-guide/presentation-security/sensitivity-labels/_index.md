---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint در PHP
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/php-java/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- نشانه‌گذاری محتوا
- حفاظت از اطلاعات
- حاکمیت اسناد
- PowerPoint
- PPTX
- امنیت ارائه
- PHP
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و مهاجرت برچسب‌های حساسیت Microsoft Purview در ارائه‌های PPTX PowerPoint با PHP."
---
## **بررسی کلی**

برچسب‌های حساسیت Microsoft Purview به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در پردازش خودکار ارائه‌ها، ممکن است یک برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسب انتخاب‌شده توسط سیاست را اعمال کند، وضعیت آن را به‌روزرسانی کند یا متادیتای برچسب نوشته‌شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides for PHP via Java متادیتای برچسب حساسیت مدرن را از طریق [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSensitivityLabels) در دسترس قرار می‌دهد. این متد یک [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به صورت PPTX آن را بررسی و تغییر داد.

{{% alert color="primary" title="یادداشت" %}}

شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. پیش از افزودن یا مهاجرت متادیتا، در محیط خود دسترسی به برچسب‌ها و الزامات سیاست را تأیید کنید. مقادیر [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) توصیف‌کنندهٔ نشانه‌گذاری‌های محتوا مرتبط با یک برچسب هستند؛ آن‌ها به تنهایی متن یا شکل‌های قابل مشاهده‌ای را به اسلایدها اضافه نمی‌کنند.

{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [SensitivityLabel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/) شامل متادیتای زیر است:

| روش‌ها | هدف |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getId) و [SensitivityLabel::setId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setId) | دریافت یا تنظیم شناسهٔ برچسب حساسیت در سیاست Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getSiteId) و [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setSiteId) | دریافت یا تنظیم سایت مرتبط با سیاست برچسب. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#isEnabled) و [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setEnabled) | دریافت یا تنظیم اینکه برچسب فعال باشد یا نه. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#isRemoved) و [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setRemoved) | دریافت یا تنظیم اینکه برچسب حذف شده باشد. مقدار `true` را زمانی که باید وضعیت حذف در متادیتا حفظ شود، تنظیم کنید. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) و [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | دریافت یا تنظیم اینکه برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | دریافت انواع نشانه‌گذاری‌های محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelassignmenttype/) نحوهٔ اختصاص برچسب را تعریف می‌کند:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده؛ شامل برچسب‌های دستی، پیشنهادی و اجباری می‌شود.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) نشانه‌گذاری مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنای آن |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای پاورق با برچسب مرتبط است. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcontenttype/) | محافظت رمزگذاری با برچسب مرتبط است. |

چندین نوع نشانه‌گذاری می‌توانند به یک برچسب مربوط شوند.

## **فهرست برچسب‌های حساسیت موجود**

متادیتای مجموعهٔ برچسب‌های مدرن را از طریق [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSensitivityLabels) بخوانید و آن را مرور کنید. مثال زیر هر خاصیت و نشانه‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **افزودن برچسب حساسیت با نشانه‌گذاری محتوا**

از [SensitivityLabelCollection::add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#add) همراه با شناسهٔ برچسب، شناسهٔ سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از بازگرداندن [SensitivityLabel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/) جدید، مقادیر نشانه‌گذاری مورد نیاز را از طریق لیست بازگردانده‌شده توسط [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) اضافه کنید.

مثال زیر برچسبی که به‌صورت دستی انتخاب‌شده و با نشانه‌گذاری‌های پاورق و واترمارک مرتبط است را اضافه می‌کند و سپس نتیجه را به صورت PPTX ذخیره می‌نماید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **به‌روزرسانی برچسب حساسیت**

مقادیر [SensitivityLabel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/) قابل خواندن/نوشتن هستند، به‌جز این‌که لیست بازگردانده‌شده توسط [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) از طریق عملیات لیستی آن اصلاح می‌شود. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسهٔ سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع نشانه‌گذاری محتوا را به‌روزرسانی کنید. برای حفظ تغییرات ارائه را ذخیره کنید.

مثال زیر وضعیت فعال بودن و روش اختصاص اولین برچسب را به‌روزرسانی می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **علامت زدهی برچسب حساسیت به‌عنوان حذف‌شده**

برای نگه‌داشتن این‌که یک برچسب حذف شده است، برچسب را پیدا کنید و با `true` متد [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setRemoved) را فراخوانی کنید. این کار ورودی برچسب را حفظ می‌کند در حالی که وضعیت حذف آن را ثبت می‌نماید. اگر به‌جای آن نیاز به حذف یک ورودی از مجموعهٔ مدرن دارید، از [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) استفاده کنید؛ برای حذف تمام ورودی‌ها از [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#clear) استفاده کنید.

مثال زیر یک برچسب خاص را به‌عنوان حذف‌شده علامت‌گذاری می‌کند و ارائه به‌روزشده را ذخیره می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **خواندن و مهاجرت برچسب‌های حساسیت قدیمی MIP**

جریان‌های کاری مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به جای مجموعهٔ برچسب مدرن ذخیره کنند. این متادیتا را با [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getSensitivityLabels) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیای [SensitivityLabel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/) در جاوا برمی‌گرداند.

برای مهاجرت متادیتا، هر برچسب بازگردانده‌شده را از طریق [SensitivityLabelCollection::add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#add) به [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/) مدرن اضافه کنید. چون افزودن شناسهٔ برچسب تکراری یک استثنا ایجاد می‌کند، مثال قبل از کپی هر برچسب مجموعۀ مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری اضافه کنید تا تأیید شود هر برچسب قدیمی هنوز در سیاست فعلی Purview موجود است.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مهاجرت اشیای برچسب تجزیه‌شده را به مجموعهٔ مدرن کپی می‌کند. نیازی به پاک کردن همهٔ ویژگی‌های سفارشی سند نیست، بنابراین متادیتای غیرمرتبط سند دست نخورده می‌ماند. برای نوشتن متادیتای برچسب مدرن به یک فایل PPTX از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) استفاده کنید.

## **FAQ**

**آیا افزودن یک نوع نشانه‌گذاری محتوا یک سرصفحه، پاورق یا واترمارک قابل مشاهده روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق لیست بازگردانده‌شده توسط [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) اضافه می‌شوند، نشانه‌گذاری‌های مرتبط با برچسب حساسیت را توصیف می‌کنند. آن‌ها متن یا شکل‌های قابل مشاهده‌ای را در ارائه ایجاد نمی‌کنند. اگر جریان کاری شما نیاز به نمایش این نشانه‌گذاری‌ها داشته باشد، محتویات اسلاید مربوطه را جداگانه اضافه کنید.

**تفاوت علامت زدهی یک برچسب به‌عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

فراخوانی [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#setRemoved) با `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) ورودی را از مجموعهٔ مدرن حذف می‌کند. عملیاتی که با الزامات نگهداری متادیتای سازمان شما همخوانی دارد را انتخاب کنید.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSensitivityLabels) در دسترس هستند. برای خواندن متادیتای قدیمی از [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getSensitivityLabels) استفاده کنید و فقط برچسب‌های معتبری را که قبلاً در مجموعهٔ مدرن وجود ندارند، مهاجرت کنید.

**چه اتفاقی می‌افتد وقتی یک برچسب با همان شناسه بیش از یک بار افزوده شود؟**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabelcollection/#add) هنگامیکه مجموعه از قبل حاوی برچسبی با همان شناسه باشد، یک استثنا ایجاد می‌کند. قبل از افزودن یا مهاجرت برچسب‌ها، مقادیر موجود را با استفاده از [SensitivityLabel::getId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sensitivitylabel/#getId) بررسی کنید.

**کدام فرمت خروجی باید برای حفظ برچسب‌های حساسیت به‌روز شده استفاده شود؟**

ارائه را همانند مثال‌های بالا با فراخوانی [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) به صورت PPTX ذخیره کنید.