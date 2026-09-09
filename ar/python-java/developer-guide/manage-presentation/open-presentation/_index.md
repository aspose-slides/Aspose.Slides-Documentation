---
title: فتح العروض التقديمية في Python عبر Java
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/python-java/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في Python عبر Java، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides للغة Python عبر Java."
---
## **مقدمة**

يمكن لـ [Aspose.Slides للغة Python عبر Java](https://products.aspose.com/slides/ar/python-java/) تحميل عروض PowerPoint وOpenDocument من الملفات والتيارات. بعد تحميل العرض التقديمي، يمكنك فحص هيكله، تحرير الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو أي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمنة.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى المُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). حرّر العرض التقديمي بعد الاستخدام حتى يتم تحرير مقابض الملفات والبيانات المؤقتة وغيرها من الموارد على الفور.

يظهر المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح:

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

كلمة مرور الفتح تشفر محتوى العرض التقديمي. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للتعرف على كلمة المرور، والتحقق، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/python-java/password-protected-presentation/). إذا تم حفظ عرض تقديمي مشفر مع خصائص المستند العامة عمدًا، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/python-java/presentation-properties/).

## **فتح العروض التقديمية الكبيرة**

تُعيد [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) خيارات تتحكم في كيفية تعامل Aspose.Slides مع الكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بملفات مؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

يظهر الكود التالي بلغة Python كيفية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):

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
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلًا حتى يتم تحرير كائن العرض التقديمي. لا تقم بنقل، أو استبدال، أو حذف ملف المصدر أثناء بقاء هذا الكائن حيا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عمومًا أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/python-java/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

تقبل [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) وكيل JPype ينفذ واجهة رد الاتصال لتحميل الموارد في Java. يمكن لرد الاتصال توفير بيانات بديلة، إعادة توجيه المورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما يحتوي العرض التقديمي على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

يمكن أن يحتوي عرض تقديمي على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. أمثلة على ذلك:

- مشاريع VBA، يمكن الوصول إليها عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getVbaProject);
- بيانات OLE مدمجة، يمكن الوصول إليها عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- بيانات عناصر التحكم ActiveX، يمكن الوصول إليها عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ar/python-java/aspose.slides/control/#getActiveXControlBinary).

اضبط [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) على `True` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

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

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً أثناء التحليل أو التنسيق عند التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض التقديمي أن يظل يحمل، لكن قد يستبدل العرض والتصدير الخطوط. يمكنك [إعداد استبدال الخطوط](/slides/ar/python-java/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/python-java/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل تحميل العرض التقديمي يحمل أيضًا الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض التقديمي. يتم حل الموارد الخارجية وفقًا لسلوك تحميل الموارد المكوّن وقد تكون غير متاحة إذا لم يمكن الوصول إلى مواقعها.