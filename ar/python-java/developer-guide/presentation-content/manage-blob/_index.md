---
title: إدارة كائنات BLOB للعرض التقديمي في Python عبر Java لتحسين استخدام الذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ Python عبر Java لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية فعّالة."
---
## **نظرة عامة**

توفر Aspose.Slides معالجة قائمة على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند العمل مع صور، صوت، فيديو وملفات عروض تقديمية كبيرة.

توضح هذه المقالة كيفية استخدام المعالجة القائمة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بشكل أكثر كفاءة. كما تشرح كيف يمكن استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادة عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يتم حفظه بصيغ ثنائية.

يتيح Aspose.Slides for Python via Java إمكانية استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert color="info" title="Note" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض وبالتالي بطء التحميل. لذا، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

يتيح [Aspose.Slides](/slides/ar/python-java/) for Python via Java إمكانية إضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تتضمن BLOB لتقليل استهلاك الذاكرة.

يعرض هذا الكود بلغة Python كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

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
            # احتفظ بتأمين التدفق لأنه لا نعتزم الوصول إلى ملف الفيديو.
            video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
            presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

            # احفظ العرض التقديمي مع الحفاظ على انخفاض استهلاك الذاكرة.
            presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
يتيح Aspose.Slides for Python via Java إمكانية تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تتضمن BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميل الملف إلى ذاكرة الكمبيوتر. من خلال تصدير الملف عبر عملية BLOB، تظل استهلاك الذاكرة منخفضًا.

يوضح هذا الكود بلغة Python العملية المذكورة:

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
باستخدام الأساليب من فئة [ImageCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/)، يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

يعرض هذا الكود بلغة Python كيفية إضافة صورة كبيرة عبر عملية BLOB:

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
        # احتفظ بتأمين التدفق لأننا لا ننوي الوصول إلى ملف الصورة.
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

عادةً، لتحميل عرض تقديمي كبير، يحتاج الكمبيوتر إلى الكثير من الذاكرة المؤقتة. يُحمل كل محتوى العرض في الذاكرة ويتوقف استخدام الملف المصدر.

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود بلغة Python:

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

لكن هذه الطريقة تستهلك نحو 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود بلغة Python التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، ينشئ الكمبيوتر ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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
عند استخدام [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath)، لا تقوم Aspose.Slides بإنشاء المجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **تحرير كائنات العرض لإطلاق الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من التخلص بشكل صحيح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) حتى تُفرغ الذاكرة التي كان يشغلها. استدعِ [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose) بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

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

## **الأسئلة المتكررة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُدار بواسطة خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. كما أن ملف العرض بالكامل يتضمن معالجة BLOB عند تحميله أو حفظه. تُدار هذه الكائنات بواسطة سياسات BLOB التي تسمح لك بالتحكم في استخدام الذاكرة وتفريغها إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط الحد الأقصى للذاكرة للكائنات BLOB، السماح أو منع الملفات المؤقتة، اختيار المسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد السرعة لكنه يرفع استهلاك ال RAM؛ خفض الحد الأقصى للذاكرة يرفع الاعتماد على الملفات المؤقتة، مما يقلل ال RAM لكنه يزيد عمليات الإدخال/الإخراج. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) للوصول إلى التوازن المناسب لعملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثل عدة جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقللان بشكل كبير من استهلاك ال RAM القصوى ويستقران عملية المعالجة لعروض تقديمية ضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق القواعد نفسها على التدفقات: يمكن لكائن العرض امتلاك القفل على تدفق الإدخال (اعتمادًا على وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة قابلًا للتنبؤ أثناء المعالجة.