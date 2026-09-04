---
title: حماية العروض التقديمية بكلمة مرور في بايثون
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/python-net/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض التقديمي
- فحص كلمة مرور العرض التقديمي
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Python
- Aspose.Slides
description: "تشفير، كشف، التحقق، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور PowerPoint بصيغ PPT و PPTX في بايثون باستخدام Aspose.Slides."
---
## **نظرة عامة**

يُشفر كلمة مرور الفتح العرض التقديمي. يلزم إدخال كلمة المرور الصحيحة لتحميل وعرض محتوى العرض التقديمي، وبالتالي توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. تحصر الحماية من الكتابة التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [حماية العروض من الكتابة](/slides/ar/python-net/write-protected-presentation/).

تنطبق سير العمل أدناه على كلٍ من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوكهما القائم على الملفات أو التيارات مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور الفتح**

استخدم [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/encrypt/) لتعيين كلمة مرور الفتح. ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي المشفر.

المثال التالي يشفر عرض PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **إبقاء خصائص المستند عامة**

بشكلٍ افتراضي، تُضمّن Aspose.Slides خصائص المستند في تشفير العرض التقديمي. تتحكم الخاصية [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) في هذا السلوك بشكلٍ مستقل عن تشفير محتوى الشرائح. اضبطها على `False` قبل استدعاء [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/encrypt/) عندما يتوجب على نظام الفهرسة أو التصنيف أو البحث أو إدارة المستندات قراءة البيانات الوصفية دون كلمة مرور الفتح.

المثال التالي يُنشئ عرض PPTX مشفّر مع إبقاء خصائص المستند المدمجة عامة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

ضبط `encrypt_document_properties` على `False` لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر من العرض التقديمي عامًا. يؤثر ذلك فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [إدارة خصائص العرض التقديمي](/slides/ar/python-net/presentation-properties/).

## **تحميل عرض تقديمي مشفر**

عيّن [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل إذا كانت كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدَّمة مفقودة أو غير صحيحة.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # العمل مع العرض التقديمي المفكوك.
    pass
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض التقديمي باستخدام كلمة مرور الفتح، استدعِ [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/remove_encryption/)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من صحة كلمة مرور الفتح قبل التحميل**

استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض التقديمي. افحص [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/is_password_protected/) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم التحقق منها باستخدام [PresentationInfo.check_password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_password/).

### **سير عمل باستخدام مسار الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/)، ثم يقوم بتحميل العرض التقديمي بالكامل:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **سير عمل باستخدام تدفق**

الإصدار المتدفق من [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) يوفر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض التقديمي الكامل من ذلك التدفق.

المثال التالي يستخدم ملف PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **قيم الإرجاع لـ CheckPassword**

تعيد [PresentationInfo.check_password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_password/) القيمة `True` فقط عندما يحتوي العرض التقديمي على كلمة مرور الفتح وتكون كلمة المرور المقدَّمة صحيحة. تعيد `False` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض التقديمي لا يحتوي على كلمة مرور الفتح.
- كلمة المرور المقدَّمة هي `None` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض التقديمي المحمّل مشفّراً**

بعد تحميل عرض تقديمي باستخدام كلمة المرور الصحيحة، افحص [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/is_encrypted/) لتأكيد أن العرض الأصلي كان مشفّراً. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `PresentationInfo.is_password_protected` كما هو موضح أعلاه.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **توصيات أمان**

{{% alert color="warning" title="الأمان" %}}
لا تقوم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط للمدة اللازمة، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض التقديمي مباشرةً.

قد تكشف خصائص المستند العامة عن أسماء المؤلفين، والعناوين، والمواضيع، والكلمات المفتاحية، ومعلومات الشركة، والتعليقات، والقيم المخصَّصة رغم أن محتوى العرض التقديمي مشفر. قم بتشفير البيانات الوصفية الحساسة مع العرض التقديمي. يجب أن تكون إبقاء الخصائص عامة قراراً صريحاً يُتخذ فقط عندما يتوجب على الأنظمة فهرسة أو تصنيف أو البحث أو إدارة الملف دون كلمة مرور الفتح.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض.
1. اختيارياً، أدخل كلمة مرور منفصلة لحماية التحرير.
1. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض من الكتابة](/slides/ar/python-net/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من صحة كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض التقديمي، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وقم بالتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل يمكن لتطبيق قراءة البيانات الوصفية دون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما تم تشفير العرض مع ضبط `encrypt_document_properties` إلى `False`. يجب على التطبيق عندها استخدام وضع التحميل الخاص بخصائص المستند فقط كما هو موضح في [إدارة خصائص العرض التقديمي](/slides/ar/python-net/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كل من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها عبر مسار الملف أو التدفق يتصرف بنفس الطريقة لكل من عروض PPT و PPTX.