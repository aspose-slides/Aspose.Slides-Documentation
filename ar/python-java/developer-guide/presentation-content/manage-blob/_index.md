---
title: إدارة كائنات BLOB للعرض التقديمي في Python عبر Java لاستخدام فعال للذاكرة
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/python-java/manage-blob/
keywords:
- كائن كبير
- عنصر كبير
- ملف كبير
- إضافة BLOB
- تصدير BLOB
- إضافة صورة كـ BLOB
- تقليل الذاكرة
- استهلاك الذاكرة
- عرض تقديمي كبير
- ملف مؤقت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides لـ Python عبر Java لتسهيل عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عرض تقديمي فعّالة."
---
## **نظرة عامة**

توفر Aspose.Slides معالجة مستندات BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند العمل مع الصور الكبيرة، والصوت، والفيديو، وملفات العروض التقديمية.

توضح هذه المقالة كيفية استخدام المعالجة المستندة إلى BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بصورة أكثر كفاءة. كما تشرح كيف يمكن استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول الـ BLOB**

الـ **BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) محفوظ بتنسيقات ثنائية.

تتيح Aspose.Slides for Python via Java لك استخدام الـ BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert color="info" title="Note" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض وبالتالي يتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.
{{% /alert %}}

## **استخدام الـ BLOBs لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير إلى عرض تقديمي باستخدام الـ BLOBs**

[Aspose.Slides](/slides/ar/python-java/) for Python via Java تتيح لك إضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تستخدم الـ BLOBs لتقليل استهلاك الذاكرة.

يعرض هذا الكود بايثون كيفية إضافة ملف فيديو كبير عبر عملية الـ BLOB إلى عرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # احتفظ بتقفل التدفق لأننا لا ننوي الوصول إلى ملف الفيديو.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # احفظ العرض التقديمي مع الحفاظ على انخفاض استهلاك الذاكرة.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **تصدير ملف كبير من عرض تقديمي باستخدام الـ BLOBs**
تتيح Aspose.Slides for Python via Java لك تصدير ملفات كبيرة (في هذه الحالة ملف صوت أو فيديو) عبر عملية تستخدم الـ BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميله إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية الـ BLOB، تحافظ على انخفاض استهلاك الذاكرة.

هذا الكود بايثون يوضح العملية الموصوفة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# قفل ملف المصدر بدلاً من تحميله إلى الذاكرة.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # نقل بيانات الفيديو عبر مخزن مؤقت للحفاظ على انخفاض استهلاك الذاكرة.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # استخدم التدفق بدلاً من تحميل الفيديو بالكامل إلى مصفوفة بايت.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # إذا لزم الأمر، طبق نفس الخطوات على ملفات الصوت.
finally:
    presentation.dispose()
```

### **إضافة صورة كـ BLOB إلى عرض تقديمي**
باستخدام أساليب الفئة [ImageCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/) يمكنك إضافة صورة كبيرة كتيار بحيث تُعامل كـ BLOB.

يعرض هذا الكود بايثون كيفية إضافة صورة كبيرة عبر عملية الـ BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# إنشاء عرض تقديمي جديد سيتم إضافة الصورة إليه.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # احتفظ بتقفل التدفق لأننا لا ننوي الوصول إلى ملف الصورة.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # احفظ العرض التقديمي مع الحفاظ على انخفاض استهلاك الذاكرة.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

اعتبر عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود بايثون:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

باستخدام معالجة الـ BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يوضح هذا الكود بايثون كيفية استخدام معالجة الـ BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية الـ BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت تريد حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
عند استخدام [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath)، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب إنشاء المجلد يدويًا.
{{% /alert %}}

### **التخلص من كائنات العرض لإطلاق الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من التخلص بشكل صحيح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) حتى يتم تحرير الذاكرة التي كان يشغلها. استدعِ [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose) بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...معالجة العرض التقديمي...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # تحرير الموارد بشكل صريح.
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات الـ BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، والصوت، والفيديو تُعامل كـ BLOBs. كما يتضمن ملف العرض الكامل معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تتيح لك إدارة استخدام الذاكرة والتفريغ إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة الـ BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة للـ BLOBs، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات الـ BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء الـ BLOBs في الذاكرة يزيد السرعة لكنه يرفع استهلاك RAM؛ تخفيض الحد يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM لكن يزيد I/O. استخدم الطريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) لتحقيق التوازن المناسب لحمل العمل والبيئة.

**هل تساعد خيارات الـ BLOB عند فتح عروض تقديمية ضخمة جدًا (مثل عدة جيجابايت)؟**

نعم. صُممت [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/) لمثل هذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من ذروة استهلاك RAM ويستقر المعالجة لعروض تقديمية ضخمة جداً.

**هل يمكنني استخدام سياسات الـ BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق القواعد ذاتها على التدفقات: يمكن لكائن العرض امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.