---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint با Java
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/java/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتا MIP
- علامت‌گذاری محتوا
- محافظت اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- Java
- Aspose.Slides
description: "برچسب‌های حساسیت Microsoft Purview را در ارائه‌های PowerPoint PPTX بخوانید، اضافه کنید، به‌روزرسانی کنید، حذف کنید و مهاجرت دهید با Aspose.Slides برای Java."
---
## **بررسی اجمالی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در طول پردازش خودکار ارائه، ممکن است یک برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده اعمال کند، وضعیت آن را به‌روزرسانی کند یا متادیتای برچسب نوشته‌شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides متادیتای برچسب حساسیت مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس قرار می‌دهد. این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به صورت PPTX، آن را بررسی و اصلاح کرد.

{{% alert color="info" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا مهاجرت متادیتا، در محیط خود دسترسی به برچسب و الزامات سیاست را اعتبارسنجی کنید. مقادیر [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) توصیف‌کننده علامت‌گذاری‌های محتوا مرتبط با یک برچسب هستند؛ آن‌ها به تنهایی متن یا شکل‌های قابل مشاهده‌ای بر روی اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) حاوی متادیتای‌های زیر است:

| متدها | هدف |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | دریافت یا تنظیم شناسه برچسب حساسیت در سیاست Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | دریافت یا تنظیم سایت مرتبط با سیاست برچسب. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | دریافت یا تنظیم اینکه آیا برچسب فعال است یا خیر. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | دریافت یا تنظیم اینکه آیا برچسب حذف شده است. مقدار را به `true` تنظیم کنید وقتی وضعیت حذف باید در متادیتا حفظ شود. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | دریافت یا تنظیم اینکه آیا برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | دریافت انواع علامت‌گذاری محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) تعریف می‌کند که یک برچسب چگونه اختصاص یافته است:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده، شامل برچسب‌های دستی، پیشنهادی و اجباری.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) تعریف می‌کند که علامت‌گذاری مرتبط با یک برچسب چیست:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای پانویس با برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sensitivitylabelcontenttype/) | محافظت رمزنگاری با برچسب مرتبط است. |

چندین نوع علامت‌گذاری می‌توانند با یک برچسب مرتبط باشند.

## **فهرست برچسب‌های حساسیت موجود**

متغیرهای برچسب مدرن را از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) بخوانید و آن را مرور کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

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

از [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از بازگشت متد، [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) جدید را دریافت می‌کنید؛ سپس مقادیر علامت‌گذاری مورد نیاز را از طریق فهرستی که [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) برمی‌گرداند، اضافه کنید.

مثال زیر برچسبی را که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پانویس و واترمارک مرتبط است، اضافه می‌کند و سپس نتیجه را به‌عنوان PPTX ذخیره می‌نماید:

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

مقادیر [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) قابل خواندن و نوشتن هستند، به‌جز اینکه فهرستی که [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) برمی‌گرداند، از طریق عملیات فهرست خود تغییر می‌یابد. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. برای تثبیت تغییرات، ارائه را ذخیره کنید.

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

## **علامت‌گذاری یک برچسب حساسیت به‌عنوان حذف شده**

برای حفظ این واقعیت که یک برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) را با مقدار `true` فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد در حالی که وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف یک ورودی از مجموعه مدرن دارید، از [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) استفاده کنید؛ برای حذف تمام ورودی‌ها از [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#clear--) بهره ببرید.

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

## **خواندن و مهاجرت برچسب‌های حساسیت قدیمی MIP**

جریان‌های کاری قدیمی مبتنی بر MIP می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به جای مجموعه برچسب مدرن ذخیره کنند. آن متادیتا را با [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیاء [ISensitivityLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/) برمی‌گرداند.

برای مهاجرت متادیتا، هر برچسب بازگردانده‌شده را از طریق [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) به مجموعه مدرن [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/) اضافه کنید. از آنجا که افزودن شناسه برچسب تکراری موجب استثنا می‌شود، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری اضافه کنید تا تأیید شود هر برچسب قدیمی هنوز در سیاست فعلی Purview موجود است.

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

مهاجرت اشیاء برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. این کار نیاز به پاک‌سازی تمام ویژگی‌های سفارشی سند ندارد، بنابراین متادیتای‌های غیرمرتبط سند دست‌نخورده می‌مانند. برای نوشتن متادیتای برچسب مدرن به یک فایل PPTX از [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) استفاده کنید.

## **سوالات متداول**

**آیا افزودن یک نوع علامت‌گذاری محتوا، سرصفحه، پانویس یا واترمارک قابل مشاهده‌ای روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق فهرست بازگشتی [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) اضافه می‌شوند، توصیف‌کننده علامت‌گذاری‌های مرتبط با برچسب حساسیت هستند. آن‌ها به تنهایی متن یا شکل‌های قابل مشاهده‌ای بر روی ارائه ایجاد نمی‌کنند. اگر جریان کاری شما نیاز به نمایش آن علامت‌گذاری‌ها دارد، محتویات اسلاید مربوطه را به‌صورت جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به‌عنوان حذف شده و حذف آن از مجموعه چیست؟**

فراخوانی [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) با مقدار `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. استفاده از [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی که متناسب با نیازهای نگهداری متادیتای سازمان شماست را انتخاب کنید.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را دربر گیرد؟**

بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) استفاده کنید و تنها برچسب‌های معتبر که هنوز در مجموعه مدرن وجود ندارند را مهاجرت کنید.

**چه اتفاقی می‌افتد وقتی برچسبی با همان شناسه بیش از یک بار اضافه شود؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) هنگام افزودن برچسبی که شناسه‌اش پیش از این در مجموعه وجود دارد، یک استثنا ایجاد می‌کند. پیش از افزودن یا مهاجرت برچسب‌ها، مقادیر موجود که توسط [ISensitivityLabel.getId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isensitivitylabel/#getId--) بازگردانده می‌شوند را بررسی کنید.

**کدام قالب خروجی باید برای حفظ برچسب‌های حساسیت به‌روزرسانی‌شده استفاده شود؟**

ارائه را به‌صورت PPTX ذخیره کنید با فراخوانی [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شد.