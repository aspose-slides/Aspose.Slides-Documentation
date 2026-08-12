---
title: مدیریت برچسب‌های حساسیت در ارائه‌های پاورپوینت با جاوا
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/java/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- نشانه‌گذاری محتوا
- محافظت اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- Java
- Aspose.Slides
description: "برچسب‌های حساسیت Microsoft Purview را در ارائه‌های PPTX پاورپوینت با Aspose.Slides برای جاوا بخوانید، اضافه کنید، به‌روزرسانی کنید، حذف کنید و منتقل کنید."
---
## **بررسی کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در هنگام پردازش خودکار ارائه، ممکن است یک برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده است اعمال کند، وضعیت آن را به‌روزرسانی کند یا متادیتای برچسب نوشته‌شده توسط یک گردش کاری قدیمی Microsoft Information Protection (MIP) را منتقل کند.

Aspose.Slides متادیتای برچسب حساسیت مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس قرار می‌دهد. این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به صورت PPTX، آن را بررسی و تغییر داد.

{{% alert color="primary" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا انتقال متادیتا، دسترسی برچسب و الزامات سیاست را در محیط خود اعتبارسنجی کنید. مقادیر [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) توصیف‌کننده نشانه‌های محتوایی مرتبط با یک برچسب هستند؛ خود به خود متن یا اشکال قابل‌مشاهده‌ای به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) شامل متادیتای زیر است:

| متدها | هدف |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | دریافت یا تعیین شناسه برچسب حساسیت در سیاست Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | دریافت یا تعیین سایتی که به سیاست برچسب مرتبط است. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | دریافت یا تعیین این که برچسب فعال است یا نه. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | دریافت یا تعیین این که برچسب حذف شده است. هنگام نیاز به نگهداری وضعیت حذف در متادیتا مقدار را به `true` تنظیم کنید. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | دریافت یا تعیین این که برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | دریافت انواع نشانه‌های محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) نحوه اختصاص برچسب را تعریف می‌کند:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده است، شامل برچسب‌های دستی، پیشنهادی و اجباری.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) نشانه‌گذاری مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای پاورقی با برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | نشانه‌گذاری محتوای واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | محافظت رمزنگاری با برچسب مرتبط است. |

چندین نوع نشانه می‌توانند به یک برچسب مرتبط باشند.

## **فهرست برچسب‌های حساسیت موجود**

مجمع برچسب‌های مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) بخوانید و آن را پیمایش کنید. مثال زیر هر ویژگی و نشانه محتوایی ذخیره‌شده برای هر برچسب را فهرست می‌کند:

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

## **افزودن برچسب حساسیت با نشانه‌گذاری محتوا**

از [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از بازگرداندن برچسب جدید [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/)، مقادیر نشانه‌گذاری مورد نیاز را از طریق فهرست برگردانده‌شده توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه کنید.

مثال زیر برچسبی که به‌صورت دستی انتخاب شده و با نشانه‌های پاورقی و واترمارک مرتبط است را اضافه می‌کند و سپس نتیجه را به صورت PPTX ذخیره می‌نماید:

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

مقادیر [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) قابل خواندن/نوشتن هستند، به‌جز اینکه فهرست برگردانده‌شده توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) از طریق عملیات فهرست آن تغییر می‌کند. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع نشانه‌گذاری محتوا را به‌روزرسانی کنید. ارائه را ذخیره کنید تا تغییرات ثابت شوند.

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

## **علامت‌گذاری یک برچسب حساسیت به عنوان حذف‌شده**

برای حفظ این واقعیت که برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) را با مقدار `true` فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف یک ورودی از مجموعه مدرن دارید، از [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) استفاده کنید؛ برای حذف همه ورودی‌ها از [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#clear--) بهره ببرید.

مثال زیر یک برچسب خاص را به‌عنوان حذف‌شده علامت‌گذاری کرده و ارائه به‌روز شده را ذخیره می‌کند:

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

## **خواندن و انتقال برچسب‌های حساسیت قدیمی MIP**

گردش‌کارهای مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به جای مجموعه برچسب مدرن ذخیره کنند. این متادیتا را با [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه می‌کند و آرایه‌ای از اشیاء [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای انتقال متادیتا، هر برچسب بازگردانده‌شده را از طریق [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) به [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/) مدرن اضافه کنید. از آنجا که افزودن شناسه برچسب تکراری منجر به استثنا می‌شود، مثال پیش از کپی هر برچسب مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری اضافه کنید تا تأیید شود هر برچسب قدیمی هنوز در سیاست Purview فعلی موجود است.

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

انتقال، اشیاء برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. نیازی به پاک‌سازی تمام ویژگی‌های سفارشی سند نیست، بنابراین متادیتای نامرتبط سند دست نخورده می‌ماند. برای نوشتن متادیتای برچسب مدرن به یک فایل PPTX از [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) استفاده کنید.

## **پرسش‌های متداول**

**آیا افزودن یک نوع نشانه‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل‌مشاهده در اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق فهرست برگردانده‌شده توسط [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه می‌شوند، نشانه‌های مرتبط با برچسب حساسیت را توصیف می‌کنند. آن‌ها متن یا اشکال قابل‌مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز به نمایش این نشانه‌ها دارد، محتوای اسلاید مربوطه را جداگانه اضافه کنید.

**فارق بین علامت‌گذاری برچسب به‌عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

فراخوانی [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) با `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با الزامات نگهداری متادیتای سازمان شما مطابقت داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای قدیمی MIP و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) استفاده کنید و تنها برچسب‌های معتبر که پیش از این در مجموعه مدرن وجود ندارند را منتقل کنید.

**وقتی یک برچسب با همان شناسه بیش از یک بار اضافه شود چه اتفاقی می‌افتد؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) هنگامیکه مجموعه قبلاً حاوی برچسبی با همان شناسه باشد، یک استثنا ایجاد می‌کند. پیش از افزودن یا انتقال برچسب‌ها، مقادیر موجود را که توسط [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getId--) برگردانده می‌شوند، بررسی کنید.

**برای حفظ برچسب‌های حساسیت به‌روز شده چه فرمت خروجی باید استفاده شود؟**

ارائه را به صورت PPTX ذخیره کنید با فراخوانی [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/)، همان‌طور که در مثال‌های فوق نشان داده شده است.