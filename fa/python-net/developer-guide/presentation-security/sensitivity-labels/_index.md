---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint با Python
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "برچسب‌های حساسیت Microsoft Purview را در ارائه‌های PPTX PowerPoint با استفاده از Aspose.Slides برای Python از طریق .NET بخوانید، اضافه کنید، به‌روزرسانی کنید، حذف کنید و مهاجرت دهید."
---
## **بررسی کلی**

برچسب‌های حساسیت Microsoft Purview به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. هنگام پردازش خودکار ارائه، یک برنامه ممکن است نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده است اعمال کند، وضعیت آن را به‌روز کند یا متادیتای برچسب نوشته‌شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides for Python via .NET متادیتای برچسب حساسیت مدرن را از طریق [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sensitivity_labels/) در دسترس می‌گذارد. این ویژگی یک [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/) باز می‌گرداند که می‌توان قبل از ذخیره ارائه به‌عنوان PPTX آن را بررسی و اصلاح کرد.

{{% alert color="primary" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا مهاجرت متادیتا، در محیط خود در دسترس بودن برچسب و الزامات سیاست را تأیید کنید. مقادیر [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/content_mark_types/) نشانه‌های محتوایی مرتبط با یک برچسب را توصیف می‌کنند؛ خودشان متن یا شکل قابل مشاهده‌ای به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [SensitivityLabel](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/) شامل متادیتای زیر است:

| خاصیت | هدف |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/id/) | شناسه برچسب حساسیت در سیاست Purview را شناسایی می‌کند. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/site_id/) | سایت مرتبط با سیاست برچسب را شناسایی می‌کند. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/is_enabled/) | نشان می‌دهد آیا برچسب فعال است یا نه. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/is_removed/) | نشان می‌دهد برچسب حذف شده است. هنگام نیاز به حفظ وضعیت حذف در متادیتا، این خاصیت را به `True` تنظیم کنید. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | مشخص می‌کند برچسب به‌صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | انواع نشانه‌های محتوایی مرتبط با برچسب را فهرست می‌کند. |

نماد [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelassignmenttype/) نحوه اختصاص برچسب را توصیف می‌کند:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده است.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر، از جمله برچسب‌های دستی، پیشنهادی و الزامی، اعمال شده.

نماد [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) نشانگر نشانه مرتبط با برچسب است:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) | نشانه محتوای سرصفحه با برچسب مرتبط است. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) | نشانه محتوای پاورقی با برچسب مرتبط است. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) | نشانه محتوای واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcontenttype/) | حفاظت رمزنگاری با برچسب مرتبط است. |

چندین نوع نشانه می‌توانند با یک برچسب مرتبط باشند.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sensitivity_labels/) بخوانید و آن را پیمایش کنید. مثال زیر هر خاصیت و نشانه محتوایی ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **افزودن برچسب حساسیت با نشانه محتوایی**

از [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/add/) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش تخصیص استفاده کنید. شناسه سایت را به عنوان شیء `uuid.UUID` پایتون ارسال کنید. پس از بازگرداندن [SensitivityLabel](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/) جدید، مقادیر نشانه مورد نیاز را به [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/content_mark_types/) اضافه کنید.

مثال زیر برچسبی انتخاب‌شده به‌صورت دستی که با نشانه‌های پاورقی و واترمارک مرتبط است اضافه می‌کند و سپس نتیجه را به‌عنوان PPTX ذخیره می‌نماید:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی برچسب حساسیت**

ویژگی‌های [SensitivityLabel](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/) قابل خواندن و نوشتن هستند، به‌استثنای فهرستی که توسط [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/content_mark_types/) بازگردانده می‌شود و از طریق عملیات فهرست آن اصلاح می‌گردد. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش تخصیص، وضعیت حذف و انواع نشانه‌های محتوا را به‌روزرسانی کنید. ارائه را ذخیره کنید تا تغییرات حفظ شوند.

مثال زیر وضعیت فعال بودن و روش تخصیص اولین برچسب را به‌روز می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **نشانه‌گذاری برچسب حساسیت به‌عنوان حذف شده**

برای حفظ این واقعیت که یک برچسب حذف شده است، برچسب را پیدا کنید و [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/is_removed/) را به `True` تنظیم کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف شده آن را ثبت می‌کند. اگر به‌جای آن می‌خواهید ورودی را از مجموعه مدرن حذف کنید، از [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) استفاده کنید؛ برای حذف تمام ورودی‌ها از [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/clear/) بهره بگیرید.

مثال زیر برچسب خاصی را به‌عنوان حذف شده علامت‌گذاری کرده و ارائه به‌روزشده را ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **خواندن و مهاجرت برچسب‌های حساسیت قدیمی MIP**

جریان‌های کاری مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به‌جای مجموعه مدرن برچسب‌ها ذخیره کنند. آن متادیتا را با [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه کرده و اشیاء [SensitivityLabel](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/) را باز می‌گرداند.

برای مهاجرت متادیتا، هر برچسب برگشتی را به [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/) مدرن از طریق [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/add/) اضافه کنید. از آنجا که افزودن شناسه برچسب تکراری باعث استثنا می‌شود، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری برای تأیید وجود هر برچسب قدیمی در سیاست فعلی Purview اضافه کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

مهاجرت اشیاء برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. این کار نیازی به پاک‌سازی تمام ویژگی‌های سفارشی سند ندارد، بنابراین متادیتای غیرمرتبط سند دست نخورده می‌ماند. از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) همراه با [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) برای نوشتن متادیتای برچسب مدرن به فایل PPTX استفاده کنید.

## **سؤالات متداول**

**آیا افزودن نوع نشانه محتوا یک سرصفحه، پاورقی یا واترمارک قابل دید در اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/content_mark_types/) اضافه می‌شوند، نشانه‌های مرتبط با برچسب حساسیت را توصیف می‌کنند. آنها متن یا شکل قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر جریان کاری شما نیاز به نمایش این نشانه‌ها دارد، محتواهای اسلاید مربوطه را جداگانه اضافه کنید.

**تفاوت علامت‌گذاری برچسب به‌عنوان حذف شده و حذف آن از مجموعه چیست؟**

تنظیم [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/is_removed/) به `True` ورودی برچسب را نگه می‌دارد و وضعیت حذف شده آن را ثبت می‌کند. فراخوانی [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) ورودی را از مجموعه مدرن حذف می‌نماید. عملیاتی را انتخاب کنید که با نیازهای نگهداری متادیتای سازمان شما هم‌خوانی داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sensitivity_labels/) در دسترس هستند. از [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) برای خواندن متادیتای قدیمی و مهاجرت فقط برچسب‌های معتبر که هنوز در مجموعه مدرن حضور ندارند، استفاده کنید.

**چه اتفاقی می‌افتد وقتی برچسبی با همان شناسه بیش از یک بار اضافه شود؟**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabelcollection/add/) هنگام وجود قبلی برچسبی با همان شناسه، استثنا می‌اندازد. پیش از افزودن یا مهاجرت برچسب‌ها، مقادیر [SensitivityLabel.id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sensitivitylabel/id/) موجود را بررسی کنید.

**کدام قالب خروجی باید برای حفظ برچسب‌های حساسیت به‌روز شده استفاده شود؟**

با فراخوانی [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) به همراه [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/)، ارائه را به‌عنوان PPTX ذخیره کنید، همان‌طور که در مثال‌های بالا نشان داده شده است.