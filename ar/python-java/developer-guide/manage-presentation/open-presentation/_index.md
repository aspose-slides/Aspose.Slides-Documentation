---
title: فتح العروض في Python عبر Java
linktitle: فتح العرض
type: docs
weight: 20
url: /ar/python-java/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في Python عبر Java، وتوفير كلمات مرور للفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides for Python via Java."
---
## **المقدمة**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ar/python-java/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات وتيارات البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالصيغة الأصلية أو بصيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/). على سبيل المثال، يمكنك تقديم كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمنة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار الملف إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). قم بتحرير العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد على الفور.

يظهر المثال التالي بلغة Python كيفية فتح عرض والحصول على عدد الشرائح:

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

## **فتح العروض المحمية بكلمة مرور**

كلمة المرور للفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للتعرف على كلمات المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/python-java/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة هذه الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/python-java/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) تُرجع خيارات تتحكم في كيفية معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفولًا، السماح بالملفات المؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

يُظهر الكود التالي بلغة Python كيفية تحميل عرض كبير (مثلاً 2 GB):

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

باستخدام [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفولًا حتى يتم تحرير كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يكون هذا الكائن حيًا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف أكثر كفاءة عمومًا من التدفق. راجع [Manage BLOBs](/slides/ar/python-java/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.

{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) تقبل وكيل JPype يُطبق واجهة استدعاء Java لتحميل الموارد. يمكن للاستدعاء توفير بيانات بديلة، إعادة توجيه مورد، استخدام المُحمّل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض دون الكائنات الثنائية المضمنة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا تحتاجها التطبيق أو لا يريد الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getVbaProject)؛
- بيانات OLE مدمجة، متاحة عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)؛
- بيانات التحكم ActiveX، متاحة عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ar/python-java/aspose.slides/control/#getActiveXControlBinary).

عيّن [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) إلى `True` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله لتثبيت النتيجة المُنقاة.

هذا الخيار يقلل من التعرض للحمولات المضمنة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الضارة أو تنقية المحتوى.

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

تقوم Aspose.Slides بإلقاء استثناء تحليل أو صيغة أثناء التحميل. تعامل مع هذا الفشل بشكل منفصل عن خطأ كلمة المرور الخاطئة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمَّل، لكن قد تستبدل الخطوط أثناء العرض أو التصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/python-java/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/python-java/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا الوسائط المضمنة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. تُحل الموارد الخارجية وفق سلوك تحميل الموارد المُكوَّن وقد لا تكون متاحة إذا تعذّر الوصول إلى مواقعها.