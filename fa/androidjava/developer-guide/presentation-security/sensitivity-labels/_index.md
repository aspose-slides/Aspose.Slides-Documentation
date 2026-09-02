---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint در Android
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
- محافظت از اطلاعات
- حاکمیت اسناد
- PowerPoint
- PPTX
- امنیت ارائه
- Android
- Java
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و مهاجرت برچسب‌های حساسیت Microsoft Purview در ارائه‌های PowerPoint PPTX با Aspose.Slides برای Android از طریق Java."
---
## **مروری**

Microsoft Purview حساسیت برچسب‌ها به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در طول پردازش خودکار ارائه، ممکن است برنامه‌ای نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط سیاست انتخاب شده است اعمال کند، وضعیت آن را به‌روز‌رسانی کند یا متادیتای برچسب نوشته‌شده توسط یک جریان کاری قدیمی‌تر Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides for Android via Java متادیتای برچسب حساسیت مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس قرار می‌دهد. این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به‌عنوان PPTX، آن را بررسی و تغییر داد.

{{% alert color="primary" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شود. پیش از افزودن یا مهاجرت متادیتا، در محیط خود در دسترس بودن برچسب و الزامات سیاست را اعتبارسنجی کنید. مقادیر [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ویژگی‌های محتوا مرتبط با برچسب را توصیف می‌کند؛ این مقادیر به‌تنهایی متن یا شکل قابل مشاهده‌ای به اسلایدها اضافه نمی‌کند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) متادیتای زیر را شامل می‌شود:

| متدها | هدف |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | دریافت یا تنظیم شناسه برچسب حساسیت در سیاست Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | دریافت یا تنظیم سایت مرتبط با سیاست برچسب. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | دریافت یا تنظیم این که برچسب فعال باشد. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | دریافت یا تنظیم این که برچسب حذف شده باشد. مقدار را به `true` تنظیم کنید زمانی که وضعیت حذف باید در متادیتا حفظ شود. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | دریافت یا تنظیم این که برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | دریافت انواع علامت‌گذاری محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نحوه اختصاص برچسب را تعریف می‌کند:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال شده.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده، شامل برچسب‌های دستی، پیشنهادی و اجباری.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) علامت‌گذاری مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در پاورقی با برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا به‌صورت واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | محافظت رمزنگاری با برچسب مرتبط است. |

چندین نوع علامت‌گذاری می‌تواند به یک برچسب مرتبط باشد.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) بخوانید و آن را شمارش کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

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

## **افزودن برچسب حساسیت با علامت‌گذاری محتوا**

از [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از اینکه متد برچسب جدید [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) را برگرداند، مقادیر علامت‌گذاری مورد نیاز را از طریق فهرست برگشتی [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه کنید.

مثال زیر برچسبی که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پاورقی و واترمارک مرتبط است را اضافه می‌کند، سپس نتیجه را به‌عنوان PPTX ذخیره می‌کند:

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

مقادیر [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) قابل خواندن/نوشتن هستند، به‌جز اینکه فهرست برگشتی توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) از طریق عملیات فهرست خود اصلاح می‌شود. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. برای حفظ تغییرات، ارائه را ذخیره کنید.

مثال زیر وضعیت فعال بودن و روش اختصاص برچسب اول را به‌روزرسانی می‌کند:

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

## **علامت‌گذاری برچسب حساسیت به‌عنوان حذف شده**

برای حفظ اینکه یک برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) را با `true` فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف یک ورودی از مجموعه مدرن دارید، از [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) استفاده کنید؛ برای حذف همه ورودی‌ها از [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) بهره ببرید.

مثال زیر یک برچسب خاص را به‌عنوان حذف شده علامت‌گذاری می‌کند و ارائه به‌روز شده را ذخیره می‌نماید:

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

## **خواندن و مهاجرت برچسب‌های حساسیت MIP قدیمی**

جریان‌های کاری قدیمی مبتنی بر MIP می‌توانند متادیتای برچسب حساسیت را در خصوصیات سند سفارشی به جای مجموعه برچسب مدرن ذخیره کنند. این متادیتا را با [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) بخوانید. این متد خصوصیات سفارشی قدیمی را تجزیه کرده و یک آرایه از اشیاء [ISensitivityLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای مهاجرت متادیتا، هر برچسب برگشتی را به [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/) مدرن از طریق [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) اضافه کنید. از آنجا که افزودن شناسه برچسب تکراری استثنا ایجاد می‌کند، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری اضافه کنید تا تأیید شود هر برچسب قدیمی همچنان در سیاست Purview فعلی وجود دارد.

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

مهاجرت اشیاء برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. این کار نیاز به پاک‌سازی تمام خصوصیات سفارشی سند ندارد، بنابراین متادیتای غیرمرتبط سند دست نخورده می‌ماند. برای نوشتن متادیتای برچسب مدرن به فایل PPTX، از [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) استفاده کنید.

## **سؤالات متداول**

**آیا افزودن یک نوع علامت‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل مشاهده بر روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیر اضافه‌شده از طریق فهرست برگشتی [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ویژگی‌های محتوا مرتبط با برچسب حساسیت را توصیف می‌کنند. آنها متن یا شکل قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز دارد این علامت‌گذاری‌ها را رندر کند، محتوا را به‌صورت جداگانه به اسلاید اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به‌عنوان حذف شده و حذف آن از مجموعه چه می‌باشد؟**

فراخوانی [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) با `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را که با نیازهای حفظ متادیتای سازمان شما مطابقت دارد انتخاب کنید.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در خصوصیات سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) استفاده کنید و فقط برچسب‌های معتبر را که هنوز در مجموعه مدرن وجود ندارند، مهاجرت کنید.

**چه اتفاقی می‌افتد زمانی که یک برچسب با همان شناسه بیش از یک بار اضافه شود؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) وقتی مجموعه از قبل شامل برچسبی با همان شناسه باشد، استثنا ایجاد می‌کند. قبل از افزودن یا مهاجرت برچسب‌ها، مقادیر موجود را با استفاده از [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isensitivitylabel/#getId--) بررسی کنید.

**کدام قالب خروجی باید برای حفظ برچسب‌های حساسیت به‌روزرسانی‌شده استفاده شود؟**

ارائه را به‌عنوان PPTX ذخیره کنید با فراخوانی [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شد.