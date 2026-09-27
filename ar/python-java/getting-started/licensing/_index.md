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
- ترخيص مؤقت
- ترخيص بالعد
- قيود التقييم
description: "تطبيق ترخيص من ملف أو من بايتات أو ترخيص بالعد في Aspose.Slides للـ Python عبر Java وإزالة قيود التقييم من تطبيقاتك."
---
## **نظرة عامة**

يمكن تشغيل Aspose.Slides for Python via Java في وضع التقييم أو باستخدام ترخيص. في وضع التقييم، يضيف صندوق نص علامة مائية للتقييم إلى كل شريحة في كل عرض تقديمي يتم حفظه ويقص النص الذي يقرأه الكود من العروض التقديمية. تُوضح هذه المقالة كيفية تطبيق ترخيص من ملف أو من بايتات وكيفية تكوين الترخيص القائم على العد.

لخيارات الشراء، راجع [Pricing Information](https://purchase.aspose.com/pricing/slides/family). للأسئلة العامة حول الترخيص والشراء، راجع [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

للتعرف على قيود التقييم وكيفية طلب ترخيص مؤقت، راجع [Evaluate Aspose.Slides](/slides/ar/python-java/evaluate-aspose-slides/). يُطبق الترخيص المؤقت بنفس طريقة ملف الترخيص المشترى.

## **About the License**

يحتوي ملف الترخيص على معلومات مثل اسم المنتج، عدد المطورين المرخصين، وتاريخ انتهاء الاشتراك. الملف هو XML موقّع رقمياً.

{{% alert color="warning" title="Warning" %}}
لا تقم بتعديل ملف الترخيص. حتى سطر فارغ إضافي يمكن أن يُبطل التوقيع الرقمي.
{{% /alert %}}

طبّق الترخيص مرة واحدة لكل تطبيق أو عملية، قبل إنشاء العروض التقديمية أو تنفيذ عمليات Aspose.Slides أخرى. لاستخدام ملف الترخيص، استخدم الفئة [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/). يستخدم الترخيص القائم على العد زوج مفاتيح عام وخاص بدلًا من ملف الترخيص.

## **Apply a License**

الفئات التالية تفترض أن Aspose.Slides for Python via Java والمتطلبات المسبقة تم تثبيتها. كل مثال هو برنامج مستقل يبدأ JVM، يستورد الـ API، ويطبق الترخيص. في تطبيقك، نفّذ عمليات العرض التقديمي بعد تطبيق الترخيص وأغلق JVM فقط بعد الانتهاء من جميع أعمال Aspose.Slides.

### **Apply a License from a File**

مرّر مسار ملف الترخيص إلى [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense). استبدل `Aspose.Slides.lic` بالمسار إلى ملف الترخيص الخاص بك.

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
        # قم بأداء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

استخدم الاسم الكامل للملف، بما في ذلك الامتداد. على سبيل المثال، إذا كان الملف اسمه `Aspose.Slides.lic.xml`، أضف `.xml` إلى المسار. يضمن المسار المطلق عدم الغموض بشأن دليل العمل الخاص بالتطبيق.

يستخدم المثال [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed) للتحقق مما إذا تم تطبيق الترخيص.

### **Apply a License from Bytes**

استخدم [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes) عندما يكون الترخيص متوفرًا كـ Python bytes. يقرأ المثال التالي الملف في وضعية binary ويغلقه قبل تطبيق الترخيص.

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
        # قم بأداء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

احتفظ بالبايتات الأصلية دون تغيير. لا تقم بفك الترميز أو إعادة التنسيق أو تعديل محتوى الترخيص بأي طريقة قبل تطبيقه.

## **Apply a Metered License**

يقوم الترخيص القائم على العد بفوترة الاستخدام وفقًا لاستهلاك الـ API. بعد الحصول على ترخيص عد، طبّق المفاتيح العامة والخاصة باستخدام [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey). أنشئ كائن [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) وطبّق المفاتيح مرة واحدة عند بدء تشغيل التطبيق.

يقرأ المثال التالي المفاتيح من المتغيرين البيئيين `ASPOSE_METERED_PUBLIC_KEY` و `ASPOSE_METERED_PRIVATE_KEY`. اضبط المتغيرين قبل تشغيل البرنامج النصي.

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
        # قم بأداء عمليات العرض التقديمي هنا، قبل إغلاق JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
يتطلب الترخيص القائم على العد اتصالًا بالإنترنت للتحقق من المفاتيح وتقرير الاستخدام. احفظ المفتاح الخاص خارج الكود المصدري والسجلات. راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) للحصول على تفاصيل الاتصال والفوترة.
{{% /alert %}}

## **FAQ**

**هل أحتاج إلى تثبيت حزمة مختلفة بعد شراء الترخيص؟**

لا. طبّق الترخيص على نفس الحزمة التي استخدمتها في التقييم.

**هل يجب أن أطبّق ترخيصًا لكل عرض تقديمي؟**

لا. طبّق الترخيص مرة واحدة عند بدء تشغيل التطبيق، قبل إنشاء أو تحميل العروض التقديمية.

**هل يمكنني إعادة تسمية ملف الترخيص؟**

نعم. استخدم الاسم الجديد تمامًا في الكود واحفظ محتويات الملف كما هي.

**هل يمكنني استخدام ترخيص مؤقت مع المثال القائم على البايتات؟**

نعم. اقرأ ملف الترخيص المؤقت كـ بايتات وطبّقه بنفس طريقة الترخيص المشتري.