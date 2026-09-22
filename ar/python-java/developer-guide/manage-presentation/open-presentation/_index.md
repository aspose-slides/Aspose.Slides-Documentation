---
title: "فتح العروض التقديمية في بايثون عبر جافا"
linktitle: "فتح عرض تقديمي"
type: docs
weight: 20
url: /ar/python-java/open-presentation/
keywords:
- "فتح PowerPoint"
- "فتح عرض تقديمي"
- "فتح PPTX"
- "فتح PPT"
- "فتح ODP"
- "تحميل عرض تقديمي"
- "تحميل PPTX"
- "تحميل PPT"
- "تحميل ODP"
- "عرض تقديمي محمي"
- "عرض تقديمي كبير"
- "مورد خارجي"
- "كائن ثنائي"
- "Python"
- "Java"
- "Aspose.Slides"
description: "تعلم كيفية فتح عروض PowerPoint و OpenDocument في بايثون عبر جافا، توفير كلمات مرور للفتح، التحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **المقدمة**

يمكن لـ Aspose.Slides for Python via Java تحميل عروض PowerPoint و OpenDocument من الملفات و التدفقات. بعد تحميل العرض التقديمي، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بتنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر فئة LoadOptions. على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة كومة Java، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض التقديمي الأصلي](/slides/ar/python-java/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك له.

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى مُنشئ Presentation. حرّر العرض التقديمي بعد الاستخدام حتى يتم تحرير مقابض الملفات والبيانات المؤقتة وغيرها من الموارد بسرعة.

المثال التالي بلغة Python يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض التقديمي. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى LoadOptions.setPassword وقدم الخيارات إلى مُنشئ Presentation. سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

لتقنيات اكتشاف كلمة المرور، والتحقق، وتشفير، راجع Password-Protect Presentations. إذا تم حفظ عرض تقديمي مشفر مع خصائص مستند عامة عن عمد، يمكن قراءة تلك الخصائص دون كلمة مرور؛ راجع Manage Presentation Properties.

## **فتح العروض التقديمية الكبيرة**

تعيد LoadOptions.getBlobManagementOptions خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بالملفات المؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

الكود التالي بلغة Python يوضح تحميل عرض تقديمي كبير (مثال، 2 جيجابايت):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يظل ملف المصدر مقفلًا حتى يتم تحرير مثيل العرض التقديمي. لا تقم بنقل ملف المصدر أو استبداله أو حذفه بينما يكون هذا المثيل قيد الاستخدام.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عمومًا أكثر كفاءة من التدفق. انظر Manage BLOBs للحصول على خيارات إضافية للتخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

تقبل LoadOptions.setResourceLoadingCallback وكيل JPype يُنفّذ واجهة استرجاع الموارد في Java. يمكن للردود تقديم بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

قد يحتوي العرض التقديمي على بيانات ثنائية مدمجة لا تحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة من خلال Presentation.getVbaProject;
- بيانات OLE المدمجة، متاحة من خلال OleEmbeddedDataInfo.getEmbeddedFileData;
- بيانات التحكم ActiveX، متاحة من خلال Control.getActiveXControlBinary.

قم بتعيين LoadOptions.setDeleteEmbeddedBinaryObjects إلى `True` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض التقديمي المحمّل لتثبيت النتيجة المُنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، ولكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تقوم Aspose.Slides بإلقاء استثناء تحليل أو تنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض التقديمي أن يظل يُحمّل، لكن قد تستبدل الخطوط أثناء العرض أو التصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/python-java/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/python-java/custom-font/) لجعل الناتج أكثر قابلية للتنبؤ.

**هل يؤدي تحميل عرض تقديمي إلى تحميل الوسائط المدمجة أيضًا؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض التقديمي. تُحل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوّن وقد تكون غير متاحة إذا لم يمكن الوصول إلى مواقعها.