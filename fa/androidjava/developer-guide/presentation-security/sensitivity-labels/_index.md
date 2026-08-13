---
title: مدیریت برچسب‌های حساسیت در ارائه‌های پاورپوینت در اندروید
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/androidjava/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- علامت‌گذاری محتوا
- حفاظت از اطلاعات
- حاکمیت اسناد
- PowerPoint
- PPTX
- امنیت ارائه
- Android
- Java
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و مهاجرت برچسب‌های حساسیت Microsoft Purview در ارائه‌های PowerPoint با فرمت PPTX با استفاده از Aspose.Slides برای Android از طریق Java."
---
## **بررسی کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در هنگام پردازش خودکار ارائه، ممکن است برنامه‌ای نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده را اعمال کند، وضعیت آن را به‌روز کند یا متادیتای برچسب نوشته‌شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides for Android via Java متادیتای مدرن برچسب حساسیت را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) ارائه می‌دهد. این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/) برمی‌گرداند که می‌توان پیش از ذخیره ارائه به‌عنوان PPTX، آن را بررسی و تغییر داد.

{{% alert color="info" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا مهاجرت متادیتا، در محیط خود موجودیت برچسب و الزامات سیاست را اعتبارسنجی کنید. مقادیر [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) توصیف کنندهٔ علامت‌های محتوا مرتبط با یک برچسب هستند؛ آن‌ها به تنهایی متن یا شکل قابل رویت به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) شامل متادیتای زیر است:

| متدها | هدف |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | دریافت یا تنظیم شناسهٔ برچسب حساسیت در سیاست Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | دریافت یا تنظیم سایت مرتبط با سیاست برچسب. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | دریافت یا تنظیم اینکه برچسب فعال باشد یا نه. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | دریافت یا تنظیم اینکه برچسب حذف شده است یا نه. مقدار را به `true` تنظیم کنید وقتی باید وضعیت حذف در متادیتا حفظ شود. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | دریافت یا تنظیم اینکه برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده باشد. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | دریافت انواع علامت‌های محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نحوهٔ اختصاص برچسب را تعریف می‌کند:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نشان‌دهندهٔ برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نشان‌دهندهٔ برچسبی است که از طریق تصمیم کاربر، شامل برچسب‌های دستی، پیشنهادی و اجباری، اعمال شده.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) علامت مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت محتوا برای سرصفحه با این برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت محتوا برای پاورقی با این برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت محتوا برای واترمارک با این برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | حفاظت رمزنگاری با این برچسب مرتبط است. |

چندین نوع علامت می‌توانند به یک برچسب اختصاص یابند.

## **فهرست برچسب‌های حساسیت موجود**

متادیتای مجموعهٔ مدرن را از [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) بخوانید و آن را پیمایش کنید. مثال زیر هر ویژگی و علامت محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **افزودن برچسب حساسیت با علامت محتوا**

از [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) همراه با شناسهٔ برچسب، شناسهٔ سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از بازگشت متد، برچسب جدید [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) دریافت می‌شود؛ سپس مقادیر علامت مورد نیاز را از طریق لیست برگشتی توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه کنید.

مثال زیر برچسبی که به‌صورت دستی انتخاب شده و شامل علامت‌های پاورقی و واترمارک است، اضافه می‌کند و سپس نتیجه را به‌عنوان PPTX ذخیره می‌نماید:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **به‌روزرسانی برچسب حساسیت**

مقدارهای [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) قابل خواندن/نوشتن هستند، به‌جز این‌که لیست برگشتی توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) از طریق عملیات لیستی خود تغییر می‌کند. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسهٔ سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع علامت محتوا را به‌روز کنید. سپس ارائه را ذخیره کنید تا تغییرات ثابت شوند.

مثال زیر وضعیت فعال بودن و روش اختصاص اولین برچسب را به‌روزرسانی می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **علامت‌گذاری برچسب حساسیت به عنوان حذف‌شده**

برای حفظ این واقعیت که برچسب حذف شده است، برچسب را پیدا کنید و با `true` متد [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) را فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن می‌خواهید ورودی را از مجموعهٔ مدرن حذف کنید، از [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) استفاده کنید؛ برای حذف تمام ورودی‌ها می‌توانید از [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) بهره بگیرید.

مثال زیر یک برچسب خاص را به‌عنوان حذف‌شده علامت‌گذاری و ارائه به‌روز شده را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خواندن و مهاجرت برچسب‌های حساسیت قدیمی MIP**

رویه‌های مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در خصوصیات سفارشی سند به‌جای مجموعهٔ مدرن ذخیره کنند. این متادیتا را با [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) بخوانید. این متد خصوصیات سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیای [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) برمی‌گرداند.

برای مهاجرت متادیتا، هر برچسب بازگشتی را به مجموعهٔ مدرن [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/) از طریق [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) اضافه کنید. چون افزودن یک شناسه برچسب تکراری استثنا ایجاد می‌کند، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری برای تأیید وجود هر برچسب قدیمی در سیاست جاری Purview اضافه کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مهاجرت اشیای برچسب تجزیه‌شده را به مجموعهٔ مدرن کپی می‌کند. این کار نیازی به پاک کردن تمام خصوصیات سفارشی سند نیست، بنابراین متادیتای غیر مرتبط سند دست نخورده می‌ماند. از [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) برای نوشتن متادیتای برچسب‌های مدرن به یک فایل PPTX استفاده کنید.

## **سوالات متداول**

**آیا افزودن یک نوع علامت محتوا، سرصفحه، پاورقی یا واترمارک قابل مشاهده‌ای روی اسلایدها ایجاد می‌کند؟**

نه. مقادیری که از طریق لیست برگشتی توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه می‌شوند، توصیف‌کنندهٔ علامت‌های مرتبط با برچسب حساسیت هستند. آن‌ها متن یا شکل قابل رؤیت در ارائه ایجاد نمی‌کنند. اگر جریان کاری شما نیاز به رندر آن علامت‌ها دارد، محتوی مربوط به اسلاید را به‌صورت جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

فراخوانی [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) با `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) ورودی را از مجموعهٔ مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با نیازهای نگهداری متادیتای سازمان شما سازگار باشد.

**آیا یک ارائه می‌تواند هم متادیتای قدیمی MIP و هم برچسب‌های حساسیت مدرن را در خود داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در خصوصیات سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) استفاده کنید و فقط برچسب‌های معتبر که هنوز در مجموعهٔ مدرن وجود ندارند را مهاجرت کنید.

**زمانی که برچسبی با همان شناسه بیش از یک بار اضافه شود چه اتفاقی می‌افتد؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) هنگامیکه مجموعه قبلاً برچسبی با همان شناسه داشته باشد، استثنا پرتاب می‌کند. قبل از افزودن یا مهاجرت برچسب‌ها، مقادیر موجود را که توسط [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getId--) برگردانده می‌شوند، بررسی کنید.

**برای حفظ برچسب‌های حساسیت به‌روز شده چه قالب خروجی باید استفاده شود؟**

ارائه را به‌صورت PPTX ذخیره کنید با فراخوانی [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شده است.