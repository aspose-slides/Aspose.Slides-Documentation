---
title: إدارة OLE في العروض باستخدام Python
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/python-java/manage-ole/
keywords:
- كائن OLE
- ربط وتضمين الكائنات
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- إضافة ملف
- تضمين ملف
- كائن مرتبط
- ملف مرتبط
- تغيير OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض
- Python
- Java
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides for Python via Java. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert color="info" title="ملاحظة" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر عبر الربط أو التضمين.

{{% /alert %}}

تخيل مخططًا تم إنشاؤه في MS Excel. ثم يتم وضعه داخل شريحة PowerPoint. يعتبر هذا المخطط في Excel كائن OLE.

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يطلب منك اختيار تطبيق لفتح أو تحرير الكائن.
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى المخطط. في هذه الحالة، يتم تفعيل المخطط في PowerPoint، يُحمَّل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ar/python-java/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Python via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بحسب الفهرس.
1. قراءة ملف Excel كمصفوفة بايت.
1. إضافة الـ [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى حول كائن OLE.
1. كتابة العرض المعدَّل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Python via Java.  
**ملاحظة** أن مُنشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للتضمين كمعامله الثاني. هذا الامتداد يسمح لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # تحضير البيانات لكائن OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # إضافة إطار كائن OLE إلى الشريحة.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إضافة إطارات OLE مرتبطة**

Aspose.Slides for Python via Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) مع رابط إلى الملف بدلاً من البيانات المضمَّنة.

هذا الكود بلغة Python يوضح كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مُضمَّنًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بسهولة بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المضمَّن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/).  
   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم تحققنا من أن الكائن هو [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # احصل على بيانات الملف المضمن.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # احصل على امتداد الملف المضمن.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطارات OLE المرتبطة.

هذا الكود بلغة Python يوضح كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # التحقق مما إذا كان كائن OLE مرتبطًا.
        if ole_frame.isObjectLink():
            # طباعة المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
            # يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="ملاحظة" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

إذا كان كائن OLE مُضمَّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المضمَّن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. الوصول إلى شكل إطار كائن OLE.  
   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم تحققنا من أن الكائن هو [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) والوصول إلى بيانات OLE.
6. الوصول إلى الـ [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) المطلوب وتعديل البيانات.
7. حفظ الـ [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # قراءة بيانات كائن OLE ككائن Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # تعديل بيانات الـ Workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # تغيير بيانات كائن إطار OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تضمين أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، Aspose.Slides for Python via Java يتيح لك تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML، PDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج ملائم لفتحه.

هذا الكود بلغة Python يوضح كيفية تضمين HTML وZIP في شريحة:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديد نوع الملف للكائنات المضمَّنة**

عند العمل على العروض، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for Python via Java يتيح لك تعيين نوع الملف لكائن مضمَّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

هذا الكود بلغة Python يوضح كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # غيّر نوع الملف إلى ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين صور الأيقونات والعناوين للكائنات المضمَّنة**

بعد تضمين كائن OLE، تُضاف معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Python via Java.

هذا الكود بلغة Python يوضح كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # إضافة صورة إلى موارد العرض.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # تعيين عنوان وصورة للمعاينة OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **منع تغيير حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، عندما تفتح العرض في PowerPoint قد ترى رسالة تطلب منك تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويُحدّث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط طريقة [setUpdateAutomatic](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) للفئة [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) إلى `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج الملفات المضمَّنة**

Aspose.Slides for Python via Java يتيح لك استخراج الملفات المُضمَّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. التكرار عبر جميع الأشكال في العرض والوصول إلى أشكال [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/).
3. الوصول إلى بيانات الملفات المضمَّنة من إطارات OLE وكتابتها إلى القرص.

هذا الكود بلغة Python يوضح كيفية استخراج الملفات المضمَّنة في شريحة ككائنات OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل سيُعرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يُعرض على الشريحة هو المعاينة (الأيقونة/الصورة البديلة). محتوى OLE "الحي" لا يُنفّذ أثناء عملية العرض. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان الشكل المتوقع في PDF المُصدّر.

**كيف يمكن قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر [قفل على مستوى الشكل](/slides/ar/python-java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والتحريك.

**لماذا "يقفز" أو يتغيّر حجم كائن Excel المرتبط عندما أفتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحفاظ على مظهر ثابت، اتبع ممارسات [الحل العملي لإعادة تحجيم ورقة العمل](/slides/ar/python-java/working-solution-for-worksheet-resizing/) — إما ضبط الإطار ليتناسب مع النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل ستتم المحافظة على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. المسارات النسبية موجودة في تنسيق PPT القديم. للملاءمة، يُفضَّل استخدام مسارات مطلقة موثوقة/URIs قابلة للوصول أو التضمين.