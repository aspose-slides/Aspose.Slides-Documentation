---
title: حماية العروض التقديمية بكلمة مرور في بايثون
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/python-net/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور افتتاحية
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Python
- Aspose.Slides
description: "تشفير، كشف، التحقق، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور بصيغة PowerPoint PPT و PPTX في بايثون باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة المرور الافتتاحية تشفر العرض التقديمي. يجب توفير كلمة المرور الصحيحة لتحميل وعرض محتوى العرض، وبالتالي توفر هذه الحماية السرية.

كلمة المرور الافتتاحية تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد تعديل العرض دون تشفير المحتوى أو منع تحميله. لإدارة كلمات المرور لتعديل العروض التقديمية، انظر [Write-Protect Presentations](/slides/ar/python-net/write-protected-presentation/).

تنطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوكهما القائم على الملفات أو التيارات مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور افتتاحية**

استخدم [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/encrypt/) لتعيين كلمة مرور افتتاحية. ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لحفظ العرض المشفر.

المثال التالي يشفر عرض PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تحميل عرض مشفر**

عيّن [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) إلى كلمة المرور الافتتاحية ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) عند تحميل الملف. يفشل التحميل عندما تكون كلمة المرور الافتتاحية مطلوبة لكن كلمة المرور المقدَّمة مفقودة أو غير صحيحة.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # العمل مع العرض المفكك تشفيره.
    pass
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مروره الافتتاحية، استدعِ [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/remove_encryption/)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ بدون كلمة مرور.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من كلمة المرور الافتتاحية قبل التحميل**

استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقّق من [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/is_password_protected/) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، قم بالتحقق من القيمة المقدَّمة باستخدام [PresentationInfo.check_password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_password/).

### **سير عمل مسار الملف**

المثال التالي يتحقق من كلمة مرور افتتاحية لملف PPTX، يمرّر القيمة التي تمّ التحقق منها إلى [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/)، ثم يحمل العرض الكامل:

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

### **سير عمل التيار**

توفير نسخة التيار من [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) يقدم نفس سير العمل. أعد ضبط موضع التيار القابل للبحث قبل تحميل العرض الكامل من ذلك التيار.

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

### **قيم إرجاع CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_password/) يعيد `True` فقط عندما يكون للعرض كلمة مرور افتتاحية ويكون كلمة المرور المقدَّمة صحيحة. يعيد `False` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور افتتاحية.
- كلمة المرور المقدَّمة هي `None` أو فارغة.

السلوك نفسه لعروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمَّل مشفرًا**

بعد تحميل عرض بكلمة مرور صحيحة، افحص [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/is_encrypted/) للتأكد من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة المرور الافتتاحية قبل التحميل، استخدم `PresentationInfo.is_password_protected` كما هو موضح أعلاه.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تُسجِّل كلمات المرور الافتتاحية أو تُدرجها في رسائل التشخيص. تجنَّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط للمدة اللازمة، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض مباشرةً.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
2. اختر أو حمّل العرض التقديمي.
3. أدخل كلمة مرور لحماية العرض.
4. اختياريًا أدخل كلمة مرور منفصلة لحماية التحرير.
5. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [حماية من الكتابة للعرض](/slides/ar/python-net/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة المرور الافتتاحية وكلمة مرور الحماية من الكتابة؟**

كلمة المرور الافتتاحية تشفر العرض وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة المرور الافتتاحية دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، تحقق ما إذا كانت حماية كلمة المرور الافتتاحية موجودة، وتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها على أساس مسار الملف أو التيار يعمل بنفس الطريقة لكل من عروض PPT و PPTX.