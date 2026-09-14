---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint با Python
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/python-java/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- علامت‌گذاری محتوا
- حفاظت اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- Python
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و انتقال برچسب‌های حساسیت Microsoft Purview در ارائه‌های PowerPoint PPTX با Aspose.Slides برای Python از طریق Java."
---
## **مروری کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در طول پردازش خودکار ارائه، ممکن است برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی را که توسط یک سیاست انتخاب شده اعمال کند، وضعیت آن را به‌روز کند یا داده‌های متادیتای برچسب نوشته‌شده توسط یک گردش کار قدیمی Microsoft Information Protection (MIP) را منتقل کند.

Aspose.Slides متادیتای مدرن برچسب‌های حساسیت را از طریق [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSensitivityLabels) در دسترس قرار می‌دهد. این متد یک [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/) را برمی‌گرداند که می‌توان آن را قبل از ذخیره ارائه به صورت PPTX بررسی و اصلاح کرد.

{{% alert color="info" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. قبل از افزودن یا انتقال متادیتا، در محیط خود موجودیت برچسب و الزامات سیاست را اعتبارسنجی کنید. مقادیر [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) انواع علامت‌گذاری محتوا مرتبط با برچسب را توصیف می‌کنند؛ آن‌ها به تنهایی متن یا شکل قابل مشاهده‌ای به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [SensitivityLabel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/) شامل متادیتای زیر است:

| متدها | هدف |
| --- | --- |
| [getId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getId) و [setId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setId) | دریافت یا تنظیم شناسه برچسب حساسیت در سیاست Purview. |
| [getSiteId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getSiteId) و [setSiteId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setSiteId) | دریافت یا تنظیم سایتی که با سیاست برچسب مرتبط است. |
| [isEnabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#isEnabled) و [setEnabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setEnabled) | دریافت یا تنظیم اینکه آیا برچسب فعال است یا خیر. |
| [isRemoved](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#isRemoved) و [setRemoved](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setRemoved) | دریافت یا تنظیم اینکه آیا برچسب حذف شده است. هنگام نیاز به حفظ وضعیت حذف در متادیتا، مقدار را به `True` تنظیم کنید. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) و [setAssignmentMethodType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | دریافت یا تنظیم اینکه آیا برچسب به صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [getContentMarkTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | دریافت انواع علامت‌گذاری محتوا مرتبط با برچسب. |

کلاس [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelassignmenttype/) نحوه اختصاص برچسب را تعریف می‌کند:

- [Standard](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسب پیش‌فرض یا به‌صورت خودکار اعمال شده است.
- [Privileged](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده است، شامل برچسب‌های دستی، پیشنهادی و اجباری.

کلاس [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) علامت‌گذاری مرتبط با برچسب را تعریف می‌کند:

| مقدار | معنا |
| --- | --- |
| [None](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [Header](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای سرصفحه با این برچسب مرتبط است. |
| [Footer](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای پاورقی با این برچسب مرتبط است. |
| [Watermark](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای واترمارک با این برچسب مرتبط است. |
| [Encryption](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcontenttype/) | حفاظت رمزنگاری با این برچسب مرتبط است. |

چند نوع علامت‌گذاری می‌توانند با یک برچسب مرتبط شوند.

## **لیست برچسب‌های حساسیت موجود**

کلکسیون مدرن برچسب‌ها را با استفاده از [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSensitivityLabels) بخوانید و آن را مرور کنید. مثال زیر تمام ویژگی‌ها و علامت‌گذاری‌های محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **افزودن برچسب حساسیت با علامت‌گذاری محتوا**

از [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#add) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال و روش تخصیص استفاده کنید. پس از اینکه این متد شیء [SensitivityLabel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/) جدید را برگرداند، مقادیر علامت‌گذاری مورد نیاز را از طریق لیست برگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) اضافه کنید.

مثال زیر برچسبی را که به‌صورت دستی انتخاب شده و مرتبط با علامت‌گذاری‌های پاورقی و واترمارک است، اضافه می‌کند و سپس نتیجه را به صورت PPTX ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **به‌روزرسانی برچسب حساسیت**

مقادیر [SensitivityLabel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/) قابل خواندن/نوشتن هستند، به‌جز اینکه لیست برگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) از طریق عملیات لیست آن اصلاح می‌شود. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال، روش تخصیص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روز کنید. برای حفظ تغییرات، ارائه را ذخیره کنید.

مثال زیر وضعیت فعال و روش تخصیص اولین برچسب را به‌روز می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **علامت‌گذاری برچسب حساسیت به‌عنوان حذف شده**

برای حفظ این که برچسب حذف شده است، برچسب را پیدا کنید و با مقدار `True` متد [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setRemoved) را فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف یک ورودی از کلکسیون مدرن دارید، از [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) استفاده کنید؛ برای حذف همه ورودی‌ها از [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#clear) بهره ببرید.

مثال زیر برچسب خاصی را به‌عنوان حذف شده علامت‌گذاری می‌کند و ارائه به‌روزرسانی‌شده را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **خواندن و انتقال برچسب‌های حساسیت ارثی MIP**

گردش‌کارهای مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به جای کلکسیون مدرن برچسب ذخیره کنند. این متادیتا را با [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getSensitivityLabels) بخوانید. این متد ویژگی‌های سفارشی ارثی را تجزیه کرده و یک آرایه از اشیای [SensitivityLabel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/) برمی‌گرداند.

برای انتقال متادیتا، هر برچسب بازگردانده‌شده را از طریق [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#add) به [SensitivityLabelCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/) مدرن اضافه کنید. چون اضافه‌کردن شناسه برچسب تکراری منجر به رخداد استثناء می‌شود، مثال قبل از کپی هر برچسب، کلکسیون مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری اضافه کنید تا تأیید شود هر برچسب ارثی هنوز در سیاست جاری Purview وجود دارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

انتقال، اشیای برچسب تجزیه‌شده را به کلکسیون مدرن کپی می‌کند. این کار نیازی به پاک‌سازی تمام ویژگی‌های سفارشی سند ندارد، بنابراین متادیتای غیرمرتبط سند دست‌نخورده باقی می‌ماند. برای نوشتن متادیتای برچسب مدرن به یک فایل PPTX از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) استفاده کنید.

## **FAQ**

**آیا افزودن نوع علامت‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل مشاهده بر روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق لیست برگردانده‌شده توسط [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) اضافه می‌شوند، انواع علامت‌گذاری مرتبط با برچسب حساسیت را توصیف می‌کنند. آن‌ها متن یا شکل قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز به نمایش این علامت‌گذاری‌ها دارد، محتوای اسلاید مربوطه را جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به‌عنوان حذف شده و حذف آن از کلکسیون چیست؟**

فراخوانی [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#setRemoved) با مقدار `True` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) ورودی را از کلکسیون مدرن حذف می‌نماید. عملیاتی را انتخاب کنید که با نیازهای نگهداری متادیتای سازمان شما سازگار باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP ارثی و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های ارثی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند، در حالی که برچسب‌های مدرن از طریق [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSensitivityLabels) در دسترس هستند. برای خواندن متادیتای ارثی از [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getSensitivityLabels) استفاده کنید و فقط برچسب‌های معتبر که هنوز در کلکسیون مدرن وجود ندارند، انتقال دهید.

**چه اتفاقی می‌افتد وقتی یک برچسب با همان شناسه بیش از یک‌بار اضافه شود؟**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabelcollection/#add) هنگامی که کلکسیون از قبل شامل برچسبی با همان شناسه باشد، استثنایی پرتاب می‌کند. قبل از افزودن یا انتقال برچسب‌ها، مقادیر موجود بازگردانده‌شده توسط [SensitivityLabel.getId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sensitivitylabel/#getId) را بررسی کنید.

**کدام فرمت خروجی باید برای حفظ برچسب‌های حساسیت به‌روز شده استفاده شود؟**

برای حفظ برچسب‌های حساسیت به‌روز شده، ارائه را به صورت PPTX ذخیره کنید؛ با فراخوانی [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شده است.