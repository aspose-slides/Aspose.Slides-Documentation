---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint با JavaScript
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/nodejs-java/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- علامت‌گذاری محتوا
- حفاظت از اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و انتقال برچسب‌های حساسیت Microsoft Purview در ارائه‌های PowerPoint PPTX با Aspose.Slides برای Node.js از طریق Java."
---
## **مرور کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در حین پردازش خودکار ارائه، ممکن است برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده است اعمال کند، وضعیت آن را به‌روز کند یا متادیتای برچسب نوشته‌شده توسط یک گردش کار قدیمی Microsoft Information Protection (MIP) را انتقال دهد.

Aspose.Slides for Node.js via Java متادیتای برچسب حساسیت مدرن را از طریق [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) ارائه می‌دهد. این متد یک [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/) برمی‌گرداند که می‌توان قبل از ذخیره ارائه به‌صورت PPTX آن را بررسی و اصلاح کرد.

{{% alert color="primary" title="نکته" %}}

شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا انتقال متادیتا، در محیط خود در دسترس بودن برچسب و الزامات سیاست را اعتبارسنجی کنید. مقادیر [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) توصیف‌کنندهٔ علامت‌گذاری‌های محتوایی مرتبط با یک برچسب هستند؛ خود به خود متن یا اشکالی قابل مشاهده در اسلایدها اضافه نمی‌کنند.

{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [SensitivityLabel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/) شامل متادیتای زیر است:

| روش‌ها | هدف |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getId) و [SensitivityLabel.setId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setId) | دریافت یا تنظیم شناسهٔ برچسب حساسیت در سیاست Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) و [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | دریافت یا تنظیم سایتی که با سیاست برچسب مرتبط است. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) و [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | دریافت یا تنظیم این‌که آیا برچسب فعال است یا خیر. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) و [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | دریافت یا تنظیم این‌که آیا برچسب حذف شده است یا خیر. مقدار را به `true` تنظیم کنید وقتی که وضعیت حذف باید در متادیتا نگهداری شود. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) و [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | دریافت یا تنظیم این‌که برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | دریافت انواع علامت‌گذاری محتوایی مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) نحوهٔ اختصاص برچسب را تعریف می‌کند:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر یک برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده، شامل برچسب‌های دستی، پیشنهادی و اجباری.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) نوع علامت‌گذاری مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در پاورقی با برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا به‌صورت واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | حفاظت با رمزنگاری به برچسب مرتبط است. |

چندین نوع علامت‌گذاری می‌تواند به یک برچسب وابسته باشد.

## **لیست برچسب‌های حساسیت موجود**

متادیتای برچسب‌های مدرن را از طریق [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) بخوانید و آن را پیمایش کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **افزودن برچسب حساسیت با علامت‌گذاری محتوا**

از [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) با شناسه برچسب، شناسه سایت، وضعیت فعال و روش اختصاص استفاده کنید. پس از بازگشت متد، برچسب جدید [SensitivityLabel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/) را دریافت کنید و مقادیر علامت‌گذاری مورد نیاز را از طریق لیست بازگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) اضافه کنید.

مثال زیر برچسبی که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پاورقی و واترمارک مرتبط است را اضافه می‌کند و سپس نتیجه را به‌صورت PPTX ذخیره می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **به‌روزرسانی برچسب حساسیت**

مقادیر [SensitivityLabel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/) قابلیت خواندن/نوشتن دارند، به‌جز اینکه لیست بازگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) از طریق عملیات لیستی خود اصلاح می‌شود. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. ارائه را ذخیره کنید تا تغییرات اعمال شوند.

مثال زیر وضعیت فعال و روش اختصاص برچسب اول را به‌روزرسانی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **علامت‌گذاری برچسب حساسیت به عنوان حذف‌شده**

برای حفظ این‌که یک برچسب حذف شده است، برچسب را پیدا کنید و با `true` به [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد در حالی که وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن می‌خواهید ورودی را از مجموعه مدرن حذف کنید، از [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) استفاده کنید؛ برای حذف همه ورودی‌ها از [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) بهره‌برید.

مثال زیر برچسب خاصی را به‌عنوان حذف‌شده علامت‌گذاری کرده و ارائه به‌روز شده را ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خواندن و انتقال برچسب‌های حساسیت میراثی MIP**

گردش‌های کاری مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در خواص سفارشی سند به جای مجموعه برچسب مدرن ذخیره کنند. این متادیتا را با [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) بخوانید. این متد خواص سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیاء [SensitivityLabel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/) برمی‌گرداند.

برای انتقال متادیتا، هر برچسب برگشت‌خورده را از طریق [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) به [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/) مدرن اضافه کنید. چون افزودن شناسهٔ برچسب تکراری یک استثنا ایجاد می‌کند، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری اضافه کنید تا تأیید شود هر برچسب میراثی هنوز در سیاست Purview فعلی وجود دارد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

انتقال، اشیاء برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. نیازی به پاک‌کردن تمام خواص سفارشی سند نیست، بنابراین متادیتای غیرمرتبط سند دست نخورده می‌ماند. برای نوشتن متادیتای برچسب مدرن به فایل PPTX از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) استفاده کنید.

## **سوالات متداول**

**آیا افزودن یک نوع علامت‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل مشاهده بر روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق لیست بازگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) افزوده می‌شوند، توصیف‌کنندهٔ علامت‌گذاری‌های مرتبط با برچسب حساسیت هستند. آن‌ها متن یا اشکال قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز به رندر آن علامت‌گذاری‌ها دارد، محتویات اسلاید مربوطه را به‌صورت جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

فراخوانی [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) با `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با الزامات نگهداری متادیتای سازمان شما مطابقت داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای میراثی MIP و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های میراثی می‌توانند در خواص سفارشی سند باقی بمانند، در حالی که برچسب‌های مدرن از طریق [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) در دسترس هستند. از [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) برای خواندن متادیتای میراثی و انتقال تنها برچسب‌های معتبر که هنوز در مجموعهٔ مدرن موجود نیستند، استفاده کنید.

**چه اتفاقی می‌افتد وقتی یک برچسب با همان شناسه بیش از یک‌بار افزوده شود؟**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) هنگامیکه مجموعه قبلاً شامل برچسبی با همان شناسه باشد، استثنا ایجاد می‌کند. پیش از افزودن یا انتقال برچسب‌ها، مقادیر موجود بازگردانده‌شده توسط [SensitivityLabel.getId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sensitivitylabel/#getId) را بررسی کنید.

**کدام فرمت خروجی باید برای حفظ برچسب‌های حساسیت به‌روز شده استفاده شود؟**

ارائه را به‌صورت PPTX ذخیره کنید با فراخوانی [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/)، همان‌طور که در مثال‌های فوق نشان داده شده است.