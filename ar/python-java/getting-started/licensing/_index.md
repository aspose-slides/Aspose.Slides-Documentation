---
title: الترخيص
type: docs
weight: 80
url: /ar/python-java/licensing/
keywords:
- Aspose.Slides
- بايثون
- جافا
- ملف الترخيص
- رخصة مؤقتة
- ترخيص قائم على الاستخدام
- قيود التقييم
description: "قم بتطبيق رخصة من ملف أو رخصة تعتمد على البايتات أو رخصة قائمة على الاستخدام في Aspose.Slides for Python via Java وأزل قيود التقييم من تطبيقاتك."
---
## **نظرة عامة**

يمكن تشغيل Aspose.Slides for Python via Java في وضع التقييم أو باستخدام رخصة. يوضح هذا المقال كيفية تطبيق رخصة من ملف أو من بايتات وكيفية تكوين الترخيص القائم على الاستخدام.

لخيارات الشراء، راجع [معلومات التسعير](https://purchase.aspose.com/pricing/slides/ar/family). للأسئلة العامة حول الترخيص والشراء، راجع [سياسات الشراء والأسئلة المتكررة](https://purchase.aspose.com/policies).

لحدود التقييم وكيفية طلب رخصة مؤقتة، راجع [تقييم Aspose.Slides](/slides/ar/python-java/evaluate-aspose-slides/). طبّق رخصة مؤقتة بنفس الطريقة التي تُطبّق بها رخصة مشتراة من ملف.

{{% alert color="warning" title="Warning" %}}
لا تقم بتحرير ملف الرخصة. حتى وجود سطر فارغ إضافي يمكن أن يبطل توقيعه الرقمي.
{{% /alert %}}

طبّق الرخصة مرة واحدة لكل تطبيق أو عملية، قبل إنشاء العروض التقديمية أو تنفيذ عمليات Aspose.Slides أخرى. لاستخدام ملف رخصة، استخدم الفئة [License](https://reference.aspose.com/slides/ar/python-java/aspose.slides/license/). الترخيص القائم على الاستخدام يستخدم زوج مفاتيح عام وخاص بدلاً من ملف رخصة.

## **حول الرخصة**

ملف الرخصة يحتوي على معلومات مثل اسم المنتج، عدد المطورين المرخصين، وتاريخ انتهاء الاشتراك. الملف هو XML موقّع رقمياً.

## **تطبيق رخصة**

تُفترض الأمثلة التالية أن Aspose.Slides for Python via Java ومتطلباته مثبتة. كل مثال هو برنامج مستقل يبدأ JVM، يستورد الواجهة البرمجية، ويطبّق رخصة. في تطبيقك، نفّذ عمليات العرض بعد تطبيق الرخصة وأغلق JVM فقط بعد اكتمال جميع أعمال Aspose.Slides.

### **تطبيق رخصة من ملف**

مرّر مسار ملف الرخصة إلى [License.setLicense](https://reference.aspose.com/slides/ar/python-java/aspose.slides/license/#setLicense). استبدل `Aspose.Slides.lic` بمسار ملف رخصتك.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # إجراء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

استخدم الاسم الدقيق للملف، بما في ذلك الامتداد. على سبيل المثال، إذا كان اسم الملف `Aspose.Slides.lic.xml`، أدرج `.xml` في المسار. استخدام مسار مطلق يجنب الالتباس حول دليل العمل الخاص بالتطبيق.

يستخدم المثال [License.isLicensed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/license/#isLicensed) للتحقق مما إذا تم تطبيق الرخصة.

### **تطبيق رخصة من بايتات**

استخدم [License.setLicenseFromBytes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/license/#setLicenseFromBytes) عندما تكون الرخصة متاحة كبايتات بايثون. يقرأ المثال التالي الملف في وضع ثنائي ويغلقه قبل تطبيق الرخصة.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # إجراء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

احتفظ بالبايتات الأصلية دون تغيير. لا تقم بفك التشفير أو إعادة التنسيق أو تعديل محتوى الرخصة بأي شكل قبل تطبيقها.

## **تطبيق رخصة قائمة على الاستخدام**

الترخيص القائم على الاستخدام يفرض رسومًا وفقًا لاستخدام الواجهة البرمجية. بعد الحصول على رخصة قائمة على الاستخدام، طبّق مفاتيحه العامة والخاصة باستخدام [Metered.setMeteredKey](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/#setMeteredKey). أنشئ كائن [Metered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/) وطبّق المفاتيح مرة واحدة عند بدء تشغيل التطبيق.

يقرأ المثال التالي المفاتيح من متغيرات البيئة `ASPOSE_METERED_PUBLIC_KEY` و `ASPOSE_METERED_PRIVATE_KEY`. اضبط كلا المتغيرين قبل تشغيل البرنامج النصي.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # إجراء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
يتطلب الترخيص القائم على الاستخدام اتصال إنترنت للتحقق من المفاتيح وتقرير الاستخدام. احفظ المفتاح الخاص خارج الشيفرة المصدرية والسجلات. راجع [الأسئلة المتكررة حول الترخيص القائم على الاستخدام](https://purchase.aspose.com/faqs/licensing/metered) لتفاصيل الاتصال والفوترة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يلزم تثبيت حزمة مختلفة بعد شراء رخصة؟**

لا. طبّق الرخصة على نفس الحزمة التي استخدمتها في التقييم.

**هل يجب تطبيق رخصة لكل عرض تقديمي؟**

لا. طبّقها مرة واحدة عند بدء تشغيل التطبيق، قبل إنشاء أو تحميل العروض التقديمية.

**هل يمكن إعادة تسمية ملف الرخصة؟**

نعم. استخدم الاسم الجديد الدقيق للملف في الشيفرة واحفظ محتويات الملف دون تعديل.

**هل يمكن استخدام رخصة مؤقتة مع المثال القائم على البايتات؟**

نعم. اقرأ ملف الرخصة المؤقتة كبايتات وطبّقه بنفس طريقة رخصة الشراء.