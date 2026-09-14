---
title: حماية العروض بكلمة مرور في بايثون
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/python-java/password-protected-presentation/
keywords:
- عرض محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض
- Python
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير العروض المحمية بكلمة مرور في PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لبايثون عبر Java."
---
## **نظرة عامة**

كلمة مرور الفتح تشفر عرضًا تقديميًا. كلمة المرور الصحيحة مطلوبة لتحميل وعرض محتوى العرض، لذا توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض. لإدارة كلمات المرور لتعديل العروض، راجع [حماية العروض من الكتابة](/slides/ar/python-java/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا التنسيقين حيث يكون سلوكهما القائم على الملفات أو البث مهمًا.

## **تشفير عرض باستخدام كلمة مرور الفتح**

استخدم [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#encrypt) لتعيين كلمة مرور الفتح. ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لحفظ العرض المشفر.

المثال التالي يشفر عرض PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اجعل خصائص المستند عامة**

بشكل افتراضي، تقوم Aspose.Slides بتضمين خصائص المستند في تشفير العرض. تتحكم الطريقة [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. مرّر `False` قبل استدعاء [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#encrypt) عندما يحتاج نظام الفهرسة أو التصنيف أو البحث أو إدارة المستندات إلى قراءة البيانات الوصفية دون كلمة مرور الفتح.

المثال التالي ينشئ عرض PPTX مشفر مع ترك خصائص المستند المدمجة عامة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تمرير `False` إلى [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر للعرض عامة. يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [إدارة خصائص العرض](/slides/ar/python-java/presentation-properties/).

## **تحميل عرض مشفر**

عيّن [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل إذا كانت كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # العمل مع العرض المفكوك تشفيره.
    pass
finally:
    presentation.dispose()
```

## **إزالة التشفير من عرض**

حمّل العرض باستخدام كلمة مرور الفتح، استدعِ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#removeEncryption)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحقق من كلمة مرور الفتح قبل التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#isPasswordProtected) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم تقديمها باستخدام [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#checkPassword).

### **سير عمل مسار الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword)، ثم يحمل العرض كاملًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **سير عمل البث**

الإصدار المتدفق من [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) يوفر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض الكامل من ذلك التدفق.

المثال التالي يستخدم ملف PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **قيم الإرجاع للدالة checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#checkPassword) تُعيد `True` فقط عندما يكون للعرض كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. تُعيد `False` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `None` أو فارغة.

السلوك نفسه للعرضين PPT و PPTX.

## **التحقق مما إذا كان عرض محمَّل مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، فحص [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isEncrypted) للتأكد من أن العرض الأصلي كان مشفرًا. للكشف عن حماية كلمة مرور الفتح قبل التحميل، استخدم [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#isPasswordProtected) كما هو موضح أعلاه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تقم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط للفترة المطلوبة، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض مباشرةً.

قد تكشف خصائص المستند العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة حتى وإن كان محتوى العرض مشفرًا. قم بتشفير البيانات الوصفية الحساسة مع العرض. يجب أن يكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما يتعين على الأنظمة فهرسة أو تصنيف أو البحث أو إدارة الملف دون كلمة مرور فتح.
{{% /alert %}}

## **حماية عرض بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
2. اختر أو حمّل العرض.
3. أدخل كلمة مرور لحماية العرض عند العرض.
4. اختياريًا، أدخل كلمة مرور منفصلة لحماية التعديل.
5. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [حماية العروض من الكتابة](/slides/ar/python-java/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، تحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل يمكن للتطبيق قراءة البيانات الوصفية دون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما يكون العرض مشفرًا مع تعطيل تشفير خصائص المستند. يجب على التطبيق حينها استعمال وضع التحميل الذي يقتصر على خصائص المستند كما هو موضح في [إدارة خصائص العرض](/slides/ar/python-java/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كلاً من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها بناءً على مسار الملف أو البث يعمل بنفس الطريقة لكلا العرضين PPT و PPTX.